using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace footFinal
{
    public partial class Form1 : Form
    {
        //image des Pions du joueur
        Image ImgPionJ1;
        Image ImgPionJ2;

        //Joueur 
        Joueur joueur1;
        Joueur joueur2;

        //pion a deplacer
        Pion pionActif;
        Image circle;           //image representant le pion a deplacer       

        //deplacement du pion1
        bool Up;bool Down;bool Right;bool Left; bool Tire;
        int Speed=10;

        //deplacement du pion2
        bool Up2;bool Down2;bool Right2;bool Left2; bool Tire2;

        //changement de pion actif
        bool ChangeActif;
        int IndiceInitial = 0;

        //pion actif du joueur2
        Pion pionActif2;

        //changement de pion actif du joueur2
        bool ChangeActif2;
        int IndiceInitial2=0;

        //ballon
        Image ImgBall;
        Ball BallFoot;
        int SpeedBall=20;
        bool Passe;
        bool Passe2;


        //arret du jeu
        bool Arret = false;

        public Form1()
        {
            InitializeComponent();

            //mettre le dessin terrain dans le fenetra et le mettre en plein ecran
            this.BackgroundImage = Image.FromFile("terrain.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
               
            //initialisation du Pion du Joueur
            ImgPionJ1 = Image.FromFile("imgJoueur1.png");
            ImgPionJ2 = Image.FromFile("imgJoueur2.png");

            //Pion du Joueur1
            List<Pion> listePion1=new List<Pion>();
            listePion1.Add(new Pion(70, 170, 30, 30, ImgPionJ1,0));       //goal
            listePion1.Add(new Pion(145, 80, 30, 30, ImgPionJ1,1));       //defenseur
            listePion1.Add(new Pion(145, 170, 30, 30, ImgPionJ1,1));       //defenseur
            listePion1.Add(new Pion(145, 260, 30, 30, ImgPionJ1,1));       //defenseur
            listePion1.Add(new Pion(340, 50, 30, 30, ImgPionJ1,2));       //attaquant
            listePion1.Add(new Pion(340, 110, 30, 30, ImgPionJ1,2));       //attaquant
            listePion1.Add(new Pion(340, 170, 30, 30, ImgPionJ1,2));       //attaquant
            listePion1.Add(new Pion(340, 230, 30, 30, ImgPionJ1,2));       //attaquant
            listePion1.Add(new Pion(340, 290, 30, 30, ImgPionJ1,2));       //attaquant
            listePion1.Add(new Pion(200, 150, 30, 30, ImgPionJ1, 2));       //milieu
            listePion1.Add(new Pion(200, 230, 30, 30, ImgPionJ1, 2));       //milieu

            //340
            //declaration du joueur1
            joueur1 = new Joueur(1,"Thony",listePion1,0);

            //Pion du joueur2
            List<Pion> listePion2 = new List<Pion>();
            listePion2.Add(new Pion(510,170,30,30,ImgPionJ2,0));          //goal
            listePion2.Add(new Pion(440, 80, 30, 30, ImgPionJ2,1));       //defenseur
            listePion2.Add(new Pion(440, 170, 30, 30, ImgPionJ2,1));      //defenseur
            listePion2.Add(new Pion(440, 260, 30, 30, ImgPionJ2,1));      //defenseur
            listePion2.Add(new Pion(245, 50, 30, 30, ImgPionJ2,2));       //attaquant
            listePion2.Add(new Pion(245, 110, 30, 30, ImgPionJ2,2));      //attaquant
            listePion2.Add(new Pion(245, 170, 30, 30, ImgPionJ2,2));      //attaquant
            listePion2.Add(new Pion(245, 230, 30, 30, ImgPionJ2,2));      //attaquant
            listePion2.Add(new Pion(245, 290, 30, 30, ImgPionJ2,2));      //attaquant
            listePion2.Add(new Pion(400, 150, 30, 30, ImgPionJ2, 2));      //milieu
            listePion2.Add(new Pion(400, 230, 30, 30, ImgPionJ2, 2));      //milieu





            //declaration du joueur2
            joueur2 = new Joueur(2,"Anthony",listePion2,0);

            //initialisation du pion a deplacer
            pionActif = listePion1[0];
            circle = Image.FromFile("circle.png");

            //placement du ballon
            ImgBall = Image.FromFile("ball.png");
            BallFoot = new Ball(440, 170, 20,20,ImgBall);

            //initialisation du joueur2
            pionActif2 = listePion2[0];
        }

        public int getInitialPion(Joueur joueur,int indiceInitial)
        {
            if (indiceInitial==joueur.getListePion().Count-1)
            {
                return 0;
            }
            else {
                return indiceInitial + 1;
            }
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            float positionY = this.pionActif.getPositionY();
            float positionX = this.pionActif.getPositionX();
            float width = this.pionActif.getWidth();
            float height = this.pionActif.getHeight();
            int limiteTerrainLR = 59;             //limite du terrain a gauche et a droite
            int limiteTerrainUD = 48;             //limite du terrain a gauche et a droite

            float BallX = this.BallFoot.getPositionX();
            float BallY = this.BallFoot.getPositionY();

            if (this.Up && positionY> limiteTerrainUD)
            {
                this.pionActif.setPositionY(positionY-this.Speed);
                if (this.pionActif.IfIntersecteBall(BallFoot,20))
                {
                    this.BallFoot.setPositionY(BallY - SpeedBall);
                    this.BallFoot.getImgBall().RotateFlip(RotateFlipType.Rotate180FlipNone);
                    this.BallFoot.getImgBall().RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            }
            if (this.Down && positionY+height<(this.ClientSize.Height- limiteTerrainUD))
            {
                this.pionActif.setPositionY(positionY + this.Speed);
                if (this.pionActif.IfIntersecteBall(BallFoot,20))
                {
                    this.BallFoot.setPositionY(BallY + SpeedBall);
                    this.BallFoot.getImgBall().RotateFlip(RotateFlipType.Rotate180FlipNone);
                    this.BallFoot.getImgBall().RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            }

            if (this.Left && positionX> limiteTerrainLR)
            {
                /*if (this.pionActif.getPoste() == 1 && (positionX - this.Speed) < 140)
                {
                    this.pionActif.setPositionX(positionX);
                }*/
                if (this.pionActif.getPoste()==2 && (positionX - this.Speed) < 140)
                {
                    this.pionActif.setPositionX(positionX);
                }
                else
                {
                    this.pionActif.setPositionX(positionX - this.Speed);
                }
                if (this.pionActif.IfIntersecteBall(BallFoot,20))
                {
                    this.BallFoot.setPositionX(BallX - SpeedBall);
                    this.BallFoot.getImgBall().RotateFlip(RotateFlipType.Rotate180FlipNone);
                    this.BallFoot.getImgBall().RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                
            }

            if (this.Right && positionX+width<(this.ClientSize.Width- limiteTerrainLR))
            {
                if ((this.pionActif.getPoste() == 0 || this.pionActif.getPoste() == 1) && (positionX + this.Speed) > 270)
                {
                    this.pionActif.setPositionX(positionX);
                }
                else
                {
                    this.pionActif.setPositionX(positionX + this.Speed);
                }
                if (this.pionActif.IfIntersecteBall(BallFoot,20))
                {
                    this.BallFoot.setPositionX(BallX + SpeedBall);
                    this.BallFoot.getImgBall().RotateFlip(RotateFlipType.Rotate180FlipNone);
                    this.BallFoot.getImgBall().RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                
            }

            if (this.ChangeActif)
            {
                this.IndiceInitial = this.getInitialPion(this.joueur1,this.IndiceInitial);
                this.pionActif = this.joueur1.getListePion()[IndiceInitial];
            }

            if (this.Passe)
            {
                int indicePasse = joueur1.PionProche(this.pionActif);
                this.pionActif = this.joueur1.getListePion()[indicePasse];
                this.BallFoot.setPositionX(this.pionActif.getPositionX() + SpeedBall);
                this.BallFoot.setPositionY(this.pionActif.getPositionY());
            }

            //tire
            if (this.Tire)
            {
                this.BallFoot.setPositionX(BallX+5);
            }
            if (BallX > 532 && BallY > 130 & BallY < 215)                   //but
            {
                int score = this.joueur1.getScore();
                this.joueur1.setScore(score+1);
                label1.Text = "Score: " + this.joueur1.getScore().ToString();
                this.BallFoot.setPositionX(290);
                this.BallFoot.setPositionY(170);
                this.Tire = false;
            }
            if (BallFoot.getPionPassageBall(joueur1)!=null)     //si la balle passe pret d'un joueur
            {
                Pion pion = BallFoot.getPionPassageBall(joueur1);
                this.pionActif = pion;
                this.BallFoot.setPositionX(this.pionActif.getPositionX() + SpeedBall);
                this.BallFoot.setPositionY(this.pionActif.getPositionY());
                this.Tire = false;                      //si joueur1 tire
                this.Tire2 = false;                      //si joueur2 tire
            }




            //deplacement joueur2
            float positionX2 = this.pionActif2.getPositionX();
            float positionY2 = this.pionActif2.getPositionY();
            float width2 = this.pionActif2.getWidth();
            float height2 = this.pionActif2.getHeight();

            if (this.Up2 && positionY2 > limiteTerrainUD)
            {
                this.pionActif2.setPositionY(positionY2 - this.Speed);
                if (this.pionActif2.IfIntersecteBall(BallFoot,20))
                {
                    this.BallFoot.setPositionY(BallY - SpeedBall);
                    this.BallFoot.getImgBall().RotateFlip(RotateFlipType.Rotate180FlipNone);
                    this.BallFoot.getImgBall().RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            }
            if(this.Down2 && positionY2 + height2 < (this.ClientSize.Height - limiteTerrainUD))
            {
                this.pionActif2.setPositionY(positionY2 + this.Speed);
                if (this.pionActif2.IfIntersecteBall(BallFoot,20))
                {
                    this.BallFoot.setPositionY(BallY + SpeedBall);
                    this.BallFoot.getImgBall().RotateFlip(RotateFlipType.Rotate180FlipNone);
                    this.BallFoot.getImgBall().RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            }
            if (this.Left2 && positionX2 + width2 < (this.ClientSize.Width - limiteTerrainLR))
            {
                if (this.pionActif2.getPoste()==2 && (positionX2 + this.Speed)>450)
                {
                    this.pionActif2.setPositionX(positionX2);
                }
                else
                {
                    this.pionActif2.setPositionX(positionX2 + this.Speed);
                }
                if (this.pionActif2.IfIntersecteBall(BallFoot,20))
                {
                    this.BallFoot.setPositionX(BallX + SpeedBall);
                    this.BallFoot.getImgBall().RotateFlip(RotateFlipType.Rotate180FlipNone);
                    this.BallFoot.getImgBall().RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            }
            if (this.Right2 && positionX2 > limiteTerrainLR)
            {
                if ((this.pionActif2.getPoste()==0 || this.pionActif2.getPoste() == 1) && (positionX2 - this.Speed)<300)
                {
                    this.pionActif2.setPositionX(positionX2);
                }
                else
                {
                    this.pionActif2.setPositionX(positionX2 - this.Speed);
                }
                if (this.pionActif2.IfIntersecteBall(BallFoot,20))
                {
                    this.BallFoot.setPositionX(BallX - SpeedBall);
                    this.BallFoot.getImgBall().RotateFlip(RotateFlipType.Rotate180FlipNone);
                    this.BallFoot.getImgBall().RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            }
            if (this.ChangeActif2)
            {
                this.IndiceInitial2 = this.getInitialPion(this.joueur2,this.IndiceInitial2);
                this.pionActif2 = this.joueur2.getListePion()[IndiceInitial2];
            }
            if (this.Passe2)
            {
                int indicePasse = joueur2.PionProche(this.pionActif2);
                this.pionActif2 = this.joueur2.getListePion()[indicePasse];
                this.BallFoot.setPositionX(this.pionActif2.getPositionX() + SpeedBall);
                this.BallFoot.setPositionY(this.pionActif2.getPositionY());
            }

            //tire
            if (this.Tire2)
            {
                this.BallFoot.setPositionX(BallX - 5);
            }
            if (BallX < 50 && BallY > 130 & BallY < 215)                   //but
            {
                int score = this.joueur2.getScore();
                this.joueur2.setScore(score + 1);
                label2.Text = "Score: " + this.joueur2.getScore().ToString();
                this.BallFoot.setPositionX(290);
                this.BallFoot.setPositionY(170);
                this.Tire2 = false;
            }
            if (BallFoot.getPionPassageBall(joueur2) != null)       //si la balle passe pret d'un joueur
            {
                Pion pion = BallFoot.getPionPassageBall(joueur2);
                this.pionActif2 = pion;
                this.BallFoot.setPositionX(this.pionActif2.getPositionX() + SpeedBall);
                this.BallFoot.setPositionY(this.pionActif2.getPositionY());
                this.Tire = false;                              //si joueur1 tire
                this.Tire2 = false;                             //si joueur2 tire
            }
            if (this.BallFoot.getPositionY()<50 || this.BallFoot.getPositionY() > 309)
            {
                this.BallFoot.setPositionX(300);
                this.BallFoot.setPositionY(80);
            }


            this.Invalidate();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            //commande pion1
            if (e.KeyCode==Keys.Up)
            {
                this.Up = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.Down = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                this.Left = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                this.Right = true;
            }
            else if (e.KeyCode == Keys.P)       //changement de joueur actif
            {
                this.ChangeActif = true;
            }
            else if (e.KeyCode == Keys.O)       //passe
            {
                this.Passe = true;
            }
            else if (e.KeyCode == Keys.I && this.pionActif.IfIntersecteBall(BallFoot,30)==true)       //tire
            {
                this.Tire = true;
            }

            //commande pion2
            if (e.KeyCode == Keys.Z)
            {
                this.Up2 = true;
            }
            else if (e.KeyCode == Keys.S)
            {
                this.Down2 = true;
            }
            else if (e.KeyCode == Keys.D)
            {
                this.Left2 = true;
            }
            else if (e.KeyCode == Keys.Q)
            {
                this.Right2 = true;
            }
            else if (e.KeyCode == Keys.T)
            {
                this.ChangeActif2 = true;
            }
            else if (e.KeyCode == Keys.Y)       //passe
            {
                this.Passe2 = true;
            }
            else if (e.KeyCode == Keys.U && this.pionActif2.IfIntersecteBall(BallFoot, 30) == true)       //tire
            {
                this.Tire2 = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.Up = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.Down = false;
            }
            else if (e.KeyCode == Keys.Left)
            {
                this.Left = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                this.Right = false;
            }
            else if (e.KeyCode == Keys.P)
            {
                this.ChangeActif = false;
            }
            else if (e.KeyCode == Keys.O)
            {
                this.Passe = false;
            }
            

            if (e.KeyCode == Keys.Z)
            {
                this.Up2 = false;
            }
            else if (e.KeyCode == Keys.S)
            {
                this.Down2 = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                this.Left2 = false;
            }
            else if (e.KeyCode == Keys.Q)
            {
                this.Right2 = false;
            }
            else if (e.KeyCode == Keys.T)
            {
                this.ChangeActif2 = false;
            }
            else if (e.KeyCode == Keys.Y)       //passe
            {
                this.Passe2 = false;
            }
        }

        private void TerrainPaintEvent(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;

            //dessiner le pion du joueur
            joueur1.drawPion(Canvas);
            joueur2.drawPion(Canvas);

            //dessin du cercle representant le pion actif
            Canvas.DrawImage(circle, pionActif.getPositionX()-20, pionActif.getPositionY()-5, 70, 40);
            Canvas.DrawImage(circle, pionActif2.getPositionX() - 20, pionActif2.getPositionY() - 5, 70, 40);

            //dessin du ballon
            Canvas.DrawImage(BallFoot.getImgBall(), BallFoot.getPositionX(), BallFoot.getPositionY(),BallFoot.getWidth(), BallFoot.getHeight());

            //arret du jeu//
            if (this.joueur1.getScore() == 5 || this.joueur2.getScore() == 5 && this.Arret == false)
            {
                Jeu jeu = new Jeu();
                jeu.getDernierJeu();
                double[] resultatGain = jeu.getMoneyGagnerByJoueur(this.joueur1,this.joueur2);
                Resultat resultat = new Resultat(jeu.getId(),this.joueur1.getScore(),this.joueur2.getScore(),resultatGain[0],resultatGain[1]);
                resultat.saveResultat();
                
                //creation d'une nouvelle fenetre
                ArretMatch newFenetre = new ArretMatch();
                newFenetre.Show();
                this.Hide();            //Fermer la fenetre 
                this.Arret = true;
            }
        }

        private void KeyIsPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
