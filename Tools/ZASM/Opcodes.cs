namespace ZASM
{
    static class Ops
    {
        static public OpcodeEncoding[] EncodingData = new OpcodeEncoding[]
        {
            new OpcodeEncoding { Name = "ADC",	// 8E: ADC A (HL)
                                  Encoding = new byte[] { 0x8E },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.Displacement | ParamFlags.AssumeA, Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// 8F: ADC A A
                                  Encoding = new byte[] { 0x8F },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// 88: ADC A B
                                  Encoding = new byte[] { 0x88 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// 89: ADC A C
                                  Encoding = new byte[] { 0x89 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// 8A: ADC A D
                                  Encoding = new byte[] { 0x8A },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// 8B: ADC A E
                                  Encoding = new byte[] { 0x8B },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// 8C: ADC A H
                                  Encoding = new byte[] { 0x8C },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// 8D: ADC A L
                                  Encoding = new byte[] { 0x8D },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// CE: ADC A n
                                  Encoding = new byte[] { 0xCE },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// ED4A: ADC HL BC
                                  Encoding = new byte[] { 0xED, 0x4A },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.BC, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// ED5A: ADC HL DE
                                  Encoding = new byte[] { 0xED, 0x5A },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.DE, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// ED6A: ADC HL HL
                                  Encoding = new byte[] { 0xED, 0x6A },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// ED7A: ADC HL SP
                                  Encoding = new byte[] { 0xED, 0x7A },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.SP, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADD",	// 86: ADD A (HL)
                                  Encoding = new byte[] { 0x86 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.Displacement | ParamFlags.AssumeA, Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 87: ADD A A
                                  Encoding = new byte[] { 0x87 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 80: ADD A B
                                  Encoding = new byte[] { 0x80 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 81: ADD A C
                                  Encoding = new byte[] { 0x81 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 82: ADD A D
                                  Encoding = new byte[] { 0x82 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 83: ADD A E
                                  Encoding = new byte[] { 0x83 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 84: ADD A H
                                  Encoding = new byte[] { 0x84 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 85: ADD A L
                                  Encoding = new byte[] { 0x85 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// C6: ADD A n
                                  Encoding = new byte[] { 0xC6 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 09: ADD HL BC
                                  Encoding = new byte[] { 0x09 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.BC, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 19: ADD HL DE
                                  Encoding = new byte[] { 0x19 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.DE, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 29: ADD HL HL
                                  Encoding = new byte[] { 0x29 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 39: ADD HL SP
                                  Encoding = new byte[] { 0x39 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.SP, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.ADD },
            new OpcodeEncoding { Name = "AND",	// A6: AND A (HL)
                                  Encoding = new byte[] { 0xA6 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.Displacement | ParamFlags.AssumeA, Function = CommandID.AND },
            new OpcodeEncoding { Name = "AND",	// A7: AND A A
                                  Encoding = new byte[] { 0xA7 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.AND },
            new OpcodeEncoding { Name = "AND",	// A0: AND A B
                                  Encoding = new byte[] { 0xA0 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.AND },
            new OpcodeEncoding { Name = "AND",	// A1: AND A C
                                  Encoding = new byte[] { 0xA1 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.AND },
            new OpcodeEncoding { Name = "AND",	// A2: AND A D
                                  Encoding = new byte[] { 0xA2 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.AND },
            new OpcodeEncoding { Name = "AND",	// A3: AND A E
                                  Encoding = new byte[] { 0xA3 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.AND },
            new OpcodeEncoding { Name = "AND",	// A4: AND A H
                                  Encoding = new byte[] { 0xA4 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.AND },
            new OpcodeEncoding { Name = "AND",	// A5: AND A L
                                  Encoding = new byte[] { 0xA5 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.AND },
            new OpcodeEncoding { Name = "AND",	// E6: AND A n
                                  Encoding = new byte[] { 0xE6 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.AND },
            new OpcodeEncoding { Name = "BIT",	// CB46: BIT 0 (HL)
                                  Encoding = new byte[] { 0xCB, 0x46 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB41: BIT 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x41 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB47: BIT 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x47 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB46: BIT 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x46 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB45: BIT 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x45 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB44: BIT 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x44 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB43: BIT 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x43 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB42: BIT 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x42 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB40: BIT 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x40 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB47: BIT 0 A
                                  Encoding = new byte[] { 0xCB, 0x47 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB40: BIT 0 B
                                  Encoding = new byte[] { 0xCB, 0x40 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB41: BIT 0 C
                                  Encoding = new byte[] { 0xCB, 0x41 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB42: BIT 0 D
                                  Encoding = new byte[] { 0xCB, 0x42 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB43: BIT 0 E
                                  Encoding = new byte[] { 0xCB, 0x43 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB44: BIT 0 H
                                  Encoding = new byte[] { 0xCB, 0x44 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB45: BIT 0 L
                                  Encoding = new byte[] { 0xCB, 0x45 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB4E: BIT 1 (HL)
                                  Encoding = new byte[] { 0xCB, 0x4E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB48: BIT 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x48 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB4C: BIT 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x4C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB4D: BIT 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x4D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB49: BIT 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x49 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB4B: BIT 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x4B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB4F: BIT 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x4F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB4E: BIT 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x4E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB4A: BIT 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x4A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB4F: BIT 1 A
                                  Encoding = new byte[] { 0xCB, 0x4F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB48: BIT 1 B
                                  Encoding = new byte[] { 0xCB, 0x48 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB49: BIT 1 C
                                  Encoding = new byte[] { 0xCB, 0x49 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB4A: BIT 1 D
                                  Encoding = new byte[] { 0xCB, 0x4A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB4B: BIT 1 E
                                  Encoding = new byte[] { 0xCB, 0x4B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB4C: BIT 1 H
                                  Encoding = new byte[] { 0xCB, 0x4C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB4D: BIT 1 L
                                  Encoding = new byte[] { 0xCB, 0x4D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB56: BIT 2 (HL)
                                  Encoding = new byte[] { 0xCB, 0x56 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB57: BIT 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x57 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB56: BIT 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x56 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB55: BIT 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x55 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB53: BIT 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x53 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB52: BIT 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x52 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB51: BIT 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x51 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB50: BIT 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x50 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB54: BIT 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x54 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB57: BIT 2 A
                                  Encoding = new byte[] { 0xCB, 0x57 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB50: BIT 2 B
                                  Encoding = new byte[] { 0xCB, 0x50 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB51: BIT 2 C
                                  Encoding = new byte[] { 0xCB, 0x51 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB52: BIT 2 D
                                  Encoding = new byte[] { 0xCB, 0x52 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB53: BIT 2 E
                                  Encoding = new byte[] { 0xCB, 0x53 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB54: BIT 2 H
                                  Encoding = new byte[] { 0xCB, 0x54 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB55: BIT 2 L
                                  Encoding = new byte[] { 0xCB, 0x55 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB5E: BIT 3 (HL)
                                  Encoding = new byte[] { 0xCB, 0x5E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB5E: BIT 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x5E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB5D: BIT 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x5D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB5C: BIT 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x5C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB5A: BIT 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x5A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB59: BIT 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x59 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB58: BIT 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x58 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB5F: BIT 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x5F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB5B: BIT 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x5B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB5F: BIT 3 A
                                  Encoding = new byte[] { 0xCB, 0x5F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB58: BIT 3 B
                                  Encoding = new byte[] { 0xCB, 0x58 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB59: BIT 3 C
                                  Encoding = new byte[] { 0xCB, 0x59 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB5A: BIT 3 D
                                  Encoding = new byte[] { 0xCB, 0x5A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB5B: BIT 3 E
                                  Encoding = new byte[] { 0xCB, 0x5B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB5C: BIT 3 H
                                  Encoding = new byte[] { 0xCB, 0x5C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB5D: BIT 3 L
                                  Encoding = new byte[] { 0xCB, 0x5D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB66: BIT 4 (HL)
                                  Encoding = new byte[] { 0xCB, 0x66 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB67: BIT 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x67 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB66: BIT 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x66 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB65: BIT 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x65 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB64: BIT 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x64 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB63: BIT 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x63 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB62: BIT 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x62 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB61: BIT 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x61 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB60: BIT 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x60 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB67: BIT 4 A
                                  Encoding = new byte[] { 0xCB, 0x67 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB60: BIT 4 B
                                  Encoding = new byte[] { 0xCB, 0x60 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB61: BIT 4 C
                                  Encoding = new byte[] { 0xCB, 0x61 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB62: BIT 4 D
                                  Encoding = new byte[] { 0xCB, 0x62 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB63: BIT 4 E
                                  Encoding = new byte[] { 0xCB, 0x63 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB64: BIT 4 H
                                  Encoding = new byte[] { 0xCB, 0x64 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB65: BIT 4 L
                                  Encoding = new byte[] { 0xCB, 0x65 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB6E: BIT 5 (HL)
                                  Encoding = new byte[] { 0xCB, 0x6E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB68: BIT 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x68 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB6F: BIT 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x6F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB6E: BIT 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x6E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB69: BIT 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x69 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB6A: BIT 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x6A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB6D: BIT 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x6D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB6C: BIT 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x6C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB6B: BIT 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x6B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB6F: BIT 5 A
                                  Encoding = new byte[] { 0xCB, 0x6F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB68: BIT 5 B
                                  Encoding = new byte[] { 0xCB, 0x68 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB69: BIT 5 C
                                  Encoding = new byte[] { 0xCB, 0x69 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB6A: BIT 5 D
                                  Encoding = new byte[] { 0xCB, 0x6A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB6B: BIT 5 E
                                  Encoding = new byte[] { 0xCB, 0x6B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB6C: BIT 5 H
                                  Encoding = new byte[] { 0xCB, 0x6C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB6D: BIT 5 L
                                  Encoding = new byte[] { 0xCB, 0x6D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB76: BIT 6 (HL)
                                  Encoding = new byte[] { 0xCB, 0x76 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB71: BIT 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x71 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB70: BIT 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x70 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB72: BIT 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x72 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB77: BIT 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x77 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB76: BIT 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x76 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB75: BIT 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x75 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB74: BIT 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x74 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB73: BIT 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x73 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB77: BIT 6 A
                                  Encoding = new byte[] { 0xCB, 0x77 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB70: BIT 6 B
                                  Encoding = new byte[] { 0xCB, 0x70 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB71: BIT 6 C
                                  Encoding = new byte[] { 0xCB, 0x71 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB72: BIT 6 D
                                  Encoding = new byte[] { 0xCB, 0x72 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB73: BIT 6 E
                                  Encoding = new byte[] { 0xCB, 0x73 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB74: BIT 6 H
                                  Encoding = new byte[] { 0xCB, 0x74 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB75: BIT 6 L
                                  Encoding = new byte[] { 0xCB, 0x75 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB7E: BIT 7 (HL)
                                  Encoding = new byte[] { 0xCB, 0x7E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB7F: BIT 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x7F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB7C: BIT 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x7C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB7D: BIT 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x7D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB7B: BIT 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x7B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB78: BIT 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x78 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB79: BIT 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x79 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB7E: BIT 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x7E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// DDCB7A: BIT 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x7A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB7F: BIT 7 A
                                  Encoding = new byte[] { 0xCB, 0x7F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB78: BIT 7 B
                                  Encoding = new byte[] { 0xCB, 0x78 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB79: BIT 7 C
                                  Encoding = new byte[] { 0xCB, 0x79 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB7A: BIT 7 D
                                  Encoding = new byte[] { 0xCB, 0x7A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB7B: BIT 7 E
                                  Encoding = new byte[] { 0xCB, 0x7B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB7C: BIT 7 H
                                  Encoding = new byte[] { 0xCB, 0x7C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB7D: BIT 7 L
                                  Encoding = new byte[] { 0xCB, 0x7D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { Name = "CALL",	// DC: CALL CY nn
                                  Encoding = new byte[] { 0xDC },
                                  Param1 = CommandID.CY, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { Name = "CALL",	// FC: CALL M nn
                                  Encoding = new byte[] { 0xFC },
                                  Param1 = CommandID.M, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { Name = "CALL",	// D4: CALL NC nn
                                  Encoding = new byte[] { 0xD4 },
                                  Param1 = CommandID.NC, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { Name = "CALL",	// CD: CALL nn 
                                  Encoding = new byte[] { 0xCD },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParamType.Immediate,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { Name = "CALL",	// C4: CALL NZ nn
                                  Encoding = new byte[] { 0xC4 },
                                  Param1 = CommandID.NZ, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { Name = "CALL",	// F4: CALL P nn
                                  Encoding = new byte[] { 0xF4 },
                                  Param1 = CommandID.P, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { Name = "CALL",	// EC: CALL PE nn
                                  Encoding = new byte[] { 0xEC },
                                  Param1 = CommandID.PE, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { Name = "CALL",	// E4: CALL PO nn
                                  Encoding = new byte[] { 0xE4 },
                                  Param1 = CommandID.PO, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { Name = "CALL",	// CC: CALL Z nn
                                  Encoding = new byte[] { 0xCC },
                                  Param1 = CommandID.Z, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { Name = "CCF",	// 3F: CCF  
                                  Encoding = new byte[] { 0x3F },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.CCF },
            new OpcodeEncoding { Name = "CP",	// BE: CP A (HL)
                                  Encoding = new byte[] { 0xBE },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.Displacement | ParamFlags.AssumeA, Function = CommandID.CP },
            new OpcodeEncoding { Name = "CP",	// BF: CP A A
                                  Encoding = new byte[] { 0xBF },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.CP },
            new OpcodeEncoding { Name = "CP",	// B8: CP A B
                                  Encoding = new byte[] { 0xB8 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.CP },
            new OpcodeEncoding { Name = "CP",	// B9: CP A C
                                  Encoding = new byte[] { 0xB9 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.CP },
            new OpcodeEncoding { Name = "CP",	// BA: CP A D
                                  Encoding = new byte[] { 0xBA },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.CP },
            new OpcodeEncoding { Name = "CP",	// BB: CP A E
                                  Encoding = new byte[] { 0xBB },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.CP },
            new OpcodeEncoding { Name = "CP",	// BC: CP A H
                                  Encoding = new byte[] { 0xBC },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.CP },
            new OpcodeEncoding { Name = "CP",	// BD: CP A L
                                  Encoding = new byte[] { 0xBD },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.CP },
            new OpcodeEncoding { Name = "CP",	// FE: CP A n
                                  Encoding = new byte[] { 0xFE },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.CP },
            new OpcodeEncoding { Name = "CPD",	// EDA9: CPD  
                                  Encoding = new byte[] { 0xED, 0xA9 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.CPD },
            new OpcodeEncoding { Name = "CPDR",	// EDB9: CPDR  
                                  Encoding = new byte[] { 0xED, 0xB9 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.CPDR },
            new OpcodeEncoding { Name = "CPI",	// EDA1: CPI  
                                  Encoding = new byte[] { 0xED, 0xA1 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.CPI },
            new OpcodeEncoding { Name = "CPIR",	// EDB1: CPIR  
                                  Encoding = new byte[] { 0xED, 0xB1 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.CPIR },
            new OpcodeEncoding { Name = "CPL",	// 2F: CPL  
                                  Encoding = new byte[] { 0x2F },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.CPL },
            new OpcodeEncoding { Name = "DAA",	// 27: DAA  
                                  Encoding = new byte[] { 0x27 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DAA },
            new OpcodeEncoding { Name = "DEC",	// 35: DEC (HL) 
                                  Encoding = new byte[] { 0x35 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.Displacement, Function = CommandID.DEC },
            new OpcodeEncoding { Name = "DEC",	// 3D: DEC A 
                                  Encoding = new byte[] { 0x3D },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { Name = "DEC",	// 05: DEC B 
                                  Encoding = new byte[] { 0x05 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { Name = "DEC",	// 0B: DEC BC 
                                  Encoding = new byte[] { 0x0B },
                                  Param1 = CommandID.BC, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { Name = "DEC",	// 0D: DEC C 
                                  Encoding = new byte[] { 0x0D },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { Name = "DEC",	// 15: DEC D 
                                  Encoding = new byte[] { 0x15 },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { Name = "DEC",	// 1B: DEC DE 
                                  Encoding = new byte[] { 0x1B },
                                  Param1 = CommandID.DE, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { Name = "DEC",	// 1D: DEC E 
                                  Encoding = new byte[] { 0x1D },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { Name = "DEC",	// 25: DEC H 
                                  Encoding = new byte[] { 0x25 },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { Name = "DEC",	// 2B: DEC HL 
                                  Encoding = new byte[] { 0x2B },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.DEC },
            new OpcodeEncoding { Name = "DEC",	// 2D: DEC L 
                                  Encoding = new byte[] { 0x2D },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { Name = "DEC",	// 3B: DEC SP 
                                  Encoding = new byte[] { 0x3B },
                                  Param1 = CommandID.SP, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { Name = "DI",	// F3: DI  
                                  Encoding = new byte[] { 0xF3 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DI },
            new OpcodeEncoding { Name = "DJNZ",	// 10: DJNZ e-2 
                                  Encoding = new byte[] { 0x10 },
                                  Param1 = CommandID.ImmediateByte, Param1Type = ParamType.Immediate,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DJNZ },
            new OpcodeEncoding { Name = "EI",	// FB: EI  
                                  Encoding = new byte[] { 0xFB },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.EI },
            new OpcodeEncoding { Name = "EX",	// E3: EX (SP) HL
                                  Encoding = new byte[] { 0xE3 },
                                  Param1 = CommandID.SP, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.EX },
            new OpcodeEncoding { Name = "EX",	// 08: EX AF AF
                                  Encoding = new byte[] { 0x08 },
                                  Param1 = CommandID.AF, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.AF, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.EX },
            new OpcodeEncoding { Name = "EX",	// EB: EX DE HL
                                  Encoding = new byte[] { 0xEB },
                                  Param1 = CommandID.DE, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.EX },
            new OpcodeEncoding { Name = "EXX",	// D9: EXX  
                                  Encoding = new byte[] { 0xD9 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.EXX },
            new OpcodeEncoding { Name = "HALT",	// 76: HALT  
                                  Encoding = new byte[] { 0x76 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.HALT },
            new OpcodeEncoding { Name = "IM",	// ED46: IM 0 
                                  Encoding = new byte[] { 0xED, 0x46 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IM },
            new OpcodeEncoding { Name = "IM",	// ED6E: IM 0 
                                  Encoding = new byte[] { 0xED, 0x6E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IM },
            new OpcodeEncoding { Name = "IM",	// ED66: IM 0 
                                  Encoding = new byte[] { 0xED, 0x66 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IM },
            new OpcodeEncoding { Name = "IM",	// ED4E: IM 0 
                                  Encoding = new byte[] { 0xED, 0x4E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IM },
            new OpcodeEncoding { Name = "IM",	// ED56: IM 1 
                                  Encoding = new byte[] { 0xED, 0x56 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IM },
            new OpcodeEncoding { Name = "IM",	// ED76: IM 1 
                                  Encoding = new byte[] { 0xED, 0x76 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IM },
            new OpcodeEncoding { Name = "IM",	// ED7E: IM 2 
                                  Encoding = new byte[] { 0xED, 0x7E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IM },
            new OpcodeEncoding { Name = "IM",	// ED5E: IM 2 
                                  Encoding = new byte[] { 0xED, 0x5E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IM },
            new OpcodeEncoding { Name = "IN",	// ED70: IN (C) 
                                  Encoding = new byte[] { 0xED, 0x70 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { Name = "IN",	// ED78: IN A (C)
                                  Encoding = new byte[] { 0xED, 0x78 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { Name = "IN",	// DB: IN A (n)
                                  Encoding = new byte[] { 0xDB },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.IN },
            new OpcodeEncoding { Name = "IN",	// ED40: IN B (C)
                                  Encoding = new byte[] { 0xED, 0x40 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { Name = "IN",	// ED48: IN C (C)
                                  Encoding = new byte[] { 0xED, 0x48 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { Name = "IN",	// ED50: IN D (C)
                                  Encoding = new byte[] { 0xED, 0x50 },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { Name = "IN",	// ED58: IN E (C)
                                  Encoding = new byte[] { 0xED, 0x58 },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { Name = "IN",	// ED60: IN H (C)
                                  Encoding = new byte[] { 0xED, 0x60 },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { Name = "IN",	// ED68: IN L (C)
                                  Encoding = new byte[] { 0xED, 0x68 },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { Name = "INC",	// 34: INC (HL) 
                                  Encoding = new byte[] { 0x34 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.Displacement, Function = CommandID.INC },
            new OpcodeEncoding { Name = "INC",	// 3C: INC A 
                                  Encoding = new byte[] { 0x3C },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { Name = "INC",	// 04: INC B 
                                  Encoding = new byte[] { 0x04 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { Name = "INC",	// 03: INC BC 
                                  Encoding = new byte[] { 0x03 },
                                  Param1 = CommandID.BC, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { Name = "INC",	// 0C: INC C 
                                  Encoding = new byte[] { 0x0C },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { Name = "INC",	// 14: INC D 
                                  Encoding = new byte[] { 0x14 },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { Name = "INC",	// 13: INC DE 
                                  Encoding = new byte[] { 0x13 },
                                  Param1 = CommandID.DE, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { Name = "INC",	// 1C: INC E 
                                  Encoding = new byte[] { 0x1C },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { Name = "INC",	// 24: INC H 
                                  Encoding = new byte[] { 0x24 },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { Name = "INC",	// 23: INC HL 
                                  Encoding = new byte[] { 0x23 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.INC },
            new OpcodeEncoding { Name = "INC",	// 2C: INC L 
                                  Encoding = new byte[] { 0x2C },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { Name = "INC",	// 33: INC SP 
                                  Encoding = new byte[] { 0x33 },
                                  Param1 = CommandID.SP, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { Name = "IND",	// EDAA: IND  
                                  Encoding = new byte[] { 0xED, 0xAA },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IND },
            new OpcodeEncoding { Name = "INDR",	// EDBA: INDR  
                                  Encoding = new byte[] { 0xED, 0xBA },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INDR },
            new OpcodeEncoding { Name = "INI",	// EDA2: INI  
                                  Encoding = new byte[] { 0xED, 0xA2 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INI },
            new OpcodeEncoding { Name = "INIR",	// EDB2: INIR  
                                  Encoding = new byte[] { 0xED, 0xB2 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INIR },
            new OpcodeEncoding { Name = "JP",	// E9: JP (HL) 
                                  Encoding = new byte[] { 0xE9 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.JP },
            new OpcodeEncoding { Name = "JP",	// DA: JP CY nn
                                  Encoding = new byte[] { 0xDA },
                                  Param1 = CommandID.CY, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { Name = "JP",	// FA: JP M nn
                                  Encoding = new byte[] { 0xFA },
                                  Param1 = CommandID.M, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { Name = "JP",	// D2: JP NC nn
                                  Encoding = new byte[] { 0xD2 },
                                  Param1 = CommandID.NC, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { Name = "JP",	// C3: JP nn 
                                  Encoding = new byte[] { 0xC3 },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParamType.Immediate,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { Name = "JP",	// C2: JP NZ nn
                                  Encoding = new byte[] { 0xC2 },
                                  Param1 = CommandID.NZ, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { Name = "JP",	// F2: JP P nn
                                  Encoding = new byte[] { 0xF2 },
                                  Param1 = CommandID.P, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { Name = "JP",	// EA: JP PE nn
                                  Encoding = new byte[] { 0xEA },
                                  Param1 = CommandID.PE, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { Name = "JP",	// E2: JP PO nn
                                  Encoding = new byte[] { 0xE2 },
                                  Param1 = CommandID.PO, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { Name = "JP",	// CA: JP Z nn
                                  Encoding = new byte[] { 0xCA },
                                  Param1 = CommandID.Z, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { Name = "JR",	// 38: JR CY e-2
                                  Encoding = new byte[] { 0x38 },
                                  Param1 = CommandID.CY, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JR },
            new OpcodeEncoding { Name = "JR",	// 18: JR e-2 
                                  Encoding = new byte[] { 0x18 },
                                  Param1 = CommandID.ImmediateByte, Param1Type = ParamType.Immediate,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.JR },
            new OpcodeEncoding { Name = "JR",	// 30: JR NC e-2
                                  Encoding = new byte[] { 0x30 },
                                  Param1 = CommandID.NC, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JR },
            new OpcodeEncoding { Name = "JR",	// 20: JR NZ e-2
                                  Encoding = new byte[] { 0x20 },
                                  Param1 = CommandID.NZ, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JR },
            new OpcodeEncoding { Name = "JR",	// 28: JR Z e-2
                                  Encoding = new byte[] { 0x28 },
                                  Param1 = CommandID.Z, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JR },
            new OpcodeEncoding { Name = "LD",	// 02: LD (BC) A
                                  Encoding = new byte[] { 0x02 },
                                  Param1 = CommandID.BC, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 12: LD (DE) A
                                  Encoding = new byte[] { 0x12 },
                                  Param1 = CommandID.DE, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 77: LD (HL) A
                                  Encoding = new byte[] { 0x77 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 70: LD (HL) B
                                  Encoding = new byte[] { 0x70 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 71: LD (HL) C
                                  Encoding = new byte[] { 0x71 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 72: LD (HL) D
                                  Encoding = new byte[] { 0x72 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 73: LD (HL) E
                                  Encoding = new byte[] { 0x73 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 74: LD (HL) H
                                  Encoding = new byte[] { 0x74 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 75: LD (HL) L
                                  Encoding = new byte[] { 0x75 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 36: LD (HL) n
                                  Encoding = new byte[] { 0x36 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 32: LD (nn) A
                                  Encoding = new byte[] { 0x32 },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParamType.ImmediatePtr,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// ED43: LD (nn) BC
                                  Encoding = new byte[] { 0xED, 0x43 },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParamType.ImmediatePtr,
                                  Param2 = CommandID.BC, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// ED53: LD (nn) DE
                                  Encoding = new byte[] { 0xED, 0x53 },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParamType.ImmediatePtr,
                                  Param2 = CommandID.DE, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// ED63: LD (nn) HL
                                  Encoding = new byte[] { 0xED, 0x63 },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParamType.ImmediatePtr,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 22: LD (nn) HL
                                  Encoding = new byte[] { 0x22 },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParamType.ImmediatePtr,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// ED73: LD (nn) SP
                                  Encoding = new byte[] { 0xED, 0x73 },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParamType.ImmediatePtr,
                                  Param2 = CommandID.SP, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 0A: LD A (BC)
                                  Encoding = new byte[] { 0x0A },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.BC, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 1A: LD A (DE)
                                  Encoding = new byte[] { 0x1A },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.DE, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 7E: LD A (HL)
                                  Encoding = new byte[] { 0x7E },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 3A: LD A (nn)
                                  Encoding = new byte[] { 0x3A },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.ImmediatePtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 7F: LD A A
                                  Encoding = new byte[] { 0x7F },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 78: LD A B
                                  Encoding = new byte[] { 0x78 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 79: LD A C
                                  Encoding = new byte[] { 0x79 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 7A: LD A D
                                  Encoding = new byte[] { 0x7A },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 7B: LD A E
                                  Encoding = new byte[] { 0x7B },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 7C: LD A H
                                  Encoding = new byte[] { 0x7C },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// ED57: LD A I
                                  Encoding = new byte[] { 0xED, 0x57 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.I, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 7D: LD A L
                                  Encoding = new byte[] { 0x7D },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 3E: LD A n
                                  Encoding = new byte[] { 0x3E },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// ED5F: LD A R
                                  Encoding = new byte[] { 0xED, 0x5F },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.R, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 46: LD B (HL)
                                  Encoding = new byte[] { 0x46 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 47: LD B A
                                  Encoding = new byte[] { 0x47 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 40: LD B B
                                  Encoding = new byte[] { 0x40 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 41: LD B C
                                  Encoding = new byte[] { 0x41 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 42: LD B D
                                  Encoding = new byte[] { 0x42 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 43: LD B E
                                  Encoding = new byte[] { 0x43 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 44: LD B H
                                  Encoding = new byte[] { 0x44 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 45: LD B L
                                  Encoding = new byte[] { 0x45 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 06: LD B n
                                  Encoding = new byte[] { 0x06 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// ED4B: LD BC (nn)
                                  Encoding = new byte[] { 0xED, 0x4B },
                                  Param1 = CommandID.BC, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.ImmediatePtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 01: LD BC nn
                                  Encoding = new byte[] { 0x01 },
                                  Param1 = CommandID.BC, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 4E: LD C (HL)
                                  Encoding = new byte[] { 0x4E },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 4F: LD C A
                                  Encoding = new byte[] { 0x4F },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 48: LD C B
                                  Encoding = new byte[] { 0x48 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 49: LD C C
                                  Encoding = new byte[] { 0x49 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 4A: LD C D
                                  Encoding = new byte[] { 0x4A },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 4B: LD C E
                                  Encoding = new byte[] { 0x4B },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 4C: LD C H
                                  Encoding = new byte[] { 0x4C },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 4D: LD C L
                                  Encoding = new byte[] { 0x4D },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 0E: LD C n
                                  Encoding = new byte[] { 0x0E },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 56: LD D (HL)
                                  Encoding = new byte[] { 0x56 },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 57: LD D A
                                  Encoding = new byte[] { 0x57 },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 50: LD D B
                                  Encoding = new byte[] { 0x50 },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 51: LD D C
                                  Encoding = new byte[] { 0x51 },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 52: LD D D
                                  Encoding = new byte[] { 0x52 },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 53: LD D E
                                  Encoding = new byte[] { 0x53 },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 54: LD D H
                                  Encoding = new byte[] { 0x54 },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 55: LD D L
                                  Encoding = new byte[] { 0x55 },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 16: LD D n
                                  Encoding = new byte[] { 0x16 },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// ED5B: LD DE (nn)
                                  Encoding = new byte[] { 0xED, 0x5B },
                                  Param1 = CommandID.DE, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.ImmediatePtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 11: LD DE nn
                                  Encoding = new byte[] { 0x11 },
                                  Param1 = CommandID.DE, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 5E: LD E (HL)
                                  Encoding = new byte[] { 0x5E },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 5F: LD E A
                                  Encoding = new byte[] { 0x5F },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 58: LD E B
                                  Encoding = new byte[] { 0x58 },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 59: LD E C
                                  Encoding = new byte[] { 0x59 },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 5A: LD E D
                                  Encoding = new byte[] { 0x5A },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 5B: LD E E
                                  Encoding = new byte[] { 0x5B },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 5C: LD E H
                                  Encoding = new byte[] { 0x5C },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 5D: LD E L
                                  Encoding = new byte[] { 0x5D },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 1E: LD E n
                                  Encoding = new byte[] { 0x1E },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 66: LD H (HL)
                                  Encoding = new byte[] { 0x66 },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 67: LD H A
                                  Encoding = new byte[] { 0x67 },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 60: LD H B
                                  Encoding = new byte[] { 0x60 },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 61: LD H C
                                  Encoding = new byte[] { 0x61 },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 62: LD H D
                                  Encoding = new byte[] { 0x62 },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 63: LD H E
                                  Encoding = new byte[] { 0x63 },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 64: LD H H
                                  Encoding = new byte[] { 0x64 },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 65: LD H L
                                  Encoding = new byte[] { 0x65 },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 26: LD H n
                                  Encoding = new byte[] { 0x26 },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 2A: LD HL (nn)
                                  Encoding = new byte[] { 0x2A },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.ImmediatePtr,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// ED6B: LD HL (nn)
                                  Encoding = new byte[] { 0xED, 0x6B },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.ImmediatePtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 21: LD HL nn
                                  Encoding = new byte[] { 0x21 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// ED47: LD I A
                                  Encoding = new byte[] { 0xED, 0x47 },
                                  Param1 = CommandID.I, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 6E: LD L (HL)
                                  Encoding = new byte[] { 0x6E },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 6F: LD L A
                                  Encoding = new byte[] { 0x6F },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 68: LD L B
                                  Encoding = new byte[] { 0x68 },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 69: LD L C
                                  Encoding = new byte[] { 0x69 },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 6A: LD L D
                                  Encoding = new byte[] { 0x6A },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 6B: LD L E
                                  Encoding = new byte[] { 0x6B },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 6C: LD L H
                                  Encoding = new byte[] { 0x6C },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 6D: LD L L
                                  Encoding = new byte[] { 0x6D },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 2E: LD L n
                                  Encoding = new byte[] { 0x2E },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// ED4F: LD R A
                                  Encoding = new byte[] { 0xED, 0x4F },
                                  Param1 = CommandID.R, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// ED7B: LD SP (nn)
                                  Encoding = new byte[] { 0xED, 0x7B },
                                  Param1 = CommandID.SP, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.ImmediatePtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// F9: LD SP HL
                                  Encoding = new byte[] { 0xF9 },
                                  Param1 = CommandID.SP, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 31: LD SP nn
                                  Encoding = new byte[] { 0x31 },
                                  Param1 = CommandID.SP, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { Name = "LDD",	// EDA8: LDD  
                                  Encoding = new byte[] { 0xED, 0xA8 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.LDD },
            new OpcodeEncoding { Name = "LDDR",	// EDB8: LDDR  
                                  Encoding = new byte[] { 0xED, 0xB8 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.LDDR },
            new OpcodeEncoding { Name = "LDI",	// EDA0: LDI  
                                  Encoding = new byte[] { 0xED, 0xA0 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.LDI },
            new OpcodeEncoding { Name = "LDIR",	// EDB0: LDIR  
                                  Encoding = new byte[] { 0xED, 0xB0 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.LDIR },
            new OpcodeEncoding { Name = "NEG",	// ED54: NEG  
                                  Encoding = new byte[] { 0xED, 0x54 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NEG },
            new OpcodeEncoding { Name = "NEG",	// ED74: NEG  
                                  Encoding = new byte[] { 0xED, 0x74 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NEG },
            new OpcodeEncoding { Name = "NEG",	// ED6C: NEG  
                                  Encoding = new byte[] { 0xED, 0x6C },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NEG },
            new OpcodeEncoding { Name = "NEG",	// ED7C: NEG  
                                  Encoding = new byte[] { 0xED, 0x7C },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NEG },
            new OpcodeEncoding { Name = "NEG",	// ED5C: NEG  
                                  Encoding = new byte[] { 0xED, 0x5C },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NEG },
            new OpcodeEncoding { Name = "NEG",	// ED44: NEG  
                                  Encoding = new byte[] { 0xED, 0x44 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NEG },
            new OpcodeEncoding { Name = "NEG",	// ED64: NEG  
                                  Encoding = new byte[] { 0xED, 0x64 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NEG },
            new OpcodeEncoding { Name = "NEG",	// ED4C: NEG  
                                  Encoding = new byte[] { 0xED, 0x4C },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NEG },
            new OpcodeEncoding { Name = "NOP",	// 00: NOP  
                                  Encoding = new byte[] { 0x00 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NOP },
            new OpcodeEncoding { Name = "OR",	// B6: OR A (HL)
                                  Encoding = new byte[] { 0xB6 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.Displacement | ParamFlags.AssumeA, Function = CommandID.OR },
            new OpcodeEncoding { Name = "OR",	// B7: OR A A
                                  Encoding = new byte[] { 0xB7 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.OR },
            new OpcodeEncoding { Name = "OR",	// B0: OR A B
                                  Encoding = new byte[] { 0xB0 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.OR },
            new OpcodeEncoding { Name = "OR",	// B1: OR A C
                                  Encoding = new byte[] { 0xB1 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.OR },
            new OpcodeEncoding { Name = "OR",	// B2: OR A D
                                  Encoding = new byte[] { 0xB2 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.OR },
            new OpcodeEncoding { Name = "OR",	// B3: OR A E
                                  Encoding = new byte[] { 0xB3 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.OR },
            new OpcodeEncoding { Name = "OR",	// B4: OR A H
                                  Encoding = new byte[] { 0xB4 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.OR },
            new OpcodeEncoding { Name = "OR",	// B5: OR A L
                                  Encoding = new byte[] { 0xB5 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.OR },
            new OpcodeEncoding { Name = "OR",	// F6: OR A n
                                  Encoding = new byte[] { 0xF6 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.OR },
            new OpcodeEncoding { Name = "OTDR",	// EDBB: OTDR  
                                  Encoding = new byte[] { 0xED, 0xBB },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.OTDR },
            new OpcodeEncoding { Name = "OTIR",	// EDB3: OTIR  
                                  Encoding = new byte[] { 0xED, 0xB3 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.OTIR },
            new OpcodeEncoding { Name = "OUT",	// ED71: OUT (C) 0
                                  Encoding = new byte[] { 0xED, 0x71 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = (CommandID)((int)CommandID.Encoded + 0), Param2Type = ParamType.Encoded,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { Name = "OUT",	// ED79: OUT (C) A
                                  Encoding = new byte[] { 0xED, 0x79 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { Name = "OUT",	// ED41: OUT (C) B
                                  Encoding = new byte[] { 0xED, 0x41 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { Name = "OUT",	// ED49: OUT (C) C
                                  Encoding = new byte[] { 0xED, 0x49 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { Name = "OUT",	// ED51: OUT (C) D
                                  Encoding = new byte[] { 0xED, 0x51 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { Name = "OUT",	// ED59: OUT (C) E
                                  Encoding = new byte[] { 0xED, 0x59 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { Name = "OUT",	// ED61: OUT (C) H
                                  Encoding = new byte[] { 0xED, 0x61 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { Name = "OUT",	// ED69: OUT (C) L
                                  Encoding = new byte[] { 0xED, 0x69 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { Name = "OUT",	// D3: OUT (n) A
                                  Encoding = new byte[] { 0xD3 },
                                  Param1 = CommandID.ImmediateByte, Param1Type = ParamType.Immediate,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.OUT },
            new OpcodeEncoding { Name = "OUTD",	// EDAB: OUTD  
                                  Encoding = new byte[] { 0xED, 0xAB },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.OUTD },
            new OpcodeEncoding { Name = "OUTI",	// EDA3: OUTI  
                                  Encoding = new byte[] { 0xED, 0xA3 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.OUTI },
            new OpcodeEncoding { Name = "POP",	// F1: POP AF 
                                  Encoding = new byte[] { 0xF1 },
                                  Param1 = CommandID.AF, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.POP },
            new OpcodeEncoding { Name = "POP",	// C1: POP BC 
                                  Encoding = new byte[] { 0xC1 },
                                  Param1 = CommandID.BC, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.POP },
            new OpcodeEncoding { Name = "POP",	// D1: POP DE 
                                  Encoding = new byte[] { 0xD1 },
                                  Param1 = CommandID.DE, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.POP },
            new OpcodeEncoding { Name = "POP",	// E1: POP HL 
                                  Encoding = new byte[] { 0xE1 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.POP },
            new OpcodeEncoding { Name = "PUSH",	// F5: PUSH AF 
                                  Encoding = new byte[] { 0xF5 },
                                  Param1 = CommandID.AF, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.PUSH },
            new OpcodeEncoding { Name = "PUSH",	// C5: PUSH BC 
                                  Encoding = new byte[] { 0xC5 },
                                  Param1 = CommandID.BC, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.PUSH },
            new OpcodeEncoding { Name = "PUSH",	// D5: PUSH DE 
                                  Encoding = new byte[] { 0xD5 },
                                  Param1 = CommandID.DE, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.PUSH },
            new OpcodeEncoding { Name = "PUSH",	// E5: PUSH HL 
                                  Encoding = new byte[] { 0xE5 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.PUSH },
            new OpcodeEncoding { Name = "RES",	// CB86: RES 0 (HL)
                                  Encoding = new byte[] { 0xCB, 0x86 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB83: RES 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x83 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB82: RES 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x82 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB81: RES 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x81 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB87: RES 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x87 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB80: RES 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x80 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB86: RES 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x86 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB85: RES 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x85 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB84: RES 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x84 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB87: RES 0 A
                                  Encoding = new byte[] { 0xCB, 0x87 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB80: RES 0 B
                                  Encoding = new byte[] { 0xCB, 0x80 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB81: RES 0 C
                                  Encoding = new byte[] { 0xCB, 0x81 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB82: RES 0 D
                                  Encoding = new byte[] { 0xCB, 0x82 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB83: RES 0 E
                                  Encoding = new byte[] { 0xCB, 0x83 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB84: RES 0 H
                                  Encoding = new byte[] { 0xCB, 0x84 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB85: RES 0 L
                                  Encoding = new byte[] { 0xCB, 0x85 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB8E: RES 1 (HL)
                                  Encoding = new byte[] { 0xCB, 0x8E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB8A: RES 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x8A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB8B: RES 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x8B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB8D: RES 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x8D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB8F: RES 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x8F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB8E: RES 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x8E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB88: RES 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x88 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB89: RES 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x89 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB8C: RES 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x8C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB8F: RES 1 A
                                  Encoding = new byte[] { 0xCB, 0x8F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB88: RES 1 B
                                  Encoding = new byte[] { 0xCB, 0x88 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB89: RES 1 C
                                  Encoding = new byte[] { 0xCB, 0x89 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB8A: RES 1 D
                                  Encoding = new byte[] { 0xCB, 0x8A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB8B: RES 1 E
                                  Encoding = new byte[] { 0xCB, 0x8B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB8C: RES 1 H
                                  Encoding = new byte[] { 0xCB, 0x8C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB8D: RES 1 L
                                  Encoding = new byte[] { 0xCB, 0x8D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB96: RES 2 (HL)
                                  Encoding = new byte[] { 0xCB, 0x96 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB90: RES 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x90 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB91: RES 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x91 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB92: RES 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x92 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB93: RES 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x93 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB97: RES 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x97 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB96: RES 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x96 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB95: RES 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x95 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB94: RES 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x94 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB97: RES 2 A
                                  Encoding = new byte[] { 0xCB, 0x97 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB90: RES 2 B
                                  Encoding = new byte[] { 0xCB, 0x90 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB91: RES 2 C
                                  Encoding = new byte[] { 0xCB, 0x91 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB92: RES 2 D
                                  Encoding = new byte[] { 0xCB, 0x92 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB93: RES 2 E
                                  Encoding = new byte[] { 0xCB, 0x93 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB94: RES 2 H
                                  Encoding = new byte[] { 0xCB, 0x94 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB95: RES 2 L
                                  Encoding = new byte[] { 0xCB, 0x95 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB9E: RES 3 (HL)
                                  Encoding = new byte[] { 0xCB, 0x9E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB98: RES 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x98 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB9F: RES 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x9F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB9E: RES 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x9E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB9D: RES 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x9D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB9C: RES 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x9C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB9B: RES 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x9B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB9A: RES 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x9A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCB99: RES 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x99 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB9F: RES 3 A
                                  Encoding = new byte[] { 0xCB, 0x9F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB98: RES 3 B
                                  Encoding = new byte[] { 0xCB, 0x98 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB99: RES 3 C
                                  Encoding = new byte[] { 0xCB, 0x99 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB9A: RES 3 D
                                  Encoding = new byte[] { 0xCB, 0x9A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB9B: RES 3 E
                                  Encoding = new byte[] { 0xCB, 0x9B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB9C: RES 3 H
                                  Encoding = new byte[] { 0xCB, 0x9C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB9D: RES 3 L
                                  Encoding = new byte[] { 0xCB, 0x9D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA6: RES 4 (HL)
                                  Encoding = new byte[] { 0xCB, 0xA6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBA7: RES 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBA6: RES 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBA5: RES 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBA4: RES 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBA3: RES 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBA2: RES 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBA0: RES 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBA1: RES 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA7: RES 4 A
                                  Encoding = new byte[] { 0xCB, 0xA7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA0: RES 4 B
                                  Encoding = new byte[] { 0xCB, 0xA0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA1: RES 4 C
                                  Encoding = new byte[] { 0xCB, 0xA1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA2: RES 4 D
                                  Encoding = new byte[] { 0xCB, 0xA2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA3: RES 4 E
                                  Encoding = new byte[] { 0xCB, 0xA3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA4: RES 4 H
                                  Encoding = new byte[] { 0xCB, 0xA4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA5: RES 4 L
                                  Encoding = new byte[] { 0xCB, 0xA5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBAE: RES 5 (HL)
                                  Encoding = new byte[] { 0xCB, 0xAE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBAE: RES 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xAE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBA8: RES 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBA9: RES 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBAA: RES 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xAA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBAB: RES 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xAB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBAD: RES 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xAD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBAF: RES 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xAF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBAC: RES 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xAC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBAF: RES 5 A
                                  Encoding = new byte[] { 0xCB, 0xAF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA8: RES 5 B
                                  Encoding = new byte[] { 0xCB, 0xA8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA9: RES 5 C
                                  Encoding = new byte[] { 0xCB, 0xA9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBAA: RES 5 D
                                  Encoding = new byte[] { 0xCB, 0xAA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBAB: RES 5 E
                                  Encoding = new byte[] { 0xCB, 0xAB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBAC: RES 5 H
                                  Encoding = new byte[] { 0xCB, 0xAC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBAD: RES 5 L
                                  Encoding = new byte[] { 0xCB, 0xAD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB6: RES 6 (HL)
                                  Encoding = new byte[] { 0xCB, 0xB6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBB4: RES 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBB3: RES 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBB2: RES 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBB1: RES 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBB0: RES 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBB5: RES 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBB6: RES 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBB7: RES 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB7: RES 6 A
                                  Encoding = new byte[] { 0xCB, 0xB7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB0: RES 6 B
                                  Encoding = new byte[] { 0xCB, 0xB0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB1: RES 6 C
                                  Encoding = new byte[] { 0xCB, 0xB1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB2: RES 6 D
                                  Encoding = new byte[] { 0xCB, 0xB2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB3: RES 6 E
                                  Encoding = new byte[] { 0xCB, 0xB3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB4: RES 6 H
                                  Encoding = new byte[] { 0xCB, 0xB4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB5: RES 6 L
                                  Encoding = new byte[] { 0xCB, 0xB5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBBE: RES 7 (HL)
                                  Encoding = new byte[] { 0xCB, 0xBE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBBA: RES 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xBA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBB8: RES 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBBF: RES 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xBF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBBE: RES 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xBE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBBD: RES 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xBD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBBC: RES 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xBC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBBB: RES 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xBB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// DDCBB9: RES 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBBF: RES 7 A
                                  Encoding = new byte[] { 0xCB, 0xBF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB8: RES 7 B
                                  Encoding = new byte[] { 0xCB, 0xB8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB9: RES 7 C
                                  Encoding = new byte[] { 0xCB, 0xB9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBBA: RES 7 D
                                  Encoding = new byte[] { 0xCB, 0xBA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBBB: RES 7 E
                                  Encoding = new byte[] { 0xCB, 0xBB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBBC: RES 7 H
                                  Encoding = new byte[] { 0xCB, 0xBC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBBD: RES 7 L
                                  Encoding = new byte[] { 0xCB, 0xBD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { Name = "RET",	// C9: RET  
                                  Encoding = new byte[] { 0xC9 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { Name = "RET",	// D8: RET CY 
                                  Encoding = new byte[] { 0xD8 },
                                  Param1 = CommandID.CY, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { Name = "RET",	// F8: RET M 
                                  Encoding = new byte[] { 0xF8 },
                                  Param1 = CommandID.M, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { Name = "RET",	// D0: RET NC 
                                  Encoding = new byte[] { 0xD0 },
                                  Param1 = CommandID.NC, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { Name = "RET",	// C0: RET NZ 
                                  Encoding = new byte[] { 0xC0 },
                                  Param1 = CommandID.NZ, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { Name = "RET",	// F0: RET P 
                                  Encoding = new byte[] { 0xF0 },
                                  Param1 = CommandID.P, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { Name = "RET",	// E8: RET PE 
                                  Encoding = new byte[] { 0xE8 },
                                  Param1 = CommandID.PE, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { Name = "RET",	// E0: RET PO 
                                  Encoding = new byte[] { 0xE0 },
                                  Param1 = CommandID.PO, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { Name = "RET",	// C8: RET Z 
                                  Encoding = new byte[] { 0xC8 },
                                  Param1 = CommandID.Z, Param1Type = ParamType.Conditional,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { Name = "RETI",	// ED4D: RETI  
                                  Encoding = new byte[] { 0xED, 0x4D },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RETI },
            new OpcodeEncoding { Name = "RETN",	// ED45: RETN  
                                  Encoding = new byte[] { 0xED, 0x45 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RETN },
            new OpcodeEncoding { Name = "RETN",	// ED65: RETN  
                                  Encoding = new byte[] { 0xED, 0x65 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RETN },
            new OpcodeEncoding { Name = "RETN",	// ED55: RETN  
                                  Encoding = new byte[] { 0xED, 0x55 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RETN },
            new OpcodeEncoding { Name = "RETN",	// ED75: RETN  
                                  Encoding = new byte[] { 0xED, 0x75 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RETN },
            new OpcodeEncoding { Name = "RETN",	// ED5D: RETN  
                                  Encoding = new byte[] { 0xED, 0x5D },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RETN },
            new OpcodeEncoding { Name = "RETN",	// ED7D: RETN  
                                  Encoding = new byte[] { 0xED, 0x7D },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RETN },
            new OpcodeEncoding { Name = "RETN",	// ED6D: RETN  
                                  Encoding = new byte[] { 0xED, 0x6D },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RETN },
            new OpcodeEncoding { Name = "RL",	// CB16: RL (HL) 
                                  Encoding = new byte[] { 0xCB, 0x16 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// DDCB16: RL (IX) 
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x16 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// DDCB17: RL (IX) A
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x17 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// DDCB10: RL (IX) B
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x10 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// DDCB11: RL (IX) C
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x11 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// DDCB12: RL (IX) D
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x12 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// DDCB13: RL (IX) E
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x13 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// DDCB14: RL (IX) H
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x14 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// DDCB15: RL (IX) L
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x15 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// CB17: RL A 
                                  Encoding = new byte[] { 0xCB, 0x17 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// CB10: RL B 
                                  Encoding = new byte[] { 0xCB, 0x10 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// CB11: RL C 
                                  Encoding = new byte[] { 0xCB, 0x11 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// CB12: RL D 
                                  Encoding = new byte[] { 0xCB, 0x12 },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// CB13: RL E 
                                  Encoding = new byte[] { 0xCB, 0x13 },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// CB14: RL H 
                                  Encoding = new byte[] { 0xCB, 0x14 },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// CB15: RL L 
                                  Encoding = new byte[] { 0xCB, 0x15 },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RL },
            new OpcodeEncoding { Name = "RLA",	// 17: RLA  
                                  Encoding = new byte[] { 0x17 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLA },
            new OpcodeEncoding { Name = "RLC",	// CB06: RLC (HL) 
                                  Encoding = new byte[] { 0xCB, 0x06 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// DDCB06: RLC (IX) 
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x06 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// DDCB07: RLC (IX) A
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x07 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// DDCB00: RLC (IX) B
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x00 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// DDCB01: RLC (IX) C
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x01 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// DDCB02: RLC (IX) D
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x02 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// DDCB03: RLC (IX) E
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x03 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// DDCB04: RLC (IX) H
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x04 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// DDCB05: RLC (IX) L
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x05 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// CB07: RLC A 
                                  Encoding = new byte[] { 0xCB, 0x07 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// CB00: RLC B 
                                  Encoding = new byte[] { 0xCB, 0x00 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// CB01: RLC C 
                                  Encoding = new byte[] { 0xCB, 0x01 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// CB02: RLC D 
                                  Encoding = new byte[] { 0xCB, 0x02 },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// CB03: RLC E 
                                  Encoding = new byte[] { 0xCB, 0x03 },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// CB04: RLC H 
                                  Encoding = new byte[] { 0xCB, 0x04 },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// CB05: RLC L 
                                  Encoding = new byte[] { 0xCB, 0x05 },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLCA",	// 07: RLCA  
                                  Encoding = new byte[] { 0x07 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLCA },
            new OpcodeEncoding { Name = "RLD",	// ED6F: RLD  
                                  Encoding = new byte[] { 0xED, 0x6F },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLD },
            new OpcodeEncoding { Name = "RR",	// CB1E: RR (HL) 
                                  Encoding = new byte[] { 0xCB, 0x1E },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// DDCB1E: RR (IX) 
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x1E },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// DDCB1F: RR (IX) A
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x1F },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// DDCB18: RR (IX) B
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x18 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// DDCB19: RR (IX) C
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x19 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// DDCB1A: RR (IX) D
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x1A },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// DDCB1B: RR (IX) E
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x1B },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// DDCB1C: RR (IX) H
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x1C },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// DDCB1D: RR (IX) L
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x1D },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// CB1F: RR A 
                                  Encoding = new byte[] { 0xCB, 0x1F },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// CB18: RR B 
                                  Encoding = new byte[] { 0xCB, 0x18 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// CB19: RR C 
                                  Encoding = new byte[] { 0xCB, 0x19 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// CB1A: RR D 
                                  Encoding = new byte[] { 0xCB, 0x1A },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// CB1B: RR E 
                                  Encoding = new byte[] { 0xCB, 0x1B },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// CB1C: RR H 
                                  Encoding = new byte[] { 0xCB, 0x1C },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// CB1D: RR L 
                                  Encoding = new byte[] { 0xCB, 0x1D },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RR },
            new OpcodeEncoding { Name = "RRA",	// 1F: RRA  
                                  Encoding = new byte[] { 0x1F },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRA },
            new OpcodeEncoding { Name = "RRC",	// CB0E: RRC (HL) 
                                  Encoding = new byte[] { 0xCB, 0x0E },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// DDCB0E: RRC (IX) 
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x0E },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// DDCB0F: RRC (IX) A
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x0F },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// DDCB08: RRC (IX) B
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x08 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// DDCB09: RRC (IX) C
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x09 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// DDCB0A: RRC (IX) D
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x0A },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// DDCB0B: RRC (IX) E
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x0B },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// DDCB0C: RRC (IX) H
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x0C },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// DDCB0D: RRC (IX) L
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x0D },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// CB0F: RRC A 
                                  Encoding = new byte[] { 0xCB, 0x0F },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// CB08: RRC B 
                                  Encoding = new byte[] { 0xCB, 0x08 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// CB09: RRC C 
                                  Encoding = new byte[] { 0xCB, 0x09 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// CB0A: RRC D 
                                  Encoding = new byte[] { 0xCB, 0x0A },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// CB0B: RRC E 
                                  Encoding = new byte[] { 0xCB, 0x0B },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// CB0C: RRC H 
                                  Encoding = new byte[] { 0xCB, 0x0C },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// CB0D: RRC L 
                                  Encoding = new byte[] { 0xCB, 0x0D },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRCA",	// 0F: RRCA  
                                  Encoding = new byte[] { 0x0F },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRCA },
            new OpcodeEncoding { Name = "RRD",	// ED67: RRD  
                                  Encoding = new byte[] { 0xED, 0x67 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRD },
            new OpcodeEncoding { Name = "RST",	// C7: RST 0H 
                                  Encoding = new byte[] { 0xC7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0x0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RST },
            new OpcodeEncoding { Name = "RST",	// D7: RST 10H 
                                  Encoding = new byte[] { 0xD7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0x10), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RST },
            new OpcodeEncoding { Name = "RST",	// DF: RST 18H 
                                  Encoding = new byte[] { 0xDF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0x18), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RST },
            new OpcodeEncoding { Name = "RST",	// E7: RST 20H 
                                  Encoding = new byte[] { 0xE7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0x20), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RST },
            new OpcodeEncoding { Name = "RST",	// EF: RST 28H 
                                  Encoding = new byte[] { 0xEF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0x28), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RST },
            new OpcodeEncoding { Name = "RST",	// F7: RST 30H 
                                  Encoding = new byte[] { 0xF7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0x30), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RST },
            new OpcodeEncoding { Name = "RST",	// FF: RST 38H 
                                  Encoding = new byte[] { 0xFF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0x38), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RST },
            new OpcodeEncoding { Name = "RST",	// CF: RST 8H 
                                  Encoding = new byte[] { 0xCF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0x8), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RST },
            new OpcodeEncoding { Name = "SBC",	// 9E: SBC A (HL)
                                  Encoding = new byte[] { 0x9E },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.Displacement | ParamFlags.AssumeA, Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// 9F: SBC A A
                                  Encoding = new byte[] { 0x9F },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// 98: SBC A B
                                  Encoding = new byte[] { 0x98 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// 99: SBC A C
                                  Encoding = new byte[] { 0x99 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// 9A: SBC A D
                                  Encoding = new byte[] { 0x9A },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// 9B: SBC A E
                                  Encoding = new byte[] { 0x9B },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// 9C: SBC A H
                                  Encoding = new byte[] { 0x9C },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// 9D: SBC A L
                                  Encoding = new byte[] { 0x9D },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// DE: SBC A n
                                  Encoding = new byte[] { 0xDE },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// ED42: SBC HL BC
                                  Encoding = new byte[] { 0xED, 0x42 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.BC, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// ED52: SBC HL DE
                                  Encoding = new byte[] { 0xED, 0x52 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.DE, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// ED62: SBC HL HL
                                  Encoding = new byte[] { 0xED, 0x62 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// ED72: SBC HL SP
                                  Encoding = new byte[] { 0xED, 0x72 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterWord,
                                  Param2 = CommandID.SP, Param2Type = ParamType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SCF",	// 37: SCF  
                                  Encoding = new byte[] { 0x37 },
                                  Param1 = CommandID.None, Param1Type = ParamType.None,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SCF },
            new OpcodeEncoding { Name = "SET",	// CBC6: SET 0 (HL)
                                  Encoding = new byte[] { 0xCB, 0xC6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBC2: SET 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBC6: SET 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBC0: SET 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBC1: SET 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBC3: SET 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBC7: SET 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBC4: SET 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBC5: SET 0 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC7: SET 0 A
                                  Encoding = new byte[] { 0xCB, 0xC7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC0: SET 0 B
                                  Encoding = new byte[] { 0xCB, 0xC0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC1: SET 0 C
                                  Encoding = new byte[] { 0xCB, 0xC1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC2: SET 0 D
                                  Encoding = new byte[] { 0xCB, 0xC2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC3: SET 0 E
                                  Encoding = new byte[] { 0xCB, 0xC3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC4: SET 0 H
                                  Encoding = new byte[] { 0xCB, 0xC4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC5: SET 0 L
                                  Encoding = new byte[] { 0xCB, 0xC5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBCE: SET 1 (HL)
                                  Encoding = new byte[] { 0xCB, 0xCE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBCB: SET 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xCB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBC9: SET 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBCA: SET 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xCA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBCC: SET 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xCC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBCD: SET 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xCD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBCE: SET 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xCE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBC8: SET 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBCF: SET 1 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xCF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBCF: SET 1 A
                                  Encoding = new byte[] { 0xCB, 0xCF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC8: SET 1 B
                                  Encoding = new byte[] { 0xCB, 0xC8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC9: SET 1 C
                                  Encoding = new byte[] { 0xCB, 0xC9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBCA: SET 1 D
                                  Encoding = new byte[] { 0xCB, 0xCA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBCB: SET 1 E
                                  Encoding = new byte[] { 0xCB, 0xCB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBCC: SET 1 H
                                  Encoding = new byte[] { 0xCB, 0xCC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBCD: SET 1 L
                                  Encoding = new byte[] { 0xCB, 0xCD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD6: SET 2 (HL)
                                  Encoding = new byte[] { 0xCB, 0xD6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBD5: SET 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBD0: SET 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBD1: SET 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBD7: SET 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBD6: SET 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBD4: SET 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBD3: SET 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBD2: SET 2 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD7: SET 2 A
                                  Encoding = new byte[] { 0xCB, 0xD7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD0: SET 2 B
                                  Encoding = new byte[] { 0xCB, 0xD0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD1: SET 2 C
                                  Encoding = new byte[] { 0xCB, 0xD1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD2: SET 2 D
                                  Encoding = new byte[] { 0xCB, 0xD2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD3: SET 2 E
                                  Encoding = new byte[] { 0xCB, 0xD3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD4: SET 2 H
                                  Encoding = new byte[] { 0xCB, 0xD4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD5: SET 2 L
                                  Encoding = new byte[] { 0xCB, 0xD5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBDE: SET 3 (HL)
                                  Encoding = new byte[] { 0xCB, 0xDE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBDC: SET 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xDC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBDB: SET 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xDB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBD8: SET 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBD9: SET 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBDA: SET 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xDA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBDF: SET 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xDF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBDE: SET 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xDE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBDD: SET 3 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xDD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBDF: SET 3 A
                                  Encoding = new byte[] { 0xCB, 0xDF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD8: SET 3 B
                                  Encoding = new byte[] { 0xCB, 0xD8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD9: SET 3 C
                                  Encoding = new byte[] { 0xCB, 0xD9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBDA: SET 3 D
                                  Encoding = new byte[] { 0xCB, 0xDA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBDB: SET 3 E
                                  Encoding = new byte[] { 0xCB, 0xDB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBDC: SET 3 H
                                  Encoding = new byte[] { 0xCB, 0xDC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBDD: SET 3 L
                                  Encoding = new byte[] { 0xCB, 0xDD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE6: SET 4 (HL)
                                  Encoding = new byte[] { 0xCB, 0xE6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBE0: SET 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBE2: SET 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBE3: SET 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBE4: SET 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBE5: SET 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBE6: SET 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBE7: SET 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBE1: SET 4 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE7: SET 4 A
                                  Encoding = new byte[] { 0xCB, 0xE7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE0: SET 4 B
                                  Encoding = new byte[] { 0xCB, 0xE0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE1: SET 4 C
                                  Encoding = new byte[] { 0xCB, 0xE1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE2: SET 4 D
                                  Encoding = new byte[] { 0xCB, 0xE2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE3: SET 4 E
                                  Encoding = new byte[] { 0xCB, 0xE3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE4: SET 4 H
                                  Encoding = new byte[] { 0xCB, 0xE4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE5: SET 4 L
                                  Encoding = new byte[] { 0xCB, 0xE5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBEE: SET 5 (HL)
                                  Encoding = new byte[] { 0xCB, 0xEE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBEA: SET 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xEA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBE9: SET 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBE8: SET 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBEE: SET 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xEE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBEF: SET 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xEF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBED: SET 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xED },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBEB: SET 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xEB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBEC: SET 5 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xEC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBEF: SET 5 A
                                  Encoding = new byte[] { 0xCB, 0xEF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE8: SET 5 B
                                  Encoding = new byte[] { 0xCB, 0xE8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE9: SET 5 C
                                  Encoding = new byte[] { 0xCB, 0xE9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBEA: SET 5 D
                                  Encoding = new byte[] { 0xCB, 0xEA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBEB: SET 5 E
                                  Encoding = new byte[] { 0xCB, 0xEB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBEC: SET 5 H
                                  Encoding = new byte[] { 0xCB, 0xEC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBED: SET 5 L
                                  Encoding = new byte[] { 0xCB, 0xED },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF6: SET 6 (HL)
                                  Encoding = new byte[] { 0xCB, 0xF6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBF2: SET 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBF5: SET 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBF7: SET 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBF4: SET 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBF0: SET 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBF1: SET 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBF6: SET 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBF3: SET 6 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF7: SET 6 A
                                  Encoding = new byte[] { 0xCB, 0xF7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF0: SET 6 B
                                  Encoding = new byte[] { 0xCB, 0xF0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF1: SET 6 C
                                  Encoding = new byte[] { 0xCB, 0xF1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF2: SET 6 D
                                  Encoding = new byte[] { 0xCB, 0xF2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF3: SET 6 E
                                  Encoding = new byte[] { 0xCB, 0xF3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF4: SET 6 H
                                  Encoding = new byte[] { 0xCB, 0xF4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF5: SET 6 L
                                  Encoding = new byte[] { 0xCB, 0xF5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBFE: SET 7 (HL)
                                  Encoding = new byte[] { 0xCB, 0xFE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBF8: SET 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBFA: SET 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xFA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBFB: SET 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xFB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBFC: SET 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xFC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBFD: SET 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xFD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBFE: SET 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xFE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBFF: SET 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xFF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// DDCBF9: SET 7 (IX)
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParamType.Unknown,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBFF: SET 7 A
                                  Encoding = new byte[] { 0xCB, 0xFF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF8: SET 7 B
                                  Encoding = new byte[] { 0xCB, 0xF8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF9: SET 7 C
                                  Encoding = new byte[] { 0xCB, 0xF9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBFA: SET 7 D
                                  Encoding = new byte[] { 0xCB, 0xFA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBFB: SET 7 E
                                  Encoding = new byte[] { 0xCB, 0xFB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBFC: SET 7 H
                                  Encoding = new byte[] { 0xCB, 0xFC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBFD: SET 7 L
                                  Encoding = new byte[] { 0xCB, 0xFD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParamType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { Name = "SLA",	// CB26: SLA (HL) 
                                  Encoding = new byte[] { 0xCB, 0x26 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// DDCB26: SLA (IX) 
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x26 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// DDCB27: SLA (IX) A
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x27 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// DDCB20: SLA (IX) B
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x20 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// DDCB21: SLA (IX) C
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x21 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// DDCB22: SLA (IX) D
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x22 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// DDCB23: SLA (IX) E
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x23 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// DDCB24: SLA (IX) H
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x24 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// DDCB25: SLA (IX) L
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x25 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// CB27: SLA A 
                                  Encoding = new byte[] { 0xCB, 0x27 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// CB20: SLA B 
                                  Encoding = new byte[] { 0xCB, 0x20 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// CB21: SLA C 
                                  Encoding = new byte[] { 0xCB, 0x21 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// CB22: SLA D 
                                  Encoding = new byte[] { 0xCB, 0x22 },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// CB23: SLA E 
                                  Encoding = new byte[] { 0xCB, 0x23 },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// CB24: SLA H 
                                  Encoding = new byte[] { 0xCB, 0x24 },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// CB25: SLA L 
                                  Encoding = new byte[] { 0xCB, 0x25 },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLL",	// CB36: SLL (HL) 
                                  Encoding = new byte[] { 0xCB, 0x36 },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// DDCB36: SLL (IX) 
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x36 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// DDCB37: SLL (IX) A
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x37 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// DDCB30: SLL (IX) B
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x30 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// DDCB31: SLL (IX) C
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x31 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// DDCB32: SLL (IX) D
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x32 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// DDCB33: SLL (IX) E
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x33 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// DDCB34: SLL (IX) H
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x34 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// DDCB35: SLL (IX) L
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x35 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// CB37: SLL A 
                                  Encoding = new byte[] { 0xCB, 0x37 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// CB30: SLL B 
                                  Encoding = new byte[] { 0xCB, 0x30 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// CB31: SLL C 
                                  Encoding = new byte[] { 0xCB, 0x31 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// CB32: SLL D 
                                  Encoding = new byte[] { 0xCB, 0x32 },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// CB33: SLL E 
                                  Encoding = new byte[] { 0xCB, 0x33 },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// CB34: SLL H 
                                  Encoding = new byte[] { 0xCB, 0x34 },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// CB35: SLL L 
                                  Encoding = new byte[] { 0xCB, 0x35 },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SRA",	// CB2E: SRA (HL) 
                                  Encoding = new byte[] { 0xCB, 0x2E },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// DDCB2E: SRA (IX) 
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x2E },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// DDCB2F: SRA (IX) A
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x2F },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// DDCB28: SRA (IX) B
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x28 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// DDCB29: SRA (IX) C
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x29 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// DDCB2A: SRA (IX) D
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x2A },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// DDCB2B: SRA (IX) E
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x2B },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// DDCB2C: SRA (IX) H
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x2C },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// DDCB2D: SRA (IX) L
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x2D },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// CB2F: SRA A 
                                  Encoding = new byte[] { 0xCB, 0x2F },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// CB28: SRA B 
                                  Encoding = new byte[] { 0xCB, 0x28 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// CB29: SRA C 
                                  Encoding = new byte[] { 0xCB, 0x29 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// CB2A: SRA D 
                                  Encoding = new byte[] { 0xCB, 0x2A },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// CB2B: SRA E 
                                  Encoding = new byte[] { 0xCB, 0x2B },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// CB2C: SRA H 
                                  Encoding = new byte[] { 0xCB, 0x2C },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// CB2D: SRA L 
                                  Encoding = new byte[] { 0xCB, 0x2D },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRL",	// CB3E: SRL (HL) 
                                  Encoding = new byte[] { 0xCB, 0x3E },
                                  Param1 = CommandID.HL, Param1Type = ParamType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// DDCB3E: SRL (IX) 
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x3E },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// DDCB3F: SRL (IX) A
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x3F },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// DDCB38: SRL (IX) B
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x38 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// DDCB39: SRL (IX) C
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x39 },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// DDCB3A: SRL (IX) D
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x3A },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// DDCB3B: SRL (IX) E
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x3B },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// DDCB3C: SRL (IX) H
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x3C },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// DDCB3D: SRL (IX) L
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x3D },
                                  Param1 = CommandID.IX, Param1Type = ParamType.Unknown,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// CB3F: SRL A 
                                  Encoding = new byte[] { 0xCB, 0x3F },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// CB38: SRL B 
                                  Encoding = new byte[] { 0xCB, 0x38 },
                                  Param1 = CommandID.B, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// CB39: SRL C 
                                  Encoding = new byte[] { 0xCB, 0x39 },
                                  Param1 = CommandID.C, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// CB3A: SRL D 
                                  Encoding = new byte[] { 0xCB, 0x3A },
                                  Param1 = CommandID.D, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// CB3B: SRL E 
                                  Encoding = new byte[] { 0xCB, 0x3B },
                                  Param1 = CommandID.E, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// CB3C: SRL H 
                                  Encoding = new byte[] { 0xCB, 0x3C },
                                  Param1 = CommandID.H, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// CB3D: SRL L 
                                  Encoding = new byte[] { 0xCB, 0x3D },
                                  Param1 = CommandID.L, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParamType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SUB",	// 96: SUB A (HL)
                                  Encoding = new byte[] { 0x96 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.Displacement | ParamFlags.AssumeA, Function = CommandID.SUB },
            new OpcodeEncoding { Name = "SUB",	// 97: SUB A A
                                  Encoding = new byte[] { 0x97 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.SUB },
            new OpcodeEncoding { Name = "SUB",	// 90: SUB A B
                                  Encoding = new byte[] { 0x90 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.SUB },
            new OpcodeEncoding { Name = "SUB",	// 91: SUB A C
                                  Encoding = new byte[] { 0x91 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.SUB },
            new OpcodeEncoding { Name = "SUB",	// 92: SUB A D
                                  Encoding = new byte[] { 0x92 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.SUB },
            new OpcodeEncoding { Name = "SUB",	// 93: SUB A E
                                  Encoding = new byte[] { 0x93 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.SUB },
            new OpcodeEncoding { Name = "SUB",	// 94: SUB A H
                                  Encoding = new byte[] { 0x94 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.SUB },
            new OpcodeEncoding { Name = "SUB",	// 95: SUB A L
                                  Encoding = new byte[] { 0x95 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.SUB },
            new OpcodeEncoding { Name = "SUB",	// D6: SUB A n
                                  Encoding = new byte[] { 0xD6 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.SUB },
            new OpcodeEncoding { Name = "XOR",	// AE: XOR A (HL)
                                  Encoding = new byte[] { 0xAE },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParamType.RegisterPtr,
                                  Flags = ParamFlags.Displacement | ParamFlags.AssumeA, Function = CommandID.XOR },
            new OpcodeEncoding { Name = "XOR",	// AF: XOR A A
                                  Encoding = new byte[] { 0xAF },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.XOR },
            new OpcodeEncoding { Name = "XOR",	// A8: XOR A B
                                  Encoding = new byte[] { 0xA8 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.XOR },
            new OpcodeEncoding { Name = "XOR",	// A9: XOR A C
                                  Encoding = new byte[] { 0xA9 },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.XOR },
            new OpcodeEncoding { Name = "XOR",	// AA: XOR A D
                                  Encoding = new byte[] { 0xAA },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.XOR },
            new OpcodeEncoding { Name = "XOR",	// AB: XOR A E
                                  Encoding = new byte[] { 0xAB },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.XOR },
            new OpcodeEncoding { Name = "XOR",	// AC: XOR A H
                                  Encoding = new byte[] { 0xAC },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.XOR },
            new OpcodeEncoding { Name = "XOR",	// AD: XOR A L
                                  Encoding = new byte[] { 0xAD },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParamType.RegisterByte,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.XOR },
            new OpcodeEncoding { Name = "XOR",	// EE: XOR A n
                                  Encoding = new byte[] { 0xEE },
                                  Param1 = CommandID.A, Param1Type = ParamType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParamType.Immediate,
                                  Flags = ParamFlags.AssumeA, Function = CommandID.XOR },
        };
    }
}
