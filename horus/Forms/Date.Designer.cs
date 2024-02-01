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
            monthCalendar = new MonthCalendar();
            btnValider = new Button();
            SuspendLayout();
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new Point(32, 35);
            monthCalendar.Margin = new Padding(12, 15, 12, 15);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.ShowToday = false;
            monthCalendar.TabIndex = 4;
            // 
            // btnValider
            // 
            btnValider.BackColor = Color.PaleTurquoise;
            btnValider.Font = new Font("Sans Serif Collection", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnValider.Location = new Point(120, 308);
            btnValider.Name = "btnValider";
            btnValider.Size = new Size(134, 44);
            btnValider.TabIndex = 5;
            btnValider.Text = "Valider";
            btnValider.UseVisualStyleBackColor = false;
            btnValider.Click += btnValider_Click;
            // 
            // Date
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(376, 414);
            Controls.Add(btnValider);
            Controls.Add(monthCalendar);
            Name = "Date";
            Text = "Date";
            ResumeLayout(false);
        }

        #endregion

        private MonthCalendar monthCalendar;
        private Button btnValider;
    }
}