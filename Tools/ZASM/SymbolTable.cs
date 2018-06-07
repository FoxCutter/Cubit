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

        // A symbol with a defined value (that can change)
        Value,

        // A symbol with a fixed value
        Constant, 

        // An address label
        Address,

        // A Forward referenc to a symbol, but one we know nothnig about.
        Forward,
    };

    enum SymbolState
    {
        Undefined,
        
        // We don't have a value for the symbol yet
        Pending,

        // We have a value for the symbol
        Set,
    }
    
    class SymbolTableEntry
    {
        public string Name;
        public SymbolType Type;
        public SymbolState State;
        public int Value;

        public LineInformation DefiendLine;

        public ObjectInformation Object;
        
        public List<LineInformation> ReferencedLines;

        public SymbolTableEntry(string SymbolName)
        {
            Name = SymbolName;
            Type = SymbolType.None;
            DefiendLine = null;

            State = SymbolState.Undefined;
            Object = null;

            ReferencedLines = new List<LineInformation>();           
        }

        public override string ToString()
        {
            return Name + ":" + Type.ToString() + "-" + State.ToString();
        }
    }

    class SymbolTable : IEnumerable<SymbolTableEntry>
    {
        Dictionary<string, SymbolTableEntry> NameList = new Dictionary<string, SymbolTableEntry>(StringComparer.OrdinalIgnoreCase);

        public SymbolTableEntry this[string SymbolName]
        {
            get
            {
                if (!NameList.ContainsKey(SymbolName))
                {
                    NameList[SymbolName] = new SymbolTableEntry(SymbolName);
                }

                return NameList[SymbolName];
            }

            set
            {
                NameList[SymbolName] = value;
            }
        }

        public IEnumerator<SymbolTableEntry> GetEnumerator()
        {
            return NameList.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return NameList.Values.GetEnumerator();
        }
    }
}
