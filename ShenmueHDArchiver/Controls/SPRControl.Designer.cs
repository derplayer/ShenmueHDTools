namespace ShenmueHDArchiver.Controls
{
    partial class SPRControl
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
            this.button_ExtractSPR = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox_ArchiveFiles = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_TextureName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_TextureID = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button_CreateSPR = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TextureID)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(629, 420);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(621, 394);
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
            this.splitContainer1.Panel2.Controls.Add(this.button_ExtractSPR);
            this.splitContainer1.Size = new System.Drawing.Size(615, 388);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox_ExtractFiles);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 388);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SPR Files";
            // 
            // listBox_ExtractFiles
            // 
            this.listBox_ExtractFiles.AllowDrop = true;
            this.listBox_ExtractFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_ExtractFiles.FormattingEnabled = true;
            this.listBox_ExtractFiles.Location = new System.Drawing.Point(3, 16);
            this.listBox_ExtractFiles.Name = "listBox_ExtractFiles";
            this.listBox_ExtractFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_ExtractFiles.Size = new System.Drawing.Size(199, 369);
            this.listBox_ExtractFiles.TabIndex = 0;
            this.listBox_ExtractFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_ExtractFiles_DragDrop);
            this.listBox_ExtractFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_ExtractFiles_DragEnter);
            this.listBox_ExtractFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_ExtractFiles_KeyDown);
            // 
            // button_ExtractSPR
            // 
            this.button_ExtractSPR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ExtractSPR.Location = new System.Drawing.Point(3, 345);
            this.button_ExtractSPR.Name = "button_ExtractSPR";
            this.button_ExtractSPR.Size = new System.Drawing.Size(400, 40);
            this.button_ExtractSPR.TabIndex = 2;
            this.button_ExtractSPR.Text = "Extract SPR...";
            this.button_ExtractSPR.UseVisualStyleBackColor = true;
            this.button_ExtractSPR.Click += new System.EventHandler(this.button_ExtractSPR_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(621, 394);
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
            this.splitContainer2.Panel2.Controls.Add(this.button_CreateSPR);
            this.splitContainer2.Size = new System.Drawing.Size(615, 388);
            this.splitContainer2.SplitterDistance = 205;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox_ArchiveFiles);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 388);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TEXN Files";
            // 
            // listBox_ArchiveFiles
            // 
            this.listBox_ArchiveFiles.AllowDrop = true;
            this.listBox_ArchiveFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_ArchiveFiles.FormattingEnabled = true;
            this.listBox_ArchiveFiles.Location = new System.Drawing.Point(3, 16);
            this.listBox_ArchiveFiles.Name = "listBox_ArchiveFiles";
            this.listBox_ArchiveFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_ArchiveFiles.Size = new System.Drawing.Size(199, 369);
            this.listBox_ArchiveFiles.TabIndex = 0;
            this.listBox_ArchiveFiles.SelectedIndexChanged += new System.EventHandler(this.listBox_ArchiveFiles_SelectedIndexChanged);
            this.listBox_ArchiveFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_ArchiveFiles_DragDrop);
            this.listBox_ArchiveFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_ArchiveFiles_DragEnter);
            this.listBox_ArchiveFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_ArchiveFiles_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.textBox_TextureName);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.numericUpDown_TextureID);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 336);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TEXN Properties";
            // 
            // textBox_TextureName
            // 
            this.textBox_TextureName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_TextureName.Location = new System.Drawing.Point(86, 51);
            this.textBox_TextureName.Name = "textBox_TextureName";
            this.textBox_TextureName.Size = new System.Drawing.Size(308, 20);
            this.textBox_TextureName.TabIndex = 3;
            this.textBox_TextureName.TextChanged += new System.EventHandler(this.textBox_TextureName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Texture Name:";
            // 
            // numericUpDown_TextureID
            // 
            this.numericUpDown_TextureID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_TextureID.Location = new System.Drawing.Point(86, 25);
            this.numericUpDown_TextureID.Name = "numericUpDown_TextureID";
            this.numericUpDown_TextureID.Size = new System.Drawing.Size(308, 20);
            this.numericUpDown_TextureID.TabIndex = 1;
            this.numericUpDown_TextureID.ValueChanged += new System.EventHandler(this.numericUpDown_TextureID_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Texture ID:";
            // 
            // button_CreateSPR
            // 
            this.button_CreateSPR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_CreateSPR.Location = new System.Drawing.Point(3, 345);
            this.button_CreateSPR.Name = "button_CreateSPR";
            this.button_CreateSPR.Size = new System.Drawing.Size(400, 40);
            this.button_CreateSPR.TabIndex = 3;
            this.button_CreateSPR.Text = "Create SPR...";
            this.button_CreateSPR.UseVisualStyleBackColor = true;
            this.button_CreateSPR.Click += new System.EventHandler(this.button_CreateSPR_Click);
            // 
            // SPRControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "SPRControl";
            this.Size = new System.Drawing.Size(629, 420);
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TextureID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox_ExtractFiles;
        private System.Windows.Forms.Button button_ExtractSPR;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox_ArchiveFiles;
        private System.Windows.Forms.Button button_CreateSPR;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_TextureName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_TextureID;
        private System.Windows.Forms.Label label1;
    }
}
