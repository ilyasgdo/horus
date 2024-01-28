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
        private horus.@class.Evenements evenements;
        private horus.@class.Evenement evenement;
        private bool entree;

        public EvenementEntreeSortieForm(horus.@class.Evenements evenements, bool entree)
        {
            InitializeComponent();
            this.evenements = evenements;
            this.entree = entree;

            evenement = evenements.GetEvenement(cboEvenements.Text);
            evenement ??= new horus.@class.Evenement();

            cboEvenements.Items.Insert(0, "porte");
            cboEvenements.Items.Insert(1, "fenetre");
            cboEvenements.SelectedIndex = 0;
            cboEvenements.DisplayMember = "Name";
        }

        private void btnValiderEvenement_Click(object sender, EventArgs e)
        {
            if (entree)
            {
                evenement.Debut();
            }
            else
            {
                evenement.Fin();
            }
            evenements.AjouterEvenement(cboEvenements.Text, evenement);


            this.Close();
        }

        private void cboEvenements_TextChanged(object sender, EventArgs e)
        {
            evenement = evenements.GetEvenement(cboEvenements.Text);
            evenement ??= new horus.@class.Evenement();
        }
    }
}
