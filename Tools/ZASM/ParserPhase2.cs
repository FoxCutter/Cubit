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
        void OutputListingData(TextWriter OutputStream, string Cycles = "", short? Address = null, byte[] Bytes = null)
        {
            // Cycles
            if (Cycles != "")
                OutputStream.Write("{0,9}  ", Cycles);
            else
                OutputStream.Write("           ");

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
            OutputStream.Write("{0, 4}:", CurrentLine.LineNumber);

            if (CurrentLine.Object != null)
            {
                switch (CurrentLine.Object.Type)
                {
                    case ObjectType.Conditional:
                        {
                            ConditionalObject Object = CurrentLine.Object as ConditionalObject;
                            if(Object == null)
                                OutputListingData(OutputStream, Object.Level.ToString());

                            else if (Object.Command == FunctionID.IF && Object.Conditional.SavedParse == true)
                                OutputListingData(OutputStream, Object.Level.ToString(), CurrentLine.ParseLine ? (short)-1 : (short)0);
                            
                            else
                                OutputListingData(OutputStream, Object.Level.ToString());
                        }
                        break;

                    case ObjectType.Opcode:
                        {
                            OpcodeObject Object = CurrentLine.Object as OpcodeObject;
                            OutputListingData(OutputStream, string.Format("{0,5}+{1,-3}", Object.CycleCount, Object.Opcode.Cycles), Object.Address);
                        }
                        break;

                    case ObjectType.Label:
                        {
                            LabelObject Object = CurrentLine.Object as LabelObject;
                            OutputListingData(OutputStream, "-   ");
                        }
                        break;

                    case ObjectType.Value:
                        {
                            ValueObject Object = CurrentLine.Object as ValueObject;
                            OutputListingData(OutputStream, "-   ", Object.Symbol.Value);
                        }
                        break;

                    default:
                        OutputListingData(OutputStream);
                        break;
                }

            }
            else if (CurrentLine.Label != null)
            {
                OutputListingData(OutputStream, "-   ", CurrentLine.Label.Address);
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
