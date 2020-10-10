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

    class LocalOpcodeEntry : OpcodeData.OpcodeEntry
    {
        public bool Prefered;
        public bool i8080;

        public LocalOpcodeEntry() : base()
        {
            Prefered = true;
            i8080 = false;
        }

        public LocalOpcodeEntry(LocalOpcodeEntry Clone) : base(Clone)
        {
            Prefered = Clone.Prefered;
            i8080 = Clone.i8080;
        }
    }

    class OpcodeGroup
    {
        public List<LocalOpcodeEntry> OpcodeList;
        public List<LocalOpcodeEntry> OpcodeMatrix;

        public OpcodeGroup()
        {
            OpcodeList = new List<LocalOpcodeEntry>();
            OpcodeMatrix = new List<LocalOpcodeEntry>();
        }
    };
    
    class OpcodeReader
    {
        static OpcodeData.ParamEntry GetParamInfo(argType Arg)
        {
            OpcodeData.ParamEntry Ret = new OpcodeData.ParamEntry();

            Ret.Implicit = Arg.hidden;

            switch (Arg.Value.ToUpper().Trim())
            {
                case "RSTVALUE":
                    Ret.Param = OpcodeData.ParameterID.EncodedValue;
                    Ret.Type = OpcodeData.ParameterType.RstValue;
                    break;

                case "VALUE":
                    Ret.Param = OpcodeData.ParameterID.EncodedValue;
                    Ret.Type = OpcodeData.ParameterType.Value;
                    break;

                case "VALUE-0":
                    Ret.Param = OpcodeData.ParameterID.Value0;
                    Ret.Type = OpcodeData.ParameterType.Value;
                    break;

                case "VALUE-1":
                    Ret.Param = OpcodeData.ParameterID.Value1;
                    Ret.Type = OpcodeData.ParameterType.Value;
                    break;

                case "VALUE-2":
                    Ret.Param = OpcodeData.ParameterID.Value2;
                    Ret.Type = OpcodeData.ParameterType.Value;
                    break;

                case "FLAG-NZ":
                    Ret.Param = OpcodeData.ParameterID.Flag_NZ;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case "FLAG-Z":
                    Ret.Param = OpcodeData.ParameterID.Flag_Z;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case "FLAG-NC":
                    Ret.Param = OpcodeData.ParameterID.Flag_NC;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case "FLAG-C":
                case "FLAG-CY":
                    Ret.Param = OpcodeData.ParameterID.Flag_CY;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case "FLAG-PO":
                    Ret.Param = OpcodeData.ParameterID.Flag_PO;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case "FLAG-PE":
                    Ret.Param = OpcodeData.ParameterID.Flag_PE;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case "FLAG-P":
                    Ret.Param = OpcodeData.ParameterID.Flag_P;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case "FLAG-M":
                    Ret.Param = OpcodeData.ParameterID.Flag_M;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case "ADDRESSPTR":
                    Ret.Param = OpcodeData.ParameterID.ImmediateWord;
                    Ret.Type = OpcodeData.ParameterType.AddressPointer;
                    break;

                case "ADDRESS":
                    Ret.Param = OpcodeData.ParameterID.ImmediateWord;
                    Ret.Type = OpcodeData.ParameterType.Address;
                    break;

                case "BYTE":
                    Ret.Param = OpcodeData.ParameterID.ImmediateByte;
                    Ret.Type = OpcodeData.ParameterType.Value;
                    break;

                case "WORD":
                    Ret.Param = OpcodeData.ParameterID.ImmediateWord;
                    Ret.Type = OpcodeData.ParameterType.Value;
                    break;

                case "DISP":
                    Ret.Param = OpcodeData.ParameterID.ImmediateByte;
                    Ret.Type = OpcodeData.ParameterType.Displacment;
                    break;

                case "BYTEREG":
                    Ret.Param = OpcodeData.ParameterID.RegisterAny;
                    Ret.Type = OpcodeData.ParameterType.ByteRegister;
                    break;

                case "WORDREG":
                    Ret.Param = OpcodeData.ParameterID.RegisterAny;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case "WORDREGF":
                    Ret.Param = OpcodeData.ParameterID.RegisterAny;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterAF;
                    break;

                case "BYTEINDEXREG":
                    Ret.Param = OpcodeData.ParameterID.RegisterAny;
                    Ret.Type = OpcodeData.ParameterType.ByteIndexRegister;
                    break;

                case "WORDINDEXREG":
                    Ret.Param = OpcodeData.ParameterID.WordReg_XX;
                    Ret.Type = OpcodeData.ParameterType.WordIndexRegister;
                    break;

                case "WORDINDEXREGPTR":
                    Ret.Param = OpcodeData.ParameterID.WordReg_XX;
                    Ret.Type = OpcodeData.ParameterType.WordIndexRegisterPointer;
                    break;

                case "FLAG":
                    Ret.Param = OpcodeData.ParameterID.FlagsAny;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case "HALFFLAG":
                    Ret.Param = OpcodeData.ParameterID.FlagsAny;
                    Ret.Type = OpcodeData.ParameterType.HalfFlag;
                    break;

                case "BYTEREG-A":
                    Ret.Param = OpcodeData.ParameterID.ByteReg_A;
                    Ret.Type = OpcodeData.ParameterType.ByteRegister;
                    break;

                case "BYTEREG-C":
                    Ret.Param = OpcodeData.ParameterID.ByteReg_C;
                    Ret.Type = OpcodeData.ParameterType.ByteRegister;
                    break;

                case "BYTEREG-I":
                    Ret.Param = OpcodeData.ParameterID.ByteReg_I;
                    Ret.Type = OpcodeData.ParameterType.ByteRegister;
                    break;

                case "BYTEREG-R":
                    Ret.Param = OpcodeData.ParameterID.ByteReg_R;
                    Ret.Type = OpcodeData.ParameterType.ByteRegister;
                    break;

                case "WORDREG-AF":
                    Ret.Param = OpcodeData.ParameterID.WordReg_AF;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case "WORDREG-AFALT":
                    Ret.Param = OpcodeData.ParameterID.WordReg_AF_Alt;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case "WORDREG-BC":
                    Ret.Param = OpcodeData.ParameterID.WordReg_BC;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case "WORDREG-DE":
                    Ret.Param = OpcodeData.ParameterID.WordReg_DE;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case "WORDREG-HL":
                    Ret.Param = OpcodeData.ParameterID.WordReg_HL;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case "WORDREG-SP":
                    Ret.Param = OpcodeData.ParameterID.WordReg_SP;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case "WORDREGPTR-BC":
                    Ret.Param = OpcodeData.ParameterID.WordReg_BC;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                case "WORDREGPTR-DE":
                    Ret.Param = OpcodeData.ParameterID.WordReg_DE;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                case "WORDREGPTR-SP":
                    Ret.Param = OpcodeData.ParameterID.WordReg_SP;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                case "WORDREGPTR-HL":
                    Ret.Param = OpcodeData.ParameterID.WordReg_HL;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                // HLI
                case "WORDREGPTR-HLI":
                    Ret.Param = OpcodeData.ParameterID.WordReg_HLI;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                // HLD
                case "WORDREGPTR-HLD":
                    Ret.Param = OpcodeData.ParameterID.WordReg_HLD;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                // ($FF00 + C)
                case "HIGHMEMPTR+C":
                    Ret.Param = OpcodeData.ParameterID.ByteReg_C;
                    Ret.Type = OpcodeData.ParameterType.HighMemPointerPlus;
                    break;

                // ($FF00 + n)
                case "HIGHMEMPTR+BYTE":
                    Ret.Param = OpcodeData.ParameterID.ImmediateByte;
                    Ret.Type = OpcodeData.ParameterType.HighMemPointerPlus;
                    break;

                // (n)
                case "BYTEPTR":
                    Ret.Param = OpcodeData.ParameterID.ImmediateByte;
                    Ret.Type = OpcodeData.ParameterType.BytePointer;
                    break;

                // (C)
                case "BYTEREGPTR-C":
                    Ret.Param = OpcodeData.ParameterID.ByteReg_C;
                    Ret.Type = OpcodeData.ParameterType.BytePointer;
                    break;
                
                
                case "WORDREG-SP+BYTE":
                    Ret.Param = OpcodeData.ParameterID.ImmediateByte;
                    Ret.Type = OpcodeData.ParameterType.SPPlusOffset;
                    break;
                
                default:
                    Console.WriteLine(Arg.Value);
                    break;
            }

            switch (Arg.encoding)
            {
                case EncodingEnum.Direct:
                case EncodingEnum.None:
                    Ret.Encoding = OpcodeData.EncodingType.None;
                    break;

                case EncodingEnum.Reg2:
                    Ret.Encoding = OpcodeData.EncodingType.Pos1;
                    break;

                case EncodingEnum.Flag:
                case EncodingEnum.Reg1:
                    Ret.Encoding = OpcodeData.EncodingType.Pos2;
                    break;

                case EncodingEnum.WordReg:
                    Ret.Encoding = OpcodeData.EncodingType.Pos3;
                    break;

                case EncodingEnum.HalfFlag:
                    Ret.Encoding = OpcodeData.EncodingType.Pos4;
                    break;

                case EncodingEnum.ByteImmidate:
                    Ret.Encoding = OpcodeData.EncodingType.ByteImmidate;
                    break;

                case EncodingEnum.WordImmidate:
                    Ret.Encoding = OpcodeData.EncodingType.WordImmidate;
                    break;

                case EncodingEnum.IndexOffset:
                    Ret.Encoding = OpcodeData.EncodingType.IndexOffset;
                    break;

                default:
                   Console.WriteLine(Arg.encoding);
                   break;
            }

            return Ret;
        }

        static int[] ShiftMap = new int[] { 0, 0, 3, 4, 3 };

        static OpcodeData.ParameterID[] ByteRegister = { OpcodeData.ParameterID.ByteReg_B, OpcodeData.ParameterID.ByteReg_C, OpcodeData.ParameterID.ByteReg_D, OpcodeData.ParameterID.ByteReg_E, OpcodeData.ParameterID.ByteReg_H, OpcodeData.ParameterID.ByteReg_L, OpcodeData.ParameterID.None, OpcodeData.ParameterID.ByteReg_A };
        static OpcodeData.ParameterID[] WordRegister = { OpcodeData.ParameterID.WordReg_BC, OpcodeData.ParameterID.WordReg_DE, OpcodeData.ParameterID.WordReg_HL, OpcodeData.ParameterID.WordReg_SP };
        static OpcodeData.ParameterID[] WordRegisterAF = { OpcodeData.ParameterID.WordReg_BC, OpcodeData.ParameterID.WordReg_DE, OpcodeData.ParameterID.WordReg_HL, OpcodeData.ParameterID.WordReg_AF };

        //static OpcodeData.ParameterID[] ByteIndexRegister = { OpcodeData.ParameterID.IYH, OpcodeData.ParameterID.IXH, OpcodeData.ParameterID.IXL, OpcodeData.ParameterID.IYL };
        //static OpcodeData.ParameterID[] WordIndexRegister = { OpcodeData.ParameterID.IX, OpcodeData.ParameterID.IY };
        //static OpcodeData.ParameterID[] AddressIndexRegister = { OpcodeData.ParameterID.IX, OpcodeData.ParameterID.IY };

        static OpcodeData.ParameterID[] ByteIndexRegister = { OpcodeData.ParameterID.ByteReg_XXH, OpcodeData.ParameterID.ByteReg_XXL, };
        static OpcodeData.ParameterID[] WordIndexRegister = { OpcodeData.ParameterID.WordReg_XX };
        static OpcodeData.ParameterID[] AddressIndexRegister = { OpcodeData.ParameterID.WordReg_XX };

        static OpcodeData.ParameterID[] Flags = { OpcodeData.ParameterID.Flag_NZ, OpcodeData.ParameterID.Flag_Z, OpcodeData.ParameterID.Flag_NC, OpcodeData.ParameterID.Flag_CY, OpcodeData.ParameterID.Flag_PO, OpcodeData.ParameterID.Flag_PE, OpcodeData.ParameterID.Flag_P, OpcodeData.ParameterID.Flag_M };
        static OpcodeData.ParameterID[] HalfFlags = { OpcodeData.ParameterID.Flag_NZ, OpcodeData.ParameterID.Flag_Z, OpcodeData.ParameterID.Flag_NC, OpcodeData.ParameterID.Flag_CY };
        static OpcodeData.ParameterID[] Encoded = { OpcodeData.ParameterID.Value0, OpcodeData.ParameterID.Value1, OpcodeData.ParameterID.Value2, OpcodeData.ParameterID.Value3, OpcodeData.ParameterID.Value4, OpcodeData.ParameterID.Value5, OpcodeData.ParameterID.Value6, OpcodeData.ParameterID.Value7 };

        static List<OpcodeData.ParamEntry> GetExpandList(OpcodeData.ParamEntry Param)
        {
            OpcodeData.ParameterID[] ParamList = null;

            switch (Param.Type)
            {
                case OpcodeData.ParameterType.ByteRegister:
                    ParamList = ByteRegister;
                    break;

                case OpcodeData.ParameterType.ByteIndexRegister:
                    ParamList = ByteIndexRegister;
                    break;

                case OpcodeData.ParameterType.WordRegister:
                    ParamList = WordRegister;
                    break;

                case OpcodeData.ParameterType.WordIndexRegister:
                    ParamList = WordIndexRegister;
                    break;

                case OpcodeData.ParameterType.WordRegisterAF:
                    ParamList = WordRegisterAF;
                    break;

                case OpcodeData.ParameterType.WordIndexRegisterPointer:
                    ParamList = AddressIndexRegister;
                    break;

                case OpcodeData.ParameterType.Flag:
                    ParamList = Flags;
                    break;

                case OpcodeData.ParameterType.HalfFlag:
                    ParamList = HalfFlags;
                    break;

                case OpcodeData.ParameterType.Value:
                case OpcodeData.ParameterType.RstValue:
                    if(Param.Param == OpcodeData.ParameterID.EncodedValue)
                        ParamList = Encoded;
                    break;

                default:
                    ParamList = null;
                    break;

            }

            List<OpcodeData.ParamEntry> Ret = new List<OpcodeData.ParamEntry>();

            if (ParamList == null)
                return Ret;

            for (int x = 0; x < ParamList.Length; x++)
            {
                OpcodeData.ParamEntry NewParam = new OpcodeData.ParamEntry();

                NewParam.Param = ParamList[x];

                NewParam.Type = Param.Type;
                NewParam.Implicit = Param.Implicit;
                if (Param.Encoding >= OpcodeData.EncodingType.Pos1 && Param.Encoding <= OpcodeData.EncodingType.Pos4)
                    NewParam.Encoding = OpcodeData.EncodingType.None;
                else
                    NewParam.Encoding = Param.Encoding;

                Ret.Add(NewParam);
            }


            return Ret;
        }

        static int GetValue(OpcodeData.ParameterID Entry)
        {
            switch (Entry)
            {
                case OpcodeData.ParameterID.Value0:
                case OpcodeData.ParameterID.Flag_NZ:
                case OpcodeData.ParameterID.WordReg_BC:
                case OpcodeData.ParameterID.ByteReg_B:
                    return 0;

                case OpcodeData.ParameterID.Value1:
                case OpcodeData.ParameterID.Flag_Z:
                case OpcodeData.ParameterID.WordReg_DE:
                case OpcodeData.ParameterID.ByteReg_C:
                    return 1;

                case OpcodeData.ParameterID.Value2:
                case OpcodeData.ParameterID.Flag_NC:
                case OpcodeData.ParameterID.WordReg_HL:
                case OpcodeData.ParameterID.WordReg_IX:
                case OpcodeData.ParameterID.WordReg_IY:
                case OpcodeData.ParameterID.WordReg_XX:
                case OpcodeData.ParameterID.ByteReg_D:
                    return 2;

                case OpcodeData.ParameterID.Value3:
                case OpcodeData.ParameterID.Flag_CY:
                case OpcodeData.ParameterID.WordReg_AF:
                case OpcodeData.ParameterID.WordReg_SP:
                case OpcodeData.ParameterID.ByteReg_E:
                    return 3;

                case OpcodeData.ParameterID.Value4:
                case OpcodeData.ParameterID.Flag_PO:
                case OpcodeData.ParameterID.ByteReg_H:
                case OpcodeData.ParameterID.ByteReg_IXH:
                case OpcodeData.ParameterID.ByteReg_IYH:
                case OpcodeData.ParameterID.ByteReg_XXH:
                    return 4;

                case OpcodeData.ParameterID.Value5:
                case OpcodeData.ParameterID.Flag_PE:
                case OpcodeData.ParameterID.ByteReg_L:
                case OpcodeData.ParameterID.ByteReg_IXL:
                case OpcodeData.ParameterID.ByteReg_IYL:
                case OpcodeData.ParameterID.ByteReg_XXL:
                    return 5;

                case OpcodeData.ParameterID.Value6:
                case OpcodeData.ParameterID.Flag_P:
                    return 6;

                case OpcodeData.ParameterID.Value7:
                case OpcodeData.ParameterID.Flag_M:
                case OpcodeData.ParameterID.ByteReg_A:
                    return 7;

                default:
                    return 0;
            }
        }

        public static bool CanExpand(OpcodeData.ParamEntry Entry)
        {
            if (Entry.Param == OpcodeData.ParameterID.RegisterAny || Entry.Param == OpcodeData.ParameterID.FlagsAny || Entry.Param == OpcodeData.ParameterID.EncodedValue)
                return true;

            return false;
        }
        
        public static bool CanExpand(LocalOpcodeEntry Opcode)
        {
            foreach (OpcodeData.ParamEntry Entry in Opcode.Params)
            {
                if (CanExpand(Entry))
                    return true;
            }

            return false;
        }

        public static byte ExpandIndex(LocalOpcodeEntry Opcode)
        {
            for (byte x = 0; x < Opcode.Params.Length; x++)
            {
                if (CanExpand(Opcode.Params[x]))
                    return x;
            }

            return 0xFF;
        }

        static LocalOpcodeEntry CloneParams(LocalOpcodeEntry Opcode, OpcodeData.ParamEntry NewParam, int NewPos)
        {
            LocalOpcodeEntry Ret = new LocalOpcodeEntry(Opcode);

            Ret.Params[NewPos] = NewParam;

            return Ret;
        }


        static List<LocalOpcodeEntry> ExpandOpcodeEntry(LocalOpcodeEntry Entry)
        {
            List<LocalOpcodeEntry> Ret = new List<LocalOpcodeEntry>();

            if (!CanExpand(Entry))
            {
                Ret.Add(Entry);
                return Ret;
            }

            int Pos = ExpandIndex(Entry);

            List<OpcodeData.ParamEntry> ExpandList = GetExpandList(Entry.Params[Pos]);

            // Create a new entry for each param
            for (int x = 0; x < ExpandList.Count; x++)
            {
                if (ExpandList[x].Param == OpcodeData.ParameterID.None)
                    continue;

                LocalOpcodeEntry NewEntry = CloneParams(Entry, ExpandList[x], Pos);

                if (Entry.Params[Pos].Encoding >= OpcodeData.EncodingType.Pos1 && Entry.Params[Pos].Encoding <= OpcodeData.EncodingType.Pos4)
                    NewEntry.Encoding += (byte)(GetValue(ExpandList[x].Param) << ShiftMap[(int)Entry.Params[Pos].Encoding]);               

                if (CanExpand(NewEntry))
                {
                    Ret.AddRange(ExpandOpcodeEntry(NewEntry));
                }
                else
                {
                    Ret.Add(NewEntry);
                }
            }

            return Ret;
        }

        public static int Order(LocalOpcodeEntry Entry)
        {
            return (!Entry.Prefered ? 0x100000 : 0) + (Entry.Index ? 0x10000 : 0) + (Entry.Prefix << 8) + Entry.Encoding;
        }

        public static byte Length(LocalOpcodeEntry Entry)
        {
            // For the base
            byte Ret = 1;

            // Prefix
            if (Entry.Prefix != 0x00)
                Ret++;

            // Index Prefix
            if (Entry.Index)
                Ret++;

            // Offset
            if (HasType(Entry, OpcodeData.ParameterType.WordIndexRegisterPointer))
                Ret++;

            if (HasParam(Entry, OpcodeData.ParameterID.ImmediateByte))
                Ret++;

            if (HasParam(Entry, OpcodeData.ParameterID.ImmediateWord))
                Ret += 2;

            return Ret;
        }
        
        public static bool HasType(LocalOpcodeEntry Opcode, OpcodeData.ParameterType Type)
        {
            foreach (OpcodeData.ParamEntry Entry in Opcode.Params)
            {
                if (Entry.Type == Type)
                    return true;
            }

            return false;
        }

        public static bool HasParam(LocalOpcodeEntry Opcode, OpcodeData.ParameterID ID)
        {
            foreach (OpcodeData.ParamEntry Entry in Opcode.Params)
            {
                if (Entry.Param == ID)
                    return true;
            }

            return false;
        }

        public static bool HasImplicit(LocalOpcodeEntry Opcode)
        {
            foreach (OpcodeData.ParamEntry Entry in Opcode.Params)
            {
                if (Entry.Implicit && (Entry.Type == OpcodeData.ParameterType.ByteRegister || Entry.Type == OpcodeData.ParameterType.WordRegister))
                    return true;
            }

            return false;
        }
        
        public static OpcodeGroup ReadOpcodeData(z80OpcodesPlatform Platform)
        {
            OpcodeGroup Ret = new OpcodeGroup();
            bool i8080 = false;

            if (Platform.name == "i8080")
                i8080 = true;


            foreach (opcodeType Opcode in Platform.opcode)
            {
                LocalOpcodeEntry NewDataEntry = new LocalOpcodeEntry();

                NewDataEntry.Encoding = (Opcode.value != null) ? (Opcode.value[0]) : (byte)0;
                NewDataEntry.Prefix = (Opcode.prefix != null) ? (Opcode.prefix[0]) : (byte)0;
                NewDataEntry.Index = Opcode.index;
                NewDataEntry.Name = (OpcodeData.CommandID) Enum.Parse(typeof(OpcodeData.CommandID), Opcode.mnemonic);
                NewDataEntry.Function = (OpcodeData.FunctionID)Enum.Parse(typeof(OpcodeData.FunctionID), Opcode.function.Replace('-', '_').ToUpper());
                NewDataEntry.Cycles = Opcode.cycles;
                NewDataEntry.Prefered = Opcode.prefered;
                NewDataEntry.i8080 = i8080;

                if (Opcode.official == "Y")
                    NewDataEntry.Type = OpcodeData.OpcodeType.Official;

                else if (Opcode.official == "X")
                    NewDataEntry.Type = OpcodeData.OpcodeType.Undocumented;

                else if (Opcode.official == "N")
                    NewDataEntry.Type = OpcodeData.OpcodeType.Unofficial;

                if (Opcode.args != null)
                {
                    List<OpcodeData.ParamEntry> ArgList = new List<OpcodeData.ParamEntry>();

                    foreach (argType Arg in Opcode.args)
                    {
                        ArgList.Add(GetParamInfo(Arg));
                    }

                    NewDataEntry.Params = ArgList.ToArray();
                }
                else
                {
                    NewDataEntry.Params = new OpcodeData.ParamEntry[0];
                }

                NewDataEntry.Length = Length(NewDataEntry);

                Ret.OpcodeList.Add(NewDataEntry);
            }

            foreach (LocalOpcodeEntry Entry in Ret.OpcodeList)
            {
                List<LocalOpcodeEntry> Indexed = ExpandOpcodeEntry(Entry);

                if (Entry.Index)
                {
                    foreach (LocalOpcodeEntry NewEntry in Indexed)
                    {
                        // Can't have HL and XX in the same opcode
                        if(HasParam(NewEntry, OpcodeData.ParameterID.WordReg_HL) & HasParam(NewEntry, OpcodeData.ParameterID.WordReg_XX))
                            continue;

                        Ret.OpcodeMatrix.Add(NewEntry);
                    }
                }
                else
                {
                    Ret.OpcodeMatrix.AddRange(Indexed);
                }
            }

            Ret.OpcodeMatrix = Ret.OpcodeMatrix.DistinctBy(e => Order(e)).OrderBy(e => Order(e)).ToList();

            return Ret;
        }
    }
}
