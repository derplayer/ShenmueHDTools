namespace ShenmueHDTools
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.packAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unpackAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filenameDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapFilenamesToTADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.wulinshuRaymonfDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tadDataTable1 = new ShenmueHDTools.GUI.Controls.TADDataTable();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_FileExplorer = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabPage_TAD = new System.Windows.Forms.TabPage();
            this.fileTreeView = new ShenmueHDTools.GUI.Controls.FileTreeView();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage_FileExplorer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage_TAD.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripMenuItem1,
            this.packAllToolStripMenuItem,
            this.unpackAllToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(126, 6);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.importToolStripMenuItem.Text = "Import...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(126, 6);
            // 
            // packAllToolStripMenuItem
            // 
            this.packAllToolStripMenuItem.Name = "packAllToolStripMenuItem";
            this.packAllToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.packAllToolStripMenuItem.Text = "Pack all";
            this.packAllToolStripMenuItem.Click += new System.EventHandler(this.packAllToolStripMenuItem_Click);
            // 
            // unpackAllToolStripMenuItem
            // 
            this.unpackAllToolStripMenuItem.Name = "unpackAllToolStripMenuItem";
            this.unpackAllToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.unpackAllToolStripMenuItem.Text = "Unpack all";
            this.unpackAllToolStripMenuItem.Click += new System.EventHandler(this.unpackAllToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filenameDatabaseToolStripMenuItem,
            this.mapFilenamesToTADToolStripMenuItem,
            this.toolStripMenuItem2,
            this.wulinshuRaymonfDBToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // filenameDatabaseToolStripMenuItem
            // 
            this.filenameDatabaseToolStripMenuItem.Name = "filenameDatabaseToolStripMenuItem";
            this.filenameDatabaseToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.filenameDatabaseToolStripMenuItem.Text = "Filename Database...";
            this.filenameDatabaseToolStripMenuItem.Click += new System.EventHandler(this.filenameDatabaseToolStripMenuItem_Click);
            // 
            // mapFilenamesToTADToolStripMenuItem
            // 
            this.mapFilenamesToTADToolStripMenuItem.Name = "mapFilenamesToTADToolStripMenuItem";
            this.mapFilenamesToTADToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.mapFilenamesToTADToolStripMenuItem.Text = "Map filenames to TAD";
            this.mapFilenamesToTADToolStripMenuItem.Click += new System.EventHandler(this.mapFilenamesToTADToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(199, 6);
            // 
            // wulinshuRaymonfDBToolStripMenuItem
            // 
            this.wulinshuRaymonfDBToolStripMenuItem.Name = "wulinshuRaymonfDBToolStripMenuItem";
            this.wulinshuRaymonfDBToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.wulinshuRaymonfDBToolStripMenuItem.Text = "Wulinshu Raymonf DB...";
            this.wulinshuRaymonfDBToolStripMenuItem.Click += new System.EventHandler(this.wulinshuRaymonfDBToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tadDataTable1
            // 
            this.tadDataTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tadDataTable1.Location = new System.Drawing.Point(3, 3);
            this.tadDataTable1.Name = "tadDataTable1";
            this.tadDataTable1.Size = new System.Drawing.Size(994, 505);
            this.tadDataTable1.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_FileExplorer);
            this.tabControl.Controls.Add(this.tabPage_TAD);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1008, 537);
            this.tabControl.TabIndex = 2;
            // 
            // tabPage_FileExplorer
            // 
            this.tabPage_FileExplorer.Controls.Add(this.splitContainer1);
            this.tabPage_FileExplorer.Location = new System.Drawing.Point(4, 22);
            this.tabPage_FileExplorer.Name = "tabPage_FileExplorer";
            this.tabPage_FileExplorer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_FileExplorer.Size = new System.Drawing.Size(1000, 511);
            this.tabPage_FileExplorer.TabIndex = 0;
            this.tabPage_FileExplorer.Text = "File Explorer";
            this.tabPage_FileExplorer.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fileTreeView);
            this.splitContainer1.Size = new System.Drawing.Size(994, 505);
            this.splitContainer1.SplitterDistance = 331;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabPage_TAD
            // 
            this.tabPage_TAD.Controls.Add(this.tadDataTable1);
            this.tabPage_TAD.Location = new System.Drawing.Point(4, 22);
            this.tabPage_TAD.Name = "tabPage_TAD";
            this.tabPage_TAD.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_TAD.Size = new System.Drawing.Size(1000, 511);
            this.tabPage_TAD.TabIndex = 1;
            this.tabPage_TAD.Text = "TAD Table";
            this.tabPage_TAD.UseVisualStyleBackColor = true;
            // 
            // fileTreeView
            // 
            this.fileTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileTreeView.Location = new System.Drawing.Point(0, 0);
            this.fileTreeView.Name = "fileTreeView";
            this.fileTreeView.Size = new System.Drawing.Size(331, 505);
            this.fileTreeView.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MainWindow";
            this.Text = "Shenmue HD ModTools";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage_FileExplorer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage_TAD.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GUI.Controls.TADDataTable tadDataTable1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filenameDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapFilenamesToTADToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem wulinshuRaymonfDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem packAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unpackAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_FileExplorer;
        private System.Windows.Forms.TabPage tabPage_TAD;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private GUI.Controls.FileTreeView fileTreeView;
    }
}