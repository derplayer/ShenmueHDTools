using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.DataStructure
{
    [Serializable]
    public class DCCollector
    {
        public List<DCStructure> FileCollector = new List<DCStructure>();
    }

    [Serializable]
    public class DCStructure
    {
        public string FilePathFull;
        public string FileName;
        public long FileSize;

        [OptionalField]
        public byte[] Hash;
    }
}
