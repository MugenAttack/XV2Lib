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
        public int unk6;
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

                    n.type0 = new List<OCS_Skill>();
                    n.type1 = new List<OCS_Skill>();
                    n.type2 = new List<OCS_Skill>();
                    n.type3 = new List<OCS_Skill>();

                    for (int j = 0; j < count2; j++)
                    {
                        br.BaseStream.Seek(16 + address + (index * 16) + (j * 16), SeekOrigin.Begin);
                        int count3 = br.ReadInt32();
                        int address2 = br.ReadInt32();
                        int index2 = br.ReadInt32();
                        int type = br.ReadInt32();
                        br.BaseStream.Seek(16 + address2 + (index2 * 24), SeekOrigin.Begin);
                        for (int k = 0; k < count3; k++)
                        {
                            
                            OCS_Skill s = new OCS_Skill();

                            s.unk1 = br.ReadInt32();
                            s.unk2 = br.ReadInt32();
                            s.unk3 = br.ReadInt32();
                            s.unk4 = br.ReadInt32();
                            s.unk5 = br.ReadInt32();
                            s.unk6 = br.ReadInt32();
                          
                            switch (type)
                            {
                                case 0:
                                    n.type0.Add(s);
                                    break;
                                case 1:
                                    n.type1.Add(s);
                                    break;
                                case 2:
                                    n.type2.Add(s);
                                    break;
                                case 3:
                                    n.type3.Add(s);
                                    break;
                            }
                        }

                    }
                    data.Add(n);
                }
            }
            return data;
        }

        public static void Write(string path, List<OCS_Char> data)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                bw.Write(new byte[] { 0x23, 0x4F, 0x43, 0x53, 0xFE, 0xFF, 0x10, 0x00 });
                bw.Write(data.Count);
                bw.BaseStream.Seek(4, SeekOrigin.Current);
                int address = 16 + (data.Count * 16);
                int indexStart = 0;
                for (int i = 0; i < data.Count; i++)
                {
                    OCS_Char w = data[i];
                    int count = 0;
                    //calculate count
                    if (w.type0.Count != 0)
                        count++;
                    if (w.type1.Count != 0)
                        count++;
                    if (w.type2.Count != 0)
                        count++;
                    if (w.type3.Count != 0)
                        count++;

                    bw.Write(count);
                    bw.Write(address - 16);
                    bw.Write(indexStart);
                    bw.Write(w.id);

                    indexStart += count;
                }

                address = address + (indexStart * 16);
                indexStart = 0;
                for (int i = 0; i < data.Count; i++)
                {
                    OCS_Char w = data[i];
                    
                    if (w.type0.Count != 0)
                    {
                        bw.Write(w.type0.Count);
                        bw.Write(address - 16);
                        bw.Write(indexStart);
                        bw.Write(0);
                        indexStart += w.type0.Count;
                    }

                    if (w.type1.Count != 0)
                    {
                        bw.Write(w.type1.Count);
                        bw.Write(address - 16);
                        bw.Write(indexStart);
                        bw.Write(1);
                        indexStart += w.type1.Count;
                    }

                    if (w.type2.Count != 0)
                    {
                        bw.Write(w.type2.Count);
                        bw.Write(address - 16);
                        bw.Write(indexStart);
                        bw.Write(2);
                        indexStart += w.type2.Count;
                    }

                    if (w.type3.Count != 0)
                    {
                        bw.Write(w.type3.Count);
                        bw.Write(address - 16);
                        bw.Write(indexStart);
                        bw.Write(3);
                        indexStart += w.type3.Count;
                    }

                }

                for (int i = 0; i < data.Count; i++)
                {
                    OCS_Char w = data[i];

                    for (int j = 0; j < w.type0.Count; j++)
                    {
                        OCS_Skill t = w.type0[j];
                        bw.Write(t.unk1);
                        bw.Write(t.unk2);
                        bw.Write(t.unk3);
                        bw.Write(t.unk4);
                        bw.Write(t.unk5);
                        bw.Write(t.unk6);
                    }

                    for (int j = 0; j < w.type1.Count; j++)
                    {
                        OCS_Skill t = w.type1[j];
                        bw.Write(t.unk1);
                        bw.Write(t.unk2);
                        bw.Write(t.unk3);
                        bw.Write(t.unk4);
                        bw.Write(t.unk5);
                        bw.Write(t.unk6);
                    }

                    for (int j = 0; j < w.type2.Count; j++)
                    {
                        OCS_Skill t = w.type2[j];
                        bw.Write(t.unk1);
                        bw.Write(t.unk2);
                        bw.Write(t.unk3);
                        bw.Write(t.unk4);
                        bw.Write(t.unk5);
                        bw.Write(t.unk6);
                    }

                    for (int j = 0; j < w.type3.Count; j++)
                    {
                        OCS_Skill t = w.type3[j];
                        bw.Write(t.unk1);
                        bw.Write(t.unk2);
                        bw.Write(t.unk3);
                        bw.Write(t.unk4);
                        bw.Write(t.unk5);
                        bw.Write(t.unk6);
                    }
                }
            }
        }
    }
}
