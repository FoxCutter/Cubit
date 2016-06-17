namespace ZASM
{
    static class Ops
    {
        static public OpcodeEncoding[] EncodingData = new OpcodeEncoding[]
        {
            new OpcodeEncoding { // 8E: ADC A (HL) 
                                  Encoding = new byte[] { 0x8E },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { // DD8E: ADC A (IX) 
                                  Encoding = new byte[] { 0xDD, 0x8E },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.ADC },
            new OpcodeEncoding { // FD8E: ADC A (IY) 
                                  Encoding = new byte[] { 0xFD, 0x8E },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.ADC },
            new OpcodeEncoding { // 8F: ADC A A 
                                  Encoding = new byte[] { 0x8F },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { // 88: ADC A B 
                                  Encoding = new byte[] { 0x88 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { // 89: ADC A C 
                                  Encoding = new byte[] { 0x89 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { // 8A: ADC A D 
                                  Encoding = new byte[] { 0x8A },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { // 8B: ADC A E 
                                  Encoding = new byte[] { 0x8B },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { // 8C: ADC A H 
                                  Encoding = new byte[] { 0x8C },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { // DD8C: ADC A IXH 
                                  Encoding = new byte[] { 0xDD, 0x8C },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.ADC },
            new OpcodeEncoding { // FD8C: ADC A IYH 
                                  Encoding = new byte[] { 0xFD, 0x8C },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.ADC },
            new OpcodeEncoding { // 8D: ADC A L 
                                  Encoding = new byte[] { 0x8D },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { // DD8D: ADC A IXL 
                                  Encoding = new byte[] { 0xDD, 0x8D },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.ADC },
            new OpcodeEncoding { // FD8D: ADC A IYL 
                                  Encoding = new byte[] { 0xFD, 0x8D },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.ADC },
            new OpcodeEncoding { // CE: ADC A N 
                                  Encoding = new byte[] { 0xCE },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { // ED4A: ADC HL BC 
                                  Encoding = new byte[] { 0xED, 0x4A },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.BC, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { // ED5A: ADC HL DE 
                                  Encoding = new byte[] { 0xED, 0x5A },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.DE, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { // ED6A: ADC HL HL 
                                  Encoding = new byte[] { 0xED, 0x6A },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { // ED7A: ADC HL SP 
                                  Encoding = new byte[] { 0xED, 0x7A },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.SP, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.ADC },
            new OpcodeEncoding { // 86: ADD A (HL) 
                                  Encoding = new byte[] { 0x86 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.ADD },
            new OpcodeEncoding { // DD86: ADD A (IX) 
                                  Encoding = new byte[] { 0xDD, 0x86 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.ADD },
            new OpcodeEncoding { // FD86: ADD A (IY) 
                                  Encoding = new byte[] { 0xFD, 0x86 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.ADD },
            new OpcodeEncoding { // 87: ADD A A 
                                  Encoding = new byte[] { 0x87 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.ADD },
            new OpcodeEncoding { // 80: ADD A B 
                                  Encoding = new byte[] { 0x80 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.ADD },
            new OpcodeEncoding { // 81: ADD A C 
                                  Encoding = new byte[] { 0x81 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.ADD },
            new OpcodeEncoding { // 82: ADD A D 
                                  Encoding = new byte[] { 0x82 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.ADD },
            new OpcodeEncoding { // 83: ADD A E 
                                  Encoding = new byte[] { 0x83 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.ADD },
            new OpcodeEncoding { // 84: ADD A H 
                                  Encoding = new byte[] { 0x84 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.ADD },
            new OpcodeEncoding { // DD84: ADD A IXH 
                                  Encoding = new byte[] { 0xDD, 0x84 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.ADD },
            new OpcodeEncoding { // FD84: ADD A IYH 
                                  Encoding = new byte[] { 0xFD, 0x84 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.ADD },
            new OpcodeEncoding { // 85: ADD A L 
                                  Encoding = new byte[] { 0x85 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.ADD },
            new OpcodeEncoding { // DD85: ADD A IXL 
                                  Encoding = new byte[] { 0xDD, 0x85 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.ADD },
            new OpcodeEncoding { // FD85: ADD A IYL 
                                  Encoding = new byte[] { 0xFD, 0x85 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.ADD },
            new OpcodeEncoding { // C6: ADD A N 
                                  Encoding = new byte[] { 0xC6 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.ADD },
            new OpcodeEncoding { // 09: ADD HL BC 
                                  Encoding = new byte[] { 0x09 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.BC, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.ADD },
            new OpcodeEncoding { // DD09: ADD IX BC 
                                  Encoding = new byte[] { 0xDD, 0x09 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.BC, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.ADD },
            new OpcodeEncoding { // FD09: ADD IY BC 
                                  Encoding = new byte[] { 0xFD, 0x09 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.BC, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.ADD },
            new OpcodeEncoding { // 19: ADD HL DE 
                                  Encoding = new byte[] { 0x19 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.DE, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.ADD },
            new OpcodeEncoding { // DD19: ADD IX DE 
                                  Encoding = new byte[] { 0xDD, 0x19 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.DE, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.ADD },
            new OpcodeEncoding { // FD19: ADD IY DE 
                                  Encoding = new byte[] { 0xFD, 0x19 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.DE, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.ADD },
            new OpcodeEncoding { // 29: ADD HL HL 
                                  Encoding = new byte[] { 0x29 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.ADD },
            new OpcodeEncoding { // DD29: ADD IX HL 
                                  Encoding = new byte[] { 0xDD, 0x29 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.ADD },
            new OpcodeEncoding { // FD29: ADD IY HL 
                                  Encoding = new byte[] { 0xFD, 0x29 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.ADD },
            new OpcodeEncoding { // 39: ADD HL SP 
                                  Encoding = new byte[] { 0x39 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.SP, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.ADD },
            new OpcodeEncoding { // DD39: ADD IX SP 
                                  Encoding = new byte[] { 0xDD, 0x39 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.SP, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.ADD },
            new OpcodeEncoding { // FD39: ADD IY SP 
                                  Encoding = new byte[] { 0xFD, 0x39 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.SP, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.ADD },
            new OpcodeEncoding { // A6: AND A (HL) 
                                  Encoding = new byte[] { 0xA6 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.AND },
            new OpcodeEncoding { // DDA6: AND A (IX) 
                                  Encoding = new byte[] { 0xDD, 0xA6 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.AND },
            new OpcodeEncoding { // FDA6: AND A (IY) 
                                  Encoding = new byte[] { 0xFD, 0xA6 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.AND },
            new OpcodeEncoding { // A7: AND A A 
                                  Encoding = new byte[] { 0xA7 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.AND },
            new OpcodeEncoding { // A0: AND A B 
                                  Encoding = new byte[] { 0xA0 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.AND },
            new OpcodeEncoding { // A1: AND A C 
                                  Encoding = new byte[] { 0xA1 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.AND },
            new OpcodeEncoding { // A2: AND A D 
                                  Encoding = new byte[] { 0xA2 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.AND },
            new OpcodeEncoding { // A3: AND A E 
                                  Encoding = new byte[] { 0xA3 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.AND },
            new OpcodeEncoding { // A4: AND A H 
                                  Encoding = new byte[] { 0xA4 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.AND },
            new OpcodeEncoding { // DDA4: AND A IXH 
                                  Encoding = new byte[] { 0xDD, 0xA4 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.AND },
            new OpcodeEncoding { // FDA4: AND A IYH 
                                  Encoding = new byte[] { 0xFD, 0xA4 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.AND },
            new OpcodeEncoding { // A5: AND A L 
                                  Encoding = new byte[] { 0xA5 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.AND },
            new OpcodeEncoding { // DDA5: AND A IXL 
                                  Encoding = new byte[] { 0xDD, 0xA5 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.AND },
            new OpcodeEncoding { // FDA5: AND A IYL 
                                  Encoding = new byte[] { 0xFD, 0xA5 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.AND },
            new OpcodeEncoding { // E6: AND A N 
                                  Encoding = new byte[] { 0xE6 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.AND },
            new OpcodeEncoding { // CB46: BIT 0 (HL) 
                                  Encoding = new byte[] { 0xCB, 0x46 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB41: BIT 0 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x41 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB41: BIT 0 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x41 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB47: BIT 0 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x47 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB47: BIT 0 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x47 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB46: BIT 0 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x46 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB46: BIT 0 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x46 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB45: BIT 0 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x45 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB45: BIT 0 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x45 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB44: BIT 0 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x44 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB44: BIT 0 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x44 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB43: BIT 0 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x43 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB43: BIT 0 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x43 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB42: BIT 0 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x42 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB42: BIT 0 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x42 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB40: BIT 0 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x40 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB40: BIT 0 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x40 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // CB47: BIT 0 A 
                                  Encoding = new byte[] { 0xCB, 0x47 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB40: BIT 0 B 
                                  Encoding = new byte[] { 0xCB, 0x40 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB41: BIT 0 C 
                                  Encoding = new byte[] { 0xCB, 0x41 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB42: BIT 0 D 
                                  Encoding = new byte[] { 0xCB, 0x42 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB43: BIT 0 E 
                                  Encoding = new byte[] { 0xCB, 0x43 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB44: BIT 0 H 
                                  Encoding = new byte[] { 0xCB, 0x44 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB45: BIT 0 L 
                                  Encoding = new byte[] { 0xCB, 0x45 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB4E: BIT 1 (HL) 
                                  Encoding = new byte[] { 0xCB, 0x4E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB48: BIT 1 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x48 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB48: BIT 1 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x48 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB4C: BIT 1 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x4C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB4C: BIT 1 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x4C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB4D: BIT 1 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x4D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB4D: BIT 1 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x4D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB49: BIT 1 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x49 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB49: BIT 1 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x49 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB4B: BIT 1 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x4B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB4B: BIT 1 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x4B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB4F: BIT 1 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x4F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB4F: BIT 1 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x4F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB4E: BIT 1 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x4E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB4E: BIT 1 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x4E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB4A: BIT 1 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x4A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB4A: BIT 1 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x4A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // CB4F: BIT 1 A 
                                  Encoding = new byte[] { 0xCB, 0x4F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB48: BIT 1 B 
                                  Encoding = new byte[] { 0xCB, 0x48 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB49: BIT 1 C 
                                  Encoding = new byte[] { 0xCB, 0x49 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB4A: BIT 1 D 
                                  Encoding = new byte[] { 0xCB, 0x4A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB4B: BIT 1 E 
                                  Encoding = new byte[] { 0xCB, 0x4B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB4C: BIT 1 H 
                                  Encoding = new byte[] { 0xCB, 0x4C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB4D: BIT 1 L 
                                  Encoding = new byte[] { 0xCB, 0x4D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB56: BIT 2 (HL) 
                                  Encoding = new byte[] { 0xCB, 0x56 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB57: BIT 2 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x57 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB57: BIT 2 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x57 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB56: BIT 2 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x56 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB56: BIT 2 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x56 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB55: BIT 2 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x55 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB55: BIT 2 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x55 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB53: BIT 2 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x53 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB53: BIT 2 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x53 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB52: BIT 2 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x52 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB52: BIT 2 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x52 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB51: BIT 2 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x51 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB51: BIT 2 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x51 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB50: BIT 2 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x50 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB50: BIT 2 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x50 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB54: BIT 2 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x54 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB54: BIT 2 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x54 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // CB57: BIT 2 A 
                                  Encoding = new byte[] { 0xCB, 0x57 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB50: BIT 2 B 
                                  Encoding = new byte[] { 0xCB, 0x50 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB51: BIT 2 C 
                                  Encoding = new byte[] { 0xCB, 0x51 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB52: BIT 2 D 
                                  Encoding = new byte[] { 0xCB, 0x52 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB53: BIT 2 E 
                                  Encoding = new byte[] { 0xCB, 0x53 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB54: BIT 2 H 
                                  Encoding = new byte[] { 0xCB, 0x54 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB55: BIT 2 L 
                                  Encoding = new byte[] { 0xCB, 0x55 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB5E: BIT 3 (HL) 
                                  Encoding = new byte[] { 0xCB, 0x5E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB5E: BIT 3 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x5E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB5E: BIT 3 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x5E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB5D: BIT 3 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x5D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB5D: BIT 3 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x5D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB5C: BIT 3 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x5C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB5C: BIT 3 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x5C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB5A: BIT 3 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x5A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB5A: BIT 3 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x5A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB59: BIT 3 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x59 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB59: BIT 3 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x59 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB58: BIT 3 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x58 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB58: BIT 3 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x58 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB5F: BIT 3 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x5F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB5F: BIT 3 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x5F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB5B: BIT 3 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x5B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB5B: BIT 3 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x5B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // CB5F: BIT 3 A 
                                  Encoding = new byte[] { 0xCB, 0x5F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB58: BIT 3 B 
                                  Encoding = new byte[] { 0xCB, 0x58 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB59: BIT 3 C 
                                  Encoding = new byte[] { 0xCB, 0x59 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB5A: BIT 3 D 
                                  Encoding = new byte[] { 0xCB, 0x5A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB5B: BIT 3 E 
                                  Encoding = new byte[] { 0xCB, 0x5B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB5C: BIT 3 H 
                                  Encoding = new byte[] { 0xCB, 0x5C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB5D: BIT 3 L 
                                  Encoding = new byte[] { 0xCB, 0x5D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB66: BIT 4 (HL) 
                                  Encoding = new byte[] { 0xCB, 0x66 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB67: BIT 4 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x67 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB67: BIT 4 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x67 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB66: BIT 4 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x66 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB66: BIT 4 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x66 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB65: BIT 4 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x65 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB65: BIT 4 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x65 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB64: BIT 4 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x64 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB64: BIT 4 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x64 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB63: BIT 4 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x63 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB63: BIT 4 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x63 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB62: BIT 4 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x62 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB62: BIT 4 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x62 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB61: BIT 4 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x61 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB61: BIT 4 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x61 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB60: BIT 4 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x60 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB60: BIT 4 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x60 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // CB67: BIT 4 A 
                                  Encoding = new byte[] { 0xCB, 0x67 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB60: BIT 4 B 
                                  Encoding = new byte[] { 0xCB, 0x60 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB61: BIT 4 C 
                                  Encoding = new byte[] { 0xCB, 0x61 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB62: BIT 4 D 
                                  Encoding = new byte[] { 0xCB, 0x62 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB63: BIT 4 E 
                                  Encoding = new byte[] { 0xCB, 0x63 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB64: BIT 4 H 
                                  Encoding = new byte[] { 0xCB, 0x64 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB65: BIT 4 L 
                                  Encoding = new byte[] { 0xCB, 0x65 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB6E: BIT 5 (HL) 
                                  Encoding = new byte[] { 0xCB, 0x6E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB68: BIT 5 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x68 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB68: BIT 5 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x68 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB6F: BIT 5 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x6F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB6F: BIT 5 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x6F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB6E: BIT 5 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x6E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB6E: BIT 5 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x6E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB69: BIT 5 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x69 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB69: BIT 5 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x69 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB6A: BIT 5 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x6A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB6A: BIT 5 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x6A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB6D: BIT 5 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x6D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB6D: BIT 5 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x6D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB6C: BIT 5 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x6C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB6C: BIT 5 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x6C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB6B: BIT 5 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x6B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB6B: BIT 5 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x6B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // CB6F: BIT 5 A 
                                  Encoding = new byte[] { 0xCB, 0x6F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB68: BIT 5 B 
                                  Encoding = new byte[] { 0xCB, 0x68 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB69: BIT 5 C 
                                  Encoding = new byte[] { 0xCB, 0x69 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB6A: BIT 5 D 
                                  Encoding = new byte[] { 0xCB, 0x6A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB6B: BIT 5 E 
                                  Encoding = new byte[] { 0xCB, 0x6B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB6C: BIT 5 H 
                                  Encoding = new byte[] { 0xCB, 0x6C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB6D: BIT 5 L 
                                  Encoding = new byte[] { 0xCB, 0x6D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB76: BIT 6 (HL) 
                                  Encoding = new byte[] { 0xCB, 0x76 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB71: BIT 6 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x71 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB71: BIT 6 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x71 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB70: BIT 6 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x70 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB70: BIT 6 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x70 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB72: BIT 6 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x72 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB72: BIT 6 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x72 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB77: BIT 6 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x77 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB77: BIT 6 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x77 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB76: BIT 6 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x76 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB76: BIT 6 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x76 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB75: BIT 6 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x75 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB75: BIT 6 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x75 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB74: BIT 6 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x74 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB74: BIT 6 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x74 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB73: BIT 6 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x73 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB73: BIT 6 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x73 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // CB77: BIT 6 A 
                                  Encoding = new byte[] { 0xCB, 0x77 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB70: BIT 6 B 
                                  Encoding = new byte[] { 0xCB, 0x70 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB71: BIT 6 C 
                                  Encoding = new byte[] { 0xCB, 0x71 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB72: BIT 6 D 
                                  Encoding = new byte[] { 0xCB, 0x72 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB73: BIT 6 E 
                                  Encoding = new byte[] { 0xCB, 0x73 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB74: BIT 6 H 
                                  Encoding = new byte[] { 0xCB, 0x74 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB75: BIT 6 L 
                                  Encoding = new byte[] { 0xCB, 0x75 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB7E: BIT 7 (HL) 
                                  Encoding = new byte[] { 0xCB, 0x7E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB7F: BIT 7 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x7F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB7F: BIT 7 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x7F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB7C: BIT 7 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x7C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB7C: BIT 7 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x7C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB7D: BIT 7 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x7D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB7D: BIT 7 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x7D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB7B: BIT 7 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x7B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB7B: BIT 7 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x7B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB78: BIT 7 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x78 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB78: BIT 7 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x78 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB79: BIT 7 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x79 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB79: BIT 7 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x79 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB7E: BIT 7 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x7E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB7E: BIT 7 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x7E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // DDCB7A: BIT 7 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x7A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // FDCB7A: BIT 7 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x7A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.BIT },
            new OpcodeEncoding { // CB7F: BIT 7 A 
                                  Encoding = new byte[] { 0xCB, 0x7F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB78: BIT 7 B 
                                  Encoding = new byte[] { 0xCB, 0x78 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB79: BIT 7 C 
                                  Encoding = new byte[] { 0xCB, 0x79 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB7A: BIT 7 D 
                                  Encoding = new byte[] { 0xCB, 0x7A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB7B: BIT 7 E 
                                  Encoding = new byte[] { 0xCB, 0x7B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB7C: BIT 7 H 
                                  Encoding = new byte[] { 0xCB, 0x7C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // CB7D: BIT 7 L 
                                  Encoding = new byte[] { 0xCB, 0x7D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.BIT },
            new OpcodeEncoding { // DC: CALL CY NN 
                                  Encoding = new byte[] { 0xDC },
                                  Param1 = CommandID.CY, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { // FC: CALL M NN 
                                  Encoding = new byte[] { 0xFC },
                                  Param1 = CommandID.M, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { // D4: CALL NC NN 
                                  Encoding = new byte[] { 0xD4 },
                                  Param1 = CommandID.NC, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { // CD: CALL NN  
                                  Encoding = new byte[] { 0xCD },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParameterType.Immediate,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { // C4: CALL NZ NN 
                                  Encoding = new byte[] { 0xC4 },
                                  Param1 = CommandID.NZ, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { // F4: CALL P NN 
                                  Encoding = new byte[] { 0xF4 },
                                  Param1 = CommandID.P, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { // EC: CALL PE NN 
                                  Encoding = new byte[] { 0xEC },
                                  Param1 = CommandID.PE, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { // E4: CALL PO NN 
                                  Encoding = new byte[] { 0xE4 },
                                  Param1 = CommandID.PO, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { // CC: CALL Z NN 
                                  Encoding = new byte[] { 0xCC },
                                  Param1 = CommandID.Z, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CALL },
            new OpcodeEncoding { // 3F: CCF   
                                  Encoding = new byte[] { 0x3F },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.CCF },
            new OpcodeEncoding { // BE: CP A (HL) 
                                  Encoding = new byte[] { 0xBE },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.CP },
            new OpcodeEncoding { // DDBE: CP A (IX) 
                                  Encoding = new byte[] { 0xDD, 0xBE },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.CP },
            new OpcodeEncoding { // FDBE: CP A (IY) 
                                  Encoding = new byte[] { 0xFD, 0xBE },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.CP },
            new OpcodeEncoding { // BF: CP A A 
                                  Encoding = new byte[] { 0xBF },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.CP },
            new OpcodeEncoding { // B8: CP A B 
                                  Encoding = new byte[] { 0xB8 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.CP },
            new OpcodeEncoding { // B9: CP A C 
                                  Encoding = new byte[] { 0xB9 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.CP },
            new OpcodeEncoding { // BA: CP A D 
                                  Encoding = new byte[] { 0xBA },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.CP },
            new OpcodeEncoding { // BB: CP A E 
                                  Encoding = new byte[] { 0xBB },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.CP },
            new OpcodeEncoding { // BC: CP A H 
                                  Encoding = new byte[] { 0xBC },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.CP },
            new OpcodeEncoding { // DDBC: CP A IXH 
                                  Encoding = new byte[] { 0xDD, 0xBC },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.CP },
            new OpcodeEncoding { // FDBC: CP A IYH 
                                  Encoding = new byte[] { 0xFD, 0xBC },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.CP },
            new OpcodeEncoding { // BD: CP A L 
                                  Encoding = new byte[] { 0xBD },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.CP },
            new OpcodeEncoding { // DDBD: CP A IXL 
                                  Encoding = new byte[] { 0xDD, 0xBD },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.CP },
            new OpcodeEncoding { // FDBD: CP A IYL 
                                  Encoding = new byte[] { 0xFD, 0xBD },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.CP },
            new OpcodeEncoding { // FE: CP A N 
                                  Encoding = new byte[] { 0xFE },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.CP },
            new OpcodeEncoding { // EDA9: CPD   
                                  Encoding = new byte[] { 0xED, 0xA9 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.CPD },
            new OpcodeEncoding { // EDB9: CPDR   
                                  Encoding = new byte[] { 0xED, 0xB9 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.CPDR },
            new OpcodeEncoding { // EDA1: CPI   
                                  Encoding = new byte[] { 0xED, 0xA1 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.CPI },
            new OpcodeEncoding { // EDB1: CPIR   
                                  Encoding = new byte[] { 0xED, 0xB1 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.CPIR },
            new OpcodeEncoding { // 2F: CPL   
                                  Encoding = new byte[] { 0x2F },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.CPL },
            new OpcodeEncoding { // 27: DAA   
                                  Encoding = new byte[] { 0x27 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DAA },
            new OpcodeEncoding { // 35: DEC (HL)  
                                  Encoding = new byte[] { 0x35 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { // DD35: DEC (IX)  
                                  Encoding = new byte[] { 0xDD, 0x35 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Displacement, Function = CommandID.DEC },
            new OpcodeEncoding { // FD35: DEC (IY)  
                                  Encoding = new byte[] { 0xFD, 0x35 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Displacement, Function = CommandID.DEC },
            new OpcodeEncoding { // 3D: DEC A  
                                  Encoding = new byte[] { 0x3D },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { // 05: DEC B  
                                  Encoding = new byte[] { 0x05 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { // 0B: DEC BC  
                                  Encoding = new byte[] { 0x0B },
                                  Param1 = CommandID.BC, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { // 0D: DEC C  
                                  Encoding = new byte[] { 0x0D },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { // 15: DEC D  
                                  Encoding = new byte[] { 0x15 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { // 1B: DEC DE  
                                  Encoding = new byte[] { 0x1B },
                                  Param1 = CommandID.DE, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { // 1D: DEC E  
                                  Encoding = new byte[] { 0x1D },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { // 25: DEC H  
                                  Encoding = new byte[] { 0x25 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { // DD25: DEC IXH  
                                  Encoding = new byte[] { 0xDD, 0x25 },
                                  Param1 = CommandID.IXH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.DEC },
            new OpcodeEncoding { // FD25: DEC IYH  
                                  Encoding = new byte[] { 0xFD, 0x25 },
                                  Param1 = CommandID.IYH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.DEC },
            new OpcodeEncoding { // 2B: DEC HL  
                                  Encoding = new byte[] { 0x2B },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { // DD2B: DEC IX  
                                  Encoding = new byte[] { 0xDD, 0x2B },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.DEC },
            new OpcodeEncoding { // FD2B: DEC IY  
                                  Encoding = new byte[] { 0xFD, 0x2B },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.DEC },
            new OpcodeEncoding { // 2D: DEC L  
                                  Encoding = new byte[] { 0x2D },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { // DD2D: DEC IXL  
                                  Encoding = new byte[] { 0xDD, 0x2D },
                                  Param1 = CommandID.IXL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.DEC },
            new OpcodeEncoding { // FD2D: DEC IYL  
                                  Encoding = new byte[] { 0xFD, 0x2D },
                                  Param1 = CommandID.IYL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.DEC },
            new OpcodeEncoding { // 3B: DEC SP  
                                  Encoding = new byte[] { 0x3B },
                                  Param1 = CommandID.SP, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DEC },
            new OpcodeEncoding { // F3: DI   
                                  Encoding = new byte[] { 0xF3 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DI },
            new OpcodeEncoding { // 10: DJNZ E-2  
                                  Encoding = new byte[] { 0x10 },
                                  Param1 = CommandID.ImmediateByte, Param1Type = ParameterType.Immediate,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.DJNZ },
            new OpcodeEncoding { // FB: EI   
                                  Encoding = new byte[] { 0xFB },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.EI },
            new OpcodeEncoding { // E3: EX (SP) HL 
                                  Encoding = new byte[] { 0xE3 },
                                  Param1 = CommandID.SP, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.EX },
            new OpcodeEncoding { // DDE3: EX (SP) IX 
                                  Encoding = new byte[] { 0xDD, 0xE3 },
                                  Param1 = CommandID.SP, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.EX },
            new OpcodeEncoding { // FDE3: EX (SP) IY 
                                  Encoding = new byte[] { 0xFD, 0xE3 },
                                  Param1 = CommandID.SP, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.EX },
            new OpcodeEncoding { // 08: EX AF AF 
                                  Encoding = new byte[] { 0x08 },
                                  Param1 = CommandID.AF, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.AF, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.EX },
            new OpcodeEncoding { // EB: EX DE HL 
                                  Encoding = new byte[] { 0xEB },
                                  Param1 = CommandID.DE, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.EX },
            new OpcodeEncoding { // D9: EXX   
                                  Encoding = new byte[] { 0xD9 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.EXX },
            new OpcodeEncoding { // 76: HALT   
                                  Encoding = new byte[] { 0x76 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.HALT },
            new OpcodeEncoding { // ED46: IM 0  
                                  Encoding = new byte[] { 0xED, 0x46 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IM },
            new OpcodeEncoding { // ED6E: IM 0  
                                  Encoding = new byte[] { 0xED, 0x6E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IM },
            new OpcodeEncoding { // ED66: IM 0  
                                  Encoding = new byte[] { 0xED, 0x66 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IM },
            new OpcodeEncoding { // ED4E: IM 0  
                                  Encoding = new byte[] { 0xED, 0x4E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IM },
            new OpcodeEncoding { // ED56: IM 1  
                                  Encoding = new byte[] { 0xED, 0x56 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IM },
            new OpcodeEncoding { // ED76: IM 1  
                                  Encoding = new byte[] { 0xED, 0x76 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IM },
            new OpcodeEncoding { // ED7E: IM 2  
                                  Encoding = new byte[] { 0xED, 0x7E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IM },
            new OpcodeEncoding { // ED5E: IM 2  
                                  Encoding = new byte[] { 0xED, 0x5E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IM },
            new OpcodeEncoding { // ED70: IN (C)  
                                  Encoding = new byte[] { 0xED, 0x70 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { // ED78: IN A (C) 
                                  Encoding = new byte[] { 0xED, 0x78 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { // DB: IN A (N) 
                                  Encoding = new byte[] { 0xDB },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { // ED40: IN B (C) 
                                  Encoding = new byte[] { 0xED, 0x40 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { // ED48: IN C (C) 
                                  Encoding = new byte[] { 0xED, 0x48 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { // ED50: IN D (C) 
                                  Encoding = new byte[] { 0xED, 0x50 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { // ED58: IN E (C) 
                                  Encoding = new byte[] { 0xED, 0x58 },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { // ED60: IN H (C) 
                                  Encoding = new byte[] { 0xED, 0x60 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { // ED68: IN L (C) 
                                  Encoding = new byte[] { 0xED, 0x68 },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.IN },
            new OpcodeEncoding { // 34: INC (HL)  
                                  Encoding = new byte[] { 0x34 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { // DD34: INC (IX)  
                                  Encoding = new byte[] { 0xDD, 0x34 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Displacement, Function = CommandID.INC },
            new OpcodeEncoding { // FD34: INC (IY)  
                                  Encoding = new byte[] { 0xFD, 0x34 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Displacement, Function = CommandID.INC },
            new OpcodeEncoding { // 3C: INC A  
                                  Encoding = new byte[] { 0x3C },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { // 04: INC B  
                                  Encoding = new byte[] { 0x04 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { // 03: INC BC  
                                  Encoding = new byte[] { 0x03 },
                                  Param1 = CommandID.BC, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { // 0C: INC C  
                                  Encoding = new byte[] { 0x0C },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { // 14: INC D  
                                  Encoding = new byte[] { 0x14 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { // 13: INC DE  
                                  Encoding = new byte[] { 0x13 },
                                  Param1 = CommandID.DE, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { // 1C: INC E  
                                  Encoding = new byte[] { 0x1C },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { // 24: INC H  
                                  Encoding = new byte[] { 0x24 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { // DD24: INC IXH  
                                  Encoding = new byte[] { 0xDD, 0x24 },
                                  Param1 = CommandID.IXH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.INC },
            new OpcodeEncoding { // FD24: INC IYH  
                                  Encoding = new byte[] { 0xFD, 0x24 },
                                  Param1 = CommandID.IYH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.INC },
            new OpcodeEncoding { // 23: INC HL  
                                  Encoding = new byte[] { 0x23 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { // DD23: INC IX  
                                  Encoding = new byte[] { 0xDD, 0x23 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.INC },
            new OpcodeEncoding { // FD23: INC IY  
                                  Encoding = new byte[] { 0xFD, 0x23 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.INC },
            new OpcodeEncoding { // 2C: INC L  
                                  Encoding = new byte[] { 0x2C },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { // DD2C: INC IXL  
                                  Encoding = new byte[] { 0xDD, 0x2C },
                                  Param1 = CommandID.IXL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.INC },
            new OpcodeEncoding { // FD2C: INC IYL  
                                  Encoding = new byte[] { 0xFD, 0x2C },
                                  Param1 = CommandID.IYL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.INC },
            new OpcodeEncoding { // 33: INC SP  
                                  Encoding = new byte[] { 0x33 },
                                  Param1 = CommandID.SP, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INC },
            new OpcodeEncoding { // EDAA: IND   
                                  Encoding = new byte[] { 0xED, 0xAA },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.IND },
            new OpcodeEncoding { // EDBA: INDR   
                                  Encoding = new byte[] { 0xED, 0xBA },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INDR },
            new OpcodeEncoding { // EDA2: INI   
                                  Encoding = new byte[] { 0xED, 0xA2 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INI },
            new OpcodeEncoding { // EDB2: INIR   
                                  Encoding = new byte[] { 0xED, 0xB2 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.INIR },
            new OpcodeEncoding { // E9: JP (HL)  
                                  Encoding = new byte[] { 0xE9 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { // DDE9: JP (HL) IX 
                                  Encoding = new byte[] { 0xDD, 0xE9 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.JP },
            new OpcodeEncoding { // FDE9: JP (HL) IY 
                                  Encoding = new byte[] { 0xFD, 0xE9 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.JP },
            new OpcodeEncoding { // DA: JP CY NN 
                                  Encoding = new byte[] { 0xDA },
                                  Param1 = CommandID.CY, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { // FA: JP M NN 
                                  Encoding = new byte[] { 0xFA },
                                  Param1 = CommandID.M, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { // D2: JP NC NN 
                                  Encoding = new byte[] { 0xD2 },
                                  Param1 = CommandID.NC, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { // C3: JP NN  
                                  Encoding = new byte[] { 0xC3 },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParameterType.Immediate,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { // C2: JP NZ NN 
                                  Encoding = new byte[] { 0xC2 },
                                  Param1 = CommandID.NZ, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { // F2: JP P NN 
                                  Encoding = new byte[] { 0xF2 },
                                  Param1 = CommandID.P, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { // EA: JP PE NN 
                                  Encoding = new byte[] { 0xEA },
                                  Param1 = CommandID.PE, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { // E2: JP PO NN 
                                  Encoding = new byte[] { 0xE2 },
                                  Param1 = CommandID.PO, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { // CA: JP Z NN 
                                  Encoding = new byte[] { 0xCA },
                                  Param1 = CommandID.Z, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JP },
            new OpcodeEncoding { // 38: JR CY E-2 
                                  Encoding = new byte[] { 0x38 },
                                  Param1 = CommandID.CY, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JR },
            new OpcodeEncoding { // 18: JR E-2  
                                  Encoding = new byte[] { 0x18 },
                                  Param1 = CommandID.ImmediateByte, Param1Type = ParameterType.Immediate,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.JR },
            new OpcodeEncoding { // 30: JR NC E-2 
                                  Encoding = new byte[] { 0x30 },
                                  Param1 = CommandID.NC, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JR },
            new OpcodeEncoding { // 20: JR NZ E-2 
                                  Encoding = new byte[] { 0x20 },
                                  Param1 = CommandID.NZ, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JR },
            new OpcodeEncoding { // 28: JR Z E-2 
                                  Encoding = new byte[] { 0x28 },
                                  Param1 = CommandID.Z, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.JR },
            new OpcodeEncoding { // 02: LD (BC) A 
                                  Encoding = new byte[] { 0x02 },
                                  Param1 = CommandID.BC, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 12: LD (DE) A 
                                  Encoding = new byte[] { 0x12 },
                                  Param1 = CommandID.DE, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 77: LD (HL) A 
                                  Encoding = new byte[] { 0x77 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD77: LD (IX) A 
                                  Encoding = new byte[] { 0xDD, 0x77 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // FD77: LD (IY) A 
                                  Encoding = new byte[] { 0xFD, 0x77 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // 70: LD (HL) B 
                                  Encoding = new byte[] { 0x70 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD70: LD (IX) B 
                                  Encoding = new byte[] { 0xDD, 0x70 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // FD70: LD (IY) B 
                                  Encoding = new byte[] { 0xFD, 0x70 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // 71: LD (HL) C 
                                  Encoding = new byte[] { 0x71 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD71: LD (IX) C 
                                  Encoding = new byte[] { 0xDD, 0x71 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // FD71: LD (IY) C 
                                  Encoding = new byte[] { 0xFD, 0x71 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // 72: LD (HL) D 
                                  Encoding = new byte[] { 0x72 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD72: LD (IX) D 
                                  Encoding = new byte[] { 0xDD, 0x72 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // FD72: LD (IY) D 
                                  Encoding = new byte[] { 0xFD, 0x72 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // 73: LD (HL) E 
                                  Encoding = new byte[] { 0x73 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD73: LD (IX) E 
                                  Encoding = new byte[] { 0xDD, 0x73 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // FD73: LD (IY) E 
                                  Encoding = new byte[] { 0xFD, 0x73 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // 74: LD (HL) H 
                                  Encoding = new byte[] { 0x74 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD74: LD (IX) H 
                                  Encoding = new byte[] { 0xDD, 0x74 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // FD74: LD (IY) H 
                                  Encoding = new byte[] { 0xFD, 0x74 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // 75: LD (HL) L 
                                  Encoding = new byte[] { 0x75 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD75: LD (IX) L 
                                  Encoding = new byte[] { 0xDD, 0x75 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // FD75: LD (IY) L 
                                  Encoding = new byte[] { 0xFD, 0x75 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // 36: LD (HL) N 
                                  Encoding = new byte[] { 0x36 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD36: LD (IX) N 
                                  Encoding = new byte[] { 0xDD, 0x36 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // FD36: LD (IY) N 
                                  Encoding = new byte[] { 0xFD, 0x36 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // 32: LD (NN) A 
                                  Encoding = new byte[] { 0x32 },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParameterType.ImmediatePtr,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // ED43: LD (NN) BC 
                                  Encoding = new byte[] { 0xED, 0x43 },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParameterType.ImmediatePtr,
                                  Param2 = CommandID.BC, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // ED53: LD (NN) DE 
                                  Encoding = new byte[] { 0xED, 0x53 },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParameterType.ImmediatePtr,
                                  Param2 = CommandID.DE, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // ED63: LD (NN) HL 
                                  Encoding = new byte[] { 0xED, 0x63 },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParameterType.ImmediatePtr,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 22: LD (NN) HL 
                                  Encoding = new byte[] { 0x22 },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParameterType.ImmediatePtr,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD22: LD (NN) IX 
                                  Encoding = new byte[] { 0xDD, 0x22 },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParameterType.ImmediatePtr,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD22: LD (NN) IY 
                                  Encoding = new byte[] { 0xFD, 0x22 },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParameterType.ImmediatePtr,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // ED73: LD (NN) SP 
                                  Encoding = new byte[] { 0xED, 0x73 },
                                  Param1 = CommandID.ImmediateWord, Param1Type = ParameterType.ImmediatePtr,
                                  Param2 = CommandID.SP, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 0A: LD A (BC) 
                                  Encoding = new byte[] { 0x0A },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.BC, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 1A: LD A (DE) 
                                  Encoding = new byte[] { 0x1A },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.DE, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 7E: LD A (HL) 
                                  Encoding = new byte[] { 0x7E },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD7E: LD A (IX) 
                                  Encoding = new byte[] { 0xDD, 0x7E },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // FD7E: LD A (IY) 
                                  Encoding = new byte[] { 0xFD, 0x7E },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // 3A: LD A (NN) 
                                  Encoding = new byte[] { 0x3A },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.ImmediatePtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 7F: LD A A 
                                  Encoding = new byte[] { 0x7F },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 78: LD A B 
                                  Encoding = new byte[] { 0x78 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 79: LD A C 
                                  Encoding = new byte[] { 0x79 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 7A: LD A D 
                                  Encoding = new byte[] { 0x7A },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 7B: LD A E 
                                  Encoding = new byte[] { 0x7B },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 7C: LD A H 
                                  Encoding = new byte[] { 0x7C },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD7C: LD A IXH 
                                  Encoding = new byte[] { 0xDD, 0x7C },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD7C: LD A IYH 
                                  Encoding = new byte[] { 0xFD, 0x7C },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // ED57: LD A I 
                                  Encoding = new byte[] { 0xED, 0x57 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.I, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 7D: LD A L 
                                  Encoding = new byte[] { 0x7D },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD7D: LD A IXL 
                                  Encoding = new byte[] { 0xDD, 0x7D },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD7D: LD A IYL 
                                  Encoding = new byte[] { 0xFD, 0x7D },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 3E: LD A N 
                                  Encoding = new byte[] { 0x3E },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // ED5F: LD A R 
                                  Encoding = new byte[] { 0xED, 0x5F },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.R, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 46: LD B (HL) 
                                  Encoding = new byte[] { 0x46 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD46: LD B (IX) 
                                  Encoding = new byte[] { 0xDD, 0x46 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // FD46: LD B (IY) 
                                  Encoding = new byte[] { 0xFD, 0x46 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // 47: LD B A 
                                  Encoding = new byte[] { 0x47 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 40: LD B B 
                                  Encoding = new byte[] { 0x40 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 41: LD B C 
                                  Encoding = new byte[] { 0x41 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 42: LD B D 
                                  Encoding = new byte[] { 0x42 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 43: LD B E 
                                  Encoding = new byte[] { 0x43 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 44: LD B H 
                                  Encoding = new byte[] { 0x44 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD44: LD B IXH 
                                  Encoding = new byte[] { 0xDD, 0x44 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD44: LD B IYH 
                                  Encoding = new byte[] { 0xFD, 0x44 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 45: LD B L 
                                  Encoding = new byte[] { 0x45 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD45: LD B IXL 
                                  Encoding = new byte[] { 0xDD, 0x45 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD45: LD B IYL 
                                  Encoding = new byte[] { 0xFD, 0x45 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 06: LD B N 
                                  Encoding = new byte[] { 0x06 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // ED4B: LD BC (NN) 
                                  Encoding = new byte[] { 0xED, 0x4B },
                                  Param1 = CommandID.BC, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.ImmediatePtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 01: LD BC NN 
                                  Encoding = new byte[] { 0x01 },
                                  Param1 = CommandID.BC, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 4E: LD C (HL) 
                                  Encoding = new byte[] { 0x4E },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD4E: LD C (IX) 
                                  Encoding = new byte[] { 0xDD, 0x4E },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // FD4E: LD C (IY) 
                                  Encoding = new byte[] { 0xFD, 0x4E },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // 4F: LD C A 
                                  Encoding = new byte[] { 0x4F },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 48: LD C B 
                                  Encoding = new byte[] { 0x48 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 49: LD C C 
                                  Encoding = new byte[] { 0x49 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 4A: LD C D 
                                  Encoding = new byte[] { 0x4A },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 4B: LD C E 
                                  Encoding = new byte[] { 0x4B },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 4C: LD C H 
                                  Encoding = new byte[] { 0x4C },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD4C: LD C IXH 
                                  Encoding = new byte[] { 0xDD, 0x4C },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD4C: LD C IYH 
                                  Encoding = new byte[] { 0xFD, 0x4C },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 4D: LD C L 
                                  Encoding = new byte[] { 0x4D },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD4D: LD C IXL 
                                  Encoding = new byte[] { 0xDD, 0x4D },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD4D: LD C IYL 
                                  Encoding = new byte[] { 0xFD, 0x4D },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 0E: LD C N 
                                  Encoding = new byte[] { 0x0E },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 56: LD D (HL) 
                                  Encoding = new byte[] { 0x56 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD56: LD D (IX) 
                                  Encoding = new byte[] { 0xDD, 0x56 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // FD56: LD D (IY) 
                                  Encoding = new byte[] { 0xFD, 0x56 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // 57: LD D A 
                                  Encoding = new byte[] { 0x57 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 50: LD D B 
                                  Encoding = new byte[] { 0x50 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 51: LD D C 
                                  Encoding = new byte[] { 0x51 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 52: LD D D 
                                  Encoding = new byte[] { 0x52 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 53: LD D E 
                                  Encoding = new byte[] { 0x53 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 54: LD D H 
                                  Encoding = new byte[] { 0x54 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD54: LD D IXH 
                                  Encoding = new byte[] { 0xDD, 0x54 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD54: LD D IYH 
                                  Encoding = new byte[] { 0xFD, 0x54 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 55: LD D L 
                                  Encoding = new byte[] { 0x55 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD55: LD D IXL 
                                  Encoding = new byte[] { 0xDD, 0x55 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD55: LD D IYL 
                                  Encoding = new byte[] { 0xFD, 0x55 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 16: LD D N 
                                  Encoding = new byte[] { 0x16 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // ED5B: LD DE (NN) 
                                  Encoding = new byte[] { 0xED, 0x5B },
                                  Param1 = CommandID.DE, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.ImmediatePtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 11: LD DE NN 
                                  Encoding = new byte[] { 0x11 },
                                  Param1 = CommandID.DE, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 5E: LD E (HL) 
                                  Encoding = new byte[] { 0x5E },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD5E: LD E (IX) 
                                  Encoding = new byte[] { 0xDD, 0x5E },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // FD5E: LD E (IY) 
                                  Encoding = new byte[] { 0xFD, 0x5E },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // 5F: LD E A 
                                  Encoding = new byte[] { 0x5F },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 58: LD E B 
                                  Encoding = new byte[] { 0x58 },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 59: LD E C 
                                  Encoding = new byte[] { 0x59 },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 5A: LD E D 
                                  Encoding = new byte[] { 0x5A },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 5B: LD E E 
                                  Encoding = new byte[] { 0x5B },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 5C: LD E H 
                                  Encoding = new byte[] { 0x5C },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD5C: LD E IXH 
                                  Encoding = new byte[] { 0xDD, 0x5C },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD5C: LD E IYH 
                                  Encoding = new byte[] { 0xFD, 0x5C },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 5D: LD E L 
                                  Encoding = new byte[] { 0x5D },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD5D: LD E IXL 
                                  Encoding = new byte[] { 0xDD, 0x5D },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD5D: LD E IYL 
                                  Encoding = new byte[] { 0xFD, 0x5D },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 1E: LD E N 
                                  Encoding = new byte[] { 0x1E },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 66: LD H (HL) 
                                  Encoding = new byte[] { 0x66 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD66: LD H (IX) 
                                  Encoding = new byte[] { 0xDD, 0x66 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // FD66: LD H (IY) 
                                  Encoding = new byte[] { 0xFD, 0x66 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // 67: LD H A 
                                  Encoding = new byte[] { 0x67 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD67: LD IXH A 
                                  Encoding = new byte[] { 0xDD, 0x67 },
                                  Param1 = CommandID.IXH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD67: LD IYH A 
                                  Encoding = new byte[] { 0xFD, 0x67 },
                                  Param1 = CommandID.IYH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 60: LD H B 
                                  Encoding = new byte[] { 0x60 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD60: LD IXH B 
                                  Encoding = new byte[] { 0xDD, 0x60 },
                                  Param1 = CommandID.IXH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD60: LD IYH B 
                                  Encoding = new byte[] { 0xFD, 0x60 },
                                  Param1 = CommandID.IYH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 61: LD H C 
                                  Encoding = new byte[] { 0x61 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD61: LD IXH C 
                                  Encoding = new byte[] { 0xDD, 0x61 },
                                  Param1 = CommandID.IXH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD61: LD IYH C 
                                  Encoding = new byte[] { 0xFD, 0x61 },
                                  Param1 = CommandID.IYH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 62: LD H D 
                                  Encoding = new byte[] { 0x62 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD62: LD IXH D 
                                  Encoding = new byte[] { 0xDD, 0x62 },
                                  Param1 = CommandID.IXH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD62: LD IYH D 
                                  Encoding = new byte[] { 0xFD, 0x62 },
                                  Param1 = CommandID.IYH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 63: LD H E 
                                  Encoding = new byte[] { 0x63 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD63: LD IXH E 
                                  Encoding = new byte[] { 0xDD, 0x63 },
                                  Param1 = CommandID.IXH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD63: LD IYH E 
                                  Encoding = new byte[] { 0xFD, 0x63 },
                                  Param1 = CommandID.IYH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 64: LD H H 
                                  Encoding = new byte[] { 0x64 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD64: LD IXH IXH 
                                  Encoding = new byte[] { 0xDD, 0x64 },
                                  Param1 = CommandID.IXH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD64: LD IYH IYH 
                                  Encoding = new byte[] { 0xFD, 0x64 },
                                  Param1 = CommandID.IYH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 65: LD H L 
                                  Encoding = new byte[] { 0x65 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD65: LD IXH IXL 
                                  Encoding = new byte[] { 0xDD, 0x65 },
                                  Param1 = CommandID.IXH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD65: LD IYH IYL 
                                  Encoding = new byte[] { 0xFD, 0x65 },
                                  Param1 = CommandID.IYH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 26: LD H N 
                                  Encoding = new byte[] { 0x26 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD26: LD IXH N 
                                  Encoding = new byte[] { 0xDD, 0x26 },
                                  Param1 = CommandID.IXH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD26: LD IYH N 
                                  Encoding = new byte[] { 0xFD, 0x26 },
                                  Param1 = CommandID.IYH, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 2A: LD HL (NN) 
                                  Encoding = new byte[] { 0x2A },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.ImmediatePtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD2A: LD IX (NN) 
                                  Encoding = new byte[] { 0xDD, 0x2A },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.ImmediatePtr,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD2A: LD IY (NN) 
                                  Encoding = new byte[] { 0xFD, 0x2A },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.ImmediatePtr,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // ED6B: LD HL (NN) 
                                  Encoding = new byte[] { 0xED, 0x6B },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.ImmediatePtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 21: LD HL NN 
                                  Encoding = new byte[] { 0x21 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD21: LD IX NN 
                                  Encoding = new byte[] { 0xDD, 0x21 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD21: LD IY NN 
                                  Encoding = new byte[] { 0xFD, 0x21 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // ED47: LD I A 
                                  Encoding = new byte[] { 0xED, 0x47 },
                                  Param1 = CommandID.I, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // 6E: LD L (HL) 
                                  Encoding = new byte[] { 0x6E },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD6E: LD L (IX) 
                                  Encoding = new byte[] { 0xDD, 0x6E },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // FD6E: LD L (IY) 
                                  Encoding = new byte[] { 0xFD, 0x6E },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.LD },
            new OpcodeEncoding { // 6F: LD L A 
                                  Encoding = new byte[] { 0x6F },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD6F: LD IXL A 
                                  Encoding = new byte[] { 0xDD, 0x6F },
                                  Param1 = CommandID.IXL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD6F: LD IYL A 
                                  Encoding = new byte[] { 0xFD, 0x6F },
                                  Param1 = CommandID.IYL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 68: LD L B 
                                  Encoding = new byte[] { 0x68 },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD68: LD IXL B 
                                  Encoding = new byte[] { 0xDD, 0x68 },
                                  Param1 = CommandID.IXL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD68: LD IYL B 
                                  Encoding = new byte[] { 0xFD, 0x68 },
                                  Param1 = CommandID.IYL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 69: LD L C 
                                  Encoding = new byte[] { 0x69 },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD69: LD IXL C 
                                  Encoding = new byte[] { 0xDD, 0x69 },
                                  Param1 = CommandID.IXL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD69: LD IYL C 
                                  Encoding = new byte[] { 0xFD, 0x69 },
                                  Param1 = CommandID.IYL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 6A: LD L D 
                                  Encoding = new byte[] { 0x6A },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD6A: LD IXL D 
                                  Encoding = new byte[] { 0xDD, 0x6A },
                                  Param1 = CommandID.IXL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD6A: LD IYL D 
                                  Encoding = new byte[] { 0xFD, 0x6A },
                                  Param1 = CommandID.IYL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 6B: LD L E 
                                  Encoding = new byte[] { 0x6B },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD6B: LD IXL E 
                                  Encoding = new byte[] { 0xDD, 0x6B },
                                  Param1 = CommandID.IXL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD6B: LD IYL E 
                                  Encoding = new byte[] { 0xFD, 0x6B },
                                  Param1 = CommandID.IYL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 6C: LD L H 
                                  Encoding = new byte[] { 0x6C },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD6C: LD IXL IXH 
                                  Encoding = new byte[] { 0xDD, 0x6C },
                                  Param1 = CommandID.IXL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD6C: LD IYL IYH 
                                  Encoding = new byte[] { 0xFD, 0x6C },
                                  Param1 = CommandID.IYL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 6D: LD L L 
                                  Encoding = new byte[] { 0x6D },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD6D: LD IXL IXL 
                                  Encoding = new byte[] { 0xDD, 0x6D },
                                  Param1 = CommandID.IXL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD6D: LD IYL IYL 
                                  Encoding = new byte[] { 0xFD, 0x6D },
                                  Param1 = CommandID.IYL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 2E: LD L N 
                                  Encoding = new byte[] { 0x2E },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DD2E: LD IXL N 
                                  Encoding = new byte[] { 0xDD, 0x2E },
                                  Param1 = CommandID.IXL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FD2E: LD IYL N 
                                  Encoding = new byte[] { 0xFD, 0x2E },
                                  Param1 = CommandID.IYL, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // ED4F: LD R A 
                                  Encoding = new byte[] { 0xED, 0x4F },
                                  Param1 = CommandID.R, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // ED7B: LD SP (NN) 
                                  Encoding = new byte[] { 0xED, 0x7B },
                                  Param1 = CommandID.SP, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.ImmediatePtr,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // F9: LD SP HL 
                                  Encoding = new byte[] { 0xF9 },
                                  Param1 = CommandID.SP, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // DDF9: LD SP IX 
                                  Encoding = new byte[] { 0xDD, 0xF9 },
                                  Param1 = CommandID.SP, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // FDF9: LD SP IY 
                                  Encoding = new byte[] { 0xFD, 0xF9 },
                                  Param1 = CommandID.SP, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.Index, Function = CommandID.LD },
            new OpcodeEncoding { // 31: LD SP NN 
                                  Encoding = new byte[] { 0x31 },
                                  Param1 = CommandID.SP, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.ImmediateWord, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.LD },
            new OpcodeEncoding { // EDA8: LDD   
                                  Encoding = new byte[] { 0xED, 0xA8 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.LDD },
            new OpcodeEncoding { // EDB8: LDDR   
                                  Encoding = new byte[] { 0xED, 0xB8 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.LDDR },
            new OpcodeEncoding { // EDA0: LDI   
                                  Encoding = new byte[] { 0xED, 0xA0 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.LDI },
            new OpcodeEncoding { // EDB0: LDIR   
                                  Encoding = new byte[] { 0xED, 0xB0 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.LDIR },
            new OpcodeEncoding { // ED54: NEG   
                                  Encoding = new byte[] { 0xED, 0x54 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NEG },
            new OpcodeEncoding { // ED74: NEG   
                                  Encoding = new byte[] { 0xED, 0x74 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NEG },
            new OpcodeEncoding { // ED6C: NEG   
                                  Encoding = new byte[] { 0xED, 0x6C },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NEG },
            new OpcodeEncoding { // ED7C: NEG   
                                  Encoding = new byte[] { 0xED, 0x7C },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NEG },
            new OpcodeEncoding { // ED5C: NEG   
                                  Encoding = new byte[] { 0xED, 0x5C },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NEG },
            new OpcodeEncoding { // ED44: NEG   
                                  Encoding = new byte[] { 0xED, 0x44 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NEG },
            new OpcodeEncoding { // ED64: NEG   
                                  Encoding = new byte[] { 0xED, 0x64 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NEG },
            new OpcodeEncoding { // ED4C: NEG   
                                  Encoding = new byte[] { 0xED, 0x4C },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NEG },
            new OpcodeEncoding { // 00: NOP   
                                  Encoding = new byte[] { 0x00 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.NOP },
            new OpcodeEncoding { // B6: OR A (HL) 
                                  Encoding = new byte[] { 0xB6 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.OR },
            new OpcodeEncoding { // DDB6: OR A (IX) 
                                  Encoding = new byte[] { 0xDD, 0xB6 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.OR },
            new OpcodeEncoding { // FDB6: OR A (IY) 
                                  Encoding = new byte[] { 0xFD, 0xB6 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.OR },
            new OpcodeEncoding { // B7: OR A A 
                                  Encoding = new byte[] { 0xB7 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OR },
            new OpcodeEncoding { // B0: OR A B 
                                  Encoding = new byte[] { 0xB0 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OR },
            new OpcodeEncoding { // B1: OR A C 
                                  Encoding = new byte[] { 0xB1 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OR },
            new OpcodeEncoding { // B2: OR A D 
                                  Encoding = new byte[] { 0xB2 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OR },
            new OpcodeEncoding { // B3: OR A E 
                                  Encoding = new byte[] { 0xB3 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OR },
            new OpcodeEncoding { // B4: OR A H 
                                  Encoding = new byte[] { 0xB4 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OR },
            new OpcodeEncoding { // DDB4: OR A IXH 
                                  Encoding = new byte[] { 0xDD, 0xB4 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.OR },
            new OpcodeEncoding { // FDB4: OR A IYH 
                                  Encoding = new byte[] { 0xFD, 0xB4 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.OR },
            new OpcodeEncoding { // B5: OR A L 
                                  Encoding = new byte[] { 0xB5 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OR },
            new OpcodeEncoding { // DDB5: OR A IXL 
                                  Encoding = new byte[] { 0xDD, 0xB5 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.OR },
            new OpcodeEncoding { // FDB5: OR A IYL 
                                  Encoding = new byte[] { 0xFD, 0xB5 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.OR },
            new OpcodeEncoding { // F6: OR A N 
                                  Encoding = new byte[] { 0xF6 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.OR },
            new OpcodeEncoding { // EDBB: OTDR   
                                  Encoding = new byte[] { 0xED, 0xBB },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.OTDR },
            new OpcodeEncoding { // EDB3: OTIR   
                                  Encoding = new byte[] { 0xED, 0xB3 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.OTIR },
            new OpcodeEncoding { // ED71: OUT (C) 0 
                                  Encoding = new byte[] { 0xED, 0x71 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = (CommandID)((int)CommandID.Encoded + 0), Param2Type = ParameterType.Encoded,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { // ED79: OUT (C) A 
                                  Encoding = new byte[] { 0xED, 0x79 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { // ED41: OUT (C) B 
                                  Encoding = new byte[] { 0xED, 0x41 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { // ED49: OUT (C) C 
                                  Encoding = new byte[] { 0xED, 0x49 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { // ED51: OUT (C) D 
                                  Encoding = new byte[] { 0xED, 0x51 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { // ED59: OUT (C) E 
                                  Encoding = new byte[] { 0xED, 0x59 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { // ED61: OUT (C) H 
                                  Encoding = new byte[] { 0xED, 0x61 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { // ED69: OUT (C) L 
                                  Encoding = new byte[] { 0xED, 0x69 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { // D3: OUT (N) A 
                                  Encoding = new byte[] { 0xD3 },
                                  Param1 = CommandID.ImmediateByte, Param1Type = ParameterType.Immediate,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.OUT },
            new OpcodeEncoding { // EDAB: OUTD   
                                  Encoding = new byte[] { 0xED, 0xAB },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.OUTD },
            new OpcodeEncoding { // EDA3: OUTI   
                                  Encoding = new byte[] { 0xED, 0xA3 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.OUTI },
            new OpcodeEncoding { // F1: POP AF  
                                  Encoding = new byte[] { 0xF1 },
                                  Param1 = CommandID.AF, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.POP },
            new OpcodeEncoding { // C1: POP BC  
                                  Encoding = new byte[] { 0xC1 },
                                  Param1 = CommandID.BC, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.POP },
            new OpcodeEncoding { // D1: POP DE  
                                  Encoding = new byte[] { 0xD1 },
                                  Param1 = CommandID.DE, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.POP },
            new OpcodeEncoding { // E1: POP HL  
                                  Encoding = new byte[] { 0xE1 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.POP },
            new OpcodeEncoding { // DDE1: POP IX  
                                  Encoding = new byte[] { 0xDD, 0xE1 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.POP },
            new OpcodeEncoding { // FDE1: POP IY  
                                  Encoding = new byte[] { 0xFD, 0xE1 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.POP },
            new OpcodeEncoding { // F5: PUSH AF  
                                  Encoding = new byte[] { 0xF5 },
                                  Param1 = CommandID.AF, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.PUSH },
            new OpcodeEncoding { // C5: PUSH BC  
                                  Encoding = new byte[] { 0xC5 },
                                  Param1 = CommandID.BC, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.PUSH },
            new OpcodeEncoding { // D5: PUSH DE  
                                  Encoding = new byte[] { 0xD5 },
                                  Param1 = CommandID.DE, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.PUSH },
            new OpcodeEncoding { // E5: PUSH HL  
                                  Encoding = new byte[] { 0xE5 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.PUSH },
            new OpcodeEncoding { // DDE5: PUSH IX  
                                  Encoding = new byte[] { 0xDD, 0xE5 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.PUSH },
            new OpcodeEncoding { // FDE5: PUSH IY  
                                  Encoding = new byte[] { 0xFD, 0xE5 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.Index, Function = CommandID.PUSH },
            new OpcodeEncoding { // CB86: RES 0 (HL) 
                                  Encoding = new byte[] { 0xCB, 0x86 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB83: RES 0 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x83 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB83: RES 0 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x83 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB82: RES 0 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x82 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB82: RES 0 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x82 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB81: RES 0 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x81 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB81: RES 0 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x81 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB87: RES 0 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x87 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB87: RES 0 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x87 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB80: RES 0 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x80 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB80: RES 0 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x80 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB86: RES 0 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x86 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB86: RES 0 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x86 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB85: RES 0 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x85 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB85: RES 0 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x85 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB84: RES 0 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x84 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB84: RES 0 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x84 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // CB87: RES 0 A 
                                  Encoding = new byte[] { 0xCB, 0x87 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB80: RES 0 B 
                                  Encoding = new byte[] { 0xCB, 0x80 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB81: RES 0 C 
                                  Encoding = new byte[] { 0xCB, 0x81 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB82: RES 0 D 
                                  Encoding = new byte[] { 0xCB, 0x82 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB83: RES 0 E 
                                  Encoding = new byte[] { 0xCB, 0x83 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB84: RES 0 H 
                                  Encoding = new byte[] { 0xCB, 0x84 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB85: RES 0 L 
                                  Encoding = new byte[] { 0xCB, 0x85 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB8E: RES 1 (HL) 
                                  Encoding = new byte[] { 0xCB, 0x8E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB8A: RES 1 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x8A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB8A: RES 1 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x8A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB8B: RES 1 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x8B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB8B: RES 1 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x8B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB8D: RES 1 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x8D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB8D: RES 1 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x8D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB8F: RES 1 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x8F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB8F: RES 1 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x8F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB8E: RES 1 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x8E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB8E: RES 1 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x8E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB88: RES 1 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x88 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB88: RES 1 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x88 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB89: RES 1 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x89 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB89: RES 1 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x89 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB8C: RES 1 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x8C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB8C: RES 1 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x8C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // CB8F: RES 1 A 
                                  Encoding = new byte[] { 0xCB, 0x8F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB88: RES 1 B 
                                  Encoding = new byte[] { 0xCB, 0x88 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB89: RES 1 C 
                                  Encoding = new byte[] { 0xCB, 0x89 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB8A: RES 1 D 
                                  Encoding = new byte[] { 0xCB, 0x8A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB8B: RES 1 E 
                                  Encoding = new byte[] { 0xCB, 0x8B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB8C: RES 1 H 
                                  Encoding = new byte[] { 0xCB, 0x8C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB8D: RES 1 L 
                                  Encoding = new byte[] { 0xCB, 0x8D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB96: RES 2 (HL) 
                                  Encoding = new byte[] { 0xCB, 0x96 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB90: RES 2 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x90 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB90: RES 2 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x90 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB91: RES 2 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x91 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB91: RES 2 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x91 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB92: RES 2 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x92 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB92: RES 2 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x92 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB93: RES 2 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x93 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB93: RES 2 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x93 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB97: RES 2 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x97 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB97: RES 2 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x97 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB96: RES 2 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x96 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB96: RES 2 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x96 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB95: RES 2 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x95 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB95: RES 2 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x95 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB94: RES 2 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x94 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB94: RES 2 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x94 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // CB97: RES 2 A 
                                  Encoding = new byte[] { 0xCB, 0x97 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB90: RES 2 B 
                                  Encoding = new byte[] { 0xCB, 0x90 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB91: RES 2 C 
                                  Encoding = new byte[] { 0xCB, 0x91 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB92: RES 2 D 
                                  Encoding = new byte[] { 0xCB, 0x92 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB93: RES 2 E 
                                  Encoding = new byte[] { 0xCB, 0x93 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB94: RES 2 H 
                                  Encoding = new byte[] { 0xCB, 0x94 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB95: RES 2 L 
                                  Encoding = new byte[] { 0xCB, 0x95 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB9E: RES 3 (HL) 
                                  Encoding = new byte[] { 0xCB, 0x9E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB98: RES 3 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x98 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB98: RES 3 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x98 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB9F: RES 3 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x9F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB9F: RES 3 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x9F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB9E: RES 3 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x9E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB9E: RES 3 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x9E },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB9D: RES 3 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x9D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB9D: RES 3 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x9D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB9C: RES 3 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x9C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB9C: RES 3 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x9C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB9B: RES 3 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x9B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB9B: RES 3 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x9B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB9A: RES 3 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x9A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB9A: RES 3 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x9A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCB99: RES 3 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x99 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCB99: RES 3 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x99 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // CB9F: RES 3 A 
                                  Encoding = new byte[] { 0xCB, 0x9F },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB98: RES 3 B 
                                  Encoding = new byte[] { 0xCB, 0x98 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB99: RES 3 C 
                                  Encoding = new byte[] { 0xCB, 0x99 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB9A: RES 3 D 
                                  Encoding = new byte[] { 0xCB, 0x9A },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB9B: RES 3 E 
                                  Encoding = new byte[] { 0xCB, 0x9B },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB9C: RES 3 H 
                                  Encoding = new byte[] { 0xCB, 0x9C },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CB9D: RES 3 L 
                                  Encoding = new byte[] { 0xCB, 0x9D },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBA6: RES 4 (HL) 
                                  Encoding = new byte[] { 0xCB, 0xA6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBA7: RES 4 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBA7: RES 4 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xA7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBA6: RES 4 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBA6: RES 4 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xA6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBA5: RES 4 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBA5: RES 4 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xA5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBA4: RES 4 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBA4: RES 4 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xA4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBA3: RES 4 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBA3: RES 4 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xA3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBA2: RES 4 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBA2: RES 4 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xA2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBA0: RES 4 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBA0: RES 4 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xA0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBA1: RES 4 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBA1: RES 4 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xA1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // CBA7: RES 4 A 
                                  Encoding = new byte[] { 0xCB, 0xA7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBA0: RES 4 B 
                                  Encoding = new byte[] { 0xCB, 0xA0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBA1: RES 4 C 
                                  Encoding = new byte[] { 0xCB, 0xA1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBA2: RES 4 D 
                                  Encoding = new byte[] { 0xCB, 0xA2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBA3: RES 4 E 
                                  Encoding = new byte[] { 0xCB, 0xA3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBA4: RES 4 H 
                                  Encoding = new byte[] { 0xCB, 0xA4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBA5: RES 4 L 
                                  Encoding = new byte[] { 0xCB, 0xA5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBAE: RES 5 (HL) 
                                  Encoding = new byte[] { 0xCB, 0xAE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBAE: RES 5 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xAE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBAE: RES 5 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xAE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBA8: RES 5 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBA8: RES 5 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xA8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBA9: RES 5 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xA9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBA9: RES 5 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xA9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBAA: RES 5 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xAA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBAA: RES 5 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xAA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBAB: RES 5 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xAB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBAB: RES 5 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xAB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBAD: RES 5 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xAD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBAD: RES 5 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xAD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBAF: RES 5 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xAF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBAF: RES 5 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xAF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBAC: RES 5 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xAC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBAC: RES 5 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xAC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // CBAF: RES 5 A 
                                  Encoding = new byte[] { 0xCB, 0xAF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBA8: RES 5 B 
                                  Encoding = new byte[] { 0xCB, 0xA8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBA9: RES 5 C 
                                  Encoding = new byte[] { 0xCB, 0xA9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBAA: RES 5 D 
                                  Encoding = new byte[] { 0xCB, 0xAA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBAB: RES 5 E 
                                  Encoding = new byte[] { 0xCB, 0xAB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBAC: RES 5 H 
                                  Encoding = new byte[] { 0xCB, 0xAC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBAD: RES 5 L 
                                  Encoding = new byte[] { 0xCB, 0xAD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBB6: RES 6 (HL) 
                                  Encoding = new byte[] { 0xCB, 0xB6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBB4: RES 6 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBB4: RES 6 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xB4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBB3: RES 6 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBB3: RES 6 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xB3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBB2: RES 6 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBB2: RES 6 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xB2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBB1: RES 6 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBB1: RES 6 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xB1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBB0: RES 6 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBB0: RES 6 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xB0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBB5: RES 6 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBB5: RES 6 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xB5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBB6: RES 6 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBB6: RES 6 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xB6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBB7: RES 6 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBB7: RES 6 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xB7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // CBB7: RES 6 A 
                                  Encoding = new byte[] { 0xCB, 0xB7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBB0: RES 6 B 
                                  Encoding = new byte[] { 0xCB, 0xB0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBB1: RES 6 C 
                                  Encoding = new byte[] { 0xCB, 0xB1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBB2: RES 6 D 
                                  Encoding = new byte[] { 0xCB, 0xB2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBB3: RES 6 E 
                                  Encoding = new byte[] { 0xCB, 0xB3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBB4: RES 6 H 
                                  Encoding = new byte[] { 0xCB, 0xB4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBB5: RES 6 L 
                                  Encoding = new byte[] { 0xCB, 0xB5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBBE: RES 7 (HL) 
                                  Encoding = new byte[] { 0xCB, 0xBE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBBA: RES 7 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xBA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBBA: RES 7 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xBA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBB8: RES 7 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBB8: RES 7 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xB8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBBF: RES 7 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xBF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBBF: RES 7 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xBF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBBE: RES 7 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xBE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBBE: RES 7 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xBE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBBD: RES 7 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xBD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBBD: RES 7 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xBD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBBC: RES 7 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xBC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBBC: RES 7 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xBC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBBB: RES 7 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xBB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBBB: RES 7 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xBB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // DDCBB9: RES 7 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xB9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // FDCBB9: RES 7 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xB9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RES },
            new OpcodeEncoding { // CBBF: RES 7 A 
                                  Encoding = new byte[] { 0xCB, 0xBF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBB8: RES 7 B 
                                  Encoding = new byte[] { 0xCB, 0xB8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBB9: RES 7 C 
                                  Encoding = new byte[] { 0xCB, 0xB9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBBA: RES 7 D 
                                  Encoding = new byte[] { 0xCB, 0xBA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBBB: RES 7 E 
                                  Encoding = new byte[] { 0xCB, 0xBB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBBC: RES 7 H 
                                  Encoding = new byte[] { 0xCB, 0xBC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // CBBD: RES 7 L 
                                  Encoding = new byte[] { 0xCB, 0xBD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.RES },
            new OpcodeEncoding { // C9: RET   
                                  Encoding = new byte[] { 0xC9 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { // D8: RET CY  
                                  Encoding = new byte[] { 0xD8 },
                                  Param1 = CommandID.CY, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { // F8: RET M  
                                  Encoding = new byte[] { 0xF8 },
                                  Param1 = CommandID.M, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { // D0: RET NC  
                                  Encoding = new byte[] { 0xD0 },
                                  Param1 = CommandID.NC, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { // C0: RET NZ  
                                  Encoding = new byte[] { 0xC0 },
                                  Param1 = CommandID.NZ, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { // F0: RET P  
                                  Encoding = new byte[] { 0xF0 },
                                  Param1 = CommandID.P, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { // E8: RET PE  
                                  Encoding = new byte[] { 0xE8 },
                                  Param1 = CommandID.PE, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { // E0: RET PO  
                                  Encoding = new byte[] { 0xE0 },
                                  Param1 = CommandID.PO, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { // C8: RET Z  
                                  Encoding = new byte[] { 0xC8 },
                                  Param1 = CommandID.Z, Param1Type = ParameterType.Conditional,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RET },
            new OpcodeEncoding { // ED4D: RETI   
                                  Encoding = new byte[] { 0xED, 0x4D },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RETI },
            new OpcodeEncoding { // ED45: RETN   
                                  Encoding = new byte[] { 0xED, 0x45 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RETN },
            new OpcodeEncoding { // ED65: RETN   
                                  Encoding = new byte[] { 0xED, 0x65 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RETN },
            new OpcodeEncoding { // ED55: RETN   
                                  Encoding = new byte[] { 0xED, 0x55 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RETN },
            new OpcodeEncoding { // ED75: RETN   
                                  Encoding = new byte[] { 0xED, 0x75 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RETN },
            new OpcodeEncoding { // ED5D: RETN   
                                  Encoding = new byte[] { 0xED, 0x5D },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RETN },
            new OpcodeEncoding { // ED7D: RETN   
                                  Encoding = new byte[] { 0xED, 0x7D },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RETN },
            new OpcodeEncoding { // ED6D: RETN   
                                  Encoding = new byte[] { 0xED, 0x6D },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RETN },
            new OpcodeEncoding { // CB16: RL (HL)  
                                  Encoding = new byte[] { 0xCB, 0x16 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RL },
            new OpcodeEncoding { // DDCB16: RL (IX)   
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x16 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RL },
            new OpcodeEncoding { // FDCB16: RL (IY)   
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x16 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RL },
            new OpcodeEncoding { // DDCB17: RL (IX) A a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x17 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RL },
            new OpcodeEncoding { // FDCB17: RL (IY) A a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x17 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RL },
            new OpcodeEncoding { // DDCB10: RL (IX) B b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x10 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RL },
            new OpcodeEncoding { // FDCB10: RL (IY) B b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x10 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RL },
            new OpcodeEncoding { // DDCB11: RL (IX) C c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x11 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RL },
            new OpcodeEncoding { // FDCB11: RL (IY) C c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x11 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RL },
            new OpcodeEncoding { // DDCB12: RL (IX) D d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x12 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RL },
            new OpcodeEncoding { // FDCB12: RL (IY) D d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x12 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RL },
            new OpcodeEncoding { // DDCB13: RL (IX) E e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x13 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RL },
            new OpcodeEncoding { // FDCB13: RL (IY) E e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x13 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RL },
            new OpcodeEncoding { // DDCB14: RL (IX) H h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x14 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RL },
            new OpcodeEncoding { // FDCB14: RL (IY) H h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x14 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RL },
            new OpcodeEncoding { // DDCB15: RL (IX) L l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x15 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RL },
            new OpcodeEncoding { // FDCB15: RL (IY) L l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x15 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RL },
            new OpcodeEncoding { // CB17: RL A  
                                  Encoding = new byte[] { 0xCB, 0x17 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RL },
            new OpcodeEncoding { // CB10: RL B  
                                  Encoding = new byte[] { 0xCB, 0x10 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RL },
            new OpcodeEncoding { // CB11: RL C  
                                  Encoding = new byte[] { 0xCB, 0x11 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RL },
            new OpcodeEncoding { // CB12: RL D  
                                  Encoding = new byte[] { 0xCB, 0x12 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RL },
            new OpcodeEncoding { // CB13: RL E  
                                  Encoding = new byte[] { 0xCB, 0x13 },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RL },
            new OpcodeEncoding { // CB14: RL H  
                                  Encoding = new byte[] { 0xCB, 0x14 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RL },
            new OpcodeEncoding { // CB15: RL L  
                                  Encoding = new byte[] { 0xCB, 0x15 },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RL },
            new OpcodeEncoding { // 17: RLA   
                                  Encoding = new byte[] { 0x17 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLA },
            new OpcodeEncoding { // CB06: RLC (HL)  
                                  Encoding = new byte[] { 0xCB, 0x06 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLC },
            new OpcodeEncoding { // DDCB06: RLC (IX)   
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x06 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RLC },
            new OpcodeEncoding { // FDCB06: RLC (IY)   
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x06 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RLC },
            new OpcodeEncoding { // DDCB07: RLC (IX) A a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x07 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RLC },
            new OpcodeEncoding { // FDCB07: RLC (IY) A a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x07 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RLC },
            new OpcodeEncoding { // DDCB00: RLC (IX) B b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x00 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RLC },
            new OpcodeEncoding { // FDCB00: RLC (IY) B b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x00 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RLC },
            new OpcodeEncoding { // DDCB01: RLC (IX) C c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x01 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RLC },
            new OpcodeEncoding { // FDCB01: RLC (IY) C c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x01 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RLC },
            new OpcodeEncoding { // DDCB02: RLC (IX) D d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x02 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RLC },
            new OpcodeEncoding { // FDCB02: RLC (IY) D d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x02 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RLC },
            new OpcodeEncoding { // DDCB03: RLC (IX) E e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x03 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RLC },
            new OpcodeEncoding { // FDCB03: RLC (IY) E e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x03 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RLC },
            new OpcodeEncoding { // DDCB04: RLC (IX) H h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x04 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RLC },
            new OpcodeEncoding { // FDCB04: RLC (IY) H h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x04 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RLC },
            new OpcodeEncoding { // DDCB05: RLC (IX) L l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x05 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RLC },
            new OpcodeEncoding { // FDCB05: RLC (IY) L l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x05 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RLC },
            new OpcodeEncoding { // CB07: RLC A  
                                  Encoding = new byte[] { 0xCB, 0x07 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLC },
            new OpcodeEncoding { // CB00: RLC B  
                                  Encoding = new byte[] { 0xCB, 0x00 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLC },
            new OpcodeEncoding { // CB01: RLC C  
                                  Encoding = new byte[] { 0xCB, 0x01 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLC },
            new OpcodeEncoding { // CB02: RLC D  
                                  Encoding = new byte[] { 0xCB, 0x02 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLC },
            new OpcodeEncoding { // CB03: RLC E  
                                  Encoding = new byte[] { 0xCB, 0x03 },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLC },
            new OpcodeEncoding { // CB04: RLC H  
                                  Encoding = new byte[] { 0xCB, 0x04 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLC },
            new OpcodeEncoding { // CB05: RLC L  
                                  Encoding = new byte[] { 0xCB, 0x05 },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLC },
            new OpcodeEncoding { // 07: RLCA   
                                  Encoding = new byte[] { 0x07 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLCA },
            new OpcodeEncoding { // ED6F: RLD   
                                  Encoding = new byte[] { 0xED, 0x6F },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RLD },
            new OpcodeEncoding { // CB1E: RR (HL)  
                                  Encoding = new byte[] { 0xCB, 0x1E },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RR },
            new OpcodeEncoding { // DDCB1E: RR (IX)   
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x1E },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RR },
            new OpcodeEncoding { // FDCB1E: RR (IY)   
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x1E },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RR },
            new OpcodeEncoding { // DDCB1F: RR (IX) A a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x1F },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RR },
            new OpcodeEncoding { // FDCB1F: RR (IY) A a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x1F },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RR },
            new OpcodeEncoding { // DDCB18: RR (IX) B b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x18 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RR },
            new OpcodeEncoding { // FDCB18: RR (IY) B b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x18 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RR },
            new OpcodeEncoding { // DDCB19: RR (IX) C c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x19 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RR },
            new OpcodeEncoding { // FDCB19: RR (IY) C c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x19 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RR },
            new OpcodeEncoding { // DDCB1A: RR (IX) D d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x1A },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RR },
            new OpcodeEncoding { // FDCB1A: RR (IY) D d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x1A },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RR },
            new OpcodeEncoding { // DDCB1B: RR (IX) E e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x1B },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RR },
            new OpcodeEncoding { // FDCB1B: RR (IY) E e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x1B },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RR },
            new OpcodeEncoding { // DDCB1C: RR (IX) H h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x1C },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RR },
            new OpcodeEncoding { // FDCB1C: RR (IY) H h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x1C },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RR },
            new OpcodeEncoding { // DDCB1D: RR (IX) L l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x1D },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RR },
            new OpcodeEncoding { // FDCB1D: RR (IY) L l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x1D },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RR },
            new OpcodeEncoding { // CB1F: RR A  
                                  Encoding = new byte[] { 0xCB, 0x1F },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RR },
            new OpcodeEncoding { // CB18: RR B  
                                  Encoding = new byte[] { 0xCB, 0x18 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RR },
            new OpcodeEncoding { // CB19: RR C  
                                  Encoding = new byte[] { 0xCB, 0x19 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RR },
            new OpcodeEncoding { // CB1A: RR D  
                                  Encoding = new byte[] { 0xCB, 0x1A },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RR },
            new OpcodeEncoding { // CB1B: RR E  
                                  Encoding = new byte[] { 0xCB, 0x1B },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RR },
            new OpcodeEncoding { // CB1C: RR H  
                                  Encoding = new byte[] { 0xCB, 0x1C },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RR },
            new OpcodeEncoding { // CB1D: RR L  
                                  Encoding = new byte[] { 0xCB, 0x1D },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RR },
            new OpcodeEncoding { // 1F: RRA   
                                  Encoding = new byte[] { 0x1F },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRA },
            new OpcodeEncoding { // CB0E: RRC (HL)  
                                  Encoding = new byte[] { 0xCB, 0x0E },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRC },
            new OpcodeEncoding { // DDCB0E: RRC (IX)   
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x0E },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RRC },
            new OpcodeEncoding { // FDCB0E: RRC (IY)   
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x0E },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RRC },
            new OpcodeEncoding { // DDCB0F: RRC (IX) A a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x0F },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RRC },
            new OpcodeEncoding { // FDCB0F: RRC (IY) A a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x0F },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RRC },
            new OpcodeEncoding { // DDCB08: RRC (IX) B b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x08 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RRC },
            new OpcodeEncoding { // FDCB08: RRC (IY) B b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x08 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RRC },
            new OpcodeEncoding { // DDCB09: RRC (IX) C c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x09 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RRC },
            new OpcodeEncoding { // FDCB09: RRC (IY) C c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x09 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RRC },
            new OpcodeEncoding { // DDCB0A: RRC (IX) D d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x0A },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RRC },
            new OpcodeEncoding { // FDCB0A: RRC (IY) D d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x0A },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RRC },
            new OpcodeEncoding { // DDCB0B: RRC (IX) E e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x0B },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RRC },
            new OpcodeEncoding { // FDCB0B: RRC (IY) E e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x0B },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RRC },
            new OpcodeEncoding { // DDCB0C: RRC (IX) H h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x0C },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RRC },
            new OpcodeEncoding { // FDCB0C: RRC (IY) H h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x0C },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RRC },
            new OpcodeEncoding { // DDCB0D: RRC (IX) L l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x0D },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RRC },
            new OpcodeEncoding { // FDCB0D: RRC (IY) L l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x0D },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.RRC },
            new OpcodeEncoding { // CB0F: RRC A  
                                  Encoding = new byte[] { 0xCB, 0x0F },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRC },
            new OpcodeEncoding { // CB08: RRC B  
                                  Encoding = new byte[] { 0xCB, 0x08 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRC },
            new OpcodeEncoding { // CB09: RRC C  
                                  Encoding = new byte[] { 0xCB, 0x09 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRC },
            new OpcodeEncoding { // CB0A: RRC D  
                                  Encoding = new byte[] { 0xCB, 0x0A },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRC },
            new OpcodeEncoding { // CB0B: RRC E  
                                  Encoding = new byte[] { 0xCB, 0x0B },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRC },
            new OpcodeEncoding { // CB0C: RRC H  
                                  Encoding = new byte[] { 0xCB, 0x0C },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRC },
            new OpcodeEncoding { // CB0D: RRC L  
                                  Encoding = new byte[] { 0xCB, 0x0D },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRC },
            new OpcodeEncoding { // 0F: RRCA   
                                  Encoding = new byte[] { 0x0F },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRCA },
            new OpcodeEncoding { // ED67: RRD   
                                  Encoding = new byte[] { 0xED, 0x67 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RRD },
            new OpcodeEncoding { // C7: RST 0H  
                                  Encoding = new byte[] { 0xC7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0x0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RST },
            new OpcodeEncoding { // D7: RST 10H  
                                  Encoding = new byte[] { 0xD7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0x10), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RST },
            new OpcodeEncoding { // DF: RST 18H  
                                  Encoding = new byte[] { 0xDF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0x18), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RST },
            new OpcodeEncoding { // E7: RST 20H  
                                  Encoding = new byte[] { 0xE7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0x20), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RST },
            new OpcodeEncoding { // EF: RST 28H  
                                  Encoding = new byte[] { 0xEF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0x28), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RST },
            new OpcodeEncoding { // F7: RST 30H  
                                  Encoding = new byte[] { 0xF7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0x30), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RST },
            new OpcodeEncoding { // FF: RST 38H  
                                  Encoding = new byte[] { 0xFF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0x38), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RST },
            new OpcodeEncoding { // CF: RST 8H  
                                  Encoding = new byte[] { 0xCF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0x8), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.RST },
            new OpcodeEncoding { // 9E: SBC A (HL) 
                                  Encoding = new byte[] { 0x9E },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { // DD9E: SBC A (IX) 
                                  Encoding = new byte[] { 0xDD, 0x9E },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SBC },
            new OpcodeEncoding { // FD9E: SBC A (IY) 
                                  Encoding = new byte[] { 0xFD, 0x9E },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SBC },
            new OpcodeEncoding { // 9F: SBC A A 
                                  Encoding = new byte[] { 0x9F },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { // 98: SBC A B 
                                  Encoding = new byte[] { 0x98 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { // 99: SBC A C 
                                  Encoding = new byte[] { 0x99 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { // 9A: SBC A D 
                                  Encoding = new byte[] { 0x9A },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { // 9B: SBC A E 
                                  Encoding = new byte[] { 0x9B },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { // 9C: SBC A H 
                                  Encoding = new byte[] { 0x9C },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { // DD9C: SBC A IXH 
                                  Encoding = new byte[] { 0xDD, 0x9C },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.SBC },
            new OpcodeEncoding { // FD9C: SBC A IYH 
                                  Encoding = new byte[] { 0xFD, 0x9C },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.SBC },
            new OpcodeEncoding { // 9D: SBC A L 
                                  Encoding = new byte[] { 0x9D },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { // DD9D: SBC A IXL 
                                  Encoding = new byte[] { 0xDD, 0x9D },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.SBC },
            new OpcodeEncoding { // FD9D: SBC A IYL 
                                  Encoding = new byte[] { 0xFD, 0x9D },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.SBC },
            new OpcodeEncoding { // DE: SBC A N 
                                  Encoding = new byte[] { 0xDE },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { // ED42: SBC HL BC 
                                  Encoding = new byte[] { 0xED, 0x42 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.BC, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { // ED52: SBC HL DE 
                                  Encoding = new byte[] { 0xED, 0x52 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.DE, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { // ED62: SBC HL HL 
                                  Encoding = new byte[] { 0xED, 0x62 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { // ED72: SBC HL SP 
                                  Encoding = new byte[] { 0xED, 0x72 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.SP, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.None, Function = CommandID.SBC },
            new OpcodeEncoding { // 37: SCF   
                                  Encoding = new byte[] { 0x37 },
                                  Param1 = CommandID.None, Param1Type = ParameterType.None,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SCF },
            new OpcodeEncoding { // CBC6: SET 0 (HL) 
                                  Encoding = new byte[] { 0xCB, 0xC6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBC2: SET 0 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBC2: SET 0 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xC2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBC6: SET 0 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBC6: SET 0 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xC6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBC0: SET 0 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBC0: SET 0 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xC0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBC1: SET 0 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBC1: SET 0 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xC1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBC3: SET 0 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBC3: SET 0 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xC3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBC7: SET 0 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBC7: SET 0 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xC7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBC4: SET 0 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBC4: SET 0 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xC4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBC5: SET 0 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBC5: SET 0 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xC5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // CBC7: SET 0 A 
                                  Encoding = new byte[] { 0xCB, 0xC7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBC0: SET 0 B 
                                  Encoding = new byte[] { 0xCB, 0xC0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBC1: SET 0 C 
                                  Encoding = new byte[] { 0xCB, 0xC1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBC2: SET 0 D 
                                  Encoding = new byte[] { 0xCB, 0xC2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBC3: SET 0 E 
                                  Encoding = new byte[] { 0xCB, 0xC3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBC4: SET 0 H 
                                  Encoding = new byte[] { 0xCB, 0xC4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBC5: SET 0 L 
                                  Encoding = new byte[] { 0xCB, 0xC5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 0), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBCE: SET 1 (HL) 
                                  Encoding = new byte[] { 0xCB, 0xCE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBCB: SET 1 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xCB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBCB: SET 1 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xCB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBC9: SET 1 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBC9: SET 1 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xC9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBCA: SET 1 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xCA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBCA: SET 1 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xCA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBCC: SET 1 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xCC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBCC: SET 1 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xCC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBCD: SET 1 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xCD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBCD: SET 1 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xCD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBCE: SET 1 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xCE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBCE: SET 1 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xCE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBC8: SET 1 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xC8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBC8: SET 1 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xC8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBCF: SET 1 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xCF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBCF: SET 1 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xCF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // CBCF: SET 1 A 
                                  Encoding = new byte[] { 0xCB, 0xCF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBC8: SET 1 B 
                                  Encoding = new byte[] { 0xCB, 0xC8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBC9: SET 1 C 
                                  Encoding = new byte[] { 0xCB, 0xC9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBCA: SET 1 D 
                                  Encoding = new byte[] { 0xCB, 0xCA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBCB: SET 1 E 
                                  Encoding = new byte[] { 0xCB, 0xCB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBCC: SET 1 H 
                                  Encoding = new byte[] { 0xCB, 0xCC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBCD: SET 1 L 
                                  Encoding = new byte[] { 0xCB, 0xCD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 1), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBD6: SET 2 (HL) 
                                  Encoding = new byte[] { 0xCB, 0xD6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBD5: SET 2 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBD5: SET 2 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xD5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBD0: SET 2 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBD0: SET 2 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xD0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBD1: SET 2 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBD1: SET 2 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xD1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBD7: SET 2 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBD7: SET 2 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xD7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBD6: SET 2 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBD6: SET 2 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xD6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBD4: SET 2 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBD4: SET 2 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xD4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBD3: SET 2 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBD3: SET 2 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xD3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBD2: SET 2 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBD2: SET 2 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xD2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // CBD7: SET 2 A 
                                  Encoding = new byte[] { 0xCB, 0xD7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBD0: SET 2 B 
                                  Encoding = new byte[] { 0xCB, 0xD0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBD1: SET 2 C 
                                  Encoding = new byte[] { 0xCB, 0xD1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBD2: SET 2 D 
                                  Encoding = new byte[] { 0xCB, 0xD2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBD3: SET 2 E 
                                  Encoding = new byte[] { 0xCB, 0xD3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBD4: SET 2 H 
                                  Encoding = new byte[] { 0xCB, 0xD4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBD5: SET 2 L 
                                  Encoding = new byte[] { 0xCB, 0xD5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 2), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBDE: SET 3 (HL) 
                                  Encoding = new byte[] { 0xCB, 0xDE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBDC: SET 3 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xDC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBDC: SET 3 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xDC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBDB: SET 3 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xDB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBDB: SET 3 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xDB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBD8: SET 3 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBD8: SET 3 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xD8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBD9: SET 3 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xD9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBD9: SET 3 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xD9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBDA: SET 3 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xDA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBDA: SET 3 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xDA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBDF: SET 3 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xDF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBDF: SET 3 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xDF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBDE: SET 3 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xDE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBDE: SET 3 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xDE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBDD: SET 3 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xDD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBDD: SET 3 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xDD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // CBDF: SET 3 A 
                                  Encoding = new byte[] { 0xCB, 0xDF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBD8: SET 3 B 
                                  Encoding = new byte[] { 0xCB, 0xD8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBD9: SET 3 C 
                                  Encoding = new byte[] { 0xCB, 0xD9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBDA: SET 3 D 
                                  Encoding = new byte[] { 0xCB, 0xDA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBDB: SET 3 E 
                                  Encoding = new byte[] { 0xCB, 0xDB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBDC: SET 3 H 
                                  Encoding = new byte[] { 0xCB, 0xDC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBDD: SET 3 L 
                                  Encoding = new byte[] { 0xCB, 0xDD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 3), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBE6: SET 4 (HL) 
                                  Encoding = new byte[] { 0xCB, 0xE6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBE0: SET 4 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBE0: SET 4 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xE0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBE2: SET 4 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBE2: SET 4 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xE2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBE3: SET 4 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBE3: SET 4 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xE3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBE4: SET 4 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBE4: SET 4 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xE4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBE5: SET 4 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBE5: SET 4 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xE5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBE6: SET 4 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBE6: SET 4 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xE6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBE7: SET 4 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBE7: SET 4 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xE7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBE1: SET 4 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBE1: SET 4 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xE1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // CBE7: SET 4 A 
                                  Encoding = new byte[] { 0xCB, 0xE7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBE0: SET 4 B 
                                  Encoding = new byte[] { 0xCB, 0xE0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBE1: SET 4 C 
                                  Encoding = new byte[] { 0xCB, 0xE1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBE2: SET 4 D 
                                  Encoding = new byte[] { 0xCB, 0xE2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBE3: SET 4 E 
                                  Encoding = new byte[] { 0xCB, 0xE3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBE4: SET 4 H 
                                  Encoding = new byte[] { 0xCB, 0xE4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBE5: SET 4 L 
                                  Encoding = new byte[] { 0xCB, 0xE5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 4), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBEE: SET 5 (HL) 
                                  Encoding = new byte[] { 0xCB, 0xEE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBEA: SET 5 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xEA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBEA: SET 5 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xEA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBE9: SET 5 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBE9: SET 5 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xE9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBE8: SET 5 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xE8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBE8: SET 5 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xE8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBEE: SET 5 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xEE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBEE: SET 5 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xEE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBEF: SET 5 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xEF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBEF: SET 5 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xEF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBED: SET 5 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xED },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBED: SET 5 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xED },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBEB: SET 5 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xEB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBEB: SET 5 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xEB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBEC: SET 5 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xEC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBEC: SET 5 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xEC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // CBEF: SET 5 A 
                                  Encoding = new byte[] { 0xCB, 0xEF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBE8: SET 5 B 
                                  Encoding = new byte[] { 0xCB, 0xE8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBE9: SET 5 C 
                                  Encoding = new byte[] { 0xCB, 0xE9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBEA: SET 5 D 
                                  Encoding = new byte[] { 0xCB, 0xEA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBEB: SET 5 E 
                                  Encoding = new byte[] { 0xCB, 0xEB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBEC: SET 5 H 
                                  Encoding = new byte[] { 0xCB, 0xEC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBED: SET 5 L 
                                  Encoding = new byte[] { 0xCB, 0xED },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 5), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBF6: SET 6 (HL) 
                                  Encoding = new byte[] { 0xCB, 0xF6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBF2: SET 6 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBF2: SET 6 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xF2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBF5: SET 6 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBF5: SET 6 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xF5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBF7: SET 6 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBF7: SET 6 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xF7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBF4: SET 6 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBF4: SET 6 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xF4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBF0: SET 6 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBF0: SET 6 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xF0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBF1: SET 6 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBF1: SET 6 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xF1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBF6: SET 6 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBF6: SET 6 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xF6 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBF3: SET 6 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBF3: SET 6 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xF3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // CBF7: SET 6 A 
                                  Encoding = new byte[] { 0xCB, 0xF7 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBF0: SET 6 B 
                                  Encoding = new byte[] { 0xCB, 0xF0 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBF1: SET 6 C 
                                  Encoding = new byte[] { 0xCB, 0xF1 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBF2: SET 6 D 
                                  Encoding = new byte[] { 0xCB, 0xF2 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBF3: SET 6 E 
                                  Encoding = new byte[] { 0xCB, 0xF3 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBF4: SET 6 H 
                                  Encoding = new byte[] { 0xCB, 0xF4 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBF5: SET 6 L 
                                  Encoding = new byte[] { 0xCB, 0xF5 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 6), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBFE: SET 7 (HL) 
                                  Encoding = new byte[] { 0xCB, 0xFE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBF8: SET 7 (IX) b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBF8: SET 7 (IY) b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xF8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBFA: SET 7 (IX) d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xFA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBFA: SET 7 (IY) d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xFA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBFB: SET 7 (IX) e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xFB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBFB: SET 7 (IY) e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xFB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBFC: SET 7 (IX) h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xFC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBFC: SET 7 (IY) h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xFC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBFD: SET 7 (IX) l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xFD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBFD: SET 7 (IY) l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xFD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBFE: SET 7 (IX)  
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xFE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBFE: SET 7 (IY)  
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xFE },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBFF: SET 7 (IX) a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xFF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBFF: SET 7 (IY) a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xFF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // DDCBF9: SET 7 (IX) c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0xF9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // FDCBF9: SET 7 (IY) c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0xF9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterWord,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SET },
            new OpcodeEncoding { // CBFF: SET 7 A 
                                  Encoding = new byte[] { 0xCB, 0xFF },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBF8: SET 7 B 
                                  Encoding = new byte[] { 0xCB, 0xF8 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBF9: SET 7 C 
                                  Encoding = new byte[] { 0xCB, 0xF9 },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBFA: SET 7 D 
                                  Encoding = new byte[] { 0xCB, 0xFA },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBFB: SET 7 E 
                                  Encoding = new byte[] { 0xCB, 0xFB },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBFC: SET 7 H 
                                  Encoding = new byte[] { 0xCB, 0xFC },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CBFD: SET 7 L 
                                  Encoding = new byte[] { 0xCB, 0xFD },
                                  Param1 = (CommandID)((int)CommandID.Encoded + 7), Param1Type = ParameterType.Encoded,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SET },
            new OpcodeEncoding { // CB26: SLA (HL)  
                                  Encoding = new byte[] { 0xCB, 0x26 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLA },
            new OpcodeEncoding { // DDCB26: SLA (IX)   
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x26 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLA },
            new OpcodeEncoding { // FDCB26: SLA (IY)   
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x26 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLA },
            new OpcodeEncoding { // DDCB27: SLA (IX) A a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x27 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLA },
            new OpcodeEncoding { // FDCB27: SLA (IY) A a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x27 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLA },
            new OpcodeEncoding { // DDCB20: SLA (IX) B b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x20 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLA },
            new OpcodeEncoding { // FDCB20: SLA (IY) B b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x20 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLA },
            new OpcodeEncoding { // DDCB21: SLA (IX) C c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x21 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLA },
            new OpcodeEncoding { // FDCB21: SLA (IY) C c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x21 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLA },
            new OpcodeEncoding { // DDCB22: SLA (IX) D d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x22 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLA },
            new OpcodeEncoding { // FDCB22: SLA (IY) D d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x22 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLA },
            new OpcodeEncoding { // DDCB23: SLA (IX) E e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x23 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLA },
            new OpcodeEncoding { // FDCB23: SLA (IY) E e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x23 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLA },
            new OpcodeEncoding { // DDCB24: SLA (IX) H h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x24 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLA },
            new OpcodeEncoding { // FDCB24: SLA (IY) H h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x24 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLA },
            new OpcodeEncoding { // DDCB25: SLA (IX) L l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x25 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLA },
            new OpcodeEncoding { // FDCB25: SLA (IY) L l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x25 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLA },
            new OpcodeEncoding { // CB27: SLA A  
                                  Encoding = new byte[] { 0xCB, 0x27 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLA },
            new OpcodeEncoding { // CB20: SLA B  
                                  Encoding = new byte[] { 0xCB, 0x20 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLA },
            new OpcodeEncoding { // CB21: SLA C  
                                  Encoding = new byte[] { 0xCB, 0x21 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLA },
            new OpcodeEncoding { // CB22: SLA D  
                                  Encoding = new byte[] { 0xCB, 0x22 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLA },
            new OpcodeEncoding { // CB23: SLA E  
                                  Encoding = new byte[] { 0xCB, 0x23 },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLA },
            new OpcodeEncoding { // CB24: SLA H  
                                  Encoding = new byte[] { 0xCB, 0x24 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLA },
            new OpcodeEncoding { // CB25: SLA L  
                                  Encoding = new byte[] { 0xCB, 0x25 },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLA },
            new OpcodeEncoding { // CB36: SLL (HL)  
                                  Encoding = new byte[] { 0xCB, 0x36 },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLL },
            new OpcodeEncoding { // DDCB36: SLL (IX)   
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x36 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLL },
            new OpcodeEncoding { // FDCB36: SLL (IY)   
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x36 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLL },
            new OpcodeEncoding { // DDCB37: SLL (IX) A a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x37 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLL },
            new OpcodeEncoding { // FDCB37: SLL (IY) A a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x37 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLL },
            new OpcodeEncoding { // DDCB30: SLL (IX) B b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x30 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLL },
            new OpcodeEncoding { // FDCB30: SLL (IY) B b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x30 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLL },
            new OpcodeEncoding { // DDCB31: SLL (IX) C c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x31 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLL },
            new OpcodeEncoding { // FDCB31: SLL (IY) C c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x31 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLL },
            new OpcodeEncoding { // DDCB32: SLL (IX) D d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x32 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLL },
            new OpcodeEncoding { // FDCB32: SLL (IY) D d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x32 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLL },
            new OpcodeEncoding { // DDCB33: SLL (IX) E e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x33 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLL },
            new OpcodeEncoding { // FDCB33: SLL (IY) E e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x33 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLL },
            new OpcodeEncoding { // DDCB34: SLL (IX) H h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x34 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLL },
            new OpcodeEncoding { // FDCB34: SLL (IY) H h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x34 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLL },
            new OpcodeEncoding { // DDCB35: SLL (IX) L l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x35 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLL },
            new OpcodeEncoding { // FDCB35: SLL (IY) L l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x35 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SLL },
            new OpcodeEncoding { // CB37: SLL A  
                                  Encoding = new byte[] { 0xCB, 0x37 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLL },
            new OpcodeEncoding { // CB30: SLL B  
                                  Encoding = new byte[] { 0xCB, 0x30 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLL },
            new OpcodeEncoding { // CB31: SLL C  
                                  Encoding = new byte[] { 0xCB, 0x31 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLL },
            new OpcodeEncoding { // CB32: SLL D  
                                  Encoding = new byte[] { 0xCB, 0x32 },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLL },
            new OpcodeEncoding { // CB33: SLL E  
                                  Encoding = new byte[] { 0xCB, 0x33 },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLL },
            new OpcodeEncoding { // CB34: SLL H  
                                  Encoding = new byte[] { 0xCB, 0x34 },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLL },
            new OpcodeEncoding { // CB35: SLL L  
                                  Encoding = new byte[] { 0xCB, 0x35 },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SLL },
            new OpcodeEncoding { // CB2E: SRA (HL)  
                                  Encoding = new byte[] { 0xCB, 0x2E },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRA },
            new OpcodeEncoding { // DDCB2E: SRA (IX)   
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x2E },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRA },
            new OpcodeEncoding { // FDCB2E: SRA (IY)   
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x2E },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRA },
            new OpcodeEncoding { // DDCB2F: SRA (IX) A a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x2F },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRA },
            new OpcodeEncoding { // FDCB2F: SRA (IY) A a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x2F },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRA },
            new OpcodeEncoding { // DDCB28: SRA (IX) B b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x28 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRA },
            new OpcodeEncoding { // FDCB28: SRA (IY) B b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x28 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRA },
            new OpcodeEncoding { // DDCB29: SRA (IX) C c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x29 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRA },
            new OpcodeEncoding { // FDCB29: SRA (IY) C c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x29 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRA },
            new OpcodeEncoding { // DDCB2A: SRA (IX) D d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x2A },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRA },
            new OpcodeEncoding { // FDCB2A: SRA (IY) D d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x2A },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRA },
            new OpcodeEncoding { // DDCB2B: SRA (IX) E e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x2B },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRA },
            new OpcodeEncoding { // FDCB2B: SRA (IY) E e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x2B },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRA },
            new OpcodeEncoding { // DDCB2C: SRA (IX) H h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x2C },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRA },
            new OpcodeEncoding { // FDCB2C: SRA (IY) H h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x2C },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRA },
            new OpcodeEncoding { // DDCB2D: SRA (IX) L l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x2D },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRA },
            new OpcodeEncoding { // FDCB2D: SRA (IY) L l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x2D },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRA },
            new OpcodeEncoding { // CB2F: SRA A  
                                  Encoding = new byte[] { 0xCB, 0x2F },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRA },
            new OpcodeEncoding { // CB28: SRA B  
                                  Encoding = new byte[] { 0xCB, 0x28 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRA },
            new OpcodeEncoding { // CB29: SRA C  
                                  Encoding = new byte[] { 0xCB, 0x29 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRA },
            new OpcodeEncoding { // CB2A: SRA D  
                                  Encoding = new byte[] { 0xCB, 0x2A },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRA },
            new OpcodeEncoding { // CB2B: SRA E  
                                  Encoding = new byte[] { 0xCB, 0x2B },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRA },
            new OpcodeEncoding { // CB2C: SRA H  
                                  Encoding = new byte[] { 0xCB, 0x2C },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRA },
            new OpcodeEncoding { // CB2D: SRA L  
                                  Encoding = new byte[] { 0xCB, 0x2D },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRA },
            new OpcodeEncoding { // CB3E: SRL (HL)  
                                  Encoding = new byte[] { 0xCB, 0x3E },
                                  Param1 = CommandID.HL, Param1Type = ParameterType.RegisterPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRL },
            new OpcodeEncoding { // DDCB3E: SRL (IX)   
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x3E },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRL },
            new OpcodeEncoding { // FDCB3E: SRL (IY)   
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x3E },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterDisplacedPtr,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRL },
            new OpcodeEncoding { // DDCB3F: SRL (IX) A a
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x3F },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRL },
            new OpcodeEncoding { // FDCB3F: SRL (IY) A a
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x3F },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRL },
            new OpcodeEncoding { // DDCB38: SRL (IX) B b
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x38 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRL },
            new OpcodeEncoding { // FDCB38: SRL (IY) B b
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x38 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRL },
            new OpcodeEncoding { // DDCB39: SRL (IX) C c
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x39 },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRL },
            new OpcodeEncoding { // FDCB39: SRL (IY) C c
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x39 },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRL },
            new OpcodeEncoding { // DDCB3A: SRL (IX) D d
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x3A },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRL },
            new OpcodeEncoding { // FDCB3A: SRL (IY) D d
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x3A },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRL },
            new OpcodeEncoding { // DDCB3B: SRL (IX) E e
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x3B },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRL },
            new OpcodeEncoding { // FDCB3B: SRL (IY) E e
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x3B },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRL },
            new OpcodeEncoding { // DDCB3C: SRL (IX) H h
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x3C },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRL },
            new OpcodeEncoding { // FDCB3C: SRL (IY) H h
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x3C },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRL },
            new OpcodeEncoding { // DDCB3D: SRL (IX) L l
                                  Encoding = new byte[] { 0xDD, 0xCB, 0x3D },
                                  Param1 = CommandID.IX, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRL },
            new OpcodeEncoding { // FDCB3D: SRL (IY) L l
                                  Encoding = new byte[] { 0xFD, 0xCB, 0x3D },
                                  Param1 = CommandID.IY, Param1Type = ParameterType.RegisterWord,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.InternalDisplacement, Function = CommandID.SRL },
            new OpcodeEncoding { // CB3F: SRL A  
                                  Encoding = new byte[] { 0xCB, 0x3F },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRL },
            new OpcodeEncoding { // CB38: SRL B  
                                  Encoding = new byte[] { 0xCB, 0x38 },
                                  Param1 = CommandID.B, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRL },
            new OpcodeEncoding { // CB39: SRL C  
                                  Encoding = new byte[] { 0xCB, 0x39 },
                                  Param1 = CommandID.C, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRL },
            new OpcodeEncoding { // CB3A: SRL D  
                                  Encoding = new byte[] { 0xCB, 0x3A },
                                  Param1 = CommandID.D, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRL },
            new OpcodeEncoding { // CB3B: SRL E  
                                  Encoding = new byte[] { 0xCB, 0x3B },
                                  Param1 = CommandID.E, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRL },
            new OpcodeEncoding { // CB3C: SRL H  
                                  Encoding = new byte[] { 0xCB, 0x3C },
                                  Param1 = CommandID.H, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRL },
            new OpcodeEncoding { // CB3D: SRL L  
                                  Encoding = new byte[] { 0xCB, 0x3D },
                                  Param1 = CommandID.L, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.None, Param2Type = ParameterType.None,
                                  Flags = ParamFlags.None, Function = CommandID.SRL },
            new OpcodeEncoding { // 96: SUB A (HL) 
                                  Encoding = new byte[] { 0x96 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.SUB },
            new OpcodeEncoding { // DD96: SUB A (IX) 
                                  Encoding = new byte[] { 0xDD, 0x96 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SUB },
            new OpcodeEncoding { // FD96: SUB A (IY) 
                                  Encoding = new byte[] { 0xFD, 0x96 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.SUB },
            new OpcodeEncoding { // 97: SUB A A 
                                  Encoding = new byte[] { 0x97 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SUB },
            new OpcodeEncoding { // 90: SUB A B 
                                  Encoding = new byte[] { 0x90 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SUB },
            new OpcodeEncoding { // 91: SUB A C 
                                  Encoding = new byte[] { 0x91 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SUB },
            new OpcodeEncoding { // 92: SUB A D 
                                  Encoding = new byte[] { 0x92 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SUB },
            new OpcodeEncoding { // 93: SUB A E 
                                  Encoding = new byte[] { 0x93 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SUB },
            new OpcodeEncoding { // 94: SUB A H 
                                  Encoding = new byte[] { 0x94 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SUB },
            new OpcodeEncoding { // DD94: SUB A IXH 
                                  Encoding = new byte[] { 0xDD, 0x94 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.SUB },
            new OpcodeEncoding { // FD94: SUB A IYH 
                                  Encoding = new byte[] { 0xFD, 0x94 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.SUB },
            new OpcodeEncoding { // 95: SUB A L 
                                  Encoding = new byte[] { 0x95 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.SUB },
            new OpcodeEncoding { // DD95: SUB A IXL 
                                  Encoding = new byte[] { 0xDD, 0x95 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.SUB },
            new OpcodeEncoding { // FD95: SUB A IYL 
                                  Encoding = new byte[] { 0xFD, 0x95 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.SUB },
            new OpcodeEncoding { // D6: SUB A N 
                                  Encoding = new byte[] { 0xD6 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.SUB },
            new OpcodeEncoding { // AE: XOR A (HL) 
                                  Encoding = new byte[] { 0xAE },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.HL, Param2Type = ParameterType.RegisterPtr,
                                  Flags = ParamFlags.None, Function = CommandID.XOR },
            new OpcodeEncoding { // DDAE: XOR A (IX) 
                                  Encoding = new byte[] { 0xDD, 0xAE },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IX, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.XOR },
            new OpcodeEncoding { // FDAE: XOR A (IY) 
                                  Encoding = new byte[] { 0xFD, 0xAE },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IY, Param2Type = ParameterType.RegisterDisplacedPtr,
                                  Flags = ParamFlags.Displacement, Function = CommandID.XOR },
            new OpcodeEncoding { // AF: XOR A A 
                                  Encoding = new byte[] { 0xAF },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.A, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.XOR },
            new OpcodeEncoding { // A8: XOR A B 
                                  Encoding = new byte[] { 0xA8 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.B, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.XOR },
            new OpcodeEncoding { // A9: XOR A C 
                                  Encoding = new byte[] { 0xA9 },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.C, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.XOR },
            new OpcodeEncoding { // AA: XOR A D 
                                  Encoding = new byte[] { 0xAA },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.D, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.XOR },
            new OpcodeEncoding { // AB: XOR A E 
                                  Encoding = new byte[] { 0xAB },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.E, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.XOR },
            new OpcodeEncoding { // AC: XOR A H 
                                  Encoding = new byte[] { 0xAC },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.H, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.XOR },
            new OpcodeEncoding { // DDAC: XOR A IXH 
                                  Encoding = new byte[] { 0xDD, 0xAC },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.XOR },
            new OpcodeEncoding { // FDAC: XOR A IYH 
                                  Encoding = new byte[] { 0xFD, 0xAC },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYH, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.XOR },
            new OpcodeEncoding { // AD: XOR A L 
                                  Encoding = new byte[] { 0xAD },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.L, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.None, Function = CommandID.XOR },
            new OpcodeEncoding { // DDAD: XOR A IXL 
                                  Encoding = new byte[] { 0xDD, 0xAD },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IXL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.XOR },
            new OpcodeEncoding { // FDAD: XOR A IYL 
                                  Encoding = new byte[] { 0xFD, 0xAD },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.IYL, Param2Type = ParameterType.RegisterByte,
                                  Flags = ParamFlags.Index, Function = CommandID.XOR },
            new OpcodeEncoding { // EE: XOR A N 
                                  Encoding = new byte[] { 0xEE },
                                  Param1 = CommandID.A, Param1Type = ParameterType.RegisterByte,
                                  Param2 = CommandID.ImmediateByte, Param2Type = ParameterType.Immediate,
                                  Flags = ParamFlags.None, Function = CommandID.XOR },
        };
    }
}
