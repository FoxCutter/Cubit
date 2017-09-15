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

        public List<char> CurrentValue { get; private set; }
        public string CurrentString { get { return string.Concat(CurrentValue); } }

        public Tokenizer(int FileID, Stream InputStream)
        {
            _DataStream = new StreamReader(InputStream);
            _FileID = FileID;
            _Line = 1;
            _Character = 1;

            CurrentValue = new List<char>();

            FlushWhitespace();
        }

        public CharacterType PeekNextCharacterType()
        {
            int Current = _DataStream.Peek();

            if (Current == -1)
                return CharacterType.End;

            else if (Current >= 0x80)
                return CharacterType.Unknown;

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

        bool ReadNewline()
        {
            // Handle CR/LF
            if (CurrentValue[0] == '\r' && PeekNextCharacterType() == CharacterType.LineFeed)
                CurrentValue.Add(ReadNextCharacter());

            _Line++;
            _Character = 1;

            return true;
        }

        bool FlushWhitespace()
        {
            while (PeekNextCharacterType() == CharacterType.Space || PeekNextCharacterType() == CharacterType.Tab)
                ReadNextCharacter();

            return true;
        }
        
        bool ReadComment()
        {
            while (PeekNextCharacterType() != CharacterType.CarriageReturn && PeekNextCharacterType() != CharacterType.LineFeed && PeekNextCharacterType() != CharacterType.End)
                CurrentValue.Add(ReadNextCharacter());

            return true;
        }

        bool ReadIdentifier(ref Token Data)
        {
            while (true)
            {
                CharacterType NextType = PeekNextCharacterType();
                char NextValue = PeekNextCharacter();

                if (NextType == CharacterType.Number)
                    CurrentValue.Add(ReadNextCharacter());

                else if (NextType == CharacterType.Identifier)
                    CurrentValue.Add(ReadNextCharacter());

                else if (NextType == CharacterType.DollarSign)
                    CurrentValue.Add(ReadNextCharacter());

                else if (NextType == CharacterType.Period)
                    CurrentValue.Add(ReadNextCharacter());

                else
                    break;
            }

            Data.StringValue = CurrentString;
            
            return true;
        }

        bool ReadNumber(ref Token Data)
        {
            while (true)
            {
                CharacterType NextType = PeekNextCharacterType();

                if (NextType == CharacterType.Number)
                    CurrentValue.Add(ReadNextCharacter());

                else if (NextType == CharacterType.Identifier)
                    CurrentValue.Add(char.ToUpper(ReadNextCharacter()));

                else if (NextType == CharacterType.Period)
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
            else if (DataTables.CharacterData[TypeChar] != CharacterType.Number)
            {
                Message.Log.Add("Tokenizer", _FileID, _Line, _Character, MessageCode.InvalidNumberToken, CurrentString);
                return false;
            }

            if (TempData.Count == 0)
            {
                Message.Log.Add("Tokenizer", _FileID, _Line, _Character, MessageCode.UnknownError, "Empty Number Token");
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
                Message.Log.Add("Tokenizer", _FileID, _Line, _Character, MessageCode.InvalidNumberToken, CurrentString);

                return false;
            }

            return true;
        }

        bool ReadString(ref Token Data)
        {
            char Quote = CurrentValue[0];

            while (true)
            {
                CharacterType Current = PeekNextCharacterType();
                if (Current == CharacterType.CarriageReturn || Current == CharacterType.LineFeed || Current == CharacterType.End)
                {
                    Message.Log.Add("Tokenizer", _FileID, _Line, _Character, MessageCode.UnexpectedLineBreak);

                    return false;
                }

                char CurrentChar = ReadNextCharacter();
                CurrentValue.Add(CurrentChar);

                if (CurrentChar == Quote)
                    break;
            }

            Data.StringValue = CurrentString.Substring(1, CurrentString.Length - 2);

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

        bool ReadSymbol(ref Token Data)
        {
            while (PeekNextCharacterType() == CharacterType.PoundSign || PeekNextCharacterType() ==  CharacterType.Comma || PeekNextCharacterType() == CharacterType.Colon ||
                   PeekNextCharacterType() == CharacterType.QuestionMark || PeekNextCharacterType() == CharacterType.Backslash)
                CurrentValue.Add(ReadNextCharacter());

            Data.StringValue = CurrentString;

            return true;
        }

        public void FlushLine()
        {
            if (PeekNextCharacterType() != CharacterType.CarriageReturn && PeekNextCharacterType() != CharacterType.LineFeed && PeekNextCharacterType() != CharacterType.End)
            {

                while (true)
                {
                    CharacterType Current = PeekNextCharacterType();
                    if (Current == CharacterType.End)
                        break;

                    else if (Current == CharacterType.CarriageReturn || Current == CharacterType.LineFeed)
                    {
                        // Handle CR/LF
                        if (ReadNextCharacter() == '\r' && PeekNextCharacterType() == CharacterType.LineFeed)
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
        }
        
        public Token GetNextToken()
        {
            Token Ret = new Token();
            CurrentValue.Clear();

            Ret.FileID = _FileID;
            Ret.Line = _Line;
            Ret.Character = _Character;

            CharacterType Type = PeekNextCharacterType();
            CurrentValue.Add(ReadNextCharacter());

            if (Type == CharacterType.End)
            {
                Ret.Type = TokenType.End;
                return Ret;
            }

            bool Success = true;

            switch (Type)
            {
                case CharacterType.Unknown:
                    Message.Log.Add("Tokenizer", _FileID, _Line, _Character, MessageCode.UnexpectedSymbol, CurrentString);
                    break;

                // LineBreak
                case CharacterType.CarriageReturn:
                case CharacterType.LineFeed:
                    Ret.Type = TokenType.LineBreak;
                    Success = ReadNewline();
                    break;

                // WhiteSpace
                case CharacterType.Tab:
                case CharacterType.Space:
                    Ret.Type = TokenType.WhiteSpace;
                    Success = FlushWhitespace();
                    break;

                case CharacterType.Number:
                    Ret.Type = TokenType.Number;
                    Success = ReadNumber(ref Ret);
                    break;

                case CharacterType.Period:
                case CharacterType.Identifier:
                    Ret.Type = TokenType.Identifier;
                    Success = ReadIdentifier(ref Ret);
                    break;

                // String
                case CharacterType.DoubleQuote:
                case CharacterType.SingleQuote:
                case CharacterType.ReverseQuote:
                    Ret.Type = TokenType.String;
                    Success = ReadString(ref Ret);
                    break;

                // Comment
                case CharacterType.SemiColon:
                    Ret.Type = TokenType.Comment;
                    Success = ReadComment();
                    break;

                // Number or Current Position
                case CharacterType.DollarSign:
                    if (PeekNextCharacterType() == CharacterType.Number)
                    {
                        Ret.Type = TokenType.Number;
                        Success = ReadNumber(ref Ret);
                    }
                    else 
                    {
                        Ret.Type = TokenType.CurrentPos;
                    }
                    break;

                case CharacterType.LessThen:
                    if (PeekNextCharacterType() == CharacterType.Equal)             // <=
                    {
                        Ret.Type = TokenType.LessEqual;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else if (PeekNextCharacterType() == CharacterType.LessThen)     // <<
                    {
                        Ret.Type = TokenType.LeftShift;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else if (PeekNextCharacterType() == CharacterType.GreaterThen)  // <>
                    {
                        Ret.Type = TokenType.NotEqual;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else                                                            // <
                    {
                        Ret.Type = TokenType.LessThen;
                    }
                    break;
                
                case CharacterType.GreaterThen:
                    if (PeekNextCharacterType() == CharacterType.Equal)             // >=
                    {
                        Ret.Type = TokenType.GreaterEqual;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else if (PeekNextCharacterType() == CharacterType.GreaterThen)  // >>
                    {
                        Ret.Type = TokenType.RightShift;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else                                                            // >
                    {
                        Ret.Type = TokenType.GreaterThen;
                    }
                    break;
                
                case CharacterType.ExclimationMark:
                    if (PeekNextCharacterType() == CharacterType.Equal)             // !=
                    {
                        Ret.Type = TokenType.NotEqual;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else                                                            // !
                    {
                        Ret.Type = TokenType.LogicalNot;
                    }
                    break;

                case CharacterType.Plus:                                            // +
                    Ret.Type = TokenType.Plus;
                    break;

                case CharacterType.Minus:                                           // -
                    Ret.Type = TokenType.Minus;
                    break;

                case CharacterType.Equal:
                    if (PeekNextCharacterType() == CharacterType.Equal)             // ==
                    {
                        Ret.Type = TokenType.Comparison;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else                                                            //  =
                    {
                        Ret.Type = TokenType.Assignment;
                    }                    
                    break;

                case CharacterType.Ampersand:
                    if (PeekNextCharacterType() == CharacterType.Ampersand)         // &&
                    {
                        Ret.Type = TokenType.LogicalAnd;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else                                                            // &
                    {
                        Ret.Type = TokenType.BitwiseAnd;
                    }                    
                    break;

                case CharacterType.Carrot:                                          // ^
                    Ret.Type = TokenType.BitwiseXOR;
                    break;

                case CharacterType.Pipe:
                    if (PeekNextCharacterType() == CharacterType.Pipe)              // ||
                    {
                        Ret.Type = TokenType.LogicalOR;
                        CurrentValue.Add(ReadNextCharacter());
                    }
                    else                                                            // |
                    {
                        Ret.Type = TokenType.BitwiseOR;
                    }                    
                    break;

                case CharacterType.Asterisk:                                        // *
                    Ret.Type = TokenType.Multiplication;
                    break;

                case CharacterType.Slash:                                           // /
                    Ret.Type = TokenType.Division;
                    break;

                case CharacterType.PercentSign:                                     // %
                    Ret.Type = TokenType.Remainder;
                    break;

                case CharacterType.Tilde:                                           // ~
                    Ret.Type = TokenType.BitwiseNot;
                    break;
                
                case CharacterType.ParenthesesLeft:
                case CharacterType.BracketLeft:
                case CharacterType.GroupLeft:
                    Ret.Type = TokenType.GroupLeft;
                    break;

                case CharacterType.ParenthesesRight:
                case CharacterType.BracketRight:
                case CharacterType.GroupRight:
                    Ret.Type = TokenType.GroupRight;
                    break;

                case CharacterType.PoundSign:
                case CharacterType.Comma:
                case CharacterType.Colon:
                case CharacterType.QuestionMark:
                case CharacterType.Backslash:
                    Ret.Type = TokenType.Symbol;
                    Success = ReadSymbol(ref Ret);
                    break;

                case CharacterType.AtSign:
                    Ret.Type = TokenType.Address;
                    break;

                default:
                    break;
            }

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
