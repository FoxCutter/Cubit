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
        Tokenizer _Tokenizer;
        SymbolTable _SymbolTable;

        List<ObjectInformation> _ObjectData;
        int _CurrentAddress;

        public bool Parse(Stream InputStream)
        {
            StreamReader InputFile = new StreamReader(InputStream);

            _Tokenizer = new Tokenizer(InputStream);
            _SymbolTable = new SymbolTable();

            _ObjectData = new List<ObjectInformation>();
            _CurrentAddress = 0;

            // Preprossesor
            
            // Stage 1
            StageOne();

            // SymbolCheck();

            // Stage 2

            foreach (ObjectInformation Entry in _ObjectData)
            {
                //var Res = FindOpcode(Entry);

                if (Entry.Type >= ObjectType.Meta)
                    continue;
                
                Console.Write("{0:X4} ", Entry.Address);

                if (Entry.Type == ObjectType.Label)
                {
                    LabelInformation Label = (LabelInformation)Entry;
                    Console.Write("{0,-10} ", Label.Symbol.Name + ":");
                    //Console.Write("{0,-10} ", Entry.Symbol.DefinedLine.ToString());
                }
                else if (Entry.Type == ObjectType.Value)
                {
                    ValueInformation Value = (ValueInformation)Entry;
                    Console.Write("{0,-10} ", Value.Symbol.Name);
                }
                else
                {
                    Console.Write("           ");
                }

                if (Entry.Type == ObjectType.Value)
                {
                    ValueInformation Value = (ValueInformation)Entry;
                    Console.Write("EQU    ");
                    Console.Write(Value.Params.ToString());

                }
                else if (Entry.Type == ObjectType.Command)
                {
                    CommandInformation Command = (CommandInformation)Entry;

                    Console.Write("{0,-6} ", Command.Command.ToString());

                    for (int x = 0; x < Command.Params.Count; x++)
                    {
                        if (x != 0)
                            Console.Write(", ");

                        Console.Write(Command.ParamString(x));
                    }
                }
                else if (Entry.Type == ObjectType.Data)
                {
                    DataInformation Command = (DataInformation)Entry;

                    Console.Write("{0,-6} ", Command.DataType.ToString());

                    for (int x = 0; x < Command.Params.Count; x++)
                    {
                        if (x != 0)
                            Console.Write(", ");

                        Console.Write(Command.ParamString(x));
                    }
                }
                else if (Entry.Type == ObjectType.Opcode)
                {
                    OpcodeInformation Opcode = (OpcodeInformation)Entry;

                    Console.Write("{0,-6} ", Opcode.Opcode.ToString());

                    for (int x = 0; x < Opcode.Params.Count; x++)
                    {
                        if (x != 0)
                            Console.Write(", ");

                        Console.Write(Opcode.ParamString(x));
                    }
                }


                Console.WriteLine();
            } 
            
            return true;

        }

        void SymbolCheck()
        {
            // Flags any undefined symbols in symbol table
            var list = _SymbolTable.Where(e => e.Type == SymbolType.Unknown || e.Type == SymbolType.None);
            foreach (SymbolTableEntry Symbol in list)
            {
                //foreach (ObjectInformation Entry in Symbol.LineIDs)
                //{
                MessageLog.Log.Add("Parser", 0, 0, MessageCode.UndefinedSymbol, Symbol.Name);
                //}
            }
        }

        
        CommandID SelectCommandToMatch(ParameterInformation CurrentParam)
        {
            if (CurrentParam.Type == ParameterType.Encoded)
                return (CommandID)((int)CommandID.Encoded + CurrentParam.Value.NumericValue);
            else
                return CurrentParam.Value.CommandID;
        }

        OpcodeEncoding FindOpcode(ObjectInformation CurrentObject)
        {
            if (CurrentObject.Type != ObjectType.Opcode)
                return default(OpcodeEncoding);

            OpcodeInformation OpcodeObject = (OpcodeInformation)CurrentObject;

            // Search based on the Command ID
            IEnumerable<OpcodeEncoding> Opcodes = Ops.EncodingData[OpcodeObject.Opcode];

            if (Opcodes.Count() == 0)
            {
                // Error, invalid opcode
                return default(OpcodeEncoding);
            }

            if (OpcodeObject.Params.Count == 0)
            {
                Opcodes = Opcodes.Where(e => e.Param1Type == ParameterType.None && e.Param2Type == ParameterType.None);
            }

            if (OpcodeObject.Params.Count >= 1)
            {
                ParameterInformation CurrentParam = OpcodeObject.Params[0];
                {
                    Opcodes = Opcodes.Where(e => (e.Param1Type == CurrentParam.Type));
                }

                CommandID CurrentCommand = SelectCommandToMatch(CurrentParam);

                if (CurrentCommand != CommandID.None)
                    Opcodes = Opcodes.Where(e => e.Param1 == CurrentCommand);

                if (Opcodes.Count() == 0)
                {
                    MessageLog.Log.Add("Parser", 0, 0, MessageCode.InvalidParamaterForOpcode, string.Format("{0} >{1}<", OpcodeObject.Opcode.ToString(), OpcodeObject.ParamString(0)));

                    // Error, Parm1 is invalid
                    return default(OpcodeEncoding);
                }
            }

            if (OpcodeObject.Params.Count >= 2)
            {
                ParameterInformation CurrentParam = OpcodeObject.Params[1];
                {
                    Opcodes = Opcodes.Where(e => (e.Param2Type == CurrentParam.Type));
                }

                CommandID CurrentCommand = SelectCommandToMatch(CurrentParam);

                if (CurrentCommand != CommandID.None)
                    Opcodes = Opcodes.Where(e => e.Param2 == CurrentCommand);

                if (Opcodes.Count() == 0)
                {
                    MessageLog.Log.Add("Parser", 0, 0, MessageCode.InvalidParamaterForOpcode, string.Format("{0} {1}, >{2}<", OpcodeObject.Opcode.ToString(), OpcodeObject.ParamString(0), OpcodeObject.ParamString(1)));

                    // Error, Parm2 is invalid
                    return default(OpcodeEncoding);
                }
            }

            if (OpcodeObject.Params.Count >= 3)
            {
                ParameterInformation CurrentParam = OpcodeObject.Params[2];
                {
                    Opcodes = Opcodes.Where(e => (e.Param3Type == CurrentParam.Type));
                }

                CommandID CurrentCommand = SelectCommandToMatch(CurrentParam);

                if (CurrentCommand != CommandID.None)
                    Opcodes = Opcodes.Where(e => e.Param3 == CurrentCommand);

                if (Opcodes.Count() == 0)
                {
                    MessageLog.Log.Add("Parser", 0,0, MessageCode.InvalidParamaterForOpcode, string.Format("{0} {1}, {2}, >{3}<", OpcodeObject.Opcode.ToString(), OpcodeObject.ParamString(0), OpcodeObject.ParamString(1), OpcodeObject.ParamString(2)));

                    // Error, Parm2 is invalid
                    return default(OpcodeEncoding);
                }
            }

            if (Opcodes.Count() > 1)
            {
                return Opcodes.OrderBy(e => e.Encoding.Length).First();
            }
            else if (Opcodes.Count() == 1)
            {
                return Opcodes.FirstOrDefault();
            }
            else
            {
                return default(OpcodeEncoding);
            }
        }
        
        LabelInformation ParseLabel(Token LabelToken, bool AddressLabel)
        {
            SymbolTableEntry SymbolEntry = _SymbolTable[_Tokenizer.CurrentString];
            LabelInformation NewLabel = new LabelInformation(SymbolEntry);

            if (AddressLabel)
            {
                if (SymbolEntry.State != SymbolState.Undefined)
                {
                    MessageLog.Log.Add("Parser", 0,0, MessageCode.SyntaxError, string.Format("{0} redefined", SymbolEntry.Name));
                    NewLabel.Error = true;
                    return NewLabel;
                }

                SymbolEntry.Type = SymbolType.Address;
                SymbolEntry.DefinedLine = _Tokenizer.CurrentLine;

                NewLabel.Address = _CurrentAddress;
                SymbolEntry.Object = NewLabel;
                SymbolEntry.State = SymbolState.ValueSet;
            }

            SymbolEntry.LineIDs.Add(_Tokenizer.CurrentLine);

            // If the label has a colon, eat it.
            if (_Tokenizer.PeekNextTokenType() == TokenType.Colon)
                _Tokenizer.GetNextToken();

            return NewLabel;
        }

        ObjectInformation ParseAssignment(Token ValueToken, LabelInformation LabelObject)
        {
            ValueInformation NewValue = new ValueInformation(LabelObject.Symbol);
            NewValue.Symbol.LineIDs.Add(_Tokenizer.CurrentLine);
            NewValue.Symbol.Object = NewValue;

            // Read the paramters
            NewValue.Params = ParseParams(NewValue);

            if (NewValue.Symbol.State == SymbolState.Undefined)
            {
                // This is the first time this symbol has been referenced
                NewValue.Symbol.Type = ValueToken.CommandID == CommandID.CONST ? SymbolType.Value : SymbolType.Constant;
                NewValue.Symbol.DefinedLine = _Tokenizer.CurrentLine;
            }
            else
            {
                // Redefining the value                
                // We can't redefine a value created with EQU/=
                if (NewValue.Symbol.Type == SymbolType.Constant)
                {
                    MessageLog.Log.Add("Parser", 0, 0, MessageCode.SyntaxWarning, string.Format("Can't redefine the value of {0}", NewValue.Symbol.Name));
                    NewValue.Error = true;
                }
            }

            if (NewValue.Params.Count == 0)
            {
                NewValue.Error = true;
                MessageLog.Log.Add("Parser", 0, 0, MessageCode.ValueMissing, NewValue.Symbol.Name);
            }
            else
            {
                if (NewValue.Params.Simplify(_CurrentAddress))
                {
                    NewValue.Value = NewValue.Params.Value.NumericValue;
                    NewValue.Symbol.State = SymbolState.ValueSet;
                }
                else
                {
                    NewValue.Symbol.State = SymbolState.ValuePending;
                }
            }


            return NewValue;
        }

        ObjectInformation ParseOpcode(Token OpcodeToken)
        {
            OpcodeInformation Opcode = new OpcodeInformation(OpcodeToken.CommandID);
            Opcode.Address = _CurrentAddress;

            if (_Tokenizer.PeekNextTokenType() != TokenType.LineBreak && _Tokenizer.PeekNextTokenType() != TokenType.Comment && _Tokenizer.PeekNextTokenType() != TokenType.End)
            {
                while (true)
                {
                    ParameterInformation Params = ParseParams(Opcode);
                    Opcode.Params.Add(Params);

                    if (_Tokenizer.PeekNextTokenType() != TokenType.Comma)
                        break;
                    else
                        _Tokenizer.GetNextToken();                    
                }
            }

            if (OpcodeToken.AssumeA() && Opcode.Params.Count == 1)
            {
                ParameterInformation NewParam = new ParameterInformation();
                NewParam.Pointer = false;
                NewParam.Type = ParameterType.RegisterByte;

                Token NewToken = new Token();
                NewToken.CommandID = CommandID.A;
                NewToken.Type = TokenType.Register;
                NewToken.Symbol = null;

                NewParam.Add(NewToken);

                Opcode.Params.Add(NewParam);

                if (OpcodeToken.CommandID != CommandID.OUT)
                    Opcode.Params.Reverse();
            }

            foreach (ParameterInformation Param in Opcode.Params)
            {
                if (Opcode.Opcode == CommandID.IN || Opcode.Opcode == CommandID.OUT || Opcode.Opcode == CommandID.JP)
                    Param.Pointer = false;

                // Differentiate between the C Register and the Carry Flag
                if (OpcodeToken.CanHaveFlag() && Param.Value.IsRegister())
                {
                    if (Param.Value.CommandID == CommandID.C)
                    {
                        Token Temp = Param.Value;
                        Temp.CommandID = CommandID.CY;
                        Temp.Type = TokenType.Flag;

                        Param.Value = Temp;
                    }
                }

                Param.Simplify(_CurrentAddress);

                if (OpcodeToken.IsEncoded() && Param.Type == ParameterType.Immediate)
                    Param.Type = ParameterType.Encoded;
            }

            Opcode.Encoding = FindOpcode(Opcode);
            _CurrentAddress += Opcode.GetOpcodeLength();

            return Opcode;
        }

        ObjectInformation ParseCommand(Token CommandToken)
        {
            CommandInformation NewCommand = new CommandInformation(CommandToken.CommandID);
            NewCommand.Address = _CurrentAddress;

            if (_Tokenizer.PeekNextTokenType() != TokenType.LineBreak && _Tokenizer.PeekNextTokenType() != TokenType.Comment && _Tokenizer.PeekNextTokenType() != TokenType.End)
            {
                while (true)
                {
                    ParameterInformation Params = ParseParams(NewCommand);
                    NewCommand.Params.Add(Params);

                    if (_Tokenizer.PeekNextTokenType() != TokenType.Comma)
                        break;
                    else
                        _Tokenizer.GetNextToken();
                }
            }

            switch (NewCommand.Command)
            {
                case CommandID.i8080:
                    break;

                case CommandID.Z80:
                    break;

                case CommandID.ORG:
                    _CurrentAddress = NewCommand.Params[0].Value.NumericValue;
                    break;
            }

            return NewCommand; 
        }

        ObjectInformation ParseData(Token CommandToken)
        {
            DataInformation NewData = new DataInformation(CommandToken.CommandID);

            NewData.Address = _CurrentAddress;

            if (_Tokenizer.PeekNextTokenType() != TokenType.LineBreak && _Tokenizer.PeekNextTokenType() != TokenType.Comment && _Tokenizer.PeekNextTokenType() != TokenType.End)
            {
                while (true)
                {
                    ParameterInformation Params = ParseParams(NewData);
                    Params.Simplify(_CurrentAddress);
                    NewData.Params.Add(Params);

                    if (CommandToken.IsReserved() && Params.Value.Type != TokenType.Result)
                    {
                        MessageLog.Log.Add("Parser", 0, 0, MessageCode.UndefinedSymbol);
                    }

                    if (_Tokenizer.PeekNextTokenType() != TokenType.Comma)
                        break;
                    else
                        _Tokenizer.GetNextToken();
                }
            }

            _CurrentAddress += NewData.GetDataLength();

            return NewData;
        }
        
        ParameterInformation ParseParams(ObjectInformation CurrentObject)
        {
            ParameterInformation Ret = new ParameterInformation();
            Stack<Token> TempStack = new Stack<Token>();

            int Depth = 0;

            bool Done = false;
            while (!Done)
            {
                TokenType NextToken = _Tokenizer.PeekNextTokenType();                

                if (NextToken == TokenType.End)
                    Done = true;

                else if (NextToken == TokenType.Comment)
                    Done = true;

                else if (NextToken == TokenType.LineBreak || (NextToken == TokenType.Comma && Depth == 0))
                {
                    Done = true;
                }
                else
                {
                    Token CurrentToken = _Tokenizer.GetNextToken();

                    if (CurrentToken.Type == TokenType.Identifier)
                    {
                        CurrentToken.Symbol = _SymbolTable[_Tokenizer.CurrentString];
                        if (CurrentToken.Symbol.Type == SymbolType.None)
                        {
                            CurrentToken.Symbol.Type = SymbolType.Unknown;
                            CurrentToken.Symbol.State = SymbolState.Undefined;
                        }

                        CurrentToken.Symbol.LineIDs.Add(_Tokenizer.CurrentLine);
                    }

                    if (CurrentToken.IsGroupLeft())
                    {
                        if (Depth == 0 && CurrentToken.Type == TokenType.ParenthesesLeft && TempStack.Count == 0 && Ret.Count == 0)
                        {
                            Ret.Pointer = true;
                        }

                        TempStack.Push(CurrentToken);

                        Depth++;
                    }
                    else if (CurrentToken.IsGroupRight())
                    {
                        if (Depth == 0)
                        {
                            CurrentObject.Error = true;
                            if (CurrentToken.Type == TokenType.ParenthesesRight)
                                MessageLog.Log.Add("Parser", 0, 0, MessageCode.MissingGroupSymbol, "Opening (");

                            else
                                MessageLog.Log.Add("Parser", 0, 0, MessageCode.MissingGroupSymbol, "Opening [");
                        }

                        Depth--;

                        while (TempStack.Count != 0)
                        {
                            Token TempToken = TempStack.Pop();

                            if (TempToken.IsGroupLeft())
                            {
                                // Check for matching open/close groups
                                if (TempToken.Type == TokenType.BracketLeft && CurrentToken.Type != TokenType.BracketRight)
                                {
                                    CurrentObject.Error = true;
                                    MessageLog.Log.Add("Parser", 0, 0, MessageCode.MissingGroupSymbol, "] expected, found )");
                                }
                                else if (TempToken.Type == TokenType.ParenthesesLeft && CurrentToken.Type != TokenType.ParenthesesRight)
                                {
                                    CurrentObject.Error = true;
                                    MessageLog.Log.Add("Parser", 0, 0, MessageCode.MissingGroupSymbol, ") expected, found ]");
                                }


                                break;
                            }

                            Ret.Add(TempToken);
                        }

                        if (Depth == 0 && CurrentToken.Type == TokenType.ParenthesesRight && _Tokenizer.PeekNextTokenType() > TokenType.Operator)
                        {
                            Ret.Pointer = false;
                        }
                    }
                    else if (CurrentToken.IsOpcode() || CurrentToken.IsCommand())
                    {
                        TempStack.Push(CurrentToken);
                    }
                    else if (CurrentToken.Type == TokenType.Comma)
                    {
                        Ret.Add(CurrentToken);

                        while (TempStack.Count != 0)
                        {
                            Token TempToken = TempStack.Peek();

                            if (TempToken.IsGroupLeft() || TempToken.IsOpcode() || TempToken.IsCommand())
                                break;

                            Ret.Add(TempStack.Pop());
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
                                    Ret.Add(TempToken);
                                }
                                else
                                    break;
                            }
                            else
                            {
                                if (Op1 >= Op2)
                                {
                                    Token TempToken = TempStack.Pop();
                                    Ret.Add(TempToken);
                                }
                                else
                                    break;
                            }
                        }

                        TempStack.Push(CurrentToken);
                    }
                    else
                    {
                        Ret.Add(CurrentToken);
                    }
                }
            };


            while (TempStack.Count != 0 && !TempStack.Peek().IsGroupLeft())
            {
                Token TempToken = TempStack.Pop();
                Ret.Add(TempToken);
            }

            if (Depth > 0)
            {
                CurrentObject.Error = true;
                if (TempStack.Peek().Type == TokenType.ParenthesesLeft)
                    MessageLog.Log.Add("Parser", 0, 0, MessageCode.MissingGroupSymbol, ") expected");
                else
                    MessageLog.Log.Add("Parser", 0, 0, MessageCode.MissingGroupSymbol, "] expected");
            }

            return Ret;
        }
        
        bool StageOne()
        {
            bool Done = false;
            ObjectInformation CurrentObject = null;
            LabelInformation LabelObject = null;

            _ObjectData.Add(new LineInformation(_Tokenizer.CurrentLine + 1));

            while (!Done)
            {
                Token CurrentToken = _Tokenizer.GetNextToken();
                switch (CurrentToken.Type)
                {
                    case TokenType.End:
                        Done = true;
                        break;

                    // Ignore comments and line breaks.
                    case TokenType.Comment:
                    case TokenType.LineBreak:
                        CurrentObject = new LineInformation(_Tokenizer.CurrentLine + 1);
                        break;

                    case TokenType.Identifier:
                        {
                            if (_Tokenizer.PeekNextTokenType() == TokenType.Colon)
                            {
                                CurrentObject = ParseLabel(CurrentToken, true);
                            }
                            else if (_Tokenizer.PeekNextTokenType() == TokenType.Equal || _Tokenizer.PeekNextTokenType() == TokenType.Identifier)
                            {
                                LabelObject = ParseLabel(CurrentToken, false);
                            }
                            else
                            {
                                MessageLog.Log.Add("Parser", 0, 0, MessageCode.SyntaxError, string.Format("Unable to define label {0}, missing colon", _Tokenizer.CurrentString));
                                CurrentToken.Type = TokenType.Error;
                            }
                        }
                        break;

                    case TokenType.Opcode:
                        CurrentObject = ParseOpcode(CurrentToken);
                        break;

                    case TokenType.Equal:
                    case TokenType.Command:
                        {
                            if (CurrentToken.Type == TokenType.Equal || CurrentToken.CommandID == CommandID.EQU || CurrentToken.CommandID == CommandID.CONST)
                            {
                                if (LabelObject == null)
                                {
                                    MessageLog.Log.Add("Parser", 0, 0, MessageCode.SyntaxError, "Can't set a value without a label");
                                    CurrentToken.Type = TokenType.Error;
                                }
                                else
                                {
                                    CurrentObject = ParseAssignment(CurrentToken, LabelObject);
                                    LabelObject = null;
                                }
                            }
                            else
                            {
                                if (CurrentToken.IsData())
                                    CurrentObject = ParseData(CurrentToken);
                                else
                                    CurrentObject = ParseCommand(CurrentToken);
                            }
                        }

                        break;

                    case TokenType.Error:
                    default:
                        MessageLog.Log.Add("Parser", 0, 0, MessageCode.UnexpectedSymbol, CurrentToken.ToString());
                        CurrentToken.Type = TokenType.Error;
                        break;
                }


                // Resync if we have an error
                if (CurrentToken.Type == TokenType.Error)
                {
                    CurrentObject = null;
                    _Tokenizer.FlushLine();
                    _ObjectData.Add(new LineInformation(_Tokenizer.CurrentLine + 1));
                }
                else
                {
                    if (CurrentObject != null)
                    {
                        if (LabelObject != null)
                        {
                            MessageLog.Log.Add("Parser", 0,0, MessageCode.UnexpectedSymbol, LabelObject.Symbol.Name);
                            LabelObject = null;
                        }
                        _ObjectData.Add(CurrentObject);
                        if (CurrentObject.Error)
                            _Tokenizer.FlushLine();
                    }

                    CurrentObject = null;
                }
            };

            return true;
        }
    }
}
