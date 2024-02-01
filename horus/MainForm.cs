using horus.@class;
using horus.Forms;
using Microsoft.VisualBasic;
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
            //tick pour warnig
            System.Windows.Forms.Timer timer10Minutes = new System.Windows.Forms.Timer();
            timer10Minutes.Interval = 1000;
            timer10Minutes.Tick += Timer10Minutes_Tick;
            timer10Minutes.Start();

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
            personneEntreeSortie.FormClosed += PersonneEntreeSortie_FormClosed;
            open_Click(personneEntreeSortie);
        }

        private void btnPersonneSortie_Click(object sender, EventArgs e)
        {
            PersonneEntreeSortieForm personneEntreeSortie = new PersonneEntreeSortieForm(parametre.Getnbpersonnes(), false);
            personneEntreeSortie.FormClosed += PersonneEntreeSortie_FormClosed;
            open_Click(personneEntreeSortie);
        }

        private void PersonneEntreeSortie_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Appelé lorsque le formulaire PersonneEntreeSortieForm est fermé
            actualiser_label();
            UpdateLabelEvenement();
            CheckAndRecordWarnings();
        }


        private void btnEvenementAjout_Click(object sender, EventArgs e)
        {
            EvenementEntreeSortieForm evenementEntreeSortie = new EvenementEntreeSortieForm(parametre.Getnbpersonnes(), true);
            evenementEntreeSortie.FormClosed += evenementEntreeSortie_FormClosed;
            open_Click(evenementEntreeSortie);
        }

        private void btnEvenementSuppression_Click(object sender, EventArgs e)
        {
            EvenementEntreeSortieForm evenementEntreeSortie = new EvenementEntreeSortieForm(parametre.Getnbpersonnes(), false);
            evenementEntreeSortie.FormClosed += evenementEntreeSortie_FormClosed;
            open_Click(evenementEntreeSortie);
        }

        private void evenementEntreeSortie_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Appelé lorsque le formulaire PersonneEntreeSortieForm est fermé
            actualiser_label();
            UpdateLabelEvenement();
            CheckAndRecordWarnings();
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


            int nbPersonnesPremierFichier = GetNombrePersonnesReference();
            lblNbPersonnes.Text = $"Nombre de personnes : {nbPersonnesPremierFichier}";
            CheckAndRecordWarnings();

        }

        public List<string> GetEvenementsActifs()
        {
            List<string> evenementsActifs = new List<string>();

            try
            {
                string cheminFichierCSV = "../../../CSV/evenementss.csv";

                if (File.Exists(cheminFichierCSV))
                {

                    List<string> lignes = File.ReadAllLines(cheminFichierCSV).ToList();

                    foreach (string ligne in lignes)
                    {
                        string[] elements = ligne.Split(';');

                        if (elements.Length >= 2)
                        {
                            string nomEvenement = elements[0].Trim();
                            bool etatEvenement = elements[1].Trim() == "1";

                            if (etatEvenement)
                            {
                                evenementsActifs.Add($"{nomEvenement}");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Le fichier CSV n'existe pas.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la lecture du fichier CSV : {ex.Message}");
            }

            return evenementsActifs;
        }

        
        public void UpdateLabelEvenement()
        {
            CheckAndRecordWarnings();

            try
            {

                List<string> evenementsActifs = GetEvenementsActifs();


                labelEvent.Text = "Événements actifs :\n";

                foreach (string evenement in evenementsActifs)
                {
                    labelEvent.Text += $"{evenement}\n";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la mise à jour du label des événements : {ex.Message}");
            }
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            actualiser_label();
            UpdateLabelEvenement();
            CheckAndRecordWarnings();
        }
        private void RecordOrUpdateWarning(DateTime dateTime, int nbPersonnes)
        {
            try
            {
                string cheminFichierAvertissements = "../../../CSV/avertissements.csv";

                // Charger les alertes existantes
                List<string> alertes = ChargerAlertes();

                // Vérifier s'il y a déjà une alerte pour la même journée
                string dateHeureFormattee = dateTime.ToString("dd/MM/yyyy");
                bool alerteExistante = false;

                for (int i = 0; i < alertes.Count; i++)
                {
                    string[] elements = alertes[i].Split(';');

                    if (elements.Length >= 2)
                    {
                        string dateHeure = elements[0].Trim();

                        if (dateHeure.StartsWith(dateHeureFormattee))
                        {
                            // Il y a déjà une alerte pour la même journée, supprimer l'ancienne
                            alertes.RemoveAt(i);
                            alerteExistante = true;
                            break;
                        }
                    }
                }

                // Ajouter la nouvelle alerte
                string ligneAvertissement = $"{dateTime.ToString("dd/MM/yyyy HH:mm:ss")};{nbPersonnes}";
                alertes.Add(ligneAvertissement);

                // Écrire les alertes mises à jour dans le fichier CSV
                File.WriteAllLines(cheminFichierAvertissements, alertes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'enregistrement ou de la mise à jour de l'avertissement : {ex.Message}");
            }
        }

        // Utilisez cette méthode dans votre code pour enregistrer ou mettre à jour une alerte
        private void CheckAndRecordWarnings()
        {
            DateTime currentDateTime = DateTime.Now;

            if (currentDateTime.Hour >= 13 && currentDateTime.Minute >= 48 )
            {
                int nbPersonnesActuel = GetNombrePersonnesReference();

                if (nbPersonnesActuel != 0)
                {
                    RecordOrUpdateWarning(currentDateTime, nbPersonnesActuel);

                   
                }
            }

            // Affichez les alertes mises à jour
            List<string> alertes = ChargerAlertes();
            AfficherAlertes(alertes);
        }



        private void Timer10Minutes_Tick(object sender, EventArgs e)
        {
            CheckAndRecordWarnings();
            UpdateLabelEvenement();
        }

        
        private List<string> ChargerAlertes()
        {
            try
            {
                string cheminFichierAvertissements = "../../../CSV/avertissements.csv";

                if (File.Exists(cheminFichierAvertissements))
                {
                    return File.ReadAllLines(cheminFichierAvertissements).ToList();
                }
                return new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la lecture du fichier CSV d'alertes : {ex.Message}");
                return new List<string>();
            }
        }

        private void AfficherAlertes(List<string> alertes)
        {
            StringBuilder alertesText = new StringBuilder();

            foreach (string alerte in alertes)
            {
                string[] elements = alerte.Split(';');

                if (elements.Length >= 2)
                {
                    string dateHeure = elements[0].Trim();
                    int nbPersonnes = int.Parse(elements[1].Trim());

                    // Vérifiez si l'alerte est toujours valide (moins d'un jour depuis la création)
                    DateTime dateAvertissement = DateTime.ParseExact(dateHeure, "dd/MM/yyyy HH:mm:ss", null);
                    if ((DateTime.Now - dateAvertissement).TotalDays < 1)
                    {
                        alertesText.AppendLine($"Avertissement ({dateHeure}) : {nbPersonnes} personne(s)");
                    }
                }
            }

            labelAlertes.ForeColor = Color.Red;
            labelAlertes.Text = alertesText.ToString();
        }

        private void BtnSupprimerAlerte_Click(object sender, EventArgs e)
        {
            try
            {
                string cheminFichierAvertissements = "../../../CSV/avertissements.csv";

              
                File.WriteAllText(cheminFichierAvertissements, string.Empty);

               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la suppression du contenu du fichier CSV d'alertes : {ex.Message}");
            }
        }



    }
}
