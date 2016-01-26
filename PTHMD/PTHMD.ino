// PERMISSIVE HYPERTENSION MONITORING DEVICE (PHTMD) Embedded Controller Main
// Mitch Baldwin	RMBIMedical	for U of M CIRCC	24 Apr 2015
// v 1.0
// Base timer code from: Arduino timer CTC interrupt example (www.engblaze.com)

// avr-libc library includes
#include <PacketSerial.h>
#include <avr/io.h>
#include <avr/interrupt.h>

// Solenoid latch pulse width, ms/2:
#define PULSE_WIDTH 50

// LED ON/OFF time (count, ms/2):
#define LED_TIME 64

// Sample count divisor for pressure sensor measurements relative to PPG sensor measurements:
#define PRES_PER_PPG 10

#define PPG1_PIN 0					// PPG sensor 1 (purple wire) analog signal pin A0
#define CP_PIN 1					// Cuff pressure analog signal pin A1

#define FADE_PIN 5					// PWM pin to do fancy classy fading blink at each beat
#define PUMP_PIN 6					// PWM control of the pump
#define S1_PIN 2					// Solenoid valve 1 control pin
#define S2_PIN 3					// Solenoid valve 2 control pin

#define LS1_ON_PIN 7				// LS1 ON signal pin to SN754410 1A (pin 2)
#define LS1_OFF_PIN 8				// LS1 OFF signal pin to SN754410 2A (pin 3)
#define LS2_ON_PIN 9				// LS2 ON signal pin to SN754410 2A (pin 7)
#define LS2_OFF_PIN 10				// LS2 OFF signal pin to SN754410 1A (pin 6)

#define LEDPIN 13					// pin to blink led at each beat

#define startbyte 0xF0
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
volatile int ls1ONPulseCounter = 0;
volatile int ls1OFFPulseCounter = 0;
volatile int ls2ONPulseCounter = 0;
volatile int ls2OFFPulseCounter = 0;

// The following state flag indicates whether to schedule a read of the PPG 
// sensors (even cycles) or the pressure sensors (odd cycles)
//volatile byte readSensors0 = 0x00;

// The following are used in  the main loop as well aa in the interrupt service routine
volatile int BPM;                   // calculated pulse rate, beats per minute
volatile int Signal;                // holds the incoming raw PPG ADC signal
volatile int CP;					// holds the incoming raw Cuff Pressure ADC signal
volatile int IBI = 600;             // int that holds the time interval between beats; must be seeded 
volatile boolean newSensorData;		// flag set in ISR indicating new sensor data is available
volatile boolean Pulse = false;     // becomes true when a live heartbeat is detected. "False" when not a "live beat"
volatile boolean QS = false;        // becomes true when the analysis algorithm in the ISR finds a beat

//  Variables
int fadeRate = 0;					// used to fade LED on with PWM on fadePin
int pumpSpeed = 0;					// PWM setting for cuff pump
uint8_t CuffPID = 127;				// Output setting from Cuff PID controller
int targetCP = 0;					// Target cuff pressure - raw ACD equivalent value

int loopHalfPeriod = 250;			// Main loop period / 2 (ms) - can be set by Host

PacketSerial spUSB;
bool newCommandMsgReceived = false;	// Flag indicating a new commang message was received over the spUSB port
uint8_t commandMsgReceived = 0x00;	// Initialize the type of command received

boolean dataFeedActive = false;		// flag to turn data feed to host on or off

// Regards Serial OutPut  -- Set This Up to your needs
static boolean serialVisual = false;   // Set to 'false' by Default.  Re-set to 'true' to see Arduino Serial Monitor ASCII Visual Pulse 

void setup()
{
	int i;

	pinMode(FADE_PIN, OUTPUT);
	pinMode(PUMP_PIN, OUTPUT);
	pinMode(S1_PIN, OUTPUT);
	pinMode(S2_PIN, OUTPUT);

	pinMode(LS1_ON_PIN, OUTPUT);
	pinMode(LS1_OFF_PIN, OUTPUT);
	pinMode(LS2_ON_PIN, OUTPUT);
	pinMode(LS2_OFF_PIN, OUTPUT);
	
	pinMode(LEDPIN, OUTPUT);

	// Initialize output pins:
	pumpSpeed = 0xFF;						// Turn pump off
	analogWrite(PUMP_PIN, pumpSpeed);
	digitalWrite(S1_PIN, 0);
	digitalWrite(S2_PIN, 0);

	digitalWrite(LS1_ON_PIN, 0);
	digitalWrite(LS1_OFF_PIN, 0);
	digitalWrite(LS2_ON_PIN, 0);
	digitalWrite(LS2_OFF_PIN, 0);

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

	//timer1InterruptSetup();
	timer2InterruptSetup();
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
		// Indicate checksum error to host and and other appropriate clients
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
		
		// BPM and IBI have been determined - send pulse data to host
		//serialOutputWhenBeatHappens();  // A Beat Happened, Output that to serial.     
		
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
		//commandMsgReceived = inBuffer[0x00];
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
					outPacket[0x01] = lowByte(Signal);		// low byte of PPG sensor measurement
					outPacket[0x02] = highByte(Signal);		// high byte of PPG sensor measurement
					outPacket[0x03] = lowByte(CP);			// low byte of cuff pressure sensor measurement
					outPacket[0x04] = highByte(CP);			// high byte of cuff pressure sensor measurement
					outPacket[0x05] = CuffPID;				// Output setting from Cuff PID controller
					outPacket[0x06] = lowByte(BPM);			// calculated pulse rate, beats per minute
					outPacket[0x07] = highByte(BPM);
					outPacket[0x08] = lowByte(IBI);			// time interval between beats
					outPacket[0x09] = highByte(IBI);

					for (i = 0x0A; i < PACKET_SIZE - 1; ++i)
					{
						outPacket[i] = 0x00;
					}

					SendUSBPacket();

					ToggleUserLED();
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

		case 0x02:		// Start serial data feed to host
			// Set flag indicating whether or not to send data to the Host
			dataFeedActive = true;
			break;

		case 0x03:		// Stop serial data feed to host
			// Set flag indicating whether or not to send data to the Host
			dataFeedActive = false;
			
			// If we're turning off the data feed then clear the serial transmission buffer
			//to help ensure frame synchronization when transmission is restarted
			//Serial.flush();		// Wait for the hardware serial transmission buffer to clear
			
			break;

		case 0x04:		// Latch LS1 ON
			digitalWrite(S1_PIN, 1);
			//LS1ON();
			break;

		case 0x05:		// Latch LS1 OFF
			digitalWrite(S1_PIN, 0);
			//LS1OFF();
			break;

		case 0x06:		// Latch LS2 ON
			digitalWrite(S2_PIN, 1);
			//LS2ON();
			break;

		case 0x07:		// Latch LS2 OFF
			digitalWrite(S2_PIN, 0);
			//LS2OFF();
			break;

		case 0x08:	// SetLoopPeriodMsgType
			// Change main loop period to value (in ms) commanded by Host
			loopPeriod = inPacket[0x02] * 0xFF + inPacket[0x01];
			loopHalfPeriod = loopPeriod / 2;
			break;

		case 0x10:	// FillCuffMsgType
			digitalWrite(S1_PIN, 1);				// Connect LS1 to pump
			digitalWrite(S2_PIN, 1);				// Connect cuff to LS1
			pumpSpeed = inPacket[0x01];				// Set initial pump speed
			analogWrite(PUMP_PIN, pumpSpeed);

			// Read and set target cuff pressure:
			targetCP = inPacket[0x03] * 0xFF + inPacket[0x02];

			// Set state:
			State = Fill;

			break;

		case 0x11:	// HoldCuffMsgType
			digitalWrite(S1_PIN, 1);				// Connect LS1 to pump
			digitalWrite(S2_PIN, 1);				// Connect cuff to LS1
			pumpSpeed = 0xFF;						// Turn pump off
			analogWrite(PUMP_PIN, pumpSpeed);

			// Set state:
			State = Hold;
			break;

		case 0x12:	// BleedCuffMsgTypee
			digitalWrite(S1_PIN, 1);				// Connect LS1 to pump
			digitalWrite(S2_PIN, 0);				// Connect cuff to bleed port
			pumpSpeed = 0xFF;						// Turn pump off
			analogWrite(PUMP_PIN, pumpSpeed);

			// Read and set target cuff pressure:
			targetCP = inPacket[0x02] * 0xFF + inPacket[0x01];

			// Set state:
			State = Bleed;
			break;

		case 0x13:	// VentCuffMsgTypee
			digitalWrite(S1_PIN, 0);				// Connect LS1 to atmosphere
			digitalWrite(S2_PIN, 1);				// Connect cuff to LS1
			pumpSpeed = 0xFF;						// Turn pump off
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
			// If cuff pressure > target cuff pressure then stop pump and set valves for Hold state
			if (CP >= targetCP)
			{
				// Transition to Hold state:
				State = Hold;
				// Switch valves and set pump for Hold state:
				digitalWrite(S1_PIN, 1);				// Connect LS1 to pump
				digitalWrite(S2_PIN, 1);				// Connect cuff to LS1

				pumpSpeed = 0xFF;						// Turn pump off
				analogWrite(PUMP_PIN, pumpSpeed);

			}

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
				digitalWrite(S1_PIN, 1);				// Connect LS1 to pump
				digitalWrite(S2_PIN, 1);				// Connect cuff to LS1

				pumpSpeed = 0xFF;						// Turn pump off
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
	if (newSensorData && dataFeedActive)
	{
		outPacket[0x00] = 0x18;					// SensorDataMsgType
		outPacket[0x01] = lowByte(Signal);		// low byte of PPG sensor measurement
		outPacket[0x02] = highByte(Signal);		// high byte of PPG sensor measurement
		outPacket[0x03] = lowByte(CP);			// low byte of cuff pressure sensor measurement
		outPacket[0x04] = highByte(CP);			// high byte of cuff pressure sensor measurement
		outPacket[0x05] = CuffPID;				// Output setting from Cuff PID controller
		outPacket[0x06] = lowByte(BPM);			// calculated pulse rate, beats per minute

		outPacket[0x07] = highByte(BPM);
		outPacket[0x08] = lowByte(IBI);			// time interval between beats
		outPacket[0x09] = highByte(IBI);

		for (i = 0x0A; i < PACKET_SIZE - 1; ++i)
		{
			outPacket[i] = 0x00;
		}

		SendUSBPacket();
		newSensorData = false;
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
