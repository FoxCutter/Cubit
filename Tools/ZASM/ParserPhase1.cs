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

        void ParseConditional(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer, FunctionID Command)
        {            
            ConditionalObject CurrentObject = new ConditionalObject(CurrentLine, Command);
            CurrentLine.Object = CurrentObject;

            Debug.Write($" {Command}");

            if (Command == FunctionID.IF)
            {
                ConditionalInformation CurrentIfDef = new ConditionalInformation();
                CurrentIfDef.Line = CurrentLine;
                CurrentIfDef.Result = false;
                CurrentIfDef.SavedParse = CurrentLine.ParseEnabled;

                if (CurrentLine.ParseEnabled)
                {
                    ParameterInformation Paramater = null;

                    CurrentToken = InputTokenizer.GetNextToken();

                    if (!IsBreakType(CurrentToken))
                        Paramater = ParseParam(CurrentLine, CurrentToken, InputTokenizer);

                    if (Paramater == null)
                    {
                        Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "Paramater missing");
                        CurrentLine.Success = false;
                        CurrentObject.Error = true;
                    }

                    CurrentToken = InputTokenizer.GetNextToken();

                    if (!IsBreakType(CurrentToken))
                    {
                        Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "To many Paramaters");
                        CurrentLine.Success = false;
                        CurrentObject.Error = true;

                    }

                    if (Paramater.Tokens[0].Type == TokenType.Number)
                    {
                        CurrentLine.ParseEnabled = Paramater.Tokens[0].NumericValue != 0;
                        Debug.Write($" TRUE");
                    }
                    else
                    {
                        CurrentLine.ParseEnabled = false;
                        Debug.Write($" FALSE");
                    }
                }
                else
                {
                    Debug.Write($" Skipping");
                }

                CurrentObject.Conditional = CurrentIfDef;
                _ConditionalStack.Push(CurrentIfDef);

                CurrentObject.ParseEnabled = CurrentLine.ParseEnabled;
                CurrentObject.Level = _ConditionalStack.Count;
            }
            else if (Command == FunctionID.ELSE)
            {
                if (_ConditionalStack.Count == 0)
                {
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "ELSE without matching IF");
                    CurrentLine.Success = false;
                    CurrentObject.Error = true;
                }
                else
                {
                    CurrentObject.Conditional = _ConditionalStack.First();

                    if (!_ConditionalStack.First().SavedParse)
                        CurrentLine.ParseEnabled = false;

                    else
                        CurrentLine.ParseEnabled = !CurrentLine.ParseEnabled;
                }

                CurrentObject.Level = _ConditionalStack.Count;
                CurrentObject.ParseEnabled = CurrentLine.ParseEnabled;

                if (!CurrentObject.ParseEnabled)
                    Debug.Write($" Skipping");

            }
            else if (Command == FunctionID.ENDIF)
            {
                CurrentObject.Level = _ConditionalStack.Count;

                if (_ConditionalStack.Count == 0)
                {
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "ENDIF without matching IF");
                    CurrentLine.Success = false;
                    CurrentObject.Error = true;
                }
                else
                {
                    CurrentObject.Conditional = _ConditionalStack.First();
                    CurrentLine.ParseEnabled = _ConditionalStack.First().SavedParse;
                    _ConditionalStack.Pop();
                }

                CurrentObject.ParseEnabled = CurrentLine.ParseEnabled;

                if (!CurrentObject.ParseEnabled)
                    Debug.Write($" Skipping");
            }

            FlushLine(CurrentToken, InputTokenizer);
        }

        void ProcessInclude(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer, FunctionID Command)
        {
            IncludeObject NewObject = new IncludeObject();
            CurrentLine.Object = NewObject;

            CurrentToken = InputTokenizer.GetNextTokenAsString();

            if (IsBreakType(CurrentToken))
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "Missing file name in INCLUDE command");
                FlushLine(CurrentToken, InputTokenizer);

                NewObject.Error = true;
                CurrentLine.Success = false;
                return;
            }

            string FileName = CurrentToken.StringValue;

            CurrentToken = InputTokenizer.GetNextToken();

            FlushLine(CurrentToken, InputTokenizer);

            if (!IsBreakType(CurrentToken))
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "Extra parameters in INCLUDE command");

                NewObject.Error = true;
                CurrentLine.Success = false;
                return;
            }

            FileInformation NewFile = FindFile(FileName);
            if (NewFile == null)
            {
                Message.Add("Include", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.FileNotFound, FileName);

                NewObject.Error = true;
                CurrentLine.Success = false;
                return;
            }

            if (FileStack.Where(e => e.FileName.Equals(FileName, StringComparison.OrdinalIgnoreCase)).Count() != 0)
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, string.Format("Recursive include of {0}", FileName));

                NewObject.Error = true;
                CurrentLine.Success = false;
                return;
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
        }

        void ParseCommand(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer, FunctionID Command)
        {
            bool Success = true;

            // IF, ELSE and ENDIF always get processed even if we're skipping a line.
            if (Command >= FunctionID.IF && Command <= FunctionID.ENDIF)
            {
                ParseConditional(CurrentLine, CurrentToken, InputTokenizer, Command);
                return;
            }

            if (!CurrentLine.ParseEnabled)
            {
                Debug.Write($" Skipping");
                FlushLine(CurrentToken, InputTokenizer);
                return;
            }

            Debug.Write($" {Command}");

            switch (Command)
            {
                case FunctionID.INCLUDE:
                    ProcessInclude(CurrentLine, CurrentToken, InputTokenizer, Command);
                    return;

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
                    Debug.Write(" Not Implemented");
                    break;

                case FunctionID.PUBLIC:
                    Debug.Write(" Not Implemented");
                    break;

                case FunctionID.ORG:
                    Debug.Write(" Not Implemented");
                    break;

                case FunctionID.END:
                    Debug.Write(" Not Implemented");
                    break;

                case FunctionID.SECTION:
                    Debug.Write(" Not Implemented");
                    break;

                case FunctionID.SIZE:
                    Debug.Write(" Not Implemented");
                    break;

                case FunctionID.FILL:
                    Debug.Write(" Not Implemented");
                    break;

                case FunctionID.POS:
                    Debug.Write(" Not Implemented");
                    break;

                default:
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.InternalError, "Unknown Command Value!");
                    CurrentLine.Success = false;
                    break;
            }

            if (Success)
            {
                CommandObject NewObject = new CommandObject();
                NewObject.Command = Command;
                CurrentLine.Object = NewObject;
            }

            FlushLine(CurrentToken, InputTokenizer);
        }

        void ParseLabel(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer)
        {
            Debug.Write($" {CurrentToken.StringValue}");

            LabelObject NewObject = new LabelObject();
            NewObject.Address = _CurrentAddress;
            CurrentLine.Label = NewObject;

            SymbolTableEntry Symbol = _SymbolTable[CurrentToken.StringValue];
            Symbol.ReferencedLines.Add(CurrentLine);
            NewObject.Symbol = Symbol;

            if (Symbol.State != SymbolState.Undefined)
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.SyntaxError, string.Format("{0} redefined", Symbol.Name));
                CurrentLine.Success = false;
            }
            else
            {
                Symbol.Type = SymbolType.Address;
                Symbol.State = SymbolState.Set;
                Symbol.DefiendLine = CurrentLine;
                Symbol.Value = _CurrentAddress;
            }

            // If we have a double Colon, mark it as exported
            if (InputTokenizer.PeekNextInputType() == InputType.Colon)
            {
                InputTokenizer.GetNextToken();
                Symbol.Visability = SymbolVisability.Public;
            }

            CurrentToken = GetFirstToken(InputTokenizer);

            if (CurrentToken.Type == TokenType.End || CurrentToken.Type == TokenType.LineBreak)
            {
                return;
            }
            else if (CurrentToken.Type != TokenType.PsudoOpcode && CurrentToken.Type != TokenType.Opcode && CurrentToken.Type != TokenType.Comment)
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.UnknownCommand, CurrentToken.StringValue);
                FlushLine(CurrentToken, InputTokenizer);
                CurrentLine.Success = false;
            }
            else
            {
                ParseToken(CurrentLine, CurrentToken, InputTokenizer);
            }

            return;
        }

        bool IsIndexRegister(OpcodeData.ParameterID ParameterID)
        {
            if (ParameterID == OpcodeData.ParameterID.WordReg_IX || ParameterID == OpcodeData.ParameterID.WordReg_IY)
                return true;

            if (ParameterID == OpcodeData.ParameterID.ByteReg_IXL || ParameterID == OpcodeData.ParameterID.ByteReg_IYL)
                return true;

            if (ParameterID == OpcodeData.ParameterID.ByteReg_IXH || ParameterID == OpcodeData.ParameterID.ByteReg_IYH)
                return true;

            return false;
        }

        bool ImplicitA(OpcodeData.CommandID CommandID)
        {
            if (Settings.ImplicitA == Setting.Off)
                return false;

            if (CommandID == OpcodeData.CommandID.ADC || CommandID == OpcodeData.CommandID.ADD ||
                CommandID == OpcodeData.CommandID.SUB || CommandID == OpcodeData.CommandID.SBC ||
                CommandID == OpcodeData.CommandID.OR || CommandID == OpcodeData.CommandID.XOR ||
                CommandID == OpcodeData.CommandID.AND || CommandID == OpcodeData.CommandID.CP ||
                CommandID == OpcodeData.CommandID.CPL || CommandID == OpcodeData.CommandID.NEG)
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
                    CurrentToken.Type = TokenType.PsudoOpcode;
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
                        // Only "CY" maps to FLAG_CY where "C" maps to the ParamaterID.Reg_C, so if CY as Carry is off let CY fall back to an identifier
                        if (CurrentToken.ParameterID == OpcodeData.ParameterID.Flag_CY && Settings.CYAsCarry == off)
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
                            if (CurrentToken.Type == TokenType.GroupRight)
                            {
                                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.MissingGroupSymbol, "Opening '('");
                                NewParam.Error = true;
                            }
                            else if (CurrentToken.Type == TokenType.ArrayRight)
                            {
                                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.MissingGroupSymbol, "Opening '['");
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
                    case TokenType.PsudoOpcode:
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
                            if (LastToken.ParameterID == OpcodeData.ParameterID.WordReg_HL && Settings.OpcodeSet == OpcodeType.GameBoy)
                            {
                                LastToken.ParameterID = OpcodeData.ParameterID.WordReg_HLI;
                                CurrentToken.Type = TokenType.None;
                            }

                            if (LastToken.Type != TokenType.Number && LastToken.Type != TokenType.Identifier && LastToken.Type != TokenType.Register && LastToken.Type != TokenType.String)
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
                            if (LastToken.ParameterID == OpcodeData.ParameterID.WordReg_HL && Settings.OpcodeSet == OpcodeType.GameBoy)
                            {
                                LastToken.ParameterID = OpcodeData.ParameterID.WordReg_HLD;
                                CurrentToken.Type = TokenType.None;
                            }

                            if (LastToken.Type != TokenType.Number && LastToken.Type != TokenType.Identifier && LastToken.Type != TokenType.Register && LastToken.Type != TokenType.String)
                                CurrentToken.Type = TokenType.UnarrayMinus;
                        }
                        break;
                }


                if (CurrentToken.Type != TokenType.None)
                {
                    NewParam.Tokens.Add(CurrentToken);
                }

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

            Debug.Write($" [{string.Join(" ", NewParam.Tokens)}]");

            if (NewParam.Error)
                CurrentLine.Success = false;

            return NewParam;
        }

        void ParsePsudoOpcode(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer, FunctionID Command)
        {
            Debug.Write($" {Command}");

            FlushLine(CurrentToken, InputTokenizer);
        }

        void ParseOpcode(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer, OpcodeData.CommandID Opcode)
        {
            Debug.Write($" {Opcode}");

            var OpcodeList = DataTables.OpcodeTable.Where(e => e.Name == Opcode).ToList();

            if (OpcodeList.Count() == 0)
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.InternalError, "Opcode Table Entry Missing");
                FlushLine(CurrentToken, InputTokenizer);
                CurrentLine.Success = false;
                return;
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

            if (Settings.OpcodeSet != OpcodeType.i8080 && ImplicitA(Opcode) && NewObject.ParamterList.Count <= 1)
            {
                ParameterInformation NewParam = new ParameterInformation();
                NewParam.Parameter = OpcodeData.ParameterID.ByteReg_A;
                NewParam.Type = OpcodeData.ParameterType.ByteRegister;

                Token NewToken = new Token();
                NewToken.Type = TokenType.Register;
                NewToken.ParameterID = OpcodeData.ParameterID.ByteReg_A;

                NewParam.Tokens.Add(NewToken);

                NewObject.ParamterList.Insert(0, NewParam);

                if (Settings.ImplicitA == Setting.Warning)
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.ImplicitA);
            }


            NewObject.Opcode = OpcodeList[0];

            _CurrentAddress += OpcodeList[0].Length;
            _CycleCount += NewObject.Opcode.Cycles;

            FlushLine(CurrentToken, InputTokenizer);
        }

        void ParseAssignment(LineInformation CurrentLine, Token LabelToken, Token CurrentToken, Tokenizer InputTokenizer, FunctionID CommandID)
        {
            Debug.Write($"   {CurrentToken.TokenData}");

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
            else if (Symbol.Type == SymbolType.Constant)
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.SyntaxError, string.Format("{0} redefined", Symbol.Name));

                CurrentObject.Error = true;
                CurrentLine.Success = false;
                FlushLine(CurrentToken, InputTokenizer);
                return;
            }

            CurrentToken = InputTokenizer.GetNextToken();
            if (!IsBreakType(CurrentToken))
                CurrentObject.Parameter = ParseParam(CurrentLine, CurrentToken, InputTokenizer);

            if (CurrentObject.Parameter == null)
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "Paramater missing");
                CurrentObject.Error = true;
                CurrentLine.Success = false;
                FlushLine(CurrentToken, InputTokenizer);
                return;
            }
            else
            {
                CurrentToken = InputTokenizer.GetNextToken();

                if (!IsBreakType(CurrentToken))
                {
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "To many Paramaters");
                    CurrentLine.Success = false;
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
        }

        void ParseIdentifier(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer)
        {
            Debug.Write($" {CurrentToken.StringValue}");

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
                    CommandID = DataTables.PsudoOpcodes[Command];

                    // If it's EQU or DEFL then it's an Identifier, otherwise it's a label, 
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
                        CurrentLine.Success = false;
                        return;
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

                    CurrentLine.Success = false;
                    return;
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

                    InputTokenizer.UnGetNextToken(NextToken);

                    Debug.Write($"->{CurrentToken.Type}");

                    ParseLabel(CurrentLine, CurrentToken, InputTokenizer);
                }
                else
                {
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.UnknownCommand, CurrentToken.StringValue);
                    FlushLine(NextToken, InputTokenizer);
                    CurrentLine.Success = false;
                }
            }
            else if (CurrentToken.Type == TokenType.Identifier && NextToken.Type == TokenType.Assignment)
            {
                ParseAssignment(CurrentLine, CurrentToken, NextToken, InputTokenizer, CommandID);
            }
            else
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.InternalError, "Identifier Parsing failed");
                FlushLine(NextToken, InputTokenizer);
                CurrentLine.Success = false;
            }
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
                // Find the easy Identifiers
                if (InputTokenizer.PeekNextInputType() == InputType.Colon)
                {
                    CurrentToken.Type = TokenType.Label;
                    InputTokenizer.GetNextToken();
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
        
        bool Phase1(FileInformation InputFile)
        {
            bool Success = true;
            bool ParseEnabled = true;

            if (InputFile.Stream == null)
            {
                Message.Add("Pass 1", InputFile.FileID, 0, 0, MessageCode.InternalError, "File Stream Missing");
                return false;
            }

            Debug.WriteLine($" {InputFile.FileID}: Input {InputFile.FileName}");

            Tokenizer InputTokenizer = new Tokenizer(InputFile.FileID, InputFile.Stream);
            InputFile.LineCount = 0;

            while (true)
            {
                Token CurrentToken = GetFirstToken(InputTokenizer);

                if (CurrentToken.Type == TokenType.End)
                    break;

                if (CurrentToken.Type == TokenType.LineBreak)
                    continue;

                Debug.Write($"  Parsing Line {InputTokenizer.CurrentLine}");

                LineInformation CurrentLine = ParseLine(CurrentToken, InputTokenizer, ParseEnabled);

                if (CurrentLine == null)
                {
                    Message.Add("Parser", InputFile.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.InternalError, "Unknown Error");
                    Success = false;
                }
                else
                {
                    Success = CurrentLine.Success;
                    ParseEnabled = CurrentLine.ParseEnabled;

                    CurrentLine.FileID = InputFile.FileID;

                    ParseData.Add(CurrentLine);

                    if (CurrentLine.Object != null)
                    {
                        if (CurrentLine.Object.Type == ObjectType.Include && !CurrentLine.Object.Error)
                        {
                            IncludeObject Include = CurrentLine.Object as IncludeObject;
                            FileStack.Push(Include.IncludeFile);
                            Success = Phase1(Include.IncludeFile);

                            if (FileStack.First() != Include.IncludeFile)
                            {
                                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, 0, MessageCode.InternalError, "File Stack desync");
                            }
                            else
                            {
                                FileStack.Pop();
                            }
                        }
                    }
                }

                Debug.WriteLine();

            }

            Debug.WriteLine();


            //    if (CurrentLine.LineNumber != InputFile.LineCount)
            //    {
            //        Message.Add("Parser", InputFile.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.InternalError, "File Input Dysync");
            //        Success = false;
            //    }
            //    else
            //    {
            //        Success = ParseNextToken(CurrentLine, CurrentToken, InputTokenizer);
            //    }


            return Success;
        }

        LineInformation ParseLine (Token CurrentToken, Tokenizer InputTokenizer, bool ParseEnabled)
        {
            LineInformation CurrentLine = new LineInformation()
            {
                LineNumber = InputTokenizer.CurrentLine,
                ParseEnabled = ParseEnabled,
                Success = true
            };


            if (!CurrentLine.ParseEnabled && CurrentToken.Type != TokenType.Command)
            {
                Debug.Write(" Skipping");
                FlushLine(CurrentToken, InputTokenizer);
                return CurrentLine;
            }


            ParseToken(CurrentLine, CurrentToken, InputTokenizer);

            return CurrentLine;
        }

        void ParseToken(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer)
        {
            Debug.Write($" {CurrentToken.Type}");

            switch (CurrentToken.Type)
            {
                case TokenType.End:
                case TokenType.LineBreak:
                    FlushLine(CurrentToken, InputTokenizer);
                    break;

                case TokenType.Comment:
                    FlushLine(CurrentToken, InputTokenizer);
                    break;

                case TokenType.Label:
                    ParseLabel(CurrentLine, CurrentToken, InputTokenizer);
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
                            ParseCommand(CurrentLine, CurrentToken, InputTokenizer, DataTables.Commands[Command]);
                        }
                        else
                        {
                            Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.UnknownCommand, CurrentToken.StringValue);
                            FlushLine(CurrentToken, InputTokenizer);
                            CurrentLine.Success = false;
                        }
                    }
                    break;

                case TokenType.PsudoOpcode:
                    ParsePsudoOpcode(CurrentLine, CurrentToken, InputTokenizer, DataTables.PsudoOpcodes[CurrentToken.StringValue.ToUpper()]);
                    break;

                case TokenType.Identifier:
                    ParseIdentifier(CurrentLine, CurrentToken, InputTokenizer);
                    break;

                case TokenType.Opcode:
                    ParseOpcode(CurrentLine, CurrentToken, InputTokenizer, DataTables.OpcodeList[CurrentToken.StringValue.ToUpper()]);
                    break;

                case TokenType.Register:
                case TokenType.Flag:
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.ReservedWord, CurrentToken.TokenData);
                    FlushLine(CurrentToken, InputTokenizer);
                    CurrentLine.Success = false;
                    break;

                default:
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.UnexpectedSymbol, CurrentToken.TokenData);
                    FlushLine(CurrentToken, InputTokenizer);
                    CurrentLine.Success = false;
                    break;
            }
        }

    }
}
