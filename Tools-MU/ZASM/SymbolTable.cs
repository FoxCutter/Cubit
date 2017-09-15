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
        Constast,

        // The symbol is an address
        Address,
    }

    class SymbolTableEntry
    {
        public string Name;
        public SymbolType Type;
        public int FileID;
        public int Line;

        public SymbolTableEntry(string SymbolName = "", SymbolType InitialType = SymbolType.None)
        {
            Name = SymbolName;
            Type = InitialType;
            FileID = -1;
            Line = -1;

            //State = Name == "" ? SymbolState.Empty : SymbolState.Undefined;
            //Object = null;
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
