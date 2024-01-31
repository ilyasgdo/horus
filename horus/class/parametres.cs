using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Classe Parametres qui permet de gérer les paramètres (ajout, suppression...)
/// </summary>
namespace horus.@class
{
    public class Parametres
    {
        private static List<Evenement> evenements;
        public static int nbpersonnes;

        public Parametres(Evenement evenement)
        {
            if (evenements == null)
            {
                evenements = new List<Evenement>();
            }
            evenements.Add(evenement);
        }

        public List<Evenement> ChargerEvenementsDepuisCSV()
        {
            string cheminFichierCSV = "../../../CSV/evenementss.csv";
            List<Evenement> listeEvenements = new List<Evenement>();

            try
            {
                if (File.Exists(cheminFichierCSV))
                {
                    
                    string[] lignes = File.ReadAllLines(cheminFichierCSV);

                    foreach (string ligne in lignes)
                    {
                        string[] elements = ligne.Split(';');

                        if (elements.Length >= 2)
                        {
                            string nomEvenement = elements[0].Trim();
                            bool etatEvenement = elements[1].Trim() == "1"; 

                            Evenement evenement = new Evenement(nomEvenement, etatEvenement);
                            listeEvenements.Add(evenement);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Erreur lors de la lecture du fichier CSV : {ex.Message}");
            }

            return listeEvenements;
        }
        public string GetEvenementsAsString()
        {
            List<string> nomsEvenements = new List<string>();

            foreach (Evenement evenement in evenements)
            {
                nomsEvenements.Add(evenement.getNom());
            }

            return string.Join(" ; ", nomsEvenements);
        }
        public Parametres()
        {
            if (evenements == null)
            {
                evenements = new List<Evenement>();
            }
        }

        public void Setnbpersonnes(int nb)
        {
            nbpersonnes = nb;
        }

        public int Getnbpersonnes()
        {
            return nbpersonnes;
        }

        public void AjouterEvenement(Evenement evenement)
        {
            evenements.Add(evenement);
        }

        public void SupprimerEvenement(Evenement evenement)
        {
            evenements.Remove(evenement);
        }

        public List<Evenement> getParametres()
        {
            return evenements;
        }

        public void InitParametres(List<Evenement> liste)
        {
            evenements = liste;
        }
    }
}
