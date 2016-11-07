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
        string Name;
        int offset;
        type _type;
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











            }





        }


    }
}
