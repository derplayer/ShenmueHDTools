namespace ShenmueHDTextureConverter.Controls
{
    partial class PVRTControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_CreateTEXN = new System.Windows.Forms.CheckBox();
            this.comboBox_DataCodec = new System.Windows.Forms.ComboBox();
            this.comboBox_PixelCodec = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_DDS = new System.Windows.Forms.GroupBox();
            this.checkBox_InsertDDS = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox_DDS.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkBox_CreateTEXN);
            this.groupBox1.Location = new System.Drawing.Point(3, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TEXN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Example: {TEX_ID}.{TEX_NAME}.PVR";
            // 
            // checkBox_CreateTEXN
            // 
            this.checkBox_CreateTEXN.AutoSize = true;
            this.checkBox_CreateTEXN.Location = new System.Drawing.Point(13, 30);
            this.checkBox_CreateTEXN.Name = "checkBox_CreateTEXN";
            this.checkBox_CreateTEXN.Size = new System.Drawing.Size(256, 17);
            this.checkBox_CreateTEXN.TabIndex = 0;
            this.checkBox_CreateTEXN.Text = "Create TEXN with texture ID (HEX) from filename";
            this.checkBox_CreateTEXN.UseVisualStyleBackColor = true;
            this.checkBox_CreateTEXN.CheckedChanged += new System.EventHandler(this.checkBox_CreateTEXN_CheckedChanged);
            // 
            // comboBox_DataCodec
            // 
            this.comboBox_DataCodec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_DataCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DataCodec.FormattingEnabled = true;
            this.comboBox_DataCodec.Location = new System.Drawing.Point(82, 13);
            this.comboBox_DataCodec.Name = "comboBox_DataCodec";
            this.comboBox_DataCodec.Size = new System.Drawing.Size(376, 21);
            this.comboBox_DataCodec.TabIndex = 1;
            this.comboBox_DataCodec.SelectedIndexChanged += new System.EventHandler(this.comboBox_DataCodec_SelectedIndexChanged);
            // 
            // comboBox_PixelCodec
            // 
            this.comboBox_PixelCodec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_PixelCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PixelCodec.FormattingEnabled = true;
            this.comboBox_PixelCodec.Location = new System.Drawing.Point(82, 40);
            this.comboBox_PixelCodec.Name = "comboBox_PixelCodec";
            this.comboBox_PixelCodec.Size = new System.Drawing.Size(376, 21);
            this.comboBox_PixelCodec.TabIndex = 2;
            this.comboBox_PixelCodec.SelectedIndexChanged += new System.EventHandler(this.comboBox_PixelCodec_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Data Codec:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pixel Codec:";
            // 
            // groupBox_DDS
            // 
            this.groupBox_DDS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_DDS.Controls.Add(this.checkBox_InsertDDS);
            this.groupBox_DDS.Location = new System.Drawing.Point(3, 170);
            this.groupBox_DDS.Name = "groupBox_DDS";
            this.groupBox_DDS.Size = new System.Drawing.Size(455, 68);
            this.groupBox_DDS.TabIndex = 5;
            this.groupBox_DDS.TabStop = false;
            this.groupBox_DDS.Text = "DDS";
            // 
            // checkBox_InsertDDS
            // 
            this.checkBox_InsertDDS.AutoSize = true;
            this.checkBox_InsertDDS.Location = new System.Drawing.Point(13, 31);
            this.checkBox_InsertDDS.Name = "checkBox_InsertDDS";
            this.checkBox_InsertDDS.Size = new System.Drawing.Size(284, 17);
            this.checkBox_InsertDDS.TabIndex = 0;
            this.checkBox_InsertDDS.Text = "Write DDS without converting (Requires DDS as input)";
            this.checkBox_InsertDDS.UseVisualStyleBackColor = true;
            this.checkBox_InsertDDS.CheckedChanged += new System.EventHandler(this.checkBox_InsertDDS_CheckedChanged);
            // 
            // PVRTControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_DDS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_PixelCodec);
            this.Controls.Add(this.comboBox_DataCodec);
            this.Controls.Add(this.groupBox1);
            this.Name = "PVRTControl";
            this.Size = new System.Drawing.Size(461, 249);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_DDS.ResumeLayout(false);
            this.groupBox_DDS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_DataCodec;
        private System.Windows.Forms.ComboBox comboBox_PixelCodec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_CreateTEXN;
        private System.Windows.Forms.GroupBox groupBox_DDS;
        private System.Windows.Forms.CheckBox checkBox_InsertDDS;
        private System.Windows.Forms.Label label3;
    }
}
