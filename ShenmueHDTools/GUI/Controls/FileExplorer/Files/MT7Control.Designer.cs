namespace ShenmueHDTools.GUI.Controls.FileExplorer.Files
{
    partial class MT7Control
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
            this.comboBox_RenderMode = new System.Windows.Forms.ComboBox();
            this.numericUpDown_ZNear = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_ZFar = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_Wireframe = new System.Windows.Forms.CheckBox();
            this.view3D = new ShenmueHDTools.GUI.Controls.View3D.View3D();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ZNear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ZFar)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_RenderMode
            // 
            this.comboBox_RenderMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RenderMode.FormattingEnabled = true;
            this.comboBox_RenderMode.Items.AddRange(new object[] {
            "Shaded",
            "Flat",
            "Normals",
            "UVs",
            "Color"});
            this.comboBox_RenderMode.Location = new System.Drawing.Point(3, 3);
            this.comboBox_RenderMode.Name = "comboBox_RenderMode";
            this.comboBox_RenderMode.Size = new System.Drawing.Size(166, 21);
            this.comboBox_RenderMode.TabIndex = 1;
            this.comboBox_RenderMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_RenderMode_SelectedIndexChanged);
            // 
            // numericUpDown_ZNear
            // 
            this.numericUpDown_ZNear.DecimalPlaces = 3;
            this.numericUpDown_ZNear.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_ZNear.Location = new System.Drawing.Point(296, 5);
            this.numericUpDown_ZNear.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDown_ZNear.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDown_ZNear.Name = "numericUpDown_ZNear";
            this.numericUpDown_ZNear.Size = new System.Drawing.Size(71, 20);
            this.numericUpDown_ZNear.TabIndex = 2;
            this.numericUpDown_ZNear.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown_ZNear.ValueChanged += new System.EventHandler(this.numericUpDown_ZNear_ValueChanged);
            // 
            // numericUpDown_ZFar
            // 
            this.numericUpDown_ZFar.DecimalPlaces = 2;
            this.numericUpDown_ZFar.Location = new System.Drawing.Point(407, 5);
            this.numericUpDown_ZFar.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_ZFar.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDown_ZFar.Name = "numericUpDown_ZFar";
            this.numericUpDown_ZFar.Size = new System.Drawing.Size(71, 20);
            this.numericUpDown_ZFar.TabIndex = 3;
            this.numericUpDown_ZFar.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_ZFar.ValueChanged += new System.EventHandler(this.numericUpDown_ZFar_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ZNear:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "ZFar:";
            // 
            // checkBox_Wireframe
            // 
            this.checkBox_Wireframe.AutoSize = true;
            this.checkBox_Wireframe.Location = new System.Drawing.Point(175, 5);
            this.checkBox_Wireframe.Name = "checkBox_Wireframe";
            this.checkBox_Wireframe.Size = new System.Drawing.Size(74, 17);
            this.checkBox_Wireframe.TabIndex = 6;
            this.checkBox_Wireframe.Text = "Wireframe";
            this.checkBox_Wireframe.UseVisualStyleBackColor = true;
            this.checkBox_Wireframe.CheckedChanged += new System.EventHandler(this.checkBox_Wireframe_CheckedChanged);
            // 
            // view3D
            // 
            this.view3D.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.view3D.BackColor = System.Drawing.Color.Black;
            this.view3D.Location = new System.Drawing.Point(0, 30);
            this.view3D.Name = "view3D";
            this.view3D.Size = new System.Drawing.Size(500, 239);
            this.view3D.TabIndex = 0;
            this.view3D.VSync = false;
            // 
            // MT7Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_Wireframe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_ZFar);
            this.Controls.Add(this.numericUpDown_ZNear);
            this.Controls.Add(this.comboBox_RenderMode);
            this.Controls.Add(this.view3D);
            this.Name = "MT7Control";
            this.Size = new System.Drawing.Size(503, 269);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ZNear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ZFar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View3D.View3D view3D;
        private System.Windows.Forms.ComboBox comboBox_RenderMode;
        private System.Windows.Forms.NumericUpDown numericUpDown_ZNear;
        private System.Windows.Forms.NumericUpDown numericUpDown_ZFar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_Wireframe;
    }
}
