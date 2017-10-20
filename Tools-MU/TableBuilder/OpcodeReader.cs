using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TableBuilder
{
    enum ParameterType
    {
        Unknown,

        // B, C, D, E, H, L, M, A, R, I, 
        ByteRegister,

        // BC, DE, HL, SP, AF, SP
        WordRegister,
        WordRegisterAF,

        // IXL, IXH, IYL, IYH
        ByteIndexRegister,

        // IX, IY
        WordIndexRegister,

        // SP + *
        ByteOffset,

        // ($FF00 + c), ($FF00 + *), (C), (*) 
        ByteOffsetPointer,

        // (**)
        AddressPointer,

        // (BC), (DE), (HL), (SP), (HLI), (HLD)
        AddressRegister,

        // (IX) (IY)
        AddressIndexRegister,

        // C, NC, Z, NZ, E, O, M, P
        Flag,
        HalfFlag,

        // Immidate, Encoded
        Value,

        Error,
    }

    enum OpcodeType
    {
        Offical,
        Undocumented,
        Unoffical,
    }
    
    class ParamInfo
    {
        public ZASM.CommandID ID = ZASM.CommandID.None;
        public ParameterType Type = ParameterType.Unknown;
        public int Pos = 0;
        public bool Implicit = false;
        public bool Pointer = false;

        public bool CanExpand()
        {
            if (ID == ZASM.CommandID.RegisterAny || ID == ZASM.CommandID.FlagsAny || ID == ZASM.CommandID.EncodedByte)
                return true;

            return false;
        }

    }
    
    class OpcodeData
    {
        public int Prefix;
        public int Base;
        public ZASM.CommandID ID = ZASM.CommandID.None;
        public List<ParamInfo> Params = new List<ParamInfo>();
        public OpcodeType Type = OpcodeType.Unoffical;
        public string Function = "";
        public int CycleCount = 0;
        public int Length = 0;

        public bool HasIndex()
        {
            foreach (ParamInfo Entry in Params)
            {
                if (Entry.Type == ParameterType.AddressIndexRegister || Entry.Type == ParameterType.ByteIndexRegister || Entry.Type == ParameterType.WordIndexRegister)
                    return true;

                if (Entry.ID == ZASM.CommandID.IX || Entry.ID == ZASM.CommandID.IXH || Entry.ID == ZASM.CommandID.IXL ||
                    Entry.ID == ZASM.CommandID.IY || Entry.ID == ZASM.CommandID.IYH || Entry.ID == ZASM.CommandID.IYL)
                    return true;
            }

            return false;
        }

        public bool HasOffset()
        {
            foreach (ParamInfo Entry in Params)
            {
                if (!Entry.Pointer || Entry.Type != ParameterType.AddressIndexRegister)
                    continue;

                if (Entry.ID == ZASM.CommandID.IX || Entry.ID == ZASM.CommandID.IY || Entry.ID == ZASM.CommandID.RegisterAny)
                    return true;
            }

            return false;
        }

        
        public bool HasParam(ZASM.CommandID ID)
        {
            foreach (ParamInfo Entry in Params)
            {
                if (Entry.ID == ID)
                    return true;
            }

            return false;
        }

        public bool HasType(ParameterType Type)
        {
            foreach (ParamInfo Entry in Params)
            {
                if (Entry.Type == Type)
                    return true;
            }

            return false;
        }
        
        public bool CanExpand()
        {
            foreach (ParamInfo Entry in Params)
            {
                if (Entry.CanExpand())
                    return true;
            }

            return false;
        }

        public byte ExpandIndex()
        {
            for (byte x = 0; x < Params.Count; x++)
            {
                if (Params[x].CanExpand())
                    return x;
            }

            return 0xFF;
        }

        public OpcodeData CloneParams(ParamInfo NewParam, int NewPos)
        {
            OpcodeData Ret = (OpcodeData)this.MemberwiseClone();

            Ret.Params = new List<ParamInfo>(this.Params);

            Ret.Params[NewPos] = NewParam;

            return Ret;
        }
    };

    struct OpcodeGroup
    {
        public List<OpcodeData> OpcodeList;
        public List<OpcodeData> OpcodeMatrix;
    };
    
    class OpcodeReader
    {
        static ParamInfo GetParamInfo(string Value)
        {
            ParamInfo Ret = new ParamInfo();

            string Name = Value.ToUpper().Trim();
            if (Name.Length > 0 && Name[0] == '!')
            {
                Ret.Implicit = true;

                Name = Name.Substring(1);
            }

            switch (Name)
            {
                case "0":
                    Ret.ID = ZASM.CommandID.Encoded0;
                    Ret.Type = ParameterType.Value;
                    break;

                case "1":
                    Ret.ID = ZASM.CommandID.Encoded1;
                    Ret.Type = ParameterType.Value;
                    break;

                case "2":
                    Ret.ID = ZASM.CommandID.Encoded2;
                    Ret.Type = ParameterType.Value;
                    break;


                case "(BC)":
                    Ret.ID = ZASM.CommandID.BC;
                    Ret.Type = ParameterType.AddressRegister;
                    Ret.Pointer = true;
                    break;

                case "(DE)":
                    Ret.ID = ZASM.CommandID.DE;
                    Ret.Type = ParameterType.AddressRegister;
                    Ret.Pointer = true;
                    break;

                case "(SP)":
                    Ret.ID = ZASM.CommandID.SP;
                    Ret.Type = ParameterType.AddressRegister;
                    Ret.Pointer = true;
                    break;

                case "(HL)":
                    Ret.ID = ZASM.CommandID.HL;
                    Ret.Type = ParameterType.AddressRegister;
                    Ret.Pointer = true;
                    break;

                case "(HLI)":
                case "(HL+)":
                    Ret.ID = ZASM.CommandID.HLI;
                    Ret.Type = ParameterType.AddressRegister;
                    Ret.Pointer = true;
                    break;

                case "(HLD)":
                case "(HL-)":
                    Ret.ID = ZASM.CommandID.HLD;
                    Ret.Type = ParameterType.AddressRegister;
                    Ret.Pointer = true;
                    break;

                case "(C)":
                case "(+C)":
                    Ret.ID = ZASM.CommandID.C;
                    Ret.Type = ParameterType.ByteOffsetPointer;
                    Ret.Pointer = true;
                    break;

                case "(BYTE)":
                case "(+BYTE) | BYTEIMMIDATE":
                    Ret.ID = ZASM.CommandID.ImmediateByte;
                    Ret.Type = ParameterType.ByteOffsetPointer;
                    Ret.Pointer = true;
                    break;

                case "+SP":
                case "SP + BYTE | BYTEIMMIDATE":
                    Ret.ID = ZASM.CommandID.ImmediateByte;
                    Ret.Type = ParameterType.ByteOffset;
                    break;

                case "A":
                    Ret.ID = ZASM.CommandID.A;
                    Ret.Type = ParameterType.ByteRegister;
                    break;

                case "C":
                    Ret.ID = ZASM.CommandID.C;
                    Ret.Type = ParameterType.ByteRegister;
                    break;

                case "M":
                    Ret.ID = ZASM.CommandID.M;
                    Ret.Type = ParameterType.ByteRegister;
                    break;

                case "I":
                    Ret.ID = ZASM.CommandID.I;
                    Ret.Type = ParameterType.ByteRegister;
                    break;

                case "R":
                    Ret.ID = ZASM.CommandID.R;
                    Ret.Type = ParameterType.ByteRegister;
                    break;

                case "PSW":
                    Ret.ID = ZASM.CommandID.PSW;
                    Ret.Type = ParameterType.WordRegisterAF;
                    break;

                case "AF":
                    Ret.ID = ZASM.CommandID.AF;
                    Ret.Type = ParameterType.WordRegister;
                    break;

                case "AF'":
                    Ret.ID = ZASM.CommandID.AF_Alt;
                    Ret.Type = ParameterType.WordRegister;
                    break;

                case "BC":
                    Ret.ID = ZASM.CommandID.BC;
                    Ret.Type = ParameterType.WordRegister;
                    break;

                case "DE":
                    Ret.ID = ZASM.CommandID.DE;
                    Ret.Type = ParameterType.WordRegister;
                    break;

                case "HL":
                    Ret.ID = ZASM.CommandID.HL;
                    Ret.Type = ParameterType.WordRegister;
                    break;

                case "SP":
                    Ret.ID = ZASM.CommandID.SP;
                    Ret.Type = ParameterType.WordRegister;
                    break;


                case "FLAG-NZ":
                    Ret.ID = ZASM.CommandID.Flag_NZ;
                    Ret.Type = ParameterType.Flag;
                    break;

                case "FLAG-Z":
                    Ret.ID = ZASM.CommandID.Flag_Z;
                    Ret.Type = ParameterType.Flag;
                    break;

                case "FLAG-NC":
                    Ret.ID = ZASM.CommandID.Flag_NC;
                    Ret.Type = ParameterType.Flag;
                    break;

                case "FLAG-C":
                case "FLAG-CY":
                    Ret.ID = ZASM.CommandID.Flag_C;
                    Ret.Type = ParameterType.Flag;
                    break;

                case "FLAG-PO":
                    Ret.ID = ZASM.CommandID.Flag_PO;
                    Ret.Type = ParameterType.Flag;
                    break;

                case "FLAG-PE":
                    Ret.ID = ZASM.CommandID.Flag_PE;
                    Ret.Type = ParameterType.Flag;
                    break;

                case "FLAG-P":
                    Ret.ID = ZASM.CommandID.Flag_P;
                    Ret.Type = ParameterType.Flag;
                    break;

                case "FLAG-M":
                    Ret.ID = ZASM.CommandID.Flag_M;
                    Ret.Type = ParameterType.Flag;
                    break;

                case "ADDRESSPTR | WORDIMMIDATE":
                    Ret.ID = ZASM.CommandID.ImmediateWord;
                    Ret.Type = ParameterType.AddressPointer;
                    Ret.Pointer = true;
                    break;

                case "ADDRESS | WORDIMMIDATE":
                    Ret.ID = ZASM.CommandID.ImmediateWord;
                    Ret.Type = ParameterType.Value;
                    break;

                case "BYTE | BYTEIMMIDATE":
                    Ret.ID = ZASM.CommandID.ImmediateByte;
                    Ret.Type = ParameterType.Value;
                    break;

                case "WORD | WORDIMMIDATE":
                    Ret.ID = ZASM.CommandID.ImmediateWord;
                    Ret.Type = ParameterType.Value;
                    break;

                case "DISP | BYTEIMMIDATE":
                    Ret.ID = ZASM.CommandID.ImmediateByte;
                    Ret.Type = ParameterType.Value;
                    break;



                case "BYTEREG | 1":
                    Ret.ID = ZASM.CommandID.RegisterAny;
                    Ret.Type = ParameterType.ByteRegister;
                    Ret.Pos = 1;
                    break;

                case "BYTEREG | 2":
                    Ret.ID = ZASM.CommandID.RegisterAny;
                    Ret.Type = ParameterType.ByteRegister;
                    Ret.Pos = 2;
                    break;

                case "WORDREG | 3":
                    Ret.ID = ZASM.CommandID.RegisterAny;
                    Ret.Type = ParameterType.WordRegister;
                    Ret.Pos = 3;
                    break;

                case "WORDREGF | 3":
                    Ret.ID = ZASM.CommandID.RegisterAny;
                    Ret.Type = ParameterType.WordRegisterAF;
                    Ret.Pos = 3;
                    break;

                case "ENCODED | 2":
                    Ret.ID = ZASM.CommandID.EncodedByte;
                    Ret.Type = ParameterType.Value;
                    Ret.Pos = 2;
                    break;

                case "FLAG | 2":
                    Ret.ID = ZASM.CommandID.FlagsAny;
                    Ret.Type = ParameterType.Flag;
                    Ret.Pos = 2;
                    break;

                case "HALFFLAG | 4":
                    Ret.ID = ZASM.CommandID.FlagsAny;
                    Ret.Type = ParameterType.HalfFlag;
                    Ret.Pos = 4;
                    break;

                case "HALFFLAG | 2":
                    Ret.ID = ZASM.CommandID.FlagsAny;
                    Ret.Type = ParameterType.HalfFlag;
                    Ret.Pos = 2;
                    break;

                case "BYTEINDEXREG | 1":
                    Ret.ID = ZASM.CommandID.RegisterAny;
                    Ret.Type = ParameterType.ByteIndexRegister;
                    Ret.Pos = 1;
                    break;

                case "BYTEINDEXREG | 2":
                    Ret.ID = ZASM.CommandID.RegisterAny;
                    Ret.Type = ParameterType.ByteIndexRegister;
                    Ret.Pos = 2;
                    break;

                case "IX/IY":
                    Ret.ID = ZASM.CommandID.RegisterAny;
                    Ret.Type = ParameterType.WordIndexRegister;
                    break;

                case "(IX/IY)":
                    Ret.ID = ZASM.CommandID.RegisterAny;
                    Ret.Type = ParameterType.AddressIndexRegister;
                    Ret.Pointer = true;
                    break;

                case "":                    
                    break;

                default:
                    Ret.ID = ZASM.CommandID.None;
                    Ret.Type = ParameterType.Unknown;                    
                    Console.WriteLine(Name);
                    break;
            }

            return Ret;
        }

        static int[] ShiftMap = new int[] { 0, 0, 3, 4, 3 };

        static ZASM.CommandID[] ByteRegister = { ZASM.CommandID.B, ZASM.CommandID.C, ZASM.CommandID.D, ZASM.CommandID.E, ZASM.CommandID.H, ZASM.CommandID.L, ZASM.CommandID.None, ZASM.CommandID.A };
        static ZASM.CommandID[] WordRegister = { ZASM.CommandID.BC, ZASM.CommandID.DE, ZASM.CommandID.HL, ZASM.CommandID.SP };
        static ZASM.CommandID[] WordRegisterAF = { ZASM.CommandID.BC, ZASM.CommandID.DE, ZASM.CommandID.HL, ZASM.CommandID.AF };
        
        static ZASM.CommandID[] ByteIndexRegister = { ZASM.CommandID.IYH, ZASM.CommandID.IXH, ZASM.CommandID.IXL, ZASM.CommandID.IYL };
        static ZASM.CommandID[] WordIndexRegister = { ZASM.CommandID.IX, ZASM.CommandID.IY };
        static ZASM.CommandID[] AddressIndexRegister = { ZASM.CommandID.IX, ZASM.CommandID.IY };

        static ZASM.CommandID[] Flags = { ZASM.CommandID.Flag_NZ, ZASM.CommandID.Flag_Z, ZASM.CommandID.Flag_NC, ZASM.CommandID.Flag_C, ZASM.CommandID.Flag_PO, ZASM.CommandID.Flag_PE, ZASM.CommandID.Flag_P, ZASM.CommandID.Flag_M };
        static ZASM.CommandID[] HalfFlags = { ZASM.CommandID.Flag_NZ, ZASM.CommandID.Flag_Z, ZASM.CommandID.Flag_NC, ZASM.CommandID.Flag_C };
        static ZASM.CommandID[] Encoded = { ZASM.CommandID.Encoded0, ZASM.CommandID.Encoded1, ZASM.CommandID.Encoded2, ZASM.CommandID.Encoded3, ZASM.CommandID.Encoded4, ZASM.CommandID.Encoded5, ZASM.CommandID.Encoded6, ZASM.CommandID.Encoded7 };

        static List<ParamInfo> GetExpandList(ParamInfo Param)
        {
            ZASM.CommandID[] ParamList = null;

            switch (Param.Type)
            {
                case ParameterType.ByteRegister:
                    ParamList = ByteRegister;
                    break;

                case ParameterType.ByteIndexRegister:
                    ParamList = ByteIndexRegister;
                    break;

                case ParameterType.WordRegister:
                    ParamList = WordRegister;
                    break;

                case ParameterType.WordIndexRegister:
                    ParamList = WordIndexRegister;
                    break;

                case ParameterType.WordRegisterAF:
                    ParamList = WordRegisterAF;
                    break;

                case ParameterType.AddressIndexRegister:
                    ParamList = AddressIndexRegister;
                    break;

                case ParameterType.Flag:
                    ParamList = Flags;
                    break;

                case ParameterType.HalfFlag:
                    ParamList = HalfFlags;
                    break;

                case ParameterType.Value:
                    if(Param.ID == ZASM.CommandID.EncodedByte)
                        ParamList = Encoded;
                    break;

                default:
                    ParamList = null;
                    break;

            }

            List<ParamInfo> Ret = new List<ParamInfo>();

            if (ParamList == null)
                return Ret;

            for (int x = 0; x < ParamList.Length; x++)
            {
                ParamInfo NewParam = new ParamInfo();

                NewParam.ID = ParamList[x];

                NewParam.Pos = Param.Pos;
                NewParam.Type = Param.Type;
                NewParam.Implicit = Param.Implicit;
                NewParam.Pointer = Param.Pointer;

                Ret.Add(NewParam);
            }


            return Ret;
        }

        static int GetValue(ZASM.CommandID Entry)
        {
            switch (Entry)
            {
                case ZASM.CommandID.Encoded0:
                case ZASM.CommandID.Flag_NZ:
                case ZASM.CommandID.BC:
                case ZASM.CommandID.B:
                    return 0;

                case ZASM.CommandID.Encoded1:
                case ZASM.CommandID.Flag_Z:
                case ZASM.CommandID.DE:
                case ZASM.CommandID.C:
                    return 1;

                case ZASM.CommandID.Encoded2:
                case ZASM.CommandID.Flag_NC:
                case ZASM.CommandID.HL:
                case ZASM.CommandID.IX:
                case ZASM.CommandID.IY:
                case ZASM.CommandID.D:
                    return 2;

                case ZASM.CommandID.Encoded3:
                case ZASM.CommandID.Flag_C:
                case ZASM.CommandID.AF:
                case ZASM.CommandID.SP:
                case ZASM.CommandID.PSW:
                case ZASM.CommandID.E:
                    return 3;

                case ZASM.CommandID.Encoded4:
                case ZASM.CommandID.Flag_PO:
                case ZASM.CommandID.H:
                case ZASM.CommandID.IXH:
                case ZASM.CommandID.IYH:
                    return 4;

                case ZASM.CommandID.Encoded5:
                case ZASM.CommandID.Flag_PE:
                case ZASM.CommandID.L:
                case ZASM.CommandID.IXL:
                case ZASM.CommandID.IYL:
                    return 5;

                case ZASM.CommandID.Encoded6:
                case ZASM.CommandID.Flag_P:
                case ZASM.CommandID.M:
                    return 6;

                case ZASM.CommandID.Encoded7:
                case ZASM.CommandID.Flag_M:
                case ZASM.CommandID.A:
                    return 7;

                default:
                    return 0;
            }
        }

        static List<OpcodeData> ExpandOpcodeEntry(OpcodeData Entry)
        {
            List<OpcodeData> Ret = new List<OpcodeData>();

            if (!Entry.CanExpand())
            {
                Ret.Add(Entry);
                return Ret;
            }

            int Pos = Entry.ExpandIndex();

            List<ParamInfo> ExpandList = GetExpandList(Entry.Params[Pos]);

            // Create a new entry for each param
            for (int x = 0; x < ExpandList.Count; x++)
            {
                if (ExpandList[x].ID == ZASM.CommandID.None)
                    continue;

                OpcodeData NewEntry = Entry.CloneParams(ExpandList[x], Pos);

                if (ExpandList[x].Pos != 0)
                    NewEntry.Base += GetValue(ExpandList[x].ID) << ShiftMap[ExpandList[x].Pos];


                if (ExpandList[x].ID == ZASM.CommandID.IX || ExpandList[x].ID == ZASM.CommandID.IXL || ExpandList[x].ID == ZASM.CommandID.IXH)
                {
                    if (NewEntry.Prefix != 0xDD && NewEntry.Prefix != 0xFD)
                    {
                        if (NewEntry.Prefix != 0)
                            NewEntry.Prefix += 0xDD00;
                        else
                            NewEntry.Prefix = 0xDD;
                    }
                }
                else if (ExpandList[x].ID == ZASM.CommandID.IY || ExpandList[x].ID == ZASM.CommandID.IYL || ExpandList[x].ID == ZASM.CommandID.IYH)
                {
                    if (NewEntry.Prefix != 0xDD && NewEntry.Prefix != 0xFD)
                    {
                        if (NewEntry.Prefix != 0)
                            NewEntry.Prefix += 0xFD00;
                        else
                            NewEntry.Prefix = 0xFD;
                    }
                }


                if (NewEntry.CanExpand())
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

        public static OpcodeGroup ReadOpcodeData(string FileName)
        {
            const int Prefix = 0;
            const int Base = 1;
            const int Name = 2;
            const int Opcode1 = 3;
            const int Opcode2 = 4;
            const int Opcode3 = 5;
            const int Offical = 6;
            const int Function = 7;
            const int CycleCount = 8;
            //const int Size = 9;

            OpcodeGroup Ret = new OpcodeGroup();
            
            string[] Data = File.ReadAllLines(FileName);

            Ret.OpcodeList = new List<OpcodeData>();

            for (int x = 1; x < Data.Length; x++)
            {
                OpcodeData NewEntry = new OpcodeData();
                                
                string[] Fields = Data[x].Split(',');

                Enum.TryParse<ZASM.CommandID>(Fields[Name], out NewEntry.ID);

                if (Fields[Prefix].Length != 0)
                    NewEntry.Prefix = Convert.ToUInt16(Fields[Prefix], 16);
                else
                    NewEntry.Prefix = 0;

                if (NewEntry.Prefix == 0xFD)
                    NewEntry.Prefix = 0;

                if (NewEntry.Prefix == 0xFDCB)
                    NewEntry.Prefix = 0xCB;

                NewEntry.Base = (byte)Convert.ToUInt16(Fields[Base], 16);

                if (Fields[Opcode1] != "")
                    NewEntry.Params.Add(GetParamInfo(Fields[Opcode1]));

                if (Fields[Opcode2] != "")
                    NewEntry.Params.Add(GetParamInfo(Fields[Opcode2]));
                
                if (Fields[Opcode3] != "")
                    NewEntry.Params.Add(GetParamInfo(Fields[Opcode3]));


                if (Fields[Offical] == "Y")
                    NewEntry.Type = OpcodeType.Offical;

                else if (Fields[Offical] == "X")
                    NewEntry.Type = OpcodeType.Undocumented;

                else if (Fields[Offical] == "N")
                    NewEntry.Type = OpcodeType.Unoffical;

                NewEntry.Function = Fields[Function].ToUpper();
                if (Fields[CycleCount].Length != 0)
                    NewEntry.CycleCount = (byte)Convert.ToUInt16(Fields[CycleCount], 10);
                else
                    NewEntry.CycleCount = 0;

                NewEntry.Length = 1;
                if (NewEntry.Prefix != 0)
                    NewEntry.Length++;
                
                if(NewEntry.HasParam(ZASM.CommandID.ImmediateWord))
                    NewEntry.Length += 2;

                if (NewEntry.HasParam(ZASM.CommandID.ImmediateByte))
                    NewEntry.Length += 1;

                if (NewEntry.HasIndex())
                {
                    NewEntry.Length++;

                    if(NewEntry.HasOffset())
                        NewEntry.Length++;
                }

                Ret.OpcodeList.Add(NewEntry);
            }

            Ret.OpcodeMatrix = new List<OpcodeData>();

            foreach (OpcodeData Entry in Ret.OpcodeList)
            {
                List<OpcodeData> Indexed = ExpandOpcodeEntry(Entry);

                if (Entry.HasIndex())
                {
                    foreach (OpcodeData NewEntry in Indexed)
                    {
                        // Can't have both index types in one opcode
                        if ((NewEntry.HasParam(ZASM.CommandID.IX) || NewEntry.HasParam(ZASM.CommandID.IXH) || NewEntry.HasParam(ZASM.CommandID.IXL)) &&
                            (NewEntry.HasParam(ZASM.CommandID.IY) || NewEntry.HasParam(ZASM.CommandID.IYH) || NewEntry.HasParam(ZASM.CommandID.IYL)))
                            continue;

                        // Can't have HL and IX/IY in the same opcode
                        if ((NewEntry.HasParam(ZASM.CommandID.HL)) && (NewEntry.HasParam(ZASM.CommandID.IX) || NewEntry.HasParam(ZASM.CommandID.IY)))
                            continue;

                        Ret.OpcodeMatrix.Add(NewEntry);
                    }
                }
                else
                {
                    Ret.OpcodeMatrix.AddRange(Indexed);
                }
            }

            Ret.OpcodeMatrix = Ret.OpcodeMatrix.OrderBy(e => (e.Prefix << 8) + e.Base).ToList();

            //var dups = Ret.OpcodeMatrix.GroupBy(e => (e.Prefix << 8) + e.Base).Where(e => e.Count() > 1).ToDictionary(e=>e.Key, e2=>e2.ToList() );

            return Ret;
        }
    }
}
