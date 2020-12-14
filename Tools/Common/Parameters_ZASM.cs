using System;
using System.Collections.Generic;
using System.Text;

namespace OpcodeData
{
    public static partial class GameBoyData
    {
        public static Dictionary<string, OpcodeData.ParameterID> ParameterList = new Dictionary<string, OpcodeData.ParameterID>()
        {
            { "A",      ParameterID.ByteReg_A   },   { "AF",     ParameterID.WordReg_AF  },   { "B",      ParameterID.ByteReg_B       },
            { "BC",     ParameterID.WordReg_BC  },   { "C",      ParameterID.Reg_C       },   { "CY",     ParameterID.Flag_CY         },   { "D",      ParameterID.ByteReg_D       },
            { "DE",     ParameterID.WordReg_DE  },   { "E",      ParameterID.ByteReg_E   },   { "H",      ParameterID.ByteReg_H       },   { "HL",     ParameterID.WordReg_HL      },
            { "HLD",    ParameterID.WordReg_HLD },   { "HLI",    ParameterID.WordReg_HLI },   { "L",      ParameterID.ByteReg_L       },   { "M",      ParameterID.Flag_M  },
            { "NC",     ParameterID.Flag_NC     },   { "NZ",     ParameterID.Flag_NZ     },   { "Z",      ParameterID.Flag_Z          },
        };
    }

    public static partial class z80Data
    {
        public static Dictionary<string, OpcodeData.ParameterID> ParameterList = new Dictionary<string, OpcodeData.ParameterID>()
        {
            { "A",      ParameterID.ByteReg_A  },   { "AF",     ParameterID.WordReg_AF },   { "AF'",    ParameterID.WordReg_AF_Alt  },   { "B",      ParameterID.ByteReg_B       },
            { "BC",     ParameterID.WordReg_BC },   { "C",      ParameterID.Reg_C      },   { "CY",     ParameterID.Flag_CY         },   { "D",      ParameterID.ByteReg_D       },
            { "DE",     ParameterID.WordReg_DE },   { "E",      ParameterID.ByteReg_E  },   { "H",      ParameterID.ByteReg_H       },   { "HL",     ParameterID.WordReg_HL      },
            { "I",      ParameterID.ByteReg_I  },   { "IX",     ParameterID.WordReg_IX },   { "IXH",    ParameterID.ByteReg_IXH     },   { "IXL",    ParameterID.ByteReg_IXL     },
            { "IY",     ParameterID.WordReg_IY },   { "IYH",    ParameterID.ByteReg_IYH},   { "IYL",    ParameterID.ByteReg_IYL     },   { "L",      ParameterID.ByteReg_L       },
            { "M",      ParameterID.Flag_M     },   { "NC",      ParameterID.Flag_NC   },   { "NV",      ParameterID.Flag_PO        },   { "NZ",       ParameterID.Flag_NZ       },
            { "P",      ParameterID.Flag_P     },   { "PE",      ParameterID.Flag_PE   },   { "PO",       ParameterID.Flag_PO       },   { "R",      ParameterID.ByteReg_R       },
            { "SP",     ParameterID.WordReg_SP },   { "V",      ParameterID.Flag_PE    },   { "Z",       ParameterID.Flag_Z  },
        };
    }

    public static partial class i8080Data
    {
        public static Dictionary<string, OpcodeData.ParameterID> ParameterList = new Dictionary<string, OpcodeData.ParameterID>()
        {
            { "A",      ParameterID.ByteReg_A   }, { "B",      ParameterID.Reg_B      },  { "C",      ParameterID.ByteReg_C  },
            { "D",      ParameterID.Reg_D       }, { "E",      ParameterID.ByteReg_E  },
            { "H",      ParameterID.Reg_H       }, { "L",      ParameterID.ByteReg_L  },  { "M",      ParameterID.Reg_M      },
            { "PSW",    ParameterID.WordReg_PSW }, { "SP",     ParameterID.WordReg_SP },
        };
    }
}