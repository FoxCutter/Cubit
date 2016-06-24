using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZASM
{


    /*
     *      Right-to-left 
     * 2:   HIGH, LOW
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
        None,

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
        IY = Word + IYH,

        // Immediate data
        ImmediateByte = 0x80,
        ImmediateWord, 
        
        RegisterMax = 0xFF,

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

        // Psudo Operators
        HIGH, LOW,

        OpcodeMax,

        // Commands
        BYTE, DC, DEFS, ELSE, ELSEIF, END, ENDIF, ENDMACRO,
        ENDPHASE, ENDPROC, ERROR, IF, IFDEF, IFNDEF, INCLUDE, MACRO,
        MESSAGE, OPTION, ORG, PHASE, PROC, WORD, EQU, DEFL, Z80, i8080,

        CommandMax,

        Encoded = 0xF000,
    }
    
    class Tokenizer
    {
        BinaryReader _DataStream;
        Token _LastToken;
        Token _NextToken;
        int _CurrentLine;
        int _CurrentCharacter;
        FileInformation _InputFile;

        public Tokenizer(Stream InputStream)
        {
            _InputFile = null;
            _DataStream = new BinaryReader(InputStream);
            _CurrentLine = 1;
            _CurrentCharacter = 1;
            _LastToken.Type = TokenType.None;
            _NextToken = GetNextToken();
        }

        TokenType PeekNextTokenType()
        {
            int Current = _DataStream.PeekChar();

            if (Current == -1)
                return TokenType.End;

            else if (Current >= 0x80)
                return TokenType.Unknown;
            
            else
                return DataTables.CharacterData[Current];
        }

        char PeekNextCharacter()
        {
            int Value = _DataStream.PeekChar();

            if (Value == -1)
                return '\0';

            return (char)Value;
        }
        
        char ReadNextCharacter()
        {
            char Value =  _DataStream.ReadChar();

            _CurrentCharacter++;

            return Value;
        }

        bool ReadNumber(ref Token Data)
        {
            while (true)
            {
                TokenType NextType = PeekNextTokenType();
                char NextValue = PeekNextCharacter();

                if (NextType == TokenType.Number)
                    Data.Value.Add(ReadNextCharacter());

                else if (NextType == TokenType.Identifier)
                    Data.Value.Add(ReadNextCharacter());

                else if (NextType == TokenType.Period || NextValue == '_')
                    Data.Value.Add(ReadNextCharacter());

                else
                    break;
            } 
            
            // Work out the base of the number.
            int Base = 10;

            List<char> TempData = Data.Value.Select(e => char.ToUpper(e)).ToList();

            char TypeChar = TempData[TempData.Count - 1];

            if (TempData.Count >= 2 && TempData[0] == '0' && TempData[1] == 'X')
            {
                TempData.RemoveRange(0, 2);    
                Base = 16;
            }
            else if (TypeChar == 'H')   // Hex
            {
                TempData.RemoveAt(TempData.Count - 1);    
                Base = 16;
            }
            else if (TypeChar == 'O')   // Octal
            {
                TempData.RemoveAt(TempData.Count - 1);
                Base = 8;
            }
            else if (TypeChar == 'D')   // Decmila
            {
                TempData.RemoveAt(TempData.Count - 1);
                Base = 10;
            }
            else if (TypeChar == 'B')   // Binary
            {
                TempData.RemoveAt(TempData.Count - 1);
                Base = 2;
            }
            else if (DataTables.CharacterData[TypeChar] != TokenType.Number)
            {
                MessageLog.Log.Add("Tokenizer", Data.Location, MessageCode.InvalidNumberToken, Data.ToString());
                return false;
            }

            if (TempData.Count == 0)
            {
                MessageLog.Log.Add("Tokenizer", Data.Location, MessageCode.UnknownError, "Empty Number Token");
                return false;
            }

            try
            {
                short Result = 0;
                foreach (char Num in TempData)
                {
                    // Ignore _ in numbers (allows spacing)
                    if (Num == '_')
                        continue;

                    Result = (short)(Result * Base);
                    Result += Convert.ToInt16(Num.ToString(), Base);
                }
            
                Data.NumaricValue = Result;
            }
            catch
            {
                MessageLog.Log.Add("Tokenizer", Data.Location, MessageCode.InvalidNumberToken, Data.ToString());

                return false;
            }

            return true;
        }
        
        
        bool ReadIdentifier(ref Token Data)
        {
            while (true)
            {
                TokenType NextType = PeekNextTokenType();
                char NextValue = PeekNextCharacter();

                if (NextType == TokenType.Number)
                    Data.Value.Add(ReadNextCharacter());

                else if (NextType == TokenType.Identifier)
                    Data.Value.Add(ReadNextCharacter());

                else if ("$.?_".Contains(NextValue))
                    Data.Value.Add(ReadNextCharacter());

                else
                    break;
            }

            return true;
        }

        bool ReadString(ref Token Data)
        {
            char Quote = Data.Value[0];
            Data.Value.Clear();
            while (true)
            {
                TokenType Current = PeekNextTokenType();
                if (Current == TokenType.LineBreak || Current == TokenType.End)
                {
                    MessageLog.Log.Add("Tokenizer", Data.Location, MessageCode.UnexpectedLineBreak);

                    return false;
                }

                char CurrentValue = ReadNextCharacter();

                if (Current == TokenType.String && CurrentValue == Quote)
                    break;
                
                Data.Value.Add(CurrentValue);
            }

            return true;
        }

        bool ReadComment(ref Token Data)
        {
            while (PeekNextTokenType() != TokenType.LineBreak && PeekNextTokenType() != TokenType.End)
                Data.Value.Add(ReadNextCharacter());

            return true;
        }

        bool ReadNewline(ref Token Data)
        {
            // Handle CR/LF
            if (Data.Value[0] == '\r' && PeekNextCharacter() == '\n')
                Data.Value.Add(ReadNextCharacter());

            _CurrentLine++;
            _CurrentCharacter = 1;

            return true;
        }

        void SkipWhitespaces()
        {
            while (PeekNextTokenType() == TokenType.WhiteSpace)
                ReadNextCharacter();
        }

        public void FlushLine()
        {
            if (PeekNextToken().Type != TokenType.LineBreak)
            {

                while (true)
                {
                    TokenType Current = PeekNextTokenType();
                    if (Current == TokenType.End)
                        break;

                    else if (Current == TokenType.LineBreak)
                    {
                        // Handle CR/LF
                        if (ReadNextCharacter() == '\r' && PeekNextCharacter() == '\n')
                            ReadNextCharacter();

                        _CurrentLine++;
                        _CurrentCharacter = 1;
                        break;
                    }
                    else
                    {
                        ReadNextCharacter();
                    }
                }
            }

            NextToken();
        }

        public Token PeekNextToken()
        {
            return _NextToken;
        }

        public Token NextToken()
        {
            Token Ret = _NextToken;
            _LastToken = _NextToken;
            _NextToken = GetNextToken();
            return Ret;
        }

        Token GetNextToken()
        {
            Token Ret = default(Token);

            SkipWhitespaces();

            Ret.Type = TokenType.End;
            Ret.Value = new List<char>();
            Ret.Location = new TokenLocation();

            Ret.Location.File = _InputFile;
            Ret.Location.Line = _CurrentLine;
            Ret.Location.Character = _CurrentCharacter;
            Ret.Location.Pos = _DataStream.BaseStream.Position;

            Ret.Type = PeekNextTokenType();
            if (Ret.Type == TokenType.End)
                return Ret;

            bool Success = true;
            
            Ret.Value.Add(ReadNextCharacter());

            switch (Ret.Type)
            {
                case TokenType.Unknown:
                    MessageLog.Log.Add("Tokenizer", Ret.Location, MessageCode.UnexpectedSymbol, Ret.ToString());
                    break;

                case TokenType.Number:
                    Success = ReadNumber(ref Ret);
                    break;

                case TokenType.Period:
                case TokenType.Identifier:
                    Ret.Type = TokenType.Identifier;
                    Success = ReadIdentifier(ref Ret);
                    break;

                case TokenType.Comment:
                    Success = ReadComment(ref Ret);
                    break;

                case TokenType.String:
                    Success = ReadString(ref Ret);
                    break;

                case TokenType.Symbol:
                    break;

                case TokenType.LessThen:
                    if (PeekNextTokenType() == TokenType.Equal)              // <=
                    {
                        Ret.Type = TokenType.LessEqual;
                        Ret.Value.Add(ReadNextCharacter());
                    }
                    else if (PeekNextTokenType() == TokenType.LessThen)     // <<
                    {
                        Ret.Type = TokenType.LeftShift;
                        Ret.Value.Add(ReadNextCharacter());
                    }
                    else if (PeekNextTokenType() == TokenType.GreaterThen)  // <>
                    {
                        Ret.Type = TokenType.NotEqual;
                        Ret.Value.Add(ReadNextCharacter());
                    }
                    break;

                case TokenType.GreaterThen:
                    if (PeekNextTokenType() == TokenType.Equal)             // >=
                    {
                        Ret.Type = TokenType.GreaterEqual;
                        Ret.Value.Add(ReadNextCharacter());
                    }
                    else if (PeekNextTokenType() == TokenType.GreaterThen)  // >>
                    {
                        Ret.Type = TokenType.RightShift;
                        Ret.Value.Add(ReadNextCharacter());
                    }
                    break;

                case TokenType.BitwiseNot:
                    if (PeekNextTokenType() == TokenType.Equal)             // !=
                    {
                        Ret.Type = TokenType.NotEqual;
                        Ret.Value.Add(ReadNextCharacter());
                    }
                    break;

                case TokenType.Equal:
                    if (PeekNextTokenType() == TokenType.Equal)             // ==
                    {
                        Ret.Value.Add(ReadNextCharacter());
                    }
                    break;

                case TokenType.BitwiseAnd:
                    if (PeekNextTokenType() == TokenType.BitwiseAnd)        // &&
                    {
                        Ret.Type = TokenType.LogicalAnd;
                        Ret.Value.Add(ReadNextCharacter());
                    }
                    break;

                case TokenType.BitwiseOR:
                    if (PeekNextTokenType() == TokenType.BitwiseOR)         // ||
                    {
                        Ret.Type = TokenType.LogicalOR;
                        Ret.Value.Add(ReadNextCharacter());
                    }
                    break;

                case TokenType.LineBreak:
                    Success = ReadNewline(ref Ret);
                    return Ret;

                case TokenType.Plus:
                    if (!_LastToken.IsValue() && _LastToken.CommandID != CommandID.IX && _LastToken.CommandID != CommandID.IY)
                        Ret.Type = TokenType.UnarrayPlus;
                    break;

                case TokenType.Minus:
                    if (!_LastToken.IsValue() && _LastToken.CommandID != CommandID.IX && _LastToken.CommandID != CommandID.IY)
                        Ret.Type = TokenType.UnarrayMinus;
                    break;

                default:
                    if (Ret.Type < TokenType.Operator)
                    {
                        while (PeekNextTokenType() == Ret.Type)
                            Ret.Value.Add(ReadNextCharacter());
                    }
                    break;
            }

            if (Ret.Type == TokenType.Identifier)
            {
                if (DataTables.Commands.ContainsKey(Ret.ToString()))
                {
                    Ret.CommandID = DataTables.Commands[Ret.ToString()];

                    if (Ret.CommandID < CommandID.RegisterMax)
                        Ret.Type = TokenType.Register;

                    else if (Ret.CommandID < CommandID.FlagsMax)
                        Ret.Type = TokenType.Flag;

                    else if (Ret.CommandID > CommandID.OpcodeMax)
                        Ret.Type = TokenType.Command;

                    else
                        Ret.Type = TokenType.Opcode;

                    if (Ret.CommandID == CommandID.LOW)
                        Ret.Type = TokenType.Low;

                    else if (Ret.CommandID == CommandID.HIGH)
                        Ret.Type = TokenType.High;
                }
            }

            if (!Success)
            {
                Ret.Type = TokenType.Error;
            }

            return Ret;
        }
    }
}
