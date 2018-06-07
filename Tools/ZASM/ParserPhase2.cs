using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZASM
{
    partial class Parser
    {
        void OutputListingData(TextWriter OutputStream, int? Cycles = null, short? Address = null, byte[] Bytes = null)
        {
            // Cycles
            if (Cycles.HasValue)
                OutputStream.Write("{0,-8}  ", Cycles.Value);
            else
                OutputStream.Write("          ");

            // Address
            if (Address.HasValue)
                OutputStream.Write("{0:X4}  ", Address.Value);
            else
                OutputStream.Write("      ");

            // Bytes
            if (Bytes != null)
            {
                int x;
                for (x = 0; x < 4 && x < Bytes.Length; x++)
                {
                    OutputStream.Write("{0:X2}", Bytes[x]);
                }

                for (; x < 4; x++)
                {
                    OutputStream.Write("  ");
                }

                OutputStream.Write("  ");
            }
            else
            {
                OutputStream.Write("          ");
            }

        }

        void OutputListingLine(TextWriter OutputStream, LineInformation CurrentLine, string LineData)
        {
            // Line Number
            OutputStream.Write("{0, 4}: ", CurrentLine.LineNumber);

            if (CurrentLine.Object != null)
            {
                if (CurrentLine.Object.Type == ObjectType.Conditional)
                {
                    ConditionalObject Object = CurrentLine.Object as ConditionalObject;
                    if (Object.Command == FunctionID.ENDIF)
                        OutputListingData(OutputStream, Object.Level, null);
                    else
                        OutputListingData(OutputStream, Object.Level, CurrentLine.ParseLine ? (short)-1 : (short)0);
                }
                else
                {
                    OutputListingData(OutputStream);
                }
            }
            else
            {
                OutputListingData(OutputStream);
            }

            OutputStream.WriteLine(LineData);

            var ErrorList = Message.ErrorList.Where(e => e.FileID == CurrentLine.FileID && e.Line == CurrentLine.LineNumber);
            foreach (MessageInformation Error in ErrorList)
            {
                OutputStream.Write("{0}", Error.Message);
                if (Error.Details != "")
                {
                    OutputStream.Write(": ");
                    OutputStream.Write(Error.Details);
                }

                OutputStream.WriteLine();
            }
        }

        bool Phase2(FileInformation File, bool ListingOnly, TextWriter OutputStream, IEnumerator<LineInformation> DataSet)
        {
            bool Success = true;
            if (File.Stream == null)
            {
                Message.Add("Pass 2", File.FileID, 0, 0, MessageCode.InternalError, "File Stream Missing");
                return false;
            }
            
            File.Stream.Position = 0;
            StreamReader DataStream = new StreamReader(File.Stream);

            int OutputLine = 0;

            while (OutputLine + 1 != File.LineCount && DataSet.MoveNext())
            {
                LineInformation CurrentLine = DataSet.Current;
                string Line = DataStream.ReadLine();

                OutputLine++;

                if (CurrentLine.LineNumber != OutputLine)
                {
                    Message.Add("Pass 2", File.FileID, CurrentLine.LineNumber, 0, MessageCode.InternalError, "File Input Dysync");
                }

                OutputListingLine(OutputStream, CurrentLine, Line);

                if (CurrentLine.Object != null && CurrentLine.Object.Type == ObjectType.Include && !CurrentLine.Object.Error)
                {
                    IncludeObject Include = CurrentLine.Object as IncludeObject;
                    OutputStream.WriteLine("**** {0} ****", Include.IncludeFile.Name);

                    Phase2(Include.IncludeFile, ListingOnly, OutputStream, DataSet);

                    OutputStream.WriteLine("**** {0} ****", File.Name);
                }

            }

            return Success;
        }
    
    }
}
