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
                else if (Type == ParameterType.RegisterDisplacedPtr)
                    return TokenList[0];
                else
                    return new Token();
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
        
        public bool Simplify(int CurrentAddress)
        {
            Token TempToken = null;
            
            Stack<Token> TempStack = new Stack<Token>();
            int Pos = 0;

            while (Pos < TokenList.Count)
            {
                Token Current = TokenList[Pos];
                Pos++;

                if (Current.IsIndexWord())
                {
                    if (TempToken != null)
                    {
                        MessageLog.Log.Add("Parser", TempToken.Location, MessageCode.SyntaxError, "Can not have two Index's in the same memory refrence");
                        return false;
                    }

                    TempToken = Current;
                    Current = new Token();
                    Current.Type = TokenType.Result;
                    Current.Location = TempToken.Location;
                    Current.NumericValue = 0;
                }

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
                    TempStack.Push(ConvertToken(Current, CurrentAddress));
                }
            }

            TokenList = TempStack.Reverse().ToList();

            if (TempToken != null)
            {
                TempToken.Type = TokenType.Displacment;
                TokenList.Insert(0, TempToken);

                //TempToken = new Token();
                //TempToken.Type = TokenType.Plus;
                //TokenList.Add(TempToken);                
            }            

            //if (TokenList[0].IsIndexWord() && TokenList.Last().IsOperator())
            //{
            //    Token Current = TokenList[0];
            //    Current.Type = TokenType.Displacment;
            //    TokenList.RemoveAt(0);
            //    TokenList.Insert(0, Current);
            //}

            Type = TypeToken(TokenList[0]);

            return TokenList.Count == 1;
        }

        Token ConvertToken(Token CurrentToken, int CurrentAddress)
        {
            if (CurrentToken.IsString())
            {
                //if (CurrentToken.StringValue.Length <= 2)
                //{
                //    CurrentToken.Type = TokenType.Result;
                //}
            }
            else if (CurrentToken.IsIdentifier())
            {
                SymbolTableEntry Symbol = CurrentToken.Symbol;

                if (Symbol.Type == SymbolType.None)
                {
                    // ERROR!
                    MessageLog.Log.Add("Parser", CurrentToken.Location, MessageCode.UndefinedSymbol, CurrentToken.ToString());
                }
                else if (Symbol.State == SymbolState.Undefined || Symbol.State == SymbolState.ValuePending)
                {
                    // Value hasn't been defined yet, so we can't do any more to it.                    
                }
                else if (Symbol.Type == SymbolType.Value || Symbol.Type == SymbolType.Constant)
                {
                    CurrentToken.Type = TokenType.Result;

                    if (Symbol.Type == SymbolType.Constant || Symbol.Type == SymbolType.Value)
                    {
                        CurrentToken.NumericValue = ((ValueInformation)Symbol.Object).Value;
                    }

                    else
                        MessageLog.Log.Add("Parser", CurrentToken.Location, MessageCode.UnknownError, "Unexpected symbol table type");
                    
                }
            }
            else if (CurrentToken.Type == TokenType.Number)
            {
                CurrentToken.Type = TokenType.Result;
            }
            else if (CurrentToken.Type == TokenType.CurrentPos)
            {
                CurrentToken.Type = TokenType.Result;
                CurrentToken.NumericValue = CurrentAddress;
            }
            
            return CurrentToken;
        }

        Token ExecuteToken(Token Op1, Token CurrentToken, Token Op2)
        {
            Token Result = new Token();
            Result.Location = CurrentToken.Location;
            Result.Type = TokenType.Unknown;
            //Result.Value = new List<char>();

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

            if (Op2.NumericValue == 0 && (CurrentToken.Type == TokenType.Division || CurrentToken.Type == TokenType.Remainder))
            {
                //MessageLog.Log.Add("Parser", CurrentToken.Location, MessageCode.DivisionByZero);
            }
            else
            {
                switch (CurrentToken.Type)
                {
                    case TokenType.UnarrayPlus:
                        Result.NumericValue = +Op2.NumericValue;
                        break;

                    case TokenType.UnarrayMinus:
                        Result.NumericValue = -Op2.NumericValue;
                        break;

                    case TokenType.BitwiseNot:
                        Result.NumericValue = ~Op2.NumericValue;
                        break;

                    case TokenType.High:
                        Result.NumericValue = (Op2.NumericValue & 0xFF00) >> 8;
                        break;

                    case TokenType.Low:
                        Result.NumericValue = (Op2.NumericValue & 0x00FF);
                        break;


                    case TokenType.Plus:
                        Result.NumericValue = Op1.NumericValue + Op2.NumericValue;
                        break;

                    case TokenType.Minus:
                        Result.NumericValue = Op1.NumericValue - Op2.NumericValue;
                        break;

                    case TokenType.Multiplication:
                        Result.NumericValue = Op1.NumericValue * Op2.NumericValue;
                        break;

                    case TokenType.Division:
                        Result.NumericValue = Op1.NumericValue / Op2.NumericValue;
                        break;

                    case TokenType.Remainder:
                        Result.NumericValue = Op1.NumericValue % Op2.NumericValue;
                        break;

                    case TokenType.BitwiseAnd:
                        Result.NumericValue = Op1.NumericValue & Op2.NumericValue;
                        break;

                    case TokenType.BitwiseXOR:
                        Result.NumericValue = Op1.NumericValue ^ Op2.NumericValue;
                        break;

                    case TokenType.BitwiseOR:
                        Result.NumericValue = Op1.NumericValue | Op2.NumericValue;
                        break;

                    case TokenType.LeftShift:
                        Result.NumericValue = Op1.NumericValue << Op2.NumericValue;
                        break;

                    case TokenType.RightShift:
                        Result.NumericValue = Op1.NumericValue >> Op2.NumericValue;
                        break;

                    case TokenType.LogicalNot:
                        Result.NumericValue = (Op2.NumericValue == 0) ? 1 : 0;
                        break;

                    case TokenType.LessThen:
                        Result.NumericValue = (Op1.NumericValue < Op2.NumericValue) ? 1 : 0;
                        break;

                    case TokenType.GreaterThen:
                        Result.NumericValue = (Op1.NumericValue > Op2.NumericValue) ? 1 : 0;
                        break;

                    case TokenType.LessEqual:
                        Result.NumericValue = (Op1.NumericValue <= Op2.NumericValue) ? 1 : 0;
                        break;

                    case TokenType.GreaterEqual:
                        Result.NumericValue = (Op1.NumericValue >= Op2.NumericValue) ? 1 : 0;
                        break;

                    case TokenType.Equal:
                        Result.NumericValue = (Op1.NumericValue == Op2.NumericValue) ? 1 : 0;
                        break;

                    case TokenType.NotEqual:
                        Result.NumericValue = (Op1.NumericValue != Op2.NumericValue) ? 1 : 0;
                        break;

                    case TokenType.LogicalAnd:
                        Result.NumericValue = (Op1.NumericValue != 0 && Op2.NumericValue != 0) ? 1 : 0;
                        break;

                    case TokenType.LogicalOR:
                        Result.NumericValue = (Op1.NumericValue != 0 || Op2.NumericValue != 0) ? 1 : 0;
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
                else if (Current.Type == TokenType.Displacment)
                {
                    TempStack.Push(string.Format("<Index> {0}", Current.CommandID));
                }
                else if (Current.Type == TokenType.Result)
                {
                    TempStack.Push(string.Format("0{0:X}h", (short)Current.NumericValue));
                }
                else if (Current.Type == TokenType.Identifier)
                {
                    TempStack.Push(Current.Symbol.Name);
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
