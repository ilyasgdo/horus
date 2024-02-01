using horus.@class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace horus.Forms
{
    public partial class EvenementEntreeSortieForm : Form
    {
        private string fichierCSV; // Chemin du fichier CSV
        private List<string> evenements = new List<string>();

        public bool entree;
        public bool DateModif;

        public EvenementEntreeSortieForm(int nbGens, bool entree)
        {
            InitializeComponent();

            // Chemin complet du fichier CSV
            fichierCSV = "../../../CSV/evenementss.csv";

            // Chargement des événements à partir du fichier CSV
            evenements = ChargerEvenements();
            this.entree = entree;
            if (this.entree)
            {
                ActualiserComboBoxEntree();
            }
            else
            {
                ActualiserComboBoxSortie();
            }
            DateModif = false;

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
                //enregistrements de la modificaion dans la mémoire 
                Parametres param = new Parametres();
                List<Evenement> liste = new List<Evenement>();
                for (int i = 0; i < evenements.Count; i++)
                {
                    string[] ligne = evenements[i].Split(';');
                    bool activite;
                    if (ligne[1] == "0") { activite = false; } else { activite = true; }
                    Evenement evenementi = new Evenement(ligne[0], activite);
                    liste.Add(evenementi);
                }
                param.InitParametres(liste);
                string dateDuJour;
                if (DateModif == true)
                {
                    dateDuJour = param.GetDate().ToString("dd/MM/yyyy");
                } else
                {
                    dateDuJour = DateTime.Now.ToString("dd/MM/yyyy");
                }
                string strDateEtHeure = dateDuJour + " " + cbHeureEvenement.SelectedItem + ":" + cbMinuteEvenement.SelectedItem;
                DateTime DateEtHeure = DateTime.Parse(strDateEtHeure);
                Modification modif = new Modification(DateEtHeure, param);
            }

            this.Close();
        }

        private void ActualiserComboBoxEntree()
        {
            // Mettre à jour la ComboBox avec la liste d'événements (nom seulement)
            List<string> EvenementNonActif = new List<string>();
            for (int i = 0; i < evenements.Count; i++)
            {
                string[] ligne = evenements[i].Split(';');
                if (ligne[1] == "0")
                {
                    EvenementNonActif.Add(ligne[0]);
                }
            }
            comboBoxEvenements.DataSource = null;
            comboBoxEvenements.DataSource = EvenementNonActif;
        }

        private void ActualiserComboBoxSortie()
        {
            // Mettre à jour la ComboBox avec la liste d'événements (nom seulement)
            List<string> EvenementActif = new List<string>();
            for (int i = 0; i < evenements.Count; i++)
            {
                string[] ligne = evenements[i].Split(';');
                if (ligne[1] == "1")
                {
                    EvenementActif.Add(ligne[0]);
                }
            }
            comboBoxEvenements.DataSource = null;
            comboBoxEvenements.DataSource = EvenementActif;

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

        private void pctboxDate_Click(object sender, EventArgs e)
        {
            DateModif = true;
            Date formDate = new Date();
            open_Click(formDate);
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


