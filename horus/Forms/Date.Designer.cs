namespace horus.Forms
{
    partial class Date
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Date));
            monthCalendar = new MonthCalendar();
            btnValider = new Button();
            SuspendLayout();
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new Point(22, 21);
            monthCalendar.Margin = new Padding(8, 9, 8, 9);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.ShowToday = false;
            monthCalendar.TabIndex = 4;
            // 
            // btnValider
            // 
            btnValider.BackColor = Color.PaleTurquoise;
            btnValider.Font = new Font("Sans Serif Collection", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnValider.Location = new Point(84, 185);
            btnValider.Margin = new Padding(2, 2, 2, 2);
            btnValider.Name = "btnValider";
            btnValider.Size = new Size(94, 26);
            btnValider.TabIndex = 5;
            btnValider.Text = "Valider";
            btnValider.UseVisualStyleBackColor = false;
            btnValider.Click += btnValider_Click;
            // 
            // Date
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(263, 248);
            Controls.Add(btnValider);
            Controls.Add(monthCalendar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            Name = "Date";
            Text = "Date";
            ResumeLayout(false);
        }

        #endregion

        private MonthCalendar monthCalendar;
        private Button btnValider;
    }
}