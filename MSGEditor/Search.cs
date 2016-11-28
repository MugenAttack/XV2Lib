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

    
    public partial class Search : Form
    {

        List<int> loc;
        List<string> locS;
        private Form1 mainform = null;
        public Search(Form callform)
        {
            mainform = callform as Form1;
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            loc = new List<int>();
            locS = new List<string>();
            for (int i = 0; i < mainform.file.data.Length; i++)
            {
                for (int j = 0; j < mainform.file.data[i].Lines.Length; j++)
                {
                    if (mainform.file.data[i].Lines[j].Contains(textBox1.Text))
                    {
                        loc.Add(i);
                        locS.Add(mainform.file.data[i].NameID);
                        break;
                    }
                }
            }

            lstSearch.Items.Clear();
            foreach (string s in locS)
                lstSearch.Items.Add(s);

        }

        private void lstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainform.cbList.SelectedIndex = loc[lstSearch.SelectedIndex];
        }
    }
}
