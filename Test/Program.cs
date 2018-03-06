using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XV2Lib;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ODF_Char> o = ODF.Read("OriginalCharacterDefaultTable.odf");
            ODF.Write("OriginalCharacterDefaultTable.odf", o);
        }
    }
}
