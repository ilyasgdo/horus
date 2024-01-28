using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Classe Evenement qui permet d'utiliser les événements dans les forms
namespace horus.@class
{
    public class Evenement
    {

        private DateTime date;
        private int compteur;

        public Evenement()
        {
            this.date = new DateTime();
            this.compteur = 0;
        }

        public void Debut()
        {
            this.compteur++;
        }

        public void Fin()
        {
            this.compteur--;
        }

        public DateTime SetDateTime()
        {
            return this.date;
        }

        public void SetDateTime(DateTime date)
        {
            this.date = date;
        }

    }
}
