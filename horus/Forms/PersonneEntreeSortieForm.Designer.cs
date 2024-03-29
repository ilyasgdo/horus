﻿namespace horus.Forms
{
    partial class PersonneEntreeSortieForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonneEntreeSortieForm));
            lblHoraireEntreePersonne = new Label();
            cbHeurePersonne = new ComboBox();
            cbMinutePersonne = new ComboBox();
            lblDeuxPoints = new Label();
            btnValiderPersonne = new Button();
            pctboxDate = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pctboxDate).BeginInit();
            SuspendLayout();
            // 
            // lblHoraireEntreePersonne
            // 
            lblHoraireEntreePersonne.AutoSize = true;
            lblHoraireEntreePersonne.Font = new Font("Sans Serif Collection", 8F);
            lblHoraireEntreePersonne.Location = new Point(24, 35);
            lblHoraireEntreePersonne.Name = "lblHoraireEntreePersonne";
            lblHoraireEntreePersonne.Size = new Size(77, 27);
            lblHoraireEntreePersonne.TabIndex = 0;
            lblHoraireEntreePersonne.Text = "Horaire :";
            // 
            // cbHeurePersonne
            // 
            cbHeurePersonne.FormattingEnabled = true;
            cbHeurePersonne.Items.AddRange(new object[] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            cbHeurePersonne.Location = new Point(62, 63);
            cbHeurePersonne.Name = "cbHeurePersonne";
            cbHeurePersonne.Size = new Size(37, 23);
            cbHeurePersonne.TabIndex = 2;
            // 
            // cbMinutePersonne
            // 
            cbMinutePersonne.FormattingEnabled = true;
            cbMinutePersonne.Items.AddRange(new object[] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" });
            cbMinutePersonne.Location = new Point(121, 63);
            cbMinutePersonne.Name = "cbMinutePersonne";
            cbMinutePersonne.Size = new Size(37, 23);
            cbMinutePersonne.TabIndex = 3;
            // 
            // lblDeuxPoints
            // 
            lblDeuxPoints.AutoSize = true;
            lblDeuxPoints.Font = new Font("Segoe UI", 11F);
            lblDeuxPoints.Location = new Point(105, 66);
            lblDeuxPoints.Name = "lblDeuxPoints";
            lblDeuxPoints.Size = new Size(12, 20);
            lblDeuxPoints.TabIndex = 3;
            lblDeuxPoints.Text = ":";
            // 
            // btnValiderPersonne
            // 
            btnValiderPersonne.BackColor = Color.PaleTurquoise;
            btnValiderPersonne.Font = new Font("Sans Serif Collection", 9F);
            btnValiderPersonne.Location = new Point(62, 106);
            btnValiderPersonne.Name = "btnValiderPersonne";
            btnValiderPersonne.Size = new Size(96, 37);
            btnValiderPersonne.TabIndex = 1;
            btnValiderPersonne.Text = "Valider";
            btnValiderPersonne.UseVisualStyleBackColor = false;
            btnValiderPersonne.Click += btnValiderPersonne_Click;
            // 
            // pctboxDate
            // 
            pctboxDate.Image = (Image)resources.GetObject("pctboxDate.Image");
            pctboxDate.Location = new Point(172, 7);
            pctboxDate.Margin = new Padding(2, 2, 2, 2);
            pctboxDate.Name = "pctboxDate";
            pctboxDate.Size = new Size(44, 35);
            pctboxDate.SizeMode = PictureBoxSizeMode.Zoom;
            pctboxDate.TabIndex = 4;
            pctboxDate.TabStop = false;
            pctboxDate.Click += pctboxDate_Click;
            // 
            // PersonneEntreeSortieForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(225, 173);
            Controls.Add(pctboxDate);
            Controls.Add(btnValiderPersonne);
            Controls.Add(lblDeuxPoints);
            Controls.Add(cbMinutePersonne);
            Controls.Add(cbHeurePersonne);
            Controls.Add(lblHoraireEntreePersonne);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PersonneEntreeSortieForm";
            Text = "PersonneEntreeSortie";
            ((System.ComponentModel.ISupportInitialize)pctboxDate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHoraireEntreePersonne;
        private ComboBox cbHeurePersonne;
        private ComboBox cbMinutePersonne;
        private Label lblDeuxPoints;
        private Button btnValiderPersonne;
        private PictureBox pctboxDate;
    }
}