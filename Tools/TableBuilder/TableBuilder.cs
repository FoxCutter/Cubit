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
        static bool Long = false;

        static void Main(string[] args)
        {
            //OpcodeGroup GroupInfo;          
            System.Xml.Serialization.XmlSerializer Tx = new System.Xml.Serialization.XmlSerializer(typeof(Opcodes.OpcodeData));
            Opcodes.OpcodeData OpcodeInput = (Opcodes.OpcodeData) Tx.Deserialize(File.OpenText(@".\Opcode Tables\Opcodes.xml"));

            // For Assambly
            Dictionary<string, List<LocalOpcodeEntry>> OpcodeEncodings = new Dictionary<string, List<LocalOpcodeEntry>>();

            // For Disasambly
            Dictionary<string, List<LocalOpcodeEntry>> OpcodeMaps = new Dictionary<string, List<LocalOpcodeEntry>>();

            List<LocalOpcodeEntry> AllOpcodes = new List<LocalOpcodeEntry>();

            foreach (Opcodes.opcodeType OpcodeEntry in OpcodeInput.Opcode)
            {
                foreach(Opcodes.opcodeEncoding Encoding in OpcodeEntry.Encoding)
                {
                    LocalOpcodeEntry Opcode = OpcodeReader.ReadOpcode(OpcodeEntry, Encoding);
                    AllOpcodes.Add(Opcode);

                    // Don't bother add execute only opcodes to the Encodings
                    if (Opcode.Status != Opcodes.statusEnum.ExecuteOnly)
                    {
                        if (!OpcodeEncodings.ContainsKey(Opcode.Platform))
                        {
                            OpcodeEncodings[Opcode.Platform] = new List<LocalOpcodeEntry>();
                        }

                        OpcodeEncodings[Opcode.Platform].Add(Opcode);

                    }

                    List<LocalOpcodeEntry> Expanded = OpcodeReader.ExpandOpcodeEntry(Opcode);

                    if (!OpcodeMaps.ContainsKey(Opcode.Platform))
                    {
                        OpcodeMaps[Opcode.Platform] = new List<LocalOpcodeEntry>();
                    }

                    foreach (LocalOpcodeEntry NewEntry in Expanded)
                    {
                        // Only add prefered versions to the opcode processing map
                        if (!NewEntry.Prefered)
                            continue;

                        // Can't have HL and an index reg in the same opcode
                        if (OpcodeReader.HasParam(NewEntry, OpcodeData.ParameterID.WordReg_HL) & OpcodeReader.HasParam(NewEntry, OpcodeData.ParameterID.WordReg_Iz))
                            continue;

                        OpcodeMaps[Opcode.Platform].Add(NewEntry);
                    }
                }
            }

            foreach (var OpcodeList in OpcodeEncodings)
            {
                SaveGroupInfo(OpcodeList.Key, OpcodeList.Value);
            }

            foreach (var OpcodeMap in OpcodeMaps)
            {
                SaveDecodedInfo(OpcodeMap.Key, OpcodeMap.Value);
            }

            SaveEnumInfo(AllOpcodes);
                
        }

        static string GenerateOpcodeExample(LocalOpcodeEntry Entry, bool ForDecoding)
        {
            StringBuilder Output = new StringBuilder();

            if (Entry.Index == true)
                Output.AppendFormat("iz");

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

            Output.Append(": ");
            if (Entry.Status == Opcodes.statusEnum.Undocumented)
                Output.Append("*");

            Output.Append(Entry.Menmontic);

            bool First = true;
            foreach (OpcodeData.ParamEntry Param in Entry.Arguments)
            {
                if (!Param.Implicit || ForDecoding)
                {
                    if (!First)
                        Output.Append(',');

                    Output.AppendFormat(" {0}{1}", Param.Implicit ? "|" : "", ParamString(Param, Entry.i8080));

                    First = false;
                }
            }

            return Output.ToString();
        }

        public static string ParamString(OpcodeData.ParamEntry Entry, bool i8080 = false)
        {
            switch (Entry.Param)
            {
                case OpcodeData.ParameterID.RegisterAny:
                    {
                        if (Entry.Type == OpcodeData.ParameterType.WordRegister)
                            return "rr";

                        else if (Entry.Type == OpcodeData.ParameterType.ByteRegister)
                            return "r";

                        else if (Entry.Type == OpcodeData.ParameterType.ByteIndexRegister)
                            return "Izb";

                        else if (Entry.Type == OpcodeData.ParameterType.WordIndexRegister)
                            return "Iz";

                        else if (Entry.Type == OpcodeData.ParameterType.WordIndexRegisterPointer) // should never happen, but better to be safe
                            return "(Iz + oo)";
                    }

                    return "r?";

                case OpcodeData.ParameterID.FlagsAny:
                    return "ff";

                case OpcodeData.ParameterID.ImmediateWord:
                    {
                        if (Entry.Type == OpcodeData.ParameterType.AddressPointer && !i8080)
                            return "(nnnn)";

                        return "nnnn";
                    }

                case OpcodeData.ParameterID.ImmediateByte:
                    {
                        if (Entry.Type == OpcodeData.ParameterType.Displacment)
                            return "e-2";

                        else if (Entry.Type == OpcodeData.ParameterType.HighMemPointerPlus)
                            return "($ff00 + nn)";

                        else if (Entry.Type == OpcodeData.ParameterType.BytePointer)
                            return "(nn)";

                        else if (Entry.Type == OpcodeData.ParameterType.SPPlusOffset)
                            return "SP + nn";

                        return "nn";
                    }

                case OpcodeData.ParameterID.EncodedValue:
                    return "e";

                case OpcodeData.ParameterID.Flag_Z:
                    return "Z";

                case OpcodeData.ParameterID.Flag_NZ:
                    return "NZ";

                case OpcodeData.ParameterID.Flag_CY:
                    return "CY";

                case OpcodeData.ParameterID.Flag_NC:
                    return "NC";

                case OpcodeData.ParameterID.Flag_P:
                    return "P";

                case OpcodeData.ParameterID.Flag_M:
                    return "M";

                case OpcodeData.ParameterID.Flag_PO:
                    return "PO";

                case OpcodeData.ParameterID.Flag_PE:
                    return "PE";

                case OpcodeData.ParameterID.Flag_NK:
                    return "NK";

                case OpcodeData.ParameterID.Flag_K:
                    return "K";


                case OpcodeData.ParameterID.WordReg_Iz:
                    if (Entry.Type == OpcodeData.ParameterType.WordIndexRegisterPointer)
                        return ("(Iz + oo)");

                    return ("Iz");

                case OpcodeData.ParameterID.WordReg_AF_Alt:
                    return "AF'";

                case OpcodeData.ParameterID.WordReg_AF:
                    return "AF";

                case OpcodeData.ParameterID.WordReg_PSW:
                    return "PSW";

                case OpcodeData.ParameterID.WordReg_BC:
                    if (i8080)
                        return "B";

                    if (Entry.Type == OpcodeData.ParameterType.WordRegisterPointer)
                        return ("(BC)");

                    return "BC";

                case OpcodeData.ParameterID.WordReg_DE:
                    if (i8080)
                        return "D";

                    if (Entry.Type == OpcodeData.ParameterType.WordRegisterPointer)
                        return ("(DE)");

                    return "DE";

                case OpcodeData.ParameterID.WordReg_HL:
                    if (i8080)
                    {
                        return "H";
                    }

                    if (Entry.Type == OpcodeData.ParameterType.WordRegisterPointer)
                        return ("(HL)");

                    return "HL";

                case OpcodeData.ParameterID.WordReg_BD:
                    if (i8080)
                        return "rp";

                    if (Entry.Type == OpcodeData.ParameterType.WordRegisterPointer)
                        return ("(rp)");

                    return "rp";

                case OpcodeData.ParameterID.WordReg_SP:
                    if (Entry.Type == OpcodeData.ParameterType.WordRegisterPointer)
                        return ("(SP)");

                    return "SP";

                case OpcodeData.ParameterID.WordReg_HLI:
                    return ("(HLI)");

                case OpcodeData.ParameterID.WordReg_HLD:
                    return ("(HLD)");

                case OpcodeData.ParameterID.WordReg_IX:
                    return ("IX");

                case OpcodeData.ParameterID.WordReg_IY:
                    return ("IY");

                case OpcodeData.ParameterID.ByteReg_A:
                    return "A";

                case OpcodeData.ParameterID.ByteReg_B:
                    return "B";

                case OpcodeData.ParameterID.ByteReg_C:
                    if (Entry.Type == OpcodeData.ParameterType.HighMemPointerPlus)
                        return ("($ff00 + C)");

                    else if (Entry.Type == OpcodeData.ParameterType.BytePointer)
                        return ("(C)");

                    return "C";

                case OpcodeData.ParameterID.ByteReg_D:
                    return "D";

                case OpcodeData.ParameterID.ByteReg_E:
                    return "E";

                case OpcodeData.ParameterID.ByteReg_H:
                    return "H";

                case OpcodeData.ParameterID.ByteReg_L:
                    return "L";

                case OpcodeData.ParameterID.ByteReg_M:
                    return "M";

                case OpcodeData.ParameterID.ByteReg_I:
                    return "I";

                case OpcodeData.ParameterID.ByteReg_R:
                    return "R";

                case OpcodeData.ParameterID.ByteReg_IzH:
                    return "IzH";

                case OpcodeData.ParameterID.ByteReg_IzL:
                    return "IzL";

                case OpcodeData.ParameterID.ByteReg_Izb:
                    return "Izb";

                case OpcodeData.ParameterID.ByteReg_IXH:
                    return "IXH";

                case OpcodeData.ParameterID.ByteReg_IXL:
                    return "IXL";

                case OpcodeData.ParameterID.ByteReg_IYH:
                    return "IYH";

                case OpcodeData.ParameterID.ByteReg_IYL:
                    return "IYL";
            }

            if (Entry.Type == OpcodeData.ParameterType.Value && Entry.Param >= OpcodeData.ParameterID.Value0 && Entry.Param <= OpcodeData.ParameterID.Value7)
                return (Entry.Param - OpcodeData.ParameterID.Value0).ToString();

            if (Entry.Type == OpcodeData.ParameterType.RstValue && Entry.Param >= OpcodeData.ParameterID.Value0 && Entry.Param <= OpcodeData.ParameterID.Value7)
                return String.Format("{0:X2}h", (Entry.Param - OpcodeData.ParameterID.Value0) * 8);

            return Entry.Param.ToString();
        }

        static string GenerateParams(LocalOpcodeEntry Entry, string Padding)
        {
            StringBuilder Output = new StringBuilder();

            if (Entry.Arguments.Length == 0)
            {
                Output.Append(" {}, ");
            }
            else
            {

                if (Long)
                {
                    Output.AppendLine();
                    Output.Append(Padding);
                    Output.Append("                    { ");
                }
                else
                {
                    Output.Append(" {");
                }

                foreach (OpcodeData.ParamEntry Param in Entry.Arguments)
                {
                    if (Long)
                    {
                        Output.AppendLine();
                        Output.Append(Padding);
                        Output.Append("                       ");
                    }

                    Output.AppendFormat("new ParamEntry {{ Param = ParameterID.{0}, Type = ParameterType.{1}", Param.Param, Param.Type);

                    if (Param.Encoding != OpcodeData.EncodingType.None)
                        Output.AppendFormat(", Encoding = EncodingType.{0}", Param.Encoding);

                    if (Param.Implicit)
                        Output.AppendFormat(", Implicit = {0}", Param.Implicit.ToString().ToLower());

                    Output.Append("}, ");
                }

                if (Long)
                {
                    Output.AppendLine();
                    Output.Append(Padding);
                    Output.Append("                    ");
                }

                Output.Append("}, ");
            }

            return Output.ToString();
        }

        static string GenerateOpcode(LocalOpcodeEntry Entry, string Padding)
        {
            StringBuilder Output = new StringBuilder();

            Output.Append(Padding);
            Output.Append("new OpcodeEntry { ");

            if(Long)
            {
                Output.Append("  // ");
                Output.Append(GenerateOpcodeExample(Entry, false));

                Output.AppendLine();
                Output.Append(Padding);
                Output.Append("                    ");
            }

            if(Entry.Index)
                Output.AppendFormat("Index = {0}, ", Entry.Index.ToString().ToLower());

            if (Entry.Prefix != 0)
                Output.AppendFormat("Prefix = 0x{0}, ", Entry.Prefix.ToString("X2"));

            Output.AppendFormat("Encoding = 0x{0}, ", Entry.Encoding.ToString("X2"));
            Output.AppendFormat("Name = CommandID.{0}, ", Entry.Menmontic);

            if (Entry.Status != Opcodes.statusEnum.Documented)
                Output.AppendFormat("Status = OpcodeStatus.{0}, ", Entry.Status);

            Output.AppendFormat("Length = {0}, ", Entry.Length);
            Output.AppendFormat("Cycles = {0}, ", Entry.Cycles);
            Output.AppendFormat("TStates = {0}, ", Entry.TStates);
            Output.Append("Arguments = new ParamEntry[]");

            Output.Append(GenerateParams(Entry, Padding));


            if (Long)
            {
                Output.AppendLine();
                Output.Append(Padding);
                Output.Append("                ");
            }

            Output.Append("}, ");

            if (!Long)
            {
                Output.Append("// ");
                Output.Append(GenerateOpcodeExample(Entry, false));
            }

            return Output.ToString();
        }

        static string GenerateMapping(LocalOpcodeEntry Entry, string Padding)
        {
            StringBuilder Output = new StringBuilder();

            Output.Append(Padding);
            Output.Append("new OpcodeMapping { ");

            if (Long)
            {
                Output.Append("// ");
                Output.Append(GenerateOpcodeExample(Entry, true));

                Output.AppendLine();
                Output.Append(Padding);
                Output.Append("                    ");
            }

            Output.AppendFormat("Opcode = 0x{0}, ", (Entry.Opcode >> 4).ToString("X5"));
            Output.AppendFormat("Menmontic = \"{0}\", ", Entry.Menmontic);
            Output.AppendFormat("Function = FunctionID.{0}, ", Entry.FunctionName);
            Output.AppendFormat("Cycles = {0}, ", Entry.Cycles);
            Output.AppendFormat("TStates = {0}, ", Entry.TStates);
            Output.Append("Arguments = new ParamEntry[]");

            Output.Append(GenerateParams(Entry, Padding));

            if (Long)
            {
                Output.AppendLine();
                Output.Append(Padding);
                Output.Append("                  ");
            }

            Output.Append("}, ");

            if (!Long)
            {
                Output.Append("// ");
                Output.Append(GenerateOpcodeExample(Entry, true));
            }

            return Output.ToString();
        }

        static void WriteDecodingRange(StreamWriter OutputFile, IEnumerable<LocalOpcodeEntry> Range)
        {
            int Count = 0;
            if (Range.Count() == 0)
                return;

            LocalOpcodeEntry Dummy = new LocalOpcodeEntry(Range.First());
            Dummy.Menmontic = "None";
            Dummy.FunctionName = "None";
            Dummy.Arguments = new OpcodeData.ParamEntry[0];


            OutputFile.WriteLine("           {");

            foreach (LocalOpcodeEntry Entry in Range)
            {
                if (Entry.Prefered == false)
                    continue;

                while (Count < Entry.Encoding)
                {
                    Dummy.Encoding = (byte)Count;
                    OutputFile.WriteLine(GenerateMapping(Dummy, "                "));
                    Count++;
                }

                OutputFile.WriteLine(GenerateMapping(Entry, "                "));

                Count++;
            }

            while (Count < 0x100)
            {
                Dummy.Encoding = (byte)Count;
                OutputFile.WriteLine(GenerateMapping(Dummy, "                "));
                Count++;
            }

            OutputFile.WriteLine("           },");
        }

        static void SaveGroupInfo(string Prefix, List<LocalOpcodeEntry> OpcodeList)
        {
            {
                string FileName = @".\Common\" + Prefix + "_ZASM.cs";
                using (StreamWriter OutputFile = new StreamWriter(FileName, false))
                {
                    OutputFile.WriteLine("using System.Collections.Generic;");
                    OutputFile.WriteLine();
                    OutputFile.WriteLine("namespace OpcodeData");
                    OutputFile.WriteLine("{");
                    OutputFile.WriteLine("    public static partial class {0}Data", Prefix);
                    OutputFile.WriteLine("    {");
                    OutputFile.WriteLine("        public static SortedList<CommandID, OpcodeEntry[]> Encoding = new SortedList<CommandID, OpcodeEntry[]>");
                    OutputFile.WriteLine("        {");

                    foreach (var OpcodeGroup in OpcodeList.OrderBy(e => e.Menmontic).GroupBy(e => e.Menmontic))
                    {
                        if(string.IsNullOrEmpty(OpcodeGroup.Key))
                            continue;

                        OutputFile.WriteLine("            {");
                        OutputFile.WriteLine("               CommandID.{0}, new OpcodeEntry[]", OpcodeGroup.Key);
                        OutputFile.WriteLine("               {");

                        foreach (LocalOpcodeEntry Entry in OpcodeGroup.OrderBy(e => e.Menmontic))
                        {
                            if (Entry.Status == Opcodes.statusEnum.ExecuteOnly || string.IsNullOrEmpty(Entry.Menmontic))
                                continue;

                            OutputFile.WriteLine(GenerateOpcode(Entry, "                  "));
                        }
                        OutputFile.WriteLine("               }");
                        OutputFile.WriteLine("            },");
                    }

                    OutputFile.WriteLine("        };");
                    OutputFile.WriteLine();
                    OutputFile.WriteLine("        public static SortedList<string, CommandID> Commands = new SortedList<string, CommandID>");
                    OutputFile.WriteLine("        {");

                    foreach (LocalOpcodeEntry Entry in OpcodeList.DistinctBy(e => e.Menmontic).OrderBy(e => e.Menmontic))
                    {
                        if (String.IsNullOrEmpty(Entry.Menmontic))
                            continue;

                        OutputFile.WriteLine("           {{ \"{0}\", CommandID.{0} }},", Entry.Menmontic);
                    }

                    OutputFile.WriteLine("        };");
                    OutputFile.WriteLine("    }");
                    OutputFile.WriteLine("}");
                }
            }
        }

        static void SaveDecodedInfo(string Prefix, List<LocalOpcodeEntry> OpcodeList)
        {
            {
                string FileName = @".\Common\" + Prefix + "_ZEMU.cs";
                using (StreamWriter OutputFile = new StreamWriter(FileName, false))
                {
                    OutputFile.WriteLine("namespace OpcodeData");
                    OutputFile.WriteLine("{");
                    OutputFile.WriteLine("    public static partial class {0}Data", Prefix);
                    OutputFile.WriteLine("    {");
                    //OutputFile.WriteLine("        public static OpcodeEntry[,] OpcodeMap = new OpcodeEntry[,]");
                    OutputFile.WriteLine("        public static OpcodeEntry[] OpcodeMap = new OpcodeEntry[]");
                    OutputFile.WriteLine("        {");

                    foreach (LocalOpcodeEntry Entry in OpcodeList.OrderBy(e => e.Opcode))
                    {
                        OutputFile.WriteLine(GenerateMapping(Entry, "                "));
                    }

                    //OutputFile.WriteLine("           // No Prefix");
                    //WriteDecodingRange(OutputFile, OpcodeList.Where(e => e.Prefix == 0x00 && e.Index == false));
                    //OutputFile.WriteLine();

                    //OutputFile.WriteLine("           // 0xCB Prefix");
                    //WriteDecodingRange(OutputFile, OpcodeList.Where(e => e.Prefix == 0xCB && e.Index == false));
                    //OutputFile.WriteLine();

                    //OutputFile.WriteLine("           // 0xED Prefix");
                    //WriteDecodingRange(OutputFile, OpcodeList.Where(e => e.Prefix == 0xED && e.Index == false));
                    //OutputFile.WriteLine();

                    //OutputFile.WriteLine("           // Index Prefix");
                    //WriteDecodingRange(OutputFile, OpcodeList.Where(e => e.Prefix == 0x00 && e.Index == true));
                    //OutputFile.WriteLine();

                    //OutputFile.WriteLine("           // Index 0xCB Prefix");
                    //WriteDecodingRange(OutputFile, OpcodeList.Where(e => e.Prefix == 0xCB && e.Index == true));

                    OutputFile.WriteLine("        };");
                    OutputFile.WriteLine("    }");
                    OutputFile.WriteLine("}");
                }
            }
        }

        static void SaveEnumInfo(List<LocalOpcodeEntry> Opcodes)
        {
            {
                string FileName = @".\Common\OpcodeEnums.cs";
                using (StreamWriter OutputFile = new StreamWriter(FileName, false))
                {
                    OutputFile.WriteLine("namespace OpcodeData");
                    OutputFile.WriteLine("{");
                    OutputFile.WriteLine("    public enum CommandID");
                    OutputFile.WriteLine("    {");
                    OutputFile.WriteLine("        None,");

                    //int LineLen = 20000;

                    foreach (LocalOpcodeEntry Entry in Opcodes.DistinctBy(e => e.Menmontic).OrderBy(e => e.Menmontic))
                    {
                        if (string.IsNullOrEmpty(Entry.Menmontic))
                            continue;

                        //if (LineLen > 122)
                        //{
                        //    OutputFile.WriteLine();
                        //    OutputFile.Write("        ");

                        //    LineLen = 8;
                        //}

                        //OutputFile.Write("{0}, ", Entry.Menmontic);

                        //LineLen += 2 + Entry.Menmontic.Length;

                        OutputFile.WriteLine("        {0}, ", Entry.Menmontic);
                    }

                    //OutputFile.WriteLine();
                    OutputFile.WriteLine("    }");
                    OutputFile.WriteLine();
                    OutputFile.WriteLine("    public enum FunctionID");
                    OutputFile.WriteLine("    {");
                    OutputFile.WriteLine("        None,");

                    //LineLen = 20000;

                    foreach (LocalOpcodeEntry Entry in Opcodes.DistinctBy(e => e.FunctionName).OrderBy(e => e.FunctionName))
                    {
                        //if (LineLen > 122)
                        //{
                        //    OutputFile.WriteLine();
                        //    OutputFile.Write("        ");

                        //    LineLen = 8;
                        //}

                        //OutputFile.Write("{0}, ", Entry.FunctionName);

                        //LineLen += 2 + Entry.FunctionName.Length;

                        OutputFile.WriteLine("        {0}, ", Entry.FunctionName);
                    }

                    //OutputFile.WriteLine();
                    OutputFile.WriteLine("    }");

                    OutputFile.WriteLine("}");
                }
            }
        }
    }
}
