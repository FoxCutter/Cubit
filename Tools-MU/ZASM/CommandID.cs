using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    enum CommandID
    {
        // Not used
        None,

        // 8-bit Registers and Indexs into the register array
        B,
        C,
        D,
        E,
        H, L,
        A,
        SPH, SPL,
        PCH, PCL,
        IXH, IXL,
        IYH, IYL,
        I,
        R,

        // 16-bit Registers
        Word = 0x40,
        AF = Word + A,
        BC = Word + B,
        DE = Word + D,
        HL = Word + H,
        SP = Word + SPH,
        PC = Word + PCH,
        IX = Word + IXH,
        IY = Word + IYH,
        
        AF_Alt,
        
        M,      // Indirect memory access (i8080 version of (HL))
        PSW,    // Processor Status Word
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

        // Opcodes z80
        ADC, ADD, AND, BIT, CALL, CCF, CP, CPD, CPDR, CPI, CPIR, CPL, DAA, DEC, DI, DJNZ, EI, EX, EXX, HALT, IM, IN, INC,
        IND, INDR, INI, INIR, JP, JR, LD, LDD, LDDR, LDI, LDIR, NEG, NOP, OR, OTDR, OTIR, OUT, OUTD, OUTI, POP, PUSH,
        RES, RET, RETI, RETN, RL, RLA, RLC, RLCA, RLD, RR, RRA, RRC, RRCA, RRD, RST, SBC, SCF, SET, SLA, SLL, SRA, SRL,
        SUB, XOR,

        // Opcodes GB
        LDH, LDHL, STOP, SWAP,

        // Opcodes i8080
        ACI, ADI, ANA, ANI, CC, CM, CMA, CMC, CMP, CNC, CNZ, CPE, CPO, CZ, DAD, DCR, DCX, HLT, INR, INX, JC, JM, JMP, 
        JNC, JNZ, JPE, JPO, JZ, LDA, LDAX, LHLD, LXI, MOV, MVI, ORA, ORI, PCHL, RAL, RAR, RC, RM, RNC, RNZ, RP, RPE,
        RPO, RZ, SBB, SBI, SHLD, SPHL, STA, STAX, STC, SUI, XCHG, XRA, XRI, XTHL,

        OpcodeMax,

        // Psudo Operators
        BYTE, WORD, DWORD, DC, RESB, RESW, RESD, 

        DataCommandsMax,

        DEFL, EQU, 

        // Commands
        EXTERN, PUBLIC, INCLUDE, Z80, i8080, GAMEBOY, ORG, END, SECTION, SIZE, FILL, POS,

        CommandMax,

        // Preprocessor commands
        IF, ELSE, ELSEIF, ENDIF,

        PreprocessorMax,
    }

}
