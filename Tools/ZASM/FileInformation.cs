using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ZASM
{
    enum FileType
    {
        None,
        Source,
        Inherited,

        Output,
        Listing,
        Map,
    }

    class FileInformation
    {
        public string Name;
        public string FullName;
        public FileType Type;

        public Stream FileStream;

        public FileInformation()
        {
            Name = "";
            FullName = "";
            Type = FileType.None;
            FileStream = null;
        }
    }
}
