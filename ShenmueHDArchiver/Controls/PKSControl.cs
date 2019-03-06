using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ShenmueDKSharp.Files.Containers;
using Ookii.Dialogs;

namespace ShenmueHDArchiver.Controls
{
    public partial class PKSControl : UserControl
    {
        public PKSControl()
        {
            InitializeComponent();
        }

        private void listBox_ExtractFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                if (Path.GetExtension(file).ToUpper() != ".PKS") continue;
                PKS entry = new PKS();
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
                List<PKS> toDelete = new List<PKS>();
                foreach (PKS entry in listBox_ExtractFiles.SelectedItems)
                {
                    toDelete.Add(entry);
                }
                foreach (PKS entry in toDelete)
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
                IPACEntry entry = new IPACEntry();
                entry.Extension = Path.GetExtension(file).Substring(1, 4).ToUpper();
                entry.Filename = Path.GetFileNameWithoutExtension(file).ToUpper();
                using (FileStream stream = new FileStream(file, FileMode.Open))
                {
                    entry.FileSize = (uint)stream.Length;
                    entry.Buffer = new byte[stream.Length];
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
                List<IPACEntry> toDelete = new List<IPACEntry>();
                foreach (IPACEntry entry in listBox_ExtractFiles.SelectedItems)
                {
                    toDelete.Add(entry);
                }
                foreach (IPACEntry entry in toDelete)
                {
                    listBox_ExtractFiles.Items.Remove(entry);
                }
            }
        }

        private void button_ExtractPKS_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog folderDialog = new VistaFolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (PKS pks in listBox_ExtractFiles.Items)
                {
                    string folder = folderDialog.SelectedPath + "\\_" + pks.FileName + "_\\";
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    pks.Read(pks.FilePath);
                    pks.Unpack(folder);
                }
            }
        }

        private void button_CreatePKS_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PKS File (*.pks)|*.pks";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                PKS pks = new PKS();
                pks.Compress = checkBox_Compress.Checked;
                foreach (IPACEntry entry in listBox_ArchiveFiles.Items)
                {
                    pks.IPAC.Entries.Add(entry);
                }
                pks.FilePath = saveFileDialog.FileName;
                pks.Write(saveFileDialog.FileName);
            }
        }

        private void textBox_FileName_TextChanged(object sender, EventArgs e)
        {
            if (listBox_ArchiveFiles.SelectedIndex >= listBox_ArchiveFiles.Items.Count || listBox_ArchiveFiles.SelectedIndex < 0) return;
            IPACEntry entry = (IPACEntry)listBox_ArchiveFiles.Items[listBox_ArchiveFiles.SelectedIndex];
            entry.Filename = textBox_FileName.Text;
        }

        private void textBox_FileExtension_TextChanged(object sender, EventArgs e)
        {
            if (listBox_ArchiveFiles.SelectedIndex >= listBox_ArchiveFiles.Items.Count || listBox_ArchiveFiles.SelectedIndex < 0) return;
            IPACEntry entry = (IPACEntry)listBox_ArchiveFiles.Items[listBox_ArchiveFiles.SelectedIndex];
            entry.Extension = textBox_FileExtension.Text;
        }

        private void listBox_ArchiveFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_ArchiveFiles.SelectedIndex >= listBox_ArchiveFiles.Items.Count || listBox_ArchiveFiles.SelectedIndex < 0) return;
            IPACEntry entry = (IPACEntry)listBox_ArchiveFiles.Items[listBox_ArchiveFiles.SelectedIndex];
            textBox_FileName.Text = entry.Filename;
            textBox_FileExtension.Text = entry.Extension;
        }
    }
}
