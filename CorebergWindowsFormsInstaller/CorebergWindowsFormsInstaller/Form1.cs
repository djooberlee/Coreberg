using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CorebergWindowsFormsInstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(Clients.GetList);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            label1.Text = "Для запуска нажмите \"НАЧАТЬ УСТАНОВКУ\"";
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) > 100001 && Convert.ToInt32(textBox1.Text) < 999999)
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    if (!(checkBox1.Checked) && (!checkBox2.Checked) && (!checkBox4.Checked))
                    {
                        MessageBox.Show("Выберете компоненты для установки");
                    }
                    else
                    {
                        comboBox1.Enabled = false;
                        comboBox2.Enabled = false;
                        checkBox1.Enabled = false;
                        checkBox2.Enabled = false;
                        checkBox3.Enabled = false;
                        checkBox4.Enabled = false;
                        textBox1.Enabled = false;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;

                        progressBar1.Value = 20;

                        button1.Text = "Дождитесь завершения установки";

                        string company = comboBox1.SelectedItem.ToString();
                        int tag = Convert.ToInt32(textBox1.Text);

                        if (checkBox2.Checked)
                        {
                            if (InstalledSoftware.NameContain("Teamviewer"))
                            {
                                label1.Text = "Удаляем Teamviewer";

                                TeamViewer.Uninstall(Convert.ToInt32(comboBox2.SelectedItem));

                                progressBar1.Value = 40;

                                label1.Text = "Устанавливаем Teamviewer";

                                if (checkBox3.Checked)
                                {
                                    TeamViewer.Install(company, tag, Convert.ToInt32(comboBox2.SelectedItem), true);
                                }
                                else TeamViewer.Install(company, tag, Convert.ToInt32(comboBox2.SelectedItem), false);
                            }
                            else
                            {
                                progressBar1.Value = 40;

                                label1.Text = "Устанавливаем Teamviewer";

                                if (checkBox3.Checked)
                                {
                                    TeamViewer.Install(company, tag, Convert.ToInt32(comboBox2.SelectedItem), true);
                                }
                                else TeamViewer.Install(company, tag, Convert.ToInt32(comboBox2.SelectedItem), false);
                            }
                        }
                        progressBar1.Value = 60;

                        if (checkBox1.Checked)
                        {
                            label1.Text = "Устанавливаем OCS";

                            OCS.Install(company, tag);
                        }
                        progressBar1.Value = 80;

                        if (checkBox4.Checked)
                        {
                            label1.Text = "Устанавливаем DesktopInfo";

                            DesktopInfo.Install();
                        }
                        progressBar1.Value = 100;

                        label1.Text = "Устанавка завершена";
                        button1.Text = "НАЧАТЬ УСТАНОВКУ";
                        comboBox1.Enabled = true;
                        checkBox1.Enabled = true;
                        checkBox2.Enabled = true;
                        if (checkBox2.Checked)
                        {
                            comboBox2.Enabled = true;
                            checkBox3.Enabled = true;
                        }
                        checkBox4.Enabled = true;
                        textBox1.Enabled = true;
                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Не выбран клиент");
                }
            }
            else MessageBox.Show("Не верный формат тега");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (InstalledSoftware.NameContain("OCS Inventory"))
            {
                label1.Text = "Удаляем OCS Inventory";
                progressBar1.Value = 50;

                OCS.Uninstall();
                progressBar1.Value = 100;

                MessageBox.Show("OCS Inventory удален");
                progressBar1.Value = 0;
                label1.Text = "Для запуска нажмите \"НАЧАТЬ УСТАНОВКУ\"";
            }
            else MessageBox.Show("OCS Inventory не установлен");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (InstalledSoftware.NameContain("Teamviewer"))
            {
                label1.Text = "Удаляем Teamviewer";
                progressBar1.Value = 50;

                TeamViewer.Uninstall(Convert.ToInt32(comboBox2.SelectedItem));
                progressBar1.Value = 100;

                MessageBox.Show("TeamViewer удален");
                progressBar1.Value = 0;
                label1.Text = "Для запуска нажмите \"НАЧАТЬ УСТАНОВКУ\"";
            }
            else MessageBox.Show("TeamViewer не установлен");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\DI\\"))
            {
                label1.Text = "Удаляем Desktopinfo";
                progressBar1.Value = 50;

                DesktopInfo.Uninstall();
                progressBar1.Value = 100;

                MessageBox.Show("DesktopInfo удален");
                progressBar1.Value = 0;
                label1.Text = "Для запуска нажмите \"НАЧАТЬ УСТАНОВКУ\"";
            }
            else MessageBox.Show("DesktopInfo не установлен");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                comboBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox3.Checked = false;
            }
            if (checkBox2.Checked)
            {
                comboBox2.Enabled = true;
                checkBox3.Enabled = true;
            }
        }
    }
}