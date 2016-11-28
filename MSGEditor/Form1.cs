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

namespace MSGEditor
{
    public partial class Form1 : Form
    {
        public MSG file;
        string FileName;
        List<string> sf = new List<string>();
        public Form1()
        {
            InitializeComponent();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFile = new OpenFileDialog();
            browseFile.Filter = "Xenoverse msg (*.msg)|*.msg";
            browseFile.Title = "Browse for msg File";
            if (browseFile.ShowDialog() == DialogResult.Cancel)
                return;

            FileName = browseFile.FileName;
            file = MSGStream.Read(FileName);

            cbList.Items.Clear();
            for (int i = 0; i < file.data.Length; i++)
                cbList.Items.Add(file.data[i].ID.ToString() + " - " + file.data[i].NameID);

            Addfile(FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MSGStream.Write(file, FileName);
            MessageBox.Show("File has been saved!!!");
        }

        private void cbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = file.data[cbList.SelectedIndex].NameID;
            txtID.Text = file.data[cbList.SelectedIndex].ID.ToString();
            cbLine.Items.Clear();
            for (int i = 0; i < file.data[cbList.SelectedIndex].Lines.Length; i++)
                cbLine.Items.Add(i);

            cbLine.SelectedIndex = 0;
            txtText.Text = file.data[cbList.SelectedIndex].Lines[cbLine.SelectedIndex];
        }

        private void cbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtText.Text = file.data[cbList.SelectedIndex].Lines[cbLine.SelectedIndex];
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            file.data[cbList.SelectedIndex].NameID = txtName.Text;
            cbList.Items[cbList.SelectedIndex] = file.data[cbList.SelectedIndex].ID.ToString() + "-" + file.data[cbList.SelectedIndex].NameID;
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            file.data[cbList.SelectedIndex].Lines[cbLine.SelectedIndex] = txtText.Text;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            msgData[] expand = new msgData[file.data.Length + 1];
            Array.Copy(file.data, expand, file.data.Length);
            string nameid = file.data[file.data.Length - 1].NameID;
            int endid = int.Parse(nameid.Substring(nameid.Length - 3, 3));
            expand[expand.Length - 1].ID = file.data.Length;
            expand[expand.Length - 1].Lines = new string[] { "New Entry" };
            expand[expand.Length - 1].NameID = nameid.Substring(0, nameid.Length - 3) + (endid + 1).ToString("000");

            file.data = expand;

            cbList.Items.Clear();
            for (int i = 0; i < file.data.Length; i++)
                cbList.Items.Add(file.data[i].ID.ToString() + "-" + file.data[i].NameID);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            msgData[] reduce = new msgData[file.data.Length - 1];
            Array.Copy(file.data, reduce, file.data.Length - 1);
            file.data = reduce;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            sf.AddRange( new string[] {"","","","","" } );
            if (File.Exists("MSGSetting.txt"))
            {
                StreamReader f = new StreamReader("MSGSetting.txt");
                for (int i = 0; i < 5; i++)
                    sf[i] = f.ReadLine();
                

                f.Close();

            }

            if (File.Exists(sf[0]))
            {
                FileInfo fi = new FileInfo(sf[0]);
                f1.Text = fi.Name;
            }
            else
                f1.Text = "-----";

            if (File.Exists(sf[1]))
            {
                FileInfo fi = new FileInfo(sf[1]);
                f2.Text = fi.Name;
            }
            else
                f2.Text = "-----";

            if (File.Exists(sf[2]))
            {
                FileInfo fi = new FileInfo(sf[2]);
                f3.Text = fi.Name;
            }
            else
                f3.Text = "-----";

            if (File.Exists(sf[3]))
            {
                FileInfo fi = new FileInfo(sf[3]);
                f4.Text = fi.Name;
            }
            else
                f4.Text = "-----";

            if (File.Exists(sf[4]))
            {
                FileInfo fi = new FileInfo(sf[4]);
                f5.Text = fi.Name;
            }
            else
                f5.Text = "-----";

        }

        private void Addfile(string s)
        {

            for (int i = 0; i < 5; i++)
            {
                if (s == sf[i])
                    return;
            }

            sf.Insert(0, s);

            if (sf.Count > 5)
                sf.RemoveAt(5);

            StreamWriter f = new StreamWriter(File.Open("MSGSetting.txt", FileMode.Create));

            for (int i = 0; i < 5; i++)
                f.WriteLine(sf[i]);

            f.Close();

            if (File.Exists(sf[0]))
            {
                FileInfo fi = new FileInfo(sf[0]);
                f1.Text = fi.Name;
            }
            else
                f1.Text = "-----";

            if (File.Exists(sf[1]))
            {
                FileInfo fi = new FileInfo(sf[1]);
                f2.Text = fi.Name;
            }
            else
                f2.Text = "-----";

            if (File.Exists(sf[2]))
            {
                FileInfo fi = new FileInfo(sf[2]);
                f3.Text = fi.Name;
            }
            else
                f3.Text = "-----";

            if (File.Exists(sf[3]))
            {
                FileInfo fi = new FileInfo(sf[3]);
                f4.Text = fi.Name;
            }
            else
                f4.Text = "-----";

            if (File.Exists(sf[4]))
            {
                FileInfo fi = new FileInfo(sf[4]);
                f5.Text = fi.Name;
            }
            else
                f5.Text = "-----";
        }

        private void f1_Click(object sender, EventArgs e)
        {
            file = MSGStream.Read(sf[0]);
            FileName = sf[0];
            cbList.Items.Clear();
            for (int i = 0; i < file.data.Length; i++)
                cbList.Items.Add(file.data[i].ID.ToString() + " - " + file.data[i].NameID);
        }

        private void f2_Click(object sender, EventArgs e)
        {
            file = MSGStream.Read(sf[1]);
            FileName = sf[1];
            cbList.Items.Clear();
            for (int i = 0; i < file.data.Length; i++)
                cbList.Items.Add(file.data[i].ID.ToString() + " - " + file.data[i].NameID);
        }

        private void f3_Click(object sender, EventArgs e)
        {
            file = MSGStream.Read(sf[2]);
            FileName = sf[2];
            cbList.Items.Clear();
            for (int i = 0; i < file.data.Length; i++)
                cbList.Items.Add(file.data[i].ID.ToString() + " - " + file.data[i].NameID);
        }

        private void f4_Click(object sender, EventArgs e)
        {
            file = MSGStream.Read(sf[3]);
            FileName = sf[3];
            cbList.Items.Clear();
            for (int i = 0; i < file.data.Length; i++)
                cbList.Items.Add(file.data[i].ID.ToString() + " - " + file.data[i].NameID);
        }

        private void f5_Click(object sender, EventArgs e)
        {
            file = MSGStream.Read(sf[4]);
            FileName = sf[4];
            cbList.Items.Clear();
            for (int i = 0; i < file.data.Length; i++)
                cbList.Items.Add(file.data[i].ID.ToString() + " - " + file.data[i].NameID);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search ns = new Search(this);
            ns.Show();
        }
    }
}
