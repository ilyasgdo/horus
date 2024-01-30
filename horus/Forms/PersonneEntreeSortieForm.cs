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
        int nombrePersonnes;
        private bool entree;

        public PersonneEntreeSortieForm(int nombrePersonnes, bool entree)
        {
            InitializeComponent();
            this.nombrePersonnes = nombrePersonnes;
            this.entree = entree;

            DateTime now = DateTime.Now;
            cbHeurePersonne.SelectedItem = now.ToString("HH");
            cbMinutePersonne.SelectedItem = now.ToString("mm");
        }

        private void btnValiderPersonne_Click(object sender, EventArgs e)
        {
            if (entree)
            {
                nombrePersonnes++;
            }
            else
            {
                if (nombrePersonnes > 0)
                {
                    nombrePersonnes--;
                }
                else
                {
                    MessageBox.Show("Il n'y a personne à faire sortir", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.Close();
        }
    }
}
