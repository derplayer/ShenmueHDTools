using ShenmueHDTools.Main.Files.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShenmueHDTools.Main.Files.Nodes
{
    public class IDXEntry
    {
        public string Filename { get; set; }
        public ushort AFSIndex { get; set; }
        public ushort AFSLastIndex { get; set; }
        public uint Unknown { get; set; }

        public void Read(BinaryReader reader)
        {
            byte[] buffer = new byte[12];
            reader.Read(buffer, 0, 12);
            Filename = Encoding.ASCII.GetString(buffer).Replace("\0", "");

            AFSIndex = reader.ReadUInt16();
            AFSLastIndex = reader.ReadUInt16();
            Unknown = reader.ReadUInt32();
        }

        public void Write(BinaryWriter writer)
        {
            byte[] buffer = new byte[12];
            byte[] fBuffer = Encoding.ASCII.GetBytes(Filename);
            fBuffer.CopyTo(buffer, 0);
            writer.Write(buffer, 0, 12);

            writer.Write(AFSIndex);
            writer.Write(AFSLastIndex);
            writer.Write(Unknown);
        }
    }

    public class IDXFile : FileNode
    {
        public IDXHeader Header { get; set; }
        public List<IDXEntry> Entries { get; set; } = new List<IDXEntry>();

        public IDXFile(CacheFile cacheFile, FileNode parent, string relativPath, bool newFile = false)
            : base(cacheFile, parent, relativPath, newFile)
        {
            if (newFile)
            {
                AFSFile afs = null;
                if (parent == null)
                {
                    string search = RelativPath.Replace(".IDX", ".AFS");
                    foreach (FileNode node in CacheFile.Files)
                    {
                        if (node.RelativPath == search)
                        {
                            afs = (AFSFile)node;
                            break;
                        }
                    }
                }
                else
                {
                    afs = (AFSFile)parent.Find(RelativPath.Replace(".IDX", ".AFS"));
                }
                if (afs == null) return; //should not happen because of alphabetical order
                afs.Unpack(this);
            }
        }

        public IDXEntry GetEntry(uint index)
        {
            foreach(IDXEntry entry in Entries)
            {
                if (entry.AFSIndex == index) return entry;
            }
            return null;
        }

        public void Read()
        {
            Header = new IDXHeader();
            Entries.Clear();
            using (FileStream stream = File.Open(FullPath, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    Header.Read(reader);
                    for (int i = 0; i < Header.EntryCount; i++)
                    {
                        IDXEntry entry = new IDXEntry();
                        entry.Read(reader);
                        Entries.Add(entry);
                    }
                }
            }
        }
    }
}
