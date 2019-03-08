namespace ShenmueHDArchiver.Controls
{
    partial class TADControl
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox_ExtractFiles = new System.Windows.Forms.ListBox();
            this.button_ExtractTAD = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox_ModelDump = new System.Windows.Forms.GroupBox();
            this.textBox_ModelFolder = new System.Windows.Forms.TextBox();
            this.comboBox_ModelType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_BrowseModelFolder = new System.Windows.Forms.Button();
            this.checkBox_DumpModels = new System.Windows.Forms.CheckBox();
            this.checkBox_FullExtract = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox_ArchiveFiles = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_TAD = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_SingleHash = new System.Windows.Forms.CheckBox();
            this.textBox_Hash2 = new System.Windows.Forms.TextBox();
            this.textBox_Hash1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Filepath = new System.Windows.Forms.TextBox();
            this.button_CreateTAD = new System.Windows.Forms.Button();
            this.textBox_MurmurHash = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_MurmurHash2 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox_ModelDump.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(898, 472);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(890, 446);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Unpack";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.button_ExtractTAD);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer2.Size = new System.Drawing.Size(884, 440);
            this.splitContainer2.SplitterDistance = 294;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox_ExtractFiles);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(294, 440);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TAD Files";
            // 
            // listBox_ExtractFiles
            // 
            this.listBox_ExtractFiles.AllowDrop = true;
            this.listBox_ExtractFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_ExtractFiles.FormattingEnabled = true;
            this.listBox_ExtractFiles.Location = new System.Drawing.Point(3, 16);
            this.listBox_ExtractFiles.Name = "listBox_ExtractFiles";
            this.listBox_ExtractFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_ExtractFiles.Size = new System.Drawing.Size(288, 421);
            this.listBox_ExtractFiles.TabIndex = 0;
            this.listBox_ExtractFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_ExtractFiles_DragDrop);
            this.listBox_ExtractFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_ExtractFiles_DragEnter);
            this.listBox_ExtractFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_ExtractFiles_KeyDown);
            // 
            // button_ExtractTAD
            // 
            this.button_ExtractTAD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ExtractTAD.Location = new System.Drawing.Point(2, 397);
            this.button_ExtractTAD.Name = "button_ExtractTAD";
            this.button_ExtractTAD.Size = new System.Drawing.Size(580, 40);
            this.button_ExtractTAD.TabIndex = 1;
            this.button_ExtractTAD.Text = "Extract TAC...";
            this.button_ExtractTAD.UseVisualStyleBackColor = true;
            this.button_ExtractTAD.Click += new System.EventHandler(this.button_ExtractTAD_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.groupBox_ModelDump);
            this.groupBox5.Controls.Add(this.checkBox_DumpModels);
            this.groupBox5.Controls.Add(this.checkBox_FullExtract);
            this.groupBox5.Location = new System.Drawing.Point(2, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(581, 388);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Settings";
            // 
            // groupBox_ModelDump
            // 
            this.groupBox_ModelDump.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_ModelDump.Controls.Add(this.textBox_ModelFolder);
            this.groupBox_ModelDump.Controls.Add(this.comboBox_ModelType);
            this.groupBox_ModelDump.Controls.Add(this.label6);
            this.groupBox_ModelDump.Controls.Add(this.label5);
            this.groupBox_ModelDump.Controls.Add(this.button_BrowseModelFolder);
            this.groupBox_ModelDump.Enabled = false;
            this.groupBox_ModelDump.Location = new System.Drawing.Point(6, 77);
            this.groupBox_ModelDump.Name = "groupBox_ModelDump";
            this.groupBox_ModelDump.Size = new System.Drawing.Size(569, 305);
            this.groupBox_ModelDump.TabIndex = 7;
            this.groupBox_ModelDump.TabStop = false;
            this.groupBox_ModelDump.Text = "Model Dump";
            // 
            // textBox_ModelFolder
            // 
            this.textBox_ModelFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ModelFolder.Location = new System.Drawing.Point(86, 25);
            this.textBox_ModelFolder.Name = "textBox_ModelFolder";
            this.textBox_ModelFolder.Size = new System.Drawing.Size(431, 20);
            this.textBox_ModelFolder.TabIndex = 2;
            // 
            // comboBox_ModelType
            // 
            this.comboBox_ModelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ModelType.FormattingEnabled = true;
            this.comboBox_ModelType.Items.AddRange(new object[] {
            "MT5",
            "MT7"});
            this.comboBox_ModelType.Location = new System.Drawing.Point(86, 51);
            this.comboBox_ModelType.MaxDropDownItems = 2;
            this.comboBox_ModelType.Name = "comboBox_ModelType";
            this.comboBox_ModelType.Size = new System.Drawing.Size(121, 21);
            this.comboBox_ModelType.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Model Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Model Folder:";
            // 
            // button_BrowseModelFolder
            // 
            this.button_BrowseModelFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_BrowseModelFolder.Location = new System.Drawing.Point(523, 24);
            this.button_BrowseModelFolder.Name = "button_BrowseModelFolder";
            this.button_BrowseModelFolder.Size = new System.Drawing.Size(40, 22);
            this.button_BrowseModelFolder.TabIndex = 4;
            this.button_BrowseModelFolder.Text = "...";
            this.button_BrowseModelFolder.UseVisualStyleBackColor = true;
            this.button_BrowseModelFolder.Click += new System.EventHandler(this.button_BrowseModelFolder_Click);
            // 
            // checkBox_DumpModels
            // 
            this.checkBox_DumpModels.AutoSize = true;
            this.checkBox_DumpModels.Enabled = false;
            this.checkBox_DumpModels.Location = new System.Drawing.Point(18, 50);
            this.checkBox_DumpModels.Name = "checkBox_DumpModels";
            this.checkBox_DumpModels.Size = new System.Drawing.Size(90, 17);
            this.checkBox_DumpModels.TabIndex = 1;
            this.checkBox_DumpModels.Text = "Dump models";
            this.checkBox_DumpModels.UseVisualStyleBackColor = true;
            this.checkBox_DumpModels.CheckedChanged += new System.EventHandler(this.checkBox_DumpModels_CheckedChanged);
            // 
            // checkBox_FullExtract
            // 
            this.checkBox_FullExtract.AutoSize = true;
            this.checkBox_FullExtract.Enabled = false;
            this.checkBox_FullExtract.Location = new System.Drawing.Point(18, 27);
            this.checkBox_FullExtract.Name = "checkBox_FullExtract";
            this.checkBox_FullExtract.Size = new System.Drawing.Size(169, 17);
            this.checkBox_FullExtract.TabIndex = 0;
            this.checkBox_FullExtract.Text = "Extract all archives inside TAC";
            this.checkBox_FullExtract.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(890, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pack";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.button_CreateTAD);
            this.splitContainer1.Size = new System.Drawing.Size(884, 440);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox_ArchiveFiles);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 440);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Files";
            // 
            // listBox_ArchiveFiles
            // 
            this.listBox_ArchiveFiles.AllowDrop = true;
            this.listBox_ArchiveFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_ArchiveFiles.FormattingEnabled = true;
            this.listBox_ArchiveFiles.Location = new System.Drawing.Point(3, 16);
            this.listBox_ArchiveFiles.Name = "listBox_ArchiveFiles";
            this.listBox_ArchiveFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_ArchiveFiles.Size = new System.Drawing.Size(288, 421);
            this.listBox_ArchiveFiles.TabIndex = 0;
            this.listBox_ArchiveFiles.SelectedIndexChanged += new System.EventHandler(this.listBox_ArchiveFiles_SelectedIndexChanged);
            this.listBox_ArchiveFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_ArchiveFiles_DragDrop);
            this.listBox_ArchiveFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_ArchiveFiles_DragEnter);
            this.listBox_ArchiveFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_ArchiveFiles_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dateTimePicker_TAD);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(580, 63);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TAD Properties";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Build Date:";
            // 
            // dateTimePicker_TAD
            // 
            this.dateTimePicker_TAD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_TAD.Location = new System.Drawing.Point(80, 26);
            this.dateTimePicker_TAD.Name = "dateTimePicker_TAD";
            this.dateTimePicker_TAD.Size = new System.Drawing.Size(494, 20);
            this.dateTimePicker_TAD.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBox_MurmurHash2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox_MurmurHash);
            this.groupBox2.Controls.Add(this.checkBox_SingleHash);
            this.groupBox2.Controls.Add(this.textBox_Hash2);
            this.groupBox2.Controls.Add(this.textBox_Hash1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_Filepath);
            this.groupBox2.Location = new System.Drawing.Point(3, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 319);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Properties";
            // 
            // checkBox_SingleHash
            // 
            this.checkBox_SingleHash.AutoSize = true;
            this.checkBox_SingleHash.Checked = true;
            this.checkBox_SingleHash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_SingleHash.Location = new System.Drawing.Point(80, 123);
            this.checkBox_SingleHash.Name = "checkBox_SingleHash";
            this.checkBox_SingleHash.Size = new System.Drawing.Size(83, 17);
            this.checkBox_SingleHash.TabIndex = 13;
            this.checkBox_SingleHash.Text = "Single Hash";
            this.checkBox_SingleHash.UseVisualStyleBackColor = true;
            // 
            // textBox_Hash2
            // 
            this.textBox_Hash2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Hash2.Location = new System.Drawing.Point(80, 93);
            this.textBox_Hash2.Name = "textBox_Hash2";
            this.textBox_Hash2.ReadOnly = true;
            this.textBox_Hash2.Size = new System.Drawing.Size(494, 20);
            this.textBox_Hash2.TabIndex = 12;
            // 
            // textBox_Hash1
            // 
            this.textBox_Hash1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Hash1.Location = new System.Drawing.Point(80, 63);
            this.textBox_Hash1.Name = "textBox_Hash1";
            this.textBox_Hash1.ReadOnly = true;
            this.textBox_Hash1.Size = new System.Drawing.Size(494, 20);
            this.textBox_Hash1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Hash2:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Hash1:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Filepath:";
            // 
            // textBox_Filepath
            // 
            this.textBox_Filepath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Filepath.Location = new System.Drawing.Point(80, 31);
            this.textBox_Filepath.Name = "textBox_Filepath";
            this.textBox_Filepath.Size = new System.Drawing.Size(494, 20);
            this.textBox_Filepath.TabIndex = 7;
            this.textBox_Filepath.TextChanged += new System.EventHandler(this.textBox_Filepath_TextChanged);
            // 
            // button_CreateTAD
            // 
            this.button_CreateTAD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_CreateTAD.Location = new System.Drawing.Point(3, 397);
            this.button_CreateTAD.Name = "button_CreateTAD";
            this.button_CreateTAD.Size = new System.Drawing.Size(580, 40);
            this.button_CreateTAD.TabIndex = 0;
            this.button_CreateTAD.Text = "Create TAD/TAC...";
            this.button_CreateTAD.UseVisualStyleBackColor = true;
            this.button_CreateTAD.Click += new System.EventHandler(this.button_CreateTAD_Click);
            // 
            // textBox_MurmurHash
            // 
            this.textBox_MurmurHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_MurmurHash.Location = new System.Drawing.Point(92, 150);
            this.textBox_MurmurHash.Name = "textBox_MurmurHash";
            this.textBox_MurmurHash.Size = new System.Drawing.Size(482, 20);
            this.textBox_MurmurHash.TabIndex = 14;
            this.textBox_MurmurHash.TextChanged += new System.EventHandler(this.textBox_MurmurHash_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "MurmurHash2:";
            // 
            // textBox_MurmurHash2
            // 
            this.textBox_MurmurHash2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_MurmurHash2.Location = new System.Drawing.Point(92, 176);
            this.textBox_MurmurHash2.Name = "textBox_MurmurHash2";
            this.textBox_MurmurHash2.ReadOnly = true;
            this.textBox_MurmurHash2.Size = new System.Drawing.Size(482, 20);
            this.textBox_MurmurHash2.TabIndex = 16;
            // 
            // TADControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TADControl";
            this.Size = new System.Drawing.Size(898, 472);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox_ModelDump.ResumeLayout(false);
            this.groupBox_ModelDump.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox_ArchiveFiles;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_TAD;
        private System.Windows.Forms.CheckBox checkBox_SingleHash;
        private System.Windows.Forms.TextBox textBox_Hash2;
        private System.Windows.Forms.TextBox textBox_Hash1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Filepath;
        private System.Windows.Forms.Button button_CreateTAD;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBox_ExtractFiles;
        private System.Windows.Forms.Button button_ExtractTAD;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox_FullExtract;
        private System.Windows.Forms.CheckBox checkBox_DumpModels;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_ModelType;
        private System.Windows.Forms.Button button_BrowseModelFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_ModelFolder;
        private System.Windows.Forms.GroupBox groupBox_ModelDump;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_MurmurHash;
        private System.Windows.Forms.TextBox textBox_MurmurHash2;
    }
}
