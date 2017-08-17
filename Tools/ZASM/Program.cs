using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    enum ParamFlags
    {
        None,
        //Index,   // The H,L and HL registers can also be Index Registers
        //Displacement,   // The HL register can be an Index register with displacment
        //InternalDisplacement, //  Same as above, but the displacment is inside the opcode
        EmbededIndex,       // The Index will be embeded in the opcode instead of following it (iiCBnnOP)

    }

    struct OpcodeEncoding
    {
        //public byte[] Encoding;

        //public CommandID Param1;
        //public ParameterType Param1Type;
        //public CommandID Param2;
        //public ParameterType Param2Type;
        //public CommandID Param3;
        //public ParameterType Param3Type;

        //public ParamFlags Flags;

        //public CommandID Function;

        public CommandID Function;
        public CommandID[] Params;
        public ParamFlags Flags;
        public byte Prefix;
        public byte Base;
    };

    class Program
    {
        static void Main(string[] args)
        {
            MessageLog.Log.GetEnumerator();
            
            //string TestLine = " label:  ld, ($0AAh << 8) + 0x55		; Load the byte at the return address into C\n  JP 	NZ, SETUP";
            //System.IO.MemoryStream Data = new System.IO.MemoryStream(UTF8Encoding.UTF8.GetBytes(TestLine));

            //var Data = System.IO.File.OpenRead(@"D:\Programing\Code\Cubit\Tools\basic8k78-2.mac");
            var Data = System.IO.File.OpenRead(@"..\..\..\basic8k78-2.mac");

            Parser Parse = new Parser();
            Parse.Parse(Data);

            Console.WriteLine("ZASM Results: Messages: {0}, Warnings: {1}, Errors: {2}", MessageLog.Log.MessageCount(), MessageLog.Log.WarningCount(), MessageLog.Log.ErrorCount());

            foreach (MessageInformation Message in MessageLog.Log)
            {
                if(Message.Code >= MessageCode.Warning && Message.Code < MessageCode.Error)
                    Console.Write("Warning: ");

                else if (Message.Code >= MessageCode.Error)
                    Console.Write("Error:   ");

                else 
                    Console.Write("Message: ");

                if (!string.IsNullOrEmpty(Message.FileName))
                    Console.Write(Message.FileName);
                Console.Write("({0}, {1}): ", Message.Line, Message.Character);
                Console.Write("{0} {1:X4}: ", Message.Source, (int)Message.Code);

                if (DataTables.MessageStrings.ContainsKey(Message.Code))
                {
                    string MessageText = DataTables.MessageStrings[Message.Code];
                    Console.Write(MessageText);
                }
                else
                {
                    Console.Write("Missing text");
                }

                if (Message.Details != "")
                {
                    Console.Write(": ");
                    Console.Write(Message.Details);
                }


                Console.WriteLine();
            }


            return;
        }
    }
}
