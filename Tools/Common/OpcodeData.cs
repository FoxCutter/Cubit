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
        B,
        C,
        D,
        E,
        H, L,
        A, F,
        SPH, SPL,
        PCH, PCL,
        IXH, IXL,
        IYH, IYL,
        I,
        R,

        // Index High and Low, can be IXL/H or IYL/H depending on prefix
        XXH, XXL,

        // 16-bit Registers
        Word = 0x40,
        BC = Word + B,
        DE = Word + D,
        HL = Word + H,
        AF = Word + A,
        SP = Word + SPH,
        PC = Word + PCH,
        IX = Word + IXH,
        IY = Word + IYH,

        // Index Registers, can be IX or IY depending on prefix
        XX = Word + XXH,

        AF_Alt,

        HLI,    // HL Increment
        HLD,    // HL Decrement

        RegisterAny,

        RegisterMax = 0x80,

        // Immediate data
        ImmediateByte,
        ImmediateWord,
        EncodedByte,

        // Flags
        Flag_NZ,
        Flag_Z,
        Flag_NC,
        Flag_C,
        Flag_PO,
        Flag_PE,
        Flag_P,
        Flag_M,

        FlagsAny,
        
        FlagsMax,

        Encoded0,
        Encoded1,
        Encoded2,
        Encoded3,
        Encoded4,
        Encoded5,
        Encoded6,
        Encoded7,

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

        string ParamString()
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

                case ParameterID.AF_Alt:
                    return "AF'";

                case ParameterID.FlagsAny:
                    return "ff";

                case ParameterID.ImmediateWord:
                    {
                        if (Type == ParameterType.AddressPointer)
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

                case ParameterID.EncodedByte:
                    return "e";

                case ParameterID.Flag_Z:
                    return "Z";

                case ParameterID.Flag_NZ:
                    return "NZ";

                case ParameterID.Flag_C:
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

                case ParameterID.C:
                    if (Type == ParameterType.HighMemPointerPlus)
                        return ("($ff00 + C)");
                    else if (Type == ParameterType.BytePointer)
                        return ("(C)");
                    break;

                case ParameterID.XX:
                    if (Type == ParameterType.WordIndexRegisterPointer)
                        return ("(XX + oo)");
                    break;

                case ParameterID.BC:
                    if (Type == ParameterType.WordRegisterPointer)
                        return ("(BC)");
                    break;

                case ParameterID.DE:
                    if (Type == ParameterType.WordRegisterPointer)
                        return ("(DE)");
                    break;

                case ParameterID.HL:
                    if (Type == ParameterType.WordRegisterPointer)
                        return ("(HL)");
                    break;

                case ParameterID.SP:
                    if (Type == ParameterType.WordRegisterPointer)
                        return ("(SP)");
                    break;

                case ParameterID.HLI:
                    return ("(HLI)");

                case ParameterID.HLD:
                    return ("(HLD)");
            }

            if (Type == ParameterType.Value && Param >= ParameterID.Encoded0 && Param <= ParameterID.Encoded7)
                return (Param - ParameterID.Encoded0).ToString();


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