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
        private List<FilenameDatabaseEntry> m_sortedEntries = new List<FilenameDatabaseEntry>();
        private ObservableCollection<FilenameDatabaseEntry> m_entriesView = new ObservableCollection<FilenameDatabaseEntry>();
        private readonly Timer m_timer;
        private int m_lastColumn;

        public FilenameDatabaseDataTable()
        {
            InitializeComponent();
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

        public void UpdateView(bool keepSorted = true)
        {
            if (!keepSorted)
            {
                m_sortedEntries = FilenameDatabase.Entries;
            }
            dataGridView_DB.DataSource = null;
            m_entriesView.Clear();
            foreach (FilenameDatabaseEntry entry in m_sortedEntries)
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

        private void dataGridView_DB_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string dataPropertyName = dataGridView_DB.Columns[e.ColumnIndex].DataPropertyName;
            PropertyInfo[] properties = typeof(FilenameDatabaseEntry).GetProperties();
            PropertyInfo property = properties.First(p => p.Name == dataPropertyName);
            if (property == null) return;

            if (m_lastColumn == e.ColumnIndex)
            {
                m_sortedEntries = FilenameDatabase.Entries.OrderByDescending(f => property.GetGetMethod().Invoke(f, new object[0])).ToList();
                m_lastColumn = -1;
            }
            else
            {
                m_sortedEntries = FilenameDatabase.Entries.OrderBy(f => property.GetGetMethod().Invoke(f, new object[0])).ToList();
                m_lastColumn = e.ColumnIndex;
            }
            UpdateView();
        }
    }
}
