using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XV2Lib
{
    public struct SkillReg
    {
        public short id;
        public string shortName;
        public string name;
    }

    public class CUSRegistry
    {
        public List<charSkillSet> css = new List<charSkillSet>();
        public List<skill> Super = new List<skill>();
        public List<skill> Ultimate = new List<skill>();
        public List<skill> Evasive = new List<skill>();
        public List<skill> blast = new List<skill>();
        public List<skill> Awaken = new List<skill>();
        public List<SkillReg> superReg = new List<SkillReg>();
        public List<SkillReg> ultimateReg = new List<SkillReg>();
        public List<SkillReg> evasiveReg = new List<SkillReg>();
        public List<SkillReg> blastReg = new List<SkillReg>();
        public List<SkillReg> awakenReg = new List<SkillReg>();

        public void readCUS(string cusPath)
        {
            charSkillSet[] css = new charSkillSet[1];
            skill[] Super = new skill[1];
            skill[] Ultimate = new skill[1];
            skill[] Evasive = new skill[1];
            skill[] blast = new skill[1];
            skill[] Awaken = new skill[1];
            CUS.Read(cusPath, ref css, ref Super, ref Ultimate, ref Evasive, ref Awaken, ref blast);
            this.css.AddRange((IEnumerable<charSkillSet>)css);
            this.Super.AddRange((IEnumerable<skill>)Super);
            this.Ultimate.AddRange((IEnumerable<skill>)Ultimate);
            this.Evasive.AddRange((IEnumerable<skill>)Evasive);
            this.blast.AddRange((IEnumerable<skill>)blast);
            this.Awaken.AddRange((IEnumerable<skill>)Awaken);
        }

        public void BuildRegistry(string Msgfolder, string lang)
        {
            if (Directory.Exists(Msgfolder))
            {
                MSG msg1 = MSGStream.Read(Msgfolder + "\\proper_noun_skill_spa_name_" + lang + ".msg");
                this.superReg.Clear();
                SkillReg skillReg;
                skill skill;
                for (int index = 0; index < this.Super.Count; ++index)
                {
                    skillReg.id = this.Super[index].id;
                    skillReg.shortName = this.Super[index].shortName;
                    string str1 = "spe_skill_";
                    skill = this.Super[index];
                    string str2 = skill.id2.ToString("0000");
                    string id = str1 + str2;
                    string str3 = msg1.Find(id);
                    skillReg.name = str3;
                    this.superReg.Add(skillReg);
                }
                MSG msg2 = MSGStream.Read(Msgfolder + "\\proper_noun_skill_ult_name_" + lang + ".msg");
                this.ultimateReg.Clear();
                for (int index = 0; index < this.Ultimate.Count; ++index)
                {
                    skillReg.id = this.Ultimate[index].id;
                    skillReg.shortName = this.Ultimate[index].shortName;
                    string str1 = "ult_";
                    skill = this.Ultimate[index];
                    string str2 = skill.id2.ToString("0000");
                    string id = str1 + str2;
                    string str3 = msg2.Find(id);
                    skillReg.name = str3;
                    this.ultimateReg.Add(skillReg);
                }
                MSG msg3 = MSGStream.Read(Msgfolder + "\\proper_noun_skill_esc_name_" + lang + ".msg");
                this.evasiveReg.Clear();
                for (int index = 0; index < this.Evasive.Count; ++index)
                {
                    skillReg.id = this.Evasive[index].id;
                    skillReg.shortName = this.Evasive[index].shortName;
                    string str1 = "avoid_skill_";
                    skill = this.Evasive[index];
                    string str2 = skill.id2.ToString("0000");
                    string id = str1 + str2;
                    string str3 = msg2.Find(id);
                    skillReg.name = str3;
                    this.evasiveReg.Add(skillReg);
                }
                this.blastReg.Clear();
                for (int index = 0; index < this.blast.Count; ++index)
                {
                    skillReg.id = this.blast[index].id;
                    skillReg.shortName = this.blast[index].shortName;
                    skillReg.name = "";
                    this.blastReg.Add(skillReg);
                }
                MSG msg4 = MSGStream.Read(Msgfolder + "\\proper_noun_skill_met_name_" + lang + ".msg");
                this.awakenReg.Clear();
                for (int index = 0; index < this.Awaken.Count; ++index)
                {
                    skillReg.id = this.Awaken[index].id;
                    skillReg.shortName = this.Awaken[index].shortName;
                    string str1 = "met_skill_";
                    skill = this.Awaken[index];
                    string str2 = skill.id2.ToString("0000");
                    string id = str1 + str2;
                    string str3 = msg4.Find(id);
                    skillReg.name = str3;
                    this.awakenReg.Add(skillReg);
                }
            }
            else
            {
                this.superReg.Clear();
                SkillReg skillReg;
                for (int index = 0; index < this.Super.Count; ++index)
                {
                    skillReg.id = this.Super[index].id;
                    skillReg.shortName = this.Super[index].shortName;
                    skillReg.name = "";
                    this.superReg.Add(skillReg);
                }
                this.ultimateReg.Clear();
                for (int index = 0; index < this.Ultimate.Count; ++index)
                {
                    skillReg.id = this.Ultimate[index].id;
                    skillReg.shortName = this.Ultimate[index].shortName;
                    skillReg.name = "";
                    this.ultimateReg.Add(skillReg);
                }
                this.evasiveReg.Clear();
                for (int index = 0; index < this.Evasive.Count; ++index)
                {
                    skillReg.id = this.Evasive[index].id;
                    skillReg.shortName = this.Evasive[index].shortName;
                    skillReg.name = "";
                    this.evasiveReg.Add(skillReg);
                }
                this.blastReg.Clear();
                for (int index = 0; index < this.blast.Count; ++index)
                {
                    skillReg.id = this.blast[index].id;
                    skillReg.shortName = this.blast[index].shortName;
                    skillReg.name = "";
                    this.blastReg.Add(skillReg);
                }
                this.awakenReg.Clear();
                for (int index = 0; index < this.Awaken.Count; ++index)
                {
                    skillReg.id = this.Awaken[index].id;
                    skillReg.shortName = this.Awaken[index].shortName;
                    skillReg.name = "";
                    this.awakenReg.Add(skillReg);
                }
            }
        }

        public void writeCUS(string cusPath)
        {
            charSkillSet[] charSkillSetArray = new charSkillSet[1];
            skill[] skillArray1 = new skill[1];
            skill[] skillArray2 = new skill[1];
            skill[] skillArray3 = new skill[1];
            skill[] skillArray4 = new skill[1];
            skill[] skillArray5 = new skill[1];
            charSkillSet[] array1 = this.css.ToArray();
            skill[] array2 = this.Super.ToArray();
            skill[] array3 = this.Ultimate.ToArray();
            skill[] array4 = this.Evasive.ToArray();
            skill[] array5 = this.blast.ToArray();
            skill[] array6 = this.Awaken.ToArray();
            CUS.Write(cusPath, ref array1, ref array2, ref array3, ref array4, ref array6, ref array5);
        }

        public int FindSkillIndex(int type, short id)
        {
            switch (type)
            {
                case 0:
                    for (int index = 0; index < this.superReg.Count; ++index)
                    {
                        if ((int)this.superReg[index].id == (int)id)
                            return index;
                    }
                    break;
                case 1:
                    for (int index = 0; index < this.ultimateReg.Count; ++index)
                    {
                        if ((int)this.ultimateReg[index].id == (int)id)
                            return index;
                    }
                    break;
                case 2:
                    for (int index = 0; index < this.evasiveReg.Count; ++index)
                    {
                        if ((int)this.evasiveReg[index].id == (int)id)
                            return index;
                    }
                    break;
                case 4:
                    for (int index = 0; index < this.blastReg.Count; ++index)
                    {
                        if ((int)this.blastReg[index].id == (int)id)
                            return index;
                    }
                    break;
                case 5:
                    for (int index = 0; index < this.awakenReg.Count; ++index)
                    {
                        if ((int)this.awakenReg[index].id == (int)id)
                            return index;
                    }
                    break;
            }
            return -1;
        }

        public string[] getSkillList(int type)
        {
            List<string> stringList = new List<string>();
            switch (type)
            {
                case 0:
                    for (int index = 0; index < this.superReg.Count; ++index)
                    {
                        if (this.superReg[index].name != "")
                            stringList.Add(this.superReg[index].name);
                        else
                            stringList.Add(this.superReg[index].shortName);
                    }
                    break;
                case 1:
                    for (int index = 0; index < this.ultimateReg.Count; ++index)
                    {
                        if (this.ultimateReg[index].name != "")
                            stringList.Add(this.ultimateReg[index].name);
                        else
                            stringList.Add(this.ultimateReg[index].shortName);
                    }
                    break;
                case 2:
                    for (int index = 0; index < this.evasiveReg.Count; ++index)
                    {
                        if (this.evasiveReg[index].name != "")
                            stringList.Add(this.evasiveReg[index].name);
                        else
                            stringList.Add(this.evasiveReg[index].shortName);
                    }
                    break;
                case 4:
                    for (int index = 0; index < this.blastReg.Count; ++index)
                    {
                        if (this.blastReg[index].name != "")
                            stringList.Add(this.blastReg[index].name);
                        else
                            stringList.Add(this.blastReg[index].shortName);
                    }
                    break;
                case 5:
                    for (int index = 0; index < this.awakenReg.Count; ++index)
                    {
                        if (this.awakenReg[index].name != "")
                            stringList.Add(this.awakenReg[index].name);
                        else
                            stringList.Add(this.awakenReg[index].shortName);
                    }
                    break;
            }
            return stringList.ToArray();
        }

        public bool Skillid2Used(int type, int id)
        {
            switch (type)
            {
                case 0:
                    for (int index = 0; index < this.Super.Count; ++index)
                    {
                        if ((int)this.Super[index].id2 == id)
                            return true;
                    }
                    break;
                case 1:
                    for (int index = 0; index < this.Ultimate.Count; ++index)
                    {
                        if ((int)this.Ultimate[index].id2 == id)
                            return true;
                    }
                    break;
                case 2:
                    for (int index = 0; index < this.Evasive.Count; ++index)
                    {
                        if ((int)this.Evasive[index].id2 == id)
                            return true;
                    }
                    break;
                case 4:
                    for (int index = 0; index < this.blast.Count; ++index)
                    {
                        if ((int)this.blast[index].id2 == id)
                            return true;
                    }
                    break;
                case 5:
                    for (int index = 0; index < this.Awaken.Count; ++index)
                    {
                        if ((int)this.Awaken[index].id2 == id)
                            return true;
                    }
                    break;
            }
            return false;
        }
    }
}
