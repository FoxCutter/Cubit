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
        static string ParamTypeToString(OpcodeMatrix.ParamType Type)
        {
            switch (Type)
            {
                case OpcodeMatrix.ParamType.ByteData:
                    return "n";

                case OpcodeMatrix.ParamType.Displacment:
                    return "e-2";

                case OpcodeMatrix.ParamType.WordData:
                case OpcodeMatrix.ParamType.Address:
                    return "nn";

                case OpcodeMatrix.ParamType.Address_Registers:
                    return "HL*";

                case OpcodeMatrix.ParamType.HL_Pointer:
                    return "(HL)";

                case OpcodeMatrix.ParamType.BC_Pointer:
                    return "(BC)";

                case OpcodeMatrix.ParamType.DE_Pointer:
                    return "(DE)";

                case OpcodeMatrix.ParamType.SP_Pointer:
                    return "(SP)";

                case OpcodeMatrix.ParamType.Address_Pointer:
                    return "(**)";

                case OpcodeMatrix.ParamType.Index_Pointer:
                    return "(IX*)";

                case OpcodeMatrix.ParamType.ByteReg:
                    return "r";

                case OpcodeMatrix.ParamType.ByteRegIndex:
                    return "r*";

                case OpcodeMatrix.ParamType.WordRegAF:
                case OpcodeMatrix.ParamType.WordReg:
                    return "rr";

                case OpcodeMatrix.ParamType.Flags:
                case OpcodeMatrix.ParamType.HalfFlags:
                    return "cc";

                case OpcodeMatrix.ParamType.Encoded:
                    return "n";

                case OpcodeMatrix.ParamType.Byte_Pointer:
                    return "(HL*)";

                case OpcodeMatrix.ParamType.High_Pointer:
                    return "(+Word)";

                case OpcodeMatrix.ParamType.High_C_Pointer:
                    return "(+C)";

                case OpcodeMatrix.ParamType.SP_Offset:
                    return "SP + n";

                default:
                    if (Type >= OpcodeMatrix.ParamType.Zero && Type < OpcodeMatrix.ParamType.Expandable)
                        return (Type - OpcodeMatrix.ParamType.Zero).ToString("X");

                    return Type.ToString();
            }
        }

        static string OpcodeToString(OpcodeMatrix.OpcodeEntry Entry, bool ShowImplicit)
        {
            StringBuilder Res = new StringBuilder();

            Res.AppendFormat("{0}{1}: {2}", Entry.Prefix == 0 ? "" : Entry.Prefix.ToString("X2"), Entry.Base.ToString("X2"), Entry.Opcode);
            foreach (OpcodeMatrix.ParamInformation Param in Entry.Params)
            {
                if(ShowImplicit || !Param.Implicit)
                    Res.AppendFormat(" {0},", ParamTypeToString(Param.Type));
                else if (Param.Implicit)
                    Res.AppendFormat(" !{0},", ParamTypeToString(Param.Type));
            }

            return Res.ToString();
        }

        static string ConvertFlags(OpcodeMatrix.OpcodeEntry Entry)
        {
            StringBuilder Ret = new StringBuilder();

            if (Entry.Offical == false)
                Ret.Append("ParamFlags.Unoffical");

            if (Entry.Prefix == 0xCB)
            {
                if (Ret.Length != 0)
                    Ret.Append(" | ");

                Ret.Append("ParamFlags.EmbededIndex");
            }

            if (Ret.Length == 0)
                return "ParamFlags.None";

            return Ret.ToString();
        }

        static string FormatParam(OpcodeMatrix.ParamInformation Param, bool Position)
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

                if (Position && Param.Pos != OpcodeMatrix.ParamPos.None)
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
                            Res.AppendFormat(" | CommandID.PosImmidate");
                            break;
                    }
                }
            }

            return Res.ToString();
        }
        
        static string GetOpcodeEncoding(OpcodeMatrix.OpcodeEntry Entry)
        {
            StringBuilder Res = new StringBuilder();

            Res.AppendFormat("            // {0}\r\n", OpcodeToString(Entry, false));
            Res.AppendFormat("            new OpcodeEncoding {{ Function = CommandID.{0},\r\n", Entry.Opcode);
            Res.AppendFormat("                                 Params = new CommandID[] {{ ");
            foreach (var Param in Entry.Params)
            {
                if (!Param.Implicit)
                {
                    Res.Append(FormatParam(Param, true));
                    Res.Append(", ");
                }
            }
            Res.AppendFormat("}},\r\n");
            Res.AppendFormat("                                 Flags = {0},\r\n", ConvertFlags(Entry));
            Res.AppendFormat("                                 Prefix = 0x{0}, Base = 0x{1},\r\n", Entry.Prefix.ToString("X2"), Entry.Base.ToString("X2"));
            Res.AppendFormat("                               }},\r\n");


            return Res.ToString();
        }

        static string FormatOpcode(OpcodeMatrix.OpcodeEntry Entry)
        {
            StringBuilder Res = new StringBuilder();

            Res.AppendFormat("                // {0}\r\n", OpcodeToString(Entry, true));
            Res.AppendFormat("                new OpcodeData {{ Name = \"{0}\",\r\n", Entry.Opcode); 
            Res.AppendFormat("                                 Function = Operation.{0},\r\n", Entry.Function);
            Res.AppendFormat("                                 new Param[] {{ ");
            foreach (var Param in Entry.Params)
            {
                Res.Append(FormatParam(Param, false));
                Res.Append(", ");
            }
            Res.AppendFormat("}},\r\n");
            Res.AppendFormat("                               }},\r\n");

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

                Res.AppendFormat("                // {0:X2}\r\n", x);
                Res.AppendFormat("                new OpcodeData {{ Name = \"\",\r\n");
                Res.AppendFormat("                                 Function = Operation.Error,\r\n");
                Res.AppendFormat("                                 new Param[] {{ }}\r\n");
                Res.AppendFormat("                               }},\r\n");

                //Res.AppendFormat("                new OpcodeData {{ Name = \"\", Function = Operation.Error, new Param[] {{ }}, }}, // {0:X2}", x);

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

                if (Entry.HasType(OpcodeMatrix.ParamType.Index_Pointer) || Entry.HasType(OpcodeMatrix.ParamType.HL_Pointer))
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

            OutputFile = new StreamWriter(@".\ZASM\Opcodes.cs", false);
            OutputFile.WriteLine("namespace ZASM");
            OutputFile.WriteLine("{");
            OutputFile.WriteLine("    static class Ops");
            OutputFile.WriteLine("    {");
            OutputFile.WriteLine("        static public OpcodeEncoding[] EncodingData = ");
            OutputFile.WriteLine("        {");

            foreach (var Entry in Matrix._OpcodeList.Where(e => e.Offical).OrderBy(e => e.Opcode))
            {
                OutputFile.WriteLine(GetOpcodeEncoding(Entry));
            }

            OutputFile.WriteLine("        };");
            OutputFile.WriteLine("    }");
            OutputFile.WriteLine("}");

            OutputFile.Flush();
            OutputFile.Close();

            //OutputFile.WriteLine("using System.Collections.Generic;");
            //OutputFile.WriteLine("namespace ZASM");
            //OutputFile.WriteLine("{");
            //OutputFile.WriteLine("    static class Ops");
            //OutputFile.WriteLine("    {");
            //OutputFile.WriteLine("        static public Dictionary<CommandID, OpcodeEncoding[]> EncodingData = new Dictionary<CommandID,OpcodeEncoding[]>");
            //OutputFile.WriteLine("        {");

            //foreach (var OpcodeList in Matrix._OpcodeMatrix.GroupBy(e => e.Opcode).OrderBy(e => e.Key))
            //{
            //    OutputFile.WriteLine("            {");
            //    OutputFile.WriteLine("                CommandID.{0}, new OpcodeEncoding[]", OpcodeList.Key);
            //    OutputFile.WriteLine("                {");
            //    foreach (var Entry in OpcodeList)
            //    {
            //        OutputFile.WriteLine(GetOpcodeEncoding(Entry));
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
