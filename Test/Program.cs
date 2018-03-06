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
            List<OCO_Char> o = OCO.Read("MenuCostumeCustomList.oco");
            OCO.Write("MenuCostumeCustomList.oco", o);
        }
    }
}
