using Shenmue_HD_Tools.ShenmueHD;
using System;
using System.Collections.Generic;

namespace ShenmueHDTools.Main.DataStructure
{
    [Serializable]
    public class HeaderStructure
    {
        public byte[] FileType { get; set; }
        public byte[] Identifier1 { get; set; }
        public byte[] Identifier2 { get; set; }
        public byte[] Reserved1 { get; set; } = new byte[4] { 0x00, 0x00, 0x00, 0x00 };

        public byte[] UnixTimestamp { get; set; }
        public byte[] Reserved2 { get; set; } = new byte[4] { 0x00, 0x00, 0x00, 0x00 };

        public byte[] RenderType { get; set; }
        public byte[] Reserved3 { get; set; } = new byte[4] { 0x00, 0x00, 0x00, 0x00 };

        public byte[] HeaderChecksum { get; set; }
        public byte[] Reserved4 { get; set; } = new byte[4] { 0x00, 0x00, 0x00, 0x00 };

        public byte[] TacSize { get; set; }
        public byte[] Reserved5 { get; set; } = new byte[4] { 0x00, 0x00, 0x00, 0x00 };

        public byte[] FileCount1 { get; set; }
        public byte[] Reserved6 { get; set; } = new byte[4] { 0x00, 0x00, 0x00, 0x00 };

        public byte[] FileCount2 { get; set; }

        public IEnumerable<byte[]> GetHeader(bool hashMode = false)
        {
            yield return FileType;
            yield return Identifier1;
            yield return Identifier2;
            yield return Reserved1;

            yield return UnixTimestamp;
            yield return Reserved2;

            yield return RenderType;
            yield return Reserved3;

            if (hashMode) yield return new byte[4] { 0x00, 0x00, 0x00, 0x00 }; //nullify for hash generation
            else yield return HeaderChecksum;
            yield return Reserved4;

            yield return TacSize;
            yield return Reserved5;

            yield return FileCount1;
            yield return Reserved6;

            if (hashMode == false)
            {
                yield return FileCount2;
            }
        }

        public byte[] GetPreHash() { return GetPreHash(this); }
        public byte[] GetPreHash(HeaderStructure header)
        {
            byte[] hashHeader = new byte[56];
            int i = 0;
            foreach (var entry in header.GetHeader(true))
            {
                entry.CopyTo(hashHeader, i);
                i += 4;
            }

            return hashHeader;
        }

        public UInt32 GetHash() { return GetHash(GetPreHash()); }
        public UInt32 GetHash(byte[] preHash)
        {
            uint tacHash = MurmurHash2Shenmue.Hash(preHash, (uint)preHash.Length);
            return tacHash;
        }

    }
}
