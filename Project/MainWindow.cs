﻿using Shenmue_HD_Tools;
using ShenmueHDTools.GUI.Windows;
using ShenmueHDTools.Main.Database;
using ShenmueHDTools.Main.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShenmueHDTools.GUI.Dialogs;
using System.Runtime.Serialization.Formatters.Binary;
using ShenmueHDTools.Main.DataStructure;
using ShenmueHDTools.Main;
using System.Threading;

namespace ShenmueHDTools
{
    public partial class MainWindow : Form
    {
        private TADFile m_tadFile;
        private CacheFile m_cacheFile;

        public MainWindow()
        {
            InitializeComponent();
            Text = Version.ApplicationTitle;

            FilenameDatabase.Load();
            WulinshuRaymonfAPI.Read();
            DescriptionDatabase.GenerateDatabase();

            Helper.CheckUpdates();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archive Dictonary file (*.tad)|*.tad";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_tadFile = new TADFile(openFileDialog.FileName);
                FilenameDatabase.MapFilenamesToTAD(m_tadFile);
                DescriptionDatabase.MapDescriptionToTAD(m_tadFile);

                if (System.Diagnostics.Debugger.IsAttached)
                {
                    if (MessageBox.Show("Do you want to unpack the TAC file?", "Unpack TAC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        tadDataTable1.SetTAD(m_tadFile);
                        return;
                    }
                }

                m_cacheFile = new CacheFile(m_tadFile);
                m_cacheFile.Unpack();
                tadDataTable1.SetCache(m_cacheFile);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_cacheFile == null) return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archive Dictonary file (*.tad)|*.tad";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string tadPath = saveFileDialog.FileName;
                m_cacheFile.Export(tadPath);

                m_tadFile = new TADFile(tadPath);
                FilenameDatabase.MapFilenamesToTAD(m_tadFile);
                DescriptionDatabase.MapDescriptionToTAD(m_tadFile);

                if (System.Diagnostics.Debugger.IsAttached)
                {
                    if (MessageBox.Show("Do you want to unpack the TAC file?", "Unpack TAC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        tadDataTable1.SetTAD(m_tadFile);
                    }
                }

                m_cacheFile = new CacheFile(m_tadFile);
                m_cacheFile.Unpack();
                tadDataTable1.SetCache(m_cacheFile);
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
            if (m_cacheFile == null || m_tadFile == null) return;

            FilenameDatabase filenameDB = new FilenameDatabase();
            LoadingDialog loadingDialog = new LoadingDialog();
            loadingDialog.SetData(filenameDB);
            Thread thread = new Thread(delegate ()
            {
                filenameDB.MapFilenamesToTADInstance(m_cacheFile);
            });
            loadingDialog.ShowDialog(thread);

            DescriptionDatabase descDB = new DescriptionDatabase();
            loadingDialog = new LoadingDialog();
            loadingDialog.SetData(descDB);
            thread = new Thread(delegate ()
            {
                descDB.MapDescriptionToTADInstance(m_tadFile);
            });
            loadingDialog.ShowDialog(thread);

            tadDataTable1.SetCache(m_cacheFile);
            m_cacheFile.Write(m_cacheFile.Filename);
        }

        private void packAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_cacheFile == null) return;
            m_cacheFile.Pack();
        }

        private void unpackAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_cacheFile == null) return;
            m_cacheFile.Unpack();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Cache file (*.cache, *.shdcache)|*.cache;*.shdcache";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_cacheFile = new CacheFile();
                if (Path.GetExtension(openFileDialog.FileName) == ".shdcache")
                {
                    m_cacheFile.ConvertLegacy(openFileDialog.FileName);
                }
                else
                {
                    m_cacheFile.Read(openFileDialog.FileName);
                }
                m_tadFile = m_cacheFile.TADFile;
                tadDataTable1.SetCache(m_cacheFile);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog AboutWindow = new AboutDialog();
            AboutWindow.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_cacheFile == null) return;
            m_cacheFile.Write(m_cacheFile.Filename);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_cacheFile == null) return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Cache file (*.cache)|*.cache";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_cacheFile.Write(saveFileDialog.FileName);
            }
        }
    }
}
