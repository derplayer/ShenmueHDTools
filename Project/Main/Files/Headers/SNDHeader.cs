using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class SNDHeader : Header
    {
        //Can have xbox before the DTPK
        public override byte[] Signature => new byte[4] { 0x44, 0x54, 0x50, 0x4B }; //DTPK

        public override FileNode.FileType Type => FileNode.FileType.SND;
    }
}
