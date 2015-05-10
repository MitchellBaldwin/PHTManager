/*
RMB - Mobile Robot System Master Communications Controller

Test mode	(0x00)	Measures the position of a potentiometer and report it to back to the PC host
TRex mode	(0x01)	TRex controlled over i2c bus
RC mode		(0x02)	TRex controlled by RC radio

*/

#include <Wire.h>

#define startbyte 0x0F
#define I2Caddress 0x07
//#define I2Caddress 0x02

#define COMM_BUFFER_SIZE 32
#define TREX_COMMAND_BUFFER_SIZE 0x1B
#define TREX_STATUS_BUFFER_SIZE 0x18
#define TEXT_MESSAGE_MAX_SIZE 29

int sensorPin = 0;		// The potentiometer is connected to analog pin A0
int ledPin = 13;		// The LED is connected to digital pin 13

byte mode = 0x00;		// 0x00	Test mode
						// 0x01 TRex mode

char inBuffer[COMM_BUFFER_SIZE];
byte outBuffer[COMM_BUFFER_SIZE];
byte commandBuffer[TREX_COMMAND_BUFFER_SIZE];
byte statusBuffer[TREX_STATUS_BUFFER_SIZE];

String textMessage;		// Initializing textNessage here does not seem to work...

void setup()			// this function runs once when the program starts
{
	int i;

	pinMode(ledPin, OUTPUT);

	for (i = 1; i < COMM_BUFFER_SIZE; ++i)
	{
		inBuffer[i] = 0x00;
		outBuffer[i] = 0x00;
	}

	Serial.begin(115200);
	Wire.begin();
	Wire.setTimeout(10);


}


void loop()				// this function runs repeatedly after setup() finishes
{
	int i, sensorValue;
	byte checkSum, msgType;
	unsigned int msgLength;
	bool newMsgReceived;

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

		switch (msgType)
		{
			case 0x00:
				// Text message message type
				for (i = 0; i < TEXT_MESSAGE_MAX_SIZE; ++i)
				{
					textMessage[i] = (char) inBuffer[i + 2];
				}
				break;

			case 0x01:
				// Set operating mode message type
				mode = inBuffer[0x02];
				if (mode == 0x00)
				{
					WriteTextLn("Entering Test mode");
				}
				else if (mode == 0x01)
				{
					WriteTextLn("Entering i2c mode");
				}
				else if (mode == 0x02)
				{
					WriteTextLn("Entering RC mode");
				}
				break;

			case 0x10:
				// TRex command message type
				for (i = 0; i < TREX_COMMAND_BUFFER_SIZE; ++i)
				{
					commandBuffer[i] = inBuffer[i+2];
				}

				if (mode == 0x00)						// If in Test mode do not use i2c
				{
					char s[TEXT_MESSAGE_MAX_SIZE];
					snprintf(s, TEXT_MESSAGE_MAX_SIZE, "CMD: %#x %#x %#x %#x %#x %#x %#x %#x\n", commandBuffer[0x00], commandBuffer[0x01], commandBuffer[0x02], commandBuffer[0x03], commandBuffer[0x04], commandBuffer[0x05], commandBuffer[0x06], commandBuffer[0x07]);	//the slave device
					WriteTextLn(s);
				}
				else if (mode == 0x01)                  // If in i2c mode send command to motor controller
				{
					MasterSend();
				}
				break;

			case 0x11:
				// TRex status request message type
				if (mode == 0x00)								// In in Test mode do not use i2c
				{
					// Build and send simulated TRex status message
					sensorValue = analogRead(sensorPin);

					outBuffer[0x00] = startbyte;				// MRS Start byte
					outBuffer[0x01] = 0x11;						// MRS TRex status message type
					outBuffer[0x02] = startbyte;				// TRex status Start byte - CHECK THIS!!! TRex data sheet has contradictory info
					outBuffer[0x03] = 0x00;						// TRex error flags
					outBuffer[0x04] = highByte(sensorValue);	// TRex Batt V Hi byte - echo pot measurement to test
					outBuffer[0x05] = lowByte(sensorValue);		// TRex Batt V Lo byte - echo pot measurement to test
					outBuffer[0x06] = inBuffer[0x04];			// TRex L Mot I Hi byte - echo L Mot setting to test
					outBuffer[0x07] = inBuffer[0x05];			// TRex L Mot I Lo byte - echo L Mot setting to test
					outBuffer[0x08] = 0x00;						// TRex L Enc Hi byte
					outBuffer[0x09] = 0x00;						// TRex L Enc Lo byte
					outBuffer[0x0A] = inBuffer[0x07];			// TRex R Mot I Hi byte - echo R Mot setting to test
					outBuffer[0x0B] = inBuffer[0x08];			// TRex R Mot I Lo byte - echo R Mot setting to test
					outBuffer[0x0C] = 0x00;						// TRex R Enc Hi byte
					outBuffer[0x0D] = 0x00;						// TRex R Enc Lo byte
					outBuffer[0x0E] = 0x00;			            // TRex Accel X Hi byte - test value
					outBuffer[0x0F] = 0x64;			            // TRex Accel X Lo byte 
					for (i = 0x10; i < COMM_BUFFER_SIZE - 1; ++i)
					{
						outBuffer[i] = 0x00;
					}
				
					checkSum = 0;
					for (i = 0; i < COMM_BUFFER_SIZE - 2; ++i)
					{
						checkSum += outBuffer[i];
					}
					outBuffer[COMM_BUFFER_SIZE - 1] = checkSum;

					Serial.write(outBuffer, COMM_BUFFER_SIZE);
				}
				else
				{
					MasterReceive();
					outBuffer[0x00] = startbyte;					// MRS Start byte
					outBuffer[0x01] = 0x11;							// MRS TRex status message type
					for (i = 0; i < TREX_STATUS_BUFFER_SIZE; ++i)
					{
						outBuffer[i + 2] = statusBuffer[i];
					}
					for (i = TREX_STATUS_BUFFER_SIZE; i < COMM_BUFFER_SIZE - 1; ++i)
					{
						outBuffer[i] = 0x00;
					}
					checkSum = 0;
					for (i = 0; i < COMM_BUFFER_SIZE - 2; ++i)
					{
						checkSum += outBuffer[i];
					}
					outBuffer[COMM_BUFFER_SIZE - 1] = checkSum;
					Serial.write(outBuffer, COMM_BUFFER_SIZE);
				}
				break;

			default:
				WriteText("Invalid message type");                  // Message type not recognized
				break;

		}
	}

	if (mode == 0x00)	// If in Test mode
	{

	}	// End of Test mode

	//// Show first half heartbeat
	//digitalWrite(ledPin, HIGH);     // Turn the LED on
	//delay(500);						// Pause for 500 ms

	////// Send a test text message
	////textMessage = "this is a text message\n";
	////SendTextMessage();

	//// Show second half heartbeat
	//digitalWrite(ledPin, LOW);      // Turn the LED off
	//delay(500);						// Pause for 500 ms

}

