using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace XV2Lib
{
    public struct Char_Model_Spec
    {
        public int id;
        public string shortname;
        public int unk1;
        public short unk2;
        public short unk3;
        public short unk4;
        public short unk5;
        public string[] Paths;//8
    }

    public static class CMS
    {
        public static Char_Model_Spec[] Read(string path)
        {
            Char_Model_Spec[] Data;
            BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open));


            br.BaseStream.Seek(8, SeekOrigin.Begin);
            int Count = br.ReadInt32();
            Data = new Char_Model_Spec[Count];
            int Offset = br.ReadInt32();
            for (int i = 0; i < Count; i++)
            {
                br.BaseStream.Seek(Offset + (84 * i), SeekOrigin.Begin);
                Data[i].id = br.ReadInt32();
                Data[i].shortname = System.Text.Encoding.ASCII.GetString(br.ReadBytes(3));
                br.BaseStream.Seek(9, SeekOrigin.Current);
                Data[i].unk1 = br.ReadInt32();
                Data[i].unk2 = br.ReadInt16();
                Data[i].unk3 = br.ReadInt16();
                Data[i].unk4 = br.ReadInt16();
                Data[i].unk5 = br.ReadInt16();
                br.BaseStream.Seek(4, SeekOrigin.Current);
                Data[i].Paths = new string[9];
                Data[i].Paths[0] = ReadText(ref br, br.ReadInt32());
                Data[i].Paths[1] = ReadText(ref br, br.ReadInt32());
                br.BaseStream.Seek(4, SeekOrigin.Current);
                Data[i].Paths[2] = ReadText(ref br, br.ReadInt32());
                Data[i].Paths[3] = ReadText(ref br, br.ReadInt32());//additional
                br.BaseStream.Seek(4, SeekOrigin.Current);
                Data[i].Paths[4] = ReadText(ref br, br.ReadInt32());
                Data[i].Paths[5] = ReadText(ref br, br.ReadInt32());
                Data[i].Paths[6] = ReadText(ref br, br.ReadInt32());
                Data[i].Paths[7] = ReadText(ref br, br.ReadInt32());
                br.BaseStream.Seek(8, SeekOrigin.Current);
                Data[i].Paths[8] = ReadText(ref br, br.ReadInt32());
            }

            br.Close();
            return Data;
        }

        public static string ReadText(ref BinaryReader br, int Address)
        {
            long position = br.BaseStream.Position;
            string rText = "";
            byte[] c;
            if (Address != 0)
            {
                br.BaseStream.Seek(Address, SeekOrigin.Begin);
                do
                {
                    c = br.ReadBytes(1);
                    if (c[0] != 0x00)
                        rText += System.Text.Encoding.ASCII.GetString(c);
                    else
                        break;
                }
                while (true);

                br.BaseStream.Seek(position, SeekOrigin.Begin);
            }
            return rText;
        }

        public static void Write(string path, Char_Model_Spec[] Data)
        {
            List<string> CmnText = new List<string>();
            for (int i = 0; i < Data.Length; i++)
            {
                for (int j = 0; j < Data[i].Paths.Length; j++)
                {
                    if (!CmnText.Contains(Data[i].Paths[j]))
                        CmnText.Add(Data[i].Paths[j]);
                }

            }

            int[] wordAddress = new int[CmnText.Count];
            int wordstartposition = 16 + (Data.Length * 84);
            using (BinaryWriter bw = new BinaryWriter(File.Create(path)))
            {
                bw.Write(new byte[] { 0x23, 0x43, 0x4D, 0x53, 0xFE, 0xFF, 0x00, 0x00 });
                bw.Write(Data.Length);
                bw.Write((int)16);
                bw.Seek(wordstartposition, SeekOrigin.Begin);
                for (int i = 0; i < CmnText.Count; i++)
                {
                    wordAddress[i] = (int)bw.BaseStream.Position;
                    bw.Write(System.Text.Encoding.ASCII.GetBytes(CmnText[i]));
                    bw.Write((byte)0);
                }

                for (int i = 0; i < Data.Length; i++)
                {
                    bw.BaseStream.Seek(16 + (84 * i), SeekOrigin.Begin);
                    bw.Write(Data[i].id);
                    bw.Write(System.Text.Encoding.ASCII.GetBytes(Data[i].shortname));
                    bw.BaseStream.Seek(9, SeekOrigin.Current);
                    bw.Write(Data[i].unk1);
                    bw.Write(Data[i].unk2);
                    bw.Write(Data[i].unk3);
                    bw.Write(Data[i].unk4);
                    bw.Write(Data[i].unk5);
                    bw.BaseStream.Seek(4, SeekOrigin.Current);
                    if (Data[i].Paths[0] == "")
                        bw.Write((int)0);
                    else
                        bw.Write(wordAddress[CmnText.IndexOf(Data[i].Paths[0])]);

                    if (Data[i].Paths[1] == "")
                        bw.Write((int)0);
                    else
                        bw.Write(wordAddress[CmnText.IndexOf(Data[i].Paths[1])]);

                    bw.BaseStream.Seek(4, SeekOrigin.Current);
                    if (Data[i].Paths[2] == "")
                        bw.Write((int)0);
                    else
                        bw.Write(wordAddress[CmnText.IndexOf(Data[i].Paths[2])]);

                    if (Data[i].Paths[3] == "")//additional
                        bw.Write((int)0);
                    else
                        bw.Write(wordAddress[CmnText.IndexOf(Data[i].Paths[3])]);

                    bw.BaseStream.Seek(4, SeekOrigin.Current);
                    if (Data[i].Paths[4] == "")
                        bw.Write((int)0);
                    else
                        bw.Write(wordAddress[CmnText.IndexOf(Data[i].Paths[4])]);

                    if (Data[i].Paths[5] == "")
                        bw.Write((int)0);
                    else
                        bw.Write(wordAddress[CmnText.IndexOf(Data[i].Paths[5])]);

                    if (Data[i].Paths[6] == "")
                        bw.Write((int)0);
                    else
                        bw.Write(wordAddress[CmnText.IndexOf(Data[i].Paths[6])]);

                    if (Data[i].Paths[7] == "")
                        bw.Write((int)0);
                    else
                        bw.Write(wordAddress[CmnText.IndexOf(Data[i].Paths[7])]);

                    bw.BaseStream.Seek(8, SeekOrigin.Current);
                    if (Data[i].Paths[8] == "")
                        bw.Write((int)0);
                    else
                        bw.Write(wordAddress[CmnText.IndexOf(Data[i].Paths[8])]);
                }

            }



        }

        public static void InjectWrite(ref BinaryWriter bw, Char_Model_Spec cms)
        {
            List<string> CmnText = new List<string>();
            
            for (int j = 0; j < cms.Paths.Length; j++)
            {
                if (!CmnText.Contains(cms.Paths[j]))
                    CmnText.Add(cms.Paths[j]);
            }

            int[] wordAddress = new int[CmnText.Count];
            int pos = (int)bw.BaseStream.Position;

            bw.BaseStream.Seek(84, SeekOrigin.Current);
            for (int i = 0; i < CmnText.Count; i++)
            {
                wordAddress[i] = (int)bw.BaseStream.Position;
                bw.Write(System.Text.Encoding.ASCII.GetBytes(CmnText[i]));
                bw.Write((byte)0);
            }

            bw.BaseStream.Seek(pos, SeekOrigin.Begin);

            bw.Write(cms.id);
            bw.Write(System.Text.Encoding.ASCII.GetBytes(cms.shortname));
            bw.BaseStream.Seek(9, SeekOrigin.Current);
            bw.Write(cms.unk1);
            bw.Write(cms.unk2);
            bw.Write(cms.unk3);
            bw.Write(cms.unk4);
            bw.Write(cms.unk5);
            bw.BaseStream.Seek(4, SeekOrigin.Current);
            if (cms.Paths[0] == "")
                bw.Write((int)0);
            else
                bw.Write(wordAddress[CmnText.IndexOf(cms.Paths[0])]);

            if (cms.Paths[1] == "")
                bw.Write((int)0);
            else
                bw.Write(wordAddress[CmnText.IndexOf(cms.Paths[1])]);

            bw.BaseStream.Seek(4, SeekOrigin.Current);
            if (cms.Paths[2] == "")
                bw.Write((int)0);
            else
                bw.Write(wordAddress[CmnText.IndexOf(cms.Paths[2])]);

            if (cms.Paths[3] == "")//additional
                bw.Write((int)0);
            else
                bw.Write(wordAddress[CmnText.IndexOf(cms.Paths[3])]);

            bw.BaseStream.Seek(4, SeekOrigin.Current);
            if (cms.Paths[4] == "")
                bw.Write((int)0);
            else
                bw.Write(wordAddress[CmnText.IndexOf(cms.Paths[4])]);

            if (cms.Paths[5] == "")
                bw.Write((int)0);
            else
                bw.Write(wordAddress[CmnText.IndexOf(cms.Paths[5])]);

            if (cms.Paths[6] == "")
                bw.Write((int)0);
            else
                bw.Write(wordAddress[CmnText.IndexOf(cms.Paths[6])]);

            if (cms.Paths[7] == "")
                bw.Write((int)0);
            else
                bw.Write(wordAddress[CmnText.IndexOf(cms.Paths[7])]);

            bw.BaseStream.Seek(8, SeekOrigin.Current);
            if (cms.Paths[8] == "")
                bw.Write((int)0);
            else
                bw.Write(wordAddress[CmnText.IndexOf(cms.Paths[8])]);

        }
    }
}
