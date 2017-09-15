using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    class ZASMApp
    {
        static void Main(string[] args)
        {
            //var Data = System.IO.File.OpenRead(@"..\..\..\basic8k78-2.mac");
            //var Data = System.IO.File.OpenRead(@"..\..\..\test.asm");

            Parser Parse = new Parser();
            Parse.Parse(@"..\..\..\basic8k78-2.mac");
            //Parse.Parse(@"..\..\..\test.asm");

            Console.WriteLine("ZASM Results: Messages: {0}, Warnings: {1}, Errors: {2}", Message.Log.MessageCount(), Message.Log.WarningCount(), Message.Log.ErrorCount());

            foreach (MessageInformation CurrentMessage in Message.Log)
            {
                if (CurrentMessage.Code >= MessageCode.Warning && CurrentMessage.Code < MessageCode.Error)
                    Console.Write("Warning: ");

                else if (CurrentMessage.Code >= MessageCode.Error)
                    Console.Write("Error:   ");

                else
                    Console.Write("Message: ");

                if (CurrentMessage.FileID != 0)
                    Console.Write(CurrentMessage.FileID);
                Console.Write("({0}, {1}): ", CurrentMessage.Line, CurrentMessage.Character);
                Console.Write("{0} {1:X4}: ", CurrentMessage.Source, (int)CurrentMessage.Code);

                if (DataTables.MessageStrings.ContainsKey(CurrentMessage.Code))
                {
                    string MessageText = DataTables.MessageStrings[CurrentMessage.Code];
                    Console.Write(MessageText);
                }
                else
                {
                    Console.Write("Missing text");
                }

                if (CurrentMessage.Details != "")
                {
                    Console.Write(": ");
                    Console.Write(CurrentMessage.Details);
                }


                Console.WriteLine();
            }
        }
    }
}
