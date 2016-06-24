﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZASM
{
    class Parser
    {
        SymbolTable _SymbolTable;
        Tokenizer _Tokenizer;
        OutputSection _Output;

        List<ObjectInformation> _ObjectData;
        int _CurrentAddress;

        public Parser()
        {
            _Tokenizer = null;
            _SymbolTable = new SymbolTable();
            _Output = new OutputSection();

            _ObjectData = new List<ObjectInformation>();

            _CurrentAddress = 0;
        }

        public bool Parse(Stream InputStream)
        {
            StreamReader InputFile = new StreamReader(InputStream);

            _Tokenizer = new Tokenizer(InputStream);

            // Pull in the file, build up the symbol table (names only though) and just get everything tokenized
            PhaseOne();

            // Validate all the symbols we found were defined.
            SymbolCheck();
            
            // Resolve anything that needs to be resolved
            PhaseTwo();
            
            //foreach (SymbolTableEntry Entry in _SymbolTable)
            //{
            //    if(Entry.DefinedLine == -1)                
            //        Console.WriteLine(" Symbol: {0} Line:", Entry.Symbol);
            //}
            foreach(ObjectInformation Entry in _ObjectData)
            {
                //var Res = FindOpcode(Entry);

                if (Entry.Type == ObjectType.Label)
                {
                    //Console.Write("{0,-10} ", Entry.Symbol.Symbol + ":");
                    Console.Write("{0,-10} ", Entry.Symbol.DefinedLine.ToString());
                }
                else if (Entry.Type == ObjectType.Value)
                {
                    Console.Write("{0,-10} ", Entry.Symbol.Symbol);
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

            var output = System.IO.File.OpenWrite(@"D:\Test\DCP\Other\Cubit\Tools\testout.bin");
            _Output.SaveData(output);

            output.Close();

            return true;
        }

        void SymbolCheck()
        {
            // Flags any undefined symbols in symbol table
            var list = _SymbolTable.Where(e => e.Type == SymbolType.Undefined);
            foreach (SymbolTableEntry Symbol in list)
            {
                foreach (ObjectInformation Entry in Symbol.LineIDs)
                {
                    MessageLog.Log.Add("Parser", Entry.Location, MessageCode.UndefinedSymbol, Symbol.Symbol);
                }
            }
        }
        
        ObjectInformation ParseLabel(Token LableToken)
        {
            SymbolTableEntry Symbol = _SymbolTable[LableToken.ToString()];           
            LabelInformation NewLabel = new LabelInformation(Symbol, LableToken.Location);

            if (Symbol.Type == SymbolType.Undefined)
            {
                Symbol.DefinedLine = NewLabel;
                Symbol.Type = SymbolType.Address;
            }
            else
            {
                MessageLog.Log.Add("Parser", LableToken.Location, MessageCode.SyntaxError, string.Format("{0} redefined", Symbol.Symbol));
            }

            NewLabel.Address = _CurrentAddress;

            Symbol.LineIDs.Add(NewLabel);

            // If the label has a token, eat it.
            if (_Tokenizer.PeekNextToken().Type == TokenType.Colon)
                _Tokenizer.NextToken();

            return NewLabel;
        }

        ParameterInformation ParseParams(ObjectInformation CurrentObject)
        {
            ParameterInformation Ret = new ParameterInformation();
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
                            if(CurrentToken.Type == TokenType.ParenthesesRight)
                                MessageLog.Log.Add("Parser", CurrentObject.Location, MessageCode.MissingGroupSymbol, "Opening (");

                            else
                                MessageLog.Log.Add("Parser", CurrentObject.Location, MessageCode.MissingGroupSymbol, "Opening [");
                        }
                        
                        Depth--;

                        while (TempStack.Count != 0)
                        {
                            TempToken = TempStack.Pop();

                            if (TempToken.IsGroupLeft())
                            {
                                // Check for matching open/close groups
                                if (TempToken.Type == TokenType.BracketLeft && CurrentToken.Type != TokenType.BracketRight)
                                {
                                    CurrentObject.Error = true;
                                    MessageLog.Log.Add("Parser", CurrentObject.Location, MessageCode.MissingGroupSymbol, "] expected, found )");
                                }
                                else if (TempToken.Type == TokenType.ParenthesesLeft && CurrentToken.Type != TokenType.ParenthesesRight)
                                {
                                    CurrentObject.Error = true;
                                    MessageLog.Log.Add("Parser", CurrentObject.Location, MessageCode.MissingGroupSymbol, ") expected, found ]");
                                }


                                break;
                            }

                            Ret.Add(TempToken);
                        }

                        if (Depth == 0 && CurrentToken.Type == TokenType.ParenthesesRight && _Tokenizer.PeekNextToken().IsOperator())
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
                            TempToken = TempStack.Peek();

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
                                    TempToken = TempStack.Pop();
                                    Ret.Add(TempToken);
                                }
                                else
                                    break;
                            }
                            else
                            {
                                if (Op1 >= Op2)
                                {
                                    TempToken = TempStack.Pop();
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
                if(TempStack.Peek().Type == TokenType.ParenthesesLeft)
                    MessageLog.Log.Add("Parser", CurrentObject.Location, MessageCode.MissingGroupSymbol, ") expected");
                else
                    MessageLog.Log.Add("Parser", CurrentObject.Location, MessageCode.MissingGroupSymbol, "] expected");
            }

            return Ret;
        }

        ObjectInformation ParseOpcode(Token OpcodeToken)
        {
            OpcodeInformation Opcode = new OpcodeInformation(OpcodeToken.CommandID, OpcodeToken.Location);
            Opcode.Address = _CurrentAddress;

            if (!_Tokenizer.PeekNextToken().IsBreak() && _Tokenizer.PeekNextToken().Type != TokenType.Comment && !_Tokenizer.PeekNextToken().IsEnd())
            {
                bool Done = false;
                while (!Done)
                {
                    ParameterInformation Params = ParseParams(Opcode);
                    Opcode.Params.Add(Params);

                    if (_Tokenizer.PeekNextToken().Type != TokenType.Comma)
                        Done = true;
                    else
                        _Tokenizer.NextToken();
                }
            }

            if (OpcodeToken.AssumeA() && Opcode.Params.Count == 1)
            {
                ParameterInformation NewParam = new ParameterInformation();
                NewParam.Pointer = false;
                NewParam.Type = ParameterType.RegisterByte;

                Token NewToken = default(Token);
                NewToken.CommandID = CommandID.A;
                NewToken.Type = TokenType.Register;
                NewToken.Symbol = null;
                NewToken.Value = new List<char>();
                NewToken.Value.Add('A');
                NewToken.Location = Opcode.Location;

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

                Param.Simplify();

                if (OpcodeToken.IsEncoded() && Param.Type == ParameterType.Immediate)
                    Param.Type = ParameterType.Encoded;
            }

            Opcode.Encoding = FindOpcode(Opcode);
            //Opcode.Length = Opcode.GetOpcodeLength();
            _CurrentAddress += Opcode.GetOpcodeLength();

            return Opcode;
        }

        ObjectInformation ParseCommand(Token CommandToken)
        {
            CommandInformation NewCommand = new CommandInformation(CommandToken.CommandID, CommandToken.Location);

            if (!_Tokenizer.PeekNextToken().IsBreak() && _Tokenizer.PeekNextToken().Type != TokenType.Comment)
            {
                bool Done = false;
                while (!Done)
                {
                    ParameterInformation Params = ParseParams(NewCommand);
                    Params.Simplify();

                    NewCommand.Params.Add(Params);

                    if (_Tokenizer.PeekNextToken().Type != TokenType.Comma)
                        Done = true;
                    else
                        _Tokenizer.NextToken();
                }
            }

            switch (NewCommand.Command)
            {
                case CommandID.i8080:
                    break;

                case CommandID.Z80:
                    break;

                case CommandID.ORG:
                    _CurrentAddress = NewCommand.Params[0].Value.NumaricValue;
                    break;
            }

            return NewCommand;
        }

        ObjectInformation ParseData(Token CommandToken)
        {
            DataInformation NewData = new DataInformation(CommandToken.CommandID, CommandToken.Location);

            NewData.Address = _CurrentAddress;

            if (!_Tokenizer.PeekNextToken().IsBreak() && _Tokenizer.PeekNextToken().Type != TokenType.Comment)
            {
                bool Done = false;
                while (!Done)
                {
                    ParameterInformation Params = ParseParams(NewData);
                    Params.Simplify();

                    NewData.Params.Add(Params);

                    if (_Tokenizer.PeekNextToken().Type != TokenType.Comma)
                        Done = true;
                    else
                        _Tokenizer.NextToken();
                }
            }

            _CurrentAddress += NewData.GetDataLength();
            //NewData.Length = NewData.GetDataLength();
            //_CurrentAddress += NewData.Length;

            return NewData;
        }
        
       
        ObjectInformation ParseValue(Token ValueToken)
        {
            SymbolTableEntry Symbol = _SymbolTable[ValueToken.ToString()];
            ValueInformation NewValue = new ValueInformation(Symbol, ValueToken.Location);
            
            if (Symbol.Type == SymbolType.Undefined)
            {
                Symbol.Type = SymbolType.Value;
                Symbol.DefinedLine = NewValue;
            }
            else
            {
                
            }

            Symbol.LineIDs.Add(NewValue);

            // Eat the command, we know what it should be already
            _Tokenizer.NextToken();

            NewValue.Params = ParseParams(NewValue);

            if (NewValue.Params.Count == 0)
            {
                NewValue.Error = true;
                MessageLog.Log.Add("Parser", ValueToken.Location, MessageCode.ValueMissing, Symbol.Symbol);
            }
            else
            {
                if (NewValue.Params.Simplify())
                {
                    NewValue.Value = NewValue.Params.Value.NumaricValue;
                }
            }

            return NewValue;
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
                    continue;

                else if (CurrentToken.Type == TokenType.Identifier)
                {
                    bool Error = false;
                    if (_Tokenizer.PeekNextToken().Type == TokenType.Colon)
                    {
                        CurrentObject = ParseLabel(CurrentToken);
                    }
                    else if (_Tokenizer.PeekNextToken().Type == TokenType.Equal)
                    {
                        // Equal is treated the same as 'EQU' in this case
                        CurrentObject = ParseValue(CurrentToken);
                    }
                    else if (_Tokenizer.PeekNextToken().Type == TokenType.Command)
                    {
                        if (_Tokenizer.PeekNextToken().CommandID == CommandID.EQU)
                        {
                            CurrentObject = ParseValue(CurrentToken);
                        }
                        else
                        {
                            Error = true;
                        }
                    }
                    else
                    {
                        Error = true;
                    }
                    
                    if(Error)
                    {
                        CurrentToken.Type = TokenType.Error;
                        MessageLog.Log.Add("Parser", CurrentToken.Location, MessageCode.SyntaxError, string.Format("Unable to define label {0}, missing colon", CurrentToken.ToString()));
                    }
                }
                else if (CurrentToken.Type == TokenType.Opcode)
                {
                    CurrentObject = ParseOpcode(CurrentToken);
                }
                else if (CurrentToken.Type == TokenType.Command)
                {
                    if (CurrentToken.IsData())
                        CurrentObject = ParseData(CurrentToken);
                    else
                        CurrentObject = ParseCommand(CurrentToken);
                }
                else
                {
                    MessageLog.Log.Add("Parser", CurrentToken.Location, MessageCode.UnexpectedSymbol, CurrentToken.ToString());
                    CurrentToken.Type = TokenType.Error;
                }

                // Resync if we have an error
                if (CurrentToken.Type == TokenType.Error)
                {
                    CurrentObject = null;
                    _Tokenizer.FlushLine();
                }
                else
                {
                    if (CurrentObject != null)
                    {
                        _ObjectData.Add(CurrentObject);
                        if (CurrentObject.Error)
                            _Tokenizer.FlushLine();
                    }

                    CurrentObject = null;
                }

            }

            return false;
        }

        bool PhaseTwo()
        {
            foreach (ObjectInformation Entry in _ObjectData)
            {
                if (Entry.Type == ObjectType.Opcode)
                {
                    OpcodeInformation OpEntry = (OpcodeInformation)Entry;

                    foreach (ParameterInformation Param in OpEntry.Params)
                    {
                        if (Param.Type != ParameterType.RegisterDisplacedPtr && !Param.Simplify())
                        {
                            MessageLog.Log.Add("Parser", OpEntry.Location, MessageCode.SyntaxError, "Invalid statemnt");
                        }
                    }
                }
            }
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

        CommandID SelectCommandToMatch(ParameterInformation CurrentParam)
        {
            if(CurrentParam.Type == ParameterType.Encoded)
                return (CommandID)((int)CommandID.Encoded + CurrentParam.Value.NumaricValue);
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
                    MessageLog.Log.Add("Parser", OpcodeObject.Location, MessageCode.InvalidParamaterForOpcode, string.Format("{0} >{1}<", OpcodeObject.Opcode.ToString(), OpcodeObject.ParamString(0)));

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
                    MessageLog.Log.Add("Parser", OpcodeObject.Location, MessageCode.InvalidParamaterForOpcode, string.Format("{0} {1}, >{2}<", OpcodeObject.Opcode.ToString(), OpcodeObject.ParamString(0), OpcodeObject.ParamString(1)));
                    
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
                    MessageLog.Log.Add("Parser", OpcodeObject.Location, MessageCode.InvalidParamaterForOpcode, string.Format("{0} {1}, {2}, >{3}<", OpcodeObject.Opcode.ToString(), OpcodeObject.ParamString(0), OpcodeObject.ParamString(1), OpcodeObject.ParamString(2)));

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
    }
}
