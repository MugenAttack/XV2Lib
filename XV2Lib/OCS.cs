using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XV2Lib
{
    public struct OCS_Skill
    {
        public int unk1;
        public int unk2;
        public int unk3;
        public int unk4;
        public int unk5;
    }
    public struct OCS_Char
    {
        public int id;
        public List<OCS_Skill> type0;
        public List<OCS_Skill> type1;
        public List<OCS_Skill> type2;
        public List<OCS_Skill> type3;

    }

    public class OCS
    {
        public static List<OCS_Char> Read(string path)
        {
            List<OCS_Char> data = new List<OCS_Char>();
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                br.BaseStream.Seek(8, SeekOrigin.Begin);
                int count = br.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    OCS_Char n = new OCS_Char();
                    br.BaseStream.Seek(16 + (i * 16), SeekOrigin.Begin);
                    int count2 = br.ReadInt32();
                    int address = br.ReadInt32();
                    int index = br.ReadInt32();
                    n.id = br.ReadInt32();

                    br.BaseStream.Seek(16 + address + (index * 20), SeekOrigin.Begin);
                    n.type0 = new List<OCS_Skill>();
                    n.type1 = new List<OCS_Skill>();
                    n.type2 = new List<OCS_Skill>();
                    n.type3 = new List<OCS_Skill>();









                    data.Add(n);
                }
            }
            return data;
        }

        public static void Write(string path, List<OCS_Char> data)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                bw.Write(new byte[] { 0x23, 0x4F, 0x43, 0x43, 0xFE, 0xFF, 0x08, 0x00 });
                bw.Write(data.Count);
                bw.BaseStream.Seek(4, SeekOrigin.Current);
                int address = 16 + (data.Count * 16);
                int indexStart = 0;
                for (int i = 0; i < data.Count; i++)
                {
                    //calculate count



                    //write
                    OCS_Char w = data[i];
                  //  bw.Write(w.data.Count);
                    bw.Write(address - 16);
                    bw.Write(indexStart);
                    bw.Write(w.id);
                    
                }

                
            }
        }
    }
}
