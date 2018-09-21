using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShenmueHDTools.Main.Files.Nodes
{
    /* MOVE TO BIN FILE
    public enum BinTypes
    {
        UNKNOWN,
        MAPINFO
    }
    */

    public abstract class FileNode
    {
        #region Serialization
        public FileType Type { get; set; }
        public string RelativPath { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public byte[] Checksum { get; set; }

        #endregion
        #region Runtime
        #endregion

        #region Runtime
        public string Name
        {
            get
            {
                if (String.IsNullOrEmpty(Description)) return Path.GetFileName(RelativPath);
                return String.Format("{0} ({1})", Path.GetFileName(RelativPath), Description);
            }
        }

        public string FullPath => CacheFile.OutputFolder + "\\" + RelativPath;
        public FileNode Parent { get; private set; }
        public List<FileNode> Children { get; private set; } = new List<FileNode>();
        public CacheFile CacheFile { get; private set; }
        public TADFileEntry TADFileEntry { get; private set; }
        public bool IsRoot { get; private set; } = false;
        public bool IsTADEntry => TADFileEntry == null;
        public bool Modified { get; private set; }    
        #endregion

        public enum TreeType
        {
            Simple,
            FilePath,
            Category
        }

        public FileNode(CacheFile cacheFile, FileNode parent, string relativPath)
        {
            CacheFile = cacheFile ?? throw new Exception("cacheFile can't be null!");
            Parent = parent;
            RelativPath = relativPath;
            if (Parent == null)
            {
                IsRoot = true;
            }
        }

        public void CalcChecksum()
        {
            string filename = FullPath;
            if (!Helper.IsFileValid(filename)) return;
            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
                Modified = false;
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (Checksum[i] != buffer[i])
                    {
                        Modified = true;
                        return;
                    }
                }
            }
        }

        private TreeNode GetOrCreateFolder(TreeNode parent, string directoryPath)
        {
            string[] folders = directoryPath.Split('\\');
            foreach (string folder in folders)
            {
                TreeNode found = null;
                foreach(TreeNode node in parent.Nodes)
                {
                    if (node.Text.ToUpper() == folder.ToUpper())
                    {
                        found = node;
                        break;
                    }
                }
                if (found == null)
                {
                    TreeNode dirNode = new TreeNode(folder);
                    parent.Nodes.Add(dirNode);
                    parent = dirNode;
                }
                else
                {
                    parent = found;
                }
            }
            return parent;
        }

        public void CreateTreeNode(TreeNode parent, TreeType treeType)
        {
            TreeNode treeNode = new TreeNode(Name);
            treeNode.Tag = this;

            if (treeType == TreeType.FilePath)
            {
                parent = GetOrCreateFolder(parent, Path.GetDirectoryName(RelativPath));
            }

            if (treeType == TreeType.Category)
            {
                throw new NotImplementedException();
            }

            parent.Nodes.Add(treeNode);


            foreach (FileNode child in Children)
            {
                child.CreateTreeNode(treeNode, treeType);
            }
        }

        public void Read(BinaryReader reader)
        {
            //READ OWN META
            //READ CHILD COUNT
            ReadMeta();
        }

        public void Write(BinaryWriter writer)
        {
            //WRITE OWN META
            //WRITE CHILD COUNT
            WriteMeta();
        }

        
        //ITERATE CHILDREN WRITE META
        public abstract void WriteMeta();

        //READ TYPE AND ADD CHILD (MOVE BACK 1 BYTE BEFORE READING CHILD META)
        //LET CHILDREN READ THE REST
        public abstract void ReadMeta();


        public static FileNode GetNode(CacheFile cacheFile, TADFileEntry entry)
        {
            string extension = entry.Extension;
            FileType type = FileType.UNKNOWN;
            if (!String.IsNullOrEmpty(extension))
            {
                type = GetTypeFromExtension(extension.Substring(1).ToUpper());
            }
            FileNode node = CreateNode(cacheFile, null, entry.RelativePath, type);
            node.TADFileEntry = entry;
            return node;
        }

        public static FileNode GetNode(CacheFile cacheFile, FileNode parent, string relativPath)
        {
            string extension = Path.GetExtension(relativPath);
            FileType type = FileType.UNKNOWN;
            if (!String.IsNullOrEmpty(extension))
            {
                type = GetTypeFromExtension(extension.Substring(1).ToUpper());
            }
            return CreateNode(cacheFile, parent, relativPath, type);
        }

        private static FileType GetTypeFromExtension(string extension)
        {
            for (int i = 0; i < Enum.GetNames(typeof(FileType)).Length; i++)
            {
                if (extension == ((FileType)i).ToString())
                {
                    return (FileType)i;
                }
            }
            return FileType.UNKNOWN;
        }

        private static FileNode CreateNode(CacheFile cacheFile, FileNode parent, string relativPath, FileType type)
        {
            switch (type)
            {
                case FileType.UNKNOWN:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.AFS:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.BIN:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.BMP:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.CHR:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.CSV:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.DAT:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.DDS:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.EMU:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.FON:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.FONTDEF:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.GLYPHS:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.GZ:
                    return new GZFile(cacheFile, parent, relativPath);
                case FileType.HLSL:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.IDX:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.MAP:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.MT5:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.MT6:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.MT7:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.MVS:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.PKF:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.PKS:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.PNG:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.PVR:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.RMP:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.SCN:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.SND:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.SPR:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.SRF:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.SUB:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.UI:
                    return new UnknownFile(cacheFile, parent, relativPath);
                case FileType.WAV:
                    return new UnknownFile(cacheFile, parent, relativPath);
            }
            return null;
        }

        /// <summary>
        /// File type enum.
        /// When any of the enum values change the serialization will be broken.
        /// Adding is allowed, removing not.
        /// </summary>
        public enum FileType : Byte
        {
            UNKNOWN = 0,
            AFS = 1,
            BIN = 2,
            BMP = 3,
            CHR = 4,
            CSV = 5,
            DAT = 6,
            DDS = 7,
            EMU = 8,
            FON = 9,
            FONTDEF = 10,
            GLYPHS = 11,
            GZ = 12,
            HLSL = 13,
            IDX = 14,
            MAP = 15,
            MT5 = 16,
            MT6 = 17,
            MT7 = 18,
            MVS = 19,
            PKF = 20,
            PKS = 21,
            PNG = 22,
            PVR = 23,
            RMP = 24,
            SCN = 25,
            SND = 26,
            SPR = 27,
            SRF = 28,
            SUB = 29,
            TGA = 30,
            UI = 31,
            WAV = 32
        }
    }
}
