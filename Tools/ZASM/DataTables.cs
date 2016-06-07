using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    class DataTables
    {
        public static Dictionary<TokenType, int> PrecedenceMap = new Dictionary<TokenType, int>()
        {
            { TokenType.Command,            20 },   { TokenType.Keyword,            20 },
            { TokenType.BracketLeft,        20 },   { TokenType.BracketRight,       20 },
            { TokenType.High,               21 },   { TokenType.Low,                21 },
            { TokenType.UnarrayPlus,        31 },   { TokenType.UnarrayMinus,       31 },   { TokenType.LogicalNot,     31 },   { TokenType.BitwiseNot,     31 },   { TokenType.Address,    31 },
            { TokenType.Multiplication,     50 },   { TokenType.Division,           50 },   { TokenType.Remainder,      50 },   
            { TokenType.Plus,               60 },   { TokenType.Minus,              60 },
            { TokenType.LeftShift,          70 },   { TokenType.RightShift,         70 },
            { TokenType.LessThen,           80 },   { TokenType.LessEqual,          80 },   { TokenType.GreaterThen,    80 },   { TokenType.GreaterEqual,   80 },
            { TokenType.Equal,              90 },   { TokenType.NotEqual,           90 },
            { TokenType.BitwiseAnd,         100 },   
            { TokenType.BitwiseXOR,         111 },   
            { TokenType.BitwiseOR,          120 },   
            { TokenType.LogicalAnd,         130 },   
            { TokenType.LogicalOR,          140 },   
            { TokenType.Ternary,            151 },   
            { TokenType.Comma,              160 },   
        };
        
        //static Dictionary<string, CommandID> Commands = new Dictionary<string, CommandID>(Comparer<string>.Create(a, b => string.Compare(a, b, true))
        public static SortedList<string, CommandID> Commands = new SortedList<string, CommandID>(Comparer<string>.Create((a, b) => string.Compare(a, b, true)))
        {
            // Register    
            { "A",	    CommandID.A },      { "F",	    CommandID.F },      { "B",	    CommandID.B },      { "C",	    CommandID.C },      { "D",	    CommandID.D },
            { "E",	    CommandID.E },      { "H",	    CommandID.H },      { "L",	    CommandID.L },      { "I",	    CommandID.I },      { "R",	    CommandID.R },
            { "AF",	    CommandID.AF },     { "BC",	    CommandID.BC },     { "DE",	    CommandID.DE },     { "HL",	    CommandID.HL },     { "IX",	    CommandID.IX }, 
            { "IY",	    CommandID.IY },     { "PC",	    CommandID.PC },     { "SP",	    CommandID.SP },     { "SPH",	CommandID.SPH },    { "SPL",	CommandID.SPL },
            { "IXH",	CommandID.IXH },    { "IXL",	CommandID.IXL },    { "IYH",	CommandID.IYH },    { "IYL",	CommandID.IYL },

            // Flags
            { "CY",	    CommandID.CY },     { "NC",	    CommandID.NC },     { "Z",	    CommandID.Z },      { "NZ",	    CommandID.NZ },     { "PE",	    CommandID.PE },
            { "PO",	    CommandID.PO },     { "P",	    CommandID.P },      { "M",	    CommandID.M },

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
            
            // Commands
            { "HIGH",	    CommandID.HIGH },       { "LOW",	    CommandID.LOW },        { ".BYTE",	    CommandID.BYTE },       { ".WORD",	    CommandID.WORD },
            { ".DB",	    CommandID.BYTE },       { ".DW",	    CommandID.WORD },       { ".DC",	    CommandID.DC },         { ".DEFS",	    CommandID.DEFS },
            { ".INCLUDE",   CommandID.INCLUDE},     { ".MESSAGE",   CommandID.MESSAGE},     { ".ERROR",     CommandID.ERROR},       { ".OPTION",    CommandID.OPTION},
            { ".ORG",       CommandID.ORG},         { ".IF",        CommandID.IF},          { ".ELSE",      CommandID.ELSE},        { ".ELSEIF",    CommandID.ELSEIF},
            { ".ENDIF",     CommandID.ENDIF},       { ".MACRO",     CommandID.MACRO},       { ".ENDMACRO",  CommandID.ENDMACRO},    { ".PROC",      CommandID.PROC},
            { ".ENDPROC",   CommandID.ENDPROC},     { ".PHASE",     CommandID.PHASE},       { ".ENDPHASE",  CommandID.ENDPHASE},    { ".EQU",       CommandID.EQU},   
            { ".DS",	    CommandID.DEFS },       { "EQU",        CommandID.EQU},         { "PROC",       CommandID.PROC},        { "ENDPROC",    CommandID.ENDPROC},     
            { "DB",	        CommandID.BYTE },       { "DW",	        CommandID.WORD },       { "DC",	        CommandID.DC },         { "DS",	        CommandID.DEFS },
            { "END",	    CommandID.END },        { ".END",	    CommandID.END },        { ".Z80",       CommandID.Z80},         { ".8080",      CommandID.i8080},
        };

        public static TokenType[] CharacterData = new TokenType[]
        {
            TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown,
            TokenType.Unknown, TokenType.Unknown, TokenType.Unknown,

            TokenType.WhiteSpace,   // Tab

            TokenType.LineBreak, TokenType.Unknown, TokenType.Unknown, TokenType.LineBreak, TokenType.Unknown, TokenType.Unknown,
            TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown,
            TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown,
            TokenType.Unknown, TokenType.Unknown, TokenType.Unknown, TokenType.Unknown,

            TokenType.WhiteSpace,   // Space
            
            // !"#$% &'()* +,-./
            TokenType.LogicalNot, TokenType.String, TokenType.Symbol, TokenType.Number, TokenType.Remainder,
            TokenType.BitwiseAnd, TokenType.String, TokenType.ParenthesesLeft, TokenType.ParenthesesRight, TokenType.Multiplication,
            TokenType.Plus, TokenType.Comma, TokenType.Minus, TokenType.Period, TokenType.Division,
            
            // 0-9
            TokenType.Number, TokenType.Number, TokenType.Number, TokenType.Number, TokenType.Number,
            TokenType.Number, TokenType.Number, TokenType.Number, TokenType.Number, TokenType.Number,

            // :;<=> ?@
            TokenType.Colon, TokenType.Comment, TokenType.LessThen, TokenType.Equal, TokenType.GreaterThen,
            TokenType.Symbol, TokenType.Address,

            // A-Z
            TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier,
            TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier,
            TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier,
            TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier,
            TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier,
            TokenType.Identifier,

            // [\]^_ `
            TokenType.BracketLeft, TokenType.Symbol, TokenType.BracketRight, TokenType.BitwiseXOR, TokenType.Identifier,
            TokenType.String,
            
            // a-z
            TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier,
            TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier,
            TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier,
            TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier,
            TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier, TokenType.Identifier,
            TokenType.Identifier,

            // {|}~
            TokenType.GroupLeft, TokenType.BitwiseOR, TokenType.GroupRight, TokenType.BitwiseNot, TokenType.Unknown,
        };
    }
}
