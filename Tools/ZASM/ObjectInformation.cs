using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZASM
{
    enum ObjectType
    {
        None,
        Include,
        Conditional,
    }

    class ObjectInformation
    {
        public ObjectType Type { get; private set; }
        public bool Error;
        public int Address;

        public ObjectInformation(ObjectType ofType = ObjectType.None)
        {
            Error = false;
            Type = ofType;
            Address = 0;
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
}
