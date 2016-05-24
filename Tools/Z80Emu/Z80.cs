using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z80Emu
{
    #region Enums and Defines

    [Flags]
    enum Flag
    {
        Carry =         0x01,
        Subtract =      0x02,
        Parity =        0x04,
        Overflow =      0x04,
        Bit3 =          0x08,
        HalfCarry =     0x10,
        Bit5 =          0x20,
        Zero =          0x40,
        Sign =          0x80,

        NotCarry = Subtract | Parity | Overflow | HalfCarry | Zero | Sign,
        All = Carry | NotCarry,
    }

    enum Register : byte
    {
        // 8-bit Registers and Indexs into the register array
        A,
        F,
        B,
        C,
        D,
        E,
        H,      L,
        SPH,    SPL,
        PCH,    PCL,
        IXH,    IXL,
        IYH,    IYL,
        I,
        R,

        // Count of 8-bit registers
        RegisterCount,

        // 16-bit Registers
        Word = 0x20,
        AF = Word + A,
        BC = Word + B,
        DE = Word + D,
        HL = Word + H,
        SP = Word + SPH,
        PC = Word + PCH,
        IX = Word + IXH,
        IY = Word + IYH,

        // Index register (can be HL, IX, IY)
        HX = 0x40,

        // Index register low (can be L, IXL, IYL)
        XL,

        // Index register high (can be H, IXH, IYH)
        XH,
        
        // Index register with Displacment (assuming it's IX or IY)
        HD,     
        
        // Immediate data
        ImmediateByte = 0x80,
        ImmediateWord,

        // Not used
        None = 0xFF,
    };

    enum ConditionCode : byte
    {
        NZ,     // Non Zero     (Z = 0)
        Z,      // Zero         (Z = 1)
        NC,     // No Carry     (C = 0)
        CY,     // Carry        (C = 1)
        PO,     // Parity Odd   (P = 0)
        PE,     // Parity Even  (P = 1)
        P,      // Positive     (S = 0)
        M,      // Negative     (S = 1)
    }

    [Flags]
    enum RegParam : byte
    {
        None            = 0x00,     // No flags on this register
        Reference       = 0x01,     // Memory Reference (Memory, BC, DE, HL, SP, IX, IY, nn)
        WordData        = 0x02,     // The Referenced data is Word sized, not byte
        Literal         = 0x04,     // The byte value in the register is used as the input value
        ConditionCode   = 0x08,     // The Byte value in the register is the condition code to test for
    }

    enum Operation
    {
        ADC, ADD, AND, BIT, CALL, CCF, CP, CPD, CPDR, CPI, CPIR, CPL, DAA, DEC, DI, DJNZ,
        EI, EX, EXX, HALT, IM, IN, INC, IND, INDR, INI, INIR, JP, JR, LD, LDD, LDDR, LDI,
        LDIR, NEG, NOP, OR, OTDR, OTIR, OUT, OUTD, OUTI, POP, PUSH, RES, RET, RETI, RETN,
        RL, RLA, RLC, RLCA, RLD, RR, RRA, RRC, RRCA, RRD, RST, SBC, SCF, SET, SLA, SLL,
        SRA, SRL, SUB, XOR, Error
    }

    public enum RunMode
    {
        Normal,
        INT,
        NMI,
    };

    struct OpcodeData
    {
        public string       Name;

        public Register     Reg1;
        public RegParam     Reg1Param;

        public Register     Reg2;
        public RegParam     Reg2Param;

        public Operation    Function;
    };

    #endregion

    public class Z80
    {
        class OpcodeInformation
        {
            public ushort PC;              // Value of PC at the start of reading
            
            public byte Prefix;            // The Prefix byte (CB, ED) if it exists
            public byte Opcode;            // The opcode
            public OpcodeData Data;        // Object we are running no

            public Register Index;         // Index register to use if provided.
            public byte Displacment;       // Index Displacment

            public byte ByteImmediate;     // Byte length Immediate data
            public ushort WordImmediate;   // Word length Immediate data or Address
        }


        Memory SystemMemory = null;
        ExternalIO SystemIO = null;
        byte[] Registers = new byte[(int)Register.RegisterCount];
        byte[] AltRegisters = new byte[(int)Register.RegisterCount];
        bool IFF1, IFF2;
        bool Halted;
        bool SkipNextInt;
        byte IntMode;

        #region Data/Register Functions

        void Set16BitRegister(Register Reg, ushort Value)
        {
            int PureReg = (int)(Reg - Register.Word);
            Registers[PureReg] = (byte)((Value & 0xFF00) >> 8);
            Registers[PureReg + 1] = (byte)(Value & 0xFF);
        }

        ushort Get16BitRegister(Register Reg)
        {
            int PureReg = (int)(Reg - Register.Word);
            return (ushort)((Registers[PureReg] << 8) + Registers[PureReg + 1]);
        }

        void Set16BitAltRegister(Register Reg, ushort Value)
        {
            int PureReg = (int)(Reg - Register.Word);
            AltRegisters[PureReg] = (byte)((Value & 0xFF00) >> 8);
            AltRegisters[PureReg + 1] = (byte)(Value & 0xFF);
        }

        ushort Get16BitAltRegister(Register Reg)
        {
            int PureReg = (int)(Reg - Register.Word);
            return (ushort)((AltRegisters[PureReg] << 8) + AltRegisters[PureReg + 1]);
        }
        
        void Set8BitRegister(Register Reg, byte Value)
        {
            int PureReg = (int)Reg;
            Registers[PureReg] = (byte)(Value);
        }

        byte Get8BitRegister(Register Reg)
        {
            int PureReg = (int)Reg;
            return Registers[PureReg];
        }

        byte Read8BitMemory(ushort Address)
        {
            return SystemMemory[Address];
        }

        void Write8BitMemory(ushort Address, byte Value)
        {
            SystemMemory[Address] = Value;
        }

        ushort Read16BitMemory(ushort Address)
        {
            ushort Ret = SystemMemory[Address];
            Ret += (ushort) (SystemMemory[(ushort)(Address + 1)] << 8);

            return Ret;
        }

        void Write16BitMemory(ushort Address, ushort Value)
        {
            SystemMemory[Address] = (byte)(Value & 0x00FF);
            SystemMemory[(ushort)(Address + 1)] = (byte)((Value & 0xFF00) >> 8);
        }

        byte Read8BitPC()
        {
            byte Ret = SystemMemory[PC];
            PC++;

            return Ret;
        }

        ushort Read16BitPC()
        {
            ushort Ret = SystemMemory[PC];
            PC++;

            Ret += (ushort)(SystemMemory[PC] << 8);
            PC++;

            return Ret;
        }

        void SwapRegister(Register Reg)
        {
            ushort Value1 = Get16BitRegister(Reg);
            ushort Value2 = Get16BitAltRegister(Reg);

            Set16BitRegister(Reg, Value2);
            Set16BitAltRegister(Reg, Value1);
        }

        ushort DereferenceAddress(Register Reg, Register Index, byte Displacment)
        {
            ushort Address = 0;
            bool UseDisplacment = false;

            if (Reg == Register.HX || Reg == Register.HD)
            {
                if (Index != Register.None)
                {
                    if (Reg == Register.HD)
                        UseDisplacment = true;
                    
                    Reg = Index;
                }
                else
                {
                    Reg = Register.HL;
                }
            } 
            
            Address = Get16BitRegister(Reg);

            if (UseDisplacment)
                Address = (ushort)(Address + (sbyte)Displacment);

            return Address;
        }

        Register IndexRegister(Register Reg, Register Index)
        {
            if (Reg == Register.HX || Reg == Register.HD)
            {
                if (Index != Register.None)
                    Reg = Index;

                else
                    Reg = Register.HL;
            }
            else if (Reg == Register.XL)
            {
                if (Index != Register.None)
                    Reg = Index + 1;

                else
                    Reg = Register.L;
            }

            else if (Reg == Register.XH)
            {
                if (Index != Register.None)
                    Reg = Index;

                else
                    Reg = Register.H;
            }

            return Reg;
        } 

        
        ushort ReadData(OpcodeInformation Current, int ParamN = 1)
        {
            Register    RegN;
            RegParam    RegNParam;

            if (ParamN == 2)
            {
                RegN = Current.Data.Reg2;
                RegNParam = Current.Data.Reg2Param;
            }
            else
            {
                RegN = Current.Data.Reg1;
                RegNParam = Current.Data.Reg1Param;
            }

            if (RegNParam.HasFlag(RegParam.Reference))
            {
                ushort Address = 0;
                if (RegN == Register.ImmediateWord)
                    Address = Current.WordImmediate;
                else
                    Address = DereferenceAddress(RegN, Current.Index, Current.Displacment);

                if (RegNParam.HasFlag(RegParam.WordData))
                    return Read16BitMemory(Address);
                else
                    return Read8BitMemory(Address);
            }
            else if (RegNParam.HasFlag(RegParam.Literal) || RegNParam.HasFlag(RegParam.ConditionCode))
            {
                return (ushort)RegN;
            }
            else if (RegN == Register.ImmediateWord)
            {
                return Current.WordImmediate;
            }
            else if (RegN == Register.ImmediateByte)
            {
                return Current.ByteImmediate;
            }
            else
            {
                RegN = IndexRegister(RegN, Current.Index);

                if (RegNParam.HasFlag(RegParam.WordData))
                    return Get16BitRegister(RegN);
                else
                    return Get8BitRegister(RegN);
            }
        }

        void WriteData(OpcodeInformation Current, ushort Value, int ParamN = 1)
        {
            Register RegN;
            RegParam RegNParam;

            if (ParamN == 2)
            {
                RegN = Current.Data.Reg2;
                RegNParam = Current.Data.Reg2Param;
            }
            else
            {
                RegN = Current.Data.Reg1;
                RegNParam = Current.Data.Reg1Param;
            }

            if (RegNParam.HasFlag(RegParam.Reference))
            {
                ushort Address = 0;
                if (RegN == Register.ImmediateWord)
                    Address = Current.WordImmediate;
                else
                    Address = DereferenceAddress(RegN, Current.Index, Current.Displacment);

                if (RegNParam.HasFlag(RegParam.WordData))
                    Write16BitMemory(Address, Value);
                else
                    Write8BitMemory(Address, (byte)Value);
            }
            else
            {
                RegN = IndexRegister(RegN, Current.Index);

                if (RegNParam.HasFlag(RegParam.WordData))
                    Set16BitRegister(RegN, Value);
                else
                    Set8BitRegister(RegN, (byte)Value);
            }            
        }

        #endregion 

        #region Properties

        Flag Flags
        {
            get
            {
                return (Flag)Get8BitRegister(Register.F);
            }
            set
            {
                Set8BitRegister(Register.F, (byte)value);
            }
        }

        ushort PC
        {
            get
            {
                return Get16BitRegister(Register.PC);
            }
            set
            {
                Set16BitRegister(Register.PC, value);
            }
        }

        ushort SP
        {
            get
            {
                return Get16BitRegister(Register.SP);
            }
            set
            {
                Set16BitRegister(Register.SP, value);
            }
        }

        #endregion

        #region Printing/Debuging Functions

        void PrintParam(OpcodeInformation Current, int ParamN)
        {
            Register RegN;
            RegParam RegNParam;

            if (ParamN == 2)
            {
                RegN = Current.Data.Reg2;
                RegNParam = Current.Data.Reg2Param;
            }
            else
            {
                RegN = Current.Data.Reg1;
                RegNParam = Current.Data.Reg1Param;
            }

            if (RegN == Register.None)
                return;

            if (RegNParam.HasFlag(RegParam.Reference))
            {
                if (RegN == Register.ImmediateWord)
                {
                    Console.Write("({0:X4})", Current.WordImmediate);
                }
                else
                {
                    if (RegN == Register.HD && Current.Index != Register.None)
                    {
                        Console.Write("({0} + {1})", Current.Index.ToString(), Current.Displacment);
                    }
                    else
                    {
                        RegN = IndexRegister(RegN, Current.Index);

                        Console.Write("({0})", RegN.ToString());
                    }
                }
            }
            else if (RegNParam.HasFlag(RegParam.Literal))
            {
                Console.Write("{0}", (byte)RegN);
            }
            else if (RegNParam.HasFlag(RegParam.ConditionCode))
            {
                ConditionCode Code = (ConditionCode)RegN;
                if (Code == ConditionCode.CY)
                    Console.Write("C");
                else
                    Console.Write("{0}", Code.ToString());
                
                Console.Write("{0}", ((ConditionCode)RegN).ToString());
            }
            else if (RegN == Register.ImmediateWord)
            {
                Console.Write("{0:X4}", Current.WordImmediate);
            }
            else if (RegN == Register.ImmediateByte)
            {
                Console.Write("{0:X2}", Current.ByteImmediate);
            }
            else
            {
                RegN = IndexRegister(RegN, Current.Index);

                Console.Write("{0}", RegN.ToString());
            }
        }

        void PrintOpcode(OpcodeInformation Current)
        {
            Console.Write(" {0:X4}: [{1:X2}{2:X2}] {3,-4} ", Current.PC, Current.Prefix, Current.Opcode, Current.Data.Name);
            PrintParam(Current, 1);
            if (Current.Data.Reg2 != Register.None)
            {
                Console.Write(", ");
                PrintParam(Current, 2);
            }
            
            Console.WriteLine();
        }

        void PrintFlags(Flag Value)
        {
            Console.Write("    S={0} Z={1} ", Value.HasFlag(Flag.Sign) ? 1 : 0, Value.HasFlag(Flag.Zero) ? 1 : 0);
            Console.Write("HC={0} P/V={1} ", Value.HasFlag(Flag.HalfCarry) ? 1 : 0, Value.HasFlag(Flag.Parity) ? 1 : 0);
            Console.Write("N={0} C={1} ", Value.HasFlag(Flag.Subtract) ? 1 : 0, Value.HasFlag(Flag.Carry) ? 1 : 0);
            Console.WriteLine();
        }

        public void PrintStatus()
        {
            PrintFlags(Flags);
            Console.Write("    F:{0:X2} A:{1:X2} ", Get8BitRegister(Register.F), Get8BitRegister(Register.A));
            Console.Write("BC:{0:X4} DE:{1:X4} HL:{2:X4} ", Get16BitRegister(Register.BC), Get16BitRegister(Register.DE), Get16BitRegister(Register.HL));
            Console.Write("SP:{0:X4} PC:{1:X4}", Get16BitRegister(Register.SP), Get16BitRegister(Register.PC));
            Console.WriteLine();
            Console.Write("    F:{0:X2} A:{1:X2} ", AltRegisters[(byte)Register.F], AltRegisters[(byte)Register.A]);
            Console.Write("BC:{0:X4} DE:{1:X4} HL:{2:X4} ", Get16BitAltRegister(Register.BC), Get16BitAltRegister(Register.DE), Get16BitAltRegister(Register.HL));
            Console.WriteLine();
            Console.Write("    I:{0:X2} R:{1:X2} ", Get8BitRegister(Register.I), Get8BitRegister(Register.R));
            Console.Write("IX:{0:X4} IY:{1:X4} ", Get16BitRegister(Register.IX), Get16BitRegister(Register.IY));
            Console.Write("IE:{0} IM:{1} ", IFF1 ? 1 : 0, IntMode);
            Console.WriteLine();            
        }

        #endregion

        #region Flag Functions

        bool TestCondition(ConditionCode Condition)
        {
            switch (Condition)
            {
                case ConditionCode.NZ:  return (Flags & Flag.Zero) == 0;
                case ConditionCode.Z:   return (Flags & Flag.Zero) == Flag.Zero;
                case ConditionCode.NC:  return (Flags & Flag.Carry) == 0;
                case ConditionCode.CY:  return (Flags & Flag.Carry) == Flag.Carry;
                case ConditionCode.PO:  return (Flags & Flag.Parity) == 0;
                case ConditionCode.PE:  return (Flags & Flag.Parity) == Flag.Parity;
                case ConditionCode.P:   return (Flags & Flag.Sign) == 0;
                case ConditionCode.M:   return (Flags & Flag.Sign) == Flag.Sign;
            }
            
            return false;
        }

        void Set_S_Z_Flags(byte Value)
        {
            if (Value == 0)
                Flags |= Flag.Zero;

            if ((Value & 0x80) == 0x80)
                Flags |= Flag.Sign;
        }

        bool CheckParity(byte Value)
        {
            int Bits = 0;
            for (int x = 0; x < 8; x++)
                Bits += (Value >> x) & 0x01;

            if ((Bits & 0x01) == 0x00)
                return true;

            return false;
        }

        #endregion

        #region Call and Return Functions

        // Flags: S=X Z=X H=X O/P=X N=X C=X
        void ExecuteJR(OpcodeInformation Current)
        {
            bool Execute = false;
            short Offset = Current.ByteImmediate;

            if (Current.Data.Reg1Param.HasFlag(RegParam.ConditionCode))
            {
                if (TestCondition((ConditionCode)Current.Data.Reg1))
                    Execute = true;
            }
            else
            {
                Execute = true;
            }

            if (Execute)
            {
                Set16BitRegister(Register.PC, (ushort)(PC + (sbyte)Offset));
            }
        }

        // Flags: S=X Z=X H=X O/P=X N=X C=X
        void ExecuteDJNZ(OpcodeInformation Current)
        {
            byte Value = Get8BitRegister(Register.B);
            Value--;
            Set8BitRegister(Register.B, Value);

            if (Value != 0)
                Set16BitRegister(Register.PC, (ushort)(PC + Current.ByteImmediate));
        }
        
        // Flags: S=X Z=X H=X O/P=X N=X C=X
        void ExecuteJP(OpcodeInformation Current)
        {
            if (Current.Data.Reg1Param.HasFlag(RegParam.ConditionCode))
            {
                if (TestCondition((ConditionCode)Current.Data.Reg1))
                    Set16BitRegister(Register.PC, ReadData(Current, 2));
            }
            else
            {
                ushort Address = ReadData(Current, 1);
                Set16BitRegister(Register.PC, Address);
            }
        }

        // Flags: S=X Z=X H=X O/P=X N=X C=X
        void ExecuteCALL(OpcodeInformation Current)
        {
            bool Execute = false;
            ushort Address = Current.WordImmediate;

            if (Current.Data.Reg1Param.HasFlag(RegParam.ConditionCode))
            {
                if (TestCondition((ConditionCode)Current.Data.Reg1))
                {
                    Execute = true;
                    Address = ReadData(Current, 2);
                }
            }
            else
            {
                Execute = true; 
                Address = ReadData(Current, 1);
            }

            if (Execute)
            {
                SP -= 2;
                Write16BitMemory(SP, PC);

                PC = Address;
            }
        }

        // Flags: S=X Z=X H=X O/P=X N=X C=X
        void ExecuteRET(OpcodeInformation Current)
        {
            bool Execute = false;

            if (Current.Data.Reg1Param.HasFlag(RegParam.ConditionCode))
            {
                if (TestCondition((ConditionCode)Current.Data.Reg1))
                    Execute = true;
            }
            else
            {
                Execute = true;
            }

            if (Execute)
            {
                ushort Address = Read16BitMemory(SP);
                SP += 2;
                PC = Address;

                if (Current.Data.Function == Operation.RETI)
                {
                    // TODO: Send a notification about the RETI
                }
                else if (Current.Data.Function == Operation.RETN)
                {
                    // Restore the saved IFF flag when exiting the NMI handler.                    
                    IFF1 = IFF2;
                }

            }
        }
        
        // Flags: S=X Z=X H=X O/P=X N=X C=X
        void ExecuteRST(OpcodeInformation Current)
        {
            // Save the old PC
            SP -= 2;
            Write16BitMemory(SP, PC);

            // And jump to the new PC.
            PC = ReadData(Current);
        }
        
        #endregion

        #region Load and Store functions

        // Flags: S=X Z=X H=X O/P=X N=X C=X
        void ExecuteLD(OpcodeInformation Current)
        {
            ushort Value = ReadData(Current, 2);
            WriteData(Current, Value);

            if (Current.Data.Reg2 == Register.I || Current.Data.Reg2 == Register.R)
            {
                Flags &= ~Flag.Parity;

                if (IFF2)
                    Flags |= Flag.Parity;
            }
        }

        // Flags: S=X Z=X H=X O/P=X N=X C=X
        void ExecuteEX(OpcodeInformation Current)
        {
            if (Current.Data.Reg1 == Current.Data.Reg2)
            {
                // swap AF and AF'
                SwapRegister(Register.AF);
            }
            else
            {
                ushort Value1 = ReadData(Current, 1);
                ushort Value2 = ReadData(Current, 2);

                WriteData(Current, Value2, 1);
                WriteData(Current, Value1, 2);
                //Set16BitRegister(IndexRegister(Current.Data.Reg2, Current.Index), Value1);
            }
        }
        
        // Flags: S=X Z=X H=X O/P=X N=X C=X
        void ExecuteEXX(OpcodeInformation Current)
        {
            // swap Register banks
            SwapRegister(Register.BC);
            SwapRegister(Register.DE);
            SwapRegister(Register.HL);
        }
        
        // Flags: S=X Z=X H=X O/P=X N=X C=X
        void ExecutePUSH(OpcodeInformation Current)
        {
            ushort Value = ReadData(Current);
            
            SP -= 2;
            Write16BitMemory(SP, Value);
        }
        
        // Flags: S=X Z=X H=X O/P=X N=X C=X
        void ExecutePOP(OpcodeInformation Current)
        {
            ushort Value = Read16BitMemory(SP);
            SP += 2;

            WriteData(Current, Value);
        }

        // Flags: S=S Z=Z H=0 O/P=P N=0 C=X
        void ExecuteIN(OpcodeInformation Current)
        {
            ushort Port = 0;

            if (Current.Data.Reg1 == Register.A && Current.Data.Reg2 == Register.ImmediateByte)
            {
                Port = (ushort)((Get8BitRegister(Register.A) << 8) + Current.ByteImmediate);
            }
            else
            {
                Port = Get16BitRegister(Register.BC);
            }

            // Get the data from the port
            byte Result = SystemIO.ReadPort(Port);

            WriteData(Current, Result);

            Flags &= ~(Flag.NotCarry);
            Set_S_Z_Flags(Result);

            if (CheckParity(Result))
                Flags |= Flag.Parity;
        }
        
        // Flags: S=X Z=X H=X O/P=X N=X C=X
        void ExecuteOUT(OpcodeInformation Current)
        {
            ushort Port = 0;
            byte Value = 0;

            Port = ReadData(Current, 1);
            Value = (byte) ReadData(Current, 2);

            Port += (ushort)(Get8BitRegister(Register.B) << 8);

            // Write out the data to the port
            SystemIO.WritePort(Port, Value);
        }

        #endregion

        #region Bitwise Functions

        // Flags: S=S Z=Z H=0 O/P=P N=0 C=0
        void ExecuteAND(OpcodeInformation Current)
        {
            byte Param1 = Get8BitRegister(Register.A);
            byte Param2 = (byte)ReadData(Current);

            byte Result = (byte)(Param1 & Param2);

            Set8BitRegister(Register.A, Result);

            Flags &= ~(Flag.All);
            Set_S_Z_Flags(Result);

            if (CheckParity(Result))
                Flags |= Flag.Parity;
        }
        
        // Flags: S=S Z=Z H=0 O/P=P N=0 C=0
        void ExecuteOR(OpcodeInformation Current)
        {
            byte Param1 = Get8BitRegister(Register.A);
            byte Param2 = (byte)ReadData(Current);

            byte Result = (byte)(Param1 | Param2);

            Set8BitRegister(Register.A, Result);

            Flags &= ~(Flag.All);
            Set_S_Z_Flags(Result);

            if (CheckParity(Result))
                Flags |= Flag.Parity;
        }

        // Flags: S=S Z=Z H=0 O/P=P N=0 C=0
        void ExecuteXOR(OpcodeInformation Current)
        {
            byte Param1 = Get8BitRegister(Register.A);
            byte Param2 = (byte)ReadData(Current);

            byte Result = (byte)(Param1 ^ Param2);

            Set8BitRegister(Register.A, Result);

            Flags &= ~(Flag.All);
            Set_S_Z_Flags(Result);

            if(CheckParity(Result))
                Flags |= Flag.Parity;
        }

        // Flags RL(C)A: S=X Z=X H=0 O/P=X N=0 C=*
        // Flags RL(C):  S=S Z=Z H=0 O/P=P N=0 C=*
        void ExecuteRLx(OpcodeInformation Current)
        {
            bool RLA = (Current.Data.Function == Operation.RLA || Current.Data.Function == Operation.RLCA);
            bool RLC = (Current.Data.Function == Operation.RLC || Current.Data.Function == Operation.RLCA);

            byte Value = 0;

            if (RLA)
                Value = Get8BitRegister(Register.A);
            else
                Value = (byte)ReadData(Current);

            bool NewCarry = (Value & 0x80) == 0x80;
            int Result = Value << 1;

            if (RLC)
            {
                if (NewCarry)
                    Result |= 0x01;
            }
            else
            {
                if (Flags.HasFlag(Flag.Carry))
                    Result |= 0x01;
            }

            if (RLA)
            {
                Flags &= ~(Flag.HalfCarry | Flag.Carry | Flag.Subtract);

                if (NewCarry)
                    Flags |= Flag.Carry;

                Set8BitRegister(Register.A, (byte)Result);
            }
            else
            {
                Flags &= ~(Flag.All);
                Set_S_Z_Flags((byte)Result);

                if(CheckParity((byte)Result))
                    Flags |= Flag.Parity;

                if (NewCarry)
                    Flags |= Flag.Carry;
                WriteData(Current, (ushort)Result);

            }
        }

        // Flags SLL: S=S Z=Z H=0 O/P=P N=0 C=*
        // Flags SLA: S=S Z=Z H=0 O/P=P N=0 C=*
        void ExecuteSLx(OpcodeInformation Current)
        {
            byte Value = (byte)ReadData(Current);

            bool NewCarry = (Value & 0x80) == 0x80;
            int Result = Value << 1;

            if (Current.Data.Function == Operation.SLL)
            {
                Result |= 0x01;
            }

            Flags &= ~(Flag.All);
            Set_S_Z_Flags((byte)Result);

            if (CheckParity((byte)Result))
                Flags |= Flag.Parity;

            if (NewCarry)
                Flags |= Flag.Carry;

            WriteData(Current, (ushort)Result);
        }
        
        // Flags RR(C)A: S=X Z=X H=0 O/P=X N=0 C=*
        // Flags RR(C):  S=S Z=Z H=0 O/P=P N=0 C=*
        void ExecuteRR(OpcodeInformation Current)
        {
            bool RRA = (Current.Data.Function == Operation.RRA || Current.Data.Function == Operation.RRCA);
            bool RRC = (Current.Data.Function == Operation.RRC || Current.Data.Function == Operation.RRCA);

            byte Value = 0;

            if (RRA)
                Value = Get8BitRegister(Register.A);
            else
                Value = (byte)ReadData(Current);

            bool NewCarry = (Value & 0x01) == 0x01;
            int Result = Value >> 1;

            if (RRC)
            {
                if (NewCarry)
                    Result |= 0x80;
            }
            else
            {
                if (Flags.HasFlag(Flag.Carry))
                    Result |= 0x80;
            }

            if (RRA)
            {
                Flags &= ~(Flag.HalfCarry | Flag.Carry | Flag.Subtract);

                if (NewCarry)
                    Flags |= Flag.Carry;

                Set8BitRegister(Register.A, (byte)Result);
            }
            else
            {
                Flags &= ~(Flag.All);
                Set_S_Z_Flags((byte)Result);

                if (CheckParity((byte)Result))
                    Flags |= Flag.Parity;

                if (NewCarry)
                    Flags |= Flag.Carry;
                WriteData(Current, (ushort)Result);

            }
        }

        // Flags SR: S=S Z=Z H=0 O/P=P N=0 C=*
        void ExecuteSR(OpcodeInformation Current)
        {
            byte Value = (byte)ReadData(Current);

            bool NewCarry = (Value & 0x01) == 0x01;
            int Result = Value >> 1;

            if (Current.Data.Function == Operation.SRA)
            {
                // SRA preserves the sign
                if ((Value & 0x80) == 0x80)
                    Result |= 0x80;
            }

            Flags &= ~(Flag.All);
            Set_S_Z_Flags((byte)Result);

            if (CheckParity((byte)Result))
                Flags |= Flag.Parity;

            if (NewCarry)
                Flags |= Flag.Carry;
            
            WriteData(Current, (ushort)Result);
        }
        
        // Flags: S=? Z=* H=1 O/P=? N=0 C=X
        void ExecuteBIT(OpcodeInformation Current)
        {
            byte Index = (byte)ReadData(Current, 1);
            byte Value = (byte)ReadData(Current, 2);

            // Should be imposable with how it's encoded, but it might slip through the way the tables are built.
            if(Index > 7)            
                Index = 7;

            byte Mask = (byte)(0x01 << Index);
            
            Flags &= ~(Flag.Zero | Flag.Subtract);
            Flags |= Flag.HalfCarry;

            if ((Value & Mask) == Mask)
                Flags |= Flag.Zero;
        }

        // Flags: S=X Z=X H=X O/P=X N=X C=X
        void ExecuteSET(OpcodeInformation Current)
        {
            byte Index = (byte)ReadData(Current, 1);
            byte Value = (byte)ReadData(Current, 2);

            // Should be imposable with how it's encoded, but it might slip through the way the tables are built.
            if(Index > 7)            
                Index = 7;

            byte Mask = (byte)(0x01 << Index);

            Value |= Mask;

            WriteData(Current, Value, 2);
        }
        
        // Flags: S=X Z=X H=X O/P=X N=X C=X
        void ExecuteRES(OpcodeInformation Current)
        {
            byte Index = (byte)ReadData(Current, 1);
            byte Value = (byte)ReadData(Current, 2);

            // Should be imposable with how it's encoded, but it might slip through the way the tables are built.
            if (Index > 7)
                Index = 7;

            byte Mask = (byte)(0x01 << Index);
            if ((Value & Mask) == Mask)
                Value ^= Mask;

            WriteData(Current, Value, 2);
        }

        // Flags: S=S Z=Z H=0 O/P=P N=0 C=X
        void ExecuteRLD(OpcodeInformation Current)
        {
            byte Val1 = Read8BitMemory(Get16BitRegister(Register.HL));
            byte Val2 = Get8BitRegister(Register.A);

            byte B1 = (byte)(Val1 & 0x0F);
            byte B2 = (byte)((Val1 & 0xF0) >> 4);
            byte B3 = (byte)(Val2 & 0x0F);

            Val2 = (byte)((Val2 & 0xF0) + B2);
            Val2 = (byte)((B1 << 4) + B3);

            Write8BitMemory(Get16BitRegister(Register.HL), Val1);
            Set8BitRegister(Register.A, Val2);

            Flags &= ~(Flag.NotCarry);
            Set_S_Z_Flags(Val2);
            if (CheckParity(Val2))
                Flags |= Flag.Parity;
        }

        // Flags: S=S Z=Z H=0 O/P=P N=0 C=X
        void ExecuteRRD(OpcodeInformation Current)
        {
            byte Val1 = Read8BitMemory(Get16BitRegister(Register.HL));
            byte Val2 = Get8BitRegister(Register.A);

            byte B1 = (byte)(Val1 & 0x0F);
            byte B2 = (byte)((Val1 & 0xF0) >> 4);
            byte B3 = (byte)(Val2 & 0x0F);

            Val2 = (byte)((Val2 & 0xF0) + B1);
            Val2 = (byte)((B3 << 4) + B2);

            Write8BitMemory(Get16BitRegister(Register.HL), Val1);
            Set8BitRegister(Register.A, Val2);

            Flags &= ~(Flag.NotCarry);
            Set_S_Z_Flags(Val2);
            if (CheckParity(Val2))
                Flags |= Flag.Parity;
        }
        
        #endregion

        #region Math Functions

        // Flags  8-Bit: S=S Z=Z H=H O/P=O N=0 C=X
        // Flags 16-Bit: S=X Z=X H=X O/P=X N=X C=X
        void ExecuteINC(OpcodeInformation Current)
        {
            ushort Value = ReadData(Current);
            ushort Result = (ushort)(Value + 1);

            if (!Current.Data.Reg1Param.HasFlag(RegParam.WordData))
            {
                Flags &= ~(Flag.NotCarry);
                Set_S_Z_Flags((byte)Result);

                if ((Value & 0x0F) == 0x0F)
                    Flags |= Flag.HalfCarry;

                if (Value == 0x7F)
                    Flags |= Flag.Overflow;
            }

            WriteData(Current, (ushort)Result);
        }

        // Flags  8-Bit: S=S Z=Z H=H O/P=O N=1 C=X
        // Flags 16-Bit: S=X Z=X H=X O/P=X N=X C=X
        void ExecuteDEC(OpcodeInformation Current)
        {
            ushort Value = ReadData(Current);
            ushort Result = (ushort)(Value - 1);

            if (!Current.Data.Reg1Param.HasFlag(RegParam.WordData))
            {
                Flags &= ~(Flag.NotCarry);
                Set_S_Z_Flags((byte)Result);

                if ((Value & 0x0F) == 0x00)
                    Flags |= Flag.HalfCarry;

                if (Value == 0x80)
                    Flags |= Flag.Overflow;

                Flags |= Flag.Subtract;
            }

            WriteData(Current, (ushort)Result);
        }

        // Flags: S=S Z=Z H=H O/P=O N=1 C=C
        void ExecuteCP(OpcodeInformation Current)
        {
            byte Param1 = Get8BitRegister(Register.A);
            byte Param2 = (byte)ReadData(Current);

            int Result = Param1 - Param2;

            Flags &= ~(Flag.All);
            Set_S_Z_Flags((byte)Result);

            if ((Param1 & 0x0F) - (Param2 & 0x0F) < 0)
                Flags |= Flag.HalfCarry;

            if (Result < -128 || Result > 127)
                Flags |= Flag.Overflow;

            Flags |= Flag.Subtract;

            if(Result < 0)
                Flags |= Flag.Carry;
        }

        // Flags  8-Bit ADD: S=S Z=Z H=H O/P=O N=0 C=C
        // Flags 16-Bit ADD: S=X Z=X H=H O/P=X N=0 C=C
        // Flags        ADC: S=S Z=Z H=H O/P=O N=0 C=C
        void ExecuteADD(OpcodeInformation Current)
        {
            bool OldCarry = Flags.HasFlag(Flag.Carry);

            if (Current.Data.Reg1Param.HasFlag(RegParam.WordData))
            {
                ushort Param1 = ReadData(Current, 1);
                ushort Param2 = ReadData(Current, 2);

                int Result = Param1 + Param2;

                if (Current.Data.Function == Operation.ADC)
                {
                    if(OldCarry)
                        Result += 1;

                    Flags &= ~(Flag.All);
                    if (Result == 0)
                        Flags |= Flag.Zero;

                    if ((Result & 0x8000) == 0x8000)
                        Flags |= Flag.Sign;

                    if (Result < -32768 || Result > 32767)
                        Flags |= Flag.Overflow;
                }
                else
                {
                    Flags &= ~(Flag.HalfCarry | Flag.Carry | Flag.Subtract);
                }

                if ((Param1 & 0x0FFF) + (Param2 & 0x0FFF) > 0x0FFF)
                    Flags |= Flag.HalfCarry;

                if (Result >= 0x10000)
                    Flags |= Flag.Carry;


                WriteData(Current, (ushort)Result);
            }
            else
            {
                byte Param1 = (byte)ReadData(Current, 1);
                byte Param2 = (byte)ReadData(Current, 2);

                int Result = Param1 + Param2;

                if (Current.Data.Function == Operation.ADC & OldCarry)
                    Result += 1;

                Flags &= ~(Flag.All);
                Set_S_Z_Flags((byte)Result);

                if ((Param1 & 0x0F) + (Param2 & 0x0F) > 0x0F)
                    Flags |= Flag.HalfCarry;

                if (Result < -128 || Result > 127)
                    Flags |= Flag.Overflow;

                if (Result >= 0x100)
                    Flags |= Flag.Carry;

                WriteData(Current, (ushort)Result);
            }
        }

        // Flags SUB  8-Bit: S=S Z=Z H=H O/P=O N=1 C=C        
        void ExecuteSUB(OpcodeInformation Current)
        {
            byte Param1 = Get8BitRegister(Register.A);
            byte Param2 = (byte)ReadData(Current);

            int Result = Param1 - Param2;

            Flags &= ~(Flag.All);
            Set_S_Z_Flags((byte)Result);

            if ((Param1 & 0x0F) - (Param2 & 0x0F) < 0)
                Flags |= Flag.HalfCarry;

            if (Result < -128 || Result > 127)
                Flags |= Flag.Overflow;

            Flags |= Flag.Subtract;

            if (Result < 0)
                Flags |= Flag.Carry;

            Set8BitRegister(Register.A, (byte)Result);
        }

        // Flags SBC: S=S Z=Z H=H O/P=O N=1 C=C
        void ExecuteSBC(OpcodeInformation Current)
        {
            bool OldCarry = Flags.HasFlag(Flag.Carry);

            if (Current.Data.Reg1Param.HasFlag(RegParam.WordData))
            {
                ushort Param1 = ReadData(Current, 1);
                ushort Param2 = ReadData(Current, 2);

                int Result = Param1 - Param2;

                if (OldCarry)
                    Result -= 1;

                Flags &= ~(Flag.All);

                if (Result == 0)
                    Flags |= Flag.Zero;

                if ((Result & 0x8000) == 0x8000)
                    Flags |= Flag.Sign;

                if (Result < -32768 || Result > 32767)
                    Flags |= Flag.Overflow;

                if ((Param1 & 0x0FFF) - (Param2 & 0x0FFF) < 0)
                    Flags |= Flag.HalfCarry;

                Flags |= Flag.Subtract;

                if (Result < 0)
                    Flags |= Flag.Carry;

                WriteData(Current, (ushort)Result);
            }
            else
            {
                byte Param1 = (byte)ReadData(Current, 1);
                byte Param2 = (byte)ReadData(Current, 2);

                int Result = Param1 - Param2;

                if (OldCarry)
                    Result -= 1;

                Flags &= ~(Flag.All);
                Set_S_Z_Flags((byte)Result);

                if ((Param1 & 0x0F) - (Param2 & 0x0F) < 0)
                    Flags |= Flag.HalfCarry;

                if (Result < -128 || Result > 127)
                    Flags |= Flag.Overflow;

                Flags |= Flag.Subtract;

                if (Result < 0)
                    Flags |= Flag.Carry;

                WriteData(Current, (ushort)Result);
            }
        }

        // Flags SBC: S=S Z=Z H=H O/P=O N=1 C=*
        void ExecuteNEG(OpcodeInformation Current)
        {
            byte Value = Get8BitRegister(Register.A);

            byte Result = (byte)-Value;

            Flags &= ~(Flag.All);
            Set_S_Z_Flags(Result);

            if ((Value & 0x0F) != 0)
                Flags |= Flag.HalfCarry;

            if (Value == 0x80) 
                Flags |= Flag.Overflow;

            Flags |= Flag.Subtract;

            if (Value != 0)
                Flags |= Flag.Carry;

            Set8BitRegister(Register.A, Result);

        }
        
        // Flags SBC: S=S Z=Z H=* O/P=P N=X C=*
        void ExecuteDAA(OpcodeInformation Current)
        {
            byte Value = Get8BitRegister(Register.A);

            int HNibble = (Value & 0xF0) >> 4;
            int LNibble = (Value & 0x0F);

            byte Adjust = 0;

            bool Carry = Flags.HasFlag(Flag.Carry);
            bool HalfCarry = Flags.HasFlag(Flag.HalfCarry);
            bool Subtract = Flags.HasFlag(Flag.Subtract);

            Flags &= ~(Flag.All);

            if (Subtract)
            {
                if (!Carry && !HalfCarry)
                    Adjust = 0x00;

                else if (!Carry && HalfCarry)
                    Adjust = 0xFA;

                else if (Carry && !HalfCarry)
                    Adjust = 0xA0;

                else if (Carry && HalfCarry)
                    Adjust = 0x9A;

                if (Carry)
                    Flags |= Flag.Carry;
                
                Flags |= Flag.Subtract;
            }
            else
            {
                if (LNibble >= 0xA0 || HalfCarry)
                {
                    Adjust |= 0x06;
                }

                if (HNibble >= 0x09 || Carry)
                {
                    Adjust |= 0x60;
                    Flags |= Flag.Carry;
                }

                // Half carry flag is weird.
                if (LNibble >= 0xA0 || (Carry & HalfCarry & LNibble <= 0x05))
                    Flags |= Flag.HalfCarry;
            }

            int Result = Value + Adjust;

            Set_S_Z_Flags((byte)Result);

            if (CheckParity((byte)Result))
                Flags |= Flag.Parity;
        }
        
        #endregion

        #region Block Commands
        
        // Flags INx:  S=? Z=* H=? O/P=? N=1 C=X
        void ExecuteINx(OpcodeInformation Current)
        {
            bool Down = (Current.Data.Function == Operation.IND || Current.Data.Function == Operation.INDR);
            bool Repeat = (Current.Data.Function == Operation.INIR || Current.Data.Function == Operation.INDR);

            byte Count = Get8BitRegister(Register.B);
            ushort Address = Get16BitRegister(Register.HL);

            ushort Port = Get16BitRegister(Register.BC);
            
            // Get the data from the port
            byte Result = SystemIO.ReadPort(Port);

            Write8BitMemory(Address, Result);
            if (Down)
                Address--;
            else
                Address++;

            Set16BitRegister(Register.HL, Address);

            Count--;
            Set8BitRegister(Register.B, Count);
            
            Flags &= ~Flag.Zero;
            if (Count == 0)
                Flags |= Flag.Zero;
            
            Flags |= Flag.Subtract;

            if (Repeat && Count != 0)
            {
                Address = Get16BitRegister(Register.PC);
                Address -= 2;
                Set16BitRegister(Register.PC, Address);
            }
        }

        // Flags OUTx: S=? Z=* H=? O/P=? N=0 C=X
        void ExecuteOUTx(OpcodeInformation Current)
        {
            bool Down = (Current.Data.Function == Operation.OUTD || Current.Data.Function == Operation.OTDR);
            bool Repeat = (Current.Data.Function == Operation.OTIR || Current.Data.Function == Operation.OTDR);

            byte Count = Get8BitRegister(Register.B);
            Count--;
            Set8BitRegister(Register.B, Count);

            ushort Port = Get16BitRegister(Register.BC);
            ushort Address = Get16BitRegister(Register.HL);

            if (Down)
                Address--;
            else
                Address++;

            Set16BitRegister(Register.HL, Address);

            byte Value = Read8BitMemory(Address);

            // Write out the data to the port
            SystemIO.WritePort(Port, Value);

            Flags &= ~Flag.Zero;
            if (Count == 0)
                Flags |= Flag.Zero;

            Flags |= Flag.Subtract;

            if (Repeat && Count != 0)
            {
                Address = Get16BitRegister(Register.PC);
                Address -= 2;
                Set16BitRegister(Register.PC, Address);
            }
        }

        // Flags LDx:  S=X Z=X H=0 O/P=* N=0 C=X
        void ExecuteLDx(OpcodeInformation Current)
        {
            bool Down = (Current.Data.Function == Operation.LDD || Current.Data.Function == Operation.LDDR);
            bool Repeat = (Current.Data.Function == Operation.LDIR || Current.Data.Function == Operation.LDDR);

            ushort Count = Get8BitRegister(Register.BC);
            ushort ScrAddress = Get16BitRegister(Register.HL);
            ushort DestAddress = Get16BitRegister(Register.DE);


            byte Value = Read8BitMemory(ScrAddress);
            Write8BitMemory(DestAddress, Value);

            if (Down)
            {
                ScrAddress--;
                DestAddress--;
            }
            else
            {
                ScrAddress++;
                DestAddress++;
            }

            Set16BitRegister(Register.HL, ScrAddress);
            Set16BitRegister(Register.DE, DestAddress);

            Count--;
            Set16BitRegister(Register.BC, Count);

            Flags &= ~(Flag.HalfCarry | Flag.Overflow | Flag.Subtract);

            if (Count != 0)
                Flags |= Flag.Overflow;
            
            if (Repeat && Count != 0)
            {
                ushort Address = Get16BitRegister(Register.PC);
                Address -= 2;
                Set16BitRegister(Register.PC, Address);
            }
        }
        
        // Flags CPx:  S=S Z=Z H=H O/P=* N=1 C=X
        void ExecuteCPx(OpcodeInformation Current)
        {
            bool Down = (Current.Data.Function == Operation.LDD || Current.Data.Function == Operation.LDDR);
            bool Repeat = (Current.Data.Function == Operation.LDIR || Current.Data.Function == Operation.LDDR);

            ushort Count = Get8BitRegister(Register.BC);
            ushort Address = Get16BitRegister(Register.HL);

            byte Param1 = Get8BitRegister(Register.A);
            byte Param2 = Read8BitMemory(Address);

            int Result = Param1 - Param2;

            if (Down)
                Address--;

            else
                Address++;

            Set16BitRegister(Register.HL, Address);

            Count--;

            Set16BitRegister(Register.BC, Count);

            Flags &= ~(Flag.NotCarry);
            Set_S_Z_Flags((byte)Result);

            if ((Param1 & 0x0F) - (Param2 & 0x0F) < 0)
                Flags |= Flag.HalfCarry;

            Flags |= Flag.Subtract;

            if (Count != 0)
                Flags |= Flag.Overflow;
            
            if (Repeat && Count != 0)
            {
                Address = Get16BitRegister(Register.PC);
                Address -= 2;
                Set16BitRegister(Register.PC, Address);
            }
        }
        
        #endregion

        public Z80(Memory Ram, ExternalIO IO)
        {
            SystemMemory = Ram;
            SystemIO = IO;

            Array.Clear(Registers, 0, Registers.Length);
            Array.Clear(AltRegisters, 0, AltRegisters.Length);

            Reset();
        }
        
        public bool ExecuteOpcode(RunMode Mode = RunMode.Normal, int InterruptData = 0)
        {
            if (Mode == RunMode.NMI)
            {
                Halted = false;

                // Disable Maskable Interrupts
                IFF1 = false;

                // Push the current address
                SP -= 2;
                Write16BitMemory(SP, PC);

                // And jump to a fixed location in memory
                PC = 0x0066;
            }
            else if (!SkipNextInt && Mode == RunMode.INT && IFF1 == true)
            {
                Halted = false;

                // Disable Maskable Interrupts
                IFF1 = IFF2 = false;

                // Push the current address
                SP -= 2;
                Write16BitMemory(SP, PC);

                if (IntMode == 0)
                {
                    PC = (ushort)(InterruptData & 0x38);
                }
                else if (IntMode == 1)
                {
                    // And jump to a fixed location in memory
                    PC = 0x0038;
                }
                else
                {
                    int Address = (Get8BitRegister(Register.I) << 8) + (InterruptData & 0xFE);

                    PC = Read16BitMemory((ushort)Address);
                }
            }

            if (Halted)
            {
                Registers[(byte)Register.R]++;
                return Halted;
            }

            SkipNextInt = false;

            OpcodeInformation Current = new OpcodeInformation();
            int TableIndex = 0;
            Current.Index = Register.None;
            Current.Prefix = 0;
            Current.PC = PC;

            Current.Opcode = Read8BitPC();

            bool ReadDisplacment = false;

            while (Current.Opcode == 0xCB || Current.Opcode == 0xED || Current.Opcode == 0xDD || Current.Opcode == 0xFD)
            {
                if (Current.Opcode == 0xCB)
                {
                    TableIndex = 1;
                    Current.Prefix = Current.Opcode;

                    // On the CB prefix the displacment comes Bettwen CB and the actuall opcode
                    if (ReadDisplacment)
                    {
                        Current.Displacment = Read8BitPC();
                        ReadDisplacment = false;
                    }
                }
                else if (Current.Opcode == 0xED)
                {
                    TableIndex = 2;
                    Current.Prefix = Current.Opcode;
                }
                else if (Current.Opcode == 0xDD)
                {
                    TableIndex = 0;
                    Current.Index = Register.IX;
                    ReadDisplacment = true;
                }
                else if (Current.Opcode == 0xFD)
                {
                    TableIndex = 0;
                    Current.Index = Register.IY;
                    ReadDisplacment = true;
                }

                Current.Opcode = Read8BitPC();
            }

            Current.Data = Ops.ByteData[TableIndex, Current.Opcode];
            Current.Displacment = 0;
            Current.ByteImmediate = 0;
            Current.WordImmediate = 0;

            // Displacement comes next if we're using an index
            if (ReadDisplacment)
            {
                if (Current.Data.Reg1 == Register.HD || Current.Data.Reg2 == Register.HD)
                    Current.Displacment = Read8BitPC();
            }

            if (Current.Data.Reg1 == Register.ImmediateWord || Current.Data.Reg2 == Register.ImmediateWord)
            {
                Current.WordImmediate = Read16BitPC();
            }

            if (Current.Data.Reg1 == Register.ImmediateByte || Current.Data.Reg2 == Register.ImmediateByte)
            {
                Current.ByteImmediate = Read8BitPC();
            }

            //PrintOpcode(Current);
            //PrintStatus();
            //Console.WriteLine();   

            switch (Current.Data.Function)
            {
                case Operation.ADC:     ExecuteADD(Current); break;
                case Operation.ADD:     ExecuteADD(Current); break;
                case Operation.AND:     ExecuteAND(Current); break;
                case Operation.BIT:     ExecuteBIT(Current); break;
                case Operation.CALL:    ExecuteCALL(Current); break;
                case Operation.CCF:     Flags &= ~(Flag.HalfCarry | Flag.Subtract); Flags |= Flags.HasFlag(Flag.Carry) ? Flag.HalfCarry : 0; Flags ^= Flag.Carry; break;    // Flags: S=X Z=X H=* O/P=X N=0 C=*
                case Operation.CP:      ExecuteCP(Current); break;
                case Operation.CPD:     ExecuteCPx(Current); break;
                case Operation.CPDR:    ExecuteCPx(Current); break;
                case Operation.CPI:     ExecuteCPx(Current); break;
                case Operation.CPIR:    ExecuteCPx(Current); break;
                case Operation.CPL:     Set8BitRegister(Register.A, (byte)~Get8BitRegister(Register.A)); Flags |= Flag.HalfCarry | Flag.Subtract; break;   // Flags: S=X Z=X H=1 O/P=X N=X C=1
                case Operation.DAA:     ExecuteDAA(Current); break;
                case Operation.DEC:     ExecuteDEC(Current); break;
                case Operation.DI:      IFF1 = IFF2 = false; break; // Flags: S=X Z=X H=X O/P=X N=X C=X
                case Operation.DJNZ:    ExecuteDJNZ(Current); break;
                case Operation.EI:      SkipNextInt = IFF1 = IFF2 = true; break;  // Flags: S=X Z=X H=X O/P=X N=X C=X
                case Operation.EX:      ExecuteEX(Current); break;
                case Operation.EXX:     ExecuteEXX(Current); break;
                case Operation.HALT:    Halted = true; break;   // Flags: S=X Z=X H=X O/P=X N=X C=X
                case Operation.IM:      IntMode = (byte)ReadData(Current); break; // Flags: S=X Z=X H=X O/P=X N=X C=X
                case Operation.IN:      ExecuteIN(Current); break;
                case Operation.INC:     ExecuteINC(Current); break;
                case Operation.IND:     ExecuteINx(Current); break;
                case Operation.INDR:    ExecuteINx(Current); break;
                case Operation.INI:     ExecuteINx(Current); break;
                case Operation.INIR:    ExecuteINx(Current); break;
                case Operation.JP:      ExecuteJP(Current); break;
                case Operation.JR:      ExecuteJR(Current); break;
                case Operation.LD:      ExecuteLD(Current); break;
                case Operation.LDD:     ExecuteLDx(Current); break;
                case Operation.LDDR:    ExecuteLDx(Current); break;
                case Operation.LDI:     ExecuteLDx(Current); break;
                case Operation.LDIR:    ExecuteLDx(Current); break;
                case Operation.NEG:     ExecuteNEG(Current); break;
                case Operation.NOP:     break;  // Flags: S=X Z=X H=X O/P=X N=X C=X
                case Operation.OR:      ExecuteOR(Current); break;
                case Operation.OTDR:    ExecuteOUTx(Current); break;
                case Operation.OTIR:    ExecuteOUTx(Current); break;
                case Operation.OUT:     ExecuteOUT(Current); break;
                case Operation.OUTD:    ExecuteOUTx(Current); break;
                case Operation.OUTI:    ExecuteOUTx(Current); break;
                case Operation.POP:     ExecutePOP(Current); break;
                case Operation.PUSH:    ExecutePUSH(Current); break;
                case Operation.RES:     ExecuteRES(Current); break;
                case Operation.RET:     ExecuteRET(Current); break;
                case Operation.RETI:    ExecuteRET(Current); break; 
                case Operation.RETN:    ExecuteRET(Current); break; 
                case Operation.RL:      ExecuteRLx(Current); break;
                case Operation.RLA:     ExecuteRLx(Current); break;
                case Operation.RLC:     ExecuteRLx(Current); break;
                case Operation.RLCA:    ExecuteRLx(Current); break;
                case Operation.RLD:     ExecuteRLD(Current); break;
                case Operation.RR:      ExecuteRR(Current); break;
                case Operation.RRA:     ExecuteRR(Current); break;
                case Operation.RRC:     ExecuteRR(Current); break;
                case Operation.RRCA:    ExecuteRR(Current); break;
                case Operation.RRD:     ExecuteRRD(Current); break;
                case Operation.RST:     ExecuteRST(Current); break;
                case Operation.SBC:     ExecuteSBC(Current); break;
                case Operation.SCF:     Flags &= ~(Flag.HalfCarry | Flag.Subtract | Flag.Carry); Flags |= Flag.Carry; break;    // Flags: S=X Z=X H=0 O/P=X N=0 C=1
                case Operation.SET:     ExecuteSET(Current); break;
                case Operation.SLA:     ExecuteSLx(Current); break;
                case Operation.SLL:     ExecuteSLx(Current); break;
                case Operation.SRA:     ExecuteSR(Current); break;
                case Operation.SRL:     ExecuteSR(Current); break;
                case Operation.SUB:     ExecuteSUB(Current); break;
                case Operation.XOR:     ExecuteXOR(Current); break;

                case Operation.Error:
                default:
                    PrintOpcode(Current);
                    PrintStatus();
                    Console.WriteLine();   
                    Console.WriteLine("  {0:X4} Unknown opcode {1} {2:X2}{3:X2}", Current.PC, Current.Data.Name, Current.Prefix, Current.Opcode);
                    throw new SystemException("Unknown Opcode");

            }

            Registers[(byte)Register.R]++;

            return Halted;
        }

        /// <summary>
        /// Returns the current state of the virutal machine
        /// </summary>
        /// <returns></returns>
        public byte[] CaptureState()
        {
            byte[] Ret = new byte[Registers.Length + AltRegisters.Length + 5];

            int Pos = 0;

            Array.Copy(Registers, 0, Ret, Pos, Registers.Length);
            Pos += Registers.Length;
            Array.Copy(AltRegisters, 0, Ret, Pos, AltRegisters.Length);
            Pos += AltRegisters.Length;
            Ret[Pos++] = IntMode;
            Ret[Pos++] = IFF1 ? (byte)1 : (byte)0;
            Ret[Pos++] = IFF2 ? (byte)1 : (byte)0;
            Ret[Pos++] = SkipNextInt ? (byte)1 : (byte)0;
            Ret[Pos++] = Halted ? (byte)1 : (byte)0; 

            return Ret;
        }

        public void Reset()
        {
            IntMode = 0;
            IFF1 = IFF2 = false;
            Halted = false;
            Set16BitRegister(Register.AF, 0xFFFF);
            Set16BitRegister(Register.PC, 0x0000);
            Set16BitRegister(Register.SP, 0xFFFF);
            Set8BitRegister(Register.I, 0);
            Set8BitRegister(Register.R, 0);
        }

    }
}
