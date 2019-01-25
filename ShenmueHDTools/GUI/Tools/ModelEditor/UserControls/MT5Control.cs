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
    public partial class MT5Control : UserControl
    {
        private MT5Node m_node;

        public MT5Control()
        {
            InitializeComponent();
        }

        public void SetMT5Node(MT5Node node)
        {
            m_node = node;
        }
    }
}
