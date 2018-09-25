using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class PKSHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x50, 0x41, 0x4B, 0x53 }; //PAKS
        public static readonly FileNode.FileType Type = FileNode.FileType.PKS;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }

        public byte[] SignatureBuffer { get; set; }
        public uint IPACOffset { get; set; }
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }

        public void Read(BinaryReader reader)
        {
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            SignatureBuffer = new byte[4];
            reader.Read(SignatureBuffer, 0 ,4);
            IPACOffset = reader.ReadUInt32();
            Unknown1 = reader.ReadUInt32();
            Unknown2 = reader.ReadUInt32();
        }
    }
}
