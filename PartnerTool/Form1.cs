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
        OCC_ColorParts currentCPart;
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

                //Character Tab
                txtID.Text = currentPartner.id.ToString();
                txtChar1.Text = currentPartner.character.unk1.ToString();
                txtChar2.Text = currentPartner.character.unk2.ToString();
                txtChar3.Text = currentPartner.character.unk3.ToString();
                txtChar4.Text = currentPartner.character.unk4.ToString();
                txtChar5.Text = currentPartner.character.unk5.ToString();
                txtChar6.Text = currentPartner.character.unk6.ToString();
                txtChar7.Text = currentPartner.character.unk7.ToString();
                txtChar8.Text = currentPartner.character.unk8.ToString();
                txtChar9.Text = currentPartner.character.unk9.ToString();
                txtChar10.Text = currentPartner.character.unk10.ToString();
                txtChar11.Text = currentPartner.character.unk11.ToString();
                txtChar12.Text = currentPartner.character.unk12.ToString();
                txtChar13.Text = currentPartner.character.unk13.ToString();

                //Part Colors Tab
                cbPartColors.SelectedIndex = -1;
                cbPartColors.Items.Clear();
                for (int i = 0; i < currentPartner.color.Count; i++)
                    cbPartColors.Items.Add(i);

                txtPrtColor1.Text = "";
                txtPrtColor2.Text = "";
                txtPrtColor3.Text = "";
                txtPrtColor4.Text = "";
                txtPrtColor5.Text = "";

                //Custom Costume
                txtCostume1.Text = currentPartner.costume.unk1.ToString();
                txtCostume2.Text = currentPartner.costume.unk2.ToString();
                txtCostume3.Text = currentPartner.costume.unk3.ToString();
                txtCostume4.Text = currentPartner.costume.unk4.ToString();
                txtCostume5.Text = currentPartner.costume.unk5.ToString();
                chkEnable.Checked = currentPartner.CostumeEnabled;
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

        private void txtChar1_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtChar1.Text,out p))
            {
                currentPartner.character.unk1 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtChar2_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtChar2.Text, out p))
            {
                currentPartner.character.unk2 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtChar3_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtChar3.Text, out p))
            {
                currentPartner.character.unk3 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtChar4_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtChar4.Text, out p))
            {
                currentPartner.character.unk4 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtChar5_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtChar5.Text, out p))
            {
                currentPartner.character.unk5 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtChar6_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtChar6.Text, out p))
            {
                currentPartner.character.unk6 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtChar7_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtChar7.Text, out p))
            {
                currentPartner.character.unk7 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtChar8_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtChar8.Text, out p))
            {
                currentPartner.character.unk8 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtChar9_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtChar9.Text, out p))
            {
                currentPartner.character.unk9 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtChar10_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtChar10.Text, out p))
            {
                currentPartner.character.unk10 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtChar11_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtChar11.Text, out p))
            {
                currentPartner.character.unk11 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtChar12_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtChar12.Text, out p))
            {
                currentPartner.character.unk12 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtChar13_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtChar13.Text, out p))
            {
                currentPartner.character.unk13 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void cbPartColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (partners.Count > 0 && cbPartColors.SelectedIndex >= 0)
            {
                currentCPart = currentPartner.color[cbPartColors.SelectedIndex];
                txtPrtColor1.Text = currentCPart.unk1.ToString();
                txtPrtColor2.Text = currentCPart.unk2.ToString();
                txtPrtColor3.Text = currentCPart.unk3.ToString();
                txtPrtColor4.Text = currentCPart.unk4.ToString();
                txtPrtColor5.Text = currentCPart.unk5.ToString();
            }
        }

        private void txtPrtColor1_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartColors.SelectedIndex >= 0 && int.TryParse(txtPrtColor1.Text, out p))
            {
                currentCPart.unk1 = p;
                currentPartner.color[cbPartColors.SelectedIndex] = currentCPart;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtPrtColor2_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartColors.SelectedIndex >= 0 && int.TryParse(txtPrtColor2.Text, out p))
            {
                currentCPart.unk2 = p;
                currentPartner.color[cbPartColors.SelectedIndex] = currentCPart;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtPrtColor3_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartColors.SelectedIndex >= 0 && int.TryParse(txtPrtColor3.Text, out p))
            {
                currentCPart.unk3 = p;
                currentPartner.color[cbPartColors.SelectedIndex] = currentCPart;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtPrtColor4_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartColors.SelectedIndex >= 0 && int.TryParse(txtPrtColor4.Text, out p))
            {
                currentCPart.unk4 = p;
                currentPartner.color[cbPartColors.SelectedIndex] = currentCPart;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtPrtColor5_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartColors.SelectedIndex >= 0 && int.TryParse(txtPrtColor5.Text, out p))
            {
                currentCPart.unk5 = p;
                currentPartner.color[cbPartColors.SelectedIndex] = currentCPart;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtCostume1_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtCostume1.Text, out p))
            {
                currentPartner.costume.unk1 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtCostume2_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtCostume2.Text, out p))
            {
                currentPartner.costume.unk2 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtCostume3_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtCostume3.Text, out p))
            {
                currentPartner.costume.unk3 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtCostume4_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtCostume4.Text, out p))
            {
                currentPartner.costume.unk4 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void txtCostume5_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (cbPartners.SelectedIndex >= 0 && int.TryParse(txtCostume5.Text, out p))
            {
                currentPartner.costume.unk5 = p;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPartners.SelectedIndex >= 0 )
            {
                currentPartner.CostumeEnabled = chkEnable.Checked;
                partners[cbPartners.SelectedIndex] = currentPartner;
            }
        }
    }
}
