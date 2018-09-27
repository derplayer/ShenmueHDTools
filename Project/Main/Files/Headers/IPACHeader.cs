using ShenmueHDTools.Main.Files.Nodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class IPACHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x50, 0x41, 0x4B, 0x53 }; //IPAC
        public static readonly FileNode.FileType Type = FileNode.FileType.IPAC;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }

        public byte[] SignatureBuffer { get; set; }
        public uint ContentOffset { get; set; }
        public uint FileCount { get; set; }
        public uint ContentSize { get; set; }

        public void Read(BinaryReader reader)
        {
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            SignatureBuffer = new byte[4];
            reader.Read(SignatureBuffer, 0, 4);
            ContentOffset = reader.ReadUInt32();
            FileCount = reader.ReadUInt32();
            ContentSize = reader.ReadUInt32();
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(Signature, 0, 4);
            writer.Write(ContentOffset);
            writer.Write(FileCount);
            writer.Write(ContentSize);
        }
    }
}
