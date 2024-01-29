using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Classe Evenement qui permet d'utiliser les événements dans les forms
/// </summary>
namespace horus.@class
{
    public class Evenement
    {

        String nom;
        bool actif;

        public Evenement(string nom)
        {
            this.nom = nom;
            this.actif = false;
        }
    }
}
