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
            List<OCT_Char> c = OCT.Read("MenuTalismanCustomList.oct");
            OCT.Write("MenuTalismanCustomList.oct", c);
        }
    }
}
