namespace ShenmueHDTextureConverter
{
    partial class TextureConverter
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.listBox_Images = new System.Windows.Forms.ListBox();
            this.pictureBox_SourcePreview = new System.Windows.Forms.PictureBoxExt();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl_Formats = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pvrtControl = new ShenmueHDTextureConverter.Controls.PVRTControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_ImageFormat = new System.Windows.Forms.ComboBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBox_TargetPreview = new System.Windows.Forms.PictureBoxExt();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_Convert = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox_ConvertSelected = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_OutputFolder = new System.Windows.Forms.TextBox();
            this.button_BrowseOutputFolder = new System.Windows.Forms.Button();
            this.ddsControl = new ShenmueHDTextureConverter.Controls.DDSControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SourcePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl_Formats.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TargetPreview)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(971, 426);
            this.splitContainer1.SplitterDistance = 285;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Files";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 16);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.listBox_Images);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.pictureBox_SourcePreview);
            this.splitContainer4.Size = new System.Drawing.Size(279, 407);
            this.splitContainer4.SplitterDistance = 229;
            this.splitContainer4.TabIndex = 1;
            // 
            // listBox_Images
            // 
            this.listBox_Images.AllowDrop = true;
            this.listBox_Images.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Images.FormattingEnabled = true;
            this.listBox_Images.Location = new System.Drawing.Point(0, 0);
            this.listBox_Images.Name = "listBox_Images";
            this.listBox_Images.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_Images.Size = new System.Drawing.Size(279, 229);
            this.listBox_Images.TabIndex = 0;
            this.listBox_Images.SelectedIndexChanged += new System.EventHandler(this.listBox_Images_SelectedIndexChanged);
            this.listBox_Images.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_Images_DragDrop);
            this.listBox_Images.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_Images_DragEnter);
            this.listBox_Images.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_Images_KeyDown);
            // 
            // pictureBox_SourcePreview
            // 
            this.pictureBox_SourcePreview.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox_SourcePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_SourcePreview.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pictureBox_SourcePreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_SourcePreview.Name = "pictureBox_SourcePreview";
            this.pictureBox_SourcePreview.Size = new System.Drawing.Size(279, 174);
            this.pictureBox_SourcePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_SourcePreview.TabIndex = 0;
            this.pictureBox_SourcePreview.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(682, 426);
            this.splitContainer2.SplitterDistance = 357;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl_Formats);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBox_ImageFormat);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 426);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target Image Format";
            // 
            // tabControl_Formats
            // 
            this.tabControl_Formats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_Formats.Controls.Add(this.tabPage1);
            this.tabControl_Formats.Controls.Add(this.tabPage2);
            this.tabControl_Formats.Controls.Add(this.tabPage3);
            this.tabControl_Formats.Controls.Add(this.tabPage4);
            this.tabControl_Formats.Controls.Add(this.tabPage5);
            this.tabControl_Formats.Location = new System.Drawing.Point(3, 46);
            this.tabControl_Formats.Name = "tabControl_Formats";
            this.tabControl_Formats.SelectedIndex = 0;
            this.tabControl_Formats.Size = new System.Drawing.Size(351, 377);
            this.tabControl_Formats.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pvrtControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(343, 351);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PVRT";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pvrtControl
            // 
            this.pvrtControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pvrtControl.Location = new System.Drawing.Point(3, 3);
            this.pvrtControl.Name = "pvrtControl";
            this.pvrtControl.Size = new System.Drawing.Size(337, 345);
            this.pvrtControl.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ddsControl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(343, 351);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DDS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(338, 319);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "PNG";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(343, 351);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "BMP";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(343, 351);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "JPEG";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Format:";
            // 
            // comboBox_ImageFormat
            // 
            this.comboBox_ImageFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_ImageFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ImageFormat.FormattingEnabled = true;
            this.comboBox_ImageFormat.Location = new System.Drawing.Point(54, 19);
            this.comboBox_ImageFormat.Name = "comboBox_ImageFormat";
            this.comboBox_ImageFormat.Size = new System.Drawing.Size(297, 21);
            this.comboBox_ImageFormat.TabIndex = 0;
            this.comboBox_ImageFormat.SelectedIndexChanged += new System.EventHandler(this.comboBox_ImageFormat_SelectedIndexChanged);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer3.Size = new System.Drawing.Size(321, 426);
            this.splitContainer3.SplitterDistance = 285;
            this.splitContainer3.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBox_TargetPreview);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(321, 285);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Preview";
            // 
            // pictureBox_TargetPreview
            // 
            this.pictureBox_TargetPreview.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox_TargetPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_TargetPreview.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pictureBox_TargetPreview.Location = new System.Drawing.Point(3, 16);
            this.pictureBox_TargetPreview.Name = "pictureBox_TargetPreview";
            this.pictureBox_TargetPreview.Size = new System.Drawing.Size(315, 266);
            this.pictureBox_TargetPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_TargetPreview.TabIndex = 0;
            this.pictureBox_TargetPreview.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_BrowseOutputFolder);
            this.groupBox3.Controls.Add(this.textBox_OutputFolder);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.checkBox_ConvertSelected);
            this.groupBox3.Controls.Add(this.button_Convert);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(321, 137);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // button_Convert
            // 
            this.button_Convert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Convert.Location = new System.Drawing.Point(6, 94);
            this.button_Convert.Name = "button_Convert";
            this.button_Convert.Size = new System.Drawing.Size(309, 37);
            this.button_Convert.TabIndex = 0;
            this.button_Convert.Text = "Convert";
            this.button_Convert.UseVisualStyleBackColor = true;
            this.button_Convert.Click += new System.EventHandler(this.button_Convert_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(971, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open...";
            // 
            // checkBox_ConvertSelected
            // 
            this.checkBox_ConvertSelected.AutoSize = true;
            this.checkBox_ConvertSelected.Location = new System.Drawing.Point(20, 61);
            this.checkBox_ConvertSelected.Name = "checkBox_ConvertSelected";
            this.checkBox_ConvertSelected.Size = new System.Drawing.Size(106, 17);
            this.checkBox_ConvertSelected.TabIndex = 1;
            this.checkBox_ConvertSelected.Text = "Convert selected";
            this.checkBox_ConvertSelected.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output Folder:";
            // 
            // textBox_OutputFolder
            // 
            this.textBox_OutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_OutputFolder.Location = new System.Drawing.Point(97, 29);
            this.textBox_OutputFolder.Name = "textBox_OutputFolder";
            this.textBox_OutputFolder.Size = new System.Drawing.Size(176, 20);
            this.textBox_OutputFolder.TabIndex = 3;
            // 
            // button_BrowseOutputFolder
            // 
            this.button_BrowseOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_BrowseOutputFolder.Location = new System.Drawing.Point(279, 28);
            this.button_BrowseOutputFolder.Name = "button_BrowseOutputFolder";
            this.button_BrowseOutputFolder.Size = new System.Drawing.Size(36, 22);
            this.button_BrowseOutputFolder.TabIndex = 4;
            this.button_BrowseOutputFolder.Text = "...";
            this.button_BrowseOutputFolder.UseVisualStyleBackColor = true;
            this.button_BrowseOutputFolder.Click += new System.EventHandler(this.button_BrowseOutputFolder_Click);
            // 
            // ddsControl
            // 
            this.ddsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddsControl.Location = new System.Drawing.Point(3, 3);
            this.ddsControl.Name = "ddsControl";
            this.ddsControl.Size = new System.Drawing.Size(337, 345);
            this.ddsControl.TabIndex = 0;
            // 
            // TextureConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TextureConverter";
            this.Text = "ShenmueHD - Texture Converter";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SourcePreview)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl_Formats.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TargetPreview)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox_Images;
        private System.Windows.Forms.Button button_Convert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_ImageFormat;
        private System.Windows.Forms.TabControl tabControl_Formats;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBoxExt pictureBox_TargetPreview;
        private Controls.PVRTControl pvrtControl;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.PictureBoxExt pictureBox_SourcePreview;
        private System.Windows.Forms.CheckBox checkBox_ConvertSelected;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_BrowseOutputFolder;
        private System.Windows.Forms.TextBox textBox_OutputFolder;
        private Controls.DDSControl ddsControl;
    }
}

