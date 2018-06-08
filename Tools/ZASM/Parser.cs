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
        public bool ParseLine;

        public ObjectInformation Label;
        public ObjectInformation Object;

        public LineInformation()
        {
            Label = null;
            Object = null;
        }
    }

    class ConditionalInformation
    {
        public LineInformation Line;
        public bool SavedParse;
        public bool Result;
    }

    partial class Parser
    {
        Dictionary<string, FileInformation> _Files;
        List<LineInformation> _ParseData;
        Stack<FileInformation> _FileStack;
        Stack<ConditionalInformation> _ConditionalStack;
        SymbolTable _SymbolTable;
        short _CurrentAddress;
        int _CycleCount;
        
        public Parser()
        {
            _Files = new Dictionary<string, FileInformation>(StringComparer.OrdinalIgnoreCase);
            _ParseData = new List<LineInformation>();
            _FileStack = new Stack<FileInformation>();
            _ConditionalStack = new Stack<ConditionalInformation>();
            _SymbolTable = new SymbolTable();
            _CurrentAddress = 0;
        }

        public string LookupFileName(int FileID)
        {
            FileInformation File = _Files.Where(e => e.Value.FileID == FileID).FirstOrDefault().Value;

            if (File == null)
                return "";
            else
                return File.FileName;
        }

        public FileInformation OpenFile(string FilePath, bool Search = true)
        {
            string FullPath = "";

            if (Search)
            {
                // Search the include paths for the inculed file
                foreach (string SearchPath in Settings.IncludePaths)
                {
                    string NewPath = Path.GetFullPath(Path.Combine(SearchPath, FilePath));
                    if (File.Exists(NewPath))
                    {
                        FullPath = NewPath;
                        break;
                    }
                }
            }
            else
            {
                FullPath = Path.GetFullPath(FilePath);
            }

            if (FullPath == "" || !File.Exists(FullPath))
            {
                return null;
            }
            
            if (_Files.ContainsKey(FullPath))
                return _Files[FullPath];

            FileInformation NewFile = new FileInformation();

            NewFile.FileID = _Files.Count;
            NewFile.Name = FilePath;
            NewFile.Path = FullPath;
            NewFile.FileName = Path.GetFileName(FullPath);

            _Files.Add(FullPath, NewFile);

            return NewFile;
        }
            
        public bool ParseFile(string InputFile)
        {
            FileInformation RootFile = OpenFile(InputFile, false);

            if(RootFile == null)
            {
                Message.Add("Parser", 0, 0, 0, MessageCode.FileNotFound, InputFile);
                return false;
            }

            RootFile.Stream = File.OpenRead(RootFile.Path);

            _FileStack.Push(RootFile);

            bool Success = true;
            Success = Phase1(RootFile);

            // Open the listing file
            string ListingFile = System.IO.Path.ChangeExtension(RootFile.Path, "lst");
            TextWriter ListingStream = new StreamWriter(File.Open(ListingFile, FileMode.Create), Encoding.ASCII);

            Success = Phase2(RootFile, !Success, ListingStream, _ParseData.GetEnumerator());

            ListingStream.WriteLine();

            foreach (SymbolTableEntry Symbol in _SymbolTable.OrderBy(e => e.Name))
            {
                ListingStream.WriteLine("{0,-15} {1:X4}", Symbol.Name, Symbol.Value);
            }
            
            _FileStack.Pop();

            ListingStream.Close();

            return Success;
        }
    }
}
