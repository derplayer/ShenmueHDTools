using ShenmueHDTools.Main.Files.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShenmueDKSharp.Files.Containers;
using static ShenmueDKSharp.Files.Containers.IDX;

namespace ShenmueHDTools.Main.Files.Nodes
{

    public class IDXFile : FileNode
    {
        public IDXHeader Header { get; set; }
        public List<IDXEntry> Entries { get; set; } = new List<IDXEntry>();

        private static Encoding m_shiftJis = Encoding.GetEncoding("shift_jis"); //possible candidate

        public IDXFile(CacheFile cacheFile, FileNode parent, string relativPath, bool newFile = false)
            : base(cacheFile, parent, relativPath, newFile)
        {
        }

        public IDXEntry GetEntry(uint index)
        {
            foreach(IDXEntry entry in Entries)
            {
                if (entry.AFSIndex == index) return entry;
            }
            return null;
        }

        public void Write()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            Entries.Clear();
            IDX idx = new IDX();
            idx.Read(FullPath);

            AFSFile afs = (AFSFile)Parent.Find(RelativPath.Replace(".IDX", ".AFS"));
            if (afs == null) return;
            for (int i = 0; i < idx.Entries.Count; i++)
            {
                if (i >= afs.Children.Count) break;
                IDXEntry entry = idx.Entries[i];
                afs.Children[i].Description = entry.Filename;
            }
        }
    }
}
