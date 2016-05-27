using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    class DataTables
    {
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
            { ".ENDPROC",   CommandID.ENDPROC},     { ".PHASE",     CommandID.PHASE},       { ".ENDPHASE",  CommandID.ENDPHASE},    { "EQU",        CommandID.EQU},   
        };

        public static CharacterType[] CharacterData = new CharacterType[]
        {
            CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown,
            CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown,

            CharacterType.WhiteSpace,   // Tab

            CharacterType.LineBreak, CharacterType.Unknown, CharacterType.Unknown, CharacterType.LineBreak, CharacterType.Unknown, CharacterType.Unknown,
            CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown,
            CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown,
            CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown, CharacterType.Unknown,

            CharacterType.WhiteSpace,   // Space
            
            // !"#$%&'()*+,-./
            CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol,
            CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol,
            CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol,
            
            // 0-9
            CharacterType.Number, CharacterType.Number, CharacterType.Number, CharacterType.Number, CharacterType.Number,
            CharacterType.Number, CharacterType.Number, CharacterType.Number, CharacterType.Number, CharacterType.Number,

            // :;<=>?@
            CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol,
            CharacterType.Symbol, CharacterType.Symbol,

            // A-Z
            CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter,
            CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter,
            CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter,
            CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter,
            CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter,
            CharacterType.Letter,

            // [\]^_`
            CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol,
            CharacterType.Symbol,
            
            // a-z
            CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter,
            CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter,
            CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter,
            CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter,
            CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter, CharacterType.Letter,
            CharacterType.Letter,

            // {|}~
            CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol, CharacterType.Symbol, CharacterType.Unknown,
        };
    }
}
