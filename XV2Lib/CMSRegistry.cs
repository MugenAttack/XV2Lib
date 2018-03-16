using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XV2Lib
{
    public struct CharReg
    {
        public int id;
        public string shortName;
        public string name;
    }

    class CMSRegistry
    {
        public List<Char_Model_Spec> Char = new List<Char_Model_Spec>();
        public List<CharReg> cReg;
        private MSG msgName;
        private bool useMSG;

        public void readCMS(string FileName)
        {
            this.Char.Clear();
            this.Char.AddRange((IEnumerable<Char_Model_Spec>)CMS.Read(FileName));
        }

        public void BuildRegistry(string MSGFolder, string lang)
        {
            this.cReg = new List<CharReg>();
            if (File.Exists(MSGFolder + "/proper_noun_character_name_" + lang + ".msg"))
            {
                this.useMSG = true;
                this.msgName = MSGStream.Read(MSGFolder + "/proper_noun_character_name_" + lang + ".msg");
                for (int index = 0; index < this.Char.Count; ++index)
                {
                    CharReg charReg;
                    charReg.id = this.Char[index].id;
                    charReg.shortName = this.Char[index].shortname;
                    charReg.name = this.msgName.Find("chara_" + this.Char[index].shortname + "_000");
                    if (charReg.name == "")
                        charReg.name = charReg.shortName;
                    this.cReg.Add(charReg);
                }
            }
            else
            {
                this.useMSG = false;
                for (int index = 0; index < this.Char.Count; ++index)
                {
                    CharReg charReg;
                    charReg.id = this.Char[index].id;
                    charReg.shortName = this.Char[index].shortname;
                    charReg.name = charReg.shortName;
                    this.cReg.Add(charReg);
                }
            }
        }

        public string getCostumeName(int charID, int costID)
        {
            int charaLoc = this.getCharaLoc(charID);
            if (charaLoc != -1 && costID != 0)
            {
                string str = this.msgName.Find("chara_" + this.cReg[charaLoc].shortName + "_" + costID.ToString("000"));
                if (str != "")
                    return costID.ToString("00") + " (" + str + ")";
            }
            return costID.ToString("00");
        }

        public int getCharaLoc(int id)
        {
            for (int index = 0; index < this.cReg.Count; ++index)
            {
                if (id == this.cReg[index].id)
                    return index;
            }
            return -1;
        }

        public string getCharaName(int id)
        {
            for (int index = 0; index < this.cReg.Count; ++index)
            {
                if (id == this.cReg[index].id)
                    return this.cReg[index].name;
            }
            return id.ToString("000");
        }
    }
}

