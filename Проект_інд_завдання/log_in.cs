using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Проект_інд_завдання
{
    public partial class log_in : Form
    {
        DataBase dataBase = new DataBase();
        public log_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sign_up firm_sign = new sign_up();
            firm_sign.Show();
            this.Hide();
        }

        private void log_in_Load(object sender, EventArgs e)
        {
            textBox_ente_password.PasswordChar = '*';
            pictureBox3.Visible = false;
            textBox_enter_log.MaxLength = 50;
            textBox_ente_password.MaxLength = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_enter_log.Text;
            var passUser = textBox_ente_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"SELECT id_user, login_user, password_user FROM register WHERE login_user = '{loginUser}' AND password_user = '{passUser}'"; SqlCommand comand = new SqlCommand(queryString, dataBase.getConnection());

            adapter.SelectCommand = comand;
            adapter.Fill(table);

            if(table.Rows.Count == 1)
            {
                MessageBox.Show("Ви успішно ввійшли!", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string labelValue = loginUser;
                Form1 form1 = new Form1(labelValue);
                this.Hide();
                form1.Show();
                //this.Show();
            }
            else
                MessageBox.Show("Такого акаунта не існує!!!", "Акаунта не існує!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox_enter_log.Text = "";
            textBox_ente_password.Text = "";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox_ente_password.UseSystemPasswordChar = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox_ente_password.UseSystemPasswordChar = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
        }
    }
}
