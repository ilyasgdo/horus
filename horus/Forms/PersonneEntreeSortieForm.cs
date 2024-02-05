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
        string fichierCSVPers = "CSV/personnes.csv";
        List<string> contenu;
        public bool DateModif;

        public PersonneEntreeSortieForm(int nombrePersonnes, bool entree)
        {
            InitializeComponent();
            this.nombrePersonnes = nombrePersonnes;
            this.entree = entree;
            this.DateModif = false;

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
            Parametres parametres = new Parametres();
            string dateDuJour;
            if (DateModif == true)
            {
                dateDuJour = parametres.GetDate().ToString("dd/MM/yyyy");
            }
            else
            {
                dateDuJour = DateTime.Now.ToString("dd/MM/yyyy");
            }
            string strDateEtHeure = dateDuJour + " " + cbHeurePersonne.SelectedItem + ":" + cbMinutePersonne.SelectedItem;
            DateTime DateEtHeure = DateTime.Parse(strDateEtHeure);
            int nbPersonnes = RecupInitPers(DateEtHeure);
            bool NonValide = entree == false && nbPersonnes == 0;
            if (NonValide)
            {
                MessageBox.Show("Il n'y a personne de présent à ce moment", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (entree)
                {
                    nombrePersonnes++;
                    //changer le contenu du csv
                    contenu.Clear(); contenu.Add(nombrePersonnes.ToString());
                    Sauvegarder();
                    parametres.Setnbpersonnes(nombrePersonnes);
                    Modification modif = new Modification(DateEtHeure, parametres);

                }
                else
                {
                    if (nombrePersonnes > 0)
                    {
                        nombrePersonnes--;
                        contenu.Clear(); contenu.Add(nombrePersonnes.ToString());
                        Sauvegarder();
                        parametres.Setnbpersonnes(nombrePersonnes);
                        Modification modif = new Modification(DateEtHeure, parametres);
                    }
                    else
                    {
                        MessageBox.Show("Il n'y a personne à faire sortir", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            this.Close();
        }

        private int RecupInitPers(DateTime currentDate)
        {
            List<string> contenuMemoire = File.ReadAllLines("CSV/memoire.csv").ToList();
            contenuMemoire = EnleverParam(contenuMemoire);
            contenuMemoire = Tri(contenuMemoire);
            int i = 1; bool Fin = false; int total = 0;
            if (contenuMemoire.Count!=0) { total = Convert.ToInt32(contenuMemoire[0].Split(';')[1]); } 
            while (i < contenuMemoire.Count && Fin == false)
            {
                Debug.WriteLine("A la ligne " + contenuMemoire[i]);
                int nb = Convert.ToInt32(contenuMemoire[i].Split(';')[1]);
                Debug.WriteLine("!!!!! nb = " + nb);
                total += nb;
                if (i+1 >= contenuMemoire.Count || DateTime.Parse(contenuMemoire[i + 1].Split(';')[0]) > currentDate)
                {
                    Fin = true;
                }
                i++;
            }
            return total;
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

        private List<string> EnleverParam(List<string> lignes)
        {
            List<string> listModification = new List<string>();
            int nbligne = lignes.Count;
            //enleve les ligne qui ne servent pas 
            for (int i = 0; i < nbligne; i++)
            {
                if (lignes[i].Split(';')[1] != "Date et heure ")
                {
                    listModification.Add(lignes[i]);
                }

            }
            return listModification;
        }

        private List<string> Tri(List<string> lignes)
        {
            //tri par date
            for (int i = lignes.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    DateTime date1 = DateTime.Parse(lignes[j].Split(';')[0]);
                    DateTime date2 = DateTime.Parse(lignes[j + 1].Split(';')[0]);
                    if (date1 > date2)
                    {
                        string intermediaire = lignes[j];
                        lignes[j] = lignes[j + 1];
                        lignes[j + 1] = intermediaire;
                    }
                }
            }
            return lignes;
        }

        private void pctboxDate_Click(object sender, EventArgs e)
        {
            DateModif = true;
            Date formDate = new Date();
            open_Click(formDate);
        }

        private void open_Click(Form form)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == form.Text)
                {
                    isOpen = true;
                    f.Focus();
                }
            }
            if (!isOpen)
            {
                form.Show();
            }
        }
    }
}
