using System;
using System.Collections.Generic;
using System.Linq;
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
        public FileStructureMeta Index { get; set; } = new FileStructureMeta();
    }

    [Serializable]
    public class FileStructureMeta
    {
        public int Index { get; set; }

        public byte[] FileExt { get; set; }
        public byte[] FilePath { get; set; }
        public bool FileModified { get; set; }
        public byte[] FileSize { get; set; }
        public DateTime FileLastWrite { get; set; }
        //Future(?): FileHashedPath, FileHashedName
    }

}
