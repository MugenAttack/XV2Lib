using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XV2Lib;

namespace AllinShopPatch
{
    class Program
    {
        static void Main(string[] args)
        {
            IDB file = new IDB();
            Settings s = new Settings();
            s.Read();
            
            
            file.Read(s.SysFolder + "/item/talisman_item.idb");
            for (int i = 0; i < file.items.Length; i++)
            {
                if (file.items[i].buy == 0)
                    file.items[i].buy = file.items[i].sell * 2;
                file.items[i].unk2 = 32767;
            }
            file.Write(s.SysFolder + "/item/talisman_item.idb");

            file.Read(s.SysFolder + "/item/costume_bottom_item.idb");
            for (int i = 0; i < file.items.Length; i++)
            {
                if (file.items[i].buy == 0)
                    file.items[i].buy = file.items[i].sell * 2;
                file.items[i].unk2 = 32767;
            }
            file.Write(s.SysFolder + "/item/costume_bottom_item.idb");

            file.Read(s.SysFolder + "/item/costume_gloves_item.idb");
            for (int i = 0; i < file.items.Length; i++)
            {
                if (file.items[i].buy == 0)
                    file.items[i].buy = file.items[i].sell * 2;
                file.items[i].unk2 = 32767;

            }
            file.Write(s.SysFolder + "/item/costume_gloves_item.idb");

            file.Read(s.SysFolder + "/item/costume_shoes_item.idb");
            for (int i = 0; i < file.items.Length; i++)
            {
                if (file.items[i].buy == 0)
                    file.items[i].buy = file.items[i].sell * 2;
                file.items[i].unk2 = 32767;
            }
            file.Write(s.SysFolder + "/item/costume_shoes_item.idb");

            file.Read(s.SysFolder + "/item/costume_top_item.idb");
            for (int i = 0; i < file.items.Length; i++)
            {
                if (file.items[i].buy == 0)
                    file.items[i].buy = file.items[i].sell * 2;
                file.items[i].unk2 = 32767;
            }
            file.Write(s.SysFolder + "/item/costume_top_item.idb");

            file.Read(s.SysFolder + "/item/accessory_item.idb");
            for (int i = 0; i < file.items.Length; i++)
            {
                if (file.items[i].buy == 0)
                    file.items[i].buy = file.items[i].sell * 2;
                file.items[i].unk2 = 32767;
            }
            file.Write(s.SysFolder + "/item/accessory_item.idb");

            file.Read(s.SysFolder + "/item/battle_item.idb");
            for (int i = 0; i < file.items.Length; i++)
            {
                if (file.items[i].buy == 0)
                    file.items[i].buy = file.items[i].sell * 2;
                file.items[i].unk2 = 32767;
            }
            file.Write(s.SysFolder + "/item/battle_item.idb");

            file.Read(s.SysFolder + "/item/material_item.idb");
            for (int i = 0; i < file.items.Length; i++)
            {
                if (file.items[i].buy == 0)
                    file.items[i].buy = file.items[i].sell * 2;
                file.items[i].unk2 = 32767;
            }
            file.Write(s.SysFolder + "/item/material_item.idb");

            file.Read(s.SysFolder + "/item/skill_item.idb");
            short type;
            for (int i = 0; i < file.items.Length; i++)
            {
                
                switch (file.items[i].type)
                {
                    case 2:
                        if (file.items[i].buy == 0)
                            file.items[i].buy = 10000;
                        break;
                    case 1:
                        if (file.items[i].buy == 0)
                            file.items[i].buy = 30000;
                        break;
                    case 0:
                        if (file.items[i].buy == 0)
                            file.items[i].buy = 20000;
                        break;
                    case 5:
                        if (file.items[i].buy == 0)
                            file.items[i].buy = 40000;
                        break;
                }
                file.items[i].unk2 = 32767;
            }
            file.Write(s.SysFolder + "/item/skill_item.idb");
        }
    }
}
