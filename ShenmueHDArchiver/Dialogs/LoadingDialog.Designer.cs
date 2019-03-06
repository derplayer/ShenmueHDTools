namespace ShenmueHDArchiver.Dialogs
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
            this.button_Abort = new System.Windows.Forms.Button();
            this.label_Description = new System.Windows.Forms.Label();
            this.progressBar_Progress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // button_Abort
            // 
            this.button_Abort.Location = new System.Drawing.Point(12, 57);
            this.button_Abort.Name = "button_Abort";
            this.button_Abort.Size = new System.Drawing.Size(312, 23);
            this.button_Abort.TabIndex = 6;
            this.button_Abort.Text = "Abort";
            this.button_Abort.UseVisualStyleBackColor = true;
            this.button_Abort.Click += new System.EventHandler(this.button_Abort_Click);
            // 
            // label_Description
            // 
            this.label_Description.AutoSize = true;
            this.label_Description.Location = new System.Drawing.Point(12, 9);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(54, 13);
            this.label_Description.TabIndex = 5;
            this.label_Description.Text = "Loading...";
            // 
            // progressBar_Progress
            // 
            this.progressBar_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_Progress.Location = new System.Drawing.Point(12, 28);
            this.progressBar_Progress.Name = "progressBar_Progress";
            this.progressBar_Progress.Size = new System.Drawing.Size(312, 23);
            this.progressBar_Progress.TabIndex = 4;
            // 
            // LoadingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 86);
            this.Controls.Add(this.button_Abort);
            this.Controls.Add(this.label_Description);
            this.Controls.Add(this.progressBar_Progress);
            this.Name = "LoadingDialog";
            this.Text = "Loading...";
            this.Shown += new System.EventHandler(this.LoadingDialog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Abort;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.ProgressBar progressBar_Progress;
    }
}