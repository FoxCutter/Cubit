using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TableBuilder
{  
    class TableBuilder
    {
        static void Main(string[] args)
        {
            OpcodeGroup GroupInfo;
            ////List<string> Data = new List<string>(File.ReadAllLines(@"Z80 Opcode Matrix.txt"));
            //System.Xml.Serialization.XmlSerializer Tx = new System.Xml.Serialization.XmlSerializer(typeof(z80Opcodes));

            //z80Opcodes KD =(z80Opcodes) Tx.Deserialize(File.OpenText(@"..\..\..\Z80-Opcodes.xml"));

            //var ee = KD.platform.Where(e => e.name == "Z80").First().opcode;

            //System.Resources.ResourceManager rm = new System.Resources.ResourceManager("TableBuilder", typeof(TableBuilder).Assembly);
            //var ss = rm.GetObject("Z80 Bin-Output.txt");
            //var ss = (List<OpcodeData>)rm.GetObject("Z80_Bin_Output");
            //MemoryStream MS = new MemoryStream(ss);

            //var asm = System.Reflection.Assembly.GetExecutingAssembly();
            //var k =asm.GetManifestResourceNames();
            //var t = asm.GetManifestResourceStream("TableBuilder.Resources.Z80 Bin-Output.txt");
            //System.Runtime.Serialization.Formatters.Binary.BinaryFormatter BB = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //var p = BB.Deserialize(t);

            //var t = OpcodeData.ZASM.z80OpcodeList.Where(e => e.Prefix == 0).ToList();
            
            System.Xml.Serialization.XmlSerializer Tx = new System.Xml.Serialization.XmlSerializer(typeof(z80Opcodes));
            z80Opcodes OpcodeInput = (z80Opcodes) Tx.Deserialize(File.OpenText(@"Z80-Opcodes.xml"));

            foreach (z80OpcodesPlatform Platform in OpcodeInput.platform)
            {
                GroupInfo = OpcodeReader.ReadOpcodeData(Platform);
                SaveGroupInfo(GroupInfo, Platform.name);
            }
        }

        static string GenerateOpcodeExample(OpcodeData.OpcodeEntry Entry, bool ForDecoding)
        {
            StringBuilder Output = new StringBuilder();

            if (Entry.Index == true)
                Output.AppendFormat("xx");

            if (Entry.Prefix != 0)
            {
                Output.AppendFormat("{0:X2}", Entry.Prefix);

                if (OpcodeReader.HasType(Entry, OpcodeData.ParameterType.WordIndexRegisterPointer))
                    Output.AppendFormat("oo");
            }

            Output.AppendFormat("{0:X2}", Entry.Encoding);

            if (Entry.Prefix == 0 & OpcodeReader.HasType(Entry, OpcodeData.ParameterType.WordIndexRegisterPointer))
                Output.AppendFormat("oo");

            if (OpcodeReader.HasParam(Entry, OpcodeData.ParameterID.ImmediateByte))
                Output.AppendFormat("nn");

            if (OpcodeReader.HasParam(Entry, OpcodeData.ParameterID.ImmediateWord))
                Output.AppendFormat("nnnn");

            Output.AppendFormat(": {0}", Entry.Name);

            bool First = true;
            foreach (OpcodeData.ParamEntry Param in Entry.Params)
            {
                if (!Param.Implicit || ForDecoding)
                {
                    if (!First)
                        Output.Append(',');

                    Output.AppendFormat(" {0}", Param.ToString());
                    First = false;
                }
            }


            return Output.ToString();
        }
        
        static string GenerateOpcode(OpcodeData.OpcodeEntry Entry, string Padding, bool ForDecoding)
        {
            StringBuilder Output = new StringBuilder();

            Output.Append(Padding);
            Output.Append("new OpcodeEntry { ");

            Output.AppendFormat("Index = {0,5}, ", Entry.Index.ToString().ToLower());
            Output.AppendFormat("Prefix = 0x{0}, ", Entry.Prefix.ToString("X2"));
            Output.AppendFormat("Encoding = 0x{0}, ", Entry.Encoding.ToString("X2"));
            Output.AppendFormat("Name = CommandID.{0,-4}, ", Entry.Name);
            Output.AppendFormat("Function = FunctionID.{0}, ", Entry.Function);

            //Output.Append("// ");
            //Output.Append(GenerateOpcodeExample(Entry));

            //Output.AppendLine();
            //Output.Append(Padding);
            //Output.Append("                 ");

            Output.Append("Params = new ParamEntry[] { ");

            foreach (OpcodeData.ParamEntry Param in Entry.Params)
            {
                //Output.AppendLine();
                //Output.Append(Padding);
                //Output.Append("                    ");

                if (!Param.Implicit || ForDecoding)
                {
                    Output.AppendFormat("new ParamEntry(ParameterID.{0}, ParameterType.{1}", Param.Param, Param.Type);
                    Output.AppendFormat(", EncodingType.{0}, {1}", Param.Encoding, Param.Implicit.ToString().ToLower());

                    Output.Append("), ");
                }

            }

            //Output.AppendLine();
            //Output.Append(Padding);
            //Output.Append("                 ");

            Output.Append("}, ");

            //Output.AppendLine();
            //Output.Append(Padding);
            //Output.Append("                 ");

            Output.AppendFormat("Type = OpcodeType.{0}, ", Entry.Type);
            Output.AppendFormat("Cycles = {0}, ", Entry.Cycles);
            Output.AppendFormat("Length = {0}, ", Entry.Length);

            //Output.AppendLine();
            //Output.Append(Padding);
            //Output.Append("                ");

            Output.Append("}, ");

            Output.Append("// ");
            Output.Append(GenerateOpcodeExample(Entry, ForDecoding));

            return Output.ToString();
        }

        static void WriteDecodingRange(StreamWriter OutputFile, IEnumerable<OpcodeData.OpcodeEntry> Range)
        {
            int Count = 0;
            OpcodeData.OpcodeEntry Dummy = new OpcodeData.OpcodeEntry();
            Dummy.Function = OpcodeData.FunctionID.None;
            Dummy.Name = OpcodeData.CommandID.None;
            Dummy.Params = new OpcodeData.ParamEntry[0];

            if (Range.Count() == 0)
                return;

            OutputFile.WriteLine("           {");

            //for (int x = 0; x < 0x100; x++)
            //{
            //    var list = Range.Where(e => e.Base == x);
            //    if (list.Count() == 0)
            //    {
            //        Dummy.Base = x;
            //        OutputFile.WriteLine(GenerateOpcode(Dummy, "              ", true));
            //    }
            //    else foreach (OpcodeDataEntry Entry in list)
            //    {
            //        OutputFile.WriteLine(GenerateOpcode(Entry, "              ", true));
            //    }
            //}
            
            //if (Range.Count() != 0)
            {
                foreach (OpcodeData.OpcodeEntry Entry in Range)
                {
                    while (Count < Entry.Encoding)
                    {
                        Dummy.Encoding = (byte) Count;
                        OutputFile.WriteLine(GenerateOpcode(Dummy, "              ", true));
                        Count++;
                    }

                    OutputFile.WriteLine(GenerateOpcode(Entry, "              ", true));

                    Count++;
                }

                while (Count < 0x100)
                {
                    Dummy.Encoding = (byte) Count;
                    OutputFile.WriteLine(GenerateOpcode(Dummy, "              ", true));
                    Count++;
                }
            }

            OutputFile.WriteLine("           },");
        }
      
        static void SaveGroupInfo(OpcodeGroup GroupInfo, string Prefix)
        {
            {
                string FileName = @".\Common\" + Prefix + "_ZASM.cs";
                using (StreamWriter OutputFile = new StreamWriter(FileName, false))
                {
                    OutputFile.WriteLine("using CommandList = System.Collections.Generic.SortedList<string, OpcodeData.CommandID>;");
                    OutputFile.WriteLine();
                    OutputFile.WriteLine("namespace OpcodeData");
                    OutputFile.WriteLine("{"); 
                    OutputFile.WriteLine("    public static partial class ZASM");
                    OutputFile.WriteLine("    {");
                    OutputFile.WriteLine("        public static OpcodeEntry[] {0}OpcodeList = new OpcodeEntry[]", Prefix);
                    OutputFile.WriteLine("        {");

                        foreach (OpcodeData.OpcodeEntry Entry in GroupInfo.OpcodeList.OrderBy(e => e.Name))
                        {
                            if (Entry.Type == OpcodeData.OpcodeType.Unofficial)
                                continue;

                            OutputFile.WriteLine(GenerateOpcode(Entry, "            ", false));
                        }

                    OutputFile.WriteLine("        };");

                    OutputFile.WriteLine();
                    
                    OutputFile.WriteLine("        public static CommandList {0}Commands = new CommandList()", Prefix);
                    OutputFile.WriteLine("        {");

                        foreach (OpcodeData.OpcodeEntry Entry in GroupInfo.OpcodeList.DistinctBy(e => e.Name).OrderBy(e => e.Name))
                        {
                            if (Entry.Type == OpcodeData.OpcodeType.Unofficial)
                                continue;

                            OutputFile.WriteLine("           {{ \"{0}\", CommandID.{0} }},", Entry.Name);    
                        }

                    OutputFile.WriteLine("        };");
                    OutputFile.WriteLine("    }");
                    OutputFile.WriteLine("}");
                }
            }

            {
                string FileName = @".\Common\" + Prefix + "_ZEMU.cs";
                using (StreamWriter OutputFile = new StreamWriter(FileName, false))
                {
                    OutputFile.WriteLine("namespace OpcodeData");
                    OutputFile.WriteLine("{");
                    OutputFile.WriteLine("    public static partial class ZEMU");
                    OutputFile.WriteLine("    {");
                    OutputFile.WriteLine("        public static OpcodeEntry[,] {0}OpcodeList = new OpcodeEntry[,]", Prefix);
                    //OutputFile.WriteLine("        public static OpcodeEntry[] {0}OpcodeList = new OpcodeEntry[]", Prefix);
                    OutputFile.WriteLine("        {");

                    //foreach (OpcodeDataEntry Entry in GroupInfo.OpcodeMatrix)
                    //{
                    //    OutputFile.WriteLine(GenerateOpcode(Entry, "           ", true));
                    //}

                    OutputFile.WriteLine("           // No Prefix");
                    WriteDecodingRange(OutputFile, GroupInfo.OpcodeMatrix.Where(e => e.Prefix == 0x00 && e.Index == false));
                    OutputFile.WriteLine();

                    OutputFile.WriteLine("           // 0xCB Prefix");
                    WriteDecodingRange(OutputFile, GroupInfo.OpcodeMatrix.Where(e => e.Prefix == 0xCB && e.Index == false));
                    OutputFile.WriteLine();

                    OutputFile.WriteLine("           // 0xED Prefix");
                    WriteDecodingRange(OutputFile, GroupInfo.OpcodeMatrix.Where(e => e.Prefix == 0xED && e.Index == false));
                    OutputFile.WriteLine();

                    OutputFile.WriteLine("           // Index Prefix");
                    WriteDecodingRange(OutputFile, GroupInfo.OpcodeMatrix.Where(e => e.Prefix == 0x00 && e.Index == true));
                    OutputFile.WriteLine();

                    OutputFile.WriteLine("           // Index 0xCB Prefix");
                    WriteDecodingRange(OutputFile, GroupInfo.OpcodeMatrix.Where(e => e.Prefix == 0xCB && e.Index == true));

                    OutputFile.WriteLine("        };");
                    OutputFile.WriteLine("    }");
                    OutputFile.WriteLine("}");
                }
            }
        }
    }
}
