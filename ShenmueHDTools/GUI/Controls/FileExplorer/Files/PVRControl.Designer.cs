namespace ShenmueHDTools.GUI.Controls.FileExplorer.Files
{
    partial class PVRControl
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
            this.pictureBox_Preview = new System.Windows.Forms.PictureBox();
            this.pictureBox_PreviewDL = new System.Windows.Forms.PictureBox();
            this.label_Original = new System.Windows.Forms.Label();
            this.label_DL = new System.Windows.Forms.Label();
            this.buttonDL_4x = new System.Windows.Forms.Button();
            this.buttonDL_2x = new System.Windows.Forms.Button();
            this.buttonSaveOrig = new System.Windows.Forms.Button();
            this.buttonSaveDL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PreviewDL)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Preview
            // 
            this.pictureBox_Preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Preview.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox_Preview.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Preview.Name = "pictureBox_Preview";
            this.pictureBox_Preview.Size = new System.Drawing.Size(214, 383);
            this.pictureBox_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Preview.TabIndex = 0;
            this.pictureBox_Preview.TabStop = false;
            // 
            // pictureBox_PreviewDL
            // 
            this.pictureBox_PreviewDL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_PreviewDL.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox_PreviewDL.Location = new System.Drawing.Point(317, 0);
            this.pictureBox_PreviewDL.Name = "pictureBox_PreviewDL";
            this.pictureBox_PreviewDL.Size = new System.Drawing.Size(438, 383);
            this.pictureBox_PreviewDL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_PreviewDL.TabIndex = 1;
            this.pictureBox_PreviewDL.TabStop = false;
            this.pictureBox_PreviewDL.MouseEnter += new System.EventHandler(this.OnMouseEnterPreview);
            this.pictureBox_PreviewDL.MouseLeave += new System.EventHandler(this.OnMouseLeavePreview);
            // 
            // label_Original
            // 
            this.label_Original.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Original.AutoSize = true;
            this.label_Original.Location = new System.Drawing.Point(3, 370);
            this.label_Original.Name = "label_Original";
            this.label_Original.Size = new System.Drawing.Size(42, 13);
            this.label_Original.TabIndex = 2;
            this.label_Original.Text = "Original";
            // 
            // label_DL
            // 
            this.label_DL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_DL.AutoSize = true;
            this.label_DL.Location = new System.Drawing.Point(638, 370);
            this.label_DL.Name = "label_DL";
            this.label_DL.Size = new System.Drawing.Size(117, 13);
            this.label_DL.TabIndex = 3;
            this.label_DL.Text = "Deep Learning (Ready)";
            this.label_DL.Click += new System.EventHandler(this.label_DL_Click);
            // 
            // buttonDL_4x
            // 
            this.buttonDL_4x.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonDL_4x.Location = new System.Drawing.Point(214, 360);
            this.buttonDL_4x.Name = "buttonDL_4x";
            this.buttonDL_4x.Size = new System.Drawing.Size(103, 23);
            this.buttonDL_4x.TabIndex = 4;
            this.buttonDL_4x.Text = "Improve - 4x";
            this.buttonDL_4x.UseVisualStyleBackColor = true;
            this.buttonDL_4x.Click += new System.EventHandler(this.buttonDL_4x_Click);
            // 
            // buttonDL_2x
            // 
            this.buttonDL_2x.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonDL_2x.Location = new System.Drawing.Point(214, 337);
            this.buttonDL_2x.Name = "buttonDL_2x";
            this.buttonDL_2x.Size = new System.Drawing.Size(103, 23);
            this.buttonDL_2x.TabIndex = 5;
            this.buttonDL_2x.Text = "Improve - 2x";
            this.buttonDL_2x.UseVisualStyleBackColor = true;
            // 
            // buttonSaveOrig
            // 
            this.buttonSaveOrig.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSaveOrig.Location = new System.Drawing.Point(214, 0);
            this.buttonSaveOrig.Name = "buttonSaveOrig";
            this.buttonSaveOrig.Size = new System.Drawing.Size(103, 23);
            this.buttonSaveOrig.TabIndex = 6;
            this.buttonSaveOrig.Text = "Save Original";
            this.buttonSaveOrig.UseVisualStyleBackColor = true;
            this.buttonSaveOrig.Click += new System.EventHandler(this.buttonSaveOrig_Click);
            // 
            // buttonSaveDL
            // 
            this.buttonSaveDL.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSaveDL.Location = new System.Drawing.Point(214, 23);
            this.buttonSaveDL.Name = "buttonSaveDL";
            this.buttonSaveDL.Size = new System.Drawing.Size(103, 23);
            this.buttonSaveDL.TabIndex = 7;
            this.buttonSaveDL.Text = "Save DL";
            this.buttonSaveDL.UseVisualStyleBackColor = true;
            this.buttonSaveDL.Click += new System.EventHandler(this.buttonSaveDL_Click);
            // 
            // PVRControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSaveDL);
            this.Controls.Add(this.buttonSaveOrig);
            this.Controls.Add(this.buttonDL_2x);
            this.Controls.Add(this.buttonDL_4x);
            this.Controls.Add(this.label_DL);
            this.Controls.Add(this.label_Original);
            this.Controls.Add(this.pictureBox_Preview);
            this.Controls.Add(this.pictureBox_PreviewDL);
            this.Name = "PVRControl";
            this.Size = new System.Drawing.Size(755, 383);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PreviewDL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Preview;
        private System.Windows.Forms.PictureBox pictureBox_PreviewDL;
        private System.Windows.Forms.Label label_Original;
        private System.Windows.Forms.Label label_DL;
        private System.Windows.Forms.Button buttonDL_4x;
        private System.Windows.Forms.Button buttonDL_2x;
        private System.Windows.Forms.Button buttonSaveOrig;
        private System.Windows.Forms.Button buttonSaveDL;
    }
}
