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

namespace ShenmueHDTools.GUI.Controls
{
    public partial class TADDataTable : UserControl
    {
        private TADFile m_tadFile;

        public TADDataTable()
        {
            InitializeComponent();
            dataGridView_TAD.AutoGenerateColumns = false;
        }

        public void SetTAD(TADFile tadFile)
        {
            m_tadFile = tadFile;
            dataGridView_TAD.DataSource = m_tadFile.FileEntries;
        }
    }
}
