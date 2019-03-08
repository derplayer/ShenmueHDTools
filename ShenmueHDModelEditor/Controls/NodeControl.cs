using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShenmueDKSharp.Files.Models;
using ShenmueDKSharp.Files.Models._MT5;

namespace ShenmueHDModelEditor.Controls
{
    public partial class NodeControl : UserControl
    {
        private ModelNode m_node;
        private bool m_updateValues;

        public event EventHandler OnNodeChanged;

        public NodeControl()
        {
            InitializeComponent();
        }

        public void SetNode(ModelNode node)
        {
            m_node = node;
            UpdateValues();
        }


        private void button_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Supported files|*.obj";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void button_Import_Click(object sender, EventArgs e)
        {
            if (!typeof(MT5Node).IsAssignableFrom(m_node.GetType())) return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Supported files|*.obj";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MT5Node mt5Node = (MT5Node)m_node;
                OBJ obj = new OBJ(openFileDialog.FileName);
                mt5Node.MeshData = new MT5Mesh(obj.RootNode, mt5Node);
                OnNodeChanged(this, null);
            }
        }

        public void UpdateValues()
        {
            m_updateValues = true;
            numericUpDown_NodeID.Value = m_node.ID;
            numericUpDown_Radius.Value = (decimal)m_node.Radius;

            numericUpDown_CenterX.Value = (decimal)m_node.Center.X;
            numericUpDown_CenterY.Value = (decimal)m_node.Center.Y;
            numericUpDown_CenterZ.Value = (decimal)m_node.Center.Z;

            numericUpDown_PosX.Value = (decimal)m_node.Position.X;
            numericUpDown_PosY.Value = (decimal)m_node.Position.Y;
            numericUpDown_PosZ.Value = (decimal)m_node.Position.Z;

            numericUpDown_RotX.Value = (decimal)m_node.Rotation.X;
            numericUpDown_RotY.Value = (decimal)m_node.Rotation.Y;
            numericUpDown_RotZ.Value = (decimal)m_node.Rotation.Z;

            numericUpDown_SclX.Value = (decimal)m_node.Scale.X;
            numericUpDown_SclY.Value = (decimal)m_node.Scale.Y;
            numericUpDown_SclZ.Value = (decimal)m_node.Scale.Z;
            m_updateValues = false;
        }

        private void numericUpDown_NodeID_ValueChanged(object sender, EventArgs e)
        {
            if (m_updateValues) return;
            m_node.ID = (uint)numericUpDown_NodeID.Value;
            OnNodeChanged(this, null);
        }

        private void numericUpDown_Radius_ValueChanged(object sender, EventArgs e)
        {
            if (m_updateValues) return;
            m_node.Radius = (float)numericUpDown_Radius.Value;
            OnNodeChanged(this, null);
        }

        private void numericUpDown_CenterX_ValueChanged(object sender, EventArgs e)
        {
            if (m_updateValues) return;
            m_node.Center.X = (float)numericUpDown_CenterX.Value;
            OnNodeChanged(this, null);
        }

        private void numericUpDown_CenterY_ValueChanged(object sender, EventArgs e)
        {
            if (m_updateValues) return;
            m_node.Center.Y = (float)numericUpDown_CenterY.Value;
            OnNodeChanged(this, null);
        }

        private void numericUpDown_CenterZ_ValueChanged(object sender, EventArgs e)
        {
            if (m_updateValues) return;
            m_node.Center.Z = (float)numericUpDown_CenterZ.Value;
            OnNodeChanged(this, null);
        }

        private void numericUpDown_PosX_ValueChanged(object sender, EventArgs e)
        {
            if (m_updateValues) return;
            m_node.Position.X = (float)numericUpDown_PosX.Value;
            OnNodeChanged(this, null);
        }

        private void numericUpDown_PosY_ValueChanged(object sender, EventArgs e)
        {
            if (m_updateValues) return;
            m_node.Position.Y = (float)numericUpDown_PosY.Value;
            OnNodeChanged(this, null);
        }

        private void numericUpDown_PosZ_ValueChanged(object sender, EventArgs e)
        {
            if (m_updateValues) return;
            m_node.Position.Z = (float)numericUpDown_PosZ.Value;
            OnNodeChanged(this, null);
        }

        private void numericUpDown_RotX_ValueChanged(object sender, EventArgs e)
        {
            if (m_updateValues) return;
            m_node.Rotation.X = (float)numericUpDown_RotX.Value;
            OnNodeChanged(this, null);
        }

        private void numericUpDown_RotY_ValueChanged(object sender, EventArgs e)
        {
            if (m_updateValues) return;
            m_node.Rotation.Y = (float)numericUpDown_RotY.Value;
            OnNodeChanged(this, null);
        }

        private void numericUpDown_RotZ_ValueChanged(object sender, EventArgs e)
        {
            if (m_updateValues) return;
            m_node.Rotation.Z = (float)numericUpDown_RotZ.Value;
            OnNodeChanged(this, null);
        }

        private void numericUpDown_SclX_ValueChanged(object sender, EventArgs e)
        {
            if (m_updateValues) return;
            m_node.Scale.X = (float)numericUpDown_SclX.Value;
            OnNodeChanged(this, null);
        }

        private void numericUpDown_SclY_ValueChanged(object sender, EventArgs e)
        {
            if (m_updateValues) return;
            m_node.Scale.Y = (float)numericUpDown_SclY.Value;
            OnNodeChanged(this, null);
        }

        private void numericUpDown_SclZ_ValueChanged(object sender, EventArgs e)
        {
            if (m_updateValues) return;
            m_node.Scale.Z = (float)numericUpDown_SclZ.Value;
            OnNodeChanged(this, null);
        }

    }
}
