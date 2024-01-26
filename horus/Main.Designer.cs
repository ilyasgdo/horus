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
            btnPersonneEntree = new Button();
            btnPersonneSortie = new Button();
            btnEvenementAjout = new Button();
            btnEvenementSuppression = new Button();
            SuspendLayout();
            // 
            // btnPersonneEntree
            // 
            btnPersonneEntree.Location = new Point(174, 119);
            btnPersonneEntree.Name = "btnPersonneEntree";
            btnPersonneEntree.Size = new Size(150, 86);
            btnPersonneEntree.TabIndex = 0;
            btnPersonneEntree.Text = "Une personne est entrée";
            btnPersonneEntree.UseVisualStyleBackColor = true;
            // 
            // btnPersonneSortie
            // 
            btnPersonneSortie.Location = new Point(496, 119);
            btnPersonneSortie.Name = "btnPersonneSortie";
            btnPersonneSortie.Size = new Size(150, 86);
            btnPersonneSortie.TabIndex = 1;
            btnPersonneSortie.Text = "Une personne est sortie";
            btnPersonneSortie.UseVisualStyleBackColor = true;
            // 
            // btnEvenementAjout
            // 
            btnEvenementAjout.Location = new Point(174, 269);
            btnEvenementAjout.Name = "btnEvenementAjout";
            btnEvenementAjout.Size = new Size(150, 86);
            btnEvenementAjout.TabIndex = 2;
            btnEvenementAjout.Text = "Ajouter un évènement";
            btnEvenementAjout.UseVisualStyleBackColor = true;
            // 
            // btnEvenementSuppression
            // 
            btnEvenementSuppression.Location = new Point(496, 269);
            btnEvenementSuppression.Name = "btnEvenementSuppression";
            btnEvenementSuppression.Size = new Size(150, 86);
            btnEvenementSuppression.TabIndex = 3;
            btnEvenementSuppression.Text = "Supprimer un évènement";
            btnEvenementSuppression.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEvenementSuppression);
            Controls.Add(btnEvenementAjout);
            Controls.Add(btnPersonneSortie);
            Controls.Add(btnPersonneEntree);
            Name = "Main";
            Text = "Main";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPersonneEntree;
        private Button btnPersonneSortie;
        private Button btnEvenementAjout;
        private Button btnEvenementSuppression;
    }
}