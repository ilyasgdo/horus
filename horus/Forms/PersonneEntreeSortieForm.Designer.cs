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
            cbMinutePersonne = new ComboBox();
            lblDeuxPoints = new Label();
            btnValiderPersonne = new Button();
            SuspendLayout();
            // 
            // lblHoraireEntreePersonne
            // 
            lblHoraireEntreePersonne.AutoSize = true;
            lblHoraireEntreePersonne.Font = new Font("Sans Serif Collection", 8F);
            lblHoraireEntreePersonne.Location = new Point(27, 47);
            lblHoraireEntreePersonne.Name = "lblHoraireEntreePersonne";
            lblHoraireEntreePersonne.Size = new Size(103, 35);
            lblHoraireEntreePersonne.TabIndex = 0;
            lblHoraireEntreePersonne.Text = "Horaire :";
            // 
            // cbHeurePersonne
            // 
            cbHeurePersonne.FormattingEnabled = true;
            cbHeurePersonne.Items.AddRange(new object[] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            cbHeurePersonne.Location = new Point(71, 84);
            cbHeurePersonne.Margin = new Padding(3, 4, 3, 4);
            cbHeurePersonne.Name = "cbHeurePersonne";
            cbHeurePersonne.Size = new Size(42, 28);
            cbHeurePersonne.TabIndex = 2;
            // 
            // cbMinutePersonne
            // 
            cbMinutePersonne.FormattingEnabled = true;
            cbMinutePersonne.Items.AddRange(new object[] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" });
            cbMinutePersonne.Location = new Point(138, 84);
            cbMinutePersonne.Margin = new Padding(3, 4, 3, 4);
            cbMinutePersonne.Name = "cbMinutePersonne";
            cbMinutePersonne.Size = new Size(42, 28);
            cbMinutePersonne.TabIndex = 3;
            // 
            // lblDeuxPoints
            // 
            lblDeuxPoints.AutoSize = true;
            lblDeuxPoints.Font = new Font("Segoe UI", 11F);
            lblDeuxPoints.Location = new Point(120, 88);
            lblDeuxPoints.Name = "lblDeuxPoints";
            lblDeuxPoints.Size = new Size(16, 25);
            lblDeuxPoints.TabIndex = 3;
            lblDeuxPoints.Text = ":";
            // 
            // btnValiderPersonne
            // 
            btnValiderPersonne.BackColor = Color.PaleTurquoise;
            btnValiderPersonne.Font = new Font("Sans Serif Collection", 9F);
            btnValiderPersonne.Location = new Point(71, 141);
            btnValiderPersonne.Margin = new Padding(3, 4, 3, 4);
            btnValiderPersonne.Name = "btnValiderPersonne";
            btnValiderPersonne.Size = new Size(110, 49);
            btnValiderPersonne.TabIndex = 1;
            btnValiderPersonne.Text = "Valider";
            btnValiderPersonne.UseVisualStyleBackColor = false;
            btnValiderPersonne.Click += btnValiderPersonne_Click;
            // 
            // PersonneEntreeSortieForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(257, 231);
            Controls.Add(btnValiderPersonne);
            Controls.Add(lblDeuxPoints);
            Controls.Add(cbMinutePersonne);
            Controls.Add(cbHeurePersonne);
            Controls.Add(lblHoraireEntreePersonne);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PersonneEntreeSortieForm";
            Text = "PersonneEntreeSortie";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHoraireEntreePersonne;
        private ComboBox cbHeurePersonne;
        private ComboBox cbMinutePersonne;
        private Label lblDeuxPoints;
        private Button btnValiderPersonne;
    }
}