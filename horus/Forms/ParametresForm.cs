
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;
using horus.@class;


namespace horus.Forms
{
    public partial class ParametresForm : Form
    {
        private string fichierCSV; 
        private List<string[]> evenements = new List<string[]>();

        public ParametresForm()
        {
            InitializeComponent();

            fichierCSV = "CSV/evenementss.csv";

            CreerFichierCSV(fichierCSV);

          
            evenements = ChargerEvenements();
            ActualiserComboBox();
        }


        private void ParametresForm_Load(object sender, EventArgs e)
        {
           
            ActualiserComboBox();
        }

        /// <summary>
        /// Supprimer l'événement sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string evenementSelectionne = comboBoxEvenements.SelectedItem as string;
            if (!string.IsNullOrEmpty(evenementSelectionne))
            {
                for(int i = 0; i < evenements.Count; i++)
                {
                    if (evenements[i][0] == evenementSelectionne)
                    {
                        evenements.Remove(evenements[i]);
                    }
                }
                //enregistrement mémoire
                Parametres param = new Parametres();
                List<Evenement> liste = new List<Evenement>();
                for (int i = 0; i < evenements.Count; i++)
                {
                    bool activite;
                    if (evenements[i][1]=="0") { activite = false; } else { activite = true; }
                    Evenement evenementi = new Evenement(evenements[i][0], activite);
                    liste.Add(evenementi);
                }
                param.InitParametres(liste);
                param.InitParametresComp();
                Modification modif1 = new Modification(param);
                ActualiserComboBox();
                SauvegarderEvenements();
                textBoxNouvelEvenement.Text = "";
            }
        }

        /// <summary>
        /// Ajouter un nouvel événement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            string nouvelEvenement = textBoxNouvelEvenement.Text.Trim();

            if (nouvelEvenement.Contains(";"))
            {
                textBoxNouvelEvenement.BackColor = Color.Red;
                Debug.WriteLine("Le texte ne peut pas contenir le caractère ';'.");
                return;
            }

            textBoxNouvelEvenement.BackColor = SystemColors.Window;

            evenements.Add([$"{nouvelEvenement}","0"]) ;
            //enregistrement mémoire
            Parametres param = new Parametres();
            List<Evenement> liste = new List<Evenement>();
            for (int i = 0; i < evenements.Count; i++)
            {
                bool activite;
                if (evenements[i][1] == "0") { activite = false; } else { activite = true; }
                Evenement evenementi = new Evenement(evenements[i][0], activite);
                liste.Add(evenementi);
            }
            param.InitParametres(liste);
            param.InitParametresComp();
            Modification modif1 = new Modification(param);
            ActualiserComboBox();
            SauvegarderEvenements();
            textBoxNouvelEvenement.Text = "";
        }

        /// <summary>
        /// Appeler la méthode de sauvegarde des événements lors de la fermeture du formulaire
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SauvegarderEvenements();

            base.OnFormClosing(e);
        }


        // ---------------------------------------------------------- Fonctions écrites en dehors des évènements basiques ----------------------------------------------------------//

        /// <summary>
        /// Charger la liste d'événements depuis le fichier CSV
        /// </summary>
        /// <returns></returns>
        private List<string[]> ChargerEvenements()
        {
            try
            {
                if (File.Exists(fichierCSV))
                {
                    return File.ReadAllLines(fichierCSV)
                        .Select(line => line.Split(';'))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erreur lors du chargement des événements : {ex.Message}");
            }

            return new List<string[]>();
        }

        /// <summary>
        /// Enregistrer la liste d'événements dans le fichier CSV
        /// </summary>
        private void SauvegarderEvenements()
        {
            try
            {
                File.WriteAllLines(fichierCSV, evenements.Select(ev => $"{ev[0]};{ev[1]}"));
                Debug.WriteLine("Événements sauvegardés avec succès dans le fichier CSV.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erreur lors de la sauvegarde des événements : {ex.Message}");
            }
        }

        /// <summary>
        /// Mettre à jour la ComboBox avec la liste d'événements (nom seulement)
        /// </summary>
        private void ActualiserComboBox()
        {
            comboBoxEvenements.DataSource = null;
            comboBoxEvenements.DataSource = evenements.Select(ev => $"{ev[0]}").ToList();
        }

        /// <summary>
        /// Lit le fichier CSV. Crée le fichier s'il n'existe pas
        /// </summary>
        /// <param name="cheminFichier"></param>
        private void CreerFichierCSV(string cheminFichier)
        {
            try
            {
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
    }
}
