using SharpDX.Direct3D11;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShenmueHDTools.Main.Files.Nodes
{
    public class DDSFile : FileNode, IImageNode
    {
        public DDSFile(CacheFile cacheFile, FileNode parent, string relativPath, bool newFile = false)
            : base(cacheFile, parent, relativPath, newFile)
        {
        }

        public Bitmap GetImage()
        {
            throw new NotImplementedException();
        }

    }
}
