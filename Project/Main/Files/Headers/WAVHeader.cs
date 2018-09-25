using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class WAVHeader : Header
    {
        public override byte[] Signature => new byte[4] { 0x52, 0x49, 0x46, 0x46 }; //RIFF

        public override FileNode.FileType Type => FileNode.FileType.WAV;
    }
}
