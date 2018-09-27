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
    public class PKFFile : FileNode, IArchiveNode
    {
        public PKFHeader Header { get; set; }

        public PKFFile(CacheFile cacheFile, FileNode parent, string relativPath, bool newFile = false)
            : base(cacheFile, parent, relativPath, newFile)
        {
            if (newFile)
            {
                Unpack();
            }
        }

        public void Unpack()
        {
            Header = new PKFHeader();
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
                PKFHeader pksHeader = new PKFHeader();
                //read current header
                using (FileStream peakStream = File.Open(FullPath, FileMode.Open))
                {
                    using (BinaryReader reader = new BinaryReader(peakStream))
                    {
                        pksHeader.Read(reader);
                    }
                }

                using (MemoryStream outStream = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(outStream))
                    {
                        outStream.Seek(16, SeekOrigin.Begin); //Skip PKSHeader

                        foreach (FileNode node in Children)
                        {
                            using (FileStream stream = File.Open(node.FullPath, FileMode.Create))
                            {
                                byte[] buffer = new byte[stream.Length];
                                stream.Read(buffer, 0, buffer.Length);
                                writer.Write(buffer);
                            }
                        }

                        pksHeader.ContentSize = (uint)outStream.Length;
                        pksHeader.FileCount = (uint)Children.Count;
                        outStream.Seek(0, SeekOrigin.Begin);
                        pksHeader.Write(writer);
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

        private void Read(BinaryReader reader)
        {
            Header.Read(reader);

            if (reader.ReadUInt32() == 0x594D5544)
            {
                //Skip DUMY
                reader.BaseStream.Seek(36, SeekOrigin.Begin);
            }
            else
            {
                reader.BaseStream.Seek(-4, SeekOrigin.Current);
            }

            string outputFolder = Path.GetDirectoryName(FullPath) + "\\_" + Path.GetFileName(FullPath) + "_\\";
            string dir = Path.GetDirectoryName(outputFolder);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            for (int i = 0; i < Header.FileCount; i++)
            {
                if (reader.BaseStream.Position == reader.BaseStream.Length) break;
                uint token = reader.ReadUInt32();
                if (token == 0x4E584554)
                {
                    reader.BaseStream.Seek(-4, SeekOrigin.Current);
                    TEXNEntry entry = new TEXNEntry();
                    entry.Read(reader);

                    byte[] buffer = new byte[entry.EntrySize - 16];
                    reader.Read(buffer, 0, buffer.Length);

                    string extension = Helper.ExtensionFinder(buffer);

                    string filepath = outputFolder + entry.Filename + extension;
                    using (FileStream stream = File.Create(filepath))
                    {
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    string relativPath = CacheFile.GetRelativePath(filepath);
                    Children.Add(CreateNode(CacheFile, this, relativPath));
                }
                else
                {
                    uint fileSize = reader.ReadUInt32();
                    reader.BaseStream.Seek(-8, SeekOrigin.Current);

                    byte[] buffer = new byte[fileSize];
                    reader.Read(buffer, 0, buffer.Length);

                    string extension = Helper.ExtensionFinder(buffer);

                    string filepath = outputFolder + i.ToString() + "." + extension;
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
}
