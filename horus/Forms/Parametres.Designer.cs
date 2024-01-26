namespace horus.Forms
{
    partial class Parametres
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
            btnValider = new Button();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnValider
            // 
            btnValider.BackColor = Color.PaleTurquoise;
            btnValider.Font = new Font("Sans Serif Collection", 9F);
            btnValider.Location = new Point(410, 285);
            btnValider.Name = "btnValider";
            btnValider.Size = new Size(141, 50);
            btnValider.TabIndex = 1;
            btnValider.Text = "Valider";
            btnValider.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(60, 295);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(243, 31);
            textBox1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(310, 285);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(52, 50);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Location = new Point(60, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(302, 215);
            panel1.TabIndex = 4;
            // 
            // Parametres
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(580, 385);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(textBox1);
            Controls.Add(btnValider);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Parametres";
            Text = "Parametres";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnValider;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        private Panel panel1;
    }
}