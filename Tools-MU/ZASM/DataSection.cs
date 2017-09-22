using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    class DataSection
    {
        // The name of the section (Optinoal)
        public string Name;

        // The placement of this block in the output, if not provide will follow right after the last block (-1 = I don't care)
        public int Placement;

        // The max size of this section, will be padded to this length when writen out.
        public int Size;

        // Byte to fill empty space with if there is a need to pad the section
        public byte EmptyFill;

        // Current address in this section
        public int CurrentOffset;
        
        // Object list
        public List<ObjectInformation> ObjectData;

        public DataSection(string SectionName)
        {
            Name = SectionName;
            Placement = -1;
            Size = -1;
            EmptyFill = 0x00;
            CurrentOffset = 0;
            ObjectData = new List<ObjectInformation>();
        }

    }
}
