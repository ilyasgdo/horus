using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using horus.@class;

namespace horus.Forms
{
    public partial class PersonneEntreeSortieForm : Form
    {
        int nombrePersonnes;
        private bool entree;
        string fichierCSVPers = "../../../CSV/personnes.csv";
        List<string> contenu;

        public PersonneEntreeSortieForm(int nombrePersonnes, bool entree)
        {
            InitializeComponent();
            this.nombrePersonnes = nombrePersonnes;
            this.entree = entree;

            DateTime now = DateTime.Now;
            cbHeurePersonne.SelectedItem = now.ToString("HH");
            cbMinutePersonne.SelectedItem = now.ToString("mm");

            CreerFichierCSV(fichierCSVPers);
            contenu = ChargerFichier();
        }

        private List<string> ChargerFichier()
        {
            // Charger la liste d'événements depuis le fichier CSV
            try
            {
                if (File.Exists(fichierCSVPers))
                {
                    return File.ReadAllLines(fichierCSVPers)
                        .Select(line => line.Split(';')[0])
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erreur lors du chargement des événements : {ex.Message}");
            }

            return new List<string>();
        }

        private void btnValiderPersonne_Click(object sender, EventArgs e)
        {
            if (entree)
            {
                nombrePersonnes++;
                //changer le contenu du csv
                contenu.Clear(); contenu.Add(nombrePersonnes.ToString());
                Sauvegarder();
                Parametres parametres = new Parametres();
                parametres.Setnbpersonnes(nombrePersonnes);
                string strDateEtHeure = DateTime.Now.ToString("dd/MM/yyyy") +" "+cbHeurePersonne.SelectedItem+":"+cbMinutePersonne.SelectedItem;
                DateTime DateEtHeure = DateTime.Parse(strDateEtHeure);
                Modification modif = new Modification(DateEtHeure, parametres);

            }
            else
            {
                if (nombrePersonnes > 0)
                {
                    nombrePersonnes--;
                    contenu.Clear(); contenu.Add(nombrePersonnes.ToString());
                    Sauvegarder();
                    Parametres parametres = new Parametres();
                    parametres.Setnbpersonnes(nombrePersonnes);
                    string strDateEtHeure = DateTime.Now.ToString("dd/MM/yyyy") + " " + cbHeurePersonne.SelectedItem + ":" + cbMinutePersonne.SelectedItem;
                    DateTime DateEtHeure = DateTime.Parse(strDateEtHeure);
                    Modification modif = new Modification(DateEtHeure,parametres);
                }
                else
                {
                    MessageBox.Show("Il n'y a personne à faire sortir", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.Close();
        }

        private void Sauvegarder()
        {
            try
            {
                // Enregistrer la liste d'événements dans le fichier CSV
                File.WriteAllLines(fichierCSVPers, contenu.Select(ev => $"{ev}"));
                Debug.WriteLine("Événements sauvegardés avec succès dans le fichier CSV.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erreur lors de la sauvegarde des événements : {ex.Message}");
            }
        }

        private void CreerFichierCSV(string cheminFichier)
        {
            try
            {
                // Crée le fichier s'il n'existe pas
                if (!File.Exists(cheminFichier))
                {
                    File.WriteAllText(cheminFichier, "");
                    Debug.WriteLine("Fichier CSV créé avec succès.");
                }
                else
                {
                    Debug.WriteLine("Le fichier CSV existe déjà.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erreur lors de la création ou vérification du fichier CSV : {ex.Message}");
            }
        }
    }
}
