using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ShenmueDKSharp.Files.Models;
using ShenmueDKSharp.Files.Images;

namespace ShenmueHDModelEditor
{
    public partial class ModelEditor : Form
    {
        private BaseModel m_model;
        private OpenTK.Graphics.OpenGL4.PrimitiveType m_primitiveType;

        private ModelType m_modelType;

        public enum ModelType
        {
            MT5,
            MT7,
            FBXD3T
        }

        public ModelEditor()
        {
            InitializeComponent();
            comboBox_RenderMode.SelectedIndex = 0;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Supported files|*.mt5;*.mt7;*.mapm;*.chrm;*.prop;*.fbx;*.obj";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(openFileDialog.FileName);

                byte[] buffer = new byte[4];
                using (FileStream stream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    stream.Read(buffer, 0, 4);
                    stream.Seek(0, SeekOrigin.Begin);
                }

                if (MT5.IsValid(buffer))
                {
                    m_model = new MT5(openFileDialog.FileName);
                    m_primitiveType = OpenTK.Graphics.OpenGL4.PrimitiveType.TriangleStrip;
                    view3D.SetTextures(m_model.Textures);
                    view3D.SetModel(m_model, m_primitiveType);
                    m_modelType = ModelType.MT5;
                }
                else if (MT7.IsValid(buffer))
                {
                    m_model = new MT7(openFileDialog.FileName);
                    m_primitiveType = OpenTK.Graphics.OpenGL4.PrimitiveType.Triangles;
                    view3D.SetTextures(m_model.Textures);
                    view3D.SetModel(m_model, m_primitiveType);
                    m_modelType = ModelType.MT7;
                }
                else if (FBXD3T.IsValid(buffer))
                {
                    m_model = new FBXD3T(openFileDialog.FileName);
                    m_modelType = ModelType.FBXD3T;
                }
                else if (extension == ".obj")
                {
                    m_model = new OBJ(openFileDialog.FileName);
                    m_primitiveType = OpenTK.Graphics.OpenGL4.PrimitiveType.Triangles;
                    view3D.SetTextures(m_model.Textures);
                    view3D.SetModel(m_model, m_primitiveType);
                }
                else
                {
                    Console.WriteLine("Invalid file format!");
                }

                treeView_MeshNodes.Nodes.Clear();
                listBox_Textures.Items.Clear();

                m_model.RootNode.GenerateTree(null);
                TreeNode treeNode = new TreeNode(openFileDialog.FileName);
                GenerateTree(treeNode, m_model.RootNode);
                treeView_MeshNodes.Nodes.Add(treeNode);

                foreach (Texture texture in m_model.Textures)
                {
                    if (texture == null) continue;
                    listBox_Textures.Items.Add(texture);
                }
            }

            if (m_modelType == ModelType.MT5)
            {
                mt5Control.Enabled = true;
                mt7Control.Enabled = false;
            }
            if (m_modelType == ModelType.MT7)
            {
                mt5Control.Enabled = false;
                mt7Control.Enabled = true;
            }
        }

        private void GenerateTree(TreeNode treeNode, ModelNode modelNode)
        {
            TreeNode tNode = new TreeNode(modelNode.ToString());
            tNode.Tag = modelNode;
            foreach(ModelNode mNode in modelNode.Children)
            {
                GenerateTree(tNode, mNode);
            }
            treeNode.Nodes.Add(tNode);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "MT5 file (*.mt5)|*.mt5|MT7 file (*.mt7)|*.mt7";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (m_modelType == ModelType.MT5)
                {
                    MT5 mt5 = (MT5)m_model;
                    mt5.Write(saveFileDialog.FileName);
                }
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

        private void comboBox_RenderMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            view3D.SetRenderMode((Controls.View3D.View3D.RenderMode)comboBox_RenderMode.SelectedIndex);
        }

        private void listBox_Textures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Textures.SelectedIndex >= m_model.Textures.Count) return;
            textureControl.SetTexture(m_model.Textures[listBox_Textures.SelectedIndex]);
        }

        private void treeView_MeshNodes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView_MeshNodes.SelectedNode;
            if (node == null || node.Level == 0) return;
            view3D.SetModelNode((ModelNode)node.Tag, m_primitiveType);
            nodeControl.SetNode((ModelNode)node.Tag);

            if (m_modelType == ModelType.MT5 && typeof(MT5Node).IsAssignableFrom(node.Tag.GetType()))
            {
                mt5Control.SetMT5Node((MT5Node)node.Tag);
            }
            if (m_modelType == ModelType.MT7 && typeof(MT7Node).IsAssignableFrom(node.Tag.GetType()))
            {
                mt7Control.SetMT7Node((MT7Node)node.Tag);
            }
        }

        private void nodeControl_OnNodeChanged(object sender, EventArgs e)
        {
            TreeNode node = treeView_MeshNodes.SelectedNode;
            if (node == null || node.Level == 0) return;
            view3D.SetModelNode((ModelNode)node.Tag, m_primitiveType);
        }

        private void textureControl_OnTextureChanged(object sender, EventArgs e)
        {
            view3D.SetTextures(m_model.Textures);
            TreeNode node = treeView_MeshNodes.SelectedNode;
            if (node == null || node.Level == 0) return;
            view3D.SetModelNode((ModelNode)node.Tag, m_primitiveType);
        }

        private void convertToMT5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_model = new MT5(m_model);
            m_primitiveType = OpenTK.Graphics.OpenGL4.PrimitiveType.TriangleStrip;
            view3D.SetModel(m_model, m_primitiveType);
            m_modelType = ModelType.MT5;

            treeView_MeshNodes.Nodes.Clear();
            listBox_Textures.Items.Clear();

            m_model.RootNode.GenerateTree(null);
            TreeNode treeNode = new TreeNode("MT5");
            GenerateTree(treeNode, m_model.RootNode);
            treeView_MeshNodes.Nodes.Add(treeNode);

            foreach (Texture texture in m_model.Textures)
            {
                listBox_Textures.Items.Add(texture);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Wavefront OBJ (*.obj)|*.obj";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                OBJ obj = new OBJ(m_model);
                obj.FilePath = saveFileDialog.FileName;
                obj.Write(saveFileDialog.FileName);
            }
        }

        private void mt5Control_OnSelectedVertexChanged(object sender, Vertex e)
        {
            TreeNode node = treeView_MeshNodes.SelectedNode;
            if (node == null || node.Level == 0) return;
            ModelNode modelNode = (ModelNode)node.Tag;
            ShenmueDKSharp.Matrix4 matrix = modelNode.GetTransformMatrix();
            Vertex vert = new Vertex(e);
            vert.Position = ShenmueDKSharp.Vector3.TransformPosition(vert.Position, matrix);
            view3D.SetSelectedVertex(vert);
        }
    }
}
