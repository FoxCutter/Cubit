using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    enum MessageCode
    {
        // 0x0000 - 0x3fff: General Messages
        // 0x4000 - 0x7FFF: Warnings
        // 0x8000 - 0xFFFF: Errors        
        NoError = 0x0000,

        Warning = 0x4000,
        SyntaxWarning,
        ImplicitA,
        CommandRequiresDotPrefix,


        Error = 0x8000,
        InvalidNumberToken,
        UnexpectedLineBreak,
        UnexpectedSymbol,
        InvalidParamaterForOpcode,
        ValueMissing,
        MissingGroupSymbol,
        DataTypeMisMatch,
        SyntaxError,
        UnknownCommand,
        ReservedWord,
        FileNotFound,


        UndefinedSymbol,
        DivisionByZero,
        InternalError,

        UnknownError = 0xFFFF,
    }

    class MessageInformation : IComparer<MessageInformation>, IComparable<MessageInformation>
    {
        // The location of the error
        public int FileID;
        public int Line;
        public int Character;

        // The error code and details related to it. 
        public MessageCode Code;
        public string Source;
        public string Details;

        public MessageInformation(int fileID, int line, int character, string source, MessageCode code, string details = "")          
        {
            FileID = fileID;
            Line = line;
            Character = character;
            Code = code;
            Source = source;
            Details = details;
        }

        public MessageInformation(string source, MessageCode code, string details = "")
        {
            FileID = 0;
            Line = 0;
            Character = 0;
            Code = code;
            Source = source;
            Details = details;
        }
                
        public int Compare(MessageInformation x, MessageInformation y)
        {
            if (x.FileID != y.FileID)
                return x.FileID - y.FileID;
            
            if (x.Line != y.Line)
                return x.Line - y.Line;

            if (x.Character != y.Character)
                return x.Character - y.Character;

            return 0;
        }

        public int CompareTo(MessageInformation other)
        {
            return Compare(this, other);
        }

        public string Message
        {
            get 
            {
                if (MessageStrings.ContainsKey(Code))
                {
                    return MessageStrings[Code];
                }
                else
                {
                    return string.Format("Missing String", Code);
                }
            }
        }

        public static Dictionary<MessageCode, string> MessageStrings = new Dictionary<MessageCode, string>()
        { 
            { MessageCode.NoError, "" },

            { MessageCode.SyntaxWarning, "Syntax Warning"},
            { MessageCode.ImplicitA, "Implicit A"},
            { MessageCode.CommandRequiresDotPrefix, "Dot Prefix missing on command" },

            { MessageCode.SyntaxError, "Syntax Error"},           
            { MessageCode.InvalidNumberToken, "Invalid character in number" },
            { MessageCode.UnexpectedLineBreak, "Unexpected line break in a string" },
            { MessageCode.UnexpectedSymbol, "Unexpected character encounter in input" },
            { MessageCode.InvalidParamaterForOpcode, "Parameter is invalid" },
            { MessageCode.ValueMissing, "Value missing in assignment" },
            { MessageCode.MissingGroupSymbol, "Missing group"},
            { MessageCode.DataTypeMisMatch, "Datatype mismatch"},
            { MessageCode.UnknownCommand, "Unknown Command" },            
            { MessageCode.ReservedWord, "Unexpected Reserved Word" },
            { MessageCode.FileNotFound, "File Not Found" },

            { MessageCode.UndefinedSymbol, "Label used but not defined" },
            { MessageCode.DivisionByZero, "Division by Zero" },
            { MessageCode.InternalError, "Internal Error" },

            { MessageCode.UnknownError, "Unknown Error" },
        };
    }

    static class Message
    {
        public static List<MessageInformation> ErrorList { get; private set; }

        static Message()
        {
            ErrorList = new List<MessageInformation>();
        }

        public static void Add(string Source, int FileID, int Line, int Character, MessageCode Code, string Details = "")
        {
            if (!Settings.Messages.ContainsKey(Code) || Settings.Messages[Code] == Setting.On)
            {
                MessageInformation Error = new MessageInformation(FileID, Line, Character, Source, Code, Details);

                Add(Error);
            }
        }

        public static void Add(MessageInformation Error)
        {
            if (!Settings.Messages.ContainsKey(Error.Code) || Settings.Messages[Error.Code] == Setting.On)
                ErrorList.Add(Error);
        }

        public static int MessageCount()
        {
            return ErrorList.Count(e => e.Code < MessageCode.Warning);
        }

        public static int WarningCount()
        {
            return ErrorList.Count(e => e.Code >= MessageCode.Warning && e.Code < MessageCode.Error);
        }

        public static int ErrorCount()
        {
            return ErrorList.Count(e => e.Code >= MessageCode.Error);
        }
    }
}
