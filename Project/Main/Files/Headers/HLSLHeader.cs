using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class HLSLHeader : Header
    {
        public override byte[] Signature => new byte[4] { 0x44, 0x58, 0x42, 0x43 }; //DXBC

        public override FileNode.FileType Type => FileNode.FileType.HLSL;
    }
}
