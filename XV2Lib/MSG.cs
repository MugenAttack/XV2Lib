using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace XV2Lib
{
    
        public class MSG
        {
            public int type;
            public msgData[] data;

            public string Find(string id)
            {
                foreach (msgData m in data)
                {
                    if (m.NameID == id)
                        return m.Lines[0];
                }
                return "";
            }

            public string Find(int id)
            {
                foreach (msgData m in data)
                {
                    if (m.ID == id)
                        return m.Lines[0];
                }
                return "";
            }
        }

        public struct msgData
        {
            public string NameID;
            public int ID;
            public string[] Lines;
        }


    //msg stream loads msg data
    public static class MSGStream
    {
        public static MSG Read(string FilePath)
        {
            MSG file = new MSG();
            using (BinaryReader br = new BinaryReader(File.Open(FilePath, FileMode.Open)))
            {
                br.BaseStream.Seek(4, SeekOrigin.Begin);
                file.type = br.ReadInt16();
                br.BaseStream.Seek(2, SeekOrigin.Current);
                file.data = new msgData[br.ReadInt32()];

                //read NameID
                int startaddress = br.ReadInt32();
                for (int i = 0; i < file.data.Length; i++)
                {
                    br.BaseStream.Seek(startaddress + (i * 16), SeekOrigin.Begin);
                    int textaddress = br.ReadInt32();
                    br.BaseStream.Seek(4, SeekOrigin.Current);
                    int charCount = br.ReadInt32();
                    br.BaseStream.Seek(textaddress, SeekOrigin.Begin);
                    if (file.type == 256)
                        file.data[i].NameID = Encoding.Unicode.GetString(br.ReadBytes(charCount - 2));
                    else if (file.type == 512)
                        file.data[i].NameID = Encoding.UTF32.GetString(br.ReadBytes(charCount - 4));
                    else
                        file.data[i].NameID = Encoding.ASCII.GetString(br.ReadBytes(charCount - 1));
                }

                // read ID
                br.BaseStream.Seek(16, SeekOrigin.Begin);
                startaddress = br.ReadInt32();
                for (int i = 0; i < file.data.Length; i++)
                {
                    br.BaseStream.Seek(startaddress + (i * 4), SeekOrigin.Begin);
                    file.data[i].ID = br.ReadInt32();
                }

                //read line/s
                br.BaseStream.Seek(20, SeekOrigin.Begin);
                startaddress = br.ReadInt32();
                int address;
                for (int i = 0; i < file.data.Length; i++)
                {
                    br.BaseStream.Seek(startaddress + (i * 8), SeekOrigin.Begin);
                    file.data[i].Lines = new string[br.ReadInt32()];
                    address = br.ReadInt32();
                    int address2;
                    for (int j = 0; j < file.data[i].Lines.Length; j++)
                    {
                        br.BaseStream.Seek(address + (j * 16), SeekOrigin.Begin);
                        address2 = br.ReadInt32();
                        br.BaseStream.Seek(4, SeekOrigin.Current);
                        int charCount = br.ReadInt32();
                        br.BaseStream.Seek(address2, SeekOrigin.Begin);
                        if (file.type == 512)
                            file.data[i].Lines[j] = Encoding.UTF32.GetString(br.ReadBytes(charCount - 4));
                        else
                            file.data[i].Lines[j] = Encoding.Unicode.GetString(br.ReadBytes(charCount - 2));
                    }
                }


                for (int i = 0; i < file.data.Length; i++)
                {
                    for (int j = 0; j < file.data[i].Lines.Length; j++)
                    {
                        file.data[i].Lines[j] = file.data[i].Lines[j].Replace(@"&apos;", @"'");
                    }
                }

            }

            return file;
        }

        public static void Write(MSG file, string FilePath)
        {
            for (int i = 0; i < file.data.Length; i++)
            {
                for (int j = 0; j < file.data[i].Lines.Length; j++)
                {
                    file.data[i].Lines[j] = file.data[i].Lines[j].Replace(@"'", @"&apos;");
                }
            }

            //MessageBox.Show("setup");
            int byteCount = 0;
            int TopLength = 32;
            int Mid1Length = file.data.Length * 16;
            int Mid2Length = file.data.Length * 4;
            int Mid3Length = file.data.Length * 8;
            int lineCount = 0;
            for (int i = 0; i < file.data.Length; i++)
                lineCount += file.data[i].Lines.Length;
            int Mid4Length = lineCount * 16;
            byteCount = TopLength + Mid1Length + Mid2Length + Mid3Length + Mid4Length;
            byte[] fileData1 = new byte[byteCount];
            List<byte> fileDataText = new List<byte>();
            int TopStart = 0;
            int Mid1Start = 32;
            int Mid2Start = Mid1Start + Mid1Length;
            int Mid3Start = Mid2Start + Mid2Length;
            int Mid4Start = Mid3Start + Mid3Length;
            int LastStart = Mid4Start + Mid4Length;
            //MessageBox.Show("setup");
            //generate top
            fileData1[0] = 0x23; fileData1[1] = 0x4D; fileData1[2] = 0x53; fileData1[3] = 0x47;
            if (file.type == 512)
            { fileData1[4] = 0x00; fileData1[5] = 0x02; fileData1[6] = 0x02; fileData1[7] = 0x00; }
            else if (file.type == 256)
            { fileData1[4] = 0x00; fileData1[5] = 0x01; fileData1[6] = 0x01; fileData1[7] = 0x00; }
            else
            { fileData1[4] = 0x00; fileData1[5] = 0x00; fileData1[6] = 0x01; fileData1[7] = 0x00; }

            byte[] pass;
            pass = BitConverter.GetBytes(file.data.Length);
            Applybyte(ref fileData1, pass, 8, 4);
            pass = BitConverter.GetBytes(32);
            Applybyte(ref fileData1, pass, 12, 4);
            pass = BitConverter.GetBytes(Mid2Start);
            Applybyte(ref fileData1, pass, 16, 4);
            pass = BitConverter.GetBytes(Mid3Start);
            Applybyte(ref fileData1, pass, 20, 4);
            pass = BitConverter.GetBytes(file.data.Length);
            Applybyte(ref fileData1, pass, 24, 4);
            pass = BitConverter.GetBytes(Mid4Start);
            Applybyte(ref fileData1, pass, 28, 4);
            //MessageBox.Show("setup 1");
            //generate Mid section 1
            for (int i = 0; i < file.data.Length; i++)
            {
                Applybyte(ref fileData1,
                          GenWordsBytes(file.data[i].NameID, file.type, ref fileDataText, LastStart),
                          Mid1Start + (i * 16),
                          16);
            }
            //MessageBox.Show("setup 2");
            //generate Mid section 2
            for (int i = 0; i < file.data.Length; i++)
            {
                Applybyte(ref fileData1, BitConverter.GetBytes(file.data[i].ID), Mid2Start + (i * 4), 4);
            }
            //MessageBox.Show("setup 3 4");
            //generate Mid section 3 & 4
            int ListCount = 0;
            int address3;
            for (int i = 0; i < file.data.Length; i++)
            {
                address3 = Mid4Start + (ListCount * 16);
                for (int j = 0; j < file.data[i].Lines.Length; j++)
                {
                    int t;
                    if (file.type != 512)
                        t = 256;
                    else
                        t = 512;
                            

                    Applybyte(ref fileData1,
                          GenWordsBytes(file.data[i].Lines[j], t , ref fileDataText, LastStart),
                          Mid4Start + (ListCount * 16),
                          16);
                    ListCount++;
                }
                Applybyte(ref fileData1, BitConverter.GetBytes(file.data[i].Lines.Length), Mid3Start + (i * 8), 4);
                Applybyte(ref fileData1, BitConverter.GetBytes(address3), Mid3Start + (i * 8) + 4, 4);
            }
            //MessageBox.Show("setup final");
            List<byte> finalize = new List<byte>();
            finalize.AddRange(fileData1);
            finalize.AddRange(fileDataText);

            FileStream fs = new FileStream(FilePath, FileMode.Create);
            fs.Write(finalize.ToArray(), 0, finalize.Count);
            fs.Close();

        }

        public static void Applybyte(ref byte[] file, byte[] data, int pos, int count)
        {
            for (int i = 0; i < count; i++)
                file[pos + i] = data[i];
        }

        public static byte[] GenWordsBytes(string Line, int type, ref List<byte> text, int bCount)
        {

            byte[] charArray;
            if (type == 512)
            {
                charArray = new byte[(Line.Length + 1) * 4];
                charArray = Encoding.UTF32.GetBytes(Line + "\0");

            }
            else if (type == 256)
            {
                charArray = new byte[(Line.Length + 1) * 2];
                charArray = Encoding.Unicode.GetBytes(Line + "\0");

            }
            else
            {
                charArray = new byte[Line.Length + 1];
                charArray = Encoding.ASCII.GetBytes(Line + "\0");
            }

            byte[] AddressInfo = { 0x00, 0x00, 0x00, 0x00,
                                   0x00, 0x00, 0x00, 0x00,
                                   0x00, 0x00, 0x00, 0x00,
                                   0x00, 0x00, 0x00, 0x00 };
            Applybyte(ref AddressInfo, BitConverter.GetBytes(bCount + text.Count), 0, 4); //address of text
            Applybyte(ref AddressInfo, BitConverter.GetBytes(Line.Length), 4, 4);
            Applybyte(ref AddressInfo, BitConverter.GetBytes(charArray.Length), 8, 4);

            text.AddRange(charArray);

            return AddressInfo;
        }

    }
}
