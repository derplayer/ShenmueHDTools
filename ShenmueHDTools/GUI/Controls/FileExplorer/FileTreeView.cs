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
using ShenmueHDTools.Main;
using System.IO;
using ShenmueHDTools.GUI.Dialogs;
using System.Threading;

namespace ShenmueHDTools.GUI.Controls
{
    public partial class FileTreeView : UserControl, IProgressable
    {
        public event EventHandler<FileNode> SelectionChanged;
        public event FinishedEventHandler Finished;
        public event Main.ProgressChangedEventHandler ProgressChanged;
        public event DescriptionChangedEventHandler DescriptionChanged;
        public event Main.ErrorEventHandler Error;

        private Dictionary<TreeNode, bool> m_preFilterCollapse = new Dictionary<TreeNode, bool>();

        private CacheFile m_cacheFile;
        private TreeNode m_grouped;
        private TreeNode m_filtered;
        private bool m_filter;

        public bool IsAbortable => false;

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

        public CacheFile GetCache()
        {
            if (m_cacheFile == null) throw new NullReferenceException();
            return m_cacheFile;
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
            if (e.Node.Tag.GetType() == typeof(CacheFile))
            {
                SelectionChanged(sender, null);
                return;
            }
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

        private void treeView_Files_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                FileNode node = (FileNode)e.Node.Tag;
                ShellContextMenu ctxMnu = new ShellContextMenu();
                FileInfo[] arrFI = new FileInfo[1];
                arrFI[0] = new FileInfo(node.FullPath);
                ctxMnu.ShowContextMenu(arrFI, Cursor.Position);
            }
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            LoadingDialog loadingDialog = new LoadingDialog();
            loadingDialog.SetData(this);
            Thread thread = new Thread(delegate () {
                NodeRefresh();
            });
            loadingDialog.ShowDialog(thread);
        }

        private void NodeRefresh()
        {
            DescriptionChanged(this, new DescriptionChangedArgs("Calculating file hashes..."));
            for (int i = 0; i < treeView_Files.Nodes[0].Nodes.Count; i++)
            {
                ProgressChanged(this, new ProgressChangedArgs(i, treeView_Files.Nodes[0].Nodes.Count));
                TreeNode node = treeView_Files.Nodes[0].Nodes[i];
                NodeRefreshRecursive(node);
            }
            Finished(this, new FinishedArgs(true));
        }

        private void NodeRefreshRecursive(TreeNode treeNode)
        {
            bool anyModified = false;
            foreach (TreeNode node in treeNode.Nodes)
            {
                NodeRefreshRecursive(node);
                FileNode fNode = (FileNode)node.Tag;
                if (fNode == null) continue;
                if (fNode.Modified) anyModified = true;
            }

            bool modified = false;
            if (treeNode.Tag != null && treeNode.Tag.GetType() != typeof(CacheFile))
            {
                FileNode fileNode = (FileNode)treeNode.Tag;
                fileNode.CalcChecksum();
                modified = fileNode.Modified;
            }

            if (anyModified || modified)
            {
                treeNode.BackColor = Color.FromArgb(160, 196, 255);
            }
            else
            {
                treeNode.BackColor = Color.FromArgb(255, 255, 255);
            }
        }

        public void Abort()
        {
            
        }
    }
}
