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
        }

        public void SetFile(FileNode fileNode)
        {
            m_fileNode = fileNode;
            fileInformation.SetFile(m_fileNode);
        }
    }
}
