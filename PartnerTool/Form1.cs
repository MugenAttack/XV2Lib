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

namespace PartnerTool
{
    struct Partner_Data
    {
        int id;
        public List<OCC_ColorParts> color;
        public List<OCS_Skill> type0;
        public List<OCS_Skill> type1;
        public List<OCS_Skill> type2;
        public List<OCS_Skill> type3;
        public List<OCT_Talisman> talisman;

    }
    public partial class Form1 : Form
    {
        Settings s = new Settings();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            s.Read();

        }
    }
}
