namespace ShenmueHDTools.GUI.Controls
{
    partial class FileTreeView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileTreeView));
            this.treeView_Files = new System.Windows.Forms.TreeView();
            this.imageList_NodeIcons = new System.Windows.Forms.ImageList(this.components);
            this.comboBox_GroupBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView_Files
            // 
            this.treeView_Files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView_Files.ImageIndex = 0;
            this.treeView_Files.ImageList = this.imageList_NodeIcons;
            this.treeView_Files.Location = new System.Drawing.Point(0, 30);
            this.treeView_Files.Name = "treeView_Files";
            this.treeView_Files.SelectedImageIndex = 0;
            this.treeView_Files.Size = new System.Drawing.Size(356, 337);
            this.treeView_Files.StateImageList = this.imageList_NodeIcons;
            this.treeView_Files.TabIndex = 0;
            this.treeView_Files.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Files_AfterSelect);
            // 
            // imageList_NodeIcons
            // 
            this.imageList_NodeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_NodeIcons.ImageStream")));
            this.imageList_NodeIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_NodeIcons.Images.SetKeyName(0, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(1, "Archive.ico");
            this.imageList_NodeIcons.Images.SetKeyName(2, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(3, "Image.ico");
            this.imageList_NodeIcons.Images.SetKeyName(4, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(5, "Text.ico");
            this.imageList_NodeIcons.Images.SetKeyName(6, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(7, "Image.ico");
            this.imageList_NodeIcons.Images.SetKeyName(8, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(9, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(10, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(11, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(12, "Archive.ico");
            this.imageList_NodeIcons.Images.SetKeyName(13, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(14, "Archive.ico");
            this.imageList_NodeIcons.Images.SetKeyName(15, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(16, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(17, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(18, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(19, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(20, "Archive.ico");
            this.imageList_NodeIcons.Images.SetKeyName(21, "Archive.ico");
            this.imageList_NodeIcons.Images.SetKeyName(22, "Image.ico");
            this.imageList_NodeIcons.Images.SetKeyName(23, "Image.ico");
            this.imageList_NodeIcons.Images.SetKeyName(24, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(25, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(26, "Audio.ico");
            this.imageList_NodeIcons.Images.SetKeyName(27, "Image.ico");
            this.imageList_NodeIcons.Images.SetKeyName(28, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(29, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(30, "Image.ico");
            this.imageList_NodeIcons.Images.SetKeyName(31, "Unknown.ico");
            this.imageList_NodeIcons.Images.SetKeyName(32, "Wav.ico");
            // 
            // comboBox_GroupBy
            // 
            this.comboBox_GroupBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_GroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_GroupBy.FormattingEnabled = true;
            this.comboBox_GroupBy.Location = new System.Drawing.Point(0, 3);
            this.comboBox_GroupBy.Name = "comboBox_GroupBy";
            this.comboBox_GroupBy.Size = new System.Drawing.Size(356, 21);
            this.comboBox_GroupBy.TabIndex = 2;
            this.comboBox_GroupBy.SelectedIndexChanged += new System.EventHandler(this.comboBox_GroupBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search: ";
            // 
            // textBox_Search
            // 
            this.textBox_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Search.Location = new System.Drawing.Point(124, 373);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(232, 20);
            this.textBox_Search.TabIndex = 4;
            this.textBox_Search.TextChanged += new System.EventHandler(this.textBox_Search_TextChanged);
            // 
            // button_Refresh
            // 
            this.button_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Refresh.Location = new System.Drawing.Point(0, 370);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(75, 23);
            this.button_Refresh.TabIndex = 5;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            // 
            // FileTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.textBox_Search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_GroupBy);
            this.Controls.Add(this.treeView_Files);
            this.Name = "FileTreeView";
            this.Size = new System.Drawing.Size(356, 396);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_Files;
        private System.Windows.Forms.ImageList imageList_NodeIcons;
        private System.Windows.Forms.ComboBox comboBox_GroupBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.Button button_Refresh;
    }
}
