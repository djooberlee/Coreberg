using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            string company = comboBox1.SelectedItem.ToString();
            int tag = Convert.ToInt32(textBox1.Text);
            int i = 0;
            for (; i < 5; i++){ progressBar1.Value = i; }

            if (InstalledSoftware.NameContain("Teamviewer"))
            {
                label1.Text = "Удаляем Teamviewer";
                for (i = 5; i < 10; i++) { progressBar1.Value = i; }
                TeamViewer.Uninstall();
                for (i = 10; i < 30; i++) { progressBar1.Value = i; }
                label1.Text = "Устанавливаем Teamviewer";
                TeamViewer.Install(company, tag);
            }
            else
            {
                for (i = 5; i < 30; i++){ progressBar1.Value = i; }
                label1.Text = "Устанавливаем Teamviewer";
                TeamViewer.Install(company, tag);
            }
            for (i = 30; i < 60; i++) { progressBar1.Value = i; }
            label1.Text = "Устанавливаем OCS";
            OCS.Install(company, tag);
            for (i = 60; i < 90; i++) { progressBar1.Value = i; }

            label1.Text = "Устанавливаем DesktopInfo";
            
            DesktopInfo.Install();
            for (i = 90; i < 101; i++) { progressBar1.Value = i; }
            label1.Text = "Устанавка завершена";


        }
    }
}
