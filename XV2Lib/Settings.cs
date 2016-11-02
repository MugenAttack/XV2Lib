using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace XV2Lib
{
    public class Settings
    {
        public string language;
        public string MSGFolder;
        public string SysFolder;

        public void Read()
        {
            StreamReader sr = new StreamReader(File.Open("Settings.csv", FileMode.Open));
            
            string line;
            string[] sep;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                sep = line.Split(",".ToCharArray());
                switch (sep[0])
                {
                    case "LANG":
                        language = sep[1];
                        break;
                    case "MSG":
                        MSGFolder = sep[1];
                        break;
                    case "SYS":
                        SysFolder = sep[1];
                        break;
                }


            }
            
            
        }

        public void Write()
        {
            StreamWriter sw = new StreamWriter(File.Create("Settings.csv"));
            sw.WriteLine("LANG," + language);
            sw.WriteLine("MSG," + MSGFolder);
            sw.WriteLine("SYS," + SysFolder);
            sw.Close();
        }

    }
}
