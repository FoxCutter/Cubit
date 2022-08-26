using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZASM
{
    class ConditionalInformation
    {
        public LineInformation Line;
        public bool SavedParse;
        public bool Result;
    }

    class ParserPhase1
    {
        List<LineInformation> ParseData;
        SymbolTable SymbolTable;
        Parser Parser;

        Stack<ConditionalInformation> ConditionalStack;
        Tokenizer InputTokenizer;
        short CurrentAddress;
        int CycleCount;

        public ParserPhase1(Parser Parser, SymbolTable SymbolTable, List<LineInformation> ParseData)
        {
            ConditionalStack = new Stack<ConditionalInformation>();
            CurrentAddress = 0;

            this.ParseData = ParseData;
            this.SymbolTable = SymbolTable;
            this.Parser = Parser;
        }

        public ParserPhase1(ParserPhase1 Clone)
        {
            ConditionalStack = new Stack<ConditionalInformation>();
            CurrentAddress = 0;

            this.ParseData = Clone.ParseData;
            this.SymbolTable = Clone.SymbolTable;
            this.Parser = Clone.Parser;
        }

        void AddMessage(LineInformation CurrentLine, Token CurrentToken, MessageCode Code, string Details = "")
        {
            Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken?.Character ?? 0, Code, Details);
        }


        bool IsBreakType(Token CurrentToken)
        {
            if (CurrentToken.Type == TokenType.LineBreak || CurrentToken.Type == TokenType.End || CurrentToken.Type == TokenType.Comment)
                return true;

            return false;
        }

        void FlushLine(Token CurrentToken)
        {
            if (CurrentToken.Type == TokenType.LineBreak || CurrentToken.Type == TokenType.End)
                return;

            InputTokenizer.FlushLine();
        }

        void ParseConditional(LineInformation CurrentLine, Token CurrentToken, FunctionID Command)
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
                        Paramater = ParseParam(CurrentLine, CurrentToken);

                    if (Paramater == null)
                    {
                        AddMessage(CurrentLine, CurrentToken, MessageCode.SyntaxError, "Paramater missing");
                        CurrentLine.Success = false;
                        CurrentObject.Error = true;
                    }

                    CurrentToken = InputTokenizer.GetNextToken();

                    if (!IsBreakType(CurrentToken))
                    {
                        AddMessage(CurrentLine, CurrentToken, MessageCode.SyntaxError, "To many Paramaters");
                        CurrentLine.Success = false;
                        CurrentObject.Error = true;

                    }

                    // TODO Real Params
                    if (Paramater.Tokens[0].Token.Type == TokenType.Number)
                    {
                        CurrentLine.ParseEnabled = Paramater.Tokens[0].Token.NumericValue != 0;
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
                ConditionalStack.Push(CurrentIfDef);

                CurrentObject.ParseEnabled = CurrentLine.ParseEnabled;
                CurrentObject.Level = ConditionalStack.Count;
            }
            else if (Command == FunctionID.ELSE)
            {
                if (ConditionalStack.Count == 0)
                {
                    AddMessage(CurrentLine, CurrentToken, MessageCode.SyntaxError, "ELSE without matching IF");
                    CurrentLine.Success = false;
                    CurrentObject.Error = true;
                }
                else
                {
                    CurrentObject.Conditional = ConditionalStack.First();

                    if (!ConditionalStack.First().SavedParse)
                        CurrentLine.ParseEnabled = false;

                    else
                        CurrentLine.ParseEnabled = !CurrentLine.ParseEnabled;
                }

                CurrentObject.Level = ConditionalStack.Count;
                CurrentObject.ParseEnabled = CurrentLine.ParseEnabled;

                if (!CurrentObject.ParseEnabled)
                    Debug.Write($" Skipping");

            }
            else if (Command == FunctionID.ENDIF)
            {
                CurrentObject.Level = ConditionalStack.Count;

                if (ConditionalStack.Count == 0)
                {
                    AddMessage(CurrentLine, CurrentToken, MessageCode.SyntaxError, "ENDIF without matching IF");
                    CurrentLine.Success = false;
                    CurrentObject.Error = true;
                }
                else
                {
                    CurrentObject.Conditional = ConditionalStack.First();
                    CurrentLine.ParseEnabled = ConditionalStack.First().SavedParse;
                    ConditionalStack.Pop();
                }

                CurrentObject.ParseEnabled = CurrentLine.ParseEnabled;

                if (!CurrentObject.ParseEnabled)
                    Debug.Write($" Skipping");
            }

            FlushLine(CurrentToken);
        }

        void ProcessInclude(LineInformation CurrentLine, Token CurrentToken, FunctionID Command)
        {
            IncludeObject NewObject = new IncludeObject();
            CurrentLine.Object = NewObject;

            CurrentToken = InputTokenizer.GetNextTokenAsString();

            if (IsBreakType(CurrentToken))
            {
                AddMessage(CurrentLine, CurrentToken, MessageCode.SyntaxError, "Missing file name in INCLUDE command");
                FlushLine(CurrentToken);

                NewObject.Error = true;
                CurrentLine.Success = false;
                return;
            }

            string FileName = CurrentToken.StringValue;

            CurrentToken = InputTokenizer.GetNextToken();

            FlushLine(CurrentToken);

            if (!IsBreakType(CurrentToken))
            {
                AddMessage(CurrentLine, CurrentToken, MessageCode.SyntaxError, "Extra parameters in INCLUDE command");

                NewObject.Error = true;
                CurrentLine.Success = false;
                return;
            }

            FileInformation NewFile = Parser.FindFile(FileName);
            if (NewFile == null)
            {
                Message.Add("Include", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.FileNotFound, FileName);

                NewObject.Error = true;
                CurrentLine.Success = false;
                return;
            }

            if (Parser.CurrentlyInFile(NewFile))
            {
                AddMessage(CurrentLine, CurrentToken, MessageCode.SyntaxError, string.Format("Recursive include of {0}", FileName));

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

        void ParseCommand(LineInformation CurrentLine, Token CurrentToken, FunctionID Command)
        {
            bool Success = true;

            // IF, ELSE and ENDIF always get processed even if we're skipping a line.
            if (Command >= FunctionID.IF && Command <= FunctionID.ENDIF)
            {
                ParseConditional(CurrentLine, CurrentToken, Command);
                return;
            }

            if (!CurrentLine.ParseEnabled)
            {
                Debug.Write($" Skipping");
                FlushLine(CurrentToken);
                return;
            }

            Debug.Write($" {Command}");

            switch (Command)
            {
                case FunctionID.INCLUDE:
                    ProcessInclude(CurrentLine, CurrentToken, Command);
                    return;

                case FunctionID.Z80:
                    Settings.OpcodeSet = OpcodeType.z80;
                    DataTables.OpcodeTable = OpcodeData.z80Data.Encoding;
                    DataTables.OpcodeList = OpcodeData.z80Data.Commands;
                    DataTables.ParameterList = OpcodeData.z80Data.ParameterList;
                    break;

                case FunctionID.i8080:
                    Settings.OpcodeSet = OpcodeType.i8080;
                    DataTables.OpcodeTable = OpcodeData.z80Data.Encoding;
                    DataTables.OpcodeList = OpcodeData.i8080Data.Commands;
                    DataTables.ParameterList = OpcodeData.z80Data.ParameterList;
                    break;

                case FunctionID.GAMEBOY:
                    Settings.OpcodeSet = OpcodeType.GameBoy;
                    DataTables.OpcodeTable = OpcodeData.z80Data.Encoding;
                    DataTables.OpcodeList = OpcodeData.GameBoyData.Commands;
                    DataTables.ParameterList = OpcodeData.z80Data.ParameterList;
                    break;

                case FunctionID.END:
                    // TODO: Parse entry point label
                    Debug.Write(" Ending File Processing");
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
                    AddMessage(CurrentLine, CurrentToken, MessageCode.InternalError, "Unknown Command Value!");
                    CurrentLine.Success = false;
                    break;
            }

            if (Success)
            {
                CommandObject NewObject = new CommandObject();
                NewObject.Command = Command;
                CurrentLine.Object = NewObject;
            }

            FlushLine(CurrentToken);
        }

        void ParseLabel(LineInformation CurrentLine, Token CurrentToken)
        {
            Debug.Write($" {CurrentToken.StringValue}");

            LabelObject NewObject = new LabelObject();
            NewObject.Address = CurrentAddress;
            CurrentLine.Label = NewObject;

            SymbolTableEntry Symbol = SymbolTable[CurrentToken.StringValue];
            Symbol.ReferencedLines.Add(CurrentLine);
            NewObject.Symbol = Symbol;

            if (Symbol.State != SymbolState.Undefined)
            {
                AddMessage(CurrentLine, CurrentToken, MessageCode.SyntaxError, string.Format("{0} redefined", Symbol.Name));
                CurrentLine.Success = false;
            }
            else
            {
                Symbol.Type = SymbolType.Address;
                Symbol.State = SymbolState.Set;
                Symbol.DefiendLine = CurrentLine;
                Symbol.Value = CurrentAddress;
            }

            // If we have a double Colon, mark it as exported
            if (InputTokenizer.PeekNextInputType() == InputType.Colon)
            {
                InputTokenizer.GetNextToken();
                Symbol.Visability = SymbolVisability.Public;
            }

            CurrentToken = GetFirstToken();

            if (CurrentToken.Type == TokenType.End || CurrentToken.Type == TokenType.LineBreak)
            {
                return;
            }
            else if (CurrentToken.Type != TokenType.PsudoOpcode && CurrentToken.Type != TokenType.Opcode && CurrentToken.Type != TokenType.Comment)
            {
                AddMessage(CurrentLine, CurrentToken, MessageCode.UnknownCommand, CurrentToken.StringValue);
                FlushLine(CurrentToken);
                CurrentLine.Success = false;
            }
            else
            {
                ParseToken(CurrentLine, CurrentToken);
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
            if(Settings.OpcodeSet == OpcodeType.i8080 || Settings.OpcodeSet == OpcodeType.i8085)
                return false;

            if (CommandID == OpcodeData.CommandID.ADC || CommandID == OpcodeData.CommandID.ADD ||
                CommandID == OpcodeData.CommandID.SUB || CommandID == OpcodeData.CommandID.SBC ||
                CommandID == OpcodeData.CommandID.OR || CommandID == OpcodeData.CommandID.XOR ||
                CommandID == OpcodeData.CommandID.AND || CommandID == OpcodeData.CommandID.CP ||
                CommandID == OpcodeData.CommandID.CPL || CommandID == OpcodeData.CommandID.NEG)
                return true;

            return false;
        }

        Token GetIdentifierToken(Tokenizer InputTokenizer, Token CurrentToken, bool ParseCommands = true)
        {
            if (CurrentToken.Type == TokenType.Identifier)
            {
                string Command = CurrentToken.StringValue.ToUpper();

                if (DataTables.PsudoOpcodes.ContainsKey(Command))
                {
                    CurrentToken.Type = TokenType.PsudoOpcode;
                }
                else if (ParseCommands && Settings.CommandRequiresDot != Setting.On && DataTables.Commands.ContainsKey(Command))
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
                        if (CurrentToken.ParameterID == OpcodeData.ParameterID.Flag_CY && Settings.CYAsCarry == Setting.Off)
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

        char MatchingBrace(TokenType Type)
        {
            switch(Type)
            {
                case TokenType.ArrayLeft:
                    return ']';

                case TokenType.ArrayRight:
                    return '[';

                case TokenType.GroupLeft:
                    return ')';

                case TokenType.GroupRight:
                    return '(';
            }

            return '?';
        }

        ParameterToken ParseParameterGroup(ParameterInformation ParamInformation, LineInformation CurrentLine, Token CurrentToken)
        {
            ParameterToken NewParam = new ParameterToken();
            NewParam.GroupTokens = new List<ParameterToken>();

            while (true)
            {
                if (CurrentToken.Type == TokenType.GroupLeft || CurrentToken.Type == TokenType.ArrayLeft)
                {
                    if (NewParam.GroupTokens.Count != 0)
                    {
                        NewParam.GroupTokens.Add(ParseParameterGroup(ParamInformation, CurrentLine, CurrentToken));
                        CurrentToken = new Token();
                    }
                }

                if (CurrentToken.Type != TokenType.None)
                {
                    CurrentToken = GetIdentifierToken(InputTokenizer, CurrentToken, false);

                    switch (CurrentToken.Type)
                    {
                        case TokenType.Register:
                            if (CurrentToken.ParameterID <= OpcodeData.ParameterID.ByteReg)
                            {
                                if (IsIndexRegister(CurrentToken.ParameterID))
                                    ParamInformation.Type = OpcodeData.ParameterType.ByteIndexRegister;
                                else
                                    ParamInformation.Type = OpcodeData.ParameterType.ByteRegister;
                            }

                            else if (CurrentToken.ParameterID <= OpcodeData.ParameterID.WordReg)
                            {
                                if (IsIndexRegister(CurrentToken.ParameterID))
                                    ParamInformation.Type = OpcodeData.ParameterType.WordIndexRegister;
                                else
                                    ParamInformation.Type = OpcodeData.ParameterType.WordRegister;
                            }

                            else if (CurrentToken.ParameterID <= OpcodeData.ParameterID.ContextReg)
                                ParamInformation.Type = OpcodeData.ParameterType.ContextRegister;

                            break;

                        case TokenType.Command:
                        case TokenType.Opcode:
                        case TokenType.PsudoOpcode:
                            AddMessage(CurrentLine, CurrentToken, MessageCode.ReservedWord, CurrentToken.StringValue);
                            NewParam.Error = true;
                            ParamInformation.Error = true;
                            break;

                        case TokenType.Plus:
                            if (NewParam.GroupTokens.Count != 0)
                            {
                                ParameterToken LastToken = NewParam.GroupTokens.Last();

                                // Check for HL+ on the gameboy
                                if (LastToken.Token != null)
                                {
                                    if (LastToken.Token.ParameterID == OpcodeData.ParameterID.WordReg_HL && Settings.OpcodeSet == OpcodeType.GameBoy)
                                    {
                                        LastToken.Token.ParameterID = OpcodeData.ParameterID.WordReg_HLI;
                                        CurrentToken.Type = TokenType.None;
                                    }
                                }
                            }
                            break;

                        case TokenType.Minus:
                            if (NewParam.GroupTokens.Count != 0)
                            {
                                ParameterToken LastToken = NewParam.GroupTokens.Last();

                                // Check for HL- on the gameboy
                                if (LastToken.Token != null)
                                {
                                    if (LastToken.Token.ParameterID == OpcodeData.ParameterID.WordReg_HL && Settings.OpcodeSet == OpcodeType.GameBoy)
                                    {
                                        LastToken.Token.ParameterID = OpcodeData.ParameterID.WordReg_HLD;
                                        CurrentToken.Type = TokenType.None;
                                    }
                                }
                            }
                            break;

                        case TokenType.Number:
                            if (ParamInformation.Type == OpcodeData.ParameterType.Unknown)
                                ParamInformation.Type = OpcodeData.ParameterType.Value;
                            break;

                        case TokenType.String:
                            if (ParamInformation.Type == OpcodeData.ParameterType.Unknown)
                                ParamInformation.Type = OpcodeData.ParameterType.Value;
                            break;

                        case TokenType.Identifier:
                            if (ParamInformation.Type == OpcodeData.ParameterType.Unknown)
                                ParamInformation.Type = OpcodeData.ParameterType.Value;
                            break;

                        case TokenType.Flag:
                            if (ParamInformation.Type == OpcodeData.ParameterType.Unknown)
                                ParamInformation.Type = OpcodeData.ParameterType.Flag;
                            break;
                    }

                    NewParam.GroupTokens.Add(new ParameterToken(CurrentToken));
                }

                if (CurrentToken.Type == TokenType.GroupRight || CurrentToken.Type == TokenType.ArrayRight)
                {
                    if (NewParam.GroupTokens.Count == 0)
                    {
                        AddMessage(CurrentLine, CurrentToken, MessageCode.MissingGroupSymbol, $"Opening '{MatchingBrace(CurrentToken.Type)}'");
                        NewParam.Error = true;
                        ParamInformation.Error = true;
                    }
                    else
                    {
                        TokenType OldGroup = NewParam.GroupTokens.First().Token.Type;

                        // Make sure the groups match.
                        if(OldGroup != TokenType.ArrayLeft && OldGroup != TokenType.GroupLeft)
                        {
                            AddMessage(CurrentLine, CurrentToken, MessageCode.MissingGroupSymbol, $"Opening '{MatchingBrace(CurrentToken.Type)}'");
                            NewParam.Error = true;
                            ParamInformation.Error = true;
                        }
                        else if (OldGroup == TokenType.GroupLeft && CurrentToken.Type != TokenType.GroupRight)
                        {
                            AddMessage(CurrentLine, CurrentToken, MessageCode.MissingGroupSymbol, "Expected ')' found ']'");
                            NewParam.Error = true;
                            ParamInformation.Error = true;
                        }
                        else if (OldGroup == TokenType.ArrayLeft && CurrentToken.Type != TokenType.ArrayRight)
                        {
                            AddMessage(CurrentLine, CurrentToken, MessageCode.MissingGroupSymbol, "Expected ']' found ')'");
                            NewParam.Error = true;
                            ParamInformation.Error = true;
                        }

                        break;
                    }
                }

                InputType NextToken = InputTokenizer.PeekNextInputType();

                if (NextToken == InputType.End || NextToken == InputType.CarriageReturn || NextToken == InputType.LineFeed || NextToken == InputType.Comma || NextToken == InputType.SemiColon)
                {
                    TokenType OldGroup = NewParam.GroupTokens.First().Token.Type;

                    if (OldGroup == TokenType.GroupLeft || OldGroup == TokenType.ArrayLeft)
                    {
                        AddMessage(CurrentLine, CurrentToken, MessageCode.MissingGroupSymbol, $"Closing '{MatchingBrace(OldGroup)}'");
                        NewParam.Error = true;
                        ParamInformation.Error = true;
                    }

                    break;
                }

                CurrentToken = InputTokenizer.GetNextToken();
            }

            return NewParam;
        }


        ParameterInformation ParseParam(LineInformation CurrentLine, Token CurrentToken)
        {
            ParameterInformation NewParam = new ParameterInformation();

            while(true)
            {
                NewParam.Tokens.Add(ParseParameterGroup(NewParam, CurrentLine, CurrentToken));

                InputType NextToken = InputTokenizer.PeekNextInputType();

                if (NextToken == InputType.End || NextToken == InputType.CarriageReturn || NextToken == InputType.LineFeed)
                    break;

                CurrentToken = InputTokenizer.GetNextToken();

                if (CurrentToken.CharacterType == InputType.Comma || CurrentToken.Type == TokenType.Comment)
                    break;
            }

            while (NewParam.Tokens.Count == 1 && NewParam.Tokens[0].Token == null)
                NewParam.Tokens = NewParam.Tokens[0].GroupTokens;

            if(NewParam.Tokens.First().Token != null && NewParam.Tokens.Last().Token != null)
            {
                TokenType FirstToken = NewParam.Tokens.First().Token.Type;
                TokenType LastToken = NewParam.Tokens.Last().Token.Type;

                if ((FirstToken == TokenType.GroupLeft && LastToken == TokenType.GroupRight) || (FirstToken == TokenType.ArrayLeft && LastToken == TokenType.ArrayRight))
                {
                    NewParam.Pointer = true;
                    NewParam.Type = OpcodeData.ParameterType.AddressPointer;
                    NewParam.Tokens = NewParam.Tokens.GetRange(1, NewParam.Tokens.Count - 2);
                }
            }

            if (NewParam.Error)
                CurrentLine.Success = false;

            Debug.Write($" [{NewParam.Type}:{string.Join(" ", NewParam.Tokens)}]");

            return NewParam;
        }


        void ParsePsudoOpcode(LineInformation CurrentLine, Token CurrentToken, FunctionID Command)
        {
            Debug.Write($" {Command}");

            DataObject NewObject = new DataObject();
            CurrentLine.Object = NewObject;

            NewObject.DataType = Command;

            NewObject.Address = CurrentAddress;
            NewObject.CycleCount = CycleCount;

            while (true)
            {
                CurrentToken = InputTokenizer.GetNextToken();
                if (IsBreakType(CurrentToken))
                    break;

                NewObject.ParamterList.Add(ParseParam(CurrentLine, CurrentToken));
            }

            // TODO: Add length of Data

            //_CurrentAddress += OpcodeList.Value[0].Length;

            FlushLine(CurrentToken);
        }

        void ParseOpcode(LineInformation CurrentLine, Token CurrentToken, OpcodeData.CommandID Opcode)
        {
            Debug.Write($" {Opcode}");

            var OpcodeList = DataTables.OpcodeTable.Where(e => e.Key == Opcode).FirstOrDefault();

            if (OpcodeList.Value == null || OpcodeList.Value.Length == 0)
            {
                AddMessage(CurrentLine, CurrentToken, MessageCode.InternalError, "Opcode Table Entry Missing");
                FlushLine(CurrentToken);
                CurrentLine.Success = false;
                return;
            }

            OpcodeObject NewObject = new OpcodeObject();
            CurrentLine.Object = NewObject;

            NewObject.Address = CurrentAddress;
            NewObject.CycleCount = CycleCount;

            while (true)
            {
                CurrentToken = InputTokenizer.GetNextToken();
                if (IsBreakType(CurrentToken))
                    break;

                NewObject.ParamterList.Add(ParseParam(CurrentLine, CurrentToken));
            }

            if (ImplicitA(Opcode) && NewObject.ParamterList.Count <= 1)
            {
                if (Settings.ImplicitA == Setting.Off)
                {
                    // TODO: A proper error in this case 
                    AddMessage(CurrentLine, CurrentToken, MessageCode.InvalidParamaterForOpcode, "Paramater Missing");
                    FlushLine(CurrentToken);
                    CurrentLine.Success = false;
                    return;
                }
                else if (Settings.ImplicitA == Setting.Warning)
                {
                    AddMessage(CurrentLine, CurrentToken, MessageCode.ImplicitA);
                }
            }

            NewObject.Opcode = OpcodeList.Value[0];

            CurrentAddress += OpcodeList.Value[0].Length;
            CycleCount += NewObject.Opcode.TStates;

            FlushLine(CurrentToken);
        }

        void ParseAssignment(LineInformation CurrentLine, Token LabelToken, Token CurrentToken, FunctionID CommandID)
        {
            Debug.Write($"   {CurrentToken.TokenData}");

            SymbolTableEntry Symbol = SymbolTable[LabelToken.StringValue];
            Symbol.ReferencedLines.Add(CurrentLine);

            ValueObject CurrentObject = new ValueObject();
            CurrentLine.Object = CurrentObject;

            CurrentObject.Address = CurrentAddress;
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
                AddMessage(CurrentLine, LabelToken, MessageCode.SyntaxError, string.Format("{0} redefined", Symbol.Name));

                CurrentObject.Error = true;
                CurrentLine.Success = false;
                FlushLine(CurrentToken);
                return;
            }

            CurrentToken = InputTokenizer.GetNextToken();
            if (!IsBreakType(CurrentToken))
                CurrentObject.Parameter = ParseParam(CurrentLine, CurrentToken);

            if (CurrentObject.Parameter == null)
            {
                AddMessage(CurrentLine, CurrentToken, MessageCode.SyntaxError, "Paramater missing");
                CurrentObject.Error = true;
                CurrentLine.Success = false;
                FlushLine(CurrentToken);
                return;
            }
            else
            {
                CurrentToken = InputTokenizer.GetNextToken();

                if (!IsBreakType(CurrentToken))
                {
                    AddMessage(CurrentLine, CurrentToken, MessageCode.SyntaxError, "To many Paramaters");
                    CurrentLine.Success = false;
                    CurrentObject.Error = true;
                }
            }


            Symbol.State = SymbolState.Pending;

            if (CurrentObject.Parameter.Tokens[0].Token.Type == TokenType.Number)
            {
                Symbol.State = SymbolState.Set;
                Symbol.Value = (short)CurrentObject.Parameter.Tokens[0].Token.NumericValue;
            }

            FlushLine(CurrentToken);
        }

        void ParseIdentifier(LineInformation CurrentLine, Token CurrentToken)
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
                        AddMessage(CurrentLine, NextToken, MessageCode.ReservedWord, NextToken.StringValue);
                        FlushLine(NextToken);
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
                    AddMessage(CurrentLine, NextToken, MessageCode.UnexpectedSymbol, NextToken.TokenData);

                    FlushLine(NextToken);

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
                        AddMessage(CurrentLine, CurrentToken, MessageCode.SyntaxWarning, "Label defined without a ':'");
                    }

                    InputTokenizer.UnGetNextToken(NextToken);

                    Debug.Write($"->{CurrentToken.Type}");

                    ParseLabel(CurrentLine, CurrentToken);
                }
                else
                {
                    AddMessage(CurrentLine, CurrentToken, MessageCode.UnknownCommand, CurrentToken.StringValue);
                    FlushLine(NextToken);
                    CurrentLine.Success = false;
                }
            }
            else if (CurrentToken.Type == TokenType.Identifier && NextToken.Type == TokenType.Assignment)
            {
                ParseAssignment(CurrentLine, CurrentToken, NextToken, CommandID);
            }
            else
            {
                AddMessage(CurrentLine, CurrentToken, MessageCode.InternalError, "Identifier Parsing failed");
                FlushLine(NextToken);
                CurrentLine.Success = false;
            }
        }

        // Gets the first token for a line
        Token GetFirstToken()
        {
            Token CurrentToken = InputTokenizer.GetNextToken();
            return GetFirstToken(CurrentToken);
        }

        Token GetFirstToken(Token CurrentToken)
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
        
        public bool Phase1(FileInformation InputFile)
        {
            bool Success = true;
            bool ParseEnabled = true;

            if (InputFile.Stream == null)
            {
                Message.Add("Parser", InputFile.FileID, 0, 0, MessageCode.InternalError, "File Stream Missing");
                return false;
            }

            Debug.WriteLine($" {InputFile.FileID}: Input {InputFile.FileName}");

            InputTokenizer = new Tokenizer(InputFile.FileID, InputFile.Stream);
            InputFile.LineCount = 0;

            while (true)
            {
                Token CurrentToken = GetFirstToken();

                if (CurrentToken.Type == TokenType.End)
                    break;

                if (CurrentToken.Type == TokenType.LineBreak)
                    continue;

                Debug.Write($"  Parsing Line {InputTokenizer.CurrentLine}");

                LineInformation CurrentLine = ParseLine(CurrentToken, ParseEnabled);

                if (CurrentLine == null)
                {
                    Message.Add("Parser", InputFile.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.InternalError, "Unknown Error");
                    Success = false;
                }
                else
                {
                    if(Success == true)
                        Success = CurrentLine.Success;

                    ParseEnabled = CurrentLine.ParseEnabled;

                    CurrentLine.FileID = InputFile.FileID;

                    ParseData.Add(CurrentLine);

                    if (CurrentLine.Object != null)
                    {
                        if (CurrentLine.Object.Type == ObjectType.Include && !CurrentLine.Object.Error)
                        {
                            IncludeObject Include = CurrentLine.Object as IncludeObject;
                            Parser.EnterFile(Include.IncludeFile);

                            ParserPhase1 Phase1 = new ParserPhase1(this);

                            Success = Phase1.Phase1(Include.IncludeFile);

                            if (!Parser.ExitFile(Include.IncludeFile))
                            {
                                AddMessage(CurrentLine, null, MessageCode.InternalError, "File Stack desync");
                            }
                        }

                        else if (CurrentLine.Object.Type == ObjectType.Command)
                        {
                            CommandObject Command = CurrentLine.Object as CommandObject;

                            if (Command.Command == FunctionID.END)
                                break;
                        }
                    }
                }

                Debug.WriteLine();

            }

            Debug.WriteLine();


            //    if (CurrentLine.LineNumber != InputFile.LineCount)
            //    {
            //        Message.Add("Parser", InputFile.FileID, CurrentLine.LineNumber.CurrentCharacter, MessageCode.InternalError, "File Input Dysync");
            //        Success = false;
            //    }
            //    else
            //    {
            //        Success = ParseNextToken(CurrentLine, CurrentToken);
            //    }


            return Success;
        }

        LineInformation ParseLine (Token CurrentToken, bool ParseEnabled)
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
                FlushLine(CurrentToken);
                return CurrentLine;
            }


            ParseToken(CurrentLine, CurrentToken);

            return CurrentLine;
        }

        void ParseToken(LineInformation CurrentLine, Token CurrentToken)
        {
            Debug.Write($" {CurrentToken.Type}");

            switch (CurrentToken.Type)
            {
                case TokenType.End:
                case TokenType.LineBreak:
                    FlushLine(CurrentToken);
                    break;

                case TokenType.Comment:
                    FlushLine(CurrentToken);
                    break;

                case TokenType.Label:
                    ParseLabel(CurrentLine, CurrentToken);
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
                            AddMessage(CurrentLine, CurrentToken, MessageCode.CommandRequiresDotPrefix, CurrentToken.StringValue);
                        }

                        if (DataTables.Commands.ContainsKey(Command))
                        {
                            ParseCommand(CurrentLine, CurrentToken, DataTables.Commands[Command]);
                        }
                        else
                        {
                            AddMessage(CurrentLine, CurrentToken, MessageCode.UnknownCommand, CurrentToken.StringValue);
                            FlushLine(CurrentToken);
                            CurrentLine.Success = false;
                        }
                    }
                    break;

                case TokenType.PsudoOpcode:
                    ParsePsudoOpcode(CurrentLine, CurrentToken, DataTables.PsudoOpcodes[CurrentToken.StringValue.ToUpper()]);
                    break;

                case TokenType.Identifier:
                    ParseIdentifier(CurrentLine, CurrentToken);
                    break;

                case TokenType.Opcode:
                    ParseOpcode(CurrentLine, CurrentToken, DataTables.OpcodeList[CurrentToken.StringValue.ToUpper()]);
                    break;

                case TokenType.Register:
                case TokenType.Flag:
                    AddMessage(CurrentLine, CurrentToken, MessageCode.ReservedWord, CurrentToken.TokenData);
                    FlushLine(CurrentToken);
                    CurrentLine.Success = false;
                    break;

                default:
                    AddMessage(CurrentLine, CurrentToken, MessageCode.UnexpectedSymbol, CurrentToken.TokenData);
                    FlushLine(CurrentToken);
                    CurrentLine.Success = false;
                    break;
            }
        }

    }
}
