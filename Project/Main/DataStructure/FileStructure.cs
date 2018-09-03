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
        public DateTime FileLastWrite { get; set; }
        //Future(?): FileHashedPath, FileHashedName
    }

}
