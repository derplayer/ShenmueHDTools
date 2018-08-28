using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.IO.Compression;

namespace Shenmue_HD_Tools.ShenmueHD
{
    class Core
    {
        public static string loadedVFS { get; set; }

        public void Main()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Shenmue HD Tools - Core Module");
                string directory = null, file = null;

                OpenFileDialog newPathDlg = new OpenFileDialog();
                newPathDlg.Filter = "The Archive Dictonary files (*.tad)|*.tad";

                if (newPathDlg.ShowDialog() == DialogResult.OK)
                {

                    file = newPathDlg.FileName;
                    directory = Path.GetDirectoryName(file);
                    loadedVFS = file;

                    List<DataEntry> readedFiles = new Data().LoadVFS(file, directory);

                    Program.MainWindowCore.toolStripStatusLabel1.Text = "Loading finished! (" + newPathDlg.FileName + ", " + readedFiles.Count + " files)";
                    Program.MainWindowCore.listViewMain.Visible = true;
                }
            }
            catch (IOException e)
            {
                Program.MainWindowCore.toolStripStatusLabel1.Text = "Error at loadData: " + e.TargetSite;
            }
        }

        public void ImportProj()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Shenmue HD Tools - Core Module");
                string directory = null, file = null;

                OpenFileDialog newPathDlg = new OpenFileDialog();
                newPathDlg.Filter = "Shenmue HD ModTools Cache (*.shdcache)|*.shdcache";

                if (newPathDlg.ShowDialog() == DialogResult.OK)
                {
                    file = newPathDlg.FileName;
                    directory = Path.GetDirectoryName(file);
                    loadedVFS = file;

                    List<DataEntry> readedFiles = new Data().LoadCache(file, directory);

                    Program.MainWindowCore.toolStripStatusLabel1.Text = "Loading finished! (" + newPathDlg.FileName + ", " + readedFiles.Count + " files)";
                    Program.MainWindowCore.listViewMain.Visible = true;
                }
            }
            catch (IOException e)
            {
                Program.MainWindowCore.toolStripStatusLabel1.Text = "Error at loadData: " + e.TargetSite;
            }
        }

        public void save()
        {
            try
            {
                if (loadedVFS != null)
                {
                    new Data().SaveVFS(loadedVFS);
                    new Data().UpdateGUI();
                    Program.MainWindowCore.toolStripStatusLabel1.Text = "VFS saved!";
                }
                else
                {
                    Program.MainWindowCore.toolStripStatusLabel1.Text = "Please load first an file!";
                }
            }
            catch (IOException e)
            {
                Program.MainWindowCore.toolStripStatusLabel1.Text = "Error at saveAs: " + e.TargetSite;
            }
        }

        public void saveAs()
        {
            try
            {
                if (loadedVFS != null)
                {
                    SaveFileDialog newSavePathDlg = new SaveFileDialog();
                    newSavePathDlg.Filter = "The Archive Dictonary files(*.tad)| *.tad";
                    
                    if (newSavePathDlg.ShowDialog() == DialogResult.OK)
                    {
                        new Data().SaveVFS(newSavePathDlg.FileName);
                        Program.MainWindowCore.toolStripStatusLabel1.Text = "VFS saved!";
                    }
                }
                else
                {
                    Program.MainWindowCore.toolStripStatusLabel1.Text = "Please load first an file!";
                }
            }
            catch (IOException e)
            {
                Program.MainWindowCore.toolStripStatusLabel1.Text = "Error at saveAs: " + e.TargetSite;
            }
        }

        public void MurmurHash2Debug()
        {
            OpenFileDialog newPathHashDlg = new OpenFileDialog();
            newPathHashDlg.Filter = "HASH TEST|*.*";

            if (newPathHashDlg.ShowDialog() == DialogResult.OK)
            {
                byte[] fileArray = File.ReadAllBytes(newPathHashDlg.FileName);
                var testHash = new MurmurHash2Simple().Hash(fileArray); //MD5?

                MessageBox.Show(testHash.ToString());

            }
        }

    }
}
