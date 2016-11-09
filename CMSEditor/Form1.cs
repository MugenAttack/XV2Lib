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
using System.Xml;

namespace CMSEditor
{
    public partial class Form1 : Form
    {
        string FileName;
        List<Char_Model_Spec> cms = new List<Char_Model_Spec>();
        Char_Model_Spec current;
        Char_Model_Spec Copy;
        bool canPaste = false;
        bool lck = true;
        bool[] selective;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFile = new OpenFileDialog();
            browseFile.Filter = "Xenoverse Char_Model_Spec (*.cms)|*.cms";
            browseFile.Title = "Browse for CMS File";
            if (browseFile.ShowDialog() == DialogResult.Cancel)
                return;

            FileName = browseFile.FileName;
            cms.Clear();
            cms.AddRange(CMS.Read(FileName));
            selective = new bool[cms.Count];

            
            cbList.Items.Clear();
            for (int i = 0; i < cms.Count; i++)
            {
                cbList.Items.Add(cms[i].id.ToString("000") + " - " + cms[i].shortname);
                selective[i] = false;
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CMS.Write(FileName, cms.ToArray());
            MessageBox.Show("File has been saved!!!");
        }

        private void cbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lck = false;
            current = cms[cbList.SelectedIndex];
            txtChar.Text = current.id.ToString();
            txtSN.Text = current.shortname;
            txt1.Text = current.unk1.ToString();
            txt2.Text = current.unk2.ToString();
            txt3.Text = current.unk3.ToString();
            txt4.Text = current.unk4.ToString();
            txt5.Text = current.unk5.ToString();
            txt6.Text = current.Paths[0];
            txt7.Text = current.Paths[1];
            txt8.Text = current.Paths[2];
            textBox1.Text = current.Paths[3];
            txt9.Text = current.Paths[4];
            txt10.Text = current.Paths[5];
            txt11.Text = current.Paths[6];
            txt12.Text = current.Paths[7];
            txt13.Text = current.Paths[8];
            checkBox1.Checked = selective[cbList.SelectedIndex];
            lck = true;
            
        }

        private void txtChar_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                lck = false;
                current.id = int.Parse(txtChar.Text);
                cms[cbList.SelectedIndex] = current;

                int temp = cbList.SelectedIndex;
                cbList.SelectedIndex = 0;
                cbList.Items.Clear();
                for (int i = 0; i < cms.Count; i++)
                    cbList.Items.Add(cms[i].id.ToString("000") + " - " + cms[i].shortname);
                cbList.SelectedIndex = temp;
                lck = true;
            }
        }

        private void txtSN_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                lck = false;
                current.shortname = txtSN.Text;
                cms[cbList.SelectedIndex] = current;

                int temp = cbList.SelectedIndex;
                cbList.SelectedIndex = 0;
                cbList.Items.Clear();
                for (int i = 0; i < cms.Count; i++)
                    cbList.Items.Add(cms[i].id.ToString("000") + " - " + cms[i].shortname);
                cbList.SelectedIndex = temp;
                lck = true;
            }
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            current.unk1 = int.Parse(txt1.Text);
            cms[cbList.SelectedIndex] = current;
        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {
            current.unk2 = short.Parse(txt2.Text);
            cms[cbList.SelectedIndex] = current;
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {
            current.unk3 = short.Parse(txt3.Text);
            cms[cbList.SelectedIndex] = current;
        }

        private void txt4_TextChanged(object sender, EventArgs e)
        {
            current.unk4 = short.Parse(txt4.Text);
            cms[cbList.SelectedIndex] = current;
        }

        private void txt5_TextChanged(object sender, EventArgs e)
        {
            current.unk5 = short.Parse(txt5.Text);
            cms[cbList.SelectedIndex] = current;
        }

        private void txt6_TextChanged(object sender, EventArgs e)
        {
            current.Paths[0] = txt6.Text;
            cms[cbList.SelectedIndex] = current;
        }

        private void txt7_TextChanged(object sender, EventArgs e)
        {
            current.Paths[1] = txt7.Text;
            cms[cbList.SelectedIndex] = current;
        }

        private void txt8_TextChanged(object sender, EventArgs e)
        {
            current.Paths[2] = txt8.Text;
            cms[cbList.SelectedIndex] = current;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            current.Paths[3] = textBox1.Text;
            cms[cbList.SelectedIndex] = current;
        }

        private void txt9_TextChanged(object sender, EventArgs e)
        {
            current.Paths[4] = txt9.Text;
            cms[cbList.SelectedIndex] = current;
        }

        private void txt10_TextChanged(object sender, EventArgs e)
        {
            current.Paths[5] = txt10.Text;
            cms[cbList.SelectedIndex] = current;
        }

        private void txt11_TextChanged(object sender, EventArgs e)
        {
            current.Paths[6] = txt11.Text;
            cms[cbList.SelectedIndex] = current;
        }

        private void txt12_TextChanged(object sender, EventArgs e)
        {
            current.Paths[7] = txt12.Text;
            cms[cbList.SelectedIndex] = current;
        }

        private void txt13_TextChanged(object sender, EventArgs e)
        {
            current.Paths[8] = txt13.Text;
            cms[cbList.SelectedIndex] = current;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Char_Model_Spec c = new Char_Model_Spec();
            c.Paths = new string[9];
            cms.Add(c);
            cbList.Items.Clear();
            for (int i = 0; i < cms.Count; i++)
                cbList.Items.Add(cms[i].id.ToString("000") + " - " + cms[i].shortname);

            Array.Resize<bool>(ref selective, selective.Length + 1);

            selective[selective.Length - 1] = false;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.RemoveAt(cbList.SelectedIndex);
            cbList.Items.Clear();
            for (int i = 0; i < cms.Count; i++)
                cbList.Items.Add(cms[i].id.ToString("000") + " - " + cms[i].shortname);

            Array.Resize<bool>(ref selective, selective.Length - 1);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy = current;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current = Copy;
            cms[cbList.SelectedIndex] = current;
            txtChar.Text = current.id.ToString();
            txtSN.Text = current.shortname;
            txt1.Text = current.unk1.ToString();
            txt2.Text = current.unk2.ToString();
            txt3.Text = current.unk3.ToString();
            txt4.Text = current.unk4.ToString();
            txt5.Text = current.unk5.ToString();
            txt6.Text = current.Paths[0];
            txt7.Text = current.Paths[1];
            txt8.Text = current.Paths[2];
            textBox1.Text = current.Paths[3];
            txt9.Text = current.Paths[4];
            txt10.Text = current.Paths[5];
            txt11.Text = current.Paths[6];
            txt12.Text = current.Paths[7];
            txt13.Text = current.Paths[8];
            current = cms[cbList.SelectedIndex];

            int temp = cbList.SelectedIndex;
            cbList.SelectedIndex = 0;
            cbList.Items.Clear();
            for (int i = 0; i < cms.Count; i++)
                cbList.Items.Add(cms[i].id.ToString("000") + " - " + cms[i].shortname);
            cbList.SelectedIndex = temp;

        }

        

        private void selectiveSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Char_Model_Spec> SelectCMS = new List<Char_Model_Spec>();

            for (int i = 0; i < cms.Count; i++)
            {
                if (selective[i])
                    SelectCMS.Add(cms[i]);

            }

            CMS.Write("Selective.cms", SelectCMS.ToArray());

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            selective[cbList.SelectedIndex] = checkBox1.Checked;
        }

        private void appendCMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFile = new OpenFileDialog();
            browseFile.Filter = "Xenoverse Char_Model_Spec (*.cms)|*.cms";
            browseFile.Title = "Browse for CMS File";
            if (browseFile.ShowDialog() == DialogResult.Cancel)
                return;

            FileName = browseFile.FileName;

            cms.AddRange(CMS.Read(FileName));
            selective = new bool[cms.Count];


            cbList.Items.Clear();
            for (int i = 0; i < cms.Count; i++)
            {
                cbList.Items.Add(cms[i].id.ToString("000") + " - " + cms[i].shortname);
                selective[i] = false;
            }
        }
    }
}
