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
    public partial class Form_condition_3 : Form
    {
        public Form_condition_3()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_task3 form_Task3 = new Form_task3();
            form_Task3.Show();
        }

        private void Form_condition_3_Load(object sender, EventArgs e)
        {

        }
    }
}
