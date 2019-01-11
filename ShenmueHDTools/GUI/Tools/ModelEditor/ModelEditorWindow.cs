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

namespace ShenmueHDTools.GUI.Tools.ModelEditor
{
    public partial class ModelEditorWindow : Form
    {
        private BaseModel m_model;
        private OpenTK.Graphics.OpenGL4.PrimitiveType m_primitiveType;

        public ModelEditorWindow()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Supported files|*.mt5;*.mt7;*.mapm;*.chrm;*.prop";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    byte[] buffer = new byte[4];
                    stream.Read(buffer, 0, 4);
                    stream.Seek(0, SeekOrigin.Begin);

                    if (MT5.IsValid(buffer))
                    {
                        m_model = new MT5(stream);
                        m_primitiveType = OpenTK.Graphics.OpenGL4.PrimitiveType.TriangleStrip;
                        view3D.SetModel(m_model, m_primitiveType);
                    }
                    else if (MT7.IsValid(buffer))
                    {
                        m_model = new MT7(stream);
                        m_primitiveType = OpenTK.Graphics.OpenGL4.PrimitiveType.Triangles;
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

                    foreach(Texture texture in m_model.Textures)
                    {
                        listBox_Textures.Items.Add(texture);
                    }
                }
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
                Console.WriteLine("TOOD");
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
            BaseImage image = m_model.Textures[listBox_Textures.SelectedIndex].Image;
            pictureBox_TextureView.Image = image.CreateBitmap();
            numericUpDown_MipMapIndex.Maximum = image.MipMaps.Count - 1;
        }

        private void treeView_MeshNodes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView_MeshNodes.SelectedNode;
            if (node == null || node.Level == 0) return;
            view3D.SetModelNode((ModelNode)node.Tag, m_primitiveType);
        }

        private void numericUpDown_MipMapIndex_ValueChanged(object sender, EventArgs e)
        {
            if (listBox_Textures.SelectedIndex >= m_model.Textures.Count) return;
            BaseImage image = m_model.Textures[listBox_Textures.SelectedIndex].Image;
            if (numericUpDown_MipMapIndex.Value > image.MipMaps.Count || numericUpDown_MipMapIndex.Value < 0) return;
            pictureBox_TextureView.Image = image.CreateBitmap((int)numericUpDown_MipMapIndex.Value);
        }
    }
}
