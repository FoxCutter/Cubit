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

        //CY, NC, Z, NZ, PE, PO, P, M,

        FlagsMax,

        // Opcodes
        ADC, ADD, AND, BIT, CALL, CCF, CP, CPD, CPDR, CPI, CPIR, CPL,
        DAA, DEC, DI, DJNZ, EI, EX, EXX, HALT, IM, IN, INC, IND,
        INDR, INI, INIR, JP, JR, LD, LDD, LDDR, LDI, LDIR, NEG, NOP,
        OR, OTDR, OTIR, OUT, OUTD, OUTI, POP, PUSH, RES, RET, RETI,
        RETN, RL, RLA, RLC, RLCA, RLD, RR, RRA, RRC, RRCA, RRD,
        RST, SBC, SCF, SET, SLA, SLL, SRA, SRL, SUB, XOR,

        // i8080 Opcodes
        ACI, ADI, ANA, CNZ, CZ, CNC, CC, CPO, CPE, CM,
        CMA, CMC, CMP, DAD, DCR, DCX, INR, INX,
        JMP, JNZ, JZ, JNC, JC, JPO, JPE, JM,
        LDA, LXI, LDAX, LHLD, MOV, MVI,
        ORA, ORI, PCHL, RAL, RAR,
        RNZ, RZ, RNC, RC, RPO, RPE, RP, RM,        
        SBB, SBI,
        SHLD, SPHL, STA, STAX,
        STC, SUI, XCHG, XRA, XRI, XTHL,

        // Psudo Operators
        HIGH, LOW, TIMES,

        OpcodeMax,

        // Commands
        CONST, BYTE, WORD, DWORD, DC, RESB, RESW, RESD,
        EQU, PROC, ENDPROC, CALLPROC, STRUCT, ENDSTRUCT,

        // Directives
        EXTERN, PUBLIC, INCLUDE, Z80, i8080, ORG, END,


        CommandMax,

        // Encoding Flags
        ByteReg,            // B, C, D, E, H, L, A
        ByteRegIndex,       // B, C, D, E, IXH, IYH, IXL, IYL, A
        WordReg,            // BC, DE, HL, SP, IX, IY
        WordRegAF,          // BC, DE, HL, AF, IX, IY
        Flags,              // NZ, Z, NC, CY, PO, PE, P, M
        HalfFlags,          // NZ, Z, NC, CY


        Byte_Pointer,       // (HL), (IX + *), (IY + *)
        Address_Registers,  // HL, IX, IY
        Index_Pointer,      // (IX+*), (IY+*)

        Address_Pointer,    // (nn)

        ByteData,           // n
        WordData,           // nn
        Displacment,        // e-2
        Address,            // nn

        HL_Pointer,         // (HL)
        BC_Pointer,         // (BC)
        DE_Pointer,         // (DE)
        SP_Pointer,         // (SP)

        HLInc_Pointer,      // (HL+) Gameboy
        HLDec_Pointer,      // (HL-) Gameboy
        High_Pointer,       // (+Word) Gameboy
        High_C_Pointer,     // (+C) Gameboy
        SP_Offset,          // SP + Byte Gameboy

        PosImmidate,        // Encoded as Immidate data
        Pos1,
        Pos2,
        Pos3,
        Pos4,

        EncodingMax,

        Encoded = 0xF000,
    }

    class Tokenizer
    {
        StreamReader _DataStream;
        int _Line;
        int _Character;
        TokenType _LastToken;
        CommandID _LastCommand;

        public int CurrentLine { get; private set; }
        public int CurrentCharacter { get; private set; }
        public List<char> CurrentValue { get; private set; }
        public string CurrentString { get { return string.Concat(CurrentValue); } }


        public Tokenizer(Stream InputStream)
        {
            _DataStream = new StreamReader(InputStream);
            _Line = 1;
            _Character = 1;
            
            CurrentLine = 0;
            CurrentCharacter = 0;
            CurrentValue = new List<char>();
            _LastToken = TokenType.None;
            _LastCommand = CommandID.None;

            // Skip to the first real token in the stream.
            SkipWhitespaces();
        }

        public TokenType PeekNextTokenType()
        {
            int Current = _DataStream.Peek();

            if (Current == -1)
                return TokenType.End;

            else if (Current >= 0x80)
                return TokenType.Unknown;

            else
                return DataTables.CharacterData[Current];
        }

        char PeekNextCharacter()
        {
            int Value = _DataStream.Peek();

            if (Value == -1)
                return '\0';

            return (char)Value;
        }

        char ReadNextCharacter()
        {
            int Value = _DataStream.Read();

            _Character++;

            return (char)Value;
        }

        public void FlushLine()
        {
            if (PeekNextTokenType() != TokenType.LineBreak)
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

                        _Line++;
                        _Character = 1;
                        break;
                    }
                    else
                    {
                        ReadNextCharacter();
                    }
                }
            }

            SkipWhitespaces();
        }
        
        void SkipWhitespaces()
        {
            while (PeekNextTokenType() == TokenType.WhiteSpace)
                ReadNextCharacter();
        }

        bool ReadString(ref Token Data)
        {
            char Quote = CurrentValue[0];
            CurrentValue.Clear();
            while (true)
            {
                TokenType Current = PeekNextTokenType();
                if (Current == TokenType.LineBreak || Current == TokenType.End)
                {
                    MessageLog.Log.Add("Tokenizer", _Line, _Character, MessageCode.UnexpectedLineBreak);

                    return false;
                }

                char CurrentChar = ReadNextCharacter();

                if (Current == TokenType.String && CurrentChar == Quote)
                    break;

                CurrentValue.Add(CurrentChar);
            }

            if (CurrentValue.Count <= 2)
            {
                Data.NumericValue = 0;
                foreach (char Entry in CurrentValue)
                {
                    Data.NumericValue <<= 8;
                    Data.NumericValue += (byte)Entry;
                }
            }

            Data.StringValue = CurrentString;

            return true;
        }
        
        bool ReadNumber(ref Token Data)
        {
            while (true)
            {
                TokenType NextType = PeekNextTokenType();

                if (NextType == TokenType.Number)
                    CurrentValue.Add(ReadNextCharacter());

                else if (NextType == TokenType.Identifier)
                    CurrentValue.Add(char.ToUpper(ReadNextCharacter()));

                else if (NextType == TokenType.Period)
                    CurrentValue.Add(ReadNextCharacter());

                else
                    break;
            }

            // Work out the base of the number.
            int Base = 10;

            List<char> TempData = new List<char>(CurrentValue);

            char TypeChar = TempData[TempData.Count - 1];

            if (TempData.Count >= 2 && TempData[0] == '0' && TempData[1] == 'X')
            {
                TempData.RemoveRange(0, 2);
                Base = 16;
            }
            else if (TempData[0] == '$')
            {
                TempData.RemoveAt(0);
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
            else if (TypeChar == 'D')   // Decimal
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
                MessageLog.Log.Add("Tokenizer", _Line, _Character, MessageCode.InvalidNumberToken, CurrentString);
                return false;
            }

            if (TempData.Count == 0)
            {
                MessageLog.Log.Add("Tokenizer", _Line, _Character, MessageCode.UnknownError, "Empty Number Token");
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

                Data.NumericValue = Result;
            }
            catch
            {
                MessageLog.Log.Add("Tokenizer", _Line, _Character, MessageCode.InvalidNumberToken, CurrentString);

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
                    CurrentValue.Add(ReadNextCharacter());

                else if (NextType == TokenType.Identifier)
                    CurrentValue.Add(ReadNextCharacter());

                else if (NextType == TokenType.CurrentPos)
                    CurrentValue.Add(ReadNextCharacter());

                else if (NextType == TokenType.Period)
                    CurrentValue.Add(ReadNextCharacter());

                else
                    break;
            }

            return true;
        }

        bool ReadComment(ref Token Data)
        {
            while (PeekNextTokenType() != TokenType.LineBreak && PeekNextTokenType() != TokenType.End)
                CurrentValue.Add(ReadNextCharacter());

            return true;
        }
        
        bool ReadNewline(ref Token Data)
        {
            // Handle CR/LF
            if (CurrentValue[0] == '\r' && PeekNextCharacter() == '\n')
                CurrentValue.Add(ReadNextCharacter());

            _Line++;
            _Character = 1;

            return true;
        }

        public Token GetNextToken()
        {
            CurrentLine = _Line;
            CurrentCharacter = _Character;
            
            Token Ret = new Token();
            
            CurrentValue.Clear();

            Ret.Type = TokenType.End;
            Ret.Type = PeekNextTokenType();
            if (Ret.Type == TokenType.End)
                return Ret;

            bool Success = true;

            CurrentValue.Add(ReadNextCharacter());

            switch (Ret.Type)
            {
                case TokenType.Unknown:
                    MessageLog.Log.Add("Tokenizer", _Line, _Character, MessageCode.UnexpectedSymbol, CurrentString);
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
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else if (PeekNextTokenType() == TokenType.LessThen)     // <<
                    {
                        Ret.Type = TokenType.LeftShift;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else if (PeekNextTokenType() == TokenType.GreaterThen)  // <>
                    {
                        Ret.Type = TokenType.NotEqual;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    break;

                case TokenType.GreaterThen:
                    if (PeekNextTokenType() == TokenType.Equal)             // >=
                    {
                        Ret.Type = TokenType.GreaterEqual;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else if (PeekNextTokenType() == TokenType.GreaterThen)  // >>
                    {
                        Ret.Type = TokenType.RightShift;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    break;

                case TokenType.BitwiseNot:
                    if (PeekNextTokenType() == TokenType.Equal)             // !=
                    {
                        Ret.Type = TokenType.NotEqual;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    break;

                case TokenType.Equal:
                    if (PeekNextTokenType() == TokenType.Equal)             // ==
                    {
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    break;

                case TokenType.BitwiseAnd:
                    if (PeekNextTokenType() == TokenType.BitwiseAnd)        // &&
                    {
                        Ret.Type = TokenType.LogicalAnd;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    break;

                case TokenType.BitwiseOR:
                    if (PeekNextTokenType() == TokenType.BitwiseOR)         // ||
                    {
                        Ret.Type = TokenType.LogicalOR;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    break;

                case TokenType.LineBreak:
                    Success = ReadNewline(ref Ret);
                    break;

                case TokenType.Plus:
                    if (_LastToken != TokenType.Number && _LastCommand != CommandID.IX && _LastCommand != CommandID.IY)
                        Ret.Type = TokenType.UnarrayPlus;
                    break;

                case TokenType.Minus:
                    if (_LastToken != TokenType.Number && _LastCommand != CommandID.IX && _LastCommand != CommandID.IY)
                        Ret.Type = TokenType.UnarrayMinus;
                    break;

                case TokenType.CurrentPos:
                    if (PeekNextTokenType() == TokenType.Number)
                    {
                        Success = ReadNumber(ref Ret);
                        Ret.Type = TokenType.Number;
                    }

                    break;

                default:
                    if (Ret.Type < TokenType.Operator)
                    {
                        while (PeekNextTokenType() == Ret.Type)
                            CurrentValue.Add(ReadNextCharacter());
                    }
                    break;
            }

            if (Ret.Type == TokenType.Identifier)
            {
                if (DataTables.Commands.ContainsKey(CurrentString))
                {
                    Ret.CommandID = DataTables.Commands[CurrentString];

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
            else
            {
                SkipWhitespaces();
                _LastToken = Ret.IsValue() ? TokenType.Number : Ret.Type;
                _LastCommand = Ret.CommandID;
            }


            return Ret;
        }

    }
}
