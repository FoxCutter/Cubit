using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    enum ParameterType
    {
        None,
        Unknown,

        // The param is a register
        RegisterByte,
        RegisterWord,
        
        // The param is a register used as a pointer
        RegisterPtr,
        
        // The param is IX or IY plus a displacment value
        RegisterDisplacedPtr,

        // Imidiate data, byte or word
        Immediate,

        // The immidate value is an addres, word length
        ImmediatePtr,

        // Encoded value
        Encoded,

        // Coniditon code
        Conditional,

        // Operator
        Operator,

        Invalid,
    }

    class ParameterInformation
    {
        List<Token> TokenList;
        public bool Pointer;
        public ParameterType Type;

        public ParameterInformation()
        {
            TokenList = new List<Token>();
            Type = ParameterType.None;
            Pointer = false;
        }

        public override string ToString()
        {
            StringBuilder Ret = new StringBuilder();

            if (Pointer)
                Ret.Append("(");

            Ret.Append(TokenListToString());

            if (Pointer)
                Ret.Append(")");

            return Ret.ToString();
        }

        public Token Value
        {
            get
            {
                if (TokenList.Count == 1)
                    return TokenList[0];
                else
                    return default(Token);
            }
            
            set
            {
                if(TokenList.Count == 0)
                    Add(value);

                else if (TokenList.Count == 1)
                {
                    TokenList.RemoveAt(0);
                    TokenList.Insert(0, value);
                }
            }
        }

        public int Count
        {
            get
            {
                return TokenList.Count;
            }
        }
        
        
        public void Add(Token NewToken)
        {
            TokenList.Add(NewToken);
        }

        public void GuessType()
        {

        }
        
        public bool Simplify()
        {
            Stack<Token> TempStack = new Stack<Token>();
            int Pos = 0;

            while (Pos < TokenList.Count)
            {                               
                Token Current = TokenList[Pos];
                Pos++;

                if (Current.IsOperator())
                {
                    if (Current.RightToLeft())
                    {
                        Token RHS = TempStack.Pop();

                        Token Result = ExecuteToken(RHS, Current, RHS);
                        if (Result.Type != TokenType.Result)
                        {
                            TempStack.Push(RHS);
                            TempStack.Push(Current);
                        }
                        else
                        {
                            TempStack.Push(Result);
                        }
                    }
                    else
                    {
                        Token RHS = TempStack.Pop();
                        Token LHS = TempStack.Pop();

                        Token Result = ExecuteToken(LHS, Current, RHS);
                        if (Result.Type != TokenType.Result)
                        {
                            TempStack.Push(LHS);
                            TempStack.Push(RHS);
                            TempStack.Push(Current);
                        }
                        else
                        {
                            TempStack.Push(Result);
                        }
                    }
                }
                else
                {
                    TempStack.Push(ConvertToken(Current));
                }
            }

            TokenList = TempStack.Reverse().ToList();

            if (TokenList[0].IsIndexWord() && TokenList.Last().IsOperator())
            {
                Token Current = TokenList[0];
                Current.Type = TokenType.Displacment;
                TokenList.RemoveAt(0);
                TokenList.Insert(0, Current);
            }

            Type = TypeToken(TokenList[0]);

            return TokenList.Count == 1;
        }

        Token ConvertToken(Token CurrentToken)
        {
            if (CurrentToken.IsString())
            {
                if (CurrentToken.Value.Count <= 2)
                {
                    CurrentToken.Type = TokenType.Result;

                    if (CurrentToken.Value.Count >= 1)
                        CurrentToken.NumaricValue = CurrentToken.Value[0];

                    if (CurrentToken.Value.Count >= 2)
                    {
                        CurrentToken.NumaricValue = CurrentToken.NumaricValue << 8;
                        CurrentToken.NumaricValue += CurrentToken.Value[1];
                    }
                }
            }
            else if (CurrentToken.IsIdentifier())
            {
                SymbolTableEntry Symbol = CurrentToken.Symbol;

                if (Symbol.Type == SymbolType.None)
                {
                    // ERROR!
                    MessageLog.Log.Add("Parser", CurrentToken.Location, MessageCode.UndefinedSymbol, CurrentToken.ToString());
                }
                else if (Symbol.Type == SymbolType.Undefined)
                {
                    // Value hasn't been defined yet, so we can't do any more to it.                    
                }
                else if (Symbol.Type == SymbolType.Address || Symbol.Type == SymbolType.Value)
                {
                    CurrentToken.Type = TokenType.Result;

                    if (Symbol.DefinedLine.Type == ObjectType.Value)
                        CurrentToken.NumaricValue = ((ValueInformation)Symbol.DefinedLine).Value; 

                    else if (Symbol.DefinedLine.Type == ObjectType.Label)
                        CurrentToken.NumaricValue = ((LabelInformation)Symbol.DefinedLine).Address; 
                    
                    else
                        MessageLog.Log.Add("Parser", CurrentToken.Location, MessageCode.UnknownError, "Unexpected symbol table type");
                    
                }
            }
            else if (CurrentToken.Type == TokenType.Number)
            {
                CurrentToken.Type = TokenType.Result;
            }
            
            return CurrentToken;
        }
        
        Token ExecuteToken(Token Op1, Token CurrentToken, Token Op2)
        {
            Token Result = CurrentToken;
            Result.Value = new List<char>();
            Result.Type = TokenType.Unknown;

            if (!CurrentToken.IsOperator())
                return Result;

            if (CurrentToken.RightToLeft())
            {
                if (Op2.Type != TokenType.Result)
                    return Result;
            }
            else
            {
                if (Op1.Type != TokenType.Result || Op2.Type != TokenType.Result)
                    return Result;
            }

            if (Op2.NumaricValue == 0 && (CurrentToken.Type == TokenType.Division || CurrentToken.Type == TokenType.Remainder))
            {
                MessageLog.Log.Add("Parser", CurrentToken.Location, MessageCode.DivisionByZero);
            }
            else
            {
                switch (CurrentToken.Type)
                {
                    case TokenType.UnarrayPlus:
                        Result.NumaricValue = +Op2.NumaricValue;
                        break;

                    case TokenType.UnarrayMinus:
                        Result.NumaricValue = -Op2.NumaricValue;
                        break;

                    case TokenType.BitwiseNot:
                        Result.NumaricValue = ~Op2.NumaricValue;
                        break;

                    case TokenType.High:
                        Result.NumaricValue = (Op2.NumaricValue & 0xFF00) >> 8;
                        break;

                    case TokenType.Low:
                        Result.NumaricValue = (Op2.NumaricValue & 0x00FF);
                        break;


                    case TokenType.Plus:
                        Result.NumaricValue = Op1.NumaricValue + Op2.NumaricValue;
                        break;

                    case TokenType.Minus:
                        Result.NumaricValue = Op1.NumaricValue - Op2.NumaricValue;
                        break;

                    case TokenType.Multiplication:
                        Result.NumaricValue = Op1.NumaricValue * Op2.NumaricValue;
                        break;

                    case TokenType.Division:
                        Result.NumaricValue = Op1.NumaricValue / Op2.NumaricValue;
                        break;

                    case TokenType.Remainder:
                        Result.NumaricValue = Op1.NumaricValue % Op2.NumaricValue;
                        break;

                    case TokenType.BitwiseAnd:
                        Result.NumaricValue = Op1.NumaricValue & Op2.NumaricValue;
                        break;

                    case TokenType.BitwiseXOR:
                        Result.NumaricValue = Op1.NumaricValue ^ Op2.NumaricValue;
                        break;

                    case TokenType.BitwiseOR:
                        Result.NumaricValue = Op1.NumaricValue | Op2.NumaricValue;
                        break;

                    case TokenType.LeftShift:
                        Result.NumaricValue = Op1.NumaricValue << Op2.NumaricValue;
                        break;

                    case TokenType.RightShift:
                        Result.NumaricValue = Op1.NumaricValue >> Op2.NumaricValue;
                        break;

                    case TokenType.LogicalNot:
                        Result.NumaricValue = (Op2.NumaricValue == 0) ? 1 : 0;
                        break;

                    case TokenType.LessThen:
                        Result.NumaricValue = (Op1.NumaricValue < Op2.NumaricValue) ? 1 : 0;
                        break;

                    case TokenType.GreaterThen:
                        Result.NumaricValue = (Op1.NumaricValue > Op2.NumaricValue) ? 1 : 0;
                        break;

                    case TokenType.LessEqual:
                        Result.NumaricValue = (Op1.NumaricValue <= Op2.NumaricValue) ? 1 : 0;
                        break;

                    case TokenType.GreaterEqual:
                        Result.NumaricValue = (Op1.NumaricValue >= Op2.NumaricValue) ? 1 : 0;
                        break;

                    case TokenType.Equal:
                        Result.NumaricValue = (Op1.NumaricValue == Op2.NumaricValue) ? 1 : 0;
                        break;

                    case TokenType.NotEqual:
                        Result.NumaricValue = (Op1.NumaricValue != Op2.NumaricValue) ? 1 : 0;
                        break;

                    case TokenType.LogicalAnd:
                        Result.NumaricValue = (Op1.NumaricValue != 0 && Op2.NumaricValue != 0) ? 1 : 0;
                        break;

                    case TokenType.LogicalOR:
                        Result.NumaricValue = (Op1.NumaricValue != 0 || Op2.NumaricValue != 0) ? 1 : 0;
                        break;
                }

                Result.Type = TokenType.Result;
            }

            return Result;
        }

        ParameterType TypeToken(Token CurrentToken)
        {
            if (CurrentToken.IsDisplacment())
            {
                return ParameterType.RegisterDisplacedPtr;
            }
            else if (CurrentToken.IsFlag())
            {
                return ParameterType.Conditional;
            }
            else if (CurrentToken.IsRegister())
            {
                if (CurrentToken.CommandID >= CommandID.Word)
                {
                    if (Pointer)
                    {
                        return ParameterType.RegisterPtr;
                    }
                    else
                    {
                        return ParameterType.RegisterWord;
                    }
                }
                else
                {
                    if (Pointer)
                    {
                        // Byte Registers can't be pointers, so thrown an error
                        return ParameterType.Invalid;
                    }
                    else
                    {
                        return ParameterType.RegisterByte;
                    }
                }
            }
            else if (CurrentToken.IsOperator() || CurrentToken.IsOpcode() || CurrentToken.IsCommand())
            {
                return ParameterType.None;
            }
            else
            {
                if (Pointer)
                    return ParameterType.ImmediatePtr;

                else
                    return ParameterType.Immediate;
            }
        }
        
        string TokenListToString()
        {
            int Pos = 0;
            StringBuilder Ret = new StringBuilder();
            if (Pos >= TokenList.Count)
                return "";

            Stack<string> TempStack = new Stack<string>();

            while (Pos < TokenList.Count)
            {
                Token Current = TokenList[Pos];
                Pos++;

                if (Current.IsOperator())
                {
                    if (Current.RightToLeft())
                    {
                        string RHS = TempStack.Pop();
                        TempStack.Push(string.Format("{0}{1}", Current.ToString(), RHS));
                    }
                    else
                    {
                        string RHS = TempStack.Pop();
                        string LHS = TempStack.Pop();

                        TempStack.Push(string.Format("{0} {1} {2}", LHS, Current, RHS));
                    }
                }
                else if(Current.Type == TokenType.Result)
                {
                    TempStack.Push(Current.NumaricValue.ToString());
                }
                else
                {
                    TempStack.Push(Current.ToString());
                }
            }

            while (TempStack.Count != 0)
            {
                if (Ret.Length != 0)
                    Ret.Append(" ");

                Ret.Append(TempStack.Pop().ToString());
            }

            return Ret.ToString();
        }
    }
}
