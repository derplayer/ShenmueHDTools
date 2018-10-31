using ShenmueHDTools.Main.Files.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class SRLHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x53, 0x43, 0x52, 0x30 }; //SCR0
        public static readonly FileNode.FileType Type = FileNode.FileType.SRL;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
        
    }
}
