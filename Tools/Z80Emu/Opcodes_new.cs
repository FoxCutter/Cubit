namespace Z80Emu
{
    static class Ops
    {
        static public OpcodeData[,] ByteData = new OpcodeData[,]
        {
            {
                // 00: NOP
                new OpcodeData { Name = "NOP",
                                 Function = Operation.NOP,
                                 new Param[] { },
                               },

                // 01: LD BC, nn,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.BC, CommandID.WordData, },
                               },

                // 02: LD (BC), A,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.BC_Pointer, CommandID.A, },
                               },

                // 03: INC BC,
                new OpcodeData { Name = "INC",
                                 Function = Operation.INC,
                                 new Param[] { CommandID.BC, },
                               },

                // 04: INC B,
                new OpcodeData { Name = "INC",
                                 Function = Operation.INC,
                                 new Param[] { CommandID.B, },
                               },

                // 05: DEC B,
                new OpcodeData { Name = "DEC",
                                 Function = Operation.DEC,
                                 new Param[] { CommandID.B, },
                               },

                // 06: LD B, n,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.B, CommandID.ByteData, },
                               },

                // 07: RLCA
                new OpcodeData { Name = "RLCA",
                                 Function = Operation.RL_A_CY,
                                 new Param[] { },
                               },

                // 08: EX AF, AF,
                new OpcodeData { Name = "EX",
                                 Function = Operation.EX,
                                 new Param[] { CommandID.AF, CommandID.AF, },
                               },

                // 09: ADD HL, BC,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.HL, CommandID.BC, },
                               },

                // 0A: LD A, (BC),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.A, CommandID.BC_Pointer, },
                               },

                // 0B: DEC BC,
                new OpcodeData { Name = "DEC",
                                 Function = Operation.DEC,
                                 new Param[] { CommandID.BC, },
                               },

                // 0C: INC C,
                new OpcodeData { Name = "INC",
                                 Function = Operation.INC,
                                 new Param[] { CommandID.C, },
                               },

                // 0D: DEC C,
                new OpcodeData { Name = "DEC",
                                 Function = Operation.DEC,
                                 new Param[] { CommandID.C, },
                               },

                // 0E: LD C, n,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.C, CommandID.ByteData, },
                               },

                // 0F: RRCA
                new OpcodeData { Name = "RRCA",
                                 Function = Operation.RR_A_CY,
                                 new Param[] { },
                               },

                // 10: DJNZ e-2,
                new OpcodeData { Name = "DJNZ",
                                 Function = Operation.DJNZ,
                                 new Param[] { CommandID.Displacment, },
                               },

                // 11: LD DE, nn,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.DE, CommandID.WordData, },
                               },

                // 12: LD (DE), A,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.DE_Pointer, CommandID.A, },
                               },

                // 13: INC DE,
                new OpcodeData { Name = "INC",
                                 Function = Operation.INC,
                                 new Param[] { CommandID.DE, },
                               },

                // 14: INC D,
                new OpcodeData { Name = "INC",
                                 Function = Operation.INC,
                                 new Param[] { CommandID.D, },
                               },

                // 15: DEC D,
                new OpcodeData { Name = "DEC",
                                 Function = Operation.DEC,
                                 new Param[] { CommandID.D, },
                               },

                // 16: LD D, n,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.D, CommandID.ByteData, },
                               },

                // 17: RLA
                new OpcodeData { Name = "RLA",
                                 Function = Operation.RL_A,
                                 new Param[] { },
                               },

                // 18: JR e-2,
                new OpcodeData { Name = "JR",
                                 Function = Operation.JR,
                                 new Param[] { CommandID.Displacment, },
                               },

                // 19: ADD HL, DE,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.HL, CommandID.DE, },
                               },

                // 1A: LD A, (DE),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.A, CommandID.DE_Pointer, },
                               },

                // 1B: DEC DE,
                new OpcodeData { Name = "DEC",
                                 Function = Operation.DEC,
                                 new Param[] { CommandID.DE, },
                               },

                // 1C: INC E,
                new OpcodeData { Name = "INC",
                                 Function = Operation.INC,
                                 new Param[] { CommandID.E, },
                               },

                // 1D: DEC E,
                new OpcodeData { Name = "DEC",
                                 Function = Operation.DEC,
                                 new Param[] { CommandID.E, },
                               },

                // 1E: LD E, n,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.E, CommandID.ByteData, },
                               },

                // 1F: RRA
                new OpcodeData { Name = "RRA",
                                 Function = Operation.RR_A,
                                 new Param[] { },
                               },

                // 20: JR Flag_NZ, e-2,
                new OpcodeData { Name = "JR",
                                 Function = Operation.JR,
                                 new Param[] { CommandID.Flag_NZ, CommandID.Displacment, },
                               },

                // 21: LD HL, nn,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.HL, CommandID.WordData, },
                               },

                // 22: LD (**), HL,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.Address_Pointer, CommandID.HL, },
                               },

                // 23: LD (**), IX,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.Address_Pointer, CommandID.IX, },
                               },

                // 24: LD (**), IY,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.Address_Pointer, CommandID.IY, },
                               },

                // 25: DEC H,
                new OpcodeData { Name = "DEC",
                                 Function = Operation.DEC,
                                 new Param[] { CommandID.H, },
                               },

                // 26: LD H, n,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.H, CommandID.ByteData, },
                               },

                // 27: DAA
                new OpcodeData { Name = "DAA",
                                 Function = Operation.BCD_Adjust,
                                 new Param[] { },
                               },

                // 28: JR Flag_Z, e-2,
                new OpcodeData { Name = "JR",
                                 Function = Operation.JR,
                                 new Param[] { CommandID.Flag_Z, CommandID.Displacment, },
                               },

                // 29: ADD HL, HL,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.HL, CommandID.HL, },
                               },

                // 2A: LD HL, (**),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.HL, CommandID.Address_Pointer, },
                               },

                // 2B: LD IX, (**),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IX, CommandID.Address_Pointer, },
                               },

                // 2C: LD IY, (**),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IY, CommandID.Address_Pointer, },
                               },

                // 2D: DEC IXH,
                new OpcodeData { Name = "DEC",
                                 Function = Operation.DEC,
                                 new Param[] { CommandID.IXH, },
                               },

                // 2E: LD IXH, n,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IXH, CommandID.ByteData, },
                               },

                // 2F: CPL A,
                new OpcodeData { Name = "CPL",
                                 Function = Operation.NOT,
                                 new Param[] { CommandID.A, },
                               },

                // 30: JR Flag_NC, e-2,
                new OpcodeData { Name = "JR",
                                 Function = Operation.JR,
                                 new Param[] { CommandID.Flag_NC, CommandID.Displacment, },
                               },

                // 31: LD SP, nn,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.SP, CommandID.WordData, },
                               },

                // 32: LD (**), A,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.Address_Pointer, CommandID.A, },
                               },

                // 33: INC SP,
                new OpcodeData { Name = "INC",
                                 Function = Operation.INC,
                                 new Param[] { CommandID.SP, },
                               },

                // 34: INC (HL),
                new OpcodeData { Name = "INC",
                                 Function = Operation.INC,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // 35: DEC (HL),
                new OpcodeData { Name = "DEC",
                                 Function = Operation.DEC,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // 36: LD (HL), n,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.HL_Pointer, CommandID.ByteData, },
                               },

                // 37: SCF
                new OpcodeData { Name = "SCF",
                                 Function = Operation.CY_SET,
                                 new Param[] { },
                               },

                // 38: JR Flag_CY, e-2,
                new OpcodeData { Name = "JR",
                                 Function = Operation.JR,
                                 new Param[] { CommandID.Flag_CY, CommandID.Displacment, },
                               },

                // 39: ADD HL, SP,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.HL, CommandID.SP, },
                               },

                // 3A: LD A, (**),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.A, CommandID.Address_Pointer, },
                               },

                // 3B: DEC SP,
                new OpcodeData { Name = "DEC",
                                 Function = Operation.DEC,
                                 new Param[] { CommandID.SP, },
                               },

                // 3C: INC L,
                new OpcodeData { Name = "INC",
                                 Function = Operation.INC,
                                 new Param[] { CommandID.L, },
                               },

                // 3D: DEC L,
                new OpcodeData { Name = "DEC",
                                 Function = Operation.DEC,
                                 new Param[] { CommandID.L, },
                               },

                // 3E: LD L, n,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.L, CommandID.ByteData, },
                               },

                // 3F: CCF
                new OpcodeData { Name = "CCF",
                                 Function = Operation.CY_Invert,
                                 new Param[] { },
                               },

                // 40: LD B, B,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.B, CommandID.B, },
                               },

                // 41: LD B, C,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.B, CommandID.C, },
                               },

                // 42: LD B, D,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.B, CommandID.D, },
                               },

                // 43: LD B, E,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.B, CommandID.E, },
                               },

                // 44: LD B, H,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.B, CommandID.H, },
                               },

                // 45: LD B, IXH,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.B, CommandID.IXH, },
                               },

                // 46: LD B, (HL),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.B, CommandID.HL_Pointer, },
                               },

                // 47: LD B, L,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.B, CommandID.L, },
                               },

                // 48: LD C, B,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.C, CommandID.B, },
                               },

                // 49: LD C, C,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.C, CommandID.C, },
                               },

                // 4A: LD C, D,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.C, CommandID.D, },
                               },

                // 4B: LD C, E,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.C, CommandID.E, },
                               },

                // 4C: LD C, H,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.C, CommandID.H, },
                               },

                // 4D: LD C, IXH,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.C, CommandID.IXH, },
                               },

                // 4E: LD C, (HL),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.C, CommandID.HL_Pointer, },
                               },

                // 4F: LD C, L,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.C, CommandID.L, },
                               },

                // 50: LD D, B,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.D, CommandID.B, },
                               },

                // 51: LD D, C,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.D, CommandID.C, },
                               },

                // 52: LD D, D,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.D, CommandID.D, },
                               },

                // 53: LD D, E,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.D, CommandID.E, },
                               },

                // 54: LD D, H,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.D, CommandID.H, },
                               },

                // 55: LD D, IXH,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.D, CommandID.IXH, },
                               },

                // 56: LD D, (HL),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.D, CommandID.HL_Pointer, },
                               },

                // 57: LD D, L,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.D, CommandID.L, },
                               },

                // 58: LD E, B,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.E, CommandID.B, },
                               },

                // 59: LD E, C,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.E, CommandID.C, },
                               },

                // 5A: LD E, D,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.E, CommandID.D, },
                               },

                // 5B: LD E, E,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.E, CommandID.E, },
                               },

                // 5C: LD E, H,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.E, CommandID.H, },
                               },

                // 5D: LD E, IXH,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.E, CommandID.IXH, },
                               },

                // 5E: LD E, (HL),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.E, CommandID.HL_Pointer, },
                               },

                // 5F: LD E, L,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.E, CommandID.L, },
                               },

                // 60: LD H, B,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.H, CommandID.B, },
                               },

                // 61: LD H, C,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.H, CommandID.C, },
                               },

                // 62: LD H, D,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.H, CommandID.D, },
                               },

                // 63: LD H, E,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.H, CommandID.E, },
                               },

                // 64: LD H, H,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.H, CommandID.H, },
                               },

                // 65: LD H, IXH,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.H, CommandID.IXH, },
                               },

                // 66: LD H, (HL),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.H, CommandID.HL_Pointer, },
                               },

                // 67: LD H, L,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.H, CommandID.L, },
                               },

                // 68: LD IXH, B,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IXH, CommandID.B, },
                               },

                // 69: LD IXH, C,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IXH, CommandID.C, },
                               },

                // 6A: LD IXH, D,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IXH, CommandID.D, },
                               },

                // 6B: LD IXH, E,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IXH, CommandID.E, },
                               },

                // 6C: LD IXH, H,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IXH, CommandID.H, },
                               },

                // 6D: LD IXH, IXH,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IXH, CommandID.IXH, },
                               },

                // 6E: LD IXH, (HL),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IXH, CommandID.HL_Pointer, },
                               },

                // 6F: LD IXH, L,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IXH, CommandID.L, },
                               },

                // 70: LD (HL), B,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.HL_Pointer, CommandID.B, },
                               },

                // 71: LD (HL), C,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.HL_Pointer, CommandID.C, },
                               },

                // 72: LD (HL), D,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.HL_Pointer, CommandID.D, },
                               },

                // 73: LD (HL), E,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.HL_Pointer, CommandID.E, },
                               },

                // 74: LD (HL), H,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.HL_Pointer, CommandID.H, },
                               },

                // 75: LD (HL), IXH,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.HL_Pointer, CommandID.IXH, },
                               },

                // 76: HALT
                new OpcodeData { Name = "HALT",
                                 Function = Operation.HALT,
                                 new Param[] { },
                               },

                // 77: LD (HL), L,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.HL_Pointer, CommandID.L, },
                               },

                // 78: LD (HL), IXL,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.HL_Pointer, CommandID.IXL, },
                               },

                // 79: LD (HL), IYL,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.HL_Pointer, CommandID.IYL, },
                               },

                // 7A: LD L, D,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.L, CommandID.D, },
                               },

                // 7B: LD (HL), A,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.HL_Pointer, CommandID.A, },
                               },

                // 7C: LD L, H,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.L, CommandID.H, },
                               },

                // 7D: LD L, IXH,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.L, CommandID.IXH, },
                               },

                // 7E: LD L, (HL),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.L, CommandID.HL_Pointer, },
                               },

                // 7F: LD L, L,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.L, CommandID.L, },
                               },

                // 80: ADD A, B,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.A, CommandID.B, },
                               },

                // 81: ADD A, C,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.A, CommandID.C, },
                               },

                // 82: ADD A, D,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.A, CommandID.D, },
                               },

                // 83: ADD A, E,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.A, CommandID.E, },
                               },

                // 84: ADD A, H,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.A, CommandID.H, },
                               },

                // 85: ADD A, IXH,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.A, CommandID.IXH, },
                               },

                // 86: ADD A, (HL),
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.A, CommandID.HL_Pointer, },
                               },

                // 87: ADD A, L,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.A, CommandID.L, },
                               },

                // 88: ADC A, B,
                new OpcodeData { Name = "ADC",
                                 Function = Operation.ADDC,
                                 new Param[] { CommandID.A, CommandID.B, },
                               },

                // 89: ADC A, C,
                new OpcodeData { Name = "ADC",
                                 Function = Operation.ADDC,
                                 new Param[] { CommandID.A, CommandID.C, },
                               },

                // 8A: ADC A, D,
                new OpcodeData { Name = "ADC",
                                 Function = Operation.ADDC,
                                 new Param[] { CommandID.A, CommandID.D, },
                               },

                // 8B: ADC A, E,
                new OpcodeData { Name = "ADC",
                                 Function = Operation.ADDC,
                                 new Param[] { CommandID.A, CommandID.E, },
                               },

                // 8C: ADC A, H,
                new OpcodeData { Name = "ADC",
                                 Function = Operation.ADDC,
                                 new Param[] { CommandID.A, CommandID.H, },
                               },

                // 8D: ADC A, IXH,
                new OpcodeData { Name = "ADC",
                                 Function = Operation.ADDC,
                                 new Param[] { CommandID.A, CommandID.IXH, },
                               },

                // 8E: ADC A, (HL),
                new OpcodeData { Name = "ADC",
                                 Function = Operation.ADDC,
                                 new Param[] { CommandID.A, CommandID.HL_Pointer, },
                               },

                // 8F: ADC A, L,
                new OpcodeData { Name = "ADC",
                                 Function = Operation.ADDC,
                                 new Param[] { CommandID.A, CommandID.L, },
                               },

                // 90: SUB A, B,
                new OpcodeData { Name = "SUB",
                                 Function = Operation.SUB,
                                 new Param[] { CommandID.A, CommandID.B, },
                               },

                // 91: SUB A, C,
                new OpcodeData { Name = "SUB",
                                 Function = Operation.SUB,
                                 new Param[] { CommandID.A, CommandID.C, },
                               },

                // 92: SUB A, D,
                new OpcodeData { Name = "SUB",
                                 Function = Operation.SUB,
                                 new Param[] { CommandID.A, CommandID.D, },
                               },

                // 93: SUB A, E,
                new OpcodeData { Name = "SUB",
                                 Function = Operation.SUB,
                                 new Param[] { CommandID.A, CommandID.E, },
                               },

                // 94: SUB A, H,
                new OpcodeData { Name = "SUB",
                                 Function = Operation.SUB,
                                 new Param[] { CommandID.A, CommandID.H, },
                               },

                // 95: SUB A, IXH,
                new OpcodeData { Name = "SUB",
                                 Function = Operation.SUB,
                                 new Param[] { CommandID.A, CommandID.IXH, },
                               },

                // 96: SUB A, (HL),
                new OpcodeData { Name = "SUB",
                                 Function = Operation.SUB,
                                 new Param[] { CommandID.A, CommandID.HL_Pointer, },
                               },

                // 97: SUB A, L,
                new OpcodeData { Name = "SUB",
                                 Function = Operation.SUB,
                                 new Param[] { CommandID.A, CommandID.L, },
                               },

                // 98: SBC A, B,
                new OpcodeData { Name = "SBC",
                                 Function = Operation.SUBC,
                                 new Param[] { CommandID.A, CommandID.B, },
                               },

                // 99: SBC A, C,
                new OpcodeData { Name = "SBC",
                                 Function = Operation.SUBC,
                                 new Param[] { CommandID.A, CommandID.C, },
                               },

                // 9A: SBC A, D,
                new OpcodeData { Name = "SBC",
                                 Function = Operation.SUBC,
                                 new Param[] { CommandID.A, CommandID.D, },
                               },

                // 9B: SBC A, E,
                new OpcodeData { Name = "SBC",
                                 Function = Operation.SUBC,
                                 new Param[] { CommandID.A, CommandID.E, },
                               },

                // 9C: SBC A, H,
                new OpcodeData { Name = "SBC",
                                 Function = Operation.SUBC,
                                 new Param[] { CommandID.A, CommandID.H, },
                               },

                // 9D: SBC A, IXH,
                new OpcodeData { Name = "SBC",
                                 Function = Operation.SUBC,
                                 new Param[] { CommandID.A, CommandID.IXH, },
                               },

                // 9E: SBC A, (HL),
                new OpcodeData { Name = "SBC",
                                 Function = Operation.SUBC,
                                 new Param[] { CommandID.A, CommandID.HL_Pointer, },
                               },

                // 9F: SBC A, L,
                new OpcodeData { Name = "SBC",
                                 Function = Operation.SUBC,
                                 new Param[] { CommandID.A, CommandID.L, },
                               },

                // A0: AND A, B,
                new OpcodeData { Name = "AND",
                                 Function = Operation.AND,
                                 new Param[] { CommandID.A, CommandID.B, },
                               },

                // A1: AND A, C,
                new OpcodeData { Name = "AND",
                                 Function = Operation.AND,
                                 new Param[] { CommandID.A, CommandID.C, },
                               },

                // A2: AND A, D,
                new OpcodeData { Name = "AND",
                                 Function = Operation.AND,
                                 new Param[] { CommandID.A, CommandID.D, },
                               },

                // A3: AND A, E,
                new OpcodeData { Name = "AND",
                                 Function = Operation.AND,
                                 new Param[] { CommandID.A, CommandID.E, },
                               },

                // A4: AND A, H,
                new OpcodeData { Name = "AND",
                                 Function = Operation.AND,
                                 new Param[] { CommandID.A, CommandID.H, },
                               },

                // A5: AND A, IXH,
                new OpcodeData { Name = "AND",
                                 Function = Operation.AND,
                                 new Param[] { CommandID.A, CommandID.IXH, },
                               },

                // A6: AND A, (HL),
                new OpcodeData { Name = "AND",
                                 Function = Operation.AND,
                                 new Param[] { CommandID.A, CommandID.HL_Pointer, },
                               },

                // A7: AND A, L,
                new OpcodeData { Name = "AND",
                                 Function = Operation.AND,
                                 new Param[] { CommandID.A, CommandID.L, },
                               },

                // A8: XOR A, B,
                new OpcodeData { Name = "XOR",
                                 Function = Operation.XOR,
                                 new Param[] { CommandID.A, CommandID.B, },
                               },

                // A9: XOR A, C,
                new OpcodeData { Name = "XOR",
                                 Function = Operation.XOR,
                                 new Param[] { CommandID.A, CommandID.C, },
                               },

                // AA: XOR A, D,
                new OpcodeData { Name = "XOR",
                                 Function = Operation.XOR,
                                 new Param[] { CommandID.A, CommandID.D, },
                               },

                // AB: XOR A, E,
                new OpcodeData { Name = "XOR",
                                 Function = Operation.XOR,
                                 new Param[] { CommandID.A, CommandID.E, },
                               },

                // AC: XOR A, H,
                new OpcodeData { Name = "XOR",
                                 Function = Operation.XOR,
                                 new Param[] { CommandID.A, CommandID.H, },
                               },

                // AD: XOR A, IXH,
                new OpcodeData { Name = "XOR",
                                 Function = Operation.XOR,
                                 new Param[] { CommandID.A, CommandID.IXH, },
                               },

                // AE: XOR A, (HL),
                new OpcodeData { Name = "XOR",
                                 Function = Operation.XOR,
                                 new Param[] { CommandID.A, CommandID.HL_Pointer, },
                               },

                // AF: XOR A, L,
                new OpcodeData { Name = "XOR",
                                 Function = Operation.XOR,
                                 new Param[] { CommandID.A, CommandID.L, },
                               },

                // B0: OR A, B,
                new OpcodeData { Name = "OR",
                                 Function = Operation.OR,
                                 new Param[] { CommandID.A, CommandID.B, },
                               },

                // B1: OR A, C,
                new OpcodeData { Name = "OR",
                                 Function = Operation.OR,
                                 new Param[] { CommandID.A, CommandID.C, },
                               },

                // B2: OR A, D,
                new OpcodeData { Name = "OR",
                                 Function = Operation.OR,
                                 new Param[] { CommandID.A, CommandID.D, },
                               },

                // B3: OR A, E,
                new OpcodeData { Name = "OR",
                                 Function = Operation.OR,
                                 new Param[] { CommandID.A, CommandID.E, },
                               },

                // B4: OR A, H,
                new OpcodeData { Name = "OR",
                                 Function = Operation.OR,
                                 new Param[] { CommandID.A, CommandID.H, },
                               },

                // B5: OR A, IXH,
                new OpcodeData { Name = "OR",
                                 Function = Operation.OR,
                                 new Param[] { CommandID.A, CommandID.IXH, },
                               },

                // B6: OR A, (HL),
                new OpcodeData { Name = "OR",
                                 Function = Operation.OR,
                                 new Param[] { CommandID.A, CommandID.HL_Pointer, },
                               },

                // B7: OR A, L,
                new OpcodeData { Name = "OR",
                                 Function = Operation.OR,
                                 new Param[] { CommandID.A, CommandID.L, },
                               },

                // B8: CP A, B,
                new OpcodeData { Name = "CP",
                                 Function = Operation.CMP,
                                 new Param[] { CommandID.A, CommandID.B, },
                               },

                // B9: CP A, C,
                new OpcodeData { Name = "CP",
                                 Function = Operation.CMP,
                                 new Param[] { CommandID.A, CommandID.C, },
                               },

                // BA: CP A, D,
                new OpcodeData { Name = "CP",
                                 Function = Operation.CMP,
                                 new Param[] { CommandID.A, CommandID.D, },
                               },

                // BB: CP A, E,
                new OpcodeData { Name = "CP",
                                 Function = Operation.CMP,
                                 new Param[] { CommandID.A, CommandID.E, },
                               },

                // BC: CP A, H,
                new OpcodeData { Name = "CP",
                                 Function = Operation.CMP,
                                 new Param[] { CommandID.A, CommandID.H, },
                               },

                // BD: CP A, IXH,
                new OpcodeData { Name = "CP",
                                 Function = Operation.CMP,
                                 new Param[] { CommandID.A, CommandID.IXH, },
                               },

                // BE: CP A, (HL),
                new OpcodeData { Name = "CP",
                                 Function = Operation.CMP,
                                 new Param[] { CommandID.A, CommandID.HL_Pointer, },
                               },

                // BF: CP A, L,
                new OpcodeData { Name = "CP",
                                 Function = Operation.CMP,
                                 new Param[] { CommandID.A, CommandID.L, },
                               },

                // C0: RET Flag_NZ, nn,
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { CommandID.Flag_NZ, CommandID.Address, },
                               },

                // C1: POP BC,
                new OpcodeData { Name = "POP",
                                 Function = Operation.POP,
                                 new Param[] { CommandID.BC, },
                               },

                // C2: JP Flag_NZ, nn,
                new OpcodeData { Name = "JP",
                                 Function = Operation.JMP,
                                 new Param[] { CommandID.Flag_NZ, CommandID.Address, },
                               },

                // C3: JP nn,
                new OpcodeData { Name = "JP",
                                 Function = Operation.JMP,
                                 new Param[] { CommandID.Address, },
                               },

                // C4: CALL Flag_NZ, nn,
                new OpcodeData { Name = "CALL",
                                 Function = Operation.CALL,
                                 new Param[] { CommandID.Flag_NZ, CommandID.Address, },
                               },

                // C5: PUSH BC,
                new OpcodeData { Name = "PUSH",
                                 Function = Operation.PUSH,
                                 new Param[] { CommandID.BC, },
                               },

                // C6: ADD A, n,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.A, CommandID.ByteData, },
                               },

                // C7: RST 0,
                new OpcodeData { Name = "RST",
                                 Function = Operation.RST,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), },
                               },

                // C8: RET Flag_Z, nn,
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { CommandID.Flag_Z, CommandID.Address, },
                               },

                // C9: RET
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { },
                               },

                // CA: JP Flag_Z, nn,
                new OpcodeData { Name = "JP",
                                 Function = Operation.JMP,
                                 new Param[] { CommandID.Flag_Z, CommandID.Address, },
                               },

                // CB
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CC: CALL Flag_Z, nn,
                new OpcodeData { Name = "CALL",
                                 Function = Operation.CALL,
                                 new Param[] { CommandID.Flag_Z, CommandID.Address, },
                               },

                // CD: CALL nn,
                new OpcodeData { Name = "CALL",
                                 Function = Operation.CALL,
                                 new Param[] { CommandID.Address, },
                               },

                // CE: ADC A, n,
                new OpcodeData { Name = "ADC",
                                 Function = Operation.ADDC,
                                 new Param[] { CommandID.A, CommandID.ByteData, },
                               },

                // CF: RST 8,
                new OpcodeData { Name = "RST",
                                 Function = Operation.RST,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 08), },
                               },

                // D0: RET Flag_NC, nn,
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { CommandID.Flag_NC, CommandID.Address, },
                               },

                // D1: POP DE,
                new OpcodeData { Name = "POP",
                                 Function = Operation.POP,
                                 new Param[] { CommandID.DE, },
                               },

                // D2: JP Flag_NC, nn,
                new OpcodeData { Name = "JP",
                                 Function = Operation.JMP,
                                 new Param[] { CommandID.Flag_NC, CommandID.Address, },
                               },

                // D3: OUT n, A,
                new OpcodeData { Name = "OUT",
                                 Function = Operation.OUT,
                                 new Param[] { CommandID.ByteData, CommandID.A, },
                               },

                // D4: CALL Flag_NC, nn,
                new OpcodeData { Name = "CALL",
                                 Function = Operation.CALL,
                                 new Param[] { CommandID.Flag_NC, CommandID.Address, },
                               },

                // D5: PUSH DE,
                new OpcodeData { Name = "PUSH",
                                 Function = Operation.PUSH,
                                 new Param[] { CommandID.DE, },
                               },

                // D6: SUB A, n,
                new OpcodeData { Name = "SUB",
                                 Function = Operation.SUB,
                                 new Param[] { CommandID.A, CommandID.ByteData, },
                               },

                // D7: RST 10,
                new OpcodeData { Name = "RST",
                                 Function = Operation.RST,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 10), },
                               },

                // D8: RET Flag_CY, nn,
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { CommandID.Flag_CY, CommandID.Address, },
                               },

                // D9: EXX
                new OpcodeData { Name = "EXX",
                                 Function = Operation.EXX,
                                 new Param[] { },
                               },

                // DA: JP Flag_CY, nn,
                new OpcodeData { Name = "JP",
                                 Function = Operation.JMP,
                                 new Param[] { CommandID.Flag_CY, CommandID.Address, },
                               },

                // DB: IN A, n,
                new OpcodeData { Name = "IN",
                                 Function = Operation.IN,
                                 new Param[] { CommandID.A, CommandID.ByteData, },
                               },

                // DC: CALL Flag_CY, nn,
                new OpcodeData { Name = "CALL",
                                 Function = Operation.CALL,
                                 new Param[] { CommandID.Flag_CY, CommandID.Address, },
                               },

                // DD
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // DE: SBC A, n,
                new OpcodeData { Name = "SBC",
                                 Function = Operation.SUBC,
                                 new Param[] { CommandID.A, CommandID.ByteData, },
                               },

                // DF: RST 18,
                new OpcodeData { Name = "RST",
                                 Function = Operation.RST,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 18), },
                               },

                // E0: RET Flag_PO, nn,
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { CommandID.Flag_PO, CommandID.Address, },
                               },

                // E1: POP HL,
                new OpcodeData { Name = "POP",
                                 Function = Operation.POP,
                                 new Param[] { CommandID.HL, },
                               },

                // E2: JP Flag_PO, nn,
                new OpcodeData { Name = "JP",
                                 Function = Operation.JMP,
                                 new Param[] { CommandID.Flag_PO, CommandID.Address, },
                               },

                // E3: EX (SP), HL,
                new OpcodeData { Name = "EX",
                                 Function = Operation.EX,
                                 new Param[] { CommandID.SP_Pointer, CommandID.HL, },
                               },

                // E4: EX (SP), IX,
                new OpcodeData { Name = "EX",
                                 Function = Operation.EX,
                                 new Param[] { CommandID.SP_Pointer, CommandID.IX, },
                               },

                // E5: EX (SP), IY,
                new OpcodeData { Name = "EX",
                                 Function = Operation.EX,
                                 new Param[] { CommandID.SP_Pointer, CommandID.IY, },
                               },

                // E6: AND A, n,
                new OpcodeData { Name = "AND",
                                 Function = Operation.AND,
                                 new Param[] { CommandID.A, CommandID.ByteData, },
                               },

                // E7: RST 20,
                new OpcodeData { Name = "RST",
                                 Function = Operation.RST,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 20), },
                               },

                // E8: RET Flag_PE, nn,
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { CommandID.Flag_PE, CommandID.Address, },
                               },

                // E9: JP HL,
                new OpcodeData { Name = "JP",
                                 Function = Operation.JMP,
                                 new Param[] { CommandID.HL, },
                               },

                // EA: JP IX,
                new OpcodeData { Name = "JP",
                                 Function = Operation.JMP,
                                 new Param[] { CommandID.IX, },
                               },

                // EB: EX DE, HL,
                new OpcodeData { Name = "EX",
                                 Function = Operation.EX,
                                 new Param[] { CommandID.DE, CommandID.HL, },
                               },

                // EC: CALL Flag_PE, nn,
                new OpcodeData { Name = "CALL",
                                 Function = Operation.CALL,
                                 new Param[] { CommandID.Flag_PE, CommandID.Address, },
                               },

                // ED
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // EE: XOR A, n,
                new OpcodeData { Name = "XOR",
                                 Function = Operation.XOR,
                                 new Param[] { CommandID.A, CommandID.ByteData, },
                               },

                // EF: RST 28,
                new OpcodeData { Name = "RST",
                                 Function = Operation.RST,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 28), },
                               },

                // F0: RET Flag_P, nn,
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { CommandID.Flag_P, CommandID.Address, },
                               },

                // F1: POP AF,
                new OpcodeData { Name = "POP",
                                 Function = Operation.POP,
                                 new Param[] { CommandID.AF, },
                               },

                // F2: JP Flag_P, nn,
                new OpcodeData { Name = "JP",
                                 Function = Operation.JMP,
                                 new Param[] { CommandID.Flag_P, CommandID.Address, },
                               },

                // F3: DI
                new OpcodeData { Name = "DI",
                                 Function = Operation.DI,
                                 new Param[] { },
                               },

                // F4: CALL Flag_P, nn,
                new OpcodeData { Name = "CALL",
                                 Function = Operation.CALL,
                                 new Param[] { CommandID.Flag_P, CommandID.Address, },
                               },

                // F5: PUSH AF,
                new OpcodeData { Name = "PUSH",
                                 Function = Operation.PUSH,
                                 new Param[] { CommandID.AF, },
                               },

                // F6: OR A, n,
                new OpcodeData { Name = "OR",
                                 Function = Operation.OR,
                                 new Param[] { CommandID.A, CommandID.ByteData, },
                               },

                // F7: RST 30,
                new OpcodeData { Name = "RST",
                                 Function = Operation.RST,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 30), },
                               },

                // F8: RET Flag_M, nn,
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { CommandID.Flag_M, CommandID.Address, },
                               },

                // F9: LD SP, HL,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.SP, CommandID.HL, },
                               },

                // FA: LD SP, IX,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.SP, CommandID.IX, },
                               },

                // FB: EI
                new OpcodeData { Name = "EI",
                                 Function = Operation.EI,
                                 new Param[] { },
                               },

                // FC: CALL Flag_M, nn,
                new OpcodeData { Name = "CALL",
                                 Function = Operation.CALL,
                                 new Param[] { CommandID.Flag_M, CommandID.Address, },
                               },

                // FD
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // FE: CP A, n,
                new OpcodeData { Name = "CP",
                                 Function = Operation.CMP,
                                 new Param[] { CommandID.A, CommandID.ByteData, },
                               },

                // FF: RST 38,
                new OpcodeData { Name = "RST",
                                 Function = Operation.RST,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 38), },
                               },

            },

            {
                // CB00: SET 7, IXL,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IXL, },
                               },

                // CB01: SET 7, IYL,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IYL, },
                               },

                // CB02: RLC D,
                new OpcodeData { Name = "RLC",
                                 Function = Operation.RL_CY,
                                 new Param[] { CommandID.D, },
                               },

                // CB03: SET 7, A,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.A, },
                               },

                // CB04: RLC H,
                new OpcodeData { Name = "RLC",
                                 Function = Operation.RL_CY,
                                 new Param[] { CommandID.H, },
                               },

                // CB05: RLC IXH,
                new OpcodeData { Name = "RLC",
                                 Function = Operation.RL_CY,
                                 new Param[] { CommandID.IXH, },
                               },

                // CB06: RLC (HL),
                new OpcodeData { Name = "RLC",
                                 Function = Operation.RL_CY,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // CB07: RLC L,
                new OpcodeData { Name = "RLC",
                                 Function = Operation.RL_CY,
                                 new Param[] { CommandID.L, },
                               },

                // CB08: RRC B,
                new OpcodeData { Name = "RRC",
                                 Function = Operation.RR_CY,
                                 new Param[] { CommandID.B, },
                               },

                // CB09: RRC C,
                new OpcodeData { Name = "RRC",
                                 Function = Operation.RR_CY,
                                 new Param[] { CommandID.C, },
                               },

                // CB0A: RRC D,
                new OpcodeData { Name = "RRC",
                                 Function = Operation.RR_CY,
                                 new Param[] { CommandID.D, },
                               },

                // CB0B: RRC E,
                new OpcodeData { Name = "RRC",
                                 Function = Operation.RR_CY,
                                 new Param[] { CommandID.E, },
                               },

                // CB0C: RRC H,
                new OpcodeData { Name = "RRC",
                                 Function = Operation.RR_CY,
                                 new Param[] { CommandID.H, },
                               },

                // CB0D: RRC IXH,
                new OpcodeData { Name = "RRC",
                                 Function = Operation.RR_CY,
                                 new Param[] { CommandID.IXH, },
                               },

                // CB0E: RRC (HL),
                new OpcodeData { Name = "RRC",
                                 Function = Operation.RR_CY,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // CB0F: RRC L,
                new OpcodeData { Name = "RRC",
                                 Function = Operation.RR_CY,
                                 new Param[] { CommandID.L, },
                               },

                // CB10: RL B,
                new OpcodeData { Name = "RL",
                                 Function = Operation.RL,
                                 new Param[] { CommandID.B, },
                               },

                // CB11: RL C,
                new OpcodeData { Name = "RL",
                                 Function = Operation.RL,
                                 new Param[] { CommandID.C, },
                               },

                // CB12: RL D,
                new OpcodeData { Name = "RL",
                                 Function = Operation.RL,
                                 new Param[] { CommandID.D, },
                               },

                // CB13: RL E,
                new OpcodeData { Name = "RL",
                                 Function = Operation.RL,
                                 new Param[] { CommandID.E, },
                               },

                // CB14: RL H,
                new OpcodeData { Name = "RL",
                                 Function = Operation.RL,
                                 new Param[] { CommandID.H, },
                               },

                // CB15: RL IXH,
                new OpcodeData { Name = "RL",
                                 Function = Operation.RL,
                                 new Param[] { CommandID.IXH, },
                               },

                // CB16: RL (HL),
                new OpcodeData { Name = "RL",
                                 Function = Operation.RL,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // CB17: RL L,
                new OpcodeData { Name = "RL",
                                 Function = Operation.RL,
                                 new Param[] { CommandID.L, },
                               },

                // CB18: RR B,
                new OpcodeData { Name = "RR",
                                 Function = Operation.RR,
                                 new Param[] { CommandID.B, },
                               },

                // CB19: RR C,
                new OpcodeData { Name = "RR",
                                 Function = Operation.RR,
                                 new Param[] { CommandID.C, },
                               },

                // CB1A: RR D,
                new OpcodeData { Name = "RR",
                                 Function = Operation.RR,
                                 new Param[] { CommandID.D, },
                               },

                // CB1B: RR E,
                new OpcodeData { Name = "RR",
                                 Function = Operation.RR,
                                 new Param[] { CommandID.E, },
                               },

                // CB1C: RR H,
                new OpcodeData { Name = "RR",
                                 Function = Operation.RR,
                                 new Param[] { CommandID.H, },
                               },

                // CB1D: RR IXH,
                new OpcodeData { Name = "RR",
                                 Function = Operation.RR,
                                 new Param[] { CommandID.IXH, },
                               },

                // CB1E: RR (HL),
                new OpcodeData { Name = "RR",
                                 Function = Operation.RR,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // CB1F: RR L,
                new OpcodeData { Name = "RR",
                                 Function = Operation.RR,
                                 new Param[] { CommandID.L, },
                               },

                // CB20: SLA B,
                new OpcodeData { Name = "SLA",
                                 Function = Operation.SL_Signed,
                                 new Param[] { CommandID.B, },
                               },

                // CB21: SLA C,
                new OpcodeData { Name = "SLA",
                                 Function = Operation.SL_Signed,
                                 new Param[] { CommandID.C, },
                               },

                // CB22: SLA D,
                new OpcodeData { Name = "SLA",
                                 Function = Operation.SL_Signed,
                                 new Param[] { CommandID.D, },
                               },

                // CB23: SLA E,
                new OpcodeData { Name = "SLA",
                                 Function = Operation.SL_Signed,
                                 new Param[] { CommandID.E, },
                               },

                // CB24: SLA H,
                new OpcodeData { Name = "SLA",
                                 Function = Operation.SL_Signed,
                                 new Param[] { CommandID.H, },
                               },

                // CB25: SLA IXH,
                new OpcodeData { Name = "SLA",
                                 Function = Operation.SL_Signed,
                                 new Param[] { CommandID.IXH, },
                               },

                // CB26: SLA (HL),
                new OpcodeData { Name = "SLA",
                                 Function = Operation.SL_Signed,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // CB27: SLA L,
                new OpcodeData { Name = "SLA",
                                 Function = Operation.SL_Signed,
                                 new Param[] { CommandID.L, },
                               },

                // CB28: SRA B,
                new OpcodeData { Name = "SRA",
                                 Function = Operation.SR_Signed,
                                 new Param[] { CommandID.B, },
                               },

                // CB29: SRA C,
                new OpcodeData { Name = "SRA",
                                 Function = Operation.SR_Signed,
                                 new Param[] { CommandID.C, },
                               },

                // CB2A: SRA D,
                new OpcodeData { Name = "SRA",
                                 Function = Operation.SR_Signed,
                                 new Param[] { CommandID.D, },
                               },

                // CB2B: SRA E,
                new OpcodeData { Name = "SRA",
                                 Function = Operation.SR_Signed,
                                 new Param[] { CommandID.E, },
                               },

                // CB2C: SRA H,
                new OpcodeData { Name = "SRA",
                                 Function = Operation.SR_Signed,
                                 new Param[] { CommandID.H, },
                               },

                // CB2D: SRA IXH,
                new OpcodeData { Name = "SRA",
                                 Function = Operation.SR_Signed,
                                 new Param[] { CommandID.IXH, },
                               },

                // CB2E: SRA (HL),
                new OpcodeData { Name = "SRA",
                                 Function = Operation.SR_Signed,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // CB2F: SRA L,
                new OpcodeData { Name = "SRA",
                                 Function = Operation.SR_Signed,
                                 new Param[] { CommandID.L, },
                               },

                // CB30: SLL B,
                new OpcodeData { Name = "SLL",
                                 Function = Operation.SL_L,
                                 new Param[] { CommandID.B, },
                               },

                // CB31: SLL C,
                new OpcodeData { Name = "SLL",
                                 Function = Operation.SL_L,
                                 new Param[] { CommandID.C, },
                               },

                // CB32: SLL D,
                new OpcodeData { Name = "SLL",
                                 Function = Operation.SL_L,
                                 new Param[] { CommandID.D, },
                               },

                // CB33: SLL E,
                new OpcodeData { Name = "SLL",
                                 Function = Operation.SL_L,
                                 new Param[] { CommandID.E, },
                               },

                // CB34: SLL H,
                new OpcodeData { Name = "SLL",
                                 Function = Operation.SL_L,
                                 new Param[] { CommandID.H, },
                               },

                // CB35: SLL IXH,
                new OpcodeData { Name = "SLL",
                                 Function = Operation.SL_L,
                                 new Param[] { CommandID.IXH, },
                               },

                // CB36: SLL (HL),
                new OpcodeData { Name = "SLL",
                                 Function = Operation.SL_L,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // CB37: SLL L,
                new OpcodeData { Name = "SLL",
                                 Function = Operation.SL_L,
                                 new Param[] { CommandID.L, },
                               },

                // CB38: SRL B,
                new OpcodeData { Name = "SRL",
                                 Function = Operation.SR_L,
                                 new Param[] { CommandID.B, },
                               },

                // CB39: SRL C,
                new OpcodeData { Name = "SRL",
                                 Function = Operation.SR_L,
                                 new Param[] { CommandID.C, },
                               },

                // CB3A: SRL D,
                new OpcodeData { Name = "SRL",
                                 Function = Operation.SR_L,
                                 new Param[] { CommandID.D, },
                               },

                // CB3B: SRL E,
                new OpcodeData { Name = "SRL",
                                 Function = Operation.SR_L,
                                 new Param[] { CommandID.E, },
                               },

                // CB3C: SRL H,
                new OpcodeData { Name = "SRL",
                                 Function = Operation.SR_L,
                                 new Param[] { CommandID.H, },
                               },

                // CB3D: SRL IXH,
                new OpcodeData { Name = "SRL",
                                 Function = Operation.SR_L,
                                 new Param[] { CommandID.IXH, },
                               },

                // CB3E: SRL (HL),
                new OpcodeData { Name = "SRL",
                                 Function = Operation.SR_L,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // CB3F: SRL L,
                new OpcodeData { Name = "SRL",
                                 Function = Operation.SR_L,
                                 new Param[] { CommandID.L, },
                               },

                // CB40: BIT 0, B,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.B, },
                               },

                // CB41: BIT 0, C,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.C, },
                               },

                // CB42: BIT 0, D,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.D, },
                               },

                // CB43: BIT 0, E,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.E, },
                               },

                // CB44: BIT 0, H,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.H, },
                               },

                // CB45: BIT 0, IXH,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IXH, },
                               },

                // CB46: BIT 0, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.HL_Pointer, },
                               },

                // CB47: BIT 0, L,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.L, },
                               },

                // CB48: BIT 1, B,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.B, },
                               },

                // CB49: BIT 1, C,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.C, },
                               },

                // CB4A: BIT 1, D,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.D, },
                               },

                // CB4B: BIT 1, E,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.E, },
                               },

                // CB4C: BIT 1, H,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.H, },
                               },

                // CB4D: BIT 1, IXH,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IXH, },
                               },

                // CB4E: BIT 1, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.HL_Pointer, },
                               },

                // CB4F: BIT 1, L,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.L, },
                               },

                // CB50: BIT 2, B,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.B, },
                               },

                // CB51: BIT 2, C,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.C, },
                               },

                // CB52: BIT 2, D,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.D, },
                               },

                // CB53: BIT 2, E,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.E, },
                               },

                // CB54: BIT 2, H,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.H, },
                               },

                // CB55: BIT 2, IXH,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IXH, },
                               },

                // CB56: BIT 2, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.HL_Pointer, },
                               },

                // CB57: BIT 2, L,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.L, },
                               },

                // CB58: BIT 3, B,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.B, },
                               },

                // CB59: BIT 3, C,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.C, },
                               },

                // CB5A: BIT 3, D,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.D, },
                               },

                // CB5B: BIT 3, E,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.E, },
                               },

                // CB5C: BIT 3, H,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.H, },
                               },

                // CB5D: BIT 3, IXH,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IXH, },
                               },

                // CB5E: BIT 3, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.HL_Pointer, },
                               },

                // CB5F: BIT 3, L,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.L, },
                               },

                // CB60: BIT 4, B,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.B, },
                               },

                // CB61: BIT 4, C,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.C, },
                               },

                // CB62: BIT 4, D,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.D, },
                               },

                // CB63: BIT 4, E,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.E, },
                               },

                // CB64: BIT 4, H,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.H, },
                               },

                // CB65: BIT 4, IXH,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IXH, },
                               },

                // CB66: BIT 4, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.HL_Pointer, },
                               },

                // CB67: BIT 4, L,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.L, },
                               },

                // CB68: BIT 5, B,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.B, },
                               },

                // CB69: BIT 5, C,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.C, },
                               },

                // CB6A: BIT 5, D,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.D, },
                               },

                // CB6B: BIT 5, E,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.E, },
                               },

                // CB6C: BIT 5, H,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.H, },
                               },

                // CB6D: BIT 5, IXH,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IXH, },
                               },

                // CB6E: BIT 5, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.HL_Pointer, },
                               },

                // CB6F: BIT 5, L,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.L, },
                               },

                // CB70: BIT 6, B,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.B, },
                               },

                // CB71: BIT 6, C,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.C, },
                               },

                // CB72: BIT 6, D,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.D, },
                               },

                // CB73: BIT 6, E,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.E, },
                               },

                // CB74: BIT 6, H,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.H, },
                               },

                // CB75: BIT 6, IXH,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IXH, },
                               },

                // CB76: BIT 6, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.HL_Pointer, },
                               },

                // CB77: BIT 6, L,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.L, },
                               },

                // CB78: BIT 7, B,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.B, },
                               },

                // CB79: BIT 7, C,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.C, },
                               },

                // CB7A: BIT 7, D,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.D, },
                               },

                // CB7B: BIT 7, E,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.E, },
                               },

                // CB7C: BIT 7, H,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.H, },
                               },

                // CB7D: BIT 7, IXH,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IXH, },
                               },

                // CB7E: BIT 7, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.HL_Pointer, },
                               },

                // CB7F: BIT 7, L,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.L, },
                               },

                // CB80: RES 0, B,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.B, },
                               },

                // CB81: RES 0, C,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.C, },
                               },

                // CB82: RES 0, D,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.D, },
                               },

                // CB83: RES 0, E,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.E, },
                               },

                // CB84: RES 0, H,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.H, },
                               },

                // CB85: RES 0, IXH,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IXH, },
                               },

                // CB86: RES 0, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.HL_Pointer, },
                               },

                // CB87: RES 0, L,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.L, },
                               },

                // CB88: RES 1, B,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.B, },
                               },

                // CB89: RES 1, C,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.C, },
                               },

                // CB8A: RES 1, D,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.D, },
                               },

                // CB8B: RES 1, E,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.E, },
                               },

                // CB8C: RES 1, H,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.H, },
                               },

                // CB8D: RES 1, IXH,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IXH, },
                               },

                // CB8E: RES 1, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.HL_Pointer, },
                               },

                // CB8F: RES 1, L,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.L, },
                               },

                // CB90: RES 2, B,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.B, },
                               },

                // CB91: RES 2, C,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.C, },
                               },

                // CB92: RES 2, D,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.D, },
                               },

                // CB93: RES 2, E,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.E, },
                               },

                // CB94: RES 2, H,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.H, },
                               },

                // CB95: RES 2, IXH,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IXH, },
                               },

                // CB96: RES 2, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.HL_Pointer, },
                               },

                // CB97: RES 2, L,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.L, },
                               },

                // CB98: RES 3, B,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.B, },
                               },

                // CB99: RES 3, C,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.C, },
                               },

                // CB9A: RES 3, D,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.D, },
                               },

                // CB9B: RES 3, E,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.E, },
                               },

                // CB9C: RES 3, H,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.H, },
                               },

                // CB9D: RES 3, IXH,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IXH, },
                               },

                // CB9E: RES 3, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.HL_Pointer, },
                               },

                // CB9F: RES 3, L,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.L, },
                               },

                // CBA0: RES 4, B,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.B, },
                               },

                // CBA1: RES 4, C,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.C, },
                               },

                // CBA2: RES 4, D,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.D, },
                               },

                // CBA3: RES 4, E,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.E, },
                               },

                // CBA4: RES 4, H,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.H, },
                               },

                // CBA5: RES 4, IXH,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IXH, },
                               },

                // CBA6: RES 4, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.HL_Pointer, },
                               },

                // CBA7: RES 4, L,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.L, },
                               },

                // CBA8: RES 5, B,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.B, },
                               },

                // CBA9: RES 5, C,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.C, },
                               },

                // CBAA: RES 5, D,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.D, },
                               },

                // CBAB: RES 5, E,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.E, },
                               },

                // CBAC: RES 5, H,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.H, },
                               },

                // CBAD: RES 5, IXH,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IXH, },
                               },

                // CBAE: RES 5, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.HL_Pointer, },
                               },

                // CBAF: RES 5, L,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.L, },
                               },

                // CBB0: RES 6, B,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.B, },
                               },

                // CBB1: RES 6, C,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.C, },
                               },

                // CBB2: RES 6, D,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.D, },
                               },

                // CBB3: RES 6, E,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.E, },
                               },

                // CBB4: RES 6, H,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.H, },
                               },

                // CBB5: RES 6, IXH,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IXH, },
                               },

                // CBB6: RES 6, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.HL_Pointer, },
                               },

                // CBB7: RES 6, L,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.L, },
                               },

                // CBB8: RES 7, B,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.B, },
                               },

                // CBB9: RES 7, C,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.C, },
                               },

                // CBBA: RES 7, D,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.D, },
                               },

                // CBBB: RES 7, E,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.E, },
                               },

                // CBBC: RES 7, H,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.H, },
                               },

                // CBBD: RES 7, IXH,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IXH, },
                               },

                // CBBE: RES 7, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.HL_Pointer, },
                               },

                // CBBF: RES 7, L,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.L, },
                               },

                // CBC0: SET 0, B,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.B, },
                               },

                // CBC1: SET 0, C,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.C, },
                               },

                // CBC2: SET 0, D,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.D, },
                               },

                // CBC3: SET 0, E,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.E, },
                               },

                // CBC4: SET 0, H,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.H, },
                               },

                // CBC5: SET 0, IXH,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IXH, },
                               },

                // CBC6: SET 0, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.HL_Pointer, },
                               },

                // CBC7: SET 0, L,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.L, },
                               },

                // CBC8: SET 1, B,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.B, },
                               },

                // CBC9: SET 1, C,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.C, },
                               },

                // CBCA: SET 1, D,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.D, },
                               },

                // CBCB: SET 1, E,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.E, },
                               },

                // CBCC: SET 1, H,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.H, },
                               },

                // CBCD: SET 1, IXH,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IXH, },
                               },

                // CBCE: SET 1, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.HL_Pointer, },
                               },

                // CBCF: SET 1, L,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.L, },
                               },

                // CBD0: SET 2, B,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.B, },
                               },

                // CBD1: SET 2, C,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.C, },
                               },

                // CBD2: SET 2, D,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.D, },
                               },

                // CBD3: SET 2, E,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.E, },
                               },

                // CBD4: SET 2, H,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.H, },
                               },

                // CBD5: SET 2, IXH,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IXH, },
                               },

                // CBD6: SET 2, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.HL_Pointer, },
                               },

                // CBD7: SET 2, L,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.L, },
                               },

                // CBD8: SET 3, B,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.B, },
                               },

                // CBD9: SET 3, C,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.C, },
                               },

                // CBDA: SET 3, D,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.D, },
                               },

                // CBDB: SET 3, E,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.E, },
                               },

                // CBDC: SET 3, H,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.H, },
                               },

                // CBDD: SET 3, IXH,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IXH, },
                               },

                // CBDE: SET 3, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.HL_Pointer, },
                               },

                // CBDF: SET 3, L,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.L, },
                               },

                // CBE0: SET 4, B,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.B, },
                               },

                // CBE1: SET 4, C,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.C, },
                               },

                // CBE2: SET 4, D,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.D, },
                               },

                // CBE3: SET 4, E,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.E, },
                               },

                // CBE4: SET 4, H,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.H, },
                               },

                // CBE5: SET 4, IXH,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IXH, },
                               },

                // CBE6: SET 4, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.HL_Pointer, },
                               },

                // CBE7: SET 4, L,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.L, },
                               },

                // CBE8: SET 5, B,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.B, },
                               },

                // CBE9: SET 5, C,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.C, },
                               },

                // CBEA: SET 5, D,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.D, },
                               },

                // CBEB: SET 5, E,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.E, },
                               },

                // CBEC: SET 5, H,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.H, },
                               },

                // CBED: SET 5, IXH,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IXH, },
                               },

                // CBEE: SET 5, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.HL_Pointer, },
                               },

                // CBEF: SET 5, L,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.L, },
                               },

                // CBF0: SET 6, B,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.B, },
                               },

                // CBF1: SET 6, C,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.C, },
                               },

                // CBF2: SET 6, D,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.D, },
                               },

                // CBF3: SET 6, E,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.E, },
                               },

                // CBF4: SET 6, H,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.H, },
                               },

                // CBF5: SET 6, IXH,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IXH, },
                               },

                // CBF6: SET 6, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.HL_Pointer, },
                               },

                // CBF7: SET 6, L,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.L, },
                               },

                // CBF8: SET 7, B,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.B, },
                               },

                // CBF9: SET 7, C,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.C, },
                               },

                // CBFA: SET 7, D,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.D, },
                               },

                // CBFB: SET 7, E,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.E, },
                               },

                // CBFC: SET 7, H,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.H, },
                               },

                // CBFD: SET 7, IXH,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IXH, },
                               },

                // CBFE: SET 7, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.HL_Pointer, },
                               },

                // CBFF: SET 7, L,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.L, },
                               },

            },

            {
                // 00
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 01
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 02
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 03
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 04
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 05
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 06
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 07
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 08
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 09
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 0A
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 0B
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 0C
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 0D
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 0E
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 0F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 10
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 11
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 12
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 13
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 14
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 15
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 16
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 17
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 18
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 19
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 1A
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 1B
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 1C
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 1D
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 1E
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 1F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 20
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 21
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 22
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 23
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 24
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 25
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 26
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 27
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 28
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 29
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 2A
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 2B
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 2C
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 2D
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 2E
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 2F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 30
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 31
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 32
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 33
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 34
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 35
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 36
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 37
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 38
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 39
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 3A
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 3B
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 3C
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 3D
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 3E
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 3F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // ED40: IN B, C,
                new OpcodeData { Name = "IN",
                                 Function = Operation.IN,
                                 new Param[] { CommandID.B, CommandID.C, },
                               },

                // ED41: OUT C, B,
                new OpcodeData { Name = "OUT",
                                 Function = Operation.OUT,
                                 new Param[] { CommandID.C, CommandID.B, },
                               },

                // ED42: SBC HL, BC,
                new OpcodeData { Name = "SBC",
                                 Function = Operation.SUBC,
                                 new Param[] { CommandID.HL, CommandID.BC, },
                               },

                // ED43: LD (**), BC,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.Address_Pointer, CommandID.BC, },
                               },

                // ED44: NEG A,
                new OpcodeData { Name = "NEG",
                                 Function = Operation.NEG,
                                 new Param[] { CommandID.A, },
                               },

                // ED45: RETN
                new OpcodeData { Name = "RETN",
                                 Function = Operation.RETN,
                                 new Param[] { },
                               },

                // ED46: IM 0,
                new OpcodeData { Name = "IM",
                                 Function = Operation.IM,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), },
                               },

                // ED47: LD I, A,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.I, CommandID.A, },
                               },

                // ED48: IN C, C,
                new OpcodeData { Name = "IN",
                                 Function = Operation.IN,
                                 new Param[] { CommandID.C, CommandID.C, },
                               },

                // ED49: OUT C, C,
                new OpcodeData { Name = "OUT",
                                 Function = Operation.OUT,
                                 new Param[] { CommandID.C, CommandID.C, },
                               },

                // ED4A: ADC HL, BC,
                new OpcodeData { Name = "ADC",
                                 Function = Operation.ADDC,
                                 new Param[] { CommandID.HL, CommandID.BC, },
                               },

                // ED4B: LD BC, (**),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.BC, CommandID.Address_Pointer, },
                               },

                // ED4C: NEG A,
                new OpcodeData { Name = "NEG",
                                 Function = Operation.NEG,
                                 new Param[] { CommandID.A, },
                               },

                // ED4D: RETI
                new OpcodeData { Name = "RETI",
                                 Function = Operation.RETI,
                                 new Param[] { },
                               },

                // ED4E: IM 0,
                new OpcodeData { Name = "IM",
                                 Function = Operation.IM,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), },
                               },

                // ED4F: LD R, A,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.R, CommandID.A, },
                               },

                // ED50: IN D, C,
                new OpcodeData { Name = "IN",
                                 Function = Operation.IN,
                                 new Param[] { CommandID.D, CommandID.C, },
                               },

                // ED51: OUT C, D,
                new OpcodeData { Name = "OUT",
                                 Function = Operation.OUT,
                                 new Param[] { CommandID.C, CommandID.D, },
                               },

                // ED52: SBC HL, DE,
                new OpcodeData { Name = "SBC",
                                 Function = Operation.SUBC,
                                 new Param[] { CommandID.HL, CommandID.DE, },
                               },

                // ED53: LD (**), DE,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.Address_Pointer, CommandID.DE, },
                               },

                // ED54: NEG A,
                new OpcodeData { Name = "NEG",
                                 Function = Operation.NEG,
                                 new Param[] { CommandID.A, },
                               },

                // ED55: RETN
                new OpcodeData { Name = "RETN",
                                 Function = Operation.RETN,
                                 new Param[] { },
                               },

                // ED56: IM 1,
                new OpcodeData { Name = "IM",
                                 Function = Operation.IM,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), },
                               },

                // ED57: LD A, I,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.A, CommandID.I, },
                               },

                // ED58: IN E, C,
                new OpcodeData { Name = "IN",
                                 Function = Operation.IN,
                                 new Param[] { CommandID.E, CommandID.C, },
                               },

                // ED59: OUT C, E,
                new OpcodeData { Name = "OUT",
                                 Function = Operation.OUT,
                                 new Param[] { CommandID.C, CommandID.E, },
                               },

                // ED5A: ADC HL, DE,
                new OpcodeData { Name = "ADC",
                                 Function = Operation.ADDC,
                                 new Param[] { CommandID.HL, CommandID.DE, },
                               },

                // ED5B: LD DE, (**),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.DE, CommandID.Address_Pointer, },
                               },

                // ED5C: NEG A,
                new OpcodeData { Name = "NEG",
                                 Function = Operation.NEG,
                                 new Param[] { CommandID.A, },
                               },

                // ED5D: RETN
                new OpcodeData { Name = "RETN",
                                 Function = Operation.RETN,
                                 new Param[] { },
                               },

                // ED5E: IM 2,
                new OpcodeData { Name = "IM",
                                 Function = Operation.IM,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), },
                               },

                // ED5F: LD A, R,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.A, CommandID.R, },
                               },

                // ED60: IN H, C,
                new OpcodeData { Name = "IN",
                                 Function = Operation.IN,
                                 new Param[] { CommandID.H, CommandID.C, },
                               },

                // ED61: OUT C, H,
                new OpcodeData { Name = "OUT",
                                 Function = Operation.OUT,
                                 new Param[] { CommandID.C, CommandID.H, },
                               },

                // ED62: SBC HL, HL,
                new OpcodeData { Name = "SBC",
                                 Function = Operation.SUBC,
                                 new Param[] { CommandID.HL, CommandID.HL, },
                               },

                // ED63: LD (**), HL,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.Address_Pointer, CommandID.HL, },
                               },

                // ED64: NEG A,
                new OpcodeData { Name = "NEG",
                                 Function = Operation.NEG,
                                 new Param[] { CommandID.A, },
                               },

                // ED65: RETN
                new OpcodeData { Name = "RETN",
                                 Function = Operation.RETN,
                                 new Param[] { },
                               },

                // ED66: IM 0,
                new OpcodeData { Name = "IM",
                                 Function = Operation.IM,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), },
                               },

                // ED67: RRD
                new OpcodeData { Name = "RRD",
                                 Function = Operation.ROLL_R,
                                 new Param[] { },
                               },

                // ED68: IN IXH, C,
                new OpcodeData { Name = "IN",
                                 Function = Operation.IN,
                                 new Param[] { CommandID.IXH, CommandID.C, },
                               },

                // ED69: OUT C, IXH,
                new OpcodeData { Name = "OUT",
                                 Function = Operation.OUT,
                                 new Param[] { CommandID.C, CommandID.IXH, },
                               },

                // ED6A: ADC HL, HL,
                new OpcodeData { Name = "ADC",
                                 Function = Operation.ADDC,
                                 new Param[] { CommandID.HL, CommandID.HL, },
                               },

                // ED6B: LD HL, (**),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.HL, CommandID.Address_Pointer, },
                               },

                // ED6C: NEG A,
                new OpcodeData { Name = "NEG",
                                 Function = Operation.NEG,
                                 new Param[] { CommandID.A, },
                               },

                // ED6D: RETN
                new OpcodeData { Name = "RETN",
                                 Function = Operation.RETN,
                                 new Param[] { },
                               },

                // ED6E: IM 0,
                new OpcodeData { Name = "IM",
                                 Function = Operation.IM,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), },
                               },

                // ED6F: RLD
                new OpcodeData { Name = "RLD",
                                 Function = Operation.ROLL_L,
                                 new Param[] { },
                               },

                // ED70: IN C,
                new OpcodeData { Name = "IN",
                                 Function = Operation.IN,
                                 new Param[] { CommandID.C, },
                               },

                // ED71: OUT C, 0,
                new OpcodeData { Name = "OUT",
                                 Function = Operation.OUT,
                                 new Param[] { CommandID.C, (CommandID)((int)CommandID.Encoded + 00), },
                               },

                // ED72: SBC HL, SP,
                new OpcodeData { Name = "SBC",
                                 Function = Operation.SUBC,
                                 new Param[] { CommandID.HL, CommandID.SP, },
                               },

                // ED73: LD (**), SP,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.Address_Pointer, CommandID.SP, },
                               },

                // ED74: NEG A,
                new OpcodeData { Name = "NEG",
                                 Function = Operation.NEG,
                                 new Param[] { CommandID.A, },
                               },

                // ED75: RETN
                new OpcodeData { Name = "RETN",
                                 Function = Operation.RETN,
                                 new Param[] { },
                               },

                // ED76: IM 1,
                new OpcodeData { Name = "IM",
                                 Function = Operation.IM,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), },
                               },

                // 77
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // ED78: IN L, C,
                new OpcodeData { Name = "IN",
                                 Function = Operation.IN,
                                 new Param[] { CommandID.L, CommandID.C, },
                               },

                // ED79: OUT C, L,
                new OpcodeData { Name = "OUT",
                                 Function = Operation.OUT,
                                 new Param[] { CommandID.C, CommandID.L, },
                               },

                // ED7A: ADC HL, SP,
                new OpcodeData { Name = "ADC",
                                 Function = Operation.ADDC,
                                 new Param[] { CommandID.HL, CommandID.SP, },
                               },

                // ED7B: LD SP, (**),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.SP, CommandID.Address_Pointer, },
                               },

                // ED7C: NEG A,
                new OpcodeData { Name = "NEG",
                                 Function = Operation.NEG,
                                 new Param[] { CommandID.A, },
                               },

                // ED7D: RETN
                new OpcodeData { Name = "RETN",
                                 Function = Operation.RETN,
                                 new Param[] { },
                               },

                // ED7E: IM 2,
                new OpcodeData { Name = "IM",
                                 Function = Operation.IM,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), },
                               },

                // 7F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // ED80: IN IXL, C,
                new OpcodeData { Name = "IN",
                                 Function = Operation.IN,
                                 new Param[] { CommandID.IXL, CommandID.C, },
                               },

                // ED81: OUT C, IXL,
                new OpcodeData { Name = "OUT",
                                 Function = Operation.OUT,
                                 new Param[] { CommandID.C, CommandID.IXL, },
                               },

                // 82
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 83
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 84
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 85
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 86
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 87
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // ED88: IN IYL, C,
                new OpcodeData { Name = "IN",
                                 Function = Operation.IN,
                                 new Param[] { CommandID.IYL, CommandID.C, },
                               },

                // ED89: OUT C, IYL,
                new OpcodeData { Name = "OUT",
                                 Function = Operation.OUT,
                                 new Param[] { CommandID.C, CommandID.IYL, },
                               },

                // 8A
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 8B
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 8C
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 8D
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 8E
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 8F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 90
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 91
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 92
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 93
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 94
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 95
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 96
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 97
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // ED98: IN A, C,
                new OpcodeData { Name = "IN",
                                 Function = Operation.IN,
                                 new Param[] { CommandID.A, CommandID.C, },
                               },

                // ED99: OUT C, A,
                new OpcodeData { Name = "OUT",
                                 Function = Operation.OUT,
                                 new Param[] { CommandID.C, CommandID.A, },
                               },

                // 9A
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 9B
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 9C
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 9D
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 9E
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 9F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // EDA0: LDI
                new OpcodeData { Name = "LDI",
                                 Function = Operation.LD_I,
                                 new Param[] { },
                               },

                // EDA1: CPI
                new OpcodeData { Name = "CPI",
                                 Function = Operation.CMP_I,
                                 new Param[] { },
                               },

                // EDA2: INI
                new OpcodeData { Name = "INI",
                                 Function = Operation.IN_I,
                                 new Param[] { },
                               },

                // EDA3: OUTI
                new OpcodeData { Name = "OUTI",
                                 Function = Operation.OUT_I,
                                 new Param[] { },
                               },

                // A4
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // A5
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // A6
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // A7
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // EDA8: LDD
                new OpcodeData { Name = "LDD",
                                 Function = Operation.LD_D,
                                 new Param[] { },
                               },

                // EDA9: CPD
                new OpcodeData { Name = "CPD",
                                 Function = Operation.CMP_D,
                                 new Param[] { },
                               },

                // EDAA: IND
                new OpcodeData { Name = "IND",
                                 Function = Operation.IN_D,
                                 new Param[] { },
                               },

                // EDAB: OUTD
                new OpcodeData { Name = "OUTD",
                                 Function = Operation.OUT_D,
                                 new Param[] { },
                               },

                // AC
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // AD
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // AE
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // AF
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // EDB0: LDIR
                new OpcodeData { Name = "LDIR",
                                 Function = Operation.LD_IR,
                                 new Param[] { },
                               },

                // EDB1: CPIR
                new OpcodeData { Name = "CPIR",
                                 Function = Operation.CMP_IR,
                                 new Param[] { },
                               },

                // EDB2: INIR
                new OpcodeData { Name = "INIR",
                                 Function = Operation.IN_IR,
                                 new Param[] { },
                               },

                // EDB3: OTIR
                new OpcodeData { Name = "OTIR",
                                 Function = Operation.OUT_IR,
                                 new Param[] { },
                               },

                // B4
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // B5
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // B6
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // B7
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // EDB8: LDDR
                new OpcodeData { Name = "LDDR",
                                 Function = Operation.LD_DR,
                                 new Param[] { },
                               },

                // EDB9: CPDR
                new OpcodeData { Name = "CPDR",
                                 Function = Operation.CMP_DR,
                                 new Param[] { },
                               },

                // EDBA: INDR
                new OpcodeData { Name = "INDR",
                                 Function = Operation.IN_DR,
                                 new Param[] { },
                               },

                // EDBB: OTDR
                new OpcodeData { Name = "OTDR",
                                 Function = Operation.OUT_DR,
                                 new Param[] { },
                               },

                // BC
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // BD
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // BE
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // BF
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C0
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C1
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C2
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C3
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C4
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C5
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C6
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C7
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C8
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C9
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CA
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CC
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CD
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CE
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CF
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D0
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D1
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D2
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D3
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D4
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D5
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D6
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D7
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D8
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D9
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // DA
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // DB
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // DC
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // DD
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // DE
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // DF
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E0
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E1
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E2
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E3
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E4
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E5
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E6
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E7
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E8
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E9
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // EA
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // EB
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // EC
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // ED
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // EE
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // EF
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F0
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F1
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F2
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F3
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F4
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F5
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F6
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F7
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F8
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F9
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // FA
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // FB
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // FC
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // FD
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // FE
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // FF
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

            },

            {
                // 00
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 01
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 02
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 03
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 04
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 05
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB06: RLC (HL),
                new OpcodeData { Name = "RLC",
                                 Function = Operation.RL_CY,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // 07
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 08
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 09
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 0A
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 0B
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 0C
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 0D
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB0E: RRC (HL),
                new OpcodeData { Name = "RRC",
                                 Function = Operation.RR_CY,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // 0F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 10
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 11
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 12
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 13
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 14
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 15
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB16: RL (HL),
                new OpcodeData { Name = "RL",
                                 Function = Operation.RL,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // 17
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 18
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 19
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 1A
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 1B
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 1C
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 1D
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB1E: RR (HL),
                new OpcodeData { Name = "RR",
                                 Function = Operation.RR,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // 1F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 20
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 21
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 22
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 23
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 24
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 25
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB26: SLA (HL),
                new OpcodeData { Name = "SLA",
                                 Function = Operation.SL_Signed,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // 27
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 28
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 29
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 2A
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 2B
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 2C
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 2D
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB2E: SRA (HL),
                new OpcodeData { Name = "SRA",
                                 Function = Operation.SR_Signed,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // 2F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 30
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 31
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 32
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 33
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 34
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 35
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB36: SLL (HL),
                new OpcodeData { Name = "SLL",
                                 Function = Operation.SL_L,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // 37
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 38
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 39
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 3A
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 3B
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 3C
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 3D
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB3E: SRL (HL),
                new OpcodeData { Name = "SRL",
                                 Function = Operation.SR_L,
                                 new Param[] { CommandID.HL_Pointer, },
                               },

                // 3F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 40
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 41
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 42
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 43
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 44
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 45
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB46: BIT 0, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.HL_Pointer, },
                               },

                // 47
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 48
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 49
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 4A
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 4B
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 4C
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 4D
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB4E: BIT 1, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.HL_Pointer, },
                               },

                // 4F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 50
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 51
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 52
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 53
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 54
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 55
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB56: BIT 2, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.HL_Pointer, },
                               },

                // 57
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 58
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 59
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 5A
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 5B
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 5C
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 5D
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB5E: BIT 3, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.HL_Pointer, },
                               },

                // 5F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 60
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 61
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 62
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 63
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 64
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 65
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB66: BIT 4, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.HL_Pointer, },
                               },

                // 67
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 68
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 69
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 6A
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 6B
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 6C
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 6D
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB6E: BIT 5, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.HL_Pointer, },
                               },

                // 6F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 70
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 71
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 72
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 73
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 74
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 75
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB76: BIT 6, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.HL_Pointer, },
                               },

                // 77
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 78
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 79
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 7A
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 7B
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 7C
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 7D
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB7E: BIT 7, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.HL_Pointer, },
                               },

                // 7F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 80
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 81
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 82
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 83
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 84
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 85
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB86: RES 0, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.HL_Pointer, },
                               },

                // 87
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 88
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 89
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 8A
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 8B
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 8C
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 8D
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB8E: RES 1, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.HL_Pointer, },
                               },

                // 8F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 90
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 91
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 92
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 93
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 94
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 95
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB96: RES 2, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.HL_Pointer, },
                               },

                // 97
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 98
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 99
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 9A
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 9B
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 9C
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 9D
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB9E: RES 3, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.HL_Pointer, },
                               },

                // 9F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // A0
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // A1
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // A2
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // A3
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // A4
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // A5
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CBA6: RES 4, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.HL_Pointer, },
                               },

                // A7
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // A8
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // A9
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // AA
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // AB
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // AC
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // AD
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CBAE: RES 5, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.HL_Pointer, },
                               },

                // AF
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // B0
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // B1
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // B2
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // B3
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // B4
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // B5
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CBB6: RES 6, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.HL_Pointer, },
                               },

                // B7
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // B8
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // B9
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // BA
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // BB
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // BC
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // BD
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CBBE: RES 7, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.HL_Pointer, },
                               },

                // BF
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C0
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C1
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C2
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C3
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C4
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C5
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CBC6: SET 0, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.HL_Pointer, },
                               },

                // C7
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C8
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // C9
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CA
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CC
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CD
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CBCE: SET 1, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.HL_Pointer, },
                               },

                // CF
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D0
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D1
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D2
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D3
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D4
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D5
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CBD6: SET 2, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.HL_Pointer, },
                               },

                // D7
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D8
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D9
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // DA
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // DB
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // DC
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // DD
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CBDE: SET 3, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.HL_Pointer, },
                               },

                // DF
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E0
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E1
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E2
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E3
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E4
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E5
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CBE6: SET 4, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.HL_Pointer, },
                               },

                // E7
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E8
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E9
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // EA
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // EB
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // EC
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // ED
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CBEE: SET 5, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.HL_Pointer, },
                               },

                // EF
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F0
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F1
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F2
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F3
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F4
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F5
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CBF6: SET 6, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.HL_Pointer, },
                               },

                // F7
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F8
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F9
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // FA
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // FB
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // FC
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // FD
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CBFE: SET 7, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.HL_Pointer, },
                               },

                // FF
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

            },
        };
    }
}
