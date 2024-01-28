using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void ajouterEvenement(String nom)
        {
            if (evenements.Contains("Personne"))
            {
                return;
            }
            evenements.Add(nom);
        }

        public void supprimerEvenement(String nom)
        {
            if (evenements.Contains("Personne"))
            {
                return;
            }
            evenements.Remove(nom);
        }
    }
}
