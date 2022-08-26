using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 * 
 * Options:
 * (IA) Implicit A - On (Default), Off, Warn
 * (IX) Indexs - On (Z80), off
 * (AF) Array Offsets - On, off (Default)
 * (CY) CY as Carry - On (Default), off
 * (DT) Commands Require Dot - On, off, Warn (Default)
 * (LB) Labels Require Colon - On, off, Warn (Default)
 * 
 * Command Line: -oXX:value 
 * Command: .Command XX, Value
 * 
 * Warnings, on and off
 * 
 * Command Line -Wxxxx:value
 * Command .Warning xxxx, Value
 * 
 *  For each line
 *      Token List
 *      Section
 *      Symbol link
 *      Address
 *      Opcode Encode
 *      Skip
 *      File Info
 *      
 * Pass 1:
 *  For Each line
 *      Read Line
 *      Parse first statement
 *      if in a preprocesses if/else decide if line needs to be processesd
 *      Process remainer of line
 *      Symbol management
 *      Resolve values only if needed
 *  Sanity check all address symbols for values
 *  Adjust symbol address for section and section placements.
 * 
 * Pass 2:
 *  For each line
 *      Resolve all calculations
 *      Read line from input file
 *      Emite Code if needed
 *      Emite list file     
 *      
 * 
 * Output Object:
 *  Name
 *  Flags
 *  Init
 *  SetInfo
 *  Directive
 *  Output
 *  SymDef
 *  Section
 *  Filename
 *  Cleanup
 *  
*/

namespace ZASM
{
    class ZASM
    {
        static void Main(string[] args)
        {
            Settings.CommandRequiresDot = Setting.Off;
            Settings.ArrayOffset = Setting.On;
            Settings.LabelsRequireColon = Setting.Warning;
            Settings.ImplicitA = Setting.On;
            Settings.Indexes = Setting.On;

            Settings.IncludePaths.Add(@"..\..\..\");
            
            Parser ParserData = new Parser();
            ParserData.ParseFile(@"..\..\..\Master.z80");
            //ParserData.ParseFile(@"..\..\..\Test.asm");

            Message.Add("", 0, 0, 0, MessageCode.NoError, "");
            Console.WriteLine("ZASM Results: Messages: {0}, Warnings: {1}, Errors: {2}", Message.MessageCount(), Message.WarningCount(), Message.ErrorCount());

            int Max = 0;
            
            foreach (MessageInformation CurrentMessage in Message.ErrorList)
            {
                if (Max > 50)
                    break;

                if (CurrentMessage.Code >= MessageCode.Warning && CurrentMessage.Code < MessageCode.Error)
                    Console.Write("Warning: ");

                else if (CurrentMessage.Code >= MessageCode.Error)
                    Console.Write("Error: ");

                else
                    Console.Write("Message: ");

                if (CurrentMessage.FileID != 0)
                    Console.Write("{0} ", ParserData.LookupFileName(CurrentMessage.FileID));

                Console.Write("({0}, {1}): ", CurrentMessage.Line, CurrentMessage.Character);
                Console.Write("{0} {1:X4}: ", CurrentMessage.Source, (int)CurrentMessage.Code);

                Console.Write(CurrentMessage.Message);
                
                if (CurrentMessage.Details != "")
                {
                    Console.Write(": ");
                    Console.Write(CurrentMessage.Details);
                }

                Max++;

                Console.WriteLine();
            }
        
        }
    }
}
