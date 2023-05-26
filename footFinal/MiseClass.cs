using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace footFinal
{
    class MiseClass
    {
        int Id;
        int IdJeu;
        double MiseJoueur1;
        double MiseJoueur2;


        public MiseClass() { }
        public MiseClass(int idJeu, double miseJoueur1, double miseJoueur2)
        {
            this.setIdJeu(idJeu);
            this.setMiseJoueur1(miseJoueur1);
            this.setMiseJoueur2(miseJoueur2);
        }

        public void setId(int id)
        {
            this.Id = id;
        }

        public void setIdJeu(int idJeu)
        {
            this.IdJeu = idJeu;
        }

        public void setMiseJoueur1(double miseJoueur1)
        {
            this.MiseJoueur1 = miseJoueur1;
        }

        public void setMiseJoueur2(double miseJoueur2)
        {
            this.MiseJoueur2 = miseJoueur2;
        }

        public int getIdJeu()
        {
            return this.IdJeu;
        }

        public double getMiseJoueur1()
        {
            return this.MiseJoueur1;
        }

        public double getMiseJoueur2()
        {
            return this.MiseJoueur2;
        }

        public void saveMiseClass()
        {
            Connexion con = new Connexion();
            MySqlConnection connection = con.connexionMysql();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO mise(idJeu,miseJoueur1,miseJoueur2) VALUES (@idJeu,@miseJoueur1,@miseJoueur2)";
            connection.Open();
            command.Parameters.AddWithValue("@idjeu", this.getIdJeu());
            command.Parameters.AddWithValue("@miseJoueur1", this.getMiseJoueur1());
            command.Parameters.AddWithValue("@miseJoueur2", this.getMiseJoueur2());
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void getMiseByIdJeu(int idJeu)
        {
            Connexion con = new Connexion();
            MySqlConnection connection = con.connexionMysql();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM mise WHERE idJeu=@idJeu";
            connection.Open();
            command.Parameters.AddWithValue("@idJeu", idJeu);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                this.setId(reader.GetInt32(0));
                this.setIdJeu(reader.GetInt32(1));
                this.setMiseJoueur1(reader.GetDouble(2));
                this.setMiseJoueur2(reader.GetDouble(3));
            }
            connection.Close();
        }
    }
}
