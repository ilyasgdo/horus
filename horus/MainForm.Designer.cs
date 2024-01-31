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
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picParametres).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picTelechargement).BeginInit();
            SuspendLayout();
            // 
            // btnPersonneEntree
            // 
            btnPersonneEntree.BackColor = Color.PaleTurquoise;
            btnPersonneEntree.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPersonneEntree.ForeColor = SystemColors.ControlText;
            btnPersonneEntree.Location = new Point(411, 233);
            btnPersonneEntree.Name = "btnPersonneEntree";
            btnPersonneEntree.Size = new Size(275, 224);
            btnPersonneEntree.TabIndex = 1;
            btnPersonneEntree.Text = "Personne entrée";
            btnPersonneEntree.UseVisualStyleBackColor = false;
            btnPersonneEntree.Click += btnPersonneEntree_Click;
            // 
            // btnPersonneSortie
            // 
            btnPersonneSortie.BackColor = Color.PaleTurquoise;
            btnPersonneSortie.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPersonneSortie.Location = new Point(1229, 226);
            btnPersonneSortie.Name = "btnPersonneSortie";
            btnPersonneSortie.Size = new Size(275, 224);
            btnPersonneSortie.TabIndex = 2;
            btnPersonneSortie.Text = "Personne sortie";
            btnPersonneSortie.UseVisualStyleBackColor = false;
            btnPersonneSortie.Click += btnPersonneSortie_Click;
            // 
            // btnEvenementAjout
            // 
            btnEvenementAjout.BackColor = Color.PaleTurquoise;
            btnEvenementAjout.Font = new Font("Segoe UI", 20.25F);
            btnEvenementAjout.Location = new Point(411, 622);
            btnEvenementAjout.Name = "btnEvenementAjout";
            btnEvenementAjout.Size = new Size(275, 224);
            btnEvenementAjout.TabIndex = 3;
            btnEvenementAjout.Text = "Début  évènement";
            btnEvenementAjout.UseVisualStyleBackColor = false;
            btnEvenementAjout.Click += btnEvenementAjout_Click;
            // 
            // btnEvenementSuppression
            // 
            btnEvenementSuppression.BackColor = Color.PaleTurquoise;
            btnEvenementSuppression.Font = new Font("Segoe UI", 20.25F);
            btnEvenementSuppression.Location = new Point(1229, 622);
            btnEvenementSuppression.Name = "btnEvenementSuppression";
            btnEvenementSuppression.Size = new Size(275, 224);
            btnEvenementSuppression.TabIndex = 4;
            btnEvenementSuppression.Text = " Fin évènement";
            btnEvenementSuppression.UseVisualStyleBackColor = false;
            btnEvenementSuppression.Click += btnEvenementSuppression_Click;
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(12, 12);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(300, 200);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 4;
            picLogo.TabStop = false;
            // 
            // picParametres
            // 
            picParametres.BackColor = SystemColors.Control;
            picParametres.Image = (Image)resources.GetObject("picParametres.Image");
            picParametres.Location = new Point(1747, 30);
            picParametres.Name = "picParametres";
            picParametres.Size = new Size(100, 100);
            picParametres.SizeMode = PictureBoxSizeMode.StretchImage;
            picParametres.TabIndex = 5;
            picParametres.TabStop = false;
            picParametres.Click += picParametres_Click;
            // 
            // picTelechargement
            // 
            picTelechargement.BackColor = SystemColors.Control;
            picTelechargement.Image = (Image)resources.GetObject("picTelechargement.Image");
            picTelechargement.Location = new Point(1595, 29);
            picTelechargement.Name = "picTelechargement";
            picTelechargement.Size = new Size(100, 100);
            picTelechargement.SizeMode = PictureBoxSizeMode.StretchImage;
            picTelechargement.TabIndex = 6;
            picTelechargement.TabStop = false;
            picTelechargement.Click += picTelechargement_Click;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 20F);
            lblDate.Location = new Point(700, 82);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(73, 37);
            lblDate.TabIndex = 7;
            lblDate.Text = "Date";
            // 
            // lblHeure
            // 
            lblHeure.AutoSize = true;
            lblHeure.Font = new Font("Segoe UI", 20F);
            lblHeure.Location = new Point(1160, 82);
            lblHeure.Name = "lblHeure";
            lblHeure.Size = new Size(88, 37);
            lblHeure.TabIndex = 8;
            lblHeure.Text = "Heure";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1904, 1041);
            Controls.Add(lblHeure);
            Controls.Add(lblDate);
            Controls.Add(picTelechargement);
            Controls.Add(picParametres);
            Controls.Add(picLogo);
            Controls.Add(btnEvenementSuppression);
            Controls.Add(btnEvenementAjout);
            Controls.Add(btnPersonneSortie);
            Controls.Add(btnPersonneEntree);
            Name = "MainForm";
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