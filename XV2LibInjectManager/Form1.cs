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

namespace XV2LibInjectManager
{
    public partial class Form1 : Form
    {
        struct Clean
        {
            byte[] Data;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void characterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "default.x2i";
            save.Filter = "XV2Lib inject files (*.x2i)|*.x2i";

            if (save.ShowDialog() == DialogResult.OK)
            {
                BinaryWriter bw = new BinaryWriter(File.Open(save.FileName, FileMode.Create));
                bw.Write(Encoding.ASCII.GetBytes("XV2I"));
                bw.Write(Encoding.ASCII.GetBytes("CHAR"));

                if (MessageBox.Show("Do you want this to be a Patch?", "",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    bw.Write(1);
                else
                    bw.Write(0);

                bw.Write(0);//cms
                bw.Write(0);

                bw.Write(0);//name
                bw.Write(0);

                bw.Write(0);//cus
                bw.Write(0);

                bw.Write(0);//psc
                bw.Write(0);

                bw.Write(0);//cso
                bw.Write(0);

                bw.Write(0);//sev
                bw.Write(0);

                bw.Write(0);//aur
                bw.Write(0);

                bw.Write(0);
                bw.Write(0);

                bw.Write(0);
                bw.Write(0);

                bw.Write(0);
                bw.Write(0);

            }        
        }

        private void superSoulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "default.x2i";
            save.Filter = "XV2Lib inject files (*.x2i)|*.x2i";

            if (save.ShowDialog() == DialogResult.OK)
            {
                BinaryWriter bw = new BinaryWriter(File.Open(save.FileName, FileMode.Create));
                bw.Write(Encoding.ASCII.GetBytes("XV2I"));
                bw.Write(Encoding.ASCII.GetBytes("SOUL"));

                if (MessageBox.Show("Do you want this to be a Patch?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    bw.Write(1);
                else
                    bw.Write(0);

                bw.Write(0);//name
                bw.Write(0);

                bw.Write(0);//description
                bw.Write(0);

                bw.Write(0);//idb data
                bw.Write(0);
            }
        }

        private void costumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "default.x2i";
            save.Filter = "XV2Lib inject files (*.x2i)|*.x2i";

            if (save.ShowDialog() == DialogResult.OK)
            {
                BinaryWriter bw = new BinaryWriter(File.Open(save.FileName, FileMode.Create));
                bw.Write(Encoding.ASCII.GetBytes("XV2I"));
                bw.Write(Encoding.ASCII.GetBytes("COST"));

                if (MessageBox.Show("Do you want this to be a Patch?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    bw.Write(1);
                else
                    bw.Write(0);

                bw.Write(0);//name
                bw.Write(0);

                bw.Write(0);//description
                bw.Write(0);

                bw.Write(0);//bcs
                bw.Write(0);

                bw.Write(0);//Accessory idb
                bw.Write(0);

                bw.Write(0);//Top idb
                bw.Write(0);

                bw.Write(0);//Bottom idb
                bw.Write(0);

                bw.Write(0);//Gloves idb
                bw.Write(0);

                bw.Write(0);//Boots idb
                bw.Write(0);
            }
        }
    }
}
