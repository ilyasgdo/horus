using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace horus.@class
{
    internal class Evenement
    {

        private DateTime date;
        private int compteur;

        public Evenement(DateTime date)
        {
            this.date = date;
            this.compteur = 0;
        }

        public void debut()
        {
            this.compteur++;
        }

        public void fin()
        {
            this.compteur--;
        }


    }
}
