#include "Common.h"

unsigned int BusRef = 0;

void PinSetup()
{
	// Address Pins
	pinMode(AddressInput, OUTPUT);
	pinMode(AddressOutput, INPUT);
	pinMode(AddressClock, OUTPUT);
	pinMode(AddressDisplay, OUTPUT);
	pinMode(AddressMode, OUTPUT);

    // Data Pins
	pinMode(DataInput, OUTPUT);
	pinMode(DataOutput, INPUT);
	pinMode(DataClock, OUTPUT);
	pinMode(DataDisplay, OUTPUT);
	pinMode(DataMode, OUTPUT);

    // Status Pins
	//pinMode(StatusInput, OUTPUT);
	//pinMode(StatusOutput, INPUT);
	//pinMode(StatusClock, OUTPUT);
	//pinMode(StatusDisplay, OUTPUT);
	//pinMode(StatusMode, OUTPUT);

    // Bus Pins
	pinMode(DataWrite, INPUT);
	pinMode(DataRead, INPUT);
	pinMode(MemoryRequest, INPUT);
	pinMode(IORequest, INPUT);


    // System Pins
	pinMode(BusReq, OUTPUT);
	pinMode(BusAck, INPUT);
	pinMode(BusWait, INPUT);

	digitalWrite(AddressInput, LOW);
	digitalWrite(AddressClock, LOW);
	digitalWrite(AddressDisplay, HIGH);
	digitalWrite(AddressMode, LOW);

	digitalWrite(DataInput, LOW);
	digitalWrite(DataClock, LOW);
	digitalWrite(DataDisplay, HIGH);
	digitalWrite(DataMode, LOW);

	//digitalWrite(StatusInput, LOW);
	//digitalWrite(StatusClock, LOW);
	//digitalWrite(StatusDisplay, HIGH);
	//digitalWrite(StatusMode, LOW);

	// Don't request the bus just yet
	digitalWrite(BusReq, HIGH);

}

bool TakeBus()
{
  // We already have it, so don't need to do a thing
  if(BusRef != 0)
  {
    BusRef++;
    return true;
  }
    
	// Check if someone else owns the bus
	if(digitalRead(BusReq) == 0 && digitalRead(BusAck) == 0)
	{
		return false;
	}

	// Turn on the bus
	digitalWrite(BusReq, LOW);

	// And wait until we get ownership
	while(digitalRead(BusAck) == 1)
		delay(1);

	pinMode(DataWrite, OUTPUT);
	pinMode(DataRead, OUTPUT);
	pinMode(MemoryRequest, OUTPUT);
	pinMode(IORequest, OUTPUT);

	digitalWrite(DataWrite, HIGH);
	digitalWrite(DataRead, HIGH);
	digitalWrite(MemoryRequest, HIGH);
	digitalWrite(IORequest, HIGH);

	BusRef++;

	return true;
}

bool ReleaseBus()
{
  // Can't release what we don't own.
  if(BusRef == 0)
    return false;

	// Check if someone else owns the bus
	if(digitalRead(BusReq) == 1 && digitalRead(BusAck) == 0)
	{
		return false;
	}

	BusRef--;

	if(BusRef <= 0)
	{
		// Reset the bus pins to floating
		pinMode(DataWrite, INPUT);
		pinMode(DataRead, INPUT);
		pinMode(MemoryRequest, INPUT);
		pinMode(IORequest, INPUT);

		// Turn off the bus
		digitalWrite(BusReq, HIGH);

		// And wait until the onwsership clears
		while(digitalRead(BusAck) == 0)
			delay(1);

		BusRef == 0;
	}

	return true;
}


void SetAddress(unsigned int Address)
{
	// Shift out first the high Byte
	shiftOut(AddressInput, AddressClock, MSBFIRST, (Address >> 8) & 0x00FF);

	// Then the low byte
	shiftOut(AddressInput, AddressClock, MSBFIRST, Address & 0xFF);
}

unsigned int GetAddress()
{
  // Set the Address shifter to read
  digitalWrite(AddressMode, HIGH);

  // Cycle the Clock
  digitalWrite(AddressClock, HIGH);
  digitalWrite(AddressClock, LOW);

  delay(1);

  // And back to write so we can shift it out.
  digitalWrite(AddressMode, LOW);

  // Save the first bit, then get the rest of the high byte
  unsigned int Data = digitalRead(AddressOutput) << 15;

  Data |= shiftIn(AddressOutput, AddressClock, MSBFIRST) << 7;

  // And the low byte
  Data |= shiftIn(AddressOutput, AddressClock, MSBFIRST) >> 1;

  return Data;
}

void SetData(byte Data)
{
   shiftOut(DataInput, DataClock, MSBFIRST, Data);
}

byte GetData()
{
  // Set the Data shifter to read
  digitalWrite(DataMode, HIGH);

  // Cycle the Clock
  digitalWrite(DataClock, HIGH);
  digitalWrite(DataClock, LOW);

  delay(1);

  // And back to write so we can shift it out.
  digitalWrite(DataMode, LOW);

  // Save the first bit, then get the rest
  byte Data = digitalRead(DataOutput) << 7;
  Data |= shiftIn(DataOutput, DataClock, MSBFIRST) >> 1;

  return Data;
}

/*
void SetStatus(byte Data)
{
   shiftOut(StatusInput, StatusClock, MSBFIRST, ~Data);
}

byte GetStatus()
{
  // Set the Data shifter to read
  digitalWrite(StatusMode, HIGH);

  // Cycle the Clock
  digitalWrite(StatusClock, HIGH);
  digitalWrite(StatusClock, LOW);

  delay(1);

  // And back to write so we can shift it out.
  digitalWrite(StatusMode, LOW);

  // Save the first bit, then get the rest
  byte Data = digitalRead(StatusOutput) << 7;
  Data |= shiftIn(StatusOutput, DataClock, MSBFIRST) >> 1;

  return ~Data;
}
*/


byte ReadData(unsigned int Address)
{
  TakeBus();

  // Set the address
  SetAddress(Address);

  // Ouput it
  digitalWrite(AddressDisplay, LOW);

  //SetStatus(StatusMREQ | StatusRD);
  //digitalWrite(StatusDisplay, LOW);

  // Tell the memory we want to read
  digitalWrite(DataRead, LOW);
  digitalWrite(DataWrite, HIGH);

  // Enable the Memory
  digitalWrite(MemoryRequest, LOW);

  delay(1);

  while(digitalRead(BusWait) == 0)
  	delay(1);

  // Grab the data
  byte Data = GetData();

  // Clear everything.
  digitalWrite(MemoryRequest, HIGH);
  digitalWrite(DataRead, HIGH);
  digitalWrite(AddressDisplay, HIGH);
  //digitalWrite(StatusDisplay, HIGH);

  ReleaseBus();

  return Data;
}


void WriteData(unsigned int Address, byte Data)
{
  TakeBus();

  // Set the address
  SetAddress(Address);

  // Set the Data
  SetData(Data);

  // Display them
  digitalWrite(AddressDisplay, LOW);
  digitalWrite(DataDisplay, LOW);

  // Tell it we want to write
  //SetStatus(StatusMREQ | StatusWD);
  //digitalWrite(StatusDisplay, LOW);

  digitalWrite(DataRead, HIGH);
  digitalWrite(DataWrite, LOW);

  // Enable the Memory
  digitalWrite(MemoryRequest, LOW);

  delay(1);

  while(digitalRead(BusWait) == 0)
  	delay(1);

  // Clear everything.
  digitalWrite(MemoryRequest, HIGH);
  digitalWrite(DataWrite, HIGH);

  digitalWrite(DataDisplay, HIGH);
  digitalWrite(AddressDisplay, HIGH);
  //digitalWrite(StatusDisplay, HIGH);

  ReleaseBus();
}


byte ReadPort(unsigned int Address)
{
  TakeBus();

  // Set the address
  SetAddress(Address);

  // Ouput it
  digitalWrite(AddressDisplay, LOW);

  // Tell the IO we want to read
  //SetStatus(StatusIORQ | StatusRD);
  //digitalWrite(StatusDisplay, LOW);
  digitalWrite(DataRead, LOW);
  digitalWrite(DataWrite, HIGH);

  // Enable the Memory
  digitalWrite(IORequest, LOW);

  delay(1);

  while(digitalRead(BusWait) == 0)
  	delay(1);

  // Grab the data
  byte Data = GetData();

  // Clear everything.
  digitalWrite(IORequest, HIGH);
  digitalWrite(DataRead, HIGH);
  digitalWrite(AddressDisplay, HIGH);
  //digitalWrite(StatusDisplay, HIGH);

  ReleaseBus();

  return Data;
}


void WritePort(unsigned int Address, byte Data)
{
  TakeBus();

  // Set the address
  SetAddress(Address);

  // Set the Data
  SetData(Data);

  // Display them
  //SetStatus(StatusIORQ | StatusWD);
  //digitalWrite(StatusDisplay, LOW);

  digitalWrite(AddressDisplay, LOW);
  digitalWrite(DataDisplay, LOW);

  // Tell it we want to write
  digitalWrite(DataRead, HIGH);
  digitalWrite(DataWrite, LOW);

  // Enable the Memory
  digitalWrite(IORequest, LOW);

  delay(1);

  while(digitalRead(BusWait) == 0)
  	delay(1);

  // Clear everything.
  digitalWrite(IORequest, HIGH);
  digitalWrite(DataWrite, HIGH);

  digitalWrite(DataDisplay, HIGH);
  digitalWrite(AddressDisplay, HIGH);
  //digitalWrite(StatusDisplay, HIGH);

  ReleaseBus();
}


bool TestBlock(unsigned short BlockNum)
{
  Serial.print("Testing Block ");
  Serial.println(BlockNum, HEX);

  unsigned int AddressBase = BlockNum << 8;

  for(int x = 0; x < 0x100; x++)
  {
    WriteData(AddressBase + x, 0xFF - x);
  }

  bool Passed = true;

  for(int x = 0; x < 0x100; x++)
  {
#ifdef MEMDEBUG
    if(digitalRead(BusWait) == LOW)
    {
		digitalWrite(AddressDisplay, LOW);
		digitalWrite(DataRead, LOW);
		digitalWrite(MemoryRequest, LOW);

      	Serial.println("Press any key...");

      	while(Serial.read() == -1)
      	  ;

		//digitalWrite(DataDisplay, HIGH);
		digitalWrite(AddressDisplay, HIGH);
		digitalWrite(DataRead, HIGH);
		digitalWrite(MemoryRequest, HIGH);
    }
#endif

    byte Data = ReadData(AddressBase + x);

    if(Data != (0xFF - x))
    {
      Serial.print("     Memory Test Failed!!!!!!!!! Block ");
      Serial.print(BlockNum, HEX);
      Serial.print(" Offest ");
      Serial.print(AddressBase + x, HEX);
      Serial.print(" Expected value ");
      Serial.print(0xFF - x, HEX);
      Serial.print(" Real value ");
      Serial.print(Data, HEX);
      Serial.print(" Diff ");
      Serial.println(Data ^ (0xFF-x), HEX);
      Passed = false;
    }
#ifdef MEMDEBUG
    /*
    else
    {
      Serial.print("     Memory Test Passed! Block ");
      Serial.print(BlockNum, HEX);
      Serial.print(" Offest ");
      Serial.print(AddressBase + x, HEX);
      Serial.print(" Expected value ");
      Serial.print(0xFF - x, HEX);
      Serial.print(" Real value ");
      Serial.println(Data, HEX);
    }
    */
#endif
  }

  Serial.print("  Block ");
  Serial.print(BlockNum, HEX);

  if(Passed)
      Serial.println(" Passed");
  else
      Serial.println(" Failed");

  return Passed;
}


