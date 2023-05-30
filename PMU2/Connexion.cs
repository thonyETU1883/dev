using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PMU2
{
    public class Connexion
    {
        public MySqlConnection connexionMysql()
        {
            string connectionString = "Server=localhost;Database=pmu;uid=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
    }
}
