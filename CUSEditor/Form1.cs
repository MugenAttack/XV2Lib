using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XV2Lib;
namespace CUSEditor
{
    public partial class Form1 : Form
    {
        string FileName;
        List<skill> Super = new List<skill>();
        List<skill> Ultimate = new List<skill>();
        List<skill> Evasive = new List<skill>();
        List<skill> blast = new List<skill>();
        List<skill> Awaken = new List<skill>();
        List<charSkillSet> css = new List<charSkillSet>();
        bool lck = true;
        charSkillSet copySet;
        charSkillSet currentSet;
        skill copySkill;
        skill currentSkill;

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFile = new OpenFileDialog();
            browseFile.Filter = "Xenoverse cus (*.cus)|*.cus";
            browseFile.Title = "Browse for Custom Skill File";
            if (browseFile.ShowDialog() == DialogResult.Cancel)
                return;

            skill[] pSuper = new skill[1];
            skill[] pUltimate = new skill[1];
            skill[] pEvasive = new skill[1];
            skill[] pblast = new skill[1];
            skill[] pAwaken = new skill[1];
            charSkillSet[] pcss = new charSkillSet[1];
            
            FileName = browseFile.FileName;
            CUS.Read(FileName, ref pcss, ref pSuper, ref pUltimate, ref pEvasive, ref pAwaken, ref pblast);

            Super.Clear();
            Ultimate.Clear();
            Evasive.Clear();
            blast.Clear();
            Awaken.Clear();
            css.Clear();

            Super.AddRange(pSuper);
            Ultimate.AddRange(pUltimate);
            Evasive.AddRange(pEvasive);
            blast.AddRange(pblast);
            Awaken.AddRange(pAwaken);
            css.AddRange(pcss);


            cbChar.Items.Clear();
            for (int i = 0; i < css.Count; i++)
                cbChar.Items.Add("Character " + css[i].charID.ToString("000") + " - Costume " + css[i].costumeID.ToString("00"));



        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            skill[] pSuper = Super.ToArray();
            skill[] pUltimate = Ultimate.ToArray();
            skill[] pEvasive = Evasive.ToArray();
            skill[] pblast = blast.ToArray();
            skill[] pAwaken = Awaken.ToArray();
            charSkillSet[] pcss = css.ToArray(); 

            CUS.Write(FileName, ref pcss, ref pSuper, ref pUltimate, ref pEvasive, ref pAwaken, ref pblast);
        }

        private void cbChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            lck = false;
            currentSet = css[cbChar.SelectedIndex];
            txtCharID.Text = currentSet.charID.ToString();
            txtCostID.Text = currentSet.costumeID.ToString();
            txtSup1.Text = currentSet.skill[0].ToString();
            txtSup2.Text = currentSet.skill[1].ToString();
            txtSup3.Text = currentSet.skill[2].ToString();
            txtSup4.Text = currentSet.skill[3].ToString();
            txtUlt1.Text = currentSet.skill[4].ToString();
            txtUlt2.Text = currentSet.skill[5].ToString();
            txtEva.Text = currentSet.skill[6].ToString();
            txtKiB.Text = currentSet.skill[7].ToString();
            txtAwa.Text = currentSet.skill[8].ToString();
            txtVal.Text = currentSet.skill[9].ToString();
            lck = true;
        }

        private void txtCharID_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (lck && int.TryParse(txtCharID.Text,out p))
            {
                lck = false;
                currentSet.charID = p;
                css[cbChar.SelectedIndex] = currentSet;

                int temp = cbChar.SelectedIndex;
                cbChar.SelectedIndex = 0;
                cbChar.Items.Clear();
                for (int i = 0; i < css.Count; i++)
                    cbChar.Items.Add("Character " + css[i].charID.ToString("000") + " - Costume " + css[i].costumeID.ToString("00"));
                cbChar.SelectedIndex = temp;
                lck = true;
            }
        }

        private void txtCostID_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (lck && int.TryParse(txtCostID.Text, out p))
            {
                lck = false;
                currentSet.costumeID = p;
                css[cbChar.SelectedIndex] = currentSet;

                int temp = cbChar.SelectedIndex;
                cbChar.SelectedIndex = 0;
                cbChar.Items.Clear();
                for (int i = 0; i < css.Count; i++)
                    cbChar.Items.Add("Character " + css[i].charID.ToString("000") + " - Costume " + css[i].costumeID.ToString("00"));
                cbChar.SelectedIndex = temp;
                lck = true;
            }
        }

        private void txtSup1_TextChanged(object sender, EventArgs e)
        {
            short p;
            if (lck && short.TryParse(txtSup1.Text, out p))
            {
                currentSet.skill[0] = p;
                css[cbChar.SelectedIndex] = currentSet;
            }
        }

        private void txtSup2_TextChanged(object sender, EventArgs e)
        {
            short p;
            if (lck && short.TryParse(txtSup2.Text, out p))
            {
                currentSet.skill[1] = p;
                css[cbChar.SelectedIndex] = currentSet;
            }
        }

        private void txtSup3_TextChanged(object sender, EventArgs e)
        {
            short p;
            if (lck && short.TryParse(txtSup3.Text, out p))
            {
                currentSet.skill[2] = p;
                css[cbChar.SelectedIndex] = currentSet;
            }
        }

        private void txtSup4_TextChanged(object sender, EventArgs e)
        {
            short p;
            if (lck && short.TryParse(txtSup4.Text, out p))
            {
                currentSet.skill[3] = p;
                css[cbChar.SelectedIndex] = currentSet;
            }
        }

        private void txtUlt1_TextChanged(object sender, EventArgs e)
        {
            short p;
            if (lck && short.TryParse(txtUlt1.Text, out p))
            {
                currentSet.skill[4] = p;
                css[cbChar.SelectedIndex] = currentSet;
            }
        }

        private void txtUlt2_TextChanged(object sender, EventArgs e)
        {
            short p;
            if (lck && short.TryParse(txtUlt2.Text, out p))
            {
                currentSet.skill[5] = p;
                css[cbChar.SelectedIndex] = currentSet;
            }
        }

        private void txtEva_TextChanged(object sender, EventArgs e)
        {
            short p;
            if (lck && short.TryParse(txtEva.Text, out p))
            {
                currentSet.skill[6] = p;
                css[cbChar.SelectedIndex] = currentSet;
            }
        }

        private void txtKiB_TextChanged(object sender, EventArgs e)
        {
            currentSet.skill[7] = short.Parse(txtKiB.Text);
            css[cbChar.SelectedIndex] = currentSet;
        }

        private void txtAwa_TextChanged(object sender, EventArgs e)
        {
            currentSet.skill[8] = short.Parse(txtAwa.Text);
            css[cbChar.SelectedIndex] = currentSet;
        }

        private void txtVal_TextChanged(object sender, EventArgs e)
        {
            currentSet.skill[9] = short.Parse(txtVal.Text);
            css[cbChar.SelectedIndex] = currentSet;
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lck = false;
            switch (cbType.SelectedIndex)
            {
                case 0:
                    cbSkill.Items.Clear();
                    for (int i = 0; i < Super.Count; i++)
                        cbSkill.Items.Add(Super[i].id.ToString("000") + " - " + Super[i].shortName);
                    break;
                case 1:
                    cbSkill.Items.Clear();
                    for (int i = 0; i < Ultimate.Count; i++)
                        cbSkill.Items.Add(Ultimate[i].id.ToString("000") + " - " + Ultimate[i].shortName);
                    break;
                case 2:
                    cbSkill.Items.Clear();
                    for (int i = 0; i < Evasive.Count; i++)
                        cbSkill.Items.Add(Evasive[i].id.ToString("000") + " - " + Evasive[i].shortName);
                    break;
                case 3:
                    cbSkill.Items.Clear();
                    for (int i = 0; i < blast.Count; i++)
                        cbSkill.Items.Add(blast[i].id.ToString("000") + " - " + blast[i].shortName);
                    break;
                case 4:
                    cbSkill.Items.Clear();
                    for (int i = 0; i < Awaken.Count; i++)
                        cbSkill.Items.Add(Awaken[i].id.ToString("000") + " - " + Awaken[i].shortName);
                    break;

            }
            lck = true;
        }

        private void cbSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbType.SelectedIndex)
            {
                case 0:
                    currentSkill = Super[cbSkill.SelectedIndex];
                    break;
                case 1:
                    currentSkill = Ultimate[cbSkill.SelectedIndex];
                    break;
                case 2:
                    currentSkill = Evasive[cbSkill.SelectedIndex];
                    break;
                case 3:
                    currentSkill = blast[cbSkill.SelectedIndex];
                    break;
                case 4:
                    currentSkill = Awaken[cbSkill.SelectedIndex];
                    break;
            }

            lck = false;
            txtShortName.Text = currentSkill.shortName;
            txtid.Text = currentSkill.id.ToString();
            txtid2.Text = currentSkill.id2.ToString();
            textBox1.Text = currentSkill.racelock.ToString();
            txt1.Text = currentSkill.unk1.ToString();
            txt2.Text = currentSkill.unk2.ToString();
            txtHair.Text = currentSkill.hair.ToString();
            txt3.Text = currentSkill.unk3.ToString();
            txt4.Text = currentSkill.Paths[0];
            txt5.Text = currentSkill.Paths[1];
            txt6.Text = currentSkill.Paths[2];
            txt7.Text = currentSkill.Paths[3];
            txt8.Text = currentSkill.Paths[4];
            txt9.Text = currentSkill.Paths[5];
            txt10.Text = currentSkill.Paths[6];
            txt11.Text = currentSkill.unk4.ToString();
            txt12.Text = currentSkill.unk5.ToString();
            txt13.Text = currentSkill.unk6.ToString();
            txt14.Text = currentSkill.unk7.ToString();
            txt15.Text = currentSkill.unk8.ToString();
            txt16.Text = currentSkill.unk9.ToString();
            txt17.Text = currentSkill.unk10.ToString();
            txt18.Text = currentSkill.unk11.ToString();
            lck = true;

        }

        private void UpdateCurrentSkill()
        {
            switch (cbType.SelectedIndex)
            {
                case 0:
                    Super[cbSkill.SelectedIndex] = currentSkill;
                    break;
                case 1:
                    Ultimate[cbSkill.SelectedIndex] = currentSkill;
                    break;
                case 2:
                    Evasive[cbSkill.SelectedIndex] = currentSkill;
                    break;
                case 3:
                    blast[cbSkill.SelectedIndex] = currentSkill;
                    break;
                case 4:
                    Awaken[cbSkill.SelectedIndex] = currentSkill;
                    break;
            }
        }

        private void txtShortName_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.shortName = txtShortName.Text;
                UpdateCurrentSkill();
                lck = false;
                switch (cbType.SelectedIndex)
                {
                    case 0:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Super.Count; i++)
                            cbSkill.Items.Add(Super[i].id.ToString("000") + " - " + Super[i].shortName);
                        break;
                    case 1:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Ultimate.Count; i++)
                            cbSkill.Items.Add(Ultimate[i].id.ToString("000") + " - " + Ultimate[i].shortName);
                        break;
                    case 2:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Evasive.Count; i++)
                            cbSkill.Items.Add(Evasive[i].id.ToString("000") + " - " + Evasive[i].shortName);
                        break;
                    case 3:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < blast.Count; i++)
                            cbSkill.Items.Add(blast[i].id.ToString("000") + " - " + blast[i].shortName);
                        break;
                    case 4:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Awaken.Count; i++)
                            cbSkill.Items.Add(Awaken[i].id.ToString("000") + " - " + Awaken[i].shortName);
                        break;

                }
                lck = true;
            }


        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.id = short.Parse(txtid.Text);
                UpdateCurrentSkill();
                lck = false;
                switch (cbType.SelectedIndex)
                {
                    case 0:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Super.Count; i++)
                            cbSkill.Items.Add(Super[i].id.ToString("000") + " - " + Super[i].shortName);
                        break;
                    case 1:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Ultimate.Count; i++)
                            cbSkill.Items.Add(Ultimate[i].id.ToString("000") + " - " + Ultimate[i].shortName);
                        break;
                    case 2:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Evasive.Count; i++)
                            cbSkill.Items.Add(Evasive[i].id.ToString("000") + " - " + Evasive[i].shortName);
                        break;
                    case 3:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < blast.Count; i++)
                            cbSkill.Items.Add(blast[i].id.ToString("000") + " - " + blast[i].shortName);
                        break;
                    case 4:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Awaken.Count; i++)
                            cbSkill.Items.Add(Awaken[i].id.ToString("000") + " - " + Awaken[i].shortName);
                        break;

                }
                lck = true;
            }
        }

        private void txtid2_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.id2 = short.Parse(txtid2.Text);
                UpdateCurrentSkill();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //race lock
            byte p;
            if (lck && byte.TryParse(textBox1.Text,out p))
            {
                currentSkill.racelock = p;
                UpdateCurrentSkill();
            }
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.unk1 = byte.Parse(txt1.Text);
                UpdateCurrentSkill();
            }
        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.unk2 = short.Parse(txt2.Text);
                UpdateCurrentSkill();
            }
        }

        private void txtHair_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.hair = short.Parse(txtHair.Text);
                UpdateCurrentSkill();
            }
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.unk3 = short.Parse(txt3.Text);
                UpdateCurrentSkill();
            }
        }

        private void txt4_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.Paths[0] = txt4.Text;
                UpdateCurrentSkill();
            }
        }

        private void txt5_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.Paths[1] = txt5.Text;
                UpdateCurrentSkill();
            }
        }

        private void txt6_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.Paths[2] = txt6.Text;
                UpdateCurrentSkill();
            }
        }

        private void txt7_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.Paths[3] = txt7.Text;
                UpdateCurrentSkill();
            }
        }

        private void txt8_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.Paths[4] = txt8.Text;
                UpdateCurrentSkill();
            }
        }

        private void txt9_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.Paths[5] = txt9.Text;
                UpdateCurrentSkill();
            }
        }

        private void txt10_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.Paths[6] = txt10.Text;
                UpdateCurrentSkill();
            }
        }

        private void txt11_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.unk4 = short.Parse(txt11.Text);
                UpdateCurrentSkill();
            }
        }

        private void txt12_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.unk5 = short.Parse(txt12.Text);
                UpdateCurrentSkill();
            }
        }

        private void txt13_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.unk6 = short.Parse(txt13.Text);
                UpdateCurrentSkill();
            }
        }

        private void txt14_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.unk7 = short.Parse(txt14.Text);
                UpdateCurrentSkill();
            }
        }

        private void txt15_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.unk8 = short.Parse(txt15.Text);
                UpdateCurrentSkill();
            }
        }

        private void txt16_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.unk9 = short.Parse(txt16.Text);
                UpdateCurrentSkill();
            }
        }

        private void txt17_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.unk10 = short.Parse(txt17.Text);
                UpdateCurrentSkill();
            }
        }

        private void txt18_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                currentSkill.unk11 = short.Parse(txt18.Text);
                UpdateCurrentSkill();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                charSkillSet n = new charSkillSet();
                n.skill = new short[12];
                css.Add(n);

                lck = false;
                int temp = cbChar.SelectedIndex;
                cbChar.SelectedIndex = 0;
                cbChar.Items.Clear();
                for (int i = 0; i < css.Count; i++)
                    cbChar.Items.Add("Character " + css[i].charID.ToString("000") + " - Costume " + css[i].costumeID.ToString("00"));
                cbChar.SelectedIndex = temp;
                lck = true;
            }
            else
            {
                skill n = new skill();
                n.Paths = new string[7];

                switch (cbType.SelectedIndex)
                {
                    case 0:
                        Super.Add(n);
                        break;
                    case 1:
                        Ultimate.Add(n);
                        break;
                    case 2:
                        Evasive.Add(n);
                        break;
                    case 3:
                        blast.Add(n);
                        break;
                    case 4:
                        Awaken.Add(n);
                        break;
                }

                lck = false;
                cbSkill.SelectedIndex = 0;
                switch (cbType.SelectedIndex)
                {
                    case 0:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Super.Count; i++)
                            cbSkill.Items.Add(Super[i].id.ToString("000") + " - " + Super[i].shortName);
                        break;
                    case 1:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Ultimate.Count; i++)
                            cbSkill.Items.Add(Ultimate[i].id.ToString("000") + " - " + Ultimate[i].shortName);
                        break;
                    case 2:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Evasive.Count; i++)
                            cbSkill.Items.Add(Evasive[i].id.ToString("000") + " - " + Evasive[i].shortName);
                        break;
                    case 3:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < blast.Count; i++)
                            cbSkill.Items.Add(blast[i].id.ToString("000") + " - " + blast[i].shortName);
                        break;
                    case 4:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Awaken.Count; i++)
                            cbSkill.Items.Add(Awaken[i].id.ToString("000") + " - " + Awaken[i].shortName);
                        break;

                }
                lck = true;

            }
        
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                css.RemoveAt(cbChar.SelectedIndex);
                lck = false;
                int temp = cbChar.SelectedIndex;
                cbChar.SelectedIndex = 0;
                cbChar.Items.Clear();
                for (int i = 0; i < css.Count; i++)
                    cbChar.Items.Add("Character " + css[i].charID.ToString("000") + " - Costume " + css[i].costumeID.ToString("00"));
                cbChar.SelectedIndex = temp;
                lck = true;
            }
            else
            {
                
                switch (cbType.SelectedIndex)
                {
                    case 0:
                        Super.RemoveAt(cbSkill.SelectedIndex);
                        break;
                    case 1:
                        Ultimate.RemoveAt(cbSkill.SelectedIndex);
                        break;
                    case 2:
                        Evasive.RemoveAt(cbSkill.SelectedIndex);
                        break;
                    case 3:
                        blast.RemoveAt(cbSkill.SelectedIndex);
                        break;
                    case 4:
                        Awaken.RemoveAt(cbSkill.SelectedIndex);
                        break;
                }

                lck = false;
                cbSkill.SelectedIndex = 0;
                switch (cbType.SelectedIndex)
                {
                    case 0:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Super.Count; i++)
                            cbSkill.Items.Add(Super[i].id.ToString("000") + " - " + Super[i].shortName);
                        break;
                    case 1:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Ultimate.Count; i++)
                            cbSkill.Items.Add(Ultimate[i].id.ToString("000") + " - " + Ultimate[i].shortName);
                        break;
                    case 2:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Evasive.Count; i++)
                            cbSkill.Items.Add(Evasive[i].id.ToString("000") + " - " + Evasive[i].shortName);
                        break;
                    case 3:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < blast.Count; i++)
                            cbSkill.Items.Add(blast[i].id.ToString("000") + " - " + blast[i].shortName);
                        break;
                    case 4:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Awaken.Count; i++)
                            cbSkill.Items.Add(Awaken[i].id.ToString("000") + " - " + Awaken[i].shortName);
                        break;

                }
                lck = true;

            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                copySet = currentSet;
            }
            else
            {

                copySkill = currentSkill;

                

            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                currentSet = copySet;
                css[cbChar.SelectedIndex] = currentSet;

                lck = false;
                int temp = cbChar.SelectedIndex;
                cbChar.SelectedIndex = 0;
                cbChar.Items.Clear();
                for (int i = 0; i < css.Count; i++)
                    cbChar.Items.Add("Character " + css[i].charID.ToString("000") + " - Costume " + css[i].costumeID.ToString("00"));
                cbChar.SelectedIndex = temp;
                lck = true;
            }
            else
            {

                currentSkill = copySkill;
                UpdateCurrentSkill();    
                

                lck = false;
                switch (cbType.SelectedIndex)
                {
                    case 0:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Super.Count; i++)
                            cbSkill.Items.Add(Super[i].id.ToString("000") + " - " + Super[i].shortName);
                        break;
                    case 1:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Ultimate.Count; i++)
                            cbSkill.Items.Add(Ultimate[i].id.ToString("000") + " - " + Ultimate[i].shortName);
                        break;
                    case 2:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Evasive.Count; i++)
                            cbSkill.Items.Add(Evasive[i].id.ToString("000") + " - " + Evasive[i].shortName);
                        break;
                    case 3:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < blast.Count; i++)
                            cbSkill.Items.Add(blast[i].id.ToString("000") + " - " + blast[i].shortName);
                        break;
                    case 4:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < Awaken.Count; i++)
                            cbSkill.Items.Add(Awaken[i].id.ToString("000") + " - " + Awaken[i].shortName);
                        break;

                }
                lck = true;

            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
    }
}
