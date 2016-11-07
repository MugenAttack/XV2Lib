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
namespace CSOEditor
{
    public partial class Form1 : Form
    {
        string FileName;
        List<CSO_Data> Data = new List<CSO_Data>();
        CSO_Data current;
        bool lck = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFile = new OpenFileDialog();
            browseFile.Filter = "Xenoverse Character Sound (*.cso)|*.cso";
            browseFile.Title = "Browse for CSO File";
            if (browseFile.ShowDialog() == DialogResult.Cancel)
                return;

            FileName = browseFile.FileName;
            Data.AddRange(CSO.Read(FileName));

            cbList.Items.Clear();
            for (int i = 0; i < Data.Count; i++)
                cbList.Items.Add("Character " + Data[i].Char_ID.ToString("000") + " - Costume " + Data[i].Costume_ID.ToString("00"));

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CSO.Write(Data.ToArray(), FileName);
            MessageBox.Show("File has been saved!!!");
        }

        private void cbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lck = false;
            current = Data[cbList.SelectedIndex];
            txtChar.Text = current.Char_ID.ToString();
            txtCostume.Text = current.Costume_ID.ToString();
            txt1.Text = current.Paths[0];
            txt2.Text = current.Paths[1];
            txt3.Text = current.Paths[2];
            txt4.Text = current.Paths[3];
            lck = true;
        }

        private void txtChar_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                lck = false;
                current.Char_ID = int.Parse(txtChar.Text);
                Data[cbList.SelectedIndex] = current;

                int temp = cbList.SelectedIndex;
                cbList.SelectedIndex = 0;
                cbList.Items.Clear();
                for (int i = 0; i < Data.Count; i++)
                    cbList.Items.Add("Character " + Data[i].Char_ID.ToString("000") + " - Costume " + Data[i].Costume_ID.ToString("00"));
                cbList.SelectedIndex = temp;
                lck = true;
            }
        }

        private void txtCostume_TextChanged(object sender, EventArgs e)
        {
            if (lck)
            {
                lck = false;
                current.Costume_ID = int.Parse(txtCostume.Text);
                Data[cbList.SelectedIndex] = current;
                int temp = cbList.SelectedIndex;
                cbList.SelectedIndex = 0;
                cbList.Items.Clear();
                for (int i = 0; i < Data.Count; i++)
                    cbList.Items.Add("Character " + Data[i].Char_ID.ToString("000") + " - Costume " + Data[i].Costume_ID.ToString("00"));
                cbList.SelectedIndex = temp;
                lck = true;
            }
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            current.Paths[0] = txt1.Text;
            Data[cbList.SelectedIndex] = current;
        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {
            current.Paths[1] = txt2.Text;
            Data[cbList.SelectedIndex] = current;
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {
            current.Paths[2] = txt3.Text;
            Data[cbList.SelectedIndex] = current;
        }

        private void txt4_TextChanged(object sender, EventArgs e)
        {
            current.Paths[3] = txt4.Text;
            Data[cbList.SelectedIndex] = current;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CSO_Data c = new CSO_Data();
            c.Paths = new string[4];
            Data.Add(c);
            
            cbList.SelectedIndex = 0;
            cbList.Items.Clear();
            for (int i = 0; i < Data.Count; i++)
                cbList.Items.Add("Character " + Data[i].Char_ID.ToString("000") + " - Costume " + Data[i].Costume_ID.ToString("00"));
            
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Data.RemoveAt(cbList.SelectedIndex);
            cbList.SelectedIndex = 0;
            cbList.Items.Clear();
            for (int i = 0; i < Data.Count; i++)
                cbList.Items.Add("Character " + Data[i].Char_ID.ToString("000") + " - Costume " + Data[i].Costume_ID.ToString("00"));
            
        }
    }
}
