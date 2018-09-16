namespace ShenmueHDTools
{
    partial class MainWindow_New
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filenameDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapFilenamesToTADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.wulinshuRaymonfDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tadDataTable1 = new ShenmueHDTools.GUI.Controls.TADDataTable();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.importToolStripMenuItem.Text = "Import...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
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
            // tadDataTable1
            // 
            this.tadDataTable1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tadDataTable1.Location = new System.Drawing.Point(12, 35);
            this.tadDataTable1.Name = "tadDataTable1";
            this.tadDataTable1.Size = new System.Drawing.Size(776, 403);
            this.tadDataTable1.TabIndex = 0;
            // 
            // MainWindow_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tadDataTable1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow_New";
            this.ShowIcon = false;
            this.Text = "MainWindow_New";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}