using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class SPRHeader : Header
    {
        public override byte[] Signature => new byte[4] { 0x54, 0x45, 0x58, 0x4E }; //TEXN

        public override FileNode.FileType Type => FileNode.FileType.SPR;
    }
}
