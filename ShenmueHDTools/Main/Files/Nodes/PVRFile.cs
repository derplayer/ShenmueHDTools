using ShenmueDKSharp.Files.Images;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Files.Nodes
{
    public class PVRFile : FileNode, IImageNode
    {
        public PVRFile(CacheFile cacheFile, FileNode parent, string relativPath, bool newFile = false)
            : base(cacheFile, parent, relativPath, newFile)
        {
        }

        public Bitmap GetImage()
        {
            PVRT pvrt = new PVRT(FullPath);
            return pvrt.CreateBitmap();
        }
    }
}
