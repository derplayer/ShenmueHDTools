using ShenmueHDTools.Main.Files.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Nodes
{
    public class AFSEntry
    {
        public uint Offset { get; set; }
        public uint FileSize { get; set; }

        public uint Index { get; set; }

        public void Read(BinaryReader reader)
        {
            Offset = reader.ReadUInt32();
            FileSize = reader.ReadUInt32();
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(Offset);
            writer.Write(FileSize);
        }
    }

    public class AFSFile : FileNode, IArchiveNode
    {
        public AFSHeader Header { get; set; }

        private IDXFile m_idx;

        public AFSFile(CacheFile cacheFile, FileNode parent, string relativPath, bool newFile = false)
            : base(cacheFile, parent, relativPath, newFile)
        {
            if (newFile)
            {
                //Can't unpack if IDX is not present
                //For now let IDX carry out the unpacking
                //Unpack();
            }
        }

        public void Pack()
        {
            throw new NotImplementedException();
        }

        public void Unpack(IDXFile idx)
        {
            m_idx = idx;
            Unpack();
        }

        public void Unpack()
        {
            IDXFile idx = m_idx;
            /*
            if (Parent == null)
            {
                string search = RelativPath.Replace(".AFS", ".IDX");
                foreach (FileNode node in CacheFile.Files)
                {
                    if (node.RelativPath == search)
                    {
                        idx = (IDXFile)node;
                        break;
                    }
                }
            }
            else
            {
                idx = (IDXFile)Parent.Find(RelativPath.Replace(".AFS", ".IDX"));
            }
            */
            if (idx == null) return;
            idx.Read();

            Header = new AFSHeader();
            using (FileStream stream = File.Open(FullPath, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    Header.Read(reader);
                    List<AFSEntry> entries = new List<AFSEntry>();
                    uint index = 0;
                    for (int i = 0; i < Header.FileCount; i++)
                    {
                        AFSEntry entry = new AFSEntry();
                        entry.Read(reader);
                        entry.Index = index;
                        entries.Add(entry);
                        index++;
                    }

                    string outputFolder = Path.GetDirectoryName(FullPath) + "\\_" + Path.GetFileName(FullPath) + "_\\";
                    string dir = Path.GetDirectoryName(outputFolder);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    foreach (AFSEntry entry in entries)
                    {
                        IDXEntry idxEntry = idx.GetEntry(entry.Index);

                        reader.BaseStream.Seek(entry.Offset, SeekOrigin.Begin);
                        byte[] buffer = new byte[entry.FileSize];
                        reader.Read(buffer, 0, buffer.Length);

                        string extension = Helper.ExtensionFinder(buffer);

                        string filepath = "";
                        if (idxEntry == null)
                        {
                            filepath = outputFolder + entry.Index.ToString() + extension;
                        }
                        else
                        {
                            filepath = outputFolder + idxEntry.Filename + extension;
                        }
                        using (FileStream outStream = File.Create(filepath))
                        {
                            outStream.Write(buffer, 0, buffer.Length);
                        }

                        string relativPath = CacheFile.GetRelativePath(filepath);
                        Children.Add(CreateNode(CacheFile, this, relativPath));
                    }
                }
            }
        }
    }
}
