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
            lblHoraireEntreePersonne.Location = new Point(34, 58);
            lblHoraireEntreePersonne.Margin = new Padding(4, 0, 4, 0);
            lblHoraireEntreePersonne.Name = "lblHoraireEntreePersonne";
            lblHoraireEntreePersonne.Size = new Size(114, 39);
            lblHoraireEntreePersonne.TabIndex = 0;
            lblHoraireEntreePersonne.Text = "Horaire :";
            // 
            // cbHeurePersonne
            // 
            cbHeurePersonne.FormattingEnabled = true;
            cbHeurePersonne.Items.AddRange(new object[] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            cbHeurePersonne.Location = new Point(89, 105);
            cbHeurePersonne.Margin = new Padding(4, 5, 4, 5);
            cbHeurePersonne.Name = "cbHeurePersonne";
            cbHeurePersonne.Size = new Size(51, 33);
            cbHeurePersonne.TabIndex = 2;
            // 
            // cbMinutePersonne
            // 
            cbMinutePersonne.FormattingEnabled = true;
            cbMinutePersonne.Items.AddRange(new object[] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" });
            cbMinutePersonne.Location = new Point(173, 105);
            cbMinutePersonne.Margin = new Padding(4, 5, 4, 5);
            cbMinutePersonne.Name = "cbMinutePersonne";
            cbMinutePersonne.Size = new Size(51, 33);
            cbMinutePersonne.TabIndex = 3;
            // 
            // lblDeuxPoints
            // 
            lblDeuxPoints.AutoSize = true;
            lblDeuxPoints.Font = new Font("Segoe UI", 11F);
            lblDeuxPoints.Location = new Point(150, 110);
            lblDeuxPoints.Margin = new Padding(4, 0, 4, 0);
            lblDeuxPoints.Name = "lblDeuxPoints";
            lblDeuxPoints.Size = new Size(18, 30);
            lblDeuxPoints.TabIndex = 3;
            lblDeuxPoints.Text = ":";
            // 
            // btnValiderPersonne
            // 
            btnValiderPersonne.BackColor = Color.PaleTurquoise;
            btnValiderPersonne.Font = new Font("Sans Serif Collection", 9F);
            btnValiderPersonne.Location = new Point(89, 177);
            btnValiderPersonne.Margin = new Padding(4, 5, 4, 5);
            btnValiderPersonne.Name = "btnValiderPersonne";
            btnValiderPersonne.Size = new Size(137, 62);
            btnValiderPersonne.TabIndex = 1;
            btnValiderPersonne.Text = "Valider";
            btnValiderPersonne.UseVisualStyleBackColor = false;
            btnValiderPersonne.Click += btnValiderPersonne_Click;
            // 
            // pctboxDate
            // 
            pctboxDate.Image = (Image)resources.GetObject("pctboxDate.Image");
            pctboxDate.Location = new Point(246, 12);
            pctboxDate.Name = "pctboxDate";
            pctboxDate.Size = new Size(63, 59);
            pctboxDate.SizeMode = PictureBoxSizeMode.Zoom;
            pctboxDate.TabIndex = 4;
            pctboxDate.TabStop = false;
            pctboxDate.Click += pctboxDate_Click;
            // 
            // PersonneEntreeSortieForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(321, 288);
            Controls.Add(pctboxDate);
            Controls.Add(btnValiderPersonne);
            Controls.Add(lblDeuxPoints);
            Controls.Add(cbMinutePersonne);
            Controls.Add(cbHeurePersonne);
            Controls.Add(lblHoraireEntreePersonne);
            Margin = new Padding(4, 5, 4, 5);
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