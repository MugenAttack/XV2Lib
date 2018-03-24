using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using XV2Lib;

namespace XV2ListGeneratorCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter in Separator: ");
            string sep = Console.ReadLine();

            skill[] Super = new skill[1];
            skill[] Ultimate = new skill[1];
            skill[] Evasive = new skill[1];
            skill[] blast = new skill[1];
            skill[] Awaken = new skill[1];
            Settings s = new Settings();
            s.Read();

            CUS.ReadSkills(s.XENOFolder + "data/system" + "/custom_skill.cus", ref Super, ref Ultimate, ref Evasive, ref Awaken, ref blast);

            MSG m = MSGStream.Read(s.XENOFolder + "data/msg" + "/proper_noun_skill_spa_name_" + s.language + ".msg");

            StreamWriter sw = new StreamWriter("Super_" + s.language + ".csv");
            sw.WriteLine("ID (Numeric)" + sep + "ID (HEX)" + sep + "Short Name" + sep + "Full Name");
            foreach (skill sk in Super)
            {
                string txt = m.Find("spe_skill_" + sk.id2.ToString("0000"));
                sw.WriteLine(sk.id.ToString() + sep + ReverseHexString4(sk.id.ToString("x4")) + sep + sk.shortName + sep + txt);
            }

            sw.Close();

            m = MSGStream.Read(s.XENOFolder + "data/msg" + "/proper_noun_skill_ult_name_" + s.language + ".msg");
            sw = new StreamWriter("Ultimate_" + s.language + ".csv");
            sw.WriteLine("ID (Numeric)" + sep + "ID (HEX)" + sep + "Short Name" + sep + "Full Name");
            foreach (skill sk in Ultimate)
            {
                string txt = m.Find("ult_" + sk.id2.ToString("0000"));
                sw.WriteLine(sk.id.ToString() + sep + ReverseHexString4(sk.id.ToString("x4")) + sep + sk.shortName + sep + txt);
            }

            sw.Close();

            m = MSGStream.Read(s.XENOFolder + "data/msg" + "/proper_noun_skill_esc_name_" + s.language + ".msg");
            sw = new StreamWriter("Evasive_" + s.language + ".csv");
            sw.WriteLine("ID (Numeric)" + sep + "ID (HEX)" + sep + "Short Name" + sep + "Full Name");
            foreach (skill sk in Evasive)
            {
                string txt = m.Find("avoid_skill_" + sk.id2.ToString("0000"));
                sw.WriteLine(sk.id.ToString() + sep + ReverseHexString4(sk.id.ToString("x4")) + sep + sk.shortName + sep + txt);
            }

            sw.Close();

            m = MSGStream.Read(s.XENOFolder + "data/msg" + "/proper_noun_skill_met_name_" + s.language + ".msg");
            sw = new StreamWriter("Awaken_" + s.language + ".csv");
            sw.WriteLine("ID (Numeric)" + sep + "ID (HEX)" + sep + "Short Name" + sep + "Full Name");
            foreach (skill sk in Awaken)
            {
                string txt = m.Find("met_skill_" + sk.id2.ToString("0000"));
                sw.WriteLine(sk.id.ToString() + sep + ReverseHexString4(sk.id.ToString("x4")) + sep + sk.shortName + sep + txt);
            }
            sw.Close();

            m = MSGStream.Read(s.XENOFolder + "data/msg" + "/proper_noun_character_name_" + s.language + ".msg");
            Char_Model_Spec[] cms = CMS.Read(s.XENOFolder + "data/system" + "/char_model_spec.cms");
            sw = new StreamWriter("Character_" + s.language + ".csv");
            sw.WriteLine("ID (Numeric)" + sep + "ID (HEX)" + sep + "Short Name" + sep + "Full Name");
            foreach (Char_Model_Spec c in cms)
            {
                string txt = m.Find("chara_" + c.shortname + "_000");
                sw.WriteLine(c.id.ToString() + sep + ReverseHexString4(c.id.ToString("x4")) + sep + c.shortname + sep + txt);
            }
            sw.Close();

            m = MSGStream.Read(s.XENOFolder + "data/msg" + "/proper_noun_talisman_name_" + s.language + ".msg");
            IDB idb = new IDB();
            idb.Read(s.XENOFolder + "data/system/item/talisman_item.idb");
            sw = new StreamWriter("Super_Soul_" + s.language + ".csv");
            sw.WriteLine("ID (Numeric)" + sep + "ID (HEX)" + sep + "Name");
            foreach (IDB_Data i in idb.items)
            {
                string txt = m.Find(i.name);
                sw.WriteLine(i.id.ToString() + sep + ReverseHexString4(i.id.ToString("x4")) + sep + txt);
            }
            sw.Close();

            m = MSGStream.Read(s.XENOFolder + "data/msg" + "/proper_noun_costume_name_" + s.language + ".msg");
            idb = new IDB();
            idb.Read(s.XENOFolder + "data/system/item/costume_top_item.idb");
            sw = new StreamWriter("Costume_" + s.language + ".csv");
            sw.WriteLine("ID (Numeric)" + sep + "ID (HEX)" + sep + "Model ID (Numeric)" + sep + "Model ID (Hex)" + sep + "Name");
            foreach (IDB_Data i in idb.items)
            {
                string txt = m.Find(i.name);
                sw.WriteLine(i.id.ToString() + sep + ReverseHexString4(i.id.ToString("x4")) + sep + i.extra.ToString() + sep + ReverseHexString4(i.extra.ToString("x4")) + sep + txt);
            }
            sw.Close();

            m = MSGStream.Read(s.XENOFolder + "data/msg" + "/proper_noun_accessory_name_" + s.language + ".msg");
            idb = new IDB();
            idb.Read(s.XENOFolder + "data/system/item/accessory_item.idb");
            sw = new StreamWriter("Accessory_" + s.language + ".csv");
            sw.WriteLine("ID (Numeric)" + sep + "ID (HEX)" + sep + "Model ID (Numeric)" + sep + "Model ID (Hex)" + sep + "Name");
            foreach (IDB_Data i in idb.items)
            {
                string txt = m.Find(i.name);
                sw.WriteLine(i.id.ToString() + sep + ReverseHexString4(i.id.ToString("x4")) + sep + i.extra.ToString() + sep + ReverseHexString4(i.extra.ToString("x4")) + sep + txt);
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
