namespace ShenmueHDTools.GUI.Tools.ModelEditor
{
    partial class ModelEditorWindow
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
            this.treeView_MeshNodes = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.listBox_Textures = new System.Windows.Forms.ListBox();
            this.numericUpDown_MipMapIndex = new System.Windows.Forms.NumericUpDown();
            this.pictureBox_TextureView = new System.Windows.Forms.PictureBoxExt();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBox_RenderMode = new System.Windows.Forms.ComboBox();
            this.checkBox_Wireframe = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_ZNear = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_ZFar = new System.Windows.Forms.NumericUpDown();
            this.view3D = new ShenmueHDTools.GUI.Controls.View3D.View3D();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MipMapIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TextureView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ZNear)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ZFar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_MeshNodes
            // 
            this.treeView_MeshNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_MeshNodes.Location = new System.Drawing.Point(0, 0);
            this.treeView_MeshNodes.Name = "treeView_MeshNodes";
            this.treeView_MeshNodes.Size = new System.Drawing.Size(129, 194);
            this.treeView_MeshNodes.TabIndex = 0;
            this.treeView_MeshNodes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_MeshNodes_AfterSelect);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView_MeshNodes);
            this.splitContainer1.Size = new System.Drawing.Size(389, 194);
            this.splitContainer1.SplitterDistance = 129;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 24);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(960, 426);
            this.splitContainer2.SplitterDistance = 395;
            this.splitContainer2.TabIndex = 1;
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
            this.splitContainer3.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer3.Size = new System.Drawing.Size(395, 426);
            this.splitContainer3.SplitterDistance = 213;
            this.splitContainer3.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitContainer1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 213);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mesh";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 209);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Textures";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 16);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.listBox_Textures);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.label3);
            this.splitContainer4.Panel2.Controls.Add(this.numericUpDown_MipMapIndex);
            this.splitContainer4.Panel2.Controls.Add(this.pictureBox_TextureView);
            this.splitContainer4.Size = new System.Drawing.Size(389, 190);
            this.splitContainer4.SplitterDistance = 129;
            this.splitContainer4.TabIndex = 1;
            // 
            // listBox_Textures
            // 
            this.listBox_Textures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Textures.FormattingEnabled = true;
            this.listBox_Textures.Location = new System.Drawing.Point(0, 0);
            this.listBox_Textures.Name = "listBox_Textures";
            this.listBox_Textures.Size = new System.Drawing.Size(129, 190);
            this.listBox_Textures.TabIndex = 0;
            this.listBox_Textures.SelectedIndexChanged += new System.EventHandler(this.listBox_Textures_SelectedIndexChanged);
            // 
            // numericUpDown_MipMapIndex
            // 
            this.numericUpDown_MipMapIndex.Location = new System.Drawing.Point(81, 3);
            this.numericUpDown_MipMapIndex.Name = "numericUpDown_MipMapIndex";
            this.numericUpDown_MipMapIndex.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_MipMapIndex.TabIndex = 1;
            this.numericUpDown_MipMapIndex.ValueChanged += new System.EventHandler(this.numericUpDown_MipMapIndex_ValueChanged);
            // 
            // pictureBox_TextureView
            // 
            this.pictureBox_TextureView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_TextureView.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox_TextureView.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pictureBox_TextureView.Location = new System.Drawing.Point(2, 27);
            this.pictureBox_TextureView.Name = "pictureBox_TextureView";
            this.pictureBox_TextureView.Size = new System.Drawing.Size(251, 160);
            this.pictureBox_TextureView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_TextureView.TabIndex = 0;
            this.pictureBox_TextureView.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel1);
            this.groupBox3.Controls.Add(this.view3D);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(561, 426);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Preview";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.comboBox_RenderMode);
            this.flowLayoutPanel1.Controls.Add(this.checkBox_Wireframe);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(480, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(558, 28);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // comboBox_RenderMode
            // 
            this.comboBox_RenderMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RenderMode.FormattingEnabled = true;
            this.comboBox_RenderMode.Items.AddRange(new object[] {
            "Shaded",
            "Flat",
            "Normals",
            "UVs",
            "Color"});
            this.comboBox_RenderMode.Location = new System.Drawing.Point(3, 3);
            this.comboBox_RenderMode.Name = "comboBox_RenderMode";
            this.comboBox_RenderMode.Size = new System.Drawing.Size(152, 21);
            this.comboBox_RenderMode.TabIndex = 13;
            this.comboBox_RenderMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_RenderMode_SelectedIndexChanged);
            // 
            // checkBox_Wireframe
            // 
            this.checkBox_Wireframe.AutoSize = true;
            this.checkBox_Wireframe.Location = new System.Drawing.Point(161, 3);
            this.checkBox_Wireframe.Name = "checkBox_Wireframe";
            this.checkBox_Wireframe.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.checkBox_Wireframe.Size = new System.Drawing.Size(74, 20);
            this.checkBox_Wireframe.TabIndex = 18;
            this.checkBox_Wireframe.Text = "Wireframe";
            this.checkBox_Wireframe.UseVisualStyleBackColor = true;
            this.checkBox_Wireframe.CheckedChanged += new System.EventHandler(this.checkBox_Wireframe_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericUpDown_ZNear);
            this.panel1.Location = new System.Drawing.Point(241, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 22);
            this.panel1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "ZNear:";
            // 
            // numericUpDown_ZNear
            // 
            this.numericUpDown_ZNear.DecimalPlaces = 3;
            this.numericUpDown_ZNear.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_ZNear.Location = new System.Drawing.Point(45, 1);
            this.numericUpDown_ZNear.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDown_ZNear.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDown_ZNear.Name = "numericUpDown_ZNear";
            this.numericUpDown_ZNear.Size = new System.Drawing.Size(71, 20);
            this.numericUpDown_ZNear.TabIndex = 14;
            this.numericUpDown_ZNear.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown_ZNear.ValueChanged += new System.EventHandler(this.numericUpDown_ZNear_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.numericUpDown_ZFar);
            this.panel2.Location = new System.Drawing.Point(364, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(113, 22);
            this.panel2.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "ZFar:";
            // 
            // numericUpDown_ZFar
            // 
            this.numericUpDown_ZFar.DecimalPlaces = 2;
            this.numericUpDown_ZFar.Location = new System.Drawing.Point(41, 1);
            this.numericUpDown_ZFar.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_ZFar.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDown_ZFar.Name = "numericUpDown_ZFar";
            this.numericUpDown_ZFar.Size = new System.Drawing.Size(71, 20);
            this.numericUpDown_ZFar.TabIndex = 15;
            this.numericUpDown_ZFar.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_ZFar.ValueChanged += new System.EventHandler(this.numericUpDown_ZFar_ValueChanged);
            // 
            // view3D
            // 
            this.view3D.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.view3D.BackColor = System.Drawing.Color.Black;
            this.view3D.Location = new System.Drawing.Point(3, 50);
            this.view3D.Name = "view3D";
            this.view3D.Size = new System.Drawing.Size(558, 373);
            this.view3D.TabIndex = 0;
            this.view3D.VSync = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(960, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mipmap Index:";
            // 
            // ModelEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 450);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ModelEditorWindow";
            this.Text = "Model Editor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MipMapIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TextureView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ZNear)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ZFar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_MeshNodes;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ListBox listBox_Textures;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private Controls.View3D.View3D view3D;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox_Wireframe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_ZFar;
        private System.Windows.Forms.NumericUpDown numericUpDown_ZNear;
        private System.Windows.Forms.ComboBox comboBox_RenderMode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBoxExt pictureBox_TextureView;
        private System.Windows.Forms.NumericUpDown numericUpDown_MipMapIndex;
        private System.Windows.Forms.Label label3;
    }
}