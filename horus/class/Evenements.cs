using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Clase Evenements qui permet de gérer les événements (ajout, suppression)
/// </summary>
namespace horus.@class
{
    public class Evenements
    {
        private Dictionary<String, Evenement> evenements;

        public Evenements()
        {
            this.evenements = new Dictionary<String, Evenement>();
        }

        public void AjouterEvenement(String nom, Evenement evenement)
        {
            if (evenements.ContainsKey(nom))
            {
                evenements[nom] = evenement;
            }
            else
            {
                evenements.Add(nom, evenement);
            }
        }

        public void SupprimerEvenement(String nom)
        {
            evenements.Remove(nom);
        }

        public Evenement GetEvenement(String nom)
        {
            if (evenements.ContainsKey(nom))
            {
                return evenements[nom];
            }
            return null;
        }
    }
}
