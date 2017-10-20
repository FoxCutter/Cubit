using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TableBuilder
{
    public static class DistinctHelper
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var identifiedKeys = new HashSet<TKey>();
            return source.Where(element => identifiedKeys.Add(keySelector(element)));
        }
    }
    
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

        static string GetParamater(ParamInfo Param, bool ForDecoding)
        {
            if(!ForDecoding)
                return Param.ID.ToString();
            
            switch (Param.ID)
            {
                case ZASM.CommandID.IX:
                case ZASM.CommandID.IY:
                    return "Index";

                case ZASM.CommandID.IXH:
                case ZASM.CommandID.IYH:
                    return "IndexHigh";

                case ZASM.CommandID.IXL:
                case ZASM.CommandID.IYL:
                    return "IndexLow";

                default:
                    return Param.ID.ToString();
            }
        }

        static string GetParamaterType(ParamInfo Param, bool ForDecoding)
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
            if (!ForDecoding)
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
                Output.Append(GetParamater(Entry.Params[x], ForDecoding));
                Output.Append(", ParameterType.");
                Output.Append(GetParamaterType(Entry.Params[x], ForDecoding));
                Output.Append(", ");
                Output.Append(Entry.Params[x].Pointer.ToString().ToLower());
                if (!ForDecoding)
                {
                    Output.Append(", ");
                    Output.Append(Entry.Params[x].Pos);
                }
                Output.Append("),\t");
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

        static void WriteDecodingRange(StreamWriter OutputFile, IEnumerable<OpcodeData> Range)
        {
            int Count = 0;
            OpcodeData Dummy = new OpcodeData();
            Dummy.Function = "None";

            foreach (OpcodeData Entry in Range)
            {
                while (Count < Entry.Base)
                {
                    Dummy.Base = Count;
                    OutputFile.WriteLine(GenerateOpcode(Dummy, true));
                    Count++;
                }

                OutputFile.WriteLine(GenerateOpcode(Entry, true));

                Count++;
            }

            while (Count < 0x100)
            {
                Dummy.Base = Count;
                OutputFile.WriteLine(GenerateOpcode(Dummy, true));
                Count++;
            }
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
            }

            OutputFile.WriteLine();
            OutputFile.WriteLine("---------------------------------------");
            OutputFile.WriteLine();

            WriteDecodingRange(OutputFile, GroupInfo.OpcodeMatrix.Where(e => e.Prefix == 0x00).DistinctBy(e => e.Base));
            OutputFile.WriteLine();

            WriteDecodingRange(OutputFile, GroupInfo.OpcodeMatrix.Where(e => e.Prefix == 0xED).DistinctBy(e => e.Base));
            OutputFile.WriteLine();

            WriteDecodingRange(OutputFile, GroupInfo.OpcodeMatrix.Where(e => e.Prefix == 0xCB).DistinctBy(e => e.Base));
            OutputFile.WriteLine();

            WriteDecodingRange(OutputFile, GroupInfo.OpcodeMatrix.Where(e => e.Prefix == 0xDD).DistinctBy(e => e.Base));
            OutputFile.WriteLine();

            WriteDecodingRange(OutputFile, GroupInfo.OpcodeMatrix.Where(e => e.Prefix == 0xDDCB).DistinctBy(e => e.Base));

            OutputFile.Close();
        }
    }
}
