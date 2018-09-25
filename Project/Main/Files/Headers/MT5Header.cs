using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class MT5Header : Header
    {
        public override byte[] Signature => new byte[4] { 0x48, 0x52, 0x43, 0x4D }; //HRCM

        public override FileNode.FileType Type => FileNode.FileType.MT5;
    }
}
