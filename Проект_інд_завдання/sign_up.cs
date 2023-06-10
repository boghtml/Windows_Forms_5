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
    public partial class sign_up : Form
    {
        DataBase dataBase = new DataBase();
        public sign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void sign_up_Load(object sender, EventArgs e)
        {
            textBox_ente_password.PasswordChar = '*';
            pictureBox3.Visible = false;
            textBox_enter_log.MaxLength = 50;
            textBox_ente_password.MaxLength = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkuser())
            {
                return;
            }
            var login = textBox_enter_log.Text;
            var password = textBox_ente_password.Text;

            string queryString = $"insert into register(login_user, password_user) values('{login}','{password}')"; SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Акант успішно створений!", "Успіх");
                string labelValue = login;
                Form1 form1 = new Form1(labelValue);
                Form_autofication form_Autofication = new Form_autofication();
                form_Autofication.Show();
            }
            else
            {
                MessageBox.Show("Аккаунт не створений!");
            }
            dataBase.closeConnection();
        }
        private Boolean checkuser()
        {
            var loginUser = textBox_enter_log.Text;
            var passUser = textBox_ente_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Користувач вже є!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox_enter_log.Text = "";
            textBox_ente_password.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox_ente_password.UseSystemPasswordChar = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox_ente_password.UseSystemPasswordChar = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            log_in firm_login = new log_in();
            firm_login.Show();
            this.Hide();
        }
    }
}
