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
        //Value,
        ////Macro,
        ////Procedure,
        //Opcode,
        //Command,
        //Data,

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

    class ValueInformation : ObjectInformation
    {
        public SymbolTableEntry Symbol;
        public int Value;

        public ValueInformation(Token CurrentToken, SymbolTableEntry Symbol)
            : base(CurrentToken, ObjectType.Label)
        {
            this.Symbol = Symbol;
            Value = 0;
        }

        public override string ToString()
        {
            return Symbol.Name + " = 0x" + Value.ToString("X");
        }
    }
}
