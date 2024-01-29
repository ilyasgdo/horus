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
            SuspendLayout();
            // 
            // comboBoxEvenements
            // 
            comboBoxEvenements.FormattingEnabled = true;
            comboBoxEvenements.Location = new Point(226, 100);
            comboBoxEvenements.Name = "comboBoxEvenements";
            comboBoxEvenements.Size = new Size(328, 28);
            comboBoxEvenements.TabIndex = 0;
            // 
            // btnSupprimer
            // 
            btnSupprimer.BackColor = Color.IndianRed;
            btnSupprimer.Location = new Point(226, 262);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(94, 29);
            btnSupprimer.TabIndex = 1;
            btnSupprimer.Text = "suprimer";
            btnSupprimer.UseVisualStyleBackColor = false;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // btnAjouter
            // 
            btnAjouter.BackColor = Color.Chartreuse;
            btnAjouter.Location = new Point(460, 262);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(94, 29);
            btnAjouter.TabIndex = 2;
            btnAjouter.Text = "ajouter";
            btnAjouter.UseVisualStyleBackColor = false;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // textBoxNouvelEvenement
            // 
            textBoxNouvelEvenement.Location = new Point(226, 178);
            textBoxNouvelEvenement.Name = "textBoxNouvelEvenement";
            textBoxNouvelEvenement.Size = new Size(328, 27);
            textBoxNouvelEvenement.TabIndex = 3;
            // 
            // ParametresForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}