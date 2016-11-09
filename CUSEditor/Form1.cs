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
        skill[] Super = new skill[1];
        skill[] Ultimate = new skill[1]; 
        skill[] Evasive = new skill[1]; 
        skill[] blast = new skill[1]; 
        skill[] Awaken = new skill[1]; 
        charSkillSet[] css = new charSkillSet[1];
        bool lck = true;
        charSkillSet copySet;
        skill copySkill;

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

            FileName = browseFile.FileName;
            CUS.Read(FileName, ref css, ref Super, ref Ultimate, ref Evasive, ref Awaken, ref blast);

            cbChar.Items.Clear();
            for (int i = 0; i < css.Length; i++)
                cbChar.Items.Add("Character " + css[i].charID.ToString("000") + " - Costume " + css[i].costumeID.ToString("00"));



        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CUS.Write(FileName, ref css, ref Super, ref Ultimate, ref Evasive, ref Awaken, ref blast);
        }

        private void cbChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            lck = false;
            txtCharID.Text = css[cbChar.SelectedIndex].charID.ToString();
            txtCostID.Text = css[cbChar.SelectedIndex].costumeID.ToString();
            txtSup1.Text = css[cbChar.SelectedIndex].skill[0].ToString();
            txtSup2.Text = css[cbChar.SelectedIndex].skill[1].ToString();
            txtSup3.Text = css[cbChar.SelectedIndex].skill[2].ToString();
            txtSup4.Text = css[cbChar.SelectedIndex].skill[3].ToString();
            txtUlt1.Text = css[cbChar.SelectedIndex].skill[4].ToString();
            txtUlt2.Text = css[cbChar.SelectedIndex].skill[5].ToString();
            txtEva.Text = css[cbChar.SelectedIndex].skill[6].ToString();
            txtKiB.Text = css[cbChar.SelectedIndex].skill[7].ToString();
            txtAwa.Text = css[cbChar.SelectedIndex].skill[8].ToString();
            txtVal.Text = css[cbChar.SelectedIndex].skill[9].ToString();
            lck = true;
        }

        private void txtCharID_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                lck = false;
                css[cbChar.SelectedIndex].charID = int.Parse(txtCharID.Text);
               
                int temp = cbChar.SelectedIndex;
                cbChar.SelectedIndex = 0;
                cbChar.Items.Clear();
                for (int i = 0; i < css.Length; i++)
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
                css[cbChar.SelectedIndex].costumeID = int.Parse(txtCostID.Text);
                
                int temp = cbChar.SelectedIndex;
                cbChar.SelectedIndex = 0;
                cbChar.Items.Clear();
                for (int i = 0; i < css.Length; i++)
                    cbChar.Items.Add("Character " + css[i].charID.ToString("000") + " - Costume " + css[i].costumeID.ToString("00"));
                cbChar.SelectedIndex = temp;
                lck = true;
            }
        }

        private void txtSup1_TextChanged(object sender, EventArgs e)
        {
            css[cbChar.SelectedIndex].skill[0] = short.Parse(txtSup1.Text);
        }

        private void txtSup2_TextChanged(object sender, EventArgs e)
        {
            css[cbChar.SelectedIndex].skill[1] = short.Parse(txtSup2.Text);
        }

        private void txtSup3_TextChanged(object sender, EventArgs e)
        {
            css[cbChar.SelectedIndex].skill[2] = short.Parse(txtSup3.Text);
        }

        private void txtSup4_TextChanged(object sender, EventArgs e)
        {
            css[cbChar.SelectedIndex].skill[3] = short.Parse(txtSup4.Text);
        }

        private void txtUlt1_TextChanged(object sender, EventArgs e)
        {
            css[cbChar.SelectedIndex].skill[4] = short.Parse(txtUlt1.Text);
        }

        private void txtUlt2_TextChanged(object sender, EventArgs e)
        {
            css[cbChar.SelectedIndex].skill[5] = short.Parse(txtUlt2.Text);
        }

        private void txtEva_TextChanged(object sender, EventArgs e)
        {
            css[cbChar.SelectedIndex].skill[6] = short.Parse(txtEva.Text);
        }

        private void txtKiB_TextChanged(object sender, EventArgs e)
        {
            css[cbChar.SelectedIndex].skill[7] = short.Parse(txtKiB.Text);
        }

        private void txtAwa_TextChanged(object sender, EventArgs e)
        {
            css[cbChar.SelectedIndex].skill[8] = short.Parse(txtAwa.Text);
        }

        private void txtVal_TextChanged(object sender, EventArgs e)
        {
            css[cbChar.SelectedIndex].skill[9] = short.Parse(txtVal.Text);
        }



    }
}
