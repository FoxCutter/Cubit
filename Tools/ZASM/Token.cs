using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    enum InputType
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
        CurlyBraceLeft,

        ParenthesesRight,
        BracketRight,
        CurlyBraceRight,

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
        Underscore,

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

        None,
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
        PsudoOpcode,
        Preprocessor,
        Label,
        Register,
        Flag,
        Opcode,
        CurrentPos,
        Address,
        //Result,
        //Displacment,

        // Operators        
        Operator,

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

        // ( & )
        GroupLeft,
        GroupRight,

        // [ & ]
        ArrayLeft,
        ArrayRight,

        UnarrayPlus,
        UnarrayMinus,
        //Ternary,
    }

    class Token
    {
        public TokenType Type;
        public InputType CharacterType;

        public int Character;

        public string StringValue;
        public int NumericValue;

        public string TokenData;

        public OpcodeData.ParameterID ParameterID;

        public Token(TokenType Type = TokenType.None, InputType CharacterType = InputType.None)
        {
            this.Type = Type;
            this.CharacterType = CharacterType;

            Character = 0;
            ParameterID = OpcodeData.ParameterID.None;
        }

        public override string ToString()
        {
            StringBuilder Ret = new StringBuilder();

            if (Type == TokenType.Number/* || Type == TokenType.Result*/)
                Ret.AppendFormat("0{0:X2}h", NumericValue);

            else if (Type == TokenType.String)
            {
                Ret.AppendFormat("'{0}'", StringValue);
            }
            else if (Type == TokenType.Label)
            {
                Ret.AppendFormat("{0}:", StringValue);
            }
            else if (Type == TokenType.Symbol || Type == TokenType.Identifier)
            {
                Ret.Append(StringValue);
            }
            else if (Type == TokenType.Register || Type == TokenType.Flag)
            {
                Ret.AppendFormat("{0}", ParameterID);
            }
            else
            {
                //if (CommandID != ZASM.CommandID.None)
                //    Ret.Append(CommandID);
                //else
                Ret.AppendFormat("<{0}>", Type);
            }

            return Ret.ToString();
        }
    }
}
