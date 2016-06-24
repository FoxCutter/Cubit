﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    enum ObjectType
    {
        None,
        Label,
        Value,
        //Macro,
        //Procedure,
        Opcode,
        Command,
        Data,
    }
       
    class ObjectInformation
    {
        public ObjectType           Type;
        public SymbolTableEntry     Symbol;
        public TokenLocation        Location;
        public bool                 Error;

        public int                  Address;

        public ObjectInformation(SymbolTableEntry Symbol, TokenLocation Location = null)
        {
            Type = ObjectType.None;
            this.Symbol = Symbol;
            this.Location = Location;
            Error = false;
            Address = 0;
        }
        
        public override string ToString()
        {
            return Symbol.Symbol;
        }
    }
   
    class LabelInformation : ObjectInformation
    {
        public LabelInformation(SymbolTableEntry Symbol, TokenLocation Location = null)
            : base(Symbol, Location)
        {
            Type = ObjectType.Label;
            Address = 0;
        }

        public override string ToString()
        {
            return base.ToString() + ":";
        }
    }

    class ValueInformation : ObjectInformation
    {
        public int Value;
        public ParameterInformation Params;
        public bool Constant;

        public ValueInformation(SymbolTableEntry Symbol, TokenLocation Location = null)
            : base(Symbol, Location)
        {
            Type = ObjectType.Value;
            Value = 0;
        }

        public override string ToString()
        {
            return base.ToString() + " = 0x" + Value.ToString("X");
        }
    }


    class ParamInformation : ObjectInformation
    {
        public List<ParameterInformation> Params;

        public ParamInformation(TokenLocation Location = null)
            : base(null, Location)
        {
            Params = new List<ParameterInformation>();
            Type = ObjectType.Data;
        }

        public override string ToString()
        {
            StringBuilder Ret = new StringBuilder();

            for (int x = 0; x < Params.Count; x++)
            {
                if (x != 0)
                    Ret.Append(", ");

                Ret.Append(ParamString(x));
            }

            return Ret.ToString();
        }

        public string ParamString(int Index)
        {
            if (Params.Count <= Index)
                return "";

            return Params[Index].ToString();
        }
    }

    class DataInformation : ParamInformation
    {
        public CommandID DataType;

        public DataInformation(CommandID DataType, TokenLocation Location = null)
            : base(Location)
        {
            Type = ObjectType.Data;
            this.DataType = DataType;
        }

        public int GetDataLength()
        {
            int Ret = 0;

            foreach (ParameterInformation Param in Params)
            {
                switch (DataType)
                {
                    case CommandID.BYTE:
                        if (Param.Value.Type == TokenType.String)
                            Ret += Param.Value.Value.Count;
                        else
                            Ret += 1;
                        break;

                    case CommandID.WORD:
                        Ret += 2;
                        break;

                    case CommandID.DC:
                        Ret += Param.Value.Value.Count;
                        break;

                    case CommandID.DEFS:
                        Ret += Param.Value.NumaricValue;
                        break;
                }
            }

            return Ret;
        }

    }

    class OpcodeInformation : ParamInformation
    {
        public CommandID Opcode; 

        public OpcodeEncoding Encoding;        

        public OpcodeInformation(CommandID Opcode, TokenLocation Location = null)
            : base(Location)
        {
            Type = ObjectType.Opcode;
            this.Opcode = Opcode;
        }

        public override string ToString()
        {
            StringBuilder Ret = new StringBuilder();

            Ret.Append(Opcode.ToString());
            Ret.Append(" ");

            Ret.Append(base.ToString());

            return Ret.ToString();
        }

        public int GetOpcodeLength()
        {
            if (Encoding == null || Encoding.Function == CommandID.None)
                return 0;

            int Ret = Encoding.Encoding.Length;

            if (Encoding.Param1Type != ParameterType.None)
            {
                if (Encoding.Param1Type == ParameterType.ImmediatePtr)
                {
                    Ret += 2;
                }
                else if (Encoding.Param1Type == ParameterType.Immediate)
                {
                    if (Encoding.Param1 == CommandID.ImmediateByte)
                        Ret += 1;
                    else
                        Ret += 2;
                }
            }

            if (Encoding.Param2Type != ParameterType.None)
            {
                if (Encoding.Param2Type == ParameterType.ImmediatePtr)
                {
                    Ret += 2;
                }
                else if (Encoding.Param2Type == ParameterType.Immediate)
                {
                    if (Encoding.Param2 == CommandID.ImmediateByte)
                        Ret += 1;
                    else
                        Ret += 2;
                }
            }

            if (Encoding.Flags == ParamFlags.InternalDisplacement || Encoding.Flags == ParamFlags.Displacement)
                Ret += 1;

            return Ret;
        }
    }

    class CommandInformation : ParamInformation
    {
        public CommandID Command; 

        public CommandInformation(CommandID Command, TokenLocation Location = null)
            : base(Location)
        {
            Type = ObjectType.Command;
            this.Command = Command;
        }
    }
}
