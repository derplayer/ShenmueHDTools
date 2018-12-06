using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShenmueHDTools.Main.Files.Nodes;
using ShenmueDKSharp.Files.Models;

namespace ShenmueHDTools.GUI.Controls.FileExplorer.Files
{
    public partial class MT5Control : UserControl
    {
        private FileNode m_file;

        public MT5Control()
        {
            InitializeComponent();
        }

        public void SetFile(FileNode file)
        {
            m_file = file;
            view3D.SetModel(((IModelNode)m_file).GetModel(), OpenTK.Graphics.OpenGL4.PrimitiveType.TriangleStrip);
        }

        private void comboBox_RenderMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_RenderMode.SelectedIndex)
            {
                case 0:
                    view3D.SetRenderMode(View3D.View3D.RenderMode.Shaded);
                    break;
                case 1:
                    view3D.SetRenderMode(View3D.View3D.RenderMode.Flat);
                    break;
                case 2:
                    view3D.SetRenderMode(View3D.View3D.RenderMode.Normal);
                    break;
                case 3:
                    view3D.SetRenderMode(View3D.View3D.RenderMode.UV);
                    break;
                case 4:
                    view3D.SetRenderMode(View3D.View3D.RenderMode.Color);
                    break;
            }

        }

        private void checkBox_Wireframe_CheckedChanged(object sender, EventArgs e)
        {
            view3D.SetWireframe(checkBox_Wireframe.Checked);
        }

        private void numericUpDown_ZNear_ValueChanged(object sender, EventArgs e)
        {
            view3D.SetZBuffer((float)numericUpDown_ZNear.Value, (float)numericUpDown_ZFar.Value);
        }

        private void numericUpDown_ZFar_ValueChanged(object sender, EventArgs e)
        {
            view3D.SetZBuffer((float)numericUpDown_ZNear.Value, (float)numericUpDown_ZFar.Value);
        }
    }
}
