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
            
            int sell;
            int buy;
            file.Read(s.SysFolder + "/item/talisman_item.idb");
            for (int i = 0; i < file.items.Length; i++)
            {
                buy = BitConverter.ToInt32(file.items[i].Data, 16);
                sell = BitConverter.ToInt32(file.items[i].Data, 20);
                if (buy == 0)
                    Array.Copy(BitConverter.GetBytes(sell * 2), 0, file.items[i].Data, 16, 4);

                Array.Copy(new byte[] {0xff,0x7f}, 0, file.items[i].Data, 12, 2);
            }
            file.Write(s.SysFolder + "/item/talisman_item.idb");

            file.Read(s.SysFolder + "/item/costume_bottom_item.idb");
            for (int i = 0; i < file.items.Length; i++)
            {
                buy = BitConverter.ToInt32(file.items[i].Data, 16);
                sell = BitConverter.ToInt32(file.items[i].Data, 20);
                if (buy == 0)
                    Array.Copy(BitConverter.GetBytes(sell * 2), 0, file.items[i].Data, 16, 4);

                Array.Copy(new byte[] { 0xff, 0x7f }, 0, file.items[i].Data, 12, 2);
            }
            file.Write(s.SysFolder + "/item/costume_bottom_item.idb");

            file.Read(s.SysFolder + "/item/costume_gloves_item.idb");
            for (int i = 0; i < file.items.Length; i++)
            {
                buy = BitConverter.ToInt32(file.items[i].Data, 16);
                sell = BitConverter.ToInt32(file.items[i].Data, 20);
                if (buy == 0)
                    Array.Copy(BitConverter.GetBytes(sell * 2), 0, file.items[i].Data, 16, 4);

                Array.Copy(new byte[] { 0xff, 0x7f }, 0, file.items[i].Data, 12, 2);

            }
            file.Write(s.SysFolder + "/item/costume_gloves_item.idb");

            file.Read(s.SysFolder + "/item/costume_shoes_item.idb");
            for (int i = 0; i < file.items.Length; i++)
            {
                buy = BitConverter.ToInt32(file.items[i].Data, 16);
                sell = BitConverter.ToInt32(file.items[i].Data, 20);
                if (buy == 0)
                    Array.Copy(BitConverter.GetBytes(sell * 2), 0, file.items[i].Data, 16, 4);

                Array.Copy(new byte[] { 0xff, 0x7f }, 0, file.items[i].Data, 12, 2);
            }
            file.Write(s.SysFolder + "/item/costume_shoes_item.idb");

            file.Read(s.SysFolder + "/item/costume_top_item.idb");
            for (int i = 0; i < file.items.Length; i++)
            {
                buy = BitConverter.ToInt32(file.items[i].Data, 16);
                sell = BitConverter.ToInt32(file.items[i].Data, 20);
                if (buy == 0)
                    Array.Copy(BitConverter.GetBytes(sell * 2), 0, file.items[i].Data, 16, 4);

                Array.Copy(new byte[] { 0xff, 0x7f }, 0, file.items[i].Data, 12, 2);
            }
            file.Write(s.SysFolder + "/item/costume_top_item.idb");

            file.Read(s.SysFolder + "/item/accessory_item.idb");
            for (int i = 0; i < file.items.Length; i++)
            {
                buy = BitConverter.ToInt32(file.items[i].Data, 16);
                sell = BitConverter.ToInt32(file.items[i].Data, 20);
                if (buy == 0)
                    Array.Copy(BitConverter.GetBytes(sell * 2), 0, file.items[i].Data, 16, 4);

                Array.Copy(new byte[] { 0xff, 0x7f }, 0, file.items[i].Data, 12, 2);
            }
            file.Write(s.SysFolder + "/item/accessory_item.idb");

            file.Read(s.SysFolder + "/item/battle_item.idb");
            for (int i = 0; i < file.items.Length; i++)
            {
                buy = BitConverter.ToInt32(file.items[i].Data, 16);
                sell = BitConverter.ToInt32(file.items[i].Data, 20);
                if (buy == 0)
                    Array.Copy(BitConverter.GetBytes(sell * 2), 0, file.items[i].Data, 16, 4);

                Array.Copy(new byte[] { 0xff, 0x7f }, 0, file.items[i].Data, 12, 2);
            }
            file.Write(s.SysFolder + "/item/battle_item.idb");

            file.Read(s.SysFolder + "/item/material_item.idb");
            for (int i = 0; i < file.items.Length; i++)
            {
                buy = BitConverter.ToInt32(file.items[i].Data, 16);
                sell = BitConverter.ToInt32(file.items[i].Data, 20);
                if (buy == 0)
                    Array.Copy(BitConverter.GetBytes(sell * 2), 0, file.items[i].Data, 16, 4);

                Array.Copy(new byte[] { 0xff, 0x7f }, 0, file.items[i].Data, 12, 2);
            }
            file.Write(s.SysFolder + "/item/material_item.idb");

            file.Read(s.SysFolder + "/item/skill_item.idb");
            short type;
            for (int i = 0; i < file.items.Length; i++)
            {
                buy = BitConverter.ToInt32(file.items[i].Data, 16);
                type = BitConverter.ToInt16(file.items[i].Data, 8);
                switch (type)
                {
                    case 2:
                        if (buy == 0)
                            Array.Copy(BitConverter.GetBytes(10000), 0, file.items[i].Data, 16, 4);
                        break;
                    case 1:
                        if (buy == 0)
                            Array.Copy(BitConverter.GetBytes(30000), 0, file.items[i].Data, 16, 4);
                        break;
                    case 0:
                        if (buy == 0)
                            Array.Copy(BitConverter.GetBytes(20000), 0, file.items[i].Data, 16, 4);
                        break;
                    case 5:
                        if (buy == 0)
                            Array.Copy(BitConverter.GetBytes(40000), 0, file.items[i].Data, 16, 4);
                        break;
                }
                Array.Copy(new byte[] { 0xff, 0x7f }, 0, file.items[i].Data, 12, 2);
            }
            file.Write(s.SysFolder + "/item/skill_item.idb");
        }
    }
}
