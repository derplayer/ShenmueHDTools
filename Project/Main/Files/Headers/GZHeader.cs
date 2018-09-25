using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class GZHeader : Header
    { 
        public override byte[] Signature { get; } = new byte[2] { 0x1F, 0x8B };
        public override FileNode.FileType Type { get; } =  FileNode.FileType.GZ;
    }
}
