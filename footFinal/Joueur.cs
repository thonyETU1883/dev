using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace footFinal
{
    public class Joueur
    {
        int Id;
        string Nom;
        List<Pion> ListePion;
        int Score;
        public Joueur(int id,string nom,List<Pion> listePion,int score)
        {
            this.setId(id);
            this.setNom(nom);
            this.setListePion(listePion);
            this.setScore(score);
        }

        public void setId(int id)
        {
            this.Id = id;
        }

        public void setNom(string nom)
        {
            this.Nom = nom;
        }
        
        public void setListePion(List<Pion> listePion)
        {
            this.ListePion = listePion;
        }

        public void setScore(int score)
        {
            this.Score = score;
        }

        public List<Pion> getListePion()
        {
            return this.ListePion;
        }

        public int getScore()
        {
            return this.Score;
        }

        public void drawPion(Graphics Canvas)
        {
            List<Pion> listePion = this.getListePion();
            foreach (Pion pion in listePion)
            {
                Canvas.DrawImage(pion.getImgPion(),pion.getPositionX(),pion.getPositionY(),pion.getWidth(),pion.getHeight());
            }
        }


        public double CalculDistance(Pion PionTeste,Pion PionActif)
        {
            float positionPTX = PionTeste.getPositionX();
            float positionPTY =PionTeste.getPositionY();

            float positionPAX = PionActif.getPositionX();
            float positionPAY = PionActif.getPositionY();

            return Math.Sqrt(Math.Pow(positionPTX-positionPAX,2)+Math.Pow(positionPTY-positionPAY,2));
        }

        public int PionProche(Pion PionActif)
        {
            List<Pion> listePion = this.getListePion();
            int indice = 0;
            double distanceProche = this.CalculDistance(listePion[0],PionActif);
            double repere = 0;
            for (int i=0;i<listePion.Count;i++)
            {
                repere = this.CalculDistance(listePion[i],PionActif);
                if (distanceProche==0)
                {
                    distanceProche = repere;
                }
                if (repere<distanceProche && repere!=0)
                {
                    distanceProche = repere;
                    indice = i;
                }
            }
            return indice;
        }
    }
}
