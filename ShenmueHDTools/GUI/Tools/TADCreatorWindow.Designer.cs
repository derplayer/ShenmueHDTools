namespace ShenmueHDTools.GUI.Tools
{
    partial class TADCreatorWindow
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
            this.button_Create = new System.Windows.Forms.Button();
            this.listBox_Files = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Hash2 = new System.Windows.Forms.TextBox();
            this.textBox_Hash1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Filepath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker_TADDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Create
            // 
            this.button_Create.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Create.Location = new System.Drawing.Point(3, 423);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(389, 23);
            this.button_Create.TabIndex = 0;
            this.button_Create.Text = "Create...";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // listBox_Files
            // 
            this.listBox_Files.AllowDrop = true;
            this.listBox_Files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Files.FormattingEnabled = true;
            this.listBox_Files.Location = new System.Drawing.Point(0, 0);
            this.listBox_Files.Name = "listBox_Files";
            this.listBox_Files.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_Files.Size = new System.Drawing.Size(401, 450);
            this.listBox_Files.TabIndex = 1;
            this.listBox_Files.SelectedIndexChanged += new System.EventHandler(this.listBox_Files_SelectedIndexChanged);
            this.listBox_Files.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_Files_DragDrop);
            this.listBox_Files.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_Files_DragEnter);
            this.listBox_Files.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_Files_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBox_Files);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.button_Create);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 401;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBox_Hash2);
            this.groupBox2.Controls.Add(this.textBox_Hash1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox_Filepath);
            this.groupBox2.Location = new System.Drawing.Point(3, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 245);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Settings";
            // 
            // textBox_Hash2
            // 
            this.textBox_Hash2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Hash2.Location = new System.Drawing.Point(59, 87);
            this.textBox_Hash2.Name = "textBox_Hash2";
            this.textBox_Hash2.ReadOnly = true;
            this.textBox_Hash2.Size = new System.Drawing.Size(324, 20);
            this.textBox_Hash2.TabIndex = 5;
            // 
            // textBox_Hash1
            // 
            this.textBox_Hash1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Hash1.Location = new System.Drawing.Point(59, 57);
            this.textBox_Hash1.Name = "textBox_Hash1";
            this.textBox_Hash1.ReadOnly = true;
            this.textBox_Hash1.Size = new System.Drawing.Size(324, 20);
            this.textBox_Hash1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hash2:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hash1:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filepath:";
            // 
            // textBox_Filepath
            // 
            this.textBox_Filepath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Filepath.Location = new System.Drawing.Point(59, 25);
            this.textBox_Filepath.Name = "textBox_Filepath";
            this.textBox_Filepath.Size = new System.Drawing.Size(324, 20);
            this.textBox_Filepath.TabIndex = 0;
            this.textBox_Filepath.TextChanged += new System.EventHandler(this.textBox_Filepath_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker_TADDate);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 164);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TAD Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "TAD Patch Date:";
            // 
            // dateTimePicker_TADDate
            // 
            this.dateTimePicker_TADDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_TADDate.Location = new System.Drawing.Point(104, 28);
            this.dateTimePicker_TADDate.Name = "dateTimePicker_TADDate";
            this.dateTimePicker_TADDate.Size = new System.Drawing.Size(276, 20);
            this.dateTimePicker_TADDate.TabIndex = 0;
            // 
            // TADCreatorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TADCreatorWindow";
            this.Text = "TAD Creator";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Create;
        private System.Windows.Forms.ListBox listBox_Files;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Filepath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Hash2;
        private System.Windows.Forms.TextBox textBox_Hash1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_TADDate;
    }
}