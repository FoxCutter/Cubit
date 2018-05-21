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
        Value,
        Constant,
        Address,
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

        public int DefinedLine;

        public List<int> LineIDs;

        public ObjectInformation Object;
        
        public SymbolTableEntry(string SymbolName = "", SymbolType InitialType = SymbolType.None)
        {
            Name = SymbolName;
            Type = InitialType;
            State = Name == "" ? SymbolState.Empty : SymbolState.Undefined;

            LineIDs = new List<int>();

            DefinedLine = 0;
            Object = null;
        }
    };

    class SymbolTable : IEnumerable<SymbolTableEntry>
    {
        Dictionary<string, SymbolTableEntry> NameList = new Dictionary<string, SymbolTableEntry>();

        public SymbolTable()
        {
        }

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
