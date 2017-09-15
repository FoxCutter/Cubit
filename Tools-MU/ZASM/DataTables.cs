﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandList = System.Collections.Generic.SortedList<string, ZASM.CommandID>;

namespace ZASM
{
    class DataTables
    {
        static Comparer<string> CommandListComparer = Comparer<string>.Create((a, b) => string.Compare(a, b, true));

        public static CommandList Commands = new CommandList(CommandListComparer)
        {
            { ".EXTERN",	CommandID.EXTERN },      { ".PUBLIC",	CommandID.PUBLIC },     { ".INCLUDE",   CommandID.INCLUDE },        { ".INCBIN",   CommandID.INCLUDE },     
            { ".Z80",       CommandID.Z80 },         { ".8080",     CommandID.i8080 },      { ".GAMEBOY",   CommandID.GAMEBOY },      
            { ".ORG",       CommandID.ORG },         { ".SECTION",   CommandID.SECTION },   { ".FILL",     CommandID.FILL},             { ".SIZE",   CommandID.SIZE },            
            { ".END",	    CommandID.END },        
        };

        public static CommandList PsudoOpcodes = new CommandList(CommandListComparer)
        {
            { "DB",	        CommandID.BYTE },       { "DW",	        CommandID.WORD },       { "DD",	        CommandID.DWORD },      { "DC",	        CommandID.DC },         
            { "DS",	        CommandID.RESB },       { "RESB",       CommandID.RESB },       { "RESW",       CommandID.RESW },       { "RESD",       CommandID.RESD }, 
            { "EQU",        CommandID.EQU },        { "CONST",	    CommandID.CONST },      { "DEFL",	    CommandID.CONST },       
        };

        public static CommandList z80Opcodes = new CommandList(CommandListComparer)
        {
            { "A",	    CommandID.A },      { "B",	    CommandID.B },      { "C",	    CommandID.C },      { "D",	    CommandID.D },
            { "E",	    CommandID.E },      { "H",	    CommandID.H },      { "L",	    CommandID.L },      { "I",	    CommandID.I },      { "R",	    CommandID.R },
            { "AF",	    CommandID.AF },     { "BC",	    CommandID.BC },     { "DE",	    CommandID.DE },     { "HL",	    CommandID.HL },     { "IX",	    CommandID.IX }, 
            { "IY",	    CommandID.IY },     { "PC",	    CommandID.PC },     { "SP",	    CommandID.SP },     { "SPH",	CommandID.SPH },    { "SPL",	CommandID.SPL },
            { "IXH",	CommandID.IXH },    { "IXL",	CommandID.IXL },    { "IYH",	CommandID.IYH },    { "IYL",	CommandID.IYL },    { "AF'",	CommandID.AF },

            // Flags
            { "CY",	    CommandID.Flag_C },  { "NC",	CommandID.Flag_NC }, { "Z",	    CommandID.Flag_Z },  { "NZ",	CommandID.Flag_NZ }, { "PE",	CommandID.Flag_PE },
            { "PO",	    CommandID.Flag_PO }, { "P",	    CommandID.Flag_P },  { "M",	    CommandID.Flag_M },

            // Opcodes
            { "ADC",	CommandID.ADC },    { "ADD",	CommandID.ADD },    { "AND",	CommandID.AND },    { "BIT",	CommandID.BIT },    { "CALL",	CommandID.CALL },
            { "CCF",	CommandID.CCF },    { "CP",	    CommandID.CP },     { "CPD",	CommandID.CPD },    { "CPDR",	CommandID.CPDR },   { "CPI",	CommandID.CPI },
            { "CPIR",	CommandID.CPIR },   { "CPL",	CommandID.CPL },    { "DAA",	CommandID.DAA },    { "DEC",	CommandID.DEC },    { "DI",	    CommandID.DI },
            { "DJNZ",	CommandID.DJNZ },   { "EI",	    CommandID.EI },     { "EX",	    CommandID.EX },     { "EXX",	CommandID.EXX },    { "HALT",	CommandID.HALT },
            { "IM",	    CommandID.IM },     { "IN",	    CommandID.IN },     { "INC",	CommandID.INC },    { "IND",	CommandID.IND },    { "INDR",	CommandID.INDR },
            { "INI",	CommandID.INI },    { "INIR",	CommandID.INIR },   { "JP",	    CommandID.JP },     { "JR",	    CommandID.JR },     { "LD",	    CommandID.LD },
            { "LDD",	CommandID.LDD },    { "LDDR",	CommandID.LDDR },   { "LDI",	CommandID.LDI },    { "LDIR",	CommandID.LDIR },   { "NEG",	CommandID.NEG },
            { "NOP",	CommandID.NOP },    { "OR",	    CommandID.OR },     { "OTDR",	CommandID.OTDR },   { "OTIR",	CommandID.OTIR },   { "OUT",	CommandID.OUT },
            { "OUTD",	CommandID.OUTD },   { "OUTI",	CommandID.OUTI },   { "POP",	CommandID.POP },    { "PUSH",	CommandID.PUSH },   { "RES",	CommandID.RES },
            { "RET",	CommandID.RET },    { "RETI",	CommandID.RETI },   { "RETN",	CommandID.RETN },   { "RL",	    CommandID.RL },     { "RLA",	CommandID.RLA },
            { "RLC",	CommandID.RLC },    { "RLCA",	CommandID.RLCA },   { "RLD",	CommandID.RLD },    { "RR",	    CommandID.RR },     { "RRA",	CommandID.RRA },
            { "RRC",	CommandID.RRC },    { "RRCA",	CommandID.RRCA },   { "RRD",	CommandID.RRD },    { "RST",	CommandID.RST },    { "SBC",	CommandID.SBC },
            { "SCF",	CommandID.SCF },    { "SET",	CommandID.SET },    { "SLA",	CommandID.SLA },    { "SLL",	CommandID.SLL },    { "SRA",	CommandID.SRA },
            { "SRL",	CommandID.SRL },    { "SUB",	CommandID.SUB },    { "XOR",	CommandID.XOR },
        };


        public static CharacterType[] CharacterData = new CharacterType[]
        {
            CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown,
            CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown,

            CharacterType.Tab,   // Tab

            CharacterType.LineFeed, CharacterType.Unknown, CharacterType.Unknown, CharacterType.CarriageReturn, CharacterType.Unknown, CharacterType.Unknown,
            CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown,
            CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown,
            CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown,

            CharacterType.Space,   // Space
            
            // !"#$% &'()* +,-./
            CharacterType.ExclimationMark, CharacterType.DoubleQuote, CharacterType.PoundSign, CharacterType.DollarSign, CharacterType.PercentSign,
            CharacterType.Ampersand, CharacterType.SingleQuote, CharacterType.ParenthesesLeft, CharacterType.ParenthesesRight, CharacterType.Asterisk,
            CharacterType.Plus, CharacterType.Comma, CharacterType.Minus, CharacterType.Period, CharacterType.Slash,
            
            // 0-9
            CharacterType.Number, CharacterType.Number, CharacterType.Number, CharacterType.Number, CharacterType.Number,
            CharacterType.Number, CharacterType.Number, CharacterType.Number, CharacterType.Number, CharacterType.Number,

            // :;<=> ?@
            CharacterType.Colon, CharacterType.SemiColon, CharacterType.LessThen, CharacterType.Equal, CharacterType.GreaterThen,
            CharacterType.QuestionMark, CharacterType.AtSign,

            // A-Z
            CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier,
            CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier,
            CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier,
            CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier,
            CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier,
            CharacterType.Identifier,

            // [\]^_ `
            CharacterType.BracketLeft, CharacterType.Backslash, CharacterType.BracketRight, CharacterType.Carrot, CharacterType.Identifier,
            CharacterType.ReverseQuote,
            
            // a-z
            CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier,
            CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier,
            CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier,
            CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier,
            CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier, CharacterType.Identifier,
            CharacterType.Identifier,

            // {|}~
            CharacterType.GroupLeft, CharacterType.Pipe, CharacterType.GroupRight, CharacterType.Tilde, CharacterType.Unknown,
        };

        public static Dictionary<MessageCode, string> MessageStrings = new Dictionary<MessageCode, string>()
        { 
            { MessageCode.NoError, "" },
            { MessageCode.UnknownError, "Unknown Error" },
            { MessageCode.InvalidNumberToken, "Invalid character in number" },
            { MessageCode.UnexpectedLineBreak, "Unexpected line break in a string" },

            { MessageCode.UnexpectedSymbol, "Unexpected character encounter in input" },
            { MessageCode.UndefinedSymbol, "Label used but not defined" },

            { MessageCode.InvalidParamaterForOpcode, "Parameter is invalid" },
            { MessageCode.DivisionByZero, "Division by Zero" },
            { MessageCode.ValueMissing, "Value missing in assignment" },
            { MessageCode.MissingGroupSymbol, "Missing group"},
            { MessageCode.DataTypeMisMatch, "Datatype mismatch"},
            { MessageCode.SyntaxError, "Syntax Error"},
            { MessageCode.SyntaxWarning, "Syntax Warning"},
            { MessageCode.RegisterMissingAssumingA, "Register Missing, using 'A'"},
            { MessageCode.InternalError, "Internal Error" },

            { MessageCode.UnknownCommand, "Unknown Command" },
            
        };
    }
}