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
        private readonly static Encoding m_shiftJis = Encoding.GetEncoding("shift_jis");

        public string Filename { get; set; }
        public ushort AFSIndex { get; set; }
        public ushort AFSLastIndex { get; set; }
        public uint Unknown { get; set; }
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }
        public IDXType IDXType { get; set; }

        public void Read(BinaryReader reader)
        {
            byte[] buffer = new byte[12];
            reader.Read(buffer, 0, 12);
            Filename = m_shiftJis.GetString(buffer).Replace("\0", "");

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

        private static Encoding m_shiftJis = Encoding.GetEncoding("shift_jis"); //possible candidate

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
                if (afs == null) return; //should not happen because of etical order
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

        public void Write()
        {
            using (FileStream stream = File.Create(FullPath))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    Header.EntryCount = (ushort)Children.Count;
                    Header.EntryCountSelf = (ushort)(Children.Count + 1);
                    Header.Write(writer);

                    //TODO HUMANS.IDX case

                    foreach (IDXEntry entry in Entries)
                    {
                        entry.Write(writer);
                    }
                }
            }
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
                    if (Header.IDXType == IDXType.HUMANS)
                    {
                        uint fileCount = Header.EntryCount;
                        for (int i = 0; i < fileCount; i++)
                        {
                            IDXEntry entry = new IDXEntry();
                            entry.AFSIndex = (ushort)i;
                            byte[] buffer = new byte[4];
                            reader.Read(buffer, 0, 4);
                            entry.Filename = Encoding.ASCII.GetString(buffer).Replace("\0", "");
                            Entries.Add(entry);
                        }
                    }
                    else if (Header.IDXType == IDXType.IDXD)
                    {
                        reader.BaseStream.Seek(8, SeekOrigin.Current); //SKIP TABL
                        uint fileCount = Header.EntryCount;
                        for (int i = 0; i < fileCount; i++)
                        {
                            IDXEntry entry = new IDXEntry();
                            entry.AFSIndex = (ushort)i;
                            entry.Unknown = reader.ReadUInt32();
                            byte[] buffer = reader.ReadBytes(4);
                            entry.Filename = Encoding.ASCII.GetString(buffer).Replace("\0", "");
                            Entries.Add(entry);
                        }
                    }
                    else if (Header.IDXType == IDXType.IDXC)
                    {
                        reader.BaseStream.Seek(8, SeekOrigin.Current); //SKIP TABL
                        uint fileCount = Header.EntryCount;
                        for (int i = 0; i < fileCount; i++)
                        {
                            IDXEntry entry = new IDXEntry();
                            entry.AFSIndex = (ushort)i;
                            entry.Unknown = reader.ReadUInt32();
                            byte[] buffer = reader.ReadBytes(4);
                            entry.Filename = Encoding.ASCII.GetString(buffer).Replace("\0", "");
                            entry.Unknown2 = reader.ReadUInt32();
                            Entries.Add(entry);
                        }
                    }
                    else if (Header.IDXType == IDXType.IDXB)
                    {
                        reader.BaseStream.Seek(8, SeekOrigin.Current); //SKIP TABL
                        uint fileCount = Header.EntryCount;
                        for (int i = 0; i < fileCount; i++)
                        {
                            IDXEntry entry = new IDXEntry();
                            entry.AFSIndex = (ushort)i;
                            entry.Unknown = reader.ReadUInt32();
                            byte[] buffer = reader.ReadBytes(4);
                            entry.Filename = Encoding.ASCII.GetString(buffer).Replace("\0", "");
                            entry.Unknown2 = reader.ReadUInt32();
                            entry.Unknown3 = reader.ReadUInt32();
                            Entries.Add(entry);
                        }
                    }
                    else
                    {
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
}
