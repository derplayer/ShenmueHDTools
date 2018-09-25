using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Nodes;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class PVRHeader : Header
    {
        public override byte[] Signature => new byte[4] { 0x50, 0x56, 0x52, 0x54 }; //PVRT
        public byte[] Signature2 => new byte[4] { 0x47, 0x42, 0x49, 0x58 }; //GBIX
        public override FileNode.FileType Type => FileNode.FileType.PVR;

        private bool m_hasGlobalIndex;

        public new bool IsValid(byte[] buffer)
        {
            m_hasGlobalIndex = false;
            bool valid = true;
            for (int i = 0; i < Signature.Length; i++)
            {
                if (buffer[i] != Signature[i])
                {
                    valid = false;
                }
            }

            if (!valid)
            {
                for (int i = 0; i < Signature2.Length; i++)
                {
                    if (buffer[i] != Signature2[i]) return false;
                }
            }
            m_hasGlobalIndex = true;
            return true;
        }
    }
}
