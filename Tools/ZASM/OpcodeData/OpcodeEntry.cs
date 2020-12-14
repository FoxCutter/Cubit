using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcodeData
{
    public class OpcodeEntry
    {
        public CommandID Name;
        public FunctionID Function;
        public bool Index;
        public byte Prefix;
        public byte Encoding;
        public ParamEntry[] Arguments;
        public OpcodeStatus Status;
        public short Cycles;
        public short TStates;
        public byte Length;

        public override string ToString()
        {
            StringBuilder Output = new StringBuilder();

            Output.AppendFormat("{0}", Name);

            bool first = true;
            foreach (ParamEntry Param in Arguments)
            {
                if (!first)
                    Output.Append(',');

                Output.AppendFormat(" {0}", Param.ToString());

                first = false;
            }

            return Output.ToString();
        }
    }
}
