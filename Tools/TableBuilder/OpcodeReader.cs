﻿using System;
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

    class OpcodeGroup
    {
        public List<OpcodeData.OpcodeEntry> OpcodeList;
        public List<OpcodeData.OpcodeEntry> OpcodeMatrix;

        public OpcodeGroup()
        {
            OpcodeList = new List<OpcodeData.OpcodeEntry>();
            OpcodeMatrix = new List<OpcodeData.OpcodeEntry>();
        }
    };
    
    class OpcodeReader
    {
        static OpcodeData.ParamEntry GetParamInfo(argType Arg)
        {
            OpcodeData.ParamEntry Ret = new OpcodeData.ParamEntry();

            Ret.Implicit = Arg.assumed;

            switch (Arg.Value.ToUpper().Trim())
            {
                case "0":
                    Ret.Param = OpcodeData.ParameterID.Encoded0;
                    Ret.Type = OpcodeData.ParameterType.Value;
                    break;

                case "1":
                    Ret.Param = OpcodeData.ParameterID.Encoded1;
                    Ret.Type = OpcodeData.ParameterType.Value;
                    break;

                case "2":
                    Ret.Param = OpcodeData.ParameterID.Encoded2;
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
                    Ret.Param = OpcodeData.ParameterID.Flag_C;
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
                    Ret.Param = OpcodeData.ParameterID.XX;
                    Ret.Type = OpcodeData.ParameterType.WordIndexRegister;
                    break;

                case "WORDINDEXREGPTR":
                    Ret.Param = OpcodeData.ParameterID.XX;
                    Ret.Type = OpcodeData.ParameterType.WordIndexRegisterPointer;
                    break;

                case "ENCODED":
                    Ret.Param = OpcodeData.ParameterID.EncodedByte;
                    Ret.Type = OpcodeData.ParameterType.Value;
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
                    Ret.Param = OpcodeData.ParameterID.A;
                    Ret.Type = OpcodeData.ParameterType.ByteRegister;
                    break;

                case "BYTEREG-C":
                    Ret.Param = OpcodeData.ParameterID.C;
                    Ret.Type = OpcodeData.ParameterType.ByteRegister;
                    break;

                case "BYTEREG-I":
                    Ret.Param = OpcodeData.ParameterID.I;
                    Ret.Type = OpcodeData.ParameterType.ByteRegister;
                    break;

                case "BYTEREG-R":
                    Ret.Param = OpcodeData.ParameterID.R;
                    Ret.Type = OpcodeData.ParameterType.ByteRegister;
                    break;

                case "WORDREG-AF":
                    Ret.Param = OpcodeData.ParameterID.AF;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case "WORDREG-AFALT":
                    Ret.Param = OpcodeData.ParameterID.AF_Alt;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case "WORDREG-BC":
                    Ret.Param = OpcodeData.ParameterID.BC;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case "WORDREG-DE":
                    Ret.Param = OpcodeData.ParameterID.DE;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case "WORDREG-HL":
                    Ret.Param = OpcodeData.ParameterID.HL;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case "WORDREG-SP":
                    Ret.Param = OpcodeData.ParameterID.SP;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case "WORDREGPTR-BC":
                    Ret.Param = OpcodeData.ParameterID.BC;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                case "WORDREGPTR-DE":
                    Ret.Param = OpcodeData.ParameterID.DE;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                case "WORDREGPTR-SP":
                    Ret.Param = OpcodeData.ParameterID.SP;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                case "WORDREGPTR-HL":
                    Ret.Param = OpcodeData.ParameterID.HL;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                // HLI
                case "WORDREGPTR-HLI":
                    Ret.Param = OpcodeData.ParameterID.HLI;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                // HLD
                case "WORDREGPTR-HLD":
                    Ret.Param = OpcodeData.ParameterID.HLD;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                // ($FF00 + C)
                case "HIGHMEMPTR+C":
                    Ret.Param = OpcodeData.ParameterID.C;
                    Ret.Type = OpcodeData.ParameterType.HighMemPointerPlus;
                    break;

                // ($FF00 + n)
                case "HIGHMEMPTR+BYTE":
                    Ret.Param = OpcodeData.ParameterID.ImmediateByte;
                    Ret.Type = OpcodeData.ParameterType.HighMemPointerPlus;
                    break;

                // (n)
                case "HIGHMEMPTR":
                    Ret.Param = OpcodeData.ParameterID.ImmediateByte;
                    Ret.Type = OpcodeData.ParameterType.HighMemPointer;
                    break;

                // (C)
                case "HIGHMEMBYTEPTR-C":
                    Ret.Param = OpcodeData.ParameterID.C;
                    Ret.Type = OpcodeData.ParameterType.HighMemPointer;
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
                case EncodingEnum.None:
                    Ret.Encoding = OpcodeData.EncodingType.None;
                    break;

                case EncodingEnum.Item1:
                    Ret.Encoding = OpcodeData.EncodingType.Pos1;
                    break;

                case EncodingEnum.Item2:
                    Ret.Encoding = OpcodeData.EncodingType.Pos2;
                    break;

                case EncodingEnum.Item3:
                    Ret.Encoding = OpcodeData.EncodingType.Pos3;
                    break;

                case EncodingEnum.Item4:
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

        static OpcodeData.ParameterID[] ByteRegister = { OpcodeData.ParameterID.B, OpcodeData.ParameterID.C, OpcodeData.ParameterID.D, OpcodeData.ParameterID.E, OpcodeData.ParameterID.H, OpcodeData.ParameterID.L, OpcodeData.ParameterID.None, OpcodeData.ParameterID.A };
        static OpcodeData.ParameterID[] WordRegister = { OpcodeData.ParameterID.BC, OpcodeData.ParameterID.DE, OpcodeData.ParameterID.HL, OpcodeData.ParameterID.SP };
        static OpcodeData.ParameterID[] WordRegisterAF = { OpcodeData.ParameterID.BC, OpcodeData.ParameterID.DE, OpcodeData.ParameterID.HL, OpcodeData.ParameterID.AF };

        //static OpcodeData.ParameterID[] ByteIndexRegister = { OpcodeData.ParameterID.IYH, OpcodeData.ParameterID.IXH, OpcodeData.ParameterID.IXL, OpcodeData.ParameterID.IYL };
        //static OpcodeData.ParameterID[] WordIndexRegister = { OpcodeData.ParameterID.IX, OpcodeData.ParameterID.IY };
        //static OpcodeData.ParameterID[] AddressIndexRegister = { OpcodeData.ParameterID.IX, OpcodeData.ParameterID.IY };

        static OpcodeData.ParameterID[] ByteIndexRegister = { OpcodeData.ParameterID.XXH, OpcodeData.ParameterID.XXL, };
        static OpcodeData.ParameterID[] WordIndexRegister = { OpcodeData.ParameterID.XX };
        static OpcodeData.ParameterID[] AddressIndexRegister = { OpcodeData.ParameterID.XX };

        static OpcodeData.ParameterID[] Flags = { OpcodeData.ParameterID.Flag_NZ, OpcodeData.ParameterID.Flag_Z, OpcodeData.ParameterID.Flag_NC, OpcodeData.ParameterID.Flag_C, OpcodeData.ParameterID.Flag_PO, OpcodeData.ParameterID.Flag_PE, OpcodeData.ParameterID.Flag_P, OpcodeData.ParameterID.Flag_M };
        static OpcodeData.ParameterID[] HalfFlags = { OpcodeData.ParameterID.Flag_NZ, OpcodeData.ParameterID.Flag_Z, OpcodeData.ParameterID.Flag_NC, OpcodeData.ParameterID.Flag_C };
        static OpcodeData.ParameterID[] Encoded = { OpcodeData.ParameterID.Encoded0, OpcodeData.ParameterID.Encoded1, OpcodeData.ParameterID.Encoded2, OpcodeData.ParameterID.Encoded3, OpcodeData.ParameterID.Encoded4, OpcodeData.ParameterID.Encoded5, OpcodeData.ParameterID.Encoded6, OpcodeData.ParameterID.Encoded7 };

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
                    if(Param.Param == OpcodeData.ParameterID.EncodedByte)
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
                case OpcodeData.ParameterID.Encoded0:
                case OpcodeData.ParameterID.Flag_NZ:
                case OpcodeData.ParameterID.BC:
                case OpcodeData.ParameterID.B:
                    return 0;

                case OpcodeData.ParameterID.Encoded1:
                case OpcodeData.ParameterID.Flag_Z:
                case OpcodeData.ParameterID.DE:
                case OpcodeData.ParameterID.C:
                    return 1;

                case OpcodeData.ParameterID.Encoded2:
                case OpcodeData.ParameterID.Flag_NC:
                case OpcodeData.ParameterID.HL:
                case OpcodeData.ParameterID.IX:
                case OpcodeData.ParameterID.IY:
                case OpcodeData.ParameterID.XX:
                case OpcodeData.ParameterID.D:
                    return 2;

                case OpcodeData.ParameterID.Encoded3:
                case OpcodeData.ParameterID.Flag_C:
                case OpcodeData.ParameterID.AF:
                case OpcodeData.ParameterID.SP:
                case OpcodeData.ParameterID.E:
                    return 3;

                case OpcodeData.ParameterID.Encoded4:
                case OpcodeData.ParameterID.Flag_PO:
                case OpcodeData.ParameterID.H:
                case OpcodeData.ParameterID.IXH:
                case OpcodeData.ParameterID.IYH:
                case OpcodeData.ParameterID.XXH:
                    return 4;

                case OpcodeData.ParameterID.Encoded5:
                case OpcodeData.ParameterID.Flag_PE:
                case OpcodeData.ParameterID.L:
                case OpcodeData.ParameterID.IXL:
                case OpcodeData.ParameterID.IYL:
                case OpcodeData.ParameterID.XXL:
                    return 5;

                case OpcodeData.ParameterID.Encoded6:
                case OpcodeData.ParameterID.Flag_P:
                    return 6;

                case OpcodeData.ParameterID.Encoded7:
                case OpcodeData.ParameterID.Flag_M:
                case OpcodeData.ParameterID.A:
                    return 7;

                default:
                    return 0;
            }
        }

        public static bool CanExpand(OpcodeData.ParamEntry Entry)
        {
            if (Entry.Param == OpcodeData.ParameterID.RegisterAny || Entry.Param == OpcodeData.ParameterID.FlagsAny || Entry.Param == OpcodeData.ParameterID.EncodedByte)
                return true;

            return false;
        }
        
        public static bool CanExpand(OpcodeData.OpcodeEntry Opcode)
        {
            foreach (OpcodeData.ParamEntry Entry in Opcode.Params)
            {
                if (CanExpand(Entry))
                    return true;
            }

            return false;
        }

        public static byte ExpandIndex(OpcodeData.OpcodeEntry Opcode)
        {
            for (byte x = 0; x < Opcode.Params.Length; x++)
            {
                if (CanExpand(Opcode.Params[x]))
                    return x;
            }

            return 0xFF;
        }

        static OpcodeData.OpcodeEntry CloneParams(OpcodeData.OpcodeEntry Opcode, OpcodeData.ParamEntry NewParam, int NewPos)
        {
            OpcodeData.OpcodeEntry Ret = new OpcodeData.OpcodeEntry(Opcode);

            Ret.Params[NewPos] = NewParam;

            return Ret;
        }


        static List<OpcodeData.OpcodeEntry> ExpandOpcodeEntry(OpcodeData.OpcodeEntry Entry)
        {
            List<OpcodeData.OpcodeEntry> Ret = new List<OpcodeData.OpcodeEntry>();

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

                OpcodeData.OpcodeEntry NewEntry = CloneParams(Entry, ExpandList[x], Pos);

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

        public static int Order(OpcodeData.OpcodeEntry Entry)
        {
            return (Entry.Index ? 0x10000 : 0) + (Entry.Prefix << 8) + Entry.Encoding;
        }

        public static byte Length(OpcodeData.OpcodeEntry Entry)
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
        
        public static bool HasType(OpcodeData.OpcodeEntry Opcode, OpcodeData.ParameterType Type)
        {
            foreach (OpcodeData.ParamEntry Entry in Opcode.Params)
            {
                if (Entry.Type == Type)
                    return true;
            }

            return false;
        }

        public static bool HasParam(OpcodeData.OpcodeEntry Opcode, OpcodeData.ParameterID ID)
        {
            foreach (OpcodeData.ParamEntry Entry in Opcode.Params)
            {
                if (Entry.Param == ID)
                    return true;
            }

            return false;
        }

        public static bool HasImplicit(OpcodeData.OpcodeEntry Opcode)
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

            foreach (opcodeType Opcode in Platform.opcode)
            {
                OpcodeData.OpcodeEntry NewDataEntry = new OpcodeData.OpcodeEntry();

                NewDataEntry.Encoding = (Opcode.value != null) ? (Opcode.value[0]) : (byte)0;
                NewDataEntry.Prefix = (Opcode.prefix != null) ? (Opcode.prefix[0]) : (byte)0;
                NewDataEntry.Index = Opcode.index;
                NewDataEntry.Name = (OpcodeData.CommandID) Enum.Parse(typeof(OpcodeData.CommandID), Opcode.mnemonic);
                NewDataEntry.Function = (OpcodeData.FunctionID)Enum.Parse(typeof(OpcodeData.FunctionID), Opcode.function);
                NewDataEntry.Cycles = Opcode.cycles;

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

            foreach (OpcodeData.OpcodeEntry Entry in Ret.OpcodeList)
            {
                List<OpcodeData.OpcodeEntry> Indexed = ExpandOpcodeEntry(Entry);

                if (Entry.Index)
                {
                    foreach (OpcodeData.OpcodeEntry NewEntry in Indexed)
                    {
                        // Can't have HL and XX in the same opcode
                        if(HasParam(NewEntry, OpcodeData.ParameterID.HL) & HasParam(NewEntry, OpcodeData.ParameterID.XX))
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
