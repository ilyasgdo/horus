using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace horus.@class
{
    internal class Evenements
    {
        private Dictionary<String, Evenement> evenements;

        public Evenements()
        {
            this.evenements = new Dictionary<String, Evenement>();
        }

        public void ajouterEvenement(String nom, DateTime date)
        {
            evenements.Add(nom, new Evenement(date));
        }

        public void supprimerEvenement(String nom)
        {
            evenements.Remove(nom);
        }

        public Evenement getEvenement(String nom)
        {
            if (evenements.ContainsKey(nom))
            {
                return evenements[nom];
            }
            return null;
        }
    }
}
