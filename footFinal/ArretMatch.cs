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
    public partial class ArretMatch : Form
    {
        public ArretMatch()
        {
            InitializeComponent();
        }

        private void ArretMatch_Load(object sender, EventArgs e)
        {
            Resultat resultat = new Resultat();
            resultat.getDernierResultat();
            label1.Text = "Score joueur 1: " + resultat.getScoreJoueur1().ToString();
            label2.Text = "Score joueur 2: " + resultat.getScoreJoueur2().ToString();
            label3.Text = "Gain joueur1 :" + resultat.getMoneyJoueur1();
            label4.Text = "Gain joueur2 :" + resultat.getMoneyJoueur2();
        }
    }
}
