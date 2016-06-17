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

        public int                  Length;

        public ObjectInformation(SymbolTableEntry Symbol, TokenLocation Location = null)
        {
            Type = ObjectType.None;
            this.Symbol = Symbol;
            this.Location = Location;
            Error = false;
            Length = 0;
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
    }

    class OpcodeInformation : ParamInformation
    {
        public CommandID Opcode; 

        public OpcodeEncoding Encoding;        
        //public int EncodingLength;

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
