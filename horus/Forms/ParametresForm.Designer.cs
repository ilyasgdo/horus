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
            comboBoxEvenements.Location = new Point(226, 162);
            comboBoxEvenements.Name = "comboBoxEvenements";
            comboBoxEvenements.Size = new Size(328, 28);
            comboBoxEvenements.TabIndex = 0;
            // 
            // btnSupprimer
            // 
            btnSupprimer.BackColor = Color.IndianRed;
            btnSupprimer.Location = new Point(226, 306);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(143, 51);
            btnSupprimer.TabIndex = 1;
            btnSupprimer.Text = "suprimer";
            btnSupprimer.UseVisualStyleBackColor = false;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // btnAjouter
            // 
            btnAjouter.BackColor = Color.Chartreuse;
            btnAjouter.Location = new Point(399, 306);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(155, 50);
            btnAjouter.TabIndex = 2;
            btnAjouter.Text = "ajouter";
            btnAjouter.UseVisualStyleBackColor = false;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // textBoxNouvelEvenement
            // 
            textBoxNouvelEvenement.Location = new Point(226, 257);
            textBoxNouvelEvenement.Name = "textBoxNouvelEvenement";
            textBoxNouvelEvenement.Size = new Size(328, 27);
            textBoxNouvelEvenement.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(226, 139);
            label1.Name = "label1";
            label1.Size = new Size(149, 20);
            label1.TabIndex = 4;
            label1.Text = "Liste des evenements";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(226, 225);
            label2.Name = "label2";
            label2.Size = new Size(128, 20);
            label2.TabIndex = 5;
            label2.Text = "Saisir l'évenement";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Red;
            label3.Location = new Point(12, 39);
            label3.Name = "label3";
            label3.Size = new Size(457, 20);
            label3.TabIndex = 6;
            label3.Text = "Pour supprimer, selectionner un evenement et cliquer sur supprimer ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LawnGreen;
            label4.Location = new Point(11, 9);
            label4.Name = "label4";
            label4.Size = new Size(543, 20);
            label4.TabIndex = 7;
            label4.Text = "Pour ajouter un évenements ecriver le nom de l'événement et cliquer sur ajouter  ";
            // 
            // ParametresForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxNouvelEvenement);
            Controls.Add(btnAjouter);
            Controls.Add(btnSupprimer);
            Controls.Add(comboBoxEvenements);
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