using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZASM
{
    class Parser
    {
        enum ParseState
        {
            LabelOrCommand,     // Looking for a Label: or a keyword/macro name
            Command,            // Found a lable, so jsut need a command
            Params,             // Matching Params
            End,                // Nothing
        };

        struct LineInformation
        {
            public Token Label;
            public Token Command;
            public List<Stack<Token>> Params;
            public int AddressParam;

            public void Clear()
            {
                Label = default(Token);
                Command = default(Token);
                AddressParam = -1;

                if (Params == null)
                    Params = new List<Stack<Token>>();
                else
                    Params.Clear();
            }
        };
        
        SymbolTable _SymbolTable;
        Tokenizer _Tokenizer;

        public Parser(Stream InputStream)
        {
            _Tokenizer = new Tokenizer(InputStream);
            _SymbolTable = new SymbolTable();
        }

        public bool Parse()
        {
            LineInformation CurrentLine = new LineInformation();
            List<LineInformation> LineData = new List<LineInformation>();
            
            bool Done = false;

            ParseState CurrentState = ParseState.LabelOrCommand;
            
            Token LastParamToken = default(Token);
            Stack<Token> Params = new Stack<Token>();
            Stack<Token> TempStack = new Stack<Token>();
            int Depth = 0;
            bool Memory = false;

            CurrentLine.Clear();

            while (!Done)
            {
                Token CurrentToken = _Tokenizer.NextToken();
                Token TempToken;

                if (CurrentToken.Type == TokenType.End)
                    Done = true;

                if (CurrentToken.Type == TokenType.Comment)
                    continue;

                // Empty line
                if (CurrentToken.Type == TokenType.LineBreak && CurrentState == ParseState.LabelOrCommand)
                    continue;

                if (CurrentToken.Type == TokenType.Label || CurrentToken.Type == TokenType.Identifier)
                {
                    _SymbolTable[CurrentToken.ToString()].LineIDs.Add(CurrentToken.Line);                    
                }

                if (CurrentToken.IsBreak())
                    CurrentState = ParseState.End;

                switch (CurrentState)
                {
                    case ParseState.LabelOrCommand:
                        if (CurrentToken.IsLabel())
                        {
                            CurrentLine.Label = CurrentToken;
                            CurrentState = ParseState.Command;
                        }
                        else if (CurrentToken.IsCommand())
                        {
                            CurrentLine.Command = CurrentToken;
                            CurrentState = ParseState.Params;
                        }
                        else
                        {
                            // ERROR:
                            CurrentState = ParseState.End;
                        }

                        break;

                    case ParseState.Command:
                        if (CurrentToken.IsCommand())
                        {
                            CurrentLine.Command = CurrentToken;
                            CurrentState = ParseState.Params;
                        }
                        else
                        {
                            // ERROR:
                            CurrentState = ParseState.End;
                        }
                        break;

                    case ParseState.Params:
                        if (CurrentToken.Type == TokenType.Label && CurrentLine.Label.IsEmpty() && CurrentLine.Command.Type == TokenType.Identifier)
                        {
                            // Looks like we had a "label    :" so we need to make it a proper label
                            
                            CurrentLine.Label = CurrentLine.Command;
                            CurrentLine.Label.Type = TokenType.Label;

                            CurrentState = ParseState.Command;
                            break;
                        }
                        else if (CurrentToken.Type == TokenType.Keyword && CurrentLine.Label.IsEmpty() && CurrentLine.Command.Type == TokenType.Identifier)
                        {
                            CurrentLine.Label = CurrentLine.Command;
                            CurrentLine.Command = CurrentToken;

                            _SymbolTable[CurrentLine.Label.ToString()].LineIDs.Add(CurrentLine.Label.Line);
                            break;
                        }

                        if (CurrentToken.Type == TokenType.Comma && Depth == 0)
                        {
                            if (Memory)
                                CurrentLine.AddressParam = CurrentLine.Params.Count;

                            while (TempStack.Count != 0)
                                Params.Push(TempStack.Pop());
                            
                            CurrentLine.Params.Add(Params);

                            Params = new Stack<Token>();
                            LastParamToken.Type = TokenType.None;
                            Memory = false;

                        }
                        else if (CurrentToken.Type == TokenType.Address && LastParamToken.IsEmpty())
                        {
                            CurrentLine.AddressParam = CurrentLine.Params.Count;
                        }
                        else if (CurrentToken.IsGroupLeft())
                        {
                            if(CurrentToken.Type == TokenType.ParenthesesLeft && LastParamToken.IsEmpty())
                                Memory = true;

                            TempStack.Push(CurrentToken);

                            Depth++;
                        }
                        else if (CurrentToken.IsGroupRight())
                        {
                            Depth--;


                            while (TempStack.Count != 0)
                            {
                                TempToken = TempStack.Pop();

                                if (TempToken.IsGroupLeft())
                                    break;

                                Params.Push(TempToken);
                            }

                            if (CurrentToken.Type == TokenType.ParenthesesRight && Depth == 0 && TempStack.Count != 0)
                                Memory = false;

                        }
                        else if (CurrentToken.IsOperator())
                        {
                            // Check for an unarray + and -
                            if (CurrentToken.Type == TokenType.Plus && (LastParamToken.IsEmpty() || LastParamToken.IsOperator()))
                                CurrentToken.Type = TokenType.UnarrayPlus;

                            if (CurrentToken.Type == TokenType.Minus && (LastParamToken.IsEmpty() || LastParamToken.IsOperator()))
                                CurrentToken.Type = TokenType.UnarrayMinus;

                            if (TempStack.Count != 0 && !TempStack.Peek().IsGroup())
                            {
                                int Op1 = 0;
                                int Op2 = 0;

                                Op1 = DataTables.PrecedenceMap[CurrentToken.Type];
                                Op2 = DataTables.PrecedenceMap[TempStack.Peek().Type];

                                if ((Op1 & 0x01) == 0x00)
                                {
                                    if (Op1 >= Op2)
                                        Params.Push(TempStack.Pop());
                                }
                                else
                                {
                                    if (Op1 > Op2)
                                        Params.Push(TempStack.Pop());
                                }
                            }

                            TempStack.Push(CurrentToken);
                            LastParamToken = CurrentToken;
                        }
                        else
                        {
                            Params.Push(CurrentToken);
                            LastParamToken = CurrentToken;
                        }
                        
                        break;
                }
                
                if (CurrentToken.IsBreak())
                {
                    if (Memory)
                        CurrentLine.AddressParam = CurrentLine.Params.Count;

                    while (TempStack.Count != 0)
                        Params.Push(TempStack.Pop());

                    if(Params.Count != 0)
                        CurrentLine.Params.Add(Params);

                    Params = new Stack<Token>();

                    CurrentState = ParseState.LabelOrCommand;
                    
                    LineData.Add(CurrentLine);
                    CurrentLine = new LineInformation();
                    CurrentLine.Clear();
                    LastParamToken.Type = TokenType.None;
                    Memory = false;

                    continue;
                }
            }

            //foreach (SymbolTableEntry Entry in _SymbolTable)
            //{
            //    Console.WriteLine(" Symbol: {0} Line:", Entry.Symbol);
            //    foreach (int line in Entry.LineIDs)
            //    {
            //        Console.WriteLine("     {0}", line);
            //    }
            //}
            foreach(LineInformation Entry in LineData)
            {
                if (!Entry.Label.IsEmpty())
                {
                    Console.Write("{0,-15} ", Entry.Label.ToString() + ":");
                }
                else
                {
                    Console.Write("                ");
                }

                if (!Entry.Command.IsEmpty())
                {
                    Console.Write("{0,-10} ", Entry.Command.ToString());
                }
                else
                {
                    Console.Write("           ");
                }

                for (int x = 0; x < Entry.Params.Count; x++)
                {
                    if(x != 0)
                        Console.Write(", ");

                    if (x == Entry.AddressParam)
                        Console.Write("(");

                    Console.Write(PrintStack(Entry.Params[x].ToList()));

                    //foreach (Token TokenEntry in Entry.Params[x])
                    //{
                    //    Console.Write("{0} ", TokenEntry);
                    //}

                    if (x == Entry.AddressParam)
                        Console.Write(")");
                }

                //Console.WriteLine(" Symbol: {0} Line:", Entry.Symbol);
                Console.WriteLine();
            }

            
             return true;
        }

        StringBuilder PrintStack(List<Token> Params, int Pos = 0)
        {
            StringBuilder Ret = new StringBuilder();
            if (Pos >= Params.Count)
                return Ret;

            Token CurrentToken = Params[Pos];

            if (CurrentToken.IsOperator())
            {
                if (CurrentToken.Type == TokenType.UnarrayMinus || CurrentToken.Type == TokenType.UnarrayPlus)
                {
                    Ret.Append(CurrentToken.ToString());
                    Ret.Append(PrintStack(Params, Pos + 1));
                }
                else
                {
                    //StringBuilder Temp = PrintStack(Params, Pos + 1);
                    //Ret.AppendFormat("{0}", CurrentToken.ToString());
                    //Ret.Append("[");
                    //Ret.Append(PrintStack(Params, Pos + 1));
                    //Ret.Append(",");
                    //Ret.Append(Temp);
                    //Ret.Append("]");

                    
                    StringBuilder Temp = PrintStack(Params, Pos + 1);
                    Ret.Append(PrintStack(Params, Pos + 1));
                    Ret.AppendFormat(" {0} ", CurrentToken.ToString());
                    Ret.Append(Temp);
                }
            }
            else
            {
                Ret.Append(CurrentToken.ToString());
            }


            Params.RemoveAt(Pos);
            return Ret;
        }
    }
}
