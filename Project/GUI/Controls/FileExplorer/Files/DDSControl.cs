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

namespace ShenmueHDTools.GUI.Controls.FileExplorer.Files
{
    public partial class DDSControl : UserControl, IFileControl
    {
        private FileNode m_file;

        public DDSControl()
        {
            InitializeComponent();
        }

        public void SetFile(FileNode file)
        {
            m_file = file;
            pictureBox_Preview.Image = ((IImageNode)file).GetImage();
        }
    }
}
