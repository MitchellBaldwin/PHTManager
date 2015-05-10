void SendTextMessage()
{
	int i, checkSum;
	unsigned int msgLength;

	outBuffer[0x00] = startbyte;	// MRS Start byte
	outBuffer[0x01] = 0x00;			// MRS text message type
	msgLength = strlen(textMessage.c_str());
	if (msgLength > TEXT_MESSAGE_MAX_SIZE)
	{
		msgLength = TEXT_MESSAGE_MAX_SIZE;
	}
	for (i = 0; i < msgLength; ++i)
	{
		outBuffer[i + 2] = textMessage[i];
		//outBuffer[i + 2] = 0x41;
	}
	for (i = msgLength + 3; i < COMM_BUFFER_SIZE; ++i)
	{
		outBuffer[i] = 0x00;		// Pad buffer
	}

	checkSum = 0;
	for (i = 0; i < COMM_BUFFER_SIZE - 1; ++i)
	{
		checkSum += outBuffer[i];
	}
	outBuffer[COMM_BUFFER_SIZE - 1] = checkSum;

	Serial.write(outBuffer, COMM_BUFFER_SIZE);

}

void WriteText(char* message)
{
	int i, checkSum;
	unsigned int msgLength;

	outBuffer[0x00] = startbyte;	// MRS Start byte
	outBuffer[0x01] = 0x00;			// MRS text message type
	msgLength = strlen(message);
	if (msgLength > TEXT_MESSAGE_MAX_SIZE)
	{
		msgLength = TEXT_MESSAGE_MAX_SIZE;
	}
	for (i = 0; i < msgLength; ++i)
	{
		outBuffer[i + 2] = message[i];
	}
	for (i = msgLength + 3; i < COMM_BUFFER_SIZE; ++i)
	{
		outBuffer[i] = 0x00;		// Pad buffer
	}

	checkSum = 0;
	for (i = 0; i < COMM_BUFFER_SIZE - 1; ++i)
	{
		checkSum += outBuffer[i];
	}
	outBuffer[COMM_BUFFER_SIZE - 1] = checkSum;

	Serial.write(outBuffer, COMM_BUFFER_SIZE);

}

void WriteTextLn(char* message)
{
	int i, checkSum;
	unsigned int msgLength;

	outBuffer[0x00] = startbyte;	                    // MRS Start byte
	outBuffer[0x01] = 0x00;			                    // MRS text message type
	for (i = 2; i < COMM_BUFFER_SIZE; ++i)
	{
		outBuffer[i] = 0x00;		                    // Pad buffer
	}
	msgLength = strlen(message);
	if (msgLength > TEXT_MESSAGE_MAX_SIZE-2)
	{
		msgLength = TEXT_MESSAGE_MAX_SIZE-2;
	}
	for (i = 0; i < msgLength; ++i)
	{
		outBuffer[i + 2] = message[i];
	}
	outBuffer[msgLength + 2] = 0x0D;                    // ASCII CR
	outBuffer[msgLength + 3] = 0x0A;                    // ASCII LF

	checkSum = 0;
	for (i = 0; i < COMM_BUFFER_SIZE - 1; ++i)
	{
		checkSum += outBuffer[i];
	}
	outBuffer[COMM_BUFFER_SIZE - 1] = checkSum;

	Serial.write(outBuffer, COMM_BUFFER_SIZE);

}
