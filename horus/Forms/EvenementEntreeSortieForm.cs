using horus.@class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        public EvenementEntreeSortieForm(int nbGens, bool entree)
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
        }

        private void btnValiderEvenement_Click(object sender, EventArgs e)
        {

            //On recupére la valeur decla combo box
            string evenementSelectionne = comboBoxEvenements.SelectedItem as string;

            if (!string.IsNullOrEmpty(evenementSelectionne))
            {
                //on cherche lma ligne ou la premier aveleurs de la ligne = le non selectionner dans la combo
                int indexEvenement = evenements.FindIndex(ev => ev.Split(';')[0] == evenementSelectionne);

                if (indexEvenement != -1)
                {
                    //on modifie 
                    evenements[indexEvenement] = $"{evenementSelectionne};{(entree ? "1" : "0")}";

                    SauvegarderEvenements();
                }
            }

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
                    return File.ReadAllLines(fichierCSV).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Err lors du chargement des événements: {ex.Message}");
            }

            return new List<string>();
        }

        //methode pour enregistrer les modification dans le evenemnts.csv
        private void SauvegarderEvenements()
        {
            try
            {

                File.WriteAllLines(fichierCSV, evenements);
                Debug.WriteLine("event sauvegardés avec succes CSV.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erreur sauvegarde des event : {ex.Message}");
            }
        }
    }
}


