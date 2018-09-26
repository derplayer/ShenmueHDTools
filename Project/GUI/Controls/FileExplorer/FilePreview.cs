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

        public FilePreview()
        {
            InitializeComponent();
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
        }

        public void SetFile(FileNode fileNode)
        {
            m_fileNode = fileNode;
            fileInformation.SetFile(m_fileNode);

            if(fileNode.Type == FileNode.FileType.DDS)
            {
                ddsControl1.SetFile(fileNode);
                tabControl1.SelectTab(fileNode.Type.ToString());
            }
            else
            {
                tabControl1.SelectTab(tabPage_UNKNOWN);
            }

        }
    }
}
