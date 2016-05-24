using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z80Emu
{
    class Program
    {
        static void Main(string[] args)
        {
            // 8k of Rom
            Memory SystemMemory = new Memory(0x2000);
            SystemMemory.LoadHex(@"..\..\..\..\z80 Monitor\zout\Monitor.hex");
            
            //Memory SystemMemory = new Memory();
            //SystemMemory.LoadHex(@"..\..\..\..\z80 Monitor\zout\basic8k78-2.hex");

            ExternalIO SystemIO = new ExternalIO();

            Z80 CPU = new Z80(SystemMemory, SystemIO);

            while (!CPU.ExecuteOpcode())
            {
            }

            return;
        }
    }
}
