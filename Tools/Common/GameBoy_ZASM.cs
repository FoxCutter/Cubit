using System.Collections.Generic;

namespace OpcodeData
{
    public static partial class GameBoyData
    {
        public static SortedList<CommandID, OpcodeEntry[]> Encoding = new SortedList<CommandID, OpcodeEntry[]>
        {
            {
               CommandID.ADC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x88, Name = CommandID.ADC, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 88: ADC A, r
                  new OpcodeEntry { Encoding = 0x8E, Name = CommandID.ADC, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // 8E: ADC A, (HL)
                  new OpcodeEntry { Encoding = 0xCE, Name = CommandID.ADC, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // CEnn: ADC A, nn
               }
            },
            {
               CommandID.ADD, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x09, Name = CommandID.ADD, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // 09: ADD HL, rr
                  new OpcodeEntry { Encoding = 0x80, Name = CommandID.ADD, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 80: ADD A, r
                  new OpcodeEntry { Encoding = 0x86, Name = CommandID.ADD, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // 86: ADD A, (HL)
                  new OpcodeEntry { Encoding = 0xC6, Name = CommandID.ADD, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // C6nn: ADD A, nn
                  new OpcodeEntry { Encoding = 0xE8, Name = CommandID.ADD, Length = 2, Cycles = 3, TStates = 16, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_SP, Type = ParameterType.WordRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // E8nn: ADD SP, nn
               }
            },
            {
               CommandID.AND, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xA0, Name = CommandID.AND, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // A0: AND r
                  new OpcodeEntry { Encoding = 0xA6, Name = CommandID.AND, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // A6: AND (HL)
                  new OpcodeEntry { Encoding = 0xE6, Name = CommandID.AND, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // E6nn: AND nn
               }
            },
            {
               CommandID.BIT, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x40, Name = CommandID.BIT, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB40: BIT e, r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x46, Name = CommandID.BIT, Length = 2, Cycles = 3, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB46: BIT e, (HL)
               }
            },
            {
               CommandID.CALL, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC4, Name = CommandID.CALL, Length = 3, Cycles = 5, TStates = 17, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.FlagsAny, Type = ParameterType.HalfFlag, Encoding = EncodingType.HalfFlag}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // C4nnnn: CALL ff, nnnn
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
                  new OpcodeEntry { Encoding = 0xB8, Name = CommandID.CP, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // B8: CP r
                  new OpcodeEntry { Encoding = 0xBE, Name = CommandID.CP, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // BE: CP (HL)
                  new OpcodeEntry { Encoding = 0xFE, Name = CommandID.CP, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // FEnn: CP nn
               }
            },
            {
               CommandID.CPL, new OpcodeEntry[]
               {
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
               }
            },
            {
               CommandID.DI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xF3, Name = CommandID.DI, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {}, }, // F3: DI
               }
            },
            {
               CommandID.EI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xFB, Name = CommandID.EI, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {}, }, // FB: EI
               }
            },
            {
               CommandID.HALT, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x76, Name = CommandID.HALT, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {}, }, // 76: HALT
               }
            },
            {
               CommandID.INC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x03, Name = CommandID.INC, Length = 1, Cycles = 1, TStates = 6, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // 03: INC rr
                  new OpcodeEntry { Encoding = 0x04, Name = CommandID.INC, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, }, }, // 04: INC r
                  new OpcodeEntry { Encoding = 0x34, Name = CommandID.INC, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // 34: INC (HL)
               }
            },
            {
               CommandID.JP, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC2, Name = CommandID.JP, Length = 3, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.FlagsAny, Type = ParameterType.HalfFlag, Encoding = EncodingType.HalfFlag}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // C2nnnn: JP ff, nnnn
                  new OpcodeEntry { Encoding = 0xC3, Name = CommandID.JP, Length = 3, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // C3nnnn: JP nnnn
                  new OpcodeEntry { Encoding = 0xE9, Name = CommandID.JP, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister}, }, }, // E9: JP HL
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
                  new OpcodeEntry { Encoding = 0x08, Name = CommandID.LD, Length = 3, Cycles = 5, TStates = 20, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.AddressPointer, Encoding = EncodingType.WordImmidate}, new ParamEntry { Param = ParameterID.WordReg_SP, Type = ParameterType.WordRegister}, }, }, // 08nnnn: LD (nnnn), SP
                  new OpcodeEntry { Encoding = 0x0A, Name = CommandID.LD, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_BD, Type = ParameterType.WordRegisterPointer, Encoding = EncodingType.WordReg}, }, }, // 0A: LD A, (rp)
                  new OpcodeEntry { Encoding = 0x22, Name = CommandID.LD, Length = 1, Cycles = 4, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HLI, Type = ParameterType.WordRegisterPointer}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // 22: LD (HLI), A
                  new OpcodeEntry { Encoding = 0x2A, Name = CommandID.LD, Length = 1, Cycles = 4, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_HLI, Type = ParameterType.WordRegisterPointer}, }, }, // 2A: LD A, (HLI)
                  new OpcodeEntry { Encoding = 0x32, Name = CommandID.LD, Length = 1, Cycles = 4, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HLD, Type = ParameterType.WordRegisterPointer}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // 32: LD (HLD), A
                  new OpcodeEntry { Encoding = 0x36, Name = CommandID.LD, Length = 2, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // 36nn: LD (HL), nn
                  new OpcodeEntry { Encoding = 0x3A, Name = CommandID.LD, Length = 1, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_HLD, Type = ParameterType.WordRegisterPointer}, }, }, // 3A: LD A, (HLD)
                  new OpcodeEntry { Encoding = 0x40, Name = CommandID.LD, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 40: LD r, r
                  new OpcodeEntry { Encoding = 0x46, Name = CommandID.LD, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // 46: LD r, (HL)
                  new OpcodeEntry { Encoding = 0x70, Name = CommandID.LD, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 70: LD (HL), r
                  new OpcodeEntry { Encoding = 0xE0, Name = CommandID.LD, Length = 2, Cycles = 3, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.HighMemPointerPlus, Encoding = EncodingType.ByteImmidate}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // E0nn: LD ($ff00 + nn), A
                  new OpcodeEntry { Encoding = 0xE2, Name = CommandID.LD, Length = 1, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_C, Type = ParameterType.HighMemPointerPlus}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // E2: LD ($ff00 + C), A
                  new OpcodeEntry { Encoding = 0xE2, Name = CommandID.LD, Length = 1, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_C, Type = ParameterType.BytePointer}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // E2: LD (C), A
                  new OpcodeEntry { Encoding = 0xEA, Name = CommandID.LD, Length = 3, Cycles = 3, TStates = 16, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.AddressPointer, Encoding = EncodingType.WordImmidate}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // EAnnnn: LD (nnnn), A
                  new OpcodeEntry { Encoding = 0xF0, Name = CommandID.LD, Length = 2, Cycles = 3, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.HighMemPointerPlus, Encoding = EncodingType.ByteImmidate}, }, }, // F0nn: LD A, ($ff00 + nn)
                  new OpcodeEntry { Encoding = 0xF2, Name = CommandID.LD, Length = 2, Cycles = 3, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ByteReg_C, Type = ParameterType.HighMemPointerPlus}, }, }, // F2: LD A, ($ff00 + C)
                  new OpcodeEntry { Encoding = 0xF2, Name = CommandID.LD, Length = 2, Cycles = 3, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ByteReg_C, Type = ParameterType.BytePointer}, }, }, // F2: LD A, (C)
                  new OpcodeEntry { Encoding = 0xF8, Name = CommandID.LD, Length = 2, Cycles = 3, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.SPPlusOffset, Encoding = EncodingType.ByteImmidate}, }, }, // F8nn: LD HL, SP + nn
                  new OpcodeEntry { Encoding = 0xF9, Name = CommandID.LD, Length = 1, Cycles = 1, TStates = 6, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_SP, Type = ParameterType.WordRegister}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister}, }, }, // F9: LD SP, HL
                  new OpcodeEntry { Encoding = 0xFA, Name = CommandID.LD, Length = 3, Cycles = 4, TStates = 16, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.AddressPointer, Encoding = EncodingType.WordImmidate}, }, }, // FAnnnn: LD A, (nnnn)
               }
            },
            {
               CommandID.LDD, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x32, Name = CommandID.LDD, Length = 1, Cycles = 4, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // 32: LDD (HL), A
                  new OpcodeEntry { Encoding = 0x3A, Name = CommandID.LDD, Length = 1, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // 3A: LDD A, (HL)
               }
            },
            {
               CommandID.LDH, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xE0, Name = CommandID.LDH, Length = 2, Cycles = 3, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.BytePointer, Encoding = EncodingType.ByteImmidate}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // E0nn: LDH (nn), A
                  new OpcodeEntry { Encoding = 0xF0, Name = CommandID.LDH, Length = 2, Cycles = 3, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.BytePointer, Encoding = EncodingType.ByteImmidate}, }, }, // F0nn: LDH A, (nn)
               }
            },
            {
               CommandID.LDHL, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xF8, Name = CommandID.LDHL, Length = 2, Cycles = 3, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_SP, Type = ParameterType.WordRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // F8nn: LDHL SP, nn
               }
            },
            {
               CommandID.LDI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x22, Name = CommandID.LDI, Length = 1, Cycles = 4, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // 22: LDI (HL), A
                  new OpcodeEntry { Encoding = 0x2A, Name = CommandID.LDI, Length = 1, Cycles = 4, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // 2A: LDI A, (HL)
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
                  new OpcodeEntry { Encoding = 0xB0, Name = CommandID.OR, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // B0: OR r
                  new OpcodeEntry { Encoding = 0xB6, Name = CommandID.OR, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // B6: OR (HL)
                  new OpcodeEntry { Encoding = 0xF6, Name = CommandID.OR, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // F6nn: OR nn
               }
            },
            {
               CommandID.POP, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC1, Name = CommandID.POP, Length = 1, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // C1: POP rr
                  new OpcodeEntry { Encoding = 0xF1, Name = CommandID.POP, Length = 1, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_AF, Type = ParameterType.WordRegister}, }, }, // F1: POP AF
               }
            },
            {
               CommandID.PUSH, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC5, Name = CommandID.PUSH, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // C5: PUSH rr
                  new OpcodeEntry { Encoding = 0xF5, Name = CommandID.PUSH, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_AF, Type = ParameterType.WordRegister}, }, }, // F5: PUSH AF
               }
            },
            {
               CommandID.RES, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x80, Name = CommandID.RES, Length = 2, Cycles = 4, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB80: RES e, r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x86, Name = CommandID.RES, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB86: RES e, (HL)
               }
            },
            {
               CommandID.RET, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC0, Name = CommandID.RET, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.FlagsAny, Type = ParameterType.HalfFlag, Encoding = EncodingType.HalfFlag}, }, }, // C0: RET ff
                  new OpcodeEntry { Encoding = 0xC9, Name = CommandID.RET, Length = 1, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {}, }, // C9: RET
               }
            },
            {
               CommandID.RETI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xD9, Name = CommandID.RETI, Length = 1, Cycles = 4, TStates = 16, Arguments = new ParamEntry[] {}, }, // D9: RETI
               }
            },
            {
               CommandID.RL, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x17, Name = CommandID.RL, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // 17: RL A
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x10, Name = CommandID.RL, Length = 2, Cycles = 8, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB10: RL r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x16, Name = CommandID.RL, Length = 2, Cycles = 6, TStates = 23, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB16: RL (HL)
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
               }
            },
            {
               CommandID.RLCA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x07, Name = CommandID.RLCA, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 07: RLCA
               }
            },
            {
               CommandID.RR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x1F, Name = CommandID.RR, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, }, }, // 1F: RR A
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x18, Name = CommandID.RR, Length = 2, Cycles = 8, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB18: RR r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x1E, Name = CommandID.RR, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB1E: RR (HL)
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
               }
            },
            {
               CommandID.RRCA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x0F, Name = CommandID.RRCA, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 0F: RRCA
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
               }
            },
            {
               CommandID.SLA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x20, Name = CommandID.SLA, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB20: SLA r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x26, Name = CommandID.SLA, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB26: SLA (HL)
               }
            },
            {
               CommandID.SRA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x28, Name = CommandID.SRA, Length = 2, Cycles = 2, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB28: SRA r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x2E, Name = CommandID.SRA, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB2E: SRA (HL)
               }
            },
            {
               CommandID.SRL, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x38, Name = CommandID.SRL, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB38: SRL r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x3E, Name = CommandID.SRL, Length = 2, Cycles = 4, TStates = 15, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB3E: SRL (HL)
               }
            },
            {
               CommandID.STOP, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x10, Name = CommandID.STOP, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {}, }, // 10: STOP
               }
            },
            {
               CommandID.SUB, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x90, Name = CommandID.SUB, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 90: SUB r
                  new OpcodeEntry { Encoding = 0x96, Name = CommandID.SUB, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // 96: SUB (HL)
                  new OpcodeEntry { Encoding = 0xD6, Name = CommandID.SUB, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // D6nn: SUB nn
               }
            },
            {
               CommandID.SWAP, new OpcodeEntry[]
               {
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x30, Name = CommandID.SWAP, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 2, TStates = 8, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // CB30: *SWAP r
                  new OpcodeEntry { Prefix = 0xCB, Encoding = 0x36, Name = CommandID.SWAP, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 3, TStates = 16, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // CB36: *SWAP (HL)
               }
            },
            {
               CommandID.XOR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xA8, Name = CommandID.XOR, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // A8: XOR A, r
                  new OpcodeEntry { Encoding = 0xAE, Name = CommandID.XOR, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegisterPointer}, }, }, // AE: XOR A, (HL)
                  new OpcodeEntry { Encoding = 0xEE, Name = CommandID.XOR, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // EEnn: XOR A, nn
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
           { "CPL", CommandID.CPL },
           { "DAA", CommandID.DAA },
           { "DEC", CommandID.DEC },
           { "DI", CommandID.DI },
           { "EI", CommandID.EI },
           { "HALT", CommandID.HALT },
           { "INC", CommandID.INC },
           { "JP", CommandID.JP },
           { "JR", CommandID.JR },
           { "LD", CommandID.LD },
           { "LDD", CommandID.LDD },
           { "LDH", CommandID.LDH },
           { "LDHL", CommandID.LDHL },
           { "LDI", CommandID.LDI },
           { "NOP", CommandID.NOP },
           { "OR", CommandID.OR },
           { "POP", CommandID.POP },
           { "PUSH", CommandID.PUSH },
           { "RES", CommandID.RES },
           { "RET", CommandID.RET },
           { "RETI", CommandID.RETI },
           { "RL", CommandID.RL },
           { "RLA", CommandID.RLA },
           { "RLC", CommandID.RLC },
           { "RLCA", CommandID.RLCA },
           { "RR", CommandID.RR },
           { "RRA", CommandID.RRA },
           { "RRC", CommandID.RRC },
           { "RRCA", CommandID.RRCA },
           { "RST", CommandID.RST },
           { "SBC", CommandID.SBC },
           { "SCF", CommandID.SCF },
           { "SET", CommandID.SET },
           { "SLA", CommandID.SLA },
           { "SRA", CommandID.SRA },
           { "SRL", CommandID.SRL },
           { "STOP", CommandID.STOP },
           { "SUB", CommandID.SUB },
           { "SWAP", CommandID.SWAP },
           { "XOR", CommandID.XOR },
        };
    }
}
