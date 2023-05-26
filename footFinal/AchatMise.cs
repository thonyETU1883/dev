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
    public partial class AchatMise : Form
    {
        public AchatMise()
        {
            InitializeComponent();

            //Ajout de fond 
            this.BackgroundImage = Image.FromFile("playImage.jpg");

            //manaraka an le ecran le image 
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void AchatMise_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Jeu matchEnCour = new Jeu();
            matchEnCour.getDernierJeu();
            //recuperartion des valeurs dans les inputs
            float mise1 = float.Parse(miseJoueur1.Text);
            float mise2 = float.Parse(miseJoueur2.Text);
            MiseClass mise = new MiseClass(matchEnCour.getId(),mise1,mise2);
            mise.saveMiseClass();

            //creation d'une nouvelle fenetre game
            Form1 newFenetreGame = new Form1();
            newFenetreGame.Show();
            this.Hide();         //Fermer la fenetre apres avoir ouvert la fenetre Mise
        }
    }
}
