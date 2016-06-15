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
        NoError                     = 0x0000,        

        Warning                     = 0x4000,

        Error                       = 0x8000,
        InvalidNumberToken          = Error,
        UnexpectedLineBreak,
        UnexpectedSymbol,
        InvalidParamaterForOpcode,


        UndefinedSymbol,
        DivisionByZero,

        UnknownError                = 0xFFFF,
    }

    struct MessageInformation : IComparer<MessageInformation>, IComparable<MessageInformation>
    {
        // The location of the error
        public FileInformation File;
        public int Line;
        public int Character;
        
        // The error code and details related to it. 
        public MessageCode Code;
        public string Source;
        public string Details;
       
        public int Compare(MessageInformation x, MessageInformation y)
        {
            if (x.File != null && y.File != null)
            {
                if (!string.Equals(x.File.FullName, y.File.FullName, StringComparison.OrdinalIgnoreCase))
                    return string.Compare(x.File.FullName, y.File.FullName, true);
            }

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
    }

    class MessageLog : IEnumerable<MessageInformation>
    {
        public static MessageLog Log = new MessageLog();
        
        List<MessageInformation> _ErrorList;

        public MessageLog()
        {
            _ErrorList = new List<MessageInformation>();
        }

        public void Add(string Source, Token Object, MessageCode Code, string Details = "")
        {
            MessageInformation Error = new MessageInformation()
            {
                File = Object.Location.File,
                Line = Object.Location.Line,
                Character = Object.Location.Character,
                Details = Details,
                Source = Source,
                Code = Code,
            };

            MessageLog.Log.Add(Error);
        }

        public void Add(string Source, TokenLocation Location, MessageCode Code, string Details = "")
        {
            MessageInformation Error = new MessageInformation()
            {
                File = Location.File,
                Line = Location.Line,
                Character = Location.Character,
                Details = Details,
                Source = Source,
                Code = Code,
            };

            MessageLog.Log.Add(Error);
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
            _ErrorList.Sort();
            return _ErrorList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
