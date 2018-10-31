using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class SNDHeader
    {
        //Can have xbox before the DTPK
        public static readonly byte[] Signature = new byte[4] { 0x44, 0x54, 0x50, 0x4B }; //DTPK
        public static readonly FileNode.FileType Type = FileNode.FileType.SND;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
    }
}
