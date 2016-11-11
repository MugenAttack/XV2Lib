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
            if (lck)
            {
                lck = false;
                currentSet.charID = int.Parse(txtCharID.Text);
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
            if (lck)
            {
                lck = false;
                currentSet.costumeID = int.Parse(txtCostID.Text);
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
            currentSet.skill[0] = short.Parse(txtSup1.Text);
            css[cbChar.SelectedIndex] = currentSet;
        }

        private void txtSup2_TextChanged(object sender, EventArgs e)
        {
            currentSet.skill[1] = short.Parse(txtSup2.Text);
            css[cbChar.SelectedIndex] = currentSet;
        }

        private void txtSup3_TextChanged(object sender, EventArgs e)
        {
            currentSet.skill[2] = short.Parse(txtSup3.Text);
            css[cbChar.SelectedIndex] = currentSet;
        }

        private void txtSup4_TextChanged(object sender, EventArgs e)
        {
            currentSet.skill[3] = short.Parse(txtSup4.Text);
            css[cbChar.SelectedIndex] = currentSet;
        }

        private void txtUlt1_TextChanged(object sender, EventArgs e)
        {
            currentSet.skill[4] = short.Parse(txtUlt1.Text);
            css[cbChar.SelectedIndex] = currentSet;
        }

        private void txtUlt2_TextChanged(object sender, EventArgs e)
        {
            currentSet.skill[5] = short.Parse(txtUlt2.Text);
            css[cbChar.SelectedIndex] = currentSet;
        }

        private void txtEva_TextChanged(object sender, EventArgs e)
        {
            currentSet.skill[6] = short.Parse(txtEva.Text);
            css[cbChar.SelectedIndex] = currentSet;
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

            txtShortName.Text = currentSkill.shortName;
            txtid.Text = currentSkill.id.ToString();
            txtid2.Text = currentSkill.id2.ToString();
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

        }

        private void txtShortName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtid2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHair_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
