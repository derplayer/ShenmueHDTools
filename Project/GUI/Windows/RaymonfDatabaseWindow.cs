using ShenmueHDTools.Main.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShenmueHDTools.GUI.Windows
{
    public partial class RaymonfDatabaseWindow : Form
    {
        public RaymonfDatabaseWindow()
        {
            InitializeComponent();
            wulinshuRaymonfDataTable1.SetData(WulinshuRaymonfAPI.Entries);
        }

        private void button_Fetch_Click(object sender, EventArgs e)
        {
            WulinshuRaymonfAPI.FetchData("sm1");
            wulinshuRaymonfDataTable1.SetData(WulinshuRaymonfAPI.Entries);
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Wulinshu Raymonf Dump (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                WulinshuRaymonfAPI.Write(saveFileDialog.FileName);
            }
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Wulinshu Raymonf Dump (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                WulinshuRaymonfAPI.Read(openFileDialog.FileName);
                wulinshuRaymonfDataTable1.SetData(WulinshuRaymonfAPI.Entries);
            }
        }

        private void button_Merge_Click(object sender, EventArgs e)
        {
            foreach (WulinshuRaymonfAPIEntry entry in WulinshuRaymonfAPI.Entries)
            {
                FilenameDatabase.Add(entry.CreateDatabaseEntry());
            }
        }
    }
}
