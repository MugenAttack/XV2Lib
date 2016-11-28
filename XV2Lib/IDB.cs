using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace XV2Lib
{
    public struct IDB_Data
    {
        public short id;
        public short star;
        public short name;
        public short desc;
        public short type;
        public short unk1;
        public short unk2;
        public short unk3;
        public int buy;
        public int sell;
        public int racelock;
        public int tp;
        public int extra;

        public byte[] E_set1;
        public byte[] E_set2;
        public byte[] E_set3;
    }

    public class IDB
    {
        public SchemaBinary schema;
        public IDB_Data[] items;

        public IDB()
        {
           
        }

        public void SetSchema(string schemaPath)
        {
            schema = new SchemaBinary();
            schema.ReadSchema(schemaPath);
        }

        public void Read(string FileName)
        {
            using (BinaryReader br = new BinaryReader(File.Open(FileName, FileMode.Open)))
            {
                br.BaseStream.Seek(8, SeekOrigin.Begin);
                int Count = br.ReadInt32();
                br.BaseStream.Seek(16, SeekOrigin.Begin);
                items = new IDB_Data[Count];
                
                for (int i = 0; i < Count; i++)
                {
                    br.BaseStream.Seek(16 + (720 * i), SeekOrigin.Begin);
                    items[i].id = br.ReadInt16();
                    items[i].star = br.ReadInt16();
                    items[i].name = br.ReadInt16();
                    items[i].desc = br.ReadInt16();
                    items[i].type = br.ReadInt16();
                    items[i].unk1 = br.ReadInt16();
                    items[i].unk2 = br.ReadInt16();
                    items[i].unk3 = br.ReadInt16();

                    items[i].buy = br.ReadInt32();
                    items[i].sell = br.ReadInt32();
                    items[i].racelock = br.ReadInt32();
                    items[i].tp = br.ReadInt32();
                    items[i].extra = br.ReadInt32();

                    br.BaseStream.Seek(12, SeekOrigin.Current);
                    items[i].E_set1 = br.ReadBytes(224);
                    items[i].E_set2 = br.ReadBytes(224);
                    items[i].E_set3 = br.ReadBytes(224);
                }


            }
        }

        public void Write(string FileName)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(FileName, FileMode.Create)))
            {
                bw.Write(new byte[] { 0x23, 0x49, 0x44, 0x42, 0xfe, 0xff, 0x07, 0x00 });
                bw.Write(items.Length);
                bw.Write(16);

                for (int i = 0; i < items.Length; i++)
                {
                    bw.Write(items[i].id);
                    bw.Write(items[i].star);
                    bw.Write(items[i].name);
                    bw.Write(items[i].desc);
                    bw.Write(items[i].type);
                    bw.Write(items[i].unk1);
                    bw.Write(items[i].unk2);
                    bw.Write(items[i].unk3);

                    bw.Write(items[i].buy);
                    bw.Write(items[i].sell);
                    bw.Write(items[i].racelock);
                    bw.Write(items[i].tp);
                    bw.Write(items[i].extra);
                    bw.BaseStream.Seek(12, SeekOrigin.Current);

                    bw.Write(items[i].E_set1);
                    bw.Write(items[i].E_set2);
                    bw.Write(items[i].E_set3);
                }


            }
        }

        public void Sort()
        {

        }

    }
}
