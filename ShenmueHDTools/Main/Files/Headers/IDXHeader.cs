using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public enum IDXType
    {
        IDX0,
        IDXD,
        IDXC,
        IDXB,
        HUMANS
    }

    public class IDXHeader
    {
        private static readonly List<byte[]> Signatures = new List<byte[]>()
        {
            new byte[] { 0x49, 0x44, 0x58, 0x30 }, //IDX0
            new byte[] { 0x49, 0x44, 0x58, 0x44 }, //IDXD
            new byte[] { 0x49, 0x44, 0x58, 0x43 }, //IDXC
            new byte[] { 0x49, 0x44, 0x58, 0x42 }, //IDXB
        };
        public static readonly FileNode.FileType Type = FileNode.FileType.IDX;
        public static bool IsValid(byte[] buffer)
        {
            foreach (byte[] signature in Signatures)
            {
                if (Helper.CompareSignature(signature, buffer)) return true;
            }
            return false;
        }

        public byte[] SignatureBuffer { get; set; }
        public ushort EntryCountSelf { get; set; }
        public ushort EntryCount { get; set; }
        public IDXType IDXType { get; set; }
        public uint Unknown { get; set; }

        private IDXType GetIDXType(byte[] data)
        {
            if (Helper.CompareSignature(Signatures[0], data)) return IDXType.IDX0;
            if (Helper.CompareSignature(Signatures[1], data)) return IDXType.IDXD;
            if (Helper.CompareSignature(Signatures[2], data)) return IDXType.IDXC;
            if (Helper.CompareSignature(Signatures[3], data)) return IDXType.IDXB;
            return IDXType.HUMANS;
        }

        public void Read(BinaryReader reader)
        {
            SignatureBuffer = reader.ReadBytes(4);
            IDXType = GetIDXType(SignatureBuffer);

            if (IDXType == IDXType.HUMANS)
            {
                reader.BaseStream.Seek(-4, SeekOrigin.Current);
                EntryCount = reader.ReadUInt16();
            }
            else if (IDXType == IDXType.IDXD)
            {
                Unknown = reader.ReadUInt32();
                EntryCountSelf = reader.ReadUInt16();
                EntryCount = reader.ReadUInt16();
                reader.BaseStream.Seek(4, SeekOrigin.Current);
            }
            else if (IDXType == IDXType.IDXC)
            {
                Unknown = reader.ReadUInt32();
                EntryCountSelf = reader.ReadUInt16();
                EntryCount = reader.ReadUInt16();
                reader.BaseStream.Seek(4, SeekOrigin.Current);
            }
            else if (IDXType == IDXType.IDXB)
            {
                Unknown = reader.ReadUInt32();
                EntryCountSelf = reader.ReadUInt16();
                EntryCount = reader.ReadUInt16();
                reader.BaseStream.Seek(4, SeekOrigin.Current);
            }
            else
            {
                EntryCountSelf = reader.ReadUInt16();
                EntryCount = reader.ReadUInt16();
                reader.BaseStream.Seek(12, SeekOrigin.Current);
            }
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(SignatureBuffer, 0, 4);
            writer.Write(EntryCountSelf);
            writer.Write(EntryCount);

            byte[] padding = new byte[12];
            writer.Write(padding, 0, padding.Length);
        }
    }
}
