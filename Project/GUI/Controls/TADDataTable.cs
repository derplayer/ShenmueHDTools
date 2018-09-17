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
    public partial class TADDataTable : UserControl, IProgressable
    {
        private TADFile m_tadFile;
        private CacheFile m_cacheFile;
        private ObservableCollection<TADFileEntry> m_entriesView = new ObservableCollection<TADFileEntry>();
        private readonly string StatisticFormat = "File coverage: {0}/{1} ({2}%)";
        private Thread m_thread;

        public event FinishedEventHandler Finished;
        public event Main.ProgressChangedEventHandler ProgressChanged;
        public event DescriptionChangedEventHandler DescriptionChanged;
        public event Main.ErrorEventHandler Error;

        public TADDataTable()
        {
            InitializeComponent();

            dataGridView_TAD = Helper.DoubleBuffered(this.dataGridView_TAD, true);
            dataGridView_TAD.AutoGenerateColumns = false;
            dataGridView_TAD.RowHeadersWidth = 15;
            dataGridView_TAD.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        public void SetTAD(TADFile tadFile)
        {
            button_Refresh.Enabled = false;
            m_tadFile = tadFile;
            TADStatistic statistic = m_tadFile.GetStatistic();
            label_Statistic.Text = String.Format(StatisticFormat, statistic.FilesCovered, statistic.FileCount, statistic.FileCoverage);
            UpdateView();
        }

        public void SetCache(CacheFile cacheFile)
        {
            button_Refresh.Enabled = true;
            m_cacheFile = cacheFile;
            m_tadFile = m_cacheFile.TADFile;
            TADStatistic statistic = m_tadFile.GetStatistic();
            label_Statistic.Text = String.Format(StatisticFormat, statistic.FilesCovered, statistic.FileCount, statistic.FileCoverage);
            UpdateView();
        }

        public void UpdateView()
        {
            Invoke((MethodInvoker)delegate {
                dataGridView_TAD.DataSource = null;
                m_entriesView.Clear();
                foreach (TADFileEntry entry in m_tadFile.FileEntries)
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

        private void RefreshModified()
        {
            DescriptionChanged(this, new DescriptionChangedArgs("Calculating hashes..."));
            string outputFolder = Path.GetDirectoryName(m_cacheFile.Filename) + m_cacheFile.Header.RelativeOutputFolder;
            for (int i = 0; i < m_tadFile.FileEntries.Count; i++)
            {
                ProgressChanged(this, new ProgressChangedArgs(i, m_tadFile.FileEntries.Count));
                TADFileEntry entry = m_tadFile.FileEntries[i];
                entry.CheckMD5(outputFolder + "\\" + entry.RelativePath);
            }
            UpdateView();
            Finished(this, new FinishedArgs(true));
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {

            LoadingDialog loadingDialog = new LoadingDialog();
            loadingDialog.SetData(this);
            Thread thread = new Thread(delegate ()
            {
                RefreshModified();
            });
            loadingDialog.ShowDialog(thread);
        }

        public void Abort()
        {
            //throw new NotImplementedException();
        }
    }
}
