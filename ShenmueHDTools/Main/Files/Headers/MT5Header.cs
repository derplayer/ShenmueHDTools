using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class MT5Header
    {
        public static readonly byte[] Signature = new byte[4] { 0x48, 0x52, 0x43, 0x4D }; //HRCM
        public static readonly FileNode.FileType Type = FileNode.FileType.MT5;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
    }
}
