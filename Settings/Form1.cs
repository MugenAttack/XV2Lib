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

namespace Settings
{
    public partial class Form1 : Form
    {
        string[] Lang = new string[]
        {
            "ca",
            "de",
            "en",
            "es",
            "fr",
            "it",
            "pl",
            "pt",
            "ru"
        };

        XV2Lib.Settings s = new XV2Lib.Settings();
        public Form1()
        {
            InitializeComponent();
        }

        private void txtMSG_TextChanged(object sender, EventArgs e)
        {
            s.XENOFolder = txtMSG.Text;
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            s.language = Lang[cbLang.SelectedIndex];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s.Write();
            MessageBox.Show("File has been saved!!!");
        }

        private void btnFMSG_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browseFolder = new FolderBrowserDialog();
            browseFolder.Description = "Find Xenoverse 2 Folder";
            if (browseFolder.ShowDialog() == DialogResult.Cancel)
                return;

            txtMSG.Text = browseFolder.SelectedPath + "\\";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
