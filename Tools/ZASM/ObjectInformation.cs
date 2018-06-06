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
        public IncludeObject(FileInformation File) : base(ObjectType.Include)
        {
            IncludeFile = File;
        }
    }
}
