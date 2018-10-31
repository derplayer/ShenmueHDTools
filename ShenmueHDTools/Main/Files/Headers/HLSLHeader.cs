using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class HLSLHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x44, 0x58, 0x42, 0x43 }; //DXBC
        public static readonly FileNode.FileType Type = FileNode.FileType.HLSL;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
    }
}
