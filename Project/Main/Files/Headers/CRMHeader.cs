using ShenmueHDTools.Main.Files.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class CRMHeader
    {
        public static readonly byte[] Signature = new byte[4] { 0x43, 0x48, 0x52, 0x4d }; //CHRM
        public static readonly FileNode.FileType Type = FileNode.FileType.CRM;
        public static bool IsValid(byte[] buffer)
        {
            return Helper.CompareSignature(Signature, buffer);
        }
    }
}
