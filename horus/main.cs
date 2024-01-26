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

        private void btnPersonne_Click(object sender, EventArgs e)
        {
            PersonneEntreeSortie personneEntreeSortie = new PersonneEntreeSortie();
            open_Click(personneEntreeSortie);
        }

        private void btnEvenement_Click(object sender, EventArgs e)
        {
            EvenementEntreeSortie evenementEntreeSortie = new EvenementEntreeSortie();
            open_Click(evenementEntreeSortie);
        }

        private void picTelechargement_Click(object sender, EventArgs e)
        {
            Telechargement telechargement = new Telechargement();
            open_Click(telechargement);
        }

        private void picParametres_Click(object sender, EventArgs e)
        {
            Parametres parametres = new Parametres();
            open_Click(parametres);
        }

        private void open_Click(Form form)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == form.Text)
                {
                    isOpen = true;
                    f.Focus();
                }
            }
            if (!isOpen)
            {
                form.Show();
            }
            
        }
        
    }
}
