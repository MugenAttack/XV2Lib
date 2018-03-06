using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XV2Lib
{
    public struct ODF_Char
    {
        public int id;
        public ODF_Data data;
    }

    public struct ODF_Data
    {
        public int unk1;
        public int unk2;
        public int unk3;
        public int unk4;
        public int unk5;
        public int unk6;
        public int unk7;
        public int unk8;
        public int unk9;
        public int unk10;
        public int unk11;
        public int unk12;
        public int unk13;
    }
    
    public class ODF
    {
        public static List<ODF_Char> Read(string path)
        {
            List<ODF_Char> data = new List<ODF_Char>();
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                ODF_Char n = new ODF_Char();
                br.BaseStream.Seek(16, SeekOrigin.Begin);
                int count = br.ReadInt32();
                br.BaseStream.Seek(32, SeekOrigin.Begin);
                for (int i = 0; i < count; i++)
                {
                    n.id = br.ReadInt32();
                    n.data.unk1 = br.ReadInt32();
                    n.data.unk2 = br.ReadInt32();
                    n.data.unk3 = br.ReadInt32();
                    n.data.unk4 = br.ReadInt32();
                    n.data.unk5 = br.ReadInt32();
                    n.data.unk6 = br.ReadInt32();
                    n.data.unk7 = br.ReadInt32();
                    n.data.unk8 = br.ReadInt32();
                    n.data.unk9 = br.ReadInt32();
                    n.data.unk10 = br.ReadInt32();
                    n.data.unk11 = br.ReadInt32();
                    n.data.unk12 = br.ReadInt32();
                    n.data.unk13 = br.ReadInt32();
                    data.Add(n);
                }
                
            }
            return data;
        }

        public static void Write(string path, List<ODF_Char> data)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                bw.Write(new byte[] { 0x23, 0x4F, 0x44, 0x46, 0xFE, 0xFF, 0x38, 0x00 });
                bw.Write(1);
                bw.BaseStream.Seek(4, SeekOrigin.Current);
                bw.Write(data.Count);
                bw.Write(16);
                bw.BaseStream.Seek(32, SeekOrigin.Begin);
                for (int i = 0; i < data.Count; i++)
                {
                    //56
                    ODF_Char w = data[i];
                    bw.Write(w.id);
                    bw.Write(w.data.unk1);
                    bw.Write(w.data.unk2);
                    bw.Write(w.data.unk3);
                    bw.Write(w.data.unk4);
                    bw.Write(w.data.unk5);
                    bw.Write(w.data.unk6);
                    bw.Write(w.data.unk7);
                    bw.Write(w.data.unk8);
                    bw.Write(w.data.unk9);
                    bw.Write(w.data.unk10);
                    bw.Write(w.data.unk11);
                    bw.Write(w.data.unk12);
                    bw.Write(w.data.unk13);
                }

            }
        }


    }
}
