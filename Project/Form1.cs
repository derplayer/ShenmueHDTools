using ShenmueHDTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Globalization;

namespace Shenmue_HD_Tools
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                WebClient w = new WebClient(); //TODO: Shorter Timeout Range?
                w.Headers.Add("user-agent", "Mozilla/5.0 (Shenmue HD ModTools v" + ShenmueHDTools.Version.actualVerison.ToString(CultureInfo.InvariantCulture) +
                    "; Linux; rv:1.0) Gecko/20160408 ShenmueHD-Client/" + ShenmueHDTools.Version.actualVerison.ToString(CultureInfo.InvariantCulture));
                Version_JSON actualVersion;

                try
                {
                    string json_data = w.DownloadString(ShenmueHDTools.Version.urlversion);
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
                string caption = "Shenmue HD ModTools";

                if (actualVersion.newestVersion > ShenmueHDTools.Version.actualVerison)
                {
                    string message = " New update is available! - Version: " + actualVersion.newestVersion.ToString(CultureInfo.InvariantCulture) + "\n\n Do you want to downtload it? \n\n---Server Message---\n\n" + actualVersion.message;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
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
                    result = MessageBox.Show(message, caption, buttons_ok);

                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        //hmm?
                    }

                }
            }

            base.Text += ShenmueHDTools.Version.actualVerison.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().Main();
        }

        private void anaButton_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().MurmurHash2Debug();
        }

        private void fileInjector_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().saveAs();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().Main();
        }

        private void cRC32FromLookupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().MurmurHash2Debug();
        }

        private void replaceFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().saveAs();
        }

        private void listBoxVFS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveVFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().saveAs();
        }

        private void listViewMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            listViewMain.AllowDrop = true;
            listViewMain.DragDrop += new DragEventHandler(listViewMain_DragDrop);
            listViewMain.DragEnter += new DragEventHandler(listViewMain_DragEnter);
        }

        void listViewMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void listViewMain_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void saveVFSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().save();
        }

        private void howToModifyAFileInVFSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Work in progress...");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About AboutWindow = new About();
            AboutWindow.ShowDialog();
        }

        private void extractVFSRecrusiveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gIMDebugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gIMShowGIMStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxPointer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void importExistingProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().ImportProj();
        }

        private void exportAsAModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().export();
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }
    }

    public static class JSONSerializer<TType> where TType : class
    {
        /// <summary>
        /// Deserializes an object from JSON with 100% .net libary (system.runtime.serialization.json)
        /// </summary>
        public static TType DeSerialize(string json)
        {
            using (var stream = new MemoryStream(Encoding.Default.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(TType));
                return serializer.ReadObject(stream) as TType;
            }
        }
    }
}
