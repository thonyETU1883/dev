using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMU2
{
    
    public partial class Form1 : Form
    {
        int x = 250;     //coordonnee x du cercle
        int y = 200;     //coordonnee y du cercle
        int radius = 130;    //rayon du cercle
        int centreX;
        int centreY;
        int largeurTerrain = 200;

        List<Cheval> listeCheval;
        List<Cheval> listeCheval2;

        //depart
        int xDepart=100;
        int yDepart=340;

        //cheval selectionner
        Cheval cheval1;
        Cheval cheval2;

        int descendLabel = 300;
        double Mise;

        bool PrimArriver=false;

        int ligne =1;

        int t;
        public Form1()
        {
            InitializeComponent();
            listeCheval = new List<Cheval>();
            listeCheval2 = new List<Cheval>();
        }

        private void TimerEvent(object sender, EventArgs e)
        {

            for (int i = 0; i < listeCheval.Count; i++)
            {
                int angle = listeCheval[i].getAngle();
                if (listeCheval[i].getGo())
                {
                    listeCheval[i].setAngle((angle - listeCheval[i].getVitesse()));
                    label2.Text = "Chrono : " + DateTime.Now;
                }

                //angle pour activer l'endurance
                float angleEndurence = (listeCheval[i].getPourcentageEndurence() * 360) / 100;

                if (Math.Abs(angle) >= angleEndurence && listeCheval[i].getEndrurenceActiver() == false)
                {
                    int vitesse = listeCheval[i].getVitesse();
                    listeCheval[i].setVitesse(vitesse + listeCheval[i].getEndurence());
                    listeCheval[i].setEndurenceActiver(true);
                }

                //plus tour
                int a = (int)Math.Floor((double)Math.Abs(angle) / 360);
                listeCheval[i].setTour(a);

                //arriver
                if (listeCheval[i].getTour() >= t && listeCheval[i].getGo())
                {
                    if (PrimArriver==false) { 
                        cheval1 = listeCheval[i];
                        PrimArriver=true;
                    }
                    listeCheval[i].setGo(false);
                    listeCheval[i].setFin(DateTime.Now);
                    listeCheval[i].setTour(0);
                    
                        TimeSpan difference =   listeCheval[i].getFin()- cheval1.getFin();
                        Label l1 = new Label();
                        l1.Text = listeCheval[i].getCouleur().ToString();
                        Label l2 = new Label();
                        l2.Text = (listeCheval[i].getFin()- listeCheval[i].getDepart()).ToString();
                        Label l3 = new Label();
                        l3.Text = (listeCheval[i].getFin()- cheval1.getFin()).ToString();
                        Label l4 = new Label();
                        l4.Text = (difference.TotalMilliseconds*Mise).ToString();
                    tableLayoutPanel3.Controls.Add(l1,0,ligne);
                    tableLayoutPanel3.Controls.Add(l2, 1, ligne);
                    tableLayoutPanel3.Controls.Add(l3, 2, ligne);
                    tableLayoutPanel3.Controls.Add(l4, 3, ligne);
                    ligne = ligne + 1;
                }

                Invalidate();
            }
        }

        public bool matchTerminer()
        {
            bool terminer = true;
            for (int i=0;i<listeCheval.Count;i++)
            {
                if (listeCheval[i].getGo())
                {
                    terminer = false;
                    break;
                }
            }
            return terminer;
        }

        private void PaintEvent(object sender, PaintEventArgs e)
        {
            //dessin du terrain//
            Graphics g = e.Graphics;
            Brush brush = new SolidBrush(Color.LightGreen);

            g.FillEllipse(brush, x, y, radius * 2, radius * 2);

            //limite du terrain
            Pen pen = new Pen(Color.Black, 2);
            int xLimite = x - largeurTerrain;
            int yLimite = y - largeurTerrain;
            int radiusLimite = radius + largeurTerrain;
            g.DrawEllipse(pen, xLimite, yLimite, radiusLimite * 2, radiusLimite * 2);

            //dessin du chaval
            /*Brush brush1 = new SolidBrush(Color.Red);
            double angleRad = angle * Math.PI / 180;
            float smallX = (float)(centreX- radius * Math.Cos(angleRad))-(ch1.getWidth()/2);
            float smallY = (float)(centreY- radius * Math.Sin(angleRad))-(ch1.getWidth()/2);
            g.FillEllipse(brush1, smallX, smallY, ch1.getWidth(), ch1.getHeight());*/

            for (int i=0;i<listeCheval.Count;i++) { 
                double angleRad = listeCheval[i].getAngle() * Math.PI / 180;
                Brush brush2 = new SolidBrush(listeCheval[i].getCouleur());
                float x1 = (float)(centreX-(radius+listeCheval[i].getDistance()) *Math.Cos(angleRad))- (listeCheval[i].getWidth() / 2);
                float x2 = (float)(centreY-(radius+ listeCheval[i].getDistance()) * Math.Sin(angleRad)) - (listeCheval[i].getWidth() / 2);
                g.FillEllipse(brush2, x1, x2, listeCheval[i].getWidth(), listeCheval[i].getHeight());
            }

            

            //g.DrawLine(pen,new Point(xDepart,yDepart), new Point(xDepart+largeurTerrain, yDepart));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            centreX = x + radius;
            centreY = y + radius;

            listeCheval.Add(new Cheval(1,0, 20, 20, Color.Olive, 30,3,70,2));
            listeCheval.Add(new Cheval(2,0, 20, 20, Color.Red, 60,3,50,3));
            listeCheval.Add(new Cheval(3,0, 20, 20, Color.Blue, 90,2,40,1));
            listeCheval.Add(new Cheval(4,0, 20, 20, Color.Green, 120,2,40,1));
            listeCheval.Add(new Cheval(5, 0, 20, 20, Color.Black, 150, 2, 40, 1));
            listeCheval.Add(new Cheval(6, 0, 20, 20, Color.Purple, 180, 2, 40, 1));


            listeCheval2.Add(new Cheval(1, 0, 20, 20, Color.Olive, 30, 3, 70, 2));
            listeCheval2.Add(new Cheval(2, 0, 20, 20, Color.Red, 60, 3, 50, 3));
            listeCheval2.Add(new Cheval(3, 0, 20, 20, Color.Blue, 90, 2, 40, 1));
            listeCheval2.Add(new Cheval(4, 0, 20, 20, Color.Chocolate, 120, 2, 40, 1));
            listeCheval2.Add(new Cheval(5, 0, 20, 20, Color.Teal, 150, 2, 40, 1));
            listeCheval2.Add(new Cheval(6, 0, 20, 20, Color.OliveDrab, 180, 2, 40, 1));

            /*Cheval instanceCheval = new Cheval();
            listeCheval = instanceCheval.getListeCheval();
            listeCheval2 = instanceCheval.getListeCheval();*/

            comboBox1.DataSource = listeCheval;
            comboBox2.DataSource = listeCheval2;



            Label l1 = new Label();
            l1.Text = "cheval";
            Label l2 = new Label();
            l2.Text = "temps";

            Label l3 = new Label();
            l3.Text = "difference";
            Label l4 = new Label();
            l4.Text = "valeur";
            tableLayoutPanel3.Controls.Add(l1, 0, 0);
            tableLayoutPanel3.Controls.Add(l2, 1, 0);
            tableLayoutPanel3.Controls.Add(l3, 2, 0);
            tableLayoutPanel3.Controls.Add(l4, 4, 0);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DateTime debut = DateTime.Now;
            for (int j=0; j<listeCheval.Count;j++)
            {
                listeCheval[j].setGo(true);
                listeCheval[j].setDepart(debut);
            }
            label1.Text = "Depart: " + debut;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Cheval ch1 = (Cheval)comboBox1.SelectedItem;
            Cheval ch2 = (Cheval)comboBox2.SelectedItem;

            //cheval selectionner
            cheval1 = listeCheval[ch1.getId()-1];
            cheval2 = listeCheval[ch2.getId()-1];

            t = int.Parse(tour.Text);

            double mise = Double.Parse(textBox1.Text);
                Mise = mise;
            //Jeu jeu = new Jeu(1,2,ch1.getId(),ch2.getId(),mise);
            //jeu.saveJeu();
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void TableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {
          

        }

        private void TableLayoutPanel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
