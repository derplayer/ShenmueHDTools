namespace ShenmueHDTools.GUI.Windows
{
    partial class FilenameDatabaseWindow
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
            this.button_Generate = new System.Windows.Forms.Button();
            this.button_Load = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Merge = new System.Windows.Forms.Button();
            this.filenameDatabaseDataTable1 = new ShenmueHDTools.GUI.Controls.FilenameDatabaseDataTable();
            this.button_ExportJSON = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Generate
            // 
            this.button_Generate.Location = new System.Drawing.Point(174, 12);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Size = new System.Drawing.Size(126, 23);
            this.button_Generate.TabIndex = 1;
            this.button_Generate.Text = "Generate Database...";
            this.button_Generate.UseVisualStyleBackColor = true;
            this.button_Generate.Click += new System.EventHandler(this.button_Generate_Click);
            // 
            // button_Load
            // 
            this.button_Load.Location = new System.Drawing.Point(12, 12);
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(75, 23);
            this.button_Load.TabIndex = 2;
            this.button_Load.Text = "Load...";
            this.button_Load.UseVisualStyleBackColor = true;
            this.button_Load.Click += new System.EventHandler(this.button_Load_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(93, 12);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 3;
            this.button_Save.Text = "Save...";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Clear.Location = new System.Drawing.Point(697, 12);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 4;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_Merge
            // 
            this.button_Merge.Location = new System.Drawing.Point(306, 12);
            this.button_Merge.Name = "button_Merge";
            this.button_Merge.Size = new System.Drawing.Size(104, 23);
            this.button_Merge.TabIndex = 5;
            this.button_Merge.Text = "Merge with...";
            this.button_Merge.UseVisualStyleBackColor = true;
            this.button_Merge.Click += new System.EventHandler(this.button_Merge_Click);
            // 
            // filenameDatabaseDataTable1
            // 
            this.filenameDatabaseDataTable1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameDatabaseDataTable1.Location = new System.Drawing.Point(12, 41);
            this.filenameDatabaseDataTable1.Name = "filenameDatabaseDataTable1";
            this.filenameDatabaseDataTable1.Size = new System.Drawing.Size(760, 358);
            this.filenameDatabaseDataTable1.TabIndex = 0;
            // 
            // button_ExportJSON
            // 
            this.button_ExportJSON.Location = new System.Drawing.Point(416, 12);
            this.button_ExportJSON.Name = "button_ExportJSON";
            this.button_ExportJSON.Size = new System.Drawing.Size(101, 23);
            this.button_ExportJSON.TabIndex = 6;
            this.button_ExportJSON.Text = "Export JSON...";
            this.button_ExportJSON.UseVisualStyleBackColor = true;
            this.button_ExportJSON.Click += new System.EventHandler(this.button_ExportJSON_Click);
            // 
            // FilenameDatabaseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.button_ExportJSON);
            this.Controls.Add(this.button_Merge);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Load);
            this.Controls.Add(this.button_Generate);
            this.Controls.Add(this.filenameDatabaseDataTable1);
            this.MinimumSize = new System.Drawing.Size(520, 300);
            this.Name = "FilenameDatabaseWindow";
            this.ShowIcon = false;
            this.Text = "Filename Database";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FilenameDatabaseDataTable filenameDatabaseDataTable1;
        private System.Windows.Forms.Button button_Generate;
        private System.Windows.Forms.Button button_Load;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Merge;
        private System.Windows.Forms.Button button_ExportJSON;
    }
}