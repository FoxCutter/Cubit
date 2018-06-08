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

                if (CurrentLine.ParseLine)
                {
                    ParameterInformation Paramater = null;

                    CurrentToken = InputTokenizer.GetNextToken();

                    if (CurrentToken.Type != TokenType.LineBreak && CurrentToken.Type != TokenType.End && CurrentToken.Type != TokenType.Comment)
                        Paramater = ParseParam(CurrentLine, CurrentToken, InputTokenizer);

                    if (Paramater == null)
                    {
                        Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "Paramater missing");
                        Success = false;
                        CurrentObject.Error = true;
                    }

                    CurrentToken = InputTokenizer.GetNextToken();

                    if (CurrentToken.Type != TokenType.LineBreak && CurrentToken.Type != TokenType.End && CurrentToken.Type != TokenType.Comment)
                    {
                        Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "To many Paramaters");
                        Success = false;
                        CurrentObject.Error = true;

                    }
                    if (CurrentToken.Type != TokenType.LineBreak && CurrentToken.Type != TokenType.End)
                        InputTokenizer.FlushLine();




                    if (Paramater.Tokens[0].Type == TokenType.Number)
                    {
                        CurrentLine.ParseLine = Paramater.Tokens[0].NumericValue != 0;
                    }
                    else
                    {
                        CurrentLine.ParseLine = false;
                    }
                }
                else
                {
                    InputTokenizer.FlushLine();
                }

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
                else
                {
                    if (!_ConditionalStack.First().SavedParse)
                        CurrentLine.ParseLine = false;

                    else
                        CurrentLine.ParseLine = !CurrentLine.ParseLine;
                }

                CurrentObject.Level = _ConditionalStack.Count;
                CurrentObject.ParseLines = CurrentLine.ParseLine;

                InputTokenizer.FlushLine();

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

                InputTokenizer.FlushLine();
            }

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
            if (NewFile == null)
            {
                Message.Add("Include", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.FileNotFound, FileName);

                NewObject.Error = true;
                return false;
            }

            if (_FileStack.Where(e => e.FileName.Equals(FileName, StringComparison.OrdinalIgnoreCase)).Count() != 0)
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
                NewFile.Stream = File.OpenRead(NewFile.Path);
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

            if (Success)
            {
                CommandObject NewObject = new CommandObject();
                NewObject.Command = Command;
                CurrentLine.Object = NewObject;
            }
            
            InputTokenizer.FlushLine();

            return Success;
        }
        
        bool ParseLabel(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer, Token NextToken = null)
        {
            bool Success = true;

            if (!CurrentLine.ParseLine)
            {
                InputTokenizer.FlushLine();
                return true;
            }

            LabelObject NewObject = new LabelObject();
            NewObject.Address = _CurrentAddress;
            CurrentLine.Label = NewObject;
            
            SymbolTableEntry Symbol = _SymbolTable[CurrentToken.StringValue];
            Symbol.ReferencedLines.Add(CurrentLine);
            NewObject.Symbol = Symbol;

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

            if (NextToken == null)
            {
                // If it ends in a colon, strip it off
                if (InputTokenizer.PeekNextInputType() == InputType.Colon)
                    InputTokenizer.GetNextToken();

                // Labels are special as they don't end a line, so there can an opcode (or psudo opcode) after it.
                CurrentToken = GetFirstToken(InputTokenizer);
            }
            else
            {
                CurrentToken = GetFirstToken(InputTokenizer, NextToken);
            }

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


        ParameterInformation ParseParam(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer)
        {
            ParameterInformation NewParam = new ParameterInformation();

            while (true)
            {
                if (CurrentToken.Type == TokenType.Identifier)
                {
                    string Parameter = CurrentToken.StringValue.ToUpper();
                    
                    if (DataTables.ParameterList.ContainsKey(Parameter))
                    {
                        CurrentToken.ParameterID = DataTables.ParameterList[Parameter];

                        if (CurrentToken.ParameterID <= OpcodeData.ParameterID.RegisterMax)
                            CurrentToken.Type = TokenType.Register;

                        else if (CurrentToken.ParameterID <= OpcodeData.ParameterID.FlagsMax)
                            CurrentToken.Type = TokenType.Flag;
                    }
                }

                NewParam.Tokens.Add(CurrentToken);

                InputType NextToken = InputTokenizer.PeekNextInputType();

                if (NextToken == InputType.End || NextToken == InputType.CarriageReturn || NextToken == InputType.LineFeed)
                    break;
                
                CurrentToken = InputTokenizer.GetNextToken();
                if (CurrentToken.CharacterType == InputType.Comma || CurrentToken.Type == TokenType.Comment)
                    break;
            }

            return NewParam;
        }

        bool ParseOpcode(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer, OpcodeData.CommandID Opcode)
        {
            bool Success = true;

            if (!CurrentLine.ParseLine)
            {
                InputTokenizer.FlushLine();
                return true;
            }

            var OpcodeList = DataTables.OpcodeTable.Where(e => e.Name == Opcode).ToList();

            if (OpcodeList.Count() == 0)
            {
                Message.Add("Phase 1", CurrentLine.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.InternalError, "Opcode Table Entry Missing");
                InputTokenizer.FlushLine();
                return false;
            }

            OpcodeObject NewObject = new OpcodeObject();
            CurrentLine.Object = NewObject;

            NewObject.Address = _CurrentAddress;
            NewObject.CycleCount = _CycleCount;

            while (true)
            {
                CurrentToken = InputTokenizer.GetNextToken();
                if (CurrentToken.Type == TokenType.LineBreak || CurrentToken.Type == TokenType.End || CurrentToken.Type == TokenType.Comment)
                    break;

                NewObject.ParamterList.Add(ParseParam(CurrentLine, CurrentToken, InputTokenizer));
            }

            if (CurrentToken.Type != TokenType.LineBreak && CurrentToken.Type != TokenType.End)
                InputTokenizer.FlushLine();

            

            NewObject.Opcode = OpcodeList[0];

            _CurrentAddress += OpcodeList[0].Length;
            _CycleCount += NewObject.Opcode.Cycles;

            return Success;
        }

        bool ParseIdentifier(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer)
        {
            bool Success = true;

            if (!CurrentLine.ParseLine)
            {
                InputTokenizer.FlushLine();
                return true;
            }
            
            // What we do with the Identifier will depend on what comes next.
            Token NextToken = InputTokenizer.GetNextToken();

            if (NextToken.Type == TokenType.LineBreak || NextToken.Type == TokenType.End || NextToken.Type == TokenType.Comment)
            {
                // If it's the identifier on the a line by itself it's a label
                CurrentToken.Type = TokenType.Label;
            }
            else if (NextToken.Type == TokenType.Identifier)
            {
                string Command = NextToken.StringValue.ToUpper();

                if (DataTables.PsudoOpcodes.ContainsKey(Command))
                {
                    FunctionID CommandID = DataTables.PsudoOpcodes[Command];

                    if (CommandID == FunctionID.EQU || CommandID == FunctionID.DEFL)
                        NextToken.Type = TokenType.Assignment;
                    else
                        CurrentToken.Type = TokenType.Label;
                }
                else if (DataTables.OpcodeList.ContainsKey(Command))
                {
                    CurrentToken.Type = TokenType.Label;
                }
            }

            if (CurrentToken.Type == TokenType.Label)
            {
                if (Settings.LabelsRequireColon != Setting.On)
                {
                    if (Settings.LabelsRequireColon == Setting.Warning)
                    {
                        Message.Add("Phase 1", CurrentLine.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.SyntaxWarning, "Label defined with a ':'");
                    }
                    
                    return ParseLabel(CurrentLine, CurrentToken, InputTokenizer, NextToken);
                }
                else
                {
                    Message.Add("Phase 1", CurrentLine.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.UnknownCommand, CurrentToken.StringValue);
                    InputTokenizer.FlushLine();
                    return false;
                }
            }
            else if (CurrentToken.Type == TokenType.Identifier && NextToken.Type != TokenType.Assignment)
            {
                Message.Add("Phase 1", CurrentLine.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.UnknownCommand, CurrentToken.StringValue);
                InputTokenizer.FlushLine();
                return false;
            }

            // So after all that what we have left is an assignment
            SymbolTableEntry Symbol = _SymbolTable[CurrentToken.StringValue];
            Symbol.ReferencedLines.Add(CurrentLine);

            ParameterInformation Paramater = null;
            CurrentToken = InputTokenizer.GetNextToken();



            if (CurrentToken.Type != TokenType.LineBreak && CurrentToken.Type != TokenType.End && CurrentToken.Type != TokenType.Comment)
                Paramater = ParseParam(CurrentLine, CurrentToken, InputTokenizer);

            if (Paramater == null)
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "Paramater missing");
                Success = false;
                //CurrentObject.Error = true;
            }
            else
            {
                CurrentToken = InputTokenizer.GetNextToken();

                if (CurrentToken.Type != TokenType.LineBreak && CurrentToken.Type != TokenType.End && CurrentToken.Type != TokenType.Comment)
                {
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "To many Paramaters");
                    Success = false;
                    //CurrentObject.Error = true;

                }

                LabelObject CurrentObject = new LabelObject();
                CurrentObject.Address = _CurrentAddress;
                CurrentObject.Symbol = Symbol;

                Symbol.Type = SymbolType.Constant;
                Symbol.State = SymbolState.Set;
                Symbol.DefiendLine = CurrentLine;
                if (Paramater != null)
                    Symbol.Value = (short)Paramater.Tokens[0].NumericValue;


                CurrentLine.Object = CurrentObject;
            }

            if (CurrentToken.Type != TokenType.LineBreak && CurrentToken.Type != TokenType.End)
                InputTokenizer.FlushLine();

            return Success;
        }

        // Gets the first token for a line
        Token GetFirstToken(Tokenizer InputTokenizer)
        {
            Token CurrentToken = InputTokenizer.GetNextToken();
            return GetFirstToken(InputTokenizer, CurrentToken);
        }
        
        Token GetFirstToken(Tokenizer InputTokenizer, Token CurrentToken)
        {
            
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

                case TokenType.Opcode:
                    Success = ParseOpcode(CurrentLine, CurrentToken, InputTokenizer, DataTables.OpcodeList[CurrentToken.StringValue.ToUpper()]);
                    break;

                case TokenType.Identifier:
                    Success = ParseIdentifier(CurrentLine, CurrentToken, InputTokenizer);
                    break;
                
                case TokenType.Data:
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
