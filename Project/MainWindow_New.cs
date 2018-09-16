using ShenmueHDTools.GUI.Windows;
using ShenmueHDTools.Main.Database;
using ShenmueHDTools.Main.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShenmueHDTools
{
    public partial class MainWindow_New : Form
    {
        private TADFile m_tadFile;
        private CacheFile m_cacheFile;

        public MainWindow_New()
        {
            InitializeComponent();

            string executable = System.Reflection.Assembly.GetEntryAssembly().Location;
            string databasePath = Path.GetDirectoryName(executable) + "\\database.bin";
            if (File.Exists(databasePath))
            {
                FilenameDatabase.Load(databasePath);
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archive Dictonary file (*.tad)|*.tad";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_tadFile = new TADFile(openFileDialog.FileName);
                FilenameDatabase.MapFilenamesToTAD(m_tadFile);

                if (MessageBox.Show("Do you want to unpack the TAC file?", "Unpack TAC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    m_cacheFile = new CacheFile(m_tadFile);
                    m_cacheFile.Unpack();
                    tadDataTable1.SetCache(m_cacheFile);
                }
                else
                {
                    tadDataTable1.SetTAD(m_tadFile);
                }
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archive Dictonary file (*.tad)|*.tad";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string tadPath = saveFileDialog.FileName;
                m_cacheFile.Export(tadPath);

                m_tadFile = new TADFile(tadPath);
                FilenameDatabase.MapFilenamesToTAD(m_tadFile);

                if (MessageBox.Show("Do you want to unpack the TAC file?", "Unpack TAC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    m_cacheFile = new CacheFile(m_tadFile);
                    m_cacheFile.Unpack();
                    tadDataTable1.SetCache(m_cacheFile);
                }
                else
                {
                    tadDataTable1.SetTAD(m_tadFile);
                }
            }
        }

        private void filenameDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilenameDatabaseWindow window = new FilenameDatabaseWindow();
            window.ShowDialog();
        }

        private void wulinshuRaymonfDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RaymonfDatabaseWindow window = new RaymonfDatabaseWindow();
            window.ShowDialog();
        }

        private void mapFilenamesToTADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_tadFile == null) return;
            FilenameDatabase.MapFilenamesToTAD(m_tadFile);
            tadDataTable1.SetTAD(m_tadFile);
        }
    }
}
