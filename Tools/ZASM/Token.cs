using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    enum TokenType
    {
        None,
        End,
        Error,
        WhiteSpace,
        Unknown,

        Comment,
        LineBreak,
        Identifier,
        Keyword,
        Command,
        Register,
        Flag,
        Number,
        Result,
        Symbol,
        String,
        Label,
        Displacment,

        // Symbol Types
        Period,
        Colon,
        Comma,

        Operator,

        GroupLeft,
        GroupRight,
        ParenthesesLeft,
        ParenthesesRight,
        BracketLeft,
        BracketRight,

        High,
        Low,

        UnarrayPlus,
        UnarrayMinus,
        LogicalNot,
        BitwiseNot,
        Address,

        Multiplication,
        Division,
        Remainder,
        Plus,
        Minus,
        LeftShift,
        RightShift,

        LessThen,
        GreaterThen,
        LessEqual,
        GreaterEqual,

        Equal,
        NotEqual,

        BitwiseAnd,
        BitwiseOR,
        BitwiseXOR,
        LogicalAnd,
        LogicalOR,

        Ternary,
    }

    struct Token
    {
        public TokenType Type;
        public CommandID CommandID;
        public List<char> Value;
        public SymbolTableEntry Symbol;
        
        public int NumaricValue;

        public FileInformation File;
        public int Line;
        public int Character;
        public long Pos;

        public bool CanHaveFlag()
        {
            if (!IsKeyword())
                return false;

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
                    Type == TokenType.Ternary ||
                    Type == TokenType.Address;
        }

        public bool IsEmpty()
        {
            return Type == TokenType.None;
        }

        public bool IsValue()
        {
            return Type == TokenType.Number || Type == TokenType.Identifier || Type == TokenType.String || Type == TokenType.Label || Type == TokenType.ParenthesesRight || Type == TokenType.BracketRight;
        }

        public bool IsIndexWord()
        {
            return Type == TokenType.Register && (CommandID == ZASM.CommandID.IX || CommandID == ZASM.CommandID.IY);
        }

        public bool IsIndexHigh()
        {
            return Type == TokenType.Register && (CommandID == ZASM.CommandID.IXH || CommandID == ZASM.CommandID.IYH);
        }

        public bool IsIndexLow()
        {
            return Type == TokenType.Register && (CommandID == ZASM.CommandID.IXL || CommandID == ZASM.CommandID.IYL);
        }
        
        public bool IsDisplacment()
        {
            return Type == TokenType.Displacment && (CommandID == ZASM.CommandID.IX || CommandID== ZASM.CommandID.IY);
        }

        public bool IsEnd()
        {
            return Type == TokenType.LineBreak;
        }

        public bool IsEncoded()
        {
            return Type == TokenType.Keyword && (CommandID == ZASM.CommandID.RST || CommandID == ZASM.CommandID.SET || CommandID == ZASM.CommandID.BIT || CommandID == ZASM.CommandID.RES);
        }

        public bool HasAddress()
        {
            return Type == TokenType.Keyword && (CommandID == ZASM.CommandID.CALL || CommandID == ZASM.CommandID.JP);
        }

        public bool HasReletiveAddress()
        {
            return Type == TokenType.Keyword && (CommandID == ZASM.CommandID.JR || CommandID == ZASM.CommandID.DJNZ);
        }

        public bool AssumeA()
        {
            return Type == TokenType.Keyword && 
                ( CommandID == ZASM.CommandID.ADC || CommandID == ZASM.CommandID.ADD || 
                  CommandID == ZASM.CommandID.SUB || CommandID == ZASM.CommandID.SBC ||
                  CommandID == ZASM.CommandID.OR  || CommandID == ZASM.CommandID.XOR ||
                  CommandID == ZASM.CommandID.AND || CommandID == ZASM.CommandID.CP  ||
                  CommandID == ZASM.CommandID.IN  || CommandID == ZASM.CommandID.OUT);
        }

        public bool IsBreak()
        {
            return Type == TokenType.End || Type == TokenType.LineBreak;
        }

        public bool IsLabel()
        {
            return Type == TokenType.Label;
        }

        public bool IsKeyword()
        {
            return Type == TokenType.Keyword;
        }

        public bool IsRegister()
        {
            return Type == TokenType.Register;
        }

        public bool IsFlag()
        {
            return Type == TokenType.Flag;
        }

        public bool IsCommand()
        {
            return Type == TokenType.Command;
        }

        public bool IsIdentifier()
        {
            return Type == TokenType.Identifier;
        }

        public bool IsString()
        {
            return Type == TokenType.String;
        }

        public bool IsOperator()
        {
            return Type > TokenType.Operator;
        }

        public bool IsGroupLeft()
        {
            return Type == TokenType.ParenthesesLeft || Type == TokenType.BracketLeft;
        }

        public bool IsGroupRight()
        {
            return Type == TokenType.ParenthesesRight || Type == TokenType.BracketRight;
        }

        public bool IsGroup()
        {
            return IsGroupLeft() || IsGroupRight();
        }

        override public string ToString()
        {
            if (Value == null || Value.Count == 0)
                return NumaricValue.ToString();

            return new string(Value.ToArray());
        }
    }
}

