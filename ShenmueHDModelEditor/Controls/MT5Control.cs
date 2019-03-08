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
    public partial class MT5Control : UserControl
    {
        private MT5Node m_node;

        public event EventHandler<Vertex> OnSelectedVertexChanged;

        public MT5Control()
        {
            InitializeComponent();
        }

        public void SetMT5Node(MT5Node node)
        {
            m_node = node;
            listBox_StripEntries.Items.Clear();
            listBox_Strips.Items.Clear();
            listBox_Vertices.Items.Clear();
            if (m_node.MeshData == null) return;
            foreach (MT5StripEntry entry in m_node.MeshData.StripEntries)
            {
                listBox_StripEntries.Items.Add(entry);
            }
        }

        private void listBox_StripEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_Strips.Items.Clear();
            listBox_Vertices.Items.Clear();
            if (listBox_StripEntries.SelectedIndex < 0) return;
            if (typeof(MT5Strip).IsAssignableFrom(listBox_StripEntries.SelectedItem.GetType()))
            {
                MT5Strip strip = (MT5Strip)listBox_StripEntries.SelectedItem;
                foreach (MeshFace face in strip.Faces)
                {
                    listBox_Strips.Items.Add(face);
                }
            }
        }

        private void listBox_Strips_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_Vertices.Items.Clear();
            if (listBox_Strips.SelectedIndex < 0) return;
            MeshFace face = (MeshFace)listBox_Strips.SelectedItem;
            foreach (Vertex vert in face.GetVertexArray(m_node))
            {
                listBox_Vertices.Items.Add(vert);
            }
        }

        private void listBox_Vertices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Vertices.SelectedIndex < 0) return;
            Vertex vert = (Vertex)listBox_Vertices.SelectedItem;
            vertexControl.SetVertex(vert);
            OnSelectedVertexChanged(this, vert);
        }
    }
}
