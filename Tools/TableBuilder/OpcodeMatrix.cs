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
            A,             
            B,             
            C,
            D,
            E,
            L,
            H,
            I,             
            R,             

            // Word Registers
            BC,            
            DE,            
            HL,            
            SP,            
            AF,
            AddrReg,    // HL, IX, IY
            
            // Flags
            NZ,
            Z,
            NC,
            CY,
            PO,
            PE,
            P,
            M,
            
            // Immidates
            ByteImmidate,   // *
            WordImmidate,   // **
            Displacment,    // *
            Address,        // **

            // Pointers
            HL_Pointer,     // (HL)
            BC_Pointer,     // (BC)
            DE_Pointer,     // (DE)
            SP_Pointer,     // (SP)
            AddressPtr,     // (**)
            IndexPtr,       // (IX+*), (IY+*)
            BytePtr,        // (HL), (IX + *), (IY + *)

            Zero = 0x100,   // 0
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,

            Expandable = 0x200, 

            WordReg,        // BC, DE, HL, SP, IX, IY
            WordRegAF,      // BC, DE, HL, AF, IX, IY
            ByteReg,        // B, C, D, E, H, L, IXH, IYH, IXL, IYL
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
            Immidate,
        }
        
        public struct ParamInformation
        {
            public ParamType Type;
            public ParamPos Pos;
        }

        public class OpcodeEntry
        {
            public string Opcode;

            public byte Prefix;
            public byte Base;

            public List<ParamInformation> Params;

            public bool Offical;
            public bool NoIndexPrefix;
            public bool IndexByteReg;
            public byte DataSize;

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
                    
                    if (Params.Where(e => e.Type == OpcodeMatrix.ParamType.IndexPtr).Count() != 0)
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
            const int NoIndex = 7;
            const int ByteIndex = 8;
            const int DataSize = 9;

            OpcodeEntry NewEntry = new OpcodeEntry();
            NewEntry.Params = new List<ParamInformation>();

            string[] Fields = EntryData.Split(',');

            if (Fields[Prefix].Length != 0)
                NewEntry.Prefix = (byte)Convert.ToUInt16(Fields[Prefix], 16);
            else
                NewEntry.Prefix = 0;

            NewEntry.Base = (byte)Convert.ToUInt16(Fields[Base], 16);
            NewEntry.Opcode = Fields[Opcode].ToUpper();

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
            NewEntry.NoIndexPrefix = Fields[NoIndex] == "Y";
            NewEntry.IndexByteReg = Fields[ByteIndex] == "Y";

            if(Fields[DataSize].ToUpper() == "BYTE")
                NewEntry.DataSize = 8;

            if (Fields[DataSize].ToUpper() == "WORD")
                NewEntry.DataSize = 8;

            else
                NewEntry.DataSize = 0;

            return NewEntry;
        }

        ParamInformation ConvertParamInformation(string Value)
        {
            ParamInformation Ret;
            Ret.Pos = ParamPos.None;

            switch (Value.ToUpper().Trim())
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

                case "A":
                    Ret.Type = ParamType.A;
                    break;

                case "AF":
                case "AF'":
                    Ret.Type = ParamType.AF;
                    break;

                case "C":
                    Ret.Type = ParamType.C;
                    break;

                case "DE":
                    Ret.Type = ParamType.DE;
                    break;

                case "HL":
                    Ret.Type = ParamType.HL;
                    break;

                case "I":
                    Ret.Type = ParamType.I;
                    break;

                case "R":
                    Ret.Type = ParamType.R;
                    break;

                case "SP":
                    Ret.Type = ParamType.SP;
                    break;

                case "ADDRESSPTR | IMMIDATE":
                    Ret.Type = ParamType.AddressPtr;
                    Ret.Pos = ParamPos.Immidate;
                    break;

                case "ADDRESS | IMMIDATE":
                    Ret.Type = ParamType.Address;
                    Ret.Pos = ParamPos.Immidate;
                    break;

                case "ADDRREG":
                    Ret.Type = ParamType.AddrReg;
                    break;

                case "BYTE | IMMIDATE":
                    Ret.Type = ParamType.ByteImmidate;
                    Ret.Pos = ParamPos.Immidate;
                    break;

                case "BYTEPTR":
                    Ret.Type = ParamType.BytePtr;
                    break;

                case "BYTEREG | 1":
                    Ret.Type = ParamType.ByteReg;
                    Ret.Pos = ParamPos.Pos1;
                    break;

                case "BYTEREG | 2":
                    Ret.Type = ParamType.ByteReg;
                    Ret.Pos = ParamPos.Pos2;
                    break;

                case "DISP | IMMIDATE":
                    Ret.Type = ParamType.Displacment;
                    Ret.Pos = ParamPos.Immidate;
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

                case "INDEXPTR":
                    Ret.Type = ParamType.IndexPtr;
                    break;

                case "WORD | IMMIDATE":
                    Ret.Type = ParamType.WordImmidate;
                    Ret.Pos = ParamPos.Immidate;
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
                    OpcodeEntry NewEntry = BuildEntry(Line);

                    _OpcodeList.Add(NewEntry);
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

        static ParamType[] AddrRegs = new ParamType[] { ParamType.HL };
        static ParamType[] BytePtrs = new ParamType[] { ParamType.HL_Pointer };
        static ParamType[] WordRegisters = new ParamType[] { ParamType.BC, ParamType.DE, ParamType.HL, ParamType.SP };
        static ParamType[] ByteRegisters = new ParamType[] { ParamType.B, ParamType.C, ParamType.D, ParamType.E, ParamType.H, ParamType.L, ParamType.None, ParamType.A };
        static ParamType[] Flags = new ParamType[] { ParamType.NZ, ParamType.Z, ParamType.NC, ParamType.CY, ParamType.PO, ParamType.PE, ParamType.P, ParamType.M };
        static ParamType[] Encoded = new ParamType[] { ParamType.Zero, ParamType.Zero + 1, ParamType.Zero + 2, ParamType.Zero + 3, ParamType.Zero + 4, ParamType.Zero + 5, ParamType.Zero + 6, ParamType.Zero + 7 };
        static ParamType[] Reset = new ParamType[] { ParamType.Zero, ParamType.Zero + 0x08, ParamType.Zero + 0x10, ParamType.Zero + 0x18, ParamType.Zero + 0x20, ParamType.Zero + 0x28, ParamType.Zero + 0x30, ParamType.Zero + 0x38 };

        static int[] ShiftMap = new int[] { 0, 0, 3, 4, 3, 0 };
        
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
            for(byte Value = 0; Value < Params.Count; Value++)
            {
                OpcodeEntry NewEntry = Entry.NewParam(Params[Value], Index);
                NewEntry.Base += (byte)(Value << ShiftMap[(int)Params[Value].Pos]);

                if (NewEntry.CanExpand())
                {
                    Ret.AddRange(ExpandOpcodeEntry(NewEntry));
                }
                else
                {
                    if (NewEntry.IsValid())
                        Ret.Add(NewEntry);
                }
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

            else if (ParamEntry.Type == ParamType.Flags || ParamEntry.Type == ParamType.HalfFlags)
                RegList = Flags;

            else if (ParamEntry.Type == ParamType.AddrReg)
                RegList = AddrRegs;

            else if (ParamEntry.Type == ParamType.BytePtr)
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
                
                Ret.Add(NewEntry);

                if (ParamEntry.Type == ParamType.HalfFlags && Ret.Count == 4)
                    break;
            }

            return Ret;
        }
    }
}
