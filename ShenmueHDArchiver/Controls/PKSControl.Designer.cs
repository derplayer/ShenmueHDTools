namespace ShenmueHDArchiver.Controls
{
    partial class PKSControl
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
            this.button_ExtractPKS = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox_ArchiveFiles = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_FileExtension = new System.Windows.Forms.TextBox();
            this.textBox_FileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_Compress = new System.Windows.Forms.CheckBox();
            this.button_CreatePKS = new System.Windows.Forms.Button();
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
            this.groupBox4.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(557, 348);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(549, 322);
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
            this.splitContainer1.Panel2.Controls.Add(this.button_ExtractPKS);
            this.splitContainer1.Size = new System.Drawing.Size(543, 316);
            this.splitContainer1.SplitterDistance = 181;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox_ExtractFiles);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 316);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PKS Files";
            // 
            // listBox_ExtractFiles
            // 
            this.listBox_ExtractFiles.AllowDrop = true;
            this.listBox_ExtractFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_ExtractFiles.FormattingEnabled = true;
            this.listBox_ExtractFiles.Location = new System.Drawing.Point(3, 16);
            this.listBox_ExtractFiles.Name = "listBox_ExtractFiles";
            this.listBox_ExtractFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_ExtractFiles.Size = new System.Drawing.Size(175, 297);
            this.listBox_ExtractFiles.TabIndex = 0;
            this.listBox_ExtractFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_ExtractFiles_DragDrop);
            this.listBox_ExtractFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_ExtractFiles_DragEnter);
            this.listBox_ExtractFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_ExtractFiles_KeyDown);
            // 
            // button_ExtractPKS
            // 
            this.button_ExtractPKS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ExtractPKS.Location = new System.Drawing.Point(3, 273);
            this.button_ExtractPKS.Name = "button_ExtractPKS";
            this.button_ExtractPKS.Size = new System.Drawing.Size(352, 40);
            this.button_ExtractPKS.TabIndex = 4;
            this.button_ExtractPKS.Text = "Extract PKS...";
            this.button_ExtractPKS.UseVisualStyleBackColor = true;
            this.button_ExtractPKS.Click += new System.EventHandler(this.button_ExtractPKS_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(549, 322);
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
            this.splitContainer2.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel2.Controls.Add(this.button_CreatePKS);
            this.splitContainer2.Size = new System.Drawing.Size(543, 316);
            this.splitContainer2.SplitterDistance = 181;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox_ArchiveFiles);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 316);
            this.groupBox2.TabIndex = 1;
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
            this.listBox_ArchiveFiles.Size = new System.Drawing.Size(175, 297);
            this.listBox_ArchiveFiles.TabIndex = 0;
            this.listBox_ArchiveFiles.SelectedIndexChanged += new System.EventHandler(this.listBox_ArchiveFiles_SelectedIndexChanged);
            this.listBox_ArchiveFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_ArchiveFiles_DragDrop);
            this.listBox_ArchiveFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_ArchiveFiles_DragEnter);
            this.listBox_ArchiveFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_ArchiveFiles_KeyDown);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.textBox_FileExtension);
            this.groupBox4.Controls.Add(this.textBox_FileName);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(3, 73);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(352, 194);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "IPAC Entry Properties";
            // 
            // textBox_FileExtension
            // 
            this.textBox_FileExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_FileExtension.Location = new System.Drawing.Point(97, 58);
            this.textBox_FileExtension.Name = "textBox_FileExtension";
            this.textBox_FileExtension.Size = new System.Drawing.Size(249, 20);
            this.textBox_FileExtension.TabIndex = 3;
            this.textBox_FileExtension.TextChanged += new System.EventHandler(this.textBox_FileExtension_TextChanged);
            // 
            // textBox_FileName
            // 
            this.textBox_FileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_FileName.Location = new System.Drawing.Point(97, 32);
            this.textBox_FileName.Name = "textBox_FileName";
            this.textBox_FileName.Size = new System.Drawing.Size(249, 20);
            this.textBox_FileName.TabIndex = 2;
            this.textBox_FileName.TextChanged += new System.EventHandler(this.textBox_FileName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "File Extension:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.checkBox_Compress);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(352, 64);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // checkBox_Compress
            // 
            this.checkBox_Compress.AutoSize = true;
            this.checkBox_Compress.Location = new System.Drawing.Point(19, 28);
            this.checkBox_Compress.Name = "checkBox_Compress";
            this.checkBox_Compress.Size = new System.Drawing.Size(96, 17);
            this.checkBox_Compress.TabIndex = 1;
            this.checkBox_Compress.Text = "Compress PKS";
            this.checkBox_Compress.UseVisualStyleBackColor = true;
            // 
            // button_CreatePKS
            // 
            this.button_CreatePKS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_CreatePKS.Location = new System.Drawing.Point(2, 273);
            this.button_CreatePKS.Name = "button_CreatePKS";
            this.button_CreatePKS.Size = new System.Drawing.Size(353, 40);
            this.button_CreatePKS.TabIndex = 5;
            this.button_CreatePKS.Text = "Create PKS...";
            this.button_CreatePKS.UseVisualStyleBackColor = true;
            this.button_CreatePKS.Click += new System.EventHandler(this.button_CreatePKS_Click);
            // 
            // PKSControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "PKSControl";
            this.Size = new System.Drawing.Size(557, 348);
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
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox listBox_ExtractFiles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox_ArchiveFiles;
        private System.Windows.Forms.Button button_ExtractPKS;
        private System.Windows.Forms.Button button_CreatePKS;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox_Compress;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_FileExtension;
        private System.Windows.Forms.TextBox textBox_FileName;
        private System.Windows.Forms.Label label2;
    }
}
