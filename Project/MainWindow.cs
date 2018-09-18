using Shenmue_HD_Tools;
using ShenmueHDTools.GUI.Windows;
using ShenmueHDTools.Main.Database;
using ShenmueHDTools.Main.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShenmueHDTools.GUI.Dialogs;
using System.Runtime.Serialization.Formatters.Binary;
using ShenmueHDTools.Main.DataStructure;
using ShenmueHDTools.Main;

namespace ShenmueHDTools
{
    public partial class MainWindow : Form
    {
        private TADFile m_tadFile;
        private CacheFile m_cacheFile;

        public MainWindow()
        {
            InitializeComponent();
            Text = Version.ApplicationTitle;

            FilenameDatabase.Load();
            WulinshuRaymonfAPI.Read();

            CheckUpdates();
        }

        private void CheckUpdates()
        {
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                WebClient w = new WebClient(); //TODO: Shorter Timeout Range?
                w.Headers.Add("user-agent", "Mozilla/5.0 (Shenmue HD ModTools v" + Version.ActualVerison.ToString(CultureInfo.InvariantCulture) +
                    "; Linux; rv:1.0) Gecko/20160408 ShenmueHD-Client/" + Version.ActualVerison.ToString(CultureInfo.InvariantCulture));
                Version_JSON actualVersion;

                try
                {
                    string json_data = w.DownloadString(Version.UrlVersion);
                    actualVersion = JSONSerializer<Version_JSON>.DeSerialize(json_data);
                }
                catch (WebException ex) //Timeout,Server dead,...
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    actualVersion = new Version_JSON();
                    actualVersion.newestVersion = 0;
                }

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxButtons buttons_ok = MessageBoxButtons.OK;
                DialogResult result;

                if (actualVersion.newestVersion > Version.ActualVerison)
                {
                    string message = " New update is available! - Version: " + actualVersion.newestVersion.ToString(CultureInfo.InvariantCulture) + "\n\n Do you want to downtload it? \n\n---Server Message---\n\n" + actualVersion.message;
                    result = MessageBox.Show(message, Version.ApplicationName, buttons);

                    if (result == DialogResult.Yes)
                    {
                        //Tricks over cmd for non-elevated EXE (UAC) to Launch a URL with default webbrowser
                        //Process.Start("cmd", "/C start \"\" \"" + actualVersion.url + "\"");
                        System.Diagnostics.Process.Start(actualVersion.url);
                        Application.Exit();
                    }
                }

                //Timeout, false/dead url
                if (actualVersion.newestVersion == 0)
                {
                    string message = "Connection to the update server could not be etablished! \n\nPress OK to continue...";
                    result = MessageBox.Show(message, Version.ApplicationName, buttons_ok);

                    if (result == DialogResult.OK)
                    {
                        //hmm?
                    }

                }
            }
        }
    

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archive Dictonary file (*.tad)|*.tad";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_tadFile = new TADFile(openFileDialog.FileName);
                FilenameDatabase.MapFilenamesToTAD(m_tadFile);

                if (MessageBox.Show("Do you want to unpack the TAC file?", "Unpack TAC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    m_cacheFile = new CacheFile(m_tadFile);
                    m_cacheFile.Unpack();
                    tadDataTable1.SetCache(m_cacheFile);
                }
                else
                {
                    tadDataTable1.SetTAD(m_tadFile);
                }
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archive Dictonary file (*.tad)|*.tad";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string tadPath = saveFileDialog.FileName;
                m_cacheFile.Export(tadPath);

                m_tadFile = new TADFile(tadPath);
                FilenameDatabase.MapFilenamesToTAD(m_tadFile);

                if (MessageBox.Show("Do you want to unpack the TAC file?", "Unpack TAC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    m_cacheFile = new CacheFile(m_tadFile);
                    m_cacheFile.Unpack();
                    tadDataTable1.SetCache(m_cacheFile);
                }
                else
                {
                    tadDataTable1.SetTAD(m_tadFile);
                }
            }
        }

        private void filenameDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilenameDatabaseWindow window = new FilenameDatabaseWindow();
            window.ShowDialog();
        }

        private void wulinshuRaymonfDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RaymonfDatabaseWindow window = new RaymonfDatabaseWindow();
            window.ShowDialog();
        }

        private void mapFilenamesToTADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_tadFile == null) return;
            FilenameDatabase.MapFilenamesToTAD(m_tadFile);
            tadDataTable1.SetTAD(m_tadFile);
        }

        private void packAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_cacheFile.Pack();
        }

        private void unpackAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_cacheFile.Unpack();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Cache file (*.cache)|*.cache|Old cache file (*.shdcache)|*.shdcache";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_cacheFile = new CacheFile();
                if (Path.GetExtension(openFileDialog.FileName) == ".shdcache")
                {
                    using (FileStream reader = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        DataCollection deserializedCache = (DataCollection)binaryFormatter.Deserialize(reader);
                        m_cacheFile.ConvertLegacy(deserializedCache);
                        m_cacheFile.Filename = openFileDialog.FileName.Replace(".shdcache", ".cache");
                        m_cacheFile.Write(m_cacheFile.Filename);
                        m_cacheFile.TADFile.Filename = openFileDialog.FileName.Replace(".shdcache", ".tad");
                    }
                }
                else
                {
                    m_cacheFile.Read(openFileDialog.FileName);
                }
                tadDataTable1.SetCache(m_cacheFile);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog AboutWindow = new AboutDialog();
            AboutWindow.ShowDialog();
        }
    }
}
