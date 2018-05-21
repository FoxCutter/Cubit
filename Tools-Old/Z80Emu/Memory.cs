using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Z80Emu
{
    public class Memory
    {
        ushort RamBottom;
        ushort RamTop;

        byte[] MemorySpace = new byte[65536];

        public Memory(ushort LowestRam = 0, ushort HighestRam = 0xFFFF)
        {
            RamBottom = LowestRam;
            RamTop = HighestRam;
            Array.Clear(MemorySpace, 0, MemorySpace.Length);
        }

        public void LoadHex(string FileName)
        {
            var HexData = File.ReadAllLines(FileName);
            foreach (string Line in HexData)
            {
                if (Line[0] != ':')
                    break;

                int Count = Convert.ToInt32(Line.Substring(1, 2), 16);
                int Address = Convert.ToInt32(Line.Substring(3, 4), 16);
                int Type = Convert.ToInt32(Line.Substring(7, 2), 16);

                if (Type == 01)
                    break;

                int Pos = 9;
                for (int x = 0; x < Count; x++, Pos += 2)
                {
                    MemorySpace[Address + x] = (byte)Convert.ToInt16(Line.Substring(Pos, 2), 16);
                }
            }
        }

        public byte this[ushort address]
        {
            get { return MemorySpace[address]; }
            set 
            { 
                if(address >= RamBottom && RamBottom <= RamTop)                
                    MemorySpace[address] = value; 
            }
        }
    }
}
