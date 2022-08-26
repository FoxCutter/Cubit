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

    public class LocalOpcodeEntry
    {
        public bool Index;
        public byte Prefix;
        public byte Encoding;
        public OpcodeData.ArgumentList Arguments;
        public Opcodes.statusEnum Status;

        public int Cycles;
        public short TStates;

        public int Conditonal_Cycles;
        public short Conditonal_TStates;

        public int Index_Cycles;
        public short Index_TStates;

        public byte Length;

        public bool Prefered;
        public string Platform;

        public string Menmontic;
        public string FunctionName;

        public bool i8080;

        public LocalOpcodeEntry() : base()
        {
            Prefered = true;
            Platform = "";
            Menmontic = "";
            FunctionName = "";
            Cycles = 0;
            Conditonal_Cycles = 0;
            i8080 = false;
        }

        public LocalOpcodeEntry(LocalOpcodeEntry Clone)
        {
            Index = Clone.Index;
            Prefix = Clone.Prefix;
            Encoding = Clone.Encoding;
            Arguments = new OpcodeData.ArgumentList(Clone.Arguments);
            Status = Clone.Status;
            TStates = Clone.TStates;
            Conditonal_TStates = Clone.Conditonal_TStates;
            Index_TStates = Clone.Index_TStates;
            Length = Clone.Length;

            Prefered = Clone.Prefered;
            Platform = Clone.Platform;
            Menmontic = Clone.Menmontic;
            FunctionName = Clone.FunctionName;
            Cycles = Clone.Cycles;
            Conditonal_Cycles = Clone.Conditonal_Cycles;
            Index_Cycles = Clone.Index_Cycles;


            i8080 = Clone.i8080;
        }

        public int Opcode
        {
            get
            {
                int Ret = this.Encoding << 4;
                Ret += this.Prefix << 12;
                if (Index)
                    Ret += 0x100000;

                if (!Prefered)
                    Ret += 0x1;

                return Ret;
            }
        }
    }

    class OpcodeReader
    {
        static System.Text.RegularExpressions.Regex ParceCycles = new System.Text.RegularExpressions.Regex(@"(\d+)\((\d*)\)");

        public static LocalOpcodeEntry ReadOpcode(Opcodes.opcodeType Opcode, Opcodes.opcodeEncoding Encoding)
        {
            LocalOpcodeEntry Entry = new LocalOpcodeEntry();

            if (Encoding.Platform.Contains("i80"))
                Entry.i8080 = true;

            Entry.Index = Opcode.Index;
            Entry.Encoding = Opcode.Value[0];
            if (Opcode.Prefix != null)
                Entry.Prefix = Opcode.Prefix[0];

            Entry.Length = (byte)Opcode.Length;
            Entry.FunctionName = Opcode.Function.Replace('-', '_').ToUpper();

            Entry.Prefered = Encoding.Preferred;
            Entry.Platform = Encoding.Platform;

            if (Encoding.Mnemonic.Equals("[None]", StringComparison.CurrentCultureIgnoreCase))
                Entry.Menmontic = "";
            else
                Entry.Menmontic = Encoding.Mnemonic.ToUpper();

            if (string.IsNullOrEmpty(Encoding.Cycles) || Encoding.Cycles == "0")
            {
                Entry.Cycles = 0;
                Entry.TStates = 0;
            }
            else
            {
                var Cycles = ParceCycles.Matches(Encoding.Cycles);
                Entry.Cycles = short.Parse(Cycles[0].Groups[1].Value);
                Entry.TStates = short.Parse(Cycles[0].Groups[2].Value);

                if(Cycles.Count > 1)
                {
                    Entry.Conditonal_Cycles = short.Parse(Cycles[1].Groups[1].Value);
                    Entry.Conditonal_TStates = short.Parse(Cycles[1].Groups[2].Value);

                }
            }

            Entry.Index_Cycles = 0;
            Entry.Index_TStates = 0;

            Entry.Status = Encoding.Status;

            Entry.Arguments = new OpcodeData.ArgumentList();

            if (Encoding.Arguments != null)
            {
                foreach (Opcodes.argType Arg in Encoding.Arguments)
                {
                    Entry.Arguments.Add(GetParamInfo(Arg));
                }
            }

            return Entry;
        }


        static OpcodeData.ParamEntry GetParamInfo(Opcodes.argType Arg)
        {
            OpcodeData.ParamEntry Ret = new OpcodeData.ParamEntry();

            Ret.Implicit = Arg.hidden;
            Ret.Expanded = false;

            switch (Arg.Value)
            {
                case Opcodes.argTypeEnum.RstValue:
                    Ret.Param = OpcodeData.ParameterID.EncodedValue;
                    Ret.Type = OpcodeData.ParameterType.RstValue;
                    break;

                case Opcodes.argTypeEnum.Value:
                    Ret.Param = OpcodeData.ParameterID.EncodedValue;
                    Ret.Type = OpcodeData.ParameterType.Value;
                    break;

                case Opcodes.argTypeEnum.Value0:
                    Ret.Param = OpcodeData.ParameterID.Value0;
                    Ret.Type = OpcodeData.ParameterType.Value;
                    break;

                case Opcodes.argTypeEnum.Value1:
                    Ret.Param = OpcodeData.ParameterID.Value1;
                    Ret.Type = OpcodeData.ParameterType.Value;
                    break;

                case Opcodes.argTypeEnum.Value2:
                    Ret.Param = OpcodeData.ParameterID.Value2;
                    Ret.Type = OpcodeData.ParameterType.Value;
                    break;

                case Opcodes.argTypeEnum.Value8:
                    Ret.Param = OpcodeData.ParameterID.Value8;
                    Ret.Type = OpcodeData.ParameterType.Value;
                    break;

                case Opcodes.argTypeEnum.FlagNZ:
                    Ret.Param = OpcodeData.ParameterID.Flag_NZ;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case Opcodes.argTypeEnum.FlagZ:
                    Ret.Param = OpcodeData.ParameterID.Flag_Z;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case Opcodes.argTypeEnum.FlagNC:
                    Ret.Param = OpcodeData.ParameterID.Flag_NC;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case Opcodes.argTypeEnum.FlagCY:
                    Ret.Param = OpcodeData.ParameterID.Flag_CY;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case Opcodes.argTypeEnum.FlagPO:
                    Ret.Param = OpcodeData.ParameterID.Flag_PO;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case Opcodes.argTypeEnum.FlagPE:
                    Ret.Param = OpcodeData.ParameterID.Flag_PE;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case Opcodes.argTypeEnum.FlagP:
                    Ret.Param = OpcodeData.ParameterID.Flag_P;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case Opcodes.argTypeEnum.FlagM:
                    Ret.Param = OpcodeData.ParameterID.Flag_M;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case Opcodes.argTypeEnum.FlagNK:
                    Ret.Param = OpcodeData.ParameterID.Flag_NK;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case Opcodes.argTypeEnum.FlagK:
                    Ret.Param = OpcodeData.ParameterID.Flag_K;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case Opcodes.argTypeEnum.AddressPtr:
                    Ret.Param = OpcodeData.ParameterID.ImmediateWord;
                    Ret.Type = OpcodeData.ParameterType.AddressPointer;
                    break;

                case Opcodes.argTypeEnum.Address:
                    Ret.Param = OpcodeData.ParameterID.ImmediateWord;
                    Ret.Type = OpcodeData.ParameterType.Address;
                    break;

                case Opcodes.argTypeEnum.Byte:
                    Ret.Param = OpcodeData.ParameterID.ImmediateByte;
                    Ret.Type = OpcodeData.ParameterType.Value;
                    break;

                case Opcodes.argTypeEnum.Word:
                    Ret.Param = OpcodeData.ParameterID.ImmediateWord;
                    Ret.Type = OpcodeData.ParameterType.Value;
                    break;

                case Opcodes.argTypeEnum.Displacment:
                    Ret.Param = OpcodeData.ParameterID.ImmediateByte;
                    Ret.Type = OpcodeData.ParameterType.Displacment;
                    break;

                case Opcodes.argTypeEnum.ByteReg:
                    Ret.Param = OpcodeData.ParameterID.RegisterAny;
                    Ret.Type = OpcodeData.ParameterType.ByteRegister;
                    break;

                case Opcodes.argTypeEnum.WordReg:
                    Ret.Param = OpcodeData.ParameterID.RegisterAny;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case Opcodes.argTypeEnum.ByteRegIzb:
                    Ret.Param = OpcodeData.ParameterID.ByteReg_Izb;
                    Ret.Type = OpcodeData.ParameterType.ByteIndexRegister;
                    break;

                case Opcodes.argTypeEnum.WordRegIz:
                    Ret.Param = OpcodeData.ParameterID.WordReg_Iz;
                    Ret.Type = OpcodeData.ParameterType.WordIndexRegister;
                    break;

                case Opcodes.argTypeEnum.WordRegPtrIz:
                    Ret.Param = OpcodeData.ParameterID.WordReg_Iz;
                    Ret.Type = OpcodeData.ParameterType.WordIndexRegisterPointer;
                    break;

                case Opcodes.argTypeEnum.Flag:
                    Ret.Param = OpcodeData.ParameterID.FlagsAny;
                    Ret.Type = OpcodeData.ParameterType.Flag;
                    break;

                case Opcodes.argTypeEnum.HalfFlag:
                    Ret.Param = OpcodeData.ParameterID.FlagsAny;
                    Ret.Type = OpcodeData.ParameterType.HalfFlag;
                    break;

                case Opcodes.argTypeEnum.ByteRegA:
                    Ret.Param = OpcodeData.ParameterID.ByteReg_A;
                    Ret.Type = OpcodeData.ParameterType.ByteRegister;
                    break;

                case Opcodes.argTypeEnum.ByteRegC:
                    Ret.Param = OpcodeData.ParameterID.ByteReg_C;
                    Ret.Type = OpcodeData.ParameterType.ByteRegister;
                    break;

                case Opcodes.argTypeEnum.ByteRegM:
                    Ret.Param = OpcodeData.ParameterID.ByteReg_M;
                    Ret.Type = OpcodeData.ParameterType.ByteRegister;
                    break;

                case Opcodes.argTypeEnum.ByteRegI:
                    Ret.Param = OpcodeData.ParameterID.ByteReg_I;
                    Ret.Type = OpcodeData.ParameterType.ByteRegister;
                    break;

                case Opcodes.argTypeEnum.ByteRegR:
                    Ret.Param = OpcodeData.ParameterID.ByteReg_R;
                    Ret.Type = OpcodeData.ParameterType.ByteRegister;
                    break;

                case Opcodes.argTypeEnum.WordRegAF:
                    Ret.Param = OpcodeData.ParameterID.WordReg_AF;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case Opcodes.argTypeEnum.WordRegPSW:
                    Ret.Param = OpcodeData.ParameterID.WordReg_PSW;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case Opcodes.argTypeEnum.WordRegAFAlt:
                    Ret.Param = OpcodeData.ParameterID.WordReg_AF_Alt;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case Opcodes.argTypeEnum.WordRegBC:
                    Ret.Param = OpcodeData.ParameterID.WordReg_BC;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case Opcodes.argTypeEnum.WordRegDE:
                    Ret.Param = OpcodeData.ParameterID.WordReg_DE;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case Opcodes.argTypeEnum.WordRegHL:
                    Ret.Param = OpcodeData.ParameterID.WordReg_HL;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case Opcodes.argTypeEnum.WordRegSP:
                    Ret.Param = OpcodeData.ParameterID.WordReg_SP;
                    Ret.Type = OpcodeData.ParameterType.WordRegister;
                    break;

                case Opcodes.argTypeEnum.WordRegPtrBC:
                    Ret.Param = OpcodeData.ParameterID.WordReg_BC;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                case Opcodes.argTypeEnum.WordRegPtrDE:
                    Ret.Param = OpcodeData.ParameterID.WordReg_DE;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                case Opcodes.argTypeEnum.WordRegPtrBD:
                    Ret.Param = OpcodeData.ParameterID.WordReg_BD;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                case Opcodes.argTypeEnum.WordRegPtrSP:
                    Ret.Param = OpcodeData.ParameterID.WordReg_SP;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                case Opcodes.argTypeEnum.WordRegPtrHL:
                    Ret.Param = OpcodeData.ParameterID.WordReg_HL;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                // HLI
                case Opcodes.argTypeEnum.WordRegPtrHLI:
                    Ret.Param = OpcodeData.ParameterID.WordReg_HLI;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                // HLD
                case Opcodes.argTypeEnum.WordRegPtrHLD:
                    Ret.Param = OpcodeData.ParameterID.WordReg_HLD;
                    Ret.Type = OpcodeData.ParameterType.WordRegisterPointer;
                    break;

                // ($FF00 + C)
                case Opcodes.argTypeEnum.HighMemPtrC:
                    Ret.Param = OpcodeData.ParameterID.ByteReg_C;
                    Ret.Type = OpcodeData.ParameterType.HighMemPointerPlus;
                    break;

                // ($FF00 + n)
                case Opcodes.argTypeEnum.HighMemPtrByte:
                    Ret.Param = OpcodeData.ParameterID.ImmediateByte;
                    Ret.Type = OpcodeData.ParameterType.HighMemPointerPlus;
                    break;

                // (n)
                case Opcodes.argTypeEnum.BytePtr:
                    Ret.Param = OpcodeData.ParameterID.ImmediateByte;
                    Ret.Type = OpcodeData.ParameterType.BytePointer;
                    break;

                // (C)
                case Opcodes.argTypeEnum.ByteRegPtrC:
                    Ret.Param = OpcodeData.ParameterID.ByteReg_C;
                    Ret.Type = OpcodeData.ParameterType.BytePointer;
                    break;


                case Opcodes.argTypeEnum.WordRegSPByte:
                    Ret.Param = OpcodeData.ParameterID.ImmediateByte;
                    Ret.Type = OpcodeData.ParameterType.SPPlusOffset;
                    break;

                default:
                    Console.WriteLine(Arg.Value);
                    break;
            }

            switch (Arg.encoding)
            {
                case Opcodes.encodingEnum.Implicit:
                case Opcodes.encodingEnum.None:
                    Ret.Encoding = OpcodeData.EncodingType.None;
                    break;

                case Opcodes.encodingEnum.Source:
                    Ret.Encoding = OpcodeData.EncodingType.Source;
                    break;

                case Opcodes.encodingEnum.Flag:
                case Opcodes.encodingEnum.Dest:
                    Ret.Encoding = OpcodeData.EncodingType.Dest;
                    break;

                case Opcodes.encodingEnum.WordReg:
                    Ret.Encoding = OpcodeData.EncodingType.WordReg;
                    break;

                case Opcodes.encodingEnum.HalfFlag:
                    Ret.Encoding = OpcodeData.EncodingType.HalfFlag;
                    break;

                case Opcodes.encodingEnum.ByteImmidate:
                    Ret.Encoding = OpcodeData.EncodingType.ByteImmidate;
                    break;

                case Opcodes.encodingEnum.WordImmidate:
                    Ret.Encoding = OpcodeData.EncodingType.WordImmidate;
                    break;

                case Opcodes.encodingEnum.IndexOffset:
                    Ret.Encoding = OpcodeData.EncodingType.IndexOffset;
                    break;

                default:
                    Console.WriteLine(Arg.encoding);
                    break;
            }

            return Ret;
        }

        static int[] ShiftMap = new int[] { 0, 0, 3, 3, 4, 3 };

        static OpcodeData.ParameterID[] ByteRegister = { OpcodeData.ParameterID.ByteReg_B, OpcodeData.ParameterID.ByteReg_C, OpcodeData.ParameterID.ByteReg_D, OpcodeData.ParameterID.ByteReg_E, OpcodeData.ParameterID.ByteReg_H, OpcodeData.ParameterID.ByteReg_L, OpcodeData.ParameterID.None, OpcodeData.ParameterID.ByteReg_A };
        static OpcodeData.ParameterID[] WordRegister = { OpcodeData.ParameterID.WordReg_BC, OpcodeData.ParameterID.WordReg_DE, OpcodeData.ParameterID.WordReg_HL, OpcodeData.ParameterID.WordReg_SP };
        static OpcodeData.ParameterID[] WordRegisterBD = { OpcodeData.ParameterID.WordReg_BC, OpcodeData.ParameterID.WordReg_DE };

        //static OpcodeData.ParameterID[] ByteIndexRegister = { OpcodeData.ParameterID.ByteReg_IYH, OpcodeData.ParameterID.ByteReg_IXH, OpcodeData.ParameterID.ByteReg_IXL, OpcodeData.ParameterID.ByteReg_IYL };
        //static OpcodeData.ParameterID[] WordIndexRegister = { OpcodeData.ParameterID.WordReg_IX, OpcodeData.ParameterID.WordReg_IY };
        //static OpcodeData.ParameterID[] WordIndexRegisterPointer = { OpcodeData.ParameterID.WordReg_IX, OpcodeData.ParameterID.WordReg_IY };

        static OpcodeData.ParameterID[] ByteIndexRegister = { OpcodeData.ParameterID.ByteReg_IzH, OpcodeData.ParameterID.ByteReg_IzL };
        static OpcodeData.ParameterID[] WordIndexRegister = { OpcodeData.ParameterID.WordReg_Iz };
        static OpcodeData.ParameterID[] WordIndexRegisterPointer = { OpcodeData.ParameterID.WordReg_Iz };

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

                case OpcodeData.ParameterType.WordRegisterPointer:
                    if (Param.Param == OpcodeData.ParameterID.WordReg_BD)
                        ParamList = WordRegisterBD;
                    else
                        ParamList = WordRegister;
                    break;

                case OpcodeData.ParameterType.WordRegister:
                    if (Param.Param == OpcodeData.ParameterID.WordReg_BD)
                        ParamList = WordRegisterBD;
                    else
                        ParamList = WordRegister;
                    break;

                case OpcodeData.ParameterType.WordIndexRegister:
                    ParamList = WordIndexRegister;
                    break;

                case OpcodeData.ParameterType.WordIndexRegisterPointer:
                    ParamList = WordIndexRegisterPointer;
                    break;

                case OpcodeData.ParameterType.Flag:
                    ParamList = Flags;
                    break;

                case OpcodeData.ParameterType.HalfFlag:
                    ParamList = HalfFlags;
                    break;

                case OpcodeData.ParameterType.Value:
                case OpcodeData.ParameterType.RstValue:
                    if (Param.Param == OpcodeData.ParameterID.EncodedValue)
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
                NewParam.Expanded = true;

                NewParam.Type = Param.Type;
                NewParam.Implicit = Param.Implicit;
                if (Param.Encoding >= OpcodeData.EncodingType.Source && Param.Encoding <= OpcodeData.EncodingType.HalfFlag)
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
                case OpcodeData.ParameterID.WordReg_Iz:
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
                case OpcodeData.ParameterID.ByteReg_IzH:
                    return 4;

                case OpcodeData.ParameterID.Value5:
                case OpcodeData.ParameterID.Flag_PE:
                case OpcodeData.ParameterID.ByteReg_L:
                case OpcodeData.ParameterID.ByteReg_IXL:
                case OpcodeData.ParameterID.ByteReg_IYL:
                case OpcodeData.ParameterID.ByteReg_IzL:
                    return 5;

                case OpcodeData.ParameterID.Value6:
                case OpcodeData.ParameterID.Flag_P:
                case OpcodeData.ParameterID.ByteReg_M:
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
            if (Entry.Param == OpcodeData.ParameterID.WordReg_BD || Entry.Param == OpcodeData.ParameterID.RegisterAny || Entry.Param == OpcodeData.ParameterID.FlagsAny || Entry.Param == OpcodeData.ParameterID.EncodedValue || Entry.Param == OpcodeData.ParameterID.ByteReg_Izb)
                return true;
            return false;
        }

        public static bool CanExpand(LocalOpcodeEntry Opcode)
        {
            foreach (OpcodeData.ParamEntry Entry in Opcode.Arguments)
            {
                if (CanExpand(Entry))
                    return true;
            }

            return false;
        }

        public static byte ExpandIndex(LocalOpcodeEntry Opcode)
        {
            for (byte x = 0; x < Opcode.Arguments.Count; x++)
            {
                if (CanExpand(Opcode.Arguments[x]))
                    return x;
            }

            return 0xFF;
        }

        static LocalOpcodeEntry CloneParams(LocalOpcodeEntry Opcode, OpcodeData.ParamEntry NewParam, int NewPos)
        {
            LocalOpcodeEntry Ret = new LocalOpcodeEntry(Opcode);

            Ret.Arguments[NewPos] = NewParam;

            return Ret;
        }


        public static List<LocalOpcodeEntry> ExpandOpcodeEntry(LocalOpcodeEntry Entry)
        {
            List<LocalOpcodeEntry> Ret = new List<LocalOpcodeEntry>();

            if (!CanExpand(Entry))
            {
                Ret.Add(Entry);
                return Ret;
            }

            int Pos = ExpandIndex(Entry);

            List<OpcodeData.ParamEntry> ExpandList = GetExpandList(Entry.Arguments[Pos]);

            // Create a new entry for each param
            for (int x = 0; x < ExpandList.Count; x++)
            {
                if (x == 3 && (Entry.Menmontic == "PUSH"|| Entry.Menmontic == "POP"))
                    break;

                if (ExpandList[x].Param == OpcodeData.ParameterID.None)
                    continue;

                LocalOpcodeEntry NewEntry = CloneParams(Entry, ExpandList[x], Pos);

                if (Entry.Arguments[Pos].Encoding >= OpcodeData.EncodingType.Source && Entry.Arguments[Pos].Encoding <= OpcodeData.EncodingType.HalfFlag)
                    NewEntry.Encoding += (byte)(GetValue(ExpandList[x].Param) << ShiftMap[(int)Entry.Arguments[Pos].Encoding]);

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
            int Ret = 0;

            if (Entry.Index)
                Ret += 0x100000;

            Ret += Entry.Prefix << 12;
            Ret += Entry.Encoding << 4;

            if (!Entry.Prefered)
                Ret += 1;

            return Ret;
        }
        public static bool HasType(LocalOpcodeEntry Opcode, OpcodeData.ParameterType Type)
        {
            foreach (OpcodeData.ParamEntry Entry in Opcode.Arguments)
            {
                if (Entry.Type == Type)
                    return true;
            }

            return false;
        }

        public static bool HasParam(LocalOpcodeEntry Opcode, OpcodeData.ParameterID ID)
        {
            foreach (OpcodeData.ParamEntry Entry in Opcode.Arguments)
            {
                if (Entry.Param == ID)
                    return true;
            }

            return false;
        }
    }
}
