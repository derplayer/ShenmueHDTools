using ShenmueDKSharp.Files.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Nodes
{
    public class MT7File : FileNode, IModelNode
    {
        public MT7File(CacheFile cacheFile, FileNode parent, string relativPath, bool newFile = false)
            : base(cacheFile, parent, relativPath, newFile)
        {
        }

        public BaseModel GetModel()
        {
            MT7 mt7 = new MT7(FullPath);
            return mt7;
        }
    }
}
