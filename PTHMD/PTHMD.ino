// PERMISSIVE HYPERTENSION MONITORING DEVICE (PHTMD) Embedded Controller Main
// Mitch Baldwin	RMBIMedical	for U of M CIRCC	24 Apr 2015
// v 1.0
// v 1.1	28 Oct 2017	Updated to support 3 solenoid control and finger tip PPG sensor
//
// Base timer code from: Arduino timer CTC interrupt example (www.engblaze.com)

// avr-libc library includes
#include <PID_v1.h>
#include <PacketSerial.h>
#include <avr/io.h>
#include <avr/interrupt.h>

// Solenoid latch pulse width, ms/2:
#define PULSE_WIDTH 50

// LED ON/OFF time (count, ms/2):
#define LED_TIME 64

// Sample count divisor for pressure sensor measurements relative to PPG sensor measurements:
#define PRES_PER_PPG 20
#define CPHISTORY_SIZE 10			// Number of cuff pressure samples to average

#define PPG1_PIN 0					// PPG sensor 1 (purple wire) analog signal pin A0
#define CP_PIN 1					// Cuff pressure analog signal pin A1
#define PPG2_PIN 2					// PPG sensor 2 (purple wire) analog signal pin A2

#define FADE_PIN 5					// PWM pin to do fancy classy fading blink at each beat
#define PUMP_PIN 6					// PWM control of the pump
#define S1_PIN 2					// Solenoid valve 1 control pin - Cuff	(RMBI: Added v1.1)
#define S2_PIN 3					// Solenoid valve 2 control pin - Bleed	(RMBI: Added v1.1)
#define S3_PIN 4					// Solenoid valve 3 control pin - Vent	(RMBI: Added v1.1)

#define LEDPIN 13					// pin to blink led at each beat

//#define startbyte 0xF0
#define COMM_BUFFER_SIZE 32
#define PACKET_SIZE 30

enum States
{
	Fill,
	Hold,
	Bleed,
	Vent
};
States State = Vent;

uint8_t inBuffer[COMM_BUFFER_SIZE];
uint8_t outBuffer[COMM_BUFFER_SIZE];

uint8_t inPacket[PACKET_SIZE];
uint8_t outPacket[PACKET_SIZE];

uint8_t mode = 0x01;				// 0x00	Test mode
									// 0x01 Normal mode
									// Automatic mode

// Counter to set interval of pressure sensor measurements relative to PPG sensor measurements
volatile int pSampleCounter = PRES_PER_PPG;

// The following are counters initialized by commands or state changes in the main loop and decremented in the ISR
volatile int ledON = 0;
volatile int ledOFF = 0;

// The following are used in  the main loop as well aa in the interrupt service routine
volatile int BPM = 0;						// calculated pulse rate, beats per minute
volatile int PPG1;							// holds the incoming raw PPG1 ADC signal
volatile int PPG2;							// holds the incoming raw PPG2 ADC signal
volatile int CP;							// holds the incoming raw Cuff Pressure ADC signal
volatile int IBI = 600;						// int that holds the time interval between beats; must be seeded 
volatile boolean newSensorData;				// flag set in ISR indicating new sensor data is available
volatile boolean Pulse = false;				// becomes true when a live heartbeat is detected. "False" when not a "live beat"
volatile boolean QS = false;				// becomes true when the analysis algorithm in the ISR finds a beat
volatile unsigned long sampleCounter = 0;	// used to determine pulse timing

//  Variables
int fadeRate = 0;					// used to fade LED on with PWM on fadePin

// Set up pump PID controller:
double dCP;
double dPumpSpeed = 255.0;
double dTargetCP = 0.0;
PID pumpPID(&dCP, &dPumpSpeed, &dTargetCP, 0.5, 0.1, 0.2, DIRECT);

//uint8_t CuffPID = 127;				// Output setting from Cuff PID controller
int pumpSpeed = 0;					// PWM setting for cuff pump
int targetCP = 0;					// Target cuff pressure - raw ACD equivalent value

int loopHalfPeriod = 250;			// Main loop period / 2 (ms) - can be set by Host

PacketSerial spUSB;
bool newCommandMsgReceived = false;	// Flag indicating a new commang message was received over the spUSB port
uint8_t commandMsgReceived = 0x00;	// Initialize the type of command received

boolean dataSaveActive = false;		// Flag indicating whether host is accumulating a data segment to save
boolean calculateHR = false;		// Flag indicating whether ISR should calculate heart rate and IBI
									// (clear to speed ISR execution)

// Regards Serial OutPut  -- Set This Up to your needs
static boolean serialVisual = false;   // Set to 'false' by Default.  Re-set to 'true' to see Arduino Serial Monitor ASCII Visual Pulse 

void setup()
{
	int i;

	pinMode(FADE_PIN, OUTPUT);
	pinMode(PUMP_PIN, OUTPUT);
	pinMode(S1_PIN, OUTPUT);
	pinMode(S2_PIN, OUTPUT);

	pinMode(LEDPIN, OUTPUT);

	// Initialize output pins:
	pumpSpeed = 0;							// Turn pump off
	analogWrite(PUMP_PIN, pumpSpeed);
	dCP = analogRead(CP_PIN);
	dTargetCP = 0.0;
	pumpPID.SetMode(MANUAL);

	digitalWrite(S1_PIN, 0);				// Turn S1 off
	digitalWrite(S2_PIN, 0);				// Turn S2 off
	digitalWrite(S3_PIN, 0);				// Turn S3 off

	for (i = 1; i < COMM_BUFFER_SIZE; ++i)
	{
		inBuffer[i] = 0x00;
		outBuffer[i] = 0x00;
	}

	for (int i = 0; i < PACKET_SIZE; ++i)
	{
		inPacket[i] = 0x00;
		outPacket[i] = 0x00;
	}
	spUSB.setPacketHandler(&OnUSBPacket);
	spUSB.begin(115200);

	//timer1InterruptSetup();						// Using TIMER1 set for T = 1 ms, f = 1000 Hz
	timer2InterruptSetup();						// Using TIMER2 set for T = 2 ms, f = 500 Hz
}

void OnUSBPacket(const uint8_t* buffer, size_t size)
{
	// Calculate and test checksum; if test fails purge buffer, set newCommangMsgReceived flag false, and return
	uint8_t checksum = 0;
	for (int i = 0; i < PACKET_SIZE - 1; ++i)
	{
		checksum += buffer[i];
	}
	if (checksum != buffer[PACKET_SIZE - 1])
	{
		// Indicate checksum error to host and other appropriate clients
		// e.g., text message back to host, LED indicating error status, etc.
		//char s[TEXT_MESSAGE_MAX_SIZE];
		//snprintf(s, TEXT_MESSAGE_MAX_SIZE, "MRS-MCC checksum %#x != %#x", checksum, buffer[PACKET_SIZE - 1]);
		//WriteTextLn(s);
		//ToggleUserLED();
		return;
	}

	// Transfer incomming buffer contents (including message type and checksum)	to inPacket
	for (int i = 0; i < PACKET_SIZE; ++i)
	{
		inPacket[i] = buffer[i];
	}

	// Determine message type
	commandMsgReceived = buffer[0];

	// Set new message received flag
	newCommandMsgReceived = true;

	// Test code:
	if (buffer[0] == 0x01)				// Test case
	{
		//ToggleUserLED();
		//outPacket[0] = buffer[0] + 1;
		//outPacket[1] = buffer[1] + 1;
		//outPacket[2] = buffer[2] + 1;
		//outPacket[3] = buffer[3] + 1;
		//SendUSBPacket();
	}
}

void SendUSBPacket()
{
	int checksum = 0;
	for (int i = 0; i < PACKET_SIZE - 1; ++i)
	{
		checksum += outPacket[i];
	}
	outPacket[PACKET_SIZE - 1] = checksum;
	spUSB.send(outPacket, PACKET_SIZE);
}

void loop()
{
	//*************************** TEST CODE START ****************************************************************************

	// Commands set cuff fill and vent pulse times here; also initiate the pulse
	// Pulse time remaining is updated in the TIMER2 COMPA ISR and the the corresponding pulse
	// is reset upon timeout
	if (mode == 0x00)
	{
		//ledON = loopHalfPeriod / 2;
		//digitalWrite(LEDPIN, 1);
		//ls1ONPulseCounter = PULSE_WIDTH;		// Initiate pulse to set cuff fill solenoid on
		//digitalWrite(LS1_ON_PIN, 1);			// Set the LS1 ON control pin high to latch LS1 to ON position
		////delay(loopHalfPeriod);
		//// LED is reset in ISR
		////digitalWrite(LEDPIN, 0);
		//if (!digitalRead(LEDPIN))
		//{
		//	ledOFF = loopHalfPeriod / 2;
		//	ls1OFFPulseCounter = PULSE_WIDTH;	// Initiate pulse to set cuff fill solenoid off
		//	digitalWrite(LS1_OFF_PIN, 1);		// Set the LS1 OFF control pin high to latch LS1 to OFF position
		//}
		////delay(loopHalfPeriod);

		//// TEST: Control pump based on voltage measured at A2 connected to a potentiometer
		//pumpSpeed = analogRead(A2);
		//pumpSpeed = map(pumpSpeed, 0, 1023, 0, 255);
		//analogWrite(PUMP_PIN, pumpSpeed);
	}
	
	//*************************** TEST CODE END ******************************************************************************

	if (QS == true){     // Quantified Self, QS, is set true when the signal analysis algorithm (in the ISR) finds a heartbeat
		
		if (mode != 0x00)
		{
			digitalWrite(LEDPIN, HIGH); // Blink LED to indicate a beat was identified 
		}
		// Set 'fadeRate' Variable to 255 to fade LED with pulse
		fadeRate = 255;					// Makes the LED Fade Effect Happen
		
		QS = false;                     // reset the Quantified Self flag for next time    
	}
	else {

		if (mode != 0x00)
		{
			digitalWrite(LEDPIN, LOW);  // There is not beat, turn off pin 13 LED
		}
	}

	// Check for incoming commands from host
	int i = 0;
	byte checkSum;
	unsigned int msgLength;
	int loopPeriod;

	if (newCommandMsgReceived)
	{
		// Check message type; if it directs a mode change then set new mode and proceed accordingly
		newCommandMsgReceived = false;

		// Commanded State settings should be made in this command parsing switch structure
		// State changes should be executed in the state machine switch structure that follows
		switch (commandMsgReceived)
		{
		case 0x00:	// Text message message type
			

			break;

		case 0x01:	// Set operating mode message type
			
			mode = inPacket[0x01];
			if (mode == 0x00)		// Change to Test mode
			{
				//ledON = loopHalfPeriod;
				//digitalWrite(LEDPIN, 1);
				//WriteTextLn("Entering Test mode");
				
					// TEST - Send a data packet to test serial communications response:
					outPacket[0x00] = 0x18;					// SensorDataMsgType
					outPacket[0x01] = lowByte(PPG1);		// low byte of PPG1 sensor measurement
					outPacket[0x02] = highByte(PPG1);		// high byte of PPG1 sensor measurement
					outPacket[0x03] = lowByte(CP);			// low byte of cuff pressure sensor measurement
					outPacket[0x04] = highByte(CP);			// high byte of cuff pressure sensor measurement
					outPacket[0x05] = pumpSpeed;			// Output setting from Cuff PID controller
					outPacket[0x06] = lowByte(BPM);			// calculated pulse rate, beats per minute
					outPacket[0x07] = highByte(BPM);
					outPacket[0x08] = lowByte(IBI);			// time interval between beats
					outPacket[0x09] = highByte(IBI);
					outPacket[0x0A] = lowByte(PPG2);		// low byte of PPG2 sensor measurement
					outPacket[0x0B] = highByte(PPG2);		// high byte of PPG2 sensor measurement

					// Break data timer (ms) into constituant bytes:
					outPacket[0x0F] = sampleCounter / 16777216L;
					outPacket[0x0E] = (sampleCounter - outPacket[0x0F] * 16777216L) / 65536L;
					outPacket[0x0D] = (sampleCounter - outPacket[0x0E] * 65536L) / 256;
					outPacket[0x0C] = sampleCounter - outPacket[0x0D] * 256;

					for (i = 0x10; i < PACKET_SIZE - 1; ++i)
					{
						outPacket[i] = 0x00;
					}

					SendUSBPacket();

					//ToggleUserLED();
					// END TEST - Send a data packet to test serial communications response:

			}
			else if (mode == 0x01)	// Change to Normal mode
			{
				ledON = 0;
				ledOFF = 0;
				digitalWrite(LEDPIN, 0);
				//WriteTextLn("Entering normal mode");
			}
			else if (mode == 0x02)  // Change to Auto mode
			{
				//WriteTextLn("Entering xxx mode");
			}
			break;

		case 0x02:		// Host program is starting a save data segment, so clear the sample counter
			sampleCounter = 0;
			dataSaveActive = true;
			break;

		case 0x03:		// Stop serial data feed to host
			// Clear the flag
			dataSaveActive = false;
			
			break;

		case 0x04:		// Latch LS1 ON
			LS1ON();
			break;

		case 0x05:		// Latch LS1 OFF
			LS1OFF();
			break;

		case 0x06:		// Latch LS2 ON
			LS2ON();
			break;

		case 0x07:		// Latch LS2 OFF
			LS2OFF();
			break;

		case 0x08:		// Latch LS3 ON
			LS3ON();
			break;

		case 0x09:		// Latch LS3 OFF
			LS3OFF();
			break;

		case 0x0E:	// SetLoopPeriodMsgType
			// Change main loop period to value (in ms) commanded by Host
			loopPeriod = inPacket[0x02] * 0xFF + inPacket[0x01];
			loopHalfPeriod = loopPeriod / 2;
			break;

		case 0x0F:	// ToggleHRCalculation
			if (calculateHR)
			{
				calculateHR = false;
				BPM = 0;
				IBI = 30000;
			}
			else
			{
				calculateHR = true;
			}
			break;

		case 0x10:	// FillCuffMsgType
			LS1ON();								// Connect cuff to manifold
			LS2OFF();								// Close bleed valve
			LS3OFF();								// Close vent valve
			//pumpSpeed = inPacket[0x01];			// Read commanded initial pump speed
			//analogWrite(PUMP_PIN, pumpSpeed);		// Set initial pump speed

			// Read and set target cuff pressure:
			targetCP = inPacket[0x03] * 0xFF + inPacket[0x02];
			dTargetCP = targetCP;
			pumpPID.SetMode(AUTOMATIC);

			// Set state:
			State = Fill;

			break;

		case 0x11:	// HoldCuffMsgType
			LS1ON();								// Connect cuff to manifold
			LS2OFF();								// Close bleed valve
			LS3OFF();								// Close vent valve
			pumpPID.SetMode(MANUAL);				// Stop the pump PID controller
			pumpSpeed = 0;							// Turn pump off
			analogWrite(PUMP_PIN, pumpSpeed);

			// Set state:
			State = Hold;
			break;

		case 0x12:	// BleedCuffMsgTypee
			LS1ON();								// Connect cuff to manifold
			LS2ON();								// Open bleed valve
			LS3OFF();								// Close vent valve
			pumpPID.SetMode(MANUAL);				// Stop the pump PID controller
			pumpSpeed = 0;							// Turn pump off
			analogWrite(PUMP_PIN, pumpSpeed);

			// Read and set target cuff pressure:
			targetCP = inPacket[0x03] * 0xFF + inPacket[0x02];
			dTargetCP = targetCP;

			// Set state:
			State = Bleed;
			break;

		case 0x13:	// VentCuffMsgTypee
			LS1ON();								// Connect cuff to manifold
			LS2OFF();								// Close bleed valve
			LS3ON();								// Open vent valve
			pumpPID.SetMode(MANUAL);				// Stop the pump PID controller
			pumpSpeed = 0;							// Turn pump off
			analogWrite(PUMP_PIN, pumpSpeed);

			// Set state:
			State = Vent;
			break;

		default:
			//WriteText("Invalid message type");                  // Message type not recognized
			break;

		}
	}

	// Execute cuff pressure control state machine:
	switch (State)
	{
		case Fill:
			
			// Execute the pump PID controller
			dCP = CP;
			pumpPID.Compute();
			pumpSpeed = dPumpSpeed;
			analogWrite(PUMP_PIN, pumpSpeed);

			//// If cuff pressure > target cuff pressure then stop pump and set valves for Hold state
			//if (CP >= targetCP)
			//{
			//	// Transition to Hold state:
			//	State = Hold;
			//	// Switch valves and set pump for Hold state:
			//	LS1ON();								// Connect LS1 to pump
			//	LS2ON();								// Connect cuff to LS1

			//	pumpPID.SetMode(MANUAL);				// Stop the pump PID controller
			//	pumpSpeed = 0;							// Turn pump off
			//	analogWrite(PUMP_PIN, pumpSpeed);

			//}

			break;

		case Hold:
			// No action needed - state set in command case or other state transition cases
			// Transition from Hold state must be initiated by host command or other logic

			break;

		case Bleed:
			// If cuff pressure < target cuff pressure then set valves for Hold state
			if (CP <= targetCP)
			{
				// Transition to Hold state:
				State = Hold;
				// Switch valves and set pump for Hold state:
				LS1ON();								// Connect cuff to manifold
				LS2OFF();								// Close bleed valve
				LS3OFF();								// Close vent valve

				pumpPID.SetMode(MANUAL);				// Stop the pump PID controller
				pumpSpeed = 0;							// Turn pump off
				analogWrite(PUMP_PIN, pumpSpeed);

			}

			break;

		case Vent:
			// No action needed - state set in command case or other state transition cases
			// Transition from Vent state must be initiated by host command or other logic

			break;

		default:

			break;
	}

	// Send sensor data to host
	// DONE: Check that the sensor data is new before sending to host
	if (newSensorData)
	{
		SendUSBPacket();
		newSensorData = false;	// Reset flag
	}

	// Uncomment the following line to enable the fader pin
	//ledFadeToBeat();						  // Makes the LED Fade Effect Happen 
	
	spUSB.update();							// Let PacketSerial do its thing

	// TODO: Ensure this delay is not pacing the transmission of data to the host:
	delay(10);								//  take a break

}

void ToggleUserLED()						// Helper function to toggle user LED (PIN 13)
{
	if (digitalRead(LEDPIN) == HIGH)
	{
		digitalWrite(LEDPIN, LOW);
	}
	else
	{
		digitalWrite(LEDPIN, HIGH);
	}
}
