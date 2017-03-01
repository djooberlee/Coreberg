using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorebergWindowsFormsInstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(Clients.GetList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((checkBox1.Checked) && (checkBox2.Checked) && (checkBox3.Checked) && (checkBox4.Checked))
            {
                if (InstalledSoftware.NameContain("Teamviewer"))
                {
                    TeamViewer.Uninstall();
                    TeamViewer.Install(comboBox1.SelectedText, Convert.ToInt32(textBox1.Text));
                }
                else
                {
                    TeamViewer.Install(comboBox1.SelectedText, Convert.ToInt32(textBox1.Text));
                }
                DesktopInfo.Install();
                OCS.Install(comboBox1.SelectedText, Convert.ToInt32(textBox1.Text));
            }
        }
    }
}
