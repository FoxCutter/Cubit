using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z80Emu
{
    public class ExternalIO
    {
        bool DLAB = false;
        
        public byte ReadPort(ushort Address)
        {
            byte Result = 0;
            
            if ((Address & 0xFF) == 0x10)
            {
                if (!DLAB)
                {
                    if (Console.KeyAvailable)
                        Result = (byte)Console.ReadKey(true).KeyChar;
                }
            }
            else if ((Address & 0xFF) == 0x15)
            {
                if (Console.KeyAvailable)
                    Result = 0x41;
                else
                    Result = 0x40;
            }

            return Result;
        }

        public void WritePort(ushort Address, short Value)
        {
            if ((Address & 0xFF) == 0x13)
            {
                DLAB = Value == 0x80;
            }
            else if ((Address & 0xFF) == 0x10)
            {
                if (!DLAB)
                {
                    Console.Write((char)Value);
                }
            }
        }
    }
}
