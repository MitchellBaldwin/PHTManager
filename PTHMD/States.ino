void SetFillState()
{
	LS1ON();								// Connect pump to manifold
	LS2OFF();								// Close bleed valve
	LS3OFF();								// Close vent valve

	// Set target cuff pressure:
	dTargetCP = targetCP;					// Set the double instance of target pressure for the PID controller
	pumpPID.SetMode(AUTOMATIC);				// Start the pump PID controller

	// Set state:
	State = Fill;
}

void SetHoldState()
{
	LS1OFF();								// Disconnect pump from manifold
	LS2OFF();								// Close bleed valve
	LS3OFF();								// Close vent valve
	
	pumpPID.SetMode(MANUAL);				// Stop the pump PID controller
	pumpSpeed = 0;							// Turn pump off
	analogWrite(PUMP_PIN, pumpSpeed);

	// Set state:
	State = Hold;
}

void SetBleedState()
{
	LS1OFF();								// Disconnect pump from manifold
	LS2ON();								// Open bleed valve
	LS3OFF();								// Close vent valve

	dTargetCP = targetCP;					// Set the double instance of target pressure for the PID controller
	pumpPID.SetMode(MANUAL);				// Stop the pump PID controller
	pumpSpeed = 0;							// Turn pump off
	analogWrite(PUMP_PIN, pumpSpeed);

	// Set state:
	State = Bleed;
}

void SetVentState()
{
	LS1OFF();								// Disconnect pump from manifold
	LS2OFF();								// Close bleed valve
	LS3ON();								// Open vent valve

	pumpPID.SetMode(MANUAL);				// Stop the pump PID controller
	pumpSpeed = 0;							// Turn pump off
	analogWrite(PUMP_PIN, pumpSpeed);

	// Set state:
	State = Vent;
}