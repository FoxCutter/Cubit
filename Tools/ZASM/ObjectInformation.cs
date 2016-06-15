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
        Keyword,
        Command,
    }
       
    class ObjectInformation
    {
        public ObjectType           Type;
        public SymbolTableEntry     Symbol;
        public TokenLocation        Location;

        public ObjectInformation(SymbolTableEntry Symbol, TokenLocation Location = null)
        {
            Type = ObjectType.None;
            this.Symbol = Symbol;
            this.Location = Location;
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
        public ParamInformation Params;

        public ValueInformation(SymbolTableEntry Symbol, TokenLocation Location = null)
            : base(Symbol, Location)
        {
            Type = ObjectType.Value;
            Value = 0;
        }

        public override string ToString()
        {
            return base.ToString() + " = " + Value.ToString("X2");
        }
    }

    class KeywordInformation : ObjectInformation
    {
        public CommandID Action;
        public List<ParamInformation> Params;

        public KeywordInformation(TokenLocation Location = null)
            : base(null, Location)
        {
            Type = ObjectType.Keyword;
            Action = CommandID.None;
            Params = new List<ParamInformation>();            
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

            ParamInformation Param = Params[Index];
            StringBuilder Ret = new StringBuilder();

            if (Param.Address)
                Ret.Append("(");

            Ret.Append(Parser.PrintStack(Param.Tokens.ToList()).ToString());

            if (Param.Address)
                Ret.Append(")");

            return Ret.ToString();
        }
        
        
        public int DataSize()
        {
            foreach (ParamInformation Param in Params)
            {
                if (Param.Type == ParamType.RegisterByte)
                    return 8;

                if (Param.Type == ParamType.RegisterWord || Param.Address)
                    return 16;
            }

            return 0;
        }
    }

    class CommandInformation : KeywordInformation
    {
        public CommandInformation(TokenLocation Location = null)
            : base(Location)
        {
            Type = ObjectType.Command;
        }
    }
}
