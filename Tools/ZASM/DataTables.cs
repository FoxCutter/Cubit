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
            { "A",      OpcodeData.ParameterID.ByteReg_A  },   { "AF",     OpcodeData.ParameterID.WordReg_AF },   { "AF'",    OpcodeData.ParameterID.WordReg_AF_Alt  },   { "B",      OpcodeData.ParameterID.ByteReg_B       },
            { "BC",     OpcodeData.ParameterID.WordReg_BC },   { "C",      OpcodeData.ParameterID.Reg_C      },   { "CY",	  OpcodeData.ParameterID.Flag_CY         },   { "D",      OpcodeData.ParameterID.ByteReg_D       },
            { "DE",     OpcodeData.ParameterID.WordReg_DE },   { "E",      OpcodeData.ParameterID.ByteReg_E  },   { "H",      OpcodeData.ParameterID.ByteReg_H       },   { "HL",     OpcodeData.ParameterID.WordReg_HL      },
            { "I",      OpcodeData.ParameterID.ByteReg_I  },   { "IX",     OpcodeData.ParameterID.WordReg_IX },   { "IXH",    OpcodeData.ParameterID.ByteReg_IXH     },   { "IXL",    OpcodeData.ParameterID.ByteReg_IXL     },
            { "IY",     OpcodeData.ParameterID.WordReg_IY },   { "IYH",    OpcodeData.ParameterID.ByteReg_IYH},   { "IYL",    OpcodeData.ParameterID.ByteReg_IYL     },   { "L",      OpcodeData.ParameterID.ByteReg_L       },
            { "M",	    OpcodeData.ParameterID.Flag_M     },   { "NC",	    OpcodeData.ParameterID.Flag_NC   },   { "NV",      OpcodeData.ParameterID.Flag_PO        },   { "NZ",	    OpcodeData.ParameterID.Flag_NZ       },
            { "P",	    OpcodeData.ParameterID.Flag_P     },   { "PE",	    OpcodeData.ParameterID.Flag_PE   },   { "PO",	    OpcodeData.ParameterID.Flag_PO       },   { "R",      OpcodeData.ParameterID.ByteReg_R       },   { "SP",     OpcodeData.ParameterID.WordReg_SP      },
            { "V",      OpcodeData.ParameterID.Flag_PE    },   { "Z",	    OpcodeData.ParameterID.Flag_Z  },  
        };

        public static ParameterList GameBoyParameterList = new ParameterList()
        {
            { "A",      OpcodeData.ParameterID.ByteReg_A   },   { "AF",     OpcodeData.ParameterID.WordReg_AF  },   { "AF'",    OpcodeData.ParameterID.WordReg_AF_Alt  },   { "B",      OpcodeData.ParameterID.ByteReg_B       },
            { "BC",     OpcodeData.ParameterID.WordReg_BC  },   { "C",      OpcodeData.ParameterID.Reg_C       },   { "CY",	    OpcodeData.ParameterID.Flag_CY         },   { "D",      OpcodeData.ParameterID.ByteReg_D       },
            { "DE",     OpcodeData.ParameterID.WordReg_DE  },   { "E",      OpcodeData.ParameterID.ByteReg_E   },   { "H",      OpcodeData.ParameterID.ByteReg_H       },   { "HL",     OpcodeData.ParameterID.WordReg_HL      },
            { "HLD",    OpcodeData.ParameterID.WordReg_HLD },   { "HLI",    OpcodeData.ParameterID.WordReg_HLI },   { "L",      OpcodeData.ParameterID.ByteReg_L       },   { "M",	    OpcodeData.ParameterID.Flag_M  },
            { "NC",	    OpcodeData.ParameterID.Flag_NC     },   { "NZ",	    OpcodeData.ParameterID.Flag_NZ     },   { "Z",	    OpcodeData.ParameterID.Flag_Z          },  
        };

        public static ParameterList i8080ParameterList = new ParameterList()
        {
            { "A",      OpcodeData.ParameterID.ByteReg_A   },   { "B",      OpcodeData.ParameterID.Reg_B       },  { "C",      OpcodeData.ParameterID.ByteReg_C  },
            { "CY",    OpcodeData.ParameterID.Flag_CY       },   { "D",      OpcodeData.ParameterID.Reg_D       },  { "E",      OpcodeData.ParameterID.ByteReg_E  },
            { "H",      OpcodeData.ParameterID.Reg_H       },   { "L",      OpcodeData.ParameterID.ByteReg_L   },  { "M",      OpcodeData.ParameterID.Reg_M      }, 
            { "NC",	    OpcodeData.ParameterID.Flag_NC     },   { "NZ",	    OpcodeData.ParameterID.Flag_NZ     },  { "P",	    OpcodeData.ParameterID.Flag_P  },
            { "PE",	    OpcodeData.ParameterID.Flag_PE     },   { "PO",	    OpcodeData.ParameterID.Flag_PO     },  { "PSW",    OpcodeData.ParameterID.WordReg_AF      },
            { "SP",     OpcodeData.ParameterID.WordReg_SP  },   { "Z",	    OpcodeData.ParameterID.Flag_Z      },  
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
