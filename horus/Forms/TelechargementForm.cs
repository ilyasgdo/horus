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
            //monthCalendarDebut.MaxDate = DateTime.Now;
            // monthCalendarFin.MaxDate = DateTime.Now;
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
                //fonction pour retrouver toutes les "Date Et Heure "et en faire la liste 
                List<string> NomsEvenements = RecupEvenements();
                string presentation = "Date et heure; nombre de personnes dans la pièce; ";
                for (int i = 0; i < NomsEvenements.Count; i++)
                {
                    presentation += NomsEvenements[i] + ";";
                }

                writer.WriteLine(presentation);

                DateTime currentDate = dateDebut;
                TimeSpan intervalle = TimeSpan.FromMinutes(5); //Debug.WriteLine("70");

                string ligneProche;
                string ligneProcheComparaison = "";
                string[] champsLigne;
                string nbPersonnes = "0";
                List<string> listeNomEvenement = new List<string>();
                List<bool> listeEtat = new List<bool>();
                List<string> creaLigne = new List<string>();
                bool ligne1 = true;

                while (currentDate <= dateFin)
                {
                    // Nina : methode "quelle est la ligne la plus proche" lapluus vielle mais 
                    string ligne = "";
                    ligneProche = LigneLaPlusProche(currentDate);
                    if (!ligne1)
                    {
                        if (ligneProche == ligneProcheComparaison)
                        {
                            creaLigne[0] = currentDate.ToString("dd/MM/yyyy HH:mm:ss") + ";";
                        }
                    }
                    else
                    {
                        //if (test == true) { Debug.WriteLine("la ligne trouvé est - " + ligneProche+" pour la date "+currentDate); }

                        //on récupère le nombre de personnes
                        champsLigne = ligneProche.Split(';');
                        if (ligne1) // ATTENTION SI PLUSIEUR MODIF DANS LA MEME PERIODE DE TEMPS
                        {
                            nbPersonnes = Convert.ToString(RecupInitPers(currentDate));
                        }
                        else
                        {
                            nbPersonnes = Convert.ToString(Convert.ToInt32(nbPersonnes) + champsLigne[1]);
                            Debug.WriteLine("!!!! ERREUR DE CONVERSION ? " + nbPersonnes + " = " + Convert.ToInt32(nbPersonnes) + " ?");
                        }
                        //if (test == true)
                        //{
                        //    Debug.Write("Ses champs sont :");
                        //    for (int i = 0; i < champsLigne.Length-1; i++) { Debug.Write(champsLigne[i] + " ; "); } Debug.Write("\n");
                        //}
                        //fonction pour trouver actuellement les evenements et leur etat (actif ou non)
                        listeNomEvenement.Clear();
                        listeEtat.Clear();
                        listeNomEvenement = ListeEvenements(currentDate); //Debug.WriteLine("85");
                                                                          //if (test == true)
                                                                          //{
                                                                          //    Debug.Write("Ses evenements sont :");
                                                                          //    for (int i = 0; i < listeNomEvenement.Count-1; i++) { Debug.Write(listeNomEvenement[i] + " ; "); }
                                                                          //    Debug.Write("\n");
                                                                          //}
                        for (int j = 2; j < champsLigne.Length; j++)
                        {
                            //if (test == true) { Debug.WriteLine("pour i = " + j + " on retrouve " + champsLigne[j]); }
                            if (champsLigne[j] == "1")
                            {
                                listeEtat.Add(true);
                            }
                            else
                            {
                                listeEtat.Add(false);
                            }
                        }
                        //if (test == true)
                        //{
                        //    Debug.Write("Ses valeurs sont :");
                        //    for (int i = 0; i < listeEtat.Count; i++) { Debug.Write(listeEtat[i] + " ; "); }
                        //    Debug.Write("\n");
                        //}
                        creaLigne.Add(currentDate.ToString("dd/MM/yyyy HH:mm:ss") + ";");
                        creaLigne.Add(nbPersonnes + ";");
                        //ligne = currentDate.ToString("dd/MM/yyyy HH:mm:ss")+";"+ nbPersonnes+";";
                        for (int i = 0; i < NomsEvenements.Count; i++)
                        {
                            //if (test == true) { Debug.Write("\nEvenement " + NomsEvenements[i]); }

                            //Debug.WriteLine("champ étudié" + NomsEvenements[i]+" (" + Convert.ToInt32(NomsEvenements[i])+")");
                            //if (listeNomEvenement.Contains(NomsEvenements[i]))
                            bool trouve = false;
                            for (int k = 0; k < listeNomEvenement.Count; k++)
                            {
                                //if (test == true) { Debug.Write("\n   " + listeNomEvenement[k]+" : "); }
                                //Debug.Write("champ Comparé" +  + " ; ");
                                //Debug.Write("champ Comparé" + listeNomEvenement[k]+" (" + Convert.ToInt32(listeNomEvenement[k]) + ") ; ");
                                if (listeNomEvenement[k] == NomsEvenements[i])
                                {
                                    //if (test == true) { Debug.Write("C'est le même champs"); }
                                    trouve = true;
                                    //Debug.WriteLine("\nchamp trouvé");
                                    if (k < listeEtat.Count && listeEtat[k] == true)
                                    {
                                        creaLigne.Add("1;");
                                        //ligne = ligne + "1;";
                                    }
                                    else
                                    {
                                        creaLigne.Add("0;");
                                        //ligne = ligne + "0;";
                                    }
                                }
                            }
                            if (trouve == false) { creaLigne.Add("0;"); }
                        }
                        //if (test == true) { Debug.WriteLine("la ligne totale est : " + ligne); test = false; }
                        //Debug.WriteLine("109");
                        //Ilyas 

                        // Récupérer le nombre de personnes du fichier de référence pour la date actuelle
                        /*int nbPersonnesReference = GetNombrePersonnesReference(currentDate);

                        // Générer la ligne du nouveau fichier en utilisant le nombre de personnes
                        string ligne = $"{currentDate.ToString("dd/MM/yyyy HH:mm:ss")};{nbPersonnesReference}";

                        // Ajouter les états des événements
                        foreach (Evenement evenement in parametres.ChargerEvenementsDepuisCSV())
                        {
                            ligne += $";{(evenement.isActif() ? "1" : "0")}";
                        }
                        */
                    }
                    for (int i = 0; i < creaLigne.Count; i++)
                    {
                        ligne = ligne + creaLigne[i];
                    }
                    writer.WriteLine(ligne);

                    currentDate = currentDate.Add(intervalle);
                    ligne1 = false;
                    ligneProcheComparaison = ligneProche;
                }
            }
        }

        private int RecupInitPers(DateTime currentDate)
        {
            List<string> contenuMemoire = File.ReadAllLines("../../../CSV/memoire.csv").ToList();
            contenuMemoire = EnleverParam(contenuMemoire);
            contenuMemoire = Tri(contenuMemoire);
            int i = 1; bool Fin = false; int total = Convert.ToInt32(contenuMemoire[0].Split(';')[1]);
            while (i < contenuMemoire.Count && Fin == false)
            {
                int nb = Convert.ToInt32(contenuMemoire[i].Split(';')[1]);
                Debug.WriteLine("!!!!! nb = " + nb);
                total += nb;
                if (DateTime.Parse(contenuMemoire[i + 1].Split(';')[1]) > currentDate)
                {
                    Fin = true;
                }
                i++;
            }
            return total;
        }

        private List<string> RecupEvenements()
        {
            List<string> contenuMemoire = File.ReadAllLines("../../../CSV/memoire.csv").ToList();
            List<string> listeEve = new List<string>();
            for (int i = 0; i < contenuMemoire.Count; i++)
            {
                //Debug.WriteLine("a");
                string[] ligneSplit = contenuMemoire[i].Split(';');
                //Debug.WriteLine(contenuMemoire[i]);
                if (ligneSplit[1] == "Date et heure ")
                {
                    //les evenements
                    for (int j = 3; j < ligneSplit.Length; j++)
                    {
                        //Debug.Write(ligneSplit[j]);
                        //si pas déjà dans listeEve on l'ajoute
                        if (!listeEve.Contains(ligneSplit[j]) && ligneSplit[j] != "" && ligneSplit[j] != " ")
                        {
                            listeEve.Add(ligneSplit[j]);
                            //Debug.WriteLine(ligneSplit[j]+" - "+);
                        }
                    }
                }
            }
            return listeEve;
        }

        private List<string> ListeEvenements(DateTime dateActu)
        {
            List<string> contenuMemoire = File.ReadAllLines("../../../CSV/memoire.csv").ToList();
            contenuMemoire = Tri(contenuMemoire);
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
                    DateTime date = DateTime.Parse(contenuMemoire[i].Split(';')[0]);
                    if (date > dateActu)
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
            }
            return (evenements);
        }


        /*
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
        */

        private string LigneLaPlusProche(DateTime date)
        {
            //récupération de la mémoire
            List<string> contenuMemoire = File.ReadAllLines("../../../CSV/memoire.csv").ToList();
            contenuMemoire = EnleverParam(contenuMemoire);
            contenuMemoire = Tri(contenuMemoire);
            //for(int i=0; i<contenuMemoire.Count; i++)
            //{
            //if (test == true) { Debug.WriteLine("\n");}
            //}

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

        private List<string> EnleverParam(List<string> lignes)
        {
            int nbligne = lignes.Count;
            //enleve les ligne qui ne servent pas 
            for (int i = 0; i < nbligne; i++)
            {
                if (lignes[i].Split(';')[1] == "Date et heure ")
                {
                    lignes.Remove(lignes[i]);
                    nbligne--;
                }

            }
            return lignes;
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

    }
}
