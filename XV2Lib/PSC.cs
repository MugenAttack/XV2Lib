using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XV2Lib
{
    struct PSC_Char
    {
        int id;
        PSC_Costume[] Costume_Data;
    }

    struct PSC_Costume
    {
        byte[] Data;
    }

    class PSC
    {
        PSC_Char[] list;
        SchemaBinary schema;



        public void Read(string path)
        {



        }

        public void Write(string path)
        {



        }


    }
}
