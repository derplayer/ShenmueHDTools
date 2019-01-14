using ShenmueDKSharp.Files.Containers;
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

namespace ShenmueHDTools.GUI.Tools
{
    public partial class TADCreatorWindow : Form
    {

        public TADCreatorWindow()
        {
            InitializeComponent();
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TAD File (*.tad)|*.tad";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string tadFilepath = saveFileDialog.FileName;
                string tacFilepath = Path.ChangeExtension(tadFilepath, ".tac");

                TAD tad = new TAD();
                tad.FilePath = tadFilepath;
                foreach (TADEntry entry in listBox_Files.Items)
                {
                    tad.Entries.Add(entry);
                }
                TAC tac = new TAC();
                tac.TAD = tad;
                tac.Pack(tacFilepath);
                tad.UnixTimestamp = dateTimePicker_TADDate.Value;
                tad.Write(tadFilepath);
            }
        }

        private void textBox_Filepath_TextChanged(object sender, EventArgs e)
        {
            if (listBox_Files.SelectedIndex >= listBox_Files.Items.Count || listBox_Files.SelectedIndex < 0) return;
            TADEntry entry = (TADEntry)listBox_Files.Items[listBox_Files.SelectedIndex];
            entry.FileName = textBox_Filepath.Text;
            entry.CalculateFilenameHashes(checkBox_SingleHash.Checked);
            textBox_Hash1.Text = String.Format("{0:X8}", entry.FirstHash);
            textBox_Hash2.Text = String.Format("{0:X8}", entry.SecondHash);
        }

        private void listBox_Files_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void listBox_Files_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < files.Length; i++)
            {
                string file = (string)files[i];
                FileInfo fileInfo = new FileInfo(file);
                TADEntry entry = new TADEntry();
                entry.FilePath = file;
                entry.FileName = file;
                entry.FileSize = (uint)fileInfo.Length;
                entry.Index = (uint)i;
                listBox_Files.Items.Add(entry);
            }
        }

        private void listBox_Files_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Files.SelectedIndex >= listBox_Files.Items.Count || listBox_Files.SelectedIndex < 0) return;
            TADEntry entry = (TADEntry)listBox_Files.Items[listBox_Files.SelectedIndex];
            textBox_Filepath.Text = entry.FileName;
            textBox_Hash1.Text = String.Format("{0:X8}", entry.FirstHash);
            textBox_Hash2.Text = String.Format("{0:X8}", entry.SecondHash);
        }

        private void listBox_Files_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                List<TADEntry> toDelete = new List<TADEntry>();
                foreach(TADEntry entry in listBox_Files.SelectedItems)
                {
                    toDelete.Add(entry);
                }
                foreach(TADEntry entry in toDelete)
                {
                    listBox_Files.Items.Remove(entry);
                }
            }
        }
    }
}
