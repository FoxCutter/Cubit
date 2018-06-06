using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    enum Setting
    {
        On,
        Off,
        Warning,
    }

    enum OpcodeType
    {
        z80,
        i8080,
        GameBoy,
    }
    
    static class Settings
    {
        public static Setting AssumeA = Setting.Warning;
        public static Setting AtAddressing = Setting.On;
        public static Setting Indexes = Setting.On;
        public static Setting ArrayOffset = Setting.On;
        public static Setting CYAsCarry = Setting.On;
        public static Setting CommandRequiresDot = Setting.Off;

        public static OpcodeType OpcodeSet = OpcodeType.z80;

        public static List<string> InputPaths = new List<string>()
        {
            ".",
        };

        public static Dictionary<MessageCode, Setting> Messages = new Dictionary<MessageCode, Setting>() 
        { 
            { MessageCode.SyntaxWarning, Setting.On }, { MessageCode.RegisterMissingAssumingA, Setting.On },
            { MessageCode.NoError, Setting.Off },
        };

        public static void SetMessage(MessageCode Code, Setting Value)
        {
            if (Messages.ContainsKey(Code))
                Messages[Code] = Value;
            else
                Messages.Add(Code, Value);
        }

        public static Setting GetMessage(MessageCode Code)
        {
            if (Messages.ContainsKey(Code))
                return Messages[Code];
            else
                return Setting.On;
        }
    }
}
