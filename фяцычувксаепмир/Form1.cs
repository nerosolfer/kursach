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
            //тут поля(не рисовые) для значений
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
            string zapros = "SELECT id, kod_pacient, kod_vrach, nazv_bol, MKB, smert FROM Diagnoz";
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
    }
}
