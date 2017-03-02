using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

            progressBar1.Value = 10;
            if (InstalledSoftware.NameContain("Teamviewer"))
            {               
                TeamViewer.Uninstall();
                progressBar1.Value = 25;
                TeamViewer.Install(comboBox1.SelectedItem.ToString(), Convert.ToInt32(textBox1.Text));
                progressBar1.Value = 50;
            }
            else
            {
                TeamViewer.Install(comboBox1.SelectedItem.ToString(), Convert.ToInt32(textBox1.Text));
                progressBar1.Value = 45;
            }
            
            
            OCS.Install(comboBox1.SelectedItem.ToString(), Convert.ToInt32(textBox1.Text));
            progressBar1.Value = 80;
            DesktopInfo.Install();
            progressBar1.Value = 90;
            
            progressBar1.Value = 100;
            MessageBox.Show("установка завершена");

            //if ((checkBox1.Checked) && (checkBox2.Checked) && (checkBox3.Checked) && (checkBox4.Checked)){}
        }
    }
}
