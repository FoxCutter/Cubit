using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    enum CharacterType
    {
        // Symbol Types
        Unknown,

        Tab,
        Space,

        LineFeed,
        CarriageReturn,

        DoubleQuote,
        SingleQuote,
        ReverseQuote,

        ParenthesesLeft,
        BracketLeft,
        GroupLeft,

        ParenthesesRight,
        BracketRight,
        GroupRight,

        Plus,
        Minus,
        Asterisk,
        Slash,
        PercentSign,
        ExclimationMark,
        Ampersand,
        Carrot,
        Pipe,
        Tilde,

        LessThen,
        Equal,
        GreaterThen,

        DollarSign,

        SemiColon,

        PoundSign,
        Comma,
        Colon,
        QuestionMark,
        AtSign,
        Backslash,

        Period,
        Number,
        Identifier,

        End,
    }
    
    enum TokenType
    {
        Unknown,
        End,
        Error,
        None,

        // Processed Types
        WhiteSpace,
        LineBreak,
        Comment,
        String,
        Number,
        Identifier,
        Symbol,
        Command,
        Label,
        Register,
        Flag,
        Opcode,
        //Result,
        //Displacment,

        // Operators        
        CurrentPos,

        Comparison,
        Assignment,
        
        Plus,
        Minus,
        Multiplication,
        Division,
        Remainder,
        
        LeftShift,
        RightShift,
        
        LessThen,
        GreaterThen,        
        LessEqual,
        GreaterEqual,
        NotEqual,

        LogicalAnd,
        LogicalOR,
        LogicalNot,
        BitwiseAnd,
        BitwiseOR,
        BitwiseXOR,
        BitwiseNot,

        GroupLeft,
        GroupRight,

        Address,

        //UnarrayPlus,
        //UnarrayMinus,
        //Ternary,
    }

    class Token
    {
        public TokenType Type;
        public CommandID CommandID;

        public int FileID;
        public int Line;
        public int Character;

        public string StringValue;
        public int NumericValue;

        public Token()
        {
            Type = TokenType.None;
            Line = 0;
            Character = 0;

            StringValue = null;
            NumericValue = 0;
        }

        override public string ToString()
        {
            StringBuilder Ret = new StringBuilder();

            if (Type == TokenType.Number/* || Type == TokenType.Result*/)
                Ret.AppendFormat("0{0:X2}h", NumericValue);

            else if (Type == TokenType.String)
            {
                Ret.AppendFormat("'{0}'", StringValue);
            }
            else if (Type == TokenType.Symbol)
            {
                Ret.Append(StringValue);
            }
            else
            {
                if (CommandID != ZASM.CommandID.None)
                    Ret.Append(CommandID);
                else
                    Ret.AppendFormat("<{0}>", Type);
            }

            return Ret.ToString();
        }
    
    }
}
