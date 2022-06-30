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

            string fio = textBox1.Text;
            string pol1 = comboBox1.Text;
            string snils1 = textBox2.Text;
            string polis1 = textBox3.Text;
            string data_rozhd1 = dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss");
            string adres1 = textBox8.Text;
            string zanyatost1 = comboBox2.Text;
            string tsel1 = comboBox3.Text;
            string rezult1 = textBox4.Text;
            string diagnoz1 = textBox5.Text;
            string data_smert1 = dateTimePicker2.Value.ToString("yyyy-MM-dd hh:mm:ss");
            int id_sotr1 = Convert.ToInt32(textBox6.Text);


            string sql = $"INSERT INTO Pacient ( FIO, pol, snils, polis, data_rozhd, adres, zanyatost, tsel, rezult, diagnoz, data_smert, id_sotr) " +
            $"VALUES ('{fio}' ,'{pol1}' ,'{snils1}' ,'{polis1}' ,'{data_rozhd1}' ,'{adres1}' ,'{zanyatost1}' ,'{tsel1}' ,'{rezult1}' ,'{diagnoz1}' ,'{data_smert1}' ,'{id_sotr1}');";
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
