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
using System.Reflection;
using System.Collections.ObjectModel;
using ShenmueHDTools.Main.Database;
using ShenmueHDTools.Main;

namespace ShenmueHDTools.GUI.Controls
{
    public partial class FilenameDatabaseDataTable : UserControl
    {
        private ObservableCollection<FilenameDatabaseEntry> m_entriesView = new ObservableCollection<FilenameDatabaseEntry>();
        private readonly Timer m_timer;

        public FilenameDatabaseDataTable()
        {
            InitializeComponent();
            dataGridView_DB = Helper.DoubleBuffered(this.dataGridView_DB, true);
            dataGridView_DB.AutoGenerateColumns = false;
            dataGridView_DB.RowHeadersWidth = 15;
            dataGridView_DB.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            m_timer = new Timer();
            m_timer.Interval = 200;
            m_timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            m_timer.Stop();
            UpdateView();
        }

        public void UpdateView()
        {
            dataGridView_DB.DataSource = null;
            m_entriesView.Clear();
            foreach (FilenameDatabaseEntry entry in FilenameDatabase.Entries)
            {
                if (entry == null) return;
                if (entry.Hash1.Contains(textBox_Filter.Text.ToUpper()) ||
                    entry.Filename.ToLower().Contains(textBox_Filter.Text.ToLower()) ||
                    entry.FileSize.ToString().Contains(textBox_Filter.Text) ||
                    entry.Hash2.Contains(textBox_Filter.Text.ToUpper()) ||
                    entry.Hash3.Contains(textBox_Filter.Text.ToUpper()))
                {
                    m_entriesView.Add(entry);
                }
            }
            dataGridView_DB.DataSource = m_entriesView;
            label_Count.Text = "Entries: " + m_entriesView.Count.ToString();
        }

        private void textBox_Filter_TextChanged(object sender, EventArgs e)
        {
            m_timer.Stop();
            m_timer.Start();
        }
    }
}
