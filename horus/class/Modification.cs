using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace horus.@class
{
    public class Modification
    {
        private DateTime dateEtHeure;
        private int nbPersonnesPrésentes;
        private Parametres param;
        private string fichierCSV = "../../../CSV/memoire.csv";
        private List<string> contenuCSV = new List<string>();
        private static int nbEvenement;

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

        private void CreerFichierCSV(string fichier)
        {
            try
            {
                // Crée le fichier s'il n'existe pas
                if (!File.Exists(fichier))
                {
                    File.WriteAllText(fichier, "");
                    CreerLigneDebut();
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
            if (listeEvenements.Count != nbEvenement)
            {
                CreerLigneDebut();
            }
            string nvModification = Convert.ToString(dateEtHeure) + ";" + Convert.ToString(nbPersonnesPrésentes) + ";";
            for (int i = 0; i < listeEvenements.Count; i++)
            {
                bool EveActif = listeEvenements[i].isActif();
                if (EveActif == true) {
                    nvModification = nvModification + "1;";
                }
                else { 
                    nvModification = nvModification + "0;";
                }
                
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

        private void CreerLigneDebut()
        {
            //récupère le contenu du fichier
            contenuCSV = ChargerContenu();

            string ligne = "Date et heure ; nombre de personnes dans la pièce ; ";
            List<Evenement> listeEvenements = param.getParametres();
            nbEvenement = listeEvenements.Count();
            for (int i = 0; i < listeEvenements.Count; i++)
            {
                ligne= ligne + listeEvenements[i].getNom()+" ; ";
            }
            contenuCSV.Add(ligne);
            SauvegarderModifs();
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
