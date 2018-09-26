using ShenmueHDTools.Main.Files.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class IWDHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x49, 0x57, 0x41, 0x44 }; //IWAD
        public static readonly FileNode.FileType Type = FileNode.FileType.IWD;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
    }
}
