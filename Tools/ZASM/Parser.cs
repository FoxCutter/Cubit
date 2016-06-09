using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZASM
{
    enum ParamType
    {
        RegisterByte,
        RegisterWord,
        RegisterPtr,
        IndexRegister,

        Immediate,
        ImmediatePtr,

        Encoded,

        //RegisterPtrByte,
        //RegisterPtrToWord,
        //ImmediatePtrToByte,
        //ImmediatePtrToWord,
        //IndexRegisterPtrToByte,
        //IndexRegisterPtrToWord,

        Conditional,
        Unknown,
        None,
    }

    
    class Parser
    {
       
        class ParamInformation
        {
            public Stack<Token> Tokens;
            public bool Address;
            public ParamType Type;

            public ParamInformation()
            {
                Tokens = new Stack<Token>();
                Address = false;
                Type = ParamType.Unknown;
            }
        }
        
        class LineInformation
        {
            public Token Label;
            public Token Operation;
            public List<ParamInformation> Params;

            public LineInformation()
            {
                Label = default(Token);
                Operation = default(Token);
                Params = new List<ParamInformation>();
            }
        };
        
        SymbolTable _SymbolTable;
        Tokenizer _Tokenizer;
        List<LineInformation> _LineData;

        public Parser()
        {
            _Tokenizer = null;
            _SymbolTable = new SymbolTable();
            _LineData = new List<LineInformation>();
        }

        public bool Parse(Stream InputStream)
        {
            _Tokenizer = new Tokenizer(InputStream);

            // Pull in the file, build up the symbol table (names only though) and just get everything tokenized
            PhaseOne();

            // Run though the parsed input, validating lables, setting data and the like
            PhaseTwo();
            
            //foreach (SymbolTableEntry Entry in _SymbolTable)
            //{
            //    if(Entry.DefinedLine == -1)                
            //        Console.WriteLine(" Symbol: {0} Line:", Entry.Symbol);
            //}
            foreach(LineInformation Entry in _LineData)
            {
                var Res = FindOpcode(Entry);

                if (Res.Function != CommandID.None)
                {
                    Console.Write("{0:X2} ", Res.Encoding[0]);
                }
                else
                {
                    Console.Write("   ");
                }

                if (!Entry.Label.IsEmpty())
                {
                    Console.Write("{0,-10} ", Entry.Label.ToString() + ":");
                }
                else
                {
                    Console.Write("           ");
                }

                if (!Entry.Operation.IsEmpty())
                {
                    Console.Write("{0,-6} ", Entry.Operation.ToString());
                }
                else
                {
                    Console.Write("       ");
                }

                for (int x = 0; x < Entry.Params.Count; x++)
                {
                    if (x != 0)
                        Console.Write(", ");

                    if (Entry.Params[x].Address)
                        Console.Write("@(");

                    Console.Write(PrintStack(Entry.Params[x].Tokens.ToList()));

                    //foreach (Token TokenEntry in Entry.Params[x])
                    //{
                    //    Console.Write("{0} ", TokenEntry);
                    //}

                    if (Entry.Params[x].Address)
                        Console.Write(")");

                    Console.Write(" [{0}]", Entry.Params[x].Type);
                }

                //Console.WriteLine(" Symbol: {0} Line:", Entry.Symbol);
                Console.WriteLine();
            }

            return true;
        }

        void ParseLabel(Token LableToken, SymbolType Type)
        {
            LineInformation NewLabel = new LineInformation();
            NewLabel.Label = LableToken;
            NewLabel.Label.Type = TokenType.Label;

            LableToken.Symbol = _SymbolTable[LableToken.ToString()];

            LableToken.Symbol.LineIDs.Add(LableToken.Line);
            LableToken.Symbol.DefinedLine = LableToken.Line;
            LableToken.Symbol.Type = Type;

            _LineData.Add(NewLabel);
        }

        ParamInformation ParseParams()
        {
            ParamInformation Ret = new ParamInformation();
            Stack<Token> TempStack = new Stack<Token>();
            int Depth = 0;

            bool Done = false;
            while (!Done)
            {
                Token CurrentToken = _Tokenizer.PeekNextToken();
                Token TempToken;

                if (CurrentToken.Type == TokenType.End)
                    Done = true;

                else if (CurrentToken.Type == TokenType.Comment)
                    Done = true;

                else if (CurrentToken.IsBreak() || (CurrentToken.Type == TokenType.Comma && Depth == 0))
                {
                    Done = true;
                }
                else
                {
                    CurrentToken = _Tokenizer.NextToken();

                    if (CurrentToken.Type == TokenType.Identifier)
                    {
                        CurrentToken.Symbol = _SymbolTable[CurrentToken.ToString()];
                        CurrentToken.Symbol.LineIDs.Add(CurrentToken.Line);
                    }

                    if (CurrentToken.IsGroupLeft())
                    {
                        if (Depth == 0 && CurrentToken.Type == TokenType.ParenthesesLeft)
                            Ret.Address = true;

                        TempStack.Push(CurrentToken);

                        Depth++;
                    }
                    else if (CurrentToken.IsGroupRight())
                    {
                        Depth--;

                        while (TempStack.Count != 0)
                        {
                            TempToken = TempStack.Pop();

                            if (TempToken.IsGroupLeft())
                                break;

                            Ret.Tokens.Push(TempToken);
                        }

                        if (Depth == 0 && CurrentToken.Type == TokenType.ParenthesesRight && _Tokenizer.PeekNextToken().IsOperator())
                            Ret.Address = false;
                    }
                    else if (CurrentToken.IsKeyword() || CurrentToken.IsCommand())
                    {
                        TempStack.Push(CurrentToken);
                    }
                    else if (CurrentToken.Type == TokenType.Comma)
                    {
                        Ret.Tokens.Push(CurrentToken);

                        while (TempStack.Count != 0)
                        {
                            TempToken = TempStack.Peek();

                            if (TempToken.IsGroupLeft() || TempToken.IsKeyword() || TempToken.IsCommand())
                                break;

                            Ret.Tokens.Push(TempStack.Pop());
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
                                    Ret.Tokens.Push(TempStack.Pop());
                                else
                                    break;
                            }
                            else
                            {
                                if (Op1 >= Op2)
                                    Ret.Tokens.Push(TempStack.Pop());
                                else
                                    break;
                            }
                        }

                        TempStack.Push(CurrentToken);
                    }
                    else
                    {
                        Ret.Tokens.Push(CurrentToken);
                    }
                }
            };

            while (TempStack.Count != 0)
                Ret.Tokens.Push(TempStack.Pop());

            return Ret;
        }
        
        void ParseKeyword(Token KeywordToken, string Label)
        {
            LineInformation Keyword = new LineInformation();
            
            Keyword.Operation = KeywordToken;

            if (!_Tokenizer.PeekNextToken().IsBreak() && _Tokenizer.PeekNextToken().Type != TokenType.Comment && !_Tokenizer.PeekNextToken().IsEnd())
            {
                bool Done = false;
                while (!Done)
                {
                    ParamInformation Params = ParseParams();
                    DecomposeParams(Params);

                    if (KeywordToken.CommandID == CommandID.IN || KeywordToken.CommandID == CommandID.OUT || KeywordToken.CommandID == CommandID.JP)
                        Params.Address = false;

                    TypeParams(Params);

                    if (KeywordToken.CanHaveFlag() && Params.Type == ParamType.RegisterByte)
                    {
                        Token Temp = Params.Tokens.Pop();
                        if(Temp.CommandID == CommandID.C)
                            Temp.CommandID = CommandID.CY;

                        Params.Tokens.Push(Temp);
                        Params.Type = ParamType.Conditional;
                    }
                    else if (KeywordToken.IsEncoded())
                    {
                        Params.Type = ParamType.Encoded;
                    }

                    Keyword.Params.Add(Params);

                    if (_Tokenizer.PeekNextToken().Type != TokenType.Comma)
                        Done = true;
                    else
                        _Tokenizer.NextToken();
                }

            }

            // If we have an equ statment, lets just assigned it now.
            if (KeywordToken.CommandID == CommandID.EQU && Keyword.Params.Count == 1)
            {
                if (_SymbolTable[Label].Type == SymbolType.Undefined)
                {
                    if (Keyword.Params[0].Tokens.Peek().Type == TokenType.Result || Keyword.Params[0].Tokens.Peek().Type == TokenType.Number)
                        _SymbolTable[Label].Value = Keyword.Params[0].Tokens.Peek().NumaricValue;

                    _SymbolTable[Label].Type = SymbolType.Constant;
                }
            }

            _LineData.Add(Keyword);
        }

        bool PhaseOne()
        {
            bool Done = false;
            string CurrentLabel = "";
            while (!Done)
            {                
                Token CurrentToken = _Tokenizer.NextToken();
                if (CurrentToken.Type == TokenType.End)
                    Done = true;

                else if (CurrentToken.Type == TokenType.Comment || CurrentToken.IsBreak())
                    continue;

                else if (CurrentToken.Type == TokenType.Identifier)
                {
                    if (_Tokenizer.PeekNextToken().Type == TokenType.Colon)
                    {
                        ParseLabel(CurrentToken, SymbolType.Address);
                        CurrentLabel = CurrentToken.ToString();
                    }
                    else if (_Tokenizer.PeekNextToken().Type == TokenType.Equal)
                    {
                        // Equal is treated the same as 'EQU' in this case
                        ParseLabel(CurrentToken, SymbolType.Undefined);
                        CurrentLabel = CurrentToken.ToString();
                    }
                    else if (_Tokenizer.PeekNextToken().Type == TokenType.Command)
                    {
                        // A few number of commands can make labels without using a :, they are marked by not having the . prefix
                        if(_Tokenizer.PeekNextToken().Value[0] != '.')
                            ParseLabel(CurrentToken, _Tokenizer.PeekNextToken().CommandID == CommandID.EQU ? SymbolType.Undefined : SymbolType.Address);
                        else
                            throw new ZASMException(CurrentToken.Line, CurrentToken.Character, "P04", "Can not define label");

                        CurrentLabel = CurrentToken.ToString();
                    }
                    else
                    {
                        // Macro
                        if (_SymbolTable[CurrentToken.ToString()].Type == SymbolType.Undefined)
                        {
                            throw new ZASMException(CurrentToken.Line, CurrentToken.Character, "P04", "Undefined Macro");
                        }
                    }
                }
                else if (CurrentToken.Type == TokenType.Equal)
                {
                    CurrentToken.Type = TokenType.Command;
                    CurrentToken.CommandID = CommandID.EQU;

                    ParseKeyword(CurrentToken, CurrentLabel);
                }
                else if (CurrentToken.Type == TokenType.Keyword)
                {
                    ParseKeyword(CurrentToken, CurrentLabel);
                }
                else if (CurrentToken.Type == TokenType.Command)
                {
                    ParseKeyword(CurrentToken, CurrentLabel);
                }
            }
            
            return false;
        }

        bool PhaseTwo()
        {
            //List<LineInformation> PhaseTwoB = new List<LineInformation>();

            //foreach (LineInformation Entry in _LineData)
            //{
            //    if (PhaseTwoLine(Entry))
            //        PhaseTwoB.Add(Entry);
            //}

            //foreach (LineInformation Entry in PhaseTwoB)
            //{
            //    // For 2B nothing should be postponed.
            //    if (PhaseTwoLine(Entry))
            //        return false;
            //}

            return true;
        }
        
        OpcodeEncoding FindOpcode(LineInformation CurrentLine)
        {
            if (CurrentLine.Operation.IsEmpty() || !CurrentLine.Operation.IsKeyword())
                return default(OpcodeEncoding);

            // Search based on the Command ID
            var Opcodes = Ops.EncodingData.Where(e => e.Function == CurrentLine.Operation.CommandID);
            

            if (CurrentLine.Params.Count == 0)
            {
                Opcodes = Opcodes.Where(e => e.Param1Type == ParamType.None && e.Param2Type == ParamType.None );
            }
            
            if (CurrentLine.Params.Count == 1)
            {
                Opcodes = Opcodes.Where(e => (e.Param1Type == CurrentLine.Params[0].Type && e.Param2Type == ParamType.None) | e.Flags.HasFlag(ParamFlags.AssumeA));

                if (Opcodes.FirstOrDefault().Flags.HasFlag(ParamFlags.AssumeA))
                {
                    ParamInformation Temp = new ParamInformation();
                    Temp.Address = false;
                    Temp.Type = ParamType.RegisterByte;
                    Token TempToken = CurrentLine.Params[0].Tokens.Peek();
                    TempToken.CommandID = CommandID.A;
                    TempToken.Symbol = null;
                    TempToken.Value = new List<char>();
                    TempToken.Value.Add('A');

                    Temp.Tokens.Push(TempToken);

                    CurrentLine.Params.Add(Temp);

                    if (CurrentLine.Operation.CommandID != CommandID.OUT)
                        CurrentLine.Params.Reverse();

                    return FindOpcode(CurrentLine);
                }


                switch (CurrentLine.Params[0].Type)
                {
                    case ParamType.Conditional:
                    case ParamType.RegisterByte:
                    case ParamType.RegisterWord:
                    case ParamType.RegisterPtr:
                        Opcodes = Opcodes.Where(e => e.Param1 == CurrentLine.Params[0].Tokens.Peek().CommandID);
                        break;

                    case ParamType.Encoded:
                        Opcodes = Opcodes.Where(e => e.Param1 == (CommandID)((int)CommandID.Encoded +  CurrentLine.Params[0].Tokens.Peek().NumaricValue));
                        break;

                    case ParamType.Immediate:
                    case ParamType.ImmediatePtr:
                    case ParamType.Unknown:
                        break;
                }
            }
            else if (CurrentLine.Params.Count == 2)
            {
                Opcodes = Opcodes.Where(e => e.Param1Type == CurrentLine.Params[0].Type && e.Param2Type == CurrentLine.Params[1].Type);

                switch (CurrentLine.Params[0].Type)
                {
                    case ParamType.Conditional:
                    case ParamType.RegisterByte:
                    case ParamType.RegisterWord:
                    case ParamType.RegisterPtr:
                        Opcodes = Opcodes.Where(e => e.Param1 == CurrentLine.Params[0].Tokens.Peek().CommandID);
                        break;

                    case ParamType.Immediate:
                    case ParamType.ImmediatePtr:
                    case ParamType.Unknown:
                        break;
                } 
                
                switch (CurrentLine.Params[1].Type)
                {
                    case ParamType.Conditional:
                    case ParamType.RegisterByte:
                    case ParamType.RegisterWord:
                    case ParamType.RegisterPtr:
                        Opcodes = Opcodes.Where(e => e.Param2 == CurrentLine.Params[1].Tokens.Peek().CommandID);
                        break;

                    case ParamType.Immediate:
                    case ParamType.ImmediatePtr:
                    case ParamType.Unknown:
                        break;
                }
            }

            if (Opcodes.Count() > 1)
                return Opcodes.FirstOrDefault();
            else if (Opcodes.Count() == 1)
                return Opcodes.FirstOrDefault();
            else
                return default(OpcodeEncoding);
        }
        
        bool DecomposeParams(ParamInformation Param)
        {
            if (Param.Tokens.Count == 0)
                return false;

            Token CurrentToken = Param.Tokens.Peek();
                        
            if (CurrentToken.IsOperator())
            {
                CurrentToken = Param.Tokens.Pop();
                Token Op1 = default(Token);
                Token Op2 = default(Token);

                if (CurrentToken.RightToLeft())
                {
                    if (DecomposeParams(Param))
                    {
                        Op1 = Param.Tokens.Pop();
                    }
                    else
                    {
                        // put the operator back on the stack.
                        Param.Tokens.Push(CurrentToken);
                        return false;
                    }
                }
                else
                {
                    if (DecomposeParams(Param))
                    {
                        Op2 = Param.Tokens.Pop();
                    }
                    else
                    {
                        // put the operator back on the stack.
                        Param.Tokens.Push(CurrentToken);
                        return false;
                    }

                    if (DecomposeParams(Param))
                    {
                        Op1 = Param.Tokens.Pop();
                    }
                    else
                    {
                        // put the operator back on the stack.
                        Param.Tokens.Push(Op2);
                        Param.Tokens.Push(CurrentToken);
                        return false;
                    } 
                }
                
   
                Token Result = default(Token);
                Result.Type = TokenType.Result;
                
                switch (CurrentToken.Type)
                {
                    case TokenType.UnarrayPlus:
                        Result.NumaricValue = +Op1.NumaricValue;
                        break;

                    case TokenType.UnarrayMinus:
                        Result.NumaricValue = -Op1.NumaricValue;
                        break;

                    case TokenType.BitwiseNot:
                        Result.NumaricValue = ~Op1.NumaricValue;
                        break;

                    case TokenType.High:
                        Result.NumaricValue = (Op1.NumaricValue & 0xFF00) >> 8;
                        break;

                    case TokenType.Low:
                        Result.NumaricValue = (Op1.NumaricValue & 0x00FF);
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
                        if(Op2.NumaricValue == 0)
                            throw new ZASMException("P00", "Division by zero");

                        Result.NumaricValue = Op1.NumaricValue / Op2.NumaricValue;
                        break;

                    case TokenType.Remainder:
                        if(Op2.NumaricValue == 0)
                            throw new ZASMException("P00", "Division by zero");

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
                        Result.NumaricValue = (Op1.NumaricValue == 0) ? 1 : 0;
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

                Param.Tokens.Push(Result);

            }
            else if (CurrentToken.IsString())
            {
                // Can't break a string down any further then that.
                if(CurrentToken.Value.Count - 2 > 2)
                    return false;

                Token Result = Param.Tokens.Pop();
                Result.Type = TokenType.Result;

                if (CurrentToken.Value.Count - 2 >= 1)
                {
                    Result.NumaricValue = CurrentToken.Value[1];
                }

                if (CurrentToken.Value.Count - 2 >= 2)
                {
                    Result.NumaricValue = Result.NumaricValue << 8;
                    Result.NumaricValue += CurrentToken.Value[2];
                }

                Param.Tokens.Push(Result);

                return true;
            }
            else if (CurrentToken.IsIdentifier())
            {
                SymbolTableEntry Symbol = _SymbolTable[CurrentToken.ToString()];
                if (Symbol.Type == SymbolType.None)
                {
                    // ERROR!
                    throw new ZASMException("P01", string.Format("Unknow Symbol {0}", CurrentToken.ToString()));
                }
                else if (Symbol.Type == SymbolType.Undefined)
                {
                    // Value hasn't been defined yet, so we can't do any more to it.
                    return false;
                }
                else if (Symbol.Type == SymbolType.Address)
                {
                    Token Result = Param.Tokens.Pop();
                    Result.Type = TokenType.Result;
                    Result.NumaricValue = (int)Symbol.Value;
                    Param.Tokens.Push(Result);

                    
                    return true;
                }
                else
                {
                    Token Result = Param.Tokens.Pop();
                    Result.Type = TokenType.Result;
                    Result.NumaricValue = (int)Symbol.Value;
                    Param.Tokens.Push(Result);

                }
            }
            else if (CurrentToken.Type == TokenType.Number)
            {
                Token Result = Param.Tokens.Pop();
                Result.Type = TokenType.Result;
                Param.Tokens.Push(Result);

            }

            return true;
        }

        bool TypeParams(ParamInformation Param)
        {
            Param.Type = ParamType.Unknown;

            if (Param.Tokens.Count == 0)
                return false;

            if (Param.Tokens.Count > 1 && Param.Address)
            {
                // Check to see if we're indexing
            }
            else
            {
                Token Value = Param.Tokens.Peek();

                if (Value.IsFlag())
                {
                    Param.Type = ParamType.Conditional;
                }
                else if (Value.IsRegister())
                {
                    if (Value.CommandID >= CommandID.Word)
                    {
                        if (Param.Address)
                        {
                            // We don't know the size of the data we are poiting to yet.
                            Param.Type = ParamType.RegisterPtr;
                        }
                        else
                        {
                            Param.Type = ParamType.RegisterWord;
                        }
                    }
                    else
                    {
                        // Byte Registers can't be pointers, so just ignore them
                        Param.Type = ParamType.RegisterByte;
                    }
                }
                else if (Value.IsIdentifier())
                {
                    if(Value.Symbol.Type == SymbolType.Constant) 
                        Param.Type = ParamType.Immediate;

                    else if (Param.Address)
                        Param.Type = ParamType.ImmediatePtr;

                    else 
                        Param.Type = ParamType.Immediate;
                }
                else if (Value.Type == TokenType.Number || Value.Type == TokenType.Result)
                {
                    if (Param.Address)
                        Param.Type = ParamType.ImmediatePtr;

                    else
                        Param.Type = ParamType.Immediate;
                }
                else if (Value.Type == TokenType.String)
                {
                    Param.Type = ParamType.Immediate;
                }

                //RegisterPtrToByte,
                //RegisterPtrToWord,

                //Immediate,      
                //ImmediateByte,            
                //ImmediateWord,

                //ImmediatePtr,
                //ImmediatePtrToByte,
                //ImmediatePtrToWord,

                //IndexRegister,
                //IndexRegisterPtrToByte,
                //IndexRegisterPtrToWord,
            }
            
            return true;

        }


        StringBuilder PrintStack(List<Token> Params, int Pos = 0)
        {
            StringBuilder Ret = new StringBuilder();
            if (Pos >= Params.Count)
                return Ret;

            Token CurrentToken = Params[Pos];

            if (CurrentToken.Type == TokenType.Colon)
            {
                Ret.Append(PrintStack(Params, Pos + 1));
                Ret.Append(":");
            }
            else if (CurrentToken.IsKeyword() || CurrentToken.IsCommand())
            {
                Ret.Append(CurrentToken.ToString());
                Ret.Append(" ");
                List<string> Results = new List<string>();


                while (Pos + 1 < Params.Count)
                {
                    if (Params[Pos + 1].Type != TokenType.Comma)
                    {
                        Results.Add(PrintStack(Params, Pos + 1).ToString());
                    }
                    else
                    {
                        Params.RemoveAt(Pos + 1);
                    }
                }

                Results.Reverse();

                bool First = true;
                foreach (string Param in Results)
                {
                    if (!First)
                        Ret.Append(", ");
                    Ret.Append(Param);

                    First = false;
                }
                
                
            }
            else if (CurrentToken.IsOperator())
            {
                if (CurrentToken.RightToLeft())
                {
                    Ret.Append(CurrentToken.ToString());
                    Ret.Append(PrintStack(Params, Pos + 1));
                }
                else
                {
                    StringBuilder Temp = PrintStack(Params, Pos + 1);
                    Ret.Append(PrintStack(Params, Pos + 1));
                    Ret.AppendFormat(" {0} ", CurrentToken.ToString());
                    Ret.Append(Temp);
                }
            }
            else
            {
                Ret.Append(CurrentToken.ToString());
            }


            Params.RemoveAt(Pos);
            return Ret;
        }
    }
}
