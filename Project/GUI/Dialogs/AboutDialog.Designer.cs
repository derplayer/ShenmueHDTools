namespace ShenmueHDTools.GUI.Dialogs
{
    partial class AboutDialog
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
            this.urlLink = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.updateLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.vmuBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.BackColor = System.Drawing.Color.Transparent;
            this.labelAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbout.Location = new System.Drawing.Point(4, 6);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(325, 33);
            this.labelAbout.TabIndex = 0;
            this.labelAbout.Text = "Shenmue HD ModTools";
            this.labelAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aboutLabel
            // 
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.BackColor = System.Drawing.Color.Transparent;
            this.aboutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLabel.Location = new System.Drawing.Point(8, 37);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(171, 20);
            this.aboutLabel.TabIndex = 1;
            this.aboutLabel.Text = "Created by Derplayer - ";
            // 
            // vmuBox
            // 
            this.vmuBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vmuBox.Location = new System.Drawing.Point(457, 174);
            this.vmuBox.Name = "vmuBox";
            this.vmuBox.Size = new System.Drawing.Size(48, 32);
            this.vmuBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.vmuBox.TabIndex = 2;
            this.vmuBox.TabStop = false;
            this.vmuBox.Click += new System.EventHandler(this.vmuBox_Click);
            // 
            // urlLink
            // 
            this.urlLink.AutoSize = true;
            this.urlLink.BackColor = System.Drawing.Color.Transparent;
            this.urlLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.urlLink.Location = new System.Drawing.Point(169, 37);
            this.urlLink.Name = "urlLink";
            this.urlLink.Size = new System.Drawing.Size(60, 20);
            this.urlLink.TabIndex = 3;
            this.urlLink.TabStop = true;
            this.urlLink.Text = "GitHub";
            this.urlLink.VisitedLinkColor = System.Drawing.Color.Blue;
            this.urlLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.urlLink_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 4;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 93);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(493, 113);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "PhilYeahz, alex-marko, Raymonf (Wulinshu database), ReeceMix";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Contributors and credits";
            // 
            // updateLabel
            // 
            this.updateLabel.AutoSize = true;
            this.updateLabel.BackColor = System.Drawing.Color.Transparent;
            this.updateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.updateLabel.Location = new System.Drawing.Point(355, 69);
            this.updateLabel.Name = "updateLabel";
            this.updateLabel.Size = new System.Drawing.Size(150, 20);
            this.updateLabel.TabIndex = 8;
            this.updateLabel.TabStop = true;
            this.updateLabel.Text = "Force update check";
            this.updateLabel.VisitedLinkColor = System.Drawing.Color.Blue;
            this.updateLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.updateLabel_LinkClicked);
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BackgroundImage = global::ShenmueHDTools.Properties.Resources.BG01;
            this.ClientSize = new System.Drawing.Size(519, 218);
            this.Controls.Add(this.updateLabel);
            this.Controls.Add(this.vmuBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.urlLink);
            this.Controls.Add(this.aboutLabel);
            this.Controls.Add(this.labelAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "About";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.About_FormClosing);
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vmuBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label aboutLabel;
        public System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.PictureBox vmuBox;
        private System.Windows.Forms.LinkLabel urlLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel updateLabel;
    }
}