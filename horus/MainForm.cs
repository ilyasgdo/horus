﻿using horus.@class;
using horus.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace horus
{
    public partial class MainForm : Form
    {
        private const string fichierCSVEve = "../../../CSV/evenementss.csv";
        private const string fichierCSVPers = "../../../CSV/personnes.csv";
        public Parametres parametre = new Parametres();

        public MainForm()
        {
            InitializeComponent();

            // Initialisation du Timer
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Intervalle en millisecondes (une seconde)
            timer.Tick += (sender, e) => lblHeure.Text = DateTime.Now.ToString("HH:mm:ss");
            timer.Start();

            // Appel initial pour mettre à jour l'heure dès le démarrage
            lblHeure.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            //Récupération de la mémoire 
            List<String> listeEvenements = ChargerEvenements();
            List<String> listePersonnes = ChargerPersonnes();
            int nbPersonnesPresentent = 0;
            if (listePersonnes.Count > 0)
            {
                nbPersonnesPresentent = Convert.ToInt32(listePersonnes[0], 10);
            }
            parametre.Setnbpersonnes(nbPersonnesPresentent);
            parametre.SetNbEvenement(listeEvenements.Count);
            for (int i = 0; i < listeEvenements.Count; i++)
            {
                string[] ligne = listeEvenements[i].Split(';');
                bool activite;
                if (ligne[1] == "0") { activite = false; } else { activite = true; }
                Evenement evenementi = new Evenement(ligne[0], activite);
                parametre.AjouterEvenement(evenementi);
            }
            actualiser_label();


            // test!!!!!!!!!!!!!!!!!!!!!!!
            //Modification test1 = new Modification(3,parametre);
            //Modification test2 = new Modification(4,parametre);
        }


        private List<string> ChargerEvenements()
        {
            // Charger la liste d'événements depuis le fichier CSV
            if (File.Exists(fichierCSVEve))
            {
                return File.ReadAllLines(fichierCSVEve).ToList();
            }
            return new List<string>();
        }

        private List<string> ChargerPersonnes()
        {
            try
            {
                // Crée le fichier s'il n'existe pas
                if (!File.Exists(fichierCSVPers))
                {
                    File.WriteAllText(fichierCSVPers, "");
                    Debug.WriteLine("Fichier CSV créé avec succès.");
                }
                else
                {
                    Debug.WriteLine("Le fichier CSV existe déjà.");
                }
                return File.ReadAllLines(fichierCSVPers).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erreur lors de la création ou vérification du fichier CSV : {ex.Message}");
                return new List<string>();
            }

        }

        private void btnPersonneEntree_Click(object sender, EventArgs e)
        {
            PersonneEntreeSortieForm personneEntreeSortie = new PersonneEntreeSortieForm(parametre.Getnbpersonnes(), true);
            personneEntreeSortie.FormClosed += PersonneEntreeSortie_FormClosed; // Ajoutez cette ligne
            open_Click(personneEntreeSortie);
        }

        private void btnPersonneSortie_Click(object sender, EventArgs e)
        {
            PersonneEntreeSortieForm personneEntreeSortie = new PersonneEntreeSortieForm(parametre.Getnbpersonnes(), false);
            personneEntreeSortie.FormClosed += PersonneEntreeSortie_FormClosed; // Ajoutez cette ligne
            open_Click(personneEntreeSortie);
        }

        private void PersonneEntreeSortie_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Appelé lorsque le formulaire PersonneEntreeSortieForm est fermé
            actualiser_label();
        }


        private void btnEvenementAjout_Click(object sender, EventArgs e)
        {
            EvenementEntreeSortieForm evenementEntreeSortie = new EvenementEntreeSortieForm(parametre.Getnbpersonnes(), true);
            open_Click(evenementEntreeSortie);
        }

        private void btnEvenementSuppression_Click(object sender, EventArgs e)
        {
            EvenementEntreeSortieForm evenementEntreeSortie = new EvenementEntreeSortieForm(parametre.Getnbpersonnes(), false);
            open_Click(evenementEntreeSortie);
        }

        private void picTelechargement_Click(object sender, EventArgs e)
        {
            TelechargementForm telechargement = new TelechargementForm();
            open_Click(telechargement);
            
        }

        private void picParametres_Click(object sender, EventArgs e)
        {
            ParametresForm parametres = new ParametresForm();
            open_Click(parametres);
            
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
        // Méthode pour obtenir le nombre de personnes du fichier
        private int GetNombrePersonnesReference()
        {
            try
            {
                string cheminFichierCSV = "../../../CSV/personnes.csv";

                if (File.Exists(cheminFichierCSV))
                {
                    List<string> referenceLines = File.ReadAllLines(cheminFichierCSV).ToList();

                    if (referenceLines.Count > 0)
                    {
                        return int.Parse(referenceLines[0].Split(';')[0]);
                    }
                    else
                    {
                        Console.WriteLine("Le fichier CSV est vide.");
                        return 0;
                    }
                }
                else
                {
                    Console.WriteLine("Le fichier CSV n'existe pas.");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la lecture du fichier CSV : {ex.Message}");
                return 0;
            }
        }




        private void actualiser_label()
        {

            // Mise à jour du label avec le nombre de personnes du premier fichier CSV
            int nbPersonnesPremierFichier = GetNombrePersonnesReference();
            lblNbPersonnes.Text = $"Nombre de personnes : {nbPersonnesPremierFichier}";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            actualiser_label();
        }
    }
}
