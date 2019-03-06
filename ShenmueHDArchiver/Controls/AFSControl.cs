using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShenmueDKSharp.Files.Containers;
using System.IO;
using Ookii.Dialogs;

namespace ShenmueHDArchiver.Controls
{
    public partial class AFSControl : UserControl
    {
        public AFSControl()
        {
            InitializeComponent();
        }

        private void listBox_ExtractFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                if (Path.GetExtension(file).ToUpper() != ".AFS") continue;
                AFS entry = new AFS();
                entry.FilePath = file;
                listBox_ExtractFiles.Items.Add(entry);
            }
        }

        private void listBox_ExtractFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void listBox_ExtractFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                List<AFS> toDelete = new List<AFS>();
                foreach (AFS entry in listBox_ExtractFiles.SelectedItems)
                {
                    toDelete.Add(entry);
                }
                foreach (AFS entry in toDelete)
                {
                    listBox_ExtractFiles.Items.Remove(entry);
                }
            }
        }

        private void listBox_ArchiveFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                FileInfo fileInfo = new FileInfo(file);
                AFSEntry entry = new AFSEntry();
                entry.Filename = Path.GetFileNameWithoutExtension(file).ToUpper();
                using (FileStream stream = new FileStream(file, FileMode.Open))
                {
                    entry.FileSize = (uint)stream.Length;
                    entry.Buffer = new byte[stream.Length];
                    entry.EntryDateTime = fileInfo.LastWriteTime;
                    stream.Read(entry.Buffer, 0, entry.Buffer.Length);
                }
                listBox_ArchiveFiles.Items.Add(entry);
            }
        }

        private void listBox_ArchiveFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void listBox_ArchiveFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                List<AFSEntry> toDelete = new List<AFSEntry>();
                foreach (AFSEntry entry in listBox_ExtractFiles.SelectedItems)
                {
                    toDelete.Add(entry);
                }
                foreach (AFSEntry entry in toDelete)
                {
                    listBox_ExtractFiles.Items.Remove(entry);
                }
            }
        }

        private void button_ExtractAFS_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog folderDialog = new VistaFolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (AFS afs in listBox_ExtractFiles.Items)
                {
                    string folder = folderDialog.SelectedPath + "\\_" + afs.FileName + "_\\";
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    afs.Read(afs.FilePath);
                    afs.Unpack(folder);
                }
            }
        }

        private void button_CreateAFS_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "AFS File (*.afs)|*.afs";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                AFS afs = new AFS();
                afs.SectorSize = (uint)numericUpDown_SectorSize.Value;
                foreach (AFSEntry entry in listBox_ArchiveFiles.Items)
                {
                    afs.Entries.Add(entry);
                }
                afs.FilePath = saveFileDialog.FileName;
                afs.Write(saveFileDialog.FileName);
            }
        }

        private void listBox_ArchiveFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_ArchiveFiles.SelectedIndex >= listBox_ArchiveFiles.Items.Count || listBox_ArchiveFiles.SelectedIndex < 0) return;
            AFSEntry entry = (AFSEntry)listBox_ArchiveFiles.Items[listBox_ArchiveFiles.SelectedIndex];
            textBox_FileName.Text = entry.Filename;
            dateTimePicker_FileDate.Value = entry.EntryDateTime;
        }

        private void textBox_FileName_TextChanged(object sender, EventArgs e)
        {
            if (listBox_ArchiveFiles.SelectedIndex >= listBox_ArchiveFiles.Items.Count || listBox_ArchiveFiles.SelectedIndex < 0) return;
            AFSEntry entry = (AFSEntry)listBox_ArchiveFiles.Items[listBox_ArchiveFiles.SelectedIndex];
            entry.Filename = textBox_FileName.Text;
        }

        private void dateTimePicker_FileDate_ValueChanged(object sender, EventArgs e)
        {
            if (listBox_ArchiveFiles.SelectedIndex >= listBox_ArchiveFiles.Items.Count || listBox_ArchiveFiles.SelectedIndex < 0) return;
            AFSEntry entry = (AFSEntry)listBox_ArchiveFiles.Items[listBox_ArchiveFiles.SelectedIndex];
            entry.EntryDateTime = dateTimePicker_FileDate.Value;
        }
    }
}
