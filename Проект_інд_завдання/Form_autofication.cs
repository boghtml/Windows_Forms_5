using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Проект_інд_завдання
{
    public partial class Form_autofication : Form
    {
        private string generatedPassword;
        private int length = 8;
        private void SendEmail(string recipient, string password)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("boghtml@gmail.com");
                mail.To.Add(recipient);
                mail.Subject = "Ваш пароль";
                mail.Body = $"Ваш пароль для підтвердження: {password}";

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("boghtml@gmail.com", "byghlanoulnjkwdo");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка надсилання електронного листа: " + ex.Message.ToString());
            }
        }
        private string GeneratePassword()
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder passwordBuilder = new StringBuilder();

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);

                for (int i = 0; i < length; i++)
                {
                    int randomIndex = randomBytes[i] % validChars.Length;
                    char randomChar = validChars[randomIndex];
                    passwordBuilder.Append(randomChar);
                }
            }
            return passwordBuilder.ToString();
        }
        public Form_autofication()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void Form_autofication_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            button2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            button2.Enabled = true;

            generatedPassword = GeneratePassword();

            SendEmail(textBox_to_email.Text, generatedPassword);

            MessageBox.Show("Пароль надіслано на вашу електронну адресу.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == generatedPassword)
            {
                MessageBox.Show("Пароль підтверджено. Вхід дозволено.");
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }
            else
            {
                // Пароль не співпадає, показуємо повідомлення про помилку
                MessageBox.Show("Неправильний пароль. Вхід заборонено.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
