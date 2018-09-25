using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Nodes
{
    class GZFile : FileNode, IArchiveNode
    {
        public static readonly byte[] Identifier = new byte[2] { 0x1f, 0x8b };

        public GZFile(CacheFile cacheFile, FileNode parent, string relativPath, bool newFile = false)
            : base(cacheFile, parent, relativPath, newFile)
        {
            if (newFile)
            {
                Decompress();
            }
        }

        public void Unpack()
        {
            Decompress();
        }

        public void Pack()
        {
            Compress();
        }

        public void Compress()
        {
            if (Children.Count == 0) return; //unpack first

            FileNode unpackedFile = Children.First();
            unpackedFile.CalcChecksum();
            if (unpackedFile.Modified)
            {
                //Compress
                using (FileStream originalFileStream = File.Open(unpackedFile.FullPath, FileMode.Create))
                {
                    using (FileStream compressedFileStream = File.Create(FullPath))
                    {
                        using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                        {
                            originalFileStream.CopyTo(compressionStream);
                        }
                    }
                }
            }
        }

        public void Decompress()
        {
            using (FileStream stream = File.Open(FullPath, FileMode.Open))
            {
                byte[] identifier = new byte[2];
                stream.Read(identifier, 0, 2);
                if (Identifier[0] != identifier[0] ||
                    Identifier[1] != identifier[1])
                {
                    return;
                }
                //skipping header and living on the edge
                //TODO read header correctly
                stream.Seek(10, SeekOrigin.Begin);

                //reading filename from header
                byte ch = (byte)stream.ReadByte();
                string fName = "";
                while (ch != 0)
                {
                    fName += (char)ch;
                    ch = (byte)stream.ReadByte();
                }

                string outputFilename = Path.GetDirectoryName(FullPath) + "\\_" + Path.GetFileName(FullPath) + "_\\" + fName;
                string dir = Path.GetDirectoryName(outputFilename);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                stream.Seek(0, SeekOrigin.Begin);
                using (FileStream streamOut = File.Create(outputFilename))
                {
                    using (GZipStream streamGZip = new GZipStream(stream, CompressionMode.Decompress))
                    {
                        streamGZip.CopyTo(streamOut);
                    }
                }
                string relativPath = CacheFile.GetRelativePath(outputFilename);
                Children.Add(CreateNode(CacheFile, this, relativPath));
            }
        }
    }
}
