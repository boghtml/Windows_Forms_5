using System;
using System.Windows.Forms;

namespace Проект_інд_завдання
{
    public partial class Form_task_1_base_solve : Form
    {
        private int kil_number_after_number = 4;
        public Form_task_1_base_solve()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private bool AreTextBoxesFilled()
        {
            return !string.IsNullOrWhiteSpace(textBox_to_enter_a.Text) &&
                   !string.IsNullOrWhiteSpace(textBox_to_enter_b.Text) &&
                   !string.IsNullOrWhiteSpace(textBox_to_enter_angle.Text);
        }
        public Form_task_1_base_solve(string labelText)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            label_to_show_operation.Text = labelText;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                kil_number_after_number = Convert.ToInt32(textBox_to_kil_after_number.Text);
            }
            catch
            {
                MessageBox.Show("Введіть значення про кількість знаків5", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double a, b, angle, result;
            try
            {
                a = Convert.ToDouble(textBox_to_enter_a.Text);
                b = Convert.ToDouble(textBox_to_enter_b.Text);
                angle = Convert.ToDouble(textBox_to_enter_angle.Text);
            }
            catch
            {
                MessageBox.Show("Введіть коректні значення в textBox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (kil_number_after_number < 11)
            {
                if (a != 0 && b != 0)
                {
                    if (angle > 0 && angle < 180)
                    {
                        textBox_to_result.Enabled = true;
                        angle = angle * Math.PI / 180.0;
                        if (label_to_show_operation.Text == "Площа трикутника")
                        {
                            result = 0.5 * a * b * Math.Sin(angle);
                            textBox_to_result.Text = "" + Math.Round(result, kil_number_after_number);
                        }
                        if (label_to_show_operation.Text == "Дожина сторони с")
                        {
                            double Part_result = a * a + b * b - 2 * a * b * Math.Cos(angle);
                            if (Part_result >= 0)
                            {
                                result = Math.Sqrt(Part_result);
                                textBox_to_result.Text = "" + Math.Round(result, kil_number_after_number);
                            }
                            else
                                MessageBox.Show("Корінь з від'ємного числа", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (label_to_show_operation.Text == "Кут а")
                        {
                            double Part_result = a * a + b * b - 2 * a * b * Math.Cos(angle);
                            if (Part_result > 0)
                            {
                                result = Math.Sqrt(Part_result);
                                if (a + b <= result || a + result <= b || b + result <= a)
                                {
                                    MessageBox.Show("Такого трикутника не існує\nзі сторонами:" + a + " " + b + " " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                else
                                {
                                    double Part_result2 = (a / result) * Math.Sin(angle);
                                    if (Part_result2 >= -1 && Part_result2 <= 1)
                                    {
                                        double true_result = Math.Asin(Part_result2);
                                        textBox_to_result.Text = "" + Math.Round(true_result, kil_number_after_number);
                                    }
                                    else
                                        MessageBox.Show("х - в arcsin існує від [-1;1]", "[Error]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                                MessageBox.Show("Корінь з від'ємного числа або корінь == 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (angle == 180)
                        MessageBox.Show("Це вже пряма, не трикутник", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Розгорнутий трикутник\nМожливо ви мали на увазі " + (360 - angle), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Сторони = 0, S = 0 \nЦе вже не трикутник ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_to_result.Text = "0";
                }
            }
            else
                MessageBox.Show("Значення похибки за велике", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_task_1_menu form_task_menu = new Form_task_1_menu();
            form_task_menu.Show();
        }

        private void textBox_to_enter_a_TextChanged(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = AreTextBoxesFilled();

        }

        private void textBox_to_enter_a_KeyPress(object sender, KeyPressEventArgs e)
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
                if (textBox_to_enter_a.Text.IndexOf(',') != -1)
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

        private void textBox_to_enter_b_KeyPress(object sender, KeyPressEventArgs e)
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
                if (textBox_to_enter_b.Text.IndexOf(',') != -1)
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

        private void textBox_to_enter_angle_KeyPress(object sender, KeyPressEventArgs e)
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
                if (textBox_to_enter_angle.Text.IndexOf(',') != -1)
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

        private void Form_task_1_base_solve_Load(object sender, EventArgs e)
        {
            textBox_to_kil_after_number.Text = "" + kil_number_after_number;
            StartPosition = FormStartPosition.CenterScreen;
            textBox_to_result.ReadOnly = true;
            textBox_to_result.Enabled = false;
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(textBox_to_enter_angle, "Значення кута в градусах");
            toolStripButton1.Enabled = AreTextBoxesFilled();

        }

        private void textBox_to_enter_b_TextChanged(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = AreTextBoxesFilled();
        }

        private void textBox_to_enter_angle_TextChanged(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = AreTextBoxesFilled();
        }

        private void textBox_to_kil_after_number_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_to_kil_after_number_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
