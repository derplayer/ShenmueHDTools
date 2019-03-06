using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShenmueDKSharp.Utils;
using ShenmueDKSharp.Files.Images;
using ShenmueDKSharp.Files.Containers;
using System.IO;
using Ookii.Dialogs;

namespace ShenmueHDArchiver.Controls
{
    public partial class PKFControl : UserControl
    {
        public PKFControl()
        {
            InitializeComponent();
        }

        private void button_ExtractPKF_Click(object sender, EventArgs e)
        {
            bool TexDBState = TextureDatabase.Automatic;
            bool PVRTState = PVRT.EnableBuffering;
            TextureDatabase.Automatic = false;
            PVRT.EnableBuffering = true;

            VistaFolderBrowserDialog folderDialog = new VistaFolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (PKF pkf in listBox_ExtractFiles.Items)
                {
                    string folder = folderDialog.SelectedPath + "\\_" + pkf.FileName + "_\\";
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    pkf.Read(pkf.FilePath);
                    pkf.Unpack(folder);
                }
            }

            TextureDatabase.Automatic = TexDBState;
            PVRT.EnableBuffering = PVRTState;
        }

        private void button_CreatePKF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PKF File (*.pkf)|*.pkf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                PKF pkf = new PKF();
                pkf.Compress = checkBox_Compress.Checked;
                foreach (PKFEntry entry in listBox_ArchiveFiles.Items)
                {
                    pkf.Entries.Add(entry);
                }
                pkf.FilePath = saveFileDialog.FileName;
                pkf.Write(saveFileDialog.FileName);
            }
        }

        private void listBox_ArchiveFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                string extension = Path.GetExtension(file).Substring(1, 4).ToUpper();

                PKFEntry entry = new PKFEntry();
                entry.TokenString = extension;
                using (FileStream stream = new FileStream(file, FileMode.Open))
                {
                    entry.Size = (uint)stream.Length;
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
                List<PKFEntry> toDelete = new List<PKFEntry>();
                foreach (PKFEntry entry in listBox_ArchiveFiles.SelectedItems)
                {
                    toDelete.Add(entry);
                }
                foreach (PKFEntry entry in toDelete)
                {
                    listBox_ArchiveFiles.Items.Remove(entry);
                }
            }
        }

        private void listBox_ExtractFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                if (Path.GetExtension(file).ToUpper() != ".PKF") continue;
                PKF entry = new PKF();
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
                List<PKF> toDelete = new List<PKF>();
                foreach (PKF entry in listBox_ExtractFiles.SelectedItems)
                {
                    toDelete.Add(entry);
                }
                foreach (PKF entry in toDelete)
                {
                    listBox_ExtractFiles.Items.Remove(entry);
                }
            }
        }
    }
}
