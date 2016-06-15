using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZASM
{
    class OutputSection
    {
        MemoryStream _DataStream;
        BinaryWriter _DataWriter;
        
        // Base Offset
        int _BaseOffset;


        public OutputSection(int BaseOffest = 0)
        {
            _BaseOffset = BaseOffest;
            _DataStream = new MemoryStream();
            _DataWriter = new BinaryWriter(_DataStream);
        }

        public int Address { get { return _BaseOffset + (int)_DataStream.Length; } }

        public void Write(byte Data)
        {
            _DataWriter.Write(Data);
        }

        public void Write(byte[] Data)
        {
            _DataWriter.Write(Data);
        }

        public void Write(int Data)
        {            
            _DataWriter.Write((byte)(Data & 0x00FF));
            _DataWriter.Write((byte)((Data & 0xFF00) >> 8));
        }

        public void WriteAt(int Offset, byte Data)
        {
            _DataWriter.Flush();
            _DataWriter.BaseStream.Position = Offset;
            _DataWriter.Write(Data);
        }

        public void WriteAt(int Offset, byte[] Data)
        {
            _DataWriter.Flush();
            _DataWriter.BaseStream.Position = Offset;
            _DataWriter.Write(Data);
        }

        public void WriteAt(int Offset, int Data)
        {
            _DataWriter.Flush(); 
            _DataWriter.BaseStream.Position = Offset;
            _DataWriter.Write((byte)(Data & 0x00FF));
            _DataWriter.Write((byte)((Data & 0xFF00) >> 8));
        }

        public void SaveData(Stream OutputStream)
        {
            _DataWriter.Flush();
            _DataStream.Flush();

            BinaryWriter Output = new BinaryWriter(OutputStream);

            Output.Write(_DataStream.GetBuffer());

            Output.Flush();

        }
    }
}
