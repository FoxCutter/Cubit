using System.Collections.Generic;
namespace ZASM
{
    static class Ops
    {
        static public OpcodeEncoding[] EncodingData = 
        {
            new OpcodeEncoding { Function = CommandID.ADC, // 88: ADC A, r,
                                 new Param[] { CommandID.A, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.ByteIndexAllowed,
                                 Prefix = 0x00, Base = 0x88, },

            new OpcodeEncoding { Function = CommandID.ADC, // 8E: ADC A, BytePtr,
                                 new Param[] { CommandID.A, CommandID.BytePtr, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x8E, },

            new OpcodeEncoding { Function = CommandID.ADC, // CE: ADC A, n,
                                 new Param[] { CommandID.A, CommandID.ByteImmidate | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xCE, },

            new OpcodeEncoding { Function = CommandID.ADC, // ED4A: ADC HL, rr,
                                 new Param[] { CommandID.HL, CommandID.WordReg | CommandID.Pos3, },
                                 Flags = ParamFlags.NoIndexPrefix,
                                 Prefix = 0xED, Base = 0x4A, },

            new OpcodeEncoding { Function = CommandID.ADD, // 09: ADD (HL), rr,
                                 new Param[] { CommandID.AddrReg, CommandID.WordReg | CommandID.Pos3, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x09, },

            new OpcodeEncoding { Function = CommandID.ADD, // 80: ADD A, r,
                                 new Param[] { CommandID.A, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.ByteIndexAllowed,
                                 Prefix = 0x00, Base = 0x80, },

            new OpcodeEncoding { Function = CommandID.ADD, // 86: ADD A, BytePtr,
                                 new Param[] { CommandID.A, CommandID.BytePtr, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x86, },

            new OpcodeEncoding { Function = CommandID.ADD, // C6: ADD A, n,
                                 new Param[] { CommandID.A, CommandID.ByteImmidate | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xC6, },

            new OpcodeEncoding { Function = CommandID.AND, // A0: AND A, r,
                                 new Param[] { CommandID.A, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.ByteIndexAllowed,
                                 Prefix = 0x00, Base = 0xA0, },

            new OpcodeEncoding { Function = CommandID.AND, // A6: AND A, BytePtr,
                                 new Param[] { CommandID.A, CommandID.BytePtr, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xA6, },

            new OpcodeEncoding { Function = CommandID.AND, // E6: AND A, n,
                                 new Param[] { CommandID.A, CommandID.ByteImmidate | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xE6, },

            new OpcodeEncoding { Function = CommandID.BIT, // CB40: BIT n, r,
                                 new Param[] { CommandID.Encoded | CommandID.Pos2, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x40, },

            new OpcodeEncoding { Function = CommandID.BIT, // CB46: BIT n, BytePtr,
                                 new Param[] { CommandID.Encoded | CommandID.Pos2, CommandID.BytePtr, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x46, },

            new OpcodeEncoding { Function = CommandID.BIT, // CB40: BIT n, (rx + *), r,
                                 new Param[] { CommandID.Encoded | CommandID.Pos2, CommandID.IndexPtr, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.Unoffical | ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x40, },

            new OpcodeEncoding { Function = CommandID.CALL, // C4: CALL cc, nn,
                                 new Param[] { CommandID.Flags | CommandID.Pos2, CommandID.Address | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xC4, },

            new OpcodeEncoding { Function = CommandID.CALL, // CD: CALL nn,
                                 new Param[] { CommandID.Address | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xCD, },

            new OpcodeEncoding { Function = CommandID.CCF, // 3F: CCF
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x3F, },

            new OpcodeEncoding { Function = CommandID.CP, // B8: CP A, r,
                                 new Param[] { CommandID.A, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.ByteIndexAllowed,
                                 Prefix = 0x00, Base = 0xB8, },

            new OpcodeEncoding { Function = CommandID.CP, // BE: CP A, BytePtr,
                                 new Param[] { CommandID.A, CommandID.BytePtr, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xBE, },

            new OpcodeEncoding { Function = CommandID.CP, // FE: CP A, n,
                                 new Param[] { CommandID.A, CommandID.ByteImmidate | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xFE, },

            new OpcodeEncoding { Function = CommandID.CPD, // EDA9: CPD
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0xA9, },

            new OpcodeEncoding { Function = CommandID.CPDR, // EDB9: CPDR
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0xB9, },

            new OpcodeEncoding { Function = CommandID.CPI, // EDA1: CPI
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0xA1, },

            new OpcodeEncoding { Function = CommandID.CPIR, // EDB1: CPIR
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0xB1, },

            new OpcodeEncoding { Function = CommandID.CPL, // 2F: CPL
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x2F, },

            new OpcodeEncoding { Function = CommandID.DAA, // 27: DAA
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x27, },

            new OpcodeEncoding { Function = CommandID.DEC, // 05: DEC r,
                                 new Param[] { CommandID.ByteReg | CommandID.Pos2, },
                                 Flags = ParamFlags.ByteIndexAllowed,
                                 Prefix = 0x00, Base = 0x05, },

            new OpcodeEncoding { Function = CommandID.DEC, // 0B: DEC rr,
                                 new Param[] { CommandID.WordReg | CommandID.Pos3, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x0B, },

            new OpcodeEncoding { Function = CommandID.DEC, // 35: DEC BytePtr,
                                 new Param[] { CommandID.BytePtr, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x35, },

            new OpcodeEncoding { Function = CommandID.DI, // F3: DI
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xF3, },

            new OpcodeEncoding { Function = CommandID.DJNZ, // 10: DJNZ e-2,
                                 new Param[] { CommandID.Displacment | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x10, },

            new OpcodeEncoding { Function = CommandID.EI, // FB: EI
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xFB, },

            new OpcodeEncoding { Function = CommandID.EX, // 08: EX AF, AF,
                                 new Param[] { CommandID.AF, CommandID.AF, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x08, },

            new OpcodeEncoding { Function = CommandID.EX, // E3: EX (SP), (HL),
                                 new Param[] { CommandID.SP_Pointer, CommandID.AddrReg, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xE3, },

            new OpcodeEncoding { Function = CommandID.EX, // EB: EX DE, HL,
                                 new Param[] { CommandID.DE, CommandID.HL, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xEB, },

            new OpcodeEncoding { Function = CommandID.EXX, // D9: EXX
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xD9, },

            new OpcodeEncoding { Function = CommandID.HALT, // 76: HALT
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x76, },

            new OpcodeEncoding { Function = CommandID.IM, // ED46: IM 0,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0x46, },

            new OpcodeEncoding { Function = CommandID.IM, // ED56: IM 1,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0x56, },

            new OpcodeEncoding { Function = CommandID.IM, // ED5E: IM 2,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0x5E, },

            new OpcodeEncoding { Function = CommandID.IM, // ED4E: IM 0,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x4E, },

            new OpcodeEncoding { Function = CommandID.IM, // ED66: IM 0,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x66, },

            new OpcodeEncoding { Function = CommandID.IM, // ED6E: IM 0,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x6E, },

            new OpcodeEncoding { Function = CommandID.IM, // ED6E: IM 0,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 00), },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x6E, },

            new OpcodeEncoding { Function = CommandID.IM, // ED76: IM 1,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 01), },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x76, },

            new OpcodeEncoding { Function = CommandID.IM, // ED7E: IM 2,
                                 new Param[] { (CommandID)((int)CommandID.Encoded + 02), },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x7E, },

            new OpcodeEncoding { Function = CommandID.IN, // DB: IN A, n,
                                 new Param[] { CommandID.A, CommandID.ByteImmidate | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xDB, },

            new OpcodeEncoding { Function = CommandID.IN, // ED40: IN r, C,
                                 new Param[] { CommandID.ByteReg | CommandID.Pos2, CommandID.C, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0x40, },

            new OpcodeEncoding { Function = CommandID.IN, // ED70: IN C,
                                 new Param[] { CommandID.C, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0x70, },

            new OpcodeEncoding { Function = CommandID.INC, // 03: INC rr,
                                 new Param[] { CommandID.WordReg | CommandID.Pos3, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x03, },

            new OpcodeEncoding { Function = CommandID.INC, // 04: INC r,
                                 new Param[] { CommandID.ByteReg | CommandID.Pos2, },
                                 Flags = ParamFlags.ByteIndexAllowed,
                                 Prefix = 0x00, Base = 0x04, },

            new OpcodeEncoding { Function = CommandID.INC, // 34: INC BytePtr,
                                 new Param[] { CommandID.BytePtr, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x34, },

            new OpcodeEncoding { Function = CommandID.IND, // EDAA: IND
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0xAA, },

            new OpcodeEncoding { Function = CommandID.INDR, // EDBA: INDR
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0xBA, },

            new OpcodeEncoding { Function = CommandID.INI, // EDA2: INI
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0xA2, },

            new OpcodeEncoding { Function = CommandID.INIR, // EDB2: INIR
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0xB2, },

            new OpcodeEncoding { Function = CommandID.JP, // C2: JP cc, nn,
                                 new Param[] { CommandID.Flags | CommandID.Pos2, CommandID.Address | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xC2, },

            new OpcodeEncoding { Function = CommandID.JP, // C3: JP nn,
                                 new Param[] { CommandID.Address | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xC3, },

            new OpcodeEncoding { Function = CommandID.JP, // E9: JP BytePtr,
                                 new Param[] { CommandID.BytePtr, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xE9, },

            new OpcodeEncoding { Function = CommandID.JR, // 18: JR e-2,
                                 new Param[] { CommandID.Displacment | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x18, },

            new OpcodeEncoding { Function = CommandID.JR, // 20: JR cc, e-2,
                                 new Param[] { CommandID.HalfFlags | CommandID.Pos4, CommandID.Displacment | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x20, },

            new OpcodeEncoding { Function = CommandID.LD, // 01: LD rr, nn,
                                 new Param[] { CommandID.WordReg | CommandID.Pos3, CommandID.WordImmidate | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x01, },

            new OpcodeEncoding { Function = CommandID.LD, // 02: LD (BC), A,
                                 new Param[] { CommandID.BC_Pointer, CommandID.A, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x02, },

            new OpcodeEncoding { Function = CommandID.LD, // 06: LD r, n,
                                 new Param[] { CommandID.ByteReg | CommandID.Pos2, CommandID.ByteImmidate | CommandID.Immidate, },
                                 Flags = ParamFlags.ByteIndexAllowed,
                                 Prefix = 0x00, Base = 0x06, },

            new OpcodeEncoding { Function = CommandID.LD, // 0A: LD A, (BC),
                                 new Param[] { CommandID.A, CommandID.BC_Pointer, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x0A, },

            new OpcodeEncoding { Function = CommandID.LD, // 12: LD (DE), A,
                                 new Param[] { CommandID.DE_Pointer, CommandID.A, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x12, },

            new OpcodeEncoding { Function = CommandID.LD, // 1A: LD A, (DE),
                                 new Param[] { CommandID.A, CommandID.DE_Pointer, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x1A, },

            new OpcodeEncoding { Function = CommandID.LD, // 22: LD (**), (HL),
                                 new Param[] { CommandID.AddressPtr | CommandID.Immidate, CommandID.AddrReg, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x22, },

            new OpcodeEncoding { Function = CommandID.LD, // 2A: LD (HL), (**),
                                 new Param[] { CommandID.AddrReg, CommandID.AddressPtr | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x2A, },

            new OpcodeEncoding { Function = CommandID.LD, // 32: LD (**), A,
                                 new Param[] { CommandID.AddressPtr | CommandID.Immidate, CommandID.A, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x32, },

            new OpcodeEncoding { Function = CommandID.LD, // 36: LD BytePtr, n,
                                 new Param[] { CommandID.BytePtr, CommandID.ByteImmidate | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x36, },

            new OpcodeEncoding { Function = CommandID.LD, // 3A: LD A, (**),
                                 new Param[] { CommandID.A, CommandID.AddressPtr | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x3A, },

            new OpcodeEncoding { Function = CommandID.LD, // 40: LD r, r,
                                 new Param[] { CommandID.ByteReg | CommandID.Pos2, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.ByteIndexAllowed,
                                 Prefix = 0x00, Base = 0x40, },

            new OpcodeEncoding { Function = CommandID.LD, // 46: LD r, BytePtr,
                                 new Param[] { CommandID.ByteReg | CommandID.Pos2, CommandID.BytePtr, },
                                 Flags = ParamFlags.ByteIndexAllowed,
                                 Prefix = 0x00, Base = 0x46, },

            new OpcodeEncoding { Function = CommandID.LD, // 70: LD BytePtr, r,
                                 new Param[] { CommandID.BytePtr, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.ByteIndexAllowed,
                                 Prefix = 0x00, Base = 0x70, },

            new OpcodeEncoding { Function = CommandID.LD, // F9: LD SP, (HL),
                                 new Param[] { CommandID.SP, CommandID.AddrReg, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xF9, },

            new OpcodeEncoding { Function = CommandID.LD, // ED43: LD (**), rr,
                                 new Param[] { CommandID.AddressPtr | CommandID.Immidate, CommandID.WordReg | CommandID.Pos3, },
                                 Flags = ParamFlags.NoIndexPrefix,
                                 Prefix = 0xED, Base = 0x43, },

            new OpcodeEncoding { Function = CommandID.LD, // ED47: LD I, A,
                                 new Param[] { CommandID.I, CommandID.A, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0x47, },

            new OpcodeEncoding { Function = CommandID.LD, // ED4B: LD rr, (**),
                                 new Param[] { CommandID.WordReg | CommandID.Pos3, CommandID.AddressPtr | CommandID.Immidate, },
                                 Flags = ParamFlags.NoIndexPrefix,
                                 Prefix = 0xED, Base = 0x4B, },

            new OpcodeEncoding { Function = CommandID.LD, // ED4F: LD R, A,
                                 new Param[] { CommandID.R, CommandID.A, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0x4F, },

            new OpcodeEncoding { Function = CommandID.LD, // ED57: LD A, I,
                                 new Param[] { CommandID.A, CommandID.I, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0x57, },

            new OpcodeEncoding { Function = CommandID.LD, // ED5F: LD A, R,
                                 new Param[] { CommandID.A, CommandID.R, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0x5F, },

            new OpcodeEncoding { Function = CommandID.LD, // ED63: LD (**), HL,
                                 new Param[] { CommandID.AddressPtr | CommandID.Immidate, CommandID.HL, },
                                 Flags = ParamFlags.Unoffical | ParamFlags.NoIndexPrefix,
                                 Prefix = 0xED, Base = 0x63, },

            new OpcodeEncoding { Function = CommandID.LD, // ED6B: LD HL, (**),
                                 new Param[] { CommandID.HL, CommandID.AddressPtr | CommandID.Immidate, },
                                 Flags = ParamFlags.Unoffical | ParamFlags.NoIndexPrefix,
                                 Prefix = 0xED, Base = 0x6B, },

            new OpcodeEncoding { Function = CommandID.LDD, // EDA8: LDD
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0xA8, },

            new OpcodeEncoding { Function = CommandID.LDDR, // EDB8: LDDR
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0xB8, },

            new OpcodeEncoding { Function = CommandID.LDI, // EDA0: LDI
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0xA0, },

            new OpcodeEncoding { Function = CommandID.LDIR, // EDB0: LDIR
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0xB0, },

            new OpcodeEncoding { Function = CommandID.NEG, // ED44: NEG A,
                                 new Param[] { CommandID.A, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0x44, },

            new OpcodeEncoding { Function = CommandID.NEG, // ED4C: NEG A,
                                 new Param[] { CommandID.A, },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x4C, },

            new OpcodeEncoding { Function = CommandID.NEG, // ED54: NEG A,
                                 new Param[] { CommandID.A, },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x54, },

            new OpcodeEncoding { Function = CommandID.NEG, // ED5C: NEG A,
                                 new Param[] { CommandID.A, },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x5C, },

            new OpcodeEncoding { Function = CommandID.NEG, // ED64: NEG A,
                                 new Param[] { CommandID.A, },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x64, },

            new OpcodeEncoding { Function = CommandID.NEG, // ED6C: NEG A,
                                 new Param[] { CommandID.A, },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x6C, },

            new OpcodeEncoding { Function = CommandID.NEG, // ED74: NEG A,
                                 new Param[] { CommandID.A, },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x74, },

            new OpcodeEncoding { Function = CommandID.NEG, // ED7C: NEG A,
                                 new Param[] { CommandID.A, },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x7C, },

            new OpcodeEncoding { Function = CommandID.NOP, // 00: NOP
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x00, },

            new OpcodeEncoding { Function = CommandID.OR, // B0: OR A, r,
                                 new Param[] { CommandID.A, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.ByteIndexAllowed,
                                 Prefix = 0x00, Base = 0xB0, },

            new OpcodeEncoding { Function = CommandID.OR, // B6: OR A, BytePtr,
                                 new Param[] { CommandID.A, CommandID.BytePtr, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xB6, },

            new OpcodeEncoding { Function = CommandID.OR, // F6: OR A, n,
                                 new Param[] { CommandID.A, CommandID.ByteImmidate | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xF6, },

            new OpcodeEncoding { Function = CommandID.OTDR, // EDBB: OTDR
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0xBB, },

            new OpcodeEncoding { Function = CommandID.OTIR, // EDB3: OTIR
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0xB3, },

            new OpcodeEncoding { Function = CommandID.OUT, // D3: OUT n, A,
                                 new Param[] { CommandID.ByteImmidate | CommandID.Immidate, CommandID.A, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xD3, },

            new OpcodeEncoding { Function = CommandID.OUT, // ED41: OUT C, r,
                                 new Param[] { CommandID.C, CommandID.ByteReg | CommandID.Pos2, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0x41, },

            new OpcodeEncoding { Function = CommandID.OUT, // ED71: OUT C, 0,
                                 new Param[] { CommandID.C, (CommandID)((int)CommandID.Encoded + 00), },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0x71, },

            new OpcodeEncoding { Function = CommandID.OUTD, // EDAB: OUTD
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0xAB, },

            new OpcodeEncoding { Function = CommandID.OUTI, // EDA3: OUTI
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0xA3, },

            new OpcodeEncoding { Function = CommandID.POP, // C1: POP rr,
                                 new Param[] { CommandID.WordRegAF | CommandID.Pos3, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xC1, },

            new OpcodeEncoding { Function = CommandID.PUSH, // C5: PUSH rr,
                                 new Param[] { CommandID.WordRegAF | CommandID.Pos3, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xC5, },

            new OpcodeEncoding { Function = CommandID.RES, // CB80: RES n, r,
                                 new Param[] { CommandID.Encoded | CommandID.Pos2, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x80, },

            new OpcodeEncoding { Function = CommandID.RES, // CB86: RES n, BytePtr,
                                 new Param[] { CommandID.Encoded | CommandID.Pos2, CommandID.BytePtr, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x86, },

            new OpcodeEncoding { Function = CommandID.RES, // CB80: RES n, (rx + *), r,
                                 new Param[] { CommandID.Encoded | CommandID.Pos2, CommandID.IndexPtr, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.Unoffical | ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x80, },

            new OpcodeEncoding { Function = CommandID.RET, // C0: RET cc,
                                 new Param[] { CommandID.Flags | CommandID.Pos2, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xC0, },

            new OpcodeEncoding { Function = CommandID.RET, // C9: RET
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xC9, },

            new OpcodeEncoding { Function = CommandID.RETI, // ED4D: RETI
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0x4D, },

            new OpcodeEncoding { Function = CommandID.RETN, // ED45: RETN
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0x45, },

            new OpcodeEncoding { Function = CommandID.RETN, // ED55: RETN
                                 new Param[] { },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x55, },

            new OpcodeEncoding { Function = CommandID.RETN, // ED5D: RETN
                                 new Param[] { },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x5D, },

            new OpcodeEncoding { Function = CommandID.RETN, // ED65: RETN
                                 new Param[] { },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x65, },

            new OpcodeEncoding { Function = CommandID.RETN, // ED6D: RETN
                                 new Param[] { },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x6D, },

            new OpcodeEncoding { Function = CommandID.RETN, // ED75: RETN
                                 new Param[] { },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x75, },

            new OpcodeEncoding { Function = CommandID.RETN, // ED7D: RETN
                                 new Param[] { },
                                 Flags = ParamFlags.Unoffical,
                                 Prefix = 0xED, Base = 0x7D, },

            new OpcodeEncoding { Function = CommandID.RL, // CB10: RL r,
                                 new Param[] { CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x10, },

            new OpcodeEncoding { Function = CommandID.RL, // CB16: RL BytePtr,
                                 new Param[] { CommandID.BytePtr, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x16, },

            new OpcodeEncoding { Function = CommandID.RL, // CB10: RL (rx + *), r,
                                 new Param[] { CommandID.IndexPtr, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.Unoffical | ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x10, },

            new OpcodeEncoding { Function = CommandID.RLA, // 17: RLA
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x17, },

            new OpcodeEncoding { Function = CommandID.RLC, // CB00: RLC r,
                                 new Param[] { CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x00, },

            new OpcodeEncoding { Function = CommandID.RLC, // CB06: RLC BytePtr,
                                 new Param[] { CommandID.BytePtr, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x06, },

            new OpcodeEncoding { Function = CommandID.RLC, // CB00: RLC (rx + *), r,
                                 new Param[] { CommandID.IndexPtr, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.Unoffical | ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x00, },

            new OpcodeEncoding { Function = CommandID.RLCA, // 07: RLCA
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x07, },

            new OpcodeEncoding { Function = CommandID.RLD, // ED6F: RLD
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0x6F, },

            new OpcodeEncoding { Function = CommandID.RR, // CB18: RR r,
                                 new Param[] { CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x18, },

            new OpcodeEncoding { Function = CommandID.RR, // CB1E: RR BytePtr,
                                 new Param[] { CommandID.BytePtr, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x1E, },

            new OpcodeEncoding { Function = CommandID.RR, // CB18: RR (rx + *), r,
                                 new Param[] { CommandID.IndexPtr, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.Unoffical | ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x18, },

            new OpcodeEncoding { Function = CommandID.RRA, // 1F: RRA
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x1F, },

            new OpcodeEncoding { Function = CommandID.RRC, // CB08: RRC r,
                                 new Param[] { CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x08, },

            new OpcodeEncoding { Function = CommandID.RRC, // CB0E: RRC BytePtr,
                                 new Param[] { CommandID.BytePtr, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x0E, },

            new OpcodeEncoding { Function = CommandID.RRC, // CB08: RRC (rx + *), r,
                                 new Param[] { CommandID.IndexPtr, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.Unoffical | ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x08, },

            new OpcodeEncoding { Function = CommandID.RRCA, // 0F: RRCA
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x0F, },

            new OpcodeEncoding { Function = CommandID.RRD, // ED67: RRD
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0xED, Base = 0x67, },

            new OpcodeEncoding { Function = CommandID.RST, // C7: RST n,
                                 new Param[] { CommandID.Encoded | CommandID.Pos2, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xC7, },

            new OpcodeEncoding { Function = CommandID.SBC, // 98: SBC A, r,
                                 new Param[] { CommandID.A, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.ByteIndexAllowed,
                                 Prefix = 0x00, Base = 0x98, },

            new OpcodeEncoding { Function = CommandID.SBC, // 9E: SBC A, BytePtr,
                                 new Param[] { CommandID.A, CommandID.BytePtr, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x9E, },

            new OpcodeEncoding { Function = CommandID.SBC, // DE: SBC A, n,
                                 new Param[] { CommandID.A, CommandID.ByteImmidate | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xDE, },

            new OpcodeEncoding { Function = CommandID.SBC, // ED42: SBC HL, rr,
                                 new Param[] { CommandID.HL, CommandID.WordReg | CommandID.Pos3, },
                                 Flags = ParamFlags.NoIndexPrefix,
                                 Prefix = 0xED, Base = 0x42, },

            new OpcodeEncoding { Function = CommandID.SCF, // 37: SCF
                                 new Param[] { },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x37, },

            new OpcodeEncoding { Function = CommandID.SET, // CBC0: SET n, r,
                                 new Param[] { CommandID.Encoded | CommandID.Pos2, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0xC0, },

            new OpcodeEncoding { Function = CommandID.SET, // CBC6: SET n, BytePtr,
                                 new Param[] { CommandID.Encoded | CommandID.Pos2, CommandID.BytePtr, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0xC6, },

            new OpcodeEncoding { Function = CommandID.SET, // CBC0: SET n, (rx + *), r,
                                 new Param[] { CommandID.Encoded | CommandID.Pos2, CommandID.IndexPtr, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.Unoffical | ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0xC0, },

            new OpcodeEncoding { Function = CommandID.SLA, // CB20: SLA r,
                                 new Param[] { CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x20, },

            new OpcodeEncoding { Function = CommandID.SLA, // CB26: SLA BytePtr,
                                 new Param[] { CommandID.BytePtr, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x26, },

            new OpcodeEncoding { Function = CommandID.SLA, // CB20: SLA (rx + *), r,
                                 new Param[] { CommandID.IndexPtr, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.Unoffical | ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x20, },

            new OpcodeEncoding { Function = CommandID.SLL, // CB30: SLL r,
                                 new Param[] { CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x30, },

            new OpcodeEncoding { Function = CommandID.SLL, // CB36: SLL BytePtr,
                                 new Param[] { CommandID.BytePtr, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x36, },

            new OpcodeEncoding { Function = CommandID.SLL, // CB30: SLL (rx + *), r,
                                 new Param[] { CommandID.IndexPtr, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.Unoffical | ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x30, },

            new OpcodeEncoding { Function = CommandID.SRA, // CB28: SRA r,
                                 new Param[] { CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x28, },

            new OpcodeEncoding { Function = CommandID.SRA, // CB2E: SRA BytePtr,
                                 new Param[] { CommandID.BytePtr, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x2E, },

            new OpcodeEncoding { Function = CommandID.SRA, // CB28: SRA (rx + *), r,
                                 new Param[] { CommandID.IndexPtr, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.Unoffical | ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x28, },

            new OpcodeEncoding { Function = CommandID.SRL, // CB38: SRL r,
                                 new Param[] { CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x38, },

            new OpcodeEncoding { Function = CommandID.SRL, // CB3E: SRL BytePtr,
                                 new Param[] { CommandID.BytePtr, },
                                 Flags = ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x3E, },

            new OpcodeEncoding { Function = CommandID.SRL, // CB38: SRL (rx + *), r,
                                 new Param[] { CommandID.IndexPtr, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.Unoffical | ParamFlags.EmbededIndex,
                                 Prefix = 0xCB, Base = 0x38, },

            new OpcodeEncoding { Function = CommandID.SUB, // 90: SUB A, r,
                                 new Param[] { CommandID.A, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.ByteIndexAllowed,
                                 Prefix = 0x00, Base = 0x90, },

            new OpcodeEncoding { Function = CommandID.SUB, // 96: SUB A, BytePtr,
                                 new Param[] { CommandID.A, CommandID.BytePtr, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0x96, },

            new OpcodeEncoding { Function = CommandID.SUB, // D6: SUB A, n,
                                 new Param[] { CommandID.A, CommandID.ByteImmidate | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xD6, },

            new OpcodeEncoding { Function = CommandID.XOR, // A8: XOR A, r,
                                 new Param[] { CommandID.A, CommandID.ByteReg | CommandID.Pos1, },
                                 Flags = ParamFlags.ByteIndexAllowed,
                                 Prefix = 0x00, Base = 0xA8, },

            new OpcodeEncoding { Function = CommandID.XOR, // AE: XOR A, BytePtr,
                                 new Param[] { CommandID.A, CommandID.BytePtr, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xAE, },

            new OpcodeEncoding { Function = CommandID.XOR, // EE: XOR A, n,
                                 new Param[] { CommandID.A, CommandID.ByteImmidate | CommandID.Immidate, },
                                 Flags = ParamFlag.None,
                                 Prefix = 0x00, Base = 0xEE, },

        };
    }
}
