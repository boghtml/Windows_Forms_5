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
    public partial class Form1 : Form
    {
        public Form1(string labelText)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            string temp_text = labelText;
            label_for_naame.Text = temp_text;
        }
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void label_for_name_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_task_1_menu tat_menu = new Form_task_1_menu();
            tat_menu.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_task_2 task2 = new Form_task_2();
            task2.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_task3 task3 = new Form_task3();
            task3.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_task_4 task4 = new Form_task_4();
            task4.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_task_5 task5 = new Form_task_5();
            task5.Show();
        }
    }
}
