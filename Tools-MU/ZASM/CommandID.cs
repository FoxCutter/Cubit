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
        M,
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

        // Immediate data
        ImmediateByte = 0x80,
        ImmediateWord,

        RegisterMax = 0xFF,

        // Flags
        Flag_NZ,
        Flag_Z,
        Flag_NC,
        Flag_C,
        Flag_PO,
        Flag_PE,
        Flag_P,
        Flag_M,

        FlagsMax,

        // Opcodes
        ADC, ADD, AND, BIT, CALL, CCF, CP, CPD, CPDR, CPI, CPIR, CPL, DAA, DEC, DI, DJNZ, EI, EX, EXX, HALT, IM, IN, INC,
        IND, INDR, INI, INIR, JP, JR, LD, LDD, LDDR, LDI, LDIR, NEG, NOP, OR, OTDR, OTIR, OUT, OUTD, OUTI, POP, PUSH,
        RES, RET, RETI, RETN, RL, RLA, RLC, RLCA, RLD, RR, RRA, RRC, RRCA, RRD, RST, SBC, SCF, SET, SLA, SLL, SRA, SRL,
        SUB, XOR,

        OpcodeMax,
        
        // Psudo Operators
        CONST, BYTE, WORD, DWORD, DC, RESB, RESW, RESD, EQU, 

        // Commands
        EXTERN, PUBLIC, INCLUDE, Z80, i8080, GAMEBOY, ORG, END, SECTION, SIZE, FILL,

        // Preprossor commands
        IF, ELSE, ELSEIF, ENDIF,

        CommandMax,
    }
}
