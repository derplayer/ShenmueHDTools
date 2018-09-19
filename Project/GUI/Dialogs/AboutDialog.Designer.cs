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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.vmuBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbout.Location = new System.Drawing.Point(6, 8);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(325, 33);
            this.labelAbout.TabIndex = 0;
            this.labelAbout.Text = "Shenmue HD ModTools";
            this.labelAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aboutLabel
            // 
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLabel.Location = new System.Drawing.Point(8, 39);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(171, 20);
            this.aboutLabel.TabIndex = 1;
            this.aboutLabel.Text = "Created by Derplayer - ";
            // 
            // vmuBox
            // 
            this.vmuBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vmuBox.Location = new System.Drawing.Point(445, 95);
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
            this.urlLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.urlLink.Location = new System.Drawing.Point(171, 39);
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
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(10, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(475, 90);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "PhilYeahz\nalex-marko\nRaymonf (Wulinshu database)\nReeceMix";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vmuBox);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(495, 129);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contributors and credits";
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(519, 218);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
    }
}