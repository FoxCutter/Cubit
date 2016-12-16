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
        /*
        const int Prefix = 0;
        const int HEX = 1;
        const int DEC = 2;
        const int Opcode = 3;
        const int Param1 = 4;
        const int Param2 = 5;
        const int BinData0 = 6;
        const int BinData1 = 7;
        const int BinData2 = 8;
        const int BinData3 = 9;
        const int BinData4 = 10;
        const int BinData5 = 11;
        const int BinData6 = 12;
        const int BinData7 = 13;
        const int BIN = 14;
        const int Immediate = 15;
        const int Official = 16;
        const int Memory = 17;
        const int IX_IY = 18;
        const int AssumeA = 19;
            
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

            public int OrderVal;
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
                    if (Temp >= 0x40)
                    {
                        Temp &= 0x07;
                        Ret.Param3 = "bcdehl a"[Temp].ToString();
                    }

                    Temp = 0xCB;
                }

                Ret.Encoding.Add(Temp);
            }

            Ret.OrderVal = Convert.ToInt32(Fields[DEC], 10);
            
            Ret.Encoding.Add((byte)Convert.ToUInt16(Fields[HEX], 16));

            return Ret;
        }



        static string FormatParam(OpcodeMatrix.OpcodeEntry Entry, int Index)
        {
            StringBuilder Res = new StringBuilder();

            if (Index >= Entry.Param.Count)
            {
                Res.AppendFormat("Reg{0} = Register.None", Index + 1);
                Res.AppendFormat(", Reg{0}Param = RegParam.None", Index + 1);

                return Res.ToString();
            }


            OpcodeMatrix.ParamInformation Param = Entry.Param[Index];
            
            Res.AppendFormat("Reg{0} = ", Index + 1);

            if (Param.Type >= OpcodeMatrix.ParamType.NZ && Param.Type <= OpcodeMatrix.ParamType.M)
                Res.AppendFormat("(Register)ConditionCode.{0}", Param.Type.ToString());

            else if (Param.Type >= OpcodeMatrix.ParamType.Zero && Param.Type < OpcodeMatrix.ParamType.Expandable)
                Res.AppendFormat("(Register){0}", (Param.Type - OpcodeMatrix.ParamType.Zero).ToString("X2"));

            else 
            {
                Res.AppendFormat("Register.");
                switch (Param.Type)
                {

                    case OpcodeMatrix.ParamType.ByteImmidate:
                    case OpcodeMatrix.ParamType.Displacment:
                        Res.AppendFormat("ImmediateByte");
                        break;

                    case OpcodeMatrix.ParamType.AddressPtr:
                    case OpcodeMatrix.ParamType.WordImmidate:
                    case OpcodeMatrix.ParamType.Address:
                        Res.AppendFormat("ImmediateWord");
                        break;

                    case OpcodeMatrix.ParamType.H:
                        if(Entry.ByteIndex)
                            Res.AppendFormat("XH");
                        else
                            Res.AppendFormat("H");
                        break;

                    case OpcodeMatrix.ParamType.L:
                        if(Entry.ByteIndex)
                            Res.AppendFormat("XL");
                        else
                            Res.AppendFormat("L");
                        break;

                    case OpcodeMatrix.ParamType.HL:
                        if (Entry.NoIndex)
                            Res.AppendFormat("HL");
                        else
                            Res.AppendFormat("HX");
                        break;

                    case OpcodeMatrix.ParamType.HL_Pointer:
                        Res.AppendFormat("HD");
                        break;

                    case OpcodeMatrix.ParamType.BC_Pointer:
                        Res.AppendFormat("BC");
                        break;

                    case OpcodeMatrix.ParamType.DE_Pointer:
                        Res.AppendFormat("DE");
                        break;

                    case OpcodeMatrix.ParamType.SP_Pointer:
                        Res.AppendFormat("SP");
                        break;

                    case OpcodeMatrix.ParamType.IndexPtr:
                        Res.AppendFormat("HD");
                        break;

                    default:
                        Res.AppendFormat(Param.Type.ToString());
                        break;
                }
            }

            Res.AppendFormat(", Reg{0}Param = RegParam.", Index + 1);

            if (Param.Type >= OpcodeMatrix.ParamType.NZ && Param.Type <= OpcodeMatrix.ParamType.M)
                Res.AppendFormat("ConditionCode");

            else if (Param.Type >= OpcodeMatrix.ParamType.Zero && Param.Type < OpcodeMatrix.ParamType.Expandable)
                Res.AppendFormat("Literal");

            else if (Param.Type == OpcodeMatrix.ParamType.Address)
                Res.AppendFormat("WordData");

            else if (Param.Type == OpcodeMatrix.ParamType.WordImmidate || (Param.Type >= OpcodeMatrix.ParamType.BC && Param.Type <= OpcodeMatrix.ParamType.AF))
                Res.AppendFormat("WordData");

            else if (Param.Type == OpcodeMatrix.ParamType.AddressPtr)
                Res.AppendFormat("Reference | RegParam.WordData");

            else if (Param.Type >= OpcodeMatrix.ParamType.HL_Pointer && Param.Type <= OpcodeMatrix.ParamType.IndexPtr)
                Res.AppendFormat("Reference");

            else
                Res.AppendFormat("None");

            
            return Res.ToString();
        }

        static string FormatParamZASM(OpcodeMatrix.OpcodeEntry Entry, int Index)
        {
            if (Index >= Entry.Param.Count)
            {
                return String.Format("Param{0}Type = ParameterType.None, Param{0}ID = CommandID.None, Param{0}Pos = 0xFF", Index + 1);
            }

            StringBuilder Res = new StringBuilder();
            OpcodeMatrix.ParamInformation Param = Entry.Param[Index];

            // Param Type is how we look up the opcode.
            Res.AppendFormat("Param{0}Type = ParameterType.", Index + 1);

            if (Param.Type == OpcodeMatrix.ParamType.ByteReg)
                Res.AppendFormat("RegisterByte");

            else if (Param.Type == OpcodeMatrix.ParamType.WordReg || Param.Type == OpcodeMatrix.ParamType.WordRegAF)
                Res.AppendFormat("RegisterWord");

            else if (Param.Type == OpcodeMatrix.ParamType.Flags || Param.Type == OpcodeMatrix.ParamType.HalfFlags)
                Res.AppendFormat("Conditional");

            else if (Param.Type == OpcodeMatrix.ParamType.AddressPtr)
                Res.AppendFormat("AddressPtr");

            else if (Param.Type >= OpcodeMatrix.ParamType.HL_Pointer && Param.Type <= OpcodeMatrix.ParamType.SP_Pointer)
                Res.AppendFormat("RegisterPtr");

            else if (Param.Type == OpcodeMatrix.ParamType.IndexPtr)
                Res.AppendFormat("IndexPtr");

            else if (Param.Type == OpcodeMatrix.ParamType.Displacment || Param.Type == OpcodeMatrix.ParamType.WordImmidate || Param.Type == OpcodeMatrix.ParamType.ByteImmidate || Param.Type == OpcodeMatrix.ParamType.Address || Param.Type == OpcodeMatrix.ParamType.Encoded)
                Res.AppendFormat("Immediate");

            else if (Param.Type >= OpcodeMatrix.ParamType.A && Param.Type <= OpcodeMatrix.ParamType.R)
                Res.AppendFormat("RegisterByte");

            else if (Param.Type >= OpcodeMatrix.ParamType.BC && Param.Type <= OpcodeMatrix.ParamType.AF)
                Res.AppendFormat("RegisterWord");

            else if (Param.Type >= OpcodeMatrix.ParamType.NZ && Param.Type <= OpcodeMatrix.ParamType.M)
                Res.AppendFormat("Conditional");

            else if (Param.Type >= OpcodeMatrix.ParamType.Zero && Param.Type < OpcodeMatrix.ParamType.Expandable)
                Res.AppendFormat("Immediate");

            else
                Res.AppendFormat("None");


            Res.AppendFormat(", Param{0}ID = ", Index + 1);

            if (Param.Type >= OpcodeMatrix.ParamType.Zero && Param.Type < OpcodeMatrix.ParamType.Expandable)
                Res.AppendFormat("(CommandID)((int)CommandID.Encoded + {0})", (Param.Type - OpcodeMatrix.ParamType.Zero).ToString("X2"));

            else
            {
                Res.AppendFormat("CommandID.");
                switch (Param.Type)
                {
                    case OpcodeMatrix.ParamType.ByteImmidate:
                        Res.AppendFormat("ImmediateByte");
                        break;

                    case OpcodeMatrix.ParamType.WordImmidate:
                        Res.AppendFormat("ImmediateWord");
                        break;

                    case OpcodeMatrix.ParamType.Displacment:
                        Res.AppendFormat("ImmediateDisplacment");
                        break;

                    case OpcodeMatrix.ParamType.AddressPtr:
                    case OpcodeMatrix.ParamType.Address:
                        Res.AppendFormat("ImmediateAddress");
                        break;

                    case OpcodeMatrix.ParamType.HL_Pointer:
                        Res.AppendFormat("HL");
                        break;

                    case OpcodeMatrix.ParamType.BC_Pointer:
                        Res.AppendFormat("BC");
                        break;

                    case OpcodeMatrix.ParamType.DE_Pointer:
                        Res.AppendFormat("DE");
                        break;

                    case OpcodeMatrix.ParamType.SP_Pointer:
                        Res.AppendFormat("SP");
                        break;

                    case OpcodeMatrix.ParamType.IndexPtr:
                        Res.AppendFormat("IndexPtr");
                        break;

                    default:
                        Res.AppendFormat(Param.Type.ToString());
                        break;
                }
            }

            Res.AppendFormat(", Param{0}Pos = 0x{1}", Index + 1, Param.Shift.ToString("X2"));


            return Res.ToString();
        }

       
        static string FormatOpcode(OpcodeMatrix.OpcodeEntry Entry)
        {
            StringBuilder Res = new StringBuilder();

            Res.AppendFormat("                new OpcodeData {{ Name = \"{0}\",\t// {1}\r\n", Entry.Opcode, OpcodeToString(Entry));
            Res.AppendFormat("                                 {0},\r\n", FormatParam(Entry, 0));
            Res.AppendFormat("                                 {0},\r\n", FormatParam(Entry, 1));
            Res.AppendFormat("                                 {0},\r\n", FormatParam(Entry, 2));            
            Res.AppendFormat("                                 Function = Operation.{0} ", Entry.Opcode);
            Res.AppendFormat("}},"); 
          
            return Res.ToString();

        }

        static string GetOpcodeEncoding(OpcodeMatrix.OpcodeEntry Entry)
        {
            StringBuilder Res = new StringBuilder();

            Res.AppendFormat("            new OpcodeEncoding {{ Function = CommandID.{0}, // {1}\r\n", Entry.Opcode, OpcodeToString(Entry));
            Res.AppendFormat("                                 {0},\r\n", FormatParamZASM(Entry, 0));
            Res.AppendFormat("                                 {0},\r\n", FormatParamZASM(Entry, 1));
            Res.AppendFormat("                                 {0},\r\n", FormatParamZASM(Entry, 2));
            Res.AppendFormat("                                 Flags = {0},\r\n", ConvertFlags(Entry));
            Res.AppendFormat("                                 Prefix = 0x{0}, Base = 0x{1},", Entry.Prefix.ToString("X2"), Entry.Base.ToString("X2"));

            Res.AppendFormat(" }},");

            return Res.ToString();
        }

        
        static void NewStyle()
        {
            OpcodeMatrix Matrix = new OpcodeMatrix();
            List<string> Data = new List<string>(File.ReadAllLines(@"Z80 Opcode Matrix.txt"));
            Matrix.ProcessData(Data.ToArray());

            // ---------------------------------------------------

            List<string>[] Output = new List<string>[4];
            Output[0] = new List<string>(256);
            Output[1] = new List<string>(256);
            Output[2] = new List<string>(256);
            Output[3] = new List<string>(256);

            for (int x = 0; x < 256; x++)
            {
                StringBuilder Res = new StringBuilder();


                Res.AppendFormat("                new OpcodeData {{ Name = \"\",\t\t// {0:X2}\r\n", x);
                Res.AppendFormat("                                 Reg1 = Register.None, Reg1Param = RegParam.None,\r\n");
                Res.AppendFormat("                                 Reg2 = Register.None, Reg2Param = RegParam.None,\r\n");
                Res.AppendFormat("                                 Reg3 = Register.None, Reg3Param = RegParam.None,\r\n");
                Res.AppendFormat("                                 Function = Operation.Error ");

                Res.AppendFormat("}},");

                Output[0].Add(Res.ToString());
                Output[1].Add(Res.ToString());
                Output[2].Add(Res.ToString());
                Output[3].Add(Res.ToString());

            }

            foreach (OpcodeMatrix.OpcodeEntry Entry in Matrix._OpcodeMatrix.Where(e => e.Prefix == 0 && e.Offical == true))
                Output[0][Entry.Base] = FormatOpcode(Entry);

            foreach (OpcodeMatrix.OpcodeEntry Entry in Matrix._OpcodeMatrix.Where(e => e.Prefix == 0xED && e.Offical == true))
                Output[2][Entry.Base] = FormatOpcode(Entry);

            foreach (OpcodeMatrix.OpcodeEntry Entry in Matrix._OpcodeMatrix.Where(e => e.Prefix == 0xCB && e.Offical == true))
            {
                Output[1][Entry.Base] = FormatOpcode(Entry);
                if(Entry.Param.Where(e => e.Type == OpcodeMatrix.ParamType.IndexPtr).Count() != 0)
                    Output[3][Entry.Base] = FormatOpcode(Entry);

                if(Entry.Param.Where(e => e.Type == OpcodeMatrix.ParamType.HL_Pointer).Count() != 0)
                    Output[3][Entry.Base] = FormatOpcode(Entry);
                
            }


            StreamWriter OutputFile = new StreamWriter(@".\Z80Emu\Opcodes_new.cs", false);

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


            // ---------------------------------------------------

            OutputFile = new StreamWriter(@".\ZASM\Opcodes_new.cs", false);
            OutputFile.WriteLine("using System.Collections.Generic;");
            OutputFile.WriteLine("namespace ZASM");
            OutputFile.WriteLine("{");
            OutputFile.WriteLine("    static class Ops");
            OutputFile.WriteLine("    {");
            OutputFile.WriteLine("        static public OpcodeEncoding[] EncodingData = ");
            OutputFile.WriteLine("        {");

            foreach (var Entry in Matrix._OpcodeList.OrderBy(e => !e.Offical).OrderBy(e => e.Opcode))
            {
                OutputFile.WriteLine(GetOpcodeEncoding(Entry));
            }

            OutputFile.WriteLine("        };");
            OutputFile.WriteLine("    }");
            OutputFile.WriteLine("}");

            OutputFile.Flush();
            OutputFile.Close(); 
           
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

            Param = Param.ToUpper().Trim();
            
            if (Param.Length == 0)
                return Base + ".None";

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


        

        */

        static string ParamTypeToString(OpcodeMatrix.ParamType Type)
        {
            switch (Type)
            {
                case OpcodeMatrix.ParamType.ByteImmidate:
                    return "n";

                case OpcodeMatrix.ParamType.Displacment:
                    return "e-2";

                case OpcodeMatrix.ParamType.WordImmidate:
                case OpcodeMatrix.ParamType.Address:
                    return "nn";

                case OpcodeMatrix.ParamType.AddrReg:
                case OpcodeMatrix.ParamType.HL_Pointer:
                    return "(HL)";

                case OpcodeMatrix.ParamType.BC_Pointer:
                    return "(BC)";

                case OpcodeMatrix.ParamType.DE_Pointer:
                    return "(DE)";

                case OpcodeMatrix.ParamType.SP_Pointer:
                    return "(SP)";

                case OpcodeMatrix.ParamType.AddressPtr:
                    return "(**)";

                case OpcodeMatrix.ParamType.IndexPtr:
                    return "(rx + *)";

                case OpcodeMatrix.ParamType.ByteReg:
                    return "r";

                case OpcodeMatrix.ParamType.WordRegAF:
                case OpcodeMatrix.ParamType.WordReg:
                    return "rr";

                case OpcodeMatrix.ParamType.Flags:
                case OpcodeMatrix.ParamType.HalfFlags:
                    return "cc";

                case OpcodeMatrix.ParamType.Encoded:
                    return "n";

                default:
                    if (Type >= OpcodeMatrix.ParamType.Zero && Type < OpcodeMatrix.ParamType.Expandable)
                        return (Type - OpcodeMatrix.ParamType.Zero).ToString("X");

                    return Type.ToString();
            }
        }

        static string OpcodeToString(OpcodeMatrix.OpcodeEntry Entry)
        {
            StringBuilder Res = new StringBuilder();

            Res.AppendFormat("{0}{1}: {2}", Entry.Prefix == 0 ? "" : Entry.Prefix.ToString("X2"), Entry.Base.ToString("X2"), Entry.Opcode);
            foreach (OpcodeMatrix.ParamInformation Param in Entry.Params)
                Res.AppendFormat(" {0},", ParamTypeToString(Param.Type));

            return Res.ToString();
        }

        static string ConvertFlags(OpcodeMatrix.OpcodeEntry Entry)
        {
            StringBuilder Ret = new StringBuilder();

            if (Entry.Offical == false)
                Ret.Append("ParamFlags.Unoffical");

            if (Entry.NoIndexPrefix == true)
            {
                if (Ret.Length != 0)
                    Ret.Append(" | ");
                Ret.Append("ParamFlags.NoIndexPrefix");
            }

            if (Entry.IndexByteReg == true && (Entry.HasType(OpcodeMatrix.ParamType.H) || Entry.HasType(OpcodeMatrix.ParamType.L) || Entry.HasType(OpcodeMatrix.ParamType.ByteReg)))
            {
                if (Ret.Length != 0)
                    Ret.Append(" | ");

                Ret.Append("ParamFlags.ByteIndexAllowed");
            }

            if (Entry.Prefix == 0xCB)
            {
                if (Ret.Length != 0)
                    Ret.Append(" | ");

                Ret.Append("ParamFlags.EmbededIndex");
            }

            if (Ret.Length == 0)
                return "ParamFlag.None";

            return Ret.ToString();
        }

        static string FormatParamZASM(OpcodeMatrix.ParamInformation Param)
        {
            StringBuilder Res = new StringBuilder();


            if (Param.Type >= OpcodeMatrix.ParamType.Zero && Param.Type < OpcodeMatrix.ParamType.Expandable)
                Res.AppendFormat("(CommandID)((int)CommandID.Encoded + {0})", (Param.Type - OpcodeMatrix.ParamType.Zero).ToString("X2"));

            else
            {
                Res.AppendFormat("CommandID.");
                switch (Param.Type)
                {

                    default:
                        Res.AppendFormat(Param.Type.ToString());
                        break;
                }

                if (Param.Pos != OpcodeMatrix.ParamPos.None)
                {
                    switch (Param.Pos)
                    {
                        case OpcodeMatrix.ParamPos.Pos1:
                            Res.AppendFormat(" | CommandID.Pos1");
                            break;
                        case OpcodeMatrix.ParamPos.Pos2:
                            Res.AppendFormat(" | CommandID.Pos2");
                            break;
                        case OpcodeMatrix.ParamPos.Pos3:
                            Res.AppendFormat(" | CommandID.Pos3");
                            break;
                        case OpcodeMatrix.ParamPos.Pos4:
                            Res.AppendFormat(" | CommandID.Pos4");
                            break;
                        case OpcodeMatrix.ParamPos.Immidate:
                            Res.AppendFormat(" | CommandID.Immidate");
                            break;
                    }
                }
            }

            /*
            if (Index >= Entry.Param.Count)
            {
                return String.Format("Param{0}Type = ParameterType.None, Param{0}ID = CommandID.None, Param{0}Pos = 0xFF", Index + 1);
            }


            // Param Type is how we look up the opcode.
            Res.AppendFormat("Param{0}Type = ParameterType.", Index + 1);

            if (Param.Type == OpcodeMatrix.ParamType.ByteReg)
                Res.AppendFormat("RegisterByte");

            else if (Param.Type == OpcodeMatrix.ParamType.WordReg || Param.Type == OpcodeMatrix.ParamType.WordRegAF)
                Res.AppendFormat("RegisterWord");

            else if (Param.Type == OpcodeMatrix.ParamType.Flags || Param.Type == OpcodeMatrix.ParamType.HalfFlags)
                Res.AppendFormat("Conditional");

            else if (Param.Type == OpcodeMatrix.ParamType.AddressPtr)
                Res.AppendFormat("AddressPtr");

            else if (Param.Type >= OpcodeMatrix.ParamType.HL_Pointer && Param.Type <= OpcodeMatrix.ParamType.SP_Pointer)
                Res.AppendFormat("RegisterPtr");

            else if (Param.Type == OpcodeMatrix.ParamType.BytePtr)
                Res.AppendFormat("BytePtr");

            else if (Param.Type == OpcodeMatrix.ParamType.AddrReg)
                Res.AppendFormat("AddrReg");

            else if (Param.Type == OpcodeMatrix.ParamType.IndexPtr)
                Res.AppendFormat("IndexPtr");

            else if (Param.Type == OpcodeMatrix.ParamType.Displacment || Param.Type == OpcodeMatrix.ParamType.WordImmidate || Param.Type == OpcodeMatrix.ParamType.ByteImmidate || Param.Type == OpcodeMatrix.ParamType.Address || Param.Type == OpcodeMatrix.ParamType.Encoded)
                Res.AppendFormat("Immediate");

            else if (Param.Type >= OpcodeMatrix.ParamType.A && Param.Type <= OpcodeMatrix.ParamType.R)
                Res.AppendFormat("RegisterByte");

            else if (Param.Type >= OpcodeMatrix.ParamType.BC && Param.Type <= OpcodeMatrix.ParamType.AF)
                Res.AppendFormat("RegisterWord");

            else if (Param.Type >= OpcodeMatrix.ParamType.NZ && Param.Type <= OpcodeMatrix.ParamType.M)
                Res.AppendFormat("Conditional");

            else if (Param.Type >= OpcodeMatrix.ParamType.Zero && Param.Type < OpcodeMatrix.ParamType.Expandable)
                Res.AppendFormat("Immediate");

            else
                Res.AppendFormat("None");


            Res.AppendFormat(", Param{0}ID = ", Index + 1);

            if (Param.Type >= OpcodeMatrix.ParamType.Zero && Param.Type < OpcodeMatrix.ParamType.Expandable)
                Res.AppendFormat("(CommandID)((int)CommandID.Encoded + {0})", (Param.Type - OpcodeMatrix.ParamType.Zero).ToString("X2"));

            else
            {
                Res.AppendFormat("CommandID.");
                switch (Param.Type)
                {
                    case OpcodeMatrix.ParamType.ByteImmidate:
                        Res.AppendFormat("ImmediateByte");
                        break;

                    case OpcodeMatrix.ParamType.WordImmidate:
                        Res.AppendFormat("ImmediateWord");
                        break;

                    case OpcodeMatrix.ParamType.Displacment:
                        Res.AppendFormat("ImmediateDisplacment");
                        break;

                    case OpcodeMatrix.ParamType.AddressPtr:
                    case OpcodeMatrix.ParamType.Address:
                        Res.AppendFormat("ImmediateAddress");
                        break;

                    case OpcodeMatrix.ParamType.HL_Pointer:
                        Res.AppendFormat("HL");
                        break;

                    case OpcodeMatrix.ParamType.BC_Pointer:
                        Res.AppendFormat("BC");
                        break;

                    case OpcodeMatrix.ParamType.DE_Pointer:
                        Res.AppendFormat("DE");
                        break;

                    case OpcodeMatrix.ParamType.SP_Pointer:
                        Res.AppendFormat("SP");
                        break;

                    case OpcodeMatrix.ParamType.IndexPtr:
                        Res.AppendFormat("IndexPtr");
                        break;

                    case OpcodeMatrix.ParamType.BytePtr:
                        Res.AppendFormat("BytePtr");
                        break;

                    case OpcodeMatrix.ParamType.AddrReg:
                        Res.AppendFormat("AddrReg");
                        break;

                    default:
                        Res.AppendFormat(Param.Type.ToString());
                        break;
                }
            }

            Res.AppendFormat(", Param{0}Pos = 0x{1}", Index + 1, Param.Shift.ToString("X2"));
            */

            return Res.ToString();
        }
        
        static string GetOpcodeEncoding(OpcodeMatrix.OpcodeEntry Entry)
        {
            StringBuilder Res = new StringBuilder();

            Res.AppendFormat("            new OpcodeEncoding {{ Function = CommandID.{0}, // {1}\r\n", Entry.Opcode, OpcodeToString(Entry));
            Res.AppendFormat("                                 new Param[] {{ ");
            foreach (var Param in Entry.Params)
            {
                Res.Append(FormatParamZASM(Param));
                Res.Append(", ");
            }
            Res.AppendFormat("}},\r\n");
            Res.AppendFormat("                                 Flags = {0},\r\n", ConvertFlags(Entry));
            Res.AppendFormat("                                 Prefix = 0x{0}, Base = 0x{1},", Entry.Prefix.ToString("X2"), Entry.Base.ToString("X2"));

            Res.AppendFormat(" }},\r\n");

            return Res.ToString();
        }

        static string FormatOpcode(OpcodeMatrix.OpcodeEntry Entry)
        {
            StringBuilder Res = new StringBuilder();

            Res.AppendFormat("                new OpcodeData {{ Name = \"{0}\",\t// {1}\r\n", Entry.Opcode, OpcodeToString(Entry));
            Res.AppendFormat("                                 Function = Operation.{0},\r\n", Entry.Opcode);
            Res.AppendFormat("                                 new Param[] {{ ");
            foreach (var Param in Entry.Params)
            {
                Res.Append(FormatParamZASM(Param));
                Res.Append(", ");
            }
            Res.AppendFormat("}},\r\n");
            //Res.AppendFormat("                                 {0},\r\n", FormatParam(Entry, 0));
            //Res.AppendFormat("                                 {0},\r\n", FormatParam(Entry, 1));
            //Res.AppendFormat("                                 {0},\r\n", FormatParam(Entry, 2));
            Res.AppendFormat("                               }},");

            return Res.ToString();

        }

        static void Main(string[] args)
        {
            OpcodeMatrix Matrix = new OpcodeMatrix();
            List<string> Data = new List<string>(File.ReadAllLines(@"Z80 Opcode Matrix.txt"));
            Matrix.ProcessData(Data.ToArray());

            // ---------------------------------------------------

            List<string>[] Output = new List<string>[4];
            Output[0] = new List<string>(256);
            Output[1] = new List<string>(256);
            Output[2] = new List<string>(256);
            Output[3] = new List<string>(256);

            for (int x = 0; x < 256; x++)
            {
                StringBuilder Res = new StringBuilder();

                Res.AppendFormat("                new OpcodeData {{ Name = \"\",\t\t// {0:X2}\r\n", x);
                Res.AppendFormat("                                 Function = Operation.Error,\r\n");
                Res.AppendFormat("                                 new Param[] {{ }},\r\n");
                //Res.AppendFormat("                                 Reg1 = Register.None, Reg1Param = RegParam.None,\r\n");
                //Res.AppendFormat("                                 Reg2 = Register.None, Reg2Param = RegParam.None,\r\n");
                //Res.AppendFormat("                                 Reg3 = Register.None, Reg3Param = RegParam.None,\r\n");

                Res.AppendFormat("                               }},");

                Output[0].Add(Res.ToString());
                Output[1].Add(Res.ToString());
                Output[2].Add(Res.ToString());
                Output[3].Add(Res.ToString());

            }

            foreach (OpcodeMatrix.OpcodeEntry Entry in Matrix._OpcodeMatrix.Where(e => e.Prefix == 0))
                Output[0][Entry.Base] = FormatOpcode(Entry);

            foreach (OpcodeMatrix.OpcodeEntry Entry in Matrix._OpcodeMatrix.Where(e => e.Prefix == 0xED))
                Output[2][Entry.Base] = FormatOpcode(Entry);

            foreach (OpcodeMatrix.OpcodeEntry Entry in Matrix._OpcodeMatrix.Where(e => e.Prefix == 0xCB))
            {
                Output[1][Entry.Base] = FormatOpcode(Entry);
                if(Entry.Params.Where(e => e.Type == OpcodeMatrix.ParamType.IndexPtr).Count() != 0)
                    Output[3][Entry.Base] = FormatOpcode(Entry);

                if(Entry.Params.Where(e => e.Type == OpcodeMatrix.ParamType.HL_Pointer).Count() != 0)
                    Output[3][Entry.Base] = FormatOpcode(Entry);
                
            }

            StreamWriter OutputFile = new StreamWriter(@".\Z80Emu\Opcodes_new.cs", false);

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


            // ---------------------------------------------------

            OutputFile = new StreamWriter(@".\ZASM\Opcodes_new.cs", false);
            OutputFile.WriteLine("using System.Collections.Generic;");
            OutputFile.WriteLine("namespace ZASM");
            OutputFile.WriteLine("{");
            OutputFile.WriteLine("    static class Ops");
            OutputFile.WriteLine("    {");
            OutputFile.WriteLine("        static public OpcodeEncoding[] EncodingData = ");
            OutputFile.WriteLine("        {");

            foreach (var Entry in Matrix._OpcodeList.OrderBy(e => !e.Offical).OrderBy(e => e.Opcode))
            {
                OutputFile.WriteLine(GetOpcodeEncoding(Entry));
            }

            OutputFile.WriteLine("        };");
            OutputFile.WriteLine("    }");
            OutputFile.WriteLine("}");

            OutputFile.Flush();
            OutputFile.Close(); 
            
            //NewStyle();

            //// Old Style

            //List<string> Data = new List<string>(File.ReadAllLines(@"Z80 Opcodes.csv"));
            //List<string>[] Output = new List<string>[4];
            //Dictionary<string, List<OpcodeEntry>> EntryList = new Dictionary<string, List<OpcodeEntry>>();

            //Output[0] = new List<string>(256);
            //Output[1] = new List<string>(256);
            //Output[2] = new List<string>(256);
            //Output[3] = new List<string>(256);

            //for (int x = 0; x < 256; x++)
            //{
            //    StringBuilder Res = new StringBuilder();


            //    Res.AppendFormat("                new OpcodeData {{ Name = \"\",\t\t// {0:X2}\r\n", x);
            //    Res.AppendFormat("                                 Reg1 = Register.None, Reg1Param = RegParam.None,\r\n");
            //    Res.AppendFormat("                                 Reg2 = Register.None, Reg2Param = RegParam.None,\r\n");
            //    Res.AppendFormat("                                 Reg3 = Register.None, Reg3Param = RegParam.None,\r\n");
            //    Res.AppendFormat("                                 Function = Operation.Error ");

            //    Res.AppendFormat("}},");

            //    Output[0].Add(Res.ToString());
            //    Output[1].Add(Res.ToString());
            //    Output[2].Add(Res.ToString());
            //    Output[3].Add(Res.ToString());

            //}

            //List<byte> ByteCode = new List<byte>();

            //foreach (string Line in Data)
            //{
            //    string[] Fields = Line.Split(',');

            //    // Skip the header line
            //    if (Fields[Official].ToUpper() == "OFFICIAL")
            //        continue;

            //    OpcodeEntry Entry = ReadOpcodeEntry(Fields);
            //    if (!EntryList.ContainsKey(Entry.Name))
            //        EntryList[Entry.Name] = new List<OpcodeEntry>();

            //    EntryList[Entry.Name].Add(Entry);

            //    if (Entry.Offical != 'N')
            //    {
            //        StringBuilder Res = new StringBuilder();

            //        Res.AppendFormat("                new OpcodeData {{ Name = \"{0}\",\t// {1}: {2} {3} {4} {5}\r\n", Entry.Name, FormatEach("{0:X2}", Entry.Encoding, false), Entry.Name, Entry.Param1, Entry.Param2, Entry.Param3);
            //        Res.AppendFormat("                                 Reg1 = {0}, Reg1Param = {1},\r\n", ConvertRegs(Entry.Param1, Entry, false), ConvertParams(Entry.Param1, Entry));
            //        Res.AppendFormat("                                 Reg2 = {0}, Reg2Param = {1},\r\n", ConvertRegs(Entry.Param2, Entry, false), ConvertParams(Entry.Param2, Entry));
            //        Res.AppendFormat("                                 Reg3 = {0}, Reg3Param = {1},\r\n", ConvertRegs(Entry.Param3, Entry, false), ConvertParams(Entry.Param3, Entry));
            //        Res.AppendFormat("                                 Function = Operation.{0} ", Entry.Name);
            //        Res.AppendFormat("}},");


            //        if (Fields[Prefix].Length == 0)
            //            Output[0][Convert.ToInt32(Fields[HEX], 16)] = Res.ToString();

            //        else if (Fields[Prefix] == "CB")
            //            Output[1][Convert.ToInt32(Fields[HEX], 16)] = Res.ToString();

            //        else if (Fields[Prefix] == "ED")
            //            Output[2][Convert.ToInt32(Fields[HEX], 16)] = Res.ToString();

            //        else if (Fields[Prefix] == "DD")
            //            Output[3][Convert.ToInt32(Fields[HEX], 16)] = Res.ToString();
            //    }

            //    if (Entry.IX_IY != 'N')
            //    {
            //        Entry.IndexOnly = false;

            //        if (Entry.IX_IY == 'Y' || Entry.IX_IY == 'V')
            //        {
            //            OpcodeEntry NewEntry = Entry;

            //            if (Entry.Param1 == "(HL)")
            //                NewEntry.Param1 = "(IX)";
            //            else
            //                NewEntry.Param2 = "(IX)";

            //            NewEntry.Encoding = new List<byte>(Entry.Encoding);
            //            NewEntry.Encoding.Insert(0, 0xDD);
            //            EntryList[Entry.Name].Add(NewEntry);

            //            if (Entry.Param1 == "(HL)")
            //                NewEntry.Param1 = "(IY)";
            //            else
            //                NewEntry.Param2 = "(IY)";

            //            NewEntry.Encoding = new List<byte>(Entry.Encoding);
            //            NewEntry.Encoding.Insert(0, 0xFD);
            //            EntryList[Entry.Name].Add(NewEntry);
            //        }

            //        if (Entry.IX_IY == 'Z')
            //        {
            //            OpcodeEntry NewEntry = Entry;

            //            if (Entry.Param1 == "HL")
            //                NewEntry.Param1 = "IX";
            //            else
            //                NewEntry.Param2 = "IX";

            //            NewEntry.Encoding = new List<byte>(Entry.Encoding);
            //            NewEntry.Encoding.Insert(0, 0xDD);
            //            EntryList[Entry.Name].Add(NewEntry);

            //            if (Entry.Param1 == "HL")
            //                NewEntry.Param1 = "IY";
            //            else
            //                NewEntry.Param2 = "IY";

            //            NewEntry.Encoding = new List<byte>(Entry.Encoding);
            //            NewEntry.Encoding.Insert(0, 0xFD);
            //            EntryList[Entry.Name].Add(NewEntry);
            //        }

            //        else if (Entry.IX_IY == 'X')
            //        {
            //            OpcodeEntry NewEntry = Entry;

            //            if (Entry.Param1 == "H")
            //                NewEntry.Param1 = "IXH";
            //            else if (Entry.Param1 == "L")
            //                NewEntry.Param1 = "IXL";

            //            if (Entry.Param2 == "H")
            //                NewEntry.Param2 = "IXH";
            //            else if (Entry.Param2 == "L")
            //                NewEntry.Param2 = "IXL";

            //            NewEntry.Encoding = new List<byte>(Entry.Encoding);
            //            NewEntry.Encoding.Insert(0, 0xDD);
            //            EntryList[Entry.Name].Add(NewEntry);

            //            if (Entry.Param1 == "H")
            //                NewEntry.Param1 = "IYH";
            //            else if (Entry.Param1 == "L")
            //                NewEntry.Param1 = "IYL";

            //            if (Entry.Param2 == "H")
            //                NewEntry.Param2 = "IYH";
            //            else if (Entry.Param2 == "L")
            //                NewEntry.Param2 = "IYL";

            //            NewEntry.Encoding = new List<byte>(Entry.Encoding);
            //            NewEntry.Encoding.Insert(0, 0xFD);
            //            EntryList[Entry.Name].Add(NewEntry);
            //        }
            //    }
            //}


            //StreamWriter OutputFile = new StreamWriter(@".\Z80Emu\Opcodes.cs", false);

            //OutputFile.WriteLine("namespace Z80Emu");
            //OutputFile.WriteLine("{");
            //OutputFile.WriteLine("    static class Ops");
            //OutputFile.WriteLine("    {");
            //OutputFile.WriteLine("        static public OpcodeData[,] ByteData = new OpcodeData[,]");
            //OutputFile.WriteLine("        {");
            //OutputFile.WriteLine("            {");

            //Output[0].ForEach(OutputFile.WriteLine);

            //OutputFile.WriteLine("            },");
            //OutputFile.WriteLine("");
            //OutputFile.WriteLine("            {");

            //Output[1].ForEach(OutputFile.WriteLine);

            //OutputFile.WriteLine("            },");
            //OutputFile.WriteLine("");
            //OutputFile.WriteLine("            {");

            //Output[2].ForEach(OutputFile.WriteLine);

            //OutputFile.WriteLine("            },");
            //OutputFile.WriteLine("");
            //OutputFile.WriteLine("            {");

            //Output[3].ForEach(OutputFile.WriteLine);

            //OutputFile.WriteLine("            },");
            //OutputFile.WriteLine("        };");
            //OutputFile.WriteLine("    }");
            //OutputFile.WriteLine("}");


            //OutputFile.Flush();
            //OutputFile.Close();

            //OutputFile = new StreamWriter(@".\ZASM\Opcodes.cs", false);
            //OutputFile.WriteLine("using System.Collections.Generic;");
            //OutputFile.WriteLine("namespace ZASM");
            //OutputFile.WriteLine("{");
            //OutputFile.WriteLine("    static class Ops");
            //OutputFile.WriteLine("    {");
            //OutputFile.WriteLine("        static public Dictionary<CommandID, OpcodeEncoding[]> EncodingData = new Dictionary<CommandID,OpcodeEncoding[]>");
            //OutputFile.WriteLine("        {");
            //foreach (var OpcodeList in EntryList.OrderBy(e => e.Key))
            //{
            //    OutputFile.WriteLine("            {");
            //    OutputFile.WriteLine("                CommandID.{0}, new OpcodeEncoding[]", OpcodeList.Key);
            //    OutputFile.WriteLine("                {");
            //    foreach (OpcodeEntry Entry in OpcodeList.Value)
            //    {
            //        if (!Entry.IndexOnly)
            //            OutputFile.WriteLine(GetOpcodeEncoding(Entry));
            //    }
            //    OutputFile.WriteLine("                }");
            //    OutputFile.WriteLine("            },");
            //}

            //OutputFile.WriteLine("        };");
            //OutputFile.WriteLine("    }");
            //OutputFile.WriteLine("}");

            //OutputFile.Flush();
            //OutputFile.Close();
        }
    }
}
