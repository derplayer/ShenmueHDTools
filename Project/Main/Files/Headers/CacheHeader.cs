using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShenmueHDTools.Main.Files.Headers
{
    public class CacheHeader
    {
        public uint Version { get; set; } = 1;

        public string RelativeOutputFolder { get; set; } = "";
        public string RelativeTADPath { get; set; } = "";
        public string RelativeTACPath { get; set; } = "";

        public void Read(BinaryReader reader)
        {
            Version = reader.ReadUInt32();
            uint outputFolderLength = reader.ReadUInt32();
            if (outputFolderLength > 0)
            {
                byte[] outputFolderBuffer = reader.ReadBytes((int)outputFolderLength);
                RelativeOutputFolder = Encoding.ASCII.GetString(outputFolderBuffer);
            }

            uint tadPathLength = reader.ReadUInt32();
            if (tadPathLength > 0)
            {
                byte[] tadPathBuffer = reader.ReadBytes((int)tadPathLength);
                RelativeTADPath = Encoding.ASCII.GetString(tadPathBuffer);
            }

            uint tacPathLength = reader.ReadUInt32();
            if (tacPathLength > 0)
            {
                byte[] tacPathBuffer = reader.ReadBytes((int)tacPathLength);
                RelativeTACPath = Encoding.ASCII.GetString(tacPathBuffer);
            }
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(Version);
            byte[] outputFolderBuffer = Encoding.ASCII.GetBytes(RelativeOutputFolder);
            writer.Write((uint)outputFolderBuffer.Length);
            if (outputFolderBuffer.Length > 0)
            {
                writer.Write(outputFolderBuffer, 0, outputFolderBuffer.Length);
            }

            byte[] tadPathBuffer = Encoding.ASCII.GetBytes(RelativeTADPath);
            writer.Write((uint)tadPathBuffer.Length);
            if (tadPathBuffer.Length > 0)
            {
                writer.Write(tadPathBuffer, 0, tadPathBuffer.Length);
            }

            byte[] tacPathBuffer = Encoding.ASCII.GetBytes(RelativeTACPath);
            writer.Write((uint)tacPathBuffer.Length);
            if (tacPathBuffer.Length > 0)
            {
                writer.Write(tacPathBuffer, 0, tacPathBuffer.Length);
            }
        }

    }
}
