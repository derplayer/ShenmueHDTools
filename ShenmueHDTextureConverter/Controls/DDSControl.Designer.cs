namespace ShenmueHDTextureConverter.Controls
{
    partial class DDSControl
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
            this.comboBox_AlphaSettings = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_MipHandling = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_DDSFormat = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_DXGIFormat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox_AlphaSettings
            // 
            this.comboBox_AlphaSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_AlphaSettings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AlphaSettings.FormattingEnabled = true;
            this.comboBox_AlphaSettings.Location = new System.Drawing.Point(117, 11);
            this.comboBox_AlphaSettings.Name = "comboBox_AlphaSettings";
            this.comboBox_AlphaSettings.Size = new System.Drawing.Size(293, 21);
            this.comboBox_AlphaSettings.TabIndex = 0;
            this.comboBox_AlphaSettings.SelectedIndexChanged += new System.EventHandler(this.comboBox_AlphaSettings_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Alpha Settings:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "MipMap Handling:";
            // 
            // comboBox_MipHandling
            // 
            this.comboBox_MipHandling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_MipHandling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_MipHandling.FormattingEnabled = true;
            this.comboBox_MipHandling.Location = new System.Drawing.Point(117, 38);
            this.comboBox_MipHandling.Name = "comboBox_MipHandling";
            this.comboBox_MipHandling.Size = new System.Drawing.Size(293, 21);
            this.comboBox_MipHandling.TabIndex = 2;
            this.comboBox_MipHandling.SelectedIndexChanged += new System.EventHandler(this.comboBox_MipHandling_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "DDS Format:";
            // 
            // comboBox_DDSFormat
            // 
            this.comboBox_DDSFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_DDSFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DDSFormat.FormattingEnabled = true;
            this.comboBox_DDSFormat.Location = new System.Drawing.Point(117, 65);
            this.comboBox_DDSFormat.Name = "comboBox_DDSFormat";
            this.comboBox_DDSFormat.Size = new System.Drawing.Size(293, 21);
            this.comboBox_DDSFormat.TabIndex = 4;
            this.comboBox_DDSFormat.SelectedIndexChanged += new System.EventHandler(this.comboBox_DDSFormat_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "DXGI/DX10 Format:";
            // 
            // comboBox_DXGIFormat
            // 
            this.comboBox_DXGIFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_DXGIFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DXGIFormat.FormattingEnabled = true;
            this.comboBox_DXGIFormat.Location = new System.Drawing.Point(117, 93);
            this.comboBox_DXGIFormat.Name = "comboBox_DXGIFormat";
            this.comboBox_DXGIFormat.Size = new System.Drawing.Size(293, 21);
            this.comboBox_DXGIFormat.TabIndex = 7;
            this.comboBox_DXGIFormat.SelectedIndexChanged += new System.EventHandler(this.comboBox_DXGIFormat_SelectedIndexChanged);
            // 
            // DDSControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox_DXGIFormat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_DDSFormat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_MipHandling);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_AlphaSettings);
            this.Name = "DDSControl";
            this.Size = new System.Drawing.Size(413, 291);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_AlphaSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_MipHandling;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_DDSFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_DXGIFormat;
    }
}
