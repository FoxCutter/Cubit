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
        RegisterMissingAssumingA,


        Error = 0x8000,
        InvalidNumberToken = Error,
        UnexpectedLineBreak,
        UnexpectedSymbol,
        InvalidParamaterForOpcode,
        ValueMissing,
        MissingGroupSymbol,
        DataTypeMisMatch,
        SyntaxError,
        UnknownCommand,
        ReservedWord,


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
            { MessageCode.RegisterMissingAssumingA, "Register Missing, using 'A'"},

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

            { MessageCode.UndefinedSymbol, "Label used but not defined" },
            { MessageCode.DivisionByZero, "Division by Zero" },
            { MessageCode.InternalError, "Internal Error" },

            { MessageCode.UnknownError, "Unknown Error" },
        };
    }

    class Message : IEnumerable<MessageInformation>
    {
        public static Message Log = new Message();
        List<MessageInformation> _ErrorList;

        public Message()
        {
            _ErrorList = new List<MessageInformation>();
        }

        public void Add(string Source, int FileID, int Line, int Character, MessageCode Code, string Details = "")
        {
            MessageInformation Error = new MessageInformation(FileID, Line, Character, Source, Code, Details);

            Log.Add(Error);
        }


        public void Add(MessageInformation Error)
        {
            _ErrorList.Add(Error);
        }

        public int MessageCount()
        {
            return _ErrorList.Count(e => e.Code < MessageCode.Warning);
        }

        public int WarningCount()
        {
            return _ErrorList.Count(e => e.Code >= MessageCode.Warning && e.Code < MessageCode.Error);
        }

        public int ErrorCount()
        {
            return _ErrorList.Count(e => e.Code >= MessageCode.Error);
        }

        public IEnumerator<MessageInformation> GetEnumerator()
        {
            return _ErrorList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
