using ShenmueHDTools.Main.Files.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueDKSharp.Files.Containers;

namespace ShenmueHDTools.Main.Files.Nodes
{

    public class AFSFile : FileNode, IArchiveNode
    {
        public AFSHeader Header { get; set; }

        public AFSFile(CacheFile cacheFile, FileNode parent, string relativPath, bool newFile = false)
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
                AFS afs = new AFS();
                afs.FileCount = (uint)Children.Count;
                foreach(FileNode node in Children)
                {
                    using (FileStream stream = File.Open(node.FullPath, FileMode.Create))
                    {
                        AFSEntry entry = new AFSEntry();
                        entry.EntryDateTime = DateTime.Now;
                        entry.Filename = Path.GetFileNameWithoutExtension(node.RelativPath);
                        entry.FileSize = (uint)stream.Length;

                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        entry.Buffer = buffer;

                        afs.Entries.Add(entry);
                    }
                }
                afs.Write(FullPath);
            }
        }

        public void Unpack()
        {
            string outputFolder = Path.GetDirectoryName(FullPath) + "\\_" + Path.GetFileName(FullPath) + "_\\";
            string dir = Path.GetDirectoryName(outputFolder);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            AFS afs = new AFS(FullPath);
            foreach (AFSEntry entry in afs.Entries)
            {
                string extension = Helper.ExtensionFinder(entry.Buffer);

                string filepath = "";
                filepath = outputFolder + entry.Filename + extension;

                using (FileStream outStream = File.Create(filepath))
                {
                    outStream.Write(entry.Buffer, 0, entry.Buffer.Length);
                }

                string relativPath = CacheFile.GetRelativePath(filepath);
                FileNode node = CreateNode(CacheFile, this, relativPath);
                Children.Add(node);
            }
        }

    }
}
