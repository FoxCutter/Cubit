#include "Common.h"

void PrintString(char Value)
{
	Serial.print(Value);
}

void PrintString(const char * Value)
{
	Serial.print(Value);
}

void PrintString(const __FlashStringHelper* Value)
{
	Serial.print(Value);
}

void PrintStringNewLine(char Value)
{
	Serial.println(Value);
}

void PrintStringNewLine(const char * Value)
{
	Serial.println(Value);
}

void PrintStringNewLine(const __FlashStringHelper* Value)
{
	Serial.println(Value);
}

void PrintStringNewLine()
{
	Serial.println();
}

void PrintValue(unsigned int Value)
{
	char buf[5];
	sprintf(buf, "%04X", Value);
	PrintString(buf);
}

void PrintValue(unsigned char Value)
{
	char buf[5];
	sprintf(buf, "%02X", Value);
	PrintString(buf);
}

char *SkipSpaces(char * Buffer)
{
	char * Ret = Buffer;

	while(*Ret == ' ')
		Ret++;

	return Ret;
}

int ReadLine(char * Buffer, int MaxLength, bool Echo)
{
	int Pos = 0;

	while(true)
	{
		if(!Serial.available())
			continue;

        char Value = Serial.read();

	    // LF
	    if(Value == 0x0A)
	    	break;

	    // CR
	    else if(Value == 0x0D)
	    {
			// Check for CR/LF
			if(Serial.peek() == 0x0A)
				Serial.read();

			break;
		}

		// Handle backspace
		else if(Value == 0x08 || Value == 0x7F)
		{
			if(Pos == 0)
			{
				if(Echo)
					PrintString("\x7");
				continue;
			}

			Pos--;

			if(Echo)
				PrintString("\x8 \x8");
		}
		else
		{
		    // Any other valid 7-bit character
		    if(Pos + 1 == MaxLength || Value < 0x20 || Value > 0x7E)
		    {
 				if(Echo)
					PrintString("\x7");
		    	continue;
			}

			if(Echo)
				PrintString(Value);

		    Buffer[Pos++] = Value;
		}
	};

	Buffer[Pos] = 0;

	if(Echo)
		PrintStringNewLine();

	return Pos;
}

char ReadInput(char * Options)
{
	// Clear out any pending data
	while(Serial.available())
		Serial.read();

	bool Done = false;
	while(!Done)
	{
		// Check for an abort
		delay(10);
		if(!Serial.available())
			continue;

		char Value = toupper(Serial.read());

        char *Res = strchr(Options, Value);

        if(Res == nullptr)
        	continue;

        PrintStringNewLine(Value);

        return *Res;
	};
}

unsigned char HexToValue(char Value)
{
	if(Value >= '0' && Value <= '9')
		return Value - '0';

	if(Value >= 'a' && Value <= 'f')
		return Value - 'a' + 10;

	if(Value >= 'A' && Value <= 'F')
		return Value - 'A' + 10;

	return 0;
}

unsigned char HexToByte(char *HexBuffer)
{
	return (HexToValue(HexBuffer[0]) << 4) + HexToValue(HexBuffer[1]);
}

unsigned short HexToShort(char *HexBuffer)
{
	return (HexToValue(HexBuffer[0]) << 12) + (HexToValue(HexBuffer[1]) << 8) + (HexToValue(HexBuffer[2]) << 4) + HexToValue(HexBuffer[3]);
}

char * ReadShort(char *DataBuffer, unsigned short &Value)
{
	Value = 0;
	for(int x = 0; x < 4; x++, DataBuffer++)
	{
		if(*DataBuffer == 0 || *DataBuffer == ' ')
			break;

		Value = Value << 4;

		Value += HexToValue(*DataBuffer);
	}

	return DataBuffer;
}

char * ReadByte(char *DataBuffer, unsigned char &Value)
{
	Value = 0;
	for(int x = 0; x < 2; x++, DataBuffer++)
	{
		if(*DataBuffer == 0 || *DataBuffer == ' ')
			break;

		Value = Value << 4;

		Value += HexToValue(*DataBuffer);
	}

	return DataBuffer;
}
