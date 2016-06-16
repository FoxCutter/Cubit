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
        public ObjectType           Type;
        public SymbolTableEntry     Symbol;
        public TokenLocation        Location;
        public bool                 Error;

        public ObjectInformation(SymbolTableEntry Symbol, TokenLocation Location = null)
        {
            Type = ObjectType.None;
            this.Symbol = Symbol;
            this.Location = Location;
            Error = false;
        }
        
        public override string ToString()
        {
            return Symbol.Symbol;
        }
    }
   
    class LabelInformation : ObjectInformation
    {
        public int Address;

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

        public ValueInformation(SymbolTableEntry Symbol, TokenLocation Location = null)
            : base(Symbol, Location)
        {
            Type = ObjectType.Value;
            Value = 0;
        }

        public override string ToString()
        {
            return base.ToString() + " = " + Value.ToString();
        }
    }


    class ParamInformation : ObjectInformation
    {
        public CommandID Action;
        public List<ParameterInformation> Params;

        public ParamInformation(CommandID Action, TokenLocation Location = null)
            : base(null, Location)
        {
            Params = new List<ParameterInformation>();
            Type = ObjectType.Data;
            this.Action = Action;
        }

        public override string ToString()
        {
            StringBuilder Ret = new StringBuilder();

            Ret.Append(Action.ToString());
            Ret.Append(" ");

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
        public int Address;

        public DataInformation(CommandID Action, TokenLocation Location = null)
            : base(Action, Location)
        {
            Address = 0;
            Type = ObjectType.Data;
        }
    }

    class OpcodeInformation : ParamInformation
    {
        public int Address;

        public OpcodeEncoding Encoding;        
        //public int EncodingLength;

        public OpcodeInformation(CommandID Action, TokenLocation Location = null)
            : base(Action, Location)
        {
            Address = 0; 
            Type = ObjectType.Opcode;
        }

        public override string ToString()
        {
            StringBuilder Ret = new StringBuilder();

            Ret.Append(Action.ToString());
            Ret.Append(" ");

            for (int x = 0; x < Params.Count; x++)
            {
                if (x != 0)
                    Ret.Append(", ");

                Ret.Append(ParamString(x));
            }

            return Ret.ToString();
        }
        
        public int DataSize()
        {
            foreach (ParameterInformation Param in Params)
            {
                if (Param.Type == ParameterType.RegisterByte)
                    return 8;

                if (Param.Type == ParameterType.RegisterWord || Param.Pointer)
                    return 16;
            }

            return 0;
        }
    }

    class CommandInformation : ParamInformation
    {
        public CommandInformation(CommandID Action, TokenLocation Location = null)
            : base(Action, Location)
        {
            Type = ObjectType.Command;
        }
    }
}
