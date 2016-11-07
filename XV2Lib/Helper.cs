using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace XV2Lib
{
    public static class Helper
    {
        public static string ReadAddressText(BinaryReader br, int Address)
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
    }
}
