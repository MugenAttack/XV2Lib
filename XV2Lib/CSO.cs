using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XV2Lib
{
    public struct CSO_Data
    {
        public int Char_ID;
        public int Costume_ID;
        public string[] Paths;
    }

    public static class CSO
    {
       
        public static CSO_Data[] Read(string path)
        {
            CSO_Data[] Data;
            BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open));
            
                
                br.BaseStream.Seek(8, SeekOrigin.Begin);
                int Count = br.ReadInt32();
                Data = new CSO_Data[Count];
                int Offset = br.ReadInt32();

                for (int i = 0; i < Count; i++)
                {
                    br.BaseStream.Seek(Offset + (32 * i), SeekOrigin.Begin);
                    Data[i].Char_ID = br.ReadInt32();
                    Data[i].Costume_ID = br.ReadInt32();
                    Data[i].Paths = new string[4];
                    Data[i].Paths[0] = TextAtAddress(ref br,br.ReadInt32());
                    Data[i].Paths[1] = TextAtAddress(ref br, br.ReadInt32());
                    Data[i].Paths[2] = TextAtAddress(ref br, br.ReadInt32()); 
                    Data[i].Paths[3] = TextAtAddress(ref br, br.ReadInt32());
                   

                }

            br.Close();
            return Data;
        }

        public static string TextAtAddress(ref BinaryReader br, int Address)
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

        public static void Write(CSO_Data[] Data, string FileName)
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
            int wordstartposition = 16 + (Data.Length * 32);
            using (BinaryWriter bw = new BinaryWriter(File.Create(FileName)))
            {
                bw.Write(new byte[] { 0x23, 0x43, 0x53, 0x4F, 0xFE, 0xFF, 0x00, 0x00 });
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
                    bw.BaseStream.Seek(16 + (32 * i), SeekOrigin.Begin);
                    bw.Write(Data[i].Char_ID);
                    bw.Write(Data[i].Costume_ID);
                    bw.Write(wordAddress[CmnText.IndexOf(Data[i].Paths[0])]);
                    bw.Write(wordAddress[CmnText.IndexOf(Data[i].Paths[1])]);
                    bw.Write(wordAddress[CmnText.IndexOf(Data[i].Paths[2])]);
                    bw.Write(wordAddress[CmnText.IndexOf(Data[i].Paths[3])]);
                 
                }


            }

        }
    }
}
