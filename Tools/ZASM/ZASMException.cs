using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    class ZASMException : SystemException
    {
        public int LineNumber { get; private set; }
        public int Character { get; private set; }

        public string ErrorCode { get; private set; }

        public ZASMException(int ExLineNumber, int ExCharacter, string exErrorCode, string exMessage)
            : base (exMessage)
        {
            LineNumber = ExLineNumber;
            Character = ExCharacter;
            ErrorCode = exErrorCode;
        }
        
        public ZASMException(string ExMessage)
            : this(-1, -1, "", ExMessage)
        {
        }

        public ZASMException(string exErrorCode, string ExMessage)
            : this(-1, -1, exErrorCode, ExMessage)
        {
        }

        public ZASMException(string Message, Exception innerException) 
            : base(Message, innerException)
        {
            
        }

    }
}
