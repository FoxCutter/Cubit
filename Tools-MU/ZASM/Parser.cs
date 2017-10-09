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
        bool _AllowIndex;
        SortedList<string, ZASM.CommandID> _OpcodeTable;

        Tokenizer _Tokenizer;
        SymbolTable _SymbolTable;
        List<DataSection> _SectionList;
        DataSection _CurrentSection;
        ValueInformation _CurrentPosition;

        public Parser()
        {
            _AllowIndex = true;
            _OpcodeTable = DataTables.z80Opcodes;
            _SectionList = new List<DataSection>();

            _SymbolTable = null;

            _CurrentPosition = null;
        }

        public bool Parse(string FileName)
        {
            FileStream Data = System.IO.File.OpenRead(FileName);
            _Tokenizer = new Tokenizer(0, Data);

            if (_SymbolTable == null)
                _SymbolTable = new SymbolTable();

            if (_CurrentSection == null)
                _CurrentSection = new DataSection("");

            if (_CurrentPosition == null)
            {
                SymbolTableEntry SymbolEntry = _SymbolTable["$"];
                Token TempToken = new Token();
                TempToken.Type = TokenType.CurrentPos;

                _CurrentPosition = new ValueInformation(TempToken, SymbolEntry);
                _CurrentPosition.Address = 0;
                _CurrentPosition.Value = 0;
                SymbolEntry.Object = _CurrentPosition;
                SymbolEntry.Type = SymbolType.Address;
                SymbolEntry.State = SymbolState.ValueSet;
            }

            StageOne();

            StreamWriter Catch = new StreamWriter(System.IO.File.OpenWrite(FileName + ".out"));
          
            foreach (ObjectInformation Entry in _CurrentSection.ObjectData)
            {
                StringBuilder Output = new StringBuilder();

                //var Res = FindOpcode(Entry);

                //if (Entry.Type >= ObjectType.Meta)
                //    continue;

                Output.AppendFormat("{0} {1} ", Entry.Line, Entry.Address.ToString("X4"));

                if (Entry.Type == ObjectType.Label)
                {
                    LabelInformation Label = (LabelInformation)Entry;
                    Output.AppendFormat("{0,-10} ", Label.Symbol.Name + ":");
                    //Output.AppendFormat("{0,-10} ", Entry.Symbol.DefinedLine.ToString());
                }
                else if (Entry.Type == ObjectType.Value)
                {
                    ValueInformation Value = (ValueInformation)Entry;
                    Output.AppendFormat("{0,-10} ", Value.Symbol.Name);
                }
                else
                {
                    Output.Append("           ");
                }

                if (Entry.Type == ObjectType.Value)
                {
                    ValueInformation Value = (ValueInformation)Entry;
                    Output.Append("EQU    ");
                    Output.Append(Value.ToValueString());

                }
                else if (Entry.Type == ObjectType.Command)
                {
                    CommandInformation Command = (CommandInformation)Entry;

                    Output.AppendFormat(".{0,-6} ", Command.Command.ToString());

                    for (int x = 0; x < Command.Params.Count; x++)
                    {
                        if (x != 0)
                            Output.Append(", ");

                        Output.Append(Command.ParamString(x));
                    }
                }
                else if (Entry.Type == ObjectType.Data)
                {
                    DataInformation Command = (DataInformation)Entry;

                    Output.AppendFormat("{0,-6} ", Command.DataType.ToString());

                    for (int x = 0; x < Command.Params.Count; x++)
                    {
                        if (x != 0)
                            Output.Append(", ");

                        Output.Append(Command.ParamString(x));
                    }
                }
                else if (Entry.Type == ObjectType.Opcode)
                {
                    OpcodeInformation Opcode = (OpcodeInformation)Entry;

                    Output.AppendFormat("{0,-6} ", Opcode.Opcode.ToString());

                    for (int x = 0; x < Opcode.Params.Count; x++)
                    {
                        if (x != 0)
                            Output.Append(", ");

                        Output.Append(Opcode.ParamString(x));
                    }
                }


                Console.WriteLine(Output.ToString());
                Catch.WriteLine(Output.ToString());
            }
            
            foreach (SymbolTableEntry Entry in _SymbolTable.OrderBy(e => e.Name))
            {
                StringBuilder Output = new StringBuilder();

                if (Entry.Type == SymbolType.Value || Entry.Type == SymbolType.Constant)
                {
                    Output.Append(Entry.Name);
                    Output.Append(' ', 20 - Output.Length);

                    Output.Append(" = ");

                    if (Entry.State == SymbolState.Undefined)
                        Output.Append("Undefined");

                    else if (Entry.State == SymbolState.ValuePending)
                        Output.Append("Pending");

                    else
                        Output.Append(((ValueInformation)Entry.Object).Value.ToString("X4"));
                }
                else if (Entry.Type == SymbolType.Address)
                {
                    Output.Append(Entry.Name);
                    Output.Append(' ', 23 - Output.Length);
                    Output.Append(Entry.Object.Address.ToString("X4"));
                }
                else
                {
                    Output.Append(Entry.Name);
                    Output.Append(' ', 23 - Output.Length);
                    Output.Append("UNKNOWN");
                }
                Console.WriteLine(Output.ToString());
                Catch.WriteLine(Output.ToString());
            }

            Catch.Close();
            return true;
        }

        void UpdateCurrentPosition(int Value)
        {
            _CurrentSection.CurrentOffset += Value;
            _CurrentPosition.Address = (short)GetCurrentPosition();
        }

        int GetCurrentPosition()
        {
            if (_CurrentSection.Placement == -1)
                return _CurrentSection.CurrentOffset;
            else
                return _CurrentSection.Placement + _CurrentSection.CurrentOffset;
        }

        void SetCurrentPosition(int Value)
        {
            _CurrentSection.CurrentOffset = Value;
            _CurrentPosition.Address = (short)GetCurrentPosition();
        }

        Token GetNextToken(bool WithLables = false)
        {
            Token CurrentToken = _Tokenizer.GetNextToken();
            if (CurrentToken.Type == TokenType.Identifier)
            {
                if (CurrentToken.StringValue[0] == '.')             // Command
                {
                    if (DataTables.Commands.ContainsKey(CurrentToken.StringValue))
                    {
                        CurrentToken.CommandID = DataTables.Commands[CurrentToken.StringValue];
                        if (CurrentToken.CommandID < CommandID.DataCommandsMax)
                            CurrentToken.Type = TokenType.Data;
                        
                        else if (CurrentToken.CommandID < CommandID.CommandMax)
                            CurrentToken.Type = TokenType.Command;

                        else if (CurrentToken.CommandID < CommandID.PreprocessorMax)
                            CurrentToken.Type = TokenType.Preprocessor;

                        else
                            Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.UnknownCommand, _Tokenizer.CurrentString);
                    }
                    else
                    {
                        CurrentToken.Type = TokenType.Error;
                        Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.UnknownCommand, _Tokenizer.CurrentString);
                    }
                }
                else if (WithLables && _Tokenizer.PeekNextCharacterType() == CharacterType.Colon)    // Label
                {
                    CurrentToken.Type = TokenType.Label;
                }
                else
                {
                    if (DataTables.PsudoOpcodes.ContainsKey(CurrentToken.StringValue))
                    {
                        CurrentToken.CommandID = DataTables.PsudoOpcodes[CurrentToken.StringValue];
                        
                        if (CurrentToken.CommandID < CommandID.DataCommandsMax)
                            CurrentToken.Type = TokenType.Data;
                        else
                            CurrentToken.Type = TokenType.Command;
                    }
                    else if (_OpcodeTable.ContainsKey(CurrentToken.StringValue))
                    {
                        CurrentToken.CommandID = _OpcodeTable[CurrentToken.StringValue];
                        if (CurrentToken.CommandID < CommandID.RegisterMax)
                            CurrentToken.Type = TokenType.Register;

                        else if (CurrentToken.CommandID < CommandID.FlagsMax)
                            CurrentToken.Type = TokenType.Flag;

                        else
                            CurrentToken.Type = TokenType.Opcode;
                    }
                }
            }
            
            return CurrentToken;
        }

        SymbolTableEntry FindSymbol(Token CurrentToken)
        {
            SymbolTableEntry SymbolEntry = _SymbolTable[CurrentToken.StringValue];
            SymbolEntry.RefrencedLines.Add(new Tuple<int, int>(CurrentToken.FileID, CurrentToken.Line));
            
            return SymbolEntry;
        }

        public LabelInformation ReadLabel(Token CurrentToken)
        {
            SymbolTableEntry SymbolEntry = FindSymbol(CurrentToken);
            LabelInformation NewLabel = new LabelInformation(CurrentToken, SymbolEntry);
            NewLabel.Address = GetCurrentPosition();

            if (SymbolEntry.State != SymbolState.Undefined)
            {
                Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.SyntaxError, string.Format("{0} redefined", SymbolEntry.Name));
                NewLabel.Error = true;
            }
            else
            {
                SymbolEntry.Type = SymbolType.Address;
                SymbolEntry.FileID = CurrentToken.FileID;
                SymbolEntry.Line = CurrentToken.Line;
              
                SymbolEntry.Object = NewLabel;
                SymbolEntry.State = SymbolState.ValueSet;
            }
            
            // If the label has a colon, eat it.
            if (_Tokenizer.PeekNextCharacterType() == CharacterType.Colon)
                _Tokenizer.GetNextToken();
            else
                Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.InternalError, "Colon missing!");

            return NewLabel;
        }

        public ValueInformation ReadIdentifier(Token CurrentToken)
        {
            SymbolTableEntry SymbolEntry = FindSymbol(CurrentToken);
            ValueInformation NewValue = new ValueInformation(CurrentToken, SymbolEntry);
            NewValue.Address = GetCurrentPosition();

            return NewValue;
        }

        public ValueInformation ReadAssignment(ValueInformation CurrentIdentifier, Token CurrentToken)
        {
            CurrentIdentifier.TokenList.Add(CurrentToken);

            if (!IsBreakType(_Tokenizer.PeekNextRoughTokenType()))
            {
                ParameterInformation Param = ParseParams(CurrentIdentifier);
                if (Param.HasTokenType(TokenType.Register) || Param.HasTokenType(TokenType.Flag))
                {
                    Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.SyntaxWarning, "Registers/Flags can't be used in equations");
                    CurrentIdentifier.Error = true;
                    Param.Type = ParameterType.Error;
                }

                Param.Simplify(_SymbolTable);
                CurrentIdentifier.Params.Add(Param);
            }

            if (CurrentIdentifier.Symbol.State == SymbolState.Undefined)
            {
                // This is the first time this symbol has been referenced
                CurrentIdentifier.Symbol.Type = CurrentToken.CommandID == CommandID.EQU ? SymbolType.Constant : SymbolType.Value;
                CurrentIdentifier.Symbol.FileID = CurrentToken.FileID;
                CurrentIdentifier.Symbol.Line = CurrentToken.Line;

                CurrentIdentifier.Symbol.Object = CurrentIdentifier;
            }
            else
            {
                // Redefining the value                
                // We can't redefine a value created with EQU
                if (CurrentIdentifier.Symbol.Type == SymbolType.Constant)
                {
                    Message.Log.Add("Parser", CurrentIdentifier.FileID, CurrentIdentifier.Line, CurrentIdentifier.Character, MessageCode.SyntaxWarning, string.Format("Can't redefine the value of {0}", CurrentIdentifier.Symbol.Name));
                    CurrentIdentifier.Error = true;
                }
                else if (CurrentToken.CommandID == CommandID.EQU)
                {
                    Message.Log.Add("Parser", CurrentIdentifier.FileID, CurrentIdentifier.Line, CurrentIdentifier.Character, MessageCode.SyntaxWarning, string.Format("Can't convert {0} to const", CurrentIdentifier.Symbol.Name));
                }
            }

            if (CurrentIdentifier.Params.Count == 0)
            {
                Message.Log.Add("Parser", CurrentIdentifier.FileID, CurrentIdentifier.Line, CurrentIdentifier.Character, MessageCode.ValueMissing, CurrentIdentifier.Symbol.Name);
                CurrentIdentifier.Error = true;
            }
            else
            {
                if (CurrentIdentifier.Params[0].Value.Type == TokenType.Number)
                {
                    CurrentIdentifier.Value = CurrentIdentifier.Params[0].Value.NumericValue;
                    CurrentIdentifier.Symbol.State = SymbolState.ValueSet;
                }
                else if (CurrentIdentifier.Params[0].Value.Type == TokenType.String)
                {
                    CurrentIdentifier.Symbol.State = SymbolState.Empty;
                    Message.Log.Add("Parser", CurrentIdentifier.Params[0].Value.FileID, CurrentIdentifier.Params[0].Value.Line, CurrentIdentifier.Params[0].Value.Character, MessageCode.SyntaxWarning, string.Format("{0}: values can not be strings", CurrentIdentifier.Symbol.Name));
                    CurrentIdentifier.Error = true;
                }
                else
                {
                    CurrentIdentifier.Symbol.State = SymbolState.ValuePending;
                }
            }

            return CurrentIdentifier;
        }

        public DataInformation ReadData(Token CurrentToken)
        {
            DataInformation NewData = new DataInformation(CurrentToken);
            NewData.Address = GetCurrentPosition();

            while (!IsBreakType(_Tokenizer.PeekNextRoughTokenType()))
            {
                ParameterInformation Param = ParseParams(NewData);
                if (Param.HasTokenType(TokenType.Register) || Param.HasTokenType(TokenType.Flag))
                {
                    Message.Log.Add("Parser", NewData.FileID, NewData.Line, NewData.Character, MessageCode.SyntaxWarning, "Registers/Flags can't be used in data statments");
                    NewData.Error = true;
                    Param.Type = ParameterType.Error;
                }

                Param.Simplify(_SymbolTable);
                NewData.Params.Add(Param);
                if (CurrentToken.CommandID == CommandID.DC && Param.Type != ParameterType.String)
                {
                    Message.Log.Add("Parser", NewData.FileID, NewData.Line, NewData.Character, MessageCode.SyntaxError, "'DC' can only contain strings");
                    NewData.Error = true;
                    Param.Type = ParameterType.Error;
                }

                if (CurrentToken.CommandID == CommandID.RESB || CurrentToken.CommandID == CommandID.RESW || CurrentToken.CommandID == CommandID.RESD)
                {
                    // Reserved values have to evaluate.
                    if (Param.Type == ParameterType.Error || Param.Resolved == false)
                    {
                        Message.Log.Add("Parser", Param.TokenList[0].FileID, Param.TokenList[0].Line, Param.TokenList[0].Character, MessageCode.SyntaxError, "Unable to resolved length of reserved data");
                        NewData.Error = true;
                    }
                }

                if (_Tokenizer.PeekNextCharacterType() != CharacterType.Comma)
                    break;
                else
                    NewData.TokenList.Add(_Tokenizer.GetNextToken());
            }

            if (NewData.GetDataLength() < 0)
            {
                Message.Log.Add("Parser", NewData.FileID, NewData.Line, NewData.Character, MessageCode.SyntaxError, "Can't reserve negitive space");
                NewData.Error = true;
            }

            
            UpdateCurrentPosition(NewData.GetDataLength());


            return NewData;
        }

        public CommandInformation ReadCommand(Token CurrentToken)
        {
            CommandInformation NewCommand = new CommandInformation(CurrentToken);
            NewCommand.Address = GetCurrentPosition();

            if (!IsBreakType(_Tokenizer.PeekNextRoughTokenType()))
            {
                ParameterInformation Param = ParseParams(NewCommand);
                if (Param.HasTokenType(TokenType.Register) || Param.HasTokenType(TokenType.Flag))
                {
                    Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.SyntaxWarning, "Registers/Flags can't be used in equations");
                    NewCommand.Error = true;
                    Param.Type = ParameterType.Error;
                }

                Param.Simplify(_SymbolTable); 
                NewCommand.Params.Add(Param);
            }

            switch (NewCommand.Command)
            {
                case CommandID.Z80:
                case CommandID.i8080:
                case CommandID.GAMEBOY:
                    break;

                case CommandID.SECTION:
                case CommandID.FILL:
                case CommandID.SIZE:
                case CommandID.POS:
                    break;

                case CommandID.ORG:
                    SetCurrentPosition(NewCommand.Params[0].Value.NumericValue);
                    break;

                case CommandID.INCLUDE:
                    break;
                    
                case CommandID.EXTERN:
                case CommandID.PUBLIC:
                    break;

                case CommandID.END:
                    break;
            }
            
            return NewCommand;
        }

        public OpcodeInformation ReadOpcode(Token CurrentToken)
        {
            OpcodeInformation NewOpcode = new OpcodeInformation(CurrentToken);
            NewOpcode.Address = GetCurrentPosition();

            while (_Tokenizer.PeekNextRoughTokenType() != TokenType.LineBreak && _Tokenizer.PeekNextRoughTokenType() != TokenType.Comment && _Tokenizer.PeekNextRoughTokenType() != TokenType.End)
            {
                ParameterInformation Param = ParseParams(NewOpcode);
                NewOpcode.Params.Add(Param);

                if (_Tokenizer.PeekNextCharacterType() != CharacterType.Comma)
                    break;
                else
                    NewOpcode.TokenList.Add(_Tokenizer.GetNextToken());
            }

            if (CurrentToken.AssumeA() && NewOpcode.Params.Count <= 1)
            {
                ParameterInformation NewParam = new ParameterInformation();
                NewParam.Pointer = false;
                NewParam.Type = ParameterType.ByteRegister;

                Token NewToken = new Token();
                NewToken.CommandID = CommandID.A;
                NewToken.Type = TokenType.Register;

                NewParam.TokenList.Add(NewToken);

                NewOpcode.Params.Add(NewParam);

                if (CurrentToken.CommandID != CommandID.OUT)
                    NewOpcode.Params.Reverse();

                //Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.RegisterMissingAssumingA);

            }

            foreach (ParameterInformation Param in NewOpcode.Params)
            {
                // The documentation for these opcodes use () even though they arn't being used as addresses, so take care of that here.
                if (NewOpcode.Opcode == CommandID.IN || NewOpcode.Opcode == CommandID.OUT || NewOpcode.Opcode == CommandID.JP)
                    Param.Pointer = false;

                // Differentiate between the C Register and the Carry Flag
                if (CurrentToken.CanHaveFlag() && Param.Value.Type == TokenType.Register)
                {
                    if (Param.Value.CommandID == CommandID.C)
                    {
                        Token Temp = Param.Value;
                        Temp.CommandID = CommandID.Flag_C;
                        Temp.Type = TokenType.Flag;

                        Param.Value = Temp;
                    }
                }

                // Sanity check the params
                if (Param.HasTokenType(TokenType.Register) && Param.TokenList.Count > 1)
                {
                    if (Param.TokenTypeCount(TokenType.Register) > 1)
                    {
                        Message.Log.Add("Parser", Param.TokenList[0].FileID, Param.TokenList[0].Line, Param.TokenList[0].Character, MessageCode.SyntaxError, "To many registers in parameter");
                        NewOpcode.Error = true;
                        Param.Type = ParameterType.Error;
                    }
                    else if (Param.HasWordIndexRegister())
                    {
                        if (Param.HasOperators() && !Param.Pointer)
                        {
                            Message.Log.Add("Parser", Param.TokenList[0].FileID, Param.TokenList[0].Line, Param.TokenList[0].Character, MessageCode.SyntaxError, "Index offsets can only be used on memory refereces");
                            NewOpcode.Error = true;
                            Param.Type = ParameterType.Error;
                        }
                    }
                    else if (Param.HasOperators())
                    {
                        Message.Log.Add("Parser", Param.TokenList[0].FileID, Param.TokenList[0].Line, Param.TokenList[0].Character, MessageCode.SyntaxError, "Registers can't be used in equations");
                        NewOpcode.Error = true;
                        Param.Type = ParameterType.Error;
                    }
                }

                if (Param.HasTokenType(TokenType.Flag) && Param.HasOperators())
                {
                    Message.Log.Add("Parser", Param.TokenList[0].FileID, Param.TokenList[0].Line, Param.TokenList[0].Character, MessageCode.SyntaxError, "Flags can't be used in equations");
                    NewOpcode.Error = true;
                    Param.Type = ParameterType.Error;
                }

                Param.Simplify(_SymbolTable);
            }

            // Look up the opcode
            LookupOpcode(NewOpcode);

            UpdateCurrentPosition(NewOpcode.Encoding.Length);

            return NewOpcode;
        }

        bool OpcodeMatch(ParameterInformation NewOpcode, System.Tuple<ZASM.CommandID, ZASM.ParameterType, bool, int> Encoding)
        {
            if (NewOpcode.Type != Encoding.Item2)
                return false;

            if (NewOpcode.Pointer != Encoding.Item3)
                return false;

            if (Encoding.Item1 == CommandID.ImmediateByte || Encoding.Item1 == CommandID.ImmediateWord || Encoding.Item1 == CommandID.EncodedByte)
                return true;

            if (Encoding.Item1 >= CommandID.Encoded0 && Encoding.Item1 <= CommandID.Encoded2)
            {
                if (Encoding.Item1 == CommandID.Encoded0 && NewOpcode.Value.NumericValue != 0)
                    return false;

                if (Encoding.Item1 == CommandID.Encoded1 && NewOpcode.Value.NumericValue != 1)
                    return false;

                if (Encoding.Item1 == CommandID.Encoded2 && NewOpcode.Value.NumericValue != 2)
                    return false;
            }
            else if (Encoding.Item1 != CommandID.RegisterAny && Encoding.Item1 != CommandID.FlagsAny)
            {
                if (NewOpcode.Value.CommandID != Encoding.Item1)
                    return false;
            }


            return true;
        }
        
        bool LookupOpcode(OpcodeInformation NewOpcode)
        {
            IEnumerable<OpcodeData> Opcodes = OpcodeTables.z80OpcodeList.Where(e => e.Name == NewOpcode.Opcode);
            if (Opcodes.Count() == 0)
            {
                Message.Log.Add("Parser", NewOpcode.FileID, NewOpcode.Line, NewOpcode.Character, MessageCode.InternalError, string.Format("Can't match Opcode {0}", NewOpcode.Opcode.ToString()));
                NewOpcode.Error = true;
                return false;
            }

            if (NewOpcode.Params.Count == 0)
            {
                Opcodes = Opcodes.Where(e => e.Param0 == null);

                if (Opcodes.Count() > 1)
                {
                    Message.Log.Add("Parser", NewOpcode.FileID, NewOpcode.Line, NewOpcode.Character, MessageCode.InternalError, string.Format("Opcode {0} 0-Param lookup error", NewOpcode.Opcode.ToString()));
                    NewOpcode.Error = true;
                    return false;
                }
            }

            // Match them on the type information
            if (NewOpcode.Params.Count >= 1)
            {
                ParameterInformation CurrentParam = NewOpcode.Params[0];
                Opcodes = Opcodes.Where(e => (e.Param0 != null && OpcodeMatch(CurrentParam, e.Param0)));

                if (Opcodes.Count() == 0)
                {
                    Message.Log.Add("Parser", CurrentParam.TokenList[0].FileID, CurrentParam.TokenList[0].Line, CurrentParam.TokenList[0].Character, MessageCode.InvalidParamaterForOpcode, string.Format("{0} >{1}<", NewOpcode.Opcode.ToString(), NewOpcode.ParamString(0)));
                    NewOpcode.Error = true;
                    return false;
                }
            }

            if (NewOpcode.Params.Count >= 2)
            {
                ParameterInformation CurrentParam = NewOpcode.Params[1];
                Opcodes = Opcodes.Where(e => (e.Param1 != null && OpcodeMatch(CurrentParam, e.Param1)));

                if (Opcodes.Count() == 0)
                {
                    Message.Log.Add("Parser", CurrentParam.TokenList[0].FileID, CurrentParam.TokenList[0].Line, CurrentParam.TokenList[0].Character, MessageCode.InvalidParamaterForOpcode, string.Format("{0} {1}, >{2}<", NewOpcode.Opcode.ToString(), NewOpcode.ParamString(0), NewOpcode.ParamString(1)));
                    NewOpcode.Error = true;
                    return false;
                }
            }
            if (NewOpcode.Params.Count == 3)
            {
                ParameterInformation CurrentParam = NewOpcode.Params[2];
                Opcodes = Opcodes.Where(e => (e.Param2 != null && OpcodeMatch(CurrentParam, e.Param2)));

                if (Opcodes.Count() == 0)
                {
                    Message.Log.Add("Parser", CurrentParam.TokenList[0].FileID, CurrentParam.TokenList[0].Line, CurrentParam.TokenList[0].Character, MessageCode.InvalidParamaterForOpcode, string.Format("{0} {1}, {2} >{3}<", NewOpcode.Opcode.ToString(), NewOpcode.ParamString(0), NewOpcode.ParamString(1), NewOpcode.ParamString(2)));
                    NewOpcode.Error = true;
                    return false;
                }
            }

            if (Opcodes.Count() > 1)
            {
                Message.Log.Add("Parser", NewOpcode.FileID, NewOpcode.Line, NewOpcode.Character, MessageCode.InternalError, string.Format("Multi match for {0} {1}, {2}, {3}", NewOpcode.Opcode.ToString(), NewOpcode.ParamString(0), NewOpcode.ParamString(1), NewOpcode.ParamString(2)));
                NewOpcode.Error = true;
                return false;
            }

            NewOpcode.Encoding = Opcodes.First();

            return true;
        }


        bool IsBreakType(TokenType Type)
        {
            if (Type == TokenType.LineBreak || Type == TokenType.Comment || Type == TokenType.End)
                return true;

            return false;
        }


        public ParameterInformation ParseParams(ObjectInformation CurrentObject)
        {
            ParameterInformation Ret = new ParameterInformation();

            // Just to keep track of group openings so we can close them in order
            Stack<Token> GroupStack = new Stack<Token>();

            bool Done = false;

            while (!Done)
            {
                TokenType NextToken = _Tokenizer.PeekNextRoughTokenType();
                CharacterType NextCharacter = _Tokenizer.PeekNextCharacterType();

                if (IsBreakType(NextToken))
                {
                    Done = true;
                }
                else if (NextToken == TokenType.Symbol && NextCharacter == CharacterType.Comma && GroupStack.Count == 0)
                {
                    Done = true;
                }
                else
                {
                    Token CurrentToken = GetNextToken();

                    switch (CurrentToken.Type)
                    {
                        case TokenType.Identifier:
                            {
                                // Make sure any symbols we find are in the symbol table
                                SymbolTableEntry SymbolEntry = FindSymbol(CurrentToken);

                                // And if we'se never seen them before mark them as such
                                if (SymbolEntry.Type == SymbolType.None)
                                {
                                    SymbolEntry.Type = SymbolType.Unknown;
                                    SymbolEntry.State = SymbolState.Undefined;
                                }
                            }
                            break;

                        case TokenType.GroupLeft:
                            GroupStack.Push(CurrentToken);
                            break;

                        case TokenType.GroupRight:
                            if (GroupStack.Count == 0)
                            {
                                // Checking for to many closing groups
                                CurrentObject.Error = true;
                                if (CurrentToken.CharacterType == CharacterType.ParenthesesRight)
                                    Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.MissingGroupSymbol, "Opening (");

                                else
                                    Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.MissingGroupSymbol, "Opening [");
                            }
                            else
                            {
                                Token OldGroup = GroupStack.Pop();

                                // Make sure the closing matchs the opening
                                if (OldGroup.CharacterType == CharacterType.ParenthesesLeft && CurrentToken.CharacterType != CharacterType.ParenthesesRight)
                                {
                                    CurrentObject.Error = true;
                                    Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.MissingGroupSymbol, "Expected ')' found ']'");
                                }
                                else if (OldGroup.CharacterType == CharacterType.BracketLeft && CurrentToken.CharacterType != CharacterType.BracketRight)
                                {
                                    CurrentObject.Error = true;
                                    Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.MissingGroupSymbol, "Expected ']' found ')'");
                                }
                            }
                            break;

                        case TokenType.Plus:
                            if (Ret.TokenList.Count == 0)
                            {
                                CurrentToken.Type = TokenType.UnarrayPlus;
                            }
                            else
                            {
                                Token LastToken = Ret.TokenList[Ret.TokenList.Count - 1];

                                if (LastToken.IsWordIndexRegister() || (LastToken.Type != TokenType.GroupRight && LastToken.IsOperator()))
                                    CurrentToken.Type = TokenType.UnarrayPlus;
                            }

                            break;

                        case TokenType.Minus:
                            if (Ret.TokenList.Count == 0)
                            {
                                CurrentToken.Type = TokenType.UnarrayMinus;
                            }
                            else
                            {
                                Token LastToken = Ret.TokenList[Ret.TokenList.Count - 1];

                                if (LastToken.IsWordIndexRegister() || (LastToken.Type != TokenType.GroupRight && LastToken.IsOperator()))
                                    CurrentToken.Type = TokenType.UnarrayMinus;
                            }

                            break;
                        
                        case TokenType.Command:
                        case TokenType.Opcode:
                        case TokenType.Data:
                            CurrentObject.Error = true;
                            Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.SyntaxError, string.Format("Unexected reserved word {0}", CurrentToken.StringValue));
                            break;

                        case TokenType.Register:
                        case TokenType.Flag:
                        case TokenType.Label:
                        case TokenType.Symbol:
                            break;

                        default:
                            break;
                            
                    }
                    
                    Ret.TokenList.Add(CurrentToken);
                    CurrentObject.TokenList.Add(CurrentToken);
                }
            };

            // Check for any groups that were opened but not closed
            while (GroupStack.Count != 0)
            {
                CurrentObject.Error = true;
                Token CurrentToken = GroupStack.Pop();
                if (CurrentToken.CharacterType == CharacterType.ParenthesesLeft)
                    Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.MissingGroupSymbol, "Closing )");

                else
                    Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.MissingGroupSymbol, "Closing ]");
            }

            if (!Ret.OrderValues(CurrentObject.Type == ObjectType.Opcode))
                CurrentObject.Error = true;

            return Ret;
        }
        
        public bool StageOne()
        {
            bool Error = false;
            bool Done = false;
            ObjectInformation CurrentObject = null;
            ValueInformation CurrentIdentifier = null;
            while (!Done)
            {
                Token CurrentToken = GetNextToken(true);

                switch (CurrentToken.Type)
                {
                    case TokenType.End:
                        Done = true;
                        break;

                    case TokenType.Comment:
                    case TokenType.LineBreak:
                    case TokenType.WhiteSpace:
                    case TokenType.Error:
                        break;

                    case TokenType.Assignment:
                    case TokenType.Command:
                    case TokenType.Preprocessor:
                        if (CurrentToken.Type == TokenType.Assignment || CurrentToken.CommandID == CommandID.EQU || CurrentToken.CommandID == CommandID.DEFL)
                        {
                            if (CurrentIdentifier == null)
                            {
                                Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.SyntaxError, "Can't set a value without a label");
                                CurrentToken.Type = TokenType.Error;
                            }
                            else
                            {
                                CurrentObject = ReadAssignment(CurrentIdentifier, CurrentToken);
                                CurrentIdentifier = null;
                            }
                        }
                        else
                        {
                            CurrentObject = ReadCommand(CurrentToken);                                
                        }                        
                        break;

                    case TokenType.Data:
                        CurrentObject = ReadData(CurrentToken);
                        break;

                    case TokenType.Label:
                        CurrentObject = ReadLabel(CurrentToken);    
                        break;

                    case TokenType.Opcode:
                        CurrentObject = ReadOpcode(CurrentToken);    
                        break;

                    case TokenType.Identifier:
                        if (CurrentIdentifier != null)
                        {
                            Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.SyntaxError, string.Format("Unable to define label '{0}', missing colon", CurrentIdentifier.Symbol.Name));
                            CurrentToken.Type = TokenType.Error;
                        }
                        else if (_Tokenizer.PeekNextCharacterType() == CharacterType.Equal || _Tokenizer.PeekNextCharacterType() == CharacterType.Identifier)
                        {
                            CurrentIdentifier = ReadIdentifier(CurrentToken);
                        }
                        else
                        {
                            Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.SyntaxError, string.Format("Unable to define label '{0}', missing colon", _Tokenizer.CurrentString));
                            CurrentToken.Type = TokenType.Error;
                        }
                        break;

                    default:
                        Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.UnexpectedSymbol, _Tokenizer.CurrentString);
                        CurrentToken.Type = TokenType.Error;
                        break;
                }

                if (CurrentToken.Type == TokenType.Error)
                {
                    CurrentObject = null;
                    CurrentIdentifier = null;
                    Error = true;

                    _Tokenizer.FlushLine();
                }
                else
                {
                    if (CurrentObject != null)
                    {
                        if (CurrentIdentifier != null)
                        {
                            Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.UnexpectedSymbol, CurrentIdentifier.Symbol.Name);
                            CurrentIdentifier = null;
                        }
                        
                        _CurrentSection.ObjectData.Add(CurrentObject);

                        if (CurrentObject.Error)
                        {
                            _Tokenizer.FlushLine();
                            Error = true;
                        }

                        CurrentObject = null;
                    }
                }
            }

            // Evaluate any values that are value based. 
            int Pass = 0;
            while (_SymbolTable.Count(e => e.State == SymbolState.ValuePending) != 0 && Pass != 0x25)
            {
                
                
                foreach (SymbolTableEntry Symbol in _SymbolTable)
                {
                    if (Symbol.Type == SymbolType.Unknown)
                    {
                        Message.Log.Add("Parser", Symbol.RefrencedLines[0].Item1, Symbol.RefrencedLines[0].Item2, 0, MessageCode.UndefinedSymbol, Symbol.Name);
                        Error = true;
                    }
                    else if ((Symbol.Type == SymbolType.Constant || Symbol.Type == SymbolType.Value) && Symbol.State == SymbolState.ValuePending)
                    {
                        ValueInformation ValueObject = (ValueInformation)Symbol.Object;
                        if (ValueObject.Params.Count == 0)
                        {
                            Message.Log.Add("Parser", ValueObject.FileID, ValueObject.Line, ValueObject.Character, MessageCode.InternalError, "Missing Param list in post stage 1");
                            Error = true;
                        }
                        else
                        {
                            ValueObject.Params[0].Simplify(_SymbolTable);

                            if (ValueObject.Params[0].Value.Type == TokenType.Number)
                            {
                                ValueObject.Value = ValueObject.Params[0].Value.NumericValue;
                                ValueObject.Symbol.State = SymbolState.ValueSet;
                            }
                        }
                    }
                }

                Pass++;
            }

            if (Pass == 0x25)
            {
                foreach (SymbolTableEntry Symbol in _SymbolTable.Where(e => e.State == SymbolState.ValuePending))
                {
                    ValueInformation ValueObject = (ValueInformation)Symbol.Object;

                    Message.Log.Add("Parser", ValueObject.FileID, ValueObject.Line, ValueObject.Character, MessageCode.SyntaxError, string.Format("Unable to resolve '{0}'", ValueObject.Symbol.Name));
                    Error = true;
                }
            }

            if (Message.Log.ErrorCount() != 0)
                Error = true;

            return !Error;
        }
    }
}
