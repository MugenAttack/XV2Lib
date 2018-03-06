using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using XV2Lib;

namespace PartnerTool
{
    public struct Partner_Data
    {
        public int id;
        public ODF_Data character;
        public List<OCC_ColorParts> color;
        public bool CostumeEnabled;
        public OCO_Costume costume;
        public List<OCS_Skill> type0;
        public List<OCS_Skill> type1;
        public List<OCS_Skill> type2;
        public List<OCS_Skill> type3;
        public List<OCP_Parameters> parameters;
        public List<OCT_Talisman> talisman;

    }

    public partial class Form1 : Form
    {
        Settings s = new Settings();
        List<Partner_Data> partners;
        Partner_Data currentPartner;
        bool disableChange = false;
        string PartnerFolder;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            s.Read();
            if (Directory.Exists(s.XENOFolder + "data\\system\\chara_custom"))
            {
                partners = new List<Partner_Data>();
                PartnerFolder = s.XENOFolder + "data\\system\\chara_custom\\";
                List<ODF_Char> Characters = ODF.Read(PartnerFolder + "OriginalCharacterDefaultTable.odf");
                List<OCC_Char> Colors = OCC.Read(PartnerFolder + "MenuColorPartsCustomList.occ");
                List<OCO_Char> Costumes = OCO.Read(PartnerFolder + "MenuCostumeCustomList.oco");
                List<OCS_Char> Skills = OCS.Read(PartnerFolder + "MenuSkillCustomList.ocs");
                List<OCP_Char> Parameters = OCP.Read(PartnerFolder + "MenuParamaterCustomList.ocp");
                List<OCT_Char> Talismans = OCT.Read(PartnerFolder + "MenuTalismanCustomList.oct");

                for (int i = 0; i < Characters.Count; i++)
                {
                    Partner_Data p = new Partner_Data();
                    p.id = Characters[i].id;
                    p.character = Characters[i].data;
                    p.color = Colors[i].data;
                    p.CostumeEnabled = Costumes[i].enabled;
                    p.costume = Costumes[i].data;
                    p.type0 = Skills[i].type0;
                    p.type1 = Skills[i].type1;
                    p.type2 = Skills[i].type2;
                    p.type3 = Skills[i].type3;
                    p.parameters = Parameters[i].data;
                    p.talisman = Talismans[i].data;
                    partners.Add(p);
                }

                cbPartners.Items.Clear();
                for (int i = 0; i < partners.Count; i++)
                {
                    cbPartners.Items.Add(partners[i].id);
                }
            }
        }

        private void cbPartners_Click(object sender, EventArgs e)
        {

        }

        private void cbPartners_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (partners.Count > 0)
            {
                currentPartner = partners[cbPartners.SelectedIndex];
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browseFolder = new FolderBrowserDialog();
            browseFolder.Description = "Find chara_custom Folder";
            if (browseFolder.ShowDialog() == DialogResult.Cancel)
                return;

            partners = new List<Partner_Data>();
            PartnerFolder = browseFolder.SelectedPath + "\\";
            List<ODF_Char> Characters = ODF.Read(PartnerFolder + "OriginalCharacterDefaultTable.odf");
            List<OCC_Char> Colors = OCC.Read(PartnerFolder + "MenuColorPartsCustomList.occ");
            List<OCO_Char> Costumes = OCO.Read(PartnerFolder + "MenuCostumeCustomList.oco");
            List<OCS_Char> Skills = OCS.Read(PartnerFolder + "MenuSkillCustomList.ocs");
            List<OCP_Char> Parameters = OCP.Read(PartnerFolder + "MenuParamaterCustomList.ocp");
            List<OCT_Char> Talismans = OCT.Read(PartnerFolder + "MenuTalismanCustomList.oct");

            for (int i = 0; i < Characters.Count; i++)
            {
                Partner_Data p = new Partner_Data();
                p.id = Characters[i].id;
                p.character = Characters[i].data;
                p.color = Colors[i].data;
                p.CostumeEnabled = Costumes[i].enabled;
                p.costume = Costumes[i].data;
                p.type0 = Skills[i].type0;
                p.type1 = Skills[i].type1;
                p.type2 = Skills[i].type2;
                p.type3 = Skills[i].type3;
                p.parameters = Parameters[i].data;
                p.talisman = Talismans[i].data;
                partners.Add(p);
            }

            cbPartners.Items.Clear();
            for (int i = 0; i < partners.Count; i++)
            {
                cbPartners.Items.Add(partners[i].id);
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<ODF_Char> Characters = new List<ODF_Char>();
            List<OCC_Char> Colors = new List<OCC_Char>();
            List<OCO_Char> Costumes = new List<OCO_Char>();
            List<OCS_Char> Skills = new List<OCS_Char>();
            List<OCP_Char> Parameters = new List<OCP_Char>();
            List<OCT_Char> Talismans = new List<OCT_Char>();

            for(int i = 0; i < partners.Count; i++)
            {
                ODF_Char n1 = new ODF_Char();
                n1.id = partners[i].id;
                n1.data = partners[i].character;
                Characters.Add(n1);

                OCC_Char n2 = new OCC_Char();
                n2.id = partners[i].id;
                n2.data = partners[i].color;
                Colors.Add(n2);

                OCO_Char n3 = new OCO_Char();
                n3.id = partners[i].id;
                n3.data = partners[i].costume;
                n3.enabled = partners[i].CostumeEnabled;
                Costumes.Add(n3);

                OCS_Char n4 = new OCS_Char();
                n4.id = partners[i].id;
                n4.type0 = partners[i].type0;
                n4.type1 = partners[i].type1;
                n4.type2 = partners[i].type2;
                n4.type3 = partners[i].type3;
                Skills.Add(n4);

                OCP_Char n5 = new OCP_Char();
                n5.id = partners[i].id;
                n5.data = partners[i].parameters;
                Parameters.Add(n5);

                OCT_Char n6 = new OCT_Char();
                n6.id = partners[i].id;
                n6.data = partners[i].talisman;
                Talismans.Add(n6);
            }

            ODF.Write(PartnerFolder + "OriginalCharacterDefaultTable.odf",Characters);
            OCC.Write(PartnerFolder + "MenuColorPartsCustomList.occ",Colors);
            OCO.Write(PartnerFolder + "MenuCostumeCustomList.oco",Costumes);
            OCS.Write(PartnerFolder + "MenuSkillCustomList.ocs",Skills);
            OCP.Write(PartnerFolder + "MenuParamaterCustomList.ocp",Parameters);
            OCT.Write(PartnerFolder + "MenuTalismanCustomList.oct", Talismans);

        }
    }
}
