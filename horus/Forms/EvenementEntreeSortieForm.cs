using horus.@class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace horus.Forms
{

public partial class EvenementEntreeSortieForm : Form
    {
        private string fichierCSV; // Chemin du fichier CSV
        private List<string> evenements = new List<string>();

        private bool entree;
        private int nbPersonnesPresentent;

        public EvenementEntreeSortieForm(int nbPersonnesPresentent, bool entree)
        {
            InitializeComponent();

            // Chemin complet du fichier CSV
            fichierCSV = "../../../CSV/evenementss.csv";

            // Chargement des événements à partir du fichier CSV
            evenements = ChargerEvenements();
            ActualiserComboBox();

            this.entree = entree;

            DateTime now = DateTime.Now;
            cbHeureEvenement.SelectedItem = now.ToString("HH");
            cbMinuteEvenement.SelectedItem = now.ToString("mm");

            this.nbPersonnesPresentent = nbPersonnesPresentent;
        }

        private void btnValiderEvenement_Click(object sender, EventArgs e)
        {
            CreationModification();
            this.Close();
        }

        private void ActualiserComboBox()
        {
            // Mettre à jour la ComboBox avec la liste d'événements (nom seulement)
            comboBoxEvenements.DataSource = null;
            comboBoxEvenements.DataSource = evenements.Select(ev => ev.Split(';')[0]).ToList();
        }

        private List<string> ChargerEvenements()
        {
            // Charger la liste d'événements depuis le fichier CSV
            try
            {
                if (File.Exists(fichierCSV))
                {
                    // Séparer le nom de l événement de la partie après le ;
                    return File.ReadAllLines(fichierCSV)
                        .Select(line => line.Split(';')[0])
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erreur lors du chargement des événements : {ex.Message}");
            }

            return new List<string>();
        }

        private void CreationModification()
        {
            Parametres parametres = new Parametres();
            List<Evenement> evenements = parametres.getParametres();
            for (int i = 0; i < evenements.Count; i++)
            {
                if (evenements[i].getNom()== comboBoxEvenements.DataSource)
                {
                    evenements[i].Change();
                }
            }
            parametres.InitParametres(evenements);
            // !!!!!!!!!!!!!!!!!!!! ATTENTION NE PREND PAS ENCORE EN COMPTE L'HEURE
            Modification modif = new Modification(parametres);
        }
    }

}