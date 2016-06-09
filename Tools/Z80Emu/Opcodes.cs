namespace Z80Emu
{
    static class Ops
    {
        static public OpcodeData[,] ByteData = new OpcodeData[,]
        {
            {
                new OpcodeData { Name = "NOP",	// 00: NOP  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.NOP },
                new OpcodeData { Name = "LD",	// 01: LD BC nn
                                 Reg1 = Register.BC, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 02: LD (BC) A
                                 Reg1 = Register.BC, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "INC",	// 03: INC BC 
                                 Reg1 = Register.BC, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.INC },
                new OpcodeData { Name = "INC",	// 04: INC B 
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.INC },
                new OpcodeData { Name = "DEC",	// 05: DEC B 
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.DEC },
                new OpcodeData { Name = "LD",	// 06: LD B n
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "RLCA",	// 07: RLCA  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RLCA },
                new OpcodeData { Name = "EX",	// 08: EX AF AF
                                 Reg1 = Register.AF, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.AF, Reg2Param = RegParam.WordData,
                                 Function = Operation.EX },
                new OpcodeData { Name = "ADD",	// 09: ADD HL BC
                                 Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.BC, Reg2Param = RegParam.WordData,
                                 Function = Operation.ADD },
                new OpcodeData { Name = "LD",	// 0A: LD A (BC)
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.BC, Reg2Param = RegParam.Reference,
                                 Function = Operation.LD },
                new OpcodeData { Name = "DEC",	// 0B: DEC BC 
                                 Reg1 = Register.BC, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.DEC },
                new OpcodeData { Name = "INC",	// 0C: INC C 
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.INC },
                new OpcodeData { Name = "DEC",	// 0D: DEC C 
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.DEC },
                new OpcodeData { Name = "LD",	// 0E: LD C n
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "RRCA",	// 0F: RRCA  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RRCA },
                new OpcodeData { Name = "DJNZ",	// 10: DJNZ e-2 
                                 Reg1 = Register.ImmediateByte, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.DJNZ },
                new OpcodeData { Name = "LD",	// 11: LD DE nn
                                 Reg1 = Register.DE, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 12: LD (DE) A
                                 Reg1 = Register.DE, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "INC",	// 13: INC DE 
                                 Reg1 = Register.DE, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.INC },
                new OpcodeData { Name = "INC",	// 14: INC D 
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.INC },
                new OpcodeData { Name = "DEC",	// 15: DEC D 
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.DEC },
                new OpcodeData { Name = "LD",	// 16: LD D n
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "RLA",	// 17: RLA  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RLA },
                new OpcodeData { Name = "JR",	// 18: JR e-2 
                                 Reg1 = Register.ImmediateByte, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.JR },
                new OpcodeData { Name = "ADD",	// 19: ADD HL DE
                                 Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.DE, Reg2Param = RegParam.WordData,
                                 Function = Operation.ADD },
                new OpcodeData { Name = "LD",	// 1A: LD A (DE)
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.DE, Reg2Param = RegParam.Reference,
                                 Function = Operation.LD },
                new OpcodeData { Name = "DEC",	// 1B: DEC DE 
                                 Reg1 = Register.DE, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.DEC },
                new OpcodeData { Name = "INC",	// 1C: INC E 
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.INC },
                new OpcodeData { Name = "DEC",	// 1D: DEC E 
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.DEC },
                new OpcodeData { Name = "LD",	// 1E: LD E n
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "RRA",	// 1F: RRA  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RRA },
                new OpcodeData { Name = "JR",	// 20: JR NZ e-2
                                 Reg1 = (Register)ConditionCode.NZ, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.JR },
                new OpcodeData { Name = "LD",	// 21: LD HL nn
                                 Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 22: LD (nn) HL
                                 Reg1 = Register.ImmediateWord, Reg1Param = RegParam.Reference | RegParam.WordData,
                                 Reg2 = Register.HX, Reg2Param = RegParam.WordData,
                                 Function = Operation.LD },
                new OpcodeData { Name = "INC",	// 23: INC HL 
                                 Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.INC },
                new OpcodeData { Name = "INC",	// 24: INC H 
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.INC },
                new OpcodeData { Name = "DEC",	// 25: DEC H 
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.DEC },
                new OpcodeData { Name = "LD",	// 26: LD H n
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "DAA",	// 27: DAA  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.DAA },
                new OpcodeData { Name = "JR",	// 28: JR Z e-2
                                 Reg1 = (Register)ConditionCode.Z, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.JR },
                new OpcodeData { Name = "ADD",	// 29: ADD HL HL
                                 Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.HX, Reg2Param = RegParam.WordData,
                                 Function = Operation.ADD },
                new OpcodeData { Name = "LD",	// 2A: LD HL (nn)
                                 Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.Reference | RegParam.WordData,
                                 Function = Operation.LD },
                new OpcodeData { Name = "DEC",	// 2B: DEC HL 
                                 Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.DEC },
                new OpcodeData { Name = "INC",	// 2C: INC L 
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.INC },
                new OpcodeData { Name = "DEC",	// 2D: DEC L 
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.DEC },
                new OpcodeData { Name = "LD",	// 2E: LD L n
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "CPL",	// 2F: CPL  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.CPL },
                new OpcodeData { Name = "JR",	// 30: JR NC e-2
                                 Reg1 = (Register)ConditionCode.NC, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.JR },
                new OpcodeData { Name = "LD",	// 31: LD SP nn
                                 Reg1 = Register.SP, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 32: LD (nn) A
                                 Reg1 = Register.ImmediateWord, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "INC",	// 33: INC SP 
                                 Reg1 = Register.SP, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.INC },
                new OpcodeData { Name = "INC",	// 34: INC (HL) 
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.INC },
                new OpcodeData { Name = "DEC",	// 35: DEC (HL) 
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.DEC },
                new OpcodeData { Name = "LD",	// 36: LD (HL) n
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "SCF",	// 37: SCF  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SCF },
                new OpcodeData { Name = "JR",	// 38: JR CY e-2
                                 Reg1 = (Register)ConditionCode.CY, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.JR },
                new OpcodeData { Name = "ADD",	// 39: ADD HL SP
                                 Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.SP, Reg2Param = RegParam.WordData,
                                 Function = Operation.ADD },
                new OpcodeData { Name = "LD",	// 3A: LD A (nn)
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.Reference,
                                 Function = Operation.LD },
                new OpcodeData { Name = "DEC",	// 3B: DEC SP 
                                 Reg1 = Register.SP, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.DEC },
                new OpcodeData { Name = "INC",	// 3C: INC A 
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.INC },
                new OpcodeData { Name = "DEC",	// 3D: DEC A 
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.DEC },
                new OpcodeData { Name = "LD",	// 3E: LD A n
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "CCF",	// 3F: CCF  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.CCF },
                new OpcodeData { Name = "LD",	// 40: LD B B
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 41: LD B C
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 42: LD B D
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 43: LD B E
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 44: LD B H
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 45: LD B L
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 46: LD B (HL)
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 47: LD B A
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 48: LD C B
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 49: LD C C
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 4A: LD C D
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 4B: LD C E
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 4C: LD C H
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 4D: LD C L
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 4E: LD C (HL)
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 4F: LD C A
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 50: LD D B
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 51: LD D C
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 52: LD D D
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 53: LD D E
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 54: LD D H
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 55: LD D L
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 56: LD D (HL)
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 57: LD D A
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 58: LD E B
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 59: LD E C
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 5A: LD E D
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 5B: LD E E
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 5C: LD E H
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 5D: LD E L
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 5E: LD E (HL)
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 5F: LD E A
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 60: LD H B
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 61: LD H C
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 62: LD H D
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 63: LD H E
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 64: LD H H
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 65: LD H L
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 66: LD H (HL)
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 67: LD H A
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 68: LD L B
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 69: LD L C
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 6A: LD L D
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 6B: LD L E
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 6C: LD L H
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 6D: LD L L
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 6E: LD L (HL)
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 6F: LD L A
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 70: LD (HL) B
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 71: LD (HL) C
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 72: LD (HL) D
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 73: LD (HL) E
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 74: LD (HL) H
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 75: LD (HL) L
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "HALT",	// 76: HALT  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.HALT },
                new OpcodeData { Name = "LD",	// 77: LD (HL) A
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 78: LD A B
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 79: LD A C
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 7A: LD A D
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 7B: LD A E
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 7C: LD A H
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 7D: LD A L
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 7E: LD A (HL)
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.LD },
                new OpcodeData { Name = "LD",	// 7F: LD A A
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "ADD",	// 80: ADD A B
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.ADD },
                new OpcodeData { Name = "ADD",	// 81: ADD A C
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.ADD },
                new OpcodeData { Name = "ADD",	// 82: ADD A D
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.ADD },
                new OpcodeData { Name = "ADD",	// 83: ADD A E
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.ADD },
                new OpcodeData { Name = "ADD",	// 84: ADD A H
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.ADD },
                new OpcodeData { Name = "ADD",	// 85: ADD A L
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.ADD },
                new OpcodeData { Name = "ADD",	// 86: ADD A (HL)
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.ADD },
                new OpcodeData { Name = "ADD",	// 87: ADD A A
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.ADD },
                new OpcodeData { Name = "ADC",	// 88: ADC A B
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.ADC },
                new OpcodeData { Name = "ADC",	// 89: ADC A C
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.ADC },
                new OpcodeData { Name = "ADC",	// 8A: ADC A D
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.ADC },
                new OpcodeData { Name = "ADC",	// 8B: ADC A E
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.ADC },
                new OpcodeData { Name = "ADC",	// 8C: ADC A H
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.ADC },
                new OpcodeData { Name = "ADC",	// 8D: ADC A L
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.ADC },
                new OpcodeData { Name = "ADC",	// 8E: ADC A (HL)
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.ADC },
                new OpcodeData { Name = "ADC",	// 8F: ADC A A
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.ADC },
                new OpcodeData { Name = "SUB",	// 90: SUB A B
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.SUB },
                new OpcodeData { Name = "SUB",	// 91: SUB A C
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.SUB },
                new OpcodeData { Name = "SUB",	// 92: SUB A D
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.SUB },
                new OpcodeData { Name = "SUB",	// 93: SUB A E
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.SUB },
                new OpcodeData { Name = "SUB",	// 94: SUB A H
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.SUB },
                new OpcodeData { Name = "SUB",	// 95: SUB A L
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.SUB },
                new OpcodeData { Name = "SUB",	// 96: SUB A (HL)
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.SUB },
                new OpcodeData { Name = "SUB",	// 97: SUB A A
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.SUB },
                new OpcodeData { Name = "SBC",	// 98: SBC A B
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.SBC },
                new OpcodeData { Name = "SBC",	// 99: SBC A C
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.SBC },
                new OpcodeData { Name = "SBC",	// 9A: SBC A D
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.SBC },
                new OpcodeData { Name = "SBC",	// 9B: SBC A E
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.SBC },
                new OpcodeData { Name = "SBC",	// 9C: SBC A H
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.SBC },
                new OpcodeData { Name = "SBC",	// 9D: SBC A L
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.SBC },
                new OpcodeData { Name = "SBC",	// 9E: SBC A (HL)
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.SBC },
                new OpcodeData { Name = "SBC",	// 9F: SBC A A
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.SBC },
                new OpcodeData { Name = "AND",	// A0: AND A B
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.AND },
                new OpcodeData { Name = "AND",	// A1: AND A C
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.AND },
                new OpcodeData { Name = "AND",	// A2: AND A D
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.AND },
                new OpcodeData { Name = "AND",	// A3: AND A E
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.AND },
                new OpcodeData { Name = "AND",	// A4: AND A H
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.AND },
                new OpcodeData { Name = "AND",	// A5: AND A L
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.AND },
                new OpcodeData { Name = "AND",	// A6: AND A (HL)
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.AND },
                new OpcodeData { Name = "AND",	// A7: AND A A
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.AND },
                new OpcodeData { Name = "XOR",	// A8: XOR A B
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.XOR },
                new OpcodeData { Name = "XOR",	// A9: XOR A C
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.XOR },
                new OpcodeData { Name = "XOR",	// AA: XOR A D
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.XOR },
                new OpcodeData { Name = "XOR",	// AB: XOR A E
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.XOR },
                new OpcodeData { Name = "XOR",	// AC: XOR A H
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.XOR },
                new OpcodeData { Name = "XOR",	// AD: XOR A L
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.XOR },
                new OpcodeData { Name = "XOR",	// AE: XOR A (HL)
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.XOR },
                new OpcodeData { Name = "XOR",	// AF: XOR A A
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.XOR },
                new OpcodeData { Name = "OR",	// B0: OR A B
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.OR },
                new OpcodeData { Name = "OR",	// B1: OR A C
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.OR },
                new OpcodeData { Name = "OR",	// B2: OR A D
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.OR },
                new OpcodeData { Name = "OR",	// B3: OR A E
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.OR },
                new OpcodeData { Name = "OR",	// B4: OR A H
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.OR },
                new OpcodeData { Name = "OR",	// B5: OR A L
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.OR },
                new OpcodeData { Name = "OR",	// B6: OR A (HL)
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.OR },
                new OpcodeData { Name = "OR",	// B7: OR A A
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.OR },
                new OpcodeData { Name = "CP",	// B8: CP A B
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.CP },
                new OpcodeData { Name = "CP",	// B9: CP A C
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.CP },
                new OpcodeData { Name = "CP",	// BA: CP A D
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.CP },
                new OpcodeData { Name = "CP",	// BB: CP A E
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.CP },
                new OpcodeData { Name = "CP",	// BC: CP A H
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.CP },
                new OpcodeData { Name = "CP",	// BD: CP A L
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.CP },
                new OpcodeData { Name = "CP",	// BE: CP A (HL)
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.CP },
                new OpcodeData { Name = "CP",	// BF: CP A A
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.CP },
                new OpcodeData { Name = "RET",	// C0: RET NZ 
                                 Reg1 = (Register)ConditionCode.NZ, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RET },
                new OpcodeData { Name = "POP",	// C1: POP BC 
                                 Reg1 = Register.BC, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.POP },
                new OpcodeData { Name = "JP",	// C2: JP NZ nn
                                 Reg1 = (Register)ConditionCode.NZ, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.JP },
                new OpcodeData { Name = "JP",	// C3: JP nn 
                                 Reg1 = Register.ImmediateWord, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.JP },
                new OpcodeData { Name = "CALL",	// C4: CALL NZ nn
                                 Reg1 = (Register)ConditionCode.NZ, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.CALL },
                new OpcodeData { Name = "PUSH",	// C5: PUSH BC 
                                 Reg1 = Register.BC, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.PUSH },
                new OpcodeData { Name = "ADD",	// C6: ADD A n
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.ADD },
                new OpcodeData { Name = "RST",	// C7: RST 0H 
                                 Reg1 = (Register)0x0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RST },
                new OpcodeData { Name = "RET",	// C8: RET Z 
                                 Reg1 = (Register)ConditionCode.Z, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RET },
                new OpcodeData { Name = "RET",	// C9: RET  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RET },
                new OpcodeData { Name = "JP",	// CA: JP Z nn
                                 Reg1 = (Register)ConditionCode.Z, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.JP },
                new OpcodeData { Name = "",		// CB
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "CALL",	// CC: CALL Z nn
                                 Reg1 = (Register)ConditionCode.Z, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.CALL },
                new OpcodeData { Name = "CALL",	// CD: CALL nn 
                                 Reg1 = Register.ImmediateWord, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.CALL },
                new OpcodeData { Name = "ADC",	// CE: ADC A n
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.ADC },
                new OpcodeData { Name = "RST",	// CF: RST 8H 
                                 Reg1 = (Register)0x8, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RST },
                new OpcodeData { Name = "RET",	// D0: RET NC 
                                 Reg1 = (Register)ConditionCode.NC, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RET },
                new OpcodeData { Name = "POP",	// D1: POP DE 
                                 Reg1 = Register.DE, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.POP },
                new OpcodeData { Name = "JP",	// D2: JP NC nn
                                 Reg1 = (Register)ConditionCode.NC, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.JP },
                new OpcodeData { Name = "OUT",	// D3: OUT (n) A
                                 Reg1 = Register.ImmediateByte, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.OUT },
                new OpcodeData { Name = "CALL",	// D4: CALL NC nn
                                 Reg1 = (Register)ConditionCode.NC, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.CALL },
                new OpcodeData { Name = "PUSH",	// D5: PUSH DE 
                                 Reg1 = Register.DE, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.PUSH },
                new OpcodeData { Name = "SUB",	// D6: SUB A n
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.SUB },
                new OpcodeData { Name = "RST",	// D7: RST 10H 
                                 Reg1 = (Register)0x10, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RST },
                new OpcodeData { Name = "RET",	// D8: RET CY 
                                 Reg1 = (Register)ConditionCode.CY, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RET },
                new OpcodeData { Name = "EXX",	// D9: EXX  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.EXX },
                new OpcodeData { Name = "JP",	// DA: JP CY nn
                                 Reg1 = (Register)ConditionCode.CY, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.JP },
                new OpcodeData { Name = "IN",	// DB: IN A (n)
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.IN },
                new OpcodeData { Name = "CALL",	// DC: CALL CY nn
                                 Reg1 = (Register)ConditionCode.CY, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.CALL },
                new OpcodeData { Name = "",		// DD
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "SBC",	// DE: SBC A n
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.SBC },
                new OpcodeData { Name = "RST",	// DF: RST 18H 
                                 Reg1 = (Register)0x18, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RST },
                new OpcodeData { Name = "RET",	// E0: RET PO 
                                 Reg1 = (Register)ConditionCode.PO, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RET },
                new OpcodeData { Name = "POP",	// E1: POP HL 
                                 Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.POP },
                new OpcodeData { Name = "JP",	// E2: JP PO nn
                                 Reg1 = (Register)ConditionCode.PO, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.JP },
                new OpcodeData { Name = "EX",	// E3: EX (SP) HL
                                 Reg1 = Register.SP, Reg1Param = RegParam.Reference | RegParam.WordData,
                                 Reg2 = Register.HX, Reg2Param = RegParam.WordData,
                                 Function = Operation.EX },
                new OpcodeData { Name = "CALL",	// E4: CALL PO nn
                                 Reg1 = (Register)ConditionCode.PO, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.CALL },
                new OpcodeData { Name = "PUSH",	// E5: PUSH HL 
                                 Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.PUSH },
                new OpcodeData { Name = "AND",	// E6: AND A n
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.AND },
                new OpcodeData { Name = "RST",	// E7: RST 20H 
                                 Reg1 = (Register)0x20, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RST },
                new OpcodeData { Name = "RET",	// E8: RET PE 
                                 Reg1 = (Register)ConditionCode.PE, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RET },
                new OpcodeData { Name = "JP",	// E9: JP (HL) 
                                 Reg1 = Register.HX, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.JP },
                new OpcodeData { Name = "JP",	// EA: JP PE nn
                                 Reg1 = (Register)ConditionCode.PE, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.JP },
                new OpcodeData { Name = "EX",	// EB: EX DE HL
                                 Reg1 = Register.DE, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.HL, Reg2Param = RegParam.WordData,
                                 Function = Operation.EX },
                new OpcodeData { Name = "CALL",	// EC: CALL PE nn
                                 Reg1 = (Register)ConditionCode.PE, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.CALL },
                new OpcodeData { Name = "",		// ED
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "XOR",	// EE: XOR A n
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.XOR },
                new OpcodeData { Name = "RST",	// EF: RST 28H 
                                 Reg1 = (Register)0x28, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RST },
                new OpcodeData { Name = "RET",	// F0: RET P 
                                 Reg1 = (Register)ConditionCode.P, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RET },
                new OpcodeData { Name = "POP",	// F1: POP AF 
                                 Reg1 = Register.AF, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.POP },
                new OpcodeData { Name = "JP",	// F2: JP P nn
                                 Reg1 = (Register)ConditionCode.P, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.JP },
                new OpcodeData { Name = "DI",	// F3: DI  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.DI },
                new OpcodeData { Name = "CALL",	// F4: CALL P nn
                                 Reg1 = (Register)ConditionCode.P, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.CALL },
                new OpcodeData { Name = "PUSH",	// F5: PUSH AF 
                                 Reg1 = Register.AF, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.PUSH },
                new OpcodeData { Name = "OR",	// F6: OR A n
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.OR },
                new OpcodeData { Name = "RST",	// F7: RST 30H 
                                 Reg1 = (Register)0x30, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RST },
                new OpcodeData { Name = "RET",	// F8: RET M 
                                 Reg1 = (Register)ConditionCode.M, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RET },
                new OpcodeData { Name = "LD",	// F9: LD SP HL
                                 Reg1 = Register.SP, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.HX, Reg2Param = RegParam.WordData,
                                 Function = Operation.LD },
                new OpcodeData { Name = "JP",	// FA: JP M nn
                                 Reg1 = (Register)ConditionCode.M, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.JP },
                new OpcodeData { Name = "EI",	// FB: EI  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.EI },
                new OpcodeData { Name = "CALL",	// FC: CALL M nn
                                 Reg1 = (Register)ConditionCode.M, Reg1Param = RegParam.ConditionCode,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.WordData,
                                 Function = Operation.CALL },
                new OpcodeData { Name = "",		// FD
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "CP",	// FE: CP A n
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.ImmediateByte, Reg2Param = RegParam.None,
                                 Function = Operation.CP },
                new OpcodeData { Name = "RST",	// FF: RST 38H 
                                 Reg1 = (Register)0x38, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RST },
            },

            {
                new OpcodeData { Name = "RLC",	// CB00: RLC B 
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RLC },
                new OpcodeData { Name = "RLC",	// CB01: RLC C 
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RLC },
                new OpcodeData { Name = "RLC",	// CB02: RLC D 
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RLC },
                new OpcodeData { Name = "RLC",	// CB03: RLC E 
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RLC },
                new OpcodeData { Name = "RLC",	// CB04: RLC H 
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RLC },
                new OpcodeData { Name = "RLC",	// CB05: RLC L 
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RLC },
                new OpcodeData { Name = "RLC",	// CB06: RLC (HL) 
                                 Reg1 = Register.HL, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RLC },
                new OpcodeData { Name = "RLC",	// CB07: RLC A 
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RLC },
                new OpcodeData { Name = "RRC",	// CB08: RRC B 
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RRC },
                new OpcodeData { Name = "RRC",	// CB09: RRC C 
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RRC },
                new OpcodeData { Name = "RRC",	// CB0A: RRC D 
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RRC },
                new OpcodeData { Name = "RRC",	// CB0B: RRC E 
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RRC },
                new OpcodeData { Name = "RRC",	// CB0C: RRC H 
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RRC },
                new OpcodeData { Name = "RRC",	// CB0D: RRC L 
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RRC },
                new OpcodeData { Name = "RRC",	// CB0E: RRC (HL) 
                                 Reg1 = Register.HL, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RRC },
                new OpcodeData { Name = "RRC",	// CB0F: RRC A 
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RRC },
                new OpcodeData { Name = "RL",	// CB10: RL B 
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RL },
                new OpcodeData { Name = "RL",	// CB11: RL C 
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RL },
                new OpcodeData { Name = "RL",	// CB12: RL D 
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RL },
                new OpcodeData { Name = "RL",	// CB13: RL E 
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RL },
                new OpcodeData { Name = "RL",	// CB14: RL H 
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RL },
                new OpcodeData { Name = "RL",	// CB15: RL L 
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RL },
                new OpcodeData { Name = "RL",	// CB16: RL (HL) 
                                 Reg1 = Register.HL, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RL },
                new OpcodeData { Name = "RL",	// CB17: RL A 
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RL },
                new OpcodeData { Name = "RR",	// CB18: RR B 
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RR },
                new OpcodeData { Name = "RR",	// CB19: RR C 
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RR },
                new OpcodeData { Name = "RR",	// CB1A: RR D 
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RR },
                new OpcodeData { Name = "RR",	// CB1B: RR E 
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RR },
                new OpcodeData { Name = "RR",	// CB1C: RR H 
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RR },
                new OpcodeData { Name = "RR",	// CB1D: RR L 
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RR },
                new OpcodeData { Name = "RR",	// CB1E: RR (HL) 
                                 Reg1 = Register.HL, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RR },
                new OpcodeData { Name = "RR",	// CB1F: RR A 
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RR },
                new OpcodeData { Name = "SLA",	// CB20: SLA B 
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLA },
                new OpcodeData { Name = "SLA",	// CB21: SLA C 
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLA },
                new OpcodeData { Name = "SLA",	// CB22: SLA D 
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLA },
                new OpcodeData { Name = "SLA",	// CB23: SLA E 
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLA },
                new OpcodeData { Name = "SLA",	// CB24: SLA H 
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLA },
                new OpcodeData { Name = "SLA",	// CB25: SLA L 
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLA },
                new OpcodeData { Name = "SLA",	// CB26: SLA (HL) 
                                 Reg1 = Register.HL, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLA },
                new OpcodeData { Name = "SLA",	// CB27: SLA A 
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLA },
                new OpcodeData { Name = "SRA",	// CB28: SRA B 
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRA },
                new OpcodeData { Name = "SRA",	// CB29: SRA C 
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRA },
                new OpcodeData { Name = "SRA",	// CB2A: SRA D 
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRA },
                new OpcodeData { Name = "SRA",	// CB2B: SRA E 
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRA },
                new OpcodeData { Name = "SRA",	// CB2C: SRA H 
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRA },
                new OpcodeData { Name = "SRA",	// CB2D: SRA L 
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRA },
                new OpcodeData { Name = "SRA",	// CB2E: SRA (HL) 
                                 Reg1 = Register.HL, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRA },
                new OpcodeData { Name = "SRA",	// CB2F: SRA A 
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRA },
                new OpcodeData { Name = "SLL",	// CB30: SLL B 
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLL },
                new OpcodeData { Name = "SLL",	// CB31: SLL C 
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLL },
                new OpcodeData { Name = "SLL",	// CB32: SLL D 
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLL },
                new OpcodeData { Name = "SLL",	// CB33: SLL E 
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLL },
                new OpcodeData { Name = "SLL",	// CB34: SLL H 
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLL },
                new OpcodeData { Name = "SLL",	// CB35: SLL L 
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLL },
                new OpcodeData { Name = "SLL",	// CB36: SLL (HL) 
                                 Reg1 = Register.HL, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLL },
                new OpcodeData { Name = "SLL",	// CB37: SLL A 
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLL },
                new OpcodeData { Name = "SRL",	// CB38: SRL B 
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRL },
                new OpcodeData { Name = "SRL",	// CB39: SRL C 
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRL },
                new OpcodeData { Name = "SRL",	// CB3A: SRL D 
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRL },
                new OpcodeData { Name = "SRL",	// CB3B: SRL E 
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRL },
                new OpcodeData { Name = "SRL",	// CB3C: SRL H 
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRL },
                new OpcodeData { Name = "SRL",	// CB3D: SRL L 
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRL },
                new OpcodeData { Name = "SRL",	// CB3E: SRL (HL) 
                                 Reg1 = Register.HL, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRL },
                new OpcodeData { Name = "SRL",	// CB3F: SRL A 
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRL },
                new OpcodeData { Name = "BIT",	// CB40: BIT 0 B
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB41: BIT 0 C
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB42: BIT 0 D
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB43: BIT 0 E
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB44: BIT 0 H
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB45: BIT 0 L
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB46: BIT 0 (HL)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB47: BIT 0 A
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB48: BIT 1 B
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB49: BIT 1 C
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB4A: BIT 1 D
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB4B: BIT 1 E
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB4C: BIT 1 H
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB4D: BIT 1 L
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB4E: BIT 1 (HL)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB4F: BIT 1 A
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB50: BIT 2 B
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB51: BIT 2 C
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB52: BIT 2 D
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB53: BIT 2 E
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB54: BIT 2 H
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB55: BIT 2 L
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB56: BIT 2 (HL)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB57: BIT 2 A
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB58: BIT 3 B
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB59: BIT 3 C
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB5A: BIT 3 D
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB5B: BIT 3 E
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB5C: BIT 3 H
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB5D: BIT 3 L
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB5E: BIT 3 (HL)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB5F: BIT 3 A
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB60: BIT 4 B
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB61: BIT 4 C
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB62: BIT 4 D
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB63: BIT 4 E
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB64: BIT 4 H
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB65: BIT 4 L
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB66: BIT 4 (HL)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB67: BIT 4 A
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB68: BIT 5 B
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB69: BIT 5 C
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB6A: BIT 5 D
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB6B: BIT 5 E
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB6C: BIT 5 H
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB6D: BIT 5 L
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB6E: BIT 5 (HL)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB6F: BIT 5 A
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB70: BIT 6 B
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB71: BIT 6 C
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB72: BIT 6 D
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB73: BIT 6 E
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB74: BIT 6 H
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB75: BIT 6 L
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB76: BIT 6 (HL)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB77: BIT 6 A
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB78: BIT 7 B
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB79: BIT 7 C
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB7A: BIT 7 D
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB7B: BIT 7 E
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB7C: BIT 7 H
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB7D: BIT 7 L
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB7E: BIT 7 (HL)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// CB7F: BIT 7 A
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "RES",	// CB80: RES 0 B
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB81: RES 0 C
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB82: RES 0 D
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB83: RES 0 E
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB84: RES 0 H
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB85: RES 0 L
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB86: RES 0 (HL)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB87: RES 0 A
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB88: RES 1 B
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB89: RES 1 C
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB8A: RES 1 D
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB8B: RES 1 E
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB8C: RES 1 H
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB8D: RES 1 L
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB8E: RES 1 (HL)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB8F: RES 1 A
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB90: RES 2 B
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB91: RES 2 C
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB92: RES 2 D
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB93: RES 2 E
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB94: RES 2 H
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB95: RES 2 L
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB96: RES 2 (HL)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB97: RES 2 A
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB98: RES 3 B
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB99: RES 3 C
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB9A: RES 3 D
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB9B: RES 3 E
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB9C: RES 3 H
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB9D: RES 3 L
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB9E: RES 3 (HL)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CB9F: RES 3 A
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBA0: RES 4 B
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBA1: RES 4 C
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBA2: RES 4 D
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBA3: RES 4 E
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBA4: RES 4 H
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBA5: RES 4 L
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBA6: RES 4 (HL)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBA7: RES 4 A
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBA8: RES 5 B
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBA9: RES 5 C
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBAA: RES 5 D
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBAB: RES 5 E
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBAC: RES 5 H
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBAD: RES 5 L
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBAE: RES 5 (HL)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBAF: RES 5 A
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBB0: RES 6 B
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBB1: RES 6 C
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBB2: RES 6 D
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBB3: RES 6 E
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBB4: RES 6 H
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBB5: RES 6 L
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBB6: RES 6 (HL)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBB7: RES 6 A
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBB8: RES 7 B
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBB9: RES 7 C
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBBA: RES 7 D
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBBB: RES 7 E
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBBC: RES 7 H
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBBD: RES 7 L
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBBE: RES 7 (HL)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// CBBF: RES 7 A
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "SET",	// CBC0: SET 0 B
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBC1: SET 0 C
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBC2: SET 0 D
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBC3: SET 0 E
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBC4: SET 0 H
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBC5: SET 0 L
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBC6: SET 0 (HL)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBC7: SET 0 A
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBC8: SET 1 B
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBC9: SET 1 C
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBCA: SET 1 D
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBCB: SET 1 E
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBCC: SET 1 H
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBCD: SET 1 L
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBCE: SET 1 (HL)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBCF: SET 1 A
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBD0: SET 2 B
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBD1: SET 2 C
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBD2: SET 2 D
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBD3: SET 2 E
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBD4: SET 2 H
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBD5: SET 2 L
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBD6: SET 2 (HL)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBD7: SET 2 A
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBD8: SET 3 B
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBD9: SET 3 C
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBDA: SET 3 D
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBDB: SET 3 E
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBDC: SET 3 H
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBDD: SET 3 L
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBDE: SET 3 (HL)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBDF: SET 3 A
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBE0: SET 4 B
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBE1: SET 4 C
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBE2: SET 4 D
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBE3: SET 4 E
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBE4: SET 4 H
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBE5: SET 4 L
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBE6: SET 4 (HL)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBE7: SET 4 A
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBE8: SET 5 B
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBE9: SET 5 C
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBEA: SET 5 D
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBEB: SET 5 E
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBEC: SET 5 H
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBED: SET 5 L
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBEE: SET 5 (HL)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBEF: SET 5 A
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBF0: SET 6 B
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBF1: SET 6 C
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBF2: SET 6 D
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBF3: SET 6 E
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBF4: SET 6 H
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBF5: SET 6 L
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBF6: SET 6 (HL)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBF7: SET 6 A
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBF8: SET 7 B
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBF9: SET 7 C
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBFA: SET 7 D
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBFB: SET 7 E
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBFC: SET 7 H
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBFD: SET 7 L
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBFE: SET 7 (HL)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HL, Reg2Param = RegParam.Reference,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// CBFF: SET 7 A
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
            },

            {
                new OpcodeData { Name = "",		// 00
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 01
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 02
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 03
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 04
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 05
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 06
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 07
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 08
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 09
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 0A
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 0B
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 0C
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 0D
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 0E
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 0F
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 10
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 11
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 12
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 13
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 14
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 15
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 16
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 17
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 18
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 19
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 1A
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 1B
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 1C
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 1D
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 1E
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 1F
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 20
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 21
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 22
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 23
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 24
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 25
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 26
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 27
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 28
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 29
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 2A
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 2B
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 2C
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 2D
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 2E
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 2F
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 30
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 31
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 32
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 33
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 34
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 35
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 36
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 37
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 38
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 39
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 3A
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 3B
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 3C
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 3D
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 3E
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 3F
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "IN",	// ED40: IN B (C)
                                 Reg1 = Register.B, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.IN },
                new OpcodeData { Name = "OUT",	// ED41: OUT (C) B
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.OUT },
                new OpcodeData { Name = "SBC",	// ED42: SBC HL BC
                                 Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.BC, Reg2Param = RegParam.WordData,
                                 Function = Operation.SBC },
                new OpcodeData { Name = "LD",	// ED43: LD (nn) BC
                                 Reg1 = Register.ImmediateWord, Reg1Param = RegParam.Reference | RegParam.WordData,
                                 Reg2 = Register.BC, Reg2Param = RegParam.WordData,
                                 Function = Operation.LD },
                new OpcodeData { Name = "NEG",	// ED44: NEG  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.NEG },
                new OpcodeData { Name = "RETN",	// ED45: RETN  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RETN },
                new OpcodeData { Name = "IM",	// ED46: IM 0 
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.IM },
                new OpcodeData { Name = "LD",	// ED47: LD I A
                                 Reg1 = Register.I, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "IN",	// ED48: IN C (C)
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.IN },
                new OpcodeData { Name = "OUT",	// ED49: OUT (C) C
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.OUT },
                new OpcodeData { Name = "ADC",	// ED4A: ADC HL BC
                                 Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.BC, Reg2Param = RegParam.WordData,
                                 Function = Operation.ADC },
                new OpcodeData { Name = "LD",	// ED4B: LD BC (nn)
                                 Reg1 = Register.BC, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.Reference | RegParam.WordData,
                                 Function = Operation.LD },
                new OpcodeData { Name = "NEG",	// ED4C: NEG  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.NEG },
                new OpcodeData { Name = "RETI",	// ED4D: RETI  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RETI },
                new OpcodeData { Name = "IM",	// ED4E: IM 0 
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.IM },
                new OpcodeData { Name = "LD",	// ED4F: LD R A
                                 Reg1 = Register.R, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "IN",	// ED50: IN D (C)
                                 Reg1 = Register.D, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.IN },
                new OpcodeData { Name = "OUT",	// ED51: OUT (C) D
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.OUT },
                new OpcodeData { Name = "SBC",	// ED52: SBC HL DE
                                 Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.DE, Reg2Param = RegParam.WordData,
                                 Function = Operation.SBC },
                new OpcodeData { Name = "LD",	// ED53: LD (nn) DE
                                 Reg1 = Register.ImmediateWord, Reg1Param = RegParam.Reference | RegParam.WordData,
                                 Reg2 = Register.DE, Reg2Param = RegParam.WordData,
                                 Function = Operation.LD },
                new OpcodeData { Name = "NEG",	// ED54: NEG  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.NEG },
                new OpcodeData { Name = "RETN",	// ED55: RETN  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RETN },
                new OpcodeData { Name = "IM",	// ED56: IM 1 
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.IM },
                new OpcodeData { Name = "LD",	// ED57: LD A I
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.I, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "IN",	// ED58: IN E (C)
                                 Reg1 = Register.E, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.IN },
                new OpcodeData { Name = "OUT",	// ED59: OUT (C) E
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.OUT },
                new OpcodeData { Name = "ADC",	// ED5A: ADC HL DE
                                 Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.DE, Reg2Param = RegParam.WordData,
                                 Function = Operation.ADC },
                new OpcodeData { Name = "LD",	// ED5B: LD DE (nn)
                                 Reg1 = Register.DE, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.Reference | RegParam.WordData,
                                 Function = Operation.LD },
                new OpcodeData { Name = "NEG",	// ED5C: NEG  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.NEG },
                new OpcodeData { Name = "RETN",	// ED5D: RETN  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RETN },
                new OpcodeData { Name = "IM",	// ED5E: IM 2 
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.IM },
                new OpcodeData { Name = "LD",	// ED5F: LD A R
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.R, Reg2Param = RegParam.None,
                                 Function = Operation.LD },
                new OpcodeData { Name = "IN",	// ED60: IN H (C)
                                 Reg1 = Register.XH, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.IN },
                new OpcodeData { Name = "OUT",	// ED61: OUT (C) H
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.OUT },
                new OpcodeData { Name = "SBC",	// ED62: SBC HL HL
                                 Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.HL, Reg2Param = RegParam.WordData,
                                 Function = Operation.SBC },
                new OpcodeData { Name = "LD",	// ED63: LD (nn) HL
                                 Reg1 = Register.ImmediateWord, Reg1Param = RegParam.Reference | RegParam.WordData,
                                 Reg2 = Register.HL, Reg2Param = RegParam.WordData,
                                 Function = Operation.LD },
                new OpcodeData { Name = "NEG",	// ED64: NEG  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.NEG },
                new OpcodeData { Name = "RETN",	// ED65: RETN  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RETN },
                new OpcodeData { Name = "IM",	// ED66: IM 0 
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.IM },
                new OpcodeData { Name = "RRD",	// ED67: RRD  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RRD },
                new OpcodeData { Name = "IN",	// ED68: IN L (C)
                                 Reg1 = Register.XL, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.IN },
                new OpcodeData { Name = "OUT",	// ED69: OUT (C) L
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.OUT },
                new OpcodeData { Name = "ADC",	// ED6A: ADC HL HL
                                 Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.HL, Reg2Param = RegParam.WordData,
                                 Function = Operation.ADC },
                new OpcodeData { Name = "LD",	// ED6B: LD HL (nn)
                                 Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.Reference | RegParam.WordData,
                                 Function = Operation.LD },
                new OpcodeData { Name = "NEG",	// ED6C: NEG  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.NEG },
                new OpcodeData { Name = "RETN",	// ED6D: RETN  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RETN },
                new OpcodeData { Name = "IM",	// ED6E: IM 0 
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.IM },
                new OpcodeData { Name = "RLD",	// ED6F: RLD  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RLD },
                new OpcodeData { Name = "IN",	// ED70: IN (C) 
                                 Reg1 = Register.C, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.IN },
                new OpcodeData { Name = "OUT",	// ED71: OUT (C) 0
                                 Reg1 = Register.C, Reg1Param = RegParam.Reference,
                                 Reg2 = (Register)0, Reg2Param = RegParam.Literal,
                                 Function = Operation.OUT },
                new OpcodeData { Name = "SBC",	// ED72: SBC HL SP
                                 Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.SP, Reg2Param = RegParam.WordData,
                                 Function = Operation.SBC },
                new OpcodeData { Name = "LD",	// ED73: LD (nn) SP
                                 Reg1 = Register.ImmediateWord, Reg1Param = RegParam.Reference | RegParam.WordData,
                                 Reg2 = Register.SP, Reg2Param = RegParam.WordData,
                                 Function = Operation.LD },
                new OpcodeData { Name = "NEG",	// ED74: NEG  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.NEG },
                new OpcodeData { Name = "RETN",	// ED75: RETN  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RETN },
                new OpcodeData { Name = "IM",	// ED76: IM 1 
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.IM },
                new OpcodeData { Name = "",		// 77
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "IN",	// ED78: IN A (C)
                                 Reg1 = Register.A, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.IN },
                new OpcodeData { Name = "OUT",	// ED79: OUT (C) A
                                 Reg1 = Register.C, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.OUT },
                new OpcodeData { Name = "ADC",	// ED7A: ADC HL SP
                                 Reg1 = Register.HL, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.SP, Reg2Param = RegParam.WordData,
                                 Function = Operation.ADC },
                new OpcodeData { Name = "LD",	// ED7B: LD SP (nn)
                                 Reg1 = Register.SP, Reg1Param = RegParam.WordData,
                                 Reg2 = Register.ImmediateWord, Reg2Param = RegParam.Reference | RegParam.WordData,
                                 Function = Operation.LD },
                new OpcodeData { Name = "NEG",	// ED7C: NEG  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.NEG },
                new OpcodeData { Name = "RETN",	// ED7D: RETN  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RETN },
                new OpcodeData { Name = "IM",	// ED7E: IM 2 
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.IM },
                new OpcodeData { Name = "",		// 7F
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 80
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 81
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 82
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 83
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 84
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 85
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 86
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 87
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 88
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 89
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 8A
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 8B
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 8C
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 8D
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 8E
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 8F
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 90
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 91
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 92
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 93
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 94
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 95
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 96
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 97
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 98
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 99
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 9A
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 9B
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 9C
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 9D
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 9E
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// 9F
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "LDI",	// EDA0: LDI  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.LDI },
                new OpcodeData { Name = "CPI",	// EDA1: CPI  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.CPI },
                new OpcodeData { Name = "INI",	// EDA2: INI  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.INI },
                new OpcodeData { Name = "OUTI",	// EDA3: OUTI  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.OUTI },
                new OpcodeData { Name = "",		// A4
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// A5
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// A6
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// A7
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "LDD",	// EDA8: LDD  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.LDD },
                new OpcodeData { Name = "CPD",	// EDA9: CPD  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.CPD },
                new OpcodeData { Name = "IND",	// EDAA: IND  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.IND },
                new OpcodeData { Name = "OUTD",	// EDAB: OUTD  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.OUTD },
                new OpcodeData { Name = "",		// AC
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// AD
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// AE
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// AF
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "LDIR",	// EDB0: LDIR  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.LDIR },
                new OpcodeData { Name = "CPIR",	// EDB1: CPIR  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.CPIR },
                new OpcodeData { Name = "INIR",	// EDB2: INIR  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.INIR },
                new OpcodeData { Name = "OTIR",	// EDB3: OTIR  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.OTIR },
                new OpcodeData { Name = "",		// B4
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// B5
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// B6
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// B7
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "LDDR",	// EDB8: LDDR  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.LDDR },
                new OpcodeData { Name = "CPDR",	// EDB9: CPDR  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.CPDR },
                new OpcodeData { Name = "INDR",	// EDBA: INDR  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.INDR },
                new OpcodeData { Name = "OTDR",	// EDBB: OTDR  
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.OTDR },
                new OpcodeData { Name = "",		// BC
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// BD
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// BE
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// BF
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// C0
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// C1
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// C2
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// C3
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// C4
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// C5
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// C6
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// C7
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// C8
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// C9
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// CA
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// CB
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// CC
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// CD
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// CE
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// CF
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// D0
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// D1
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// D2
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// D3
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// D4
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// D5
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// D6
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// D7
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// D8
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// D9
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// DA
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// DB
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// DC
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// DD
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// DE
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// DF
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// E0
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// E1
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// E2
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// E3
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// E4
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// E5
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// E6
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// E7
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// E8
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// E9
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// EA
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// EB
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// EC
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// ED
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// EE
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// EF
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// F0
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// F1
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// F2
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// F3
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// F4
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// F5
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// F6
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// F7
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// F8
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// F9
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// FA
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// FB
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// FC
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// FD
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// FE
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
                new OpcodeData { Name = "",		// FF
                                 Reg1 = Register.None, Reg1Param = RegParam.None,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.Error },
            },

            {
                new OpcodeData { Name = "RLC",	// DDCB00: RLC (IX) B
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.RLC },
                new OpcodeData { Name = "RLC",	// DDCB01: RLC (IX) C
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.RLC },
                new OpcodeData { Name = "RLC",	// DDCB02: RLC (IX) D
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.RLC },
                new OpcodeData { Name = "RLC",	// DDCB03: RLC (IX) E
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.RLC },
                new OpcodeData { Name = "RLC",	// DDCB04: RLC (IX) H
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.RLC },
                new OpcodeData { Name = "RLC",	// DDCB05: RLC (IX) L
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.RLC },
                new OpcodeData { Name = "RLC",	// DDCB06: RLC (IX) 
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RLC },
                new OpcodeData { Name = "RLC",	// DDCB07: RLC (IX) A
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.RLC },
                new OpcodeData { Name = "RRC",	// DDCB08: RRC (IX) B
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.RRC },
                new OpcodeData { Name = "RRC",	// DDCB09: RRC (IX) C
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.RRC },
                new OpcodeData { Name = "RRC",	// DDCB0A: RRC (IX) D
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.RRC },
                new OpcodeData { Name = "RRC",	// DDCB0B: RRC (IX) E
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.RRC },
                new OpcodeData { Name = "RRC",	// DDCB0C: RRC (IX) H
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.RRC },
                new OpcodeData { Name = "RRC",	// DDCB0D: RRC (IX) L
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.RRC },
                new OpcodeData { Name = "RRC",	// DDCB0E: RRC (IX) 
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RRC },
                new OpcodeData { Name = "RRC",	// DDCB0F: RRC (IX) A
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.RRC },
                new OpcodeData { Name = "RL",	// DDCB10: RL (IX) B
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.RL },
                new OpcodeData { Name = "RL",	// DDCB11: RL (IX) C
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.RL },
                new OpcodeData { Name = "RL",	// DDCB12: RL (IX) D
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.RL },
                new OpcodeData { Name = "RL",	// DDCB13: RL (IX) E
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.RL },
                new OpcodeData { Name = "RL",	// DDCB14: RL (IX) H
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.RL },
                new OpcodeData { Name = "RL",	// DDCB15: RL (IX) L
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.RL },
                new OpcodeData { Name = "RL",	// DDCB16: RL (IX) 
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RL },
                new OpcodeData { Name = "RL",	// DDCB17: RL (IX) A
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.RL },
                new OpcodeData { Name = "RR",	// DDCB18: RR (IX) B
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.RR },
                new OpcodeData { Name = "RR",	// DDCB19: RR (IX) C
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.RR },
                new OpcodeData { Name = "RR",	// DDCB1A: RR (IX) D
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.RR },
                new OpcodeData { Name = "RR",	// DDCB1B: RR (IX) E
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.RR },
                new OpcodeData { Name = "RR",	// DDCB1C: RR (IX) H
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.RR },
                new OpcodeData { Name = "RR",	// DDCB1D: RR (IX) L
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.RR },
                new OpcodeData { Name = "RR",	// DDCB1E: RR (IX) 
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.RR },
                new OpcodeData { Name = "RR",	// DDCB1F: RR (IX) A
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.RR },
                new OpcodeData { Name = "SLA",	// DDCB20: SLA (IX) B
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.SLA },
                new OpcodeData { Name = "SLA",	// DDCB21: SLA (IX) C
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.SLA },
                new OpcodeData { Name = "SLA",	// DDCB22: SLA (IX) D
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.SLA },
                new OpcodeData { Name = "SLA",	// DDCB23: SLA (IX) E
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.SLA },
                new OpcodeData { Name = "SLA",	// DDCB24: SLA (IX) H
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.SLA },
                new OpcodeData { Name = "SLA",	// DDCB25: SLA (IX) L
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.SLA },
                new OpcodeData { Name = "SLA",	// DDCB26: SLA (IX) 
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLA },
                new OpcodeData { Name = "SLA",	// DDCB27: SLA (IX) A
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.SLA },
                new OpcodeData { Name = "SRA",	// DDCB28: SRA (IX) B
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.SRA },
                new OpcodeData { Name = "SRA",	// DDCB29: SRA (IX) C
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.SRA },
                new OpcodeData { Name = "SRA",	// DDCB2A: SRA (IX) D
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.SRA },
                new OpcodeData { Name = "SRA",	// DDCB2B: SRA (IX) E
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.SRA },
                new OpcodeData { Name = "SRA",	// DDCB2C: SRA (IX) H
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.SRA },
                new OpcodeData { Name = "SRA",	// DDCB2D: SRA (IX) L
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.SRA },
                new OpcodeData { Name = "SRA",	// DDCB2E: SRA (IX) 
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRA },
                new OpcodeData { Name = "SRA",	// DDCB2F: SRA (IX) A
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.SRA },
                new OpcodeData { Name = "SLL",	// DDCB30: SLL (IX) B
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.SLL },
                new OpcodeData { Name = "SLL",	// DDCB31: SLL (IX) C
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.SLL },
                new OpcodeData { Name = "SLL",	// DDCB32: SLL (IX) D
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.SLL },
                new OpcodeData { Name = "SLL",	// DDCB33: SLL (IX) E
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.SLL },
                new OpcodeData { Name = "SLL",	// DDCB34: SLL (IX) H
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.SLL },
                new OpcodeData { Name = "SLL",	// DDCB35: SLL (IX) L
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.SLL },
                new OpcodeData { Name = "SLL",	// DDCB36: SLL (IX) 
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SLL },
                new OpcodeData { Name = "SLL",	// DDCB37: SLL (IX) A
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.SLL },
                new OpcodeData { Name = "SRL",	// DDCB38: SRL (IX) B
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.B, Reg2Param = RegParam.None,
                                 Function = Operation.SRL },
                new OpcodeData { Name = "SRL",	// DDCB39: SRL (IX) C
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.C, Reg2Param = RegParam.None,
                                 Function = Operation.SRL },
                new OpcodeData { Name = "SRL",	// DDCB3A: SRL (IX) D
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.D, Reg2Param = RegParam.None,
                                 Function = Operation.SRL },
                new OpcodeData { Name = "SRL",	// DDCB3B: SRL (IX) E
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.E, Reg2Param = RegParam.None,
                                 Function = Operation.SRL },
                new OpcodeData { Name = "SRL",	// DDCB3C: SRL (IX) H
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.XH, Reg2Param = RegParam.None,
                                 Function = Operation.SRL },
                new OpcodeData { Name = "SRL",	// DDCB3D: SRL (IX) L
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.XL, Reg2Param = RegParam.None,
                                 Function = Operation.SRL },
                new OpcodeData { Name = "SRL",	// DDCB3E: SRL (IX) 
                                 Reg1 = Register.HD, Reg1Param = RegParam.Reference,
                                 Reg2 = Register.None, Reg2Param = RegParam.None,
                                 Function = Operation.SRL },
                new OpcodeData { Name = "SRL",	// DDCB3F: SRL (IX) A
                                 Reg1 = Register.HD, Reg1Param = RegParam.None,
                                 Reg2 = Register.A, Reg2Param = RegParam.None,
                                 Function = Operation.SRL },
                new OpcodeData { Name = "BIT",	// DDCB40: BIT 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB41: BIT 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB42: BIT 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB43: BIT 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB44: BIT 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB45: BIT 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB46: BIT 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB47: BIT 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB48: BIT 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB49: BIT 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB4A: BIT 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB4B: BIT 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB4C: BIT 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB4D: BIT 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB4E: BIT 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB4F: BIT 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB50: BIT 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB51: BIT 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB52: BIT 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB53: BIT 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB54: BIT 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB55: BIT 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB56: BIT 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB57: BIT 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB58: BIT 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB59: BIT 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB5A: BIT 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB5B: BIT 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB5C: BIT 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB5D: BIT 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB5E: BIT 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB5F: BIT 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB60: BIT 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB61: BIT 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB62: BIT 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB63: BIT 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB64: BIT 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB65: BIT 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB66: BIT 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB67: BIT 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB68: BIT 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB69: BIT 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB6A: BIT 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB6B: BIT 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB6C: BIT 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB6D: BIT 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB6E: BIT 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB6F: BIT 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB70: BIT 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB71: BIT 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB72: BIT 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB73: BIT 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB74: BIT 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB75: BIT 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB76: BIT 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB77: BIT 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB78: BIT 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB79: BIT 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB7A: BIT 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB7B: BIT 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB7C: BIT 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB7D: BIT 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB7E: BIT 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "BIT",	// DDCB7F: BIT 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.BIT },
                new OpcodeData { Name = "RES",	// DDCB80: RES 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB81: RES 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB82: RES 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB83: RES 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB84: RES 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB85: RES 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB86: RES 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB87: RES 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB88: RES 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB89: RES 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB8A: RES 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB8B: RES 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB8C: RES 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB8D: RES 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB8E: RES 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB8F: RES 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB90: RES 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB91: RES 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB92: RES 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB93: RES 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB94: RES 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB95: RES 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB96: RES 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB97: RES 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB98: RES 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB99: RES 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB9A: RES 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB9B: RES 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB9C: RES 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB9D: RES 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB9E: RES 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCB9F: RES 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBA0: RES 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBA1: RES 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBA2: RES 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBA3: RES 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBA4: RES 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBA5: RES 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBA6: RES 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBA7: RES 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBA8: RES 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBA9: RES 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBAA: RES 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBAB: RES 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBAC: RES 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBAD: RES 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBAE: RES 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBAF: RES 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBB0: RES 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBB1: RES 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBB2: RES 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBB3: RES 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBB4: RES 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBB5: RES 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBB6: RES 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBB7: RES 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBB8: RES 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBB9: RES 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBBA: RES 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBBB: RES 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBBC: RES 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBBD: RES 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBBE: RES 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.RES },
                new OpcodeData { Name = "RES",	// DDCBBF: RES 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.RES },
                new OpcodeData { Name = "SET",	// DDCBC0: SET 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBC1: SET 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBC2: SET 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBC3: SET 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBC4: SET 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBC5: SET 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBC6: SET 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBC7: SET 0 (IX)
                                 Reg1 = (Register)0, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBC8: SET 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBC9: SET 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBCA: SET 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBCB: SET 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBCC: SET 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBCD: SET 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBCE: SET 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBCF: SET 1 (IX)
                                 Reg1 = (Register)1, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBD0: SET 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBD1: SET 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBD2: SET 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBD3: SET 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBD4: SET 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBD5: SET 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBD6: SET 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBD7: SET 2 (IX)
                                 Reg1 = (Register)2, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBD8: SET 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBD9: SET 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBDA: SET 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBDB: SET 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBDC: SET 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBDD: SET 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBDE: SET 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBDF: SET 3 (IX)
                                 Reg1 = (Register)3, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBE0: SET 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBE1: SET 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBE2: SET 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBE3: SET 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBE4: SET 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBE5: SET 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBE6: SET 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBE7: SET 4 (IX)
                                 Reg1 = (Register)4, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBE8: SET 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBE9: SET 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBEA: SET 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBEB: SET 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBEC: SET 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBED: SET 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBEE: SET 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBEF: SET 5 (IX)
                                 Reg1 = (Register)5, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBF0: SET 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBF1: SET 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBF2: SET 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBF3: SET 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBF4: SET 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBF5: SET 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBF6: SET 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBF7: SET 6 (IX)
                                 Reg1 = (Register)6, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBF8: SET 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBF9: SET 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBFA: SET 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBFB: SET 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBFC: SET 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBFD: SET 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBFE: SET 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.Reference,
                                 Function = Operation.SET },
                new OpcodeData { Name = "SET",	// DDCBFF: SET 7 (IX)
                                 Reg1 = (Register)7, Reg1Param = RegParam.Literal,
                                 Reg2 = Register.HD, Reg2Param = RegParam.None,
                                 Function = Operation.SET },
            },
        };
    }
}
