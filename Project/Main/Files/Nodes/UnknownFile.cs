using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Nodes
{
    public class UnknownFile : FileNode
    {
        public UnknownFile(CacheFile cacheFile, FileNode parent, string relativPath)
            : base(cacheFile, parent, relativPath)
        {
        }

        public override void ReadMeta() {}

        public override void WriteMeta() {}
    }
}
