namespace ShenmueHDArchiver.Controls
{
    partial class AFSControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox_ExtractFiles = new System.Windows.Forms.ListBox();
            this.button_ExtractAFS = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox_ArchiveFiles = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_FileName = new System.Windows.Forms.TextBox();
            this.dateTimePicker_FileDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_SectorSize = new System.Windows.Forms.NumericUpDown();
            this.button_CreateAFS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SectorSize)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.button_ExtractAFS);
            this.splitContainer1.Size = new System.Drawing.Size(467, 339);
            this.splitContainer1.SplitterDistance = 155;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox_ExtractFiles);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 339);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AFS Files";
            // 
            // listBox_ExtractFiles
            // 
            this.listBox_ExtractFiles.AllowDrop = true;
            this.listBox_ExtractFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_ExtractFiles.FormattingEnabled = true;
            this.listBox_ExtractFiles.Location = new System.Drawing.Point(3, 16);
            this.listBox_ExtractFiles.Name = "listBox_ExtractFiles";
            this.listBox_ExtractFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_ExtractFiles.Size = new System.Drawing.Size(149, 320);
            this.listBox_ExtractFiles.TabIndex = 0;
            this.listBox_ExtractFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_ExtractFiles_DragDrop);
            this.listBox_ExtractFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_ExtractFiles_DragEnter);
            this.listBox_ExtractFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_ExtractFiles_KeyDown);
            // 
            // button_ExtractAFS
            // 
            this.button_ExtractAFS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ExtractAFS.Location = new System.Drawing.Point(3, 296);
            this.button_ExtractAFS.Name = "button_ExtractAFS";
            this.button_ExtractAFS.Size = new System.Drawing.Size(302, 40);
            this.button_ExtractAFS.TabIndex = 5;
            this.button_ExtractAFS.Text = "Extract AFS...";
            this.button_ExtractAFS.UseVisualStyleBackColor = true;
            this.button_ExtractAFS.Click += new System.EventHandler(this.button_ExtractAFS_Click);
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
            this.tabControl1.Size = new System.Drawing.Size(481, 371);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(473, 345);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Unpack";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(473, 345);
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
            this.splitContainer2.Panel2.Controls.Add(this.button_CreateAFS);
            this.splitContainer2.Size = new System.Drawing.Size(467, 339);
            this.splitContainer2.SplitterDistance = 155;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox_ArchiveFiles);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 339);
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
            this.listBox_ArchiveFiles.Size = new System.Drawing.Size(149, 320);
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
            this.groupBox4.Controls.Add(this.textBox_FileName);
            this.groupBox4.Controls.Add(this.dateTimePicker_FileDate);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(3, 73);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(302, 217);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "AFS Entry Properties";
            // 
            // textBox_FileName
            // 
            this.textBox_FileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_FileName.Location = new System.Drawing.Point(84, 29);
            this.textBox_FileName.Name = "textBox_FileName";
            this.textBox_FileName.Size = new System.Drawing.Size(212, 20);
            this.textBox_FileName.TabIndex = 3;
            this.textBox_FileName.TextChanged += new System.EventHandler(this.textBox_FileName_TextChanged);
            // 
            // dateTimePicker_FileDate
            // 
            this.dateTimePicker_FileDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_FileDate.Location = new System.Drawing.Point(84, 55);
            this.dateTimePicker_FileDate.Name = "dateTimePicker_FileDate";
            this.dateTimePicker_FileDate.Size = new System.Drawing.Size(212, 20);
            this.dateTimePicker_FileDate.TabIndex = 2;
            this.dateTimePicker_FileDate.ValueChanged += new System.EventHandler(this.dateTimePicker_FileDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "File Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "File Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.numericUpDown_SectorSize);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 64);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sector Size:";
            // 
            // numericUpDown_SectorSize
            // 
            this.numericUpDown_SectorSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_SectorSize.Increment = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.numericUpDown_SectorSize.Location = new System.Drawing.Point(91, 27);
            this.numericUpDown_SectorSize.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.numericUpDown_SectorSize.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDown_SectorSize.Name = "numericUpDown_SectorSize";
            this.numericUpDown_SectorSize.Size = new System.Drawing.Size(205, 20);
            this.numericUpDown_SectorSize.TabIndex = 0;
            this.numericUpDown_SectorSize.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // button_CreateAFS
            // 
            this.button_CreateAFS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_CreateAFS.Location = new System.Drawing.Point(3, 296);
            this.button_CreateAFS.Name = "button_CreateAFS";
            this.button_CreateAFS.Size = new System.Drawing.Size(302, 40);
            this.button_CreateAFS.TabIndex = 6;
            this.button_CreateAFS.Text = "Create AFS...";
            this.button_CreateAFS.UseVisualStyleBackColor = true;
            this.button_CreateAFS.Click += new System.EventHandler(this.button_CreateAFS_Click);
            // 
            // AFSControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "AFSControl";
            this.Size = new System.Drawing.Size(481, 371);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SectorSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox_ExtractFiles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox_ArchiveFiles;
        private System.Windows.Forms.Button button_ExtractAFS;
        private System.Windows.Forms.Button button_CreateAFS;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_SectorSize;
        private System.Windows.Forms.TextBox textBox_FileName;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FileDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
