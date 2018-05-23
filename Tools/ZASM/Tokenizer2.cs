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
        CharEnumerator CurrentLine;
        
        /*
        StreamReader _DataReader;
        
        int _FileID;
        int _Line;
        int _Character;

        public Tokenizer(Stream InputStream)
        {
            _DataReader = new StreamReader(InputStream);
            _FileID = 0;
            _Line = 1;
            _Character = 1;
        }

        public InputType PeekNextCharacterType()
        {
            int Current = _DataReader.Peek();

            if (Current == -1)
                return InputType.End;

            else if (Current >= 0x80)
                return InputType.Unknown;

            else
                return DataTables.CharacterData[Current];
        }

        char PeekNextCharacter()
        {
            int Value = _DataReader.Peek();

            if (Value == -1)
                return '\0';

            return (char)Value;
        }

        char ReadNextCharacter()
        {
            int Value = _DataReader.Read();

            _Character++;

            return (char)Value;
        }

        void FlushWhitespace()
        {
            while (PeekNextCharacterType() == InputType.Space || PeekNextCharacterType() == InputType.Tab)
                ReadNextCharacter();
        }

        Token ReadNewline(ref Token NewToken)
        {
            NewToken.Type = TokenType.LineBreak;

            char Current = ReadNextCharacter();
            NewToken.Data.Add(Current);

            // Handle CR/LF
            if (Current == '\r' && PeekNextCharacter() == '\n')
                NewToken.Data.Add(ReadNextCharacter());

            _Line++;
            _Character = 1;

            return NewToken;
        }

        Token ReadComment(ref Token NewToken)
        {
            NewToken.Type = TokenType.Comment;

            while (PeekNextCharacterType() != InputType.LineFeed && PeekNextCharacterType() != InputType.CarriageReturn && PeekNextCharacterType() != InputType.End)
                ReadNextCharacter();

            return NewToken;
        }

        Token ReadIdentifier(ref Token NewToken)
        {
            NewToken.Type = TokenType.Identifier;

            NewToken.Data.Add(ReadNextCharacter());

            while (true)
            {
                InputType NextType = PeekNextCharacterType();

                if(NextType == InputType.Identifier || NextType == InputType.Number || 
                    NextType == InputType.DollarSign || NextType == InputType.Period || NextType == InputType.QuestionMark ||
                    NextType == InputType.AtSign || NextType == InputType.Underscore)
                    NewToken.Data.Add(ReadNextCharacter());

                else
                    break;
                
            }

            return NewToken;
        }

        Token ReadNumber(ref Token NewToken)
        {
            NewToken.Type = TokenType.Number;

            while (true)
            {
                InputType NextType = PeekNextCharacterType();

                if (NextType == InputType.Number)
                    NewToken.Data.Add(ReadNextCharacter());

                else if (NextType == InputType.Identifier)
                    NewToken.Data.Add(ReadNextCharacter());

                else
                    break;
            }

            // Work out the base of the number.
            int Base = 10;
            List<char> TempData = new List<char>(NewToken.Data);

            char TypeChar = TempData[TempData.Count - 1];

            if (TempData.Count >= 2 && TempData[0] == '0' && TempData[1] == 'X') // 0xFF
            {
                TempData.RemoveRange(0, 2);
                Base = 16;
            }
            else if (TempData.Count >= 2 && TempData[0] == '0' && TempData[1] == 'B') // 0b11
            {
                TempData.RemoveRange(0, 2);
                Base = 2;
            }
            else if (TempData[0] == '$') // $FF
            {
                TempData.RemoveAt(0);
                Base = 16;
            }
            else if (TypeChar == 'H')   // 1FH
            {
                TempData.RemoveAt(TempData.Count - 1);
                Base = 16;
            }
            else if (TypeChar == 'O')   // 17o
            {
                TempData.RemoveAt(TempData.Count - 1);
                Base = 8;
            }
            else if (TypeChar == 'D')   // 10D
            {
                TempData.RemoveAt(TempData.Count - 1);
                Base = 10;
            }
            else if (TypeChar == 'B')   // 11B
            {
                TempData.RemoveAt(TempData.Count - 1);
                Base = 2;
            }
            else if (DataTables.CharacterData[TypeChar] != InputType.Number)
            {
                //Message.Log.Add("Tokenizer", _FileID, _Line, _Character, MessageCode.InvalidNumberToken, CurrentString);
                NewToken.Type = TokenType.Error;
                return NewToken;
            }

            if (TempData.Count == 0)
            {
                //Message.Log.Add("Tokenizer", _FileID, _Line, _Character, MessageCode.UnknownError, "Empty Number Token");
                NewToken.Type = TokenType.Error;
                return NewToken;
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

                //Data.NumericValue = Result;
            }
            catch
            {
                //Message.Log.Add("Tokenizer", _FileID, _Line, _Character, MessageCode.InvalidNumberToken, CurrentString);

                //return false;
            }

            return NewToken;
        }

        Token ReadString(ref Token NewToken)
        {
            NewToken.Type = TokenType.String;

            char Quote = ReadNextCharacter();
            NewToken.Data.Add(Quote);

            while (true)
            {
                if (PeekNextCharacterType() == InputType.CarriageReturn || PeekNextCharacterType() == InputType.LineFeed || PeekNextCharacterType() == InputType.End)
                {
                    NewToken.Type = TokenType.Error;
                    break;
                }
                
                char Current = ReadNextCharacter();
                NewToken.Data.Add(Current);

                if (Current == Quote)
                    break;
            }

            return NewToken;
        }

        Token ReadSymbol(ref Token NewToken)
        {
            NewToken.Type = TokenType.Symbol;
            NewToken.Data.Add(ReadNextCharacter());

            while (PeekNextCharacterType() == InputType.PoundSign || PeekNextCharacterType() == InputType.Comma || PeekNextCharacterType() == InputType.Colon ||
                   PeekNextCharacterType() == InputType.QuestionMark || PeekNextCharacterType() == InputType.Backslash || PeekNextCharacterType() == InputType.CurlyBraceLeft ||
                   PeekNextCharacterType() == InputType.CurlyBraceRight)
                NewToken.Data.Add(ReadNextCharacter());

            //Data.StringValue = CurrentString;

            return NewToken;
        }


        public List<Token> GetNextLine()
        {
            List<Token> LineData = new List<Token>();


            while (!_DataReader.EndOfStream)
            {
                Token Data = GetNextToken();

                if (Data.Type == TokenType.WhiteSpace)
                    continue;

                if (Data.Type == TokenType.LineBreak)
                {
                    if (LineData.Count != 0)
                        break;
                }
                else
                {
                    LineData.Add(Data);
                }

                if (_DataReader.EndOfStream)
                    break;
            }

            return LineData;
        }


        public Token GetNextToken()
        {
            Token Ret = new Token();
            Ret.FileID = _FileID;
            Ret.Line = _Line;
            Ret.Character = _Character;
            Ret.CharacterType = PeekNextCharacterType();

            switch (Ret.CharacterType)
            {
                case InputType.Unknown:
                    break;

                case InputType.End:
                    Ret.Type = TokenType.End;
                    Ret.CharacterType = InputType.End;
                    break;

                // New Lines
                case InputType.LineFeed:
                case InputType.CarriageReturn:
                    ReadNewline(ref Ret);
                    break;

                // WhiteSpaces
                case InputType.Tab:
                case InputType.Space:
                    Ret.Type = TokenType.WhiteSpace;
                    FlushWhitespace();
                    break;

                // Comment
                case InputType.SemiColon:
                    ReadComment(ref Ret);
                    break;

                // Indentifiers
                case InputType.Period:
                case InputType.Identifier:
                case InputType.QuestionMark:
                case InputType.Underscore:
                    ReadIdentifier(ref Ret);
                    break;

                case InputType.AtSign:
                    ReadIdentifier(ref Ret);
                    break;

                case InputType.Number:
                    ReadNumber(ref Ret);
                    break;

                // Number or Current Position
                case InputType.DollarSign:
                    if (PeekNextCharacterType() == InputType.Number || PeekNextCharacterType() == InputType.Identifier)
                    {
                        ReadNumber(ref Ret);
                    }
                    else
                    {
                        Ret.Type = TokenType.CurrentPos;
                        Ret.Data.Add(ReadNextCharacter());
                    }
                    break;

                // String
                case InputType.DoubleQuote:
                case InputType.SingleQuote:
                case InputType.ReverseQuote:
                    ReadString(ref Ret);
                    break;

                case InputType.CurlyBraceRight:
                case InputType.CurlyBraceLeft:
                case InputType.PoundSign:
                case InputType.Comma:
                case InputType.Colon:
                case InputType.Backslash:
                    ReadSymbol(ref Ret);
                    break;

                default:
                    Ret.Type = TokenType.Unknown;
                    while (PeekNextCharacterType() == Ret.CharacterType)
                        Ret.Data.Add(ReadNextCharacter());                        

                    break;
                    
            }

            return Ret;
        }
        */    
    }
}
