using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class PVRHeader
    {
        private static readonly List<byte[]> Signatures = new List<byte[]>()
        {
            new byte[] { 0x50, 0x56, 0x52, 0x54 }, //PVRT
            new byte[] { 0x47, 0x42, 0x49, 0x58 }, //GBIX
        };
        public static readonly FileNode.FileType Type = FileNode.FileType.PVR;

        public static bool IsValid(byte[] buffer)
        {
            foreach (byte[] signature in Signatures)
            {
                if (Helper.CompareSignature(signature, buffer)) return true;
            }
            return false;
        }
    }
}
