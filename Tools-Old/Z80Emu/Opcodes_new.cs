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

                // 07: RST 28,
                new OpcodeData { Name = "RST",
                                 Function = Operation.RST,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 28), },
                               },

                // 08: EX AF, AF,
                new OpcodeData { Name = "EX",
                                 Function = Operation.EX,
                                 new Param[] { CommandID.AF, CommandID.AF, },
                               },

                // 09: ADD IY, BC,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.IY, CommandID.BC, },
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

                // 19: ADD IY, DE,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.IY, CommandID.DE, },
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

                // 22: LD (**), IY,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.Address_Pointer, CommandID.IY, },
                               },

                // 23: INC HL,
                new OpcodeData { Name = "INC",
                                 Function = Operation.INC,
                                 new Param[] { CommandID.HL, },
                               },

                // 24: INC IYH,
                new OpcodeData { Name = "INC",
                                 Function = Operation.INC,
                                 new Param[] { CommandID.IYH, },
                               },

                // 25: DEC IYH,
                new OpcodeData { Name = "DEC",
                                 Function = Operation.DEC,
                                 new Param[] { CommandID.IYH, },
                               },

                // 26: LD IYH, n,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IYH, CommandID.ByteData, },
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

                // 29: ADD IY, HL,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.IY, CommandID.HL, },
                               },

                // 2A: LD IY, (**),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IY, CommandID.Address_Pointer, },
                               },

                // 2B: DEC HL,
                new OpcodeData { Name = "DEC",
                                 Function = Operation.DEC,
                                 new Param[] { CommandID.HL, },
                               },

                // 2C: INC IYL,
                new OpcodeData { Name = "INC",
                                 Function = Operation.INC,
                                 new Param[] { CommandID.IYL, },
                               },

                // 2D: DEC IYL,
                new OpcodeData { Name = "DEC",
                                 Function = Operation.DEC,
                                 new Param[] { CommandID.IYL, },
                               },

                // 2E: LD IYL, n,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IYL, CommandID.ByteData, },
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

                // 36: INC (IY + *),
                new OpcodeData { Name = "INC",
                                 Function = Operation.INC,
                                 new Param[] { CommandID.IY_Pointer, },
                               },

                // 37: SCF
                new OpcodeData { Name = "SCF",
                                 Function = Operation.CY_SET,
                                 new Param[] { },
                               },

                // 38: LD (IY + *), n,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IY_Pointer, CommandID.ByteData, },
                               },

                // 39: ADD IY, SP,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.IY, CommandID.SP, },
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

                // 3C: INC A,
                new OpcodeData { Name = "INC",
                                 Function = Operation.INC,
                                 new Param[] { CommandID.A, },
                               },

                // 3D: DEC A,
                new OpcodeData { Name = "DEC",
                                 Function = Operation.DEC,
                                 new Param[] { CommandID.A, },
                               },

                // 3E: LD A, n,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.A, CommandID.ByteData, },
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

                // 44: LD B, IYH,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.B, CommandID.IYH, },
                               },

                // 45: LD B, IYL,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.B, CommandID.IYL, },
                               },

                // 46
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 47: RST 30,
                new OpcodeData { Name = "RST",
                                 Function = Operation.RST,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 30), },
                               },

                // 48: LD B, (IY + *),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.B, CommandID.IY_Pointer, },
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

                // 4C: LD C, IYH,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.C, CommandID.IYH, },
                               },

                // 4D: LD C, IYL,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.C, CommandID.IYL, },
                               },

                // 4E
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 4F: LD C, A,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.C, CommandID.A, },
                               },

                // 50: LD C, (IY + *),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.C, CommandID.IY_Pointer, },
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

                // 54: LD D, IYH,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.D, CommandID.IYH, },
                               },

                // 55: LD D, IYL,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.D, CommandID.IYL, },
                               },

                // 56
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 57: LD D, A,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.D, CommandID.A, },
                               },

                // 58: LD D, (IY + *),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.D, CommandID.IY_Pointer, },
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

                // 5C: LD E, IYH,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.E, CommandID.IYH, },
                               },

                // 5D: LD E, IYL,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.E, CommandID.IYL, },
                               },

                // 5E
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 5F: LD E, A,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.E, CommandID.A, },
                               },

                // 60: LD E, (IY + *),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.E, CommandID.IY_Pointer, },
                               },

                // 61: LD IYH, C,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IYH, CommandID.C, },
                               },

                // 62: LD IYH, D,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IYH, CommandID.D, },
                               },

                // 63: LD IYH, E,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IYH, CommandID.E, },
                               },

                // 64: LD IYH, IYH,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IYH, CommandID.IYH, },
                               },

                // 65: LD IYH, IYL,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IYH, CommandID.IYL, },
                               },

                // 66
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 67: LD IYH, A,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IYH, CommandID.A, },
                               },

                // 68: LD IYH, (IY + *),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IYH, CommandID.IY_Pointer, },
                               },

                // 69: LD IYL, C,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IYL, CommandID.C, },
                               },

                // 6A: LD IYL, D,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IYL, CommandID.D, },
                               },

                // 6B: LD IYL, E,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IYL, CommandID.E, },
                               },

                // 6C: LD IYL, IYH,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IYL, CommandID.IYH, },
                               },

                // 6D: LD IYL, IYL,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IYL, CommandID.IYL, },
                               },

                // 6E
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 6F: LD IYL, A,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IYL, CommandID.A, },
                               },

                // 70: LD IYL, (IY + *),
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IYL, CommandID.IY_Pointer, },
                               },

                // 71
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 72: LD (IY + *), B,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IY_Pointer, CommandID.B, },
                               },

                // 73: LD (IY + *), C,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IY_Pointer, CommandID.C, },
                               },

                // 74: LD (IY + *), D,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IY_Pointer, CommandID.D, },
                               },

                // 75: LD (IY + *), E,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IY_Pointer, CommandID.E, },
                               },

                // 76: HALT
                new OpcodeData { Name = "HALT",
                                 Function = Operation.HALT,
                                 new Param[] { },
                               },

                // 77: LD (IY + *), IYL,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IY_Pointer, CommandID.IYL, },
                               },

                // 78: LD A, B,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.A, CommandID.B, },
                               },

                // 79: LD (IY + *), A,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.IY_Pointer, CommandID.A, },
                               },

                // 7A: LD A, D,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.A, CommandID.D, },
                               },

                // 7B: LD A, E,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.A, CommandID.E, },
                               },

                // 7C: LD A, IYH,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.A, CommandID.IYH, },
                               },

                // 7D: LD A, IYL,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.A, CommandID.IYL, },
                               },

                // 7E
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 7F: LD A, A,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.A, CommandID.A, },
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

                // 84: ADD A, IYH,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.A, CommandID.IYH, },
                               },

                // 85: ADD A, IYL,
                new OpcodeData { Name = "ADD",
                                 Function = Operation.ADD,
                                 new Param[] { CommandID.A, CommandID.IYL, },
                               },

                // 86
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 87: RST 38,
                new OpcodeData { Name = "RST",
                                 Function = Operation.RST,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 38), },
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

                // 8C: ADC A, IYH,
                new OpcodeData { Name = "ADC",
                                 Function = Operation.ADDC,
                                 new Param[] { CommandID.A, CommandID.IYH, },
                               },

                // 8D: ADC A, IYL,
                new OpcodeData { Name = "ADC",
                                 Function = Operation.ADDC,
                                 new Param[] { CommandID.A, CommandID.IYL, },
                               },

                // 8E
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 8F: ADC A, A,
                new OpcodeData { Name = "ADC",
                                 Function = Operation.ADDC,
                                 new Param[] { CommandID.A, CommandID.A, },
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

                // 94: SUB A, IYH,
                new OpcodeData { Name = "SUB",
                                 Function = Operation.SUB,
                                 new Param[] { CommandID.A, CommandID.IYH, },
                               },

                // 95: SUB A, IYL,
                new OpcodeData { Name = "SUB",
                                 Function = Operation.SUB,
                                 new Param[] { CommandID.A, CommandID.IYL, },
                               },

                // 96
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 97: SUB A, A,
                new OpcodeData { Name = "SUB",
                                 Function = Operation.SUB,
                                 new Param[] { CommandID.A, CommandID.A, },
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

                // 9C: SBC A, IYH,
                new OpcodeData { Name = "SBC",
                                 Function = Operation.SUBC,
                                 new Param[] { CommandID.A, CommandID.IYH, },
                               },

                // 9D: SBC A, IYL,
                new OpcodeData { Name = "SBC",
                                 Function = Operation.SUBC,
                                 new Param[] { CommandID.A, CommandID.IYL, },
                               },

                // 9E
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 9F: SBC A, A,
                new OpcodeData { Name = "SBC",
                                 Function = Operation.SUBC,
                                 new Param[] { CommandID.A, CommandID.A, },
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

                // A4: AND A, IYH,
                new OpcodeData { Name = "AND",
                                 Function = Operation.AND,
                                 new Param[] { CommandID.A, CommandID.IYH, },
                               },

                // A5: AND A, IYL,
                new OpcodeData { Name = "AND",
                                 Function = Operation.AND,
                                 new Param[] { CommandID.A, CommandID.IYL, },
                               },

                // A6
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // A7: AND A, A,
                new OpcodeData { Name = "AND",
                                 Function = Operation.AND,
                                 new Param[] { CommandID.A, CommandID.A, },
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

                // AC: XOR A, IYH,
                new OpcodeData { Name = "XOR",
                                 Function = Operation.XOR,
                                 new Param[] { CommandID.A, CommandID.IYH, },
                               },

                // AD: XOR A, IYL,
                new OpcodeData { Name = "XOR",
                                 Function = Operation.XOR,
                                 new Param[] { CommandID.A, CommandID.IYL, },
                               },

                // AE
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // AF: XOR A, A,
                new OpcodeData { Name = "XOR",
                                 Function = Operation.XOR,
                                 new Param[] { CommandID.A, CommandID.A, },
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

                // B4: OR A, IYH,
                new OpcodeData { Name = "OR",
                                 Function = Operation.OR,
                                 new Param[] { CommandID.A, CommandID.IYH, },
                               },

                // B5: OR A, IYL,
                new OpcodeData { Name = "OR",
                                 Function = Operation.OR,
                                 new Param[] { CommandID.A, CommandID.IYL, },
                               },

                // B6
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // B7: OR A, A,
                new OpcodeData { Name = "OR",
                                 Function = Operation.OR,
                                 new Param[] { CommandID.A, CommandID.A, },
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

                // BC: CP A, IYH,
                new OpcodeData { Name = "CP",
                                 Function = Operation.CMP,
                                 new Param[] { CommandID.A, CommandID.IYH, },
                               },

                // BD: CP A, IYL,
                new OpcodeData { Name = "CP",
                                 Function = Operation.CMP,
                                 new Param[] { CommandID.A, CommandID.IYL, },
                               },

                // BE
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // BF: CP A, A,
                new OpcodeData { Name = "CP",
                                 Function = Operation.CMP,
                                 new Param[] { CommandID.A, CommandID.A, },
                               },

                // C0: RET Flag_NZ,
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { CommandID.Flag_NZ, },
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

                // C7: RST 20,
                new OpcodeData { Name = "RST",
                                 Function = Operation.RST,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 20), },
                               },

                // C8: RET Flag_Z,
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { CommandID.Flag_Z, },
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

                // CF
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D0: RET Flag_NC,
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { CommandID.Flag_NC, },
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

                // D7
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // D8: RET Flag_C,
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { CommandID.Flag_C, },
                               },

                // D9: EXX
                new OpcodeData { Name = "EXX",
                                 Function = Operation.EXX,
                                 new Param[] { },
                               },

                // DA: JP Flag_C, nn,
                new OpcodeData { Name = "JP",
                                 Function = Operation.JMP,
                                 new Param[] { CommandID.Flag_C, CommandID.Address, },
                               },

                // DB: IN A, n,
                new OpcodeData { Name = "IN",
                                 Function = Operation.IN,
                                 new Param[] { CommandID.A, CommandID.ByteData, },
                               },

                // DC: CALL Flag_C, nn,
                new OpcodeData { Name = "CALL",
                                 Function = Operation.CALL,
                                 new Param[] { CommandID.Flag_C, CommandID.Address, },
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

                // DF
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E0: RET Flag_PO,
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { CommandID.Flag_PO, },
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

                // E3: EX (SP), IY,
                new OpcodeData { Name = "EX",
                                 Function = Operation.EX,
                                 new Param[] { CommandID.SP_Pointer, CommandID.IY, },
                               },

                // E4: CALL Flag_PO, nn,
                new OpcodeData { Name = "CALL",
                                 Function = Operation.CALL,
                                 new Param[] { CommandID.Flag_PO, CommandID.Address, },
                               },

                // E5: PUSH HL,
                new OpcodeData { Name = "PUSH",
                                 Function = Operation.PUSH,
                                 new Param[] { CommandID.HL, },
                               },

                // E6: AND A, n,
                new OpcodeData { Name = "AND",
                                 Function = Operation.AND,
                                 new Param[] { CommandID.A, CommandID.ByteData, },
                               },

                // E7
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // E8: RET Flag_PE,
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { CommandID.Flag_PE, },
                               },

                // E9: JP IY,
                new OpcodeData { Name = "JP",
                                 Function = Operation.JMP,
                                 new Param[] { CommandID.IY, },
                               },

                // EA: JP Flag_PE, nn,
                new OpcodeData { Name = "JP",
                                 Function = Operation.JMP,
                                 new Param[] { CommandID.Flag_PE, CommandID.Address, },
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

                // EF
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F0: RET Flag_P,
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { CommandID.Flag_P, },
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

                // F7
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // F8: RET Flag_M,
                new OpcodeData { Name = "RET",
                                 Function = Operation.RET,
                                 new Param[] { CommandID.Flag_M, },
                               },

                // F9: LD SP, IY,
                new OpcodeData { Name = "LD",
                                 Function = Operation.LD,
                                 new Param[] { CommandID.SP, CommandID.IY, },
                               },

                // FA: JP Flag_M, nn,
                new OpcodeData { Name = "JP",
                                 Function = Operation.JMP,
                                 new Param[] { CommandID.Flag_M, CommandID.Address, },
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

                // FF
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

            },

            {
                // CB00: SET 7, (IY + *),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, },
                               },

                // CB01: SET 7, (IY + *), A,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CB02: RLC (IY + *), B,
                new OpcodeData { Name = "RLC",
                                 Function = Operation.RL_CY,
                                 new Param[] { CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB03: RLC (IY + *), C,
                new OpcodeData { Name = "RLC",
                                 Function = Operation.RL_CY,
                                 new Param[] { CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB04: RLC (IY + *), D,
                new OpcodeData { Name = "RLC",
                                 Function = Operation.RL_CY,
                                 new Param[] { CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB05: RLC (IY + *), E,
                new OpcodeData { Name = "RLC",
                                 Function = Operation.RL_CY,
                                 new Param[] { CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB06: RLC (IY + *), H,
                new OpcodeData { Name = "RLC",
                                 Function = Operation.RL_CY,
                                 new Param[] { CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB07: RLC (IY + *), L,
                new OpcodeData { Name = "RLC",
                                 Function = Operation.RL_CY,
                                 new Param[] { CommandID.IY_Pointer, CommandID.L, },
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

                // CB0A: RRC (IY + *), B,
                new OpcodeData { Name = "RRC",
                                 Function = Operation.RR_CY,
                                 new Param[] { CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB0B: RRC (IY + *), C,
                new OpcodeData { Name = "RRC",
                                 Function = Operation.RR_CY,
                                 new Param[] { CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB0C: RRC (IY + *), D,
                new OpcodeData { Name = "RRC",
                                 Function = Operation.RR_CY,
                                 new Param[] { CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB0D: RRC (IY + *), E,
                new OpcodeData { Name = "RRC",
                                 Function = Operation.RR_CY,
                                 new Param[] { CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB0E: RRC (IY + *), H,
                new OpcodeData { Name = "RRC",
                                 Function = Operation.RR_CY,
                                 new Param[] { CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB0F: RRC (IY + *), L,
                new OpcodeData { Name = "RRC",
                                 Function = Operation.RR_CY,
                                 new Param[] { CommandID.IY_Pointer, CommandID.L, },
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

                // CB12: RL (IY + *), B,
                new OpcodeData { Name = "RL",
                                 Function = Operation.RL,
                                 new Param[] { CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB13: RL (IY + *), C,
                new OpcodeData { Name = "RL",
                                 Function = Operation.RL,
                                 new Param[] { CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB14: RL (IY + *), D,
                new OpcodeData { Name = "RL",
                                 Function = Operation.RL,
                                 new Param[] { CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB15: RL (IY + *), E,
                new OpcodeData { Name = "RL",
                                 Function = Operation.RL,
                                 new Param[] { CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB16: RL (IY + *), H,
                new OpcodeData { Name = "RL",
                                 Function = Operation.RL,
                                 new Param[] { CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB17: RL (IY + *), L,
                new OpcodeData { Name = "RL",
                                 Function = Operation.RL,
                                 new Param[] { CommandID.IY_Pointer, CommandID.L, },
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

                // CB1A: RR (IY + *), B,
                new OpcodeData { Name = "RR",
                                 Function = Operation.RR,
                                 new Param[] { CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB1B: RR (IY + *), C,
                new OpcodeData { Name = "RR",
                                 Function = Operation.RR,
                                 new Param[] { CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB1C: RR (IY + *), D,
                new OpcodeData { Name = "RR",
                                 Function = Operation.RR,
                                 new Param[] { CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB1D: RR (IY + *), E,
                new OpcodeData { Name = "RR",
                                 Function = Operation.RR,
                                 new Param[] { CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB1E: RR (IY + *), H,
                new OpcodeData { Name = "RR",
                                 Function = Operation.RR,
                                 new Param[] { CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB1F: RR (IY + *), L,
                new OpcodeData { Name = "RR",
                                 Function = Operation.RR,
                                 new Param[] { CommandID.IY_Pointer, CommandID.L, },
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

                // CB22: SLA (IY + *), B,
                new OpcodeData { Name = "SLA",
                                 Function = Operation.SL_Signed,
                                 new Param[] { CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB23: SLA (IY + *), C,
                new OpcodeData { Name = "SLA",
                                 Function = Operation.SL_Signed,
                                 new Param[] { CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB24: SLA (IY + *), D,
                new OpcodeData { Name = "SLA",
                                 Function = Operation.SL_Signed,
                                 new Param[] { CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB25: SLA (IY + *), E,
                new OpcodeData { Name = "SLA",
                                 Function = Operation.SL_Signed,
                                 new Param[] { CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB26: SLA (IY + *), H,
                new OpcodeData { Name = "SLA",
                                 Function = Operation.SL_Signed,
                                 new Param[] { CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB27: SLA (IY + *), L,
                new OpcodeData { Name = "SLA",
                                 Function = Operation.SL_Signed,
                                 new Param[] { CommandID.IY_Pointer, CommandID.L, },
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

                // CB2A: SRA (IY + *), B,
                new OpcodeData { Name = "SRA",
                                 Function = Operation.SR_Signed,
                                 new Param[] { CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB2B: SRA (IY + *), C,
                new OpcodeData { Name = "SRA",
                                 Function = Operation.SR_Signed,
                                 new Param[] { CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB2C: SRA (IY + *), D,
                new OpcodeData { Name = "SRA",
                                 Function = Operation.SR_Signed,
                                 new Param[] { CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB2D: SRA (IY + *), E,
                new OpcodeData { Name = "SRA",
                                 Function = Operation.SR_Signed,
                                 new Param[] { CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB2E: SRA (IY + *), H,
                new OpcodeData { Name = "SRA",
                                 Function = Operation.SR_Signed,
                                 new Param[] { CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB2F: SRA (IY + *), L,
                new OpcodeData { Name = "SRA",
                                 Function = Operation.SR_Signed,
                                 new Param[] { CommandID.IY_Pointer, CommandID.L, },
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

                // CB32: SLL (IY + *), B,
                new OpcodeData { Name = "SLL",
                                 Function = Operation.SL_L,
                                 new Param[] { CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB33: SLL (IY + *), C,
                new OpcodeData { Name = "SLL",
                                 Function = Operation.SL_L,
                                 new Param[] { CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB34: SLL (IY + *), D,
                new OpcodeData { Name = "SLL",
                                 Function = Operation.SL_L,
                                 new Param[] { CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB35: SLL (IY + *), E,
                new OpcodeData { Name = "SLL",
                                 Function = Operation.SL_L,
                                 new Param[] { CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB36: SLL (IY + *), H,
                new OpcodeData { Name = "SLL",
                                 Function = Operation.SL_L,
                                 new Param[] { CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB37: SLL (IY + *), L,
                new OpcodeData { Name = "SLL",
                                 Function = Operation.SL_L,
                                 new Param[] { CommandID.IY_Pointer, CommandID.L, },
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

                // CB3A: SRL (IY + *), B,
                new OpcodeData { Name = "SRL",
                                 Function = Operation.SR_L,
                                 new Param[] { CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB3B: SRL (IY + *), C,
                new OpcodeData { Name = "SRL",
                                 Function = Operation.SR_L,
                                 new Param[] { CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB3C: SRL (IY + *), D,
                new OpcodeData { Name = "SRL",
                                 Function = Operation.SR_L,
                                 new Param[] { CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB3D: SRL (IY + *), E,
                new OpcodeData { Name = "SRL",
                                 Function = Operation.SR_L,
                                 new Param[] { CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB3E: SRL (IY + *), H,
                new OpcodeData { Name = "SRL",
                                 Function = Operation.SR_L,
                                 new Param[] { CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB3F: SRL (IY + *), L,
                new OpcodeData { Name = "SRL",
                                 Function = Operation.SR_L,
                                 new Param[] { CommandID.IY_Pointer, CommandID.L, },
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

                // CB42: BIT 0, (IY + *), B,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB43: BIT 0, (IY + *), C,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB44: BIT 0, (IY + *), D,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB45: BIT 0, (IY + *), E,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB46: BIT 0, (IY + *), H,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB47: BIT 0, (IY + *), L,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CB48: BIT 0, (IY + *),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, },
                               },

                // CB49: BIT 0, (IY + *), A,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CB4A: BIT 1, (IY + *), B,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB4B: BIT 1, (IY + *), C,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB4C: BIT 1, (IY + *), D,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB4D: BIT 1, (IY + *), E,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB4E: BIT 1, (IY + *), H,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB4F: BIT 1, (IY + *), L,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CB50: BIT 1, (IY + *),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, },
                               },

                // CB51: BIT 1, (IY + *), A,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CB52: BIT 2, (IY + *), B,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB53: BIT 2, (IY + *), C,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB54: BIT 2, (IY + *), D,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB55: BIT 2, (IY + *), E,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB56: BIT 2, (IY + *), H,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB57: BIT 2, (IY + *), L,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CB58: BIT 2, (IY + *),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, },
                               },

                // CB59: BIT 2, (IY + *), A,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CB5A: BIT 3, (IY + *), B,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB5B: BIT 3, (IY + *), C,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB5C: BIT 3, (IY + *), D,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB5D: BIT 3, (IY + *), E,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB5E: BIT 3, (IY + *), H,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB5F: BIT 3, (IY + *), L,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CB60: BIT 3, (IY + *),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, },
                               },

                // CB61: BIT 3, (IY + *), A,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CB62: BIT 4, (IY + *), B,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB63: BIT 4, (IY + *), C,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB64: BIT 4, (IY + *), D,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB65: BIT 4, (IY + *), E,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB66: BIT 4, (IY + *), H,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB67: BIT 4, (IY + *), L,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CB68: BIT 4, (IY + *),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, },
                               },

                // CB69: BIT 4, (IY + *), A,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CB6A: BIT 5, (IY + *), B,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB6B: BIT 5, (IY + *), C,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB6C: BIT 5, (IY + *), D,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB6D: BIT 5, (IY + *), E,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB6E: BIT 5, (IY + *), H,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB6F: BIT 5, (IY + *), L,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CB70: BIT 5, (IY + *),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, },
                               },

                // CB71: BIT 5, (IY + *), A,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CB72: BIT 6, (IY + *), B,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB73: BIT 6, (IY + *), C,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB74: BIT 6, (IY + *), D,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB75: BIT 6, (IY + *), E,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB76: BIT 6, (IY + *), H,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB77: BIT 6, (IY + *), L,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CB78: BIT 6, (IY + *),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, },
                               },

                // CB79: BIT 6, (IY + *), A,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CB7A: BIT 7, (IY + *), B,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB7B: BIT 7, (IY + *), C,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB7C: BIT 7, (IY + *), D,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB7D: BIT 7, (IY + *), E,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB7E: BIT 7, (IY + *), H,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB7F: BIT 7, (IY + *), L,
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.L, },
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

                // CB82: RES 0, (IY + *), B,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB83: RES 0, (IY + *), C,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB84: RES 0, (IY + *), D,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB85: RES 0, (IY + *), E,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB86: RES 0, (IY + *), H,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB87: RES 0, (IY + *), L,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CB88: RES 0, (IY + *),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, },
                               },

                // CB89: RES 0, (IY + *), A,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CB8A: RES 1, (IY + *), B,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB8B: RES 1, (IY + *), C,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB8C: RES 1, (IY + *), D,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB8D: RES 1, (IY + *), E,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB8E: RES 1, (IY + *), H,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB8F: RES 1, (IY + *), L,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CB90: RES 1, (IY + *),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, },
                               },

                // CB91: RES 1, (IY + *), A,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CB92: RES 2, (IY + *), B,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB93: RES 2, (IY + *), C,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB94: RES 2, (IY + *), D,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB95: RES 2, (IY + *), E,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB96: RES 2, (IY + *), H,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB97: RES 2, (IY + *), L,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CB98: RES 2, (IY + *),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, },
                               },

                // CB99: RES 2, (IY + *), A,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CB9A: RES 3, (IY + *), B,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CB9B: RES 3, (IY + *), C,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CB9C: RES 3, (IY + *), D,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CB9D: RES 3, (IY + *), E,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CB9E: RES 3, (IY + *), H,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CB9F: RES 3, (IY + *), L,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CBA0: RES 3, (IY + *),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, },
                               },

                // CBA1: RES 3, (IY + *), A,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CBA2: RES 4, (IY + *), B,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CBA3: RES 4, (IY + *), C,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CBA4: RES 4, (IY + *), D,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CBA5: RES 4, (IY + *), E,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CBA6: RES 4, (IY + *), H,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CBA7: RES 4, (IY + *), L,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CBA8: RES 4, (IY + *),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, },
                               },

                // CBA9: RES 4, (IY + *), A,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CBAA: RES 5, (IY + *), B,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CBAB: RES 5, (IY + *), C,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CBAC: RES 5, (IY + *), D,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CBAD: RES 5, (IY + *), E,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CBAE: RES 5, (IY + *), H,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CBAF: RES 5, (IY + *), L,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CBB0: RES 5, (IY + *),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, },
                               },

                // CBB1: RES 5, (IY + *), A,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CBB2: RES 6, (IY + *), B,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CBB3: RES 6, (IY + *), C,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CBB4: RES 6, (IY + *), D,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CBB5: RES 6, (IY + *), E,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CBB6: RES 6, (IY + *), H,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CBB7: RES 6, (IY + *), L,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CBB8: RES 6, (IY + *),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, },
                               },

                // CBB9: RES 6, (IY + *), A,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CBBA: RES 7, (IY + *), B,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CBBB: RES 7, (IY + *), C,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CBBC: RES 7, (IY + *), D,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CBBD: RES 7, (IY + *), E,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CBBE: RES 7, (IY + *), H,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CBBF: RES 7, (IY + *), L,
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.L, },
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

                // CBC2: SET 0, (IY + *), B,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CBC3: SET 0, (IY + *), C,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CBC4: SET 0, (IY + *), D,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CBC5: SET 0, (IY + *), E,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CBC6: SET 0, (IY + *), H,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CBC7: SET 0, (IY + *), L,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CBC8: SET 0, (IY + *),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, },
                               },

                // CBC9: SET 0, (IY + *), A,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CBCA: SET 1, (IY + *), B,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CBCB: SET 1, (IY + *), C,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CBCC: SET 1, (IY + *), D,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CBCD: SET 1, (IY + *), E,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CBCE: SET 1, (IY + *), H,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CBCF: SET 1, (IY + *), L,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CBD0: SET 1, (IY + *),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, },
                               },

                // CBD1: SET 1, (IY + *), A,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CBD2: SET 2, (IY + *), B,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CBD3: SET 2, (IY + *), C,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CBD4: SET 2, (IY + *), D,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CBD5: SET 2, (IY + *), E,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CBD6: SET 2, (IY + *), H,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CBD7: SET 2, (IY + *), L,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CBD8: SET 2, (IY + *),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, },
                               },

                // CBD9: SET 2, (IY + *), A,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CBDA: SET 3, (IY + *), B,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CBDB: SET 3, (IY + *), C,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CBDC: SET 3, (IY + *), D,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CBDD: SET 3, (IY + *), E,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CBDE: SET 3, (IY + *), H,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CBDF: SET 3, (IY + *), L,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CBE0: SET 3, (IY + *),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, },
                               },

                // CBE1: SET 3, (IY + *), A,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CBE2: SET 4, (IY + *), B,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CBE3: SET 4, (IY + *), C,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CBE4: SET 4, (IY + *), D,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CBE5: SET 4, (IY + *), E,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CBE6: SET 4, (IY + *), H,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CBE7: SET 4, (IY + *), L,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CBE8: SET 4, (IY + *),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, },
                               },

                // CBE9: SET 4, (IY + *), A,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CBEA: SET 5, (IY + *), B,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CBEB: SET 5, (IY + *), C,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CBEC: SET 5, (IY + *), D,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CBED: SET 5, (IY + *), E,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CBEE: SET 5, (IY + *), H,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CBEF: SET 5, (IY + *), L,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CBF0: SET 5, (IY + *),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, },
                               },

                // CBF1: SET 5, (IY + *), A,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CBF2: SET 6, (IY + *), B,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CBF3: SET 6, (IY + *), C,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CBF4: SET 6, (IY + *), D,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CBF5: SET 6, (IY + *), E,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CBF6: SET 6, (IY + *), H,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CBF7: SET 6, (IY + *), L,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.L, },
                               },

                // CBF8: SET 6, (IY + *),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, },
                               },

                // CBF9: SET 6, (IY + *), A,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.IY_Pointer, CommandID.A, },
                               },

                // CBFA: SET 7, (IY + *), B,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.B, },
                               },

                // CBFB: SET 7, (IY + *), C,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.C, },
                               },

                // CBFC: SET 7, (IY + *), D,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.D, },
                               },

                // CBFD: SET 7, (IY + *), E,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.E, },
                               },

                // CBFE: SET 7, (IY + *), H,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.H, },
                               },

                // CBFF: SET 7, (IY + *), L,
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.IY_Pointer, CommandID.L, },
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

                // ED68: IN L, C,
                new OpcodeData { Name = "IN",
                                 Function = Operation.IN,
                                 new Param[] { CommandID.L, CommandID.C, },
                               },

                // ED69: OUT C, L,
                new OpcodeData { Name = "OUT",
                                 Function = Operation.OUT,
                                 new Param[] { CommandID.C, CommandID.L, },
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

                // ED78: IN A, C,
                new OpcodeData { Name = "IN",
                                 Function = Operation.IN,
                                 new Param[] { CommandID.A, CommandID.C, },
                               },

                // ED79: OUT C, A,
                new OpcodeData { Name = "OUT",
                                 Function = Operation.OUT,
                                 new Param[] { CommandID.C, CommandID.A, },
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
                // CB00: SET 7, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.HL_Pointer, },
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

                // CB08: RLC (HL),
                new OpcodeData { Name = "RLC",
                                 Function = Operation.RL_CY,
                                 new Param[] { CommandID.HL_Pointer, },
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

                // CB10: RRC (HL),
                new OpcodeData { Name = "RRC",
                                 Function = Operation.RR_CY,
                                 new Param[] { CommandID.HL_Pointer, },
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

                // CB18: RL (HL),
                new OpcodeData { Name = "RL",
                                 Function = Operation.RL,
                                 new Param[] { CommandID.HL_Pointer, },
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

                // CB20: RR (HL),
                new OpcodeData { Name = "RR",
                                 Function = Operation.RR,
                                 new Param[] { CommandID.HL_Pointer, },
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

                // CB28: SLA (HL),
                new OpcodeData { Name = "SLA",
                                 Function = Operation.SL_Signed,
                                 new Param[] { CommandID.HL_Pointer, },
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

                // CB30: SRA (HL),
                new OpcodeData { Name = "SRA",
                                 Function = Operation.SR_Signed,
                                 new Param[] { CommandID.HL_Pointer, },
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

                // CB38: SLL (HL),
                new OpcodeData { Name = "SLL",
                                 Function = Operation.SL_L,
                                 new Param[] { CommandID.HL_Pointer, },
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

                // CB40: SRL (HL),
                new OpcodeData { Name = "SRL",
                                 Function = Operation.SR_L,
                                 new Param[] { CommandID.HL_Pointer, },
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

                // 46
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 47
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB48: BIT 0, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.HL_Pointer, },
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

                // 4E
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 4F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB50: BIT 1, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.HL_Pointer, },
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

                // 56
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 57
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB58: BIT 2, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.HL_Pointer, },
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

                // 5E
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 5F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB60: BIT 3, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.HL_Pointer, },
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

                // 66
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 67
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB68: BIT 4, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.HL_Pointer, },
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

                // 6E
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 6F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB70: BIT 5, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.HL_Pointer, },
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

                // 76
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 77
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB78: BIT 6, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.HL_Pointer, },
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

                // 7E
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // 7F
                new OpcodeData { Name = "",
                                 Function = Operation.Error,
                                 new Param[] { }
                               },

                // CB80: BIT 7, (HL),
                new OpcodeData { Name = "BIT",
                                 Function = Operation.BIT,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.HL_Pointer, },
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

                // CB88: RES 0, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.HL_Pointer, },
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

                // CB90: RES 1, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.HL_Pointer, },
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

                // CB98: RES 2, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.HL_Pointer, },
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

                // CBA0: RES 3, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.HL_Pointer, },
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

                // CBA8: RES 4, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.HL_Pointer, },
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

                // CBB0: RES 5, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.HL_Pointer, },
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

                // CBB8: RES 6, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.HL_Pointer, },
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

                // CBC0: RES 7, (HL),
                new OpcodeData { Name = "RES",
                                 Function = Operation.RES,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 07), CommandID.HL_Pointer, },
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

                // CBC8: SET 0, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), CommandID.HL_Pointer, },
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

                // CBD0: SET 1, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), CommandID.HL_Pointer, },
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

                // CBD8: SET 2, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), CommandID.HL_Pointer, },
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

                // CBE0: SET 3, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 03), CommandID.HL_Pointer, },
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

                // CBE8: SET 4, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 04), CommandID.HL_Pointer, },
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

                // CBF0: SET 5, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 05), CommandID.HL_Pointer, },
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

                // CBF8: SET 6, (HL),
                new OpcodeData { Name = "SET",
                                 Function = Operation.SET,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 06), CommandID.HL_Pointer, },
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
        };
    }
}
