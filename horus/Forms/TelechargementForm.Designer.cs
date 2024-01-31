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
            fileSystemWatcher1 = new FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // monthCalendarDebut
            // 
            monthCalendarDebut.BackColor = SystemColors.Window;
            monthCalendarDebut.Location = new Point(50, 59);
            monthCalendarDebut.Margin = new Padding(10, 12, 10, 12);
            monthCalendarDebut.Name = "monthCalendarDebut";
            monthCalendarDebut.ShowToday = false;
            monthCalendarDebut.TabIndex = 2;
            // 
            // monthCalendarFin
            // 
            monthCalendarFin.Location = new Point(353, 59);
            monthCalendarFin.Margin = new Padding(10, 12, 10, 12);
            monthCalendarFin.Name = "monthCalendarFin";
            monthCalendarFin.ShowToday = false;
            monthCalendarFin.TabIndex = 3;
            // 
            // btnValiderTelechargement
            // 
            btnValiderTelechargement.BackColor = Color.PaleTurquoise;
            btnValiderTelechargement.Location = new Point(517, 320);
            btnValiderTelechargement.Margin = new Padding(3, 4, 3, 4);
            btnValiderTelechargement.Name = "btnValiderTelechargement";
            btnValiderTelechargement.Size = new Size(96, 31);
            btnValiderTelechargement.TabIndex = 1;
            btnValiderTelechargement.Text = "Télécharger";
            btnValiderTelechargement.UseVisualStyleBackColor = false;
            btnValiderTelechargement.Click += btnValiderTelechargement_Click;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // TelechargementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(653, 381);
            Controls.Add(btnValiderTelechargement);
            Controls.Add(monthCalendarFin);
            Controls.Add(monthCalendarDebut);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TelechargementForm";
            Text = "TelechargementForm";
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MonthCalendar monthCalendarDebut;
        private MonthCalendar monthCalendarFin;
        private Button btnValiderTelechargement;
        private FileSystemWatcher fileSystemWatcher1;
    }
}