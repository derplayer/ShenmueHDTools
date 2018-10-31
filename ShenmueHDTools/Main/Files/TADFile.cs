using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Headers;
using System.IO;
using System.Security.Cryptography;
using ShenmueHDTools.Main;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ShenmueHDTools.Main.Database;

namespace ShenmueHDTools.Main.Files
{
    public struct TADStatistic
    {
        public int FileCount;
        public int FilesCovered;
        public double FileCoverage;
    }

    public class TADFile
    {
        public static readonly string Extension = ".tad";

        public List<TADFileEntry> FileEntries = new List<TADFileEntry>();
        public TADHeader Header = new TADHeader();
        public string Filename { get; set; } = "";

        public TADFile() { }
        public TADFile(string filename)
        {
            Filename = filename;
            Read(filename);
        }

        /// <summary>
        /// Reads the specified filename inside the current object.
        /// </summary>
        /// <param name="filename">The TAD filename</param>
        public bool Read(string filename, bool includeMeta = false)
        {
            if (Path.GetExtension(filename).ToLower() != Extension) return false;
            if (!File.Exists(filename)) return false;
            Filename = filename;
            if (!Helper.IsFileValid(filename)) return false;
            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    Read(reader, includeMeta);
                }
            }
            return true;
        }

        public void Read(BinaryReader reader, bool includeMeta = false)
        {
            FileEntries.Clear();

            int dataOffset = 56 + 4; //including the useless filecount
            byte[] headerBuffer = new byte[dataOffset];
            reader.Read(headerBuffer, 0, headerBuffer.Length);
            Header.Read(headerBuffer);

            for (int i = 0; i < Header.FileCount; i++)
            {
                TADFileEntry entry = new TADFileEntry();
                entry.Read(reader, includeMeta);
                entry.Index = i;
                FileEntries.Add(entry);
            }
        }

        /// <summary>
        /// Writes the current object to the specified filename.
        /// </summary>
        /// <param name="filename">The TAD filename.</param>
        public void Write(string filename, bool includeMeta = false)
        {
            if (!Helper.IsFileValid(filename, false)) return;
            using (FileStream stream = File.Create(filename))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    Write(writer, includeMeta);
                }
            }
        }

        public void Write(BinaryWriter writer, bool includeMeta = false)
        {
            Header.Write(writer);

            for (int i = 0; i < FileEntries.Count; i++)
            {
                TADFileEntry entry = FileEntries[i];
                entry.Write(writer, includeMeta);
            }
        }

        public TADStatistic GetStatistic()
        {
            int counter = 0;
            foreach (TADFileEntry entry in FileEntries)
            {
                if (String.IsNullOrEmpty(entry.Filename)) continue;
                counter++;
            }

            TADStatistic statistic = new TADStatistic()
            {
                FileCount = FileEntries.Count,
                FilesCovered = counter,
                FileCoverage = Math.Round((float)counter / (float)FileEntries.Count * 100.0f, 2)
            };

            return statistic;
        }

        public void PrintStatistic(bool verbose = false, bool interleaved = false)
        {
            int counter = 0;


            List<TADFileEntry> unknownEntries = new List<TADFileEntry>();
            List<TADFileEntry> knownEntries = new List<TADFileEntry>();
            foreach (TADFileEntry entry in FileEntries)
            {
                if (String.IsNullOrEmpty(entry.Filename))
                {
                    unknownEntries.Add(entry);
                    continue;
                }
                knownEntries.Add(entry);
                counter++;
            }

            Console.WriteLine("\n### TAD File Statistic ###\n");
            Console.WriteLine(" File coverage: {0}/{1} ({2}%)", counter, FileEntries.Count,
                Math.Round((float)counter / (float)FileEntries.Count * 100.0f, 2));

            if (verbose)
            {
                if (interleaved)
                {
                    Console.WriteLine("\n Files:");
                    int c = 0;
                    foreach (TADFileEntry entry in FileEntries)
                    {
                        Console.WriteLine(String.Format("  [{0}] {1}", c.ToString(), entry.ToString()));
                        c++;
                    }
                }
                else
                {
                    Console.WriteLine("\n Found Files:");
                    foreach (TADFileEntry entry in knownEntries)
                    {
                        Console.WriteLine("  " + entry.ToString());
                    }
                    Console.WriteLine("\n Unknown Files:");
                    foreach (TADFileEntry entry in unknownEntries)
                    {
                        Console.WriteLine("  " + entry.ToString());
                    }
                }
            }
            
            Console.WriteLine("\n##########################\n");
        }
    }


    /// <summary>
    /// File entry inside the TAD file (32 Bytes)
    /// </summary>
    public class TADFileEntry : INotifyPropertyChanged
    {
        /// <summary>
        /// The TAD file entry size in bytes.
        /// </summary>
        public static readonly ushort TADEntrySize = 32;

        public event PropertyChangedEventHandler PropertyChanged;

        private uint m_firstHash;
        private uint m_secondHash;
        private uint m_unknown;
        private uint m_fileOffset;
        private uint m_fileSize;

        public uint FirstHash
        {
            get { return m_firstHash; }
            set
            {
                SetProperty(ref m_firstHash, value);
                OnPropertyChanged("Hash1");
            }
        }
        public uint SecondHash
        {
            get { return m_secondHash; }
            set
            {
                SetProperty(ref m_secondHash, value);
                OnPropertyChanged("Hash2");
            }
        }
        public uint Unknown
        {
            get { return m_unknown; }
            set
            {
                SetProperty(ref m_unknown, value);
                OnPropertyChanged("Hash3");
            }
        }
        /// <summary>
        /// Offset inside the TAC file.
        /// </summary>
        public uint FileOffset
        {
            get { return m_fileOffset; }
            set { SetProperty(ref m_fileOffset, value); }
        }
        public uint FileSize
        {
            get { return m_fileSize; }
            set { SetProperty(ref m_fileSize, value); }
        }

        #region MetaData
        private byte[] m_md5Checksum = new byte[16];
        private string m_filename = "";
        private string m_relativPath = "";
        private string m_description = "";
        private string m_category = "";

        public byte[] MD5Checksum
        {
            get { return m_md5Checksum; }
            set { SetProperty(ref m_md5Checksum, value); }
        }
        public string Filename
        {
            get { return m_filename; }
            set { SetProperty(ref m_filename, value); }
        }
        public string RelativPath
        {
            get { return m_relativPath; }
            set
            {
                SetProperty(ref m_relativPath, value);
                OnPropertyChanged("Extension");
            }
        }
        public string Description
        {
            get
            {
                return m_description;
            }
            set
            {
                if (value == null)
                {
                    SetProperty(ref m_description, "");
                }
                else
                {
                    SetProperty(ref m_description, value);
                }
            }
        }

        public string Category
        {
            get
            {
                return m_category;
            }
            set
            {
                if (value == null)
                {
                    SetProperty(ref m_category, "");
                }
                else
                {
                    SetProperty(ref m_category, value);
                }
            }
        }

        #region Runtime
        private int m_index;
        private bool m_export;
        private bool m_modified;

        public int Index
        {
            get { return m_index; }
            set { SetProperty(ref m_index, value); }
        }
        public bool Export
        {
            get { return m_export; }
            set { SetProperty(ref m_export, value); }
        }
        public bool Modified
        {
            get { return m_modified; }
            set { SetProperty(ref m_modified, value); }
        }
        #endregion

        #endregion

        #region DataBinding

        public string Hash1
        {
            get
            {
                return FirstHash.ToString("X8");
            }
        }

        public string Hash2
        {
            get
            {
                return SecondHash.ToString("X8");
            }
        }

        public string Hash3
        {
            get
            {
                return Unknown.ToString("X8");
            }
        }

        public string Extension
        {
            get
            {
                return Path.GetExtension(RelativPath);
            }
        }

        #endregion


        public TADFileEntry() { }
        public TADFileEntry(byte[] data, bool includeMeta = false)
        {
            Read(data);
        }

        public bool CheckMD5(string filename)
        {
            if (!Helper.IsFileValid(filename)) return false;
            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
                return CheckMD5(Helper.MD5Hash(buffer));
            }
        }

        public bool CheckMD5(byte[] hash)
        {
            Modified = false;
            for (int i = 0; i < hash.Length; i++)
            {
                if (MD5Checksum[i] != hash[i])
                {
                    Modified = true;
                    Export = true;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Reads the file entry with binary reader into the current file entry object.
        /// </summary>
        public void Read(BinaryReader reader, bool includeMeta = false)
        {
            FirstHash = reader.ReadUInt32();
            SecondHash = reader.ReadUInt32();
            Unknown = reader.ReadUInt32();
            reader.ReadUInt32();
            FileOffset = reader.ReadUInt32();
            reader.ReadUInt32();
            FileSize = reader.ReadUInt32();
            reader.ReadUInt32();

            if (includeMeta)
            {
                MD5Checksum = reader.ReadBytes(16);

                uint filenameLength = reader.ReadUInt32();
                if (filenameLength > 0)
                {
                    byte[] filenameBuffer = reader.ReadBytes((int)filenameLength);
                    Filename = Encoding.ASCII.GetString(filenameBuffer);
                }
                
                uint relativePathLength = reader.ReadUInt32();
                if (relativePathLength > 0)
                {
                    byte[] relativePathBuffer = reader.ReadBytes((int)relativePathLength);
                    RelativPath = Encoding.ASCII.GetString(relativePathBuffer);
                }

                uint descriptionLength = reader.ReadUInt32();
                if (descriptionLength > 0)
                {
                    byte[] descriptionBuffer = reader.ReadBytes((int)descriptionLength);
                    Description = Encoding.ASCII.GetString(descriptionBuffer);
                }

                uint categoryLength = reader.ReadUInt32();
                if (categoryLength > 0)
                {
                    byte[] categoryBuffer = reader.ReadBytes((int)categoryLength);
                    Category = Encoding.ASCII.GetString(categoryBuffer);
                }
            }
        }

        /// <summary>
        /// Reads the file entry as byte array into the current file entry object.
        /// No Metadata support.
        /// </summary>
        public void Read(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    Read(reader);
                }
            }
        }

        public void RenameAndMoveFile(CacheFile cacheFile, FilenameDatabaseEntry entry)
        {
            if (entry != null)
            {
                string filename = entry.Filename;
                if (filename[0] == '.')
                {
                    filename = filename.Substring(1);
                }
                Filename = filename;
            }

            string outputFolder = cacheFile.OutputFolder;
            string oldFileEntryPath = outputFolder + "\\" + RelativPath;

            string fileEntryPath = "";
            if (String.IsNullOrEmpty(Filename))
            {
                string unknownDir = cacheFile.OutputUnknownFolder;
                if (!Directory.Exists(unknownDir))
                {
                    Directory.CreateDirectory(unknownDir);
                }

                string Extension = Helper.ExtensionFinder(oldFileEntryPath);
                string fileEntryName = String.Format("{0}{1}{2}", TACFile.UnknownFilesPath, Index.ToString(), Extension);
                fileEntryPath = outputFolder + fileEntryName;
            }
            else
            {
                fileEntryPath = Filename.Replace('/', '\\');
                fileEntryPath = outputFolder + "\\" + fileEntryPath;
                fileEntryPath = Helper.SwitchExtension(fileEntryPath);

                string dir = Path.GetDirectoryName(fileEntryPath);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }
            fileEntryPath = fileEntryPath.Replace("\\\\", "\\");
            oldFileEntryPath = oldFileEntryPath.Replace("\\\\", "\\");

            RelativPath = "\\" + Helper.GetRelativePath(fileEntryPath, outputFolder);
            if (fileEntryPath == oldFileEntryPath) return;
            if (File.Exists(fileEntryPath))
            {
                File.Delete(fileEntryPath);
            }
            File.Move(oldFileEntryPath, fileEntryPath);
        }

        /// <summary>
        /// Writes the current file entry object to the binary writer.
        /// </summary>
        public void Write(BinaryWriter writer, bool includeMeta = false)
        {
            byte[] entryBytes = GetBytes(includeMeta);
            writer.Write(entryBytes, 0, entryBytes.Length);
        }

        /// <summary>
        /// Gets the bytes of the current file entry object as inside an TAD file.
        /// </summary>
        public byte[] GetBytes(bool includeMeta = false)
        {
            byte[] result = new byte[TADEntrySize];
            if (includeMeta)
            {
                int metaDataSize = 16 + 4 + Filename.Length + 4 + RelativPath.Length
                    + 4 + Description.Length + 4 + Category.Length;
                result = new byte[TADEntrySize + metaDataSize];
            }
            using (MemoryStream stream = new MemoryStream(result))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(FirstHash);
                    writer.Write(SecondHash);
                    writer.Write(Unknown);
                    writer.Write(0);
                    writer.Write(FileOffset);
                    writer.Write(0);
                    writer.Write(FileSize);
                    writer.Write(0);

                    if (includeMeta)
                    {
                        writer.Write(MD5Checksum, 0, 16);

                        byte[] filenameBytes = Encoding.ASCII.GetBytes(Filename);
                        writer.Write((uint)filenameBytes.Length);
                        if (filenameBytes.Length > 0)
                        {
                            writer.Write(filenameBytes, 0, filenameBytes.Length);
                        }

                        byte[] relativePathBytes = Encoding.ASCII.GetBytes(RelativPath);
                        writer.Write((uint)relativePathBytes.Length);
                        if (relativePathBytes.Length > 0)
                        {
                            writer.Write(relativePathBytes, 0, relativePathBytes.Length);
                        }

                        byte[] descriptionBytes = Encoding.ASCII.GetBytes(Description);
                        writer.Write((uint)descriptionBytes.Length);
                        if (descriptionBytes.Length > 0)
                        {
                            writer.Write(descriptionBytes, 0, descriptionBytes.Length);
                        }

                        byte[] categoryBytes = Encoding.ASCII.GetBytes(Category);
                        writer.Write((uint)categoryBytes.Length);
                        if (categoryBytes.Length > 0)
                        {
                            writer.Write(categoryBytes, 0, categoryBytes.Length);
                        }
                    }
                }
            }
            return result;
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(Filename))
            {
                return String.Format("[{0}|{1}|{2}] Offset: {3}, Size: {4}", FirstHash.ToString("X8"), SecondHash.ToString("X8"),
                    Unknown.ToString("X8"), FileOffset, FileSize);
            }
            else
            {
                return String.Format("[{0}|{1}|{2}] Offset: {3}, Size: {4}, Filename:{5}", FirstHash.ToString("X8"), SecondHash.ToString("X8"),
                    Unknown.ToString("X8"), FileOffset, FileSize, Filename);
            }
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
