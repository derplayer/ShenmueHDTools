using ShenmueHDTools.Main.Files.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class MAPHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x4d, 0x41, 0x50, 0x4d }; //MAPM
        public static readonly FileNode.FileType Type = FileNode.FileType.MAP;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
    }
}
