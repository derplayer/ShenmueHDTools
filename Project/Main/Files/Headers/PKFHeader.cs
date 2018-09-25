using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class PKFHeader : Header
    {
        public override byte[] Signature => new byte[4] { 0x50, 0x41, 0x4B, 0x46 }; //PAKF

        public override FileNode.FileType Type => FileNode.FileType.PKF;
    }
}
