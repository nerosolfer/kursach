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
using static фяцычувксаепмир.Form1._ConnectDB;
using static фяцычувксаепмир.DB;

namespace фяцычувксаепмир
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_19_21;database=is_1_19_st21_KURS;password=47173474;";
            string sql = "SELECT * FROM `PW` WHERE `login` = @un and  `passw`= @up";

            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@un", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@up", MySqlDbType.VarChar, 25);

            command.Parameters["@un"].Value = textBox1.Text;
            command.Parameters["@up"].Value = textBox2.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Успешно!");
                Hide();
                Form1 f1 = new Form1();
                f1.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Вы ввели неверный логин или пароль");
            }

            conn.Close();

        }
    }
}
