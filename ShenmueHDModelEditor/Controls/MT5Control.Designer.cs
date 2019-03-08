namespace ShenmueHDModelEditor.Controls
{
    partial class MT5Control
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
            this.listBox_StripEntries = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.listBox_Strips = new System.Windows.Forms.ListBox();
            this.listBox_Vertices = new System.Windows.Forms.ListBox();
            this.vertexControl = new ShenmueHDModelEditor.Controls.VertexControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_StripEntries
            // 
            this.listBox_StripEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_StripEntries.FormattingEnabled = true;
            this.listBox_StripEntries.Location = new System.Drawing.Point(0, 0);
            this.listBox_StripEntries.Name = "listBox_StripEntries";
            this.listBox_StripEntries.Size = new System.Drawing.Size(186, 320);
            this.listBox_StripEntries.TabIndex = 0;
            this.listBox_StripEntries.SelectedIndexChanged += new System.EventHandler(this.listBox_StripEntries_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBox_StripEntries);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(558, 320);
            this.splitContainer1.SplitterDistance = 186;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.vertexControl);
            this.splitContainer2.Size = new System.Drawing.Size(368, 320);
            this.splitContainer2.SplitterDistance = 160;
            this.splitContainer2.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.listBox_Strips);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.listBox_Vertices);
            this.splitContainer3.Size = new System.Drawing.Size(368, 160);
            this.splitContainer3.SplitterDistance = 173;
            this.splitContainer3.TabIndex = 1;
            // 
            // listBox_Strips
            // 
            this.listBox_Strips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Strips.FormattingEnabled = true;
            this.listBox_Strips.Location = new System.Drawing.Point(0, 0);
            this.listBox_Strips.Name = "listBox_Strips";
            this.listBox_Strips.Size = new System.Drawing.Size(173, 160);
            this.listBox_Strips.TabIndex = 0;
            this.listBox_Strips.SelectedIndexChanged += new System.EventHandler(this.listBox_Strips_SelectedIndexChanged);
            // 
            // listBox_Vertices
            // 
            this.listBox_Vertices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Vertices.FormattingEnabled = true;
            this.listBox_Vertices.HorizontalScrollbar = true;
            this.listBox_Vertices.Location = new System.Drawing.Point(0, 0);
            this.listBox_Vertices.Name = "listBox_Vertices";
            this.listBox_Vertices.Size = new System.Drawing.Size(191, 160);
            this.listBox_Vertices.TabIndex = 0;
            this.listBox_Vertices.SelectedIndexChanged += new System.EventHandler(this.listBox_Vertices_SelectedIndexChanged);
            // 
            // vertexControl
            // 
            this.vertexControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vertexControl.Location = new System.Drawing.Point(0, 0);
            this.vertexControl.MinimumSize = new System.Drawing.Size(370, 120);
            this.vertexControl.Name = "vertexControl";
            this.vertexControl.Size = new System.Drawing.Size(370, 156);
            this.vertexControl.TabIndex = 0;
            // 
            // MT5Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "MT5Control";
            this.Size = new System.Drawing.Size(558, 320);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_StripEntries;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBox_Strips;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox listBox_Vertices;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private VertexControl vertexControl;
    }
}
