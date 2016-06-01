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

    class LineInfo
    {
        public Token Label;
        public Token Operator;
        public List<List<Token>> Paramiters = new List<List<Token>>();
    };
    
    class Program
    {
        static void Main(string[] args)
        {
            //string TestLine = " label:  ld, ($0AAh << 8) + 0x55		; Load the byte at the return address into C\n  JP 	NZ, SETUP";
            //System.IO.MemoryStream Data = new System.IO.MemoryStream(UTF8Encoding.UTF8.GetBytes(TestLine));

            var Data = System.IO.File.OpenRead(@"D:\Programing\Code\Cubit\Tools\basic8k78-2.mac");
            

            Tokenizer Temp = new Tokenizer(Data);

            List<Token> LineData = new List<Token>();

            SymbolTable Labels = new SymbolTable();

            int LineNumber = 1;

            LineInfo CurrentLine = new LineInfo();
             
            while (true)
            {
                Token Current = Temp.NextToken();
                if (Current.Type == TokenType.End)
                    break;

                if (Current.Type == TokenType.Label)
                    CurrentLine.Label = Current;

                if (Current.Type == TokenType.Keyword)
                    CurrentLine.Operator = Current;

                if (Current.Type == TokenType.Label || Current.Type == TokenType.Identifier)
                {
                    Labels[Current.ToString()].LineIDs.Add(LineNumber);
                }


                //Console.WriteLine(Current.ToString());
                
                //if (Current.Type == TokenType.Identifier)
                //    Labels.AddName(Current.ToString());

                //if (Current.Type != TokenType.Comment && Current.Type != TokenType.LineBreak) 
                
                //LineData.Add(Current);

                if (Current.Type == TokenType.LineBreak)
                {
                    LineNumber += Current.Value.Count;
                    CurrentLine = new LineInfo();
                }
            };

            //foreach (Token Current in LineData)
            //{
            //    if(Current.Type != TokenType.LineBreak)
            //        Console.WriteLine(" Token Type: {0} Value: {1}", Current.Type.ToString(), Current.ToString());
            //}

            foreach (SymbolTableEntry Entry in Labels)
            {
                Console.WriteLine(" Symbol: {0} Line:", Entry.Symbol);
                foreach (int line in Entry.LineIDs)
                {
                    Console.WriteLine("     {0}", line);
                }
            }
        }
    }
}
