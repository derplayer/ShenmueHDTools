using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
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


    public interface IArchiveNode
    {
        void Unpack();
        void Pack();
    }

    public interface IAudioNode
    {
        void GetWAVEStream(); //TODO
    }

    public interface IImageNode
    {
        Bitmap GetImage();
    }

    public interface IModelNode
    {
        void GetModel(); //TODO
    }

    public class FileNode : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Serialization
        private FileType m_type;
        private string m_relativPath = "";
        private byte[] m_checksum = new byte[16];
        private string m_category = "";
        private string m_description = "";
        private string m_location = "";
        private string m_notes = "";

        public FileType Type
        {
            get { return m_type; }
            set
            {
                SetProperty(ref m_type, value);
                OnPropertyChanged("TypeString");
            }
        }
        public string RelativPath
        {
            get { return m_relativPath; }
            set
            {
                if (value == null) 
                {
                    SetProperty(ref m_relativPath, "");
                    return;
                }
                SetProperty(ref m_relativPath, value);
            }
        }
        public byte[] Checksum
        {
            get { return m_checksum; }
            set
            {
                if (value == null || value.Length != 16)
                {
                    SetProperty(ref m_checksum, new byte[16]);
                    OnPropertyChanged("ChecksumString");
                    return;
                }
                SetProperty(ref m_checksum, value);
                OnPropertyChanged("ChecksumString");
            }
        }
        public string Category
        {
            get { return m_category; }
            set
            {
                if (value == null)
                {
                    SetProperty(ref m_category, "");
                    return;
                }
                SetProperty(ref m_category, value);
            }
        }
        public string Description
        {
            get { return m_description; }
            set
            {
                if (value == null)
                {
                    SetProperty(ref m_description, "");
                    return;
                }
                SetProperty(ref m_description, value);
            }
        }
        public string Location
        {
            get { return m_location; }
            set
            {
                if (value == null)
                {
                    SetProperty(ref m_location, "");
                    return;
                }
                SetProperty(ref m_location, value);
            }
        }
        public string Notes
        {
            get { return m_notes; }
            set
            {
                if (value == null)
                {
                    SetProperty(ref m_notes, "");
                    return;
                }
                SetProperty(ref m_notes, value);
            }
        }
        #endregion

        #region Runtime
        private bool m_modified;

        public string TypeString
        {
            get
            {
                return String.Format("{0} ({1})", Type.ToString(), GetTypeDescription(Type));
            }
        }

        public string ChecksumString
        {
            get
            {
                return Helper.ByteArrayToString(Checksum);
            }
        }

        public string Name
        {
            get
            {
                if (String.IsNullOrEmpty(Description)) return Path.GetFileName(RelativPath);
                return String.Format("{0} ({1})", Path.GetFileName(RelativPath), Description);
            }
        }
        public string FullPath => CacheFile.GetFullPath(RelativPath);
        public FileNode Parent { get; private set; }
        public List<FileNode> Children { get; private set; } = new List<FileNode>();
        public CacheFile CacheFile { get; private set; }
        public TreeNode TreeNode { get; private set; }
        public bool IsRoot { get; private set; } = false;
        public bool Modified
        {
            get { return m_modified; }
            set { SetProperty(ref m_modified, value); }
        }
        #endregion

        public enum TreeType
        {
            Simple,
            FilePath,
            Category,
            Location
        }

        public FileNode(CacheFile cacheFile, FileNode parent, string relativPath, bool newFile)
        {
            CacheFile = cacheFile;
            Parent = parent;
            RelativPath = relativPath;
            if (Parent == null)
            {
                IsRoot = true;
            }
            if (newFile)
            {
                CalcChecksum(true);
            }
        }

        public FileNode Find(string relativePath)
        {
            foreach(FileNode node in Children)
            {
                if (node.RelativPath == relativePath)
                {
                    return node;
                }
            }
            return null;
        }

        /// <summary>
        /// Calculates the checksum.
        /// If writeChecksum is true the checksum will be written in to the node.
        /// If not than the calculated checksum will be compared to the checksum inside the node,
        /// which will set the Modified flag accordingly.
        /// </summary>
        /// <param name="writeChecksum"></param>
        public void CalcChecksum(bool writeChecksum = false)
        {
            string filename = FullPath;
            if (!Helper.IsFileValid(filename)) return;
            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
                byte[] hash = Helper.MD5Hash(buffer);
                Modified = false;

                if (writeChecksum)
                {
                    Checksum = hash;
                }
                else
                {
                    for (int i = 0; i < hash.Length; i++)
                    {
                        if (Checksum[i] != hash[i])
                        {
                            Modified = true;
                            return;
                        }
                    }
                }
            }
        }

        private TreeNode GetOrCreateFolder(TreeNode parent, string directoryPath)
        {
            if (parent.Tag.GetType().IsSubclassOf(typeof(FileNode)))
            {
                FileNode fileNode = (FileNode)parent.Tag;
                if (typeof(IArchiveNode).IsAssignableFrom(fileNode.GetType())) return parent;
            }

            string[] folders = directoryPath.Split('\\');
            foreach (string folder in folders)
            {
                TreeNode found = null;
                foreach (TreeNode node in parent.Nodes)
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

        /// <summary>
        /// Creates an TreeNode structure for the TreeView inside the given parent
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="treeType"></param>
        public void CreateTreeNode(TreeNode parent, TreeType treeType)
        {
            TreeNode = new TreeNode(Name);
            TreeNode.Tag = this;
            TreeNode.SelectedImageIndex = (int)Type;
            TreeNode.ImageIndex = (int)Type;

            if (treeType == TreeType.FilePath)
            {
                parent = GetOrCreateFolder(parent, Path.GetDirectoryName(RelativPath));
            }

            if (treeType == TreeType.Category)
            {
                throw new NotImplementedException();
            }

            if (treeType == TreeType.Location)
            {
                throw new NotImplementedException();
            }

            parent.Nodes.Add(TreeNode);

            foreach (FileNode child in Children)
            {
                child.CreateTreeNode(TreeNode, treeType);
            }
        }

        /// <summary>
        /// Reads the node and all child nodes from the binary stream
        /// </summary>
        /// <param name="cacheFile"></param>
        /// <param name="parent"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static FileNode Read(CacheFile cacheFile, FileNode parent, BinaryReader reader)
        {
            FileType type = (FileType)reader.ReadByte();
            byte[] checksum = reader.ReadBytes(16);

            string relativPath = "";
            uint relativPathLength = reader.ReadUInt32();
            if (relativPathLength > 0)
            {
                byte[] relativPathBuffer = reader.ReadBytes((int)relativPathLength);
                relativPath = Encoding.ASCII.GetString(relativPathBuffer);
            }

            string category = "";
            uint categoryLength = reader.ReadUInt32();
            if (categoryLength > 0)
            {
                byte[] categoryBuffer = reader.ReadBytes((int)categoryLength);
                category = Encoding.ASCII.GetString(categoryBuffer);
            }

            string location = "";
            uint locationLength = reader.ReadUInt32();
            if (locationLength > 0)
            {
                byte[] locationBuffer = reader.ReadBytes((int)locationLength);
                location = Encoding.ASCII.GetString(locationBuffer);
            }

            string description = "";
            uint descriptionLength = reader.ReadUInt32();
            if (descriptionLength > 0)
            {
                byte[] descriptionBuffer = reader.ReadBytes((int)descriptionLength);
                description = Encoding.ASCII.GetString(descriptionBuffer);
            }

            string notes = "";
            uint notesLength = reader.ReadUInt32();
            if (notesLength > 0)
            {
                byte[] notesBuffer = reader.ReadBytes((int)notesLength);
                notes = Encoding.ASCII.GetString(notesBuffer);
            }

            FileNode node = CreateNodeInternal(cacheFile, parent, relativPath, type, false);
            node.Type = type;
            node.Checksum = checksum;
            node.Category = category;
            node.Description = description;
            node.Location = location;
            node.Notes = notes;

            uint childCount = reader.ReadUInt32();
            for (uint i = 0; i < childCount; i++)
            {
                node.Children.Add(Read(cacheFile, node, reader));
            }
                    
            return node;
        }

        /// <summary>
        /// Writes the node and all child nodes to the binary stream.
        /// </summary>
        /// <param name="writer"></param>
        public void Write(BinaryWriter writer)
        {
            writer.Write((byte)Type);
            writer.Write(Checksum, 0, 16);

            byte[] relativPathBytes = Encoding.ASCII.GetBytes(RelativPath);
            writer.Write((uint)relativPathBytes.Length);
            if (relativPathBytes.Length > 0)
            {
                writer.Write(relativPathBytes, 0, relativPathBytes.Length);
            }

            byte[] categoryBytes = Encoding.ASCII.GetBytes(Category);
            writer.Write((uint)categoryBytes.Length);
            if (categoryBytes.Length > 0)
            {
                writer.Write(categoryBytes, 0, categoryBytes.Length);
            }

            byte[] locationBytes = Encoding.ASCII.GetBytes(Location);
            writer.Write((uint)locationBytes.Length);
            if (locationBytes.Length > 0)
            {
                writer.Write(locationBytes, 0, locationBytes.Length);
            }

            byte[] descriptionBytes = Encoding.ASCII.GetBytes(Description);
            writer.Write((uint)descriptionBytes.Length);
            if (descriptionBytes.Length > 0)
            {
                writer.Write(descriptionBytes, 0, descriptionBytes.Length);
            }

            byte[] notesBytes = Encoding.ASCII.GetBytes(Notes);
            writer.Write((uint)notesBytes.Length);
            if (notesBytes.Length > 0)
            {
                writer.Write(notesBytes, 0, notesBytes.Length);
            }

            writer.Write((uint)Children.Count);

            foreach(FileNode node in Children)
            {
                node.Write(writer);
            }
        }

        /// <summary>
        /// Creates a new Node which is only used when not reading serialized nodes
        /// </summary>
        /// <param name="cacheFile"></param>
        /// <param name="entry"></param>
        /// <returns></returns>
        public static FileNode CreateNode(CacheFile cacheFile, TADFileEntry entry)
        {
            string extension = entry.Extension;
            FileType type = FileType.UNKNOWN;
            type = PeakFileType(cacheFile.GetFullPath(entry.RelativPath), type);

            if (type == FileType.UNKNOWN && !String.IsNullOrEmpty(extension))
            {
                //fallback to extension
                type = GetTypeFromExtension(extension.Substring(1).ToUpper());
            }

            FileNode node = CreateNodeInternal(cacheFile, null, entry.RelativPath, type);
            node.Type = type;
            return node;
        }

        /// <summary>
        /// Creates a new Node which is only used when not reading serialized nodes
        /// </summary>
        /// <param name="cacheFile"></param>
        /// <param name="parent"></param>
        /// <param name="relativPath"></param>
        /// <returns></returns>
        public static FileNode CreateNode(CacheFile cacheFile, FileNode parent, string relativPath)
        {
            string extension = Path.GetExtension(relativPath);
            FileType type = FileType.UNKNOWN;
            type = PeakFileType(cacheFile.GetFullPath(relativPath), type);

            if (type == FileType.UNKNOWN && !String.IsNullOrEmpty(extension))
            {
                //fallback to extension
                type = GetTypeFromExtension(extension.Substring(1).ToUpper());
            }

            FileNode node = CreateNodeInternal(cacheFile, parent, relativPath, type);
            node.Type = type;
            return node;
        }

        private static FileType PeakFileType(string filename, FileType type)
        {
            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                byte[] extBuffer = new byte[2];
                stream.Read(extBuffer, 0, 2);
                stream.Seek(0, SeekOrigin.Begin);

                //TODO Static GZ Header check and others
                if (extBuffer[0] == 0x1F && extBuffer[1] == 0x8B)
                {
                    using (GZipStream streamGZip = new GZipStream(stream, CompressionMode.Decompress))
                    {
                        byte[] buffer = new byte[64];
                        streamGZip.Read(buffer, 0, 4);
                        return Headers.Headers.GetFileType(buffer);
                    }
                }
                else
                {
                    byte[] buffer = new byte[64];
                    stream.Read(buffer, 0, 4);
                    FileType tmpType = Headers.Headers.GetFileType(buffer);
                    if (tmpType == FileType.UNKNOWN) return type;
                    return tmpType;
                }
            }
        }

        /// <summary>
        /// Creates the an node for normal creation and deserialization
        /// </summary>
        /// <param name="cacheFile"></param>
        /// <param name="parent"></param>
        /// <param name="relativPath"></param>
        /// <param name="type"></param>
        /// <param name="newFile"></param>
        /// <returns></returns>
        private static FileNode CreateNodeInternal(CacheFile cacheFile, FileNode parent, string relativPath, FileType type, bool newFile = true)
        {
            switch (type)
            {
                case FileType.UNKNOWN:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.AFS:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.BIN:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.BMP:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.CHR:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.CSV:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.DAT:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.DDS:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.EMU:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.FON:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.FONTDEF:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.GLYPHS:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.GZ:
                    return new GZFile(cacheFile, parent, relativPath, newFile);
                case FileType.HLSL:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.IDX:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.MAP:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.MT5:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.MT6:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.MT7:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.MVS:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.PKF:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.PKS:
                    return new PKSFile(cacheFile, parent, relativPath, newFile);
                case FileType.PNG:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.PVR:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.RMP:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.SCN:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.SND:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.SPR:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.SRF:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.SUB:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.TGA:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.UI:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
                case FileType.WAV:
                    return new UnknownFile(cacheFile, parent, relativPath, newFile);
            }
            return null;
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

        /*
        private static Icon GetIcon(FileType fileType)
        {

        }
        */

        public static string GetTypeDescription(FileType type)
        {
            if (FileTypeDescription.Keys.Contains(type)) return FileTypeDescription[type];
            return "Unknown";
        }

        private static Dictionary<FileType, string> FileTypeDescription = new Dictionary<FileType, string>()
        {
            { FileType.AFS, "Archive file with IDX" },
            { FileType.BIN, "Unknown Binary file" },
            { FileType.BMP, "Bitmap" },
            { FileType.CHR, "Character" },
            { FileType.CSV, "Comma-separated values" },
            { FileType.DAT, "Unknown Binary file" },
            { FileType.DDS, "Direct draw surface texture" },
            { FileType.EMU, "Unknown emulator file" },
            { FileType.FON, "Unknown" },
            { FileType.FONTDEF, "Font definition file" },
            { FileType.GLYPHS, "Font glyph file" },
            { FileType.GZ, "GZip compressed file" },
            { FileType.HLSL, "Compiled HLSL shader" },
            { FileType.IDX, "Index for AFS archive file" },
            { FileType.MAP, "Map" },
            { FileType.MT5, "Model container" },
            { FileType.MT6, "Model container" },
            { FileType.MT7, "Model container" },
            { FileType.MVS, "MVS data" },
            { FileType.PKF, "Archive file" },
            { FileType.PKS, "Archive file" },
            { FileType.PNG, "Portable network graphics" },
            { FileType.PVR, "PowerVR texture" },
            { FileType.RMP, "Remap file" },
            { FileType.SCN, "Scene file" },
            { FileType.SND, "Sound file" },
            { FileType.SPR, "Sprite container" },
            { FileType.SRF, "" },
            { FileType.SUB, "Subtitles file" },
            { FileType.TGA, "Targa image file" },
            { FileType.UI, "UI JSON" },
            { FileType.WAV, "WAVE file" },
        };

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

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (TreeNode != null)
            {
                TreeNode.Text = Name;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
