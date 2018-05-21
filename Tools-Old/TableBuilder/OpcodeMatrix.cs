using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableBuilder
{
    public class OpcodeMatrix
    {
        public enum ParamType
        {
            None,

            // Byte Registers
            B,             
            C,
            D,
            E,
            H,
            L,
            M,  // i8080
            A,

            IXL,    // Z80
            IXH,    // Z80
            IYL,    // Z80
            IYH,    // Z80

            I,             
            R,             

            // Word Registers
            BC,            
            DE,            
            HL,            
            SP,            
            AF,     // Z80
            PSW,    // i8080

            IX,     // Z80
            IY,     // Z80
            
            // Flags
            Flag_NZ,
            Flag_Z,
            Flag_NC,
            Flag_C,
            Flag_PO,
            Flag_PE,
            Flag_P,
            Flag_M,
            
            // Immidates
            ByteData,       // *
            WordData,       // **
            Displacment,    // *
            Address,        // **

            // Pointers
            HL_Pointer,     // (HL) Z80
            IX_Pointer,     // (IX +) Z80
            IY_Pointer,     // (IY +) Z80
            BC_Pointer,     // (BC)
            DE_Pointer,     // (DE)
            SP_Pointer,     // (SP)

            HLInc_Pointer,  // (HL+) Gameboy
            HLDec_Pointer,  // (HL-) Gameboy
            High_Pointer,   // (+Word) Gameboy
            High_C_Pointer, // (+C) Gameboy
            SP_Offset,      // SP + Byte Gameboy

            Address_Pointer,    // (**)

            Zero = 0x100,   // 0
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,

            Expandable = 0x200,

            Byte_Pointer,       // (HL), (IX + *), (IY + *)
            Address_Registers,  // HL, IX, IY
            Index_Pointer,      // (IX+*), (IY+*)

            WordReg,        // BC, DE, HL, SP, IX, IY
            WordRegAF,      // BC, DE, HL, AF, IX, IY
            ByteReg,        // B, C, D, E, H, L, A
            ByteRegIndex,   // B, C, D, E, IXH, IYH, IXL, IYL, A
            Flags,          // NZ, Z, NC, CY, PO, PE, P, M
            HalfFlags,      // NZ, Z, NC, CY
            Encoded,        // 0-7
        }

        public enum ParamPos
        {
            None,
            Pos1,
            Pos2,
            Pos3,
            Pos4,
            ImmidateByte,
            ImmidateWord,
        }
        
        public struct ParamInformation
        {
            public ParamType Type;
            public ParamPos Pos;
            public bool Implicit;
        }

        public class OpcodeEntry
        {
            public string Opcode;
            public string Function;

            public byte Prefix;
            public byte Base;

            public List<ParamInformation> Params;

            public bool Offical;

            public bool IsIndexed()
            {
                foreach (ParamInformation Entry in Params)
                {
                    if (Entry.Type == ParamType.IX || Entry.Type == ParamType.IY ||
                        Entry.Type == ParamType.IX_Pointer || Entry.Type == ParamType.IY_Pointer ||
                        Entry.Type == ParamType.IXL || Entry.Type == ParamType.IXH ||
                        Entry.Type == ParamType.IYL || Entry.Type == ParamType.IYH)
                        return true;
                }

                return false;
            }
            
            public bool CanExpand()
            {
                foreach (ParamInformation Entry in Params)
                {
                    if (Entry.Type > ParamType.Expandable)
                        return true;
                }

                return false;
            }

            public byte ExpandIndex()
            {
                for(byte x = 0; x < Params.Count; x++)
                {
                    if (Params[x].Type > ParamType.Expandable)
                        return x;
                }

                return 0xFF;
            }

            public bool IsValid()
            {
                if (Params.Where(e => e.Type == OpcodeMatrix.ParamType.HL_Pointer).Count() != 0)
                {
                    if(Opcode.ToUpper() == "IN" || Opcode.ToUpper() == "OUT")
                        return false;

                    if (Params.Where(e => e.Type == OpcodeMatrix.ParamType.Index_Pointer).Count() != 0)
                        return false;
                }

                
                return true;
            }

            public bool HasType(ParamType Type)
            {
                foreach (ParamInformation Entry in Params)
                {
                    if (Entry.Type == Type)
                        return true;
                }

                return false;
            }

            public OpcodeEntry NewParam(ParamInformation Param, int Index)
            {
                OpcodeEntry Ret = (OpcodeEntry) this.MemberwiseClone();

                Ret.Params = new List<ParamInformation>(this.Params);

                Ret.Params[Index] = Param;

                return Ret;
            }
        };


        public List<OpcodeEntry> _OpcodeList = new List<OpcodeEntry>();
        public List<OpcodeEntry> _OpcodeMatrix = new List<OpcodeEntry>();

        OpcodeEntry BuildEntry(string EntryData)
        {
            const int Prefix = 0;
            const int Base = 1;
            const int Opcode = 2;
            const int Op1Type = 3;
            const int Op2Type = 4;
            const int Op3Type = 5;
            const int Offical = 6;
            const int Function = 7;
            //const int ByteIndex = 8;
            //const int Size = 9;

            OpcodeEntry NewEntry = new OpcodeEntry();
            NewEntry.Params = new List<ParamInformation>();

            string[] Fields = EntryData.Split(',');

            if (Fields[Prefix].Length != 0)
                NewEntry.Prefix = (byte)Convert.ToUInt16(Fields[Prefix], 16);
            else
                NewEntry.Prefix = 0;

            NewEntry.Base = (byte)Convert.ToUInt16(Fields[Base], 16);
            NewEntry.Opcode = Fields[Opcode].ToUpper();
            NewEntry.Function = Fields[Function];

            ParamInformation NewParam1 = ConvertParamInformation(Fields[Op1Type]);
            ParamInformation NewParam2 = ConvertParamInformation(Fields[Op2Type]);
            ParamInformation NewParam3 = ConvertParamInformation(Fields[Op3Type]);

            if(NewParam1.Type != ParamType.None)
                NewEntry.Params.Add(NewParam1);

            if (NewParam2.Type != ParamType.None)
                NewEntry.Params.Add(NewParam2);

            if (NewParam3.Type != ParamType.None)
                NewEntry.Params.Add(NewParam3);

            NewEntry.Offical = Fields[Offical] == "Y" || Fields[Offical] == "X";

            return NewEntry;
        }

        ParamInformation ConvertParamInformation(string Value)
        {
            ParamInformation Ret;
            Ret.Pos = ParamPos.None;
            Ret.Type = ParamType.None;
            Ret.Implicit = false;

            string Name = Value.ToUpper().Trim();
            if (Name.Length > 0 && Name[0] == '!')
            {
                Ret.Implicit = true;

                Name = Name.Substring(1);
            }

            switch (Name)
            {
                case "0":
                    Ret.Type = ParamType.Zero;
                    break;

                case "1":
                    Ret.Type = ParamType.One;
                    break;

                case "2":
                    Ret.Type = ParamType.Two;
                    break;


                case "(BC)":
                    Ret.Type = ParamType.BC_Pointer;
                    break;

                case "(DE)":
                    Ret.Type = ParamType.DE_Pointer;
                    break;

                case "(SP)":
                    Ret.Type = ParamType.SP_Pointer;
                    break;

                case "(HL)":
                    Ret.Type = ParamType.HL_Pointer;
                    break;

                case "(HL+)":
                    Ret.Type = ParamType.HLInc_Pointer;
                    break;

                case "(HL-)":
                    Ret.Type = ParamType.HLDec_Pointer;
                    break;

                case "(+C)":
                    Ret.Type = ParamType.High_C_Pointer;
                    break;

                case "(+WORD) | IMMIDATE":
                    Ret.Type = ParamType.High_Pointer;
                    Ret.Pos = ParamPos.ImmidateWord;
                    break;

                case "SP + BYTE | IMMIDATE":
                    Ret.Type = ParamType.SP_Offset;
                    Ret.Pos = ParamPos.ImmidateByte;
                    break;


                case "A":
                    Ret.Type = ParamType.A;
                    break;

                case "C":
                    Ret.Type = ParamType.C;
                    break;

                case "M":
                    Ret.Type = ParamType.M;
                    break;

                case "I":
                    Ret.Type = ParamType.I;
                    break;

                case "R":
                    Ret.Type = ParamType.R;
                    break;


                case "PSW":
                    Ret.Type = ParamType.PSW;
                    break;

                case "AF":
                case "AF'":
                    Ret.Type = ParamType.AF;
                    break;

                case "DE":
                    Ret.Type = ParamType.DE;
                    break;

                case "HL":
                    Ret.Type = ParamType.HL;
                    break;

                case "SP":
                    Ret.Type = ParamType.SP;
                    break;


                case "FLAG-NZ":
                    Ret.Type = ParamType.Flag_NZ;
                    break;

                case "FLAG-Z":
                    Ret.Type = ParamType.Flag_Z;
                    break;

                case "FLAG-NC":
                    Ret.Type = ParamType.Flag_NC;
                    break;

                case "FLAG-C":
                case "FLAG-CY":
                    Ret.Type = ParamType.Flag_C;
                    break;

                case "FLAG-PO":
                    Ret.Type = ParamType.Flag_PO;
                    break;

                case "FLAG-PE":
                    Ret.Type = ParamType.Flag_PE;
                    break;

                case "FLAG-P":
                    Ret.Type = ParamType.Flag_P;
                    break;

                case "FLAG-M":
                    Ret.Type = ParamType.Flag_M;
                    break;


                case "ADDRESSPTR | IMMIDATE":
                    Ret.Type = ParamType.Address_Pointer;
                    Ret.Pos = ParamPos.ImmidateWord;
                    break;

                case "ADDRESS | IMMIDATE":
                    Ret.Type = ParamType.Address;
                    Ret.Pos = ParamPos.ImmidateWord;
                    break;

                case "HL*":
                case "ADDRREG":
                    Ret.Type = ParamType.Address_Registers;
                    break;

                case "(HL*)":
                case "BYTEPTR":
                    Ret.Type = ParamType.Byte_Pointer;
                    break;

                case "(IX*)":
                case "INDEXPTR":
                    Ret.Type = ParamType.Index_Pointer;
                    break;

                case "BYTE | IMMIDATE":
                    Ret.Type = ParamType.ByteData;
                    Ret.Pos = ParamPos.ImmidateByte;
                    break;

                case "WORD | IMMIDATE":
                    Ret.Type = ParamType.WordData;
                    Ret.Pos = ParamPos.ImmidateWord;
                    break;

                case "DISP | IMMIDATE":
                    Ret.Type = ParamType.Displacment;
                    Ret.Pos = ParamPos.ImmidateByte;
                    break;



                case "BYTEREG* | 1":
                    Ret.Type = ParamType.ByteRegIndex;
                    Ret.Pos = ParamPos.Pos1;
                    break;

                case "BYTEREG | 1":
                    Ret.Type = ParamType.ByteReg;
                    Ret.Pos = ParamPos.Pos1;
                    break;

                case "BYTEREG* | 2":
                    Ret.Type = ParamType.ByteRegIndex;
                    Ret.Pos = ParamPos.Pos2;
                    break;

                case "BYTEREG | 2":
                    Ret.Type = ParamType.ByteReg;
                    Ret.Pos = ParamPos.Pos2;
                    break;

                case "ENCODED | 2":
                    Ret.Type = ParamType.Encoded;
                    Ret.Pos = ParamPos.Pos2;
                    break;


                case "FLAG | 2":
                    Ret.Type = ParamType.Flags;
                    Ret.Pos = ParamPos.Pos2;
                    break;

                case "HALFFLAG | 4":
                    Ret.Type = ParamType.HalfFlags;
                    Ret.Pos = ParamPos.Pos4;
                    break;


                case "WORDREG | 3":
                    Ret.Type = ParamType.WordReg;
                    Ret.Pos = ParamPos.Pos3;
                    break;

                case "WORDREGF | 3":
                    Ret.Type = ParamType.WordRegAF;
                    Ret.Pos = ParamPos.Pos3;
                    break;
                

                case "":
                    Ret.Type = ParamType.None;
                    break;

                default:
                    Ret.Type = ParamType.None;
                    break;
            }

            return Ret;
        }

        public void ProcessData(string[] Data)
        {
            bool Skip = true;
            foreach (string Line in Data)
            {
                if (!Skip)
                {
                    if (Line.Length != 0)
                    {
                        OpcodeEntry NewEntry = BuildEntry(Line);

                        _OpcodeList.Add(NewEntry);
                    }
                }

                Skip = false;
            }
            
            foreach (OpcodeEntry Entry in _OpcodeList)
            {
                if (Entry.CanExpand())
                {
                    _OpcodeMatrix.AddRange(ExpandOpcodeEntry(Entry));
                }
                else
                {
                    // Nothing to do if it can't expand.
                    _OpcodeMatrix.Add(Entry);
                }
            }            
            _OpcodeMatrix = _OpcodeMatrix.OrderBy(e => (e.Prefix << 8) + e.Base).ToList();
        }

        static ParamType[] AddrRegs = new ParamType[] { ParamType.HL, ParamType.IX, ParamType.IY };
        static ParamType[] BytePtrs = new ParamType[] { ParamType.HL_Pointer, ParamType.IX_Pointer, ParamType.IY_Pointer };
        static ParamType[] IndexPtrs = new ParamType[] { ParamType.IX_Pointer, ParamType.IY_Pointer };
        static ParamType[] WordRegisters = new ParamType[] { ParamType.BC, ParamType.DE, ParamType.HL, ParamType.SP };
        static ParamType[] ByteRegisters = new ParamType[] { ParamType.B, ParamType.C, ParamType.D, ParamType.E, ParamType.H, ParamType.L, ParamType.None, ParamType.A };
        static ParamType[] ByteIndexRegisters = new ParamType[] { ParamType.B, ParamType.C, ParamType.D, ParamType.E, ParamType.H, ParamType.IXH, ParamType.IYH, ParamType.L, ParamType.IXL, ParamType.IYL, ParamType.None, ParamType.A };
        static ParamType[] Flags = new ParamType[] { ParamType.Flag_NZ, ParamType.Flag_Z, ParamType.Flag_NC, ParamType.Flag_C, ParamType.Flag_PO, ParamType.Flag_PE, ParamType.Flag_P, ParamType.Flag_M };
        static ParamType[] Encoded = new ParamType[] { ParamType.Zero, ParamType.Zero + 1, ParamType.Zero + 2, ParamType.Zero + 3, ParamType.Zero + 4, ParamType.Zero + 5, ParamType.Zero + 6, ParamType.Zero + 7 };
        static ParamType[] Reset = new ParamType[] { ParamType.Zero, ParamType.Zero + 0x08, ParamType.Zero + 0x10, ParamType.Zero + 0x18, ParamType.Zero + 0x20, ParamType.Zero + 0x28, ParamType.Zero + 0x30, ParamType.Zero + 0x38 };

        static int[] ShiftMap = new int[] { 0, 0, 3, 4, 3, 0 };

        byte LookupValue(ParamType Type)
        {
            if (Type >= ParamType.Zero)
            {
                return (byte)((int)Type - (int)ParamType.Zero);
            }
            
            switch (Type)
            {
                case ParamType.B:
                    return 0;
                case ParamType.C:
                    return 1;
                case ParamType.D:
                    return 2;
                case ParamType.E:
                    return 3;
                case ParamType.H:
                case ParamType.IXH:
                case ParamType.IYH:
                    return 4;
                case ParamType.L:
                case ParamType.IXL:
                case ParamType.IYL:
                    return 5;
                case ParamType.A:
                    return 7;

                case ParamType.BC:
                    return 0;
                case ParamType.DE:
                    return 1;
                case ParamType.HL:
                case ParamType.HL_Pointer:
                case ParamType.IX:
                case ParamType.IX_Pointer:
                case ParamType.IY:
                case ParamType.IY_Pointer:
                    return 2;
                case ParamType.AF:
                case ParamType.PSW:
                case ParamType.SP:
                    return 3;
                
                case ParamType.Flag_NZ:
                    return 0;
                case ParamType.Flag_Z:
                    return 1;
                case ParamType.Flag_NC:
                    return 2;
                case ParamType.Flag_C:
                    return 3;
                case ParamType.Flag_PO:
                    return 4;
                case ParamType.Flag_PE:
                    return 5;
                case ParamType.Flag_P:
                    return 6;
                case ParamType.Flag_M:
                    return 7;

                default:
                    return 0;
            }
        }

        List<OpcodeEntry> ExpandOpcodeEntry(OpcodeEntry Entry)
        {
            List<OpcodeEntry> Ret = new List<OpcodeEntry>();

            if (!Entry.CanExpand())
            {
                Ret.Add(Entry);
                return Ret;
            }

            // Find the Parma to expand,
            int Index = Entry.ExpandIndex();

            // Get the expanded Param list
            List<ParamInformation> Params = ExpandParam(Entry.Opcode, Entry.Params[Index]);

            // Create new opcode entries for each new param            
            for(int x = 0; x < Params.Count; x++)
            {
                if (Params[x].Type == ParamType.None)
                    continue;

                byte Value = 0;
                
                if(Entry.Params[Index].Type != ParamType.Address_Registers)
                    Value = LookupValue(Params[x].Type);

                OpcodeEntry NewEntry = Entry.NewParam(Params[x], Index);
                NewEntry.Base += (byte)(Value << ShiftMap[(int)Params[x].Pos]);

                if (NewEntry.CanExpand())
                {
                    Ret.AddRange(ExpandOpcodeEntry(NewEntry));
                }
                else
                {
                    if (NewEntry.IsValid())
                        Ret.Add(NewEntry);
                }

                //if (Entry.Params[Index].Type == ParamType.ByteRegIndex)
                //{
                //    if (Params[Value].Type == ParamType.H)
                //    {
                //        NewEntry.Type = ParamType.IXH;
                //        Ret.Add(NewEntry);
                //        NewEntry.Type = ParamType.IYH;
                //        Ret.Add(NewEntry);
                //    }
                //    else if (Params[Value].Type == ParamType.L)
                //    {
                //        NewEntry.Type = ParamType.IXL;
                //        Ret.Add(NewEntry);
                //        NewEntry.Type = ParamType.IYL;
                //        Ret.Add(NewEntry);
                //    }
                //}

            }

            return Ret;
        }

        List<ParamInformation> ExpandParam(string Opcode, ParamInformation ParamEntry)
        {
            List<ParamInformation> Ret = new List<ParamInformation>();

            ParamType[] RegList = null;
            if (ParamEntry.Type == ParamType.WordReg || ParamEntry.Type == ParamType.WordRegAF)
                RegList = WordRegisters;

            else if (ParamEntry.Type == ParamType.ByteReg)
                RegList = ByteRegisters;

            else if (ParamEntry.Type == ParamType.ByteRegIndex)
                RegList = ByteIndexRegisters;

            else if (ParamEntry.Type == ParamType.Flags || ParamEntry.Type == ParamType.HalfFlags)
                RegList = Flags;

            else if (ParamEntry.Type == ParamType.Address_Registers)
                RegList = AddrRegs;

            else if (ParamEntry.Type == ParamType.Index_Pointer)
                RegList = IndexPtrs;

            else if (ParamEntry.Type == ParamType.Byte_Pointer)
                RegList = BytePtrs;

            else if (ParamEntry.Type == ParamType.Encoded)
            {
                if(Opcode.ToUpper() == "RST")
                    RegList = Reset;
                else
                    RegList = Encoded;
            }

            else
                return Ret;

            foreach (ParamType Entry in RegList)
            {
                ParamInformation NewEntry;

                if (ParamEntry.Type == ParamType.WordRegAF && Entry == ParamType.SP)
                    NewEntry.Type = ParamType.AF;
                else
                    NewEntry.Type = Entry;

                NewEntry.Pos = ParamEntry.Pos;
                NewEntry.Implicit = ParamEntry.Implicit;
                
                Ret.Add(NewEntry);

                if (ParamEntry.Type == ParamType.HalfFlags && Ret.Count == 4)
                    break;

            }

            return Ret;
        }
    }
}
