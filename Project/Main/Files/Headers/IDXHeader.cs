using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class IDXHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x49, 0x44, 0x58, 0x30 }; //IDX0
        public static readonly FileNode.FileType Type = FileNode.FileType.IDX;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }

        public byte[] SignatureBuffer { get; set; }
        public ushort EntryCountSelf { get; set; }
        public ushort EntryCount { get; set; }

        public void Read(BinaryReader reader)
        {
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            SignatureBuffer = new byte[4];
            reader.Read(SignatureBuffer, 0, 4);
            EntryCountSelf = reader.ReadUInt16();
            EntryCount = reader.ReadUInt16();
            reader.BaseStream.Seek(12, SeekOrigin.Current);
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(Signature, 0, 4);
            writer.Write(EntryCountSelf);
            writer.Write(EntryCount);

            byte[] padding = new byte[12];
            writer.Write(padding, 0, padding.Length);
        }
    }
}
