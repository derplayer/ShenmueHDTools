using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueDKSharp;
using ShenmueDKSharp.Files.Images;
using ShenmueDKSharp.Files.Images._DDS;

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
            DDS dds = new DDS(FullPath);
            return dds.CreateBitmap();
        }

    }
}
