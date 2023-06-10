using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проект_інд_завдання
{
    public partial class Form_task_4 : Form
    {
        private bool AreTextBoxesFilled()
        {
            return !string.IsNullOrWhiteSpace(textBox_to_kil_rows.Text) &&
                   !string.IsNullOrWhiteSpace(textBox_to_kil_colums.Text) &&
                   !string.IsNullOrWhiteSpace(textBox_to_left_value.Text) &&
                   !string.IsNullOrWhiteSpace(textBox_to_right_value.Text);
        }
        private void GenerateArray(int rows, int columns, int minValue, int maxValue)
        {
            textBox_show_kil.Enabled = true;
            textBox_show_suma.Enabled = true;
            int suma_all_positive_value = 0;
            int kil_positive_kil_value = 0;
            int[,] array = new int[rows, columns];
            Random random = new Random();

            // Заповнюємо масив випадковими значеннями, обмеженими межами генерації
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = random.Next(minValue, maxValue + 1);
                    if (array[i, j] > 0)
                    {
                        suma_all_positive_value += array[i, j];
                        kil_positive_kil_value += 1;
                    }
                }
            }
            listBox1.Items.Clear();

            // Виводимо масив до listBox1
            for (int i = 0; i < rows; i++)
            {
                string rowString = "";
                for (int j = 0; j < columns; j++)
                {
                    rowString += array[i, j] + "  ";
                }
                listBox1.Items.Add(rowString);
            }
            textBox_show_kil.Text = "" + kil_positive_kil_value;
            textBox_show_suma.Text = "" + suma_all_positive_value;
        }
        public Form_task_4()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form_task_4_Load(object sender, EventArgs e)
        {

            обчислитиToolStripMenuItem.Enabled = false;
            textBox_show_kil.Enabled = false;
            textBox_show_suma.Enabled = false;
            textBox_show_kil.ReadOnly = true;
            textBox_show_suma.ReadOnly = true;
        }

        private void textBox_to_kil_rows_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox_to_kil_colums_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox_to_left_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == '-')
            {
                if (textBox_to_left_value.Text.IndexOf('-') != -1)
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

        private void textBox_to_right_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == '-')
            {
                if (textBox_to_left_value.Text.IndexOf('-') != -1)
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

            int kil_rows, kil_colums, left_line_generate, rigth_line_generate;
            try
            {
                kil_rows = Convert.ToInt32(textBox_to_kil_rows.Text);
                kil_colums = Convert.ToInt32(textBox_to_kil_colums.Text);
                left_line_generate = Convert.ToInt32(textBox_to_left_value.Text);
                rigth_line_generate = Convert.ToInt32(textBox_to_right_value.Text);
            }
            catch
            {
                MessageBox.Show("Введіть коректні значення в textBox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (kil_rows != 0 && kil_colums != 0)
            {
                GenerateArray(kil_rows, kil_colums, left_line_generate, rigth_line_generate);
            }
            else
                MessageBox.Show("Межі = 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void textBox_to_kil_rows_TextChanged(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            обчислитиToolStripMenuItem.Enabled = AreTextBoxesFilled();

        }

        private void textBox_to_kil_colums_TextChanged(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            обчислитиToolStripMenuItem.Enabled = AreTextBoxesFilled();

        }

        private void textBox_to_left_value_TextChanged(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            обчислитиToolStripMenuItem.Enabled = AreTextBoxesFilled();

        }

        private void textBox_to_right_value_TextChanged(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            обчислитиToolStripMenuItem.Enabled = AreTextBoxesFilled();

        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void умоваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form__condition_4 form__Condition_4 = new Form__condition_4();
            form__Condition_4.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
