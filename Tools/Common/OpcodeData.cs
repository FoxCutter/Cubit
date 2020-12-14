using System;
using System.Text;

namespace OpcodeData
{
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

        ByteReg_M,

        // Index High and Low, can be IXL/H or IYL/H depending on prefix
        ByteReg_Izb, ByteReg_IzH, ByteReg_IzL,

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

        // Could be only BC or DE
        WordReg_BD,
        WordReg_PSW,

        // Index Registers, can be IX or IY depending on prefix
        WordReg_Iz = Word + ByteReg_IzH,

        WordReg_AF_Alt,

        WordReg_HLI,    // HL Increment
        WordReg_HLD,    // HL Decrement

        RegisterAny,

        // These registers have more context based meanings
        Reg_B,  // ByteReg_B or WordReg_BC on 808x
        Reg_C,  // ByteReg_C or Flag_CY on Z80 or GB
        Reg_D,  // ByteReg_D or WordReg_DE on 808x
        Reg_H,  // ByteReg_H or WordReg_HL on 808x
        Reg_M,  // Flag_M or WordReg_HL on 808x

        RegisterMax = 0x80,

        // Flags
        Flag_NZ,
        Flag_Z,
        Flag_NC,
        Flag_CY,
        Flag_PO,
        Flag_PE,
        Flag_P,
        Flag_M,

        Flag_NK,
        Flag_K,

        FlagsAny,
        
        FlagsMax,

        // Immediate data
        ImmediateByte,
        ImmediateWord,
        EncodedValue,

        Value0,
        Value1,
        Value2,
        Value3,
        Value4,
        Value5,
        Value6,
        Value7,
        Value8,

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

        // NZ, Z, NC, C, PO, PE, P, M
        Flag,
        HalfFlag,

        // SP + *
        SPPlusOffset,

        // **
        Address,

        // e-2
        Displacment,

        // ($FF00 + c), ($FF00 + *), 
        HighMemPointerPlus,

        // (**)
        AddressPointer,

        // (c), (*), 
        BytePointer,

        // (BC), (DE), (HL), (SP), (HLI), (HLD)
        WordRegisterPointer,

        // (IX + n) (IY + n)
        WordIndexRegisterPointer,

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
        Source,
        
        // Encoding Position 2, mask = 0b00111000
        Dest,

        // Encoding Position 2, mask = 0b00111000
        Flags,

        // Encoding Position 3, mask = 0b00110000
        WordReg,
        
        // Encoding Position 4, mask = 0b00011000
        HalfFlag,

        // A byte of Immidate data following the opcode
        ByteImmidate,

        // A word of Immidate data following the opcode
        WordImmidate,

        // An index offset, one byte long, encoded one byte after the Index prefix (After the opcode in most cases, but before the opcode if the CB prefix is used)
        IndexOffset,

    }

    public enum OpcodeStatus
    {
        Documented,
        ExecuteOnly,         
        Undocumented,
    }

    public class ParamEntry
    {
        public ParameterID Param;
        public ParameterType Type;
        public EncodingType Encoding;
        public bool Implicit;

        public string ParamString()
        {
            if (Type == ParameterType.Value && Param >= ParameterID.Value0 && Param <= ParameterID.Value7)
                return (Param - ParameterID.Value0).ToString();

            if (Type == ParameterType.RstValue && Param >= ParameterID.Value0 && Param <= ParameterID.Value7)
                return String.Format("{0:X2}h", (Param - ParameterID.Value0) * 8);
            
            return Param.ToString();
        }

        public override string ToString()
        {
            if (Implicit)
                return "#" + ParamString();

            return ParamString();

        }
    }
}