using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{

    enum ParameterType
    {
        Unknown,

        // B, C, D, E, H, L, M, A, R, I, 
        ByteRegister,

        // BC, DE, HL, SP, AF, PSW
        WordRegister,

        // IXL, IXH, IYL, IYH
        ByteIndexRegister,

        // IX, IY
        WordIndexRegister,

        // SP + *
        ByteOffset,

        // ($FF00 + c), ($FF00 + *), (C), (*) 
        ByteOffsetPointer,

        // (**)
        AddressPointer,

        // (BC), (DE), (HL), (SP), (HLI), (HLD), M
        AddressRegister,

        // (IX) (IY)
        AddressIndexRegister,

        // C, NC, Z, NZ, E, O, M, P
        Flag,

        // Immidate, Encoded
        Value,

        Error,
    }
    
    class ParameterInformation
    {
        public List<Token> TokenList;
        public bool Pointer;
        public ParameterType Type;

        public ParameterInformation()
        {
            TokenList = new List<Token>();
            Pointer = false;
            Type = ParameterType.Unknown;
        }

        public Token Value
        {
            get
            {
                if (TokenList.Count == 1)
                    return TokenList[0];
                else
                    return new Token();
            }

            set
            {
                if (TokenList.Count == 0)
                    TokenList.Add(value);

                else if (TokenList.Count == 1)
                {
                    TokenList.RemoveAt(0);
                    TokenList.Insert(0, value);
                }
            }
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

        public bool HasTokenType(TokenType Value)
        {
            return TokenList.Where(e => e.Type == Value).Count() != 0;
        }

        public int TokenTypeCount(TokenType Value)
        {
            return TokenList.Where(e => e.Type == Value).Count();
        }

        public bool HasCommandID(CommandID Value)
        {
            return TokenList.Where(e => e.CommandID == Value).Count() != 0;
        }

        public bool HasOperators()
        {
            return TokenList.Where(e => e.IsOperator()).Count() != 0;
        }

        public bool HasByteRegister()
        {
            return TokenList.Where(e => e.IsByteRegister()).Count() != 0;
        }

        public bool HasByteIndexRegister()
        {
            return TokenList.Where(e => e.IsByteIndexRegister()).Count() != 0;
        }

        public bool HasWordRegister()
        {
            return TokenList.Where(e => e.IsWordRegister()).Count() != 0;
        }

        public bool HasWordIndexRegister()
        {
            return TokenList.Where(e => e.IsWordIndexRegister()).Count() != 0;
        }


        void SetTokenType()
        {
            if (Pointer)
            {
                if (HasWordIndexRegister())
                    Type = ParameterType.AddressIndexRegister;

                else if (HasWordRegister())
                    Type = ParameterType.AddressRegister;

                else
                    Type = ParameterType.AddressPointer;
            }
            else
            {
                if (HasTokenType(TokenType.Flag))
                    Type = ParameterType.Flag;

                else if (HasWordIndexRegister())
                    Type = ParameterType.WordIndexRegister;

                else if (HasWordRegister())
                    Type = ParameterType.WordRegister;

                else if (HasByteRegister())
                    Type = ParameterType.ByteRegister;

                else
                    Type = ParameterType.Value;
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

                if (Current.IsGroup())
                {
                    TempStack.Push(Current.ToString());
                }
                else if (Current.IsOperator())
                {
                    if (Current.RightToLeft())
                    {
                        if (TempStack.Count < 1)
                        {
                            TempStack.Push(string.Format("{0}[Missing]", Current.ToString()));
                        }
                        else
                        {
                            string RHS = TempStack.Pop();
                            TempStack.Push(string.Format("{0}{1}", Current.ToString(), RHS));
                        }
                    }
                    else
                    {
                        if (TempStack.Count < 2)
                        {
                            if (TempStack.Count == 1)
                            {
                                string LHS = TempStack.Pop();
                                TempStack.Push(string.Format("{0} {1} [Missing]", LHS, Current));
                            }
                            else
                            {
                                TempStack.Push(string.Format("[Missing] {0} [Missing]", Current));
                            }
                        }
                        else
                        {
                            string RHS = TempStack.Pop();
                            string LHS = TempStack.Pop();

                            TempStack.Push(string.Format("{0} {1} {2}", LHS, Current, RHS));
                        }
                    }
                }
                //else if (Current.Type == TokenType.Displacment)
                //{
                //    TempStack.Push(string.Format("<Index> {0}", Current.CommandID));
                //}
                //else if (Current.Type == TokenType.Result)
                //{
                //    TempStack.Push(string.Format("0{0:X}h", (short)Current.NumericValue));
                //}
                else if (Current.Type == TokenType.Identifier)
                {
                    TempStack.Push(Current.StringValue);
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

        public bool OrderValues(bool CanHavePointer)
        {
            Stack<Token> TempStack = new Stack<Token>();
            List<Token> NewTokenList = new List<Token>();

            int Depth = 0;

            for(int Pos = 0; Pos < TokenList.Count; Pos++)
            {
                Token CurrentToken = TokenList[Pos];

                if (CurrentToken.Type == TokenType.GroupLeft)
                {
                    if (CanHavePointer && Depth == 0 && TempStack.Count == 0 && NewTokenList.Count == 0)
                    {
                        Pointer = true;
                    }

                    TempStack.Push(CurrentToken);

                    Depth++;
                }
                else if (CurrentToken.Type == TokenType.GroupRight)
                {
                    Depth--;

                    while (TempStack.Count != 0)
                    {
                        Token TempToken = TempStack.Pop();

                        if (TempToken.Type == TokenType.GroupLeft)
                        {
                            break;
                        }

                        NewTokenList.Add(TempToken);
                    }

                    if (CanHavePointer && Depth == 0 && CurrentToken.Type == TokenType.GroupRight && Pos + 1 != TokenList.Count)
                    {
                        Pointer = false;
                    }
                } 
                else if (CurrentToken.Type == TokenType.Opcode || CurrentToken.Type == TokenType.Command)
                {
                    TempStack.Push(CurrentToken);
                }
                else if (CurrentToken.Type == TokenType.Symbol && CurrentToken.CharacterType == CharacterType.Comma)
                {
                    NewTokenList.Add(CurrentToken);

                    while (TempStack.Count != 0)
                    {
                        Token TempToken = TempStack.Peek();

                        if (TempToken.Type == TokenType.GroupLeft || TempToken.Type == TokenType.Opcode || TempToken.Type == TokenType.Command)
                            break;

                        NewTokenList.Add(TempStack.Pop());
                    }
                }
                else if (CurrentToken.IsOperator())
                {
                    while (TempStack.Count != 0 && TempStack.Peek().IsOperator() && !TempStack.Peek().IsGroup())
                    {
                        int Op1 = 0;
                        int Op2 = 0;

                        Op1 = DataTables.PrecedenceMap[CurrentToken.Type];
                        Op2 = DataTables.PrecedenceMap[TempStack.Peek().Type];

                        if (CurrentToken.RightToLeft())
                        {
                            if (Op1 > Op2)
                            {
                                Token TempToken = TempStack.Pop();
                                NewTokenList.Add(TempToken);
                            }
                            else
                                break;
                        }
                        else
                        {
                            if (Op1 >= Op2)
                            {
                                Token TempToken = TempStack.Pop();
                                NewTokenList.Add(TempToken);
                            }
                            else
                                break;
                        }
                    }

                    TempStack.Push(CurrentToken);
                }
                else
                {
                    NewTokenList.Add(CurrentToken);
                }
            }

            while (TempStack.Count != 0 && TempStack.Peek().Type != TokenType.GroupLeft)
            {
                Token TempToken = TempStack.Pop();
                NewTokenList.Add(TempToken);
            }

            TokenList = NewTokenList;
            
            return true;
        }

        public bool Simplify(SymbolTable Symbols)
        {
            if (Type == ParameterType.Error)
                return false;
            
            //Token TempToken = null;

            Stack<Token> TempStack = new Stack<Token>();
            int Pos = 0;

            while (Pos < TokenList.Count)
            {
                Token Current = TokenList[Pos];
                Pos++;

                //if (Current.IsIndexWord() && Pointer == true)
                //{
                //    if (TempToken != null)
                //    {
                //        MessageLog.Log.Add("Parser", 0, 0, MessageCode.SyntaxError, "Can not have two Index's in the same memory refrence");
                //        return false;
                //    }

                //    TempToken = Current;
                //    Current = new Token();
                //    Current.Type = TokenType.Result;
                //    Current.NumericValue = 0;
                //}

                if (Current.IsOperator())
                {
                    if (Current.RightToLeft())
                    {
                        if (TempStack.Count < 1)
                        {
                            Message.Log.Add("Evaluator", Current.FileID, Current.Line, Current.Character, MessageCode.ValueMissing);
                            Type = ParameterType.Error;
                            return false;
                        }
                        
                        Token RHS = TempStack.Pop();

                        Token Result = ExecuteToken(RHS, Current, RHS);
                        if (Result.Type != TokenType.Number)
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
                        if (TempStack.Count < 2)
                        {
                            Message.Log.Add("Evaluator", Current.FileID, Current.Line, Current.Character, MessageCode.ValueMissing);
                            Type = ParameterType.Error;
                            return false;
                        }

                        Token RHS = TempStack.Pop();
                        Token LHS = TempStack.Pop();

                        Token Result = ExecuteToken(LHS, Current, RHS);
                        if (Result.Type != TokenType.Number)
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
                    TempStack.Push(ConvertToken(Current, Symbols));
                }
            }

            TokenList = TempStack.Reverse().ToList();

            //if (TempToken != null)
            //{
            //    TempToken.Type = TokenType.Displacment;
            //    TokenList.Insert(0, TempToken);

            //    //TempToken = new Token();
            //    //TempToken.Type = TokenType.Plus;
            //    //TokenList.Add(TempToken);                
            //}

            //if (TokenList[0].IsIndexWord() && TokenList.Last().IsOperator())
            //{
            //    Token Current = TokenList[0];
            //    Current.Type = TokenType.Displacment;
            //    TokenList.RemoveAt(0);
            //    TokenList.Insert(0, Current);
            //}

            SetTokenType();

            return TokenList.Count == 1;
        }

        Token ConvertToken(Token CurrentToken, SymbolTable Symbols)
        {
            if (CurrentToken.Type == TokenType.String)
            {
                if (CurrentToken.StringValue.Length <= 2)
                {
                    CurrentToken.Type = TokenType.Number;
                }
            }
            else if (CurrentToken.Type == TokenType.Identifier)
            {
                SymbolTableEntry Symbol = Symbols[CurrentToken.StringValue];

                if (Symbol.Type == SymbolType.None)
                {
                    // ERROR!
                    Message.Log.Add("Evaluator", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.UndefinedSymbol, CurrentToken.ToString());
                }
                else if (Symbol.State == SymbolState.Undefined || Symbol.State == SymbolState.ValuePending)
                {
                    // Value hasn't been defined yet, so we can't do any more to it.                    
                }
                else if (Symbol.Type == SymbolType.Value || Symbol.Type == SymbolType.Constant)
                {
                    CurrentToken.Type = TokenType.Number;

                    if (Symbol.Type == SymbolType.Constant || Symbol.Type == SymbolType.Value)
                    {
                        CurrentToken.NumericValue = ((ValueInformation)Symbol.Object).Value;
                    }

                    else
                        Message.Log.Add("Evaluator", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.UnknownError, "Unexpected symbol table type");

                }
            }

            return CurrentToken;
        }

        Token ExecuteToken(Token Op1, Token CurrentToken, Token Op2)
        {
            Token Result = new Token();
            Result.Type = TokenType.Unknown;
            //Result.Value = new List<char>();

            if (!CurrentToken.IsOperator())
                return Result;

            if (CurrentToken.RightToLeft())
            {
                if (Op2.Type != TokenType.Number)
                    return Result;
            }
            else
            {
                if (Op1.Type != TokenType.Number || Op2.Type != TokenType.Number)
                    return Result;
            }

            if (Op2.NumericValue == 0 && (CurrentToken.Type == TokenType.Division || CurrentToken.Type == TokenType.Remainder))
            {
                Message.Log.Add("Evaluator", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.DivisionByZero);
                Result.Type = TokenType.Error;
            }
            else
            {
                switch (CurrentToken.Type)
                {
                    case TokenType.UnarrayPlus:
                        Result.NumericValue = (short)+Op2.NumericValue;
                        break;

                    case TokenType.UnarrayMinus:
                        Result.NumericValue = (short)-Op2.NumericValue;
                        break;

                    case TokenType.BitwiseNot:
                        Result.NumericValue = (short)~Op2.NumericValue;
                        break;

                    case TokenType.High:
                        Result.NumericValue = (short)((Op2.NumericValue & 0xFF00) >> 8);
                        break;

                    case TokenType.Low:
                        Result.NumericValue = (short)(Op2.NumericValue & 0x00FF);
                        break;


                    case TokenType.Plus:
                        Result.NumericValue = (short)(Op1.NumericValue + Op2.NumericValue);
                        break;

                    case TokenType.Minus:
                        Result.NumericValue = (short)(Op1.NumericValue - Op2.NumericValue);
                        break;

                    case TokenType.Multiplication:
                        Result.NumericValue = (short)(Op1.NumericValue * Op2.NumericValue);
                        break;

                    case TokenType.Division:
                        Result.NumericValue = (short)(Op1.NumericValue / Op2.NumericValue);
                        break;

                    case TokenType.Remainder:
                        Result.NumericValue = (short)(Op1.NumericValue % Op2.NumericValue);
                        break;

                    case TokenType.BitwiseAnd:
                        Result.NumericValue = (short)(Op1.NumericValue & Op2.NumericValue);
                        break;

                    case TokenType.BitwiseXOR:
                        Result.NumericValue = (short)(Op1.NumericValue ^ Op2.NumericValue);
                        break;

                    case TokenType.BitwiseOR:
                        Result.NumericValue = (short)(Op1.NumericValue | Op2.NumericValue);
                        break;

                    case TokenType.LeftShift:
                        Result.NumericValue = (short)(Op1.NumericValue << Op2.NumericValue);
                        break;

                    case TokenType.RightShift:
                        Result.NumericValue = (short)(Op1.NumericValue >> Op2.NumericValue);
                        break;

                    case TokenType.LogicalNot:
                        Result.NumericValue = (Op2.NumericValue == 0) ? (short)1 : (short)0;
                        break;

                    case TokenType.LessThen:
                        Result.NumericValue = (Op1.NumericValue < Op2.NumericValue) ? (short)1 : (short)0;
                        break;

                    case TokenType.GreaterThen:
                        Result.NumericValue = (Op1.NumericValue > Op2.NumericValue) ? (short)1 : (short)0;
                        break;

                    case TokenType.LessEqual:
                        Result.NumericValue = (Op1.NumericValue <= Op2.NumericValue) ? (short)1 : (short)0;
                        break;

                    case TokenType.GreaterEqual:
                        Result.NumericValue = (Op1.NumericValue >= Op2.NumericValue) ? (short)1 : (short)0;
                        break;

                    case TokenType.Comparison:
                        Result.NumericValue = (Op1.NumericValue == Op2.NumericValue) ? (short)1 : (short)0;
                        break;

                    case TokenType.NotEqual:
                        Result.NumericValue = (Op1.NumericValue != Op2.NumericValue) ? (short)1 : (short)0;
                        break;

                    case TokenType.LogicalAnd:
                        Result.NumericValue = (Op1.NumericValue != 0 && Op2.NumericValue != 0) ? (short)1 : (short)0;
                        break;

                    case TokenType.LogicalOR:
                        Result.NumericValue = (Op1.NumericValue != 0 || Op2.NumericValue != 0) ? (short)1 : (short)0;
                        break;
                }

                Result.Type = TokenType.Number;
            }

            return Result;
        }

    }
}
