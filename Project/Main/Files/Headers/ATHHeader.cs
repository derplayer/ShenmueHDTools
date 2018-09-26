using ShenmueHDTools.Main.Files.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class ATHHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x41, 0x55, 0x54, 0x48 }; //AUTH
        public static readonly FileNode.FileType Type = FileNode.FileType.ATH;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
    }
}
