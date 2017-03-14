using System;
using System.IO;
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
            string[] tvall = File.ReadAllLines("c:\\tvall.csv");
            string[] tv12 = File.ReadAllLines("c:\\tv12.csv");
            string[] tv9 = new string[0];
            bool flag;
            foreach (string str_in_tvall in tvall)
            {
                flag = true;
                foreach (string str_in_tv12 in tv12)
                {
                    if (str_in_tvall.Split(';')[0] == str_in_tv12.Split(';')[0]) flag = false;                    
                }
                if(flag)
                {
                    Array.Resize(ref tv9, tv9.Length + 1);
                    tv9[tv9.Length - 1] = str_in_tvall;
                }
            }
            File.WriteAllLines("c:\\tv9.csv",tv9);
        }
    }
}