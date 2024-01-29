namespace horus.Forms
{
    partial class TelechargementForm
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
            monthCalendarDebut = new MonthCalendar();
            monthCalendarFin = new MonthCalendar();
            btnValiderTelechargement = new Button();
            SuspendLayout();
            // 
            // monthCalendarDebut
            // 
            monthCalendarDebut.Location = new Point(44, 44);
            monthCalendarDebut.Name = "monthCalendarDebut";
            monthCalendarDebut.TabIndex = 0;
            // 
            // monthCalendarFin
            // 
            monthCalendarFin.Location = new Point(309, 44);
            monthCalendarFin.Name = "monthCalendarFin";
            monthCalendarFin.TabIndex = 1;
            // 
            // btnValiderTelechargement
            // 
            btnValiderTelechargement.Location = new Point(461, 240);
            btnValiderTelechargement.Name = "btnValiderTelechargement";
            btnValiderTelechargement.Size = new Size(75, 23);
            btnValiderTelechargement.TabIndex = 2;
            btnValiderTelechargement.Text = "valider";
            btnValiderTelechargement.UseVisualStyleBackColor = true;
            // 
            // TelechargementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 286);
            Controls.Add(btnValiderTelechargement);
            Controls.Add(monthCalendarFin);
            Controls.Add(monthCalendarDebut);
            Name = "TelechargementForm";
            Text = "TelechargementForm";
            ResumeLayout(false);
        }

        #endregion

        private MonthCalendar monthCalendarDebut;
        private MonthCalendar monthCalendarFin;
        private Button btnValiderTelechargement;
    }
}