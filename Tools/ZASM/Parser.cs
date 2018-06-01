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
        public string FileName = "";
        public string Path = "";
        public int FileID = 0;
        public FileStream Stream = null;
    }


    class LineInformation
    {
        public int FileID;
        public int LineNumber;
        public List<Token> TokenList;

        public LineInformation()
        {
            TokenList = new List<Token>();
        }
    }

    class Parser
    {
        Dictionary<string, FileInformation> _Files;
        List<LineInformation> _ParseData;
        
        public Parser()
        {
            _Files = new Dictionary<string, FileInformation>();
            _ParseData = new List<LineInformation>();
        }
        
        bool Pass1(FileInformation File)
        {
            Tokenizer RootTokenizer = new Tokenizer(File.FileID, File.Stream);

            LineInformation CurrentLine = null;
            int OutputLine = 1;
            bool Success = true;
            
            while (true)
            {

                if (CurrentLine == null)
                {
                    CurrentLine = new LineInformation();
                    CurrentLine.FileID = File.FileID;
                    CurrentLine.LineNumber = RootTokenizer.CurrentLine;
                }

                if (CurrentLine.LineNumber != OutputLine)
                {
                    Message.Add("Pass 1", File.FileID, CurrentLine.LineNumber, RootTokenizer.CurrentCharacter, MessageCode.InternalError, "File Input Dysync");
                    Success = false;
                }

                Token Data = RootTokenizer.GetNextToken();
                if (Data.Type == TokenType.End)
                    break;

                CurrentLine.TokenList.Add(Data);
                if (Data.Type == TokenType.LineBreak)
                {
                    _ParseData.Add(CurrentLine);
                    CurrentLine = null;
                    OutputLine++;
                }

            }

            if(CurrentLine != null && CurrentLine.TokenList.Count != 0)
                _ParseData.Add(CurrentLine);

            return Success;
        }

        bool Pass2(FileInformation File, bool ListingOnly)
        {
            File.Stream.Position = 0;
            StreamReader _DataStream = new StreamReader(File.Stream);

            int OutputLine = 1;
            foreach (LineInformation CurrentLine in _ParseData)
            {
                string Line = _DataStream.ReadLine();

                if (CurrentLine.LineNumber != OutputLine)
                {
                    Message.Add("Pass 2", File.FileID, CurrentLine.LineNumber, 0, MessageCode.InternalError, "File Input Dysync");
                }

                //OutputListingLine(Console.Out, CurrentLine, Line);

                OutputLine++;
            }
            
            return false;
        }

        void OutputListingLine(TextWriter OutputStream, LineInformation CurrentLine, string LineData)
        {
            // Line Number
            OutputStream.Write("{0, 5}: ", CurrentLine.LineNumber);
            
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


        public bool ParseFile(string InputFile)
        {
            FileInformation RootFile = new FileInformation();

            RootFile.FileID = _Files.Count;
            RootFile.FileName = Path.GetFileName(InputFile);
            RootFile.Path = Path.GetFullPath(InputFile);
            RootFile.Stream = File.OpenRead(RootFile.Path);


            _Files.Add(RootFile.Path, RootFile);



            // Open the file
            bool Success = true;

            Success = Pass1(RootFile);
            Success = Pass2(RootFile, !Success);

            return Success;
        }
    }
}
