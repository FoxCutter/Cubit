using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    enum Register
    {
        // Not used
        None,
        
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
    };

    enum ConditionCode
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

        public CommandID Function;
    };

    class LineInfo
    {
        public Token Label;
        public Token Operator;
        public List<Stack<Token>> Params = new List<Stack<Token>>();
    };

    enum ParseState
    {
        StartOfLine,
        FoundLabel,
        FoundOperator,
        Params,
        End,
    };
    
    class Program
    {
        static void Main(string[] args)
        {
            //string TestLine = " label:  ld, ($0AAh << 8) + 0x55		; Load the byte at the return address into C\n  JP 	NZ, SETUP";
            //System.IO.MemoryStream Data = new System.IO.MemoryStream(UTF8Encoding.UTF8.GetBytes(TestLine));

            //var Data = System.IO.File.OpenRead(@"D:\Programing\Code\Cubit\Tools\basic8k78-2.mac");
            var Data = System.IO.File.OpenRead(@"..\..\..\basic8k78-2.mac");
            

            Tokenizer Temp = new Tokenizer(Data);

            SymbolTable Labels = new SymbolTable();

            LineInfo CurrentLine = new LineInfo();
            ParseState State = ParseState.StartOfLine;
            Stack<Token> Params = new Stack<Token>();
            Stack<Token> TempStack = new Stack<Token>();
            Token TempToken;
            Token LastToken;
            LastToken.Type = TokenType.End;

            string ParentID = "";
            int Depth = 0;
            bool Memory = false;

            while (true)
            {
                Token Current = Temp.NextToken();
                
                if (Current.Type == TokenType.Label || Current.Type == TokenType.Identifier)
                {
                    if (Current.Value[0] == '.')
                    {
                        Labels[ParentID + Current.ToString()].LineIDs.Add(Current.Line);
                    }
                    else
                    {
                        if(Current.Type == TokenType.Label)
                            ParentID = Current.ToString();
                        
                        Labels[Current.ToString()].LineIDs.Add(Current.Line);
                    }
                }


                if (Current.Type == TokenType.LineBreak || Current.Type == TokenType.Comment || Current.Type == TokenType.End)
                    State = ParseState.End;

                switch (State)
                {
                    case ParseState.StartOfLine:
                        if (Current.Type == TokenType.Label)
                        {
                            CurrentLine.Label = Current;
                            State = ParseState.FoundLabel;
                        }
                        else
                        {
                            goto case ParseState.FoundLabel;                            
                        }
                        break;

                    case ParseState.FoundLabel:
                        if (Current.Type == TokenType.Keyword || Current.Type == TokenType.Identifier)
                        {
                            CurrentLine.Operator = Current;
                            State = ParseState.FoundOperator;
                        }
                        else
                        {
                            State = ParseState.End;
                        }
                        break;

                    case ParseState.FoundOperator:
                        if (Current.Type == TokenType.Keyword && CurrentLine.Label.Type == TokenType.None && CurrentLine.Operator.Type == TokenType.Identifier)
                        {
                            CurrentLine.Label = CurrentLine.Operator;
                            CurrentLine.Operator = Current;

                            Labels[CurrentLine.Label.ToString()].LineIDs.Add(CurrentLine.Label.Line);
                        }
                        else
                        {
                            goto case ParseState.Params;  
                        }
                        break;

                    case ParseState.Params:
                        if (Current.Value[0] == ',' && Depth == 0)
                        {
                            while (TempStack.Count != 0)
                                Params.Push(TempStack.Pop());

                            if (Memory)
                            {
                                TempToken = Current;
                                TempToken.Type = TokenType.Symbol;
                                TempToken.Value[0] = '@';
                                Params.Push(TempToken);
                                Memory = false;
                            }

                            CurrentLine.Params.Add(Params);
                            Params = new Stack<Token>();
                            break;
                        }
                        else if (Current.Value[0] == '(')
                        {
                            if (Params.Count == 0 && TempStack.Count == 0)
                                Memory = true;

                            TempStack.Push(Current);
                            Depth++;
                        }
                        else if (Current.Value[0] == ')')
                        {
                            Depth--;

                            while (TempStack.Count != 0)
                            {
                                TempToken = TempStack.Pop();
                                if (TempToken.Value[0] == '(')
                                    break;

                                Params.Push(TempToken);
                            }

                            if (TempStack.Count != 0 && (TempStack.Peek().Type == TokenType.Keyword || TempStack.Peek().Type == TokenType.Identifier) )
                                Params.Push(TempStack.Pop());

                            if (Depth == 0 && TempStack.Count != 0)
                                Memory = false;

                        }
                        else if (Current.Type == TokenType.Symbol || Current.Type == TokenType.Identifier || Current.Type == TokenType.Keyword)
                        {
                            // Check for an unarray + and -
                            if (Current.Value[0] == '-' || Current.Value[0] == '+' )
                            {
                                if (Params.Count == 0 && TempStack.Count == 0)
                                    Current.Type = TokenType.Unarray;
                                
                                if (LastToken.Type == TokenType.Symbol)
                                    Current.Type = TokenType.Unarray;
                            }

                            TempStack.Push(Current);
                            LastToken = Current;
                        }
                        else
                        {
                            Params.Push(Current);
                            LastToken = Current;
                        }

                        break;
                }


                if (Current.Type == TokenType.LineBreak || Current.Type == TokenType.End)
                {
                    if (Params.Count != 0 || TempStack.Count != 0)
                    {
                        while (TempStack.Count != 0)
                            Params.Push(TempStack.Pop());

                        if (Memory)
                        {
                            TempToken = Current;
                            TempToken.Type = TokenType.Symbol;
                            TempToken.Value[0] = '@';
                            Params.Push(TempToken);
                            Memory = false;
                        }

                        CurrentLine.Params.Add(Params);
                    }

                    //if(CurrentLine.Operator.Type == TokenType.Keyword && CurrentLine.Operator.t
                    
                    // Process line
                    if (CurrentLine.Operator.Type != TokenType.None)
                    {
                        var x = Ops.EncodingData.Where(e => string.Equals(e.Name, CurrentLine.Operator.ToString(), StringComparison.InvariantCultureIgnoreCase));

                        if (x.Count() != 0)
                        {
                            foreach (Stack<Token> Param in CurrentLine.Params)
                            {
                                if (Param.Peek().Value[0] == '@')
                                {
                                    x = x.Where(e => e.Reg1Param.HasFlag(RegParam.Reference));
                                }
                            }
                        }                           
                    }

                    
                    // New Line
                    CurrentLine = new LineInfo();
                    Params = new Stack<Token>();
                    State = ParseState.StartOfLine;
                    Depth = 0;
                }

                if (Current.Type == TokenType.End)
                    break;
            };

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
