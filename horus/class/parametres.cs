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
        private static List<Evenement> evenements;

        public Parametres(Evenement evenement)
        {
            if (evenements == null)
            {
                evenements = new List<Evenement>();
            }
            evenements.Add(evenement);
        }

        public Parametres()
        {
            if (evenements == null)
            {
                evenements = new List<Evenement>();
            }
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

    }
}
