using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
            //monthCalendarFin.MaxDate = DateTime.Now;
        }

        private void btnValiderTelechargement_Click(object sender, EventArgs e)
        {
            DateTime dateDebut = monthCalendarDebut.SelectionStart;
            DateTime dateFin = monthCalendarFin.SelectionStart;

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
                    string ligne = $"{currentDate.ToString("dd/MM/yyyy HH:mm:ss")};{parametres.Getnbpersonnes()}";

                    foreach (Evenement evenement in parametres.getParametres())
                    {
                        ligne += $";{(evenement.isActif() ? "1" : "0")}";
                    }

                    writer.WriteLine(ligne);

                    currentDate = currentDate.Add(intervalle);
                }
            }
        }

       
    }
}
