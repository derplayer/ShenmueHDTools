using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class MT7Header
    {
        private static readonly List<byte[]> Signatures = new List<byte[]>()
        {
            new byte[] { 0x4D, 0x44, 0x43, 0x58 }, //MDCX
            new byte[] { 0x4D, 0x44, 0x43, 0x37 }, //MDC7
            new byte[] { 0x4D, 0x44, 0x4C, 0x37 }, //MDL7
            new byte[] { 0x4D, 0x44, 0x4F, 0x37 }, //MDO7
            new byte[] { 0x4D, 0x44, 0x50, 0x37 }, //MDP7
            new byte[] { 0x4D, 0x44, 0x48, 0x37 }, //MDH7
            new byte[] { 0x4D, 0x44, 0x4C, 0x58 }, //MDLX
            new byte[] { 0x4D, 0x44, 0x4F, 0x58 }, //MDOX
            new byte[] { 0x4D, 0x44, 0x50, 0x58 }, //MDPX
            new byte[] { 0x4D, 0x44, 0x48, 0x58 }, //MDHX
        };
        public static readonly FileNode.FileType Type = FileNode.FileType.MT7;

        public static bool IsValid(byte[] buffer)
        {
            foreach(byte[] signature in Signatures)
            {
                if (Helper.CompareSignature(signature, buffer)) return true;
            }
            return false;
        }
        
    }
}
