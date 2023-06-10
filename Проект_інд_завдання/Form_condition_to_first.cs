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
    public partial class Form_condition_to_first : Form
    {
        public Form_condition_to_first()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Form_condition_to_first_Load(object sender, EventArgs e)
        {

        }
    }
}
