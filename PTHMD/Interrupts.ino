// PERMISSIVE HYPERTENSION MONITORING DEVICE (PHTMD) Embedded Controller Interrupt Service Routines
// Mitch Baldwin	RMBIMedical	for U of M CIRCC	24 Apr 2015
// v 1.0

// Variables used in the ISR to parse the PPG signal
volatile int rate[10];                    // array to hold last ten IBI values
volatile unsigned long sampleCounter = 0; // used to determine pulse timing
volatile unsigned long lastBeatTime = 0;  // used to find IBI
volatile int P = 512;                     // used to find peak in pulse wave, seeded
volatile int T = 512;                     // used to find trough in pulse wave, seeded
volatile int thresh = 525;                // used to find instant moment of heart beat, seeded
volatile int amp = 100;                   // used to hold amplitude of pulse waveform, seeded
volatile boolean firstBeat = true;        // used to seed rate array so we startup with reasonable BPM
volatile boolean secondBeat = false;      // used to seed rate array so we startup with reasonable BPM


void timer1InterruptSetup()
{
	// Initialize Timer1 to interrupt every 1 ms
	cli();          // disable global interrupts
	TCCR1A = 0;     // set entire TCCR1A register to 0
	TCCR1B = 0;     // same for TCCR1B

	// Configure TIMER1 to trigger an interrupt at 1000 Hz
	// set compare match register to desired timer count:
	//OCR1A = 15624;
	OCR1A = 32;
	// turn on CTC mode:
	TCCR1B |= (1 << WGM12);
	// Set CS10 and CS12 bits for 1024 prescaler:
	TCCR1B |= (1 << CS10);
	TCCR1B |= (1 << CS12);
	// enable timer compare interrupt:
	TIMSK1 |= (1 << OCIE1A);
	// enable global interrupts:
	sei();
}

void timer2InterruptSetup(){
	// Initializes Timer2 to interrupt every 2 mS
	TCCR2A = 0x02;     // DISABLE PWM ON DIGITAL PINS 3 AND 11, AND GO INTO CTC MODE
	TCCR2B = 0x06;     // DON'T FORCE COMPARE, 256 PRESCALER 
	OCR2A = 0X7C;      // SET THE TOP OF THE COUNT TO 124 FOR 500Hz SAMPLE RATE
	TIMSK2 = 0x02;     // ENABLE INTERRUPT ON MATCH BETWEEN TIMER2 AND OCR2A
	sei();             // MAKE SURE GLOBAL INTERRUPTS ARE ENABLED      
}


// TIMER1 INTERRUPT SERVICE ROUTINE - Test Timer Interrupts
// Assumes Timer1 is initialized to interrupt every ~1 ms (1000 Hz)
ISR(TIMER1_COMPA_vect)
{
	//// Read PPG sensors on even interrupt cycles, or pressure sensors on odd cycles
	//if (readSensors0)
	//{
	//	// Schedule a read of the PPG sensors

	//	// Set flag to read pressure sensors next interrupt
	//	readSensors0 = 0;
	//}
	//else
	//{
	//	// Schedule a read of the pressure sensors

	//	// Set flag to read PPG sensors next interrupt
	//	readSensors0 = 1;
	//}

	// Manage LED timer
	if (ledON > 0)
	{
		ledON--;
		if (ledON <= 0)
		{
			digitalWrite(LEDPIN, 0);
		}
	}

	// Manage latching solenoid pulse timers
	if (ls1ONPulseCounter > 0)
	{
		ls1ONPulseCounter--;
		if (ls1ONPulseCounter <= 0)
		{
			digitalWrite(LS1_ON_PIN, 0);
		}
	}
	if (ls1OFFPulseCounter > 0)
	{
		ls1OFFPulseCounter--;
		if (ls1OFFPulseCounter <= 0)
		{
			digitalWrite(LS1_OFF_PIN, 0);
		}
	}
	if (ls2ONPulseCounter > 0)
	{
		ls2ONPulseCounter--;
		if (ls2ONPulseCounter <= 0)
		{
			digitalWrite(LS2_ON_PIN, 0);
		}
	}
	if (ls2OFFPulseCounter > 0)
	{
		ls2OFFPulseCounter--;
		if (ls2OFFPulseCounter <= 0)
		{
			digitalWrite(LS2_OFF_PIN, 0);
		}
	}
}	// end Timer1 ISR

// TIMER2 INTERRUPT SERVICE ROUTINE - PPG & Pressure Signal Acquisition & Analysis
// Assumes Timer2 is initialized to interrupt every 2 ms (500 Hz)
ISR(TIMER2_COMPA_vect){                         // triggered when Timer2 counts to 0x7C
	cli();                                      // disable interrupts while handling an interrupt
	Signal = analogRead(PPG1_PIN);              // read the Pulse Sensor 
	sampleCounter += 2;                         // keep track of the time in mS with this variable
	int N = sampleCounter - lastBeatTime;       // monitor the time since the last beat to avoid noise

	//  find the peak and trough of the pulse wave
	if (Signal < thresh && N >(IBI / 5) * 3){       // avoid dichrotic noise by waiting 3/5 of last IBI
		if (Signal < T){                        // T is the trough
			T = Signal;                         // keep track of lowest point in pulse wave 
		}
	}

	if (Signal > thresh && Signal > P){          // thresh condition helps avoid noise
		P = Signal;                             // P is the peak
	}                                        // keep track of highest point in pulse wave

	//  NOW IT'S TIME TO LOOK FOR THE HEART BEAT
	// signal surges up in value every time there is a pulse
	if (N > 250){                                   // avoid high frequency noise
		if ((Signal > thresh) && (Pulse == false) && (N > (IBI / 5) * 3)){
			Pulse = true;                               // set the Pulse flag when we think there is a pulse
			//      digitalWrite(blinkPin,HIGH);                // turn on pin 13 LED
			IBI = sampleCounter - lastBeatTime;         // measure time between beats in mS
			lastBeatTime = sampleCounter;               // keep track of time for next pulse

			if (secondBeat){                        // if this is the second beat, if secondBeat == TRUE
				secondBeat = false;                  // clear secondBeat flag
				for (int i = 0; i <= 9; i++){             // seed the running total to get a realisitic BPM at startup
					rate[i] = IBI;
				}
			}

			if (firstBeat){                         // if it's the first time we found a beat, if firstBeat == TRUE
				firstBeat = false;                   // clear firstBeat flag
				secondBeat = true;                   // set the second beat flag
				sei();                               // enable interrupts again
				return;                              // IBI value is unreliable so discard it
			}


			// keep a running total of the last 10 IBI values
			word runningTotal = 0;                  // clear the runningTotal variable    

			for (int i = 0; i <= 8; i++){                // shift data in the rate array
				rate[i] = rate[i + 1];                  // and drop the oldest IBI value 
				runningTotal += rate[i];              // add up the 9 oldest IBI values
			}

			rate[9] = IBI;                          // add the latest IBI to the rate array
			runningTotal += rate[9];                // add the latest IBI to runningTotal
			runningTotal /= 10;                     // average the last 10 IBI values 
			BPM = 60000 / runningTotal;               // how many beats can fit into a minute? that's BPM!
			QS = true;                              // set Quantified Self flag 
			// QS FLAG IS NOT CLEARED INSIDE THIS ISR
		}
	}

	if (Signal < thresh && Pulse == true){   // when the values are going down, the beat is over
		//    digitalWrite(blinkPin,LOW);            // turn off pin 13 LED
		Pulse = false;                         // reset the Pulse flag so we can do it again
		amp = P - T;                           // get amplitude of the pulse wave
		thresh = amp / 2 + T;                    // set thresh at 50% of the amplitude
		P = thresh;                            // reset these for next time
		T = thresh;
	}

	if (N > 2500){                           // if 2.5 seconds go by without a beat
		thresh = 512;                          // set thresh default
		P = 512;                               // set P default
		T = 512;                               // set T default
		lastBeatTime = sampleCounter;          // bring the lastBeatTime up to date        
		firstBeat = true;                      // set these to avoid noise
		secondBeat = false;                    // when we get the heartbeat back
	}

	// Read pressure sensors
	if (--pSampleCounter == 0)
	{
		CP = analogRead(CP_PIN);
		pSampleCounter = PRES_PER_PPG;

		// DONE: Schedule data transmission to host
		newSensorData = true;

	}
	
	// Manage LED timer
	if (ledON > 0)
	{
		if (--ledON <= 0)
		{
			digitalWrite(LEDPIN, 0);
			ledOFF = loopHalfPeriod;
		}
	}

	if (ledOFF > 0)
	{
		if (--ledOFF <= 0)
		{
			digitalWrite(LEDPIN, 1);
			ledON = loopHalfPeriod;
		}
	}

	//// Manage latching solenoid pulse timers
	//if (ls1ONPulseCounter > 0)
	//{
	//	ls1ONPulseCounter--;
	//	if (ls1ONPulseCounter <= 0)
	//	{
	//		digitalWrite(LS1_ON_PIN, 0);
	//	}
	//}
	//if (ls1OFFPulseCounter > 0)
	//{
	//	ls1OFFPulseCounter--;
	//	if (ls1OFFPulseCounter <= 0)
	//	{
	//		digitalWrite(LS1_OFF_PIN, 0);
	//	}
	//}
	//if (ls2ONPulseCounter > 0)
	//{
	//	ls2ONPulseCounter--;
	//	if (ls2ONPulseCounter <= 0)
	//	{
	//		digitalWrite(LS2_ON_PIN, 0);
	//	}
	//}
	//if (ls2OFFPulseCounter > 0)
	//{
	//	ls2OFFPulseCounter--;
	//	if (ls2OFFPulseCounter <= 0)
	//	{
	//		digitalWrite(LS2_OFF_PIN, 0);
	//	}
	//}

	sei();                                   // enable interrupts when youre done!
}// end Timer 2 ISR

