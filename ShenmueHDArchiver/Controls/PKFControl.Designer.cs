namespace ShenmueHDArchiver.Controls
{
    partial class PKFControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox_ExtractFiles = new System.Windows.Forms.ListBox();
            this.button_ExtractPKF = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox_ArchiveFiles = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_Compress = new System.Windows.Forms.CheckBox();
            this.button_CreatePKF = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(567, 409);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(559, 383);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Unpack";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button_ExtractPKF);
            this.splitContainer1.Size = new System.Drawing.Size(553, 377);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox_ExtractFiles);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 377);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PKF Files";
            // 
            // listBox_ExtractFiles
            // 
            this.listBox_ExtractFiles.AllowDrop = true;
            this.listBox_ExtractFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_ExtractFiles.FormattingEnabled = true;
            this.listBox_ExtractFiles.Location = new System.Drawing.Point(3, 16);
            this.listBox_ExtractFiles.Name = "listBox_ExtractFiles";
            this.listBox_ExtractFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_ExtractFiles.Size = new System.Drawing.Size(178, 358);
            this.listBox_ExtractFiles.TabIndex = 0;
            this.listBox_ExtractFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_ExtractFiles_DragDrop);
            this.listBox_ExtractFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_ExtractFiles_DragEnter);
            this.listBox_ExtractFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_ExtractFiles_KeyDown);
            // 
            // button_ExtractPKF
            // 
            this.button_ExtractPKF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ExtractPKF.Location = new System.Drawing.Point(3, 334);
            this.button_ExtractPKF.Name = "button_ExtractPKF";
            this.button_ExtractPKF.Size = new System.Drawing.Size(359, 40);
            this.button_ExtractPKF.TabIndex = 3;
            this.button_ExtractPKF.Text = "Extract PKF...";
            this.button_ExtractPKF.UseVisualStyleBackColor = true;
            this.button_ExtractPKF.Click += new System.EventHandler(this.button_ExtractPKF_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(559, 383);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pack";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel2.Controls.Add(this.button_CreatePKF);
            this.splitContainer2.Size = new System.Drawing.Size(553, 377);
            this.splitContainer2.SplitterDistance = 184;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox_ArchiveFiles);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(184, 377);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Files";
            // 
            // listBox_ArchiveFiles
            // 
            this.listBox_ArchiveFiles.AllowDrop = true;
            this.listBox_ArchiveFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_ArchiveFiles.FormattingEnabled = true;
            this.listBox_ArchiveFiles.Location = new System.Drawing.Point(3, 16);
            this.listBox_ArchiveFiles.Name = "listBox_ArchiveFiles";
            this.listBox_ArchiveFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_ArchiveFiles.Size = new System.Drawing.Size(178, 358);
            this.listBox_ArchiveFiles.TabIndex = 0;
            this.listBox_ArchiveFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_ArchiveFiles_DragDrop);
            this.listBox_ArchiveFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_ArchiveFiles_DragEnter);
            this.listBox_ArchiveFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_ArchiveFiles_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.checkBox_Compress);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(359, 325);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // checkBox_Compress
            // 
            this.checkBox_Compress.AutoSize = true;
            this.checkBox_Compress.Location = new System.Drawing.Point(19, 29);
            this.checkBox_Compress.Name = "checkBox_Compress";
            this.checkBox_Compress.Size = new System.Drawing.Size(95, 17);
            this.checkBox_Compress.TabIndex = 0;
            this.checkBox_Compress.Text = "Compress PKF";
            this.checkBox_Compress.UseVisualStyleBackColor = true;
            // 
            // button_CreatePKF
            // 
            this.button_CreatePKF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_CreatePKF.Location = new System.Drawing.Point(3, 334);
            this.button_CreatePKF.Name = "button_CreatePKF";
            this.button_CreatePKF.Size = new System.Drawing.Size(359, 40);
            this.button_CreatePKF.TabIndex = 4;
            this.button_CreatePKF.Text = "Create PKF...";
            this.button_CreatePKF.UseVisualStyleBackColor = true;
            this.button_CreatePKF.Click += new System.EventHandler(this.button_CreatePKF_Click);
            // 
            // PKFControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "PKFControl";
            this.Size = new System.Drawing.Size(567, 409);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox_ExtractFiles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox_ArchiveFiles;
        private System.Windows.Forms.Button button_ExtractPKF;
        private System.Windows.Forms.Button button_CreatePKF;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox_Compress;
    }
}
