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
    public partial class Form_task_1_menu : Form
    {
        public Form_task_1_menu()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form_task_1_menu_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;
            toolStripButton1.Enabled = false;
            radioButton_to_angle.Checked = false;
            radioButton_to_solve_S.Checked = false;
            radioButto_to_solve_c.Checked = false;
        }

        private void radioButton_to_solve_S_CheckedChanged(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = true;
        }

        private void radioButto_to_solve_c_CheckedChanged(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = true;
        }

        private void radioButton_to_angle_CheckedChanged(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (radioButton_to_solve_S.Checked || radioButto_to_solve_c.Checked || radioButton_to_angle.Checked)
            {
                this.Hide();
                if (radioButton_to_solve_S.Checked)
                {
                    string labelValue = "Площа трикутника";
                    Form_task_1_base_solve form_solve = new Form_task_1_base_solve(labelValue);
                    form_solve.Show();
                }
                if (radioButto_to_solve_c.Checked)
                {
                    string labelValue = "Дожина сторони с";
                    Form_task_1_base_solve form_solve = new Form_task_1_base_solve(labelValue);
                    form_solve.Show();
                }
                if (radioButton_to_angle.Checked)
                {
                    string labelValue = "Кут а";
                    Form_task_1_base_solve form_solve = new Form_task_1_base_solve(labelValue);
                    form_solve.Show();
                }
            }
            else
                MessageBox.Show("Оберіть пункт меню", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form_condition_to_first form_cond = new Form_condition_to_first();
            form_cond.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
