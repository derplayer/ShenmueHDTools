using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Nodes
{
    class GZMetaFile
    {
        
    }

    class GZFile : FileNode
    {
        public static readonly byte[] Identifier = new byte[2] { 0x1f, 0x8b };

        #region Metadata
        public byte[] CompressedHash { get; set; }
        public byte[] DecompresedHash { get; set; }
        public string RelativeOutputPath { get; set; }
        #endregion

        public GZFile(CacheFile cacheFile, FileNode parent, string relativPath)
            : base(cacheFile, parent, relativPath)
        {
            Decompress();
        }

        public void Compress()
        {
            //TODO
            using (FileStream originalFileStream = File.Open(FullPath, FileMode.Create))
            {
                using (FileStream compressedFileStream = File.Create(FullPath + ".GZ"))
                {
                    using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressionStream);
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
                stream.Seek(10, SeekOrigin.Begin);

                //reading filename from header
                byte ch = (byte)stream.ReadByte();
                string fName = "";
                while (ch != 0)
                {
                    fName += (char)ch;
                    ch = (byte)stream.ReadByte();
                }

                string outputFilename = Path.GetDirectoryName(FullPath) + "\\_" + Path.GetFileNameWithoutExtension(FullPath) + "_\\" + fName;
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
            }
        }

        public override void WriteMeta()
        {
            
        }

        public override void ReadMeta()
        {
            
        }
    }
}
