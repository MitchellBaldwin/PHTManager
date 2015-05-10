// Arduino timer CTC interrupt example
// www.engblaze.com

// avr-libc library includes
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
#define LS1_ON_PIN 7				// LS1 ON signal pin to SN754410 1A (pin 2)
#define LS1_OFF_PIN 8				// LS1 OFF signal pin to SN754410 2A (pin 3)
#define LS2_ON_PIN 9				// LS2 ON signal pin to SN754410 2A (pin 7)
#define LS2_OFF_PIN 10				// LS2 OFF signal pin to SN754410 1A (pin 6)

#define LEDPIN 13					// pin to blink led at each beat

#define startbyte 0xF0
#define COMM_BUFFER_SIZE 32

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

boolean dataFeedActive = true;		// flag to turn data feed to host on or off

// Regards Serial OutPut  -- Set This Up to your needs
static boolean serialVisual = false;   // Set to 'false' by Default.  Re-set to 'true' to see Arduino Serial Monitor ASCII Visual Pulse 

void setup()
{
	int i;

	pinMode(FADE_PIN, OUTPUT);
	pinMode(PUMP_PIN, OUTPUT);
	pinMode(LS1_ON_PIN, OUTPUT);
	pinMode(LS1_OFF_PIN, OUTPUT);
	pinMode(LS2_ON_PIN, OUTPUT);
	pinMode(LS2_OFF_PIN, OUTPUT);
	
	pinMode(LEDPIN, OUTPUT);

	digitalWrite(LS1_ON_PIN, 0);
	digitalWrite(LS1_OFF_PIN, 0);

	for (i = 1; i < COMM_BUFFER_SIZE; ++i)
	{
		inBuffer[i] = 0x00;
		outBuffer[i] = 0x00;
	}

	Serial.begin(115200);
	Serial.flush();
	
	//timer1InterruptSetup();
	timer2InterruptSetup();
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
	byte checkSum, msgType;
	unsigned int msgLength;
	bool newMsgReceived;
	int loopPeriod;

	if (Serial.available() >= COMM_BUFFER_SIZE)
	{
		Serial.readBytes(inBuffer, COMM_BUFFER_SIZE);

		// Check integrity of message received
		checkSum = 0x00;
		for (i = 0; i < COMM_BUFFER_SIZE - 1; ++i)
		{
			checkSum += inBuffer[i];
		}
		if (checkSum == inBuffer[COMM_BUFFER_SIZE - 1] && inBuffer[0x00] == startbyte)
		{
			newMsgReceived = true;
		}
		else
		{
			// Attempt to recover from a framing error
			while (Serial.available() > 0)
			{
				if (Serial.peek() != startbyte)
				{
					Serial.read();      // Purge serial port buffer until at the start of a new frame
				}
			}
			newMsgReceived = false;
		}
	}
	else
	{
		newMsgReceived = false;
	}

	if (newMsgReceived)
	{
		// Check message type; if it directs a mode change then set new mode and proceed accordingly
		msgType = inBuffer[0x01];
		newMsgReceived = false;

		switch (msgType)
		{
		case 0x00:	// Text message message type
			

			break;

		case 0x01:	// Set operating mode message type
			
			mode = inBuffer[0x02];
			if (mode == 0x00)		// Change to Test mode
			{
				ledON = loopHalfPeriod;
				digitalWrite(LEDPIN, 1);
				//WriteTextLn("Entering Test mode");
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

		case 0x02:
			// Toggle flag indicating whether or not to send data to the Host
			dataFeedActive = !dataFeedActive;
			break;

		case 0x08:	// SetLoopPeriodMsgType
			// Change main loop period to value (in ms) commanded by Host
			loopPeriod = inBuffer[0x03] * 0xFF + inBuffer[0x02];
			loopHalfPeriod = loopPeriod / 2;
			break;

		case 0x10:	// FillCuffMsgType
			ls1ONPulseCounter = PULSE_WIDTH;		// Initiate pulse to set cuff fill solenoid on
			digitalWrite(LS1_ON_PIN, 1);			// Set the LS1 ON control pin high to latch LS1 to ON position
			ls2ONPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect cuff to LS1
			digitalWrite(LS2_ON_PIN, 1);			// Set the LS2 ON control pin high to latch LS2 to ON position

			pumpSpeed = inBuffer[0x02];				// Set initial pump speed
			analogWrite(PUMP_PIN, pumpSpeed);

			// Read and set target cuff pressure:
			targetCP = inBuffer[0x04] * 0xFF + inBuffer[0x03];

			// Set state:
			State = Fill;

			break;

		case 0x11:	// HoldCuffMsgTypee
			ls1ONPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect LS2 to pump
			digitalWrite(LS1_ON_PIN, 1);			// Set the LS1 ON control pin high to latch LS1 to ON position
			ls2ONPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect cuff to LS1
			digitalWrite(LS2_ON_PIN, 1);			// Set the LS2 ON control pin high to latch LS2 to ON position
			
			pumpSpeed = 0xFF;						// Turn pump off
			analogWrite(PUMP_PIN, pumpSpeed);

			// Set state:
			State = Hold;
			break;

		case 0x12:	// BleedCuffMsgTypee
			ls1ONPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect LS2 to pump
			digitalWrite(LS1_ON_PIN, 1);			// Set the LS1 ON control pin high to latch LS1 to ON position
			ls2OFFPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect cuff to bleed port
			digitalWrite(LS2_OFF_PIN, 1);			// Set the LS2 OFF control pin high to latch LS2 to OFF position
			
			pumpSpeed = 0xFF;						// Turn pump off
			analogWrite(PUMP_PIN, pumpSpeed);

			// Read and set target cuff pressure:
			targetCP = inBuffer[0x03] * 0xFF + inBuffer[0x02];

			// Set state:
			State = Bleed;
			break;

		case 0x13:	// VentCuffMsgTypee
			ls1OFFPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect LS2 to atmosphere
			digitalWrite(LS1_OFF_PIN, 1);			// Set the LS1 OFF control pin high to latch LS1 to OFF position
			ls2ONPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect cuff to LS1
			digitalWrite(LS2_ON_PIN, 1);			// Set the LS2 ON control pin high to latch LS2 to ON position
			
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
				ls1ONPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect LS2 to pump
				digitalWrite(LS1_ON_PIN, 1);			// Set the LS1 ON control pin high to latch LS1 to ON position
				ls2ONPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect cuff to LS1
				digitalWrite(LS2_ON_PIN, 1);			// Set the LS2 ON control pin high to latch LS2 to ON position

				pumpSpeed = 0xFF;						// Turn pump off
				analogWrite(PUMP_PIN, pumpSpeed);

			}

			break;

		case Hold:

			break;

		case Bleed:
			// If cuff pressure < target cuff pressure then set valves for Hold state
			if (CP <= targetCP)
			{
				// Transition to Hold state:
				State = Hold;
				// Switch valves and set pump for Hold state:
				ls1ONPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect LS2 to pump
				digitalWrite(LS1_ON_PIN, 1);			// Set the LS1 ON control pin high to latch LS1 to ON position
				ls2ONPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect cuff to LS1
				digitalWrite(LS2_ON_PIN, 1);			// Set the LS2 ON control pin high to latch LS2 to ON position

				pumpSpeed = 0xFF;						// Turn pump off
				analogWrite(PUMP_PIN, pumpSpeed);

			}

			break;

		case Vent:

			break;

		default:

			break;
	}

	// Send sensor data to host
	// DONE: Check that the sensor data is new before sending to host
	if (newSensorData && dataFeedActive)
	{
		outBuffer[0x00] = startbyte;
		outBuffer[0x01] = 0x18;					// SensorDataMsgType
		outBuffer[0x02] = lowByte(Signal);		// low byte of PPG sensor measurement
		outBuffer[0x03] = highByte(Signal);		// high byte of PPG sensor measurement
		outBuffer[0x04] = lowByte(CP);			// low byte of cuff pressure sensor measurement
		outBuffer[0x05] = highByte(CP);			// high byte of cuff pressure sensor measurement
		outBuffer[0x06] = CuffPID;				// Output setting from Cuff PID controller
		outBuffer[0x07] = lowByte(BPM);			// calculated pulse rate, beats per minute

		outBuffer[0x08] = highByte(BPM);
		outBuffer[0x09] = lowByte(IBI);			// time interval between beats
		outBuffer[0x0A] = highByte(IBI);

		for (i = 0x0B; i < COMM_BUFFER_SIZE - 1; ++i)
		{
			outBuffer[i] = 0x00;
		}

		checkSum = 0;
		for (i = 0; i < COMM_BUFFER_SIZE - 2; ++i)
		{
			checkSum += outBuffer[i];
		}
		outBuffer[COMM_BUFFER_SIZE - 1] = checkSum;

		Serial.flush();
		Serial.write(outBuffer, COMM_BUFFER_SIZE);
		newSensorData = false;
	}



	// Uncomment the following line to enable the fader pin
	//ledFadeToBeat();                    // Makes the LED Fade Effect Happen 
	
	delay(10);								//  take a break

}
