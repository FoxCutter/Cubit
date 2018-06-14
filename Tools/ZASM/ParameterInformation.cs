using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    class ParameterInformation
    {
        public List<Token> Tokens;
        public bool Error;

        public OpcodeData.ParameterType Type;
        public OpcodeData.ParameterID Parameter;

        public ParameterInformation()
        {
            Tokens = new List<Token>();
            Error = false;

            Parameter = OpcodeData.ParameterID.None;
            Type = OpcodeData.ParameterType.Unknown;
        }

        public bool OrderValues()
        {

            return false;
        }
    }
}
