namespace Shenmue_HD_Tools
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.test1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importExistingProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsAModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveVFSToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveVFSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gIMOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gIMShowGIMStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractVFSRecrusiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cRC32FromLookupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToModifyAFileInVFSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewMain = new System.Windows.Forms.ListView();
            this.indexHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.beginHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.endHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hashHeaderOne = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hashHeaderTwo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modifiedFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hashedPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.dataCollectorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.refreshButton = new System.Windows.Forms.Button();
            this.mainMenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCollectorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem1,
            this.gIMOptionsToolStripMenuItem,
            this.otherToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(879, 24);
            this.mainMenuStrip.TabIndex = 4;
            this.mainMenuStrip.Text = "mainMenuStrip";
            this.mainMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainMenuStrip_ItemClicked);
            // 
            // testToolStripMenuItem1
            // 
            this.testToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.test1ToolStripMenuItem,
            this.importExistingProjectToolStripMenuItem,
            this.exportAsAModToolStripMenuItem,
            this.saveVFSToolStripMenuItem1,
            this.saveVFSToolStripMenuItem});
            this.testToolStripMenuItem1.Name = "testToolStripMenuItem1";
            this.testToolStripMenuItem1.Size = new System.Drawing.Size(113, 20);
            this.testToolStripMenuItem1.Text = "TAD/TAC Options";
            this.testToolStripMenuItem1.Click += new System.EventHandler(this.testToolStripMenuItem1_Click);
            // 
            // test1ToolStripMenuItem
            // 
            this.test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
            this.test1ToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.test1ToolStripMenuItem.Text = "Create project (from *.tad/*.tac)";
            this.test1ToolStripMenuItem.Click += new System.EventHandler(this.test1ToolStripMenuItem_Click);
            // 
            // importExistingProjectToolStripMenuItem
            // 
            this.importExistingProjectToolStripMenuItem.Name = "importExistingProjectToolStripMenuItem";
            this.importExistingProjectToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.importExistingProjectToolStripMenuItem.Text = "Import existing project (*.shdcache)";
            this.importExistingProjectToolStripMenuItem.Click += new System.EventHandler(this.importExistingProjectToolStripMenuItem_Click);
            // 
            // exportAsAModToolStripMenuItem
            // 
            this.exportAsAModToolStripMenuItem.Name = "exportAsAModToolStripMenuItem";
            this.exportAsAModToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.exportAsAModToolStripMenuItem.Text = "Export as mod container";
            this.exportAsAModToolStripMenuItem.Click += new System.EventHandler(this.exportAsAModToolStripMenuItem_Click);
            // 
            // saveVFSToolStripMenuItem1
            // 
            this.saveVFSToolStripMenuItem1.Name = "saveVFSToolStripMenuItem1";
            this.saveVFSToolStripMenuItem1.Size = new System.Drawing.Size(262, 22);
            this.saveVFSToolStripMenuItem1.Text = "Save";
            this.saveVFSToolStripMenuItem1.Click += new System.EventHandler(this.saveVFSToolStripMenuItem1_Click);
            // 
            // saveVFSToolStripMenuItem
            // 
            this.saveVFSToolStripMenuItem.Name = "saveVFSToolStripMenuItem";
            this.saveVFSToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.saveVFSToolStripMenuItem.Text = "Save as...";
            this.saveVFSToolStripMenuItem.Click += new System.EventHandler(this.saveVFSToolStripMenuItem_Click);
            // 
            // gIMOptionsToolStripMenuItem
            // 
            this.gIMOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gIMShowGIMStripMenuItem});
            this.gIMOptionsToolStripMenuItem.Enabled = false;
            this.gIMOptionsToolStripMenuItem.Name = "gIMOptionsToolStripMenuItem";
            this.gIMOptionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.gIMOptionsToolStripMenuItem.Text = "Options";
            // 
            // gIMShowGIMStripMenuItem
            // 
            this.gIMShowGIMStripMenuItem.Name = "gIMShowGIMStripMenuItem";
            this.gIMShowGIMStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.gIMShowGIMStripMenuItem.Text = "Show DDS";
            this.gIMShowGIMStripMenuItem.Click += new System.EventHandler(this.gIMShowGIMStripMenuItem_Click);
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractVFSRecrusiveToolStripMenuItem});
            this.otherToolStripMenuItem.Enabled = false;
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.otherToolStripMenuItem.Text = "Other";
            // 
            // extractVFSRecrusiveToolStripMenuItem
            // 
            this.extractVFSRecrusiveToolStripMenuItem.Name = "extractVFSRecrusiveToolStripMenuItem";
            this.extractVFSRecrusiveToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.extractVFSRecrusiveToolStripMenuItem.Text = "Test01";
            this.extractVFSRecrusiveToolStripMenuItem.Click += new System.EventHandler(this.extractVFSRecrusiveToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cRC32FromLookupToolStripMenuItem});
            this.debugToolStripMenuItem.Enabled = false;
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // cRC32FromLookupToolStripMenuItem
            // 
            this.cRC32FromLookupToolStripMenuItem.Name = "cRC32FromLookupToolStripMenuItem";
            this.cRC32FromLookupToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.cRC32FromLookupToolStripMenuItem.Text = "HASH Test";
            this.cRC32FromLookupToolStripMenuItem.Click += new System.EventHandler(this.cRC32FromLookupToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToModifyAFileInVFSToolStripMenuItem});
            this.helpToolStripMenuItem.Enabled = false;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // howToModifyAFileInVFSToolStripMenuItem
            // 
            this.howToModifyAFileInVFSToolStripMenuItem.Enabled = false;
            this.howToModifyAFileInVFSToolStripMenuItem.Name = "howToModifyAFileInVFSToolStripMenuItem";
            this.howToModifyAFileInVFSToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.howToModifyAFileInVFSToolStripMenuItem.Text = "How to modify my Shenmue files?";
            this.howToModifyAFileInVFSToolStripMenuItem.Click += new System.EventHandler(this.howToModifyAFileInVFSToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // listViewMain
            // 
            this.listViewMain.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewMain.AllowColumnReorder = true;
            this.listViewMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.indexHeader,
            this.beginHeader,
            this.sizeHeader,
            this.endHeader,
            this.hashHeaderOne,
            this.hashHeaderTwo,
            this.modifiedFlag,
            this.hashedPath});
            this.listViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMain.FullRowSelect = true;
            this.listViewMain.MultiSelect = false;
            this.listViewMain.HideSelection = false;
            this.listViewMain.Location = new System.Drawing.Point(0, 24);
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.ShowItemToolTips = true;
            this.listViewMain.Size = new System.Drawing.Size(879, 322);
            this.listViewMain.TabIndex = 6;
            this.listViewMain.Tag = "";
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            this.listViewMain.View = System.Windows.Forms.View.Details;
            this.listViewMain.Visible = false;
            this.listViewMain.SelectedIndexChanged += new System.EventHandler(this.listViewMain_SelectedIndexChanged);
            this.listViewMain.DoubleClick += new System.EventHandler(this.listViewMain_Click);
            this.listViewMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // indexHeader
            // 
            this.indexHeader.Tag = "";
            this.indexHeader.Text = "Index";
            this.indexHeader.Width = 46;
            // 
            // beginHeader
            // 
            this.beginHeader.Text = "Begin (*)";
            // 
            // sizeHeader
            // 
            this.sizeHeader.Text = "File Size";
            // 
            // endHeader
            // 
            this.endHeader.Text = "End (*)";
            // 
            // hashHeaderOne
            // 
            this.hashHeaderOne.Text = "Hash1";
            this.hashHeaderOne.Width = 74;
            // 
            // hashHeaderTwo
            // 
            this.hashHeaderTwo.Text = "Hash2";
            this.hashHeaderTwo.Width = 71;
            // 
            // modifiedFlag
            // 
            this.modifiedFlag.Text = "Modified";
            // 
            // hashedPath
            // 
            this.hashedPath.Text = "Path";
            this.hashedPath.Width = 78;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 324);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(879, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Ready!";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(829, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 22);
            this.button1.TabIndex = 11;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(211, 155);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(446, 39);
            this.labelMessage.TabIndex = 13;
            this.labelMessage.Text = "Please load a TAD/TAC file!";
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Location = new System.Drawing.Point(769, 324);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(54, 22);
            this.refreshButton.TabIndex = 14;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 346);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listViewMain);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.labelMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(696, 332);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "Shenmue HD ModTools v";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Enter += new System.EventHandler(this.Form1_Enter);
            this.Leave += new System.EventHandler(this.Form1_Enter);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCollectorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem test1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveVFSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cRC32FromLookupToolStripMenuItem;
        private System.Windows.Forms.BindingSource dataCollectorBindingSource;
        public System.Windows.Forms.ListView listViewMain;
        public System.Windows.Forms.ColumnHeader indexHeader;
        public System.Windows.Forms.ColumnHeader beginHeader;
        public System.Windows.Forms.ColumnHeader sizeHeader;
        public System.Windows.Forms.ColumnHeader endHeader;
        private System.Windows.Forms.ToolStripMenuItem saveVFSToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToModifyAFileInVFSToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractVFSRecrusiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gIMOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gIMShowGIMStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importExistingProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsAModToolStripMenuItem;
        public System.Windows.Forms.ColumnHeader hashHeaderOne;
        public System.Windows.Forms.ColumnHeader hashHeaderTwo;
        public System.Windows.Forms.ColumnHeader hashedPath;
        private System.Windows.Forms.Button refreshButton;
        public System.Windows.Forms.ColumnHeader modifiedFlag;
    }
}

