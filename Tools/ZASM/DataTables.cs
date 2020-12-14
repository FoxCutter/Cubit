using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static SortedList<OpcodeData.CommandID, OpcodeData.OpcodeEntry[]> OpcodeTable = OpcodeData.z80Data.Encoding;
        public static SortedList<string, OpcodeData.CommandID> OpcodeList = OpcodeData.z80Data.Commands;
        public static System.Collections.Generic.Dictionary<string, OpcodeData.ParameterID> ParameterList = OpcodeData.z80Data.ParameterList;
    }
}
