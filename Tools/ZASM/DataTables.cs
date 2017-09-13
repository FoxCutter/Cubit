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
            { TokenType.Command,            2 },   { TokenType.Opcode,             2 },   { TokenType.Register,       2},   { TokenType.Flag,          2 },
            { TokenType.BracketLeft,        2 },   { TokenType.BracketRight,       2 },
            { TokenType.High,               2 },   { TokenType.Low,                2 },
            { TokenType.UnarrayPlus,        3 },   { TokenType.UnarrayMinus,       3 },   { TokenType.LogicalNot,     3 },   { TokenType.BitwiseNot,     3 },   
            { TokenType.Multiplication,     5 },   { TokenType.Division,           5 },   { TokenType.Remainder,      5 },   
            { TokenType.Plus,               6 },   { TokenType.Minus,              6 },
            { TokenType.LeftShift,          7 },   { TokenType.RightShift,         7 },
            { TokenType.LessThen,           8 },   { TokenType.LessEqual,          8 },   { TokenType.GreaterThen,    8 },   { TokenType.GreaterEqual,   8 },
            { TokenType.Equal,              9 },   { TokenType.NotEqual,           9 },
            { TokenType.BitwiseAnd,         10 },   
            { TokenType.BitwiseXOR,         11 },   
            { TokenType.BitwiseOR,          12 },   
            { TokenType.LogicalAnd,         13 },   
            { TokenType.LogicalOR,          14 },   
            { TokenType.Ternary,            15 },   
            { TokenType.Comma,              16 },   
            { TokenType.Address,            20 },
        };

        public static SortedList<string, CommandID> Common = new SortedList<string, CommandID>(Comparer<string>.Create((a, b) => string.Compare(a, b, true)))
        {
            // Speical Opperators
            { "HIGH",	    CommandID.HIGH },       { "LOW",	    CommandID.LOW },        { "TIMES",	    CommandID.TIMES },        
            
            // Psudo ops            
            { "DB",	        CommandID.BYTE },       { "DW",	        CommandID.WORD },       { "DD",	        CommandID.DWORD },      { "DC",	        CommandID.DC },         
            { "DS",	        CommandID.RESB },       { "RESB",       CommandID.RESB },       { "RESW",       CommandID.RESW },       { "RESD",       CommandID.RESD }, 
            { "EQU",        CommandID.EQU },        { "CONST",	    CommandID.CONST },      { "DEFL",	    CommandID.CONST },       

            // Commands
            //{ "PROC",       CommandID.PROC },        { "ENDPROC",   CommandID.ENDPROC },    { "CALLPROC",   CommandID.CALLPROC },
            //{ "STRUCT",     CommandID.STRUCT },      { "ENDSTRUCT", CommandID.ENDSTRUCT },
                        
            // Directives
            { ".EXTERN",	CommandID.EXTERN },      { ".PUBLIC",	CommandID.PUBLIC },
            { ".INCLUDE",   CommandID.INCLUDE },     { ".INCBIN",   CommandID.INCLUDE },     
            { ".Z80",       CommandID.Z80 },         { ".8080",     CommandID.i8080 },     
            { ".ORG",       CommandID.ORG },        
            { ".SECTION",   CommandID.SECTION },     { ".FILL",     CommandID.FILL},        { ".SIZE",   CommandID.SIZE },
            
            { ".END",	    CommandID.END },        

        };

        public static SortedList<string, CommandID> i8080Opcodes = new SortedList<string, CommandID>(Comparer<string>.Create((a, b) => string.Compare(a, b, true)))
        {
            // Registers  
            { "A",	    CommandID.A },      { "B",	    CommandID.B },      { "C",	    CommandID.C },      { "D",	    CommandID.D },
            { "E",	    CommandID.E },      { "H",	    CommandID.H },      { "L",	    CommandID.L },      
            { "PSW",    CommandID.AF },     { "BC",	    CommandID.BC },     { "DE",	    CommandID.DE },     { "HL",	    CommandID.HL },     { "M",	    CommandID.HL },     
            { "SP",	    CommandID.SP },    

            // Flags
            { "CY",	    CommandID.Flag_C },      { "NC",	CommandID.Flag_NC },     { "Z",	    CommandID.Flag_Z },      { "NZ",	    CommandID.Flag_NZ },     { "PE",	    CommandID.Flag_PE },
            { "PO",	    CommandID.Flag_PO },     { "P",	    CommandID.Flag_P },     

            // Opcodes
            { "ADC",	CommandID.ADC },    { "ACI",	CommandID.ACI },    { "ADD",	CommandID.ADD },    { "ADI",	CommandID.ADI },    
            { "ANA",	CommandID.ANA },    { "ANI",	CommandID.AND },                

            { "CALL",	CommandID.CALL },   
            { "CNZ",    CommandID.CNZ },    { "CZ",	    CommandID.CZ },     { "CNC",    CommandID.CNC },    { "CC",	    CommandID.CC },
            { "CPO",    CommandID.CPO },    { "CPE",	CommandID.CPE },    { "CP",     CommandID.CP },     { "CM",	    CommandID.CM },

            { "CMA",	CommandID.CMA },    { "CMC",	CommandID.CMC },    
            { "CMP",	CommandID.CMP },    { "CPI",	CommandID.CPI },     
            
            { "DAA",	CommandID.DAA },    { "DAD",	CommandID.DAD },                

            { "DCR",	CommandID.DCR },    { "DCX",	CommandID.DCX },    

            { "DI",	    CommandID.DI },     { "EI",	    CommandID.EI },     { "HALT",	CommandID.HALT },   { "IN",	    CommandID.IN },     

            { "INR",	CommandID.INR },    { "INX",	CommandID.INX },  

            { "JMP",    CommandID.JMP }, 
            { "JNZ",    CommandID.JNZ },    { "JZ",	    CommandID.JZ },     { "JNC",    CommandID.JNC },    { "JC",	    CommandID.JC },
            { "JPO",    CommandID.JPO },    { "JPE",	CommandID.JPE },    { "JP",     CommandID.JP },     { "JM",	    CommandID.JM },

            { "LDA",	CommandID.LDA },    { "LXI",    CommandID.LXI },   { "LDAX",    CommandID.LDAX },   { "LHLD",    CommandID.LHLD },
            { "MOV",	CommandID.MOV },    { "MVI",	CommandID.MVI },     

            { "NOP",	CommandID.NOP },
            { "ORA",	CommandID.ORA },     { "ORI",    CommandID.ORI },
            { "OUT",	CommandID.OUT },
            { "PCHL",   CommandID.PCHL }, 
            { "POP",	CommandID.POP },    { "PUSH",	CommandID.PUSH },
            { "RAL",	CommandID.RAL },    { "RAR",	CommandID.RAR },
            { "RET",	CommandID.RET },
            { "RNZ",    CommandID.RNZ },    { "RZ",	    CommandID.RZ },      { "RNC",    CommandID.RNC },     { "RC",	    CommandID.RC },
            { "RPO",    CommandID.RPO },    { "RPE",    CommandID.RPE },     { "RP",     CommandID.RP },      { "RM",	    CommandID.RM },

            { "RLC",	CommandID.RLC },    { "RRC",	CommandID.RRC },   
            { "RST",	CommandID.RST },
            { "SBB",	CommandID.SBB },    { "SBI",	CommandID.SBI },

            { "SHLD",	CommandID.SHLD },   { "SPHL",	CommandID.SPHL },    { "STA",	CommandID.STA},       { "STAX",	CommandID.STAX },  
            { "STC",	CommandID.STC },
            { "SUB",	CommandID.SUB },    { "SUI",	CommandID.SUI },

            { "XCHG",	CommandID.XCHG },     
            { "XRA",	CommandID.XRA },    { "XRI",	CommandID.XRI },
            { "XTHL",	CommandID.XTHL },
        };

        public static SortedList<string, CommandID> z80Opcodes = new SortedList<string, CommandID>(Comparer<string>.Create((a, b) => string.Compare(a, b, true)))
        {
            // Register    
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
            TokenType.LogicalNot, TokenType.String, TokenType.Symbol, TokenType.CurrentPos, TokenType.Remainder,
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

        
        public static Dictionary<MessageCode, string> MessageStrings = new Dictionary<MessageCode,string>()
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
            
        };
    }
}
