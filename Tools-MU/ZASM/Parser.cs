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

        public Parser()
        {
            _AllowIndex = true;
            _OpcodeTable = DataTables.z80Opcodes;
            _SectionList = new List<DataSection>();

            _SymbolTable = null;
        }

        public bool Parse(string FileName)
        {
            FileStream Data = System.IO.File.OpenRead(FileName);
            _Tokenizer = new Tokenizer(0, Data);

            if (_SymbolTable == null)
                _SymbolTable = new SymbolTable();

            _CurrentSection = new DataSection("");
            
            StageOne();

            return true;
        }

        Token GetNextToken()
        {
            Token CurrentToken = _Tokenizer.GetNextToken();
            if (CurrentToken.Type == TokenType.Identifier)
            {
                if (CurrentToken.StringValue[0] == '.')             // Command
                {
                    if (DataTables.Commands.ContainsKey(CurrentToken.StringValue))
                    {
                        CurrentToken.CommandID = DataTables.Commands[CurrentToken.StringValue];
                        if (CurrentToken.CommandID < CommandID.CommandMax)
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
                else if (_Tokenizer.PeekNextCharacterType() == CharacterType.Colon)    // Label
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

        public ObjectInformation ReadLine(Token CurrentToken)
        {
            ObjectInformation CurrentObject = new ObjectInformation(CurrentToken);

            while (_Tokenizer.PeekNextCharacterType() != CharacterType.CarriageReturn && _Tokenizer.PeekNextCharacterType() != CharacterType.LineFeed && _Tokenizer.PeekNextCharacterType() != CharacterType.End)
                CurrentObject.TokenList.Add(_Tokenizer.GetNextToken());

            return CurrentObject;        
        }

        SymbolTableEntry FindSymbol(Token CurrentToken)
        {
            SymbolTableEntry SymbolEntry = _SymbolTable[CurrentToken.StringValue];
            SymbolEntry.RefrencedLines.Add(new Tuple<int, int>(CurrentToken.FileID, CurrentToken.Line));
            
            return SymbolEntry;
        }
        
        public ObjectInformation ReadLabel(Token CurrentToken)
        {
            SymbolTableEntry SymbolEntry = FindSymbol(CurrentToken);
            LabelInformation NewLabel = new LabelInformation(CurrentToken, SymbolEntry);

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

                NewLabel.Address = 0;
                
                SymbolEntry.Object = NewLabel;
                SymbolEntry.State = SymbolState.ValuePending;
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

            return NewValue;
        }

        public ValueInformation ReadAssignment(ValueInformation CurrentIdentifier, Token CurrentToken)
        {
            CurrentIdentifier.TokenList.Add(CurrentToken);

            while (_Tokenizer.PeekNextCharacterType() != CharacterType.CarriageReturn && _Tokenizer.PeekNextCharacterType() != CharacterType.LineFeed && _Tokenizer.PeekNextCharacterType() != CharacterType.SemiColon && _Tokenizer.PeekNextCharacterType() != CharacterType.End)
                CurrentIdentifier.TokenList.Add(_Tokenizer.GetNextToken());

            if (CurrentIdentifier.Symbol.State == SymbolState.Undefined)
            {
                // This is the first time this symbol has been referenced
                CurrentIdentifier.Symbol.Type = CurrentToken.CommandID == CommandID.CONST ? SymbolType.Constant : SymbolType.Value;
                CurrentIdentifier.Symbol.FileID = CurrentToken.FileID;
                CurrentIdentifier.Symbol.Line = CurrentToken.Line;
            }
            else
            {
                // Redefining the value                
                // We can't redefine a value created with CONST
                if (CurrentIdentifier.Symbol.Type == SymbolType.Constant)
                {
                    Message.Log.Add("Parser", CurrentIdentifier.FileID, CurrentIdentifier.Line, CurrentIdentifier.Character, MessageCode.SyntaxWarning, string.Format("Can't redefine the value of {0}", CurrentIdentifier.Symbol.Name));
                    CurrentIdentifier.Error = true;
                }
            }

            if (CurrentIdentifier.Params.Count == 0)
            {
                Message.Log.Add("Parser", CurrentIdentifier.FileID, CurrentIdentifier.Line, CurrentIdentifier.Character, MessageCode.ValueMissing, CurrentIdentifier.Symbol.Name);
                CurrentIdentifier.Error = true;
            }
            else
            {
                //if (CurrentIdentifier.Params.Simplify(_CurrentSection.CurrentAddress))
                //{
                //    CurrentIdentifier.Value = CurrentIdentifier.Params.Value.NumericValue;
                //    CurrentIdentifier.Symbol.State = SymbolState.ValueSet;
                //}
                //else
                {
                    CurrentIdentifier.Symbol.State = SymbolState.ValuePending;
                }
            }


            return CurrentIdentifier;
        }

        public DataInformation ReadData(Token CurrentToken)
        {
            DataInformation NewData = new DataInformation(CurrentToken);

            while (_Tokenizer.PeekNextRoughTokenType() != TokenType.LineBreak && _Tokenizer.PeekNextRoughTokenType() != TokenType.End)
                NewData.TokenList.Add(_Tokenizer.GetNextToken());

            return NewData;
        }

        public CommandInformation ReadCommand(Token CurrentToken)
        {
            CommandInformation NewCommand = new CommandInformation(CurrentToken);

            while (_Tokenizer.PeekNextRoughTokenType() != TokenType.LineBreak && _Tokenizer.PeekNextRoughTokenType() != TokenType.Comment && _Tokenizer.PeekNextRoughTokenType() != TokenType.End)
                NewCommand.TokenList.Add(_Tokenizer.GetNextToken());

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

            while (_Tokenizer.PeekNextRoughTokenType() != TokenType.LineBreak && _Tokenizer.PeekNextRoughTokenType() != TokenType.Comment && _Tokenizer.PeekNextRoughTokenType() != TokenType.End)
                NewOpcode.TokenList.Add(_Tokenizer.GetNextToken());

            return NewOpcode;
        }
        
        public bool StageOne()
        {
            bool Done = false;
            ObjectInformation CurrentObject = null;
            ValueInformation CurrentIdentifier = null;
            while (!Done)
            {
                Token CurrentToken = GetNextToken();

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
                        if (CurrentToken.Type == TokenType.Assignment || CurrentToken.CommandID == CommandID.EQU || CurrentToken.CommandID == CommandID.CONST)
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
                            _Tokenizer.FlushLine();

                        CurrentObject = null;
                    }
                }
            }

            return true;
        }
    }
}
