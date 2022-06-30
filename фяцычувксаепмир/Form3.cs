using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace фяцычувксаепмир
{
    public partial class Form3 : Form
    {
       
        public Form3()
        {
            InitializeComponent();
        }
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_19_21;database=is_1_19_st21_KURS;password=47173474;";
            MySqlConnection conn = new MySqlConnection(connStr);

            /* string sql = $"INSERT INTO Pacient ( FIO, pol, snils, polis, data_rozhd, adres, zanyatost, tsel, rezult, diagnoz, data_smert, id_sotr) " +
                $"VALUES ( {textBox1.Text} , {comboBox1.SelectedItem}, {textBox2.Text}, {textBox3.Text}, {dateTimePicker1.Value},  {textBox8.Text}, {comboBox2.SelectedItem}, {comboBox3.SelectedItem},  {textBox4.Text},  {textBox5.Text}, {dateTimePicker2.Value}, {textBox6.Text});";
             try
             {
                 conn.Open();
                 MySqlCommand cmd = new MySqlCommand(sql, conn);
                 cmd.ExecuteNonQuery();
                 MessageBox.Show("Запись добавлена!");
             }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }
             finally
             {
                 conn.Close();
             }*/
            try
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO Pacient VALUES(@FIO, @pol, @snils, @polis, @data_rozhd, @adres, @zanyatost, @tsel, @rezult, @diagnoz, @data_smert, @id_sotr)", conn);
                command.Parameters.AddWithValue("@FIO", textBox1.Text);
                command.Parameters.AddWithValue("@pol", comboBox1.SelectedItem);
                command.Parameters.AddWithValue("@snils", textBox2.Text);
                command.Parameters.AddWithValue("@polis", textBox3.Text);
                command.Parameters.AddWithValue("@data_rozhd", dateTimePicker1.Value);
                command.Parameters.AddWithValue("@adres", textBox8.Text);
                command.Parameters.AddWithValue("@zanyatost", comboBox2.SelectedItem);
                command.Parameters.AddWithValue("@tsel", comboBox3.SelectedItem);
                command.Parameters.AddWithValue("@rezult", textBox4.Text);
                command.Parameters.AddWithValue("@diagnoz", textBox5.Text);
                command.Parameters.AddWithValue("@data_smert", dateTimePicker2.Value);
                command.Parameters.AddWithValue("@id_sotr", textBox6.Text);
                command.Connection.Open();
                command.ExecuteNonQuery();

                MessageBox.Show("Сотрудник добавлен", "Все прошло успешно!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
