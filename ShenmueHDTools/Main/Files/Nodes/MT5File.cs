using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueDKSharp.Files.Models;

namespace ShenmueHDTools.Main.Files.Nodes
{
    public class MT5File : FileNode, IModelNode
    {
        public MT5File(CacheFile cacheFile, FileNode parent, string relativPath, bool newFile = false)
            : base(cacheFile, parent, relativPath, newFile)
        {
        }

        public BaseModel GetModel()
        {
            MT5 mt5 = new MT5(FullPath);
            return mt5;
        }
    }

}
