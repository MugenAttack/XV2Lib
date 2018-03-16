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
namespace CUSEditor
{
    public partial class Form1 : Form
    {
        string FileName;
        CUSRegistry file = new CUSRegistry();
        
        bool lck = true;
        charSkillSet copySet;
        charSkillSet currentSet;
        skill copySkill;
        skill currentSkill;
        Settings s = new Settings();
        
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
                file.BuildRegistry(s.XENOFolder + "data\\msg\\", s.language);
            }
            else
            {
                file.BuildRegistry("", "");
            }

            cbChar.Items.Clear();
            for (int i = 0; i < file.css.Count; i++)
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
                for (int i = 0; i < file.css.Count; i++)
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
            this.UpdateSkillList();
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
                    currentSkill = file.Evasive[cbSkill.SelectedIndex];
                    break;
                case 3:
                    currentSkill = file.blast[cbSkill.SelectedIndex];
                    break;
                case 4:
                    currentSkill = file.Awaken[cbSkill.SelectedIndex];
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
                    file.Evasive[cbSkill.SelectedIndex] = currentSkill;
                    break;
                case 3:
                    file.blast[cbSkill.SelectedIndex] = currentSkill;
                    break;
                case 4:
                    file.Awaken[cbSkill.SelectedIndex] = currentSkill;
                    break;
            }
        }

        private void txtShortName_TextChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSkill.shortName = this.txtShortName.Text;
            this.UpdateCurrentSkill();
            this.UpdateSkillList();
            this.lblStatus.Text = "";
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            short result;
            if (!this.lck || !short.TryParse(this.txtid.Text, out result))
                return;
            this.currentSkill.id = result;
            this.UpdateCurrentSkill();
            this.UpdateSkillList();
            this.lblStatus.Text = "";
        }

        private void txtid2_TextChanged(object sender, EventArgs e)
        {
            short result;
            if (!this.lck || !short.TryParse(this.txtid2.Text, out result))
                return;
            this.currentSkill.id2 = result;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //race lock
            byte result;
            if (!this.lck || !byte.TryParse(this.textBox1.Text, out result))
                return;
            this.currentSkill.racelock = result;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            byte result;
            if (!this.lck || !byte.TryParse(this.txtid.Text, out result))
                return;
            this.currentSkill.unk1 = result;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {
            short result;
            if (!this.lck || !short.TryParse(this.txt2.Text, out result))
                return;
            this.currentSkill.unk2 = result;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txtHair_TextChanged(object sender, EventArgs e)
        {
            short result;
            if (!this.lck || !short.TryParse(this.txtHair.Text, out result))
                return;
            this.currentSkill.hair = result;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {
            short result;
            if (!this.lck || !short.TryParse(this.txt3.Text, out result))
                return;
            this.currentSkill.unk3 = result;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt4_TextChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSkill.Paths[0] = this.txt4.Text;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt5_TextChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSkill.Paths[1] = this.txt5.Text;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt6_TextChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSkill.Paths[2] = this.txt6.Text;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt7_TextChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSkill.Paths[3] = this.txt7.Text;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt8_TextChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSkill.Paths[4] = this.txt8.Text;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt9_TextChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSkill.Paths[5] = this.txt9.Text;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt10_TextChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSkill.Paths[6] = this.txt10.Text;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt11_TextChanged(object sender, EventArgs e)
        {
            short result;
            if (!this.lck || !short.TryParse(this.txt11.Text, out result))
                return;
            this.currentSkill.unk4 = result;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt12_TextChanged(object sender, EventArgs e)
        {
            short result;
            if (!this.lck || !short.TryParse(this.txt12.Text, out result))
                return;
            this.currentSkill.unk5 = result;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt13_TextChanged(object sender, EventArgs e)
        {
            short result;
            if (!this.lck || !short.TryParse(this.txt13.Text, out result))
                return;
            this.currentSkill.unk6 = result;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt14_TextChanged(object sender, EventArgs e)
        {
            short result;
            if (!this.lck || !short.TryParse(this.txt14.Text, out result))
                return;
            this.currentSkill.unk7 = result;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt15_TextChanged(object sender, EventArgs e)
        {
            short result;
            if (!this.lck || !short.TryParse(this.txt15.Text, out result))
                return;
            this.currentSkill.unk8 = result;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt16_TextChanged(object sender, EventArgs e)
        {
            short result;
            if (!this.lck || !short.TryParse(this.txt16.Text, out result))
                return;
            this.currentSkill.unk9 = result;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt17_TextChanged(object sender, EventArgs e)
        {
            short result;
            if (!this.lck || !short.TryParse(this.txt17.Text, out result))
                return;
            this.currentSkill.unk10 = result;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void txt18_TextChanged(object sender, EventArgs e)
        {
            short result;
            if (!this.lck || !short.TryParse(this.txt18.Text, out result))
                return;
            this.currentSkill.unk11 = (int)result;
            this.UpdateCurrentSkill();
            this.lblStatus.Text = "";
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                this.file.css.Add(new charSkillSet()
                {
                    skill = new short[10],
                    charID = 999
                });
                this.lblStatus.Text = "New Skill Set Added";
                this.lck = false;
                this.UpdateCharlist();
                this.lck = true;
            }
            else
            {
                skill skill = new skill();
                skill.Paths = new string[7];
                SkillReg skillReg = new SkillReg();
                skillReg.name = "";
                skillReg.shortName = "NEW";
                this.lblStatus.Text = "New Skill Data Added";
                switch (this.cbType.SelectedIndex)
                {
                    case 0:
                        this.file.Super.Add(skill);
                        this.file.superReg.Add(skillReg);
                        break;
                    case 1:
                        this.file.Ultimate.Add(skill);
                        this.file.ultimateReg.Add(skillReg);
                        break;
                    case 2:
                        this.file.Evasive.Add(skill);
                        this.file.evasiveReg.Add(skillReg);
                        break;
                    case 3:
                        this.file.blast.Add(skill);
                        this.file.blastReg.Add(skillReg);
                        break;
                    case 4:
                        this.file.Awaken.Add(skill);
                        this.file.awakenReg.Add(skillReg);
                        break;
                }
                this.cbSkill.SelectedIndex = 0;
                this.UpdateSkillList();
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.tabControl1.SelectedIndex == 0)
            {
                this.file.css.RemoveAt(this.cbChar.SelectedIndex);
                this.lblStatus.Text = "Skill set has been removed";
                this.lck = false;
                this.UpdateCharlist();
                this.lck = true;
            }
            else
            {
                switch (this.cbType.SelectedIndex)
                {
                    case 0:
                        this.file.Super.RemoveAt(this.cbSkill.SelectedIndex);
                        this.file.superReg.RemoveAt(this.cbSkill.SelectedIndex);
                        break;
                    case 1:
                        this.file.Ultimate.RemoveAt(this.cbSkill.SelectedIndex);
                        this.file.ultimateReg.RemoveAt(this.cbSkill.SelectedIndex);
                        break;
                    case 2:
                        this.file.Evasive.RemoveAt(this.cbSkill.SelectedIndex);
                        this.file.evasiveReg.RemoveAt(this.cbSkill.SelectedIndex);
                        break;
                    case 3:
                        this.file.blast.RemoveAt(this.cbSkill.SelectedIndex);
                        this.file.blastReg.RemoveAt(this.cbSkill.SelectedIndex);
                        break;
                    case 4:
                        this.file.Awaken.RemoveAt(this.cbSkill.SelectedIndex);
                        this.file.awakenReg.RemoveAt(this.cbSkill.SelectedIndex);
                        break;
                }
                this.lblStatus.Text = "Skill data has been removed";
                this.cbSkill.SelectedIndex = 0;
                this.UpdateSkillList();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
                this.copySet = this.currentSet;
            else
                this.copySkill = this.currentSkill;
            this.lblStatus.Text = "Data has been copied";
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                this.currentSet.skill = this.copySet.skill;
                this.file.css[this.cbChar.SelectedIndex] = this.currentSet;
                this.lck = false;
                int selectedIndex = this.cbChar.SelectedIndex;
                this.cbChar.SelectedIndex = 0;
                this.cbChar.Items.Clear();
                for (int index = 0; index < this.file.css.Count; ++index)
                {
                    ComboBox.ObjectCollection items = this.cbChar.Items;
                    string str1 = "Character ";
                    charSkillSet charSkillSet = this.file.css[index];
                    string str2 = charSkillSet.charID.ToString("000");
                    string str3 = " - Costume ";
                    charSkillSet = this.file.css[index];
                    string str4 = charSkillSet.costumeID.ToString("00");
                    string str5 = str1 + str2 + str3 + str4;
                    items.Add((object)str5);
                }
                this.cbChar.SelectedIndex = selectedIndex;
                this.lck = true;
            }
            else
            {
                this.currentSkill = this.copySkill;
                this.UpdateCurrentSkill();
                this.UpdateSkillList();
                this.lck = false;
                this.txtShortName.Text = this.currentSkill.shortName;
                this.txtid.Text = this.currentSkill.id.ToString();
                this.txtid2.Text = this.currentSkill.id2.ToString();
                this.textBox1.Text = this.currentSkill.racelock.ToString();
                this.txt1.Text = this.currentSkill.unk1.ToString();
                this.txt2.Text = this.currentSkill.unk2.ToString();
                this.txtHair.Text = this.currentSkill.hair.ToString();
                this.txt3.Text = this.currentSkill.unk3.ToString();
                this.txt4.Text = this.currentSkill.Paths[0];
                this.txt5.Text = this.currentSkill.Paths[1];
                this.txt6.Text = this.currentSkill.Paths[2];
                this.txt7.Text = this.currentSkill.Paths[3];
                this.txt8.Text = this.currentSkill.Paths[4];
                this.txt9.Text = this.currentSkill.Paths[5];
                this.txt10.Text = this.currentSkill.Paths[6];
                this.txt11.Text = this.currentSkill.unk4.ToString();
                this.txt12.Text = this.currentSkill.unk5.ToString();
                this.txt13.Text = this.currentSkill.unk6.ToString();
                this.txt14.Text = this.currentSkill.unk7.ToString();
                this.txt15.Text = this.currentSkill.unk8.ToString();
                this.txt16.Text = this.currentSkill.unk9.ToString();
                this.txt17.Text = this.currentSkill.unk10.ToString();
                this.txt18.Text = this.currentSkill.unk11.ToString();
                this.lck = true;
            }
            this.lblStatus.Text = "Data has been pasted in";
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //read CUS
            s.Read();
            
            if (File.Exists(s.XENOFolder + "data\\system\\custom_skill.cus"))
            {
                file.readCUS(s.XENOFolder + "data\\system\\custom_skill.cus");
                file.BuildRegistry(s.XENOFolder + "data\\msg", s.language);
                cbChar.Items.Clear();
                for (int i = 0; i < file.css.Count; i++)
                    cbChar.Items.Add("Character " + file.css[i].charID.ToString("000") + " - Costume " + file.css[i].costumeID.ToString("00"));
            }
            
            
        }

        private void UpdateSkillList()
        {
            this.lck = false;
            //int selectedIndex = this.cbSkill.SelectedIndex;
            this.cbSkill.SelectedIndex = -1;
            switch (this.cbType.SelectedIndex)
            {
                case 0:
                    this.cbSkill.Items.Clear();
                    this.cbSkill.Items.AddRange((object[])this.file.getSkillList(0));
                    break;
                case 1:
                    this.cbSkill.Items.Clear();
                    this.cbSkill.Items.AddRange((object[])this.file.getSkillList(1));
                    break;
                case 2:
                    this.cbSkill.Items.Clear();
                    this.cbSkill.Items.AddRange((object[])this.file.getSkillList(2));
                    break;
                case 3:
                    this.cbSkill.Items.Clear();
                    this.cbSkill.Items.AddRange((object[])this.file.getSkillList(4));
                    break;
                case 4:
                    this.cbSkill.Items.Clear();
                    this.cbSkill.Items.AddRange((object[])this.file.getSkillList(5));
                    break;
            }
            //this.cbSkill.SelectedIndex = selectedIndex;
            this.lck = true;
        }

        private void cbSuper1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSet.skill[0] = this.file.superReg[this.cbSuper1.SelectedIndex].id;
            this.file.css[this.cbChar.SelectedIndex] = this.currentSet;
            this.lblStatus.Text = "";
        }

        private void cbSuper2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSet.skill[1] = this.file.superReg[this.cbSuper2.SelectedIndex].id;
            this.file.css[this.cbChar.SelectedIndex] = this.currentSet;
            this.lblStatus.Text = "";
        }

        private void cbSuper3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSet.skill[2] = this.file.superReg[this.cbSuper3.SelectedIndex].id;
            this.file.css[this.cbChar.SelectedIndex] = this.currentSet;
            this.lblStatus.Text = "";
        }

        private void cbSuper4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSet.skill[3] = this.file.superReg[this.cbSuper4.SelectedIndex].id;
            this.file.css[this.cbChar.SelectedIndex] = this.currentSet;
            this.lblStatus.Text = "";
        }

        private void cbUltimate1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSet.skill[4] = this.file.ultimateReg[this.cbUltimate1.SelectedIndex].id;
            this.file.css[this.cbChar.SelectedIndex] = this.currentSet;
            this.lblStatus.Text = "";
        }

        private void cbUltimate2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSet.skill[5] = this.file.ultimateReg[this.cbUltimate2.SelectedIndex].id;
            this.file.css[this.cbChar.SelectedIndex] = this.currentSet;
            this.lblStatus.Text = "";
        }

        private void cbEvasive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSet.skill[6] = this.file.evasiveReg[this.cbEvasive.SelectedIndex].id;
            this.file.css[this.cbChar.SelectedIndex] = this.currentSet;
            this.lblStatus.Text = "";
        }

        private void cbBlast_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSet.skill[7] = this.file.blastReg[this.cbBlast.SelectedIndex].id;
            this.file.css[this.cbChar.SelectedIndex] = this.currentSet;
            this.lblStatus.Text = "";
        }

        private void cbAwaken_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.lck)
                return;
            this.currentSet.skill[8] = this.file.awakenReg[this.cbAwaken.SelectedIndex].id;
            this.file.css[this.cbChar.SelectedIndex] = this.currentSet;
            this.lblStatus.Text = "";
        }
    }
}
