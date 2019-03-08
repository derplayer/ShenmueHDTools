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
using System.Threading;
using ShenmueHDArchiver.Dialogs;
using ShenmueDKSharp.Utils;

namespace ShenmueHDArchiver.Controls
{
    public partial class TADControl : UserControl
    {
        public TADControl()
        {
            InitializeComponent();
            comboBox_ModelType.SelectedIndex = 0;
        }

        private void textBox_Filepath_TextChanged(object sender, EventArgs e)
        {
            if (listBox_ArchiveFiles.SelectedIndex >= listBox_ArchiveFiles.Items.Count || listBox_ArchiveFiles.SelectedIndex < 0) return;
            TADEntry entry = (TADEntry)listBox_ArchiveFiles.Items[listBox_ArchiveFiles.SelectedIndex];
            entry.FileName = textBox_Filepath.Text;
            entry.CalculateFilenameHashes(checkBox_SingleHash.Checked);
            textBox_Hash1.Text = String.Format("{0:X8}", entry.FirstHash);
            textBox_Hash2.Text = String.Format("{0:X8}", entry.SecondHash);
        }

        private void listBox_ArchiveFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                List<TADEntry> toDelete = new List<TADEntry>();
                foreach (TADEntry entry in listBox_ArchiveFiles.SelectedItems)
                {
                    toDelete.Add(entry);
                }
                foreach (TADEntry entry in toDelete)
                {
                    listBox_ArchiveFiles.Items.Remove(entry);
                }
            }
        }

        private void listBox_ArchiveFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_ArchiveFiles.SelectedIndex >= listBox_ArchiveFiles.Items.Count || listBox_ArchiveFiles.SelectedIndex < 0) return;
            TADEntry entry = (TADEntry)listBox_ArchiveFiles.Items[listBox_ArchiveFiles.SelectedIndex];
            textBox_Filepath.Text = entry.FileName;
            textBox_Hash1.Text = String.Format("{0:X8}", entry.FirstHash);
            textBox_Hash2.Text = String.Format("{0:X8}", entry.SecondHash);
        }

        private void listBox_ArchiveFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                FileInfo fileInfo = new FileInfo(file);
                TADEntry entry = new TADEntry();
                entry.FilePath = file;
                entry.FileName = file;
                entry.FileSize = (uint)fileInfo.Length;
                entry.Index = (uint)i;
                listBox_ArchiveFiles.Items.Add(entry);
            }
        }

        private void listBox_ArchiveFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void button_CreateTAD_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TAD File (*.tad)|*.tad";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string tadFilepath = saveFileDialog.FileName;
                string tacFilepath = Path.ChangeExtension(tadFilepath, ".tac");

                TAD tad = new TAD();
                tad.FilePath = tadFilepath;
                foreach (TADEntry entry in listBox_ArchiveFiles.Items)
                {
                    tad.Entries.Add(entry);
                }
                TAC tac = new TAC();
                tac.TAD = tad;

                LoadingDialog loadingDialog = new LoadingDialog();
                loadingDialog.SetProgessable(tac);
                Thread thread = new Thread(delegate () {
                    tac.Pack(tacFilepath);
                });
                loadingDialog.ShowDialog(thread);
                
                tad.UnixTimestamp = dateTimePicker_TAD.Value;
                tad.Write(tadFilepath);
            }
        }

        private void button_ExtractTAD_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog folderDialog = new VistaFolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (TAD tad in listBox_ExtractFiles.Items)
                {
                    string folder = folderDialog.SelectedPath + "\\_" + Path.ChangeExtension(tad.FileName, ".tac") + "_\\";
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    TAC tac = new TAC(tad);

                    LoadingDialog loadingDialog = new LoadingDialog();
                    loadingDialog.SetProgessable(tac);
                    Thread thread = new Thread(delegate () {
                        tac.Unpack(false, false, folder);
                    });
                    loadingDialog.ShowDialog(thread);
                }
            }
        }

        private void listBox_ExtractFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (Path.GetExtension(file).ToUpper() != ".TAD") continue;
                TAD entry = new TAD(file);
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
                List<TAD> toDelete = new List<TAD>();
                foreach (TAD entry in listBox_ExtractFiles.SelectedItems)
                {
                    toDelete.Add(entry);
                }
                foreach (TAD entry in toDelete)
                {
                    listBox_ExtractFiles.Items.Remove(entry);
                }
            }
        }

        private void checkBox_DumpModels_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DumpModels.Checked)
            {
                groupBox_ModelDump.Enabled = true;
            }
            else
            {
                groupBox_ModelDump.Enabled = false;
            }
        }

        private void button_BrowseModelFolder_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog folderDialog = new VistaFolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_ModelFolder.Text = folderDialog.SelectedPath;
            }
        }

        private void textBox_MurmurHash_TextChanged(object sender, EventArgs e)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(textBox_MurmurHash.Text);
            textBox_MurmurHash2.Text = String.Format("{0:X8}", MurmurHash2.Hash(buffer, (uint)buffer.Length));
        }
    }
}
