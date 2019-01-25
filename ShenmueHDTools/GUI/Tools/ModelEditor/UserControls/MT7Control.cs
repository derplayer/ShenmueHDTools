using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShenmueDKSharp.Files.Models;

namespace ShenmueHDTools.GUI.Tools.ModelEditor.UserControls
{
    public partial class MT7Control : UserControl
    {
        private MT7Node m_node;

        public MT7Control()
        {
            InitializeComponent();
        }

        public void SetMT7Node(MT7Node node)
        {
            m_node = node;
        }
    }
}
