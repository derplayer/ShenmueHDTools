using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Nodes
{
    public class PKFFile : FileNode, IArchiveNode
    {
        public PKFFile(CacheFile cacheFile, FileNode parent, string relativPath, bool newFile = false)
            : base(cacheFile, parent, relativPath, newFile)
        {
            if (newFile)
            {
                Unpack();
            }
        }

        public void Pack()
        {
            throw new NotImplementedException();
        }

        public void Unpack()
        {
            throw new NotImplementedException();
        }
    }
}
