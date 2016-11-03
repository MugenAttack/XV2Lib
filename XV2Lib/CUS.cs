using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XV2Lib
{
    public struct charSkillSet
    {
        public int charID;
        public int costumeID;
        public short[] skill; // set as 9
    }

    public struct skill
    {
        public string shortName;
        public short id;
        public short id2;
        //byte RaceLock;
        //byte[] unknown;
    }

    public static class CUS
    {
        public static void Read(string path, ref charSkillSet[] css,ref skill[] Super, ref skill[] Ultimate, ref skill[] Evasive, ref skill[] Awaken, ref skill[] blast)
        {
            
        }

        public static void ReadCharSet(string path, ref charSkillSet[] css)
        {
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                br.BaseStream.Seek(8, SeekOrigin.Begin);
                css = new charSkillSet[br.ReadInt32()];
                int setAddress = br.ReadInt32();
                br.BaseStream.Seek(setAddress, SeekOrigin.Begin);
                for (int i = 0; i < css.Length; i++)
                {
                    css[i].charID = br.ReadInt32();
                    css[i].costumeID = br.ReadInt32();
                    css[i].skill = new short[9];
                    css[i].skill[0] = br.ReadInt16();
                    css[i].skill[1] = br.ReadInt16();
                    css[i].skill[2] = br.ReadInt16();
                    css[i].skill[3] = br.ReadInt16();
                    css[i].skill[4] = br.ReadInt16();
                    css[i].skill[5] = br.ReadInt16();
                    css[i].skill[6] = br.ReadInt16();
                    css[i].skill[7] = br.ReadInt16();
                    css[i].skill[8] = br.ReadInt16();
                    br.BaseStream.Seek(6, SeekOrigin.Current);
                }

            }
        }

        public static void ReadSkills(string path, ref skill[] Super, ref skill[] Ultimate, ref skill[] Evasive, ref skill[] Awaken, ref skill[] blast)
        {
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                br.BaseStream.Seek(16, SeekOrigin.Begin);
                int supCount = br.ReadInt32(); //super
                int ultCount = br.ReadInt32(); //ultimate
                int evaCount = br.ReadInt32(); //evasive
                int unkCount = br.ReadInt32(); //unknown
                int blaCount = br.ReadInt32(); //blast
                int awaCount = br.ReadInt32(); //awaken

                int supAddress = br.ReadInt32();
                int ultAddress = br.ReadInt32();
                int evaAddress = br.ReadInt32();
                int unkAddress = br.ReadInt32();
                int blaAddress = br.ReadInt32();
                int awaAddress = br.ReadInt32();

                Super = new skill[supCount];
                Ultimate = new skill[ultCount];
                Evasive = new skill[evaCount];
                //unknown = new skill[unkCount];
                blast = new skill[blaCount];
                Awaken = new skill[awaCount];

                for (int i = 0; i < supCount; i++)
                {
                    br.BaseStream.Seek(supAddress + (i * 68), SeekOrigin.Begin);
                    byte[] b = br.ReadBytes(4);
                    Super[i].shortName = Encoding.ASCII.GetString(b);
                    br.BaseStream.Seek(4, SeekOrigin.Current);
                    Super[i].id = br.ReadInt16();
                    Super[i].id2 = br.ReadInt16();
                }

                for (int i = 0; i < ultCount; i++)
                {
                    br.BaseStream.Seek(ultAddress + (i * 68), SeekOrigin.Begin);
                    byte[] b = br.ReadBytes(4);
                    Ultimate[i].shortName = Encoding.ASCII.GetString(b);
                    br.BaseStream.Seek(4, SeekOrigin.Current);
                    Ultimate[i].id = br.ReadInt16();
                    Ultimate[i].id2 = br.ReadInt16();
                }

                for (int i = 0; i < evaCount; i++)
                {
                    br.BaseStream.Seek(evaAddress + (i * 68), SeekOrigin.Begin);
                    byte[] b = br.ReadBytes(4);
                    Evasive[i].shortName = Encoding.ASCII.GetString(b);
                    br.BaseStream.Seek(4, SeekOrigin.Current);
                    Evasive[i].id = br.ReadInt16();
                    Evasive[i].id2 = br.ReadInt16();
                }

                for (int i = 0; i < blaCount; i++)
                {
                    br.BaseStream.Seek(blaAddress + (i * 68), SeekOrigin.Begin);
                    byte[] b = br.ReadBytes(4);
                    blast[i].shortName = Encoding.ASCII.GetString(b);
                    br.BaseStream.Seek(4, SeekOrigin.Current);
                    blast[i].id = br.ReadInt16();
                    blast[i].id2 = br.ReadInt16();
                }

                for (int i = 0; i < awaCount; i++)
                {
                    br.BaseStream.Seek(awaAddress + (i * 68), SeekOrigin.Begin);
                    byte[] b = br.ReadBytes(4);
                    Awaken[i].shortName = Encoding.ASCII.GetString(b);
                    br.BaseStream.Seek(4, SeekOrigin.Current);
                    Awaken[i].id = br.ReadInt16();
                    Awaken[i].id2 = br.ReadInt16();
                }
            }
        }
    }

    static class CUSMod
    {
        static void PatchSkillset(string path, charSkillSet cs)
        {




        }
    }
}
