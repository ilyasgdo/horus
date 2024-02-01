namespace horus.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EvenementEntreeSortieForm));
            btnValiderEvenement = new Button();
            lblDeuxPoints = new Label();
            cbMinuteEvenement = new ComboBox();
            cbHeureEvenement = new ComboBox();
            lblHoraireEntreePersonne = new Label();
            comboBoxEvenements = new ComboBox();
            pctboxDate = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pctboxDate).BeginInit();
            SuspendLayout();
            // 
            // btnValiderEvenement
            // 
            btnValiderEvenement.BackColor = Color.PaleTurquoise;
            btnValiderEvenement.Font = new Font("Sans Serif Collection", 9F);
            btnValiderEvenement.Location = new Point(93, 266);
            btnValiderEvenement.Margin = new Padding(4, 5, 4, 5);
            btnValiderEvenement.Name = "btnValiderEvenement";
            btnValiderEvenement.Size = new Size(137, 62);
            btnValiderEvenement.TabIndex = 2;
            btnValiderEvenement.Text = "Valider";
            btnValiderEvenement.UseVisualStyleBackColor = false;
            btnValiderEvenement.Click += btnValiderEvenement_Click;
            // 
            // lblDeuxPoints
            // 
            lblDeuxPoints.AutoSize = true;
            lblDeuxPoints.Font = new Font("Segoe UI", 11F);
            lblDeuxPoints.Location = new Point(154, 202);
            lblDeuxPoints.Margin = new Padding(4, 0, 4, 0);
            lblDeuxPoints.Name = "lblDeuxPoints";
            lblDeuxPoints.Size = new Size(18, 30);
            lblDeuxPoints.TabIndex = 8;
            lblDeuxPoints.Text = ":";
            // 
            // cbMinuteEvenement
            // 
            cbMinuteEvenement.FormattingEnabled = true;
            cbMinuteEvenement.Items.AddRange(new object[] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" });
            cbMinuteEvenement.Location = new Point(177, 197);
            cbMinuteEvenement.Margin = new Padding(4, 5, 4, 5);
            cbMinuteEvenement.Name = "cbMinuteEvenement";
            cbMinuteEvenement.Size = new Size(51, 33);
            cbMinuteEvenement.TabIndex = 4;
            // 
            // cbHeureEvenement
            // 
            cbHeureEvenement.FormattingEnabled = true;
            cbHeureEvenement.Items.AddRange(new object[] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            cbHeureEvenement.Location = new Point(93, 197);
            cbHeureEvenement.Margin = new Padding(4, 5, 4, 5);
            cbHeureEvenement.Name = "cbHeureEvenement";
            cbHeureEvenement.Size = new Size(51, 33);
            cbHeureEvenement.TabIndex = 3;
            // 
            // lblHoraireEntreePersonne
            // 
            lblHoraireEntreePersonne.AutoSize = true;
            lblHoraireEntreePersonne.Font = new Font("Sans Serif Collection", 7F);
            lblHoraireEntreePersonne.Location = new Point(47, 152);
            lblHoraireEntreePersonne.Margin = new Padding(4, 0, 4, 0);
            lblHoraireEntreePersonne.Name = "lblHoraireEntreePersonne";
            lblHoraireEntreePersonne.Size = new Size(103, 35);
            lblHoraireEntreePersonne.TabIndex = 5;
            lblHoraireEntreePersonne.Text = "Horaire :";
            // 
            // comboBoxEvenements
            // 
            comboBoxEvenements.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEvenements.FormattingEnabled = true;
            comboBoxEvenements.Location = new Point(71, 99);
            comboBoxEvenements.Margin = new Padding(4, 5, 4, 5);
            comboBoxEvenements.Name = "comboBoxEvenements";
            comboBoxEvenements.Size = new Size(171, 33);
            comboBoxEvenements.TabIndex = 1;
            comboBoxEvenements.UseWaitCursor = true;
            // 
            // pctboxDate
            // 
            pctboxDate.Image = (Image)resources.GetObject("pctboxDate.Image");
            pctboxDate.Location = new Point(242, 12);
            pctboxDate.Name = "pctboxDate";
            pctboxDate.Size = new Size(67, 56);
            pctboxDate.SizeMode = PictureBoxSizeMode.Zoom;
            pctboxDate.TabIndex = 9;
            pctboxDate.TabStop = false;
            pctboxDate.Click += pctboxDate_Click;
            // 
            // EvenementEntreeSortieForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(321, 364);
            Controls.Add(pctboxDate);
            Controls.Add(comboBoxEvenements);
            Controls.Add(btnValiderEvenement);
            Controls.Add(lblDeuxPoints);
            Controls.Add(cbMinuteEvenement);
            Controls.Add(cbHeureEvenement);
            Controls.Add(lblHoraireEntreePersonne);
            Margin = new Padding(4, 5, 4, 5);
            Name = "EvenementEntreeSortieForm";
            Text = "EvenementEntree";
            ((System.ComponentModel.ISupportInitialize)pctboxDate).EndInit();
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
        private PictureBox pctboxDate;
    }
}