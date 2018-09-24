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

        private CacheFile m_cacheFile;

        public FileTreeView()
        {
            InitializeComponent();
        }

        public void SetCache(CacheFile cacheFile)
        {
            m_cacheFile = cacheFile;
            treeView_Files.Nodes.Clear();

            TreeNode rootNode = new TreeNode(cacheFile.Header.RelativeTACPath.Substring(1));
            rootNode.Tag = cacheFile;

            foreach (FileNode node in m_cacheFile.Files)
            {
                node.CreateTreeNode(rootNode, FileNode.TreeType.FilePath);
            }

            treeView_Files.Nodes.Add(rootNode);
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
    }
}
