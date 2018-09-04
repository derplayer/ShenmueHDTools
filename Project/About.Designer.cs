namespace Shenmue_HD_Tools
{
    partial class About
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
            this.labelAbout = new System.Windows.Forms.Label();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.vmuBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.vmuBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbout.Location = new System.Drawing.Point(10, 12);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(292, 33);
            this.labelAbout.TabIndex = 0;
            this.labelAbout.Text = "Shenmue HD Tools v";
            // 
            // aboutLabel
            // 
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLabel.Location = new System.Drawing.Point(13, 47);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(155, 20);
            this.aboutLabel.TabIndex = 1;
            this.aboutLabel.Text = "Created by derplayer";
            // 
            // vmuBox
            // 
            this.vmuBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vmuBox.Location = new System.Drawing.Point(355, 12);
            this.vmuBox.Name = "vmuBox";
            this.vmuBox.Size = new System.Drawing.Size(48, 32);
            this.vmuBox.TabIndex = 2;
            this.vmuBox.TabStop = false;
            this.vmuBox.Click += new System.EventHandler(this.vmuBox_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(415, 76);
            this.Controls.Add(this.vmuBox);
            this.Controls.Add(this.aboutLabel);
            this.Controls.Add(this.labelAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "About";
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vmuBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label aboutLabel;
        public System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.PictureBox vmuBox;
    }
}