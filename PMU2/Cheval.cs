using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MySql.Data.MySqlClient;


namespace PMU2
{
    public class Cheval
    {
        int Id;
        int Angle;
        float Width;
        float Height;
        Color Couleur;
        int Distance; //distance par rapport au cercle
        int Tour;
        bool Go=false;
        int Vitesse;
        int PourcentageEndurence;
        bool EndurenceActiver;
        int Endurence;
        DateTime Depart;
        DateTime Fin;
        double Gain = 0;

        public Cheval(int id,int angle, float width, float height,Color couleur,int distance,int vitesse,int pe,int endurence)
        {
            this.setId(id);
            this.setAngle(angle);
            this.setWidth(width);
            this.setHeight(height);
            this.setCouleur(couleur);
            this.setDistance(distance);
            this.setVitesse(vitesse);
            this.setPourcentageEndurence(pe);
            this.setEndurence(endurence);
            Tour = 0;
            EndurenceActiver = false;
        }

        public Cheval()
        {

        }

        public void setAngle(int angle)
        {
            this.Angle = angle;
        }

        public void setWidth(float width)
        {
            this.Width = width;
        }

        public void setHeight(float height)
        {
            this.Height = height;
        }

        public void setCouleur(Color couleur)
        {
            this.Couleur = couleur;
        }

        public void setDistance(int distance)
        {
            this.Distance = distance;
        }

        public void setTour(int tour)
        {
            this.Tour = tour;
        }

        public void setGo(bool go)
        {
            this.Go = go;
        }

        public void setVitesse(int vitesse)
        {
            this.Vitesse = vitesse;
        }

        public void setPourcentageEndurence(int pe)
        {
            this.PourcentageEndurence = pe;
        }
        
        public void setEndurenceActiver(bool e)
        {
            this.EndurenceActiver = e;
        }

        public void setEndurence(int endurence)
        {
            this.Endurence = endurence;
        }

        public void setDepart(DateTime depart)
        {
            this.Depart = depart;
        }

        public void setFin(DateTime fin)
        {
            this.Fin = fin;
        }


        public void setId(int id)
        {
            this.Id = id;
        }

        public int getAngle()
        {
            return this.Angle;
        }

        public float getWidth()
        {
            return this.Width;
        }

        public float getHeight()
        {
            return this.Height;
        }

        public Color getCouleur()
        {
            return this.Couleur;
        }

        public int getDistance()
        {
            return this.Distance;
        }

        public int getTour()
        {
            return this.Tour;
        }

        public bool getGo()
        {
            return this.Go;
        }

        public int getVitesse()
        {
            return this.Vitesse;
        }

        public int getPourcentageEndurence()
        {
            return this.PourcentageEndurence;
        }

        public bool getEndrurenceActiver()
        {
            return this.EndurenceActiver;
        }

        public int getEndurence()
        {
            return this.Endurence;
        }

        public DateTime getDepart()
        {
            return this.Depart;
        }

        public DateTime getFin()
        {
            return this.Fin;
        }

        public int getId()
        {
            return this.Id;
        }

        public override string ToString()
        {
            return Couleur.Name;
        }

        public List<Cheval> getListeCheval()
        {
            List<Cheval> listeCheval = new List<Cheval>();
            Connexion con = new Connexion();
            MySqlConnection connection = con.connexionMysql();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM cheval";
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                String c = reader.GetString(4);
                Cheval cheval = new Cheval(reader.GetInt32(0), reader.GetInt32(1), reader.GetFloat(2), reader.GetFloat(3), Color.FromName(c), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8));
                listeCheval.Add(cheval);
             }
            connection.Close();
            return listeCheval;
        }
    }
}
