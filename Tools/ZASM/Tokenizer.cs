using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZASM
{
    enum TokenType
    {
        None,
        End,
        WhiteSpace,
        Unknown,

        Comment,
        LineBreak,
        Identifier,
        Keyword,
        Number,
        Symbol,
        String,
        Label,

        Unarray,

        // Symbol Types

    }

    /*
     *      Left-to-right 
     * 2:   Displacment [, ]
     *      HIGH, LOW
     * 
     *      Right-to-left 
     * 3:   Unary plus and minus
     *      Logical NOT and bitwise NOT
     *      @ (Address)
     *      
     *      Left-to-right 
     * 5:   Multiplication, division, and remainder
     * 6:   Addition and subtraction
     * 7:   Bitwise left shift and right shift
     * 8:   <, <=, >, >=
     * 9:   ==, !=, = <>
     * 10:  Bitwise AND
     * 11:  Bitwise XOR
     * 12:  Bitwise OR
     * 13:  Logical AND
     * 14:  Logical OR
     * 
     *      Right-to-left 
     * 15:  Ternary conditional
     * 
     *      Left-to-right 
     * 16:  Comma
     */

    struct Token
    {
        public TokenType Type;
        public List<char> Value;

        public int Line;
        public int Character;
        public long Pos;

        override public string ToString()
        {
            if(Value == null || Value.Count == 0)
                return "";

            return new string(Value.ToArray());
        }

        public int ToInt()
        {
            if (Type != TokenType.Number)
                return 0;
            
            if (Value == null || Value.Count == 0)
                return 0;

            return int.Parse(ToString());
        }
    }

    /*
    .ORG        ; Current Offset
    .INCLUDE    ; Include file
    .END        ; End of File
    .OPTION     ; Gerenal Options

    ; Data Commands
    .DC         ; Ansii string high bit set on last byte
    .DB         ; Byte data
    .BYTE       ; Byte data
    .WORD       ; Word data
    .DW         ; Word Data
    .DEFS       ; Uninitilized data

    .MACRO      ; Macro
    .ENDMACRO   

    .PROC       ; Function
    .ENDPROC
    
    .PHASE      ; Start phase processing (Code stays in current org, but assumes different offset)
    .ENDPHASE   ; End phase

    ; Conditional Compiling
    .IF         
    .ELSE
    .ELSEIF
    .ENDIF
    .IFDEF  
    .IFNDEF

    .MESSAGE    ; Output message
    .ERROR      ; Output Error

     */

    enum CommandID
    {
        // Not used
        None = 0xFF,

        // 8-bit Registers and Indexs into the register array
        A,
        F,
        B,
        C,
        D,
        E,
        H, L,
        SPH, SPL,
        PCH, PCL,
        IXH, IXL,
        IYH, IYL,
        I,
        R,

        // Count of 8-bit registers
        RegisterCount,

        // 16-bit Registers
        Word = 0x20,
        AF = Word + A,
        BC = Word + B,
        DE = Word + D,
        HL = Word + H,
        SP = Word + SPH,
        PC = Word + PCH,
        IX = Word + IXH,
        IY = Word + IXH,

        // Index register (can be HL, IX, IY)
        HX = 0x40,

        // Index register low (can be L, IXL, IYL)
        XL,

        // Index register high (can be H, IXH, IYH)
        XH,

        // Index register with Displacment (assuming it's IX or IY)
        HD,

        // Immediate data
        Immediate = 0x80,
        ImmediateByte = Immediate,
        ImmediateWord = Immediate, 
        
        //// Register
        //A, F, B, C, D, E, H, L, I, R, AF, BC, DE, HL, IX, IY, PC, SP,
        //SPH, SPL, IXH, IXL, IYH, IYL,

        RegisterMax = 0xFF,

        //// Dummy Index Registers
        //HD, HX, XH, XL, ImmediateByte, ImmediateWord,

        //DummyRegisterMax,

        // Flags
        CY, NC, Z, NZ, PE, PO, P, M,

        FlagsMax,

        // Opcodes
        ADC, ADD, AND, BIT, CALL, CCF, CP, CPD, CPDR, CPI, CPIR, CPL,
        DAA, DEC, DI, DJNZ, EI, EX, EXX, HALT, IM, IN, INC, IND,
        INDR, INI, INIR, JP, JR, LD, LDD, LDDR, LDI, LDIR, NEG, NOP,
        OR, OTDR, OTIR, OUT, OUTD, OUTI, POP, PUSH, RES, RET, RETI,
        RETN, RL, RLA, RLC, RLCA, RLD, RR, RRA, RRC, RRCA, RRD,
        RST, SBC, SCF, SET, SLA, SLL, SRA, SRL, SUB, XOR,

        OpcodeMax,

        // Commands
        HIGH, LOW, BYTE, DC, DEFS, ELSE, ELSEIF, END, ENDIF, ENDMACRO,
        ENDPHASE, ENDPROC, ERROR, IF, IFDEF, IFNDEF, INCLUDE, MACRO,
        MESSAGE, OPTION, ORG, PHASE, PROC, WORD, EQU, Z80, i8080,

        CommandMax,
    }
    
    class Tokenizer
    {
        BinaryReader DataStream;
        int CurrentLine;
        int CurrentCharacter;
        Stack<char> Buffer;

        public Tokenizer(Stream InputStream)
        {
            DataStream = new BinaryReader(InputStream);
            Buffer = new Stack<char>();
            CurrentLine = 1;
            CurrentCharacter = 1;
        }

        TokenType PeakNextTokenType()
        {
            int Current = -1;

            if (Buffer.Count != 0)
            {
                Current = Buffer.Pop();                
            }
            else
            {
                Current = DataStream.PeekChar();
            }

            if (Current == -1)
                return TokenType.End;

            else if (Current >= 0x80)
                return TokenType.Unknown;
            
            else
                return DataTables.CharacterData[Current];
        }

        char PeakNextCharacter()
        {
            int Value = -1;
            if (Buffer.Count != 0)
            {
                Value = Buffer.Pop();                
            }
            else
            {
                Value = DataStream.PeekChar();
            }

            if (Value == -1)
                return '\0';

            return (char)Value;
        }
        
        char ReadNextCharacter()
        {
            char Value = '\0';

            if (Buffer.Count != 0)
            {
                Value = Buffer.Pop();                
            }
            else
            {
                Value = DataStream.ReadChar();
            }

            CurrentCharacter++;

            return Value;
        }

        void UnReadCharacter(char Value)
        {
            Buffer.Push(Value);
            CurrentCharacter--;
        }

        void ReadIdentifier(ref Token Data)
        {
            while (true)
            {
                TokenType NextType = PeakNextTokenType();
                char NextValue = PeakNextCharacter();

                if (NextType == TokenType.Number)
                    Data.Value.Add(ReadNextCharacter());

                else if (NextType == TokenType.Identifier)
                    Data.Value.Add(ReadNextCharacter());

                else if (NextType == TokenType.Symbol && "$.?_".Contains(NextValue))
                    Data.Value.Add(ReadNextCharacter());

                else
                    break;
            }
        }

        void ReadString(ref Token Data)
        {
            while (true)
            {
                TokenType Current = PeakNextTokenType();
                if (Current == TokenType.LineBreak || Current == TokenType.End)
                    break; // ERROR

                char CurrentValue = ReadNextCharacter();
                Data.Value.Add(CurrentValue);

                if (Current == TokenType.Symbol && CurrentValue == Data.Value[0])
                    break;
            }

        }

        void SkipWhitespaces()
        {
            while (PeakNextTokenType() == TokenType.WhiteSpace)
                ReadNextCharacter();
        }

        public void FlushLine()
        {
            Buffer.Clear();

            while (true)
            {
                TokenType Current = PeakNextTokenType();
                if (Current == TokenType.End)
                    break;

                else if (Current == TokenType.LineBreak)
                {
                    // Handle CR/LF
                    if (ReadNextCharacter() == '\r' && PeakNextCharacter() == '\n')
                        ReadNextCharacter();

                    CurrentLine++;
                    CurrentCharacter = 1;
                    break;
                }
                else
                {
                    ReadNextCharacter();
                }
            }

        }

        public Token NextToken()
        {
            Token Ret;
            bool StartOfLine = false;

            if (CurrentCharacter == 1)
                StartOfLine = true;

            Ret.Type = TokenType.End;
            Ret.Value = new List<char>();

            Ret.Line = CurrentLine;
            Ret.Character = CurrentCharacter;
            Ret.Pos = DataStream.BaseStream.Position;

            SkipWhitespaces();

            Ret.Type = PeakNextTokenType();

            // Decide what token we have based on the type of the current character
            switch (Ret.Type)
            {
                case TokenType.End:
                    Ret.Type = TokenType.End;
                    return Ret;

                case TokenType.Number:
                    Ret.Value.Add(ReadNextCharacter());
                    break;

                case TokenType.Identifier:
                    Ret.Value.Add(ReadNextCharacter());
                    break;

                case TokenType.Symbol:
                    Ret.Value.Add(ReadNextCharacter());

                    if (Ret.Value[0] == '?' && PeakNextTokenType() == TokenType.Identifier)
                        Ret.Type = TokenType.Identifier;

                    else
                    {
                        if (Ret.Value[0] == '<' && (PeakNextCharacter() == '<' || PeakNextCharacter() == '='))
                            Ret.Value.Add(ReadNextCharacter());

                        if (Ret.Value[0] == '>' && (PeakNextCharacter() == '>' || PeakNextCharacter() == '='))
                            Ret.Value.Add(ReadNextCharacter());

                        if (Ret.Value[0] == '=' && PeakNextCharacter() == '=')
                            Ret.Value.Add(ReadNextCharacter());

                        if (Ret.Value[0] == '!' && PeakNextCharacter() == '=')
                            Ret.Value.Add(ReadNextCharacter());

                        return Ret;
                    }
                    
                    break;

                case TokenType.LineBreak:
                    Ret.Type = TokenType.LineBreak;
                    Ret.Value.Add(ReadNextCharacter());

                    // Handle CR/LF
                    if (Ret.Value[0] == '\r' && PeakNextCharacter() == '\n')
                        Ret.Value.Add(ReadNextCharacter());

                    CurrentLine++;
                    CurrentCharacter = 1;
                    return Ret;
            }


            switch (Ret.Type)
            {
                case TokenType.Number:
                    while (PeakNextTokenType() == TokenType.Identifier || PeakNextTokenType() == TokenType.Number || PeakNextCharacter() == '.')
                        Ret.Value.Add(ReadNextCharacter());
                    break;

                case TokenType.Identifier:
                    ReadIdentifier(ref Ret);
                    break;

                case TokenType.Comment:
                    while (PeakNextTokenType() != TokenType.LineBreak && PeakNextTokenType() != TokenType.End)
                        Ret.Value.Add(ReadNextCharacter());
                    break;

                case TokenType.String:
                    ReadString(ref Ret);
                    break;

                default:
                    while (PeakNextTokenType() == Ret.Type)
                        Ret.Value.Add(ReadNextCharacter());
                    break;
            }

            if (Ret.Type == TokenType.Identifier)
            {
                if (StartOfLine && PeakNextTokenType() == TokenType.Symbol && PeakNextCharacter() == ':')
                {
                    Ret.Type = TokenType.Label;
                    ReadNextCharacter();
                }
                else if (DataTables.Commands.ContainsKey(Ret.ToString()))
                {
                    Ret.Type = TokenType.Keyword;
                    CommandID ID = DataTables.Commands[Ret.ToString()];
                }
            }
            
            return Ret;
        }
    }
}
