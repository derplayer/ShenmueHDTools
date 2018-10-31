using ShenmueHDTools.Main.Files.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShenmueHDTools.GUI.Controls.FileExplorer.Files
{
    public interface IFileControl
    {
        void SetFile(FileNode fileNode);
    }

}
