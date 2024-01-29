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
        private List<Evenement> evenements;

        public Parametres(Evenement evenement)
        {
            this.evenements = new List<Evenement>();
            evenements.Add(evenement);
        }

        public Parametres()
        {
            this.evenements = new List<Evenement>();
        }

        public void AjouterEvenement(Evenement evenement)
        {
            evenements.Add(evenement);
        }

        public void SupprimerEvenement(Evenement evenement)
        {
            evenements.Remove(evenement);
        }
    }
}
