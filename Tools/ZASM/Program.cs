using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    [Flags]
    enum ParamFlags
    {
        None        = 0x00,
        AssumeA     = 0x01,
        Index       = 0x02,   // The H,L and HL registers can also be Index Registers
        Displacement= 0x04,   // The HL register can be an Index register with displacment
    }

    struct OpcodeEncoding
    {
        public string Name;

        public byte[] Encoding;

        public CommandID Param1;
        public ParamType Param1Type;
        public CommandID Param2;
        public ParamType Param2Type;

        public ParamFlags Flags;

        public CommandID Function;
    };   

    class Program
    {
        static void Main(string[] args)
        {
            //string TestLine = " label:  ld, ($0AAh << 8) + 0x55		; Load the byte at the return address into C\n  JP 	NZ, SETUP";
            //System.IO.MemoryStream Data = new System.IO.MemoryStream(UTF8Encoding.UTF8.GetBytes(TestLine));

            //var Data = System.IO.File.OpenRead(@"D:\Programing\Code\Cubit\Tools\basic8k78-2.mac");
            var Data = System.IO.File.OpenRead(@"..\..\..\basic8k78-2.mac");

            Parser Parse = new Parser();
            Parse.Parse(Data);

            return;
        }
    }
}
