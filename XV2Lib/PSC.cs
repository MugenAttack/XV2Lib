using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XV2Lib
{
    public struct PSC_Char
    {
        public int id;
        public PSC_Costume[] Costume_Data;
    }

    public struct PSC_Costume
    {
        public byte[] Data;
    }

    public class PSC
    {
        public PSC_Char[] list;
        SchemaBinary schema;
        
        public PSC(string schemaPath)
        {
            schema.ReadSchema(schemaPath);
        }

        public void Read(string path)
        {
            BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open));
            br.BaseStream.Seek(8,SeekOrigin.Begin);
            int Count = br.ReadInt32();
            br.BaseStream.Seek(16, SeekOrigin.Begin);
            list = new PSC_Char[Count];
            for (int i = 0; i < Count; i++)
            {
                list[i].id = br.ReadInt32();
                list[i].Costume_Data = new PSC_Costume[br.ReadInt32()];
                br.BaseStream.Seek(4, SeekOrigin.Current);
            }

            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < list[i].Costume_Data.Length; j++)
                {
                    list[i].Costume_Data[j].Data = br.ReadBytes(196);
                }
            }

            br.Close();
        }

        public void Write(string path)
        {
            BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create));
            bw.Write(new byte[] {0x23,0x50,0x53,0x43,0xfe,0xff,0x10,0x00});
            bw.Write(list.Length);
            bw.Write(0);
            
            for (int i = 0; i < list.Length; i++)
            {
                bw.Write(list[i].id);
                bw.Write(list[i].Costume_Data.Length);
                bw.Write(0);
            }

            for (int i = 0; i < list.Length; i++)
            {
                for (int j = 0; j < list[i].Costume_Data.Length; j++)
                {
                    bw.Write(list[i].Costume_Data[j].Data);
                }

            }
        }


    }
}
