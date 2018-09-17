using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShenmueHDTools.Main.Database;
using ShenmueHDTools.Main;

namespace ShenmueHDTools.GUI.Controls
{
    public partial class WulinshuRaymonfDataTable : UserControl
    {
        public WulinshuRaymonfDataTable()
        {
            InitializeComponent();
            dataGridView_Entries = Helper.DoubleBuffered(this.dataGridView_Entries, true);
            dataGridView_Entries.AutoGenerateColumns = false;
        }

        public void SetData(List<WulinshuRaymonfAPIEntry> entries)
        {
            dataGridView_Entries.DataSource = null;
            dataGridView_Entries.DataSource = entries;
            dataGridView_Entries.Refresh();
        }
    }
}
