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
        ////Macro,
        ////Procedure,
        Opcode,
        Command,
        Data,

        //Meta,

        //// Meta types after this one
        //File,
        //Line,
        //Offset,
    }
        
    class ObjectInformation
    {
        public ObjectType Type  { get; private set; }
        public int FileID;
        public int Line;
        public int Character;

        public bool Error;
        
        public List<Token> TokenList;

        public ObjectInformation(Token CurrentToken, ObjectType ofType = ObjectType.None)
        {
            Error = false;

            FileID = CurrentToken.FileID;
            Line = CurrentToken.Line;
            Character = CurrentToken.Character;
            Type = ofType;

            TokenList = new List<Token>();
            TokenList.Add(CurrentToken);
        }
    }

    class LabelInformation : ObjectInformation
    {
        public SymbolTableEntry Symbol;
        public int Address;

        public LabelInformation(Token CurrentToken, SymbolTableEntry Symbol)
            : base(CurrentToken, ObjectType.Label)
        {
            this.Symbol = Symbol;
            Address = 0;
        }

        public override string ToString()
        {
            return Symbol.Name + ":";
        }
    }

    class ParamInformation : ObjectInformation
    {
        public List<ParameterInformation> Params;
        
        public ParamInformation(Token CurrentToken, ObjectType ofType = ObjectType.None)
            : base(CurrentToken, ofType)
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

    class ValueInformation : ParamInformation
    {
        public SymbolTableEntry Symbol;
        public short Value;

        public ValueInformation(Token CurrentToken, SymbolTableEntry Symbol)
            : base(CurrentToken, ObjectType.Value)
        {
            this.Symbol = Symbol;
            Value = 0;
        }

        public override string ToString()
        {
            if(Symbol.State == SymbolState.ValueSet)
                return Symbol.Name + " = 0x" + Value.ToString("X");
            else
                return Symbol.Name + " = " + base.ToString();
        }

        public string ToValueString()
        {
            if (Symbol.State == SymbolState.ValueSet)
                return "0x" + Value.ToString("X");
            else
                return base.ToString();
        }
    }

    class DataInformation : ParamInformation
    {
        public CommandID DataType;

        public DataInformation(Token CurrentToken)
            : base(CurrentToken, ObjectType.Data)
        {
            this.DataType = CurrentToken.CommandID;
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

        public override string ToString()
        {
            return DataType.ToString() + " " + base.ToString();
        }
    }

    class CommandInformation : ParamInformation
    {
        public CommandID Command;

        public CommandInformation(Token CurrentToken)
            : base(CurrentToken, ObjectType.Command)
        {
            Command = CurrentToken.CommandID;
        }

        public override string ToString()
        {
            return Command.ToString() + " " + base.ToString();
        }
    }

    class OpcodeInformation : ParamInformation
    {
        public CommandID Opcode;

        public OpcodeInformation(Token CurrentToken)
            : base(CurrentToken, ObjectType.Opcode)
        {
            Opcode = CurrentToken.CommandID;
        }

        public override string ToString()
        {
            return Opcode.ToString() + " " + base.ToString();
        }
    }
}
