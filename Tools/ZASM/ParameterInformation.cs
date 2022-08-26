using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    class ParameterToken
    {
        public Token Token;
        public bool Error;

        public List<ParameterToken> GroupTokens;

        public ParameterToken()
        {
            Token = null;
            Error = false;
            GroupTokens = null;
        }

        public ParameterToken(Token CurrentToken, bool Error = false)
        {
            Token = CurrentToken;
            this.Error = Error;
            GroupTokens = null;
        }

        public override string ToString()
        {
            if(Token != null)
                return Token.ToString();

            if (GroupTokens != null)
                return string.Join(" ", GroupTokens);

            return "ERROR";
        }
    }


    class ParameterInformation
    {
        public List<ParameterToken> Tokens;
        public bool Error;
        public bool Pointer;

        public OpcodeData.ParameterType Type;
        //public OpcodeData.ParameterID Parameter;

        public ParameterInformation()
        {
            Tokens = new List<ParameterToken>();
            Error = false;

            //Parameter = OpcodeData.ParameterID.None;
            Type = OpcodeData.ParameterType.Unknown;
        }

        public bool OrderValues()
        {

            return false;
        }
    }
}
