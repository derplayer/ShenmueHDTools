using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Headers;
using System.IO;
using System.Security.Cryptography;

namespace ShenmueHDTools.Main.Files
{
    class TADFile
    {
        public static readonly string Extension = ".tad";

        public List<TADFileEntry> FileEntries = new List<TADFileEntry>();
        public TADHeader Header = new TADHeader();

        public TADFile() { }
        public TADFile(string filename)
        {
            Read(filename);
        }

        /// <summary>
        /// Reads the specified filename inside the current object.
        /// </summary>
        /// <param name="filename">The TAD filename</param>
        public bool Read(string filename, bool includeMeta = false)
        {
            if (Path.GetExtension(filename).ToLower() != Extension) return false;
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
                FileEntries.Add(entry);
            }
        }

        /// <summary>
        /// Writes the current object to the specified filename.
        /// </summary>
        /// <param name="filename">The TAD filename.</param>
        public void Write(string filename, bool includeMeta = false)
        {
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
            foreach (TADFileEntry entry in FileEntries)
            {
                entry.Write(writer, includeMeta);
            }
        }

        public double GetStatisticPercentage()
        {
            int counter = 0;
            foreach (TADFileEntry entry in FileEntries)
            {
                if (String.IsNullOrEmpty(entry.Filename)) continue;
                counter++;
            }
            return Math.Round((float)counter / (float)FileEntries.Count * 100.0f, 2);
        }

        public void PrintStatistic(bool verbose = false)
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
            
            Console.WriteLine("\n##########################\n");
        }
    }


    /// <summary>
    /// File entry inside the TAD file (32 Bytes)
    /// </summary>
    class TADFileEntry
    {
        /// <summary>
        /// The TAD file entry size in bytes.
        /// </summary>
        public static readonly ushort TADEntrySize = 32;
        public uint FirstHash { get; set; }
        public uint SecondHash { get; set; }
        public uint Unknown { get; set; }

        /// <summary>
        /// Offset inside the TAC file.
        /// </summary>
        public uint FileOffset { get; set; }
        public uint FileSize { get; set; }

        #region MetaData

        public byte[] MD5Checksum { get; set; } = new byte[32];
        public string Filename { get; set; } = "";
        public string RelativePath { get; set; } = "";

        #region Runtime Flags

        public bool Export { get; set; }
        public bool Modified { get; set; }

        #endregion

        #endregion


        public TADFileEntry() { }
        public TADFileEntry(byte[] data, bool includeMeta = false)
        {
            Read(data);
        }

        public bool CheckMD5(string filename)
        {
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
                MD5Checksum = reader.ReadBytes(32);

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
                    RelativePath = Encoding.ASCII.GetString(relativePathBuffer);
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
                int metaDataSize = 32 + 4 + Filename.Length + 4 + RelativePath.Length;
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
                        writer.Write(MD5Checksum, 0, 32);

                        byte[] filenameBytes = Encoding.ASCII.GetBytes(Filename);
                        writer.Write((uint)filenameBytes.Length);
                        if (filenameBytes.Length > 0)
                        {
                            writer.Write(filenameBytes, 0, filenameBytes.Length);
                        }

                        byte[] relativePathBytes = Encoding.ASCII.GetBytes(RelativePath);
                        writer.Write((uint)relativePathBytes.Length);
                        if (relativePathBytes.Length > 0)
                        {
                            writer.Write(relativePathBytes, 0, relativePathBytes.Length);
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
                return String.Format("[{0}{1}{2}] Offset: {3}, Size: {4}", FirstHash.ToString("X8"), SecondHash.ToString("X8"),
                    Unknown.ToString("X8"), FileOffset, FileSize);
            }
            else
            {
                return String.Format("[{0}{1}{2}] Offset: {3}, Size: {4}, Filename:{5}", FirstHash.ToString("X8"), SecondHash.ToString("X8"),
                    Unknown.ToString("X8"), FileOffset, FileSize, Filename);
            }
        }
    }
}
