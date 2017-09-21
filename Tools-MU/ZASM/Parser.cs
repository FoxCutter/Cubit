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
                        CurrentToken.Type = TokenType.Command;
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
        
        public ObjectInformation ReadLabel(Token CurrentToken)
        {
            SymbolTableEntry SymbolEntry = _SymbolTable[_Tokenizer.CurrentString];
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

        public ObjectInformation ReadIdentifier(Token CurrentToken)
        {
            SymbolTableEntry SymbolEntry = _SymbolTable[_Tokenizer.CurrentString];
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
        
        public bool StageOne()
        {
            bool Done = false;
            while (!Done)
            {
                Token CurrentToken = GetNextToken();
                ObjectInformation CurrentObject = null;

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
                        if (CurrentToken.Type == TokenType.Assignment || CurrentToken.CommandID == CommandID.EQU || CurrentToken.CommandID == CommandID.CONST)
                        {

                        }
                        else
                        {

                        }
                        CurrentObject = ReadLine(CurrentToken);    
                        //_Tokenizer.FlushLine();
                        break;

                    case TokenType.Label:
                        CurrentObject = ReadLabel(CurrentToken);    
                        break;

                    case TokenType.Opcode:
                        CurrentObject = ReadLine(CurrentToken);    
                        //_Tokenizer.FlushLine();
                        break;

                    case TokenType.Identifier:
                        CurrentObject = ReadLine(CurrentToken);    
                        //_Tokenizer.FlushLine();
                        break;

                    default:
                        Message.Log.Add("Parser", CurrentToken.FileID, CurrentToken.Line, CurrentToken.Character, MessageCode.UnexpectedSymbol, _Tokenizer.CurrentString);
                        CurrentToken.Type = TokenType.Error;
                        break;
                }

                if (CurrentToken.Type == TokenType.Error)
                {
                    _Tokenizer.FlushLine();
                }
                else
                {
                    if (CurrentObject != null)
                    {
                        _CurrentSection.ObjectData.Add(CurrentObject);

                        if (CurrentObject.Error)
                            _Tokenizer.FlushLine();
                    }
                }
            }

            return true;
        }
    }
}
