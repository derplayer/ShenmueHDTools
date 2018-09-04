using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
