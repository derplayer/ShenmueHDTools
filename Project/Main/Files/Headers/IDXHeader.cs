using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class IDXHeader : Header
    {
        public override byte[] Signature => new byte[4] { 0x49, 0x44, 0x58, 0x30 }; //IDX0

        public override FileNode.FileType Type => FileNode.FileType.IDX;
    }
}
