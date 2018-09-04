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
using ShenmueHDTools.Main.DataStructure;
using System.Threading;
using ShenmueHDTools;

namespace Shenmue_HD_Tools.ShenmueHD
{
    class Core
    {
        public static string loadedVFS { get; set; }
        private static DataLogic data { get; set; } = new DataLogic();
        private Thread loadingThread;

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
                    LockGUI();
                    file = newPathDlg.FileName;
                    directory = Path.GetDirectoryName(file);
                    loadedVFS = file;

                    List<FileStructure> readedFiles = data.LoadVFS(file, directory);

                    Program.MainWindowCore.toolStripStatusLabel1.Text = "Loading finished! (" + newPathDlg.FileName + ", " + readedFiles.Count + " files)";
                    UnlockGUI();
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
                    LockGUI();
                    file = newPathDlg.FileName;
                    directory = Path.GetDirectoryName(file);
                    loadedVFS = file;

                    List<FileStructure> readedFiles = data.LoadCache(file, directory);

                    Program.MainWindowCore.toolStripStatusLabel1.Text = "Loading finished! (" + newPathDlg.FileName + ", " + readedFiles.Count + " files)";
                    UnlockGUI();
                    Program.MainWindowCore.listViewMain.Visible = true;
                }
            }
            catch (IOException e)
            {
                Program.MainWindowCore.toolStripStatusLabel1.Text = "Error at loadData: " + e.TargetSite;
            }
        }

        public void Save()
        {
            try
            {
                if (loadedVFS != null)
                {
                    LockGUI();
                    data.SaveVFS(loadedVFS);
                    UnlockGUI();
                    data.UpdateGUI();
                    Program.MainWindowCore.toolStripStatusLabel1.Text = "Tac/Tad saved!";
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

        public void SaveAs()
        {
            try
            {
                if (loadedVFS != null)
                {
                    SaveFileDialog newSavePathDlg = new SaveFileDialog();
                    newSavePathDlg.Filter = "The Archive Dictonary files(*.tad)| *.tad";

                    if (newSavePathDlg.ShowDialog() == DialogResult.OK)
                    {
                        LockGUI();
                        data.SaveVFS(newSavePathDlg.FileName);
                        UnlockGUI();
                        Program.MainWindowCore.toolStripStatusLabel1.Text = "Tac/Tad saved!";
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

        public void Export()
        {
            try
            {
                if (loadedVFS != null)
                {
                    SaveFileDialog newSavePathDlg = new SaveFileDialog();
                    newSavePathDlg.Filter = "The Archive Dictonary files(*.tad)| *.tad";

                    if (newSavePathDlg.ShowDialog() == DialogResult.OK)
                    {
                        LockGUI();
                        data.Export(newSavePathDlg.FileName);
                        UnlockGUI();
                        Program.MainWindowCore.toolStripStatusLabel1.Text = "Export executed!";
                    }
                }
                else
                {
                    Program.MainWindowCore.toolStripStatusLabel1.Text = "Please load first an file!";
                }
            }
            catch (IOException e)
            {
                Program.MainWindowCore.toolStripStatusLabel1.Text = "Error at export: " + e.TargetSite;
            }
        }

        public void UpdateGUI()
        {
            try
            {
                data.UpdateGUI();
            }
            catch (Exception e)
            {
                Program.MainWindowCore.toolStripStatusLabel1.Text = "Error! : " + e.TargetSite;
            }
        }

        public void LockGUI()
        {
            try
            {
                loadingThread = new Thread(() => new Loading());
                Program.MainWindowCore.Hide();
                loadingThread.Start();
            }
            catch (Exception)
            {
                Program.MainWindowCore.Hide();
            }
        }

        public void UnlockGUI()
        {
            try
            {
                loadingThread.Abort();
                Program.MainWindowCore.Show();
            }
            catch (Exception)
            {
                Program.MainWindowCore.Show();
            }

        }
    }
}
