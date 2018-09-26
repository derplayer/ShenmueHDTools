using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShenmueHDTools.Main.Files;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.GUI.Controls
{
    public partial class FileTreeView : UserControl
    {
        public event EventHandler<FileNode> SelectionChanged;

        private Dictionary<TreeNode, bool> m_preFilterCollapse = new Dictionary<TreeNode, bool>();

        private CacheFile m_cacheFile;
        private TreeNode m_grouped;
        private TreeNode m_filtered;
        private bool m_filter;

        public FileTreeView()
        {
            InitializeComponent();

            foreach (FileNode.TreeType treeType in Enum.GetValues(typeof(FileNode.TreeType)))
            {
                comboBox_GroupBy.Items.Add(treeType);
            }

            comboBox_GroupBy.SelectedIndex = 1;
        }

        public void SetCache(CacheFile cacheFile)
        {
            m_cacheFile = cacheFile;
            UpdateTree(FileNode.TreeType.FilePath);
        }

        private void UpdateTree(FileNode.TreeType treeType)
        {
            if (m_cacheFile == null) return;
            treeView_Files.Nodes.Clear();

            TreeNode rootNode = new TreeNode(m_cacheFile.Header.RelativeTACPath.Substring(1));
            rootNode.Tag = m_cacheFile;

            foreach (FileNode node in m_cacheFile.Files)
            {
                node.CreateTreeNode(rootNode, treeType);
            }
            m_grouped = rootNode;
            treeView_Files.Nodes.Add(rootNode);
            StoreCollapseState();
        }

        private bool SearchTreeNodes(TreeNode node, TreeNode newNode, string search, bool force = false)
        {
            bool found = false;
            foreach (TreeNode child in node.Nodes)
            {
                TreeNode newChild = new TreeNode();
                newChild.Text = child.Text;
                newChild.Tag = child.Tag;
                newChild.ImageIndex = child.ImageIndex;
                newChild.SelectedImageIndex = child.SelectedImageIndex;

                if (force)
                {
                    SearchTreeNodes(child, newChild, search, true);
                    newNode.Nodes.Add(newChild);
                    found = true;
                    continue;
                }
                
                if (child.Text.ToLower().Contains(search.ToLower()))
                {
                    SearchTreeNodes(child, newChild, search, true);
                    newNode.Nodes.Add(newChild);
                    found = true;
                }
                else if (SearchTreeNodes(child, newChild, search))
                {
                    newNode.Nodes.Add(newChild);
                    found = true;
                }
            }
            return found;
        }

        private void StoreCollapseState()
        {
            m_preFilterCollapse.Clear();
            StoreCollapseRecursive(m_grouped);
        }

        private void StoreCollapseRecursive(TreeNode node)
        {
            m_preFilterCollapse.Add(node, node.IsExpanded);
            foreach (TreeNode child in node.Nodes)
            {
                StoreCollapseRecursive(child);
            }
        }

        private void LoadCollapseState()
        {
            LoadCollapseRecursive(m_grouped);
        }

        private void LoadCollapseRecursive(TreeNode node)
        {
            if (m_preFilterCollapse[node])
            {
                node.Expand();
            }
            else
            {
                node.Collapse();
            }

            foreach (TreeNode child in node.Nodes)
            {
                LoadCollapseRecursive(child);
            }
        }

        private void treeView_Files_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
            {
                SelectionChanged(sender, null);
                return;
            }
            if (e.Node.Tag == null)
            {
                SelectionChanged(sender, null);
                return;
            }
            if (e.Node.Tag.GetType() == typeof(CacheFile)) return;
            SelectionChanged(sender, (FileNode)e.Node.Tag);
        }

        private void comboBox_GroupBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTree((FileNode.TreeType)comboBox_GroupBy.SelectedIndex);
        }

        private void textBox_Search_TextChanged(object sender, EventArgs e)
        {
            if (m_grouped == null) return;
            if (String.IsNullOrEmpty(textBox_Search.Text))
            {
                m_filter = false;
                LoadCollapseState();
                treeView_Files.Nodes.Clear();
                treeView_Files.Nodes.Add(m_grouped);
            }
            else
            {
                if (!m_filter)
                {
                    m_filter = true;
                    StoreCollapseState();
                }
                m_filtered = new TreeNode
                {
                    Tag = m_grouped.Tag,
                    Text = m_grouped.Text,
                    SelectedImageIndex = m_grouped.SelectedImageIndex,
                    ImageIndex = m_grouped.ImageIndex
                };
                SearchTreeNodes(m_grouped, m_filtered, textBox_Search.Text);
                treeView_Files.Nodes.Clear();
                m_filtered.ExpandAll();
                treeView_Files.Nodes.Add(m_filtered);
            }
        }
    }
}
