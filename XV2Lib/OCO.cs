using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XV2Lib
{
    public struct OCO_Costume
    {
        public int unk1;
        public int unk2;
        public int unk3;
        public int unk4;
        public int unk5;
    }
    public struct OCO_Char
    {
        public int id;
        public bool enabled;
        public OCO_Costume data;
    }

    public class OCO
    {
        public static List<OCO_Char> Read(string path)
        {
            List<OCO_Char> data = new List<OCO_Char>();
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                br.BaseStream.Seek(8, SeekOrigin.Begin);
                int count = br.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    OCO_Char n = new OCO_Char();
                    br.BaseStream.Seek(16 + (i * 16), SeekOrigin.Begin);
                    int count2 = br.ReadInt32();
                    int address = br.ReadInt32();
                    int index = br.ReadInt32();
                    n.id = br.ReadInt32();

                    
                    n.data = new OCO_Costume();
                    n.enabled = (count2 == 1);
                    if (n.enabled)
                    {
                        br.BaseStream.Seek(16 + address + (index * 20), SeekOrigin.Begin);
                        n.data.unk1 = br.ReadInt32();
                        n.data.unk2 = br.ReadInt32();
                        n.data.unk3 = br.ReadInt32();
                        n.data.unk4 = br.ReadInt32();
                        n.data.unk5 = br.ReadInt32();
                    }
                    
                    data.Add(n);
                }
            }
            return data;
        }

        public static void Write(string path, List<OCO_Char> data)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                bw.Write(new byte[] { 0x23, 0x4F, 0x43, 0x4F, 0xFE, 0xFF, 0x10, 0x00 });
                bw.Write(data.Count);
                bw.BaseStream.Seek(4, SeekOrigin.Current);
                int address = 16 + (data.Count * 16);
                int indexStart = 0;
                for (int i = 0; i < data.Count; i++)
                {
                    OCO_Char w = data[i];
                    bw.Write(w.enabled ? 1 : 0);
                    bw.Write(address - 16);
                    bw.Write(indexStart);
                    if (w.enabled)
                    {
                        bw.Write(w.id);
                        indexStart += 1;
                    }
                    else
                        bw.Write(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF });

                    
                }

                for (int i = 0; i < data.Count; i++)
                {
                    OCO_Char w = data[i];
                    
                    if (w.enabled)
                    {
                        bw.Write(w.data.unk1);
                        bw.Write(w.data.unk2);
                        bw.Write(w.data.unk3);
                        bw.Write(w.data.unk4);
                        bw.Write(w.data.unk5);
                    }
                    
                }
            }
        }
    }
}
