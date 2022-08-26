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
        
        public Stream Stream = null;
    }

    class LineInformation
    {
        public int FileID;
        public int LineNumber;
        public bool ParseEnabled;
        public bool Success;

        public ObjectInformation Label;
        public ObjectInformation Object;

        public LineInformation()
        {
            Label = null;
            Object = null;
        }
    }

    partial class Parser
    {
        Dictionary<string, FileInformation> Files;
        List<LineInformation> ParseData;
        Stack<FileInformation> FileStack;
        SymbolTable SymbolTable;
        
        public Parser()
        {
            Files = new Dictionary<string, FileInformation>(StringComparer.OrdinalIgnoreCase);
            ParseData = new List<LineInformation>();
            FileStack = new Stack<FileInformation>();
            SymbolTable = new SymbolTable();
        }

        public string LookupFileName(int FileID)
        {
            FileInformation File = Files.Where(e => e.Value.FileID == FileID).FirstOrDefault().Value;

            if (File == null)
                return "";
            else
                return File.FileName;
        }

        public FileInformation FindFile(string FilePath, bool Search = true)
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
            
            if (Files.ContainsKey(FullPath))
                return Files[FullPath];

            FileInformation NewFile = new FileInformation();

            NewFile.FileID = Files.Count;
            NewFile.Name = FilePath;
            NewFile.Path = FullPath;
            NewFile.FileName = Path.GetFileName(FullPath);

            Files.Add(FullPath, NewFile);

            return NewFile;
        }

        public bool CurrentlyInFile(FileInformation FileInformation)
        {
            if (FileStack.Where(e => e.FileName.Equals(FileInformation.FileName, StringComparison.OrdinalIgnoreCase)).Count() != 0)
                return true;

            return false;
        }

        public bool EnterFile(FileInformation FileInformation)
        {
            FileStack.Push(FileInformation);

            return true;
        }

        public bool ExitFile(FileInformation FileInformation)
        {
            if (FileStack.First() != FileInformation)
                return false;

            FileStack.Pop();

            return true;
        }

        public bool ParseFile(string InputFile)
        {
            FileInformation RootFile = FindFile(InputFile, false);

            if(RootFile == null)
            {
                Message.Add("Parser", 0, 0, 0, MessageCode.FileNotFound, InputFile);
                return false;
            }

            RootFile.Stream = File.OpenRead(RootFile.Path);
            FileStack.Push(RootFile);

            bool Success = true;
            Debug.WriteLine("Phase 1");
            ParserPhase1 Phase1 = new ParserPhase1(this, SymbolTable, ParseData);


            Success = Phase1.Phase1(RootFile);

            // Open the listing file
            //string ListingFile = System.IO.Path.ChangeExtension(RootFile.Path, "lst");
            //TextWriter ListingStream = new StreamWriter(File.Open(ListingFile, FileMode.Create), Encoding.ASCII);

            //Debug.WriteLine("Phase 2");
            //Success = Phase2(RootFile, !Success, ListingStream, _ParseData.GetEnumerator());

            //ListingStream.WriteLine();

            //foreach (SymbolTableEntry Symbol in _SymbolTable.OrderBy(e => e.Name))
            //{
            //    if (Symbol.Type == SymbolType.Address)
            //    {
            //        ListingStream.WriteLine("{0,-15} {1:X4}", Symbol.Name, Symbol.Value);
            //    }
            //    else
            //    {
            //        ListingStream.WriteLine("{0,-15}={1,4:X2}", Symbol.Name, Symbol.Value);
            //    }
            //}
            
            FileStack.Pop();

            //ListingStream.Close();

            return Success;
        }
    }
}
