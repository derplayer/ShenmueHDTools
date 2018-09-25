using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class DDSHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x44, 0x44, 0x53, 0x20 }; //DDS 
        public static readonly FileNode.FileType Type = FileNode.FileType.DDS;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
    }
}
