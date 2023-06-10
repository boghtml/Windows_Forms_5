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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Проект_інд_завдання
{
    public partial class Form_task_5 : Form
    {
        private DataTable dataTable_5;
        private DataSet dataSet_5;
        private DataTable dataTable2_5;
        private DataSet dataSet2_5;
        private const string fileName_5 = "Data_Five.xml";
        private const string tableName_5 = "Base_For_Five";
        private int current_index = 0;
        private bool isSaved = false;

        public struct Person
        {
            public string Surname;
            public string Kind_of_sport;
            public string Kil_of_years;
        }
        private bool AreTextBoxesFilled()
        {
            return !string.IsNullOrWhiteSpace(textBox_enter_year.Text);
        }
        private bool AreTextBoxesFilled_block_to_EntN()
        {
            return !string.IsNullOrWhiteSpace(textBox_surname_Nrow.Text) &&
                   !string.IsNullOrWhiteSpace(textBox_kind_of_sport_Nrow.Text) &&
                   !string.IsNullOrWhiteSpace(textBox_kil_year_Nrow.Text);
        }
        private void ShowStudentsByIndex(int index)
        {
            if (index < 0 || index >= dataGridView1.Rows.Count - 1)
            {
                return;
            }
            current_index = index;
            textBox_Surname.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox_from_sport.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textBox_kil_years.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
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

            }
        }

        public Form_task_5()
        {
            InitializeComponent();
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = false;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form_task_5_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            toolStripButton3.Enabled = false;
            dataTable_5 = new DataTable();
            dataSet_5 = new DataSet();
            dataTable2_5 = new DataTable();
            dataSet2_5 = new DataSet();
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;

            if (File.Exists(fileName_5) == false)
            {
                dataGridView1.DataSource = dataTable_5;
                dataTable_5.Columns.Add("Прізвище");
                dataTable_5.Columns.Add("Вид спорту");
                dataTable_5.Columns.Add("Кіл-сть відвідання(у роках)");
                dataSet_5.Tables.Add(dataTable_5);
            }
            else
            {
                dataSet_5.ReadXml(fileName_5);
                dataGridView1.DataMember = (tableName_5);
                dataGridView1.DataSource = dataSet_5;
                ShowStudentsByIndex(current_index);
                AddStudentsToComboBox();
            }
            dataGridView2.DataSource = dataTable2_5;
            dataTable2_5.Columns.Add("Прізвище");
            dataTable2_5.Columns.Add("Вид спорту");
            dataTable2_5.Columns.Add("Кіл-сть відвідання(у роках)");
            dataSet_5.Tables.Add(dataTable2_5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    dataSet_5.ReadXml(fileName_5);
            //    dataGridView1.DataMember = "Назва таблиці";// (tableName_5)
            //    dataGridView1.DataSource = dataSet_5;
            //    button1.Enabled = true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Помилка під час завантаження даних: " + ex.Message);
            //}
            try
            {
                // Очищення DataGridView
                dataGridView1.DataSource = null;

                dataSet_5.ReadXml(fileName_5);
                dataGridView1.DataMember = "Назва таблиці";// (tableName_5)
                dataGridView1.DataSource = dataSet_5;
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
            редагуватиToolStripMenuItem.Enabled = true;
            toolStripButton1.Enabled = true;
            toolStripButton2.Enabled = true;
            toolStripButton4.Enabled = false;
            label11.Visible = false;
            label7.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            textBox_surname_Nrow.Visible = false;
            textBox_kind_of_sport_Nrow.Visible = false;
            textBox_kil_year_Nrow.Visible = false;
            button_to_enter_new_rows.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
        }

        private void записатиУФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            редагуватиToolStripMenuItem.Enabled = false;
            toolStripButton1.Enabled = false;
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = false;
            label11.Visible = true;
            label7.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            textBox_surname_Nrow.Visible = true;
            textBox_kind_of_sport_Nrow.Visible = true;
            textBox_kil_year_Nrow.Visible = true;
            button_to_enter_new_rows.Visible = true;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            AddStudentsToComboBox();
        }

        private void умоваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_condition_5 form_Condition_5 = new Form_condition_5();
            form_Condition_5.Show();
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
                    Kind_of_sport = dataGridView1.Rows[i].Cells["Вид спорту"].Value.ToString(),
                    Kil_of_years = dataGridView1.Rows[i].Cells["Кіл-сть відвідання(у роках)"].Value.ToString()
                };
            }

            dataGridView2.Visible = true;
            string search_years = textBox_enter_year.Text;
            DataTable dataTable2 = new DataTable(); // Створюємо таблицю для dataGridView2
            dataTable2.Columns.Add("Прізвище");
            dataTable2.Columns.Add("Вид спорту");
            dataTable2.Columns.Add("Кіл-сть відвідання(у роках)");
            

            foreach (Person person in people)
            {
                string kil_years = person.Kil_of_years;
                if (Convert.ToInt32(kil_years) >= Convert.ToInt32(search_years))
                {
                    string surname = person.Surname;
                    string kind_of_sport = person.Kind_of_sport;
                    string kil_year = person.Kil_of_years;

                    dataTable2.Rows.Add(surname, kind_of_sport, kil_year);
                }
            }

            dataGridView2.DataSource = dataTable2;
            if (dataTable2.Rows.Count == 0)
            {
                MessageBox.Show("Немає результатів для відображення.");
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView1.Rows[current_index].Cells[0].Value.ToString() + " запис буде видалено!!!");
            dataGridView1.Rows.RemoveAt(current_index);
            textBox_Surname.Text = string.Empty;
            textBox_from_sport.Text = string.Empty;
            textBox_kil_years.Text = string.Empty;
            comboBox1.Text = string.Empty;
            AddStudentsToComboBox();
            isSaved = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripButton4.Enabled = true;
            ShowStudentsByIndex(comboBox1.SelectedIndex);
        }

        private void аЯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void яАToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Descending);
        }

        private void textBox_Surname_KeyUp(object sender, KeyEventArgs e)
        {
            if (current_index >= 0 && current_index < dataTable_5.Rows.Count)
            {
                dataTable_5.Rows[current_index][0] = textBox_Surname.Text;
                isSaved = false;
            }
        }

        private void textBox_from_sport_KeyUp(object sender, KeyEventArgs e)
        {
            if (current_index >= 0 && current_index < dataTable_5.Rows.Count)
            {
                dataTable_5.Rows[current_index][1] = textBox_from_sport.Text;
                isSaved = false;
            }
        }

        private void textBox_kil_years_KeyUp(object sender, KeyEventArgs e)
        {
            if (current_index >= 0 && current_index < dataTable_5.Rows.Count)
            {
                dataTable_5.Rows[current_index][2] = textBox_kil_years.Text;
                isSaved = false;
            }
        }

        private void Form_task_5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSaved)
            {
                DialogResult result = MessageBox.Show("Дані не були збережені. Зберегти дані перед закриттям?", "Підтвердження закриття", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        dataTable_5.TableName = tableName_5;
                        dataSet_5.WriteXml(fileName_5);
                        MessageBox.Show("Дані успішно збережено в файлі.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка під час збереження даних: " + ex.Message);
                    }
                }
            }
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                dataTable_5.TableName = "Назва таблиці";
                dataSet_5.WriteXml(fileName_5);
                comboBox1.Items.Clear();
                AddStudentsToComboBox();
                isSaved = true;
                MessageBox.Show("Дані успішно збережено в файлі.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка під час збереження даних: " + ex.Message);
            }
            
        }

        private void textBox_enter_year_TextChanged(object sender, EventArgs e)
        {
            toolStripButton3.Enabled = AreTextBoxesFilled();
        }

        private void textBox_enter_year_KeyPress(object sender, KeyPressEventArgs e)
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

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox_surname_Nrow_TextChanged(object sender, EventArgs e)
        {
            button_to_enter_new_rows.Enabled = AreTextBoxesFilled_block_to_EntN();
        }

        private void textBox_kind_of_sport_Nrow_TextChanged(object sender, EventArgs e)
        {
            button_to_enter_new_rows.Enabled = AreTextBoxesFilled_block_to_EntN();
        }

        private void textBox_kil_year_Nrow_TextChanged(object sender, EventArgs e)
        {
            button_to_enter_new_rows.Enabled = AreTextBoxesFilled_block_to_EntN();
        }
        List<Person> students = new List<Person>();
        private void button_to_enter_new_rows_Click(object sender, EventArgs e)
        {
            string surname = textBox_surname_Nrow.Text;
            string kindOfSport = textBox_kind_of_sport_Nrow.Text;
            string kilYears = textBox_kil_year_Nrow.Text;

            Person newStudent = new Person()
            {
                Surname = surname,
                Kind_of_sport = kindOfSport,
                Kil_of_years = kilYears
            };

            students.Add(newStudent);
            dataGridView1.Rows.Add(surname, kindOfSport, kilYears);

            textBox_surname_Nrow.Clear();
            textBox_kind_of_sport_Nrow.Clear();
            textBox_kil_year_Nrow.Clear();
        }

        private void textBox_kil_year_Nrow_KeyPress(object sender, KeyPressEventArgs e)
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
