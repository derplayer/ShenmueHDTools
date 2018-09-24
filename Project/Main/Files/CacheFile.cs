using ShenmueHDTools.Main.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Headers;
using System.IO;
using System.Threading;
using ShenmueHDTools.GUI.Dialogs;
using System.Runtime.Serialization.Formatters.Binary;
using ShenmueHDTools.Main.Database;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files
{
    public class CacheFile : IProgressable
    {
        public static readonly string Extension = ".shdcache";

        public bool IsAbortable { get { return false; } }

        public event FinishedEventHandler Finished;
        public event ProgressChangedEventHandler ProgressChanged;
        public event DescriptionChangedEventHandler DescriptionChanged;
        public event ErrorEventHandler Error;

        public CacheHeader Header { get; set; } = new CacheHeader();
        public TADFile TADFile { get; set; }
        public List<FileNode> Files { get; set; } = new List<FileNode>();


        public string Filename { get; set; }

        public string OutputFolder
        {
            get
            {
                return Path.GetDirectoryName(Filename) + Header.RelativeOutputFolder;
            }
        }

        public string OutputUnknownFolder
        {
            get
            {
                return OutputFolder + TACFile.UnknownFilesPath;
            }
        }


        public CacheFile() { }
        public CacheFile(TADFile tadFile)
        {
            TADFile = tadFile;
        }

        public string GetRelativePath(string filename)
        {
            return Helper.GetRelativePath(filename, OutputFolder);
        }

        public string GetFullPath(string relativePath)
        {
            return OutputFolder + "\\" + relativePath;
        }

        public void Clean()
        {
            string outputFolder = Path.GetDirectoryName(Filename) + Header.RelativeOutputFolder;
            if (Directory.Exists(outputFolder))
            {
                Directory.Delete(outputFolder, true);
            }
        }

        public void Unpack()
        {
            Clean();
            string tacFilename = Path.GetFileName(TADFile.Filename).ToLower().Replace(".tad", ".tac");
            string tacPath = Path.GetDirectoryName(TADFile.Filename) + "\\" + tacFilename;
            string targetDirectory = Path.GetDirectoryName(tacPath) + "\\" + "_" + tacFilename + "_";

            Header.RelativeOutputFolder = "\\" + Helper.GetRelativePath(targetDirectory, Path.GetDirectoryName(tacPath));
            Header.RelativeTACPath = "\\" + Helper.GetRelativePath(tacPath, Path.GetDirectoryName(tacPath));
            Header.RelativeTADPath = "\\" + Helper.GetRelativePath(TADFile.Filename, Path.GetDirectoryName(tacPath));

            TACFile tacFile = new TACFile();
            LoadingDialog loadingDialog = new LoadingDialog();
            loadingDialog.SetData(tacFile);
            Thread thread = new Thread(delegate () {
                tacFile.Unpack(tacPath, targetDirectory, TADFile);
            });
            loadingDialog.ShowDialog(thread);

            string cachePath = Path.GetDirectoryName(tacPath) + "\\" + Path.GetFileName(TADFile.Filename).ToLower().Replace(".tad", ".cache");
            Filename = cachePath;

            Header.Version = 1; //Delete when activating cache 2.0 import
            /* Uncomment for activating cache 2.0 on import
            LoadingDialog loadingDialog = new LoadingDialog();
            loadingDialog.SetData(this);
            Thread thread = new Thread(delegate () {
                GenerateFileNodeTree();
            });
            loadingDialog.ShowDialog(thread);

            DescriptionDatabase descDB = new DescriptionDatabase();
            loadingDialog = new LoadingDialog();
            loadingDialog.SetData(descDB);
            thread = new Thread(delegate () {
                descDB.MapDescriptionToNodeInstance(this);
            });
            loadingDialog.ShowDialog(thread);
            */

            Write(cachePath);
        }

        public void Export(string tadFilename, bool exportModified = true)
        {
            string tacPath = Path.GetDirectoryName(tadFilename) + "\\" + Path.GetFileName(tadFilename).ToLower().Replace(".tad", ".tac");
            string inputFolder = Path.GetDirectoryName(Filename) + Header.RelativeOutputFolder;

            if (exportModified)
            {
                LoadingDialog loadingDialogHash = new LoadingDialog();
                loadingDialogHash.SetData(this);
                Thread threadHash = new Thread(delegate ()
                {
                    CalculateHashes();
                });
                loadingDialogHash.ShowDialog(threadHash);
            }

            TACFile tacFile = new TACFile();
            LoadingDialog loadingDialog = new LoadingDialog();
            loadingDialog.SetData(tacFile);
            Thread thread = new Thread(delegate () {
                tacFile.Pack(tacPath, inputFolder, TADFile);
            });
            loadingDialog.ShowDialog(thread);

            TADFile.Write(tadFilename);
        }

        public void Pack()
        {
            string tacPath = Path.GetDirectoryName(Filename) + Header.RelativeTACPath;
            string inputFolder = Path.GetDirectoryName(Filename) + Header.RelativeOutputFolder;

            TACFile tacFile = new TACFile();
            LoadingDialog loadingDialog = new LoadingDialog();
            loadingDialog.SetData(tacFile);
            Thread thread = new Thread(delegate () {
                tacFile.Pack(tacPath, inputFolder, TADFile, false);
            });
            loadingDialog.ShowDialog(thread);

            string cachePath = Path.GetDirectoryName(tacPath) + "\\" + Path.GetFileName(TADFile.Filename).ToLower().Replace(".tad", ".cache");
            Filename = cachePath;
            Write(cachePath);
        }

        public void Read(string filename)
        {
            Filename = filename;
            if (!Helper.IsFileValid(filename)) return;
            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    Header.Read(reader);
                    TADFile = new TADFile();
                    TADFile.Read(reader, true);
                    TADFile.Filename = Path.GetDirectoryName(Filename) + Header.RelativeTADPath;
                    if (Header.Version > 1)
                    {
                        while(stream.CanRead)
                        {
                            if (stream.Position == stream.Length) break;
                            Files.Add(FileNode.Read(this, null, reader));
                        }
                    }
                    else
                    {
                        LoadingDialog loadingDialog = new LoadingDialog();
                        loadingDialog.SetData(this);
                        Thread thread = new Thread(delegate () {
                            GenerateFileNodeTree();
                        });
                        loadingDialog.ShowDialog(thread);

                        DescriptionDatabase descDB = new DescriptionDatabase();
                        loadingDialog = new LoadingDialog();
                        loadingDialog.SetData(descDB);
                        thread = new Thread(delegate () {
                            descDB.MapDescriptionToNodeInstance(this);
                        });
                        loadingDialog.ShowDialog(thread);

                        Header.Version = 2; //Update Version
                        //TODO Overwrite old cache file
                        //Unpack children stuff (currently at node tree generation)
                    }
                }
            }
        }

        private void GenerateFileNodeTree()
        {
            DescriptionChanged(this, new DescriptionChangedArgs("Creating file node tree..."));
            for (int i = 0; i < TADFile.FileEntries.Count; i++)
            {
                ProgressChanged(this, new ProgressChangedArgs(i, TADFile.FileEntries.Count));
                TADFileEntry entry = TADFile.FileEntries[i];
                Files.Add(FileNode.CreateNode(this, entry));
            }
            Finished(this, new FinishedArgs(true));
        }

        public void Write(string filename)
        {
            if (!Helper.IsFileValid(filename, false)) return;
            using (FileStream stream = File.Create(filename))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    Header.Write(writer);
                    TADFile.Write(writer, true);
                    if (Header.Version > 1)
                    {
                        foreach(FileNode node in Files)
                        {
                            node.Write(writer);
                        }
                    }
                }
            }
        }

        public void CalculateHashes()
        {
            DescriptionChanged(this, new DescriptionChangedArgs("Calculating hashes..."));
            string outputFolder = Path.GetDirectoryName(Filename) + Header.RelativeOutputFolder;
            for (int i = 0; i < TADFile.FileEntries.Count; i++)
            {
                ProgressChanged(this, new ProgressChangedArgs(i, TADFile.FileEntries.Count));
                TADFileEntry entry = TADFile.FileEntries[i];
                entry.CheckMD5(outputFolder + "\\" + entry.RelativPath);
            }
            Finished(this, new FinishedArgs(true));
        }

        public void ConvertLegacy(string filename)
        {
            DataCollection dataCollection;
            using (FileStream reader = new FileStream(filename, FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                dataCollection = (DataCollection)binaryFormatter.Deserialize(reader);
            }
            if (dataCollection == null) return;

            Filename = filename.Replace(".shdcache", ".cache");
            
            TADFile = new TADFile();
            TADFile.Filename = filename.Replace(".shdcache", ".tad");
            TADFile.Header.FileCount = BitConverter.ToUInt32(dataCollection.Header.FileCount1, 0);
            TADFile.Header.HeaderChecksum = BitConverter.ToUInt32(dataCollection.Header.HeaderChecksum, 0);
            TADFile.Header.TacSize = BitConverter.ToUInt32(dataCollection.Header.TacSize, 0);
            TADFile.Header.UnixTimestamp = new DateTime(1970, 1, 1).AddSeconds(BitConverter.ToInt32(dataCollection.Header.UnixTimestamp, 0));

            string fileDir = Path.GetDirectoryName(Filename);
            string dir = fileDir;
            if (dataCollection.Files.Count > 0)
            {
                dir = Path.GetDirectoryName(dataCollection.Files[0].Meta.FilePath);
            }
            
            Header.RelativeOutputFolder = "\\" + Helper.GetRelativePath(dir, fileDir);
            Header.RelativeTADPath = "\\" + Helper.GetRelativePath(TADFile.Filename, fileDir);
            Header.RelativeTACPath = "\\" + Helper.GetRelativePath(TADFile.Filename.Replace(".tad", ".tac"), fileDir);

            foreach (FileStructure file in dataCollection.Files)
            {
                TADFileEntry entry = new TADFileEntry();
                entry.FileOffset = BitConverter.ToUInt32(file.FileStart, 0);
                entry.FileSize = BitConverter.ToUInt32(file.FileSize, 0);
                entry.RelativPath = Helper.GetRelativePath(file.Meta.FilePath, dir);
                entry.Index = file.Meta.Index;

                byte[] firstHash = new byte[4];
                Array.Copy(file.Hash1, firstHash, 4);
                entry.FirstHash = BitConverter.ToUInt32(firstHash, 0);

                byte[] secondHash = new byte[4];
                Array.Copy(file.Hash1, 4, secondHash, 0, 4);
                entry.SecondHash = BitConverter.ToUInt32(secondHash, 0);

                byte[] unknown = new byte[4];
                Array.Copy(file.Hash2, 0, unknown, 0, 4);
                entry.Unknown = BitConverter.ToUInt32(unknown, 0);

                entry.MD5Checksum = file.Meta.MD5Hash;

                TADFile.FileEntries.Add(entry);
            }

            FilenameDatabase filenameDB = new FilenameDatabase();
            LoadingDialog loadingDialog = new LoadingDialog();
            loadingDialog.SetData(filenameDB);
            Thread thread = new Thread(delegate () {
                filenameDB.MapFilenamesToTADInstance(this);
            });
            loadingDialog.ShowDialog(thread);

            DescriptionDatabase descDB = new DescriptionDatabase();
            loadingDialog = new LoadingDialog();
            loadingDialog.SetData(descDB);
            thread = new Thread(delegate () {
                descDB.MapDescriptionToTADInstance(TADFile);
            });
            loadingDialog.ShowDialog(thread);

            Write(Filename);
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }

        public void Abort()
        {
            //throw new NotImplementedException();
        }
    }
}
