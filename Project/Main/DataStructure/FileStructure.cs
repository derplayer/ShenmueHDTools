using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Shenmue_HD_Tools.ShenmueHD;

namespace ShenmueHDTools.Main.DataStructure
{
    [Serializable]
    public class FileStructure
    {
        public byte[] Hash1 { get; set; }
        public byte[] Hash2 { get; set; }

        public byte[] FileStart { get; set; }
        public byte[] FileSize { get; set; }

        // Not part of real "tad" file, but useful
        public FileStructureMeta Meta { get; set; } = new FileStructureMeta();

        public static byte[] GetFilenameHash(String filename)
        {
            if (filename[0] == '.')
            {
                filename = filename.Substring(1);
            }
            string strippedFilename = filename.ToLower().Replace("/", "");
            uint murmurHash = MurmurHash2Shenmue.Hash(Encoding.ASCII.GetBytes(strippedFilename), (uint)strippedFilename.Length);

            Console.WriteLine(murmurHash.ToString("X"));

            uint hash = murmurHash * 0x0001003F + (uint)strippedFilename.Length * (uint)strippedFilename.Length * 0x0002001F;

            return BitConverter.GetBytes(hash);
        }
    }

    [Serializable]
    public class FileStructureMeta
    {
        public int Index { get; set; }
        public byte[] FileEnd { get; set; }

        public string FileExt { get; set; }
        public string FilePath { get; set; }
        public bool FileModified { get; set; }
        public byte[] MD5Hash { get; set; }

        //Reserved for future use
        [OptionalField]
        public byte[] FileHashedPath;
        [OptionalField]
        public byte[] FileHashedName;
        [OptionalField]
        public byte[] FileHashedExt;
        [OptionalField]
        public byte[] FileHashedReserved;
    }

}
