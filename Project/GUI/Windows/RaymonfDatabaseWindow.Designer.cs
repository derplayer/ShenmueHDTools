namespace ShenmueHDTools.GUI.Windows
{
    partial class RaymonfDatabaseWindow
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
            this.wulinshuRaymonfDataTable1 = new ShenmueHDTools.GUI.Controls.WulinshuRaymonfDataTable();
            this.button_Load = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Fetch = new System.Windows.Forms.Button();
            this.button_Merge = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wulinshuRaymonfDataTable1
            // 
            this.wulinshuRaymonfDataTable1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wulinshuRaymonfDataTable1.Location = new System.Drawing.Point(12, 41);
            this.wulinshuRaymonfDataTable1.Name = "wulinshuRaymonfDataTable1";
            this.wulinshuRaymonfDataTable1.Size = new System.Drawing.Size(776, 397);
            this.wulinshuRaymonfDataTable1.TabIndex = 0;
            // 
            // button_Load
            // 
            this.button_Load.Location = new System.Drawing.Point(12, 12);
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(75, 23);
            this.button_Load.TabIndex = 1;
            this.button_Load.Text = "Load...";
            this.button_Load.UseVisualStyleBackColor = true;
            this.button_Load.Click += new System.EventHandler(this.button_Load_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(93, 12);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 2;
            this.button_Save.Text = "Save...";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Fetch
            // 
            this.button_Fetch.Location = new System.Drawing.Point(174, 12);
            this.button_Fetch.Name = "button_Fetch";
            this.button_Fetch.Size = new System.Drawing.Size(108, 23);
            this.button_Fetch.TabIndex = 3;
            this.button_Fetch.Text = "Fetch Database";
            this.button_Fetch.UseVisualStyleBackColor = true;
            this.button_Fetch.Click += new System.EventHandler(this.button_Fetch_Click);
            // 
            // button_Merge
            // 
            this.button_Merge.Location = new System.Drawing.Point(288, 12);
            this.button_Merge.Name = "button_Merge";
            this.button_Merge.Size = new System.Drawing.Size(202, 23);
            this.button_Merge.TabIndex = 4;
            this.button_Merge.Text = "Merge  with Filename Database";
            this.button_Merge.UseVisualStyleBackColor = true;
            this.button_Merge.Click += new System.EventHandler(this.button_Merge_Click);
            // 
            // RaymonfDatabaseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_Merge);
            this.Controls.Add(this.button_Fetch);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Load);
            this.Controls.Add(this.wulinshuRaymonfDataTable1);
            this.Name = "RaymonfDatabaseWindow";
            this.ShowIcon = false;
            this.Text = "Wulinshu Raymonf Database";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.WulinshuRaymonfDataTable wulinshuRaymonfDataTable1;
        private System.Windows.Forms.Button button_Load;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Fetch;
        private System.Windows.Forms.Button button_Merge;
    }
}