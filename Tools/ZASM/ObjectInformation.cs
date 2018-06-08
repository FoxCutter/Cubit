﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    enum ObjectType
    {
        None,
        Command,
        Include,
        Conditional,
        Label,
        Opcode,
        Value,
    }

    class ObjectInformation
    {
        public ObjectType Type { get; private set; }
        public bool Error;
        public short Address;
        public int CycleCount;

        public ObjectInformation(ObjectType ofType = ObjectType.None)
        {
            Error = false;
            Type = ofType;
            Address = 0;
            CycleCount = 0;
        }
    }

    class CommandObject : ObjectInformation
    {
        public FunctionID Command;
        public CommandObject()
            : base(ObjectType.Command)
        {
            Command = FunctionID.None;
        }
    }
    
    class IncludeObject : ObjectInformation
    {
        public FileInformation IncludeFile;
        public IncludeObject() : base(ObjectType.Include)
        {
            IncludeFile = null;
        }
    }

    class ConditionalObject : ObjectInformation
    {
        public LineInformation DefinedLine;
        public FunctionID Command;
        public bool ParseLines;
        public int Level;
        public ConditionalObject(LineInformation Line, FunctionID Command)
            : base(ObjectType.Conditional)
        {
            this.Command = Command;
            DefinedLine = Line;
            ParseLines = true;
            Level = 0;
        }
    }

    class LabelObject : ObjectInformation
    {
        public SymbolTableEntry Symbol;
        public LabelObject()
            : base(ObjectType.Label)
        {
            Symbol = null;
        }
    }

    class OpcodeObject : ObjectInformation
    {
        public List<ParameterInformation> ParamterList;
        public OpcodeData.OpcodeEntry Opcode;
        
        public OpcodeObject()
            : base(ObjectType.Opcode)
        {
            ParamterList = new List<ParameterInformation>();
            Opcode = null;
        }
    }
}
