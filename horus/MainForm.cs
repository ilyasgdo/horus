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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Initialisation du Timer
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Intervalle en millisecondes (une seconde)
            timer.Tick += (sender, e) => lblHeure.Text = DateTime.Now.ToString("HH:mm:ss");
            timer.Start();

            // Appel initial pour mettre à jour l'heure dès le démarrage
            lblHeure.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }

        private void btnPersonneEntree_Click(object sender, EventArgs e)
        {
            PersonneEntreeSortieForm personneEntreeSortie = new PersonneEntreeSortieForm();
            open_Click(personneEntreeSortie);
        }

        private void btnPersonneSortie_Click(object sender, EventArgs e)
        {
            PersonneEntreeSortieForm personneEntreeSortie = new PersonneEntreeSortieForm();
            open_Click(personneEntreeSortie);
        }

        private void btnEvenementAjout_Click(object sender, EventArgs e)
        {
            EvenementEntreeSortieForm evenementEntreeSortie = new EvenementEntreeSortieForm();
            open_Click(evenementEntreeSortie);
        }

        private void btnEvenementSuppression_Click(object sender, EventArgs e)
        {
            EvenementEntreeSortieForm evenementEntreeSortie = new EvenementEntreeSortieForm();
            open_Click(evenementEntreeSortie);
        }

        private void picTelechargement_Click(object sender, EventArgs e)
        {
            TelechargementForm telechargement = new TelechargementForm();
            open_Click(telechargement);
        }

        private void picParametres_Click(object sender, EventArgs e)
        {
            ParametresForm parametres = new ParametresForm();
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
