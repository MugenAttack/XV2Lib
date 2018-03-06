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
        public string language = "en";
        public string XENOFolder ;
        

        public bool Read()
        {
            if (File.Exists("Settings.csv"))
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
                        case "XENO":
                            XENOFolder = sep[1];
                            break;
                    }
                }
                return true;
            }
            else
                return false;
        }

        public void Write()
        {
            StreamWriter sw = new StreamWriter(File.Create("Settings.csv"));
            sw.WriteLine("LANG," + language);
            sw.WriteLine("XV2," + XENOFolder);
            sw.Close();
        }

    }
}
