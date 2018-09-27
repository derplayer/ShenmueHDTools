using ShenmueHDTools.Main.Files.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Nodes
{
    public class PKSEntry
    {
        public string Filename { get; set; }
        public string Extension { get; set; }
        public uint Offset { get; set; }
        public uint FileSize { get; set; }

        public void Read(BinaryReader reader)
        {
            byte[] buffer = new byte[8];
            reader.Read(buffer, 0, 8);
            Filename = Encoding.ASCII.GetString(buffer).Replace("\0", "");

            buffer = new byte[4];
            reader.Read(buffer, 0, 4);
            Extension = Encoding.ASCII.GetString(buffer).Replace("\0", "");

            Offset = reader.ReadUInt32();
            FileSize = reader.ReadUInt32();
        }

        public void Write(BinaryWriter writer)
        {
            byte[] buffer = new byte[8];
            byte[] fBuffer = Encoding.ASCII.GetBytes(Filename);
            fBuffer.CopyTo(buffer, 0);
            writer.Write(buffer, 0, 8);

            buffer = new byte[4];
            fBuffer = Encoding.ASCII.GetBytes(Extension);
            fBuffer.CopyTo(buffer, 0);
            writer.Write(buffer, 0, 4);

            writer.Write(Offset);
            writer.Write(FileSize);
        }
    }

    public class PKSFile : FileNode, IArchiveNode
    {
        public PKSHeader Header { get; set; }

        public PKSFile(CacheFile cacheFile, FileNode parent, string relativPath, bool newFile = false)
            : base(cacheFile, parent, relativPath, newFile)
        {
            if (newFile)
            {
                Unpack();
            }
        }

        public void Pack()
        {
            if (Children.Count == 0) return; //unpack first

            bool anyModified = false;
            foreach (FileNode node in Children)
            {
                if (typeof(IArchiveNode).IsAssignableFrom(node.GetType()))
                {
                    ((IArchiveNode)node).Pack();
                }
                node.CalcChecksum();
                if (node.Modified) anyModified = true;
            }

            CalcChecksum();
            if (Modified)
            {
                //TODO check if self is modified and handle the situation
                throw new NotImplementedException();
            }

            if (anyModified)
            {
                List<PKSEntry> entries = new List<PKSEntry>();
                PKSHeader pksHeader = new PKSHeader();
                IPACHeader ipacHeader = new IPACHeader();

                //read current header
                using (FileStream peakStream = File.Open(FullPath, FileMode.Open))
                {
                    using (BinaryReader reader = new BinaryReader(peakStream))
                    {
                        pksHeader.Read(reader);
                        ipacHeader.Read(reader);
                    }
                }

                using (MemoryStream outStream = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(outStream))
                    {
                        pksHeader.Write(writer);
                        outStream.Seek(16, SeekOrigin.Current); //Skip IPAC header
                        
                        foreach (FileNode node in Children)
                        {
                            using (FileStream stream = File.Open(node.FullPath, FileMode.Create))
                            {
                                PKSEntry entry = new PKSEntry();
                                entry.Offset = (uint)outStream.Position - 16;
                                entry.Filename = Path.GetFileNameWithoutExtension(node.RelativPath);
                                entry.Extension = Path.GetExtension(node.RelativPath);
                                entry.FileSize = (uint)stream.Length;
                                entries.Add(entry);

                                byte[] buffer = new byte[stream.Length];
                                stream.Read(buffer, 0, buffer.Length);
                                writer.Write(buffer);
                            }
                        }

                        ipacHeader.ContentOffset = (uint)outStream.Position - 16;
                        ipacHeader.ContentSize = (uint)outStream.Position - 16;
                        ipacHeader.FileCount = (uint)Children.Count;

                        foreach (PKSEntry entry in entries)
                        {
                            entry.Write(writer);
                        }

                        outStream.Seek(16, SeekOrigin.Begin);
                        ipacHeader.Write(writer);
                    }

                    //Compress
                    using (FileStream compressedFileStream = File.Create(FullPath))
                    {
                        using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress, false))
                        {
                            outStream.CopyTo(compressedFileStream);
                        }
                    }
                }
            }
        }

        public void Unpack()
        {
            Header = new PKSHeader();
            using (FileStream stream = File.Open(FullPath, FileMode.Open))
            {
                byte[] identifier = new byte[2];
                stream.Read(identifier, 0, 2);
                if (GZHeader.IsValid(identifier))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    using (GZipStream streamGZip = new GZipStream(stream, CompressionMode.Decompress))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            streamGZip.CopyTo(memoryStream);
                            using (BinaryReader reader = new BinaryReader(memoryStream))
                            {
                                Read(reader);
                            }
                        }
                    }
                }
                else
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        Read(reader);
                    }
                }
            }
        }

        private void Read(BinaryReader reader)
        {
            Header.Read(reader);
            reader.BaseStream.Seek(Header.IPACOffset + 4, SeekOrigin.Begin);

            uint dictionaryOffset = reader.ReadUInt32();
            uint fileCount = reader.ReadUInt32();

            List<PKSEntry> entries = new List<PKSEntry>();

            reader.BaseStream.Seek(dictionaryOffset + Header.IPACOffset, SeekOrigin.Begin);
            for (int i = 0; i < fileCount; i++)
            {
                PKSEntry entry = new PKSEntry();
                entry.Read(reader);
                entries.Add(entry);
            }

            string outputFolder = Path.GetDirectoryName(FullPath) + "\\_" + Path.GetFileName(FullPath) + "_\\";
            string dir = Path.GetDirectoryName(outputFolder);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            foreach (PKSEntry entry in entries)
            {
                reader.BaseStream.Seek(entry.Offset + Header.IPACOffset, SeekOrigin.Begin);

                byte[] buffer = new byte[entry.FileSize];
                reader.Read(buffer, 0, buffer.Length);

                string filepath = outputFolder + entry.Filename + "." + entry.Extension;
                using (FileStream stream = File.Create(filepath))
                {
                    stream.Write(buffer, 0, buffer.Length);
                }

                string relativPath = CacheFile.GetRelativePath(filepath);
                Children.Add(CreateNode(CacheFile, this, relativPath));
            }
        }
    }
}
