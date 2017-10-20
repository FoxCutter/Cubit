#include "Common.h"

unsigned short CurrentAddress = 0;
bool Running = false;

bool CPU_MemReq = false;
bool CPU_IOReq = false;
bool CPU_Read = false;
bool CPU_Write = false;
bool CPU_M1 = false;
bool CPU_Halt = false;
bool CPU_INT = false;
bool CPU_NMI = false;
bool CPU_IntAck = false;

unsigned short CPU_Address = 0;
unsigned char  CPU_Data = 0;

void setup()
{
	Serial.begin(9600);
	PinSetup();

    // System Pins
	pinMode(M1Input, INPUT);

	//digitalWrite(BusReq, LOW);
	//while(digitalRead(BusAck) == HIGH) ;

	PrintStringNewLine();
	PrintStringNewLine(F("  ========== Z-80 Anti Monitor ========== "));
	PrintStringNewLine();

	Running = true;

	StopCPU(nullptr):
}

void loop()
{
	char Buffer[128];

	if(Running)
	{
		PrintStringNewLine("Running...");
		PrintStringNewLine(">>> ");
	}
	else
	{
		// Stopped
		// [  ] [  ] [  ] [  ] [  ] [  ] [  ] [  ] [  ]
		// Address: 0000, Data: 00
		// [0000] >>>

		// Stopped
		// [M1] [  ] [ME] [  ] [RD] [  ] [  ] [  ] [  ]
		// Address: DDEE, Data: E8
		// [0000] >>>

		// Stopped
		// [  ] [  ] [ME] [  ] [  ] [WD] [  ] [  ] [  ]
		// Address: FFEE, Data: 00
		// [0000] >>>

		// Stopped
		// [  ] [  ] [  ] [IO] [RD] [  ] [  ] [  ] [  ]
		// Address: 0010, Data: 00
		// [0000] >>>

		// Stopped
		// [M1] [  ] [  ] [IO] [  ] [  ] [IT] [  ] [IA]
		// Address: 0000, Data: 00
		// [0000] >>>

		PrintStringNewLine("Stopped");
		PrintString(CPU_M1 		? "[M1] " : "[  ] ");
		PrintString(CPU_Halt 	? "[HT] " : "[  ] ");
		PrintString(CPU_MemReq 	? "[ME] " : "[  ] ");
		PrintString(CPU_IOReq 	? "[IO] " : "[  ] ");
		PrintString(CPU_Read 	? "[RD] " : "[  ] ");
		PrintString(CPU_Write 	? "[WD] " : "[  ] ");
		PrintString(CPU_INT 	? "[IT] " : "[  ] ");
		PrintString(CPU_NMI 	? "[NI] " : "[  ] ");
		PrintString(CPU_IntAck 	? "[IA] " : "[  ] ");

		PrintStringNewLine();
		PrintString("Address: ");
		PrintValue(CPUAddress);
		PrintString(", Data: ");
		PrintValue(CPUData);

		PrintStringNewLine();

		PrintString("[");
		PrintValue(CurrentAddress);
		PrintString("] >>> ");
	}

	ReadLine(Buffer, 40, true);

	switch(toupper(Buffer[0]))
	{
		// help
		case '?':
		case 'H':
			ShowHelp(&Buffer[1]);
			break;

		// Run
		case 'R':
		    if(Running)
		    {
				PrintStringNewLine(F("  Command is only available in stop mode"));
				break;
			}

			RunCPU(&Buffer[1]);

			break;

		// Stop
		case 'S':
		    if(!Running)
		    {
				PrintStringNewLine(F("  Command is only available in run mode"));
				break;
			}

			StopCPU(&Buffer[1]);

  			break;

		// Trace
		case 'T':
		    if(Running)
		    {
				PrintStringNewLine(F("  Command is only available in stop mode"));
				break;
			}

			StepCPU(&Buffer[1]);

			break;

		// Examine
		case 'E':
		    if(Running)
		    {
				PrintStringNewLine(F("  Command is only available in stop mode"));
				break;
			}

			ExamineMemory(&Buffer[1], false);

			break;

		// Examine Next
		case 'N':
		    if(Running)
		    {
				PrintStringNewLine(F("  Command is only available in stop mode"));
				break;
			}

			ExamineMemory(&Buffer[1], true);

			break;

		// Deposit
		case 'D':
		    if(Running)
		    {
				PrintStringNewLine(F("  Command is only available in stop mode"));
				break;
			}

			DepositMemory(&Buffer[1], false);

			break;


		// Deposit Next
		case 'X':
		    if(Running)
		    {
				PrintStringNewLine(F("  Command is only available in stop mode"));
				break;
			}

			DepositMemory(&Buffer[1], true);
			break;

		// Input
		case 'I':
		    if(Running)
		    {
				PrintStringNewLine(F("  Command is only available in stop mode"));
				break;
			}

			InFromPort(&Buffer[1]);

			break;

		// Output
		case 'O':
		    if(Running)
		    {
				PrintStringNewLine(F("  Command is only available in stop mode"));
				break;
			}

			OutToPort(&Buffer[1]);

			break;

		// Load Hex
		case 'L':
		    if(Running)
		    {
				PrintStringNewLine(F("  Command is only available in stop mode"));
				break;
			}

			LoadHexData(Buffer);

			break;

		// Download Hex
		case 'G':
		    if(Running)
		    {
				PrintStringNewLine(F("  Command is only available in stop mode"));
				break;
			}

			DownloadHexData(&Buffer[1]);

			break;

		// Display Bus Data
		case 'K':
		    if(Running)
		    {
				PrintStringNewLine(F("  Command is only available in stop mode"));
				break;
			}

			DisplayBus(&Buffer[1]);

			break;

		// Flash Bus
		case 'F':
		    if(Running)
		    {
				PrintStringNewLine(F("  Command is only available in stop mode"));
				break;
			}

			FlashBus(&Buffer[1]);

			break;
	}
}

void CycleCPU()
{
	// Assuming direct control
	pinMode(BusWait, OUTPUT);
	pinMode(DataWrite, INPUT);
	pinMode(DataRead, INPUT);
	pinMode(MemoryRequest, INPUT);
	pinMode(IORequest, INPUT);

	// Tell the chip to wait when we release the bus
	digitalWrite(BusWait, LOW);

	// Release the bus
	digitalWrite(BusReq, HIGH);

	// And wait until the ownership clears
	while(digitalRead(BusAck) == LOW)
		delay(1);

	// Make sure we are at the wait state (This might need tuning)
	delay(1);

	// copy the values off the buses and control pins
	CPU_Address = GetAddress();
	CPU_Data = GetData();

	//unsigned char Status = GetStatus();
	//CPU_M1 = Status & StatusM1;
	//CPU_MemReq = Status & StatusMEMRQ;
	//CPU_IOReq = Status & IQRQ;
	//CPU_Read = Status & StatusRD;
	//CPU_Write = Status & StatusWD;
	//CPU_Halt = Status & StatusHalt;
	//CPU_INT = Status & StatusINT;
	//CPU_NMI = Status & StatusNMI;

	CPU_M1 = !digitalRead(M1Input);
	CPU_MemReq = !digitalRead(MemoryRequest);
	CPU_IOReq = !digitalRead(IORequest);

	CPU_Read = !digitalRead(DataRead);
	CPU_Write = !digitalRead(DataWrite);

	CPU_IntAck = CPU_Read && CPU_M1;

	// Get the bus and stop waiting
	digitalWrite(BusReq, LOW);
	digitalWrite(BusWait, HIGH);

  	while(digitalRead(BusAck) == HIGH)
  		delay(1);

	// And now we should be at the start of the next T state

	// Reset everything
	pinMode(BusWait, INPUT);
	pinMode(DataWrite, OUTPUT);
	pinMode(DataRead, OUTPUT);
	pinMode(MemoryRequest, OUTPUT);
	pinMode(IORequest, OUTPUT);

	digitalWrite(DataWrite, HIGH);
	digitalWrite(DataRead, HIGH);
	digitalWrite(MemoryRequest, HIGH);
	digitalWrite(IORequest, HIGH);

}

void WaitForM1()
{
	// Cycle the wait state until we reach the end of M1
	while(!CPU_M1)
		CycleCPU();
}

/*
void WaitForPin(int Pin)
{
	// Wait until a pin goes low
	while(digitalRead(Pin) == 1)
		delay(1);
}
*/

void CycleWait()
{
	digitalWrite(BusWait, HIGH);
	digitalWrite(BusWait, LOW);

	// Digital 13 (BusWait) == PORTB5


	//PORTB |= _BV(PORTB5); // HIGH
	//__builtin_avr_nop();
	//PORTB &= ~(_BV(PORTB5)); // LOW

	//bitSet(PORTB, PORTB5); // HIGH
	//__builtin_avr_nop();
	//bitClear(PORTB, PORTB5); // LOW

	//__extension__ __asm__ __volatile__ ("sbi PORTB, PORTB5"); // HIGH
	//__builtin_avr_nop();
	//__extension__ __asm__ __volatile__ ("cbi PORTB, PORTB5"); // LOW

	//__builtin_avr_delay_cycles(5);
	//__builtin_avr_nop();

}

// Executes a no op on the Z80
void ExecuteNoOp()
{
	// Time to juggle the bus
	pinMode(BusWait, OUTPUT);

	// Tell the chip to wait when we release the bus
	digitalWrite(BusWait, LOW);
	digitalWrite(BusReq, HIGH);

	// Cycle wait until we are at M1
	while(digitalRead(M1Input) == HIGH)
	{
		CycleWait();
	}

	// Put the NoOp on the data buss
	SetData(0x00);
    digitalWrite(DataDisplay, LOW);

	CycleWait();

	// Get the bus and stop waiting
	digitalWrite(BusReq, LOW);
	digitalWrite(BusWait, HIGH);

  	while(digitalRead(BusAck) == HIGH)
  		delay(1);

	// Clear the data
	digitalWrite(DataDisplay, HIGH);

	// And now we should be at the start of the next T state
	pinMode(BusWait, INPUT);
}

// Executes a far jump on the Z80
void ExecuteJump(unsigned short Address)
{
	// Time to juggle the bus
	pinMode(BusWait, OUTPUT);

	// Tell the chip to wait when we release the bus
	digitalWrite(BusWait, LOW);
	digitalWrite(BusReq, HIGH);

	// Cycle wait until we are at M1
	while(digitalRead(M1Input) == HIGH)
	{
		CycleWait();
	}

	// Put the jump op code on the bus
	SetData(0xC3);
    digitalWrite(DataDisplay, LOW);

	// Cycle the CPU to the next wait state
	CycleWait();

	// Low byte of the address
	digitalWrite(DataDisplay, HIGH);
	SetData(Address & 0xFF);
    digitalWrite(DataDisplay, LOW);

	// Cycle
	CycleWait();

	// High byte of the address
	digitalWrite(DataDisplay, HIGH);
	SetData((Address >> 8) & 0x00FF);
    digitalWrite(DataDisplay, LOW);

	// Get the bus and stop waiting
	digitalWrite(BusReq, LOW);
	digitalWrite(BusWait, HIGH);

  	while(digitalRead(BusAck) == HIGH)
  		delay(1);

	// Clear the data
	digitalWrite(DataDisplay, HIGH);

	// And now we should be at the start of the next T state
	pinMode(BusWait, INPUT);
}


bool ProcessHexString(char *HexBuffer)
{
	PrintString('.');

    if(HexBuffer[0] != ':')
	{
		PrintStringNewLine();
		PrintStringNewLine(F("  Invalid HEX String"));
		return false;
	}

	unsigned char Length = HexToByte(&HexBuffer[1]);
	unsigned short Address = HexToShort(&HexBuffer[3]);
	unsigned char Type = HexToByte(&HexBuffer[7]);
	unsigned char Checksum = Length + Type + (Address >> 8) + Address & 0xFF;

	unsigned int Pos = 9;
	for(int x = 0; x < Length; x++)
	{
		unsigned char Data = HexToByte(&HexBuffer[Pos]);
		Checksum += Data;
		Pos += 2;

		if(Type == 0)
		{
			WriteData(Address, Data);
			Address++;
		}
	}

	Checksum += HexToByte(&HexBuffer[Pos]);

	if(Checksum != 0)
	{
		// Invalid HEX string
		PrintStringNewLine();
		PrintStringNewLine(F("  Invalid HEX Checksum"));
		return false;
	}

	// End of record
	if(Type == 1)
	{
		PrintStringNewLine();
		PrintStringNewLine(F("  End of HEX"));
		return false;
	}

	// Not much to do with this one at the moment
	if(Type == 2)
		return true;

	return true;
}

void ShowHelp(char *BufferData)
{
	PrintStringNewLine(F(" Command List"));
	PrintStringNewLine(F("  Run Mode Commands "));
	PrintStringNewLine(F("    S: Stop"));
	PrintStringNewLine();
	PrintStringNewLine(F("  Stop Mode Commands "));
	PrintStringNewLine(F("    R: Run                         T: Step"));
	PrintStringNewLine();
	PrintStringNewLine(F("    E: Examine [Address] [Length]  N: Examine Next "));
	PrintStringNewLine();
	PrintStringNewLine(F("    D: Deposit (Address) (Value)   X: Deposit Next (Value)"));
	PrintStringNewLine();
	PrintStringNewLine(F("    I: Read Port (Port)            O: Write Port (Port) (Value)"));
	PrintStringNewLine();
	PrintStringNewLine(F("    L: Load Hex                    G: Download Hex (Start) [End]"));
	PrintStringNewLine();
	PrintStringNewLine(F("    K: Display Bus Data            F: Flash Bus (Address) (Data)"));
	PrintStringNewLine();
	PrintStringNewLine(F("    All values are in hexadecimal. Address can be replaced with '-' to"));
	PrintStringNewLine(F("    use the current address, otherwise it will change it to the provived"));
	PrintStringNewLine(F("    address"));
}

void RunCPU(char *BufferData)
{
	BufferData = SkipSpaces(BufferData);

	if(*BufferData != 0)
	{
		if(*BufferData == '-')
			BufferData ++;
		else
			BufferData = ReadShort(BufferData, CurrentAddress);

		PrintString(F("  Entering Run Mode at "));
		PrintValue(CurrentAddress);
		PrintStringNewLine();

		ExecuteJump(CurrentAddress);
	}
	else
	{
		PrintStringNewLine(F("  Entering Run Mode"));

	}

	Running = true;

	// Give up the bus
	ReleaseBus();
}

void StopCPU(char *BufferData)
{
	PrintStringNewLine(F("  Entering Stop Mode"));

	// Take over the bus from the CPU
	TakeBus();

  	// The move to M1
  	WaitForM1();

	Running = false;

	CurrentAddress = CPU_Address;
}

void StepCPU(char *BufferData)
{
	PrintStringNewLine(F("  Tracing..."));

	CycleCPU();
}

void ExamineMemory(char *BufferData, bool Next)
{
	unsigned short Length = 1;

	if(Next)
	{
		CurrentAddress++;
	}
	else
	{
		BufferData = SkipSpaces(BufferData);

		if(*BufferData != 0)
		{
			if(*BufferData == '-')
				BufferData ++;
			else
				BufferData = ReadShort(BufferData, CurrentAddress);
		}

		BufferData = SkipSpaces(BufferData);

		if(*BufferData != 0)
		{
			BufferData = ReadShort(BufferData, Length);
		}
	}

	for(int x = 0; x < Length; x++)
	{
		unsigned char TempData = ReadData(CurrentAddress + x);

		PrintString("  ");
		PrintValue(CurrentAddress + x);
		PrintString(": ");
		PrintValue(TempData);
		PrintStringNewLine();
	}
}

void DepositMemory(char *BufferData, bool Next)
{
	unsigned short TempAddress = CurrentAddress;

	if(Next)
	{
		TempAddress++;
	}
	else
	{
		BufferData = SkipSpaces(BufferData);

		if(*BufferData == 0)
		{
			PrintStringNewLine(F("  Address missing (use '-' to skip)"));
			return;
		}
		else
		{
			if(*BufferData == '-')
				BufferData ++;
			else
				BufferData = ReadShort(BufferData, TempAddress);
		}
	}

	BufferData = SkipSpaces(BufferData);

	if(*BufferData == 0)
	{
		PrintStringNewLine(F("  Data Missing"));
		return;
	}

	unsigned char TempData;
	BufferData = ReadByte(BufferData, TempData);

	WriteData(TempAddress, TempData);

	delay(1);

	TempData = ReadData(TempAddress);

	CurrentAddress = TempAddress;

	PrintString("  ");
	PrintValue(CurrentAddress);
	PrintString(": ");
	PrintValue(TempData);
	PrintStringNewLine();
}

void InFromPort(char *BufferData)
{
	BufferData = SkipSpaces(BufferData);

	unsigned char Port;

	if(*BufferData == 0)
	{
		PrintStringNewLine(F("  Port number missing"));
		return;
	}
	else
	{
		BufferData = ReadByte(BufferData, Port);
	}

	unsigned char TempData = ReadPort(Port);

	PrintString("  ");
	PrintValue(Port);
	PrintString(": ");
	PrintValue(TempData);
	PrintStringNewLine();

}

void OutToPort(char *BufferData)
{
	BufferData = SkipSpaces(BufferData);

	unsigned char Port;

	if(*BufferData == 0)
	{
		PrintStringNewLine(F("  Port number missing"));
		return;
	}
	else
	{
		BufferData = ReadByte(BufferData, Port);
	}

	BufferData = SkipSpaces(BufferData);

	if(*BufferData == 0)
	{
		PrintStringNewLine(F("  Data Missing"));
		return;
	}

	unsigned char TempData;

	BufferData = ReadByte(BufferData, TempData);

	WritePort(Port, TempData);

	PrintString("  ");
	PrintValue(Port);
	PrintString(": ");
	PrintValue(TempData);
	PrintStringNewLine();

}

void LoadHexData(char *Buffer)
{
	PrintStringNewLine(F("  Ready for HEX data"));

	unsigned int Lines = 0;

	do
	{
		// XON
		PrintString("\x11");

		ReadLine(Buffer, 100, false);

		// XOFF
		PrintString("\x13");

		Lines++;
	} while(ProcessHexString(Buffer));

	// XON
	PrintString("\x11");

	PrintString(F(" Processed "));
	PrintValue(Lines);
	PrintStringNewLine(F(" lines of Hex data"));
}

void DownloadHexData(char *BufferData)
{
	unsigned short StartAddress = CurrentAddress;

	BufferData = SkipSpaces(BufferData);

	if(*BufferData == 0)
	{
		PrintStringNewLine(F("  Address missing (use '-' to skip)"));
		return;
	}
	else
	{
		if(*BufferData == '-')
			BufferData ++;
		else
			BufferData = ReadShort(BufferData, StartAddress);
	}

	BufferData = SkipSpaces(BufferData);

	unsigned short EndAddress;

	if(*BufferData == 0)
	{
		// Save until the end of memory
		EndAddress = 0xFFFF;
	}
	else
	{
		BufferData = ReadShort(BufferData, EndAddress);
	}

	// If the length wraps, goto EOM
	if(EndAddress < StartAddress)
		EndAddress = 0xFFFF;

    PrintString(F("  Dumping "));
    PrintValue(StartAddress);
    PrintString(F(" to "));
    PrintValue(EndAddress);
    PrintStringNewLine();

    unsigned char Data;
    unsigned char Checksum = 0;
    unsigned char LineRemaining = 0;
    for(; StartAddress <= EndAddress; StartAddress++)
    {
		if(LineRemaining == 0)
		{
			LineRemaining = 0x10;
			if(EndAddress - StartAddress < LineRemaining)
				LineRemaining = EndAddress - StartAddress +1;

			PrintString(":");
			PrintValue(LineRemaining);			// Byte Count
			PrintValue(StartAddress);			// Address
			PrintValue((unsigned char) 0x00);	// LineType

			Checksum = LineRemaining + (StartAddress & 0x00FF) + ((StartAddress & 0xFF00) >> 8) + 0x00;
		}

		Data = ReadData(StartAddress);
		PrintValue(Data);
		Checksum += Data;

		LineRemaining --;

		if(LineRemaining == 0)
		{
			PrintValue((unsigned char)(0-Checksum));
			PrintStringNewLine();
		}

		if(StartAddress == 0xFFFF && EndAddress == 0xFFFF)
			break;
	}

	PrintStringNewLine(":00000001FF");
}


void DisplayBus(char *BufferData)
{
	unsigned short Address = GetAddress();
	unsigned char Data = GetData();

	PrintString(F("  Current Bus Address: "));
	PrintValue(Address);
	PrintString(F(" Data: "));
	PrintValue(Data);
	PrintStringNewLine();
}

void FlashBus(char *BufferData)
{
	unsigned short TempAddress = CurrentAddress;

	BufferData = SkipSpaces(BufferData);

	if(*BufferData == 0)
	{
		PrintStringNewLine(F("  Address missing (use '-' to skip)"));
		return;
	}
	else
	{
		if(*BufferData == '-')
			BufferData ++;
		else
			BufferData = ReadShort(BufferData, TempAddress);
	}

	BufferData = SkipSpaces(BufferData);

	if(*BufferData == 0)
	{
		PrintStringNewLine(F("  Data Missing"));
		return;
	}

	unsigned char TempData;

	BufferData = ReadByte(BufferData, TempData);

	SetAddress(TempAddress);
	SetData(TempData);

	PrintString(F("  Flashing Address: "));
	PrintValue(Address);
	PrintString(F(" Data: "));
	PrintValue(Data);
	PrintStringNewLine();
	PrintStringNewLine("  Enter to stop");

	// Display the new values
	digitalWrite(AddressDisplay, LOW);
	digitalWrite(DataDisplay, LOW);

	ReadLine(BufferData, 1, false);

	// Clear the display
	digitalWrite(AddressDisplay, HIGH);
	digitalWrite(DataDisplay, HIGH);
}
