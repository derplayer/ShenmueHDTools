using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.IO.Compression;
using ShenmueHDTools.Main;

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

                    List<DataEntry> readedFiles = new DataLogic().LoadVFS(file, directory);

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

                    List<DataEntry> readedFiles = new DataLogic().LoadCache(file, directory);

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
                    new DataLogic().SaveVFS(loadedVFS);
                    new DataLogic().UpdateGUI();
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
                        new DataLogic().SaveVFS(newSavePathDlg.FileName);
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
            byte[] hashHeader = new byte[56];
            int i = 0;
            foreach (var entry in DataCollector.header.GetHeader(true))
            {
                entry.CopyTo(hashHeader, i);
                i += 4;
            }

            var testHash = MurmurHash2Shenmue.Hash(hashHeader, 56);
            OpenFileDialog newPathHashDlg = new OpenFileDialog();
            //newPathHashDlg.Filter = "HASH TEST|*.*";

            //if (newPathHashDlg.ShowDialog() == DialogResult.OK)
            //{
            //    byte[] fileArray = File.ReadAllBytes(newPathHashDlg.FileName);
            //    var testHash = new MurmurHash2Simple().Hash(fileArray); //MD5?

            //    MessageBox.Show(testHash.ToString());

            //}
        }

    }
}
