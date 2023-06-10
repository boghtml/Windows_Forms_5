using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проект_інд_завдання
{
    public partial class Form_task_2 : Form
    {
        private string writePath = "file.txt";
        public Form_task_2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            listBox2.Visible = false;
            textBox_to_show_result.ReadOnly = true;
            textBox_to_show_result.Text = "0";
        }
        private bool AreTextBoxesFilled()
        {
            return !string.IsNullOrWhiteSpace(textBox1.Text) &&
                   !string.IsNullOrWhiteSpace(textBox2.Text) &&
                   !string.IsNullOrWhiteSpace(textBox3.Text);
        }
        private void Form_task_2_Load(object sender, EventArgs e)
        {
            обчислитиToolStripMenuItem.Enabled = AreTextBoxesFilled();
        }

        private void протабулюватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double a, b, h, x, y;
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                h = Convert.ToDouble(textBox3.Text);
            }
            catch
            {
                MessageBox.Show("Error", "Введіть коректне значення", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listBox1.Items.Clear();
            if (a == 0 && b == 0 || a == b)
            {
                MessageBox.Show("Так як ліва та права межа = 0 або вони однакові", "Результат табуляції одне значення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                y = b * Math.Pow(Math.E, Math.Atan(b));
                listBox2.Items.Add("X" + "\t" + "Y");
                listBox2.Items.Add(a.ToString("00.00") + "\t" + y.ToString("00.0000") + "\r\n");
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    foreach (var item in listBox2.Items)
                    {
                        sw.WriteLine(item.ToString());
                    }
                }
                if (y > 0.1 && y < 0.9) { textBox_to_show_result.Text = "" + Math.Round(y, 4); }
                listBox1.Items.Add("Результат табуляції записаний у файл");
                listBox1.Items.Add("                                    ");
            }
            else
            {
                if (h == 0)
                {
                    MessageBox.Show("Значення кроку = 0 \n нескінечна кількість х та y", "Відомість", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (a > b)
                    {
                        if (h > 0) { MessageBox.Show("Так як ліва межа = " + a + " а права = " + b + "\n то значення кроку некоректне", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        else
                        {
                            int k = 0;
                            double arrage_mas = 0;
                            listBox1.Items.Add("X" + "\t" + "Y");
                            listBox2.Items.Add("X" + "\t" + "Y");
                            for (x = a; x >= b; x += h)
                            {
                                y = x * Math.Pow(Math.E, Math.Atan(x));
                                //series.Points.AddXY(x, y);
                                listBox1.Items.Add(x.ToString("00.00") + "\t" + y.ToString("00.0000") + "\r\n");
                                listBox2.Items.Add(x.ToString("00.00") + "\t" + y.ToString("00.0000") + "\r\n");
                                if (y > 0.1 && y < 0.9) { k++; arrage_mas += y; }
                            }
                            textBox_to_show_result.Text = "" + (Math.Round(arrage_mas / k, 4));
                            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                            {
                                foreach (var item in listBox2.Items)
                                {
                                    sw.WriteLine(item.ToString());
                                }
                            }
                            listBox1.Items.Add("Результат табуляції записаний у файл");
                            listBox1.Items.Add("                                    ");
                        }

                    }
                    if (a < b)
                    {
                        if (h < 0) { MessageBox.Show("Так як ліва межа = " + a + " а права = " + b + "\n то значення кроку некоректне", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        else
                        {
                            int k = 0;
                            double arrage_mas = 0;
                            listBox1.Items.Add("X" + "\t" + "Y");
                            listBox2.Items.Add("X" + "\t" + "Y");
                            for (x = a; x <= b; x += h)
                            {
                                y = x * Math.Pow(Math.E, Math.Atan(x));
                                //series.Points.AddXY(x, y);
                                listBox1.Items.Add(x.ToString("00.00") + "\t" + y.ToString("00.0000") + "\r\n");
                                listBox2.Items.Add(x.ToString("00.00") + "\t" + y.ToString("00.0000") + "\r\n");
                                if (y > 0.1 && y < 0.9) { k++; arrage_mas += y; }
                            }
                            textBox_to_show_result.Text = "" + (Math.Round(arrage_mas / k, 4));
                            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                            {
                                foreach (var item in listBox2.Items)
                                {
                                    sw.WriteLine(item.ToString());
                                }
                            }
                            listBox1.Items.Add("Результат табуляції записаний у файл");
                            listBox1.Items.Add("                                    ");
                        }
                    }
                }
            }
        }

        private void очиститиПолеВведенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            listBox1.Items.Clear();
        }

        private void умоваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_condotion_2 form_Condotion_2 = new Form_condotion_2();
            form_Condotion_2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            обчислитиToolStripMenuItem.Enabled = AreTextBoxesFilled();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            обчислитиToolStripMenuItem.Enabled = AreTextBoxesFilled();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            обчислитиToolStripMenuItem.Enabled = AreTextBoxesFilled();

        }

        private void кінецьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox1.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyChar == '-')
            {
                if (textBox1.Text.IndexOf('-') != -1)
                {
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox2.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyChar == '-')
            {
                if (textBox2.Text.IndexOf('-') != -1)
                {
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox3.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyChar == '-')
            {
                if (textBox3.Text.IndexOf('-') != -1)
                {
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            e.Handled = true;
        }

        private void обчислитиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
