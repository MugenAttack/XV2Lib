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
        CUSRegistry file;
        
        bool lck = true;
        charSkillSet copySet;
        charSkillSet currentSet;
        skill copySkill;
        skill currentSkill;
        Settings s;
        bool infoLoaded = false;
        
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
            //read CUS
            file.readCUS(FileName);

            bool infoLoaded = s.Read();
            if (infoLoaded)
            {
                file.BuildRegistry(s.MSGFolder, s.language);
            }
            else
            {
                file.BuildRegistry("", "");
            }

            cbChar.Items.Clear();
            for (int i = 0; i < file.css.Length; i++)
                cbChar.Items.Add("Character " + file.css[i].charID.ToString("000") + " - Costume " + file.css[i].costumeID.ToString("00"));

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            file.readCUS(FileName);
        }

        private void cbChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            lck = false;
            currentSet = file.css[cbChar.SelectedIndex];
            txtCharID.Text = currentSet.charID.ToString();
            txtCostID.Text = currentSet.costumeID.ToString();
            


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
                file.css[cbChar.SelectedIndex] = currentSet;

                UpdateCharlist();
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
                file.css[cbChar.SelectedIndex] = currentSet;

                UpdateCharlist();
                lck = true;
            }
        }

        private void UpdateCharlist()
        {
            int temp = cbChar.SelectedIndex;
            cbChar.SelectedIndex = 0;
            cbChar.Items.Clear();
            //if (infoLoaded)
            //{

            //}
            //else
            //{
                for (int i = 0; i < file.css.Length; i++)
                    cbChar.Items.Add("Character " + file.css[i].charID.ToString("000") + " - Costume " + file.css[i].costumeID.ToString("00"));
            //}
            cbChar.SelectedIndex = temp;

        }

        

        private void txtVal_TextChanged(object sender, EventArgs e)
        {
            file.css[cbChar.SelectedIndex].skill[9] = short.Parse(txtVal.Text); 
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lck = false;
            switch (cbType.SelectedIndex)
            {
                case 0:
                    cbSkill.Items.Clear();
                    for (int i = 0; i < file.Super.Count; i++)
                        cbSkill.Items.Add(file.Super[i].id.ToString("000") + " - " + file.Super[i].shortName);
                    break;
                case 1:
                    cbSkill.Items.Clear();
                    for (int i = 0; i < file.Ultimate.Count; i++)
                        cbSkill.Items.Add(file.Ultimate[i].id.ToString("000") + " - " + file.Ultimate[i].shortName);
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
                    currentSkill = file.Super[cbSkill.SelectedIndex];
                    break;
                case 1:
                    currentSkill = file.Ultimate[cbSkill.SelectedIndex];
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
                    file.Super[cbSkill.SelectedIndex] = currentSkill;
                    break;
                case 1:
                    file.Ultimate[cbSkill.SelectedIndex] = currentSkill;
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
                        for (int i = 0; i < file.Super.Count; i++)
                            cbSkill.Items.Add(file.Super[i].id.ToString("000") + " - " + file.Super[i].shortName);
                        break;
                    case 1:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < file.Ultimate.Count; i++)
                            cbSkill.Items.Add(file.Ultimate[i].id.ToString("000") + " - " + file.Ultimate[i].shortName);
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
                        for (int i = 0; i < file.Super.Count; i++)
                            cbSkill.Items.Add(file.Super[i].id.ToString("000") + " - " + file.Super[i].shortName);
                        break;
                    case 1:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < file.Ultimate.Count; i++)
                            cbSkill.Items.Add(file.Ultimate[i].id.ToString("000") + " - " + file.Ultimate[i].shortName);
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
                file.css.Add(n);

                lck = false;
                int temp = cbChar.SelectedIndex;
                cbChar.SelectedIndex = 0;
                cbChar.Items.Clear();
                for (int i = 0; i < file.css.Count; i++)
                    cbChar.Items.Add("Character " + file.css[i].charID.ToString("000") + " - Costume " + file.css[i].costumeID.ToString("00"));
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
                        file.Super.Add(n);
                        break;
                    case 1:
                        file.Ultimate.Add(n);
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
                        for (int i = 0; i < file.Super.Count; i++)
                            cbSkill.Items.Add(file.Super[i].id.ToString("000") + " - " + file.Super[i].shortName);
                        break;
                    case 1:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < file.Ultimate.Count; i++)
                            cbSkill.Items.Add(file.Ultimate[i].id.ToString("000") + " - " + file.Ultimate[i].shortName);
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
                file.css.RemoveAt(cbChar.SelectedIndex);
                lck = false;
                int temp = cbChar.SelectedIndex;
                cbChar.SelectedIndex = 0;
                cbChar.Items.Clear();
                for (int i = 0; i < file.css.Count; i++)
                    cbChar.Items.Add("Character " + file.css[i].charID.ToString("000") + " - Costume " + file.css[i].costumeID.ToString("00"));
                cbChar.SelectedIndex = temp;
                lck = true;
            }
            else
            {
                
                switch (cbType.SelectedIndex)
                {
                    case 0:
                        file.Super.RemoveAt(cbSkill.SelectedIndex);
                        break;
                    case 1:
                        file.Ultimate.RemoveAt(cbSkill.SelectedIndex);
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
                        for (int i = 0; i < file.Super.Count; i++)
                            cbSkill.Items.Add(file.Super[i].id.ToString("000") + " - " + file.Super[i].shortName);
                        break;
                    case 1:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < file.Ultimate.Count; i++)
                            cbSkill.Items.Add(file.Ultimate[i].id.ToString("000") + " - " + file.Ultimate[i].shortName);
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
                file.css[cbChar.SelectedIndex] = currentSet;

                lck = false;
                int temp = cbChar.SelectedIndex;
                cbChar.SelectedIndex = 0;
                cbChar.Items.Clear();
                for (int i = 0; i < file.css.Count; i++)
                    cbChar.Items.Add("Character " + file.css[i].charID.ToString("000") + " - Costume " + file.css[i].costumeID.ToString("00"));
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
                        for (int i = 0; i < file.Super.Count; i++)
                            cbSkill.Items.Add(file.Super[i].id.ToString("000") + " - " + file.Super[i].shortName);
                        break;
                    case 1:
                        cbSkill.Items.Clear();
                        for (int i = 0; i < file.Ultimate.Count; i++)
                            cbSkill.Items.Add(file.Ultimate[i].id.ToString("000") + " - " + file.Ultimate[i].shortName);
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

        private void label34_Click(object sender, EventArgs e)
        {

        }
    }
}
