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
using Ookii.Dialogs;
using ShenmueDKSharp.Files.Containers;
using ShenmueDKSharp.Utils;
using ShenmueDKSharp.Files.Images;
using ShenmueDKSharp.Files.Misc;

namespace ShenmueHDArchiver.Controls
{
    public partial class SPRControl : UserControl
    {
        public SPRControl()
        {
            InitializeComponent();

            numericUpDown_TextureID.Minimum = 0;
            numericUpDown_TextureID.Maximum = UInt64.MaxValue;
        }

        private void button_ExtractSPR_Click(object sender, EventArgs e)
        {
            bool TexDBState = TextureDatabase.Automatic;
            bool PVRTState = PVRT.EnableBuffering;
            TextureDatabase.Automatic = false;
            PVRT.EnableBuffering = true;

            VistaFolderBrowserDialog folderDialog = new VistaFolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (SPR spr in listBox_ExtractFiles.Items)
                {
                    string folder = folderDialog.SelectedPath + "\\_" + spr.FileName + "_\\";
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    spr.Read(spr.FilePath);
                    spr.Unpack(folder);
                }
            }

            TextureDatabase.Automatic = TexDBState;
            PVRT.EnableBuffering = PVRTState;
        }

        private void listBox_ExtractFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                if (Path.GetExtension(file).ToUpper() != ".SPR") continue;
                SPR entry = new SPR();
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
                List<SPR> toDelete = new List<SPR>();
                foreach (SPR entry in listBox_ExtractFiles.SelectedItems)
                {
                    toDelete.Add(entry);
                }
                foreach (SPR entry in toDelete)
                {
                    listBox_ExtractFiles.Items.Remove(entry);
                }
            }
        }

        private void button_CreateSPR_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SPR File (*.spr)|*.spr";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SPR spr = new SPR();
                foreach (TEXN entry in listBox_ArchiveFiles.Items)
                {
                    spr.Textures.Add(entry);
                }
                spr.FilePath = saveFileDialog.FileName;
                spr.Write(saveFileDialog.FileName);
            }
        }

        private void listBox_ArchiveFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_ArchiveFiles.SelectedIndex >= listBox_ArchiveFiles.Items.Count || listBox_ArchiveFiles.SelectedIndex < 0) return;
            TEXN entry = (TEXN)listBox_ArchiveFiles.Items[listBox_ArchiveFiles.SelectedIndex];
            numericUpDown_TextureID.Value = entry.TextureID.Data;
            textBox_TextureName.Text = entry.TextureID.Name;
        }

        private void listBox_ArchiveFiles_DragDrop(object sender, DragEventArgs e)
        {
            bool TexDBState = TextureDatabase.Automatic;
            bool PVRTState = PVRT.EnableBuffering;
            TextureDatabase.Automatic = false;
            PVRT.EnableBuffering = true;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                if (Path.GetExtension(file).ToUpper() != ".TEXN") continue;
                TEXN entry = new TEXN(file);
                listBox_ArchiveFiles.Items.Add(entry);
            }

            TextureDatabase.Automatic = TexDBState;
            PVRT.EnableBuffering = PVRTState;
        }

        private void listBox_ArchiveFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void listBox_ArchiveFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                List<TEXN> toDelete = new List<TEXN>();
                foreach (TEXN entry in listBox_ArchiveFiles.SelectedItems)
                {
                    toDelete.Add(entry);
                }
                foreach (TEXN entry in toDelete)
                {
                    listBox_ArchiveFiles.Items.Remove(entry);
                }
            }
        }

        private void numericUpDown_TextureID_ValueChanged(object sender, EventArgs e)
        {
            if (listBox_ArchiveFiles.SelectedIndex >= listBox_ArchiveFiles.Items.Count || listBox_ArchiveFiles.SelectedIndex < 0) return;
            TEXN entry = (TEXN)listBox_ArchiveFiles.Items[listBox_ArchiveFiles.SelectedIndex];
            entry.TextureID.Data = (UInt64)numericUpDown_TextureID.Value;
        }

        private void textBox_TextureName_TextChanged(object sender, EventArgs e)
        {
            if (listBox_ArchiveFiles.SelectedIndex >= listBox_ArchiveFiles.Items.Count || listBox_ArchiveFiles.SelectedIndex < 0) return;
            TEXN entry = (TEXN)listBox_ArchiveFiles.Items[listBox_ArchiveFiles.SelectedIndex];
            entry.TextureID.Name = textBox_TextureName.Name;
        }
    }
}
