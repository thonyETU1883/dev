using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace PMU2
{
    public class Jeu
    {
        int Id;
        int IdJoueur1;
        int IdJoueur2;
        int IdCheval1;
        int IdCheval2;
        double Mise;

        public Jeu(int idJoueur1,int idJoueur2,int idCheval1,int idCheval2,double mise)
        {
            this.setIdJoueur1(idJoueur1);
            this.setIdJoueur2(idJoueur2);
            this.setIdCheval1(idCheval1);
            this.setIdCheval2(idCheval2);
            this.setMise(mise);
        }

        public void setId(int id)
        {
            this.Id = id;
        }

        public void setIdJoueur1(int idJoueur1)
        {
            this.IdJoueur1 = idJoueur1;
        }

        public void setIdJoueur2(int idJoueur2)
        {
            this.IdJoueur2 = idJoueur2;
        }

        public void setIdCheval1(int idCheval1)
        {
            this.IdCheval1 = idCheval1;
        }

        public void setIdCheval2(int idCheval2)
        {
            this.IdCheval2 = idCheval2;
        }

        public void setMise(double mise)
        {
            this.Mise = mise;
        }

        public int getId()
        {
            return this.Id;
        }

        public int getIdJoueur1()
        {
            return this.IdJoueur1;
        }

        public int getIdJoueur2()
        {
            return this.IdJoueur2;
        }

        public int getIdCheval1()
        {
            return this.IdCheval1;
        }

        public int getIdCheval2()
        {
            return this.IdCheval2;
        }

        public double getMise()
        {
            return this.Mise;
        }

        public void saveJeu()
        {
            Connexion con = new Connexion();
            MySqlConnection connection = con.connexionMysql();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO jeu(idJoueur1,idJoueur2,idCheval1,idCheval2,mise) VALUES (@idJoueur1,@idJoueur2,@idCheval1,@idCheval2,@mise)";
            connection.Open();
            command.Parameters.AddWithValue("@idjoueur1", this.getIdJoueur1());
            command.Parameters.AddWithValue("@idJoueur2", this.getIdJoueur2());
            command.Parameters.AddWithValue("@idCheval1", this.getIdCheval1());
            command.Parameters.AddWithValue("@idCheval2", this.getIdCheval2());
            command.Parameters.AddWithValue("@mise", this.getMise());
            command.ExecuteNonQuery();

            command.CommandText = "SELECT COUNT(*) AS derniereId FROM jeu";
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                this.setId(reader.GetInt32(0));
            }

            connection.Close();
        }
    }
}
