using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XV2Lib
{
    enum type{bin_byte,bin_int16,bin_int32,bin_float}

    struct BinaryDR //Binary Data Read
    {
        public int offset;
        public type _type;
    }

    class SchemaBinary
    {
        int maxSize;
        Dictionary<string,BinaryDR> DataSet;

        public void ReadSchema(string file)
        {
            StreamReader sr = new StreamReader(file);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] input = line.Split(",".ToCharArray());

                type t = type.bin_byte;
                input[2].Replace(" ", "");
                switch (input[2])
                {
                    case "byte":
                        t = type.bin_byte;
                        break;
                    case "int16":
                        t = type.bin_int16;
                        break;
                    case "int32":
                        t = type.bin_int32;
                        break;
                    case "float":
                        t = type.bin_float;
                        break;

                }

                BinaryDR BDR;
                BDR.offset = int.Parse(input[1]);
                BDR._type = t;
                DataSet.Add(input[0], BDR);

            }
        }


        public string[] getKeys()
        {
            return DataSet.Keys.ToArray();
        }

        public string getValueString(string key,ref byte[] Data)
        {
            switch(DataSet[key]._type)
            {
                case type.bin_byte:
                    return Data[DataSet[key].offset].ToString();
                    break;
                case type.bin_int16:
                    return BitConverter.ToInt16(Data,DataSet[key].offset).ToString();
                    break;
                case type.bin_int32:
                    return BitConverter.ToInt32(Data, DataSet[key].offset).ToString();
                    break;
                case type.bin_float:
                    return BitConverter.ToSingle(Data, DataSet[key].offset).ToString();
                    break;

            }

            return "";
        }

        public void setValueString(string key, ref byte[] Data, string val)
        {
            switch (DataSet[key]._type)
            {
                case type.bin_byte:
                    byte p;
                    if (byte.TryParse(val,out p))
                        Data[DataSet[key].offset] = p;
                    break;
                case type.bin_int16:
                    short p16;
                    if (short.TryParse(val, out p16))
                        Array.Copy(BitConverter.GetBytes(p16), 0, Data, DataSet[key].offset, 2);
                    break;
                case type.bin_int32:
                    int p32;
                    if (int.TryParse(val, out p32))
                        Array.Copy(BitConverter.GetBytes(p32), 0, Data, DataSet[key].offset, 4);
                    break;
                case type.bin_float:
                    float pf;
                    if (float.TryParse(val, out pf))
                        Array.Copy(BitConverter.GetBytes(pf), 0, Data, DataSet[key].offset, 4);
                    break;

            }

        }
    }
}
