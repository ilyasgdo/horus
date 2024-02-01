namespace horus
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnPersonneEntree = new Button();
            btnPersonneSortie = new Button();
            btnEvenementAjout = new Button();
            btnEvenementSuppression = new Button();
            picLogo = new PictureBox();
            picParametres = new PictureBox();
            picTelechargement = new PictureBox();
            lblDate = new Label();
            lblHeure = new Label();
            lblNbPersonnes = new Label();
            label1 = new Label();
            labelEvent = new Label();
            labelAlertes = new Label();
            btnSupprimerAlerte = new Button();
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
            btnPersonneEntree.Location = new Point(175, 196);
            btnPersonneEntree.Margin = new Padding(3, 4, 3, 4);
            btnPersonneEntree.Name = "btnPersonneEntree";
            btnPersonneEntree.Size = new Size(171, 141);
            btnPersonneEntree.TabIndex = 1;
            btnPersonneEntree.Text = "Personne ENTREE";
            btnPersonneEntree.UseVisualStyleBackColor = false;
            btnPersonneEntree.Click += btnPersonneEntree_Click;
            // 
            // btnPersonneSortie
            // 
            btnPersonneSortie.BackColor = Color.PaleTurquoise;
            btnPersonneSortie.Font = new Font("Sans Serif Collection", 9F);
            btnPersonneSortie.Location = new Point(543, 196);
            btnPersonneSortie.Margin = new Padding(3, 4, 3, 4);
            btnPersonneSortie.Name = "btnPersonneSortie";
            btnPersonneSortie.Size = new Size(171, 134);
            btnPersonneSortie.TabIndex = 2;
            btnPersonneSortie.Text = "Personne SORTIE";
            btnPersonneSortie.UseVisualStyleBackColor = false;
            btnPersonneSortie.Click += btnPersonneSortie_Click;
            // 
            // btnEvenementAjout
            // 
            btnEvenementAjout.BackColor = Color.PaleTurquoise;
            btnEvenementAjout.Font = new Font("Sans Serif Collection", 9F);
            btnEvenementAjout.Location = new Point(175, 396);
            btnEvenementAjout.Margin = new Padding(3, 4, 3, 4);
            btnEvenementAjout.Name = "btnEvenementAjout";
            btnEvenementAjout.Size = new Size(171, 125);
            btnEvenementAjout.TabIndex = 3;
            btnEvenementAjout.Text = "DEBUT  évènement";
            btnEvenementAjout.UseVisualStyleBackColor = false;
            btnEvenementAjout.Click += btnEvenementAjout_Click;
            // 
            // btnEvenementSuppression
            // 
            btnEvenementSuppression.BackColor = Color.PaleTurquoise;
            btnEvenementSuppression.Font = new Font("Sans Serif Collection", 9F);
            btnEvenementSuppression.Location = new Point(543, 396);
            btnEvenementSuppression.Margin = new Padding(3, 4, 3, 4);
            btnEvenementSuppression.Name = "btnEvenementSuppression";
            btnEvenementSuppression.Size = new Size(171, 125);
            btnEvenementSuppression.TabIndex = 4;
            btnEvenementSuppression.Text = " FIN évènement";
            btnEvenementSuppression.UseVisualStyleBackColor = false;
            btnEvenementSuppression.Click += btnEvenementSuppression_Click;
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(34, 16);
            picLogo.Margin = new Padding(3, 4, 3, 4);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(175, 157);
            picLogo.TabIndex = 4;
            picLogo.TabStop = false;
            // 
            // picParametres
            // 
            picParametres.BackColor = SystemColors.Control;
            picParametres.Image = (Image)resources.GetObject("picParametres.Image");
            picParametres.Location = new Point(806, 39);
            picParametres.Margin = new Padding(3, 4, 3, 4);
            picParametres.Name = "picParametres";
            picParametres.Size = new Size(64, 68);
            picParametres.SizeMode = PictureBoxSizeMode.StretchImage;
            picParametres.TabIndex = 5;
            picParametres.TabStop = false;
            picParametres.Click += picParametres_Click;
            // 
            // picTelechargement
            // 
            picTelechargement.BackColor = SystemColors.Control;
            picTelechargement.Image = (Image)resources.GetObject("picTelechargement.Image");
            picTelechargement.Location = new Point(728, 39);
            picTelechargement.Margin = new Padding(3, 4, 3, 4);
            picTelechargement.Name = "picTelechargement";
            picTelechargement.Size = new Size(57, 68);
            picTelechargement.SizeMode = PictureBoxSizeMode.StretchImage;
            picTelechargement.TabIndex = 6;
            picTelechargement.TabStop = false;
            picTelechargement.Click += picTelechargement_Click;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(403, 73);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(41, 20);
            lblDate.TabIndex = 7;
            lblDate.Text = "Date";
            // 
            // lblHeure
            // 
            lblHeure.AutoSize = true;
            lblHeure.Location = new Point(482, 73);
            lblHeure.Name = "lblHeure";
            lblHeure.Size = new Size(49, 20);
            lblHeure.TabIndex = 8;
            lblHeure.Text = "Heure";
            // 
            // lblNbPersonnes
            // 
            lblNbPersonnes.AutoSize = true;
            lblNbPersonnes.Location = new Point(352, 253);
            lblNbPersonnes.Name = "lblNbPersonnes";
            lblNbPersonnes.Size = new Size(50, 20);
            lblNbPersonnes.TabIndex = 9;
            lblNbPersonnes.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 10;
            label1.Text = "label1";
            // 
            // labelEvent
            // 
            labelEvent.AutoSize = true;
            labelEvent.Location = new Point(378, 455);
            labelEvent.Name = "labelEvent";
            labelEvent.Size = new Size(50, 20);
            labelEvent.TabIndex = 11;
            labelEvent.Text = "label2";
            // 
            // labelAlertes
            // 
            labelAlertes.AutoSize = true;
            labelAlertes.Location = new Point(609, 138);
            labelAlertes.Name = "labelAlertes";
            labelAlertes.Size = new Size(50, 20);
            labelAlertes.TabIndex = 12;
            labelAlertes.Text = "label2";
            // 
            // btnSupprimerAlerte
            // 
            btnSupprimerAlerte.Location = new Point(510, 138);
            btnSupprimerAlerte.Name = "btnSupprimerAlerte";
            btnSupprimerAlerte.Size = new Size(76, 24);
            btnSupprimerAlerte.TabIndex = 13;
            btnSupprimerAlerte.Text = "button1";
            btnSupprimerAlerte.UseVisualStyleBackColor = true;
            btnSupprimerAlerte.Click += BtnSupprimerAlerte_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(914, 600);
            Controls.Add(btnSupprimerAlerte);
            Controls.Add(labelAlertes);
            Controls.Add(labelEvent);
            Controls.Add(label1);
            Controls.Add(lblNbPersonnes);
            Controls.Add(lblHeure);
            Controls.Add(lblDate);
            Controls.Add(picTelechargement);
            Controls.Add(picParametres);
            Controls.Add(picLogo);
            Controls.Add(btnEvenementSuppression);
            Controls.Add(btnEvenementAjout);
            Controls.Add(btnPersonneSortie);
            Controls.Add(btnPersonneEntree);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Main";
            Load += MainForm_Load;
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
        private Label lblNbPersonnes;
        private Label label1;
        private Label labelEvent;
        private Label labelAlertes;
        private Button btnSupprimerAlerte;
    }
}