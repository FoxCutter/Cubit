using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TableBuilder
{
    class Program
    {
        const int Prefix = 0;
        const int HEX = 1;
        const int DEC = 2;
        const int Opcode = 3;
        const int Param1 = 4;
        const int Param2 = 5;
        const int BinData = 6;
        const int BIN = 14;
        const int Immediate = 15;
        const int Official = 16;
        const int Memory = 17;
        const int IX_IY = 18;
        const int AssumeA = 19;
            
        static int SortData(string l, string r)
        {
            string[] Fieldsl = l.Split(',');
            string[] Fieldsr = r.Split(',');

            if (string.Compare(Fieldsl[Opcode], Fieldsr[Opcode], true) != 0)
                return string.Compare(Fieldsl[Opcode], Fieldsr[Opcode], true);

            if (string.Compare(Fieldsl[Param1], Fieldsr[Param1], true) != 0)
                return string.Compare(Fieldsl[Param1], Fieldsr[Param1], true);

            return string.Compare(Fieldsl[Param2], Fieldsr[Param2], true);
        }

        static string FormatEach<T>(string Format, IEnumerable<T> Data, bool Seperator = true)
        {
            StringBuilder Ret = new StringBuilder();
            bool First = true;
            foreach (T Entry in Data)
            {
                if (!First && Seperator)
                    Ret.Append(", ");

                First = false;

                Ret.AppendFormat(Format, Entry);
            }

            return Ret.ToString();
        }

        static string GetOpcodeEncoding(string[] Fields)
        {
            StringBuilder Res = new StringBuilder();
            List<byte> ByteCode = new List<byte>();

            byte TempCode = 0;

            if (Fields[Prefix].Length != 0)
            {
                TempCode = (byte)Convert.ToUInt16(Fields[Prefix], 16);

                ByteCode.Add(TempCode);

                if (TempCode == 0xDD)
                    ByteCode.Add(0xCB);
            }

            TempCode = (byte)Convert.ToUInt16(Fields[HEX], 16);
            ByteCode.Add(TempCode);

            Res.AppendFormat("            new OpcodeEncoding {{ // {0}: {1} {2} {3}\r\n", FormatEach("{0:X2}", ByteCode, false), Fields[Opcode], Fields[Param1], Fields[Param2]);
            Res.AppendFormat("                                  Encoding = new byte[] {{ {0} }},\r\n", FormatEach("0x{0:X2}", ByteCode));
            Res.AppendFormat("                                  Param1 = {0}, Param1Type = {1},\r\n", ConvertRegs(Fields[Param1], Fields, true), ConvertType(Fields[Param1], Fields));
            Res.AppendFormat("                                  Param2 = {0}, Param2Type = {1},\r\n", ConvertRegs(Fields[Param2], Fields, true), ConvertType(Fields[Param2], Fields));
            Res.AppendFormat("                                  Flags = {0}, Function = CommandID.{1} ", ConvertFlags(Fields), Fields[Opcode]);
            Res.AppendFormat("}},");

            return Res.ToString();
        }

        struct OpcodeEntry
        {
            public string Name;
            public List<byte> Encoding;
            public string Param1;
            public string Param2;
            public string Param3;
            public bool Immediate;
            public char Offical;
            public bool Memory;
            public char IX_IY;
            public bool AssumeA;
            public bool IndexOnly; // Can only be used with IX/IY
        };


        static OpcodeEntry ReadOpcodeEntry(string[] Fields)
        {
            OpcodeEntry Ret;
            Ret.Encoding = new List<byte>();
            Ret.IndexOnly = false;

            Ret.Name = Fields[Opcode];
            
            Ret.Param1 = Fields[Param1].ToUpper();
            Ret.Param2 = Fields[Param2].ToUpper();
            Ret.Param3 = "";
            Ret.Immediate = Fields[Immediate].ToUpper() == "Y";
            Ret.Memory = Fields[Memory].ToUpper() == "Y";
            Ret.AssumeA = Fields[AssumeA].ToUpper() == "Y";
            
            Ret.Offical = Fields[Official].ToUpper().FirstOrDefault();
                        
            Ret.IX_IY = Fields[IX_IY].ToUpper().FirstOrDefault();

            if (Fields[IX_IY] == "Y - No Displacment")
                Ret.IX_IY = 'Z';

            if (Fields[Prefix].Length != 0)
            {
                byte Temp = (byte)Convert.ToUInt16(Fields[Prefix], 16);
                if (Temp == 0xDD)
                {
                    Ret.IndexOnly = true;

                    if (Ret.Param1 == "(IX)")
                        Ret.Param1 = "(HL)";

                    if (Ret.Param2 == "(IX)")
                        Ret.Param2 = "(HL)";

                    Ret.IX_IY = 'V';

                    Temp = (byte)Convert.ToUInt16(Fields[HEX], 16);
                    Temp &= 0x07;
                    Ret.Param3 = "bcdehl a"[Temp].ToString();

                    Temp = 0xCB;
                }

                Ret.Encoding.Add(Temp);
            }

            Ret.Encoding.Add((byte)Convert.ToUInt16(Fields[HEX], 16));

            return Ret;
        }

        static string GetOpcodeEncoding(OpcodeEntry Entry)
        {
            StringBuilder Res = new StringBuilder();

            Res.AppendFormat("            new OpcodeEncoding {{ // {0}: {1} {2} {3} {4}\r\n", FormatEach("{0:X2}", Entry.Encoding, false), Entry.Name, Entry.Param1, Entry.Param2, Entry.Param3);
            Res.AppendFormat("                                  Encoding = new byte[] {{ {0} }},\r\n", FormatEach("0x{0:X2}", Entry.Encoding));
            Res.AppendFormat("                                  Param1 = {0}, Param1Type = {1},\r\n", ConvertRegs(Entry.Param1, Entry, true), ConvertType(Entry.Param1, Entry));
            Res.AppendFormat("                                  Param2 = {0}, Param2Type = {1},\r\n", ConvertRegs(Entry.Param2, Entry, true), ConvertType(Entry.Param2, Entry));
            //Res.AppendFormat("                                  Param3 = {0}, Param3Type = {1},\r\n", ConvertRegs(Entry.Param3, Entry, true), ConvertType(Entry.Param3, Entry));
            Res.AppendFormat("                                  Flags = {0}, Function = CommandID.{1} ", ConvertFlags(Entry), Entry.Name);
            Res.AppendFormat("}},");

            return Res.ToString();
        }
        
        
        static void Main(string[] args)
        {
            List<string> Data = new List<string>(File.ReadAllLines(@"Z80 Opcodes.csv"));
            List<string>[] Output = new List<string>[4];
            Output[0] = new List<string>(256);
            Output[1] = new List<string>(256);
            Output[2] = new List<string>(256);
            Output[3] = new List<string>(256);

            List<string> OutputZasm = new List<string>();

            for (int x = 0; x < 256; x++)
            {
                StringBuilder Res = new StringBuilder();


                Res.AppendFormat("                new OpcodeData {{ Name = \"\",\t\t// {0:X2}\r\n", x);
                Res.AppendFormat("                                 Reg1 = Register.None, Reg1Param = RegParam.None,\r\n");
                Res.AppendFormat("                                 Reg2 = Register.None, Reg2Param = RegParam.None,\r\n");
                Res.AppendFormat("                                 Function = Operation.Error ");

                Res.AppendFormat("}},");

                Output[0].Add(Res.ToString());
                Output[1].Add(Res.ToString());
                Output[2].Add(Res.ToString());
                Output[3].Add(Res.ToString());
                
            }


            //Data.OrderBy(e => { return false; });
            Data.Sort(SortData);

            List<byte> ByteCode = new List<byte>();

            foreach (string Line in Data)
            {
                string[] Fields = Line.Split(',');

                // Skip the header line
                if (Fields[Official].ToUpper() == "OFFICIAL")
                    continue;

                OpcodeEntry Entry = ReadOpcodeEntry(Fields);

                if (Entry.Offical != 'N')
                {
                    StringBuilder Res = new StringBuilder();

                    Res.AppendFormat("                new OpcodeData {{ Name = \"{0}\",\t// {1}: {2} {3} {4}\r\n", Entry.Name, FormatEach("{0:X2}", Entry.Encoding, false), Entry.Name, Entry.Param1, Entry.Param2);
                    Res.AppendFormat("                                 Reg1 = {0}, Reg1Param = {1},\r\n", ConvertRegs(Entry.Param1, Entry, false), ConvertParams(Entry.Param1, Entry));
                    Res.AppendFormat("                                 Reg2 = {0}, Reg2Param = {1},\r\n", ConvertRegs(Entry.Param2, Entry, false), ConvertParams(Entry.Param2, Entry));
                    Res.AppendFormat("                                 Function = Operation.{0} ", Entry.Name);
                    Res.AppendFormat("}},");


                    if (Fields[Prefix].Length == 0)
                        Output[0][Convert.ToInt32(Fields[HEX], 16)] = Res.ToString();

                    else if (Fields[Prefix] == "CB")
                        Output[1][Convert.ToInt32(Fields[HEX], 16)] = Res.ToString();

                    else if (Fields[Prefix] == "ED")
                        Output[2][Convert.ToInt32(Fields[HEX], 16)] = Res.ToString();

                    else if (Fields[Prefix] == "DD")
                        Output[3][Convert.ToInt32(Fields[HEX], 16)] = Res.ToString();
                }

                if (!Entry.IndexOnly)
                    OutputZasm.Add(GetOpcodeEncoding(Entry));

                if (Entry.IX_IY != 'N')
                {
                    if (Entry.IX_IY == 'Y' || Entry.IX_IY == 'V')
                    {
                        if (Entry.Param1 == "(HL)")
                            Entry.Param1 = "(IX)";
                        else
                            Entry.Param2 = "(IX)";

                        Entry.Encoding.Insert(0, 0xDD);
                        OutputZasm.Add(GetOpcodeEncoding(Entry));

                        if (Entry.Param1 == "(IX)")
                            Entry.Param1 = "(IY)";
                        else
                            Entry.Param2 = "(IY)";

                        Entry.Encoding.RemoveAt(0);
                        Entry.Encoding.Insert(0, 0xFD);
                        OutputZasm.Add(GetOpcodeEncoding(Entry));
                    }

                    if (Entry.IX_IY == 'Z')
                    {
                        if (Entry.Param1 == "HL")
                            Entry.Param1 = "IX";
                        else
                            Entry.Param2 = "IX";

                        Entry.Encoding.Insert(0, 0xDD);
                        OutputZasm.Add(GetOpcodeEncoding(Entry));

                        if (Entry.Param1 == "IX")
                            Entry.Param1 = "IY";
                        else
                            Entry.Param2 = "IY";

                        Entry.Encoding.RemoveAt(0);
                        Entry.Encoding.Insert(0, 0xFD);
                        OutputZasm.Add(GetOpcodeEncoding(Entry));
                    }
                    
                    else if (Entry.IX_IY == 'X')
                    {
                        if (Entry.Param1.Contains('H'))
                            Entry.Param1 = "IXH";
                        else if (Entry.Param1.Contains('L'))
                            Entry.Param1 = "IXL";

                        if (Entry.Param2.Contains('H'))
                            Entry.Param2 = "IXH";
                        else if (Entry.Param2.Contains('L'))
                            Entry.Param2 = "IXL";

                        Entry.Encoding.Insert(0, 0xDD);
                        OutputZasm.Add(GetOpcodeEncoding(Entry));

                        if (Entry.Param1.Contains('H'))
                            Entry.Param1 = "IYH";
                        else if (Entry.Param1.Contains('L'))
                            Entry.Param1 = "IYL";

                        if (Entry.Param2.Contains('H'))
                            Entry.Param2 = "IYH";
                        else if (Entry.Param2.Contains('L'))
                            Entry.Param2 = "IYL";

                        Entry.Encoding.RemoveAt(0);
                        Entry.Encoding.Insert(0, 0xFD);
                        OutputZasm.Add(GetOpcodeEncoding(Entry));
                    }
                }
            
            }

            StreamWriter OutputFile = new StreamWriter(@".\Z80Emu\Opcodes.cs", false);

            OutputFile.WriteLine("namespace Z80Emu");
            OutputFile.WriteLine("{");
            OutputFile.WriteLine("    static class Ops");
            OutputFile.WriteLine("    {");
            OutputFile.WriteLine("        static public OpcodeData[,] ByteData = new OpcodeData[,]");
            OutputFile.WriteLine("        {");
            OutputFile.WriteLine("            {");

            Output[0].ForEach(OutputFile.WriteLine);

            OutputFile.WriteLine("            },");
            OutputFile.WriteLine("");
            OutputFile.WriteLine("            {");
            
            Output[1].ForEach(OutputFile.WriteLine);

            OutputFile.WriteLine("            },");
            OutputFile.WriteLine("");
            OutputFile.WriteLine("            {");
            
            Output[2].ForEach(OutputFile.WriteLine);

            OutputFile.WriteLine("            },");
            OutputFile.WriteLine("");
            OutputFile.WriteLine("            {");

            Output[3].ForEach(OutputFile.WriteLine);

            OutputFile.WriteLine("            },");
            OutputFile.WriteLine("        };");
            OutputFile.WriteLine("    }");
            OutputFile.WriteLine("}");


            OutputFile.Flush();
            OutputFile.Close();

            OutputFile = new StreamWriter(@".\ZASM\Opcodes.cs", false);
            OutputFile.WriteLine("namespace ZASM");
            OutputFile.WriteLine("{");
            OutputFile.WriteLine("    static class Ops");
            OutputFile.WriteLine("    {");
            OutputFile.WriteLine("        static public OpcodeEncoding[] EncodingData = new OpcodeEncoding[]");
            OutputFile.WriteLine("        {");
            OutputZasm.ForEach(OutputFile.WriteLine);
            OutputFile.WriteLine("        };");
            OutputFile.WriteLine("    }");
            OutputFile.WriteLine("}");

            OutputFile.Flush();
            OutputFile.Close();

        }

        static string ConvertRegs(string Param, string[] Fields, bool CommandID)
        {
            string Base = "Register";
            if (CommandID)
                Base = "CommandID";
            
            if (Param.Length == 0)
                return Base + ".None";

            Param = Param.ToUpper();
            if (Param[0] == '(')
            {
                Param = Param.Substring(1, Param.Length - 2);
            }

            if (Param == "N" || Param == "E-2")
                return Base + ".ImmediateByte";

            if (Param == "NN")
                return Base + ".ImmediateWord";

            if (Param == "0" || Param == "1" || Param == "2" || 
                Param == "3" || Param == "4" || Param == "5" ||
                Param == "6" || Param == "7"
                )
            {
                if (CommandID)
                    return "(" + Base + ")((int)CommandID.Encoded + " + Param + ")";
                    //return Base + ".Encoded + (" + Base + ")" + Param;
                else
                    return "(" + Base + ")" + Param;
            }


            if (Param == "0H"  || Param == "8H"  || Param == "10H" ||
                Param == "18H" || Param == "20H" || Param == "28H" ||
                Param == "30H" || Param == "38H"
                )
            {
                Param = Param.Substring(0, Param.Length - 1);
                if (CommandID)
                    return "(" + Base + ")((int)CommandID.Encoded + 0x" + Param + ")";
                    //return Base + ".Encoded + (" + Base + ")0x" + Param;
                else
                    return "(" + Base + ")0x" + Param;
            }

            if (Param == "NZ" || Param == "Z" || Param == "NC" ||
                Param == "CY" || Param == "PO" || Param == "PE" ||
                Param == "P" || Param == "M"
                )
            {

                if (CommandID)
                    return "CommandID." + Param;
                else
                    return "(Register)ConditionCode." + Param;
            }

            if (!CommandID)
            {
                if (Param == "HL" || Param == "IX" || Param == "IY")
                {
                    if (Fields[IX_IY] == "Y - No Displacment")
                        return Base + ".HX";

                    else if (Fields[IX_IY] == "Y")
                        return Base + ".HD";
                }

                if (Param == "H")
                    return Base + ".XH";

                if (Param == "L")
                    return Base + ".XL";
            }

            return Base + "." + Param;
        }

        static string ConvertParams(string Param, string[] Fields)
        {
            if (Param.Length == 0)
                return "RegParam.None";

            StringBuilder Ret = new StringBuilder();

            Param = Param.ToUpper();
            if (Param[0] == '(')
            {
                Param = Param.Substring(1, Param.Length - 2);

                if (Fields[Memory] == "Y")
                {
                    Ret.Append("RegParam.Reference");

                    string OtherParam = "";

                    // Work out how big the data we are point to is, based on the other operand
                    if (Fields[Param1][0] == '(')
                    {
                        if (Fields[Param2].Length != 0)
                        {
                            OtherParam = Fields[Param2].ToUpper();
                        }
                    }
                    else if (Fields[Param2][0] == '(')
                    {
                        OtherParam = Fields[Param1].ToUpper();
                    }

                    if (OtherParam == "SP" || OtherParam == "AF" || OtherParam == "BC" || OtherParam == "DE" || OtherParam == "HL" || OtherParam == "NN")
                    {
                        Ret.Append(" | RegParam.WordData");
                    }
                }
            }

            if (Ret.Length == 0 && (Param == "SP" || Param == "AF" || Param == "BC" || Param == "DE" || Param == "HL" || Param == "NN"))
            {
                Ret.Append("RegParam.WordData");
            }

            if (Param == "0" || Param == "0H" ||
                Param == "1" || Param == "8H" ||
                Param == "2" || Param == "10H" ||
                Param == "3" || Param == "18H" ||
                Param == "4" || Param == "20H" ||
                Param == "5" || Param == "28H" ||
                Param == "6" || Param == "30H" ||
                Param == "7" || Param == "38H"
                )
            {
                if (Ret.Length != 0)
                    Ret.Append(" | ");

                Ret.Append("RegParam.Literal");
            }

            if (Param == "NZ" || Param == "Z"  || Param == "NC" || 
                Param == "CY" || Param == "PO" || Param == "PE" || 
                Param == "P"  || Param == "M" 
                )
            {
                if (Ret.Length != 0)
                    Ret.Append(" | ");

                Ret.Append("RegParam.ConditionCode");
            }

            if (Ret.Length == 0)
            {
                Ret.Append("RegParam.None");
            }

            return Ret.ToString();
        }

        static string ConvertType(string Param, string[] Fields)
        {
            if (Param.Length == 0)
                return "ParameterType.None";

            bool Address = false;
            
            Param = Param.ToUpper();
            if (Param[0] == '(')
            {
                Param = Param.Substring(1, Param.Length - 2);

                if (Fields[Memory] == "Y")
                    Address = true;
            }


            if (Param == "NZ" || Param == "Z" || Param == "NC" ||
                Param == "CY" || Param == "PO" || Param == "PE" ||
                Param == "P" || Param == "M"
                )
            {
                return "ParameterType.Conditional";
            }

            if (Param == "A" || Param == "F" || Param == "B" || Param == "C" || Param == "D" || Param == "E" ||
                Param == "H" || Param == "L" || Param == "I" || Param == "R" || Param == "SPH" || Param == "SPL" ||
                Param == "PCH" || Param == "PCL" ||Param == "IXH" || Param == "IXL" ||Param == "IYH" || Param == "IYL")
            {
                return "ParameterType.RegisterByte";
            }

            if (Param == "SP" || Param == "AF" || Param == "BC" || Param == "DE" || Param == "HL")
            {
                if(Address)
                    return "ParameterType.RegisterPtr";
                else
                    return "ParameterType.RegisterWord";
            }

            if (Param == "N" || Param == "E-2")
                return "ParameterType.Immediate";
                
            if (Param == "NN")
            {
                if (Address)
                    return "ParameterType.ImmediatePtr";
                else
                    return "ParameterType.Immediate";
            }

            if (Param == "0" || Param == "0H" ||
                Param == "1" || Param == "8H" ||
                Param == "2" || Param == "10H" ||
                Param == "3" || Param == "18H" ||
                Param == "4" || Param == "20H" ||
                Param == "5" || Param == "28H" ||
                Param == "6" || Param == "30H" ||
                Param == "7" || Param == "38H"
                )
            {
                return "ParameterType.Encoded";
            }

            return "ParameterType.Unknown";

        }

        static string ConvertFlags(string[] Fields)
        {
            StringBuilder Ret = new StringBuilder();

            if (Fields[IX_IY].ToUpper() == "Y")
                Ret.Append("ParamFlags.Displacement");

            else if (Fields[IX_IY] == "Y - No Displacment" || Fields[IX_IY].ToUpper() == "X")
                Ret.Append("ParamFlags.Index");

            if (Fields[AssumeA].ToUpper() == "Y")
            {
                if (Ret.Length != 0)
                    Ret.Append(" | ");

                Ret.Append("ParamFlags.AssumeA");
            }

            if (Ret.Length != 0)
                return Ret.ToString();

            return "ParamFlags.None";
        }

        static string ConvertParams(string Param, OpcodeEntry Entry)
        {
            if (Param.Length == 0)
                return "RegParam.None";

            StringBuilder Ret = new StringBuilder();

            Param = Param.ToUpper();
            if (Param[0] == '(')
            {
                Param = Param.Substring(1, Param.Length - 2);

                if (Entry.Memory)
                {
                    Ret.Append("RegParam.Reference");

                    string OtherParam = "";

                    // Work out how big the data we are point to is, based on the other operand
                    if (Entry.Param1[0] == '(')
                    {
                        if (Entry.Param2.Length != 0)
                        {
                            OtherParam = Entry.Param2.ToUpper();
                        }
                    }
                    else if (Entry.Param2[0] == '(')
                    {
                        OtherParam = Entry.Param1.ToUpper();
                    }

                    if (OtherParam == "SP" || OtherParam == "AF" || OtherParam == "BC" || OtherParam == "DE" || OtherParam == "HL" || OtherParam == "NN")
                    {
                        Ret.Append(" | RegParam.WordData");
                    }
                }
            }

            if (Ret.Length == 0 && (Param == "SP" || Param == "AF" || Param == "BC" || Param == "DE" || Param == "HL" || Param == "NN"))
            {
                Ret.Append("RegParam.WordData");
            }

            if (Param == "0" || Param == "0H" ||
                Param == "1" || Param == "8H" ||
                Param == "2" || Param == "10H" ||
                Param == "3" || Param == "18H" ||
                Param == "4" || Param == "20H" ||
                Param == "5" || Param == "28H" ||
                Param == "6" || Param == "30H" ||
                Param == "7" || Param == "38H"
                )
            {
                if (Ret.Length != 0)
                    Ret.Append(" | ");

                Ret.Append("RegParam.Literal");
            }

            if (Param == "NZ" || Param == "Z" || Param == "NC" ||
                Param == "CY" || Param == "PO" || Param == "PE" ||
                Param == "P" || Param == "M"
                )
            {
                if (Ret.Length != 0)
                    Ret.Append(" | ");

                Ret.Append("RegParam.ConditionCode");
            }

            if (Ret.Length == 0)
            {
                Ret.Append("RegParam.None");
            }

            return Ret.ToString();
        }
        
        static string ConvertRegs(string Param, OpcodeEntry Entry, bool CommandID)
        {
            string Base = "Register";
            if (CommandID)
                Base = "CommandID";

            if (Param.Length == 0)
                return Base + ".None";

            Param = Param.ToUpper();
            if (Param[0] == '(')
            {
                Param = Param.Substring(1, Param.Length - 2);
            }

            if (Param == "N" || Param == "E-2")
                return Base + ".ImmediateByte";

            if (Param == "NN")
                return Base + ".ImmediateWord";

            if (Param == "0" || Param == "1" || Param == "2" ||
                Param == "3" || Param == "4" || Param == "5" ||
                Param == "6" || Param == "7"
                )
            {
                if (CommandID)
                    return "(" + Base + ")((int)CommandID.Encoded + " + Param + ")";
                else
                    return "(" + Base + ")" + Param;
            }


            if (Param == "0H" || Param == "8H" || Param == "10H" ||
                Param == "18H" || Param == "20H" || Param == "28H" ||
                Param == "30H" || Param == "38H"
                )
            {
                Param = Param.Substring(0, Param.Length - 1);
                if (CommandID)
                    return "(" + Base + ")((int)CommandID.Encoded + 0x" + Param + ")";
                //return Base + ".Encoded + (" + Base + ")0x" + Param;
                else
                    return "(" + Base + ")0x" + Param;
            }

            if (Param == "NZ" || Param == "Z" || Param == "NC" ||
                Param == "CY" || Param == "PO" || Param == "PE" ||
                Param == "P" || Param == "M"
                )
            {

                if (CommandID)
                    return "CommandID." + Param;
                else
                    return "(Register)ConditionCode." + Param;
            }

            if (!CommandID)
            {
                if (Param == "HL" || Param == "IX" || Param == "IY")
                {
                    if (Entry.IX_IY == 'Z')
                        return Base + ".HX";

                    else if (Entry.IX_IY == 'Y' || Entry.IX_IY == 'V')
                        return Base + ".HD";
                }

                if (Param == "H" && Entry.IX_IY == 'X')
                    return Base + ".XH";

                if (Param == "L" && Entry.IX_IY == 'X')
                    return Base + ".XL";
            }

            return Base + "." + Param;
        }
        
        static string ConvertType(string Param, OpcodeEntry Entry)
        {
            if (Param.Length == 0)
                return "ParameterType.None";

            bool Address = false;

            Param = Param.ToUpper();
            if (Param[0] == '(')
            {
                Param = Param.Substring(1, Param.Length - 2);

                if(Entry.Memory)
                    Address = true;
            }

            if (Param == "NZ" || Param == "Z" || Param == "NC" ||
                Param == "CY" || Param == "PO" || Param == "PE" ||
                Param == "P" || Param == "M"
                )
            {
                return "ParameterType.Conditional";
            }

            if (Param == "A" || Param == "F" || Param == "B" || Param == "C" || Param == "D" || Param == "E" ||
                Param == "H" || Param == "L" || Param == "I" || Param == "R" || Param == "SPH" || Param == "SPL" ||
                Param == "PCH" || Param == "PCL" || Param == "IXH" || Param == "IXL" || Param == "IYH" || Param == "IYL")
            {
                return "ParameterType.RegisterByte";
            }

            if (Param == "SP" || Param == "AF" || Param == "BC" || Param == "DE" || Param == "HL")
            {
                if (Address)
                    return "ParameterType.RegisterPtr";
                else
                    return "ParameterType.RegisterWord";
            }

            if (Param == "IX" || Param == "IY")
            {
                if (Address)
                    return "ParameterType.RegisterDisplacedPtr";
                else
                    return "ParameterType.RegisterWord";
            }

            if (Param == "N" || Param == "E-2")
                return "ParameterType.Immediate";

            if (Param == "NN")
            {
                if (Address)
                    return "ParameterType.ImmediatePtr";
                else
                    return "ParameterType.Immediate";
            }

            if (Param == "0" || Param == "0H" ||
                Param == "1" || Param == "8H" ||
                Param == "2" || Param == "10H" ||
                Param == "3" || Param == "18H" ||
                Param == "4" || Param == "20H" ||
                Param == "5" || Param == "28H" ||
                Param == "6" || Param == "30H" ||
                Param == "7" || Param == "38H"
                )
            {
                return "ParameterType.Encoded";
            }

            return "ParameterType.Unknown";

        }
        
        static string ConvertFlags(OpcodeEntry Entry)
        {
            bool Indexreg = false;

            if (Entry.Param1.Contains("IX") || Entry.Param2.Contains("IX") || Entry.Param3.Contains("IX"))
                Indexreg = true;

            if (Entry.Param1.Contains("IY") || Entry.Param2.Contains("IY") || Entry.Param3.Contains("IY"))
                Indexreg = true;

            if(!Indexreg)
                return "ParamFlags.None";


            if (Entry.IX_IY == 'Y')
                return "ParamFlags.Displacement";

            else if (Entry.IX_IY == 'V' && (Entry.Param1.Contains("IX") || Entry.Param1.Contains("IY") || Entry.Param2.Contains("IX") || Entry.Param2.Contains("IY")))
                return "ParamFlags.InternalDisplacement";

            else if (Entry.IX_IY == 'X' || Entry.IX_IY == 'Z')
                return "ParamFlags.Index";

            return "ParamFlags.None";
        }
    }
}
