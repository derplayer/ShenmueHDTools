using ShenmueHDTools.Main.Files.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class MVSHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x4D, 0x56, 0x53, 0x44 }; //MVSD
        public static readonly FileNode.FileType Type = FileNode.FileType.MVS;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
        
    }
}
