using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShenmueHDTools.Main.Files.Nodes.FileNode;

namespace ShenmueHDTools.Main.Files.Headers
{
    public abstract class Header
    {
        public abstract byte[] Signature { get; }
        public abstract FileType Type { get; }
        public bool IsValid(byte[] buffer)
        {
            for (int i = 0; i < Signature.Length; i++)
            {
                if (buffer[i] != Signature[i]) return false;
            }
            return true;
        }
    }

    public static class Headers
    {
        public static List<Header> HeaderList = new List<Header>
        {
            new GZHeader(),
            new AFSHeader(),
            new DDSHeader(),
            new HLSLHeader(),
            new IDXHeader(),
            new MT5Header(),
            new PKFHeader(),
            new PKSHeader(),
            new PVRHeader(),
            new SNDHeader(),
            new SPRHeader(),
            new WAVHeader()
        };

        /// <summary>
        /// [UNUSED] Will replace the Helper ExtensionFinder
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static FileType GetType(string filename)
        {
            int minBytes = 64;
            byte[] buffer;
            if (!File.Exists(filename)) return FileType.UNKNOWN;
            if (!Helper.IsFileValid(filename)) return FileType.UNKNOWN;
            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                if (stream.Length < minBytes)
                {
                    minBytes = (int)stream.Length;
                }
                buffer = new byte[minBytes];
                stream.Read(buffer, 0, minBytes);
            }
            return GetType(buffer);
        }

        /// <summary>
        /// [UNUSED] Will replace the Helper ExtensionFinder
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static FileType GetType(byte[] buffer)
        {
            foreach (Header header in HeaderList)
            {
                if (header.IsValid(buffer)) return header.Type;
            }
            return FileType.UNKNOWN;
        }
    }
}
