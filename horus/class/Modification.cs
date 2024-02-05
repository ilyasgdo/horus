using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace horus.@class
{
    public class Modification
    {
        private DateTime dateEtHeure;
        private static int nbPersComparaison = 1000;
        private int nbPersonnesPrésentes;
        private Parametres param;
        private string fichierCSV = "CSV/memoire.csv";
        private List<string> contenuCSV = new List<string>();

        public Modification(Parametres para)
        {
            this.dateEtHeure = DateTime.Now;
            this.nbPersonnesPrésentes = para.Getnbpersonnes();
            this.param = para;
            EcritureCSV();
        }

        public Modification(DateTime temps, Parametres para)
        {
            this.dateEtHeure = temps;
            this.nbPersonnesPrésentes = para.Getnbpersonnes();
            this.param = para;
            EcritureCSV();
        }
        public Modification(int nb, Parametres para)
        {
            if (nbPersComparaison == 1000) { nbPersComparaison = nb; }
        }

        private void CreerFichierCSV(string fichier)
        {
            try
            {
                // Crée le fichier s'il n'existe pas
                if (!File.Exists(fichier))
                {
                    File.WriteAllText(fichier, "");
                    string premiereLigne=CreerLigneDebut();
                    contenuCSV = ChargerContenu();
                    contenuCSV.Add(premiereLigne);
                    SauvegarderModifs();
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

        private List<string> ChargerContenu()
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

        private string CreerLigneModification()
        {
            List<Evenement> listeEvenements = param.getParametres();
            List<Evenement> listeEvenementsComparaison = param.getParametresComp();
            string nvModification="";
            if (listeEvenements.Count != param.GetNbEvenement())
            {
                nvModification=CreerLigneDebut();
                param.SetNbEvenement(listeEvenements.Count);
            }
            else
            {
                string personnes = Convert.ToString(nbPersonnesPrésentes - nbPersComparaison);
                nbPersComparaison = nbPersonnesPrésentes;
                nvModification = Convert.ToString(dateEtHeure) + ";" + personnes + ";";
                for (int i = 0; i < listeEvenements.Count; i++)
                {
                    bool EveActif = listeEvenements[i].isActif();
                    bool EveActifComp = listeEvenementsComparaison[i].isActif();
                    Debug.WriteLine("Comparatif " + EveActif + " l'etat de " + listeEvenements[i] + " et " + EveActifComp + " l'état de " + listeEvenementsComparaison[i]);
                    if (EveActif == EveActifComp)
                    {
                        nvModification = nvModification + "0;";
                    }
                    else
                    {
                        if (EveActif==true && EveActifComp==false)
                        {
                            nvModification = nvModification + "1;";
                        }
                        else
                        {
                            nvModification = nvModification + "-1;";
                        }
                    }
                }
                param.InitParametresComp();
            }
            return nvModification;
        }

        private void SauvegarderModifs()
        {
            try
            {
                // Enregistrer la liste d'événements dans le fichier CSV
                File.WriteAllLines(fichierCSV, contenuCSV);
                Debug.WriteLine("Événements sauvegardés avec succès dans le fichier CSV.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erreur lors de la sauvegarde des événements : {ex.Message}");
            }
        }

        private string CreerLigneDebut()
        {
            //récupère le contenu du fichier
            contenuCSV = ChargerContenu();

            string ligne = Convert.ToString(DateTime.Now) + ";Date et heure ; nombre de personnes dans la pièce ;";
            List<Evenement> listeEvenements = param.getParametres();
            for (int i = 0; i < listeEvenements.Count; i++)
            {
                ligne = ligne + listeEvenements[i].getNom() + " ;";
            }
            return ligne;
        }

        private void EcritureCSV()
        {
            // Vérifie si le fichier CSV existe, sinon le crée
            CreerFichierCSV(fichierCSV);

            //récupère le contenu du fichier
            contenuCSV = ChargerContenu();

            //crée la nouvelle ligne à y ajouter
            string nvModif = CreerLigneModification();

            contenuCSV.Add(nvModif);
            SauvegarderModifs();
        }
    }
}
