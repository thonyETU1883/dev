using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace footFinal
{
    class Jeuton
    {
        int Id;
        double Prix;
        int NombreBall;

        public Jeuton(double prix,int nombreBall)
        {
            this.setPrix(prix);
        }

        public Jeuton() { }

        public void setId(int id)
        {
            this.Id = id;
        }

        public void setPrix(double prix)
        {
            this.Prix = prix;
        }

        public void setNombreBall(int nombreBall)
        {
            this.NombreBall = nombreBall;
        }

        public double getPrix()
        {
            return this.Prix;
        }

        public void getJeutonById(int idJeuton)
        {
            Connexion con = new Connexion();
            MySqlConnection connection = con.connexionMysql();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM jeuton WHERE id=@id";
            connection.Open();
            command.Parameters.AddWithValue("@id", idJeuton);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                this.setId(reader.GetInt32(0));
                this.setPrix(reader.GetInt32(1));
                this.setNombreBall(reader.GetInt32(2));
            }
            connection.Close();
        }
    }
}
