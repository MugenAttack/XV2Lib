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
        PSC file;
        string FileName;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            file = new PSC("PSC_Schema.csv");

            OpenFileDialog browseFile = new OpenFileDialog();
            browseFile.Filter = "Xenoverse psc (*.psc)|*.psc";
            browseFile.Title = "Browse for parameter spec char file";
            if (browseFile.ShowDialog() == DialogResult.Cancel)
                return;

            FileName = browseFile.FileName;
            file.Read(FileName);


        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            file.Write(FileName);
        }
    }
}
