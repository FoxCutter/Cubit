namespace ZASM
{
    static class Ops
    {
        static public OpcodeEncoding[] EncodingData = new OpcodeEncoding[]
        {
            new OpcodeEncoding { Name = "NOP",	// 0: NOP  
                                  Encoding = new byte[] { 0x00 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.NOP },
            new OpcodeEncoding { Name = "LD",	// 1: LD BC nn
                                  Encoding = new byte[] { 0x01 },
                                  Reg1 = Register.BC, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 2: LD (BC) A
                                  Encoding = new byte[] { 0x02 },
                                  Reg1 = Register.BC, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "INC",	// 3: INC BC 
                                  Encoding = new byte[] { 0x03 },
                                  Reg1 = Register.BC, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.INC },
            new OpcodeEncoding { Name = "INC",	// 4: INC B 
                                  Encoding = new byte[] { 0x04 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.INC },
            new OpcodeEncoding { Name = "DEC",	// 5: DEC B 
                                  Encoding = new byte[] { 0x05 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.DEC },
            new OpcodeEncoding { Name = "LD",	// 6: LD B n
                                  Encoding = new byte[] { 0x06 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "RLCA",	// 7: RLCA  
                                  Encoding = new byte[] { 0x07 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RLCA },
            new OpcodeEncoding { Name = "EX",	// 8: EX AF AF
                                  Encoding = new byte[] { 0x08 },
                                  Reg1 = Register.AF, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.AF, Reg2Param = RegParam.WordData,
                                  Function = CommandID.EX },
            new OpcodeEncoding { Name = "ADD",	// 9: ADD HL BC
                                  Encoding = new byte[] { 0x09 },
                                  Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.BC, Reg2Param = RegParam.WordData,
                                  Function = CommandID.ADD },
            new OpcodeEncoding { Name = "LD",	// 0A: LD A (BC)
                                  Encoding = new byte[] { 0x0A },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.BC, Reg2Param = RegParam.Reference,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "DEC",	// 0B: DEC BC 
                                  Encoding = new byte[] { 0x0B },
                                  Reg1 = Register.BC, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.DEC },
            new OpcodeEncoding { Name = "INC",	// 0C: INC C 
                                  Encoding = new byte[] { 0x0C },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.INC },
            new OpcodeEncoding { Name = "DEC",	// 0D: DEC C 
                                  Encoding = new byte[] { 0x0D },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.DEC },
            new OpcodeEncoding { Name = "LD",	// 0E: LD C n
                                  Encoding = new byte[] { 0x0E },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "RRCA",	// 0F: RRCA  
                                  Encoding = new byte[] { 0x0F },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RRCA },
            new OpcodeEncoding { Name = "DJNZ",	// 10: DJNZ e-2 
                                  Encoding = new byte[] { 0x10 },
                                  Reg1 = Register.ImmediateByte, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.DJNZ },
            new OpcodeEncoding { Name = "LD",	// 11: LD DE nn
                                  Encoding = new byte[] { 0x11 },
                                  Reg1 = Register.DE, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 12: LD (DE) A
                                  Encoding = new byte[] { 0x12 },
                                  Reg1 = Register.DE, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "INC",	// 13: INC DE 
                                  Encoding = new byte[] { 0x13 },
                                  Reg1 = Register.DE, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.INC },
            new OpcodeEncoding { Name = "INC",	// 14: INC D 
                                  Encoding = new byte[] { 0x14 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.INC },
            new OpcodeEncoding { Name = "DEC",	// 15: DEC D 
                                  Encoding = new byte[] { 0x15 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.DEC },
            new OpcodeEncoding { Name = "LD",	// 16: LD D n
                                  Encoding = new byte[] { 0x16 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "RLA",	// 17: RLA  
                                  Encoding = new byte[] { 0x17 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RLA },
            new OpcodeEncoding { Name = "JR",	// 18: JR e-2 
                                  Encoding = new byte[] { 0x18 },
                                  Reg1 = Register.ImmediateByte, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.JR },
            new OpcodeEncoding { Name = "ADD",	// 19: ADD HL DE
                                  Encoding = new byte[] { 0x19 },
                                  Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.DE, Reg2Param = RegParam.WordData,
                                  Function = CommandID.ADD },
            new OpcodeEncoding { Name = "LD",	// 1A: LD A (DE)
                                  Encoding = new byte[] { 0x1A },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.DE, Reg2Param = RegParam.Reference,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "DEC",	// 1B: DEC DE 
                                  Encoding = new byte[] { 0x1B },
                                  Reg1 = Register.DE, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.DEC },
            new OpcodeEncoding { Name = "INC",	// 1C: INC E 
                                  Encoding = new byte[] { 0x1C },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.INC },
            new OpcodeEncoding { Name = "DEC",	// 1D: DEC E 
                                  Encoding = new byte[] { 0x1D },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.DEC },
            new OpcodeEncoding { Name = "LD",	// 1E: LD E n
                                  Encoding = new byte[] { 0x1E },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "RRA",	// 1F: RRA  
                                  Encoding = new byte[] { 0x1F },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RRA },
            new OpcodeEncoding { Name = "JR",	// 20: JR NZ e-2
                                  Encoding = new byte[] { 0x20 },
                                  Reg1 = (Register)ConditionCode.NZ, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                  Function = CommandID.JR },
            new OpcodeEncoding { Name = "LD",	// 21: LD HL nn
                                  Encoding = new byte[] { 0x21 },
                                  Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 22: LD (nn) HL
                                  Encoding = new byte[] { 0x22 },
                                  Reg1 = Register.ImmediateWord, Reg1Param = RegParam.Reference | RegParam.WordData,
                                  Reg2 = Register.HX, Reg2Param = RegParam.WordData,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "INC",	// 23: INC HL 
                                  Encoding = new byte[] { 0x23 },
                                  Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.INC },
            new OpcodeEncoding { Name = "INC",	// 24: INC H 
                                  Encoding = new byte[] { 0x24 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.INC },
            new OpcodeEncoding { Name = "DEC",	// 25: DEC H 
                                  Encoding = new byte[] { 0x25 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.DEC },
            new OpcodeEncoding { Name = "LD",	// 26: LD H n
                                  Encoding = new byte[] { 0x26 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "DAA",	// 27: DAA  
                                  Encoding = new byte[] { 0x27 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.DAA },
            new OpcodeEncoding { Name = "JR",	// 28: JR Z e-2
                                  Encoding = new byte[] { 0x28 },
                                  Reg1 = (Register)ConditionCode.Z, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                  Function = CommandID.JR },
            new OpcodeEncoding { Name = "ADD",	// 29: ADD HL HL
                                  Encoding = new byte[] { 0x29 },
                                  Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.HX, Reg2Param = RegParam.WordData,
                                  Function = CommandID.ADD },
            new OpcodeEncoding { Name = "LD",	// 2A: LD HL (nn)
                                  Encoding = new byte[] { 0x2A },
                                  Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.Reference | RegParam.WordData,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "DEC",	// 2B: DEC HL 
                                  Encoding = new byte[] { 0x2B },
                                  Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.DEC },
            new OpcodeEncoding { Name = "INC",	// 2C: INC L 
                                  Encoding = new byte[] { 0x2C },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.INC },
            new OpcodeEncoding { Name = "DEC",	// 2D: DEC L 
                                  Encoding = new byte[] { 0x2D },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.DEC },
            new OpcodeEncoding { Name = "LD",	// 2E: LD L n
                                  Encoding = new byte[] { 0x2E },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "CPL",	// 2F: CPL  
                                  Encoding = new byte[] { 0x2F },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.CPL },
            new OpcodeEncoding { Name = "JR",	// 30: JR NC e-2
                                  Encoding = new byte[] { 0x30 },
                                  Reg1 = (Register)ConditionCode.NC, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                  Function = CommandID.JR },
            new OpcodeEncoding { Name = "LD",	// 31: LD SP nn
                                  Encoding = new byte[] { 0x31 },
                                  Reg1 = Register.SP, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 32: LD (nn) A
                                  Encoding = new byte[] { 0x32 },
                                  Reg1 = Register.ImmediateWord, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "INC",	// 33: INC SP 
                                  Encoding = new byte[] { 0x33 },
                                  Reg1 = Register.SP, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.INC },
            new OpcodeEncoding { Name = "INC",	// 34: INC (HL) 
                                  Encoding = new byte[] { 0x34 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.INC },
            new OpcodeEncoding { Name = "DEC",	// 35: DEC (HL) 
                                  Encoding = new byte[] { 0x35 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.DEC },
            new OpcodeEncoding { Name = "LD",	// 36: LD (HL) n
                                  Encoding = new byte[] { 0x36 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "SCF",	// 37: SCF  
                                  Encoding = new byte[] { 0x37 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SCF },
            new OpcodeEncoding { Name = "JR",	// 38: JR CY e-2
                                  Encoding = new byte[] { 0x38 },
                                  Reg1 = (Register)ConditionCode.CY, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                  Function = CommandID.JR },
            new OpcodeEncoding { Name = "ADD",	// 39: ADD HL SP
                                  Encoding = new byte[] { 0x39 },
                                  Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.SP, Reg2Param = RegParam.WordData,
                                  Function = CommandID.ADD },
            new OpcodeEncoding { Name = "LD",	// 3A: LD A (nn)
                                  Encoding = new byte[] { 0x3A },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.Reference,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "DEC",	// 3B: DEC SP 
                                  Encoding = new byte[] { 0x3B },
                                  Reg1 = Register.SP, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.DEC },
            new OpcodeEncoding { Name = "INC",	// 3C: INC A 
                                  Encoding = new byte[] { 0x3C },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.INC },
            new OpcodeEncoding { Name = "DEC",	// 3D: DEC A 
                                  Encoding = new byte[] { 0x3D },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.DEC },
            new OpcodeEncoding { Name = "LD",	// 3E: LD A n
                                  Encoding = new byte[] { 0x3E },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "CCF",	// 3F: CCF  
                                  Encoding = new byte[] { 0x3F },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.CCF },
            new OpcodeEncoding { Name = "LD",	// 40: LD B B
                                  Encoding = new byte[] { 0x40 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 41: LD B C
                                  Encoding = new byte[] { 0x41 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 42: LD B D
                                  Encoding = new byte[] { 0x42 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 43: LD B E
                                  Encoding = new byte[] { 0x43 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 44: LD B H
                                  Encoding = new byte[] { 0x44 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 45: LD B L
                                  Encoding = new byte[] { 0x45 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 46: LD B (HL)
                                  Encoding = new byte[] { 0x46 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 47: LD B A
                                  Encoding = new byte[] { 0x47 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 48: LD C B
                                  Encoding = new byte[] { 0x48 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 49: LD C C
                                  Encoding = new byte[] { 0x49 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 4A: LD C D
                                  Encoding = new byte[] { 0x4A },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 4B: LD C E
                                  Encoding = new byte[] { 0x4B },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 4C: LD C H
                                  Encoding = new byte[] { 0x4C },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 4D: LD C L
                                  Encoding = new byte[] { 0x4D },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 4E: LD C (HL)
                                  Encoding = new byte[] { 0x4E },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 4F: LD C A
                                  Encoding = new byte[] { 0x4F },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 50: LD D B
                                  Encoding = new byte[] { 0x50 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 51: LD D C
                                  Encoding = new byte[] { 0x51 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 52: LD D D
                                  Encoding = new byte[] { 0x52 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 53: LD D E
                                  Encoding = new byte[] { 0x53 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 54: LD D H
                                  Encoding = new byte[] { 0x54 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 55: LD D L
                                  Encoding = new byte[] { 0x55 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 56: LD D (HL)
                                  Encoding = new byte[] { 0x56 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 57: LD D A
                                  Encoding = new byte[] { 0x57 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 58: LD E B
                                  Encoding = new byte[] { 0x58 },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 59: LD E C
                                  Encoding = new byte[] { 0x59 },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 5A: LD E D
                                  Encoding = new byte[] { 0x5A },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 5B: LD E E
                                  Encoding = new byte[] { 0x5B },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 5C: LD E H
                                  Encoding = new byte[] { 0x5C },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 5D: LD E L
                                  Encoding = new byte[] { 0x5D },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 5E: LD E (HL)
                                  Encoding = new byte[] { 0x5E },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 5F: LD E A
                                  Encoding = new byte[] { 0x5F },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 60: LD H B
                                  Encoding = new byte[] { 0x60 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 61: LD H C
                                  Encoding = new byte[] { 0x61 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 62: LD H D
                                  Encoding = new byte[] { 0x62 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 63: LD H E
                                  Encoding = new byte[] { 0x63 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 64: LD H H
                                  Encoding = new byte[] { 0x64 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 65: LD H L
                                  Encoding = new byte[] { 0x65 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 66: LD H (HL)
                                  Encoding = new byte[] { 0x66 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 67: LD H A
                                  Encoding = new byte[] { 0x67 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 68: LD L B
                                  Encoding = new byte[] { 0x68 },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 69: LD L C
                                  Encoding = new byte[] { 0x69 },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 6A: LD L D
                                  Encoding = new byte[] { 0x6A },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 6B: LD L E
                                  Encoding = new byte[] { 0x6B },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 6C: LD L H
                                  Encoding = new byte[] { 0x6C },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 6D: LD L L
                                  Encoding = new byte[] { 0x6D },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 6E: LD L (HL)
                                  Encoding = new byte[] { 0x6E },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 6F: LD L A
                                  Encoding = new byte[] { 0x6F },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 70: LD (HL) B
                                  Encoding = new byte[] { 0x70 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 71: LD (HL) C
                                  Encoding = new byte[] { 0x71 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 72: LD (HL) D
                                  Encoding = new byte[] { 0x72 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 73: LD (HL) E
                                  Encoding = new byte[] { 0x73 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 74: LD (HL) H
                                  Encoding = new byte[] { 0x74 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 75: LD (HL) L
                                  Encoding = new byte[] { 0x75 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "HALT",	// 76: HALT  
                                  Encoding = new byte[] { 0x76 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.HALT },
            new OpcodeEncoding { Name = "LD",	// 77: LD (HL) A
                                  Encoding = new byte[] { 0x77 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 78: LD A B
                                  Encoding = new byte[] { 0x78 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 79: LD A C
                                  Encoding = new byte[] { 0x79 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 7A: LD A D
                                  Encoding = new byte[] { 0x7A },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 7B: LD A E
                                  Encoding = new byte[] { 0x7B },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 7C: LD A H
                                  Encoding = new byte[] { 0x7C },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 7D: LD A L
                                  Encoding = new byte[] { 0x7D },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 7E: LD A (HL)
                                  Encoding = new byte[] { 0x7E },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "LD",	// 7F: LD A A
                                  Encoding = new byte[] { 0x7F },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "ADD",	// 80: ADD A B
                                  Encoding = new byte[] { 0x80 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 81: ADD A C
                                  Encoding = new byte[] { 0x81 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 82: ADD A D
                                  Encoding = new byte[] { 0x82 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 83: ADD A E
                                  Encoding = new byte[] { 0x83 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 84: ADD A H
                                  Encoding = new byte[] { 0x84 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 85: ADD A L
                                  Encoding = new byte[] { 0x85 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 86: ADD A (HL)
                                  Encoding = new byte[] { 0x86 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADD",	// 87: ADD A A
                                  Encoding = new byte[] { 0x87 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.ADD },
            new OpcodeEncoding { Name = "ADC",	// 88: ADC A B
                                  Encoding = new byte[] { 0x88 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// 89: ADC A C
                                  Encoding = new byte[] { 0x89 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// 8A: ADC A D
                                  Encoding = new byte[] { 0x8A },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// 8B: ADC A E
                                  Encoding = new byte[] { 0x8B },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// 8C: ADC A H
                                  Encoding = new byte[] { 0x8C },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// 8D: ADC A L
                                  Encoding = new byte[] { 0x8D },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// 8E: ADC A (HL)
                                  Encoding = new byte[] { 0x8E },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.ADC },
            new OpcodeEncoding { Name = "ADC",	// 8F: ADC A A
                                  Encoding = new byte[] { 0x8F },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.ADC },
            new OpcodeEncoding { Name = "SUB",	// 90: SUB B 
                                  Encoding = new byte[] { 0x90 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SUB },
            new OpcodeEncoding { Name = "SUB",	// 91: SUB C 
                                  Encoding = new byte[] { 0x91 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SUB },
            new OpcodeEncoding { Name = "SUB",	// 92: SUB D 
                                  Encoding = new byte[] { 0x92 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SUB },
            new OpcodeEncoding { Name = "SUB",	// 93: SUB E 
                                  Encoding = new byte[] { 0x93 },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SUB },
            new OpcodeEncoding { Name = "SUB",	// 94: SUB H 
                                  Encoding = new byte[] { 0x94 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SUB },
            new OpcodeEncoding { Name = "SUB",	// 95: SUB L 
                                  Encoding = new byte[] { 0x95 },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SUB },
            new OpcodeEncoding { Name = "SUB",	// 96: SUB (HL) 
                                  Encoding = new byte[] { 0x96 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SUB },
            new OpcodeEncoding { Name = "SUB",	// 97: SUB A 
                                  Encoding = new byte[] { 0x97 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SUB },
            new OpcodeEncoding { Name = "SBC",	// 98: SBC A B
                                  Encoding = new byte[] { 0x98 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// 99: SBC A C
                                  Encoding = new byte[] { 0x99 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// 9A: SBC A D
                                  Encoding = new byte[] { 0x9A },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// 9B: SBC A E
                                  Encoding = new byte[] { 0x9B },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// 9C: SBC A H
                                  Encoding = new byte[] { 0x9C },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// 9D: SBC A L
                                  Encoding = new byte[] { 0x9D },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// 9E: SBC A (HL)
                                  Encoding = new byte[] { 0x9E },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.SBC },
            new OpcodeEncoding { Name = "SBC",	// 9F: SBC A A
                                  Encoding = new byte[] { 0x9F },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.SBC },
            new OpcodeEncoding { Name = "AND",	// A0: AND B 
                                  Encoding = new byte[] { 0xA0 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.AND },
            new OpcodeEncoding { Name = "AND",	// A1: AND C 
                                  Encoding = new byte[] { 0xA1 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.AND },
            new OpcodeEncoding { Name = "AND",	// A2: AND D 
                                  Encoding = new byte[] { 0xA2 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.AND },
            new OpcodeEncoding { Name = "AND",	// A3: AND E 
                                  Encoding = new byte[] { 0xA3 },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.AND },
            new OpcodeEncoding { Name = "AND",	// A4: AND H 
                                  Encoding = new byte[] { 0xA4 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.AND },
            new OpcodeEncoding { Name = "AND",	// A5: AND L 
                                  Encoding = new byte[] { 0xA5 },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.AND },
            new OpcodeEncoding { Name = "AND",	// A6: AND (HL) 
                                  Encoding = new byte[] { 0xA6 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.AND },
            new OpcodeEncoding { Name = "AND",	// A7: AND A 
                                  Encoding = new byte[] { 0xA7 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.AND },
            new OpcodeEncoding { Name = "XOR",	// A8: XOR B 
                                  Encoding = new byte[] { 0xA8 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.XOR },
            new OpcodeEncoding { Name = "XOR",	// A9: XOR C 
                                  Encoding = new byte[] { 0xA9 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.XOR },
            new OpcodeEncoding { Name = "XOR",	// AA: XOR D 
                                  Encoding = new byte[] { 0xAA },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.XOR },
            new OpcodeEncoding { Name = "XOR",	// AB: XOR E 
                                  Encoding = new byte[] { 0xAB },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.XOR },
            new OpcodeEncoding { Name = "XOR",	// AC: XOR H 
                                  Encoding = new byte[] { 0xAC },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.XOR },
            new OpcodeEncoding { Name = "XOR",	// AD: XOR L 
                                  Encoding = new byte[] { 0xAD },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.XOR },
            new OpcodeEncoding { Name = "XOR",	// AE: XOR (HL) 
                                  Encoding = new byte[] { 0xAE },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.XOR },
            new OpcodeEncoding { Name = "XOR",	// AF: XOR A 
                                  Encoding = new byte[] { 0xAF },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.XOR },
            new OpcodeEncoding { Name = "OR",	// B0: OR B 
                                  Encoding = new byte[] { 0xB0 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.OR },
            new OpcodeEncoding { Name = "OR",	// B1: OR C 
                                  Encoding = new byte[] { 0xB1 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.OR },
            new OpcodeEncoding { Name = "OR",	// B2: OR D 
                                  Encoding = new byte[] { 0xB2 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.OR },
            new OpcodeEncoding { Name = "OR",	// B3: OR E 
                                  Encoding = new byte[] { 0xB3 },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.OR },
            new OpcodeEncoding { Name = "OR",	// B4: OR H 
                                  Encoding = new byte[] { 0xB4 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.OR },
            new OpcodeEncoding { Name = "OR",	// B5: OR L 
                                  Encoding = new byte[] { 0xB5 },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.OR },
            new OpcodeEncoding { Name = "OR",	// B6: OR (HL) 
                                  Encoding = new byte[] { 0xB6 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.OR },
            new OpcodeEncoding { Name = "OR",	// B7: OR A 
                                  Encoding = new byte[] { 0xB7 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.OR },
            new OpcodeEncoding { Name = "CP",	// B8: CP B 
                                  Encoding = new byte[] { 0xB8 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.CP },
            new OpcodeEncoding { Name = "CP",	// B9: CP C 
                                  Encoding = new byte[] { 0xB9 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.CP },
            new OpcodeEncoding { Name = "CP",	// BA: CP D 
                                  Encoding = new byte[] { 0xBA },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.CP },
            new OpcodeEncoding { Name = "CP",	// BB: CP E 
                                  Encoding = new byte[] { 0xBB },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.CP },
            new OpcodeEncoding { Name = "CP",	// BC: CP H 
                                  Encoding = new byte[] { 0xBC },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.CP },
            new OpcodeEncoding { Name = "CP",	// BD: CP L 
                                  Encoding = new byte[] { 0xBD },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.CP },
            new OpcodeEncoding { Name = "CP",	// BE: CP (HL) 
                                  Encoding = new byte[] { 0xBE },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.CP },
            new OpcodeEncoding { Name = "CP",	// BF: CP A 
                                  Encoding = new byte[] { 0xBF },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.CP },
            new OpcodeEncoding { Name = "RET",	// C0: RET NZ 
                                  Encoding = new byte[] { 0xC0 },
                                  Reg1 = (Register)ConditionCode.NZ, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RET },
            new OpcodeEncoding { Name = "POP",	// C1: POP BC 
                                  Encoding = new byte[] { 0xC1 },
                                  Reg1 = Register.BC, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.POP },
            new OpcodeEncoding { Name = "JP",	// C2: JP NZ nn
                                  Encoding = new byte[] { 0xC2 },
                                  Reg1 = (Register)ConditionCode.NZ, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.JP },
            new OpcodeEncoding { Name = "JP",	// C3: JP nn 
                                  Encoding = new byte[] { 0xC3 },
                                  Reg1 = Register.ImmediateWord, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.JP },
            new OpcodeEncoding { Name = "CALL",	// C4: CALL NZ nn
                                  Encoding = new byte[] { 0xC4 },
                                  Reg1 = (Register)ConditionCode.NZ, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.CALL },
            new OpcodeEncoding { Name = "PUSH",	// C5: PUSH BC 
                                  Encoding = new byte[] { 0xC5 },
                                  Reg1 = Register.BC, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.PUSH },
            new OpcodeEncoding { Name = "ADD",	// C6: ADD A n
                                  Encoding = new byte[] { 0xC6 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                  Function = CommandID.ADD },
            new OpcodeEncoding { Name = "RST",	// C7: RST 0H 
                                  Encoding = new byte[] { 0xC7 },
                                  Reg1 = (Register)0x0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RST },
            new OpcodeEncoding { Name = "RET",	// C8: RET Z 
                                  Encoding = new byte[] { 0xC8 },
                                  Reg1 = (Register)ConditionCode.Z, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RET },
            new OpcodeEncoding { Name = "RET",	// C9: RET  
                                  Encoding = new byte[] { 0xC9 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RET },
            new OpcodeEncoding { Name = "JP",	// CA: JP Z nn
                                  Encoding = new byte[] { 0xCA },
                                  Reg1 = (Register)ConditionCode.Z, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.JP },
            new OpcodeEncoding { Name = "CALL",	// CC: CALL Z nn
                                  Encoding = new byte[] { 0xCC },
                                  Reg1 = (Register)ConditionCode.Z, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.CALL },
            new OpcodeEncoding { Name = "CALL",	// CD: CALL nn 
                                  Encoding = new byte[] { 0xCD },
                                  Reg1 = Register.ImmediateWord, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.CALL },
            new OpcodeEncoding { Name = "ADC",	// CE: ADC A n
                                  Encoding = new byte[] { 0xCE },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                  Function = CommandID.ADC },
            new OpcodeEncoding { Name = "RST",	// CF: RST 8H 
                                  Encoding = new byte[] { 0xCF },
                                  Reg1 = (Register)0x8, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RST },
            new OpcodeEncoding { Name = "RET",	// D0: RET NC 
                                  Encoding = new byte[] { 0xD0 },
                                  Reg1 = (Register)ConditionCode.NC, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RET },
            new OpcodeEncoding { Name = "POP",	// D1: POP DE 
                                  Encoding = new byte[] { 0xD1 },
                                  Reg1 = Register.DE, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.POP },
            new OpcodeEncoding { Name = "JP",	// D2: JP NC nn
                                  Encoding = new byte[] { 0xD2 },
                                  Reg1 = (Register)ConditionCode.NC, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.JP },
            new OpcodeEncoding { Name = "OUT",	// D3: OUT (n) A
                                  Encoding = new byte[] { 0xD3 },
                                  Reg1 = Register.ImmediateByte, Reg1Param = RegParam.None,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.OUT },
            new OpcodeEncoding { Name = "CALL",	// D4: CALL NC nn
                                  Encoding = new byte[] { 0xD4 },
                                  Reg1 = (Register)ConditionCode.NC, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.CALL },
            new OpcodeEncoding { Name = "PUSH",	// D5: PUSH DE 
                                  Encoding = new byte[] { 0xD5 },
                                  Reg1 = Register.DE, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.PUSH },
            new OpcodeEncoding { Name = "SUB",	// D6: SUB n 
                                  Encoding = new byte[] { 0xD6 },
                                  Reg1 = Register.ImmediateByte, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SUB },
            new OpcodeEncoding { Name = "RST",	// D7: RST 10H 
                                  Encoding = new byte[] { 0xD7 },
                                  Reg1 = (Register)0x10, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RST },
            new OpcodeEncoding { Name = "RET",	// D8: RET CY 
                                  Encoding = new byte[] { 0xD8 },
                                  Reg1 = (Register)ConditionCode.CY, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RET },
            new OpcodeEncoding { Name = "EXX",	// D9: EXX  
                                  Encoding = new byte[] { 0xD9 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.EXX },
            new OpcodeEncoding { Name = "JP",	// DA: JP CY nn
                                  Encoding = new byte[] { 0xDA },
                                  Reg1 = (Register)ConditionCode.CY, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.JP },
            new OpcodeEncoding { Name = "IN",	// DB: IN A (n)
                                  Encoding = new byte[] { 0xDB },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                  Function = CommandID.IN },
            new OpcodeEncoding { Name = "CALL",	// DC: CALL CY nn
                                  Encoding = new byte[] { 0xDC },
                                  Reg1 = (Register)ConditionCode.CY, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.CALL },
            new OpcodeEncoding { Name = "SBC",	// DE: SBC A n
                                  Encoding = new byte[] { 0xDE },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                  Function = CommandID.SBC },
            new OpcodeEncoding { Name = "RST",	// DF: RST 18H 
                                  Encoding = new byte[] { 0xDF },
                                  Reg1 = (Register)0x18, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RST },
            new OpcodeEncoding { Name = "RET",	// E0: RET PO 
                                  Encoding = new byte[] { 0xE0 },
                                  Reg1 = (Register)ConditionCode.PO, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RET },
            new OpcodeEncoding { Name = "POP",	// E1: POP HL 
                                  Encoding = new byte[] { 0xE1 },
                                  Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.POP },
            new OpcodeEncoding { Name = "JP",	// E2: JP PO nn
                                  Encoding = new byte[] { 0xE2 },
                                  Reg1 = (Register)ConditionCode.PO, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.JP },
            new OpcodeEncoding { Name = "EX",	// E3: EX (SP) HL
                                  Encoding = new byte[] { 0xE3 },
                                  Reg1 = Register.SP, Reg1Param = RegParam.Reference | RegParam.WordData,
                                  Reg2 = Register.HX, Reg2Param = RegParam.WordData,
                                  Function = CommandID.EX },
            new OpcodeEncoding { Name = "CALL",	// E4: CALL PO nn
                                  Encoding = new byte[] { 0xE4 },
                                  Reg1 = (Register)ConditionCode.PO, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.CALL },
            new OpcodeEncoding { Name = "PUSH",	// E5: PUSH HL 
                                  Encoding = new byte[] { 0xE5 },
                                  Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.PUSH },
            new OpcodeEncoding { Name = "AND",	// E6: AND n 
                                  Encoding = new byte[] { 0xE6 },
                                  Reg1 = Register.ImmediateByte, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.AND },
            new OpcodeEncoding { Name = "RST",	// E7: RST 20H 
                                  Encoding = new byte[] { 0xE7 },
                                  Reg1 = (Register)0x20, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RST },
            new OpcodeEncoding { Name = "RET",	// E8: RET PE 
                                  Encoding = new byte[] { 0xE8 },
                                  Reg1 = (Register)ConditionCode.PE, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RET },
            new OpcodeEncoding { Name = "JP",	// E9: JP (HL) 
                                  Encoding = new byte[] { 0xE9 },
                                  Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.JP },
            new OpcodeEncoding { Name = "JP",	// EA: JP PE nn
                                  Encoding = new byte[] { 0xEA },
                                  Reg1 = (Register)ConditionCode.PE, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.JP },
            new OpcodeEncoding { Name = "EX",	// EB: EX DE HL
                                  Encoding = new byte[] { 0xEB },
                                  Reg1 = Register.DE, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.HL, Reg2Param = RegParam.WordData,
                                  Function = CommandID.EX },
            new OpcodeEncoding { Name = "CALL",	// EC: CALL PE nn
                                  Encoding = new byte[] { 0xEC },
                                  Reg1 = (Register)ConditionCode.PE, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.CALL },
            new OpcodeEncoding { Name = "XOR",	// EE: XOR n 
                                  Encoding = new byte[] { 0xEE },
                                  Reg1 = Register.ImmediateByte, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.XOR },
            new OpcodeEncoding { Name = "RST",	// EF: RST 28H 
                                  Encoding = new byte[] { 0xEF },
                                  Reg1 = (Register)0x28, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RST },
            new OpcodeEncoding { Name = "RET",	// F0: RET P 
                                  Encoding = new byte[] { 0xF0 },
                                  Reg1 = (Register)ConditionCode.P, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RET },
            new OpcodeEncoding { Name = "POP",	// F1: POP AF 
                                  Encoding = new byte[] { 0xF1 },
                                  Reg1 = Register.AF, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.POP },
            new OpcodeEncoding { Name = "JP",	// F2: JP P nn
                                  Encoding = new byte[] { 0xF2 },
                                  Reg1 = (Register)ConditionCode.P, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.JP },
            new OpcodeEncoding { Name = "DI",	// F3: DI  
                                  Encoding = new byte[] { 0xF3 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.DI },
            new OpcodeEncoding { Name = "CALL",	// F4: CALL P nn
                                  Encoding = new byte[] { 0xF4 },
                                  Reg1 = (Register)ConditionCode.P, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.CALL },
            new OpcodeEncoding { Name = "PUSH",	// F5: PUSH AF 
                                  Encoding = new byte[] { 0xF5 },
                                  Reg1 = Register.AF, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.PUSH },
            new OpcodeEncoding { Name = "OR",	// F6: OR n 
                                  Encoding = new byte[] { 0xF6 },
                                  Reg1 = Register.ImmediateByte, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.OR },
            new OpcodeEncoding { Name = "RST",	// F7: RST 30H 
                                  Encoding = new byte[] { 0xF7 },
                                  Reg1 = (Register)0x30, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RST },
            new OpcodeEncoding { Name = "RET",	// F8: RET M 
                                  Encoding = new byte[] { 0xF8 },
                                  Reg1 = (Register)ConditionCode.M, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RET },
            new OpcodeEncoding { Name = "LD",	// F9: LD SP HL
                                  Encoding = new byte[] { 0xF9 },
                                  Reg1 = Register.SP, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.HX, Reg2Param = RegParam.WordData,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "JP",	// FA: JP M nn
                                  Encoding = new byte[] { 0xFA },
                                  Reg1 = (Register)ConditionCode.M, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.JP },
            new OpcodeEncoding { Name = "EI",	// FB: EI  
                                  Encoding = new byte[] { 0xFB },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.EI },
            new OpcodeEncoding { Name = "CALL",	// FC: CALL M nn
                                  Encoding = new byte[] { 0xFC },
                                  Reg1 = (Register)ConditionCode.M, Reg1Param = RegParam.ConditionCode,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                  Function = CommandID.CALL },
            new OpcodeEncoding { Name = "CP",	// FE: CP n 
                                  Encoding = new byte[] { 0xFE },
                                  Reg1 = Register.ImmediateByte, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.CP },
            new OpcodeEncoding { Name = "RST",	// FF: RST 38H 
                                  Encoding = new byte[] { 0xFF },
                                  Reg1 = (Register)0x38, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RST },
            new OpcodeEncoding { Name = "RLC",	// CB0: RLC  
                                  Encoding = new byte[] { 0xCB, 0x00 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// CB1: RLC C 
                                  Encoding = new byte[] { 0xCB, 0x01 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// CB2: RLC D 
                                  Encoding = new byte[] { 0xCB, 0x02 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// CB3: RLC E 
                                  Encoding = new byte[] { 0xCB, 0x03 },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// CB4: RLC H 
                                  Encoding = new byte[] { 0xCB, 0x04 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// CB5: RLC L 
                                  Encoding = new byte[] { 0xCB, 0x05 },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// CB6: RLC (HL) 
                                  Encoding = new byte[] { 0xCB, 0x06 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RLC",	// CB7: RLC A 
                                  Encoding = new byte[] { 0xCB, 0x07 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RLC },
            new OpcodeEncoding { Name = "RRC",	// CB8: RRC B 
                                  Encoding = new byte[] { 0xCB, 0x08 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// CB9: RRC C 
                                  Encoding = new byte[] { 0xCB, 0x09 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// CB0A: RRC D 
                                  Encoding = new byte[] { 0xCB, 0x0A },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// CB0B: RRC E 
                                  Encoding = new byte[] { 0xCB, 0x0B },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// CB0C: RRC H 
                                  Encoding = new byte[] { 0xCB, 0x0C },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// CB0D: RRC L 
                                  Encoding = new byte[] { 0xCB, 0x0D },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// CB0E: RRC (HL) 
                                  Encoding = new byte[] { 0xCB, 0x0E },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RRC",	// CB0F: RRC A 
                                  Encoding = new byte[] { 0xCB, 0x0F },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RRC },
            new OpcodeEncoding { Name = "RL",	// CB10: RL B 
                                  Encoding = new byte[] { 0xCB, 0x10 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// CB11: RL C 
                                  Encoding = new byte[] { 0xCB, 0x11 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// CB12: RL D 
                                  Encoding = new byte[] { 0xCB, 0x12 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// CB13: RL E 
                                  Encoding = new byte[] { 0xCB, 0x13 },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// CB14: RL H 
                                  Encoding = new byte[] { 0xCB, 0x14 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// CB15: RL L 
                                  Encoding = new byte[] { 0xCB, 0x15 },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// CB16: RL (HL) 
                                  Encoding = new byte[] { 0xCB, 0x16 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RL },
            new OpcodeEncoding { Name = "RL",	// CB17: RL A 
                                  Encoding = new byte[] { 0xCB, 0x17 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RL },
            new OpcodeEncoding { Name = "RR",	// CB18: RR B 
                                  Encoding = new byte[] { 0xCB, 0x18 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// CB19: RR C 
                                  Encoding = new byte[] { 0xCB, 0x19 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// CB1A: RR D 
                                  Encoding = new byte[] { 0xCB, 0x1A },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// CB1B: RR E 
                                  Encoding = new byte[] { 0xCB, 0x1B },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// CB1C: RR H 
                                  Encoding = new byte[] { 0xCB, 0x1C },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// CB1D: RR L 
                                  Encoding = new byte[] { 0xCB, 0x1D },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// CB1E: RR (HL) 
                                  Encoding = new byte[] { 0xCB, 0x1E },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RR },
            new OpcodeEncoding { Name = "RR",	// CB1F: RR A 
                                  Encoding = new byte[] { 0xCB, 0x1F },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RR },
            new OpcodeEncoding { Name = "SLA",	// CB20: SLA B 
                                  Encoding = new byte[] { 0xCB, 0x20 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// CB21: SLA C 
                                  Encoding = new byte[] { 0xCB, 0x21 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// CB22: SLA D 
                                  Encoding = new byte[] { 0xCB, 0x22 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// CB23: SLA E 
                                  Encoding = new byte[] { 0xCB, 0x23 },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// CB24: SLA H 
                                  Encoding = new byte[] { 0xCB, 0x24 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// CB25: SLA L 
                                  Encoding = new byte[] { 0xCB, 0x25 },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// CB26: SLA (HL) 
                                  Encoding = new byte[] { 0xCB, 0x26 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SLA",	// CB27: SLA A 
                                  Encoding = new byte[] { 0xCB, 0x27 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SLA },
            new OpcodeEncoding { Name = "SRA",	// CB28: SRA B 
                                  Encoding = new byte[] { 0xCB, 0x28 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// CB29: SRA C 
                                  Encoding = new byte[] { 0xCB, 0x29 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// CB2A: SRA D 
                                  Encoding = new byte[] { 0xCB, 0x2A },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// CB2B: SRA E 
                                  Encoding = new byte[] { 0xCB, 0x2B },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// CB2C: SRA H 
                                  Encoding = new byte[] { 0xCB, 0x2C },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// CB2D: SRA L 
                                  Encoding = new byte[] { 0xCB, 0x2D },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// CB2E: SRA (HL) 
                                  Encoding = new byte[] { 0xCB, 0x2E },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SRA",	// CB2F: SRA A 
                                  Encoding = new byte[] { 0xCB, 0x2F },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SRA },
            new OpcodeEncoding { Name = "SLL",	// CB30: SLL B 
                                  Encoding = new byte[] { 0xCB, 0x30 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// CB31: SLL C 
                                  Encoding = new byte[] { 0xCB, 0x31 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// CB32: SLL D 
                                  Encoding = new byte[] { 0xCB, 0x32 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// CB33: SLL E 
                                  Encoding = new byte[] { 0xCB, 0x33 },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// CB34: SLL H 
                                  Encoding = new byte[] { 0xCB, 0x34 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// CB35: SLL L 
                                  Encoding = new byte[] { 0xCB, 0x35 },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// CB36: SLL (HL) 
                                  Encoding = new byte[] { 0xCB, 0x36 },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SLL",	// CB37: SLL A 
                                  Encoding = new byte[] { 0xCB, 0x37 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SLL },
            new OpcodeEncoding { Name = "SRL",	// CB38: SRL B 
                                  Encoding = new byte[] { 0xCB, 0x38 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// CB39: SRL C 
                                  Encoding = new byte[] { 0xCB, 0x39 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// CB3A: SRL D 
                                  Encoding = new byte[] { 0xCB, 0x3A },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// CB3B: SRL E 
                                  Encoding = new byte[] { 0xCB, 0x3B },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// CB3C: SRL H 
                                  Encoding = new byte[] { 0xCB, 0x3C },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// CB3D: SRL L 
                                  Encoding = new byte[] { 0xCB, 0x3D },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// CB3E: SRL (HL) 
                                  Encoding = new byte[] { 0xCB, 0x3E },
                                  Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SRL },
            new OpcodeEncoding { Name = "SRL",	// CB3F: SRL A 
                                  Encoding = new byte[] { 0xCB, 0x3F },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.SRL },
            new OpcodeEncoding { Name = "BIT",	// CB40: BIT 0 B
                                  Encoding = new byte[] { 0xCB, 0x40 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB41: BIT 0 C
                                  Encoding = new byte[] { 0xCB, 0x41 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB42: BIT 0 D
                                  Encoding = new byte[] { 0xCB, 0x42 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB43: BIT 0 E
                                  Encoding = new byte[] { 0xCB, 0x43 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB44: BIT 0 H
                                  Encoding = new byte[] { 0xCB, 0x44 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB45: BIT 0 L
                                  Encoding = new byte[] { 0xCB, 0x45 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB46: BIT 0 (HL)
                                  Encoding = new byte[] { 0xCB, 0x46 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB47: BIT 0 A
                                  Encoding = new byte[] { 0xCB, 0x47 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB48: BIT 1 B
                                  Encoding = new byte[] { 0xCB, 0x48 },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB49: BIT 1 C
                                  Encoding = new byte[] { 0xCB, 0x49 },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB4A: BIT 1 D
                                  Encoding = new byte[] { 0xCB, 0x4A },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB4B: BIT 1 E
                                  Encoding = new byte[] { 0xCB, 0x4B },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB4C: BIT 1 H
                                  Encoding = new byte[] { 0xCB, 0x4C },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB4D: BIT 1 L
                                  Encoding = new byte[] { 0xCB, 0x4D },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB4E: BIT 1 (HL)
                                  Encoding = new byte[] { 0xCB, 0x4E },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB4F: BIT 1 A
                                  Encoding = new byte[] { 0xCB, 0x4F },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB50: BIT 2 B
                                  Encoding = new byte[] { 0xCB, 0x50 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB51: BIT 2 C
                                  Encoding = new byte[] { 0xCB, 0x51 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB52: BIT 2 D
                                  Encoding = new byte[] { 0xCB, 0x52 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB53: BIT 2 E
                                  Encoding = new byte[] { 0xCB, 0x53 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB54: BIT 2 H
                                  Encoding = new byte[] { 0xCB, 0x54 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB55: BIT 2 L
                                  Encoding = new byte[] { 0xCB, 0x55 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB56: BIT 2 (HL)
                                  Encoding = new byte[] { 0xCB, 0x56 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB57: BIT 2 A
                                  Encoding = new byte[] { 0xCB, 0x57 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB58: BIT 3 B
                                  Encoding = new byte[] { 0xCB, 0x58 },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB59: BIT 3 C
                                  Encoding = new byte[] { 0xCB, 0x59 },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB5A: BIT 3 D
                                  Encoding = new byte[] { 0xCB, 0x5A },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB5B: BIT 3 E
                                  Encoding = new byte[] { 0xCB, 0x5B },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB5C: BIT 3 H
                                  Encoding = new byte[] { 0xCB, 0x5C },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB5D: BIT 3 L
                                  Encoding = new byte[] { 0xCB, 0x5D },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB5E: BIT 3 (HL)
                                  Encoding = new byte[] { 0xCB, 0x5E },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB5F: BIT 3 A
                                  Encoding = new byte[] { 0xCB, 0x5F },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB60: BIT 4 B
                                  Encoding = new byte[] { 0xCB, 0x60 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB61: BIT 4 C
                                  Encoding = new byte[] { 0xCB, 0x61 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB62: BIT 4 D
                                  Encoding = new byte[] { 0xCB, 0x62 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB63: BIT 4 E
                                  Encoding = new byte[] { 0xCB, 0x63 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB64: BIT 4 H
                                  Encoding = new byte[] { 0xCB, 0x64 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB65: BIT 4 L
                                  Encoding = new byte[] { 0xCB, 0x65 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB66: BIT 4 (HL)
                                  Encoding = new byte[] { 0xCB, 0x66 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB67: BIT 4 A
                                  Encoding = new byte[] { 0xCB, 0x67 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB68: BIT 5 B
                                  Encoding = new byte[] { 0xCB, 0x68 },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB69: BIT 5 C
                                  Encoding = new byte[] { 0xCB, 0x69 },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB6A: BIT 5 D
                                  Encoding = new byte[] { 0xCB, 0x6A },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB6B: BIT 5 E
                                  Encoding = new byte[] { 0xCB, 0x6B },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB6C: BIT 5 H
                                  Encoding = new byte[] { 0xCB, 0x6C },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB6D: BIT 5 L
                                  Encoding = new byte[] { 0xCB, 0x6D },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB6E: BIT 5 (HL)
                                  Encoding = new byte[] { 0xCB, 0x6E },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB6F: BIT 5 A
                                  Encoding = new byte[] { 0xCB, 0x6F },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB70: BIT 6 B
                                  Encoding = new byte[] { 0xCB, 0x70 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB71: BIT 6 C
                                  Encoding = new byte[] { 0xCB, 0x71 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB72: BIT 6 D
                                  Encoding = new byte[] { 0xCB, 0x72 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB73: BIT 6 E
                                  Encoding = new byte[] { 0xCB, 0x73 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB74: BIT 6 H
                                  Encoding = new byte[] { 0xCB, 0x74 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB75: BIT 6 L
                                  Encoding = new byte[] { 0xCB, 0x75 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB76: BIT 6 (HL)
                                  Encoding = new byte[] { 0xCB, 0x76 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB77: BIT 6 A
                                  Encoding = new byte[] { 0xCB, 0x77 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB78: BIT 7 B
                                  Encoding = new byte[] { 0xCB, 0x78 },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB79: BIT 7 C
                                  Encoding = new byte[] { 0xCB, 0x79 },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB7A: BIT 7 D
                                  Encoding = new byte[] { 0xCB, 0x7A },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB7B: BIT 7 E
                                  Encoding = new byte[] { 0xCB, 0x7B },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB7C: BIT 7 H
                                  Encoding = new byte[] { 0xCB, 0x7C },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB7D: BIT 7 L
                                  Encoding = new byte[] { 0xCB, 0x7D },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB7E: BIT 7 (HL)
                                  Encoding = new byte[] { 0xCB, 0x7E },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "BIT",	// CB7F: BIT 7 A
                                  Encoding = new byte[] { 0xCB, 0x7F },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.BIT },
            new OpcodeEncoding { Name = "RES",	// CB80: RES 0 B
                                  Encoding = new byte[] { 0xCB, 0x80 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB81: RES 0 C
                                  Encoding = new byte[] { 0xCB, 0x81 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB82: RES 0 D
                                  Encoding = new byte[] { 0xCB, 0x82 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB83: RES 0 E
                                  Encoding = new byte[] { 0xCB, 0x83 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB84: RES 0 H
                                  Encoding = new byte[] { 0xCB, 0x84 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB85: RES 0 L
                                  Encoding = new byte[] { 0xCB, 0x85 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB86: RES 0 (HL)
                                  Encoding = new byte[] { 0xCB, 0x86 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB87: RES 0 A
                                  Encoding = new byte[] { 0xCB, 0x87 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB88: RES 1 B
                                  Encoding = new byte[] { 0xCB, 0x88 },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB89: RES 1 C
                                  Encoding = new byte[] { 0xCB, 0x89 },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB8A: RES 1 D
                                  Encoding = new byte[] { 0xCB, 0x8A },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB8B: RES 1 E
                                  Encoding = new byte[] { 0xCB, 0x8B },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB8C: RES 1 H
                                  Encoding = new byte[] { 0xCB, 0x8C },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB8D: RES 1 L
                                  Encoding = new byte[] { 0xCB, 0x8D },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB8E: RES 1 (HL)
                                  Encoding = new byte[] { 0xCB, 0x8E },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB8F: RES 1 A
                                  Encoding = new byte[] { 0xCB, 0x8F },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB90: RES 2 B
                                  Encoding = new byte[] { 0xCB, 0x90 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB91: RES 2 C
                                  Encoding = new byte[] { 0xCB, 0x91 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB92: RES 2 D
                                  Encoding = new byte[] { 0xCB, 0x92 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB93: RES 2 E
                                  Encoding = new byte[] { 0xCB, 0x93 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB94: RES 2 H
                                  Encoding = new byte[] { 0xCB, 0x94 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB95: RES 2 L
                                  Encoding = new byte[] { 0xCB, 0x95 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB96: RES 2 (HL)
                                  Encoding = new byte[] { 0xCB, 0x96 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB97: RES 2 A
                                  Encoding = new byte[] { 0xCB, 0x97 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB98: RES 3 B
                                  Encoding = new byte[] { 0xCB, 0x98 },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB99: RES 3 C
                                  Encoding = new byte[] { 0xCB, 0x99 },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB9A: RES 3 D
                                  Encoding = new byte[] { 0xCB, 0x9A },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB9B: RES 3 E
                                  Encoding = new byte[] { 0xCB, 0x9B },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB9C: RES 3 H
                                  Encoding = new byte[] { 0xCB, 0x9C },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB9D: RES 3 L
                                  Encoding = new byte[] { 0xCB, 0x9D },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB9E: RES 3 (HL)
                                  Encoding = new byte[] { 0xCB, 0x9E },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CB9F: RES 3 A
                                  Encoding = new byte[] { 0xCB, 0x9F },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA0: RES 4 B
                                  Encoding = new byte[] { 0xCB, 0xA0 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA1: RES 4 C
                                  Encoding = new byte[] { 0xCB, 0xA1 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA2: RES 4 D
                                  Encoding = new byte[] { 0xCB, 0xA2 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA3: RES 4 E
                                  Encoding = new byte[] { 0xCB, 0xA3 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA4: RES 4 H
                                  Encoding = new byte[] { 0xCB, 0xA4 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA5: RES 4 L
                                  Encoding = new byte[] { 0xCB, 0xA5 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA6: RES 4 (HL)
                                  Encoding = new byte[] { 0xCB, 0xA6 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA7: RES 4 A
                                  Encoding = new byte[] { 0xCB, 0xA7 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA8: RES 5 B
                                  Encoding = new byte[] { 0xCB, 0xA8 },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBA9: RES 5 C
                                  Encoding = new byte[] { 0xCB, 0xA9 },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBAA: RES 5 D
                                  Encoding = new byte[] { 0xCB, 0xAA },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBAB: RES 5 E
                                  Encoding = new byte[] { 0xCB, 0xAB },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBAC: RES 5 H
                                  Encoding = new byte[] { 0xCB, 0xAC },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBAD: RES 5 L
                                  Encoding = new byte[] { 0xCB, 0xAD },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBAE: RES 5 (HL)
                                  Encoding = new byte[] { 0xCB, 0xAE },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBAF: RES 5 A
                                  Encoding = new byte[] { 0xCB, 0xAF },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB0: RES 6 B
                                  Encoding = new byte[] { 0xCB, 0xB0 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB1: RES 6 C
                                  Encoding = new byte[] { 0xCB, 0xB1 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB2: RES 6 D
                                  Encoding = new byte[] { 0xCB, 0xB2 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB3: RES 6 E
                                  Encoding = new byte[] { 0xCB, 0xB3 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB4: RES 6 H
                                  Encoding = new byte[] { 0xCB, 0xB4 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB5: RES 6 L
                                  Encoding = new byte[] { 0xCB, 0xB5 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB6: RES 6 (HL)
                                  Encoding = new byte[] { 0xCB, 0xB6 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB7: RES 6 A
                                  Encoding = new byte[] { 0xCB, 0xB7 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB8: RES 7 B
                                  Encoding = new byte[] { 0xCB, 0xB8 },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBB9: RES 7 C
                                  Encoding = new byte[] { 0xCB, 0xB9 },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBBA: RES 7 D
                                  Encoding = new byte[] { 0xCB, 0xBA },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBBB: RES 7 E
                                  Encoding = new byte[] { 0xCB, 0xBB },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBBC: RES 7 H
                                  Encoding = new byte[] { 0xCB, 0xBC },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBBD: RES 7 L
                                  Encoding = new byte[] { 0xCB, 0xBD },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBBE: RES 7 (HL)
                                  Encoding = new byte[] { 0xCB, 0xBE },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "RES",	// CBBF: RES 7 A
                                  Encoding = new byte[] { 0xCB, 0xBF },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.RES },
            new OpcodeEncoding { Name = "SET",	// CBC0: SET 0 B
                                  Encoding = new byte[] { 0xCB, 0xC0 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC1: SET 0 C
                                  Encoding = new byte[] { 0xCB, 0xC1 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC2: SET 0 D
                                  Encoding = new byte[] { 0xCB, 0xC2 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC3: SET 0 E
                                  Encoding = new byte[] { 0xCB, 0xC3 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC4: SET 0 H
                                  Encoding = new byte[] { 0xCB, 0xC4 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC5: SET 0 L
                                  Encoding = new byte[] { 0xCB, 0xC5 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC6: SET 0 (HL)
                                  Encoding = new byte[] { 0xCB, 0xC6 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC7: SET 0 A
                                  Encoding = new byte[] { 0xCB, 0xC7 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC8: SET 1 B
                                  Encoding = new byte[] { 0xCB, 0xC8 },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBC9: SET 1 C
                                  Encoding = new byte[] { 0xCB, 0xC9 },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBCA: SET 1 D
                                  Encoding = new byte[] { 0xCB, 0xCA },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBCB: SET 1 E
                                  Encoding = new byte[] { 0xCB, 0xCB },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBCC: SET 1 H
                                  Encoding = new byte[] { 0xCB, 0xCC },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBCD: SET 1 L
                                  Encoding = new byte[] { 0xCB, 0xCD },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBCE: SET 1 (HL)
                                  Encoding = new byte[] { 0xCB, 0xCE },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBCF: SET 1 A
                                  Encoding = new byte[] { 0xCB, 0xCF },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD0: SET 2 B
                                  Encoding = new byte[] { 0xCB, 0xD0 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD1: SET 2 C
                                  Encoding = new byte[] { 0xCB, 0xD1 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD2: SET 2 D
                                  Encoding = new byte[] { 0xCB, 0xD2 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD3: SET 2 E
                                  Encoding = new byte[] { 0xCB, 0xD3 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD4: SET 2 H
                                  Encoding = new byte[] { 0xCB, 0xD4 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD5: SET 2 L
                                  Encoding = new byte[] { 0xCB, 0xD5 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD6: SET 2 (HL)
                                  Encoding = new byte[] { 0xCB, 0xD6 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD7: SET 2 A
                                  Encoding = new byte[] { 0xCB, 0xD7 },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD8: SET 3 B
                                  Encoding = new byte[] { 0xCB, 0xD8 },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBD9: SET 3 C
                                  Encoding = new byte[] { 0xCB, 0xD9 },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBDA: SET 3 D
                                  Encoding = new byte[] { 0xCB, 0xDA },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBDB: SET 3 E
                                  Encoding = new byte[] { 0xCB, 0xDB },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBDC: SET 3 H
                                  Encoding = new byte[] { 0xCB, 0xDC },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBDD: SET 3 L
                                  Encoding = new byte[] { 0xCB, 0xDD },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBDE: SET 3 (HL)
                                  Encoding = new byte[] { 0xCB, 0xDE },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBDF: SET 3 A
                                  Encoding = new byte[] { 0xCB, 0xDF },
                                  Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE0: SET 4 B
                                  Encoding = new byte[] { 0xCB, 0xE0 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE1: SET 4 C
                                  Encoding = new byte[] { 0xCB, 0xE1 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE2: SET 4 D
                                  Encoding = new byte[] { 0xCB, 0xE2 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE3: SET 4 E
                                  Encoding = new byte[] { 0xCB, 0xE3 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE4: SET 4 H
                                  Encoding = new byte[] { 0xCB, 0xE4 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE5: SET 4 L
                                  Encoding = new byte[] { 0xCB, 0xE5 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE6: SET 4 (HL)
                                  Encoding = new byte[] { 0xCB, 0xE6 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE7: SET 4 A
                                  Encoding = new byte[] { 0xCB, 0xE7 },
                                  Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE8: SET 5 B
                                  Encoding = new byte[] { 0xCB, 0xE8 },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBE9: SET 5 C
                                  Encoding = new byte[] { 0xCB, 0xE9 },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBEA: SET 5 D
                                  Encoding = new byte[] { 0xCB, 0xEA },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBEB: SET 5 E
                                  Encoding = new byte[] { 0xCB, 0xEB },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBEC: SET 5 H
                                  Encoding = new byte[] { 0xCB, 0xEC },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBED: SET 5 L
                                  Encoding = new byte[] { 0xCB, 0xED },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBEE: SET 5 (HL)
                                  Encoding = new byte[] { 0xCB, 0xEE },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBEF: SET 5 A
                                  Encoding = new byte[] { 0xCB, 0xEF },
                                  Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF0: SET 6 B
                                  Encoding = new byte[] { 0xCB, 0xF0 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF1: SET 6 C
                                  Encoding = new byte[] { 0xCB, 0xF1 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF2: SET 6 D
                                  Encoding = new byte[] { 0xCB, 0xF2 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF3: SET 6 E
                                  Encoding = new byte[] { 0xCB, 0xF3 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF4: SET 6 H
                                  Encoding = new byte[] { 0xCB, 0xF4 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF5: SET 6 L
                                  Encoding = new byte[] { 0xCB, 0xF5 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF6: SET 6 (HL)
                                  Encoding = new byte[] { 0xCB, 0xF6 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF7: SET 6 A
                                  Encoding = new byte[] { 0xCB, 0xF7 },
                                  Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF8: SET 7 B
                                  Encoding = new byte[] { 0xCB, 0xF8 },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBF9: SET 7 C
                                  Encoding = new byte[] { 0xCB, 0xF9 },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBFA: SET 7 D
                                  Encoding = new byte[] { 0xCB, 0xFA },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBFB: SET 7 E
                                  Encoding = new byte[] { 0xCB, 0xFB },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBFC: SET 7 H
                                  Encoding = new byte[] { 0xCB, 0xFC },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBFD: SET 7 L
                                  Encoding = new byte[] { 0xCB, 0xFD },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBFE: SET 7 (HL)
                                  Encoding = new byte[] { 0xCB, 0xFE },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "SET",	// CBFF: SET 7 A
                                  Encoding = new byte[] { 0xCB, 0xFF },
                                  Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.SET },
            new OpcodeEncoding { Name = "IN",	// ED40: IN B (C)
                                  Encoding = new byte[] { 0xED, 0x40 },
                                  Reg1 = Register.B, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.IN },
            new OpcodeEncoding { Name = "OUT",	// ED41: OUT (C) B
                                  Encoding = new byte[] { 0xED, 0x41 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.B, Reg2Param = RegParam.None,
                                  Function = CommandID.OUT },
            new OpcodeEncoding { Name = "SBC",	// ED42: SBC HL BC
                                  Encoding = new byte[] { 0xED, 0x42 },
                                  Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.BC, Reg2Param = RegParam.WordData,
                                  Function = CommandID.SBC },
            new OpcodeEncoding { Name = "LD",	// ED43: LD (nn) BC
                                  Encoding = new byte[] { 0xED, 0x43 },
                                  Reg1 = Register.ImmediateWord, Reg1Param = RegParam.Reference | RegParam.WordData,
                                  Reg2 = Register.BC, Reg2Param = RegParam.WordData,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "NEG",	// ED44: NEG  
                                  Encoding = new byte[] { 0xED, 0x44 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.NEG },
            new OpcodeEncoding { Name = "RETN",	// ED45: RETN  
                                  Encoding = new byte[] { 0xED, 0x45 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RETN },
            new OpcodeEncoding { Name = "IM",	// ED46: IM 0 
                                  Encoding = new byte[] { 0xED, 0x46 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.IM },
            new OpcodeEncoding { Name = "LD",	// ED47: LD I A
                                  Encoding = new byte[] { 0xED, 0x47 },
                                  Reg1 = Register.I, Reg1Param = RegParam.None,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "IN",	// ED48: IN C (C)
                                  Encoding = new byte[] { 0xED, 0x48 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.IN },
            new OpcodeEncoding { Name = "OUT",	// ED49: OUT (C) C
                                  Encoding = new byte[] { 0xED, 0x49 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.OUT },
            new OpcodeEncoding { Name = "ADC",	// ED4A: ADC HL BC
                                  Encoding = new byte[] { 0xED, 0x4A },
                                  Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.BC, Reg2Param = RegParam.WordData,
                                  Function = CommandID.ADC },
            new OpcodeEncoding { Name = "LD",	// ED4B: LD BC (nn)
                                  Encoding = new byte[] { 0xED, 0x4B },
                                  Reg1 = Register.BC, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.Reference | RegParam.WordData,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "RETI",	// ED4D: RETI  
                                  Encoding = new byte[] { 0xED, 0x4D },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RETI },
            new OpcodeEncoding { Name = "LD",	// ED4F: LD R A
                                  Encoding = new byte[] { 0xED, 0x4F },
                                  Reg1 = Register.R, Reg1Param = RegParam.None,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "IN",	// ED50: IN D (C)
                                  Encoding = new byte[] { 0xED, 0x50 },
                                  Reg1 = Register.D, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.IN },
            new OpcodeEncoding { Name = "OUT",	// ED51: OUT (C) D
                                  Encoding = new byte[] { 0xED, 0x51 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.D, Reg2Param = RegParam.None,
                                  Function = CommandID.OUT },
            new OpcodeEncoding { Name = "SBC",	// ED52: SBC HL DE
                                  Encoding = new byte[] { 0xED, 0x52 },
                                  Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.DE, Reg2Param = RegParam.WordData,
                                  Function = CommandID.SBC },
            new OpcodeEncoding { Name = "LD",	// ED53: LD (nn) DE
                                  Encoding = new byte[] { 0xED, 0x53 },
                                  Reg1 = Register.ImmediateWord, Reg1Param = RegParam.Reference | RegParam.WordData,
                                  Reg2 = Register.DE, Reg2Param = RegParam.WordData,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "RETN",	// ED55: RETN  
                                  Encoding = new byte[] { 0xED, 0x55 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RETN },
            new OpcodeEncoding { Name = "IM",	// ED56: IM 1 
                                  Encoding = new byte[] { 0xED, 0x56 },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.IM },
            new OpcodeEncoding { Name = "LD",	// ED57: LD A I
                                  Encoding = new byte[] { 0xED, 0x57 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.I, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "IN",	// ED58: IN E (C)
                                  Encoding = new byte[] { 0xED, 0x58 },
                                  Reg1 = Register.E, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.IN },
            new OpcodeEncoding { Name = "OUT",	// ED59: OUT (C) E
                                  Encoding = new byte[] { 0xED, 0x59 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.E, Reg2Param = RegParam.None,
                                  Function = CommandID.OUT },
            new OpcodeEncoding { Name = "ADC",	// ED5A: ADC HL DE
                                  Encoding = new byte[] { 0xED, 0x5A },
                                  Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.DE, Reg2Param = RegParam.WordData,
                                  Function = CommandID.ADC },
            new OpcodeEncoding { Name = "LD",	// ED5B: LD DE (nn)
                                  Encoding = new byte[] { 0xED, 0x5B },
                                  Reg1 = Register.DE, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.Reference | RegParam.WordData,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "RETN",	// ED5D: RETN  
                                  Encoding = new byte[] { 0xED, 0x5D },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RETN },
            new OpcodeEncoding { Name = "IM",	// ED5E: IM 2 
                                  Encoding = new byte[] { 0xED, 0x5E },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.IM },
            new OpcodeEncoding { Name = "LD",	// ED5F: LD A R
                                  Encoding = new byte[] { 0xED, 0x5F },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.R, Reg2Param = RegParam.None,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "IN",	// ED60: IN H (C)
                                  Encoding = new byte[] { 0xED, 0x60 },
                                  Reg1 = Register.XH, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.IN },
            new OpcodeEncoding { Name = "OUT",	// ED61: OUT (C) H
                                  Encoding = new byte[] { 0xED, 0x61 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.XH, Reg2Param = RegParam.None,
                                  Function = CommandID.OUT },
            new OpcodeEncoding { Name = "SBC",	// ED62: SBC HL HL
                                  Encoding = new byte[] { 0xED, 0x62 },
                                  Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.HL, Reg2Param = RegParam.WordData,
                                  Function = CommandID.SBC },
            new OpcodeEncoding { Name = "RETN",	// ED65: RETN  
                                  Encoding = new byte[] { 0xED, 0x65 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RETN },
            new OpcodeEncoding { Name = "IM",	// ED66: IM 0 
                                  Encoding = new byte[] { 0xED, 0x66 },
                                  Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.IM },
            new OpcodeEncoding { Name = "RRD",	// ED67: RRD  
                                  Encoding = new byte[] { 0xED, 0x67 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RRD },
            new OpcodeEncoding { Name = "IN",	// ED68: IN L (C)
                                  Encoding = new byte[] { 0xED, 0x68 },
                                  Reg1 = Register.XL, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.IN },
            new OpcodeEncoding { Name = "OUT",	// ED69: OUT (C) L
                                  Encoding = new byte[] { 0xED, 0x69 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.XL, Reg2Param = RegParam.None,
                                  Function = CommandID.OUT },
            new OpcodeEncoding { Name = "ADC",	// ED6A: ADC HL HL
                                  Encoding = new byte[] { 0xED, 0x6A },
                                  Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.HL, Reg2Param = RegParam.WordData,
                                  Function = CommandID.ADC },
            new OpcodeEncoding { Name = "RETN",	// ED6D: RETN  
                                  Encoding = new byte[] { 0xED, 0x6D },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RETN },
            new OpcodeEncoding { Name = "RLD",	// ED6F: RLD  
                                  Encoding = new byte[] { 0xED, 0x6F },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RLD },
            new OpcodeEncoding { Name = "SBC",	// ED72: SBC HL SP
                                  Encoding = new byte[] { 0xED, 0x72 },
                                  Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.SP, Reg2Param = RegParam.WordData,
                                  Function = CommandID.SBC },
            new OpcodeEncoding { Name = "LD",	// ED73: LD (nn) SP
                                  Encoding = new byte[] { 0xED, 0x73 },
                                  Reg1 = Register.ImmediateWord, Reg1Param = RegParam.Reference | RegParam.WordData,
                                  Reg2 = Register.SP, Reg2Param = RegParam.WordData,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "RETN",	// ED75: RETN  
                                  Encoding = new byte[] { 0xED, 0x75 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RETN },
            new OpcodeEncoding { Name = "IM",	// ED76: IM 1 
                                  Encoding = new byte[] { 0xED, 0x76 },
                                  Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.IM },
            new OpcodeEncoding { Name = "IN",	// ED78: IN A (C)
                                  Encoding = new byte[] { 0xED, 0x78 },
                                  Reg1 = Register.A, Reg1Param = RegParam.None,
                                  Reg2 = Register.C, Reg2Param = RegParam.None,
                                  Function = CommandID.IN },
            new OpcodeEncoding { Name = "OUT",	// ED79: OUT (C) A
                                  Encoding = new byte[] { 0xED, 0x79 },
                                  Reg1 = Register.C, Reg1Param = RegParam.None,
                                  Reg2 = Register.A, Reg2Param = RegParam.None,
                                  Function = CommandID.OUT },
            new OpcodeEncoding { Name = "ADC",	// ED7A: ADC HL SP
                                  Encoding = new byte[] { 0xED, 0x7A },
                                  Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.SP, Reg2Param = RegParam.WordData,
                                  Function = CommandID.ADC },
            new OpcodeEncoding { Name = "LD",	// ED7B: LD SP (nn)
                                  Encoding = new byte[] { 0xED, 0x7B },
                                  Reg1 = Register.SP, Reg1Param = RegParam.WordData,
                                  Reg2 = Register.ImmediateWord, Reg2Param = RegParam.Reference | RegParam.WordData,
                                  Function = CommandID.LD },
            new OpcodeEncoding { Name = "RETN",	// ED7D: RETN  
                                  Encoding = new byte[] { 0xED, 0x7D },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.RETN },
            new OpcodeEncoding { Name = "IM",	// ED7E: IM 2 
                                  Encoding = new byte[] { 0xED, 0x7E },
                                  Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.IM },
            new OpcodeEncoding { Name = "LDI",	// EDA0: LDI  
                                  Encoding = new byte[] { 0xED, 0xA0 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.LDI },
            new OpcodeEncoding { Name = "CPI",	// EDA1: CPI  
                                  Encoding = new byte[] { 0xED, 0xA1 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.CPI },
            new OpcodeEncoding { Name = "INI",	// EDA2: INI  
                                  Encoding = new byte[] { 0xED, 0xA2 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.INI },
            new OpcodeEncoding { Name = "OUTI",	// EDA3: OUTI  
                                  Encoding = new byte[] { 0xED, 0xA3 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.OUTI },
            new OpcodeEncoding { Name = "LDD",	// EDA8: LDD  
                                  Encoding = new byte[] { 0xED, 0xA8 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.LDD },
            new OpcodeEncoding { Name = "CPD",	// EDA9: CPD  
                                  Encoding = new byte[] { 0xED, 0xA9 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.CPD },
            new OpcodeEncoding { Name = "IND",	// EDAA: IND  
                                  Encoding = new byte[] { 0xED, 0xAA },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.IND },
            new OpcodeEncoding { Name = "OUTD",	// EDAB: OUTD  
                                  Encoding = new byte[] { 0xED, 0xAB },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.OUTD },
            new OpcodeEncoding { Name = "LDIR",	// EDB0: LDIR  
                                  Encoding = new byte[] { 0xED, 0xB0 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.LDIR },
            new OpcodeEncoding { Name = "CPIR",	// EDB1: CPIR  
                                  Encoding = new byte[] { 0xED, 0xB1 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.CPIR },
            new OpcodeEncoding { Name = "INIR",	// EDB2: INIR  
                                  Encoding = new byte[] { 0xED, 0xB2 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.INIR },
            new OpcodeEncoding { Name = "OTIR",	// EDB3: OTIR  
                                  Encoding = new byte[] { 0xED, 0xB3 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.OTIR },
            new OpcodeEncoding { Name = "LDDR",	// EDB8: LDDR  
                                  Encoding = new byte[] { 0xED, 0xB8 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.LDDR },
            new OpcodeEncoding { Name = "CPDR",	// EDB9: CPDR  
                                  Encoding = new byte[] { 0xED, 0xB9 },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.CPDR },
            new OpcodeEncoding { Name = "INDR",	// EDBA: INDR  
                                  Encoding = new byte[] { 0xED, 0xBA },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.INDR },
            new OpcodeEncoding { Name = "OTDR",	// EDBB: OTDR  
                                  Encoding = new byte[] { 0xED, 0xBB },
                                  Reg1 = Register.None, Reg1Param = RegParam.None,
                                  Reg2 = Register.None, Reg2Param = RegParam.None,
                                  Function = CommandID.OTDR },
        };
    }
}
