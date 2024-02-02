namespace horus.Forms
{
    partial class ParametresForm
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
            comboBoxEvenements = new ComboBox();
            btnSupprimer = new Button();
            btnAjouter = new Button();
            textBoxNouvelEvenement = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // comboBoxEvenements
            // 
            comboBoxEvenements.FormattingEnabled = true;
            comboBoxEvenements.Location = new Point(198, 122);
            comboBoxEvenements.Margin = new Padding(3, 2, 3, 2);
            comboBoxEvenements.Name = "comboBoxEvenements";
            comboBoxEvenements.Size = new Size(288, 23);
            comboBoxEvenements.TabIndex = 4;
            // 
            // btnSupprimer
            // 
            btnSupprimer.BackColor = Color.IndianRed;
            btnSupprimer.Location = new Point(198, 230);
            btnSupprimer.Margin = new Padding(3, 2, 3, 2);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(125, 38);
            btnSupprimer.TabIndex = 3;
            btnSupprimer.Text = "supprimer";
            btnSupprimer.UseVisualStyleBackColor = false;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // btnAjouter
            // 
            btnAjouter.BackColor = Color.Chartreuse;
            btnAjouter.Location = new Point(349, 230);
            btnAjouter.Margin = new Padding(3, 2, 3, 2);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(136, 38);
            btnAjouter.TabIndex = 2;
            btnAjouter.Text = "ajouter";
            btnAjouter.UseVisualStyleBackColor = false;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // textBoxNouvelEvenement
            // 
            textBoxNouvelEvenement.Location = new Point(198, 193);
            textBoxNouvelEvenement.Margin = new Padding(3, 2, 3, 2);
            textBoxNouvelEvenement.Name = "textBoxNouvelEvenement";
            textBoxNouvelEvenement.Size = new Size(288, 23);
            textBoxNouvelEvenement.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(198, 104);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 4;
            label1.Text = "Liste des évènements";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(198, 169);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 5;
            label2.Text = "Saisir l'évènement";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Red;
            label3.Location = new Point(10, 29);
            label3.Name = "label3";
            label3.Size = new Size(369, 15);
            label3.TabIndex = 6;
            label3.Text = "Pour supprimer, sélectionner un évènement et cliquer sur supprimer ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LawnGreen;
            label4.Location = new Point(10, 7);
            label4.Name = "label4";
            label4.Size = new Size(429, 15);
            label4.TabIndex = 7;
            label4.Text = "Pour ajouter un évènements écrire le nom de l'évènement et cliquer sur ajouter  ";
            // 
            // ParametresForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxNouvelEvenement);
            Controls.Add(btnAjouter);
            Controls.Add(btnSupprimer);
            Controls.Add(comboBoxEvenements);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ParametresForm";
            Text = "ParametresForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxEvenements;
        private Button btnSupprimer;
        private Button btnAjouter;
        private TextBox textBoxNouvelEvenement;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}