using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace XV2Lib
{
    public struct AGDItem
    {
        public int Level;
        public int ExpToNext;
        public int RequiredExp;
        public int AttributePoints;
    }

    public static class AGD
    {
        public static AGDItem[] Read(string FileName)
        {
            byte[] file = File.ReadAllBytes(FileName);
            AGDItem[] LEVELS = new AGDItem[BitConverter.ToInt32(file, 8)];
            for (int i = 0; i < LEVELS.Length; i++)
            {
                LEVELS[i].Level = BitConverter.ToInt32(file, 16 + (i * 16));
                LEVELS[i].ExpToNext = BitConverter.ToInt32(file, 16 + (i * 16) + 4);
                LEVELS[i].RequiredExp = BitConverter.ToInt32(file, 16 + (i * 16) + 8);
                LEVELS[i].AttributePoints = BitConverter.ToInt32(file, 16 + (i * 16) + 12);


            }
            return LEVELS;
        }

        public static void Write(string FileName, AGDItem[] LEVELS)
        {
            //check if negative
            for (int i = 0; i < LEVELS.Length; i++)
            {
                if (LEVELS[i].ExpToNext < 0)
                    return;
            }

            List<byte> filebyte = new List<byte>();
            filebyte.AddRange(new byte[] { 0x23, 0x41, 0x47, 0x44, 0xFE, 0xFF, 0x10, 0x00 });
            filebyte.AddRange(BitConverter.GetBytes(LEVELS.Length));
            filebyte.AddRange(BitConverter.GetBytes(16));

            for (int i = 0; i < LEVELS.Length; i++)
            {
                filebyte.AddRange(BitConverter.GetBytes(LEVELS[i].Level));
                filebyte.AddRange(BitConverter.GetBytes(LEVELS[i].ExpToNext));
                filebyte.AddRange(BitConverter.GetBytes(LEVELS[i].RequiredExp));
                filebyte.AddRange(BitConverter.GetBytes(LEVELS[i].AttributePoints));
            }

            FileStream file = new FileStream(FileName, FileMode.Create);
            file.Write(filebyte.ToArray(), 0, filebyte.Count);
            file.Close();
        }
    }
}
