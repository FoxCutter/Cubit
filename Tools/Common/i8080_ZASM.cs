using CommandList = System.Collections.Generic.SortedList<string, OpcodeData.CommandID>;

namespace OpcodeData
{
    public static partial class ZASM
    {
        public static OpcodeEntry[] i8080OpcodeList = new OpcodeEntry[]
        {
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x88, Name = CommandID.ADC , Function = FunctionID.ADD_C, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.ByteRegister, EncodingType.Pos1, false), }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // 88: ADC r
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x8E, Name = CommandID.ADC , Function = FunctionID.ADD_C, Params = new ParamEntry[] { new ParamEntry(ParameterID.WordReg_HL, ParameterType.WordRegisterPointer, EncodingType.None, false), }, Type = OpcodeType.Official, Cycles = 6, Length = 1, }, // 8E: ADC M
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x80, Name = CommandID.ADD , Function = FunctionID.ADD, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.ByteRegister, EncodingType.Pos1, false), }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // 80: ADD r
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x86, Name = CommandID.ADD , Function = FunctionID.ADD, Params = new ParamEntry[] { new ParamEntry(ParameterID.WordReg_HL, ParameterType.WordRegisterPointer, EncodingType.None, false), }, Type = OpcodeType.Official, Cycles = 6, Length = 1, }, // 86: ADD M
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xCD, Name = CommandID.CALL, Function = FunctionID.CALL, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 17, Length = 3, }, // CDnnnn: CALL nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xF4, Name = CommandID.CP  , Function = FunctionID.CALL, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 17, Length = 3, }, // F4nnnn: CP nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xFE, Name = CommandID.CPI , Function = FunctionID.CMP, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateByte, ParameterType.Value, EncodingType.ByteImmidate, false), }, Type = OpcodeType.Official, Cycles = 7, Length = 2, }, // FEnn: CPI nn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x27, Name = CommandID.DAA , Function = FunctionID.BCD_ADJUST, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // 27: DAA
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xF3, Name = CommandID.DI  , Function = FunctionID.DI, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // F3: DI
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xFB, Name = CommandID.EI  , Function = FunctionID.EI, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // FB: EI
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xDB, Name = CommandID.IN  , Function = FunctionID.IN, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateByte, ParameterType.Value, EncodingType.ByteImmidate, false), }, Type = OpcodeType.Official, Cycles = 7, Length = 2, }, // DBnn: IN nn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xF2, Name = CommandID.JP  , Function = FunctionID.JMP, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 3, }, // F2nnnn: JP nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x00, Name = CommandID.NOP , Function = FunctionID.NOP, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // 00: NOP
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xD3, Name = CommandID.OUT , Function = FunctionID.OUT, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateByte, ParameterType.Value, EncodingType.ByteImmidate, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 2, }, // D3nn: OUT nn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xC1, Name = CommandID.POP , Function = FunctionID.POP, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.WordRegisterAF, EncodingType.Pos3, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 1, }, // C1: POP rr
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xC5, Name = CommandID.PUSH, Function = FunctionID.PUSH, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.WordRegisterAF, EncodingType.Pos3, false), }, Type = OpcodeType.Official, Cycles = 11, Length = 1, }, // C5: PUSH rr
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xC9, Name = CommandID.RET , Function = FunctionID.RET, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 10, Length = 1, }, // C9: RET
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x07, Name = CommandID.RLC , Function = FunctionID.RL_CY, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // 07: RLC
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x0F, Name = CommandID.RRC , Function = FunctionID.RR_CY, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // 0F: RRC
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xC7, Name = CommandID.RST , Function = FunctionID.RST, Params = new ParamEntry[] { new ParamEntry(ParameterID.EncodedValue, ParameterType.Value, EncodingType.Pos2, false), }, Type = OpcodeType.Official, Cycles = 11, Length = 1, }, // C7: RST e
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x90, Name = CommandID.SUB , Function = FunctionID.SUB, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.ByteRegister, EncodingType.Pos1, false), }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // 90: SUB r
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x96, Name = CommandID.SUB , Function = FunctionID.SUB, Params = new ParamEntry[] { new ParamEntry(ParameterID.WordReg_HL, ParameterType.WordRegisterPointer, EncodingType.None, false), }, Type = OpcodeType.Official, Cycles = 6, Length = 1, }, // 96: SUB M
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xCE, Name = CommandID.ACI , Function = FunctionID.ADD_C, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateByte, ParameterType.Value, EncodingType.ByteImmidate, false), }, Type = OpcodeType.Official, Cycles = 7, Length = 2, }, // CEnn: ACI nn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xC6, Name = CommandID.ADI , Function = FunctionID.ADD, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateByte, ParameterType.Value, EncodingType.ByteImmidate, false), }, Type = OpcodeType.Official, Cycles = 7, Length = 2, }, // C6nn: ADI nn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xA0, Name = CommandID.ANA , Function = FunctionID.AND, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.ByteRegister, EncodingType.Pos1, false), }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // A0: ANA r
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xA6, Name = CommandID.ANA , Function = FunctionID.AND, Params = new ParamEntry[] { new ParamEntry(ParameterID.WordReg_HL, ParameterType.WordRegisterPointer, EncodingType.None, false), }, Type = OpcodeType.Official, Cycles = 6, Length = 1, }, // A6: ANA M
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xE6, Name = CommandID.ANI , Function = FunctionID.AND, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateByte, ParameterType.Value, EncodingType.ByteImmidate, false), }, Type = OpcodeType.Official, Cycles = 7, Length = 2, }, // E6nn: ANI nn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xDC, Name = CommandID.CC  , Function = FunctionID.CALL, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 11, Length = 3, }, // DCnnnn: CC nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xFC, Name = CommandID.CM  , Function = FunctionID.CALL, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 17, Length = 3, }, // FCnnnn: CM nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x2F, Name = CommandID.CMA , Function = FunctionID.NOT, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // 2F: CMA
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x3F, Name = CommandID.CMC , Function = FunctionID.CY_INVERT, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // 3F: CMC
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xB8, Name = CommandID.CMP , Function = FunctionID.CMP, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.ByteRegister, EncodingType.Pos1, false), }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // B8: CMP r
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xBE, Name = CommandID.CMP , Function = FunctionID.CMP, Params = new ParamEntry[] { new ParamEntry(ParameterID.WordReg_HL, ParameterType.WordRegisterPointer, EncodingType.None, false), }, Type = OpcodeType.Official, Cycles = 6, Length = 1, }, // BE: CMP M
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xD4, Name = CommandID.CNC , Function = FunctionID.CALL, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 11, Length = 3, }, // D4nnnn: CNC nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xC4, Name = CommandID.CNZ , Function = FunctionID.CALL, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 11, Length = 3, }, // C4nnnn: CNZ nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xEC, Name = CommandID.CPE , Function = FunctionID.CALL, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 17, Length = 3, }, // ECnnnn: CPE nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xE4, Name = CommandID.CPO , Function = FunctionID.CALL, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 17, Length = 3, }, // E4nnnn: CPO nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xCC, Name = CommandID.CZ  , Function = FunctionID.CALL, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 11, Length = 3, }, // CCnnnn: CZ nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x09, Name = CommandID.DAD , Function = FunctionID.ADD, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.WordRegister, EncodingType.Pos3, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 1, }, // 09: DAD rr
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x05, Name = CommandID.DCR , Function = FunctionID.DEC, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.ByteRegister, EncodingType.Pos2, false), }, Type = OpcodeType.Official, Cycles = 5, Length = 1, }, // 05: DCR r
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x35, Name = CommandID.DCR , Function = FunctionID.DEC, Params = new ParamEntry[] { new ParamEntry(ParameterID.WordReg_HL, ParameterType.WordRegisterPointer, EncodingType.None, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 1, }, // 35: DCR M
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x0B, Name = CommandID.DCX , Function = FunctionID.DEC, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.WordRegister, EncodingType.Pos3, false), }, Type = OpcodeType.Official, Cycles = 5, Length = 1, }, // 0B: DCX rr
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x76, Name = CommandID.HLT , Function = FunctionID.HALT, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // 76: HLT
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x04, Name = CommandID.INR , Function = FunctionID.INC, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.ByteRegister, EncodingType.Pos2, false), }, Type = OpcodeType.Official, Cycles = 5, Length = 1, }, // 04: INR r
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x34, Name = CommandID.INR , Function = FunctionID.INC, Params = new ParamEntry[] { new ParamEntry(ParameterID.WordReg_HL, ParameterType.WordRegisterPointer, EncodingType.None, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 1, }, // 34: INR M
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x03, Name = CommandID.INX , Function = FunctionID.INC, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.WordRegister, EncodingType.Pos3, false), }, Type = OpcodeType.Official, Cycles = 5, Length = 1, }, // 03: INX rr
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xDA, Name = CommandID.JC  , Function = FunctionID.JMP, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 3, }, // DAnnnn: JC nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xFA, Name = CommandID.JM  , Function = FunctionID.JMP, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 3, }, // FAnnnn: JM nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xC3, Name = CommandID.JMP , Function = FunctionID.JMP, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 3, }, // C3nnnn: JMP nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xD2, Name = CommandID.JNC , Function = FunctionID.JMP, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 3, }, // D2nnnn: JNC nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xC2, Name = CommandID.JNZ , Function = FunctionID.JMP, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 3, }, // C2nnnn: JNZ nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xEA, Name = CommandID.JPE , Function = FunctionID.JMP, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 3, }, // EAnnnn: JPE nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xE2, Name = CommandID.JPO , Function = FunctionID.JMP, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 3, }, // E2nnnn: JPO nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xCA, Name = CommandID.JZ  , Function = FunctionID.JMP, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.Address, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 3, }, // CAnnnn: JZ nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x3A, Name = CommandID.LDA , Function = FunctionID.LD, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.AddressPointer, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 13, Length = 3, }, // 3Annnn: LDA nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x0A, Name = CommandID.LDAX, Function = FunctionID.LD, Params = new ParamEntry[] { new ParamEntry(ParameterID.WordReg_BC, ParameterType.WordRegisterPointer, EncodingType.None, false), }, Type = OpcodeType.Official, Cycles = 7, Length = 1, }, // 0A: LDAX B
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x1A, Name = CommandID.LDAX, Function = FunctionID.LD, Params = new ParamEntry[] { new ParamEntry(ParameterID.WordReg_DE, ParameterType.WordRegisterPointer, EncodingType.None, false), }, Type = OpcodeType.Official, Cycles = 7, Length = 1, }, // 1A: LDAX D
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x2A, Name = CommandID.LHLD, Function = FunctionID.LD, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.AddressPointer, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 16, Length = 3, }, // 2Annnn: LHLD nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x01, Name = CommandID.LXI , Function = FunctionID.LD, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.WordRegister, EncodingType.Pos3, false), new ParamEntry(ParameterID.ImmediateWord, ParameterType.Value, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 3, }, // 01nnnn: LXI rr, nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x40, Name = CommandID.MOV , Function = FunctionID.LD, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.ByteRegister, EncodingType.Pos2, false), new ParamEntry(ParameterID.RegisterAny, ParameterType.ByteRegister, EncodingType.Pos1, false), }, Type = OpcodeType.Official, Cycles = 5, Length = 1, }, // 40: MOV r, r
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x46, Name = CommandID.MOV , Function = FunctionID.LD, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.ByteRegister, EncodingType.Pos2, false), new ParamEntry(ParameterID.WordReg_HL, ParameterType.WordRegisterPointer, EncodingType.None, false), }, Type = OpcodeType.Official, Cycles = 7, Length = 1, }, // 46: MOV r, M
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x70, Name = CommandID.MOV , Function = FunctionID.LD, Params = new ParamEntry[] { new ParamEntry(ParameterID.WordReg_HL, ParameterType.WordRegisterPointer, EncodingType.None, false), new ParamEntry(ParameterID.RegisterAny, ParameterType.ByteRegister, EncodingType.Pos1, false), }, Type = OpcodeType.Official, Cycles = 7, Length = 1, }, // 70: MOV M, r
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x06, Name = CommandID.MVI , Function = FunctionID.LD, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.ByteRegister, EncodingType.Pos2, false), new ParamEntry(ParameterID.ImmediateByte, ParameterType.Value, EncodingType.ByteImmidate, false), }, Type = OpcodeType.Official, Cycles = 7, Length = 2, }, // 06nn: MVI r, nn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x36, Name = CommandID.MVI , Function = FunctionID.LD, Params = new ParamEntry[] { new ParamEntry(ParameterID.WordReg_HL, ParameterType.WordRegisterPointer, EncodingType.None, false), new ParamEntry(ParameterID.ImmediateByte, ParameterType.Value, EncodingType.ByteImmidate, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 2, }, // 36nn: MVI M, nn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xB0, Name = CommandID.ORA , Function = FunctionID.OR, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.ByteRegister, EncodingType.Pos1, false), }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // B0: ORA r
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xB6, Name = CommandID.ORA , Function = FunctionID.OR, Params = new ParamEntry[] { new ParamEntry(ParameterID.WordReg_HL, ParameterType.WordRegisterPointer, EncodingType.None, false), }, Type = OpcodeType.Official, Cycles = 6, Length = 1, }, // B6: ORA M
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xF6, Name = CommandID.ORI , Function = FunctionID.OR, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateByte, ParameterType.Value, EncodingType.ByteImmidate, false), }, Type = OpcodeType.Official, Cycles = 7, Length = 2, }, // F6nn: ORI nn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xE9, Name = CommandID.PCHL, Function = FunctionID.JMP, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 5, Length = 1, }, // E9: PCHL
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x17, Name = CommandID.RAL , Function = FunctionID.RL, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // 17: RAL
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x1F, Name = CommandID.RAR , Function = FunctionID.RR, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // 1F: RAR
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xD8, Name = CommandID.RC  , Function = FunctionID.RET, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 11, Length = 1, }, // D8: RC
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xF8, Name = CommandID.RM  , Function = FunctionID.RET, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 11, Length = 1, }, // F8: RM
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xD0, Name = CommandID.RNC , Function = FunctionID.RET, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 11, Length = 1, }, // D0: RNC
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xC0, Name = CommandID.RNZ , Function = FunctionID.RET, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 11, Length = 1, }, // C0: RNZ
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xF0, Name = CommandID.RP  , Function = FunctionID.RET, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 11, Length = 1, }, // F0: RP
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xE8, Name = CommandID.RPE , Function = FunctionID.RET, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 11, Length = 1, }, // E8: RPE
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xE0, Name = CommandID.RPO , Function = FunctionID.RET, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 11, Length = 1, }, // E0: RPO
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xC8, Name = CommandID.RZ  , Function = FunctionID.RET, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 11, Length = 1, }, // C8: RZ
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x98, Name = CommandID.SBB , Function = FunctionID.SUB_C, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.ByteRegister, EncodingType.Pos1, false), }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // 98: SBB r
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x9E, Name = CommandID.SBB , Function = FunctionID.SUB_C, Params = new ParamEntry[] { new ParamEntry(ParameterID.WordReg_HL, ParameterType.WordRegisterPointer, EncodingType.None, false), }, Type = OpcodeType.Official, Cycles = 6, Length = 1, }, // 9E: SBB M
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xDE, Name = CommandID.SBI , Function = FunctionID.SUB_C, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateByte, ParameterType.Value, EncodingType.ByteImmidate, false), }, Type = OpcodeType.Official, Cycles = 7, Length = 2, }, // DEnn: SBI nn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x22, Name = CommandID.SHLD, Function = FunctionID.LD, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.AddressPointer, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 3, }, // 22nnnn: SHLD nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xF9, Name = CommandID.SPHL, Function = FunctionID.LD, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 5, Length = 1, }, // F9: SPHL
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x32, Name = CommandID.STA , Function = FunctionID.LD, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateWord, ParameterType.AddressPointer, EncodingType.WordImmidate, false), }, Type = OpcodeType.Official, Cycles = 10, Length = 3, }, // 32nnnn: STA nnnn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x02, Name = CommandID.STAX, Function = FunctionID.LD, Params = new ParamEntry[] { new ParamEntry(ParameterID.WordReg_BC, ParameterType.WordRegisterPointer, EncodingType.None, false), }, Type = OpcodeType.Official, Cycles = 7, Length = 1, }, // 02: STAX B
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x12, Name = CommandID.STAX, Function = FunctionID.LD, Params = new ParamEntry[] { new ParamEntry(ParameterID.WordReg_DE, ParameterType.WordRegisterPointer, EncodingType.None, false), }, Type = OpcodeType.Official, Cycles = 7, Length = 1, }, // 12: STAX D
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0x37, Name = CommandID.STC , Function = FunctionID.CY_SET, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // 37: STC
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xD6, Name = CommandID.SUI , Function = FunctionID.SUB, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateByte, ParameterType.Value, EncodingType.ByteImmidate, false), }, Type = OpcodeType.Official, Cycles = 7, Length = 2, }, // D6nn: SUI nn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xEB, Name = CommandID.XCHG, Function = FunctionID.EX, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 5, Length = 1, }, // EB: XCHG
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xA8, Name = CommandID.XRA , Function = FunctionID.XOR, Params = new ParamEntry[] { new ParamEntry(ParameterID.RegisterAny, ParameterType.ByteRegister, EncodingType.Pos1, false), }, Type = OpcodeType.Official, Cycles = 4, Length = 1, }, // A8: XRA r
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xAE, Name = CommandID.XRA , Function = FunctionID.XOR, Params = new ParamEntry[] { new ParamEntry(ParameterID.WordReg_HL, ParameterType.WordRegisterPointer, EncodingType.None, false), }, Type = OpcodeType.Official, Cycles = 6, Length = 1, }, // AE: XRA M
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xEE, Name = CommandID.XRI , Function = FunctionID.XOR, Params = new ParamEntry[] { new ParamEntry(ParameterID.ImmediateByte, ParameterType.Value, EncodingType.ByteImmidate, false), }, Type = OpcodeType.Official, Cycles = 7, Length = 2, }, // EEnn: XRI nn
            new OpcodeEntry { Index = false, Prefix = 0x00, Encoding = 0xE3, Name = CommandID.XTHL, Function = FunctionID.EX, Params = new ParamEntry[] { }, Type = OpcodeType.Official, Cycles = 18, Length = 1, }, // E3: XTHL
        };

        public static CommandList i8080Commands = new CommandList()
        {
           { "ADC", CommandID.ADC },
           { "ADD", CommandID.ADD },
           { "CALL", CommandID.CALL },
           { "CP", CommandID.CP },
           { "CPI", CommandID.CPI },
           { "DAA", CommandID.DAA },
           { "DI", CommandID.DI },
           { "EI", CommandID.EI },
           { "IN", CommandID.IN },
           { "JP", CommandID.JP },
           { "NOP", CommandID.NOP },
           { "OUT", CommandID.OUT },
           { "POP", CommandID.POP },
           { "PUSH", CommandID.PUSH },
           { "RET", CommandID.RET },
           { "RLC", CommandID.RLC },
           { "RRC", CommandID.RRC },
           { "RST", CommandID.RST },
           { "SUB", CommandID.SUB },
           { "ACI", CommandID.ACI },
           { "ADI", CommandID.ADI },
           { "ANA", CommandID.ANA },
           { "ANI", CommandID.ANI },
           { "CC", CommandID.CC },
           { "CM", CommandID.CM },
           { "CMA", CommandID.CMA },
           { "CMC", CommandID.CMC },
           { "CMP", CommandID.CMP },
           { "CNC", CommandID.CNC },
           { "CNZ", CommandID.CNZ },
           { "CPE", CommandID.CPE },
           { "CPO", CommandID.CPO },
           { "CZ", CommandID.CZ },
           { "DAD", CommandID.DAD },
           { "DCR", CommandID.DCR },
           { "DCX", CommandID.DCX },
           { "HLT", CommandID.HLT },
           { "INR", CommandID.INR },
           { "INX", CommandID.INX },
           { "JC", CommandID.JC },
           { "JM", CommandID.JM },
           { "JMP", CommandID.JMP },
           { "JNC", CommandID.JNC },
           { "JNZ", CommandID.JNZ },
           { "JPE", CommandID.JPE },
           { "JPO", CommandID.JPO },
           { "JZ", CommandID.JZ },
           { "LDA", CommandID.LDA },
           { "LDAX", CommandID.LDAX },
           { "LHLD", CommandID.LHLD },
           { "LXI", CommandID.LXI },
           { "MOV", CommandID.MOV },
           { "MVI", CommandID.MVI },
           { "ORA", CommandID.ORA },
           { "ORI", CommandID.ORI },
           { "PCHL", CommandID.PCHL },
           { "RAL", CommandID.RAL },
           { "RAR", CommandID.RAR },
           { "RC", CommandID.RC },
           { "RM", CommandID.RM },
           { "RNC", CommandID.RNC },
           { "RNZ", CommandID.RNZ },
           { "RP", CommandID.RP },
           { "RPE", CommandID.RPE },
           { "RPO", CommandID.RPO },
           { "RZ", CommandID.RZ },
           { "SBB", CommandID.SBB },
           { "SBI", CommandID.SBI },
           { "SHLD", CommandID.SHLD },
           { "SPHL", CommandID.SPHL },
           { "STA", CommandID.STA },
           { "STAX", CommandID.STAX },
           { "STC", CommandID.STC },
           { "SUI", CommandID.SUI },
           { "XCHG", CommandID.XCHG },
           { "XRA", CommandID.XRA },
           { "XRI", CommandID.XRI },
           { "XTHL", CommandID.XTHL },
        };
    }
}
