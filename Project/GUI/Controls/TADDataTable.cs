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
using System.IO;
using System.Diagnostics;
using System.Threading;
using ShenmueHDTools.GUI.Dialogs;
using ShenmueHDTools.Main;

namespace ShenmueHDTools.GUI.Controls
{
    public partial class TADDataTable : UserControl
    {
        private TADFile m_tadFile;
        private CacheFile m_cacheFile;
        private List<TADFileEntry> m_sortedEntries = new List<TADFileEntry>();
        private ObservableCollection<TADFileEntry> m_entriesView = new ObservableCollection<TADFileEntry>();
        private readonly string StatisticFormat = "File coverage: {0}/{1} ({2}%)";
        private int m_lastColumn;
        private bool m_suspendSpacebar = false;

        public bool IsAbortable { get { return false; } }

        public TADDataTable()
        {
            InitializeComponent();

            dataGridView_TAD.AutoGenerateColumns = false;
            dataGridView_TAD.RowHeadersWidth = 15;
            dataGridView_TAD.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        public void SetTAD(TADFile tadFile)
        {
            button_Refresh.Enabled = false;
            m_tadFile = tadFile;
            m_cacheFile = null;
            TADStatistic statistic = m_tadFile.GetStatistic();
            label_Statistic.Text = String.Format(StatisticFormat, statistic.FilesCovered, statistic.FileCount, statistic.FileCoverage);
            m_sortedEntries = tadFile.FileEntries;
            UpdateView();
        }

        public void SetCache(CacheFile cacheFile)
        {
            button_Refresh.Enabled = true;
            m_cacheFile = cacheFile;
            m_tadFile = m_cacheFile.TADFile;
            if (m_tadFile == null)
            {
                m_sortedEntries = new List<TADFileEntry>();
                UpdateView();
                return;
            }
            TADStatistic statistic = m_tadFile.GetStatistic();
            label_Statistic.Text = String.Format(StatisticFormat, statistic.FilesCovered, statistic.FileCount, statistic.FileCoverage);
            m_sortedEntries = m_tadFile.FileEntries;
            UpdateView();
        }

        public void UpdateView()
        {
            Invoke((MethodInvoker)delegate {
                dataGridView_TAD.DataSource = null;
                m_entriesView.Clear();
                foreach (TADFileEntry entry in m_sortedEntries)
                {
                    if (entry.RelativePath.ToLower().Contains(textBox_Filter.Text.ToLower()) ||
                        entry.Hash1.Contains(textBox_Filter.Text.ToUpper()) ||
                        entry.Filename.ToLower().Contains(textBox_Filter.Text.ToLower()) ||
                        entry.FileOffset.ToString().Contains(textBox_Filter.Text) ||
                        entry.FileSize.ToString().Contains(textBox_Filter.Text) ||
                        entry.Hash2.Contains(textBox_Filter.Text.ToUpper()) ||
                        entry.Hash3.Contains(textBox_Filter.Text.ToUpper()))
                    {
                        m_entriesView.Add(entry);
                    }
                }
                dataGridView_TAD.DataSource = m_entriesView;
                label_Count.Text = "Entries: " + m_entriesView.Count.ToString();
            });
        }

        private void textBox_Filter_TextChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void dataGridView_TAD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (m_suspendSpacebar) return;
                if (dataGridView_TAD.SelectedRows.Count < 1) return;
                bool firstSelectedEntryValue = m_entriesView[dataGridView_TAD.SelectedRows[0].Index].Export;
                for (int i = 0; i < dataGridView_TAD.SelectedRows.Count; i++)
                {
                    TADFileEntry entry = m_entriesView[dataGridView_TAD.SelectedRows[i].Index];
                    entry.Export = !firstSelectedEntryValue;
                }
                dataGridView_TAD.Refresh();
            }
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            if (m_cacheFile == null) return;
            LoadingDialog loadingDialog = new LoadingDialog();
            loadingDialog.SetData(m_cacheFile);
            Thread thread = new Thread(delegate ()
            {
                m_cacheFile.CalculateHashes();
                UpdateView();
            });
            loadingDialog.ShowDialog(thread);
        }

        public void Abort()
        {
            //throw new NotImplementedException();
        }

        private void dataGridView_TAD_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (m_tadFile == null) return;
            string dataPropertyName = dataGridView_TAD.Columns[e.ColumnIndex].DataPropertyName;
            PropertyInfo[] properties = typeof(TADFileEntry).GetProperties();
            PropertyInfo property = properties.First(p => p.Name == dataPropertyName);
            if (property == null) return;

            if (m_lastColumn == e.ColumnIndex)
            {
                m_sortedEntries = m_tadFile.FileEntries.OrderByDescending(f => property.GetGetMethod().Invoke(f, new object[0])).ToList();
                m_lastColumn = -1;
            }
            else
            {
                m_sortedEntries = m_tadFile.FileEntries.OrderBy(f => property.GetGetMethod().Invoke(f, new object[0])).ToList();
                m_lastColumn = e.ColumnIndex;
            }
            UpdateView();
        }

        private void dataGridView_TAD_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            m_suspendSpacebar = false;
        }

        private void dataGridView_TAD_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            m_suspendSpacebar = true;
        }

        private void dataGridView_TAD_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            if (e.Button != MouseButtons.Right) return;

            this.dataGridView_TAD.CurrentCell = this.dataGridView_TAD.Rows[e.RowIndex].Cells[e.ColumnIndex];
            TADFileEntry entry = m_entriesView[e.RowIndex];
            string filename = Path.GetDirectoryName(m_cacheFile.Filename) + m_cacheFile.Header.RelativeOutputFolder + "\\" + entry.RelativePath;

            ShellContextMenu ctxMnu = new ShellContextMenu();
            FileInfo[] arrFI = new FileInfo[1];
            arrFI[0] = new FileInfo(filename);
            ctxMnu.ShowContextMenu(arrFI, Cursor.Position);
        }
    }
}
