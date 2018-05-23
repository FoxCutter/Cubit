using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    static class DataTables
    {
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
    }
}
