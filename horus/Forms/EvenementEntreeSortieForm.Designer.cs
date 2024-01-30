﻿namespace horus.Forms
{
    partial class EvenementEntreeSortieForm
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
            btnValiderEvenement = new Button();
            lblDeuxPoints = new Label();
            cbMinuteEvenement = new ComboBox();
            cbHeureEvenement = new ComboBox();
            lblHoraireEntreePersonne = new Label();
            comboBoxEvenements = new ComboBox();
            SuspendLayout();
            // 
            // btnValiderEvenement
            // 
            btnValiderEvenement.BackColor = Color.PaleTurquoise;
            btnValiderEvenement.Font = new Font("Sans Serif Collection", 9F);
            btnValiderEvenement.Location = new Point(65, 139);
            btnValiderEvenement.Name = "btnValiderEvenement";
            btnValiderEvenement.Size = new Size(96, 37);
            btnValiderEvenement.TabIndex = 9;
            btnValiderEvenement.Text = "Valider";
            btnValiderEvenement.UseVisualStyleBackColor = false;
            btnValiderEvenement.Click += btnValiderEvenement_Click;
            // 
            // lblDeuxPoints
            // 
            lblDeuxPoints.AutoSize = true;
            lblDeuxPoints.Font = new Font("Segoe UI", 11F);
            lblDeuxPoints.Location = new Point(108, 99);
            lblDeuxPoints.Name = "lblDeuxPoints";
            lblDeuxPoints.Size = new Size(12, 20);
            lblDeuxPoints.TabIndex = 8;
            lblDeuxPoints.Text = ":";
            // 
            // cbMinuteEvenement
            // 
            cbMinuteEvenement.FormattingEnabled = true;
            cbMinuteEvenement.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" });
            cbMinuteEvenement.Location = new Point(124, 96);
            cbMinuteEvenement.Name = "cbMinuteEvenement";
            cbMinuteEvenement.Size = new Size(37, 23);
            cbMinuteEvenement.TabIndex = 7;
            // 
            // cbHeureEvenement
            // 
            cbHeureEvenement.FormattingEnabled = true;
            cbHeureEvenement.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            cbHeureEvenement.Location = new Point(65, 96);
            cbHeureEvenement.Name = "cbHeureEvenement";
            cbHeureEvenement.Size = new Size(37, 23);
            cbHeureEvenement.TabIndex = 6;
            // 
            // lblHoraireEntreePersonne
            // 
            lblHoraireEntreePersonne.AutoSize = true;
            lblHoraireEntreePersonne.Font = new Font("Sans Serif Collection", 7F);
            lblHoraireEntreePersonne.Location = new Point(33, 69);
            lblHoraireEntreePersonne.Name = "lblHoraireEntreePersonne";
            lblHoraireEntreePersonne.Size = new Size(65, 24);
            lblHoraireEntreePersonne.TabIndex = 5;
            lblHoraireEntreePersonne.Text = "Horaire :";
            // 
            // comboBoxEvenements
            // 
            comboBoxEvenements.FormattingEnabled = true;
            comboBoxEvenements.Location = new Point(51, 32);
            comboBoxEvenements.Name = "comboBoxEvenements";
            comboBoxEvenements.Size = new Size(121, 23);
            comboBoxEvenements.TabIndex = 10;
            // 
            // EvenementEntreeSortieForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(225, 206);
            Controls.Add(comboBoxEvenements);
            Controls.Add(btnValiderEvenement);
            Controls.Add(lblDeuxPoints);
            Controls.Add(cbMinuteEvenement);
            Controls.Add(cbHeureEvenement);
            Controls.Add(lblHoraireEntreePersonne);
            Name = "EvenementEntreeSortieForm";
            Text = "EvenementEntree";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnValiderEvenement;
        private Label lblDeuxPoints;
        private ComboBox cbMinuteEvenement;
        private ComboBox cbHeureEvenement;
        private Label lblHoraireEntreePersonne;
        private ComboBox comboBoxEvenements;
    }
}