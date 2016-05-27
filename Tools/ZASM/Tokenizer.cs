using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZASM
{
    enum CharacterType
    {
        End,
        WhiteSpace,
        Letter,
        Number,
        Symbol,
        LineBreak,
        Unknown,
    }

    enum TokenType
    {
        End,
        Comment,
        LineBreak,
        Identifier,
        Keyword,
        Number,
        Symbol,
        String,
        Label,
    }

    struct Token
    {
        public TokenType Type;
        public List<char> Value;

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
        // Register
        A, F, B, C, D, E, H, L, I, R, AF, BC, DE, HL, IX, IY, PC, SP,
        SPH, SPL, IXH, IXL, IYH, IYL,

        RegisterMax,

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
        MESSAGE, OPTION, ORG, PHASE, PROC, WORD, EQU,

        CommandMax,
    }
    
    class Tokenizer
    {
        BinaryReader DataStream;

        public Tokenizer(Stream InputStream)
        {
            DataStream = new BinaryReader(InputStream);
        }

        CharacterType PeakNextCharacter()
        {
            int Current = DataStream.PeekChar();

            if (Current == -1)
                return CharacterType.End;

            else if (Current >= 0x80)
                return CharacterType.Unknown;
            
            else
                return DataTables.CharacterData[Current];
        }

        public Token NextToken()
        {
            Token Ret;

            Ret.Type = TokenType.End;
            Ret.Value = new List<char>();

            while (PeakNextCharacter() == CharacterType.WhiteSpace)
                DataStream.Read();

            CharacterType Current = PeakNextCharacter();

            switch (Current)
            {
                case CharacterType.End:
                    Ret.Type = TokenType.End;
                    return Ret;

                case CharacterType.Number:
                    Ret.Type = TokenType.Number;
                    break;

                case CharacterType.Letter:
                    Ret.Type = TokenType.Identifier;
                    break;

                case CharacterType.Symbol:
                    if (DataStream.PeekChar() == ';')
                        Ret.Type = TokenType.Comment;

                    else if (DataStream.PeekChar() == '$')
                        Ret.Type = TokenType.Number;

                    else if (DataStream.PeekChar() == '.' || DataStream.PeekChar() == '@')
                        Ret.Type = TokenType.Identifier;

                    else if (DataStream.PeekChar() == '"')
                        Ret.Type = TokenType.String;
                        
                    else
                        Ret.Type = TokenType.Symbol;

                    Ret.Value.Add(DataStream.ReadChar());
                    
                    break;

                case CharacterType.LineBreak:
                    Ret.Type = TokenType.LineBreak;
                    break;
            }


            if (Ret.Type == TokenType.End || Ret.Type == TokenType.Symbol)
                return Ret;

            switch (Ret.Type)
            {
                case TokenType.Number:
                    while (PeakNextCharacter() == CharacterType.Letter || PeakNextCharacter() == CharacterType.Number)
                        Ret.Value.Add(DataStream.ReadChar());
                    break;

                case TokenType.Identifier:
                    while (PeakNextCharacter() == CharacterType.Letter || PeakNextCharacter() == CharacterType.Number || (PeakNextCharacter() == CharacterType.Symbol && "$.?@_".Contains((char)DataStream.PeekChar())))
                        Ret.Value.Add(DataStream.ReadChar());

                    if (PeakNextCharacter() == CharacterType.Symbol && DataStream.PeekChar() == ':')
                    {
                        Ret.Type = TokenType.Label;
                        DataStream.ReadChar();
                    }
                    break;

                case TokenType.Comment:
                    while (PeakNextCharacter() != CharacterType.LineBreak && PeakNextCharacter() != CharacterType.End)
                        Ret.Value.Add(DataStream.ReadChar());
                    break;

                case TokenType.String:
                    while (true)
                    {
                        Current = PeakNextCharacter();
                        if (Current == CharacterType.LineBreak || Current == CharacterType.End)
                            break; // ERROR

                        Ret.Value.Add(DataStream.ReadChar());

                        if (Current == CharacterType.Symbol && Ret.Value.Last() == Ret.Value[0])
                            break;
                    }
                    break;

                default:
                    while (PeakNextCharacter() == Current)
                        Ret.Value.Add(DataStream.ReadChar());
                    break;
            }

            if (Ret.Type == TokenType.Identifier)
            {
                if (DataTables.Commands.ContainsKey(Ret.ToString()))
                {
                    Ret.Type = TokenType.Keyword;
                    CommandID ID = DataTables.Commands[Ret.ToString()];
                }
            }
            
            return Ret;
        }
    }
}
