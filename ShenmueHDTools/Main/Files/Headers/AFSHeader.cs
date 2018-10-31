using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class AFSHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x41, 0x46, 0x53, 0x00 }; //AFS
        public static readonly FileNode.FileType Type = FileNode.FileType.AFS;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }

        public byte[] SignatureBuffer { get; set; }
        public uint FileCount { get; set; }

        public void Read(BinaryReader reader)
        {
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            SignatureBuffer = new byte[4];
            reader.Read(SignatureBuffer, 0, 4);
            FileCount = reader.ReadUInt32();
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(Signature, 0, 4);
            writer.Write(FileCount);
        }
    }
}
