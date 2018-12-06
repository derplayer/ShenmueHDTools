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

namespace ShenmueHDTools.GUI.Controls
{
    public partial class FilePreview : UserControl
    {
        FileNode m_fileNode;
        List<string> m_pages = new List<string>();

        public FilePreview()
        {
            InitializeComponent();
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            foreach(TabPage page in tabControl1.TabPages)
            {
                m_pages.Add(page.Text);
            }
        }

        public void SetFile(FileNode fileNode)
        {
            m_fileNode = fileNode;
            fileInformation.SetFile(m_fileNode);
            if (fileNode == null) return;
            if(fileNode.Type == FileNode.FileType.DDS)
            {
                DDS.SetFile(fileNode);
                string tabName = Enum.GetName(typeof(FileNode.FileType), fileNode.Type);
                tabControl1.SelectTab(m_pages.IndexOf(tabName));
            }
            else if(fileNode.Type == FileNode.FileType.PVR)
            {
                PVR.SetFile(fileNode);
                string tabName = Enum.GetName(typeof(FileNode.FileType), fileNode.Type);
                tabControl1.SelectTab(m_pages.IndexOf(tabName));
            }
            else if (fileNode.Type == FileNode.FileType.MT5)
            {
                string tabName = Enum.GetName(typeof(FileNode.FileType), fileNode.Type);
                tabControl1.SelectTab(m_pages.IndexOf(tabName));
                MT5.SetFile(fileNode);
            }
            else if (fileNode.Type == FileNode.FileType.MT7)
            {
                string tabName = Enum.GetName(typeof(FileNode.FileType), fileNode.Type);
                tabControl1.SelectTab(m_pages.IndexOf(tabName));
                MT7.SetFile(fileNode);
            }
            else
            {
                tabControl1.SelectTab(UNKNOWN);
            }

        }
    }
}
