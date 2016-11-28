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
namespace PSCEditor
{
    public partial class Form1 : Form
    {
        PSC file = new PSC();
        PSC_Costume Copy;
        string FileName;
        string[] keys;
        bool lck = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFile = new OpenFileDialog();
            browseFile.Filter = "Xenoverse psc (*.psc)|*.psc";
            browseFile.Title = "Browse for parameter spec char file";
            if (browseFile.ShowDialog() == DialogResult.Cancel)
                return;

            FileName = browseFile.FileName;
            file.Read(FileName);
            file.SetSchema("PSC_Schema.csv");
            
            cbChar.Items.Clear();
            for (int i = 0; i < file.list.Length; i++)
                cbChar.Items.Add(file.list[i].id);

            lstData.Items.Clear();
             keys = file.schema.getKeys();
            foreach (string s in keys)
            {
                var Item = new ListViewItem(new[] { s, "0" });
                lstData.Items.Add(Item);
            }
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            file.Write(FileName);
        }

        private void cbChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCostume.Items.Clear();
            for (int i = 0; i < file.list[cbChar.SelectedIndex].Costume_Data.Length; i++)
            {
                cbCostume.Items.Add(file.schema.getValueString(keys[0], ref file.list[cbChar.SelectedIndex].Costume_Data[i].Data));
            }
            txtCharID.Text = file.list[cbChar.SelectedIndex].id.ToString();
        }

        private void cbCostume_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstData.Items.Clear();
            foreach (string s in keys)
            {
                var Item = new ListViewItem(new[] { s, file.schema.getValueString(s, ref file.list[cbChar.SelectedIndex].Costume_Data[cbCostume.SelectedIndex].Data) });
                lstData.Items.Add(Item);
            }
        }

        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {
            lck = false;
            if (lstData.SelectedItems.Count != 0)
            {
                txtName.Text = lstData.SelectedItems[0].SubItems[0].Text;
                txtVal.Text = lstData.SelectedItems[0].SubItems[1].Text;
            }
            lck = true;
        }

        private void txtVal_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                lstData.SelectedItems[0].SubItems[1].Text = txtVal.Text;
                file.schema.setValueString(txtName.Text, ref file.list[cbChar.SelectedIndex].Costume_Data[cbCostume.SelectedIndex].Data, txtVal.Text);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy = file.list[cbChar.SelectedIndex].Costume_Data[cbCostume.SelectedIndex];
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            file.list[cbChar.SelectedIndex].Costume_Data[cbCostume.SelectedIndex] = Copy;
            cbCostume.Items[cbCostume.SelectedIndex] = file.schema.getValueString(keys[0], ref file.list[cbChar.SelectedIndex].Costume_Data[cbCostume.SelectedIndex].Data);
            lstData.Items.Clear();
            foreach (string s in keys)
            {
                var Item = new ListViewItem(new[] { s, file.schema.getValueString(s, ref file.list[cbChar.SelectedIndex].Costume_Data[cbCostume.SelectedIndex].Data) });
                lstData.Items.Add(Item);
            }
        }

        private void characterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //add character
            cbChar.SelectedIndex = 0;
            Array.Resize<PSC_Char>(ref file.list, file.list.Length + 1);
            file.list[file.list.Length - 1].Costume_Data = new PSC_Costume[1];
            file.list[file.list.Length - 1].Costume_Data[0].Data = new byte[196];
            cbChar.Items.Clear();
            for (int i = 0; i < file.list.Length; i++)
                cbChar.Items.Add(file.list[i].id);

        }

        private void costumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //add costume
            cbCostume.SelectedIndex = 0;
            Array.Resize<PSC_Costume>(ref file.list[cbChar.SelectedIndex].Costume_Data, file.list[cbChar.SelectedIndex].Costume_Data.Length + 1);
            file.list[cbChar.SelectedIndex].Costume_Data[file.list[cbChar.SelectedIndex].Costume_Data.Length - 1].Data = new byte[196];
            cbCostume.Items.Clear();
            for (int i = 0; i < file.list[cbChar.SelectedIndex].Costume_Data.Length; i++)
            {
                cbCostume.Items.Add(file.schema.getValueString(keys[0], ref file.list[cbChar.SelectedIndex].Costume_Data[i].Data));
            }
        }

        private void characterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //remove character
            cbChar.SelectedIndex = 0;
            Array.Resize<PSC_Char>(ref file.list, file.list.Length - 1);

            cbChar.Items.Clear();
            for (int i = 0; i < file.list.Length; i++)
                cbChar.Items.Add(file.list[i].id);
        }

        private void costumeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //remove costume
            cbCostume.SelectedIndex = 0;
            if (file.list[cbChar.SelectedIndex].Costume_Data.Length != 1)
                Array.Resize<PSC_Costume>(ref file.list[cbChar.SelectedIndex].Costume_Data, file.list[cbChar.SelectedIndex].Costume_Data.Length - 1);

            cbCostume.Items.Clear();
            for (int i = 0; i < file.list[cbChar.SelectedIndex].Costume_Data.Length; i++)
            {
                cbCostume.Items.Add(file.schema.getValueString(keys[0], ref file.list[cbChar.SelectedIndex].Costume_Data[i].Data));
            }
        }

        private void txtCharID_TextChanged(object sender, EventArgs e)
        {
            int p;
            if (int.TryParse(txtCharID.Text,out p))
            {
                file.list[cbChar.SelectedIndex].id = p;
                cbChar.Items[cbChar.SelectedIndex] = txtCharID.Text;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
