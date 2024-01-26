using horus.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace horus
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnPersonneEntree_Click(object sender, EventArgs e)
        {
            PersonneEntreeSortie personneEntreeSortie = new PersonneEntreeSortie();
            personneEntreeSortie.Show();
        }

        private void btnPersonneSortie_Click(object sender, EventArgs e)
        {
            PersonneEntreeSortie personneEntreeSortie = new PersonneEntreeSortie();
            personneEntreeSortie.Show();
        }

        private void btnEvenementAjout_Click(object sender, EventArgs e)
        {
            EvenementEntreeSortie evenementEntreeSortie = new EvenementEntreeSortie();
            evenementEntreeSortie.Show();
        }

        private void btnEvenementSuppression_Click(object sender, EventArgs e)
        {
            EvenementEntreeSortie evenementEntreeSortie = new EvenementEntreeSortie();
            evenementEntreeSortie.Show();
        }

        private void picTelechargement_Click(object sender, EventArgs e)
        {
            Telechargement telechargement = new Telechargement();
            telechargement.Show();
        }

        private void picParametres_Click(object sender, EventArgs e)
        {
            Parametres parametres = new Parametres();
            parametres.Show();
        }
    }
}
