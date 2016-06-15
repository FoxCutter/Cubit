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
        Address,
        Function,
        Macro,
        Undefined,
    }
    
    class SymbolTableEntry
    {
        public string Symbol { get; set; }
        public List<ObjectInformation> LineIDs { get; set; }

        public ObjectInformation DefinedLine { get; set; }
        public SymbolType Type { get; set; }
        public long Value { get; set; }

        public SymbolTableEntry(string Name = "", SymbolType InitialType = SymbolType.None)
        {
            Type = InitialType;
            Symbol = Name;
            LineIDs = new List<ObjectInformation>();
            Value = 0;

            DefinedLine = null;
        }
    };

    class SymbolTable : IEnumerable<SymbolTableEntry>
    {
        Dictionary<string, SymbolTableEntry> NameList = new Dictionary<string, SymbolTableEntry>();

        public SymbolTable() 
        {
        }

        public SymbolTableEntry this[string Name]
        {
            get 
            {
                if (!NameList.ContainsKey(Name.ToUpper()))
                {
                    NameList[Name.ToUpper()] = new SymbolTableEntry(Name, SymbolType.Undefined);
                }

                return NameList[Name.ToUpper()];
            }
            
            set 
            {
                NameList[Name.ToUpper()] = value;            
            }
        }

        public IEnumerator<SymbolTableEntry> GetEnumerator()
        {
            return NameList.Values.OrderBy(e => e.Symbol.ToUpper()).GetEnumerator();

            //return NameList.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return NameList.Values.GetEnumerator();
        }
    }
}
