using ShenmueHDTools.Main.Files.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class WDTHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x57, 0x44, 0x41, 0x54 }; //WDAT
        public static readonly FileNode.FileType Type = FileNode.FileType.WDT;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
    }
}
