using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ShenmueHDTools.Main.Database;

namespace ShenmueHDTools.Main.Files
{

    public class TACFile : IProgressable
    {
        public static readonly string Extension = ".tac";
        public static readonly string UnknownFilesPath = "\\_UNKNOWN\\";

        public string Filename { get; set; }
        public TADFile TADFile { get; set; }
        public bool IsAbortable { get { return false; } }

        private byte[] m_buffer;

        public event FinishedEventHandler Finished;
        public event ProgressChangedEventHandler ProgressChanged;
        public event DescriptionChangedEventHandler DescriptionChanged;
        public event ErrorEventHandler Error;

        public byte[] GetFileFromEntry(FilenameDatabaseEntry dbEntry, out bool found)
        {
            uint offset = 0;
            uint size = 0;
            foreach (TADFileEntry entry in TADFile.FileEntries)
            {
                if (entry.FirstHash == dbEntry.FirstHash && entry.SecondHash == dbEntry.SecondHash)
                {
                    offset = entry.FileOffset;
                    size = entry.FileSize;
                    break;
                }
            }
            found = false;
            if (offset == 0) return new byte[0];
            if (m_buffer == null || m_buffer.Length == 0)
            {
                if (!Helper.IsFileValid(Filename)) return new byte[0];
                using (FileStream stream = File.Open(Filename, FileMode.Open))
                {
                    stream.Seek(offset, SeekOrigin.Begin);
                    byte[] buffer = new byte[size];
                    stream.Read(buffer, 0, (int)size);

                    found = true;
                    return buffer;
                }
            }

            byte[] fileBuffer = new byte[size];
            Array.Copy(m_buffer, offset, fileBuffer, 0, size);
            found = true;
            return fileBuffer;
        }

        /// <summary>
        /// Loads the TAC inside an buffer for the filename crawler.
        /// </summary>
        /// <param name="filename">The TAC filename.</param>
        /// <param name="tadFile">The TAD file.</param>
        public void Load(string filename, TADFile tadFile)
        {
            TADFile = tadFile;
            if (!Helper.IsFileValid(filename)) return;
            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                m_buffer = new byte[stream.Length];
                stream.Read(m_buffer, 0, m_buffer.Length);
            }
        }

        public void Unpack(string filename)
        {
            string outputFolder = String.Format("{0}\\_{1}_", Path.GetDirectoryName(filename), Path.GetFileName(filename));
            Unpack(filename, outputFolder);
        }

        public void Unpack(string filename, string outputFolder)
        {
            string tadFilename = String.Format("{0}\\{1}{2}", Path.GetDirectoryName(filename),
                Path.GetFileNameWithoutExtension(filename),
                TADFile.Extension);
            TADFile tadFile = new TADFile(tadFilename);
            Unpack(filename, outputFolder, tadFile);
        }

        /// <summary>
        /// Unpacks the TAC file accordingly to the TAD file.
        /// </summary>
        /// <param name="filename">The TAC filename.</param>
        /// <param name="outputFolder">The extraction output folder.</param>
        /// <param name="tadFile">The TAD file.</param>
        /// <returns></returns>
        public bool Unpack(string tacFilename, string outputFolder, TADFile tadFile)
        {
            if (Path.GetExtension(tacFilename).ToLower() != Extension) return false;
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            DescriptionChanged(this, new DescriptionChangedArgs("Unpacking TAC..."));

            if (!Helper.IsFileValid(tacFilename))
            {
                Finished(this, new FinishedArgs(false));
                return false;
            }
            using (FileStream tacStream = File.Open(tacFilename, FileMode.Open))
            {
                int counter = 0;
                foreach (TADFileEntry entry in tadFile.FileEntries)
                {
                    tacStream.Seek(entry.FileOffset, SeekOrigin.Begin);
                    byte[] fileBuffer = new byte[entry.FileSize];
                    tacStream.Read(fileBuffer, 0, fileBuffer.Length);
                    entry.MD5Checksum = Helper.MD5Hash(fileBuffer);

                    string fileEntryPath = "";
                    if (String.IsNullOrEmpty(entry.Filename))
                    {
                        string unknownDir = outputFolder + UnknownFilesPath;
                        if (!Directory.Exists(unknownDir))
                        {
                            Directory.CreateDirectory(unknownDir);
                        }

                        string Extension = Helper.ExtensionFinder(fileBuffer);
                        string fileEntryName = String.Format("{0}{1}{2}", UnknownFilesPath, counter.ToString(), Extension);
                        fileEntryPath = outputFolder + fileEntryName;
                    }
                    else
                    {
                        fileEntryPath = entry.Filename.Replace('/', '\\');
                        fileEntryPath = outputFolder + "\\" + fileEntryPath;
                        fileEntryPath = Helper.SwitchExtension(fileEntryPath);

                        string dir = Path.GetDirectoryName(fileEntryPath);
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }
                    }

                    if (!Helper.IsFileValid(fileEntryPath, false))
                    {
                        Finished(this, new FinishedArgs(false));
                        return false;
                    }
                    using (FileStream fileEntryStream = File.Create(fileEntryPath))
                    {
                        entry.RelativPath = Helper.GetRelativePath(fileEntryStream.Name, outputFolder);
                        fileEntryStream.Write(fileBuffer, 0, fileBuffer.Length);
                    }

                    counter++;
                    ProgressChanged(this, new ProgressChangedArgs(counter, tadFile.FileEntries.Count));
                }
            }
            Finished(this, new FinishedArgs(true));
            return true;
        }

        /// <summary>
        /// Packs the TAC file and changes the input TAD file accordingly.
        /// </summary>
        /// <param name="filename">The TAC filename.</param>
        /// <param name="inputFolder">The TAC extraction folder.</param>
        /// <param name="tadFile">The TAD file.</param>
        public void Pack(string filename, string inputFolder, TADFile tadFile, bool useExport = true)
        {
            DescriptionChanged(this, new DescriptionChangedArgs("Packing TAC..."));
            if (!Helper.IsFileValid(filename, false))
            {
                Finished(this, new FinishedArgs(false));
                return;
            }

            List<TADFileEntry> toRemove = new List<TADFileEntry>();
            using (FileStream tacStream = File.Create(filename))
            {
                uint fileCount = 0;
                int counter = 0;
                foreach (TADFileEntry entry in tadFile.FileEntries)
                {
                    counter++;
                    ProgressChanged(this, new ProgressChangedArgs(counter, tadFile.FileEntries.Count));
                    if (useExport)
                    {
                        if (!entry.Export)
                        {
                            toRemove.Add(entry);
                            continue; //skip tad entries that are not flagged for exporting.
                        }
                    }

                    fileCount++;

                    if (String.IsNullOrEmpty(entry.RelativPath))
                    {
                        Console.WriteLine("TAC was not unpacked before!");
                        break;
                    }

                    string sourceFilename = String.Format("{0}\\{1}", inputFolder, entry.RelativPath);

                    byte[] buffer;
                    if (!Helper.IsFileValid(sourceFilename))
                    {
                        Finished(this, new FinishedArgs(false));
                        return;
                    }
                    using (FileStream stream = File.Open(sourceFilename, FileMode.Open))
                    {
                        buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);

                        entry.FileOffset = (uint)tacStream.Position;
                        entry.FileSize = (uint)buffer.Length;
                        entry.MD5Checksum = Helper.MD5Hash(buffer);
                    }
                    tacStream.Write(buffer, 0, buffer.Length);
                }
                tadFile.Header.FileCount = fileCount;
                tadFile.Header.TacSize = (uint)tacStream.Length;
                tadFile.Header.UnixTimestamp = DateTime.UtcNow + TimeSpan.FromDays(365 * 5);
            }
            foreach(TADFileEntry entry in toRemove)
            {
                tadFile.FileEntries.Remove(entry);
            }

            Finished(this, new FinishedArgs(true));
        }

        public void Abort()
        {
            //throw new NotImplementedException();
        }
    }
}
