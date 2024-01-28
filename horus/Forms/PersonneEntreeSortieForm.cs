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
    public partial class PersonneEntreeSortieForm : Form
    {
        private horus.@class.Evenements evenements;
        private horus.@class.Evenement evenement;
        private bool entree;

        public PersonneEntreeSortieForm(horus.@class.Evenements evenements, bool entree)
        {
            InitializeComponent();
            this.evenements = evenements;
            this.entree = entree;

            evenement = evenements.GetEvenement("Personne");
        }

        private void btnValiderPersonne_Click(object sender, EventArgs e)
        {
            if (entree)
            {
                evenement.Debut();
            }
            else
            {
                evenement.Fin();
            }
            evenements.AjouterModifierEvenement("Personne", evenement);

            this.Close();
        }
    }
}
