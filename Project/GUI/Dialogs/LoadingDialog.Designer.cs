namespace ShenmueHDTools.GUI.Dialogs
{
    partial class LoadingDialog
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
            this.progressBar_Progress = new System.Windows.Forms.ProgressBar();
            this.label_Description = new System.Windows.Forms.Label();
            this.vmuBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.vmuBox)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar_Progress
            // 
            this.progressBar_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_Progress.Location = new System.Drawing.Point(12, 28);
            this.progressBar_Progress.Name = "progressBar_Progress";
            this.progressBar_Progress.Size = new System.Drawing.Size(274, 23);
            this.progressBar_Progress.TabIndex = 0;
            // 
            // label_Description
            // 
            this.label_Description.AutoSize = true;
            this.label_Description.Location = new System.Drawing.Point(12, 9);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(54, 13);
            this.label_Description.TabIndex = 1;
            this.label_Description.Text = "Loading...";
            // 
            // vmuBox
            // 
            this.vmuBox.Location = new System.Drawing.Point(292, 19);
            this.vmuBox.Name = "vmuBox";
            this.vmuBox.Size = new System.Drawing.Size(32, 32);
            this.vmuBox.TabIndex = 2;
            this.vmuBox.TabStop = false;
            this.vmuBox.UseWaitCursor = true;
            // 
            // LoadingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 62);
            this.Controls.Add(this.vmuBox);
            this.Controls.Add(this.label_Description);
            this.Controls.Add(this.progressBar_Progress);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 100);
            this.MinimumSize = new System.Drawing.Size(350, 100);
            this.Name = "LoadingDialog";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Loading...";
            this.Shown += new System.EventHandler(this.LoadingDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.vmuBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar_Progress;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.PictureBox vmuBox;
    }
}