using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace фяцычувксаепмир
{
     class DB
    {
        MySqlConnection conn = new MySqlConnection("server=chuc.caseum.ru;port=33333;user=st_1_19_21;database=is_1_19_st21_KURS;password=47173474;");

        public void openConn()
        {
            if(conn.State == System.Data.ConnectionState.Closed)
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
}
