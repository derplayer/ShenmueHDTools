﻿using ShenmueHDTools.Main.Database;
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

using Ookii.Dialogs;
using System.Threading;
using ShenmueHDTools.GUI.Dialogs;

namespace ShenmueHDTools.GUI.Windows
{
    public partial class FilenameDatabaseWindow : Form
    {
        public FilenameDatabaseWindow()
        {
            InitializeComponent();
            filenameDatabaseDataTable1.UpdateView();
        }

        private void button_Generate_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog folderDialog = new VistaFolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                FilenameCrawler crawler = new FilenameCrawler();
                LoadingDialog loadingDialog = new LoadingDialog();
                loadingDialog.SetData(crawler);
                Thread thread = new Thread(delegate () {
                    crawler.GenerateFilenameDatabase(folderDialog.SelectedPath);
                });
                loadingDialog.ShowDialog(thread);

                string executable = System.Reflection.Assembly.GetEntryAssembly().Location;
                string databasePath = Path.GetDirectoryName(executable) + "\\database.bin";
                FilenameDatabase.Save(databasePath);

                filenameDatabaseDataTable1.UpdateView();
            }
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Filename Database Dump (*.bin)|*.bin";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilenameDatabase.Load(openFileDialog.FileName);
                filenameDatabaseDataTable1.UpdateView();
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Filename Database Dump (*.bin)|*.bin";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilenameDatabase.Save(saveFileDialog.FileName);
            }
        }
    }
}
