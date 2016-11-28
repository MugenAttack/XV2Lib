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

namespace IDBEditor
{
    public partial class Form1 : Form
    {
        IDB file = new IDB();
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
            browseFile.Filter = "Xenoverse idb (*.idb)|*.idb";
            browseFile.Title = "Browse for idb file";
            if (browseFile.ShowDialog() == DialogResult.Cancel)
                return;

            FileName = browseFile.FileName;
            file.Read(FileName);
            file.SetSchema("IDB_Schema.csv");
            cbList.Items.Clear();
            for (int i = 0; i < file.items.Length; i++)
                cbList.Items.Add(file.items[i].id);

            lstData.Items.Clear();
            keys = file.schema.getKeys();
            foreach (string s in keys)
            {
                var Item = new ListViewItem(new[] { s, "0" });
                lstData.Items.Add(Item);
            }

        }

        private void cbList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
