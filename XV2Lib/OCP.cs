using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XV2Lib
{
    public struct OCP_Parameters
    {
        public int unk1;
        public int unk2;
        public int unk3;
        public int unk4;
        public int unk5;
    }
    public struct OCP_Char
    {
        public int id;
        public List<OCP_Parameters> data;
    }

    public class OCP
    {
        public static List<OCP_Char> Read(string path)
        {
            List<OCP_Char> data = new List<OCP_Char>();
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                br.BaseStream.Seek(8, SeekOrigin.Begin);
                int count = br.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    OCP_Char n = new OCP_Char();
                    br.BaseStream.Seek(16 + (i * 16), SeekOrigin.Begin);
                    int count2 = br.ReadInt32();
                    int address = br.ReadInt32();
                    int index = br.ReadInt32();
                    n.id = br.ReadInt32();

                    br.BaseStream.Seek(16 + address + (index * 20), SeekOrigin.Begin);
                    n.data = new List<OCP_Parameters>();
                    for (int j = 0; j < count2; j++)
                    {
                        OCP_Parameters t = new OCP_Parameters();
                        t.unk1 = br.ReadInt32();
                        t.unk2 = br.ReadInt32();
                        t.unk3 = br.ReadInt32();
                        t.unk4 = br.ReadInt32();
                        t.unk5 = br.ReadInt32();
                        n.data.Add(t);
                    }
                    data.Add(n);
                }
            }
            return data;
        }

        public static void Write(string path, List<OCP_Char> data)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                bw.Write(new byte[] { 0x23, 0x4F, 0x43, 0x50, 0xFE, 0xFF, 0x10, 0x00 });
                bw.Write(data.Count);
                bw.BaseStream.Seek(4, SeekOrigin.Current);
                int address = 16 + (data.Count * 16);
                int indexStart = 0;
                for (int i = 0; i < data.Count; i++)
                {
                    OCP_Char w = data[i];
                    bw.Write(w.data.Count);
                    bw.Write(address - 16);
                    bw.Write(indexStart);
                    bw.Write(w.id);
                    indexStart += w.data.Count;
                }

                for (int i = 0; i < data.Count; i++)
                {
                    OCP_Char w = data[i];
                    for (int j = 0; j < w.data.Count; j++)
                    {
                        OCP_Parameters t = w.data[j];
                        bw.Write(t.unk1);
                        bw.Write(t.unk2);
                        bw.Write(t.unk3);
                        bw.Write(t.unk4);
                        bw.Write(t.unk5);
                    }
                }
            }
        }
    }
}
