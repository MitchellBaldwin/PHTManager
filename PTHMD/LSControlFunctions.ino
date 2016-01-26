volatile boolean ls1IsON = false;
volatile boolean ls2IsON = false;

void LS1ON()
{
	ls1ONPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect LS1 to pump
	digitalWrite(S1_PIN, 1);				// Set the LS1 ON control pin high to latch LS1 to ON position
	ls1IsON = true;							// Set flag indicating LS1 is ON
}

void LS1OFF()
{
	ls1OFFPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect LS1 to atmosphere
	digitalWrite(S1_PIN, 0);				// Set the LS1 OFF control pin high to latch LS1 to OFF position
	ls1IsON = false;						// Set flag indicating LS1 is OFF
}

void LS2ON()
{
	ls2ONPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect cuff to LS1
	digitalWrite(S2_PIN, 1);				// Set the LS2 ON control pin high to latch LS2 to ON position
	ls2IsON = true;							// Set flag indicating LS2 is ON
}

void LS2OFF()
{
	ls2OFFPulseCounter = PULSE_WIDTH;		// Initiate pulse to connect cuff to bleed port
	digitalWrite(S2_PIN, 0);				// Set the LS2 OFF control pin high to latch LS2 to OFF position
	ls2IsON = false;						// Set flag indicating LS2 is OFF
}
