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
            skill[] Super = new skill[1];
            skill[] Ultimate = new skill[1]; ;
            skill[] Evasive = new skill[1]; ;
            skill[] blast = new skill[1]; ;
            skill[] Awaken = new skill[1]; ;
            charSkillSet[] css = new charSkillSet[1];

            CUS.Read("custom_skill.cus", ref css, ref Super, ref Ultimate, ref Evasive, ref Awaken, ref blast);
            CUS.Write("custom_skill.cus", ref css, ref Super, ref Ultimate, ref Evasive, ref Awaken, ref blast);
        }
    }
}
