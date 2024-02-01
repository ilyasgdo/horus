using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection.Metadata;
using System.Windows.Forms;
using horus.@class;

namespace horus.Forms
{
    public partial class TelechargementForm : Form
    {
        public TelechargementForm()
        {
            InitializeComponent();
            //monthCalendarDebut.MaxDate = DateTime.Now;
            //  monthCalendarFin.MaxDate = DateTime.Now;
        }

        private void btnValiderTelechargement_Click(object sender, EventArgs e)
        {
            DateTime dateDebut = monthCalendarDebut.SelectionStart;
            DateTime dateFin = monthCalendarFin.SelectionStart;
            dateFin = dateFin.Date.AddHours(23).AddMinutes(55).AddSeconds(0);

            if (dateDebut > dateFin)
            {
                MessageBox.Show("La date de début doit être antérieure à la date de fin.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Fichiers CSV (*.csv)|*.csv",
                FileName = $"donnees_{dateDebut.ToString("yyyyMMdd")}_{dateFin.ToString("yyyyMMdd")}.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;


                GenererEtSauvegarderDonnees(filePath, dateDebut, dateFin);

                MessageBox.Show($"Les données ont été enregistrées dans {filePath}.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        private void GenererEtSauvegarderDonnees(string filePath, DateTime dateDebut, DateTime dateFin)
        {
            Parametres parametres = new Parametres();

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Date et heure ; nombre de personnes dans la pièce ; " + parametres.GetEvenementsAsString());

                DateTime currentDate = dateDebut;
                TimeSpan intervalle = TimeSpan.FromMinutes(5);

                while (currentDate <= dateFin)
                {
                    // Récupérer le nombre de personnes du fichier de référence pour la date actuelle
                    int nbPersonnesReference = GetNombrePersonnesReference(currentDate);

                    // Générer la ligne du nouveau fichier en utilisant le nombre de personnes
                    string ligne = $"{currentDate.ToString("dd/MM/yyyy HH:mm:ss")};{nbPersonnesReference}";

                    // Ajouter les états des événements
                    foreach (Evenement evenement in parametres.ChargerEvenementsDepuisCSV())
                    {
                        ligne += $";{(evenement.isActif() ? "1" : "0")}";
                    }

                    writer.WriteLine(ligne);

                    currentDate = currentDate.Add(intervalle);
                }
            }
        }

        // Méthode pour obtenir le nombre de personnes du fichier de référence pour une date donnée
        private int GetNombrePersonnesReference(DateTime currentDate)
        {
            // Charger les données depuis le fichier CSV de référence
            List<string> referenceLines = File.ReadAllLines("../../../CSV/evenementss.csv").ToList();

            // Rechercher la ligne correspondante dans le fichier de référence
            string referenceLine = referenceLines.FirstOrDefault(line => line.StartsWith(currentDate.ToString("dd/MM/yyyy HH:mm:ss")));

            if (referenceLine != null)
            {
                // Récupérer le nombre de personnes de la ligne de référence
                return int.Parse(referenceLine.Split(';')[1]);
            }

            // Valeur par défaut si la ligne n'est pas trouvée
            return 0;
        }



    }
}
