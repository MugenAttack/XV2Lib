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
namespace MSGEditor
{
    public partial class convert : Form
    {
        int[] type = { 0, 256, 512 };
        public convert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFile = new OpenFileDialog();
            browseFile.Filter = "Xenoverse msg (*.msg)|*.msg";
            browseFile.Title = "Browse for msg File";
            if (browseFile.ShowDialog() == DialogResult.Cancel)
                return;
            MSG m;
            foreach (string f in browseFile.FileNames)
            {
                m = MSGStream.Read(f);
                m.type = type[cbType.SelectedIndex];
                MSGStream.Write(m, f);
            }
        }
    }
}
