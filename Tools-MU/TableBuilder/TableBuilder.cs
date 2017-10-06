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
            //List<string> Data = new List<string>(File.ReadAllLines(@"Z80 Opcode Matrix.txt"));
            
            GroupInfo = OpcodeReader.ReadOpcodeData(@"Z80 Opcode Matrix.txt");
            SaveGroupInfo(GroupInfo, "Z80");
            
            GroupInfo = OpcodeReader.ReadOpcodeData(@"i8080 Opcode Matrix.txt");
            SaveGroupInfo(GroupInfo, "i8080");

            GroupInfo = OpcodeReader.ReadOpcodeData(@"GameBoy Opcode Matrix.txt");
            SaveGroupInfo(GroupInfo, "GB");
        }

        static string GetParamaterType(ParamInfo Param)
        {
            switch (Param.Type)
            {
                case ParameterType.WordRegisterAF:
                    return ParameterType.WordRegister.ToString();

                case ParameterType.HalfFlag:
                    return ParameterType.Flag.ToString();

                default:
                    return Param.Type.ToString();
            }
        }

        static string GenerateFlags(OpcodeData Entry)
        {
            StringBuilder Output = new StringBuilder();

            if (Entry.HasIndex())
            {
                Output.Append("OpcodeFlags.Index");
                if(Entry.Prefix == 0xCB)
                    Output.Append(" | OpcodeFlags.InternalIndex");
            }

            if (Entry.Type == OpcodeType.Undocumented)
            {
                if (Output.Length != 0)
                    Output.Append(" | ");

                Output.Append("OpcodeFlags.Undocumented");
            }
            
            if(Entry.HasType(ParameterType.HalfFlag))
            {
                if (Output.Length != 0)
                    Output.Append(" | ");

                Output.Append("OpcodeFlags.HalfFlag");

            }
            
            if(Entry.HasType(ParameterType.WordRegisterAF))
            {
                if (Output.Length != 0)
                    Output.Append(" | ");

                Output.Append("OpcodeFlags.WordRegisterAF");
            }

            if (Output.Length == 0)
                Output.Append("OpcodeFlags.None");

            return Output.ToString();
        }

        static string GenerateOpcode(OpcodeData Entry, bool ForDecoding)
        {
            StringBuilder Output = new StringBuilder();

            Output.Append("            new OpcodeData { ");
            if (ForDecoding)
                Output.AppendFormat("Prefix = 0x{0}, ", Entry.Prefix.ToString("X4"));
            else
                Output.AppendFormat("Prefix = 0x{0}, ", Entry.Prefix.ToString("X2"));
            
            Output.AppendFormat("Encoding = 0x{0}, ", Entry.Base.ToString("X2"));

            if (ForDecoding)
            {
                Output.AppendFormat("Name = \"{0}\",\t", Entry.ID.ToString());
                Output.AppendFormat("Function = FunctionID.{0},\t", Entry.Function);
            }
            else
            {
                Output.AppendFormat("Name = CommandID.{0},\t", Entry.ID.ToString());
            }

            for (int x = 0, v = 0; x < Entry.Params.Count; x++)
            {
                if (!ForDecoding && Entry.Params[x].Implicit)
                    continue;
                
                //Output.AppendFormat("Param{0} = new ParamEntry(CommandID.{1}, ParameterType.{2}, {3}), ", x, Entry.Params[x].ID.ToString(), Entry.Params[x].Type.ToString(), Entry.Params[x].Pointer);
                Output.AppendFormat("Param{0} = new ParamEntry(CommandID.", v);
                Output.Append(Entry.Params[x].ID.ToString());
                Output.Append(", ParameterType.");
                Output.Append(GetParamaterType(Entry.Params[x]));
                Output.Append(", ");
                Output.Append(Entry.Params[x].Pointer.ToString().ToLower());
                if (!ForDecoding)
                {
                    Output.Append(", ");
                    Output.Append(Entry.Params[x].Pos);
                    Output.Append("),\t");
                }
                v++;
            }

            if (!ForDecoding)
            {
                Output.AppendFormat("Flags = {0},\t", GenerateFlags(Entry));
                Output.AppendFormat("Cycles = {0},\t", Entry.CycleCount);
                Output.AppendFormat("Length = {0},\t", Entry.Length);
                
            }
            
            Output.Append("}, ");

            return Output.ToString();
        }

        static void SaveGroupInfo(OpcodeGroup GroupInfo, string Prefix)
        {
            string FileName = Prefix + " Output.txt";
            StreamWriter OutputFile = new StreamWriter(FileName, false);

            foreach (OpcodeData Entry in GroupInfo.OpcodeList)
            {
                if (Entry.Type == OpcodeType.Unoffical)
                    continue;

                OutputFile.WriteLine(GenerateOpcode(Entry, false));

                //if (Entry.Prefix == 0)
                //{
                //    OutputFile.Write("    ");
                //}
                //else if (Entry.Prefix < 0x100)
                //{
                //    OutputFile.Write("  ");
                //    OutputFile.Write(Entry.Prefix.ToString("X2"));
                //}
                //else
                //{
                //    OutputFile.Write(Entry.Prefix.ToString("X4"));
                //}

                //OutputFile.Write(Entry.Base.ToString("X2"));
                //OutputFile.Write(": ");
                //OutputFile.Write(Entry.ID.ToString());

                //foreach (ParamInfo Param in Entry.Params)
                //{
                //    OutputFile.Write(" ");
                //    if (Param.Pointer)
                //        OutputFile.Write("(");

                //    if (Param.ID != ZASM.CommandID.RegisterMax)
                //        OutputFile.Write(Param.ID.ToString());
                //    else
                //        OutputFile.Write(Param.Type.ToString());

                //    if (Param.Pointer)
                //        OutputFile.Write(")");
                //}

                //OutputFile.WriteLine();
            }

            OutputFile.WriteLine();
            OutputFile.WriteLine("---------------------------------------");
            OutputFile.WriteLine();

            foreach (OpcodeData Entry in GroupInfo.OpcodeMatrix)
            {
                OutputFile.WriteLine(GenerateOpcode(Entry, true));

            }

            OutputFile.Close();
        }
    }
}
