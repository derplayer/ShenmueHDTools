using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ShenmueHDTools.Main.Database;

namespace ShenmueHDTools.Main.Files
{

    class TACFile
    {
        public static readonly string Extension = ".tac";

        private byte[] m_buffer;
        private TADFile m_tadFile;

        public byte[] GetFileFromEntry(FilenameDatabaseEntry dbEntry, out bool found)
        {
            uint offset = 0;
            uint size = 0;
            foreach (TADFileEntry entry in m_tadFile.FileEntries)
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
            if (m_buffer.Length == 0) return new byte[0];

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
            m_tadFile = tadFile;
            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                m_buffer = new byte[stream.Length];
                stream.Read(m_buffer, 0, m_buffer.Length);
            }
        }

        public static void Unpack(string filename)
        {
            string outputFolder = String.Format("{0}\\_{1}_", Path.GetDirectoryName(filename), Path.GetFileName(filename));
            Unpack(filename, outputFolder);
        }

        public static void Unpack(string filename, string outputFolder)
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
        public static bool Unpack(string filename, string outputFolder, TADFile tadFile)
        {
            if (Path.GetExtension(filename).ToLower() != Extension) return false;
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }
            using (FileStream tacStream = File.Open(filename, FileMode.Open))
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
                        string Extension = Helper.ExtensionFinder(fileBuffer);
                        string fileEntryName = String.Format("{0}{1}", counter.ToString(), Extension);
                        fileEntryPath = Path.Combine(outputFolder, fileEntryName);
                    }
                    else
                    {
                        fileEntryPath = entry.Filename.Replace('/', '\\');
                        fileEntryPath = outputFolder + "\\" + fileEntryPath;
                        fileEntryPath = SwitchExtension(fileEntryPath);

                        string dir = Path.GetDirectoryName(fileEntryPath);
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }
                    }
                    
                    using (FileStream fileEntryStream = File.Create(fileEntryPath))
                    {
                        entry.RelativePath = GetRelativePath(fileEntryStream.Name, outputFolder);
                        fileEntryStream.Write(fileBuffer, 0, fileBuffer.Length);
                    }

                    counter++;
                }
            }
            return true;
        }

        /// <summary>
        /// Packs the TAC file and changes the input TAD file accordingly.
        /// </summary>
        /// <param name="filename">The TAC filename.</param>
        /// <param name="inputFolder">The TAC extraction folder.</param>
        /// <param name="tadFile">The TAD file.</param>
        public static void Pack(string filename, string inputFolder, TADFile tadFile)
        {
            using (FileStream tacStream = File.Create(filename))
            {
                uint fileCount = 0;
                foreach (TADFileEntry entry in tadFile.FileEntries)
                {
                    if (!entry.Export) continue; //skip tad entries that are not flagged for exporting.

                    fileCount++;

                    if (String.IsNullOrEmpty(entry.RelativePath))
                    {
                        Console.WriteLine("TAC was not unpacked before!");
                        break;
                    }

                    string sourceFilename = String.Format("{0}\\{1}", inputFolder, entry.RelativePath);

                    byte[] buffer;
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
                tadFile.Header.UnixTimestamp = DateTime.UtcNow;
            }
        }

        /// <summary>
        /// Switches the extension with the hash vice versa
        /// </summary>
        private static string SwitchExtension(string input)
        {
            string originalInput = input;
            int cutOffLength = input.LastIndexOf('.');
            if (input.Substring(cutOffLength).Length == 9)
            {
                string hash = input.Substring(cutOffLength + 1);
                input = input.Substring(0, cutOffLength);
                string extension = Path.GetExtension(input);
                cutOffLength = input.LastIndexOf('.');
                input = input.Substring(0, cutOffLength + 1) + hash + extension;
                return input;
            }
            else
            {
                string extension = input.Substring(cutOffLength + 1);
                input = input.Substring(0, cutOffLength);
                string hash = Path.GetExtension(input);
                if (hash.Length != 9) return originalInput;
                cutOffLength = input.LastIndexOf('.');
                input = input.Substring(0, cutOffLength + 1) + extension + hash;
                return input;
            }
        }

        private static string GetRelativePath(string filename, string folder)
        {
            Uri pathUri = new Uri(filename);
            if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                folder += Path.DirectorySeparatorChar;
            }
            Uri folderUri = new Uri(folder);
            return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }
    }
}
