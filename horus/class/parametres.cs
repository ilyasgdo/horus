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
    internal class Parametres
    {
        private List<String> evenements;

        public Parametres()
        {
            this.evenements = new List<String>();
            evenements.Add("Personne");
        }

        public void AjouterEvenement(String nom)
        {
            if (evenements.Contains("Personne"))
            {
                return;
            }
            evenements.Add(nom);
        }

        public void SupprimerEvenement(String nom)
        {
            if (evenements.Contains("Personne"))
            {
                return;
            }
            evenements.Remove(nom);
        }
    }
}
