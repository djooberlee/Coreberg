using System;
using System.IO;
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
            label1.Text = "Для запуска нажмите \"НАЧАТЬ УСТАНОВКУ\"";
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
                        button1.Text = "Подождите завершения установки";
                        string company = comboBox1.SelectedItem.ToString();
                        int tag = Convert.ToInt32(textBox1.Text);

                        progressBar1.Value = 5;
                        if (checkBox2.Checked)
                        {
                            if (InstalledSoftware.NameContain("Teamviewer"))
                            {
                                label1.Text = "Удаляем Teamviewer";
                                progressBar1.Value = 10;
                                TeamViewer.Uninstall();
                                progressBar1.Value = 30;
                                label1.Text = "Устанавливаем Teamviewer";
                                if (checkBox3.Checked)
                                {
                                    TeamViewer.Install(company, tag, true);
                                }
                                else TeamViewer.Install(company, tag, false);
                            }
                            else
                            {
                                progressBar1.Value = 30;
                                label1.Text = "Устанавливаем Teamviewer";
                                if (checkBox3.Checked)
                                {
                                    TeamViewer.Install(company, tag, true);
                                }
                                else TeamViewer.Install(company, tag, false);
                            }
                        }
                        progressBar1.Value = 60;

                        if (checkBox1.Checked)
                        {
                            label1.Text = "Устанавливаем OCS";
                            OCS.Install(company, tag);
                        }
                        progressBar1.Value = 90;

                        if (checkBox4.Checked)
                        {
                            label1.Text = "Устанавливаем DesktopInfo";
                            DesktopInfo.Install();
                        }
                        progressBar1.Value = 95;

                        label1.Text = "Устанавка завершена";
                        progressBar1.Value = 100;
                        button1.Text = "НАЧАТЬ УСТАНОВКУ";
                    }

                }
                else
                {
                    MessageBox.Show("Не выбран клиент");
                }
            }
            else MessageBox.Show("Не верный формат тега");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                checkBox3.Enabled = false;
                checkBox3.Checked = false;
            }
            if (checkBox2.Checked)
            {
                checkBox3.Enabled = true;
            }
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
                TeamViewer.Uninstall();
                progressBar1.Value = 100;
                MessageBox.Show("TeamViewer удален");
                progressBar1.Value = 0;
                label1.Text = "Для запуска нажмите \"НАЧАТЬ УСТАНОВКУ\"";
            }
            else MessageBox.Show("TeamViewer не установлен");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + "\\DI\\"))
            {
                DesktopInfo.Uninstall();
                MessageBox.Show("DesktopInfo удален");
            }
            else MessageBox.Show("DesktopInfo не установлен");
        }
    }
}
