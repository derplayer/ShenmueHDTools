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
    public partial class FileInformation : UserControl
    {
        FileNode m_fileNode;

        public FileInformation()
        {
            InitializeComponent();
        }

        public void SetFile(FileNode fileNode)
        {
            m_fileNode = fileNode;
            textBox_Type.DataBindings.Clear();
            textBox_RelativPath.DataBindings.Clear();
            textBox_Checksum.DataBindings.Clear();
            textBox_Description.DataBindings.Clear();
            comboBox_Category.DataBindings.Clear();
            comboBox_Location.DataBindings.Clear();
            richTextBox_Notes.DataBindings.Clear();
            if (fileNode == null) return;
            textBox_Description.DataBindings.Add("Text", fileNode, "Description");
            comboBox_Category.DataBindings.Add("Text", fileNode, "Category");
            comboBox_Location.DataBindings.Add("Text", fileNode, "Location");
            textBox_Checksum.DataBindings.Add("Text", fileNode, "ChecksumString");
            textBox_Type.DataBindings.Add("Text", fileNode, "TypeString");
            textBox_RelativPath.DataBindings.Add("Text", fileNode, "RelativPath");
            richTextBox_Notes.DataBindings.Add("Text", fileNode, "Notes");
        }
    }
}
