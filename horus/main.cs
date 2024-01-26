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

            // Initialisation du Timer
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Intervalle en millisecondes (une seconde)
            timer.Tick += (sender, e) => lblHeure.Text = DateTime.Now.ToString("HH:mm:ss");
            timer.Start();

            // Appel initial pour mettre à jour l'heure dès le démarrage
            lblHeure.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
