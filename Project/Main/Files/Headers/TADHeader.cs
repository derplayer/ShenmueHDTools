using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class TADHeader
    {
        /// <summary>
        /// The TAD header size in bytes.
        /// </summary>
        public static readonly ushort TADHeaderSize = 56;

        public uint FileType { get; set; } = 1;
        public uint Identifier1 { get; set; } = 5;
        public uint Identifier2 { get; set; } = 2;
        public DateTime UnixTimestamp { get; set; } = DateTime.UtcNow;
        public string RenderType { get; set; } = "dx11";
        public uint HeaderChecksum { get; set; } = 0;
        public uint TacSize { get; set; } = 0;
        public uint FileCount { get; set; } = 0;

        public void CalcHeaderChecksum()
        {
            HeaderChecksum = MurmurHash2Shenmue.Hash(GetBytes(true), TADHeaderSize);
        }

        public void Read(BinaryReader reader)
        {
            FileType = reader.ReadUInt32();
            Identifier1 = reader.ReadUInt32();
            Identifier2 = reader.ReadUInt32();
            reader.ReadUInt32();
            UnixTimestamp = new DateTime(1970, 1, 1).AddSeconds(reader.ReadInt32());
            reader.ReadUInt32();
            char[] typeBuffer = new char[4];
            reader.Read(typeBuffer, 0, 4);
            RenderType = new string(typeBuffer);
            reader.ReadUInt32();
            HeaderChecksum = reader.ReadUInt32();
            reader.ReadUInt32();
            TacSize = reader.ReadUInt32();
            reader.ReadUInt32();
            FileCount = reader.ReadUInt32();
        }

        public void Read(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    Read(reader);
                }
            }
        }

        public void Write(BinaryWriter writer, bool writeLastFilecount = true)
        {
            CalcHeaderChecksum();
            writer.Write(GetBytes(), 0, TADHeaderSize);
            if (writeLastFilecount)
            {
                writer.Write(FileCount);
            }
        }

        public byte[] GetBytes(bool nullHash = false)
        {
            byte[] result = new byte[TADHeaderSize];

            using (MemoryStream stream = new MemoryStream(result))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(FileType);
                    writer.Write(Identifier1);
                    writer.Write(Identifier2);
                    writer.Write(0);
                    writer.Write(BitConverter.GetBytes((Int32)(UnixTimestamp.Subtract(new DateTime(1970, 1, 1))).TotalSeconds), 0, 4);
                    writer.Write(0);
                    byte[] renderTypeBytes = Encoding.ASCII.GetBytes(RenderType);
                    writer.Write(renderTypeBytes, 0, 4);
                    writer.Write(0);

                    if (nullHash)
                    {
                        writer.Write(0);
                    }
                    else
                    {
                        writer.Write(HeaderChecksum);
                    }

                    writer.Write(0);
                    writer.Write(TacSize);
                    writer.Write(0);
                    writer.Write(FileCount);
                    writer.Write(0);
                }
            }

            return result;
        }
    }
}
