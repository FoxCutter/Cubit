using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    class NameTableEntry
    {
        public string Value;
        public NameTable ChildTable;
        public int Address;

        public override bool Equals(object obj)
        {
            return string.Equals(Value, obj.ToString());
        }
        
        public override string ToString()
        {
            return Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    };

    class NameTable
    {
        HashSet<NameTableEntry> NameList = new HashSet<NameTableEntry>();
        NameTable Parent = null;

        public NameTable()
        {
        }

        public bool AddName(string Name, int Address = -1)
        {
            NameTableEntry NewEntry = new NameTableEntry();
            NewEntry.Value = Name.ToUpper();
            NewEntry.Address = Address;
            NewEntry.ChildTable = null;

            if (NameList.Contains(NewEntry))
            {
                var ent= NameList.First(e => e.Value == NewEntry.Value);
                //NameList[NewEntry];   

                if (ent.Address == -1 && Address != -1)
                    ent.Address = Address;
                else if(ent.Address == -1)
                    return false;
            }
            else
            {
                NameList.Add(NewEntry);
            }

            return true;
        }
    }
}
