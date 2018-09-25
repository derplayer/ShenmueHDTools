using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class AFSHeader : Header
    {
        public override byte[] Signature => new byte[4] { 0x41, 0x46, 0x53, 0x00 }; //AFS

        public override FileNode.FileType Type => FileNode.FileType.AFS;
    }
}
