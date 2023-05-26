using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace footFinal
{
    public class Resultat
    {
        int Id;
        int IdJeu;
        int ScoreJoueur1;
        int ScoreJoueur2;
        double MoneyJoueur1;
        double MoneyJoueur2;

        public Resultat(int idJeu,int scoreJoueur1,int scoreJoueur2,double moneyJoueur1,double moneyJoueur2)
        {
            this.setIdJeu(idJeu);
            this.setScoreJoueur1(scoreJoueur1);
            this.setScoreJoueur2(scoreJoueur2);
            this.setMoneyJoueur1(moneyJoueur1);
            this.setMoneyJoueur2(moneyJoueur2);
        }

        public Resultat() { }

        public void setId(int id)
        {
            this.Id = id;
        }

        public void setIdJeu(int idJeu)
        {
            this.IdJeu = idJeu;
        }

        public void setScoreJoueur1(int scoreJoueur1)
        {
            this.ScoreJoueur1 = scoreJoueur1;
        }

        public void setScoreJoueur2(int scoreJoueur2)
        {
            this.ScoreJoueur2 = scoreJoueur2;
        }

        public void setMoneyJoueur1(double moneyJoueur1)
        {
            this.MoneyJoueur1 = moneyJoueur1;
        }

        public void setMoneyJoueur2(double moneyJoueur2)
        {
            this.MoneyJoueur2 = moneyJoueur2;
        }

        public int getIdJeu()
        {
            return this.IdJeu;
        }

        public int getScoreJoueur1()
        {
            return this.ScoreJoueur1;
        }

        public int getScoreJoueur2()
        {
            return this.ScoreJoueur2;
        }

        public double getMoneyJoueur1()
        {
            return this.MoneyJoueur1;
        }

        public double getMoneyJoueur2()
        {
            return this.MoneyJoueur2;
        }

        public void saveResultat()
        {
            Connexion con = new Connexion();
            MySqlConnection connection = con.connexionMysql();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO resultat(idJeu,scoreJoueur1,scoreJoueur2,moneyJoueur1,moneyJoueur2) VALUES (@idJeu,@scoreJoueur1,@scoreJoueur2,@moneyJoueur1,@moneyJoueur2)";
            connection.Open();
            command.Parameters.AddWithValue("@idJeu", this.getIdJeu());
            command.Parameters.AddWithValue("@scoreJoueur1", this.getScoreJoueur1());
            command.Parameters.AddWithValue("@scoreJoueur2", this.getScoreJoueur2());
            command.Parameters.AddWithValue("@moneyJoueur1", this.getMoneyJoueur1());
            command.Parameters.AddWithValue("@moneyJoueur2", this.getMoneyJoueur2());
            command.ExecuteNonQuery();

            command.CommandText = "SELECT COUNT(*) AS derniereId FROM resultat";
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                this.setId(reader.GetInt32(0));
            }

            connection.Close();
        }

        public void getDernierResultat()
        {
            Connexion con = new Connexion();
            MySqlConnection connection = con.connexionMysql();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM resultat ORDER BY id DESC LIMIT 1";
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                this.setId(reader.GetInt32(0));
                this.setIdJeu(reader.GetInt32(1));
                this.setScoreJoueur1(reader.GetInt32(2));
                this.setScoreJoueur2(reader.GetInt32(3));
                this.setMoneyJoueur1(reader.GetDouble(4));
                this.setMoneyJoueur2(reader.GetDouble(5));
            }
            connection.Close();
        }
    }
}
