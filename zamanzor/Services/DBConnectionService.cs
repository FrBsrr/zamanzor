using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zamanzor.Services
{
    public class DBConnectionService
    {

        public MySqlConnection _connection = new MySqlConnection();
        public DBConnectionService()
        {
            MySqlConnection conn = new MySqlConnection("Server=192.168.1.3; Database=zamanzor;Uid=root1;Pwd=root;");
            _connection = conn;
        }
    }
}
