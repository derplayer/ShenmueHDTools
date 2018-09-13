namespace ShenmueHDTools.GUI.Controls
{
    partial class TADDataTable
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
            this.dataGridView_TAD = new System.Windows.Forms.DataGridView();
            this.ColumnExport = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnHash1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHash2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHash3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOffset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModified = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TAD)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_TAD
            // 
            this.dataGridView_TAD.AllowUserToAddRows = false;
            this.dataGridView_TAD.AllowUserToDeleteRows = false;
            this.dataGridView_TAD.AllowUserToOrderColumns = true;
            this.dataGridView_TAD.AllowUserToResizeRows = false;
            this.dataGridView_TAD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TAD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnExport,
            this.ColumnHash1,
            this.ColumnHash2,
            this.ColumnHash3,
            this.ColumnOffset,
            this.ColumnSize,
            this.ColumnPath,
            this.ColumnExtension,
            this.ColumnModified});
            this.dataGridView_TAD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_TAD.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_TAD.Name = "dataGridView_TAD";
            this.dataGridView_TAD.Size = new System.Drawing.Size(153, 152);
            this.dataGridView_TAD.TabIndex = 0;
            this.dataGridView_TAD.VirtualMode = true;
            // 
            // ColumnExport
            // 
            this.ColumnExport.DataPropertyName = "Export";
            this.ColumnExport.HeaderText = "Export";
            this.ColumnExport.Name = "ColumnExport";
            // 
            // ColumnHash1
            // 
            this.ColumnHash1.DataPropertyName = "Hash1";
            this.ColumnHash1.HeaderText = "Hash1";
            this.ColumnHash1.Name = "ColumnHash1";
            this.ColumnHash1.ReadOnly = true;
            // 
            // ColumnHash2
            // 
            this.ColumnHash2.DataPropertyName = "Hash2";
            this.ColumnHash2.HeaderText = "Hash2";
            this.ColumnHash2.Name = "ColumnHash2";
            this.ColumnHash2.ReadOnly = true;
            // 
            // ColumnHash3
            // 
            this.ColumnHash3.DataPropertyName = "Hash3";
            this.ColumnHash3.HeaderText = "Hash3";
            this.ColumnHash3.Name = "ColumnHash3";
            this.ColumnHash3.ReadOnly = true;
            // 
            // ColumnOffset
            // 
            this.ColumnOffset.DataPropertyName = "FileOffset";
            this.ColumnOffset.HeaderText = "Offset";
            this.ColumnOffset.Name = "ColumnOffset";
            this.ColumnOffset.ReadOnly = true;
            // 
            // ColumnSize
            // 
            this.ColumnSize.DataPropertyName = "FileSize";
            this.ColumnSize.HeaderText = "Size";
            this.ColumnSize.Name = "ColumnSize";
            this.ColumnSize.ReadOnly = true;
            // 
            // ColumnPath
            // 
            this.ColumnPath.DataPropertyName = "RelativePath";
            this.ColumnPath.HeaderText = "Path";
            this.ColumnPath.Name = "ColumnPath";
            this.ColumnPath.ReadOnly = true;
            // 
            // ColumnExtension
            // 
            this.ColumnExtension.DataPropertyName = "Extension";
            this.ColumnExtension.HeaderText = "Extension";
            this.ColumnExtension.Name = "ColumnExtension";
            this.ColumnExtension.ReadOnly = true;
            // 
            // ColumnModified
            // 
            this.ColumnModified.DataPropertyName = "Modified";
            this.ColumnModified.HeaderText = "Modified";
            this.ColumnModified.Name = "ColumnModified";
            this.ColumnModified.ReadOnly = true;
            // 
            // TADDataTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView_TAD);
            this.Name = "TADDataTable";
            this.Size = new System.Drawing.Size(153, 152);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TAD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_TAD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHash1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHash2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHash3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOffset;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExtension;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnModified;
    }
}
