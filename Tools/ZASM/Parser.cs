using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZASM
{
    class Parser
    {
        enum ParseState
        {
            LabelOrCommand,     // Looking for a Label: or a keyword/macro name
            Command,            // Found a lable, so jsut need a command
            Params,             // Matching Params
            End,                // Nothing
        };

        class LineInformation
        {
            public Token Label;
            public Token Operation;
            public List<Stack<Token>> Params;
            public int AddressParam;

            public LineInformation()
            {
                Label = default(Token);
                Operation = default(Token);
                AddressParam = -1;
                Params = new List<Stack<Token>>();
            }
        };
        
        SymbolTable _SymbolTable;
        Tokenizer _Tokenizer;
        List<LineInformation> _LineData;

        public Parser(Stream InputStream)
        {
            _Tokenizer = new Tokenizer(InputStream);
            _SymbolTable = new SymbolTable();
            _LineData = new List<LineInformation>();
        }

        public bool Parse()
        {
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
                    Console.Write("{0:X} ", Res.Encoding[0]);
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

                    if (x == Entry.AddressParam)
                        Console.Write("(");

                    Console.Write(PrintStack(Entry.Params[x].ToList()));

                    //foreach (Token TokenEntry in Entry.Params[x])
                    //{
                    //    Console.Write("{0} ", TokenEntry);
                    //}

                    if (x == Entry.AddressParam)
                        Console.Write(")");
                }

                //Console.WriteLine(" Symbol: {0} Line:", Entry.Symbol);
                Console.WriteLine();
            }

            return true;
        }

        bool PhaseOne()
        {
            LineInformation CurrentLine = new LineInformation();

            bool Done = false;

            ParseState CurrentState = ParseState.LabelOrCommand;

            Token LastParamToken = default(Token);
            Stack<Token> Params = new Stack<Token>();
            Stack<Token> TempStack = new Stack<Token>();
            int Depth = 0;
            bool Memory = false;


            while (!Done)
            {
                Token CurrentToken = _Tokenizer.NextToken();
                Token TempToken;

                if (CurrentToken.Type == TokenType.End)
                    Done = true;

                if (CurrentToken.Type == TokenType.Comment)
                    continue;

                // Empty line
                if (CurrentToken.Type == TokenType.LineBreak && CurrentState == ParseState.LabelOrCommand)
                    continue;

                if (CurrentToken.Type == TokenType.Identifier)
                    _SymbolTable[CurrentToken.ToString()].LineIDs.Add(CurrentToken.Line);

                if (CurrentToken.IsBreak())
                    CurrentState = ParseState.End;

                switch (CurrentState)
                {
                    case ParseState.LabelOrCommand:
                        if (CurrentToken.IsKeyword() || CurrentToken.IsCommand())
                        {
                            CurrentLine.Operation = CurrentToken;
                            CurrentState = ParseState.Params;
                        }
                        else if (CurrentToken.IsIdentifier())
                        {
                            if (_Tokenizer.PeekNextToken().Type == TokenType.Colon)
                            {
                                _Tokenizer.NextToken();
                                CurrentToken.Type = TokenType.Label;

                                CurrentLine.Label = CurrentToken;
                                CurrentState = ParseState.Command;

                                _SymbolTable[CurrentLine.Label.ToString()].LineIDs.Add(CurrentLine.Label.Line);
                                _SymbolTable[CurrentLine.Label.ToString()].DefinedLine = CurrentLine.Label.Line;
                                _SymbolTable[CurrentLine.Label.ToString()].Type = SymbolType.Address;
                            }
                            else if (_Tokenizer.PeekNextToken().Type == TokenType.Equal)
                            {
                                // Treate '=' and same as 'equ'
                                CurrentToken.Type = TokenType.Label;
                                CurrentLine.Label = CurrentToken;
                                CurrentState = ParseState.Command;

                                _SymbolTable[CurrentLine.Label.ToString()].LineIDs.Add(CurrentLine.Label.Line);
                                _SymbolTable[CurrentLine.Label.ToString()].DefinedLine = CurrentLine.Label.Line;
                            }
                            else if (_Tokenizer.PeekNextToken().IsCommand() && _Tokenizer.PeekNextToken().Value[0] != '.')
                            {
                                // If a command can be used without a . prefix, it's assumed to be a label 
                                CurrentToken.Type = TokenType.Label;
                                CurrentLine.Label = CurrentToken;
                                CurrentState = ParseState.Command;

                                _SymbolTable[CurrentLine.Label.ToString()].LineIDs.Add(CurrentLine.Label.Line);
                                _SymbolTable[CurrentLine.Label.ToString()].DefinedLine = CurrentLine.Label.Line;
                            }
                            else
                            {
                                CurrentLine.Operation = CurrentToken;
                                CurrentState = ParseState.Params;
                            }
                        }
                        else
                        {
                            // ERROR:
                            CurrentState = ParseState.End;
                        }

                        break;

                    case ParseState.Command:
                        if (CurrentToken.IsKeyword() || CurrentToken.IsCommand())
                        {
                            CurrentLine.Operation = CurrentToken;
                            CurrentState = ParseState.Params;
                        }
                        else if (CurrentToken.IsIdentifier())
                        {
                            CurrentLine.Operation = CurrentToken;
                            CurrentState = ParseState.Params;
                        }
                        else if (CurrentToken.Type == TokenType.Equal)
                        {
                            CurrentLine.Operation = CurrentToken;
                            CurrentLine.Operation.Type = TokenType.Command;
                            CurrentLine.Operation.CommandID = CommandID.EQU;
                            CurrentState = ParseState.Params;
                        }
                        else
                        {
                            // ERROR:
                            CurrentState = ParseState.End;
                        }
                        break;

                    case ParseState.Params:
                        if (CurrentToken.Type == TokenType.Comma && Depth == 0)
                        {
                            if (Memory)
                                CurrentLine.AddressParam = CurrentLine.Params.Count;

                            while (TempStack.Count != 0)
                                Params.Push(TempStack.Pop());

                            CurrentLine.Params.Add(Params);

                            Params = new Stack<Token>();
                            LastParamToken.Type = TokenType.None;
                            Memory = false;

                        }
                        else if (CurrentToken.Type == TokenType.Address && LastParamToken.IsEmpty())
                        {
                            CurrentLine.AddressParam = CurrentLine.Params.Count;
                        }
                        else if (CurrentToken.IsGroupLeft())
                        {
                            if (CurrentToken.Type == TokenType.ParenthesesLeft && LastParamToken.IsEmpty())
                                Memory = true;

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

                                Params.Push(TempToken);
                            }

                            if (CurrentToken.Type == TokenType.ParenthesesRight && Depth == 0 && _Tokenizer.PeekNextToken().IsOperator())
                                Memory = false;

                        }
                        else if (CurrentToken.IsOperator())
                        {
                            // Check for an unarray + and -
                            if (CurrentToken.Type == TokenType.Plus && (LastParamToken.IsEmpty() || LastParamToken.IsOperator()))
                                CurrentToken.Type = TokenType.UnarrayPlus;

                            if (CurrentToken.Type == TokenType.Minus && (LastParamToken.IsEmpty() || LastParamToken.IsOperator()))
                                CurrentToken.Type = TokenType.UnarrayMinus;

                            if (TempStack.Count != 0 && !TempStack.Peek().IsGroup())
                            {
                                int Op1 = 0;
                                int Op2 = 0;

                                Op1 = DataTables.PrecedenceMap[CurrentToken.Type];
                                Op2 = DataTables.PrecedenceMap[TempStack.Peek().Type];

                                if (CurrentToken.RightToLeft())
                                {
                                    if (Op1 > Op2)
                                        Params.Push(TempStack.Pop());
                                }
                                else
                                {
                                    if (Op1 >= Op2)
                                        Params.Push(TempStack.Pop());
                                }
                            }

                            TempStack.Push(CurrentToken);
                            LastParamToken = CurrentToken;
                        }
                        else
                        {
                            Params.Push(CurrentToken);
                            LastParamToken = CurrentToken;
                        }

                        break;
                }

                if (CurrentToken.IsBreak())
                {
                    if (Memory)
                        CurrentLine.AddressParam = CurrentLine.Params.Count;

                    while (TempStack.Count != 0)
                        Params.Push(TempStack.Pop());

                    if (Params.Count != 0)
                        CurrentLine.Params.Add(Params);

                    PhaseOneProcessLine(CurrentLine);
                    _LineData.Add(CurrentLine);
                                                          
                    Params = new Stack<Token>();
                    CurrentState = ParseState.LabelOrCommand;

                    CurrentLine = new LineInformation();
                    LastParamToken.Type = TokenType.None;
                    Memory = false;

                    continue;
                }
            }

            return true;
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

        // Process a line and see if it can be resolved.
        bool PhaseOneProcessLine(LineInformation Entry)
        {
            for (int x = 0; x < Entry.Params.Count; x++)
                DecomposeParams(Entry.Params[x]);

            if (Entry.Label.IsLabel())
            {
                // At this point ever idetifier will be in the symbol table (or else we are in trouble)
                SymbolTableEntry Symbol = _SymbolTable[Entry.Label.ToString()];
                if (Symbol.DefinedLine == -1)
                {
                    // Error, referenceing an undefined symbol
                    return false;
                }
                else if (Symbol.DefinedLine < Entry.Label.Line)
                {
                    // Error, redefined label
                    return false;
                }
            }

            if (Entry.Operation.IsCommand())
            {
                switch (Entry.Operation.CommandID)
                {
                    case CommandID.END:
                        // Stop parsing the file
                        break;

                    case CommandID.i8080:
                        Console.WriteLine("ERROR: Line: {0}, Pos: {1}: .8080 command not supported", Entry.Operation.Line, Entry.Operation.Character);
                        // ERROR: Bail out 100%, we can't go on without knowing a thing.
                        break;

                    case CommandID.EQU:
                        if (Entry.Params.Count == 1)
                        {
                            // Not finalized
                            if (Entry.Params[0].Count != 1)
                                return false;

                            _SymbolTable[Entry.Label.ToString()].Value = Entry.Params[0].Peek().NumaricValue;
                            _SymbolTable[Entry.Label.ToString()].Type = SymbolType.Constant;
                        }
                        else
                        {
                            //Error;
                            return false;
                        }
                        break;
                }
                
                //return false;
            }
            else if (Entry.Operation.IsKeyword())
            {
                if (Entry.Params.Count >= 1 && Entry.Operation.CanHaveFlag())
                {
                    Token CurrentToken = Entry.Params[0].Peek();
                    if (CurrentToken.CommandID == CommandID.C)
                    {
                        CurrentToken = Entry.Params[0].Pop();

                        CurrentToken.CommandID = CommandID.CY;
                        CurrentToken.Type = TokenType.Flag;

                        Entry.Params[0].Push(CurrentToken);
                    }
                }

                if (Entry.Operation.CommandID == CommandID.IN || Entry.Operation.CommandID == CommandID.OUT || Entry.Operation.CommandID == CommandID.JP)
                    Entry.AddressParam = -1;
            }
            else if (Entry.Operation.IsIdentifier())
            {
                // Executing something user defined. 
                return false;
            }

            return false;
        }

        OpcodeEncoding FindOpcode(LineInformation CurrentLine)
        {
            if (CurrentLine.Operation.IsEmpty() || !CurrentLine.Operation.IsKeyword())
                return default(OpcodeEncoding);

            // Search based on the Command ID
            var Opcodes = Ops.EncodingData.Where(e => e.Function == CurrentLine.Operation.CommandID);

            // Filter based on Peramiters
            if (CurrentLine.Params.Count >= 1)
            {
                RegParam Param = RegParam.None;
                CommandID Reg = CommandID.None;

                if(CurrentLine.Params[0].Count != 1)
                    return default(OpcodeEncoding);

                Token Value = CurrentLine.Params[0].Peek();
                Reg = Value.CommandID;

                if (Value.IsRegister())
                {
                    if (Reg >= CommandID.Word)
                        Param |= RegParam.WordData;

                    else if (CurrentLine.AddressParam == 0)
                        CurrentLine.AddressParam = -1;
                }
                else if (Value.IsFlag())
                {
                    Param |= RegParam.ConditionCode;
                }
                else if (Value.Type == TokenType.Result)
                {
                    Reg = CommandID.Immediate;
                }
                else if (Value.Type == TokenType.Identifier)
                {
                    SymbolTableEntry Symbol = _SymbolTable[Value.ToString()];
                    if (Symbol.Type == SymbolType.Address)
                        Param |= RegParam.WordData;

                    else if (Symbol.Type == SymbolType.Address)
                        Param |= RegParam.WordData;

                    Reg = CommandID.Immediate;
                }

                if (CurrentLine.AddressParam == 0)
                {
                    Param |= RegParam.Reference;
                    
                    // Refrences are never to word data
                    Param &= ~RegParam.WordData;
                }

                Opcodes = Opcodes.Where(e => (e.Reg1Param & Param) == Param && e.Reg1 == Reg);
                Opcodes.Count();
            }
            else
            {
                Opcodes = Opcodes.Where(e => e.Reg1Param == RegParam.None && e.Reg1 == CommandID.None);
                
                return Opcodes.First();
            }
            
            return default(OpcodeEncoding);
        }

        bool DecomposeParams(Stack<Token> Params)
        {
            if (Params.Count == 0)
                return false;

            Token CurrentToken = Params.Peek();

            if (CurrentToken.IsOperator())
            {
                CurrentToken = Params.Pop();
                Token Op1 = default(Token);
                Token Op2 = default(Token);

                if (CurrentToken.RightToLeft())
                {
                    if (DecomposeParams(Params))
                    {
                        Op1 = Params.Pop();
                    }
                    else
                    {
                        // put the operator back on the stack.
                        Params.Push(CurrentToken);
                        return false;
                    }
                }
                else
                {
                    if (DecomposeParams(Params))
                    {
                        Op2 = Params.Pop();
                    }
                    else
                    {
                        // put the operator back on the stack.
                        Params.Push(CurrentToken);
                        return false;
                    }

                    if (DecomposeParams(Params))
                    {
                        Op1 = Params.Pop();
                    }
                    else
                    {
                        // put the operator back on the stack.
                        Params.Push(Op2);
                        Params.Push(CurrentToken);
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

                Params.Push(Result);

            }
            else if (CurrentToken.IsString())
            {
                // Can't break a string down any further then that.
                if(CurrentToken.Value.Count - 2 > 2)
                    return false;

                Token Result = Params.Pop();
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

                Params.Push(Result);

                return true;
            }
            else if (CurrentToken.IsIdentifier())
            {
                SymbolTableEntry Symbol = _SymbolTable[CurrentToken.ToString()];
                if (Symbol.Type == SymbolType.None)
                {
                    // ERROR!
                    return false;
                }
                else if (Symbol.Type == SymbolType.Undefined)
                {
                    // Value hasn't been defined yet, so we can't do any more to it.
                    return false;
                }
                else if (Symbol.Type == SymbolType.Address)
                {
                    Token Result = Params.Pop();
                    Result.Type = TokenType.Result;
                    Result.NumaricValue = (int)Symbol.Value;
                    Params.Push(Result);

                    return true;
                }
                else
                {
                    Token Result = Params.Pop();
                    Result.Type = TokenType.Result;
                    Result.NumaricValue = (int)Symbol.Value;
                    Params.Push(Result);
                }
            }


            return true;
        }

        StringBuilder PrintStack(List<Token> Params, int Pos = 0)
        {
            StringBuilder Ret = new StringBuilder();
            if (Pos >= Params.Count)
                return Ret;

            Token CurrentToken = Params[Pos];

            if (CurrentToken.IsOperator())
            {
                if (CurrentToken.Type == TokenType.UnarrayMinus || CurrentToken.Type == TokenType.UnarrayPlus)
                {
                    Ret.Append(CurrentToken.ToString());
                    Ret.Append(PrintStack(Params, Pos + 1));
                }
                else
                {
                    //StringBuilder Temp = PrintStack(Params, Pos + 1);
                    //Ret.AppendFormat("{0}", CurrentToken.ToString());
                    //Ret.Append("[");
                    //Ret.Append(PrintStack(Params, Pos + 1));
                    //Ret.Append(",");
                    //Ret.Append(Temp);
                    //Ret.Append("]");

                    
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
