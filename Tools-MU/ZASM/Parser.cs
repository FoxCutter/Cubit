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

        public Parser()
        {
            _AllowIndex = true;
            _OpcodeTable = DataTables.z80Opcodes;
        }

        public bool Parse(string FileName, SymbolTable ExistingTable = null)
        {
            FileStream Data = System.IO.File.OpenRead(FileName);
            _Tokenizer = new Tokenizer(0, Data);
            _SymbolTable = ExistingTable;
            if (_SymbolTable == null)
                _SymbolTable = new SymbolTable();
            
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

        public bool StageOne()
        {
            bool Done = false;
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

                    case TokenType.Command:
                        _Tokenizer.FlushLine();
                        break;

                    case TokenType.Label:
                        _Tokenizer.FlushLine();
                        break;

                    case TokenType.Opcode:
                        _Tokenizer.FlushLine();
                        break;

                    case TokenType.Identifier:
                        _Tokenizer.FlushLine();
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
            }

            return true;
        }
    }
}
