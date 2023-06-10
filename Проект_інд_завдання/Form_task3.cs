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
    public partial class Form_task3 : Form
    {
        private DataTable dataTable;
        private DataSet dataSet;
        private DataTable dataTable2;
        private DataSet dataSet2;
        private const string fileName = "dataBase.xml";
        private const string tableName = "MyBase";
        private int current_index = 0;
        private bool isSaved = false;

        public struct Person
        {
            public string Surname;
            public string Address;
            public string PhoneNumber;
        }
        public Form_task3()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void RemoveColumns()
        {
            if (dataTable.Columns.Count > 1) // Переконайтеся, що в таблиці є щонайменше 2 стовпці
            {
                dataTable.Columns.RemoveAt(2); // Видалення третього стовпця
                dataTable.Columns.RemoveAt(1); // Видалення другого стовпця (після видалення третього стовпця)
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form_task3_Load(object sender, EventArgs e)
        {
            dataTable = new DataTable();
            dataSet = new DataSet();
            dataTable2 = new DataTable();
            dataSet2 = new DataSet();
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;

            if (File.Exists(fileName) == false)
            {
                dataGridView1.DataSource = dataTable;
                dataTable.Columns.Add("Прізвище");
                dataTable.Columns.Add("Адреса");
                dataTable.Columns.Add("Телефон");
                dataSet.Tables.Add(dataTable);
            }
            else
            {
                dataSet.ReadXml(fileName);
                dataGridView1.DataMember = (tableName);
                dataGridView1.DataSource = dataSet;
                ShowStudentsByIndex(current_index);
                AddStudentsToComboBox();
            }
            dataGridView2.DataSource = dataTable2;
            dataTable2.Columns.Add("Прізвище");
            dataTable2.Columns.Add("Адреса");
            dataSet2.Tables.Add(dataTable2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataTable.TableName = "Назва таблиці";
                dataSet.WriteXml(fileName);
                MessageBox.Show("Дані успішно збережено в файлі.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка під час збереження даних: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                dataSet.ReadXml(fileName);
                dataGridView1.DataMember = "Назва таблиці";
                dataGridView1.DataSource = dataSet;
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка під час завантаження даних: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void відToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
        }

        private void записатиУФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            AddStudentsToComboBox();
        }

        private void умоваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Заданий одновимірний з довільною кількістю елементів не меньше 10,\nзначення елементів вводяться користувачем з клавіатури та записуються в файл.\nВиконати опрацювання масиву у відповідності з заданим варіантом завдання.\n\n18 - В\nВідомі прізвища, адреси та телефони групи людей.\nСкласти програму, що виводить на екран прізвища та адреси тих,\nчий номер починається із заданого набору цифр.\nЯкщо даних немає, видати відповідне повідомлення", "Умова", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ShowStudentsByIndex(current_index - 1);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ShowStudentsByIndex(current_index + 1);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Person[] people = new Person[dataGridView1.Rows.Count - 1];
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                people[i] = new Person
                {
                    Surname = dataGridView1.Rows[i].Cells["Прізвище"].Value.ToString(),
                    Address = dataGridView1.Rows[i].Cells["Адреса"].Value.ToString(),
                    PhoneNumber = dataGridView1.Rows[i].Cells["Телефон"].Value.ToString()
                };
            }

            dataGridView2.Visible = true;
            string searchNumber = textBox1.Text;

            DataTable dataTable2 = new DataTable(); // Створюємо таблицю для dataGridView2
            dataTable2.Columns.Add("Прізвище");
            dataTable2.Columns.Add("Адреса");

            foreach (Person person in people)
            {
                string phoneNumber = person.PhoneNumber;
                if (phoneNumber.StartsWith(searchNumber))
                {
                    string surname = person.Surname;
                    string address = person.Address;

                    dataTable2.Rows.Add(surname, address);
                }
            }

            dataGridView2.DataSource = dataTable2;
            if (dataTable2.Rows.Count == 0)
            {
                MessageBox.Show("Немає результатів для відображення.");
            }
        }
        //dataGridView2.Visible = true;
        //string searchNumber = textBox1.Text;

        //DataTable dataTable2 = new DataTable(); // Створюємо таблицю для dataGridView2
        //dataTable2.Columns.Add("Прізвище");
        //dataTable2.Columns.Add("Адреса");

        //foreach (DataGridViewRow row in dataGridView1.Rows)
        //{
        //    string phoneNumber = row.Cells["Телефон"].Value?.ToString();
        //    if (phoneNumber != null && phoneNumber.StartsWith(searchNumber))
        //    {
        //        string surname = row.Cells["Прізвище"].Value.ToString();
        //        string address = row.Cells["Адреса"].Value.ToString();

        //        dataTable2.Rows.Add(surname, address);
        //    }
        //}

        //dataGridView2.DataSource = dataTable2;
        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            MessageBox.Show(dataGridView1.Rows[current_index].Cells[0].Value.ToString() + " запис буде видалено!!!");
            dataGridView1.Rows.RemoveAt(current_index);
            textBox2.Text = string.Empty;
            textBox4.Text = string.Empty;
            comboBox1.Text = string.Empty;
            AddStudentsToComboBox();
            isSaved = false;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            dataTable.TableName = tableName;
            dataSet.WriteXml(fileName);
            comboBox1.Items.Clear();
            AddStudentsToComboBox();
            isSaved = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowStudentsByIndex(comboBox1.SelectedIndex);
        }



        private void ShowStudentsByIndex(int index)
        {
            if (index < 0 || index >= dataGridView1.Rows.Count - 1)
            {
                return;
            }
            current_index = index;
            textBox2.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
        }
        private void AddStudentsToComboBox()
        {
            comboBox1.Items.Clear();
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow && row.Cells[0].Value != null)
                    {
                        comboBox1.Items.Add(row.Cells[0].Value.ToString());
                    }
                }
            }
            catch
            {
                // Обробка помилки, якщо необхідно
            }
        }

        private void аЯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

        }

        private void яАToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Descending);

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (current_index >= 0 && current_index < dataTable.Rows.Count)
            {
                dataTable.Rows[current_index][0] = textBox2.Text;
                isSaved = false;
            }
            //dataGridView1.Rows[current_index].Cells[0].Value = textBox2.Text;
            //isSaved = false;
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (current_index >= 0 && current_index < dataTable.Rows.Count)
            {
                dataTable.Rows[current_index][1] = textBox4.Text;
                isSaved = false;
            }
            //dataGridView1.Rows[current_index].Cells[0].Value = textBox4.Text;
            //isSaved = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSaved)
            {
                DialogResult result = MessageBox.Show("Дані не були збережені. Зберегти дані перед закриттям?", "Підтвердження закриття", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        dataTable.TableName = tableName;
                        dataSet.WriteXml(fileName);
                        MessageBox.Show("Дані успішно збережено в файлі.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка під час збереження даних: " + ex.Message);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}

