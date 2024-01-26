namespace horus
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            btnPersonneEntree = new Button();
            btnPersonneSortie = new Button();
            btnEvenementAjout = new Button();
            btnEvenementSuppression = new Button();
            picLogo = new PictureBox();
            picParametres = new PictureBox();
            picTelechargement = new PictureBox();
            lblDate = new Label();
            lblHeure = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picParametres).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picTelechargement).BeginInit();
            SuspendLayout();
            // 
            // btnPersonneEntree
            // 
            btnPersonneEntree.BackColor = Color.PaleTurquoise;
            btnPersonneEntree.Font = new Font("Sans Serif Collection", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPersonneEntree.ForeColor = SystemColors.ControlText;
            btnPersonneEntree.Location = new Point(153, 147);
            btnPersonneEntree.Name = "btnPersonneEntree";
            btnPersonneEntree.Size = new Size(150, 86);
            btnPersonneEntree.TabIndex = 0;
            btnPersonneEntree.Text = "Une personne est entrée";
            btnPersonneEntree.UseVisualStyleBackColor = false;
            btnPersonneEntree.Click += btnPersonne_Click;
            // 
            // btnPersonneSortie
            // 
            btnPersonneSortie.BackColor = Color.PaleTurquoise;
            btnPersonneSortie.Font = new Font("Sans Serif Collection", 9F);
            btnPersonneSortie.Location = new Point(475, 147);
            btnPersonneSortie.Name = "btnPersonneSortie";
            btnPersonneSortie.Size = new Size(150, 86);
            btnPersonneSortie.TabIndex = 1;
            btnPersonneSortie.Text = "Une personne est sortie";
            btnPersonneSortie.UseVisualStyleBackColor = false;
            btnPersonneSortie.Click += btnPersonne_Click;
            // 
            // btnEvenementAjout
            // 
            btnEvenementAjout.BackColor = Color.PaleTurquoise;
            btnEvenementAjout.Font = new Font("Sans Serif Collection", 9F);
            btnEvenementAjout.Location = new Point(153, 297);
            btnEvenementAjout.Name = "btnEvenementAjout";
            btnEvenementAjout.Size = new Size(150, 86);
            btnEvenementAjout.TabIndex = 2;
            btnEvenementAjout.Text = "Ajouter un évènement";
            btnEvenementAjout.UseVisualStyleBackColor = false;
            btnEvenementAjout.Click += btnEvenement_Click;
            // 
            // btnEvenementSuppression
            // 
            btnEvenementSuppression.BackColor = Color.PaleTurquoise;
            btnEvenementSuppression.Font = new Font("Sans Serif Collection", 9F);
            btnEvenementSuppression.Location = new Point(475, 297);
            btnEvenementSuppression.Name = "btnEvenementSuppression";
            btnEvenementSuppression.Size = new Size(150, 86);
            btnEvenementSuppression.TabIndex = 3;
            btnEvenementSuppression.Text = "Supprimer un évènement";
            btnEvenementSuppression.UseVisualStyleBackColor = false;
            btnEvenementSuppression.Click += btnEvenement_Click;
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(30, 12);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(153, 118);
            picLogo.TabIndex = 4;
            picLogo.TabStop = false;
            // 
            // picParametres
            // 
            picParametres.BackColor = SystemColors.Control;
            picParametres.Image = (Image)resources.GetObject("picParametres.Image");
            picParametres.Location = new Point(705, 29);
            picParametres.Name = "picParametres";
            picParametres.Size = new Size(56, 51);
            picParametres.SizeMode = PictureBoxSizeMode.StretchImage;
            picParametres.TabIndex = 5;
            picParametres.TabStop = false;
            picParametres.Click += picParametres_Click;
            // 
            // picTelechargement
            // 
            picTelechargement.BackColor = SystemColors.Control;
            picTelechargement.Image = (Image)resources.GetObject("picTelechargement.Image");
            picTelechargement.Location = new Point(637, 29);
            picTelechargement.Name = "picTelechargement";
            picTelechargement.Size = new Size(50, 51);
            picTelechargement.SizeMode = PictureBoxSizeMode.StretchImage;
            picTelechargement.TabIndex = 6;
            picTelechargement.TabStop = false;
            picTelechargement.Click += picTelechargement_Click;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(353, 55);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(31, 15);
            lblDate.TabIndex = 7;
            lblDate.Text = "Date";
            // 
            // lblHeure
            // 
            lblHeure.AutoSize = true;
            lblHeure.Location = new Point(422, 55);
            lblHeure.Name = "lblHeure";
            lblHeure.Size = new Size(39, 15);
            lblHeure.TabIndex = 8;
            lblHeure.Text = "Heure";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(800, 450);
            Controls.Add(lblHeure);
            Controls.Add(lblDate);
            Controls.Add(picTelechargement);
            Controls.Add(picParametres);
            Controls.Add(picLogo);
            Controls.Add(btnEvenementSuppression);
            Controls.Add(btnEvenementAjout);
            Controls.Add(btnPersonneSortie);
            Controls.Add(btnPersonneEntree);
            Name = "Main";
            Text = "Main";
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picParametres).EndInit();
            ((System.ComponentModel.ISupportInitialize)picTelechargement).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPersonneEntree;
        private Button btnPersonneSortie;
        private Button btnEvenementAjout;
        private Button btnEvenementSuppression;
        private PictureBox picLogo;
        private PictureBox picParametres;
        private PictureBox picTelechargement;
        private Label lblDate;
        private Label lblHeure;
    }
}