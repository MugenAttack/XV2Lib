using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XV2Lib
{
    struct charSkillSet
    {
        int charID;
        int costumeID;
        short[] skill; // set as 9
    }

    struct skill
    {
        string shortName;
        short id;
        short id2;
        byte RaceLock;
        byte[] unknown;
    }

    static class CUS
    {








    }

    static class CUSMod
    {
        static void PatchSkillset(charSkillSet cs)
        {




        }
    }
}
