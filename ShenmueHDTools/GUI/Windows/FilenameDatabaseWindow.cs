using ShenmueHDTools.Main.Database;
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
using System.Runtime.Serialization.Formatters.Binary;
using ShenmueHDTools.Main;

namespace ShenmueHDTools.GUI.Windows
{
    public partial class FilenameDatabaseWindow : Form, IProgressable
    {
        public bool IsAbortable { get { return false; } }

        public FilenameDatabaseWindow()
        {
            InitializeComponent();
            filenameDatabaseDataTable1.UpdateView(false);
        }

        public event FinishedEventHandler Finished;
        public event Main.ProgressChangedEventHandler ProgressChanged;
        public event DescriptionChangedEventHandler DescriptionChanged;
        public event Main.ErrorEventHandler Error;

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

                FilenameDatabase.Save();
                filenameDatabaseDataTable1.UpdateView(false);
            }
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Filename Database Dump (*.bin)|*.bin";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilenameDatabase.Load(openFileDialog.FileName);
                filenameDatabaseDataTable1.UpdateView(false);
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

        private void button_Clear_Click(object sender, EventArgs e)
        {
            FilenameDatabase.Clear();
            filenameDatabaseDataTable1.UpdateView(false);
        }

        private void Merge(List<FilenameDatabaseEntry> entries)
        {
            DescriptionChanged(this, new DescriptionChangedArgs("Merging file with database..."));
            for (int i = 0; i < entries.Count; i++)
            {
                ProgressChanged(this, new ProgressChangedArgs(i, entries.Count));
                FilenameDatabaseEntry entry = entries[i];
                FilenameDatabase.Add(entry);
            }
            Finished(this, new FinishedArgs(true));
        }

        private void button_Merge_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Filename Database Dump (*.bin)|*.bin";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!Helper.IsFileValid(openFileDialog.FileName)) return;

                List<FilenameDatabaseEntry> newEntries;
                using (FileStream stream = File.Open(openFileDialog.FileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    newEntries = (List<FilenameDatabaseEntry>)formatter.Deserialize(stream);
                }

                LoadingDialog loadingDialog = new LoadingDialog();
                loadingDialog.SetData(this);
                Thread thread = new Thread(delegate () {
                    Merge(newEntries);
                });
                loadingDialog.ShowDialog(thread);
            }
            FilenameDatabase.Save();
            filenameDatabaseDataTable1.UpdateView(false);
        }

        public void Abort()
        {
            throw new NotImplementedException();
        }
    }
}
