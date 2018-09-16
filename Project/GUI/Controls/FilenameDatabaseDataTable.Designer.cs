namespace ShenmueHDTools.GUI.Controls
{
    partial class FilenameDatabaseDataTable
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
            this.dataGridView_DB = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Filter = new System.Windows.Forms.TextBox();
            this.label_Count = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ColumnHash1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHash2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHash3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DB)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_DB
            // 
            this.dataGridView_DB.AllowUserToAddRows = false;
            this.dataGridView_DB.AllowUserToDeleteRows = false;
            this.dataGridView_DB.AllowUserToOrderColumns = true;
            this.dataGridView_DB.AllowUserToResizeRows = false;
            this.dataGridView_DB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_DB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnHash1,
            this.ColumnHash2,
            this.ColumnHash3,
            this.ColumnSize,
            this.ColumnPath,
            this.ColumnType});
            this.dataGridView_DB.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_DB.Name = "dataGridView_DB";
            this.dataGridView_DB.Size = new System.Drawing.Size(500, 168);
            this.dataGridView_DB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_Filter
            // 
            this.textBox_Filter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Filter.Location = new System.Drawing.Point(53, 3);
            this.textBox_Filter.Name = "textBox_Filter";
            this.textBox_Filter.Size = new System.Drawing.Size(321, 20);
            this.textBox_Filter.TabIndex = 2;
            this.textBox_Filter.TextChanged += new System.EventHandler(this.textBox_Filter_TextChanged);
            // 
            // label_Count
            // 
            this.label_Count.AutoSize = true;
            this.label_Count.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Count.Location = new System.Drawing.Point(380, 0);
            this.label_Count.Name = "label_Count";
            this.label_Count.Size = new System.Drawing.Size(114, 26);
            this.label_Count.TabIndex = 4;
            this.label_Count.Text = "Entries: 0";
            this.label_Count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Controls.Add(this.label_Count, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Filter, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 171);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(497, 26);
            this.tableLayoutPanel1.TabIndex = 5;
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
            // ColumnSize
            // 
            this.ColumnSize.DataPropertyName = "FileSize";
            this.ColumnSize.HeaderText = "Size";
            this.ColumnSize.Name = "ColumnSize";
            this.ColumnSize.ReadOnly = true;
            // 
            // ColumnPath
            // 
            this.ColumnPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPath.DataPropertyName = "Filename";
            this.ColumnPath.HeaderText = "Filename";
            this.ColumnPath.MinimumWidth = 50;
            this.ColumnPath.Name = "ColumnPath";
            this.ColumnPath.ReadOnly = true;
            // 
            // ColumnType
            // 
            this.ColumnType.DataPropertyName = "Type";
            this.ColumnType.HeaderText = "Archive";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            // 
            // FilenameDatabaseDataTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dataGridView_DB);
            this.Name = "FilenameDatabaseDataTable";
            this.Size = new System.Drawing.Size(500, 200);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DB)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_DB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Filter;
        private System.Windows.Forms.Label label_Count;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHash1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHash2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHash3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
    }
}
