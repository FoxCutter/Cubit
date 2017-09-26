using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    class ParameterInformation
    {
        public List<Token> TokenList;

        public bool Pointer;

        public ParameterInformation()
        {
            TokenList = new List<Token>();
            Pointer = false;
        }

        public override string ToString()
        {
            StringBuilder Ret = new StringBuilder();

            for (int x = 0; x < TokenList.Count; x++)
            {
                if (x != 0)
                    Ret.Append(" ");

                Ret.Append(TokenList[x].ToString());
            }

            return Ret.ToString();

        }
    }
}
