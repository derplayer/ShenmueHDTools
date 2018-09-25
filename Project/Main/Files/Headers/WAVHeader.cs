using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class WAVHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x52, 0x49, 0x46, 0x46 }; //RIFF
        public static readonly FileNode.FileType Type = FileNode.FileType.WAV;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
    }
}
