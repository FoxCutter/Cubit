using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZASM
{
    partial class Parser
    {
        bool ParseConditional(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer, FunctionID Command)
        {
            bool Success = true;
            ConditionalObject CurrentObject = new ConditionalObject(CurrentLine, Command);
            CurrentLine.Object = CurrentObject;

            if (Command == FunctionID.IF)
            {
                ConditionalInformation CurrentIfDef = new ConditionalInformation();
                CurrentIfDef.Line = CurrentLine;
                CurrentIfDef.Result = false;
                CurrentIfDef.SavedParse = CurrentLine.ParseLine;

                CurrentLine.ParseLine = false;

                _ConditionalStack.Push(CurrentIfDef);

                CurrentObject.ParseLines = CurrentLine.ParseLine;
                CurrentObject.Level = _ConditionalStack.Count;
            }
            else if (Command == FunctionID.ELSE)
            {
                if (_ConditionalStack.Count == 0)
                {
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "ELSE without matching IF");
                    Success = false;
                    CurrentObject.Error = true;
                }

                if (!_ConditionalStack.First().SavedParse)
                    CurrentLine.ParseLine = false;

                else
                    CurrentLine.ParseLine = !CurrentLine.ParseLine;

                CurrentObject.Level = _ConditionalStack.Count;
                CurrentObject.ParseLines = CurrentLine.ParseLine;
            }
            else if (Command == FunctionID.ENDIF)
            {
                CurrentObject.Level = _ConditionalStack.Count;

                if (_ConditionalStack.Count == 0)
                {
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "ENDIF without matching IF");
                    Success = false;
                    CurrentObject.Error = true;
                }
                else
                {
                    CurrentLine.ParseLine = _ConditionalStack.First().SavedParse;
                    _ConditionalStack.Pop();
                }

                CurrentObject.ParseLines = CurrentLine.ParseLine;
            }

            InputTokenizer.FlushLine();
            return Success;
        }



        bool ProcessInclude(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer, FunctionID Command)
        {
            IncludeObject NewObject = new IncludeObject();
            CurrentLine.Object = NewObject;

            Token Param = InputTokenizer.GetNextTokenAsString();

            if (Param.Type == TokenType.LineBreak || Param.Type == TokenType.Comment || Param.Type == TokenType.End)
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "Missing file name in INCLUDE command");
                if (Param.Type == TokenType.Comment)
                    InputTokenizer.FlushLine();

                NewObject.Error = true;
                return false;
            }

            string FileName = Param.StringValue;

            Param = InputTokenizer.GetNextToken();
            if (Param.Type != TokenType.LineBreak && Param.Type != TokenType.End)
            {
                InputTokenizer.FlushLine();

                if (Param.Type != TokenType.Comment)
                {
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, Param.Character, MessageCode.SyntaxError, "Extra parameters in INCLUDE command");

                    NewObject.Error = true;
                    return false;
                }
            }

            FileInformation NewFile = OpenFile(FileName);

            if (_FileStack.Contains(NewFile))
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, string.Format("Recursive include of {0}", FileName));

                NewObject.Error = true;
                return false;
            }

            if (NewFile.Stream != null)
            {
                NewFile.Stream.Seek(0, SeekOrigin.Begin);
                NewFile.LineCount = 0;
            }
            else
            {
                try
                {
                    NewFile.Stream = File.OpenRead(NewFile.Path);
                }
                catch (IOException)
                {
                    Message.Add("Include", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.FileNotFound, FileName);

                    NewObject.Error = true;
                    return false;
                }
            }

            NewObject.IncludeFile = NewFile;

            return true;
        }
        
        bool ParseCommand(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer, FunctionID Command)
        {
            bool Success = true;

            // IF, ELSE and ENDIF always get processed even if we're skipping a line.
            if (Command >= FunctionID.IF && Command <= FunctionID.ENDIF)
            {
                return ParseConditional(CurrentLine, CurrentToken, InputTokenizer, Command);
            }

            if (!CurrentLine.ParseLine)
            {
                InputTokenizer.FlushLine();
                return true;
            }

            switch (Command)
            {
                case FunctionID.INCLUDE:
                    return ProcessInclude(CurrentLine, CurrentToken, InputTokenizer, Command);

                case FunctionID.Z80:
                    Settings.OpcodeSet = OpcodeType.z80;
                    DataTables.OpcodeTable = OpcodeData.ZASM.z80OpcodeList;
                    DataTables.OpcodeList = OpcodeData.ZASM.z80Commands;
                    DataTables.ParameterList = DataTables.z80ParameterList;
                    break;

                case FunctionID.i8080:
                    Settings.OpcodeSet = OpcodeType.i8080;
                    DataTables.OpcodeTable = OpcodeData.ZASM.i8080OpcodeList;
                    DataTables.OpcodeList = OpcodeData.ZASM.i8080Commands;
                    DataTables.ParameterList = DataTables.i8080ParameterList;
                    break;

                case FunctionID.GAMEBOY:
                    Settings.OpcodeSet = OpcodeType.GameBoy;
                    DataTables.OpcodeTable = OpcodeData.ZASM.GameBoyOpcodeList;
                    DataTables.OpcodeList = OpcodeData.ZASM.GameBoyCommands;
                    DataTables.ParameterList = DataTables.GameBoyParameterList;
                    break;

                case FunctionID.EXTERN:
                    break;

                case FunctionID.PUBLIC:
                    break;

                case FunctionID.ORG:
                    break;

                case FunctionID.END:
                    break;

                case FunctionID.SECTION:
                    break;

                case FunctionID.SIZE:
                    break;

                case FunctionID.FILL:
                    break;

                case FunctionID.POS:
                    break;

                default:
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.InternalError, "Unknown Command Value!");
                    Success = false;
                    break;
            }

            InputTokenizer.FlushLine();

            return Success;
        }
        
        bool ParseLabel(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer)
        {
            bool Success = true;

            if (!CurrentLine.ParseLine)
            {
                InputTokenizer.FlushLine();
                return true;
            }

            SymbolTableEntry Symbol = _SymbolTable[CurrentToken.StringValue];
            Symbol.ReferencedLines.Add(CurrentLine);

            if (Symbol.State != SymbolState.Undefined)
            {
                Message.Add("Phase 1", CurrentLine.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.SyntaxError, string.Format("{0} redefined", Symbol.Name));
                Success = false;
            }
            else
            {
                Symbol.Type = SymbolType.Address;
                Symbol.State = SymbolState.Set;
                Symbol.DefiendLine = CurrentLine;
                Symbol.Value = _CurrentAddress;
            }

            // If it ends in a colon, strip it off
            if (InputTokenizer.PeekNextInputType() == InputType.Colon)
                InputTokenizer.GetNextToken();


            // Labels are special as they don't end a line, so there can an opcode (or psudo opcode) after it.
            CurrentToken = GetFirstToken(InputTokenizer);
            if (CurrentToken.Type == TokenType.End || CurrentToken.Type == TokenType.LineBreak)
                return Success;

            if (CurrentToken.Type != TokenType.Data && CurrentToken.Type != TokenType.Opcode && CurrentToken.Type != TokenType.Comment)
            {
                Message.Add("Phase 1", CurrentLine.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.SyntaxError, "Only opcodes allowed after a label");
                InputTokenizer.FlushLine();
                return false;
            }

            return ParseNextToken(CurrentLine, CurrentToken, InputTokenizer);
        }

        // Gets the first token for a line
        Token GetFirstToken(Tokenizer InputTokenizer)
        {
            Token CurrentToken = InputTokenizer.GetNextToken();

            if (CurrentToken.Type == TokenType.Identifier)
            {
                if (InputTokenizer.PeekNextInputType() == InputType.Colon)
                {
                    CurrentToken.Type = TokenType.Label;
                }
                else if (CurrentToken.StringValue[0] == '.') // Command
                {
                    CurrentToken.Type = TokenType.Command;
                }
                else
                {
                    string Command = CurrentToken.StringValue.ToUpper();

                    if (DataTables.PsudoOpcodes.ContainsKey(Command))
                    {
                        CurrentToken.Type = TokenType.Data;
                    }
                    else if (Settings.CommandRequiresDot != Setting.On && DataTables.Commands.ContainsKey(Command))
                    {
                        CurrentToken.Type = TokenType.Command;
                    }
                    else if (DataTables.OpcodeList.ContainsKey(Command))
                    {
                        CurrentToken.Type = TokenType.Opcode;
                    }
                }
            }

            return CurrentToken;
        }

        bool ParseNextToken(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer)
        {
            bool Success = true;

            switch (CurrentToken.Type)
            {
                case TokenType.End:
                case TokenType.LineBreak:
                    break;

                case TokenType.Comment:
                    InputTokenizer.FlushLine();
                    break;

                case TokenType.Label:
                    Success = ParseLabel(CurrentLine, CurrentToken, InputTokenizer);
                    break;

                case TokenType.Command:
                    {
                        string Command = CurrentToken.StringValue.ToUpper();

                        if (Command[0] == '.')
                        {
                            Command = Command.Substring(1);
                        }
                        else if (Settings.CommandRequiresDot == Setting.Warning)
                        {
                            Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.CommandRequiresDotPrefix, CurrentToken.StringValue);
                        }

                        if (DataTables.Commands.ContainsKey(Command))
                        {
                            Success = ParseCommand(CurrentLine, CurrentToken, InputTokenizer, DataTables.Commands[Command]);
                        }
                        else
                        {
                            Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.UnknownCommand, CurrentToken.StringValue);
                            InputTokenizer.FlushLine();
                            Success = false;
                        }
                    }
                    break;

                case TokenType.Data:
                case TokenType.Opcode:
                case TokenType.Identifier:
                    InputTokenizer.FlushLine();
                    break;

                default:
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.UnexpectedSymbol, CurrentToken.TokenData);
                    InputTokenizer.FlushLine();
                    Success = false;
                    break;
            }

            return Success;
        }
               
        bool Phase1(FileInformation InputFile)
        {
            LineInformation CurrentLine = null;
            bool Success = true;
            bool ParseLine = true;

            if (InputFile.Stream == null)
            {
                Message.Add("Pass 1", InputFile.FileID, 0, 0, MessageCode.InternalError, "File Stream Missing");
                return false;
            }

            Tokenizer InputTokenizer = new Tokenizer(InputFile.FileID, InputFile.Stream);
            InputFile.LineCount = 0;
            while (true)
            {
                Success = true;
                InputFile.LineCount++;

                if (CurrentLine == null)
                {
                    CurrentLine = new LineInformation();
                    CurrentLine.FileID = InputFile.FileID;
                    CurrentLine.LineNumber = InputTokenizer.CurrentLine;
                    CurrentLine.ParseLine = ParseLine;
                }

                Token CurrentToken = GetFirstToken(InputTokenizer);
                if (CurrentToken.Type == TokenType.End)
                    break;

                if (CurrentLine.LineNumber != InputFile.LineCount)
                {
                    Message.Add("Phase 1", InputFile.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.InternalError, "File Input Dysync");
                    Success = false;
                }
                else
                {
                    Success = ParseNextToken(CurrentLine, CurrentToken, InputTokenizer);
                }

                ParseLine = CurrentLine.ParseLine;
                _ParseData.Add(CurrentLine);

                if (CurrentLine.Object != null && CurrentLine.Object.Type == ObjectType.Include && !CurrentLine.Object.Error)
                {
                    IncludeObject Include = CurrentLine.Object as IncludeObject;
                    _FileStack.Push(Include.IncludeFile);
                    Success = Phase1(Include.IncludeFile);

                    if (_FileStack.First() != Include.IncludeFile)
                    {
                        Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, 0, MessageCode.InternalError, "File Stack desync");
                    }
                    else
                    {
                        _FileStack.Pop();
                    }
                }

                CurrentLine = null;
            }

            return Success;
        }
    }
}
