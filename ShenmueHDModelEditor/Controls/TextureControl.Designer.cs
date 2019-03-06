namespace ShenmueHDModelEditor.Controls
{
    partial class TextureControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_MipMapIndex = new System.Windows.Forms.NumericUpDown();
            this.button_Export = new System.Windows.Forms.Button();
            this.button_Import = new System.Windows.Forms.Button();
            this.pictureBox_TextureView = new System.Windows.Forms.PictureBoxExt();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MipMapIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TextureView)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mipmap Index:";
            // 
            // numericUpDown_MipMapIndex
            // 
            this.numericUpDown_MipMapIndex.Location = new System.Drawing.Point(82, 4);
            this.numericUpDown_MipMapIndex.Name = "numericUpDown_MipMapIndex";
            this.numericUpDown_MipMapIndex.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_MipMapIndex.TabIndex = 4;
            this.numericUpDown_MipMapIndex.ValueChanged += new System.EventHandler(this.numericUpDown_MipMapIndex_ValueChanged);
            // 
            // button_Export
            // 
            this.button_Export.Location = new System.Drawing.Point(138, 3);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(75, 23);
            this.button_Export.TabIndex = 6;
            this.button_Export.Text = "Export...";
            this.button_Export.UseVisualStyleBackColor = true;
            this.button_Export.Click += new System.EventHandler(this.button_Export_Click);
            // 
            // button_Import
            // 
            this.button_Import.Location = new System.Drawing.Point(219, 3);
            this.button_Import.Name = "button_Import";
            this.button_Import.Size = new System.Drawing.Size(75, 23);
            this.button_Import.TabIndex = 7;
            this.button_Import.Text = "Import...";
            this.button_Import.UseVisualStyleBackColor = true;
            this.button_Import.Click += new System.EventHandler(this.button_Import_Click);
            // 
            // pictureBox_TextureView
            // 
            this.pictureBox_TextureView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_TextureView.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox_TextureView.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pictureBox_TextureView.Location = new System.Drawing.Point(3, 32);
            this.pictureBox_TextureView.Name = "pictureBox_TextureView";
            this.pictureBox_TextureView.Size = new System.Drawing.Size(295, 115);
            this.pictureBox_TextureView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_TextureView.TabIndex = 3;
            this.pictureBox_TextureView.TabStop = false;
            // 
            // TextureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_Import);
            this.Controls.Add(this.button_Export);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_MipMapIndex);
            this.Controls.Add(this.pictureBox_TextureView);
            this.MinimumSize = new System.Drawing.Size(301, 150);
            this.Name = "TextureControl";
            this.Size = new System.Drawing.Size(301, 150);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MipMapIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TextureView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_MipMapIndex;
        private System.Windows.Forms.PictureBoxExt pictureBox_TextureView;
        private System.Windows.Forms.Button button_Export;
        private System.Windows.Forms.Button button_Import;
    }
}
