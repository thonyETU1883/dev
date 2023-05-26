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
    public partial class Mise : Form
    {
        public Mise()
        {
            InitializeComponent();

            //Ajout de fond 
            this.BackgroundImage = Image.FromFile("playImage.jpg");

            //manaraka an le ecran le image 
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Mise_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //insertion d'une nouvelle match
            Jeu match = new Jeu(1, 2, DateTime.Now, 1);
            match.saveJeu();

            //creation d'une nouvelle fenetre Achat de mise
            AchatMise newFenetreAchatMise = new AchatMise();
            newFenetreAchatMise.Show();
            this.Hide();            //Fermer la fenetre apres avoir ouvert la fenetre Mise
        }

        private void MisePaintEvent(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Image imageBallon = Image.FromFile("ball.png");
            float positionX = 200;
            for (int i = 0; i < 5; i++)
            {
                canvas.DrawImage(imageBallon, positionX, 300, 20, 20);
                positionX += 40;
            }
        }
    }
}
