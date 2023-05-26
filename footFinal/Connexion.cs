using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace footFinal
{
    class Connexion
    {
        public MySqlConnection connexionMysql()
        {
            string connectionString = "Server=localhost;Database=footBall;uid=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
    }
}
