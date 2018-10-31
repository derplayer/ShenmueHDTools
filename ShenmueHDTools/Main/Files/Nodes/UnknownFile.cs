using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Nodes
{
    public class UnknownFile : FileNode
    {

        public UnknownFile(CacheFile cacheFile, FileNode parent, string relativPath, bool newFile = false)
            : base(cacheFile, parent, relativPath, newFile)
        {
        }

    }
}
