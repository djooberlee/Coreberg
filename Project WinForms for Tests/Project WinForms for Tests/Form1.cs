using System;
using System.Windows.Forms;

namespace Project_WinForms_for_Tests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Program.GetOSVersionAndCaption().Key + " " + Program.GetOSVersionAndCaption().Value.Split('.')[0] + "." + Program.GetOSVersionAndCaption().Value.Split('.')[1]);
        }
    }
}