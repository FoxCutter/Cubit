using System;
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
        public ObjectType           Type { get; private set; }

        public bool                 Error;
        public int                  Address;

        public ObjectInformation(ObjectType Type = ObjectType.None)
        {
            this.Type = Type;
            Error = false;
            Address = 0;
        }
        
        public override string ToString()
        {
            return "";
        }
    }

    class SymbolInformation : ObjectInformation
    {
        public SymbolTableEntry Symbol;

        public SymbolInformation(SymbolTableEntry Symbol, ObjectType Type)
            : base(Type)
        {
            this.Symbol = Symbol;
        }

        public override string ToString()
        {
            return base.ToString() + ":";
        }
    }


    class LabelInformation : SymbolInformation
    {
        public LabelInformation(SymbolTableEntry Symbol)
            : base(Symbol, ObjectType.Label)
        {
        }

        public override string ToString()
        {
            return base.ToString() + ":";
        }
    }

    class ValueInformation : SymbolInformation
    {
        public int Value;
        public ParameterInformation Params;
        //public bool Constant;

        public ValueInformation(SymbolTableEntry Symbol)
            : base(Symbol, ObjectType.Value)
        {
            Value = 0;
            Params = null;
        }

        public override string ToString()
        {
            return base.ToString() + " = 0x" + Value.ToString("X");
        }
    }


    class ParamInformation : ObjectInformation
    {
        public List<ParameterInformation> Params;

        public ParamInformation(ObjectType Type)
            : base(Type)
        {
            Params = new List<ParameterInformation>();
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

        public DataInformation(CommandID DataType)
            : base(ObjectType.Data)
        {
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
                            Ret += Param.Value.StringValue.Length;
                        else
                            Ret += 1;
                        break;

                    case CommandID.WORD:
                        Ret += 2;
                        break;

                    case CommandID.DC:
                        Ret += Param.Value.StringValue.Length;
                        break;

                    case CommandID.RESB:
                        Ret += Param.Value.NumericValue;
                        break;

                    case CommandID.RESW:
                        Ret += Param.Value.NumericValue * 2;
                        break;

                    case CommandID.RESD:
                        Ret += Param.Value.NumericValue * 4;
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

        public OpcodeInformation(CommandID Opcode)
            : base(ObjectType.Opcode)
        {
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
            if (Encoding.Function == CommandID.None)
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

        public CommandInformation(CommandID Command)
            : base(ObjectType.Command)
        {
            this.Command = Command;
        }
    }
}
