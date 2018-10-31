using ShenmueHDTools.Main.Files.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class SNFHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x53, 0x43, 0x4e, 0x46 }; //SCNF
        public static readonly FileNode.FileType Type = FileNode.FileType.SNF;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
    }
}
