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
using System.Threading;
using ShenmueHDModelEditor;
using ShenmueHDArchiver;
using ShenmueHDTextureConverter;
using ShenmueHDTools.Main.Files.Nodes;
using ShenmueHDTools.Main.Utils;
using ShenmueDKSharp.Files;
using ShenmueDKSharp.Files.Images;
using ShenmueDKSharp.Files.Misc;
using ShenmueDKSharp.Files.Images._DDS;

namespace ShenmueHDTools
{
    public partial class MainWindow : Form
    {
        private TADFile m_tadFile;
        private CacheFile m_cacheFile;

        public static ModelEditor ModelEditor;
        public static Archiver Archiver;
        public static TextureConverter TextureConverter;

        public MainWindow()
        {
            InitializeComponent();
            Text = Version.ApplicationTitle;

            FilenameDatabase.Load();
            WulinshuRaymonfAPI.Read();
            DescriptionDatabase.GenerateDatabase();

            fileTreeView.SelectionChanged += FileTreeView_SelectionChanged;

            Helper.CheckUpdates();
        }

        private void FileTreeView_SelectionChanged(object sender, Main.Files.Nodes.FileNode e)
        {
            filePreview.SetFile(e);
        }

        private void UpdateControls()
        {
            tadDataTable1.SetCache(m_cacheFile);
            fileTreeView.SetCache(m_cacheFile);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archive Dictonary file (*.tad)|*.tad";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_tadFile = new TADFile(openFileDialog.FileName);
                FilenameDatabase.MapFilenamesToTAD(m_tadFile);
                DescriptionDatabase.MapDescriptionToTAD(m_tadFile);

                if (System.Diagnostics.Debugger.IsAttached)
                {
                    if (MessageBox.Show("Do you want to unpack the TAC file?", "Unpack TAC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        tadDataTable1.SetTAD(m_tadFile);
                        return;
                    }
                }

                m_cacheFile = new CacheFile(m_tadFile);
                m_cacheFile.Unpack();
                UpdateControls();
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_cacheFile == null) return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archive Dictonary file (*.tad)|*.tad";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string tadPath = saveFileDialog.FileName;
                m_cacheFile.Export(tadPath);

                m_tadFile = new TADFile(tadPath);
                FilenameDatabase.MapFilenamesToTAD(m_tadFile);
                DescriptionDatabase.MapDescriptionToTAD(m_tadFile);

                if (System.Diagnostics.Debugger.IsAttached)
                {
                    if (MessageBox.Show("Do you want to unpack the TAC file?", "Unpack TAC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        tadDataTable1.SetTAD(m_tadFile);
                    }
                }

                m_cacheFile = new CacheFile(m_tadFile);
                m_cacheFile.Unpack();
                UpdateControls();
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
            if (m_cacheFile == null || m_tadFile == null) return;

            FilenameDatabase filenameDB = new FilenameDatabase();
            LoadingDialog loadingDialog = new LoadingDialog();
            loadingDialog.SetData(filenameDB);
            Thread thread = new Thread(delegate ()
            {
                filenameDB.MapFilenamesToTADInstance(m_cacheFile);
            });
            loadingDialog.ShowDialog(thread);

            DescriptionDatabase descDB = new DescriptionDatabase();
            loadingDialog = new LoadingDialog();
            loadingDialog.SetData(descDB);
            thread = new Thread(delegate ()
            {
                descDB.MapDescriptionToTADInstance(m_tadFile);
            });
            loadingDialog.ShowDialog(thread);

            UpdateControls();
            m_cacheFile.Write(m_cacheFile.Filename);
        }

        private void packAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_cacheFile == null) return;
            m_cacheFile.Pack();
        }

        private void unpackAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_cacheFile == null) return;
            m_cacheFile.Unpack();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Cache file (*.cache, *.shdcache)|*.cache;*.shdcache";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_cacheFile = new CacheFile();
                if (Path.GetExtension(openFileDialog.FileName) == ".shdcache")
                {
                    m_cacheFile.ConvertLegacy(openFileDialog.FileName);
                }
                else
                {
                    m_cacheFile.Read(openFileDialog.FileName);
                }
                m_tadFile = m_cacheFile.TADFile;
                UpdateControls();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog AboutWindow = new AboutDialog();
            AboutWindow.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_cacheFile == null) return;
            m_cacheFile.Write(m_cacheFile.Filename);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_cacheFile == null) return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Cache file (*.cache)|*.cache";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_cacheFile.Write(saveFileDialog.FileName);
            }
        }

        /// <summary>
        /// TODO: Deprecated (to delete)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dEBUGNodeExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //NodeExplorer explorer = new NodeExplorer();
            //explorer.ShowDialog();
        }

        /// <summary>
        /// TODO: Deprecated (to delete)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dEBUGModelDumperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_cacheFile == null) return;
            //ModelDumper dumper = new ModelDumper(m_cacheFile);
            //dumper.ShowDialog();
        }

        private void modelEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ModelEditor == null)
            {
                ModelEditor = new ModelEditor();
                ModelEditor.FormClosed += ModelEditor_FormClosed;
                ModelEditor.Show();
            }
            else
            {
                ModelEditor.Show();
                ModelEditor.Focus();
            }
        }

        private void ModelEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            ModelEditor = null;
        }

        private void tADCreatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Archiver == null)
            {
                Archiver = new Archiver();
                Archiver.FormClosed += TADCreator_FormClosed;
                Archiver.Show();
            }
            else
            {
                Archiver.Show();
                Archiver.Focus();
            }
        }

        private void TADCreator_FormClosed(object sender, FormClosedEventArgs e)
        {
            Archiver = null;
        }

        private void textureConvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TextureConverter == null)
            {
                TextureConverter = new TextureConverter();
                TextureConverter.FormClosed += TextureConverter_FormClosed;
                TextureConverter.Show();
            }
            else
            {
                TextureConverter.Show();
                TextureConverter.Focus();
            }
        }

        private void TextureConverter_FormClosed(object sender, FormClosedEventArgs e)
        {
            TextureConverter = null;
        }

        //TODO: Own UI widget
        private void upscaleMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: Check if DL Folder is there, when not Show MessageBox that asks you to download it from a link
            CacheFile cacheFiles = fileTreeView.GetCache();

            foreach (FileNode fileNode in cacheFiles.Files)
            {
                if(fileNode.Type == FileNode.FileType.DDS || fileNode.Type == FileNode.FileType.PVR)
                {
                    if (fileNode.Size >= 33000) continue;
                    //TODO: Separate Alpha channel and convert into greyscale and upscale and merge back
                    string dlPath = "\\DL\\" + fileNode.RelativPath;
                    DeepLearningUtil.UpscaleImage(((IImageNode)fileNode).GetImage(), 4);
                    
                        object image = Activator.CreateInstance(typeof(PNG), new object[] { AppDomain.CurrentDomain.BaseDirectory + "DL\\data\\shenmue_tmp\\shdtst.png" });
                        BaseImage entry = (BaseImage)image;

                        if (fileNode.Type == FileNode.FileType.DDS) {
                            //TODO: Fake png vs real dds
                            DDS upscaledImage = new DDS(entry);
                            DDS oldImage = new DDS(fileNode.FullPath);
                            //Copy old FormatDetails into new resized file
                            upscaledImage.FormatDetails = new DDSFormats.DDSFormatDetails(oldImage.FormatDetails.Format);
                            upscaledImage.Write(fileNode.RootPath + dlPath);
                        }

                        if (fileNode.Type == FileNode.FileType.PVR)
                        {
                            PVRT upscaledImage = new PVRT(entry);
                            upscaledImage.Write(fileNode.RootPath + dlPath);
                        }
                    
                }
            }
        }

        private void fileTreeView_Load(object sender, EventArgs e)
        {

        }
    }
}
