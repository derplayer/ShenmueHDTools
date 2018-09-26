namespace ShenmueHDTools.GUI.Controls
{
    partial class FilePreview
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fileInformation = new ShenmueHDTools.GUI.Controls.FileInformation();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_UNKNOWN = new System.Windows.Forms.TabPage();
            this.tabPage_DDS = new System.Windows.Forms.TabPage();
            this.ddsControl1 = new ShenmueHDTools.GUI.Controls.FileExplorer.Files.DDSControl();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_UNKNOWN.SuspendLayout();
            this.tabPage_DDS.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fileInformation);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(510, 432);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 0;
            // 
            // fileInformation
            // 
            this.fileInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileInformation.Location = new System.Drawing.Point(0, 0);
            this.fileInformation.Name = "fileInformation";
            this.fileInformation.Size = new System.Drawing.Size(510, 150);
            this.fileInformation.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_UNKNOWN);
            this.tabControl1.Controls.Add(this.tabPage_DDS);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(510, 278);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_UNKNOWN
            // 
            this.tabPage_UNKNOWN.Controls.Add(this.label1);
            this.tabPage_UNKNOWN.Location = new System.Drawing.Point(4, 22);
            this.tabPage_UNKNOWN.Name = "tabPage_UNKNOWN";
            this.tabPage_UNKNOWN.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_UNKNOWN.Size = new System.Drawing.Size(502, 252);
            this.tabPage_UNKNOWN.TabIndex = 0;
            this.tabPage_UNKNOWN.Text = "UNKNOWN";
            this.tabPage_UNKNOWN.UseVisualStyleBackColor = true;
            // 
            // tabPage_DDS
            // 
            this.tabPage_DDS.Controls.Add(this.ddsControl1);
            this.tabPage_DDS.Location = new System.Drawing.Point(4, 22);
            this.tabPage_DDS.Name = "tabPage_DDS";
            this.tabPage_DDS.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DDS.Size = new System.Drawing.Size(502, 252);
            this.tabPage_DDS.TabIndex = 1;
            this.tabPage_DDS.Text = "DDS";
            this.tabPage_DDS.UseVisualStyleBackColor = true;
            // 
            // ddsControl1
            // 
            this.ddsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddsControl1.Location = new System.Drawing.Point(3, 3);
            this.ddsControl1.Name = "ddsControl1";
            this.ddsControl1.Size = new System.Drawing.Size(496, 246);
            this.ddsControl1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "UNKNOWN";
            // 
            // FilePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FilePreview";
            this.Size = new System.Drawing.Size(510, 432);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_UNKNOWN.ResumeLayout(false);
            this.tabPage_UNKNOWN.PerformLayout();
            this.tabPage_DDS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private FileInformation fileInformation;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_UNKNOWN;
        private System.Windows.Forms.TabPage tabPage_DDS;
        private FileExplorer.Files.DDSControl ddsControl1;
        private System.Windows.Forms.Label label1;
    }
}
