namespace horus.Forms
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
            lblHoraireEntreePersonne = new Label();
            cbHeurePersonne = new ComboBox();
            cboMinutePersonne = new ComboBox();
            lblDeuxPoints = new Label();
            btnValiderPersonne = new Button();
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
            cbHeurePersonne.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            cbHeurePersonne.Location = new Point(62, 63);
            cbHeurePersonne.Name = "cbHeurePersonne";
            cbHeurePersonne.Size = new Size(37, 23);
            cbHeurePersonne.TabIndex = 1;
            // 
            // cboMinutePersonne
            // 
            cboMinutePersonne.FormattingEnabled = true;
            cboMinutePersonne.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" });
            cboMinutePersonne.Location = new Point(121, 63);
            cboMinutePersonne.Name = "cboMinutePersonne";
            cboMinutePersonne.Size = new Size(37, 23);
            cboMinutePersonne.TabIndex = 2;
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
            btnValiderPersonne.TabIndex = 4;
            btnValiderPersonne.Text = "Valider";
            btnValiderPersonne.UseVisualStyleBackColor = false;
            // 
            // PersonneEntreeSortie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(225, 173);
            Controls.Add(btnValiderPersonne);
            Controls.Add(lblDeuxPoints);
            Controls.Add(cboMinutePersonne);
            Controls.Add(cbHeurePersonne);
            Controls.Add(lblHoraireEntreePersonne);
            Name = "PersonneEntreeSortie";
            Text = "PersonneEntreeSortie";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHoraireEntreePersonne;
        private ComboBox cbHeurePersonne;
        private ComboBox cboMinutePersonne;
        private Label lblDeuxPoints;
        private Button btnValiderPersonne;
    }
}