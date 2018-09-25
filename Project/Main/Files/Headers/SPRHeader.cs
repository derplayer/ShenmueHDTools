using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class SPRHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x54, 0x45, 0x58, 0x4E }; //TEXN
        public static readonly FileNode.FileType Type = FileNode.FileType.SPR;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
    }
}
