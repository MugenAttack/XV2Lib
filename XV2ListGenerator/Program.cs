using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XV2Lib;
using System.IO;
namespace XV2ListGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            skill[] Super = new skill[1];
            skill[] Ultimate = new skill[1]; ;
            skill[] Evasive = new skill[1]; ;
            skill[] blast = new skill[1]; ;
            skill[] Awaken = new skill[1]; ;
            Settings s = new Settings();
            s.Read();

            CUS.ReadSkills(s.SysFolder + "/custom_skill.cus", ref Super, ref Ultimate, ref Evasive, ref Awaken, ref blast);

            MSG m = MSGStream.Read(s.MSGFolder + "/proper_noun_skill_spa_name_" + s.language + ".msg");

            StreamWriter sw = new StreamWriter("Super_" + s.language + ".txt");
            foreach (skill sk in Super)
            {
                string txt = m.Find("spe_skill_" + sk.id2.ToString("0000"));
                sw.WriteLine(sk.id.ToString() + " - " + ReverseHexString4(sk.id.ToString("x4")) + " - " + sk.shortName + " - " + txt);
            }

            sw.Close();

            m = MSGStream.Read(s.MSGFolder + "/proper_noun_skill_ult_name_" + s.language + ".msg");
            sw = new StreamWriter("Ultimate_" + s.language + ".txt");
            foreach (skill sk in Ultimate)
            {
                string txt = m.Find("ult_" + sk.id2.ToString("0000"));
                sw.WriteLine(sk.id.ToString() + " - " + ReverseHexString4(sk.id.ToString("x4")) + " - " + sk.shortName + " - " + txt);
            }

            sw.Close();

            m = MSGStream.Read(s.MSGFolder + "/proper_noun_skill_esc_name_" + s.language + ".msg");
            sw = new StreamWriter("Evasive_" + s.language + ".txt");
            foreach (skill sk in Evasive)
            {
                string txt = m.Find("avoid_skill_" + sk.id2.ToString("0000"));
                sw.WriteLine(sk.id.ToString() + " - " + ReverseHexString4(sk.id.ToString("x4")) + " - " + sk.shortName + " - " + txt);
            }

            sw.Close();

            m = MSGStream.Read(s.MSGFolder + "/proper_noun_skill_met_name_" + s.language + ".msg");
            sw = new StreamWriter("Awaken_" + s.language + ".txt");
            foreach (skill sk in Awaken)
            {
                string txt = m.Find("met_skill_" + sk.id2.ToString("0000"));
                sw.WriteLine(sk.id.ToString() + " - " + ReverseHexString4(sk.id.ToString("x4")) + " - " + sk.shortName + " - " + txt);
            }

            sw.Close();
        }

        static string ReverseHexString4(string h)
        {
            //split string
            string[] hs = new string[2];
            hs[0] = h.Substring(0, 2);
            hs[1] = h.Substring(2, 2);
            return hs[1] + hs[0]; 
        }
    }
}
