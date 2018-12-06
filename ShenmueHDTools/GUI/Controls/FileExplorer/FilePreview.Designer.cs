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
            this.UNKNOWN = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_DDS = new System.Windows.Forms.TabPage();
            this.DDS = new ShenmueHDTools.GUI.Controls.FileExplorer.Files.DDSControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PVR = new ShenmueHDTools.GUI.Controls.FileExplorer.Files.PVRControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.MT7 = new ShenmueHDTools.GUI.Controls.FileExplorer.Files.MT7Control();
            this.MT5 = new ShenmueHDTools.GUI.Controls.FileExplorer.Files.MT5Control();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.UNKNOWN.SuspendLayout();
            this.tabPage_DDS.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.UNKNOWN);
            this.tabControl1.Controls.Add(this.tabPage_DDS);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(510, 278);
            this.tabControl1.TabIndex = 0;
            // 
            // UNKNOWN
            // 
            this.UNKNOWN.Controls.Add(this.label1);
            this.UNKNOWN.Location = new System.Drawing.Point(4, 22);
            this.UNKNOWN.Name = "UNKNOWN";
            this.UNKNOWN.Padding = new System.Windows.Forms.Padding(3);
            this.UNKNOWN.Size = new System.Drawing.Size(502, 252);
            this.UNKNOWN.TabIndex = 0;
            this.UNKNOWN.Text = "UNKNOWN";
            this.UNKNOWN.UseVisualStyleBackColor = true;
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
            // tabPage_DDS
            // 
            this.tabPage_DDS.Controls.Add(this.DDS);
            this.tabPage_DDS.Location = new System.Drawing.Point(4, 22);
            this.tabPage_DDS.Name = "tabPage_DDS";
            this.tabPage_DDS.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DDS.Size = new System.Drawing.Size(502, 252);
            this.tabPage_DDS.TabIndex = 1;
            this.tabPage_DDS.Text = "DDS";
            this.tabPage_DDS.UseVisualStyleBackColor = true;
            // 
            // DDS
            // 
            this.DDS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DDS.Location = new System.Drawing.Point(3, 3);
            this.DDS.Name = "DDS";
            this.DDS.Size = new System.Drawing.Size(496, 246);
            this.DDS.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PVR);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(502, 252);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "PVR";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PVR
            // 
            this.PVR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PVR.Location = new System.Drawing.Point(3, 3);
            this.PVR.Name = "PVR";
            this.PVR.Size = new System.Drawing.Size(496, 246);
            this.PVR.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.MT5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(502, 252);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "MT5";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.MT7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(502, 252);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "MT7";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // MT7
            // 
            this.MT7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MT7.Location = new System.Drawing.Point(3, 3);
            this.MT7.Name = "MT7";
            this.MT7.Size = new System.Drawing.Size(496, 246);
            this.MT7.TabIndex = 0;
            // 
            // MT5
            // 
            this.MT5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MT5.Location = new System.Drawing.Point(3, 3);
            this.MT5.Name = "MT5";
            this.MT5.Size = new System.Drawing.Size(496, 246);
            this.MT5.TabIndex = 0;
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
            this.UNKNOWN.ResumeLayout(false);
            this.UNKNOWN.PerformLayout();
            this.tabPage_DDS.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private FileInformation fileInformation;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage UNKNOWN;
        private System.Windows.Forms.TabPage tabPage_DDS;
        private FileExplorer.Files.DDSControl DDS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private FileExplorer.Files.PVRControl PVR;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private FileExplorer.Files.MT5Control MT5;
        private FileExplorer.Files.MT7Control MT7;
    }
}
