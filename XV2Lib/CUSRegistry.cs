using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XV2Lib
{
    struct SkillReg
    {
        public short id;
        public string shortName;
        public string name;
    }

    public class CUSRegistry
    {

        public charSkillSet[] css = new charSkillSet[1];
        public skill[] Super = new skill[1];
        public skill[] Ultimate = new skill[1];
        public skill[] Evasive = new skill[1];
        public skill[] blast = new skill[1];
        public skill[] Awaken = new skill[1];

        SkillReg[] superReg = new SkillReg[1]; 
        SkillReg[] ultimateReg = new SkillReg[1];
        SkillReg[] evasiveReg = new SkillReg[1];
        SkillReg[] blastReg = new SkillReg[1];
        SkillReg[] awakenReg = new SkillReg[1];

        public void readCUS(string cusPath)
        {
            CUS.Read(cusPath, ref css, ref Super, ref Ultimate, ref Evasive, ref Awaken, ref blast);
        }

        public void BuildRegistry(string Msgfolder,string lang)
        {
            if (Directory.Exists(Msgfolder))
            {
                MSG m = MSGStream.Read(Msgfolder + "/proper_noun_skill_spa_name_" + lang + ".msg");
                superReg = new SkillReg[Super.Length];
                for(int i = 0; i < Super.Length; i++)
                {
                    superReg[i].id = Super[i].id;
                    superReg[i].shortName = Super[i].shortName;
                    superReg[i].name = m.Find("spe_skill_" + Super[i].id2.ToString("0000"));
                }

                m = MSGStream.Read(Msgfolder + "/proper_noun_skill_ult_name_" + lang + ".msg");
                ultimateReg = new SkillReg[Ultimate.Length];
                for (int i = 0; i < Ultimate.Length; i++)
                {
                    ultimateReg[i].id = Ultimate[i].id;
                    ultimateReg[i].shortName = Ultimate[i].shortName;
                    ultimateReg[i].name = m.Find("ult_skill_" + Ultimate[i].id2.ToString("0000"));
                }

                m = MSGStream.Read(Msgfolder + "/proper_noun_skill_esc_name_" + lang + ".msg");
                evasiveReg = new SkillReg[Evasive.Length];
                for (int i = 0; i < Evasive.Length; i++)
                {
                    evasiveReg[i].id = Evasive[i].id;
                    evasiveReg[i].shortName = Evasive[i].shortName;
                    evasiveReg[i].name = m.Find("avoid_skill_" + Evasive[i].id2.ToString("0000"));
                }

             
                blastReg = new SkillReg[blast.Length];
                for (int i = 0; i < blast.Length; i++)
                {
                    blastReg[i].id = blast[i].id;
                    blastReg[i].shortName = blast[i].shortName;
                    blastReg[i].name = "";
                }

                m = MSGStream.Read(Msgfolder + "/proper_noun_skill_met_name_" + lang + ".msg");
                awakenReg = new SkillReg[Awaken.Length];
                for (int i = 0; i < Awaken.Length; i++)
                {
                    awakenReg[i].id = Awaken[i].id;
                    awakenReg[i].shortName = Awaken[i].shortName;
                    awakenReg[i].name = m.Find("met_skill_" + Awaken[i].id2.ToString("0000"));
                }
            }
            else
            {
                superReg = new SkillReg[Super.Length];
                for (int i = 0; i < Super.Length; i++)
                {
                    superReg[i].id = Super[i].id;
                    superReg[i].shortName = Super[i].shortName;
                    superReg[i].name = "";
                }

                ultimateReg = new SkillReg[Ultimate.Length];
                for (int i = 0; i < Ultimate.Length; i++)
                {
                    ultimateReg[i].id = Ultimate[i].id;
                    ultimateReg[i].shortName = Ultimate[i].shortName;
                    ultimateReg[i].name = "";
                }

               
                evasiveReg = new SkillReg[Evasive.Length];
                for (int i = 0; i < Evasive.Length; i++)
                {
                    evasiveReg[i].id = Evasive[i].id;
                    evasiveReg[i].shortName = Evasive[i].shortName;
                    evasiveReg[i].name = "";
                }

                blastReg = new SkillReg[blast.Length];
                for (int i = 0; i < blast.Length; i++)
                {
                    blastReg[i].id = blast[i].id;
                    blastReg[i].shortName = blast[i].shortName;
                    blastReg[i].name = "";
                }

                awakenReg = new SkillReg[Awaken.Length];
                for (int i = 0; i < Awaken.Length; i++)
                {
                    awakenReg[i].id = Awaken[i].id;
                    awakenReg[i].shortName = Awaken[i].shortName;
                    awakenReg[i].name = "";
                }
            }
        }

        public void writeCUS(string cusPath)
        {
            CUS.Write(cusPath, ref css, ref Super, ref Ultimate, ref Evasive, ref Awaken, ref blast);
        }

        public string FindSkillName(int type, short id)
        {
            
            switch(type)
            {
                case 0:
                    for(int i = 0; i < superReg.Length; i++)
                    {
                        if (superReg[i].id == id)
                            return superReg[i].name;
                    }
                    break;
                case 1:
                    for (int i = 0; i < ultimateReg.Length; i++)
                    {
                        if (ultimateReg[i].id == id)
                            return ultimateReg[i].name;
                    }
                    break;
                case 0:
                    break;
                case 0:
                    break;
                case 0:
                    break;
                case 0:
                    break;
            }

            return "";
        }

        public string[] getSkillList(int type)
        {

        }
    }
}
