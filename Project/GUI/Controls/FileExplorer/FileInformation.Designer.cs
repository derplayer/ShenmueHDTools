namespace ShenmueHDTools.GUI.Controls
{
    partial class FileInformation
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
            this.richTextBox_Notes = new System.Windows.Forms.RichTextBox();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.comboBox_Category = new System.Windows.Forms.ComboBox();
            this.comboBox_Location = new System.Windows.Forms.ComboBox();
            this.textBox_RelativPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Checksum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Type = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // richTextBox_Notes
            // 
            this.richTextBox_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Notes.Location = new System.Drawing.Point(3, 112);
            this.richTextBox_Notes.MaxLength = 8192;
            this.richTextBox_Notes.Name = "richTextBox_Notes";
            this.richTextBox_Notes.Size = new System.Drawing.Size(506, 76);
            this.richTextBox_Notes.TabIndex = 0;
            this.richTextBox_Notes.Text = "";
            // 
            // textBox_Description
            // 
            this.textBox_Description.Location = new System.Drawing.Point(375, 8);
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.Size = new System.Drawing.Size(121, 20);
            this.textBox_Description.TabIndex = 1;
            // 
            // comboBox_Category
            // 
            this.comboBox_Category.FormattingEnabled = true;
            this.comboBox_Category.Location = new System.Drawing.Point(375, 34);
            this.comboBox_Category.Name = "comboBox_Category";
            this.comboBox_Category.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Category.TabIndex = 2;
            // 
            // comboBox_Location
            // 
            this.comboBox_Location.FormattingEnabled = true;
            this.comboBox_Location.Location = new System.Drawing.Point(375, 61);
            this.comboBox_Location.Name = "comboBox_Location";
            this.comboBox_Location.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Location.TabIndex = 3;
            // 
            // textBox_RelativPath
            // 
            this.textBox_RelativPath.Location = new System.Drawing.Point(87, 35);
            this.textBox_RelativPath.Name = "textBox_RelativPath";
            this.textBox_RelativPath.ReadOnly = true;
            this.textBox_RelativPath.Size = new System.Drawing.Size(100, 20);
            this.textBox_RelativPath.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Relativ Path: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Category:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(298, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Location:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Notes:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Checksum: ";
            // 
            // textBox_Checksum
            // 
            this.textBox_Checksum.Location = new System.Drawing.Point(87, 61);
            this.textBox_Checksum.Name = "textBox_Checksum";
            this.textBox_Checksum.ReadOnly = true;
            this.textBox_Checksum.Size = new System.Drawing.Size(100, 20);
            this.textBox_Checksum.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Type:";
            // 
            // textBox_Type
            // 
            this.textBox_Type.Location = new System.Drawing.Point(87, 8);
            this.textBox_Type.Name = "textBox_Type";
            this.textBox_Type.ReadOnly = true;
            this.textBox_Type.Size = new System.Drawing.Size(100, 20);
            this.textBox_Type.TabIndex = 14;
            // 
            // FileInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_Type);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_Checksum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_RelativPath);
            this.Controls.Add(this.comboBox_Location);
            this.Controls.Add(this.comboBox_Category);
            this.Controls.Add(this.textBox_Description);
            this.Controls.Add(this.richTextBox_Notes);
            this.Name = "FileInformation";
            this.Size = new System.Drawing.Size(512, 191);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_Notes;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.ComboBox comboBox_Category;
        private System.Windows.Forms.ComboBox comboBox_Location;
        private System.Windows.Forms.TextBox textBox_RelativPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Checksum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Type;
    }
}
