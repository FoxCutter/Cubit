using System.Collections.Generic;

namespace OpcodeData
{
    public static partial class z80Data
    {
        public static SortedList<CommandID, OpcodeEntry[]> Encoding = new SortedList<CommandID, OpcodeEntry[]>
        {
            {
               CommandID.ADC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x88, Name = CommandID.ADC, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 88: ADC A, r
                  new OpcodeEntry { Encoding = 0x8E, Name = CommandID.ADC, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // 8E: ADC A, (HL)
                  new OpcodeEntry { Encoding = 0xCE, Name = CommandID.ADC, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // CEnn: ADC A, nn
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x4A, Name = CommandID.ADC, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // ED4A: ADC HL, rr
                  new OpcodeEntry { Index = true, Encoding = 0x88, Name = CommandID.ADC, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Source}, }, }, // iz88: *ADC A, Izb
                  new OpcodeEntry { Index = true, Encoding = 0x8E, Name = CommandID.ADC, Length = 3, Cycles = 5, TStates = 19, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // iz8Eoo: ADC A, (Iz + oo)
               }
            },
            {
               CommandID.ADD, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x09, Name = CommandID.ADD, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // 09: ADD HL, rr
                  new OpcodeEntry { Encoding = 0x80, Name = CommandID.ADD, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 80: ADD A, r
                  new OpcodeEntry { Encoding = 0x86, Name = CommandID.ADD, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // 86: ADD A, (HL)
                  new OpcodeEntry { Encoding = 0xC6, Name = CommandID.ADD, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // C6nn: ADD A, nn
                  new OpcodeEntry { Index = true, Encoding = 0x09, Name = CommandID.ADD, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // iz09: ADD Iz, rr
                  new OpcodeEntry { Index = true, Encoding = 0x29, Name = CommandID.ADD, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegister}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegister}, }, }, // iz29: ADD Iz, Iz
                  new OpcodeEntry { Index = true, Encoding = 0x80, Name = CommandID.ADD, Status = OpcodeStatus.Undocumented, Length = 1, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Source}, }, }, // iz80: *ADD A, Izb
                  new OpcodeEntry { Index = true, Encoding = 0x86, Name = CommandID.ADD, Length = 3, Cycles = 5, TStates = 19, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // iz86oo: ADD A, (Iz + oo)
               }
            },
            {
               CommandID.AND, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xA0, Name = CommandID.AND, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // A0: AND A, r
                  new OpcodeEntry { Encoding = 0xA0, Name = CommandID.AND, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // A0: AND r
                  new OpcodeEntry { Encoding = 0xA6, Name = CommandID.AND, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // A6: AND A, (HL)
                  new OpcodeEntry { Encoding = 0xA6, Name = CommandID.AND, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // A6: AND (HL)
                  new OpcodeEntry { Encoding = 0xE6, Name = CommandID.AND, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // E6nn: AND A, nn
                  new OpcodeEntry { Encoding = 0xE6, Name = CommandID.AND, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // E6nn: AND nn
                  new OpcodeEntry { Index = true, Encoding = 0xA0, Name = CommandID.AND, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Source}, }, }, // izA0: *AND A, Izb
                  new OpcodeEntry { Index = true, Encoding = 0xA0, Name = CommandID.AND, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Source}, }, }, // izA0: *AND Izb
                  new OpcodeEntry { Index = true, Encoding = 0xA6, Name = CommandID.AND, Length = 3, Cycles = 5, TStates = 19, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izA6oo: AND A, (Iz + oo)
                  new OpcodeEntry { Index = true, Encoding = 0xA6, Name = CommandID.AND, Length = 3, Cycles = 5, TStates = 19, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izA6oo: AND (Iz + oo)
               }
            },
            {
               CommandID.BIT, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x40, Name = CommandID.BIT, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB40: BIT e, r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x46, Name = CommandID.BIT, Length = 2, Cycles = 3, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB46: BIT e, (HL)
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x40, Name = CommandID.BIT, Status = OpcodeStatus.Undocumented, Length = 4, Cycles = 5, TStates = 20, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izCBoo40: *BIT e, (Iz + oo)
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x46, Name = CommandID.BIT, Length = 4, Cycles = 5, TStates = 20, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izCBoo46: BIT e, (Iz + oo)
               }
            },
            {
               CommandID.CALL, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC4, Name = CommandID.CALL, Length = 3, Cycles = 5, TStates = 17, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.FlagsAny, Type = ParameterType.Flag, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // C4nnnn: CALL ff, nnnn
                  new OpcodeEntry { Encoding = 0xCD, Name = CommandID.CALL, Length = 3, Cycles = 5, TStates = 17, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // CDnnnn: CALL nnnn
               }
            },
            {
               CommandID.CCF, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x3F, Name = CommandID.CCF, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {}, }, // 3F: CCF
               }
            },
            {
               CommandID.CP, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xB8, Name = CommandID.CP, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // B8: CP A, r
                  new OpcodeEntry { Encoding = 0xB8, Name = CommandID.CP, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // B8: CP r
                  new OpcodeEntry { Encoding = 0xBE, Name = CommandID.CP, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // BE: CP A, (HL)
                  new OpcodeEntry { Encoding = 0xBE, Name = CommandID.CP, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // BE: CP (HL)
                  new OpcodeEntry { Encoding = 0xFE, Name = CommandID.CP, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // FEnn: CP A, nn
                  new OpcodeEntry { Encoding = 0xFE, Name = CommandID.CP, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // FEnn: CP nn
                  new OpcodeEntry { Index = true, Encoding = 0xB8, Name = CommandID.CP, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Source}, }, }, // izB8: *CP A, Izb
                  new OpcodeEntry { Index = true, Encoding = 0xB8, Name = CommandID.CP, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Source}, }, }, // izB8: *CP Izb
                  new OpcodeEntry { Index = true, Encoding = 0xBE, Name = CommandID.CP, Length = 3, Cycles = 5, TStates = 19, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izBEoo: CP A, (Iz + oo)
                  new OpcodeEntry { Index = true, Encoding = 0xBE, Name = CommandID.CP, Length = 3, Cycles = 5, TStates = 19, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izBEoo: CP (Iz + oo)
               }
            },
            {
               CommandID.CPD, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0xA9, Name = CommandID.CPD, Length = 2, Cycles = 4, TStates = 16, Arguments = new ParamEntry[] {}, }, // EDA9: CPD
               }
            },
            {
               CommandID.CPDR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0xB9, Name = CommandID.CPDR, Length = 2, Cycles = 5, TStates = 21, Arguments = new ParamEntry[] {}, }, // EDB9: CPDR
               }
            },
            {
               CommandID.CPI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0xA1, Name = CommandID.CPI, Length = 2, Cycles = 4, TStates = 16, Arguments = new ParamEntry[] {}, }, // EDA1: CPI
               }
            },
            {
               CommandID.CPIR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0xB1, Name = CommandID.CPIR, Length = 2, Cycles = 5, TStates = 21, Arguments = new ParamEntry[] {}, }, // EDB1: CPIR
               }
            },
            {
               CommandID.CPL, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x2F, Name = CommandID.CPL, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // 2F: CPL A
                  new OpcodeEntry { Encoding = 0x2F, Name = CommandID.CPL, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 2F: CPL
               }
            },
            {
               CommandID.DAA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x27, Name = CommandID.DAA, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 27: DAA
               }
            },
            {
               CommandID.DEC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x05, Name = CommandID.DEC, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, }, }, // 05: DEC r
                  new OpcodeEntry { Encoding = 0x0B, Name = CommandID.DEC, Length = 1, Cycles = 1, TStates = 6, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // 0B: DEC rr
                  new OpcodeEntry { Encoding = 0x35, Name = CommandID.DEC, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // 35: DEC (HL)
                  new OpcodeEntry { Index = true, Encoding = 0x05, Name = CommandID.DEC, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Dest}, }, }, // iz05: *DEC Izb
                  new OpcodeEntry { Index = true, Encoding = 0x2B, Name = CommandID.DEC, Length = 2, Cycles = 2, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegister}, }, }, // iz2B: DEC Iz
                  new OpcodeEntry { Index = true, Encoding = 0x35, Name = CommandID.DEC, Length = 3, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // iz35oo: DEC (Iz + oo)
               }
            },
            {
               CommandID.DI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xF3, Name = CommandID.DI, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {}, }, // F3: DI
               }
            },
            {
               CommandID.DJNZ, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x10, Name = CommandID.DJNZ, Length = 2, Cycles = 3, TStates = 13, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Displacment, Encoding = EncodingType.ByteImmidate}, }, }, // 10nn: DJNZ e-2
               }
            },
            {
               CommandID.EI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xFB, Name = CommandID.EI, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {}, }, // FB: EI
               }
            },
            {
               CommandID.EX, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x08, Name = CommandID.EX, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_AF, Type = ParameterType.WordRegister}, new ParamEntry { Param = ParameterID.WordReg_AF_Alt, Type = ParameterType.WordRegister}, }, }, // 08: EX AF, AF'
                  new OpcodeEntry { Encoding = 0xE3, Name = CommandID.EX, Length = 1, Cycles = 5, TStates = 19, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_SP, Type = ParameterType.WordRegisterPointer}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister}, }, }, // E3: EX (SP), HL
                  new OpcodeEntry { Encoding = 0xEB, Name = CommandID.EX, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_DE, Type = ParameterType.WordRegister}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister}, }, }, // EB: EX DE, HL
                  new OpcodeEntry { Index = true, Encoding = 0xE3, Name = CommandID.EX, Length = 2, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_SP, Type = ParameterType.WordRegisterPointer}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegister}, }, }, // izE3: EX (SP), Iz
               }
            },
            {
               CommandID.EXX, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xD9, Name = CommandID.EXX, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {}, }, // D9: EXX
               }
            },
            {
               CommandID.HALT, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x76, Name = CommandID.HALT, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {}, }, // 76: HALT
               }
            },
            {
               CommandID.IM, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x46, Name = CommandID.IM, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Value0, Type = ParameterType.Value}, }, }, // ED46: IM 0
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x56, Name = CommandID.IM, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Value1, Type = ParameterType.Value}, }, }, // ED56: IM 1
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x5E, Name = CommandID.IM, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Value2, Type = ParameterType.Value}, }, }, // ED5E: IM 2
               }
            },
            {
               CommandID.IN, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xDB, Name = CommandID.IN, Length = 2, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // DBnn: IN A, nn
                  new OpcodeEntry { Encoding = 0xDB, Name = CommandID.IN, Length = 2, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // DBnn: IN A, nn
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x40, Name = CommandID.IN, Length = 2, Cycles = 3, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.ByteReg_C, Type = ParameterType.ByteRegister}, }, }, // ED40: IN r, C
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x40, Name = CommandID.IN, Length = 2, Cycles = 3, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.ByteReg_C, Type = ParameterType.ByteRegister}, }, }, // ED40: IN r, C
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x70, Name = CommandID.IN, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_C, Type = ParameterType.ByteRegister}, }, }, // ED70: *IN C
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x70, Name = CommandID.IN, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_C, Type = ParameterType.ByteRegister}, }, }, // ED70: *IN C
               }
            },
            {
               CommandID.INC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x03, Name = CommandID.INC, Length = 1, Cycles = 1, TStates = 6, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // 03: INC rr
                  new OpcodeEntry { Encoding = 0x04, Name = CommandID.INC, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, }, }, // 04: INC r
                  new OpcodeEntry { Encoding = 0x34, Name = CommandID.INC, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // 34: INC (HL)
                  new OpcodeEntry { Index = true, Encoding = 0x04, Name = CommandID.INC, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Dest}, }, }, // iz04: *INC Izb
                  new OpcodeEntry { Index = true, Encoding = 0x23, Name = CommandID.INC, Length = 2, Cycles = 2, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegister}, }, }, // iz23: INC Iz
                  new OpcodeEntry { Index = true, Encoding = 0x34, Name = CommandID.INC, Length = 3, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // iz34oo: INC (Iz + oo)
               }
            },
            {
               CommandID.IND, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0xAA, Name = CommandID.IND, Length = 2, Cycles = 4, TStates = 16, Arguments = new ParamEntry[] {}, }, // EDAA: IND
               }
            },
            {
               CommandID.INDR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0xBA, Name = CommandID.INDR, Length = 2, Cycles = 5, TStates = 21, Arguments = new ParamEntry[] {}, }, // EDBA: INDR
               }
            },
            {
               CommandID.INI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0xA2, Name = CommandID.INI, Length = 2, Cycles = 4, TStates = 16, Arguments = new ParamEntry[] {}, }, // EDA2: INI
               }
            },
            {
               CommandID.INIR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0xB2, Name = CommandID.INIR, Length = 2, Cycles = 5, TStates = 21, Arguments = new ParamEntry[] {}, }, // EDB2: INIR
               }
            },
            {
               CommandID.JP, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC2, Name = CommandID.JP, Length = 3, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.FlagsAny, Type = ParameterType.Flag, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // C2nnnn: JP ff, nnnn
                  new OpcodeEntry { Encoding = 0xC3, Name = CommandID.JP, Length = 3, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // C3nnnn: JP nnnn
                  new OpcodeEntry { Encoding = 0xE9, Name = CommandID.JP, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister}, }, }, // E9: JP HL
                  new OpcodeEntry { Index = true, Encoding = 0xE9, Name = CommandID.JP, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegister}, }, }, // izE9: JP Iz
               }
            },
            {
               CommandID.JR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x18, Name = CommandID.JR, Length = 2, Cycles = 3, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Displacment, Encoding = EncodingType.ByteImmidate}, }, }, // 18nn: JR e-2
                  new OpcodeEntry { Encoding = 0x20, Name = CommandID.JR, Length = 2, Cycles = 3, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.FlagsAny, Type = ParameterType.HalfFlag, Encoding = EncodingType.HalfFlag}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Displacment, Encoding = EncodingType.ByteImmidate}, }, }, // 20nn: JR ff, e-2
               }
            },
            {
               CommandID.LD, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x01, Name = CommandID.LD, Length = 3, Cycles = 2, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Value, Encoding = EncodingType.WordImmidate}, }, }, // 01nnnn: LD rr, nnnn
                  new OpcodeEntry { Encoding = 0x02, Name = CommandID.LD, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_BD, Type = ParameterType.WordRegisterPointer, Encoding = EncodingType.WordReg}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // 02: LD (rp), A
                  new OpcodeEntry { Encoding = 0x06, Name = CommandID.LD, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // 06nn: LD r, nn
                  new OpcodeEntry { Encoding = 0x0A, Name = CommandID.LD, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_BD, Type = ParameterType.WordRegisterPointer, Encoding = EncodingType.WordReg}, }, }, // 0A: LD A, (rp)
                  new OpcodeEntry { Encoding = 0x22, Name = CommandID.LD, Length = 3, Cycles = 5, TStates = 16, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.AddressPointer, Encoding = EncodingType.WordImmidate}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister}, }, }, // 22nnnn: LD (nnnn), HL
                  new OpcodeEntry { Encoding = 0x2A, Name = CommandID.LD, Length = 3, Cycles = 5, TStates = 16, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.AddressPointer, Encoding = EncodingType.WordImmidate}, }, }, // 2Annnn: LD HL, (nnnn)
                  new OpcodeEntry { Encoding = 0x32, Name = CommandID.LD, Length = 3, Cycles = 4, TStates = 13, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.AddressPointer, Encoding = EncodingType.WordImmidate}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // 32nnnn: LD (nnnn), A
                  new OpcodeEntry { Encoding = 0x36, Name = CommandID.LD, Length = 2, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // 36nn: LD (HL), nn
                  new OpcodeEntry { Encoding = 0x3A, Name = CommandID.LD, Length = 3, Cycles = 4, TStates = 13, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.AddressPointer, Encoding = EncodingType.WordImmidate}, }, }, // 3Annnn: LD A, (nnnn)
                  new OpcodeEntry { Encoding = 0x40, Name = CommandID.LD, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 40: LD r, r
                  new OpcodeEntry { Encoding = 0x46, Name = CommandID.LD, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // 46: LD r, (HL)
                  new OpcodeEntry { Encoding = 0x70, Name = CommandID.LD, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 70: LD (HL), r
                  new OpcodeEntry { Encoding = 0xF9, Name = CommandID.LD, Length = 1, Cycles = 1, TStates = 6, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_SP, Type = ParameterType.WordRegister}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister}, }, }, // F9: LD SP, HL
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x43, Name = CommandID.LD, Length = 4, Cycles = 6, TStates = 20, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.AddressPointer, Encoding = EncodingType.WordImmidate}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // ED43nnnn: LD (nnnn), rr
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x47, Name = CommandID.LD, Length = 2, Cycles = 2, TStates = 9, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_I, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // ED47: LD I, A
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x4B, Name = CommandID.LD, Length = 4, Cycles = 6, TStates = 20, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.AddressPointer, Encoding = EncodingType.WordImmidate}, }, }, // ED4Bnnnn: LD rr, (nnnn)
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x4F, Name = CommandID.LD, Length = 2, Cycles = 2, TStates = 9, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_R, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // ED4F: LD R, A
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x57, Name = CommandID.LD, Length = 2, Cycles = 2, TStates = 9, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ByteReg_I, Type = ParameterType.ByteRegister}, }, }, // ED57: LD A, I
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x5F, Name = CommandID.LD, Length = 2, Cycles = 2, TStates = 9, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ByteReg_R, Type = ParameterType.ByteRegister}, }, }, // ED5F: LD A, R
                  new OpcodeEntry { Index = true, Encoding = 0x06, Name = CommandID.LD, Status = OpcodeStatus.Undocumented, Length = 3, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // iz06nn: *LD Izb, nn
                  new OpcodeEntry { Index = true, Encoding = 0x21, Name = CommandID.LD, Length = 4, Cycles = 4, TStates = 14, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegister}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Value, Encoding = EncodingType.WordImmidate}, }, }, // iz21nnnn: LD Iz, nnnn
                  new OpcodeEntry { Index = true, Encoding = 0x22, Name = CommandID.LD, Length = 4, Cycles = 6, TStates = 20, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.AddressPointer, Encoding = EncodingType.WordImmidate}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegister}, }, }, // iz22nnnn: LD (nnnn), Iz
                  new OpcodeEntry { Index = true, Encoding = 0x2A, Name = CommandID.LD, Length = 4, Cycles = 6, TStates = 20, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegister}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.AddressPointer, Encoding = EncodingType.WordImmidate}, }, }, // iz2Annnn: LD Iz, (nnnn)
                  new OpcodeEntry { Index = true, Encoding = 0x36, Name = CommandID.LD, Length = 4, Cycles = 5, TStates = 19, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // iz36oonn: LD (Iz + oo), nn
                  new OpcodeEntry { Index = true, Encoding = 0x46, Name = CommandID.LD, Length = 3, Cycles = 5, TStates = 19, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // iz46oo: LD r, (Iz + oo)
                  new OpcodeEntry { Index = true, Encoding = 0x70, Name = CommandID.LD, Length = 3, Cycles = 5, TStates = 19, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // iz70oo: LD (Iz + oo), r
                  new OpcodeEntry { Index = true, Encoding = 0xF9, Name = CommandID.LD, Length = 2, Cycles = 2, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_SP, Type = ParameterType.WordRegister}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegister}, }, }, // izF9: LD SP, Iz
               }
            },
            {
               CommandID.LDD, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0xA8, Name = CommandID.LDD, Length = 2, Cycles = 4, TStates = 16, Arguments = new ParamEntry[] {}, }, // EDA8: LDD
               }
            },
            {
               CommandID.LDDR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0xB8, Name = CommandID.LDDR, Length = 2, Cycles = 5, TStates = 21, Arguments = new ParamEntry[] {}, }, // EDB8: LDDR
               }
            },
            {
               CommandID.LDI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0xA0, Name = CommandID.LDI, Length = 2, Cycles = 4, TStates = 16, Arguments = new ParamEntry[] {}, }, // EDA0: LDI
               }
            },
            {
               CommandID.LDIR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0xB0, Name = CommandID.LDIR, Length = 2, Cycles = 5, TStates = 21, Arguments = new ParamEntry[] {}, }, // EDB0: LDIR
               }
            },
            {
               CommandID.LDX, new OpcodeEntry[]
               {
                  new OpcodeEntry { Index = true, Encoding = 0x40, Name = CommandID.LDX, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Source}, }, }, // iz40: *LDX r, Izb
                  new OpcodeEntry { Index = true, Encoding = 0x40, Name = CommandID.LDX, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // iz40: *LDX Izb, r
               }
            },
            {
               CommandID.NEG, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x44, Name = CommandID.NEG, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // ED44: NEG A
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x44, Name = CommandID.NEG, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // ED44: NEG
               }
            },
            {
               CommandID.NOP, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x00, Name = CommandID.NOP, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {}, }, // 00: NOP
               }
            },
            {
               CommandID.OR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xB0, Name = CommandID.OR, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // B0: OR A, r
                  new OpcodeEntry { Encoding = 0xB0, Name = CommandID.OR, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // B0: OR r
                  new OpcodeEntry { Encoding = 0xB6, Name = CommandID.OR, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // B6: OR A, (HL)
                  new OpcodeEntry { Encoding = 0xB6, Name = CommandID.OR, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // B6: OR (HL)
                  new OpcodeEntry { Encoding = 0xF6, Name = CommandID.OR, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // F6nn: OR A, nn
                  new OpcodeEntry { Encoding = 0xF6, Name = CommandID.OR, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // F6nn: OR nn
                  new OpcodeEntry { Index = true, Encoding = 0xB0, Name = CommandID.OR, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Source}, }, }, // izB0: *OR A, Izb
                  new OpcodeEntry { Index = true, Encoding = 0xB0, Name = CommandID.OR, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Source}, }, }, // izB0: *OR Izb
                  new OpcodeEntry { Index = true, Encoding = 0xB6, Name = CommandID.OR, Length = 3, Cycles = 5, TStates = 19, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izB6oo: OR A, (Iz + oo)
                  new OpcodeEntry { Index = true, Encoding = 0xB6, Name = CommandID.OR, Length = 3, Cycles = 5, TStates = 19, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izB6oo: OR (Iz + oo)
               }
            },
            {
               CommandID.OTDR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0xBB, Name = CommandID.OTDR, Length = 2, Cycles = 5, TStates = 21, Arguments = new ParamEntry[] {}, }, // EDBB: OTDR
               }
            },
            {
               CommandID.OTIR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0xB3, Name = CommandID.OTIR, Length = 2, Cycles = 5, TStates = 21, Arguments = new ParamEntry[] {}, }, // EDB3: OTIR
               }
            },
            {
               CommandID.OUT, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xD3, Name = CommandID.OUT, Length = 2, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // D3nn: OUT nn, A
                  new OpcodeEntry { Encoding = 0xD3, Name = CommandID.OUT, Length = 2, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // D3nn: OUT nn, A
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x41, Name = CommandID.OUT, Length = 2, Cycles = 3, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_C, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, }, }, // ED41: OUT C, r
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x41, Name = CommandID.OUT, Length = 2, Cycles = 3, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_C, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, }, }, // ED41: OUT C, r
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x71, Name = CommandID.OUT, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_C, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.Value0, Type = ParameterType.Value}, }, }, // ED71: *OUT C, 0
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x71, Name = CommandID.OUT, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_C, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.Value0, Type = ParameterType.Value}, }, }, // ED71: *OUT C, 0
               }
            },
            {
               CommandID.OUTD, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0xAB, Name = CommandID.OUTD, Length = 2, Cycles = 4, TStates = 16, Arguments = new ParamEntry[] {}, }, // EDAB: OUTD
               }
            },
            {
               CommandID.OUTI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0xA3, Name = CommandID.OUTI, Length = 2, Cycles = 4, TStates = 16, Arguments = new ParamEntry[] {}, }, // EDA3: OUTI
               }
            },
            {
               CommandID.POP, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC1, Name = CommandID.POP, Length = 1, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // C1: POP rr
                  new OpcodeEntry { Encoding = 0xF1, Name = CommandID.POP, Length = 1, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_AF, Type = ParameterType.WordRegister}, }, }, // F1: POP AF
                  new OpcodeEntry { Index = true, Encoding = 0xE1, Name = CommandID.POP, Length = 2, Cycles = 4, TStates = 14, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegister}, }, }, // izE1: POP Iz
               }
            },
            {
               CommandID.PUSH, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC5, Name = CommandID.PUSH, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // C5: PUSH rr
                  new OpcodeEntry { Encoding = 0xF5, Name = CommandID.PUSH, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_AF, Type = ParameterType.WordRegister}, }, }, // F5: PUSH AF
                  new OpcodeEntry { Index = true, Encoding = 0xE5, Name = CommandID.PUSH, Length = 2, Cycles = 5, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegister}, }, }, // izE5: PUSH Iz
               }
            },
            {
               CommandID.RES, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x80, Name = CommandID.RES, Length = 2, Cycles = 4, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB80: RES e, r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x86, Name = CommandID.RES, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB86: RES e, (HL)
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x80, Name = CommandID.RES, Status = OpcodeStatus.Undocumented, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // izCBoo80: *RES e, (Iz + oo), r
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x86, Name = CommandID.RES, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izCBoo86: RES e, (Iz + oo)
               }
            },
            {
               CommandID.RET, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC0, Name = CommandID.RET, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.FlagsAny, Type = ParameterType.Flag, Encoding = EncodingType.Dest}, }, }, // C0: RET ff
                  new OpcodeEntry { Encoding = 0xC9, Name = CommandID.RET, Length = 1, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {}, }, // C9: RET
               }
            },
            {
               CommandID.RETI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x4D, Name = CommandID.RETI, Length = 2, Cycles = 4, TStates = 14, Arguments = new ParamEntry[] {}, }, // ED4D: RETI
               }
            },
            {
               CommandID.RETN, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x45, Name = CommandID.RETN, Length = 2, Cycles = 4, TStates = 14, Arguments = new ParamEntry[] {}, }, // ED45: RETN
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x55, Name = CommandID.RETN, Length = 2, Cycles = 4, TStates = 14, Arguments = new ParamEntry[] {}, }, // ED55: RETN
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x5D, Name = CommandID.RETN, Length = 2, Cycles = 4, TStates = 14, Arguments = new ParamEntry[] {}, }, // ED5D: RETN
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x65, Name = CommandID.RETN, Length = 2, Cycles = 4, TStates = 14, Arguments = new ParamEntry[] {}, }, // ED65: RETN
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x6D, Name = CommandID.RETN, Length = 2, Cycles = 4, TStates = 14, Arguments = new ParamEntry[] {}, }, // ED6D: RETN
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x75, Name = CommandID.RETN, Length = 2, Cycles = 4, TStates = 14, Arguments = new ParamEntry[] {}, }, // ED75: RETN
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x7D, Name = CommandID.RETN, Length = 2, Cycles = 4, TStates = 14, Arguments = new ParamEntry[] {}, }, // ED7D: RETN
               }
            },
            {
               CommandID.RL, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x17, Name = CommandID.RL, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // 17: RL A
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x10, Name = CommandID.RL, Length = 2, Cycles = 8, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB10: RL r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x16, Name = CommandID.RL, Length = 2, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB16: RL (HL)
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x10, Name = CommandID.RL, Status = OpcodeStatus.Undocumented, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // izCBoo10: *RL (Iz + oo), r
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x16, Name = CommandID.RL, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izCBoo16: RL (Iz + oo)
               }
            },
            {
               CommandID.RLA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x17, Name = CommandID.RLA, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 17: RLA
               }
            },
            {
               CommandID.RLC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x07, Name = CommandID.RLC, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // 07: RLC A
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x00, Name = CommandID.RLC, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB00: RLC r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x06, Name = CommandID.RLC, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB06: RLC (HL)
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x00, Name = CommandID.RLC, Status = OpcodeStatus.Undocumented, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // izCBoo00: *RLC (Iz + oo), r
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x06, Name = CommandID.RLC, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izCBoo06: RLC (Iz + oo)
               }
            },
            {
               CommandID.RLCA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x07, Name = CommandID.RLCA, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 07: RLCA
               }
            },
            {
               CommandID.RLD, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x6F, Name = CommandID.RLD, Length = 2, Cycles = 5, TStates = 18, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // ED6F: RLD A
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x6F, Name = CommandID.RLD, Length = 2, Cycles = 5, TStates = 18, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // ED6F: RLD
               }
            },
            {
               CommandID.RR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x1F, Name = CommandID.RR, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // 1F: RR A
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x18, Name = CommandID.RR, Length = 2, Cycles = 8, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB18: RR r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x1E, Name = CommandID.RR, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB1E: RR (HL)
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x18, Name = CommandID.RR, Status = OpcodeStatus.Undocumented, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // izCBoo18: *RR (Iz + oo), r
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x1E, Name = CommandID.RR, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izCBoo1E: RR (Iz + oo)
               }
            },
            {
               CommandID.RRA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x1F, Name = CommandID.RRA, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 1F: RRA
               }
            },
            {
               CommandID.RRC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x0F, Name = CommandID.RRC, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // 0F: RRC A
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x08, Name = CommandID.RRC, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB08: RRC r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x0E, Name = CommandID.RRC, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB0E: RRC (HL)
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x08, Name = CommandID.RRC, Status = OpcodeStatus.Undocumented, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // izCBoo08: *RRC (Iz + oo), r
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x0E, Name = CommandID.RRC, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izCBoo0E: RRC (Iz + oo)
               }
            },
            {
               CommandID.RRCA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x0F, Name = CommandID.RRCA, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 0F: RRCA
               }
            },
            {
               CommandID.RRD, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x67, Name = CommandID.RRD, Length = 2, Cycles = 5, TStates = 18, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // ED67: RRD A
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x67, Name = CommandID.RRD, Length = 2, Cycles = 5, TStates = 18, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // ED67: RRD
               }
            },
            {
               CommandID.RST, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC7, Name = CommandID.RST, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.RstValue, Encoding = EncodingType.Dest}, }, }, // C7: RST e
               }
            },
            {
               CommandID.SBC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x98, Name = CommandID.SBC, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 98: SBC A, r
                  new OpcodeEntry { Encoding = 0x9E, Name = CommandID.SBC, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // 9E: SBC A, (HL)
                  new OpcodeEntry { Encoding = 0xDE, Name = CommandID.SBC, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // DEnn: SBC A, nn
                  new OpcodeEntry { Prefix = 0xED, Encoding = 0x42, Name = CommandID.SBC, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // ED42: SBC HL, rr
                  new OpcodeEntry { Index = true, Encoding = 0x98, Name = CommandID.SBC, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Source}, }, }, // iz98: *SBC A, Izb
                  new OpcodeEntry { Index = true, Encoding = 0x9E, Name = CommandID.SBC, Length = 3, Cycles = 5, TStates = 19, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // iz9Eoo: SBC A, (Iz + oo)
               }
            },
            {
               CommandID.SCF, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x37, Name = CommandID.SCF, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {}, }, // 37: SCF
               }
            },
            {
               CommandID.SET, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0xC0, Name = CommandID.SET, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CBC0: SET e, r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0xC6, Name = CommandID.SET, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CBC6: SET e, (HL)
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0xC0, Name = CommandID.SET, Status = OpcodeStatus.Undocumented, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // izCBooC0: *SET e, (Iz + oo), r
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0xC6, Name = CommandID.SET, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izCBooC6: SET e, (Iz + oo)
               }
            },
            {
               CommandID.SL1, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x30, Name = CommandID.SL1, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB30: *SL1 r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x36, Name = CommandID.SL1, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB36: *SL1 (HL)
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x30, Name = CommandID.SL1, Status = OpcodeStatus.Undocumented, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // izCBoo30: *SL1 (Iz + oo), r
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x36, Name = CommandID.SL1, Status = OpcodeStatus.Undocumented, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izCBoo36: *SL1 (Iz + oo)
               }
            },
            {
               CommandID.SLA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x20, Name = CommandID.SLA, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB20: SLA r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x26, Name = CommandID.SLA, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB26: SLA (HL)
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x20, Name = CommandID.SLA, Status = OpcodeStatus.Undocumented, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // izCBoo20: *SLA (Iz + oo), r
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x26, Name = CommandID.SLA, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izCBoo26: SLA (Iz + oo)
               }
            },
            {
               CommandID.SLL, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x30, Name = CommandID.SLL, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB30: *SLL r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x36, Name = CommandID.SLL, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB36: *SLL (HL)
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x30, Name = CommandID.SLL, Status = OpcodeStatus.Undocumented, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // izCBoo30: *SLL (Iz + oo), r
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x36, Name = CommandID.SLL, Status = OpcodeStatus.Undocumented, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izCBoo36: *SLL (Iz + oo)
               }
            },
            {
               CommandID.SRA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x28, Name = CommandID.SRA, Length = 2, Cycles = 2, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB28: SRA r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x2E, Name = CommandID.SRA, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB2E: SRA (HL)
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x28, Name = CommandID.SRA, Status = OpcodeStatus.Undocumented, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // izCBoo28: *SRA (Iz + oo), r
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x2E, Name = CommandID.SRA, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izCBoo2E: SRA (Iz + oo)
               }
            },
            {
               CommandID.SRL, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x38, Name = CommandID.SRL, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB38: SRL r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x3E, Name = CommandID.SRL, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB3E: SRL (HL)
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x38, Name = CommandID.SRL, Status = OpcodeStatus.Undocumented, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // izCBoo38: *SRL (Iz + oo), r
                  new OpcodeEntry { Index = true, Prefix = 0xCB, Encoding = 0x3E, Name = CommandID.SRL, Length = 4, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izCBoo3E: SRL (Iz + oo)
               }
            },
            {
               CommandID.SUB, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x90, Name = CommandID.SUB, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 90: SUB A, r
                  new OpcodeEntry { Encoding = 0x90, Name = CommandID.SUB, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 90: SUB r
                  new OpcodeEntry { Encoding = 0x96, Name = CommandID.SUB, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // 96: SUB A, (HL)
                  new OpcodeEntry { Encoding = 0x96, Name = CommandID.SUB, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // 96: SUB (HL)
                  new OpcodeEntry { Encoding = 0xD6, Name = CommandID.SUB, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // D6nn: SUB A, nn
                  new OpcodeEntry { Encoding = 0xD6, Name = CommandID.SUB, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // D6nn: SUB nn
                  new OpcodeEntry { Index = true, Encoding = 0x90, Name = CommandID.SUB, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Source}, }, }, // iz90: *SUB A, Izb
                  new OpcodeEntry { Index = true, Encoding = 0x90, Name = CommandID.SUB, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Source}, }, }, // iz90: *SUB Izb
                  new OpcodeEntry { Index = true, Encoding = 0x96, Name = CommandID.SUB, Length = 3, Cycles = 5, TStates = 19, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // iz96oo: SUB A, (Iz + oo)
                  new OpcodeEntry { Index = true, Encoding = 0x96, Name = CommandID.SUB, Length = 3, Cycles = 5, TStates = 19, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // iz96oo: SUB (Iz + oo)
               }
            },
            {
               CommandID.XOR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xA8, Name = CommandID.XOR, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // A8: XOR A, r
                  new OpcodeEntry { Encoding = 0xAE, Name = CommandID.XOR, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // AE: XOR A, (HL)
                  new OpcodeEntry { Encoding = 0xEE, Name = CommandID.XOR, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // EEnn: XOR A, nn
                  new OpcodeEntry { Index = true, Encoding = 0xA8, Name = CommandID.XOR, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ByteReg_Izb, Type = ParameterType.ByteIndexRegister, Encoding = EncodingType.Source}, }, }, // izA8: *XOR A, Izb
                  new OpcodeEntry { Index = true, Encoding = 0xAE, Name = CommandID.XOR, Length = 3, Cycles = 5, TStates = 19, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_Iz, Type = ParameterType.WordIndexRegisterPointer, Encoding = EncodingType.IndexOffset}, }, }, // izAEoo: XOR A, (Iz + oo)
               }
            },
        };

        public static SortedList<string, CommandID> Commands = new SortedList<string, CommandID>
        {
           { "ADC", CommandID.ADC },
           { "ADD", CommandID.ADD },
           { "AND", CommandID.AND },
           { "BIT", CommandID.BIT },
           { "CALL", CommandID.CALL },
           { "CCF", CommandID.CCF },
           { "CP", CommandID.CP },
           { "CPD", CommandID.CPD },
           { "CPDR", CommandID.CPDR },
           { "CPI", CommandID.CPI },
           { "CPIR", CommandID.CPIR },
           { "CPL", CommandID.CPL },
           { "DAA", CommandID.DAA },
           { "DEC", CommandID.DEC },
           { "DI", CommandID.DI },
           { "DJNZ", CommandID.DJNZ },
           { "EI", CommandID.EI },
           { "EX", CommandID.EX },
           { "EXX", CommandID.EXX },
           { "HALT", CommandID.HALT },
           { "IM", CommandID.IM },
           { "IN", CommandID.IN },
           { "INC", CommandID.INC },
           { "IND", CommandID.IND },
           { "INDR", CommandID.INDR },
           { "INI", CommandID.INI },
           { "INIR", CommandID.INIR },
           { "JP", CommandID.JP },
           { "JR", CommandID.JR },
           { "LD", CommandID.LD },
           { "LDD", CommandID.LDD },
           { "LDDR", CommandID.LDDR },
           { "LDI", CommandID.LDI },
           { "LDIR", CommandID.LDIR },
           { "LDX", CommandID.LDX },
           { "NEG", CommandID.NEG },
           { "NOP", CommandID.NOP },
           { "OR", CommandID.OR },
           { "OTDR", CommandID.OTDR },
           { "OTIR", CommandID.OTIR },
           { "OUT", CommandID.OUT },
           { "OUTD", CommandID.OUTD },
           { "OUTI", CommandID.OUTI },
           { "POP", CommandID.POP },
           { "PUSH", CommandID.PUSH },
           { "RES", CommandID.RES },
           { "RET", CommandID.RET },
           { "RETI", CommandID.RETI },
           { "RETN", CommandID.RETN },
           { "RL", CommandID.RL },
           { "RLA", CommandID.RLA },
           { "RLC", CommandID.RLC },
           { "RLCA", CommandID.RLCA },
           { "RLD", CommandID.RLD },
           { "RR", CommandID.RR },
           { "RRA", CommandID.RRA },
           { "RRC", CommandID.RRC },
           { "RRCA", CommandID.RRCA },
           { "RRD", CommandID.RRD },
           { "RST", CommandID.RST },
           { "SBC", CommandID.SBC },
           { "SCF", CommandID.SCF },
           { "SET", CommandID.SET },
           { "SL1", CommandID.SL1 },
           { "SLA", CommandID.SLA },
           { "SLL", CommandID.SLL },
           { "SRA", CommandID.SRA },
           { "SRL", CommandID.SRL },
           { "SUB", CommandID.SUB },
           { "XOR", CommandID.XOR },
        };
    }
}
