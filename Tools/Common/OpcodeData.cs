using System;
using System.Collections.Generic;
using System.Text;

namespace OpcodeData
{
    public enum CommandID
    {
        None,

        // Opcodes z80
        ADC, ADD, AND, BIT, CALL, CCF, CP, CPD, CPDR, CPI, CPIR, CPL, DAA, DEC, DI, DJNZ, EI, EX, EXX, HALT, IM, IN, INC,
        IND, INDR, INI, INIR, JP, JR, LD, LDD, LDDR, LDI, LDIR, NEG, NOP, OR, OTDR, OTIR, OUT, OUTD, OUTI, POP, PUSH,
        RES, RET, RETI, RETN, RL, RLA, RLC, RLCA, RLD, RR, RRA, RRC, RRCA, RRD, RST, SBC, SCF, SET, SLA, SL1, SLL, SRA, SRL,
        SUB, XOR,

        // Opcodes GB
        LDH, LDHL, STOP, SWAP,

        // Opcodes i8080
        ACI, ADI, ANA, ANI, CC, CM, CMA, CMC, CMP, CNC, CNZ, CPE, CPO, CZ, DAD, DCR, DCX, HLT, INR, INX, JC, JM, JMP,
        JNC, JNZ, JPE, JPO, JZ, LDA, LDAX, LHLD, LXI, MOV, MVI, ORA, ORI, PCHL, RAL, RAR, RC, RM, RNC, RNZ, RP, RPE,
        RPO, RZ, SBB, SBI, SHLD, SPHL, STA, STAX, STC, SUI, XCHG, XRA, XRI, XTHL,

        OpcodeMax,
    }

    public enum FunctionID
    {
        None, 

        ADD, ADD_C, AND, BCD_ADJUST, BIT, CALL, CMP, CMP_D, CMP_DR, CMP_I, CMP_IR, CY_INVERT, CY_SET, DEC, DI, DJNZ, EI, EX, EXX,
        HALT, IM, IN, IN_D, IN_DR, IN_I, IN_IR, INC, JMP, JR, LD, LD_D, LD_DEC, LD_DR, LD_HIGH, LD_I, LD_INC, LD_IR, LD_SP, NEG,
        NOP, NOT, OR, OUT, OUT_D, OUT_DR, OUT_I, OUT_IR, POP, PUSH, RES, RET, RETI, RETN, RL, RL_A, RL_A_CY, RL_CY, ROLL_L, ROLL_R,
        RR, RR_A, RR_A_CY, RR_CY, RST, SET, SL_L, SL_SIGNED, SR_L, SR_SIGNED, STOP, SUB, SUB_C, SWAP, XOR, 
    }

    public enum ParameterID
    {
        // Not used
        None,

        // 8-bit Registers and Indexs into the register array
        ByteReg_B, ByteReg_C,
        ByteReg_D, ByteReg_E,
        ByteReg_H, ByteReg_L,
        ByteReg_A, ByteReg_F,
        ByteReg_SPH, ByteReg_SPL,
        ByteReg_PCH, ByteReg_PCL,
        ByteReg_IXH, ByteReg_IXL,
        ByteReg_IYH, ByteReg_IYL,
        ByteReg_I,
        ByteReg_R,

        // Index High and Low, can be IXL/H or IYL/H depending on prefix
        ByteReg_XXH, ByteReg_XXL,

        // 16-bit Registers
        Word = 0x40,
        WordReg_BC = Word + ByteReg_B,
        WordReg_DE = Word + ByteReg_D,
        WordReg_HL = Word + ByteReg_H,
        WordReg_AF = Word + ByteReg_A,
        WordReg_SP = Word + ByteReg_SPH,
        WordReg_PC = Word + ByteReg_PCH,
        WordReg_IX = Word + ByteReg_IXH,
        WordReg_IY = Word + ByteReg_IYH,

        // Index Registers, can be IX or IY depending on prefix
        WordReg_XX = Word + ByteReg_XXH,

        WordReg_AF_Alt,

        WordReg_HLI,    // HL Increment
        WordReg_HLD,    // HL Decrement

        RegisterAny,

        // These registers have more context based meanings
        Reg_B,  // ByteReg_B or WordReg_BC on 808x
        Reg_C,  // ByteReg_C or Flag_CY
        Reg_D,  // ByteReg_D or WordReg_DE on 808x
        Reg_H,  // ByteReg_H or WordReg_HL on 808x
        Reg_M,  // Flag_M or WordReg_HL on 808x

        RegisterMax = 0x80,

        // Immediate data
        ImmediateByte,
        ImmediateWord,
        EncodedValue,

        // Flags
        Flag_NZ,
        Flag_Z,
        Flag_NC,
        Flag_CY,
        Flag_PO,
        Flag_PE,
        Flag_P,
        Flag_M,

        FlagsAny,
        
        FlagsMax,

        Value0,
        Value1,
        Value2,
        Value3,
        Value4,
        Value5,
        Value6,
        Value7,

        EncodedMax,
    }

    public enum ParameterType
    {
        Unknown,

        // B, C, D, E, H, L, M, A, R, I, 
        ByteRegister,

        // BC, DE, HL, SP, AF
        WordRegister,
        WordRegisterAF,

        // IXL, IXH, IYL, IYH
        ByteIndexRegister,

        // IX, IY
        WordIndexRegister,

        // SP + *
        SPPlusOffset,

        // ($FF00 + c), ($FF00 + *), 
        HighMemPointerPlus,

        // (**)
        AddressPointer,

        // (c), (*), 
        BytePointer,

        // **
        Address,

        // e-2
        Displacment,

        // (BC), (DE), (HL), (SP), (HLI), (HLD)
        WordRegisterPointer,

        // (IX + n) (IY + n)
        WordIndexRegisterPointer,

        // NZ, Z, NC, C, PO, PE, P, M
        Flag,
        HalfFlag,

        // Immidate, Encoded
        Value,
        RstValue,

        Error,
    }

    public enum EncodingType
    {
        // This paramater dosn't need any encoding
        None,
        
        // Encoding Position 1, mask = 0b00000111
        Pos1,
        
        // Encoding Position 2, mask = 0b00111000
        Pos2,

        // Encoding Position 3, mask = 0b00110000
        Pos3,
        
        // Encoding Position 4, mask = 0b00011000
        Pos4,

        // A byte of Immidate data following the opcode
        ByteImmidate,

        // A word of Immidate data following the opcode
        WordImmidate,

        // An index offset, one byte long, encoded one byte after the Index prefix (After the opcode in most cases, but before the opcode if the CB prefix is used)
        IndexOffset,

    }

    public enum OpcodeType
    {
        Official,
        Unofficial,
         
        Undocumented,
    }

    public class ParamEntry
    {
        public ParameterID Param;
        public ParameterType Type;
        public EncodingType Encoding;
        public bool Implicit;

        public ParamEntry()
        {
            this.Param = ParameterID.None;
            this.Type = ParameterType.Unknown;
            this.Encoding = EncodingType.None;
            this.Implicit = false;
        }
        
        public ParamEntry(ParameterID Param, ParameterType Type)
        {
            this.Param = Param;
            this.Type = Type;
            this.Encoding = EncodingType.None;
            this.Implicit = false;
        }

        public ParamEntry(ParameterID Param, ParameterType Type, EncodingType Encoding, bool Implicit)
        {
            this.Param = Param;
            this.Type = Type;
            this.Encoding = Encoding;
            this.Implicit = Implicit;
        }

        public string ParamString(bool i8080 = false)
        {
            switch (Param)
            {
                case ParameterID.RegisterAny:
                    {
                        if (Type == ParameterType.WordRegister)
                            return "rr";

                        else if (Type == ParameterType.WordRegisterAF)
                            return "rr";

                        else if (Type == ParameterType.ByteRegister)
                            return "r";

                        else if (Type == ParameterType.ByteIndexRegister)
                            return "xxx";

                        else if (Type == ParameterType.WordIndexRegister)
                            return "xx";

                        else if (Type == ParameterType.WordIndexRegisterPointer) // should never happen, but better to be safe
                            return "(xx + oo)";
                    }
                    break;

                case ParameterID.WordReg_AF_Alt:
                    return "AF'";

                case ParameterID.FlagsAny:
                    return "ff";

                case ParameterID.ImmediateWord:
                    {
                        if (Type == ParameterType.AddressPointer && !i8080)
                            return "(nnnn)";

                        return "nnnn";
                    }

                case ParameterID.ImmediateByte:
                    {
                        if (Type == ParameterType.Displacment)
                            return "e-2";

                        else if (Type == ParameterType.HighMemPointerPlus)
                            return "($ff00 + nn)";

                        else if (Type == ParameterType.BytePointer)
                            return "(nn)";

                        else if (Type == ParameterType.SPPlusOffset)
                            return "SP + nn";

                        return "nn";
                    }

                case ParameterID.EncodedValue:
                    return "e";

                case ParameterID.Flag_Z:
                    return "Z";

                case ParameterID.Flag_NZ:
                    return "NZ";

                case ParameterID.Flag_CY:
                    return "CY";

                case ParameterID.Flag_NC:
                    return "NC";

                case ParameterID.Flag_P:
                    return "P";

                case ParameterID.Flag_M:
                    return "M";

                case ParameterID.Flag_PO:
                    return "PO";

                case ParameterID.Flag_PE:
                    return "PE";

                case ParameterID.ByteReg_C:
                    if (Type == ParameterType.HighMemPointerPlus)
                        return ("($ff00 + C)");

                    else if (Type == ParameterType.BytePointer)
                        return ("(C)");
                    break;

                case ParameterID.WordReg_XX:
                    if (Type == ParameterType.WordIndexRegisterPointer)
                        return ("(XX + oo)");
                    break;

                case ParameterID.WordReg_BC:
                    if (i8080)
                        return "B";

                    if (Type == ParameterType.WordRegisterPointer)
                        return ("(BC)");
                    break;

                case ParameterID.WordReg_DE:
                    if (i8080)
                        return "D";

                    if (Type == ParameterType.WordRegisterPointer)
                        return ("(DE)");
                    break;

                case ParameterID.WordReg_HL:
                    if (i8080)
                    {
                        if (Type == ParameterType.WordRegisterPointer)
                            return ("M");
                        else
                            return "H";
                    }

                    if (Type == ParameterType.WordRegisterPointer)
                        return ("(HL)");
                    break;

                case ParameterID.WordReg_SP:
                    if (i8080)
                        return "SP";

                    if (Type == ParameterType.WordRegisterPointer)
                        return ("(SP)");
                    break;

                case ParameterID.WordReg_HLI:
                    return ("(HLI)");

                case ParameterID.WordReg_HLD:
                    return ("(HLD)");
            }

            if (Type == ParameterType.Value && Param >= ParameterID.Value0 && Param <= ParameterID.Value7)
                return (Param - ParameterID.Value0).ToString();

            if (Type == ParameterType.RstValue && Param >= ParameterID.Value0 && Param <= ParameterID.Value7)
                return String.Format("{0:X2}h", (Param - ParameterID.Value0) * 8);
            
            return Param.ToString();
        }

        public override string ToString()
        {
            if (Implicit)
                return "!" + ParamString();

            return ParamString();

        }
    }

    public class OpcodeEntry
    {
        public CommandID Name;
        public FunctionID Function;
        public bool Index;
        public byte Prefix;
        public byte Encoding;
        public ParamEntry[] Params;
        public OpcodeType Type;
        public short Cycles;
        public byte Length;

        public OpcodeEntry()
        {
        }

        public OpcodeEntry(OpcodeEntry Clone)
        {
            Name = Clone.Name;
            Function = Clone.Function;
            Index = Clone.Index;
            Prefix = Clone.Prefix;
            Encoding = Clone.Encoding;
            Params = (ParamEntry[])Clone.Params.Clone();
            Type = Clone.Type;
            Cycles = Clone.Cycles;
            Length = Clone.Length;
        }

        public override string ToString()
        {
            StringBuilder Output = new StringBuilder();

            Output.AppendFormat("{0}", Name);

            bool first = true;
            foreach (ParamEntry Param in Params)
            {
                if(!first)
                    Output.Append(',');
                
                Output.AppendFormat(" {0}", Param.ToString());

                first = false;
            }

            return Output.ToString();
        }
    }
}