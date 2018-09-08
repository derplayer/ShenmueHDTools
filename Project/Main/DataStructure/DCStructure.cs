using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.DataStructure
{
    public static class DCCollector
    {
        public static List<DCStructure> FileCollector = new List<DCStructure>();
    }

    public class DCStructure
    {
        public string FilePathFull;
        public string FileName;
        public long FileSize;
        public byte[] Hash;
    }
}
