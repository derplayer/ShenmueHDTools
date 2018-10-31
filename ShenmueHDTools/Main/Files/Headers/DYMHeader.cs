using ShenmueHDTools.Main.Files.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class DYMHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x44, 0x59, 0x4e, 0x4d }; //DYNM
        public static readonly FileNode.FileType Type = FileNode.FileType.DYM;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
    }
}
