using horus.@class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace horus.Forms
{
    public partial class EvenementEntreeSortieForm : Form
    {
        private horus.@class.Evenement evenement;
        private bool entree;

        public EvenementEntreeSortieForm(Evenement evenement, bool entree)
        {
            InitializeComponent();
            this.evenement = evenement;
            this.entree = entree;
        }

        private void btnValiderEvenement_Click(object sender, EventArgs e)
        {
            if (entree)
            {
                if (!evenement.isActif())
                {
                    evenement.Debut();
                }
                else
                {
                    MessageBox.Show("L'événement est déjà actif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (evenement.isActif())
                {
                    evenement.Fin();
                }
                else
                {
                    MessageBox.Show("L'événement n'est pas actif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.Close();
        }
    }
}
