using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    enum Register
    {
        // 8-bit Registers and Indexs into the register array
        A,
        F,
        B,
        C,
        D,
        E,
        H, L,
        SPH, SPL,
        PCH, PCL,
        IXH, IXL,
        IYH, IYL,
        I,
        R,

        // Count of 8-bit registers
        RegisterCount,

        // 16-bit Registers
        Word = 0x20,
        AF = Word + A,
        BC = Word + B,
        DE = Word + D,
        HL = Word + H,
        SP = Word + SPH,
        PC = Word + PCH,
        IX = Word + IXH,
        IY = Word + IXH,

        // Index register (can be HL, IX, IY)
        HX = 0x40,

        // Index register low (can be L, IXL, IYL)
        XL,

        // Index register high (can be H, IXH, IYH)
        XH,

        // Index register with Displacment (assuming it's IX or IY)
        HD,

        // Immediate data
        Immediate = 0x80,
        ImmediateByte = Immediate,
        ImmediateWord = Immediate,

        // Not used
        None = 0xFF,
    };

    enum ConditionCode : byte
    {
        NZ,     // Non Zero     (Z = 0)
        Z,      // Zero         (Z = 1)
        NC,     // No Carry     (C = 0)
        CY,     // Carry        (C = 1)
        PO,     // Parity Odd   (P = 0)
        PE,     // Parity Even  (P = 1)
        P,      // Positive     (S = 0)
        M,      // Negative     (S = 1)
    }

    [Flags]
    enum RegParam : byte
    {
        None = 0x00,     // No flags on this register
        Reference = 0x01,     // Memory Reference (Memory, BC, DE, HL, SP, IX, IY, nn)
        WordData = 0x02,     // The Referenced data is Word sized, not byte
        Literal = 0x04,     // The byte value in the register is used as the input value
        ConditionCode = 0x08,     // The Byte value in the register is the condition code to test for
    }

    enum Operation
    {
        ADC, ADD, AND, BIT, CALL, CCF, CP, CPD, CPDR, CPI, CPIR, CPL, DAA, DEC, DI, DJNZ,
        EI, EX, EXX, HALT, IM, IN, INC, IND, INDR, INI, INIR, JP, JR, LD, LDD, LDDR, LDI,
        LDIR, NEG, NOP, OR, OTDR, OTIR, OUT, OUTD, OUTI, POP, PUSH, RES, RET, RETI, RETN,
        RL, RLA, RLC, RLCA, RLD, RR, RRA, RRC, RRCA, RRD, RST, SBC, SCF, SET, SLA, SLL,
        SRA, SRL, SUB, XOR, Error
    }

    struct OpcodeEncoding
    {
        public string Name;

        public byte[] Encoding;

        public Register Reg1;
        public RegParam Reg1Param;

        public Register Reg2;
        public RegParam Reg2Param;

        public Operation Function;
    };
    
    class Program
    {
        static List<string> Keywords = new List<string>
        {
            "A", "ADC", "ADD", "AF", "AND", "B", "BC", "BIT", "C", "CALL", "CCF", "CP", "CPD", "CPDR", "CPI",
            "CPIR", "CPL", "D", "DAA", "DE", "DEC", "DI", "DJNZ", "E", "EI", "EX", "EXX", "F", "H", "HALT",
            "HL", "I", "IM", "IN", "INC", "IND", "INDR", "INI", "INIR", "IX", "IXH", "IXL", "IY", "IYH",
            "IYL", "JP", "JR", "L", "LD", "LDD", "LDDR", "LDI", "LDIR", "M", "NC", "NEG", "NOP", "NZ", "OR",
            "OTDR", "OTIR", "OUT", "OUTD", "OUTI", "P", "PC", "PE", "PO", "POP", "PUSH", "R", "RES", "RET",
            "RETI", "RETN", "RL", "RLA", "RLC", "RLCA", "RLD", "RR", "RRA", "RRC", "RRCA", "RRD", "RST",
            "SBC", "SCF", "SET", "SLA", "SLL", "SP", "SPH", "SPL", "SRA", "SRL", "SUB", "XOR", "Z",
        };
        
        //static string[][] Keywords = new string[][]
        //{
        //    new string[] 
        //    {
        //        "A", "B", "C", "D", "E", "F", "H", "I", "L", "M", "P", "R", "Z",
        //    },

        //    new string[] 
        //    {
        //        "AF", "BC", "CP", "DE", "DI", "EI", "EX", "HL", "IM", "IN", "IX", "IY", "JP", "JR", "LD", "NC",
        //        "NZ", "OR", "PC", "PE", "PO", "RL", "RR", "SP",
        //    },

        //    new string[] 
        //    {
        //        "ADC", "ADD", "AND", "BIT", "CCF", "CPD", "CPI", "CPL", "DAA", "DEC", "EXX", "INC", "IND", "INI",
        //        "IXH", "IXL", "IYH", "IYL", "LDD", "LDI", "NEG", "NOP", "OUT", "POP", "RES", "RET", "RLA", "RLC",
        //        "RLD", "RRA", "RRC", "RRD", "RST", "SBC", "SCF", "SET", "SLA", "SLL", "SPH", "SPL", "SRA", "SRL",
        //        "SUB", "XOR",
        //    },

        //    new string[] 
        //    {
        //        "CALL", "CPDR", "CPIR", "DJNZ", "HALT", "INDR", "INIR", "LDDR", "LDIR", "OTDR", "OTIR", "OUTD",
        //        "OUTI", "PUSH", "RETI", "RETN", "RLCA", "RRCA",
        //    }
        //};
        
        static void Main(string[] args)
        {
            string TestLine = " label:  ld, ($0AAh)		; Load the byte at the return address into C\n  JP 	NZ, SETUP";

            var Data = System.IO.File.OpenRead(@"D:\Test\DCP\Other\SystemDev\AntiMonitor\basic8k78-2.mac");
            
            //System.IO.MemoryStream Data = new System.IO.MemoryStream(UTF8Encoding.UTF8.GetBytes(TestLine));

            Tokenizer Temp = new Tokenizer(Data);

            List<Token> LineData = new List<Token>();

            NameTable Labels = new NameTable();

            int Address = 0;

            while (true)
            {
                Token Current = Temp.NextToken();
                if (Current.Type == TokenType.End)
                    break;

                if(Current.Type == TokenType.Label)
                    Labels.AddName(Current.ToString(), Address);

                if (Current.Type == TokenType.Identifier)
                    Labels.AddName(Current.ToString());

                if (Current.Type != TokenType.Comment && Current.Type != TokenType.LineBreak) 
                    LineData.Add(Current);

                if (Current.Type == TokenType.LineBreak)
                    Address++;
            };

            foreach (Token Current in LineData)
            {
                Console.WriteLine(" Token Type: {0} Value: \"{1}\"", Current.Type.ToString(), Current.ToString());
            }
        }
    }
}
