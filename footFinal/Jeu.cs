using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace footFinal
{
    class Jeu
    {
        int Id;
        int IdJoeur1;
        int IdJoeur2;
        DateTime Date;
        int IdJeuton;

        public Jeu() { }
        public Jeu(int idJoueur1, int idJoueur2, DateTime date, int idJeuton)
        {
            this.setIdJoeur1(idJoueur1);
            this.setIdJoeur2(idJoueur2);
            this.setDate(date);
            this.setIdJeuton(idJeuton);
        }

        public void setId(int id)
        {
            this.Id = id;
        }

        public void setIdJoeur1(int idJoueur1)
        {
            this.IdJoeur1 = idJoueur1;
        }

        public void setIdJoeur2(int idJoueur2)
        {
            this.IdJoeur2 = idJoueur2;
        }

        public void setDate(DateTime date)
        {
            this.Date = date;
        }

        public void setIdJeuton(int idJeuton)
        {
            this.IdJeuton = idJeuton;
        }

        public int getId()
        {
            return this.Id;
        }

        public int getIdJoueur1()
        {
            return this.IdJoeur1;
        }

        public int getIdJoueur2()
        {
            return this.IdJoeur2;
        }

        public DateTime getDate()
        {
            return this.Date;
        }

        public int getIdJeuton()
        {
            return this.IdJeuton;
        }

        //methode pour inserer une match
        public void saveJeu()
        {
            Connexion con = new Connexion();
            MySqlConnection connection = con.connexionMysql();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO jeu(idJoueur1,idJoueur2,date,idJeuton) VALUES (@idJoueur1,@idJoueur2,@date,@idJeuton)";
            connection.Open();
            command.Parameters.AddWithValue("@idjoueur1", this.getIdJoueur1());
            command.Parameters.AddWithValue("@idJoueur2", this.getIdJoueur2());
            command.Parameters.AddWithValue("@date", this.getDate());
            command.Parameters.AddWithValue("@idJeuton", this.getIdJeuton());
            command.ExecuteNonQuery();

            command.CommandText = "SELECT COUNT(*) AS derniereId FROM jeu";
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                this.setId(reader.GetInt32(0));
            }

            connection.Close();
        }

        public void getDernierJeu()
        {
            Connexion con = new Connexion();
            MySqlConnection connection = con.connexionMysql();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM jeu ORDER BY id DESC LIMIT 1";
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                this.setId(reader.GetInt32(0));
                this.setIdJoeur1(reader.GetInt32(1));
                this.setIdJoeur2(reader.GetInt32(2));
                this.setDate(reader.GetDateTime(3));
                this.setIdJeuton(reader.GetInt32(4));
            }
            connection.Close();
        }

        public double[] getMoneyGagnerByJoueur(Joueur joueur1, Joueur joueur2)
        {
            Jeuton jeuton = new Jeuton();
            jeuton.getJeutonById(this.getIdJeuton());
            MiseClass mise = new MiseClass();
            mise.getMiseByIdJeu(this.getId());
            double miseJoueur1 = mise.getMiseJoueur1();
            double miseJoueur2 = mise.getMiseJoueur2();
            double[] resultat = new double[2];
            double gain = miseJoueur1 + miseJoueur2 - jeuton.getPrix();
            if (joueur1.getScore()>joueur2.getScore())
            {
                resultat[0] = gain;
                resultat[1] = 0;
            }
            else
            {
                resultat[0] = 0;
                resultat[1] = gain;
            }

            return resultat;
        }
    }
}
