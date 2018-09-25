using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class GZHeader
    { 
        public static readonly byte[] Signature = new byte[2] { 0x1F, 0x8B };
        public static readonly FileNode.FileType Type =  FileNode.FileType.GZ;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
    }
}
