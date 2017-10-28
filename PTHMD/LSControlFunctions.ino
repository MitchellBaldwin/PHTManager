volatile boolean ls1IsON = false;
volatile boolean ls2IsON = false;
volatile boolean ls3IsON = false;

void LS1ON()
{
	//ls1ONPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect LS1 to pump
	digitalWrite(S1_PIN, 1);				// Set the S1 control pin HIGH to set S1 to ON position
	ls1IsON = true;							// Set flag indicating S1 is ON
}

void LS1OFF()
{
	//ls1OFFPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect LS1 to atmosphere
	digitalWrite(S1_PIN, 0);				// Set the S1 control pin LOW to set S1 to OFF position
	ls1IsON = false;						// Set flag indicating L1 is OFF
}

void LS2ON()
{
	//ls2ONPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect cuff to LS1
	digitalWrite(S2_PIN, 1);				// Set the S2 control pin HIGH to set S2 to ON position
	ls2IsON = true;							// Set flag indicating S2 is ON
}

void LS2OFF()
{
	//ls2OFFPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect cuff to bleed port
	digitalWrite(S2_PIN, 0);				// Set the S2 control pin LOW to set S2 to OFF position
	ls2IsON = false;						// Set flag indicating S2 is OFF
}

void LS3ON()
{
	//ls2ONPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect cuff to LS1
	digitalWrite(S2_PIN, 1);				// Set the S3 control pin HIGH to set S3 to ON position
	ls3IsON = true;							// Set flag indicating S3 is ON
}

void LS3OFF()
{
	//ls2OFFPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect cuff to bleed port
	digitalWrite(S2_PIN, 0);				// Set the S3 control pin LOW to set S3 to OFF position
	ls3IsON = false;						// Set flag indicating S3 is OFF
}
