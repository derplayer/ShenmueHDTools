using Be.Windows.Forms;
using ShenmueDKSharp.Files.Misc;
using ShenmueDKSharp.Files.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShenmueHDMapEditor
{
    public partial class MapEditor : Form
    {
        private MAPINFO m_mapinfo;
        private DynamicByteProvider m_provider;

        public MapEditor()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "MAPINFO files|mapinfo.bin;mapinfo.bin";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_mapinfo = new MAPINFO(openFileDialog.FileName);

                treeView.Nodes.Clear();
                TreeNode rootNode = TokenHelper.CreateTree(m_mapinfo.Tokens);
                rootNode.Text = openFileDialog.FileName;
                treeView.Nodes.Add(rootNode);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_mapinfo == null) return;
            m_mapinfo.Write(m_mapinfo.FilePath);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_mapinfo == null) return;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "MAPINFO files|mapinfo.bin;mapinfo.bin";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_mapinfo.Write(saveFileDialog.FileName);
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView.SelectedNode;
            if (node == null || node.Level == 0) return;
            BaseToken token = (BaseToken)node.Tag;
            if (token.Tokens.Count > 0)
            {
                hexBox.ByteProvider = null;
                return;
            }
            m_provider = new DynamicByteProvider(token.Content);
            m_provider.Changed += ByteProvider_Changed;
            hexBox.ByteProvider = m_provider;
        }

        private void ByteProvider_Changed(object sender, EventArgs e)
        {
            TreeNode node = treeView.SelectedNode;
            if (node == null || node.Level == 0) return;
            BaseToken token = (BaseToken)node.Tag;
            token.Content = m_provider.Bytes.ToArray();
            token.Size = (uint)(token.Content.Length + 8);
        }

        private void hexBox_SelectionStartChanged(object sender, EventArgs e)
        {

        }
    }
}
