namespace ShenmueHDTools.GUI.Controls
{
    partial class WulinshuRaymonfDataTable
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
            this.dataGridView_Entries = new ShenmueHDTools.GUI.Controls.DataGridViewEx();
            this.ColumnPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMatches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Entries)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Entries
            // 
            this.dataGridView_Entries.AllowUserToAddRows = false;
            this.dataGridView_Entries.AllowUserToDeleteRows = false;
            this.dataGridView_Entries.AllowUserToOrderColumns = true;
            this.dataGridView_Entries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Entries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPath,
            this.ColumnHash,
            this.ColumnMatches,
            this.ColumnGame});
            this.dataGridView_Entries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Entries.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Entries.Name = "dataGridView_Entries";
            this.dataGridView_Entries.Size = new System.Drawing.Size(150, 150);
            this.dataGridView_Entries.TabIndex = 0;
            // 
            // ColumnPath
            // 
            this.ColumnPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPath.DataPropertyName = "Path";
            this.ColumnPath.HeaderText = "Path";
            this.ColumnPath.Name = "ColumnPath";
            this.ColumnPath.ReadOnly = true;
            // 
            // ColumnHash
            // 
            this.ColumnHash.DataPropertyName = "Hash";
            this.ColumnHash.HeaderText = "Hash";
            this.ColumnHash.Name = "ColumnHash";
            this.ColumnHash.ReadOnly = true;
            // 
            // ColumnMatches
            // 
            this.ColumnMatches.DataPropertyName = "Matches";
            this.ColumnMatches.HeaderText = "Matches";
            this.ColumnMatches.Name = "ColumnMatches";
            this.ColumnMatches.ReadOnly = true;
            // 
            // ColumnGame
            // 
            this.ColumnGame.DataPropertyName = "Game";
            this.ColumnGame.HeaderText = "Game";
            this.ColumnGame.Name = "ColumnGame";
            this.ColumnGame.ReadOnly = true;
            // 
            // WulinshuRaymonfDataTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView_Entries);
            this.Name = "WulinshuRaymonfDataTable";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Entries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ShenmueHDTools.GUI.Controls.DataGridViewEx dataGridView_Entries;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHash;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMatches;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGame;
    }
}
