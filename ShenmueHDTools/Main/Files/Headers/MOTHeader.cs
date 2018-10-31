using ShenmueHDTools.Main.Files.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class MOTHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x4d, 0x4f, 0x54, 0x4e }; //MOTN
        public static readonly FileNode.FileType Type = FileNode.FileType.MOT;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
        
    }
}
