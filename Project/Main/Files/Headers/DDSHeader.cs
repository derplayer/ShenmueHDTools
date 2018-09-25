using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class DDSHeader : Header
    {
        public override byte[] Signature => new byte[4] { 0x44, 0x44, 0x53, 0x20 }; //DDS 

        public override FileNode.FileType Type => FileNode.FileType.DDS;
    }
}
