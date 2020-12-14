using System.Collections.Generic;

namespace OpcodeData
{
    public static partial class i8085Data
    {
        public static SortedList<CommandID, OpcodeEntry[]> Encoding = new SortedList<CommandID, OpcodeEntry[]>
        {
            {
               CommandID.ACI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xCE, Name = CommandID.ACI, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // CEnn: ACI nn
               }
            },
            {
               CommandID.ADC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x88, Name = CommandID.ADC, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 88: ADC r
                  new OpcodeEntry { Encoding = 0x8E, Name = CommandID.ADC, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ByteReg_M, Type = ParameterType.ByteRegister}, }, }, // 8E: ADC M
               }
            },
            {
               CommandID.ADD, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x80, Name = CommandID.ADD, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 80: ADD r
                  new OpcodeEntry { Encoding = 0x86, Name = CommandID.ADD, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ByteReg_M, Type = ParameterType.ByteRegister}, }, }, // 86: ADD M
               }
            },
            {
               CommandID.ADI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x28, Name = CommandID.ADI, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_DE, Type = ParameterType.WordRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // 28nn: *ADI H, nn
                  new OpcodeEntry { Encoding = 0x38, Name = CommandID.ADI, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_DE, Type = ParameterType.WordRegister}, new ParamEntry { Param = ParameterID.WordReg_SP, Type = ParameterType.WordRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // 38nn: *ADI D, SP, nn
                  new OpcodeEntry { Encoding = 0xC6, Name = CommandID.ADI, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // C6nn: ADI nn
               }
            },
            {
               CommandID.ANA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xA0, Name = CommandID.ANA, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // A0: ANA r
                  new OpcodeEntry { Encoding = 0xA6, Name = CommandID.ANA, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ByteReg_M, Type = ParameterType.ByteRegister}, }, }, // A6: ANA M
               }
            },
            {
               CommandID.ANI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xE6, Name = CommandID.ANI, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // E6nn: ANI nn
               }
            },
            {
               CommandID.ARHL, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x10, Name = CommandID.ARHL, Status = OpcodeStatus.Undocumented, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister, Implicit = true}, }, }, // 10: *ARHL
               }
            },
            {
               CommandID.CALL, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xCD, Name = CommandID.CALL, Length = 3, Cycles = 5, TStates = 17, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // CDnnnn: CALL nnnn
               }
            },
            {
               CommandID.CC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xDC, Name = CommandID.CC, Length = 3, Cycles = 5, TStates = 17, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_CY, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // DCnnnn: CC nnnn
               }
            },
            {
               CommandID.CM, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xFC, Name = CommandID.CM, Length = 3, Cycles = 5, TStates = 17, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_M, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // FCnnnn: CM nnnn
               }
            },
            {
               CommandID.CMA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x2F, Name = CommandID.CMA, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 2F: CMA
               }
            },
            {
               CommandID.CMC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x3F, Name = CommandID.CMC, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {}, }, // 3F: CMC
               }
            },
            {
               CommandID.CMP, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xB8, Name = CommandID.CMP, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // B8: CMP r
                  new OpcodeEntry { Encoding = 0xBE, Name = CommandID.CMP, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ByteReg_M, Type = ParameterType.ByteRegister}, }, }, // BE: CMP M
               }
            },
            {
               CommandID.CNC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xD4, Name = CommandID.CNC, Length = 3, Cycles = 5, TStates = 17, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_NC, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // D4nnnn: CNC nnnn
               }
            },
            {
               CommandID.CNZ, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC4, Name = CommandID.CNZ, Length = 3, Cycles = 5, TStates = 17, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_NZ, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // C4nnnn: CNZ nnnn
               }
            },
            {
               CommandID.CP, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xF4, Name = CommandID.CP, Length = 3, Cycles = 5, TStates = 17, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_P, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // F4nnnn: CP nnnn
               }
            },
            {
               CommandID.CPE, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xEC, Name = CommandID.CPE, Length = 3, Cycles = 5, TStates = 17, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_PE, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // ECnnnn: CPE nnnn
               }
            },
            {
               CommandID.CPI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xFE, Name = CommandID.CPI, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // FEnn: CPI nn
               }
            },
            {
               CommandID.CPO, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xE4, Name = CommandID.CPO, Length = 3, Cycles = 5, TStates = 17, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_PO, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // E4nnnn: CPO nnnn
               }
            },
            {
               CommandID.CZ, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xCC, Name = CommandID.CZ, Length = 3, Cycles = 5, TStates = 17, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_Z, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // CCnnnn: CZ nnnn
               }
            },
            {
               CommandID.DAA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x27, Name = CommandID.DAA, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 27: DAA
               }
            },
            {
               CommandID.DAD, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x09, Name = CommandID.DAD, Length = 1, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // 09: DAD rr
               }
            },
            {
               CommandID.DCR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x05, Name = CommandID.DCR, Length = 1, Cycles = 1, TStates = 5, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, }, }, // 05: DCR r
                  new OpcodeEntry { Encoding = 0x35, Name = CommandID.DCR, Length = 1, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_M, Type = ParameterType.ByteRegister}, }, }, // 35: DCR M
               }
            },
            {
               CommandID.DCX, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x0B, Name = CommandID.DCX, Length = 1, Cycles = 1, TStates = 5, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // 0B: DCX rr
               }
            },
            {
               CommandID.DI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xF3, Name = CommandID.DI, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {}, }, // F3: DI
               }
            },
            {
               CommandID.DSUB, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x08, Name = CommandID.DSUB, Status = OpcodeStatus.Undocumented, Length = 1, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_BC, Type = ParameterType.WordRegister, Implicit = true}, }, }, // 08: *DSUB
               }
            },
            {
               CommandID.EI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xFB, Name = CommandID.EI, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {}, }, // FB: EI
               }
            },
            {
               CommandID.HLT, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x76, Name = CommandID.HLT, Length = 1, Cycles = 1, TStates = 7, Arguments = new ParamEntry[] {}, }, // 76: HLT
               }
            },
            {
               CommandID.IN, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xDB, Name = CommandID.IN, Length = 2, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // DBnn: IN nn
               }
            },
            {
               CommandID.INR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x04, Name = CommandID.INR, Length = 1, Cycles = 1, TStates = 5, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, }, }, // 04: INR r
                  new OpcodeEntry { Encoding = 0x34, Name = CommandID.INR, Length = 1, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_M, Type = ParameterType.ByteRegister}, }, }, // 34: INR M
               }
            },
            {
               CommandID.INX, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x03, Name = CommandID.INX, Length = 1, Cycles = 1, TStates = 5, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // 03: INX rr
               }
            },
            {
               CommandID.JC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xDA, Name = CommandID.JC, Length = 3, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_CY, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // DAnnnn: JC nnnn
               }
            },
            {
               CommandID.JK, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xFD, Name = CommandID.JK, Status = OpcodeStatus.Undocumented, Length = 3, Cycles = 5, TStates = 17, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_K, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // FDnnnn: *JK nnnn
               }
            },
            {
               CommandID.JM, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xFA, Name = CommandID.JM, Length = 3, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_M, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // FAnnnn: JM nnnn
               }
            },
            {
               CommandID.JMP, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC3, Name = CommandID.JMP, Length = 3, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // C3nnnn: JMP nnnn
               }
            },
            {
               CommandID.JNC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xD2, Name = CommandID.JNC, Length = 3, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_NC, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // D2nnnn: JNC nnnn
               }
            },
            {
               CommandID.JNK, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xDD, Name = CommandID.JNK, Status = OpcodeStatus.Undocumented, Length = 3, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_NK, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // DDnnnn: *JNK nnnn
               }
            },
            {
               CommandID.JNZ, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC2, Name = CommandID.JNZ, Length = 3, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_NZ, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // C2nnnn: JNZ nnnn
               }
            },
            {
               CommandID.JP, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xF2, Name = CommandID.JP, Length = 3, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_P, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // F2nnnn: JP nnnn
               }
            },
            {
               CommandID.JPE, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xEA, Name = CommandID.JPE, Length = 3, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_PE, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // EAnnnn: JPE nnnn
               }
            },
            {
               CommandID.JPO, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xE2, Name = CommandID.JPO, Length = 3, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_PO, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // E2nnnn: JPO nnnn
               }
            },
            {
               CommandID.JZ, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xCA, Name = CommandID.JZ, Length = 3, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_Z, Type = ParameterType.Flag, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Address, Encoding = EncodingType.WordImmidate}, }, }, // CAnnnn: JZ nnnn
               }
            },
            {
               CommandID.LDA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x3A, Name = CommandID.LDA, Length = 3, Cycles = 4, TStates = 13, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.AddressPointer, Encoding = EncodingType.WordImmidate}, }, }, // 3Annnn: LDA nnnn
               }
            },
            {
               CommandID.LDAX, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x0A, Name = CommandID.LDAX, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_BD, Type = ParameterType.WordRegisterPointer, Encoding = EncodingType.WordReg}, }, }, // 0A: LDAX rp
               }
            },
            {
               CommandID.LDHI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x28, Name = CommandID.LDHI, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_DE, Type = ParameterType.WordRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // 28nn: *LDHI nn
               }
            },
            {
               CommandID.LDSI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x38, Name = CommandID.LDSI, Status = OpcodeStatus.Undocumented, Length = 2, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_DE, Type = ParameterType.WordRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_SP, Type = ParameterType.WordRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // 38nn: *LDSI nn
               }
            },
            {
               CommandID.LHLD, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x2A, Name = CommandID.LHLD, Length = 3, Cycles = 5, TStates = 16, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.AddressPointer, Encoding = EncodingType.WordImmidate}, }, }, // 2Annnn: LHLD nnnn
               }
            },
            {
               CommandID.LHLDE, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xED, Name = CommandID.LHLDE, Status = OpcodeStatus.Undocumented, Length = 3, Cycles = 5, TStates = 17, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_DE, Type = ParameterType.WordRegister, Implicit = true}, }, }, // ED: *LHLDE
               }
            },
            {
               CommandID.LHLX, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xED, Name = CommandID.LHLX, Status = OpcodeStatus.Undocumented, Length = 3, Cycles = 5, TStates = 17, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_DE, Type = ParameterType.WordRegister, Implicit = true}, }, }, // ED: *LHLX
               }
            },
            {
               CommandID.LXI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x01, Name = CommandID.LXI, Length = 3, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.Value, Encoding = EncodingType.WordImmidate}, }, }, // 01nnnn: LXI rr, nnnn
               }
            },
            {
               CommandID.MOV, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x40, Name = CommandID.MOV, Length = 1, Cycles = 1, TStates = 5, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 40: MOV r, r
                  new OpcodeEntry { Encoding = 0x46, Name = CommandID.MOV, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.ByteReg_M, Type = ParameterType.ByteRegister}, }, }, // 46: MOV r, M
                  new OpcodeEntry { Encoding = 0x70, Name = CommandID.MOV, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_M, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 70: MOV M, r
               }
            },
            {
               CommandID.MVI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x06, Name = CommandID.MVI, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Dest}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // 06nn: MVI r, nn
                  new OpcodeEntry { Encoding = 0x36, Name = CommandID.MVI, Length = 2, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_M, Type = ParameterType.ByteRegister}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // 36nn: MVI M, nn
               }
            },
            {
               CommandID.NOP, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x00, Name = CommandID.NOP, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {}, }, // 00: NOP
               }
            },
            {
               CommandID.ORA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xB0, Name = CommandID.ORA, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // B0: ORA r
                  new OpcodeEntry { Encoding = 0xB6, Name = CommandID.ORA, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ByteReg_M, Type = ParameterType.ByteRegister}, }, }, // B6: ORA M
               }
            },
            {
               CommandID.ORI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xF6, Name = CommandID.ORI, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // F6nn: ORI nn
               }
            },
            {
               CommandID.OUT, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xD3, Name = CommandID.OUT, Length = 2, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // D3nn: OUT nn
               }
            },
            {
               CommandID.PCHL, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xE9, Name = CommandID.PCHL, Length = 1, Cycles = 1, TStates = 5, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister, Implicit = true}, }, }, // E9: PCHL
               }
            },
            {
               CommandID.POP, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC1, Name = CommandID.POP, Length = 1, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // C1: POP rr
                  new OpcodeEntry { Encoding = 0xF1, Name = CommandID.POP, Length = 1, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_PSW, Type = ParameterType.WordRegister}, }, }, // F1: POP PSW
               }
            },
            {
               CommandID.PUSH, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC5, Name = CommandID.PUSH, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.WordRegister, Encoding = EncodingType.WordReg}, }, }, // C5: PUSH rr
                  new OpcodeEntry { Encoding = 0xF5, Name = CommandID.PUSH, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_PSW, Type = ParameterType.WordRegister}, }, }, // F5: PUSH PSW
               }
            },
            {
               CommandID.RAL, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x17, Name = CommandID.RAL, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 17: RAL
               }
            },
            {
               CommandID.RAR, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x1F, Name = CommandID.RAR, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 1F: RAR
               }
            },
            {
               CommandID.RC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xD8, Name = CommandID.RC, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_CY, Type = ParameterType.Flag, Implicit = true}, }, }, // D8: RC
               }
            },
            {
               CommandID.RDLE, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x18, Name = CommandID.RDLE, Status = OpcodeStatus.Undocumented, Length = 1, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_DE, Type = ParameterType.WordRegister, Implicit = true}, }, }, // 18: *RDLE
               }
            },
            {
               CommandID.RET, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC9, Name = CommandID.RET, Length = 1, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {}, }, // C9: RET
               }
            },
            {
               CommandID.RIM, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x20, Name = CommandID.RIM, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 20: RIM
               }
            },
            {
               CommandID.RLC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x07, Name = CommandID.RLC, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 07: RLC
               }
            },
            {
               CommandID.RM, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xF8, Name = CommandID.RM, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_M, Type = ParameterType.Flag, Implicit = true}, }, }, // F8: RM
               }
            },
            {
               CommandID.RNC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xD0, Name = CommandID.RNC, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_NC, Type = ParameterType.Flag, Implicit = true}, }, }, // D0: RNC
               }
            },
            {
               CommandID.RNZ, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC0, Name = CommandID.RNZ, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_NZ, Type = ParameterType.Flag, Implicit = true}, }, }, // C0: RNZ
               }
            },
            {
               CommandID.RP, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xF0, Name = CommandID.RP, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_P, Type = ParameterType.Flag, Implicit = true}, }, }, // F0: RP
               }
            },
            {
               CommandID.RPE, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xE8, Name = CommandID.RPE, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_PE, Type = ParameterType.Flag, Implicit = true}, }, }, // E8: RPE
               }
            },
            {
               CommandID.RPO, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xE0, Name = CommandID.RPO, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_PO, Type = ParameterType.Flag, Implicit = true}, }, }, // E0: RPO
               }
            },
            {
               CommandID.RRC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x0F, Name = CommandID.RRC, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 0F: RRC
               }
            },
            {
               CommandID.RST, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC7, Name = CommandID.RST, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.EncodedValue, Type = ParameterType.Value, Encoding = EncodingType.Dest}, }, }, // C7: RST e
               }
            },
            {
               CommandID.RSTV, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xCB, Name = CommandID.RSTV, Status = OpcodeStatus.Undocumented, Length = 1, Cycles = 4, TStates = 12, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Value8, Type = ParameterType.Value, Implicit = true}, }, }, // CB: *RSTV
               }
            },
            {
               CommandID.RZ, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xC8, Name = CommandID.RZ, Length = 1, Cycles = 3, TStates = 11, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.Flag_Z, Type = ParameterType.Flag, Implicit = true}, }, }, // C8: RZ
               }
            },
            {
               CommandID.SBB, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x98, Name = CommandID.SBB, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 98: SBB r
                  new OpcodeEntry { Encoding = 0x9E, Name = CommandID.SBB, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ByteReg_M, Type = ParameterType.ByteRegister}, }, }, // 9E: SBB M
               }
            },
            {
               CommandID.SBI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xDE, Name = CommandID.SBI, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // DEnn: SBI nn
               }
            },
            {
               CommandID.SHLD, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x22, Name = CommandID.SHLD, Length = 3, Cycles = 5, TStates = 16, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.AddressPointer, Encoding = EncodingType.WordImmidate}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister, Implicit = true}, }, }, // 22nnnn: SHLD nnnn
               }
            },
            {
               CommandID.SHLDE, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xD9, Name = CommandID.SHLDE, Status = OpcodeStatus.Undocumented, Length = 1, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_DE, Type = ParameterType.WordRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister, Implicit = true}, }, }, // D9: *SHLDE
               }
            },
            {
               CommandID.SHLX, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xD9, Name = CommandID.SHLX, Status = OpcodeStatus.Undocumented, Length = 1, Cycles = 3, TStates = 10, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_DE, Type = ParameterType.WordRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister, Implicit = true}, }, }, // D9: *SHLX
               }
            },
            {
               CommandID.SIM, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x30, Name = CommandID.SIM, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 30: SIM
               }
            },
            {
               CommandID.SPHL, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xF9, Name = CommandID.SPHL, Length = 1, Cycles = 1, TStates = 5, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_SP, Type = ParameterType.WordRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister, Implicit = true}, }, }, // F9: SPHL
               }
            },
            {
               CommandID.STA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x32, Name = CommandID.STA, Length = 3, Cycles = 4, TStates = 13, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ImmediateWord, Type = ParameterType.AddressPointer, Encoding = EncodingType.WordImmidate}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 32nnnn: STA nnnn
               }
            },
            {
               CommandID.STAX, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x02, Name = CommandID.STAX, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_BD, Type = ParameterType.WordRegisterPointer, Encoding = EncodingType.WordReg}, new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, }, }, // 02: STAX rp
               }
            },
            {
               CommandID.STC, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x37, Name = CommandID.STC, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {}, }, // 37: STC
               }
            },
            {
               CommandID.SUB, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0x90, Name = CommandID.SUB, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // 90: SUB r
                  new OpcodeEntry { Encoding = 0x96, Name = CommandID.SUB, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ByteReg_M, Type = ParameterType.ByteRegister}, }, }, // 96: SUB M
               }
            },
            {
               CommandID.SUI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xD6, Name = CommandID.SUI, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // D6nn: SUI nn
               }
            },
            {
               CommandID.XCHG, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xEB, Name = CommandID.XCHG, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_DE, Type = ParameterType.WordRegister, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister, Implicit = true}, }, }, // EB: XCHG
               }
            },
            {
               CommandID.XRA, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xA8, Name = CommandID.XRA, Length = 1, Cycles = 1, TStates = 4, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.RegisterAny, Type = ParameterType.ByteRegister, Encoding = EncodingType.Source}, }, }, // A8: XRA r
                  new OpcodeEntry { Encoding = 0xAE, Name = CommandID.XRA, Length = 1, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ByteReg_M, Type = ParameterType.ByteRegister}, }, }, // AE: XRA M
               }
            },
            {
               CommandID.XRI, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xEE, Name = CommandID.XRI, Length = 2, Cycles = 2, TStates = 7, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.ByteReg_A, Type = ParameterType.ByteRegister, Implicit = true}, new ParamEntry { Param = ParameterID.ImmediateByte, Type = ParameterType.Value, Encoding = EncodingType.ByteImmidate}, }, }, // EEnn: XRI nn
               }
            },
            {
               CommandID.XTHL, new OpcodeEntry[]
               {
                  new OpcodeEntry { Encoding = 0xE3, Name = CommandID.XTHL, Length = 1, Cycles = 5, TStates = 18, Arguments = new ParamEntry[] {new ParamEntry { Param = ParameterID.WordReg_SP, Type = ParameterType.WordRegisterPointer, Implicit = true}, new ParamEntry { Param = ParameterID.WordReg_HL, Type = ParameterType.WordRegister, Implicit = true}, }, }, // E3: XTHL
               }
            },
        };

        public static SortedList<string, CommandID> Commands = new SortedList<string, CommandID>
        {
           { "ACI", CommandID.ACI },
           { "ADC", CommandID.ADC },
           { "ADD", CommandID.ADD },
           { "ADI", CommandID.ADI },
           { "ANA", CommandID.ANA },
           { "ANI", CommandID.ANI },
           { "ARHL", CommandID.ARHL },
           { "CALL", CommandID.CALL },
           { "CC", CommandID.CC },
           { "CM", CommandID.CM },
           { "CMA", CommandID.CMA },
           { "CMC", CommandID.CMC },
           { "CMP", CommandID.CMP },
           { "CNC", CommandID.CNC },
           { "CNZ", CommandID.CNZ },
           { "CP", CommandID.CP },
           { "CPE", CommandID.CPE },
           { "CPI", CommandID.CPI },
           { "CPO", CommandID.CPO },
           { "CZ", CommandID.CZ },
           { "DAA", CommandID.DAA },
           { "DAD", CommandID.DAD },
           { "DCR", CommandID.DCR },
           { "DCX", CommandID.DCX },
           { "DI", CommandID.DI },
           { "DSUB", CommandID.DSUB },
           { "EI", CommandID.EI },
           { "HLT", CommandID.HLT },
           { "IN", CommandID.IN },
           { "INR", CommandID.INR },
           { "INX", CommandID.INX },
           { "JC", CommandID.JC },
           { "JK", CommandID.JK },
           { "JM", CommandID.JM },
           { "JMP", CommandID.JMP },
           { "JNC", CommandID.JNC },
           { "JNK", CommandID.JNK },
           { "JNZ", CommandID.JNZ },
           { "JP", CommandID.JP },
           { "JPE", CommandID.JPE },
           { "JPO", CommandID.JPO },
           { "JZ", CommandID.JZ },
           { "LDA", CommandID.LDA },
           { "LDAX", CommandID.LDAX },
           { "LDHI", CommandID.LDHI },
           { "LDSI", CommandID.LDSI },
           { "LHLD", CommandID.LHLD },
           { "LHLDE", CommandID.LHLDE },
           { "LHLX", CommandID.LHLX },
           { "LXI", CommandID.LXI },
           { "MOV", CommandID.MOV },
           { "MVI", CommandID.MVI },
           { "NOP", CommandID.NOP },
           { "ORA", CommandID.ORA },
           { "ORI", CommandID.ORI },
           { "OUT", CommandID.OUT },
           { "PCHL", CommandID.PCHL },
           { "POP", CommandID.POP },
           { "PUSH", CommandID.PUSH },
           { "RAL", CommandID.RAL },
           { "RAR", CommandID.RAR },
           { "RC", CommandID.RC },
           { "RDLE", CommandID.RDLE },
           { "RET", CommandID.RET },
           { "RIM", CommandID.RIM },
           { "RLC", CommandID.RLC },
           { "RM", CommandID.RM },
           { "RNC", CommandID.RNC },
           { "RNZ", CommandID.RNZ },
           { "RP", CommandID.RP },
           { "RPE", CommandID.RPE },
           { "RPO", CommandID.RPO },
           { "RRC", CommandID.RRC },
           { "RST", CommandID.RST },
           { "RSTV", CommandID.RSTV },
           { "RZ", CommandID.RZ },
           { "SBB", CommandID.SBB },
           { "SBI", CommandID.SBI },
           { "SHLD", CommandID.SHLD },
           { "SHLDE", CommandID.SHLDE },
           { "SHLX", CommandID.SHLX },
           { "SIM", CommandID.SIM },
           { "SPHL", CommandID.SPHL },
           { "STA", CommandID.STA },
           { "STAX", CommandID.STAX },
           { "STC", CommandID.STC },
           { "SUB", CommandID.SUB },
           { "SUI", CommandID.SUI },
           { "XCHG", CommandID.XCHG },
           { "XRA", CommandID.XRA },
           { "XRI", CommandID.XRI },
           { "XTHL", CommandID.XTHL },
        };
    }
}
