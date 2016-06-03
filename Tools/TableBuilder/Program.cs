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
        
        static void Main(string[] args)
        {
            List<string> Data = new List<string>(File.ReadAllLines(@"Z80 Opcodes.csv"));
            List<string>[] Output = new List<string>[3];
            Output[0] = new List<string>(256);
            Output[1] = new List<string>(256);
            Output[2] = new List<string>(256);

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
                
            }


            //Data.OrderBy(e => { return false; });
            Data.Sort(SortData);
            
            
            foreach (string Line in Data)
            {
                string[] Fields = Line.Split(',');

                if (Fields[Official] != "Y")
                    continue;

                StringBuilder Res = new StringBuilder();

                uint Code0 = 0;
                uint Code1 = 0;

                if (Fields[Prefix].Length != 0)
                    Code0 = Convert.ToUInt16(Fields[Prefix], 16);

                Code1 = Convert.ToUInt16(Fields[HEX], 16);

                Res.AppendFormat("            new OpcodeEncoding {{ Name = \"{0}\",\t// {1}{2}: {3} {4} {5}\r\n", Fields[Opcode], Fields[Prefix], Fields[HEX], Fields[Opcode], Fields[Param1], Fields[Param2]);
                if(Code0 == 0)
                    Res.AppendFormat("                                  Encoding = new byte[] {{ 0x{0:X2} }},\r\n", Code1);
                else
                    Res.AppendFormat("                                  Encoding = new byte[] {{ 0x{0:X2}, 0x{1:X2} }},\r\n", Code0, Code1);
                Res.AppendFormat("                                  Reg1 = {0}, Reg1Param = {1},\r\n", ConvertRegs(Fields[Param1], Fields, true), ConvertParams(Fields[Param1], Fields));
                Res.AppendFormat("                                  Reg2 = {0}, Reg2Param = {1},\r\n", ConvertRegs(Fields[Param2], Fields, true), ConvertParams(Fields[Param2], Fields));
                Res.AppendFormat("                                  Function = CommandID.{0} ", Fields[Opcode]);
                Res.AppendFormat("}},");

                OutputZasm.Add(Res.ToString());

                Res.Clear();


                Res.AppendFormat("                new OpcodeData {{ Name = \"{0}\",\t// {1}{2}: {3} {4} {5}\r\n", Fields[Opcode], Fields[Prefix], Fields[HEX], Fields[Opcode], Fields[Param1], Fields[Param2]);
                Res.AppendFormat("                                 Reg1 = {0}, Reg1Param = {1},\r\n", ConvertRegs(Fields[Param1], Fields, false), ConvertParams(Fields[Param1], Fields));
                Res.AppendFormat("                                 Reg2 = {0}, Reg2Param = {1},\r\n", ConvertRegs(Fields[Param2], Fields, false), ConvertParams(Fields[Param2], Fields));
                Res.AppendFormat("                                 Function = Operation.{0} ", Fields[Opcode]);
                Res.AppendFormat("}},");

                if(Fields[Prefix].Length == 0)
                    Output[0][Convert.ToInt32(Fields[HEX], 16)] = Res.ToString();

                else if (Fields[Prefix] == "CB")
                    Output[1][Convert.ToInt32(Fields[HEX], 16)] = Res.ToString();
                
                else if (Fields[Prefix] == "ED")
                    Output[2][Convert.ToInt32(Fields[HEX], 16)] = Res.ToString();


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
                return "(" + Base + ")" + Param;
            }


            if (Param == "0H"  || Param == "8H"  || Param == "10H" ||
                Param == "18H" || Param == "20H" || Param == "28H" ||
                Param == "30H" || Param == "38H"
                )
            {
                Param = Param.Substring(0, Param.Length - 1);
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

            if (Param == "HL")
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
    }
}
