using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandList = System.Collections.Generic.SortedList<string, OpcodeData.CommandID>;
using ParameterList = System.Collections.Generic.Dictionary<string, OpcodeData.ParameterID>;

namespace ZASM
{
    enum FunctionID
    {
        // Psudo Operators
        BYTE, WORD, DWORD, DC, RESB, RESW, RESD,

        DataCommandsMax,

        DEFL, EQU,

        // Commands
        EXTERN, PUBLIC, INCLUDE, Z80, i8080, GAMEBOY, ORG, END, SECTION, SIZE, FILL, POS,

        CommandMax,

        // Preprocessor commands
        IF, ELSE, ENDIF,

        PreprocessorMax,
        
        
        None,
    };

    static class DataTables
    {
        public static ParameterList z80ParameterList = new ParameterList()
        {
            { "A",      OpcodeData.ParameterID.A       },   { "AF",     OpcodeData.ParameterID.AF      },   { "AF'",    OpcodeData.ParameterID.AF_Alt  },   { "B",      OpcodeData.ParameterID.B       },
            { "BC",     OpcodeData.ParameterID.BC      },   { "C",      OpcodeData.ParameterID.C       },   { "CY",	    OpcodeData.ParameterID.Flag_C  },   { "D",      OpcodeData.ParameterID.D       },
            { "DE",     OpcodeData.ParameterID.DE      },   { "E",      OpcodeData.ParameterID.E       },   { "H",      OpcodeData.ParameterID.H       },   { "HL",     OpcodeData.ParameterID.HL      },
            { "I",      OpcodeData.ParameterID.I       },   { "IX",     OpcodeData.ParameterID.IX      },   { "IXH",    OpcodeData.ParameterID.IXH     },   { "IXL",    OpcodeData.ParameterID.IXL     },
            { "IY",     OpcodeData.ParameterID.IY      },   { "IYH",    OpcodeData.ParameterID.IYH     },   { "IYL",    OpcodeData.ParameterID.IYL     },   { "L",      OpcodeData.ParameterID.L       },
            { "M",	    OpcodeData.ParameterID.Flag_M  },   { "NC",	    OpcodeData.ParameterID.Flag_NC },   { "NZ",	    OpcodeData.ParameterID.Flag_NZ },   { "P",	    OpcodeData.ParameterID.Flag_P  },  
            { "PE",	    OpcodeData.ParameterID.Flag_PE },   { "PO",	    OpcodeData.ParameterID.Flag_PO },   { "R",      OpcodeData.ParameterID.R       },   { "SP",     OpcodeData.ParameterID.SP      },
            { "Z",	    OpcodeData.ParameterID.Flag_Z  },  
        };

        public static ParameterList GameBoyParameterList = new ParameterList()
        {
            { "A",      OpcodeData.ParameterID.A       },   { "AF",     OpcodeData.ParameterID.AF      },   { "AF'",    OpcodeData.ParameterID.AF_Alt  },   { "B",      OpcodeData.ParameterID.B       },
            { "BC",     OpcodeData.ParameterID.BC      },   { "C",      OpcodeData.ParameterID.C       },   { "CY",	    OpcodeData.ParameterID.Flag_C  },   { "D",      OpcodeData.ParameterID.D       },
            { "DE",     OpcodeData.ParameterID.DE      },   { "E",      OpcodeData.ParameterID.E       },   { "H",      OpcodeData.ParameterID.H       },   { "HL",     OpcodeData.ParameterID.HL      },
            { "HLD",    OpcodeData.ParameterID.HLD     },   { "HLI",    OpcodeData.ParameterID.HLI     },   { "L",      OpcodeData.ParameterID.L       },   { "M",	    OpcodeData.ParameterID.Flag_M  },
            { "NC",	    OpcodeData.ParameterID.Flag_NC },   { "NZ",	    OpcodeData.ParameterID.Flag_NZ },   { "P",	    OpcodeData.ParameterID.Flag_P  },   { "PE",	    OpcodeData.ParameterID.Flag_PE }, 
            { "PO",	    OpcodeData.ParameterID.Flag_PO },   { "SP",     OpcodeData.ParameterID.SP      },   { "Z",	    OpcodeData.ParameterID.Flag_Z  },  
        };

        public static ParameterList i8080ParameterList = new ParameterList()
        {
            { "A",      OpcodeData.ParameterID.A       },   { "B",      OpcodeData.ParameterID.B       }, /*{ "B",     OpcodeData.ParameterID.BC       },*/ { "C",      OpcodeData.ParameterID.C       },
            { "CY",    OpcodeData.ParameterID.Flag_C   },   { "D",      OpcodeData.ParameterID.D       }, /*{ "D",     OpcodeData.ParameterID.DE       },*/ { "E",      OpcodeData.ParameterID.E       },
            { "H",      OpcodeData.ParameterID.H       }, /*{ "H",      OpcodeData.ParameterID.HL      },*/ { "L",      OpcodeData.ParameterID.L       },   { "M",      OpcodeData.ParameterID.HL      }, 
            /*{ "M",    OpcodeData.ParameterID.Flag_M  },*/ { "NC",	    OpcodeData.ParameterID.Flag_NC },   { "NZ",	    OpcodeData.ParameterID.Flag_NZ },   { "P",	    OpcodeData.ParameterID.Flag_P  },
            { "PE",	    OpcodeData.ParameterID.Flag_PE },   { "PO",	    OpcodeData.ParameterID.Flag_PO },   { "PSW",    OpcodeData.ParameterID.AF      },   { "SP",     OpcodeData.ParameterID.SP      },
            { "Z",	    OpcodeData.ParameterID.Flag_Z  },  
        };

        public static Dictionary<string, FunctionID> Commands = new Dictionary<string,FunctionID>()
        {
            { "EXTERN", FunctionID.EXTERN },        { "PUBLIC",   FunctionID.PUBLIC },          { "INCLUDE",    FunctionID.INCLUDE },        
            { "Z80",    FunctionID.Z80 },           { "8080",     FunctionID.i8080 },           { "GAMEBOY",    FunctionID.GAMEBOY },       
            { "ORG",    FunctionID.ORG },           { "SECTION",  FunctionID.SECTION },         { "FILL",       FunctionID.FILL },        
            { "POS",    FunctionID.POS },           { "END",      FunctionID.END },        
            { "IF",     FunctionID.IF },            { "ELSE",     FunctionID.ELSE },            { "ENDIF",      FunctionID.ENDIF },        
        };

        public static Dictionary<string, FunctionID> PsudoOpcodes = new Dictionary<string,FunctionID>()
        {
            { "DB",     FunctionID.BYTE },          { "DW",     FunctionID.WORD },              { "DD",     FunctionID.DWORD },             { "DC",     FunctionID.DC },         
            { "DS",	    FunctionID.RESB },          { "RESB",   FunctionID.RESB },              { "RESW",   FunctionID.RESW },              { "RESD",   FunctionID.RESD }, 
            { "EQU",    FunctionID.EQU },           { "CONST",	FunctionID.DEFL },              { "DEFL",   FunctionID.DEFL },       
        };
        
        public static InputType[] CharacterData = new InputType[]
        {
            InputType.Unknown, InputType.Unknown, InputType.Unknown, InputType.Unknown, InputType.Unknown, InputType.Unknown,
            InputType.Unknown, InputType.Unknown, InputType.Unknown,

            InputType.Tab,   // Tab

            InputType.LineFeed, InputType.Unknown, InputType.Unknown, InputType.CarriageReturn, InputType.Unknown, InputType.Unknown,
            InputType.Unknown, InputType.Unknown, InputType.Unknown, InputType.Unknown, InputType.Unknown, InputType.Unknown,
            InputType.Unknown, InputType.Unknown, InputType.Unknown, InputType.Unknown, InputType.Unknown, InputType.Unknown,
            InputType.Unknown, InputType.Unknown, InputType.Unknown, InputType.Unknown,

            InputType.Space,   // Space
            
            // !"#$% &'()* +,-./
            InputType.ExclimationMark, InputType.DoubleQuote, InputType.PoundSign, InputType.DollarSign, InputType.PercentSign,
            InputType.Ampersand, InputType.SingleQuote, InputType.ParenthesesLeft, InputType.ParenthesesRight, InputType.Asterisk,
            InputType.Plus, InputType.Comma, InputType.Minus, InputType.Period, InputType.Slash,
            
            // 0-9
            InputType.Number, InputType.Number, InputType.Number, InputType.Number, InputType.Number,
            InputType.Number, InputType.Number, InputType.Number, InputType.Number, InputType.Number,

            // :;<=> ?@
            InputType.Colon, InputType.SemiColon, InputType.LessThen, InputType.Equal, InputType.GreaterThen,
            InputType.QuestionMark, InputType.AtSign,

            // A-Z
            InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier,
            InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier,
            InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier,
            InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier,
            InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier,
            InputType.Identifier,

            // [\]^_ `
            InputType.BracketLeft, InputType.Backslash, InputType.BracketRight, InputType.Carrot, InputType.Underscore,
            InputType.ReverseQuote,
            
            // a-z
            InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier,
            InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier,
            InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier,
            InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier,
            InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier, InputType.Identifier,
            InputType.Identifier,

            // {|}~
            InputType.CurlyBraceLeft, InputType.Pipe, InputType.CurlyBraceRight, InputType.Tilde, InputType.Unknown,
        };

        public static OpcodeData.OpcodeEntry[] OpcodeTable = OpcodeData.ZASM.z80OpcodeList;
        public static CommandList OpcodeList = OpcodeData.ZASM.z80Commands;
        public static ParameterList ParameterList = DataTables.z80ParameterList;
    }
}
