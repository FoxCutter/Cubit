using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    [Flags]
    enum RegParam : byte
    {
        None = 0x00,            // No flags on this register
        Reference = 0x01,       // Memory Reference (Memory, BC, DE, HL, SP, IX, IY, nn)
        WordData = 0x02,        // The Referenced data is Word sized, not byte
        Literal = 0x04,         // The byte value in the register is used as the input value
        ConditionCode = 0x08,   // The Byte value in the register is the condition code to test for
    }

    struct OpcodeEncoding
    {
        public string Name;

        public byte[] Encoding;

        public CommandID Reg1;
        public RegParam Reg1Param;

        public CommandID Reg2;
        public RegParam Reg2Param;

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

            Parser Parse = new Parser(Data);
            Parse.Parse();

            return;
        }
    }
}
