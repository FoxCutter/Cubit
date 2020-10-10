using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZASM
{
    class Tokenizer
    {
        StreamReader _DataStream;
        int _FileID;
        int _Line;
        int _Character;

        List<char> CurrentValue;
        string CurrentString { get { return string.Concat(CurrentValue); } }

        public int CurrentLine { get { return _Line; } }
        public int CurrentCharacter { get { return _Character; } }

        Stack<Token> SavedTokens;

        public Tokenizer(int FileID, Stream InputStream)
        {
            _DataStream = new StreamReader(InputStream);
            _FileID = FileID;
            _Line = 1;
            _Character = 1;

            CurrentValue = new List<char>();
            SavedTokens = new Stack<Token>();

            FlushWhitespace();
        }

        public InputType PeekNextInputType()
        {
            if (SavedTokens.Count != 0)
            {
                return SavedTokens.Peek().CharacterType;
            }

            int Current = _DataStream.Peek();

            if (Current == -1)
                return InputType.End;

            else if (Current >= 0x80)
                return InputType.Unknown;

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

        bool ReadNewline(ref Token Data)
        {
            Data.Type = TokenType.LineBreak;
            CurrentValue.Add(ReadNextCharacter());

            // Handle CR/LF
            if (CurrentValue[0] == '\r' && PeekNextCharacter() == '\n')
                CurrentValue.Add(ReadNextCharacter());

            _Line++;
            _Character = 1;

            return true;
        }

        bool FlushWhitespace()
        {
            while (PeekNextInputType() == InputType.Space || PeekNextInputType() == InputType.Tab)
                ReadNextCharacter();

            return true;
        }

        bool ReadComment(ref Token Data)
        {
            Data.Type = TokenType.Comment;
            CurrentValue.Add(ReadNextCharacter());

            while (PeekNextInputType() != InputType.CarriageReturn && PeekNextInputType() != InputType.LineFeed && PeekNextInputType() != InputType.End)
                CurrentValue.Add(ReadNextCharacter());

            return true;
        }

        bool ReadIdentifier(ref Token Data)
        {
            Data.Type = TokenType.Identifier;
            CurrentValue.Add(ReadNextCharacter());

            while (true)
            {
                InputType NextType = PeekNextInputType();

                if (NextType == InputType.Identifier || NextType == InputType.Number ||
                     NextType == InputType.DollarSign || NextType == InputType.Period || NextType == InputType.QuestionMark ||
                     NextType == InputType.AtSign || NextType == InputType.Underscore)
                {
                    CurrentValue.Add(ReadNextCharacter());
                }
                else
                {
                    break;
                }
            }

            Data.StringValue = CurrentString;
            
            return true;
        }

        bool ReadNumber(ref Token Data)
        {
            Data.Type = TokenType.Number;
            CurrentValue.Add(ReadNextCharacter());

            while (true)
            {
                InputType NextType = PeekNextInputType();

                if (NextType == InputType.Number)
                    CurrentValue.Add(ReadNextCharacter());

                else if (NextType == InputType.Identifier)
                    CurrentValue.Add(char.ToUpper(ReadNextCharacter()));

                else
                    break;
            }

            // Work out the base of the number.
            int Base = 10;

            List<char> TempData = new List<char>(CurrentValue);

            char TypeChar = TempData[TempData.Count - 1];

            if (TempData.Count >= 2 && TempData[0] == '0' && TempData[1] == 'X')        // 0xFF
            {
                TempData.RemoveRange(0, 2);
                Base = 16;
            }
            else if (TempData[0] == '$')    // $FF
            {
                TempData.RemoveAt(0);
                Base = 16;
            }
            else if (TypeChar == 'H')       // 0Fh - Hex
            {
                TempData.RemoveAt(TempData.Count - 1);
                Base = 16;
            }
            else if (TypeChar == 'O' || TypeChar == 'Q')       // 77o/77q - Octal
            {
                TempData.RemoveAt(TempData.Count - 1);
                Base = 8;
            }
            else if (TypeChar == 'B')       // 11b - Octal
            {
                TempData.RemoveAt(TempData.Count - 1);
                Base = 2;
            }
            else if (TypeChar == 'D')       // 10d - Decimal
            {
                TempData.RemoveAt(TempData.Count - 1);
                Base = 10;
            }
            else if (DataTables.CharacterData[TypeChar] != InputType.Number)
            {
                Message.Add("Tokenizer", _FileID, _Line, _Character, MessageCode.InvalidNumberToken, CurrentString);
                return false;
            }

            if (TempData.Count == 0)
            {
                Message.Add("Tokenizer", _FileID, _Line, _Character, MessageCode.UnknownError, "Empty Number Token");
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
                Message.Add("Tokenizer", _FileID, _Line, _Character, MessageCode.InvalidNumberToken, CurrentString);

                return false;
            }

            return true;
        }

        bool ReadString(ref Token Data, bool Quoted = true)
        {
            Data.Type = TokenType.String;

            char Quote = PeekNextCharacter();

            CurrentValue.Add(ReadNextCharacter());

            while (true)
            {
                InputType Current = PeekNextInputType();
                if (Current == InputType.CarriageReturn || Current == InputType.LineFeed || Current == InputType.End)
                {
                    if (Quoted)
                    {
                        Message.Add("Tokenizer", _FileID, _Line, _Character, MessageCode.UnexpectedLineBreak);
                        return false;
                    }

                    break;
                }

                char CurrentChar = ReadNextCharacter();
                CurrentValue.Add(CurrentChar);

                if (Quoted)
                {
                    if (CurrentChar == Quote)
                        break;
                }
                else
                {
                    if (Current == InputType.Space || Current == InputType.Tab)
                        break;
                }
            }

            if (Quoted)
            {
                Data.StringValue = CurrentString.Substring(1, CurrentString.Length - 2);
            }
            else
            {
                Data.StringValue = CurrentString;
            }

            if (Data.StringValue.Count() <= 2)
            {
                Data.NumericValue = 0;
                foreach (char Entry in Data.StringValue)
                {
                    Data.NumericValue <<= 8;
                    Data.NumericValue += (byte)Entry;
                }
            }

            return true;
        }

        public void FlushLine()
        {
            while (true)
            {
                InputType Current = PeekNextInputType();
                if (Current == InputType.End)
                    break;

                else if (Current == InputType.CarriageReturn || Current == InputType.LineFeed)
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

            SavedTokens.Clear();
            FlushWhitespace();
        }

        public Token GetNextTokenAsString()
        {
            Token Ret = new Token();
            CurrentValue.Clear();

            if (SavedTokens.Count != 0)
            {
                Ret = SavedTokens.Pop();

                if (Ret.Type != TokenType.LineBreak && Ret.Type != TokenType.Comment && Ret.Type != TokenType.String)
                    Ret.Type = TokenType.String;

                return Ret;
            }

            Ret.Character = _Character;

            Ret.CharacterType = PeekNextInputType();
            
            if (Ret.CharacterType == InputType.End)
            {
                Ret.Type = TokenType.End;
                return Ret;
            }

            bool Success = true;

            switch (Ret.CharacterType)
            {
                case InputType.Unknown:
                    Message.Add("Tokenizer", _FileID, _Line, _Character, MessageCode.UnexpectedSymbol, CurrentString);
                    break;

                // LineBreak
                case InputType.CarriageReturn:
                case InputType.LineFeed:
                    Success = ReadNewline(ref Ret);
                    break;

                // String
                case InputType.DoubleQuote:
                case InputType.SingleQuote:
                case InputType.ReverseQuote:
                    Success = ReadString(ref Ret);
                    break;

                // Comment
                case InputType.SemiColon:
                    Success = ReadComment(ref Ret);
                    break;

                default:
                    Success = ReadString(ref Ret, false);
                    break;
            }

            Ret.TokenData = CurrentString;

            if (!Success)
            {
                Ret.Type = TokenType.Error;
            }
            else
            {
                FlushWhitespace();
            }

            return Ret;
        }
        
        public void UnGetNextToken(Token NextToken)
        {
            SavedTokens.Push(NextToken);
        }

        public Token GetNextToken()
        {
            if (SavedTokens.Count != 0)
                return SavedTokens.Pop();

            Token Ret = new Token();
            CurrentValue.Clear();

            Ret.Character = _Character;

            Ret.CharacterType = PeekNextInputType();

            if (Ret.CharacterType == InputType.End)
            {
                Ret.Type = TokenType.End;
                return Ret;
            }

            bool Success = true;

            switch (Ret.CharacterType)
            {
                case InputType.Unknown:
                    Message.Add("Tokenizer", _FileID, _Line, _Character, MessageCode.UnexpectedSymbol, CurrentString);
                    break;

                // LineBreak
                case InputType.CarriageReturn:
                case InputType.LineFeed:
                    Success = ReadNewline(ref Ret);
                    break;

                // WhiteSpace
                case InputType.Tab:
                case InputType.Space:
                    Ret.Type = TokenType.WhiteSpace;
                    Success = FlushWhitespace();
                    break;

                case InputType.Number:
                    Success = ReadNumber(ref Ret);
                    break;

                case InputType.Period:
                case InputType.Identifier:
                case InputType.Underscore:
                    Success = ReadIdentifier(ref Ret);
                    break;

                case InputType.AtSign:
                    if (Settings.OpcodeSet == OpcodeType.i8080 || Settings.AtAddressing == Setting.Off)
                    {
                        Success = ReadIdentifier(ref Ret);
                    }
                    else
                    {
                        CurrentValue.Add(ReadNextCharacter());
                        Ret.Type = TokenType.Address;
                    }
                        
                    break;

                // String
                case InputType.DoubleQuote:
                case InputType.SingleQuote:
                case InputType.ReverseQuote:
                    Success = ReadString(ref Ret);
                    break;

                // Comment
                case InputType.SemiColon:
                    Success = ReadComment(ref Ret);
                    break;

                // Number or Current Position
                case InputType.DollarSign:
                    CurrentValue.Add(ReadNextCharacter());
                    if (PeekNextInputType() == InputType.Number || PeekNextInputType() == InputType.Identifier)
                    {
                        Success = ReadNumber(ref Ret);
                    }
                    else 
                    {
                        Ret.Type = TokenType.CurrentPos;
                    }
                    break;

                case InputType.LessThen:
                    CurrentValue.Add(ReadNextCharacter());
                    if (PeekNextInputType() == InputType.Equal)             // <=
                    {
                        Ret.Type = TokenType.LessEqual;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else if (PeekNextInputType() == InputType.LessThen)     // <<
                    {
                        Ret.Type = TokenType.LeftShift;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else if (PeekNextInputType() == InputType.GreaterThen)  // <>
                    {
                        Ret.Type = TokenType.NotEqual;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else                                                    // <
                    {
                        Ret.Type = TokenType.LessThen;
                    }
                    break;
                
                case InputType.GreaterThen:
                    CurrentValue.Add(ReadNextCharacter());
                    if (PeekNextInputType() == InputType.Equal)             // >=
                    {
                        Ret.Type = TokenType.GreaterEqual;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else if (PeekNextInputType() == InputType.GreaterThen)  // >>
                    {
                        Ret.Type = TokenType.RightShift;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else                                                    // >
                    {
                        Ret.Type = TokenType.GreaterThen;
                    }
                    break;
                
                case InputType.ExclimationMark:
                    CurrentValue.Add(ReadNextCharacter());
                    if (PeekNextInputType() == InputType.Equal)             // !=
                    {
                        Ret.Type = TokenType.NotEqual;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else                                                    // !
                    {
                        Ret.Type = TokenType.LogicalNot;
                    }
                    break;

                case InputType.Plus:                                        // +
                    CurrentValue.Add(ReadNextCharacter());
                    Ret.Type = TokenType.Plus;
                    break;

                case InputType.Minus:                                       // -
                    CurrentValue.Add(ReadNextCharacter());
                    Ret.Type = TokenType.Minus;
                    break;

                case InputType.Equal:
                    CurrentValue.Add(ReadNextCharacter());
                    if (PeekNextInputType() == InputType.Equal)             // ==
                    {
                        Ret.Type = TokenType.Comparison;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else                                                    //  =
                    {
                        Ret.Type = TokenType.Assignment;
                    }                    
                    break;

                case InputType.Ampersand:
                    CurrentValue.Add(ReadNextCharacter());
                    if (PeekNextInputType() == InputType.Ampersand)         // &&
                    {
                        Ret.Type = TokenType.LogicalAnd;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else                                                    // &
                    {
                        Ret.Type = TokenType.BitwiseAnd;
                    }                    
                    break;

                case InputType.Carrot:                                      // ^
                    CurrentValue.Add(ReadNextCharacter());
                    Ret.Type = TokenType.BitwiseXOR;
                    break;

                case InputType.Pipe:
                    CurrentValue.Add(ReadNextCharacter());
                    if (PeekNextInputType() == InputType.Pipe)              // ||
                    {
                        Ret.Type = TokenType.LogicalOR;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else                                                    // |
                    {
                        Ret.Type = TokenType.BitwiseOR;
                    }                    
                    break;

                case InputType.Asterisk:                                    // *
                    CurrentValue.Add(ReadNextCharacter());
                    Ret.Type = TokenType.Multiplication;
                    break;

                case InputType.Slash:                                       // /
                    CurrentValue.Add(ReadNextCharacter());
                    Ret.Type = TokenType.Division;
                    break;

                case InputType.PercentSign:                                 // %
                    CurrentValue.Add(ReadNextCharacter());
                    Ret.Type = TokenType.Remainder;
                    break;

                case InputType.Tilde:                                       // ~
                    CurrentValue.Add(ReadNextCharacter());
                    Ret.Type = TokenType.BitwiseNot;
                    break;
                
                case InputType.ParenthesesLeft:
                    CurrentValue.Add(ReadNextCharacter());
                    Ret.Type = TokenType.GroupLeft;
                    break;

                case InputType.ParenthesesRight:
                    CurrentValue.Add(ReadNextCharacter());
                    Ret.Type = TokenType.GroupRight;
                    break;

                case InputType.BracketLeft:
                    CurrentValue.Add(ReadNextCharacter());
                    Ret.Type = TokenType.ArrayLeft;
                    break;

                case InputType.BracketRight:
                    CurrentValue.Add(ReadNextCharacter());
                    Ret.Type = TokenType.ArrayRight;
                    break;

                case InputType.CurlyBraceRight:
                case InputType.CurlyBraceLeft:
                case InputType.PoundSign:
                case InputType.Comma:
                case InputType.Colon:
                case InputType.QuestionMark:
                case InputType.Backslash:
                    CurrentValue.Add(ReadNextCharacter());
                    Ret.Type = TokenType.Symbol;
                    Ret.StringValue = CurrentString;
                    break;

                default:
                    break;
            }

            Ret.TokenData = CurrentString;

            if (!Success)
            {
                Ret.Type = TokenType.Error;
            }
            else
            {
                FlushWhitespace();
            }

            return Ret;
        }
    }
}
