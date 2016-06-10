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
        RegisterDisplacedPtr,

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
        Invalid,
        None,
    }


    class ParamInformation
    {
        public Stack<Token> Tokens;
        public bool Address;

        public ParamType Type;
        public Token Value;

        public ParamInformation()
        {
            Tokens = new Stack<Token>();
            Address = false;
            Type = ParamType.Unknown;
        }
    }

    class ObjectInformation
    {
        public Token Label;
        public Token Operation;
        public List<ParamInformation> Params;

        public ObjectInformation()
        {
            Label = default(Token);
            Operation = default(Token);
            Params = new List<ParamInformation>();
        }

        public override string ToString()
        {
            StringBuilder Ret = new StringBuilder();

            if (!Label.IsEmpty())
            {
                Ret.Append(LabelString());
                Ret.Append(" ");
            }

            if (!Operation.IsEmpty())
            {
                Ret.Append(CommandString());
                Ret.Append(" ");
            }

            for (int x = 0; x < Params.Count; x++)
            {
                if (x != 0)
                    Ret.Append(", ");

                Ret.Append(ParamString(x));
            }
            
            return Ret.ToString();
        }

        public string LabelString()
        {
            if (Label.Type == TokenType.None)
                return "";

            else
                return Label.ToString() + ":";
        }

        public string CommandString()
        {
            if (Operation.Type == TokenType.None)
                return "";

            else if (Operation.Type == TokenType.Identifier)
                return Operation.ToString();

            else
                return Operation.CommandID.ToString();
        }
        
        public string ParamString(int Index)
        {
            if (Params.Count <= Index)
                return "";

            ParamInformation Param = Params[Index];
            StringBuilder Ret = new StringBuilder();

            if (Param.Address)
                Ret.Append("(");

            Ret.Append(Parser.PrintStack(Param.Tokens.ToList()).ToString());
            
            if (Param.Address)
                Ret.Append(")");

            return Ret.ToString();            
        }

        public int DataSize()
        {
            foreach (ParamInformation Param in Params)
            {
                if (Param.Type == ParamType.RegisterByte)
                    return 8;

                if (Param.Type == ParamType.RegisterWord)
                    return 16;
            }

            return 0;
        }
    };

    class Parser
    {
        SymbolTable _SymbolTable;
        Tokenizer _Tokenizer;
        List<ObjectInformation> _ObjectData;

        public Parser()
        {
            _Tokenizer = null;
            _SymbolTable = new SymbolTable();
            _ObjectData = new List<ObjectInformation>();
        }

        public bool Parse(Stream InputStream)
        {
            _Tokenizer = new Tokenizer(InputStream);

            // Pull in the file, build up the symbol table (names only though) and just get everything tokenized
            PhaseOne();

            // Validate all the symbols we found were defined.
            SymbolCheck();
            
            // Run though the parsed input, validating lables, setting data and the like
            PhaseTwo();
            
            //foreach (SymbolTableEntry Entry in _SymbolTable)
            //{
            //    if(Entry.DefinedLine == -1)                
            //        Console.WriteLine(" Symbol: {0} Line:", Entry.Symbol);
            //}
            foreach(ObjectInformation Entry in _ObjectData)
            {
                var Res = FindOpcode(Entry);
                var SIze = SizeOpcode(Entry, Res);

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

        void SymbolCheck()
        {
            // Flags any undefined symbols in symbol table
            foreach (SymbolTableEntry Symbol in _SymbolTable.Where(e => e.Type == SymbolType.Undefined))
            {
                foreach (ObjectInformation Entry in Symbol.LineIDs)
                {
                    MessageLog.Log.Add("Parser", Entry.Operation, MessageCode.UnexpectedSymbol, Symbol.Symbol);
                }
            }
        }
        
        ObjectInformation ParseLabel(Token LableToken, SymbolType Type)
        {
            ObjectInformation NewLabel = new ObjectInformation();
            NewLabel.Label = LableToken;
            NewLabel.Label.Type = TokenType.Label;

            LableToken.Symbol = _SymbolTable[LableToken.ToString()];
           
            LableToken.Symbol.LineIDs.Add(NewLabel);
            LableToken.Symbol.DefinedLine = NewLabel;
            LableToken.Symbol.Type = Type;

            // If the label has a token, eat it.
            if (_Tokenizer.PeekNextToken().Type == TokenType.Colon)
                _Tokenizer.NextToken();

            return NewLabel;
        }

        ParamInformation ParseParams(ObjectInformation CurrentObject)
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
                        CurrentToken.Symbol.LineIDs.Add(CurrentObject);
                    }

                    if (CurrentToken.IsGroupLeft())
                    {
                        if (Depth == 0 && CurrentToken.Type == TokenType.ParenthesesLeft && TempStack.Count == 0 && Ret.Tokens.Count == 0)
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

        ObjectInformation ParseKeyword(Token KeywordToken, ObjectInformation CurrentObject)
        {
            ObjectInformation Keyword = CurrentObject;

            if (Keyword == null)
                Keyword = new ObjectInformation();
            
            Keyword.Operation = KeywordToken;

            if (!_Tokenizer.PeekNextToken().IsBreak() && _Tokenizer.PeekNextToken().Type != TokenType.Comment && !_Tokenizer.PeekNextToken().IsEnd())
            {
                bool Done = false;
                while (!Done)
                {
                    ParamInformation Params = ParseParams(Keyword);
                    Keyword.Params.Add(Params);

                    if (_Tokenizer.PeekNextToken().Type != TokenType.Comma)
                        Done = true;
                    else
                        _Tokenizer.NextToken();
                }

            }

            if (Keyword.Operation.AssumeA() && Keyword.Params.Count == 1)
            {
                ParamInformation NewParam = new ParamInformation();
                NewParam.Address = false;
                NewParam.Type = ParamType.None;

                Token NewToken = Keyword.Params[0].Tokens.Peek();
                NewToken.CommandID = CommandID.A;
                NewToken.Type = TokenType.Register;
                NewToken.Symbol = null;
                NewToken.Value = new List<char>();
                NewToken.Value.Add('A');

                NewParam.Tokens.Push(NewToken);

                Keyword.Params.Add(NewParam);

                if (Keyword.Operation.CommandID != CommandID.OUT)
                    Keyword.Params.Reverse();
            }

            foreach (ParamInformation Param in Keyword.Params)
            {
                if (Keyword.Operation.CommandID == CommandID.IN || Keyword.Operation.CommandID == CommandID.OUT || Keyword.Operation.CommandID == CommandID.JP)
                    Param.Address = false;

                DecomposeParams(Param);

                if (Keyword.Operation.CanHaveFlag() && Param.Value.IsRegister())
                {
                    Token Temp = Param.Tokens.Pop();
                    if (Temp.CommandID == CommandID.C)
                    {
                        Temp.CommandID = CommandID.CY;
                        Temp.Type = TokenType.Flag;
                    }

                    Param.Value = Temp;
                    Param.Tokens.Push(Temp);
                }

                TypeParams(Param);

                if (Keyword.Operation.IsEncoded() && Param.Type == ParamType.Immediate)
                    Param.Type = ParamType.Encoded;
            }
            return Keyword;
        }

        ObjectInformation ParseCommand(Token CommandToken, ObjectInformation CurrentObject)
        {
            ObjectInformation Command = CurrentObject;

            if (Command == null)
                Command = new ObjectInformation();

            Command.Operation = CommandToken;

            if (!_Tokenizer.PeekNextToken().IsBreak() && _Tokenizer.PeekNextToken().Type != TokenType.Comment && !_Tokenizer.PeekNextToken().IsEnd())
            {
                bool Done = false;
                while (!Done)
                {
                    ParamInformation Params = ParseParams(Command);

                    DecomposeParams(Params);
                    TypeParams(Params);

                    Command.Params.Add(Params);

                    if (_Tokenizer.PeekNextToken().Type != TokenType.Comma)
                        Done = true;
                    else
                        _Tokenizer.NextToken();
                }

            }

            // If we have an equ statment, lets just assigned it now.
            if (CommandToken.CommandID == CommandID.EQU && Command.Params.Count == 1 && !Command.Label.IsEmpty())
            {
                string Label = Command.Label.ToString();
                if (_SymbolTable[Label].Type == SymbolType.Undefined)
                {
                    if (Command.Params[0].Tokens.Peek().Type == TokenType.Result || Command.Params[0].Tokens.Peek().Type == TokenType.Number)
                        _SymbolTable[Label].Value = Command.Params[0].Tokens.Peek().NumaricValue;

                    _SymbolTable[Label].Type = SymbolType.Constant;
                }
            }

            return Command;
        }
        
        bool PhaseOne()
        {
            bool Done = false;
            ObjectInformation CurrentObject = null;
            while (!Done)
            {                
                Token CurrentToken = _Tokenizer.NextToken();

                if (CurrentToken.Type == TokenType.End)
                    Done = true;

                else if (CurrentToken.Type == TokenType.Comment)
                    continue;
                
                else if (CurrentToken.IsBreak())
                {
                    if(CurrentObject != null)
                        _ObjectData.Add(CurrentObject);

                    CurrentObject = null;
                }

                else if (CurrentToken.Type == TokenType.Identifier)
                {
                    if (_Tokenizer.PeekNextToken().Type == TokenType.Colon)
                    {
                        CurrentObject = ParseLabel(CurrentToken, SymbolType.Address);
                    }
                    else if (_Tokenizer.PeekNextToken().Type == TokenType.Equal)
                    {
                        // Equal is treated the same as 'EQU' in this case
                        CurrentObject = ParseLabel(CurrentToken, SymbolType.Undefined);
                    }
                    else if (_Tokenizer.PeekNextToken().Type == TokenType.Command)
                    {
                        // A few number of commands can make labels without using a :, they are marked by not having the . prefix
                        if (_Tokenizer.PeekNextToken().Value[0] != '.')
                        {
                            CurrentObject = ParseLabel(CurrentToken, _Tokenizer.PeekNextToken().CommandID == CommandID.EQU ? SymbolType.Undefined : SymbolType.Address);
                        }
                        else
                        {
                            MessageLog.Log.Add("Parser", CurrentToken, MessageCode.UnknownError, CurrentToken.ToString());
                            CurrentToken.Type = TokenType.Error;
                        }
                    }
                    else
                    {
                        // Macro
                        if (_SymbolTable[CurrentToken.ToString()].Type == SymbolType.Undefined)
                        {
                            MessageLog.Log.Add("Parser", CurrentToken, MessageCode.UnknownError, CurrentToken.ToString());
                            CurrentToken.Type = TokenType.Error;
                        }
                    }
                }
                else if (CurrentToken.Type == TokenType.Equal)
                {
                    CurrentToken.Type = TokenType.Command;
                    CurrentToken.CommandID = CommandID.EQU;

                    CurrentObject = ParseKeyword(CurrentToken, CurrentObject);
                }
                else if (CurrentToken.Type == TokenType.Keyword)
                {
                    CurrentObject = ParseKeyword(CurrentToken, CurrentObject);
                }
                else if (CurrentToken.Type == TokenType.Command)
                {
                    CurrentObject = ParseCommand(CurrentToken, CurrentObject);
                }
                else
                {
                    MessageLog.Log.Add("Parser", CurrentToken, MessageCode.UnexpectedSymbol, CurrentToken.ToString());                                        
                    CurrentToken.Type = TokenType.Error;
                }

                // Resync if we have an error
                if (CurrentToken.Type == TokenType.Error)
                {
                    CurrentObject = null;
                    _Tokenizer.FlushLine();
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

        ParamType SelectTypeToMatch(ParamInformation CurrentParam)
        {
            if (CurrentParam.Type == ParamType.RegisterDisplacedPtr)
                return ParamType.RegisterPtr;

            return CurrentParam.Type;
        }

        CommandID SelectCommandToMatch(ParamInformation CurrentParam)
        {
            switch (CurrentParam.Type)
            {
                case ParamType.Conditional:
                case ParamType.RegisterPtr:
                    break;

                case ParamType.RegisterWord:
                    if (CurrentParam.Value.IsIndexWord())
                        return CommandID.HL;
                    break;

                case ParamType.RegisterByte:
                    if (CurrentParam.Value.IsIndexHigh())
                        return CommandID.H;

                    else if (CurrentParam.Value.IsIndexLow())
                        return CommandID.L;

                    break;

                case ParamType.Encoded:
                    return (CommandID)((int)CommandID.Encoded + CurrentParam.Value.NumaricValue);

                case ParamType.Immediate:
                case ParamType.ImmediatePtr:
                    return CommandID.None;
            }

            return CurrentParam.Value.CommandID;
        }

        int SizeOpcode(ObjectInformation CurrentObject, OpcodeEncoding Encoding)
        {
            if (Encoding.Encoding == null || Encoding.Encoding.Length == 0)
                return 0;

            int Ret = Encoding.Encoding.Length;

            foreach (ParamInformation Param in CurrentObject.Params)
            {
                switch (Param.Type)
                {
                    case ParamType.Immediate:
                        if(CurrentObject.Operation.HasAddress())
                            Ret += 2;

                        else if(CurrentObject.Operation.HasReletiveAddress())
                            Ret += 1;

                        else
                            Ret += CurrentObject.DataSize() / 8;
                        break;

                    case ParamType.ImmediatePtr:
                        // Add the address
                        Ret += 2;
                        break;

                    case ParamType.RegisterDisplacedPtr:
                        // Add two bytes, one for the prefix, the other for displacment
                        Ret += 2;
                        break;

                    case ParamType.RegisterByte:
                        // Add the prefix bites
                        if (Param.Value.IsIndexHigh())
                            Ret++;

                        else if (Param.Value.IsIndexLow())
                            Ret++;

                        break;
                }
            }
            
            return Ret;
        }
        
        OpcodeEncoding FindOpcode(ObjectInformation CurrentObject)
        {
            if (CurrentObject.Operation.IsEmpty() || !CurrentObject.Operation.IsKeyword())
                return default(OpcodeEncoding);

            // Search based on the Command ID
            IEnumerable<OpcodeEncoding> Opcodes = Ops.EncodingData.Where(e => e.Function == CurrentObject.Operation.CommandID);

            if (Opcodes.Count() == 0)
            {
                // Error, invalid opcode
                return default(OpcodeEncoding);
            }

            if (CurrentObject.Params.Count == 0)
            {
                Opcodes = Opcodes.Where(e => e.Param1Type == ParamType.None && e.Param2Type == ParamType.None);
            }
            
            if(CurrentObject.Params.Count >= 1)
            {
                ParamInformation CurrentParam = CurrentObject.Params[0];
                {
                    ParamType Type = SelectTypeToMatch(CurrentParam);
                    Opcodes = Opcodes.Where(e => (e.Param1Type == Type));
                }

                CommandID CurrentCommand = SelectCommandToMatch(CurrentParam);

                if (CurrentCommand != CommandID.None)
                    Opcodes = Opcodes.Where(e => e.Param1 == CurrentCommand);

                if (Opcodes.Count() == 0)
                {
                    MessageLog.Log.Add("Parser", CurrentParam.Value, MessageCode.InvalidParamaterForOpcode, string.Format("{0} >{1}<", CurrentObject.CommandString(), CurrentObject.ParamString(0)));

                    // Error, Parm1 is invalid
                    return default(OpcodeEncoding);
                }            
            }

            if (CurrentObject.Params.Count >= 2)
            {
                ParamInformation CurrentParam = CurrentObject.Params[1];
                {
                    ParamType Type = SelectTypeToMatch(CurrentParam);
                    Opcodes = Opcodes.Where(e => (e.Param2Type == Type));
                }

                CommandID CurrentCommand = SelectCommandToMatch(CurrentParam);

                if (CurrentCommand != CommandID.None)
                    Opcodes = Opcodes.Where(e => e.Param2 == CurrentCommand);

                if (Opcodes.Count() == 0)
                {
                    MessageLog.Log.Add("Parser", CurrentParam.Value, MessageCode.InvalidParamaterForOpcode, string.Format("{0} {1}, >{2}<", CurrentObject.CommandString(), CurrentObject.ParamString(0), CurrentObject.ParamString(1)));
                    
                    // Error, Parm2 is invalid
                    return default(OpcodeEncoding);
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
                return true;

            if (!DecomposeParam(Param))
                return false;

            if (Param.Tokens.Count == 1)
            {
                Param.Value = Param.Tokens.Peek();
                return true;
            }
            else if (!Param.Tokens.Peek().IsOperator())
            {
                // There should be a single token, a displaced index or an error
                if (Param.Tokens.Count == 2)
                {
                    Token Op2 = Param.Tokens.Pop();
                    Token Op1 = Param.Tokens.Pop();

                    if (Op1.IsIndexWord() && Param.Address)
                    {
                        Op2.Type = TokenType.Displacment;
                        Op2.CommandID = Op1.CommandID;
                        Param.Tokens.Push(Op2);
                        Param.Value = Param.Tokens.Peek();

                        return true;
                    }
                    else
                    {
                        // ERROR;
                        Param.Tokens.Push(Op1);
                        Param.Tokens.Push(Op2);
                    }
                }
            }

            return false;
        }

        bool DecomposeParam(ParamInformation Param)
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
                    if (DecomposeParam(Param))
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
                    if (DecomposeParam(Param))
                    {
                        Op2 = Param.Tokens.Pop();
                    }
                    else
                    {
                        // put the operator back on the stack.
                        Param.Tokens.Push(CurrentToken);
                        return false;
                    }

                    if (DecomposeParam(Param))
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


                Token Result = CurrentToken;
                Result.Value = new List<char>();
                Result.Type = TokenType.Result;

                if (Op2.NumaricValue == 0 && (CurrentToken.Type == TokenType.Division || CurrentToken.Type == TokenType.Remainder))
                {
                    MessageLog.Log.Add("Parser", CurrentToken, MessageCode.DivisionByZero);
                }
                else switch (CurrentToken.Type)
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
                    MessageLog.Log.Add("Parser", CurrentToken, MessageCode.UndefinedSymbol, CurrentToken.ToString());
                    return false;
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

        ParamType TypeToken(Token CurrentToken, bool Address)
        {
            if (CurrentToken.IsDisplacment())
            {
                return ParamType.RegisterDisplacedPtr;
            }
            else if (CurrentToken.IsFlag())
            {
                return ParamType.Conditional;
            }
            else if (CurrentToken.IsRegister())
            {
                if (CurrentToken.CommandID >= CommandID.Word)
                {
                    if (Address)
                    {
                        return ParamType.RegisterPtr;
                    }
                    else
                    {
                        return ParamType.RegisterWord;
                    }
                }
                else
                {
                    if (Address)
                    {
                        // Byte Registers can't be pointers, so thrown an error
                        return ParamType.Invalid;
                    }
                    else
                    {
                        return ParamType.RegisterByte;
                    }
                }
            }
            else if (CurrentToken.IsOperator() || CurrentToken.IsKeyword() || CurrentToken.IsCommand())
            {
                return ParamType.None;
            }
            else
            {
                if (Address)
                    return ParamType.ImmediatePtr;

                else
                    return ParamType.Immediate;
            }
        }
        
        bool TypeParams(ParamInformation Param)
        {
            Param.Type = ParamType.Unknown;

            if (Param.Tokens.Count == 0)
                return false;

            if (Param.Tokens.Count == 1)
            {
                Param.Type = TypeToken(Param.Tokens.Peek(), Param.Address);
            }
            else
            {               
                if (Param.Address)
                    Param.Type = ParamType.ImmediatePtr;
                else
                    Param.Type = ParamType.Immediate;
            }
            
            return true;

        }

        static public StringBuilder PrintStack(List<Token> Params, int Pos = 0)
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
