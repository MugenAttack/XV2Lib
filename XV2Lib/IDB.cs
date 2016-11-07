using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace XV2Lib
{
    public struct IDB_Set
    {
        public byte[] Data;
    }

    public class IDB
    {
        //SchemaBinary schema;
        public IDB_Set[] items;

        public IDB()
        {
            //schema.ReadSchema("IDB_Schema.csv");
        }

        public void Read(string FileName)
        {
            using (BinaryReader br = new BinaryReader(File.Open(FileName, FileMode.Open)))
            {
                br.BaseStream.Seek(8, SeekOrigin.Begin);
                int Count = br.ReadInt32();
                br.BaseStream.Seek(16, SeekOrigin.Begin);
                items = new IDB_Set[Count];
                for (int i = 0; i < Count; i++)
                {
                    items[i].Data = br.ReadBytes(720);
                }
            }
        }

        public void Write(string FileName)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(FileName, FileMode.Create)))
            {
                bw.Write(new byte[] { 0x23, 0x49, 0x44, 0x42, 0xfe, 0xff, 0x07, 0x00 });
                bw.Write(items.Length);
                bw.Write(16);
                for (int i = 0; i < items.Length; i++)
                {
                    bw.Write(items[i].Data);
                }
            }
        }


    }
}
