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
        public static List<string> EvenementNonActif = new List<string>();
        public static List<string> EvenementActif = new List<string>();

        public EvenementEntreeSortieForm(int nbGens, bool entree)
        {
            InitializeComponent();

            // Chemin complet du fichier CSV
            fichierCSV = "CSV/evenementss.csv";

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
                //récup contenu mémoire dans l'ordre
                List<string> contenuMemoire = File.ReadAllLines("CSV/memoire.csv").ToList();
                contenuMemoire = EnleverParam(contenuMemoire);
                contenuMemoire = Tri(contenuMemoire);

                //récupère la date et l'heure selectionné
                string dateDuJour;
                Parametres param = new Parametres();
                if (DateModif == true)
                {
                    dateDuJour = param.GetDate().ToString("dd/MM/yyyy");
                }
                else
                {
                    dateDuJour = DateTime.Now.ToString("dd/MM/yyyy");
                }
                string strDateEtHeure = dateDuJour + " " + cbHeureEvenement.SelectedItem + ":" + cbMinuteEvenement.SelectedItem;
                Debug.WriteLine("la date et l'heure choisi est : "+strDateEtHeure);

                //recup des évènepents
                string ligneParametre = ligneParametreProche();
                //string ligneProche = LigneLaPlusProche(DateTime.Parse(strDateEtHeure));
                //List<string> Evenements = ListeEvenements(ligneProche);
                List<string> Evenements = new List<string>();
                string[] contenuLigne = ligneParametre.Split(';');
                for (int k = 3; k < contenuLigne.Length - 1; k++)
                {
                    string ev = contenuLigne[k].Substring(0, contenuLigne[k].Length - 1);
                    Evenements.Add(ev);
                }
                List<int> valeurs = RecupInitEve(DateTime.Parse(strDateEtHeure), Evenements.Count);
                int j = 0; bool trouve = false;
                while (j < Evenements.Count && trouve == false)
                {
                    //Debug.Write(evenementSelectionne + " est comparé à " + Evenements[j] + " ;  ");
                    if (Evenements[j] == evenementSelectionne)
                    {
                        trouve = true; j--;
                    }
                    j++;
                }
                bool Nonvalide = (entree == false && valeurs[j] != 1) || (entree == true && valeurs[j] != 0);
                Debug.WriteLine("Ainsi l'action est-elle valide ? : " + Nonvalide + "   (true si non valide)");
                if (Nonvalide)
                {
                    if (entree == false)
                    {
                        MessageBox.Show("L'évènement n'est pas en cours à ce moment", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("L'évènement est déjà en cours à ce moment", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
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
                    param.InitParametresComp();
                    List<Evenement> liste = new List<Evenement>();
                    for (int i = 0; i < evenements.Count; i++)
                    {
                        string[] ligne = evenements[i].Split(';');
                        Debug.WriteLine("Cette ligne est : " + evenements[i]);
                        bool activite;
                        if (ligne[1] == "0") { activite = false; } else { activite = true; }
                        Evenement evenementi = new Evenement(ligne[0], activite);
                        liste.Add(evenementi);
                    }
                    param.InitParametres(liste);
                    DateTime DateEtHeure = DateTime.Parse(strDateEtHeure);
                    Modification modif = new Modification(DateEtHeure, param);
                }
            }
            this.Close();
        }

        private string ligneParametreProche()
        {
            List<string> contenuMemoire = File.ReadAllLines("CSV/memoire.csv").ToList();
            string ligneparametre="";
            for (int i=0; i<contenuMemoire.Count; i++)
            {
                string[] ligne = contenuMemoire[i].Split(';');
                if (ligne[1] == "Date et heure ")
                {
                    ligneparametre = contenuMemoire[i];
                }
            }
            return ligneparametre;
        }

        private List<int> RecupInitEve(DateTime currentDate, int taille)
        {
            List<string> contenuMemoire = File.ReadAllLines("CSV/memoire.csv").ToList();
            contenuMemoire = EnleverParam(contenuMemoire);
            contenuMemoire = Tri(contenuMemoire);
            int i = 0; bool Fin = false; List<int> total = new List<int>();
            for (int j = 0; j < taille; j++) { total.Add(0); }
            while (i < contenuMemoire.Count && Fin == false)
            {
                for (int j = 0; j < taille; j++)
                {
                    string[] ligne = contenuMemoire[i].Split(';');
                    if ((2 + j) < ligne.Length-1)
                    {
                        int nb = Convert.ToInt32(ligne[2 + j]);
                        total[j] = total[j] + nb;
                        if (total[j] != 0 && total[j] != 1) { total[j] = 0; }
                    }
                }
                if (i + 1 < contenuMemoire.Count && DateTime.Parse(contenuMemoire[i + 1].Split(';')[0]) > currentDate)
                {
                    Fin = true;
                }
                i++;
            }
            return total;
        }

        private string LigneLaPlusProche(DateTime date)
        {
            //récupération de la mémoire
            List<string> contenuMemoire = File.ReadAllLines("CSV/memoire.csv").ToList();
            contenuMemoire = EnleverParam(contenuMemoire);
            contenuMemoire = Tri(contenuMemoire);
            for (int i = 0; i < contenuMemoire.Count; i++)
            {
                string dateligne = contenuMemoire[i].Split(';')[0];
                //if (test == true) { Debug.Write("Comparaison " + DateTime.Parse(dateligne) + " et " + date + " = " + Convert.ToString(DateTime.Parse(dateligne) > date) + "  -  "); }

                if (DateTime.Parse(dateligne) > date)
                {
                    //if (test == true) { Debug.Write("La ligne est plus tard " + dateligne + "  -  "); }
                    if (i != 0)
                    {
                        //if (test == true) { Debug.Write("La ligne d'avant " + contenuMemoire[i - 1].Split(';')[0] + "  -  "); }

                        //ligne d'avant
                        return contenuMemoire[i - 1];

                    }
                    else
                    {
                        //if (test == true) { Debug.Write("La ligne d'avant " + contenuMemoire[i].Split(';')[0] + "  -  "); }

                        //ligne vide
                        return contenuMemoire[i];

                    }
                }
            }
            //dernière ligne
            return contenuMemoire[contenuMemoire.Count - 1];
        }

        private List<string> ListeEvenements(string ligneProche)
        {
            List<string> contenuMemoire = File.ReadAllLines("CSV/memoire.csv").ToList();
            contenuMemoire=Tri(contenuMemoire);
            string dernierListeParametres = ""; bool Fin = false; int j = 0;
            while (j < contenuMemoire.Count && Fin == false)
            {
                if (contenuMemoire[j].Split(';')[1] == "Date et heure ")
                {
                    dernierListeParametres = contenuMemoire[j];
                    Fin = true;
                }
                j++;
            }
            Fin = false; int i = 0;
            while (i < contenuMemoire.Count && Fin == false)
            {
                if (contenuMemoire[i].Split(';')[1] == "Date et heure ")
                {
                    dernierListeParametres = contenuMemoire[i];
                }
                else
                {
                    if (contenuMemoire[i] == ligneProche)
                    {
                        Fin = true;
                    }
                }
                i++;
            }
            string message = "";
            for (int k = 0; k < contenuMemoire.Count; k++)
            {
                message = message + "\n" + contenuMemoire[k];
            }
            MessageBox.Show("La ligne de parametre prise en compte est "+dernierListeParametres, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            string[] contenuLigne = dernierListeParametres.Split(";");
            List<string> evenements = new List<string>();
            for (int k = 3; k < contenuLigne.Length-1; k++)
            {
                evenements.Add(contenuLigne[k]);
            }
            return (evenements);
        }

        private List<string> EnleverParam(List<string> lignes)
        {
            List<string> res = new List<string>();
            //enleve les ligne qui ne servent pas 
            for (int i = 0; i < lignes.Count; i++)
            {
                if (lignes[i].Split(';')[1] != "Date et heure ")
                {
                    res.Add(lignes[i]);
                }

            }
            return res;
        }

        private List<string> Tri(List<string> lignes)
        {
            //tri par date
            for (int i = lignes.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    DateTime date1 = DateTime.Parse(lignes[j].Split(';')[0]);
                    DateTime date2 = DateTime.Parse(lignes[j + 1].Split(';')[0]);
                    if (date1 > date2)
                    {
                        string intermediaire = lignes[j];
                        lignes[j] = lignes[j + 1];
                        lignes[j + 1] = intermediaire;
                    }
                }
            }
            return lignes;
        }

        private void ActualiserComboBoxEntree()
        {
            // Mettre à jour la ComboBox avec la liste d'événements (nom seulement)
            EvenementNonActif.Clear();
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
            EvenementActif.Clear();
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


