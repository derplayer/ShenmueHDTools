using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Nodes
{
    public class TEXNEntry
    {
        private static Encoding m_shiftJis = Encoding.GetEncoding("shift_jis"); //possible candidate

        public static byte[] Identifier = new byte[4] { 0x54, 0x45, 0x58, 0x4E };
        
        public uint EntrySize { get; set; }
        public string Filename { get; set; }

        public void Read(BinaryReader reader)
        {
            reader.BaseStream.Seek(4, SeekOrigin.Current);
            EntrySize = reader.ReadUInt32();

            byte[] buffer = new byte[8];
            reader.Read(buffer, 0, 8);

            string hexString = Helper.ByteArrayToString(buffer);
            //byte[] reversedBuffer = Helper.ReverseBytes(buffer);
            string filename = Helper.RemoveIllegalCharacters(m_shiftJis.GetString(buffer).Replace("\0", ""));

            Filename = filename + "." + hexString;
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(Identifier, 0, 4);
            writer.Write(EntrySize);

            byte[] buffer = new byte[8];
            byte[] fBuffer = Helper.StringToByteArray(Filename.Split('.')[1]);
            fBuffer.CopyTo(buffer, 0);
            writer.Write(buffer, 0, 8);
        }
    }

    public class SPRFile : FileNode, IArchiveNode
    {
        public SPRFile(CacheFile cacheFile, FileNode parent, string relativPath, bool newFile = false)
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
            foreach(FileNode node in Children)
            {
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
                using (FileStream outStream = File.Create(FullPath))
                {
                    using (BinaryWriter writer = new BinaryWriter(outStream))
                    {
                        foreach (FileNode node in Children)
                        {
                            using (FileStream stream = File.Open(node.FullPath, FileMode.Create))
                            {
                                TEXNEntry entry = new TEXNEntry();
                                entry.EntrySize = (uint)stream.Length;
                                entry.Filename = Path.GetFileName(node.RelativPath);
                                entry.Write(writer);

                                byte[] buffer = new byte[stream.Length];
                                stream.Read(buffer, 0, buffer.Length);
                                writer.Write(buffer);
                            }
                        }
                    }
                }
            }
        }

        public void Unpack()
        {
            using (FileStream stream = File.Open(FullPath, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    Read(reader);
                }
            }
        }

        private void Read(BinaryReader reader)
        {
            string outputFolder = Path.GetDirectoryName(FullPath) + "\\_" + Path.GetFileName(FullPath) + "_\\";
            string dir = Path.GetDirectoryName(outputFolder);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            int i = 0;
            while(reader.BaseStream.CanRead)
            {
                if (reader.BaseStream.Position == reader.BaseStream.Length) break;
                uint token = reader.ReadUInt32();
                if (reader.BaseStream.Position == reader.BaseStream.Length) break;
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
                    reader.BaseStream.Seek(4, SeekOrigin.Current);
                    if (reader.BaseStream.Position == reader.BaseStream.Length) break;
                    uint entrySize = reader.ReadUInt32();
                    reader.BaseStream.Seek(-4, SeekOrigin.Current);
                    byte[] buffer = new byte[entrySize];
                    reader.Read(buffer, 0, buffer.Length);

                    string extension = Helper.ExtensionFinder(buffer);

                    string filepath = outputFolder + i.ToString() + extension;
                    using (FileStream stream = File.Create(filepath))
                    {
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    string relativPath = CacheFile.GetRelativePath(filepath);
                    Children.Add(CreateNode(CacheFile, this, relativPath));
                    //break;
                }
                i++;
            }
        }

    }
}
