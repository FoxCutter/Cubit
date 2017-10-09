using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    enum SymbolType
    {
        None,        
        
        // A symbol with a defined value
        Value,
        
        // A symbol with a fixed value
        Constant,

        // The symbol is an address
        Address,

        // A symbol that has been used as a param, but we know nothing about it.
        Unknown,
    }

    enum SymbolState
    {
        // The Symbol has no values associated with it and represents nothing
        Empty,

        // The Symbol is known but undefined, 
        Undefined,

        // Object is non-null, but may need additinal processing to produce a value
        ValuePending,

        // The object is Non-null and has a finalized/current value.
        ValueSet,
    }
    
    class SymbolTableEntry
    {
        public string Name;
        public SymbolType Type;
        public SymbolState State;
        public int FileID;
        public int Line;

        public List<Tuple<int, int>> RefrencedLines;
        public ObjectInformation Object;

        public SymbolTableEntry(string SymbolName = "", SymbolType InitialType = SymbolType.None)
        {
            Name = SymbolName;
            Type = InitialType;
            FileID = -1;
            Line = -1;

            State = Name == "" ? SymbolState.Empty : SymbolState.Undefined;
            Object = null;

            RefrencedLines = new List<Tuple<int, int>>();
        }

        public override string ToString()
        {
            return Name + ":" + Type.ToString() + "-" + State.ToString();
        }
    }

    class SymbolTable : IEnumerable<SymbolTableEntry>
    {
        Dictionary<string, SymbolTableEntry> NameList = new Dictionary<string, SymbolTableEntry>();

        public SymbolTableEntry this[string SymbolName]
        {
            get
            {
                if (!NameList.ContainsKey(SymbolName.ToUpper()))
                {
                    NameList[SymbolName.ToUpper()] = new SymbolTableEntry(SymbolName, SymbolType.None);
                }

                return NameList[SymbolName.ToUpper()];
            }

            set
            {
                NameList[SymbolName.ToUpper()] = value;
            }
        }
        
        public IEnumerator<SymbolTableEntry> GetEnumerator()
        {
            //return NameList.Values.OrderBy(e => e.Symbol.ToUpper()).GetEnumerator();
            return NameList.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return NameList.Values.GetEnumerator();
        }
    }
}
