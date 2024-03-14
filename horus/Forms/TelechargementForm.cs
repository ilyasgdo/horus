using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Windows.Forms;
using horus.@class;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace horus.Forms
{
    public partial class TelechargementForm : Form
    {
        public TelechargementForm()
        {
            InitializeComponent();
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


        // ---------------------------------------------------------- Fonctions écrites en dehors des évènements basiques ----------------------------------------------------------//


        private void GenererEtSauvegarderDonnees(string filePath, DateTime dateDebut, DateTime dateFin)
        {
            Parametres parametres = new Parametres();

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                //fonction pour retrouver toutes les "Date Et Heure "et en faire la liste 
                List<string> NomsEvenements = RecupEvenements();
                string presentation = "Date et heure; nombre de personnes dans la pièce; ";
                for (int i = 0; i < NomsEvenements.Count; i++)
                {
                    presentation += NomsEvenements[i] + ";";
                }

                writer.WriteLine(presentation);

                DateTime currentDate = dateDebut;
                TimeSpan intervalle = TimeSpan.FromMinutes(5);

                string ligneProche;
                string ligneProcheComparaison = "";
                string[] champsLigne;
                string nbPersonnes = "0";
                List<string> listeNomEvenement = new List<string>();
                List<int> listeEtat = new List<int>();
                List<string> creaLigne = new List<string>();
                bool ligne1 = true;
                bool test = true;
                bool PasDeLigneAvant = false;
                int PremiereLigneTrouve = 0;

                while (currentDate <= dateFin)
                {
                    (ligneProche, PasDeLigneAvant) = LigneLaPlusProche(currentDate);
                    if (PasDeLigneAvant == false) { PremiereLigneTrouve++; }
                    if (!ligne1 && PremiereLigneTrouve != 1 && ligneProche == ligneProcheComparaison)
                    {
                        creaLigne[0] = currentDate.ToString("dd/MM/yyyy HH:mm:ss") + ";";
                    }
                    else
                    {
                        creaLigne.Clear();
                        if (test == true)
                        {
                            Debug.WriteLine("la ligne trouvé est - " + ligneProche + " pour la date " + currentDate);
                        }

                        //on récupère le nombre de personnes
                        champsLigne = ligneProche.Split(';');

                        nbPersonnes = Convert.ToString(RecupInitPers(currentDate));
                        if (test == true)
                        {
                            Debug.Write("Ses champs sont :");
                            for (int i = 0; i < champsLigne.Length - 1; i++) { Debug.Write(champsLigne[i] + " ; "); }
                            Debug.Write("\n");
                        }
                        //fonction pour trouver actuellement les evenements et leur etat (actif ou non)
                        listeNomEvenement.Clear();
                        listeEtat.Clear();
                        listeNomEvenement = ListeEvenements(ligneProche);
                        if (test == true)
                        {
                            Debug.Write("Ses evenements sont :");
                            for (int i = 0; i < listeNomEvenement.Count - 1; i++) { Debug.Write(listeNomEvenement[i] + " ; "); }
                            Debug.Write("\n");
                        }

                        listeEtat = RecupInitEve(currentDate, NomsEvenements.Count);
                        if (test == true)
                        {
                            Debug.Write("Ses valeurs sont :");
                            for (int i = 0; i < listeEtat.Count; i++) { Debug.Write(listeEtat[i] + " ; "); }
                            Debug.Write("\n");
                        }
                        creaLigne.Add(currentDate.ToString("dd/MM/yyyy HH:mm:ss") + ";");
                        creaLigne.Add(nbPersonnes + ";");
                        for (int i = 0; i < NomsEvenements.Count; i++)
                        {
                            if (test == true)
                            {
                                Debug.Write("\nEvenement " + NomsEvenements[i]);
                            }

                            bool trouve = false;
                            for (int k = 0; k < listeNomEvenement.Count; k++)
                            {
                                if (test == true)
                                {
                                    Debug.Write("\n   " + listeNomEvenement[k] + " : ");
                                }
                                if (listeNomEvenement[k] == NomsEvenements[i])
                                {
                                    if (test == true)
                                    {
                                        Debug.Write("C'est le même champs");
                                    }
                                    trouve = true;

                                    if (k < listeEtat.Count && listeEtat[k] == 1)
                                    {
                                        creaLigne.Add("1;");
                                    }
                                    else
                                    {
                                        creaLigne.Add("0;");
                                    }
                                }
                            }
                            if (trouve == false) { creaLigne.Add("0;"); }
                        }

                    }
                    string ligne = "";
                    for (int i = 0; i < creaLigne.Count; i++)
                    {
                        ligne = ligne + creaLigne[i];
                    }
                    writer.WriteLine(ligne);

                    if (test == true) { Debug.WriteLine("la ligne totale est : " + ligne); }

                    currentDate = currentDate.Add(intervalle);
                    ligne1 = false; test = false;
                    ligneProcheComparaison = ligneProche;
                    Debug.WriteLine("\n\n");
                }
            }
        }


        private int RecupInitPers(DateTime currentDate)
        {
            List<string> contenuMemoire = File.ReadAllLines("CSV/memoire.csv").ToList();
            contenuMemoire = EnleverParam(contenuMemoire);
            contenuMemoire = Tri(contenuMemoire);
            int i = 0; int total = 0;
            while (i < contenuMemoire.Count && DateTime.Parse(contenuMemoire[i].Split(';')[0]) <= currentDate)
            {
                int nb = Convert.ToInt32(contenuMemoire[i].Split(';')[1]);
                total += nb;
                i++;
            }
            return total;
        }

        private List<int> RecupInitEve(DateTime currentDate, int taille)
        {
            List<string> contenuMemoire = File.ReadAllLines("CSV/memoire.csv").ToList();
            contenuMemoire = EnleverParam(contenuMemoire);
            contenuMemoire = Tri(contenuMemoire);
            int i = 0; List<int> total=new List<int>(); 
            for (int j=0; j<taille; j++) { total.Add(0); }
            while (i < contenuMemoire.Count && DateTime.Parse(contenuMemoire[i].Split(';')[0]) < currentDate)
            {
                for (int j = 0; j < taille; j++)
                {
                    string[] ligne = contenuMemoire[i].Split(';');
                    if ((2 + j) < ligne.Length - 1)
                    {
                        int nb = Convert.ToInt32(ligne[2 + j]);
                        total[j] = total[j] + nb;
                        if (total[j] != 0 && total[j] != 1) { total[j] = 0; }
                    }
                }
                i++;
            }
            return total;
        }

        private List<string> RecupEvenements()
        {
            List<string> contenuMemoire = File.ReadAllLines("CSV/memoire.csv").ToList();
            List<string> listeEve = new List<string>();
            for (int i = 0; i < contenuMemoire.Count; i++)
            {
                string[] ligneSplit = contenuMemoire[i].Split(';');
                if (ligneSplit[1] == "Date et heure ")
                {
                    //les evenements
                    for (int j = 3; j < ligneSplit.Length; j++)
                    {
                        //si pas déjà dans listeEve on l'ajoute
                        if (!listeEve.Contains(ligneSplit[j]) && ligneSplit[j] != "" && ligneSplit[j] != " ")
                        {
                            listeEve.Add(ligneSplit[j]);
                        }
                    }
                }
            }
            return listeEve;
        }

        private List<string> ListeEvenements(string ligneProche)
        {
            List<string> contenuMemoire = File.ReadAllLines("CSV/memoire.csv").ToList();
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
                    if (contenuMemoire[i]==ligneProche)
                    {
                        Fin = true;
                    }
                }
                i++;
            }
            string[] contenuLigne = dernierListeParametres.Split(";");
            List<string> evenements = new List<string>();
            for (int k = 3; k < contenuLigne.Length; k++)
            {
                evenements.Add(contenuLigne[k]);
                Debug.WriteLine("l'évenement numéro " + Convert.ToString(k - 2) + " est " + contenuLigne[k]);
            }
            Debug.WriteLine("Atteind la fin : " + Fin);
            return (evenements);
        }


        private (string,bool) LigneLaPlusProche(DateTime date)
        {
            //récupération de la mémoire
            List<string> contenuMemoire = File.ReadAllLines("CSV/memoire.csv").ToList();
            contenuMemoire = EnleverParam(contenuMemoire);
            contenuMemoire = Tri(contenuMemoire);

            for (int i = 0; i < contenuMemoire.Count; i++)
            {
                string dateligne = contenuMemoire[i].Split(';')[0];

                if (DateTime.Parse(dateligne) > date)
                {
                    if (i != 0)
                    {

                        //ligne d'avant
                        return (contenuMemoire[i - 1],false);

                    }
                    else
                    {

                        //ligne vide
                        return (contenuMemoire[i],true);

                    }
                }
            }
            //dernière ligne
            return (contenuMemoire[contenuMemoire.Count - 1],false);
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

        /// <summary>
        /// tri par date
        /// </summary>
        /// <param name="lignes"></param>
        /// <returns></returns>
        private List<string> Tri(List<string> lignes)
        {
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
    }
}
