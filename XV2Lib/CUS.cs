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
        public byte RaceLock;
        public byte unk1;
        public short unk2;
        public short hair;
        public short unk3;
        public string[] Paths; //7
        public short unk4;
        public short unk5;
        public short unk6;
        public short unk7;
        public short unk8;
        public short unk9;
        public short unk10;
        public int unk11;

    }

    public static class CUS
    {
        public static void Read(string path, ref charSkillSet[] css, ref skill[] Super, ref skill[] Ultimate, ref skill[] Evasive, ref skill[] Awaken, ref skill[] blast)
        {
            ReadCharSet(path, ref css);
            ReadSkills(path, ref Super, ref Ultimate, ref Evasive, ref Awaken, ref blast);
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
                    css[i].skill = new short[10];
                    css[i].skill[0] = br.ReadInt16();
                    css[i].skill[1] = br.ReadInt16();
                    css[i].skill[2] = br.ReadInt16();
                    css[i].skill[3] = br.ReadInt16();
                    css[i].skill[4] = br.ReadInt16();
                    css[i].skill[5] = br.ReadInt16();
                    css[i].skill[6] = br.ReadInt16();
                    css[i].skill[7] = br.ReadInt16();
                    css[i].skill[8] = br.ReadInt16();
                    css[i].skill[9] = br.ReadInt16();
                    br.BaseStream.Seek(4, SeekOrigin.Current);
                }

            }
        }

        public static void ReadSkills(string path, ref skill[] Super, ref skill[] Ultimate, ref skill[] Evasive, ref skill[] Awaken, ref skill[] blast)
        {
            BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open));


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
                Super[i].RaceLock = br.ReadByte();
                Super[i].unk1 = br.ReadByte();
                Super[i].unk2 = br.ReadInt16();
                Super[i].hair = br.ReadInt16();
                Super[i].unk3 = br.ReadInt16(); //20

                Super[i].Paths = new string[7];
                Super[i].Paths[0] = Helper.ReadAddressText(br, br.ReadInt32());
                Super[i].Paths[1] = Helper.ReadAddressText(br, br.ReadInt32());
                Super[i].Paths[2] = Helper.ReadAddressText(br, br.ReadInt32());
                Super[i].Paths[3] = Helper.ReadAddressText(br, br.ReadInt32());
                Super[i].Paths[4] = Helper.ReadAddressText(br, br.ReadInt32());
                Super[i].Paths[5] = Helper.ReadAddressText(br, br.ReadInt32());
                Super[i].Paths[6] = Helper.ReadAddressText(br, br.ReadInt32()); //28

                br.BaseStream.Seek(2, SeekOrigin.Current);
                Super[i].unk4 = br.ReadInt16();
                Super[i].unk5 = br.ReadInt16();
                Super[i].unk6 = br.ReadInt16();
                Super[i].unk7 = br.ReadInt16();
                Super[i].unk8 = br.ReadInt16();
                Super[i].unk9 = br.ReadInt16();
                Super[i].unk10 = br.ReadInt16(); 
                Super[i].unk11 = br.ReadInt32(); //20
            }

            for (int i = 0; i < ultCount; i++)
            {
                br.BaseStream.Seek(ultAddress + (i * 68), SeekOrigin.Begin);
                byte[] b = br.ReadBytes(4);
                Ultimate[i].shortName = Encoding.ASCII.GetString(b);
                br.BaseStream.Seek(4, SeekOrigin.Current);
                Ultimate[i].id = br.ReadInt16();
                Ultimate[i].id2 = br.ReadInt16();
                Ultimate[i].RaceLock = br.ReadByte();
                Ultimate[i].unk1 = br.ReadByte();
                Ultimate[i].unk2 = br.ReadInt16();
                Ultimate[i].hair = br.ReadInt16();
                Ultimate[i].unk3 = br.ReadInt16();

                Ultimate[i].Paths = new string[7];
                Ultimate[i].Paths[0] = Helper.ReadAddressText(br, br.ReadInt32());
                Ultimate[i].Paths[1] = Helper.ReadAddressText(br, br.ReadInt32());
                Ultimate[i].Paths[2] = Helper.ReadAddressText(br, br.ReadInt32());
                Ultimate[i].Paths[3] = Helper.ReadAddressText(br, br.ReadInt32());
                Ultimate[i].Paths[4] = Helper.ReadAddressText(br, br.ReadInt32());
                Ultimate[i].Paths[5] = Helper.ReadAddressText(br, br.ReadInt32());
                Ultimate[i].Paths[6] = Helper.ReadAddressText(br, br.ReadInt32()); //28

                br.BaseStream.Seek(2, SeekOrigin.Current);
                Ultimate[i].unk4 = br.ReadInt16();
                Ultimate[i].unk5 = br.ReadInt16();
                Ultimate[i].unk6 = br.ReadInt16();
                Ultimate[i].unk7 = br.ReadInt16();
                Ultimate[i].unk8 = br.ReadInt16();
                Ultimate[i].unk9 = br.ReadInt16();
                Ultimate[i].unk10 = br.ReadInt16();
                Ultimate[i].unk11 = br.ReadInt32(); //20

            }

            for (int i = 0; i < evaCount; i++)
            {
                br.BaseStream.Seek(evaAddress + (i * 68), SeekOrigin.Begin);
                byte[] b = br.ReadBytes(4);
                Evasive[i].shortName = Encoding.ASCII.GetString(b);
                br.BaseStream.Seek(4, SeekOrigin.Current);
                Evasive[i].id = br.ReadInt16();
                Evasive[i].id2 = br.ReadInt16();
                Evasive[i].RaceLock = br.ReadByte();
                Evasive[i].unk1 = br.ReadByte();
                Evasive[i].unk2 = br.ReadInt16();
                Evasive[i].hair = br.ReadInt16();
                Evasive[i].unk3 = br.ReadInt16();

                Evasive[i].Paths = new string[7];
                Evasive[i].Paths[0] = Helper.ReadAddressText(br, br.ReadInt32());
                Evasive[i].Paths[1] = Helper.ReadAddressText(br, br.ReadInt32());
                Evasive[i].Paths[2] = Helper.ReadAddressText(br, br.ReadInt32());
                Evasive[i].Paths[3] = Helper.ReadAddressText(br, br.ReadInt32());
                Evasive[i].Paths[4] = Helper.ReadAddressText(br, br.ReadInt32());
                Evasive[i].Paths[5] = Helper.ReadAddressText(br, br.ReadInt32());
                Evasive[i].Paths[6] = Helper.ReadAddressText(br, br.ReadInt32()); //28

                br.BaseStream.Seek(2, SeekOrigin.Current);
                Evasive[i].unk4 = br.ReadInt16();
                Evasive[i].unk5 = br.ReadInt16();
                Evasive[i].unk6 = br.ReadInt16();
                Evasive[i].unk7 = br.ReadInt16();
                Evasive[i].unk8 = br.ReadInt16();
                Evasive[i].unk9 = br.ReadInt16();
                Evasive[i].unk10 = br.ReadInt16();
                Evasive[i].unk11 = br.ReadInt32(); //20

            }

            for (int i = 0; i < blaCount; i++)
            {
                br.BaseStream.Seek(blaAddress + (i * 68), SeekOrigin.Begin);
                byte[] b = br.ReadBytes(4);
                blast[i].shortName = Encoding.ASCII.GetString(b);
                br.BaseStream.Seek(4, SeekOrigin.Current);
                blast[i].id = br.ReadInt16();
                blast[i].id2 = br.ReadInt16();
                blast[i].RaceLock = br.ReadByte();
                blast[i].unk1 = br.ReadByte();
                blast[i].unk2 = br.ReadInt16();
                blast[i].hair = br.ReadInt16();
                blast[i].unk3 = br.ReadInt16();

                blast[i].Paths = new string[7];
                blast[i].Paths[0] = Helper.ReadAddressText(br, br.ReadInt32());
                blast[i].Paths[1] = Helper.ReadAddressText(br, br.ReadInt32());
                blast[i].Paths[2] = Helper.ReadAddressText(br, br.ReadInt32());
                blast[i].Paths[3] = Helper.ReadAddressText(br, br.ReadInt32());
                blast[i].Paths[4] = Helper.ReadAddressText(br, br.ReadInt32());
                blast[i].Paths[5] = Helper.ReadAddressText(br, br.ReadInt32());
                blast[i].Paths[6] = Helper.ReadAddressText(br, br.ReadInt32()); //28

                br.BaseStream.Seek(2, SeekOrigin.Current);
                blast[i].unk4 = br.ReadInt16();
                blast[i].unk5 = br.ReadInt16();
                blast[i].unk6 = br.ReadInt16();
                blast[i].unk7 = br.ReadInt16();
                blast[i].unk8 = br.ReadInt16();
                blast[i].unk9 = br.ReadInt16();
                blast[i].unk10 = br.ReadInt16();
                blast[i].unk11 = br.ReadInt32(); //20
            }

            for (int i = 0; i < awaCount; i++)
            {
                br.BaseStream.Seek(awaAddress + (i * 68), SeekOrigin.Begin);
                byte[] b = br.ReadBytes(4);
                Awaken[i].shortName = Encoding.ASCII.GetString(b);
                br.BaseStream.Seek(4, SeekOrigin.Current);
                Awaken[i].id = br.ReadInt16();
                Awaken[i].id2 = br.ReadInt16();
                Awaken[i].RaceLock = br.ReadByte();
                Awaken[i].unk1 = br.ReadByte();
                Awaken[i].unk2 = br.ReadInt16();
                Awaken[i].hair = br.ReadInt16();
                Awaken[i].unk3 = br.ReadInt16();

                Awaken[i].Paths = new string[7];
                Awaken[i].Paths[0] = Helper.ReadAddressText(br, br.ReadInt32());
                Awaken[i].Paths[1] = Helper.ReadAddressText(br, br.ReadInt32());
                Awaken[i].Paths[2] = Helper.ReadAddressText(br, br.ReadInt32());
                Awaken[i].Paths[3] = Helper.ReadAddressText(br, br.ReadInt32());
                Awaken[i].Paths[4] = Helper.ReadAddressText(br, br.ReadInt32());
                Awaken[i].Paths[5] = Helper.ReadAddressText(br, br.ReadInt32());
                Awaken[i].Paths[6] = Helper.ReadAddressText(br, br.ReadInt32()); //28

                br.BaseStream.Seek(2, SeekOrigin.Current);
                Awaken[i].unk4 = br.ReadInt16();
                Awaken[i].unk5 = br.ReadInt16();
                Awaken[i].unk6 = br.ReadInt16();
                Awaken[i].unk7 = br.ReadInt16();
                Awaken[i].unk8 = br.ReadInt16();
                Awaken[i].unk9 = br.ReadInt16();
                Awaken[i].unk10 = br.ReadInt16();
                Awaken[i].unk11 = br.ReadInt32(); //20
            }

            br.Close();
            
        }

        public static void Write(string path, ref charSkillSet[] css, ref skill[] Super, ref skill[] Ultimate, ref skill[] Evasive, ref skill[] Awaken, ref skill[] blast)
        {
            List<string> CmnText = new List<string>();
            for (int i = 0; i < Super.Length; i++)
            {
                for (int j = 0; j < Super[i].Paths.Length; j++)
                {
                    if (!CmnText.Contains(Super[i].Paths[j]))
                        CmnText.Add(Super[i].Paths[j]);
                }
            }

            for (int i = 0; i < Ultimate.Length; i++)
            {
                for (int j = 0; j < Ultimate[i].Paths.Length; j++)
                {
                    if (!CmnText.Contains(Ultimate[i].Paths[j]))
                        CmnText.Add(Ultimate[i].Paths[j]);
                }
            }

            for (int i = 0; i < Evasive.Length; i++)
            {
                for (int j = 0; j < Evasive[i].Paths.Length; j++)
                {
                    if (!CmnText.Contains(Evasive[i].Paths[j]))
                        CmnText.Add(Evasive[i].Paths[j]);
                }
            }

            for (int i = 0; i < blast.Length; i++)
            {
                for (int j = 0; j < blast[i].Paths.Length; j++)
                {
                    if (!CmnText.Contains(blast[i].Paths[j]))
                        CmnText.Add(blast[i].Paths[j]);
                }
            }

            for (int i = 0; i < Awaken.Length; i++)
            {
                for (int j = 0; j < Awaken[i].Paths.Length; j++)
                {
                    if (!CmnText.Contains(Awaken[i].Paths[j]))
                        CmnText.Add(Awaken[i].Paths[j]);
                }
            }

            int[] wordAddress = new int[CmnText.Count];

            int BTLength = 72 + (css.Length * 32) + (Super.Length * 68) + (Ultimate.Length * 68) + (Evasive.Length * 68) + (blast.Length * 68) + (Awaken.Length * 68);
            BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create));
            bw.BaseStream.Seek(BTLength, SeekOrigin.Begin);

            for (int i = 0; i < CmnText.Count; i++)
            {
                wordAddress[i] = (int)bw.BaseStream.Position;
                bw.Write(System.Text.Encoding.ASCII.GetBytes(CmnText[i]));
                bw.Write((byte)0);
            }

            bw.BaseStream.Seek(0, SeekOrigin.Begin);

            bw.Write(new byte[] { 0x23, 0x43, 0x55, 0x53, 0xfe, 0xff, 0x00, 0x00 });
            bw.Write(css.Length);
            bw.Write(72);
            bw.Write(Super.Length);
            bw.Write(Ultimate.Length);
            bw.Write(Evasive.Length);
            bw.Write(0);
            bw.Write(blast.Length);
            bw.Write(Awaken.Length);
            bw.Write(72 + (css.Length * 32));
            bw.Write(72 + (css.Length * 32) + (Super.Length * 68));
            bw.Write(72 + (css.Length * 32) + (Super.Length * 68) + (Ultimate.Length * 68));
            bw.Write(72 + (css.Length * 32) + (Super.Length * 68) + (Ultimate.Length * 68) + (Evasive.Length * 68));
            bw.Write(72 + (css.Length * 32) + (Super.Length * 68) + (Ultimate.Length * 68) + (Evasive.Length * 68));
            bw.Write(72 + (css.Length * 32) + (Super.Length * 68) + (Ultimate.Length * 68) + (Evasive.Length * 68) + (blast.Length * 68));

            bw.BaseStream.Seek(72, SeekOrigin.Begin);
            for (int i = 0; i < css.Length; i++)
            {
                bw.Write(css[i].charID);
                bw.Write(css[i].costumeID);

                for (int j = 0; j < 10; j++)
                    bw.Write(css[i].skill[j]);

                bw.BaseStream.Seek(4, SeekOrigin.Current);
            }

            for(int i = 0; i < Super.Length; i++)
                writeSkill(ref bw, Super[i], ref wordAddress, ref CmnText);

            for (int i = 0; i < Ultimate.Length; i++)
                writeSkill(ref bw, Ultimate[i], ref wordAddress, ref CmnText);

            for (int i = 0; i < Evasive.Length; i++)
                writeSkill(ref bw, Evasive[i], ref wordAddress, ref CmnText);

            for (int i = 0; i < blast.Length; i++)
                writeSkill(ref bw, blast[i], ref wordAddress, ref CmnText);

            for (int i = 0; i < Awaken.Length; i++)
                writeSkill(ref bw, Awaken[i], ref wordAddress, ref CmnText);


            bw.Close();
        }

        public static void writeSkill(ref BinaryWriter bw, skill s, ref int[] wordAddress, ref List<string> CmnText)
        {
            bw.Write(Encoding.ASCII.GetBytes(s.shortName));
            if (s.shortName.Length == 3)
                bw.BaseStream.Seek(5, SeekOrigin.Current);
            else
                bw.BaseStream.Seek(4, SeekOrigin.Current);

            bw.Write(s.id);
            bw.Write(s.id2);
            bw.Write(s.RaceLock);
            bw.Write(s.unk1);
            bw.Write(s.unk2);
            bw.Write(s.hair);
            bw.Write(s.unk3);

            for (int k = 0; k < s.Paths.Length; k++)
            {
                if (s.Paths[k] == "")
                    bw.Write((int)0);
                else
                    bw.Write(wordAddress[CmnText.IndexOf(s.Paths[k])]);
            }

            bw.BaseStream.Seek(2, SeekOrigin.Current);
            bw.Write(s.unk4);
            bw.Write(s.unk5);
            bw.Write(s.unk6);
            bw.Write(s.unk7);
            bw.Write(s.unk8);
            bw.Write(s.unk9);
            bw.Write(s.unk10);
            bw.Write(s.unk11);
        }
    }

    static class CUSMod
    {
        static void PatchSkillset(string path, charSkillSet cs)
        {




        }
    }
}
