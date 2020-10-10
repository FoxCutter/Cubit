using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    static class Debug
    {
        static bool Enabled = true;

        public static void WriteLine(string Line)
        {
            if (!Enabled)
                return;

            Console.WriteLine(Line);
        }

        public static void WriteLine()
        {
            if (!Enabled)
                return;

            Console.WriteLine();
        }

        public static void Write(string Line)
        {
            if (!Enabled)
                return;

            Console.Write(Line);
        }
    }
}
