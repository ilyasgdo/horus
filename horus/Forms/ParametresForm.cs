
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;

namespace horus.Forms
{
    public partial class ParametresForm : Form
    {
        private string fichierCSV; // Chemin du fichier CSV
        private List<string> evenements = new List<string>();

        public ParametresForm()
        {
            InitializeComponent();



            // Chemin complet du fichier CSV
            fichierCSV = "../../../CSV/evenementss.csv";

            // Vérifie si le fichier CSV existe, sinon le crée
            CreerFichierCSV(fichierCSV);

            // Chargement des événements à partir du fichier CSV
            evenements = ChargerEvenements();
            ActualiserComboBox();
        }

        private void ParametresForm_Load(object sender, EventArgs e)
        {
            // Actualiser la ComboBox avec les événements chargés
            ActualiserComboBox();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            // Supprimer l'événement sélectionné
            string evenementSelectionne = comboBoxEvenements.SelectedItem as string;
            if (!string.IsNullOrEmpty(evenementSelectionne))
            {
                evenements.Remove(evenementSelectionne);
                ActualiserComboBox();
                SauvegarderEvenements();
                textBoxNouvelEvenement.Text = "";
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // Ajouter un nouvel événement
            string nouvelEvenement = textBoxNouvelEvenement.Text.Trim();
            if (!string.IsNullOrEmpty(nouvelEvenement))
            {
                evenements.Add(nouvelEvenement);
                ActualiserComboBox();
                SauvegarderEvenements();
                textBoxNouvelEvenement.Text = "";
            }
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
                Debug.WriteLine($"Erreur lors du chargement des événements : {ex.Message}");
            }

            return new List<string>();
        }

        private void SauvegarderEvenements()
        {
            try
            {
                // Enregistrer la liste d'événements dans le fichier CSV
                File.WriteAllLines(fichierCSV, evenements);
                Debug.WriteLine("Événements sauvegardés avec succès dans le fichier CSV.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erreur lors de la sauvegarde des événements : {ex.Message}");
            }
        }

        private void ActualiserComboBox()
        {
            // Mettre à jour la ComboBox avec la liste d'événements
            comboBoxEvenements.DataSource = null;
            comboBoxEvenements.DataSource = evenements;
        }

        private void CreerFichierCSV(string cheminFichier)
        {
            try
            {
                // Crée le fichier s'il n'existe pas
                if (!File.Exists(cheminFichier))
                {
                    File.WriteAllText(cheminFichier, "");
                    Debug.WriteLine("Fichier CSV créé avec succès.");
                }
                else
                {
                    Debug.WriteLine("Le fichier CSV existe déjà.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erreur lors de la création ou vérification du fichier CSV : {ex.Message}");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Appeler la méthode de sauvegarde des événements lors de la fermeture du formulaire
            SauvegarderEvenements();

            base.OnFormClosing(e);
        }

    
    }
}
