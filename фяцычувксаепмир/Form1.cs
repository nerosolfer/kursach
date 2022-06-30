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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class _ConnectDB
        {
            // поля для значений
            public string conn;
            public string Host;
            public string Port;
            public string User;
            public string Database;
            public string Password;

            //инициализация
            public string Initialization()
            {
                //присвоение значений
                Host = "chuc.caseum.ru";
                Port = "33333";
                User = "st_1_19_21";
                Database = "is_1_19_st21_KURS";
                Password = "47173474";
                //поле, отвечающее за подключение
                string connecionString;
                //создание подключения
                connecionString = $"server={Host};port={Port};user={User};database={Database};password={Password};";

                conn = connecionString;
                //возвращеник подключения
                return conn;
            }
        }
        class DB
        {
            MySqlConnection conn = new MySqlConnection("server=chuc.caseum.ru;port=33333;user=st_1_19_21;database=is_1_19_st21_KURS;password=47173474;");

            public void openConn()
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            public void closeConn()
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            public MySqlConnection getConn()
            {
                return conn;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _ConnectDB ConnDb = new _ConnectDB();
            MySqlConnection connDb = new MySqlConnection(ConnDb.Initialization());
            string zapros = "SELECT id, id_pac, id_sotr, nazv_bol, MKB, smert FROM Diagnoz";
            try
            {
                connDb.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(zapros, connDb);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message);
                this.Close();
            }
            TimeInApp();

                async void TimeInApp()
            
             {
                var dt = new DateTime();
                while (true)
                {
                    dt = dt.AddSeconds(1);
                    if (dt.Minute == 0)
                        label1.Text = dt.ToString("ss");
                    if (dt.Hour == 0)
                        label1.Text = dt.ToString("mm:ss");
                    else
                        label1.Text = dt.ToString("HH:mm:ss");
                    await Task.Delay(1000);
                }
            }

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Left))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.CurrentRow.Selected = true;

                string index;
                string id = "0";

                index = dataGridView1.SelectedCells[0].RowIndex.ToString();
                id = dataGridView1.Rows[Convert.ToInt32(index)].Cells[1].Value.ToString();
                MessageBox.Show(id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //показывает таблицу сотрудников
            _ConnectDB ConnDb = new _ConnectDB();
            MySqlConnection connDb = new MySqlConnection(ConnDb.Initialization());
            string zapros = "SELECT id_sotr, fio, dolzhn, data_rozhd, seria_pasp, n_pasp, data_nayma, zp, stazh FROM Sotrudniki";
            try
            {
                connDb.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(zapros, connDb);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message);
                this.Close();
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[5].Visible = true;
            dataGridView1.Columns[6].Visible = true;
            dataGridView1.Columns[7].Visible = true;
            dataGridView1.Columns[8].Visible = true;
           

            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[7].ReadOnly = true;
            dataGridView1.Columns[8].ReadOnly = true;
          


            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersVisible = true;

            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[2].HeaderText = "Дата рождения";
            dataGridView1.Columns[3].HeaderText = "Должность";
            dataGridView1.Columns[4].HeaderText = "Серия паспорта";
            dataGridView1.Columns[5].HeaderText = "Номер паспорта";
            dataGridView1.Columns[6].HeaderText = "Дата найма";
            dataGridView1.Columns[7].HeaderText = "Зар.плата";
            dataGridView1.Columns[8].HeaderText = "Стаж";
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //таблица пациентов
            _ConnectDB ConnDb = new _ConnectDB();
            MySqlConnection connDb = new MySqlConnection(ConnDb.Initialization());
            string zapros = "SELECT id_pac, FIO, pol, snils, polis, data_rozhd, adres, zanyatost, tsel, rezult, diagnoz, data_smert, id_sotr FROM Pacient";
            try
            {
                connDb.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(zapros, connDb);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message);
                this.Close();
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[5].Visible = true;
            dataGridView1.Columns[6].Visible = true;
            dataGridView1.Columns[7].Visible = true;
            dataGridView1.Columns[8].Visible = true;
            dataGridView1.Columns[9].Visible = true;
            dataGridView1.Columns[10].Visible = true;
            dataGridView1.Columns[11].Visible = true;
            dataGridView1.Columns[12].Visible = true;

            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[7].ReadOnly = true;
            dataGridView1.Columns[8].ReadOnly = true;
            dataGridView1.Columns[9].ReadOnly = true;
            dataGridView1.Columns[10].ReadOnly = true;
            dataGridView1.Columns[11].ReadOnly = true;
            dataGridView1.Columns[12].ReadOnly = true;
           

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersVisible = true;

            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[2].HeaderText = "Пол";
            dataGridView1.Columns[3].HeaderText = "Номер СНИЛС";
            dataGridView1.Columns[4].HeaderText = "Номер полиса";
            dataGridView1.Columns[5].HeaderText = "Дата рождения";
            dataGridView1.Columns[6].HeaderText = "Адрес";
            dataGridView1.Columns[7].HeaderText = "Занятость";
            dataGridView1.Columns[8].HeaderText = "Цель обращения";
            dataGridView1.Columns[9].HeaderText = "Результат обращения";
            dataGridView1.Columns[10].HeaderText = "Диагноз";
            dataGridView1.Columns[11].HeaderText = "Дата смерти";
            dataGridView1.Columns[12].HeaderText = "ID сотрудника";
          

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //таблица диагнозов
            _ConnectDB ConnDb = new _ConnectDB();
            MySqlConnection connDb = new MySqlConnection(ConnDb.Initialization());
            string zapros = "SELECT id, id_pac, id_sotr, nazv_bol, MKB, smert FROM Diagnoz";
            try
            {
                connDb.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(zapros, connDb);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message);
                this.Close();
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[5].Visible = true;

            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersVisible = true;

            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[1].HeaderText = "ID пациента";
            dataGridView1.Columns[2].HeaderText = "ID сотрудника";
            dataGridView1.Columns[3].HeaderText = "Название болезни";
            dataGridView1.Columns[4].HeaderText = "Диагноз по МКБ";
            dataGridView1.Columns[5].HeaderText = "Причина смерти";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _ConnectDB ConnDb = new _ConnectDB();
            MySqlConnection connDb = new MySqlConnection(ConnDb.Initialization());
            connDb.Open();
            
            string query = "DELETE FROM `is_1_19_st21_KURS` `Pacient` WHERE id = pac_id.id_selected_rowsA ";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connDb);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Удаление успешо!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connDb.Close();
                
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
