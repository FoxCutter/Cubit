using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZASM
{
    class FileInformation
    {
        // The file name as passed to us
        public string Name = ""; 
        
        // The full path to the file
        public string Path = "";

        public string FileName = "";

        public int FileID = 0;
        public int LineCount = 0;
        
        public FileStream Stream = null;
    }


    class LineInformation
    {
        public int FileID;
        public int LineNumber;

        public ObjectInformation Object;

        public LineInformation()
        {
            Object = null;
        }
    }

    class Parser
    {
        Dictionary<string, FileInformation> _Files;
        List<LineInformation> _ParseData;
        Stack<FileInformation> _FileStack;
        
        public Parser()
        {
            _Files = new Dictionary<string, FileInformation>();
            _ParseData = new List<LineInformation>();
            _FileStack = new Stack<FileInformation>();
        }

        public string LookupFileName(int FileID)
        {
            FileInformation File = _Files.Where(e => e.Value.FileID == FileID).First().Value;

            if (File == null)
                return "";
            else
                return File.FileName;
        }

        bool ParseCommand(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer, FunctionID Command)
        {
            bool Success = true;
            
            if (Command == FunctionID.INCLUDE)
            {
                return ProcessInclude(CurrentLine, CurrentToken, InputTokenizer, Command);
            }
            else switch (Command)
            {
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

                case FunctionID.IF:
                case FunctionID.ELSE:
                case FunctionID.ENDIF:
                    break;

                default:
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.InternalError, "Unknown Command Value!");
                    Success = false;
                    break;
            }

            InputTokenizer.FlushLine();

            return Success;
        }

        bool ProcessInclude(LineInformation CurrentLine, Token CurrentToken, Tokenizer InputTokenizer, FunctionID Command)
        { 
            Token Param = InputTokenizer.GetNextTokenAsString();

            if (Param.Type == TokenType.LineBreak || Param.Type == TokenType.End)
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, "Missing file name in INCLUDE command");
                return false;
            }

            string FileName = Param.StringValue;

            Param = InputTokenizer.GetNextToken();
            if (Param.Type != TokenType.LineBreak && Param.Type != TokenType.End)
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, Param.Character, MessageCode.SyntaxError, "To many paramters in INCLUDE command");
                InputTokenizer.FlushLine();
                return false;
            }

            FileInformation NewFile = OpenFile(FileName);

            if (_FileStack.Contains(NewFile))
            {
                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.SyntaxError, string.Format("Recursive include of {0}", FileName));
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
                    Message.Add("Include", NewFile.FileID, CurrentLine.LineNumber, CurrentToken.Character, MessageCode.FileNotFound, FileName);
                    return false;
                }
            }

            IncludeObject NewObject = new IncludeObject(NewFile);
            CurrentLine.Object = NewObject;

            return true;
        }
            

        public bool ParseFile(string InputFile)
        {
            FileInformation RootFile = OpenFile(InputFile);

            try
            {
                RootFile.Stream = File.OpenRead(RootFile.Path);
            }
            catch (FileNotFoundException)
            {
                Message.Add("Parser", RootFile.FileID, 0, 0, MessageCode.FileNotFound, RootFile.Path);
                return false;
            }


            _FileStack.Push(RootFile);

            bool Success = true;
            Success = Phase1(RootFile);

            // Open the listing file
            string ListingFile = System.IO.Path.ChangeExtension(RootFile.Path, "lst");
            TextWriter ListingStream = new StreamWriter(File.Open(ListingFile, FileMode.Create), Encoding.ASCII);

            Success = Phase2(RootFile, !Success, ListingStream, _ParseData.GetEnumerator());

            _FileStack.Pop();

            ListingStream.Close();

            return Success;
        }

        bool Phase1(FileInformation InputFile)
        {
            LineInformation CurrentLine = null;
            bool Success = true;

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
                }

                Token Data = InputTokenizer.GetNextToken();
                if (Data.Type == TokenType.End)
                    break;

                if (CurrentLine.LineNumber != InputFile.LineCount)
                {
                    Message.Add("Phase 1", InputFile.FileID, CurrentLine.LineNumber, InputTokenizer.CurrentCharacter, MessageCode.InternalError, "File Input Dysync");
                    Success = false;
                }

                else if (Data.Type == TokenType.Identifier)
                {
                    if (InputTokenizer.PeekNextInputType() == InputType.Colon)
                    {
                        InputTokenizer.GetNextToken();
                        Data.Type = TokenType.Label;

                        // Parse Label
                        InputTokenizer.FlushLine();
                    }
                    else if (Data.StringValue[0] == '.') // Command
                    {
                        // Remove the dot so it's the raw command
                        Data.StringValue = Data.StringValue.Substring(1);
                        string Command = Data.StringValue.ToUpper();
                        if (DataTables.Commands.ContainsKey(Command))
                        {
                            Data.Type = TokenType.Command;
                            Success = ParseCommand(CurrentLine, Data, InputTokenizer, DataTables.Commands[Command]);                           
                        }
                        else
                        {
                            Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, Data.Character, MessageCode.UnknownCommand, Command);
                        }
                    }
                    else
                    {
                        string Command = Data.StringValue.ToUpper();

                        if (DataTables.PsudoOpcodes.ContainsKey(Command))
                        {
                            Data.Type = TokenType.Data;
                            FunctionID CommandID = DataTables.PsudoOpcodes[Command];
                            // Parse Data
                            InputTokenizer.FlushLine();
                        }
                        else if (Settings.CommandRequiresDot != Setting.On && DataTables.Commands.ContainsKey(Command))
                        {
                            Data.Type = TokenType.Command;
                            FunctionID CommandID = DataTables.Commands[Command];

                            if (Settings.CommandRequiresDot == Setting.Warning)
                            {
                                Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, Data.Character, MessageCode.CommandRequiresDotPrefix, Command);
                            }

                            Success = ParseCommand(CurrentLine, Data, InputTokenizer, DataTables.Commands[Command]);                           
                        }
                        else if (DataTables.OpcodeList.ContainsKey(Command))
                        {
                            Data.Type = TokenType.Opcode;
                            OpcodeData.CommandID CommandID = DataTables.OpcodeList[Command];

                            // Parse Opcode
                            InputTokenizer.FlushLine();
                        }
                        else
                        {
                            // Parse Identifier
                            InputTokenizer.FlushLine();
                        }
                    }
                }
                else if (Data.Type == TokenType.Comment)
                {
                    InputTokenizer.FlushLine();
                }
                else if (Data.Type != TokenType.LineBreak)
                {
                    Message.Add("Parser", CurrentLine.FileID, CurrentLine.LineNumber, Data.Character, MessageCode.UnexpectedSymbol, Data.TokenData);
                    Success = false;
                }

                _ParseData.Add(CurrentLine);

                if (CurrentLine.Object != null && CurrentLine.Object.Type == ObjectType.Include)
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

                //if(!Success)
                //    InputTokenizer.FlushLine();
            }

            return Success;
        }

        bool Phase2(FileInformation File, bool ListingOnly, TextWriter OutputStream, IEnumerator<LineInformation> DataSet)
        {
            bool Success = true;
            File.Stream.Position = 0;
            StreamReader DataStream = new StreamReader(File.Stream);

            int OutputLine = 0;

            while (OutputLine + 1 != File.LineCount && DataSet.MoveNext())
            {
                LineInformation CurrentLine = DataSet.Current;
                string Line = DataStream.ReadLine();

                OutputLine++;

                if (CurrentLine.LineNumber != OutputLine)
                {
                    Message.Add("Pass 2", File.FileID, CurrentLine.LineNumber, 0, MessageCode.InternalError, "File Input Dysync");
                }

                OutputListingLine(OutputStream, CurrentLine, Line);


                if (CurrentLine.Object != null && CurrentLine.Object.Type == ObjectType.Include)
                {
                    IncludeObject Include = CurrentLine.Object as IncludeObject;
                    OutputStream.WriteLine("**** {0} ****", Include.IncludeFile.Name);

                    Phase2(Include.IncludeFile, ListingOnly, OutputStream, DataSet);

                    OutputStream.WriteLine("**** {0} ****", File.Name);
                }

            }

            return Success;
        }

        void OutputListingLine(TextWriter OutputStream, LineInformation CurrentLine, string LineData)
        {
            // Line Number
            OutputStream.Write("{0, 4}: ", CurrentLine.LineNumber);

            //if (CurrentLine.TokenList[0].Type == TokenType.Comment)
            {
                // Cycles
                OutputStream.Write("          ");

                // Address
                OutputStream.Write("     ");

                // Bytes
                OutputStream.Write("          ");

            }
            //else
            //{
            //    // Cycles
            //    OutputStream.Write("{0,-9} ", 0);

            //    // Address
            //    OutputStream.Write("{0:X4} ", 0xFFFF);

            //    // Bytes
            //    OutputStream.Write("AABBCCDD  ");
            //}

            OutputStream.WriteLine(LineData);

        }

        public FileInformation OpenFile(string FilePath)
        {
            string FullPath = Path.GetFullPath(FilePath).ToUpper();

            if (_Files.ContainsKey(FullPath))
                return _Files[FullPath];

            FileInformation NewFile = new FileInformation();

            NewFile.FileID = _Files.Count;
            NewFile.Name = FilePath;
            NewFile.Path = FullPath;
            NewFile.FileName = Path.GetFileName(FilePath);

            _Files.Add(FullPath, NewFile);

            return NewFile;
        }
        
    }
}
