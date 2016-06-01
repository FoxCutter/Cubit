using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    class SymbolTableEntry
    {
        public string Symbol { get; set; }
        public List<int> LineIDs { get; set; }

        public SymbolTableEntry(string Name = "")
        {
            Symbol = Name;
            LineIDs = new List<int>();
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
                    NameList[Name.ToUpper()] = new SymbolTableEntry(Name);
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
