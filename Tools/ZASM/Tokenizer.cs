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
        End,
        WhiteSpace,
        Letter,
        Number,
        Symbol,
        LineBreak,
        Comment,
        Unknown,
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

    class Tokenizer
    {        
        BinaryReader DataStream;

        static TokenType[] TokenData = new TokenType[]
        {
            TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown,
            TokenType.Unknown, TokenType.Unknown, TokenType.Unknown,

            TokenType.WhiteSpace,   // Tab

            TokenType.LineBreak, TokenType.Unknown, TokenType.Unknown, TokenType.LineBreak, TokenType.Unknown, TokenType.Unknown,
            TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown,
            TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown,
            TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown,

            TokenType.WhiteSpace,   // Space
            
            // !"#$%&'()*+,-./
            TokenType.Symbol, TokenType.Symbol, TokenType.Symbol, TokenType.Symbol, TokenType.Symbol,
            TokenType.Symbol, TokenType.Symbol, TokenType.Symbol, TokenType.Symbol, TokenType.Symbol,
            TokenType.Symbol, TokenType.Symbol, TokenType.Symbol, TokenType.Symbol, TokenType.Symbol,
            
            // 0-9
            TokenType.Number, TokenType.Number, TokenType.Number, TokenType.Number, TokenType.Number,
            TokenType.Number, TokenType.Number, TokenType.Number, TokenType.Number, TokenType.Number,

            // :;<=>?@
            TokenType.Symbol, TokenType.Comment, TokenType.Symbol, TokenType.Symbol, TokenType.Symbol,
            TokenType.Symbol, TokenType.Symbol,

            // A-Z
            TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter,
            TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter,
            TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter,
            TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter,
            TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter,
            TokenType.Letter,

            // [\]^_`
            TokenType.Symbol, TokenType.Symbol, TokenType.Symbol, TokenType.Symbol, TokenType.Symbol,
            TokenType.Symbol,
            
            // a-z
            TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter,
            TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter,
            TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter,
            TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter,
            TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter, TokenType.Letter,
            TokenType.Letter,

            // {|}~
            TokenType.Symbol, TokenType.Symbol, TokenType.Symbol, TokenType.Symbol, TokenType.Unknown,
        };

        TokenType PeakNextToken()
        {
            int Current = DataStream.PeekChar();

            if (Current == -1)
                return TokenType.End;
            else
                return TokenData[Current];
        }
        
        public Tokenizer(Stream InputStream)
        {
            DataStream = new BinaryReader(InputStream);
        }

        public Token NextToken()
        {
            Token Ret;

            Ret.Type = TokenType.End;
            Ret.Value = new List<char>();

            while (PeakNextToken() == TokenType.WhiteSpace)
                DataStream.Read();

            Ret.Type = PeakNextToken();

            if (PeakNextToken() == TokenType.Symbol && DataStream.PeekChar() == '$')
            {
                Ret.Type = TokenType.Number;
                Ret.Value.Add(DataStream.ReadChar());
            }
                
            switch (Ret.Type)
            {
                case TokenType.End:
                    return Ret;

                case TokenType.Number:
                    while (PeakNextToken() == TokenType.Letter || PeakNextToken() == TokenType.Number)
                        Ret.Value.Add(DataStream.ReadChar());
                    break;

                case TokenType.Letter:
                    while (PeakNextToken() == TokenType.Letter || PeakNextToken() == TokenType.Number)
                        Ret.Value.Add(DataStream.ReadChar());

                    if(PeakNextToken() == TokenType.Symbol && DataStream.PeekChar() == ':')
                        Ret.Value.Add(DataStream.ReadChar());
                    break;

                case TokenType.Comment:
                    while (PeakNextToken() != TokenType.LineBreak && PeakNextToken() != TokenType.End)
                        Ret.Value.Add(DataStream.ReadChar());
                    break;

                case TokenType.Symbol:
                    Ret.Value.Add(DataStream.ReadChar());
                    break;

                default:
                    while (PeakNextToken() == Ret.Type)
                        Ret.Value.Add(DataStream.ReadChar());
                    break;
            }
            
            return Ret;
        }

    }
}
