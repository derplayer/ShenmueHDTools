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
            this.button_Load = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Fetch = new System.Windows.Forms.Button();
            this.button_Merge = new System.Windows.Forms.Button();
            this.button_Local = new System.Windows.Forms.Button();
            this.wulinshuRaymonfDataTable1 = new ShenmueHDTools.GUI.Controls.WulinshuRaymonfDataTable();
            this.SuspendLayout();
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
            this.button_Merge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Merge.Location = new System.Drawing.Point(604, 12);
            this.button_Merge.Name = "button_Merge";
            this.button_Merge.Size = new System.Drawing.Size(168, 23);
            this.button_Merge.TabIndex = 4;
            this.button_Merge.Text = "Merge with Filename Database";
            this.button_Merge.UseVisualStyleBackColor = true;
            this.button_Merge.Click += new System.EventHandler(this.button_Merge_Click);
            // 
            // button_Local
            // 
            this.button_Local.Location = new System.Drawing.Point(288, 12);
            this.button_Local.Name = "button_Local";
            this.button_Local.Size = new System.Drawing.Size(171, 23);
            this.button_Local.TabIndex = 5;
            this.button_Local.Text = "Fetch offline fallback Database";
            this.button_Local.UseVisualStyleBackColor = true;
            this.button_Local.Click += new System.EventHandler(this.button_Local_Click);
            // 
            // wulinshuRaymonfDataTable1
            // 
            this.wulinshuRaymonfDataTable1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wulinshuRaymonfDataTable1.Location = new System.Drawing.Point(12, 41);
            this.wulinshuRaymonfDataTable1.Name = "wulinshuRaymonfDataTable1";
            this.wulinshuRaymonfDataTable1.Size = new System.Drawing.Size(760, 358);
            this.wulinshuRaymonfDataTable1.TabIndex = 0;
            // 
            // RaymonfDatabaseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.button_Local);
            this.Controls.Add(this.button_Merge);
            this.Controls.Add(this.button_Fetch);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Load);
            this.Controls.Add(this.wulinshuRaymonfDataTable1);
            this.MinimumSize = new System.Drawing.Size(660, 300);
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
        private System.Windows.Forms.Button button_Local;
    }
}