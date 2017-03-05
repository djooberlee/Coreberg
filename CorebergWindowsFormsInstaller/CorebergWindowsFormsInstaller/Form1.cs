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
                        button1.Text = "Дождитесь завершения установки";
                        string company = comboBox1.SelectedItem.ToString();
                        int tag = Convert.ToInt32(textBox1.Text);

                        progressBar1.PerformStep();
                        Application.DoEvents();
                        if (checkBox2.Checked)
                        {
                            if (InstalledSoftware.NameContain("Teamviewer"))
                            {
                                label1.Text = "20% Удаляем Teamviewer";
                                Application.DoEvents();
                                TeamViewer.Uninstall();
                                progressBar1.PerformStep();
                                

                                label1.Text = "40% Устанавливаем Teamviewer";
                                progressBar1.PerformStep(); //этот метод не отрабатывает тут, прогрессбар не меняется . Смотрои комментарий ниже                                
                                Application.DoEvents();

                                if (checkBox3.Checked)
                                {
                                    TeamViewer.Install(company, tag, true);
                                }
                                else TeamViewer.Install(company, tag, false);
                            }
                            else
                            {
                                progressBar1.PerformStep();
                                label1.Text = "40% Устанавливаем Teamviewer";
                                Application.DoEvents();
                                if (checkBox3.Checked)
                                {
                                    TeamViewer.Install(company, tag, true);
                                }
                                else TeamViewer.Install(company, tag, false);
                            }
                        }
                        progressBar1.PerformStep();   // зато тут он отрабатывает дважды, прогресбар увеличивается до 60%
                        Application.DoEvents();

                        if (checkBox1.Checked)
                        {
                            label1.Text = "60% Устанавливаем OCS";
                            Application.DoEvents();
                            OCS.Install(company, tag);
                        }
                        progressBar1.PerformStep();
                        Application.DoEvents();

                        if (checkBox4.Checked)
                        {
                            label1.Text = "80% Устанавливаем DesktopInfo";
                            Application.DoEvents();
                            DesktopInfo.Install();
                        }
                        progressBar1.PerformStep();
                        label1.Text = "100% Устанавка завершена";
                        button1.Text = "НАЧАТЬ УСТАНОВКУ";
                        Application.DoEvents();
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
                Application.DoEvents();
                OCS.Uninstall();
                progressBar1.Value = 100;
                Application.DoEvents();
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
                Application.DoEvents();
                TeamViewer.Uninstall();
                progressBar1.Value = 100;
                Application.DoEvents();
                MessageBox.Show("TeamViewer удален");
                progressBar1.Value = 0;
                label1.Text = "Для запуска нажмите \"НАЧАТЬ УСТАНОВКУ\"";
                Application.DoEvents();
            }
            else MessageBox.Show("TeamViewer не установлен");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\DI\\"))
            {
                DesktopInfo.Uninstall();
                MessageBox.Show("DesktopInfo удален");
            }
            else MessageBox.Show("DesktopInfo не установлен");
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
    }
}