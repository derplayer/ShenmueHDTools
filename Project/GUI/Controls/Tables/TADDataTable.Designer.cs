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
            this.dataGridView_TAD = new ShenmueHDTools.GUI.Controls.DataGridViewEx();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Filter = new System.Windows.Forms.TextBox();
            this.label_Count = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_Statistic = new System.Windows.Forms.Label();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.ColumnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExport = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnHash1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHash2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHash3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOffset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModified = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TAD)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_TAD
            // 
            this.dataGridView_TAD.AllowUserToAddRows = false;
            this.dataGridView_TAD.AllowUserToDeleteRows = false;
            this.dataGridView_TAD.AllowUserToOrderColumns = true;
            this.dataGridView_TAD.AllowUserToResizeRows = false;
            this.dataGridView_TAD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_TAD.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_TAD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TAD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIndex,
            this.ColumnExport,
            this.ColumnHash1,
            this.ColumnHash2,
            this.ColumnHash3,
            this.ColumnOffset,
            this.ColumnSize,
            this.ColumnFilename,
            this.ColumnPath,
            this.ColumnExtension,
            this.ColumnModified});
            this.dataGridView_TAD.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_TAD.Name = "dataGridView_TAD";
            this.dataGridView_TAD.Size = new System.Drawing.Size(500, 168);
            this.dataGridView_TAD.TabIndex = 0;
            this.dataGridView_TAD.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_TAD_CellBeginEdit);
            this.dataGridView_TAD.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_TAD_CellEndEdit);
            this.dataGridView_TAD.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_TAD_CellMouseClick);
            this.dataGridView_TAD.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_TAD_ColumnHeaderMouseClick);
            this.dataGridView_TAD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView_TAD_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(84, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_Filter
            // 
            this.textBox_Filter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Filter.Location = new System.Drawing.Point(134, 3);
            this.textBox_Filter.Name = "textBox_Filter";
            this.textBox_Filter.Size = new System.Drawing.Size(157, 20);
            this.textBox_Filter.TabIndex = 2;
            this.textBox_Filter.TextChanged += new System.EventHandler(this.textBox_Filter_TextChanged);
            // 
            // label_Count
            // 
            this.label_Count.AutoSize = true;
            this.label_Count.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Count.Location = new System.Drawing.Point(297, 0);
            this.label_Count.Name = "label_Count";
            this.label_Count.Size = new System.Drawing.Size(74, 26);
            this.label_Count.TabIndex = 4;
            this.label_Count.Text = "Entries: 0";
            this.label_Count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label_Count, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Filter, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_Statistic, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Refresh, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 171);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(497, 26);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label_Statistic
            // 
            this.label_Statistic.AutoSize = true;
            this.label_Statistic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Statistic.Location = new System.Drawing.Point(377, 0);
            this.label_Statistic.Name = "label_Statistic";
            this.label_Statistic.Size = new System.Drawing.Size(117, 26);
            this.label_Statistic.TabIndex = 5;
            this.label_Statistic.Text = "File coverage: 0/0 (0%)";
            this.label_Statistic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_Refresh
            // 
            this.button_Refresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Refresh.Location = new System.Drawing.Point(3, 3);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(75, 20);
            this.button_Refresh.TabIndex = 6;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // ColumnIndex
            // 
            this.ColumnIndex.DataPropertyName = "Index";
            this.ColumnIndex.FillWeight = 40F;
            this.ColumnIndex.HeaderText = "";
            this.ColumnIndex.Name = "ColumnIndex";
            this.ColumnIndex.ReadOnly = true;
            this.ColumnIndex.Width = 40;
            // 
            // ColumnExport
            // 
            this.ColumnExport.DataPropertyName = "Export";
            this.ColumnExport.FillWeight = 50F;
            this.ColumnExport.HeaderText = "Export";
            this.ColumnExport.Name = "ColumnExport";
            this.ColumnExport.Width = 50;
            // 
            // ColumnHash1
            // 
            this.ColumnHash1.DataPropertyName = "Hash1";
            this.ColumnHash1.FillWeight = 80F;
            this.ColumnHash1.HeaderText = "Hash1";
            this.ColumnHash1.Name = "ColumnHash1";
            this.ColumnHash1.ReadOnly = true;
            this.ColumnHash1.Width = 80;
            // 
            // ColumnHash2
            // 
            this.ColumnHash2.DataPropertyName = "Hash2";
            this.ColumnHash2.FillWeight = 80F;
            this.ColumnHash2.HeaderText = "Hash2";
            this.ColumnHash2.Name = "ColumnHash2";
            this.ColumnHash2.ReadOnly = true;
            this.ColumnHash2.Width = 80;
            // 
            // ColumnHash3
            // 
            this.ColumnHash3.DataPropertyName = "Hash3";
            this.ColumnHash3.FillWeight = 80F;
            this.ColumnHash3.HeaderText = "Hash3";
            this.ColumnHash3.Name = "ColumnHash3";
            this.ColumnHash3.ReadOnly = true;
            this.ColumnHash3.Width = 80;
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
            // ColumnFilename
            // 
            this.ColumnFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnFilename.DataPropertyName = "Filename";
            this.ColumnFilename.HeaderText = "Filename";
            this.ColumnFilename.MinimumWidth = 100;
            this.ColumnFilename.Name = "ColumnFilename";
            this.ColumnFilename.ReadOnly = true;
            // 
            // ColumnPath
            // 
            this.ColumnPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPath.DataPropertyName = "RelativePath";
            this.ColumnPath.HeaderText = "Path";
            this.ColumnPath.MinimumWidth = 100;
            this.ColumnPath.Name = "ColumnPath";
            this.ColumnPath.ReadOnly = true;
            // 
            // ColumnExtension
            // 
            this.ColumnExtension.DataPropertyName = "Extension";
            this.ColumnExtension.FillWeight = 80F;
            this.ColumnExtension.HeaderText = "Extension";
            this.ColumnExtension.Name = "ColumnExtension";
            this.ColumnExtension.ReadOnly = true;
            this.ColumnExtension.Width = 80;
            // 
            // ColumnModified
            // 
            this.ColumnModified.DataPropertyName = "Modified";
            this.ColumnModified.FillWeight = 60F;
            this.ColumnModified.HeaderText = "Modified";
            this.ColumnModified.Name = "ColumnModified";
            this.ColumnModified.ReadOnly = true;
            this.ColumnModified.Width = 60;
            // 
            // TADDataTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dataGridView_TAD);
            this.Name = "TADDataTable";
            this.Size = new System.Drawing.Size(500, 200);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TAD)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ShenmueHDTools.GUI.Controls.DataGridViewEx dataGridView_TAD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Filter;
        private System.Windows.Forms.Label label_Count;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_Statistic;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIndex;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHash1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHash2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHash3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOffset;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExtension;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnModified;
    }
}
