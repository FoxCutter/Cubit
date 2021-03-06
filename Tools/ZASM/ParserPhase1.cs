﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZASM
{
    partial class Parser
    {
        private const Setting off = Setting.Off;

        bool IsBreakType(Token CurrentToken)
        {
            if (CurrentToken.Type == TokenType.LineBreak || CurrentToken.Type == TokenType.End || CurrentToken.Type == TokenType.Comment)
                return true;

            return false;
        }

        void FlushLine(Token CurrentToken, Tokenizer InputTokenizer)
        {
            if (CurrentToken.Type == TokenType.LineBreak || CurrentToken.Type == TokenType.End)
                return;

            InputTokenizer.FlushLine();
        }

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

                    if (!IsBreakType(CurrentToken))
                        Paramater = ParseParam(CurrentLine, CurrentToken, InputTokenizer);

                    if (Paramater == null)
                    {
                        Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "Paramater missing");
                        Success = false;
                        CurrentObject.Error = true;
                    }

                    CurrentToken = InputTokenizer.GetNextToken();

                    if (!IsBreakType(CurrentToken))
                    {
                        Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "To many Paramaters");
                        Success = false;
                        CurrentObject.Error = true;

                    }

                    if (Paramater.Tokens[0].Type == TokenType.Number)
                    {
                        CurrentLine.ParseLine = Paramater.Tokens[0].NumericValue != 0;
                    }
                    else
                    {
                        CurrentLine.ParseLine = false;
                    }
                }

                CurrentObject.Conditional = CurrentIfDef;
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
                    CurrentObject.Conditional = _ConditionalStack.First();
                    
                    if (!_ConditionalStack.First().SavedParse)
                        CurrentLine.ParseLine = false;

                    else
                        CurrentLine.ParseLine = !CurrentLine.ParseLine;
                }

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
                    CurrentObject.Conditional = _ConditionalStack.First();
                    CurrentLine.ParseLine = _ConditionalStack.First().SavedParse;
                    _ConditionalStack.Pop();
                }

                CurrentObject.ParseLines = CurrentLine.ParseLine;
            }

            FlushLine(CurrentToken, InputTokenizer);

            return Success;
        }

        bool ProcessInclude(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer, FunctionID Command)
        {
            IncludeObject NewObject = new IncludeObject();
            CurrentLine.Object = NewObject;

            CurrentToken = InputTokenizer.GetNextTokenAsString();

            if (IsBreakType(CurrentToken))
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "Missing file name in INCLUDE command");
                FlushLine(CurrentToken, InputTokenizer);

                NewObject.Error = true;
                return false;
            }

            string FileName = CurrentToken.StringValue;

            CurrentToken = InputTokenizer.GetNextToken();

            FlushLine(CurrentToken, InputTokenizer);

            if (!IsBreakType(CurrentToken))
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "Extra parameters in INCLUDE command");

                NewObject.Error = true;
                return false;
            }

            FileInformation NewFile = FindFile(FileName);
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
            }
            else
            {
                NewFile.Stream = File.OpenRead(NewFile.Path);
            }

            NewFile.LineCount = 0; 
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
                FlushLine(CurrentToken, InputTokenizer);
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

            FlushLine(CurrentToken, InputTokenizer);

            return Success;
        }
        
        bool ParseLabel(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer, Token NextToken = null)
        {
            bool Success = true;

            LabelObject NewObject = new LabelObject();
            NewObject.Address = _CurrentAddress;
            CurrentLine.Label = NewObject;
            
            SymbolTableEntry Symbol = _SymbolTable[CurrentToken.StringValue];
            Symbol.ReferencedLines.Add(CurrentLine);
            NewObject.Symbol = Symbol;

            if (Symbol.State != SymbolState.Undefined)
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.SyntaxError, string.Format("{0} redefined", Symbol.Name));
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
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.UnknownCommand, CurrentToken.StringValue);
                FlushLine(NextToken ?? CurrentToken, InputTokenizer);
                return false;
            }

            return ParseNextToken(CurrentLine, CurrentToken, InputTokenizer);
        }

        bool IsIndexRegister(OpcodeData.ParameterID ParameterID)
        {
            if (ParameterID == OpcodeData.ParameterID.IX || ParameterID == OpcodeData.ParameterID.IY)
                return true;

            if (ParameterID == OpcodeData.ParameterID.IXL || ParameterID == OpcodeData.ParameterID.IYL)
                return true;

            if (ParameterID == OpcodeData.ParameterID.IXH || ParameterID == OpcodeData.ParameterID.IYH)
                return true;

            return false;
        }

        bool AssumeA(OpcodeData.CommandID CommandID)
        {
            if (Settings.AssumeA == Setting.Off)
                return false;

            if (CommandID == OpcodeData.CommandID.ADC || CommandID == OpcodeData.CommandID.ADD ||
                CommandID == OpcodeData.CommandID.SUB || CommandID == OpcodeData.CommandID.SBC ||
                CommandID == OpcodeData.CommandID.OR || CommandID == OpcodeData.CommandID.XOR ||
                CommandID == OpcodeData.CommandID.AND || CommandID == OpcodeData.CommandID.CP ||
                CommandID == OpcodeData.CommandID.IN || CommandID == OpcodeData.CommandID.OUT ||
                CommandID == OpcodeData.CommandID.CPL)
                return true;

            return false;
        }

        Token GetIdentifierToken(Tokenizer InputTokenizer, Token CurrentToken)
        {
            if (CurrentToken.Type == TokenType.Identifier)
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
                else if (DataTables.ParameterList.ContainsKey(Command))
                {
                    CurrentToken.ParameterID = DataTables.ParameterList[Command];

                    // If indexs are off, treat them as identifiers. 
                    if (Settings.Indexes == Setting.Off && IsIndexRegister(CurrentToken.ParameterID))
                        CurrentToken.ParameterID = OpcodeData.ParameterID.None;

                    else if (CurrentToken.ParameterID <= OpcodeData.ParameterID.RegisterMax)
                        CurrentToken.Type = TokenType.Register;

                    else if (CurrentToken.ParameterID <= OpcodeData.ParameterID.FlagsMax)
                    {
                        // Only "CY" maps to FLAG_C where "C" maps to the ParamaterID.C, is of CY as Carry is off let CY fall back to an identifier
                        if (CurrentToken.ParameterID == OpcodeData.ParameterID.Flag_C && Settings.CYAsCarry == off)
                        {
                            CurrentToken.ParameterID = OpcodeData.ParameterID.None;
                        }
                        else
                        {
                            CurrentToken.Type = TokenType.Flag;
                        }
                    }
                }
            }

            return CurrentToken;
        }


        ParameterInformation ParseParam(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer)
        {
            ParameterInformation NewParam = new ParameterInformation();

            // Just to keep track of group openings so we can close them in order
            Stack<TokenType> GroupStack = new Stack<TokenType>();

            while (true)
            {
                CurrentToken = GetIdentifierToken(InputTokenizer, CurrentToken);

                switch (CurrentToken.Type)
                {
                    case TokenType.Identifier:
                        break;

                    case TokenType.GroupLeft:
                    case TokenType.ArrayLeft:
                        GroupStack.Push(CurrentToken.Type);
                        break;

                    case TokenType.GroupRight:
                    case TokenType.ArrayRight:
                        if (GroupStack.Count == 0)
                        {
                            if ( CurrentToken.Type == TokenType.GroupRight)
                            {
                                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.MissingGroupSymbol, "Opening '('");
                                NewParam.Error = true;
                            }
                            else if (CurrentToken.Type == TokenType.ArrayRight)
                            {
                                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.MissingGroupSymbol, "Opering '['");
                                NewParam.Error = true;
                            }
                        }
                        else
                        {
                            TokenType OldGroup = GroupStack.Pop();

                            // Make sure the groups match.
                            if (OldGroup == TokenType.GroupLeft && CurrentToken.Type != TokenType.GroupRight)
                            {
                                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.MissingGroupSymbol, "Expected ')' found ']'");
                                NewParam.Error = true;
                            }
                            else if (OldGroup == TokenType.ArrayLeft && CurrentToken.Type != TokenType.ArrayRight)
                            {
                                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.MissingGroupSymbol, "Expected ']' found ')'");
                                NewParam.Error = true;
                            }
                        }
                        break;

                    case TokenType.Command:
                    case TokenType.Opcode:
                    case TokenType.Data:
                        Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.ReservedWord, CurrentToken.StringValue);
                        NewParam.Error = true;
                        break;

                    case TokenType.Plus:
                        if (NewParam.Tokens.Count == 0)
                        {
                            CurrentToken.Type = TokenType.UnarrayPlus;
                        }
                        else
                        {
                            Token LastToken = NewParam.Tokens.Last();

                            // Check for HL+ on the gameboy
                            if (LastToken.ParameterID == OpcodeData.ParameterID.HL && Settings.OpcodeSet == OpcodeType.GameBoy)
                            {
                                LastToken.ParameterID = OpcodeData.ParameterID.HLI;
                                CurrentToken.Type = TokenType.None;
                            }
                            
                            if(LastToken.Type != TokenType.Number && LastToken.Type != TokenType.Identifier && LastToken.Type != TokenType.Register && LastToken.Type != TokenType.String)
                                CurrentToken.Type = TokenType.UnarrayPlus;
                        }
                        break;

                    case TokenType.Minus:
                        if (NewParam.Tokens.Count == 0)
                        {
                            CurrentToken.Type = TokenType.UnarrayMinus;
                        }
                        else
                        {
                            Token LastToken = NewParam.Tokens.Last();

                            // Check for HL- on the gameboy
                            if (LastToken.ParameterID == OpcodeData.ParameterID.HL && Settings.OpcodeSet == OpcodeType.GameBoy)
                            {
                                LastToken.ParameterID = OpcodeData.ParameterID.HLD;
                                CurrentToken.Type = TokenType.None;
                            }

                            if (LastToken.Type != TokenType.Number && LastToken.Type != TokenType.Identifier && LastToken.Type != TokenType.Register && LastToken.Type != TokenType.String)
                                CurrentToken.Type = TokenType.UnarrayMinus;
                        }                        
                        break;
                }


                if(CurrentToken.Type != TokenType.None)
                    NewParam.Tokens.Add(CurrentToken);

                InputType NextToken = InputTokenizer.PeekNextInputType();

                if (NextToken == InputType.End || NextToken == InputType.CarriageReturn || NextToken == InputType.LineFeed)
                    break;
                
                CurrentToken = InputTokenizer.GetNextToken();
                if (CurrentToken.CharacterType == InputType.Comma || CurrentToken.Type == TokenType.Comment)
                    break;
            }

            // Check for any groups there were opened bu never closed
            while (GroupStack.Count != 0)
            {
                TokenType OldGroup = GroupStack.Pop();
                if (OldGroup == TokenType.GroupLeft)
                {
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.MissingGroupSymbol, "Closing ')'");
                    NewParam.Error = true;
                }
                else if (OldGroup == TokenType.ArrayLeft)
                {
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.MissingGroupSymbol, "Closing ']'");
                    NewParam.Error = true;
                }                
            }



            return NewParam;
        }

        bool ParseDataCommand(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer, FunctionID Command)
        {
            bool Success = true;


            FlushLine(CurrentToken, InputTokenizer);
            return Success;
        }
            
        bool ParseOpcode(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer, OpcodeData.CommandID Opcode)
        {
            bool Success = true;

            var OpcodeList = DataTables.OpcodeTable.Where(e => e.Name == Opcode).ToList();

            if (OpcodeList.Count() == 0)
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.InternalError, "Opcode Table Entry Missing");
                FlushLine(CurrentToken, InputTokenizer);
                return false;
            }

            OpcodeObject NewObject = new OpcodeObject();
            CurrentLine.Object = NewObject;

            NewObject.Address = _CurrentAddress;
            NewObject.CycleCount = _CycleCount;

            while (true)
            {
                CurrentToken = InputTokenizer.GetNextToken();
                if (IsBreakType(CurrentToken))
                    break;

                NewObject.ParamterList.Add(ParseParam(CurrentLine, CurrentToken, InputTokenizer));
            }

            if(Settings.OpcodeSet != OpcodeType.i8080 && AssumeA(Opcode) && NewObject.ParamterList.Count <= 1)
            {
                ParameterInformation NewParam = new ParameterInformation();
                NewParam.Parameter = OpcodeData.ParameterID.A;
                NewParam.Type = OpcodeData.ParameterType.ByteRegister;

                Token NewToken = new Token();
                NewToken.Type = TokenType.Register;
                NewToken.ParameterID = OpcodeData.ParameterID.A;

                NewParam.Tokens.Add(NewToken);

                // for out A is the second paramater, for everything else it's the first.
                if (Opcode == OpcodeData.CommandID.OUT)
                    NewObject.ParamterList.Add(NewParam);
                else
                    NewObject.ParamterList.Insert(0, NewParam);

                if(Settings.AssumeA == Setting.Warning)
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.RegisterMissingAssumingA);
            }


            NewObject.Opcode = OpcodeList[0];

            _CurrentAddress += OpcodeList[0].Length;
            _CycleCount += NewObject.Opcode.Cycles;

            FlushLine(CurrentToken, InputTokenizer);

            return Success;
        }

        bool ParseAssignment(LineInformation CurrentLine, Token LabelToken, Token CurrentToken, Tokenizer InputTokenizer, FunctionID CommandID)
        {
            bool Success = true;

            SymbolTableEntry Symbol = _SymbolTable[LabelToken.StringValue];
            Symbol.ReferencedLines.Add(CurrentLine);

            ValueObject CurrentObject = new ValueObject();
            CurrentLine.Object = CurrentObject;

            CurrentObject.Address = _CurrentAddress;
            CurrentObject.Symbol = Symbol;

            if (Symbol.State == SymbolState.Undefined)
            {
                if (CommandID == FunctionID.EQU)
                {
                    Symbol.Type = SymbolType.Constant;
                }
            }
            else if(Symbol.Type == SymbolType.Constant)
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.SyntaxError, string.Format("{0} redefined", Symbol.Name));
                CurrentObject.Error = true;
                FlushLine(CurrentToken, InputTokenizer);
                return false;
            }

            CurrentToken = InputTokenizer.GetNextToken();
            if(!IsBreakType(CurrentToken))
                CurrentObject.Parameter = ParseParam(CurrentLine, CurrentToken, InputTokenizer);

            if (CurrentObject.Parameter == null)
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "Paramater missing");
                CurrentObject.Error = true;
                FlushLine(CurrentToken, InputTokenizer);
                return false;
            }
            else
            {
                CurrentToken = InputTokenizer.GetNextToken();

                if (!IsBreakType(CurrentToken))
                {
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "To many Paramaters");
                    Success = false;
                    CurrentObject.Error = true;
                }
            }


            Symbol.State = SymbolState.Pending;

            if (CurrentObject.Parameter.Tokens[0].Type == TokenType.Number)
            {
                Symbol.State = SymbolState.Set;
                Symbol.Value = (short)CurrentObject.Parameter.Tokens[0].NumericValue;
            }

            FlushLine(CurrentToken, InputTokenizer);

            return Success;
        }


        bool ParseIdentifier(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer)
        {
            // What we do with the Identifier will depend on what comes next.
            Token NextToken = InputTokenizer.GetNextToken();

            FunctionID CommandID = FunctionID.None;

            if (IsBreakType(NextToken))
            {
                // If it's the identifier on the a line by itself it's a label
                CurrentToken.Type = TokenType.Label;
            }
            else if (NextToken.Type == TokenType.Identifier)
            {
                string Command = NextToken.StringValue.ToUpper();

                if (DataTables.PsudoOpcodes.ContainsKey(Command))
                {
                    // If it's a psudo opcode, it's a data command
                    CommandID = DataTables.PsudoOpcodes[Command];

                    // unless it's Assignment
                    if (CommandID == FunctionID.EQU || CommandID == FunctionID.DEFL)
                        NextToken.Type = TokenType.Assignment;
                    else
                        CurrentToken.Type = TokenType.Label;
                }
                else if (DataTables.ParameterList.ContainsKey(Command))
                {
                    CurrentToken.ParameterID = DataTables.ParameterList[Command];

                    // If indexs are off, fall back to it being a label, otherwise it's an error
                    if (Settings.Indexes == Setting.Off && IsIndexRegister(CurrentToken.ParameterID))
                    {
                        CurrentToken.ParameterID = OpcodeData.ParameterID.None;
                        CurrentToken.Type = TokenType.Label;
                    }
                    else
                    {
                        Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, NextToken.Character, MessageCode.ReservedWord, NextToken.StringValue);
                        FlushLine(NextToken, InputTokenizer);
                        return false;
                    }
                }
                else
                {                    
                    CurrentToken.Type = TokenType.Label;
                }
            }
            else if (NextToken.Type == TokenType.Assignment)
            {
                CommandID = FunctionID.EQU;
            }
            else
            {
                CurrentToken.Type = TokenType.Label;

                if (Settings.LabelsRequireColon != Setting.On)
                {
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, NextToken.Character, MessageCode.UnexpectedSymbol, NextToken.TokenData);

                    FlushLine(NextToken, InputTokenizer);
                    return false;
                }
            }

            if (CurrentToken.Type == TokenType.Label)
            {
                if (Settings.LabelsRequireColon != Setting.On)
                {
                    if (Settings.LabelsRequireColon == Setting.Warning)
                    {
                        Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxWarning, "Label defined without a ':'");
                    }

                    return ParseLabel(CurrentLine, CurrentToken, InputTokenizer, NextToken);
                }
                else
                {
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.UnknownCommand, CurrentToken.StringValue);
                    FlushLine(NextToken, InputTokenizer);
                    return false;
                }
            }
            else if (CurrentToken.Type == TokenType.Identifier && NextToken.Type == TokenType.Assignment)
            {
                return ParseAssignment(CurrentLine, CurrentToken, NextToken, InputTokenizer, CommandID);
            }

            Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.InternalError, "Identifier Parsing failed");
            FlushLine(NextToken, InputTokenizer);
            return false;               
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
                    GetIdentifierToken(InputTokenizer, CurrentToken);
                }
            }

            return CurrentToken;
        }

        bool ParseNextToken(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer)
        {
            bool Success = true;

            if (!CurrentLine.ParseLine && CurrentToken.Type != TokenType.Command)
            {
                FlushLine(CurrentToken, InputTokenizer);
                return true;
            }                       
            
            switch (CurrentToken.Type)
            {
                case TokenType.End:
                case TokenType.LineBreak:
                    break;

                case TokenType.Comment:
                    FlushLine(CurrentToken, InputTokenizer);
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
                            FlushLine(CurrentToken, InputTokenizer);
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
                    Success = ParseDataCommand(CurrentLine, CurrentToken, InputTokenizer, DataTables.PsudoOpcodes[CurrentToken.StringValue.ToUpper()]);
                    break;

                case TokenType.Register:
                case TokenType.Flag:
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.ReservedWord, CurrentToken.TokenData);
                    FlushLine(CurrentToken, InputTokenizer);
                    Success = false;
                    break;

                default:
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.UnexpectedSymbol, CurrentToken.TokenData);
                    FlushLine(CurrentToken, InputTokenizer);
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
                    Message.Add("Parser", InputFile.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.InternalError, "File Input Dysync");
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
