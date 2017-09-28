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
        Data,
        Preprocessor,
        Label,
        Register,
        Flag,
        Opcode,
        CurrentPos,
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

        GroupLeft,
        GroupRight,

        Address,

        UnarrayPlus,
        UnarrayMinus,
        //Ternary,

        High,
        Low,
    }

    class Token
    {
        public TokenType Type;
        public CharacterType CharacterType;
        public CommandID CommandID;

        public int FileID;
        public int Line;
        public int Character;

        public string StringValue;
        public short NumericValue;

        public Token()
        {
            Type = TokenType.None;
            CharacterType = ZASM.CharacterType.None;
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
            else if (Type == TokenType.Symbol || Type == TokenType.Identifier)
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

        public bool AssumeA()
        {
            return Type == TokenType.Opcode &&
                (CommandID == ZASM.CommandID.ADC || CommandID == ZASM.CommandID.ADD ||
                  CommandID == ZASM.CommandID.SUB || CommandID == ZASM.CommandID.SBC ||
                  CommandID == ZASM.CommandID.OR || CommandID == ZASM.CommandID.XOR ||
                  CommandID == ZASM.CommandID.AND || CommandID == ZASM.CommandID.CP ||
                  CommandID == ZASM.CommandID.IN || CommandID == ZASM.CommandID.OUT ||
                  CommandID == ZASM.CommandID.CPL);
        }

        public bool CanHaveFlag()
        {
            return (CommandID == CommandID.JR || CommandID == CommandID.JP || CommandID == CommandID.CALL || CommandID == CommandID.RET);
        }

        public bool RightToLeft()
        {
            return Type == TokenType.UnarrayMinus ||
                    Type == TokenType.UnarrayPlus ||
                    Type == TokenType.LogicalNot ||
                    Type == TokenType.BitwiseNot ||
                    Type == TokenType.High ||
                    Type == TokenType.Low ||
                    Type == TokenType.Address;
        }

        public bool IsOperator()
        {
            return Type > TokenType.Operator;
        }

        public bool IsGroup()
        {
            return Type == TokenType.GroupLeft || Type == TokenType.GroupRight;
        }

        public bool IsIndex()
        {
            return Type == TokenType.Register && (CommandID == ZASM.CommandID.IX || CommandID == ZASM.CommandID.IY);
        }

    }
}
