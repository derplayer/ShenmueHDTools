using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static ShenmueHDTools.Main.Files.Nodes.FileNode;

namespace ShenmueHDTools.Main.Files.Headers
{

    public static class Headers
    {
        /// <summary>
        /// All available headers need to be listed here
        /// </summary>
        public static HashSet<Type> HeaderList = new HashSet<Type>
        {
            typeof(GZHeader),
            typeof(AFSHeader),
            typeof(DDSHeader),
            typeof(HLSLHeader),
            typeof(IDXHeader),
            typeof(MT5Header),
            typeof(MT7Header),
            typeof(MVSHeader),
            typeof(PKFHeader),
            typeof(PKSHeader),
            typeof(PVRHeader),
            typeof(SNDHeader),
            typeof(SPRHeader),
            typeof(WAVHeader),
            typeof(ATHHeader),
            typeof(CHTHeader),
            typeof(CRMHeader),
            typeof(DYMHeader),
            typeof(IWDHeader),
            typeof(MAPHeader),
            typeof(MOTHeader),
            typeof(SNFHeader),
            typeof(SRLHeader),
            typeof(WDTHeader)
        };

        //Using delegate so we don't use reflections to get the return type and parameters at runtime
        //when we call the IsValid method.
        public delegate bool IsValidDelegate(byte[] buffer);
        public static Dictionary<IsValidDelegate, FileType> HeaderRuntime = new Dictionary<IsValidDelegate, FileType>();

        public static void CreateHeaderList()
        {
            HeaderRuntime.Clear();
            foreach (Type header in HeaderList)
            {
                FieldInfo info = header.GetField("Type");
                FileType type = (FileType)info.GetValue(null);
                IsValidDelegate delegate_ = (IsValidDelegate)Delegate.CreateDelegate(typeof(IsValidDelegate), header.GetMethod("IsValid"));
                HeaderRuntime.Add(delegate_, type);
            }
        }

        public static FileType GetFileType(string filename)
        {
            int minBytes = 64;
            byte[] buffer;
            if (!File.Exists(filename)) return FileType.UNKNOWN;
            if (!Helper.IsFileValid(filename)) return FileType.UNKNOWN;
            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                if (stream.Length < minBytes)
                {
                    minBytes = (int)stream.Length;
                }
                buffer = new byte[minBytes];
                stream.Read(buffer, 0, minBytes);
            }
            return GetFileType(buffer);
        }

        public static FileType GetFileType(byte[] buffer)
        {
            foreach (KeyValuePair<IsValidDelegate, FileType> header in HeaderRuntime)
            {
                if (header.Key(buffer))
                {
                    return header.Value;
                }
            }
            return FileType.UNKNOWN;
        }
    }
}
