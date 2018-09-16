using ShenmueHDTools.Main.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files.Headers;
using System.IO;

namespace ShenmueHDTools.Main.Files
{
    public class CacheFile
    {
        public static readonly string Extension = ".shdcache";

        public CacheHeader Header { get; set; } = new CacheHeader();
        public TADFile TADFile { get; set; }
        public string Filename { get; set; }

        public CacheFile() { }
        public CacheFile(TADFile tadFile)
        {
            TADFile = tadFile;
        }

        public void Unpack()
        {
            string tacFilename = Path.GetFileName(TADFile.Filename).ToLower().Replace("tad", "tac");
            string tacPath = Path.GetDirectoryName(TADFile.Filename) + "\\" + tacFilename;
            string targetDirectory = Path.GetDirectoryName(tacPath) + "\\" + "_" + tacFilename + "_";

            Header.RelativeOutputFolder = "\\" + Helper.GetRelativePath(targetDirectory, Path.GetDirectoryName(tacPath));
            Header.RelativeTACPath = "\\" + Helper.GetRelativePath(tacPath, Path.GetDirectoryName(tacPath));
            Header.RelativeTADPath = "\\" + Helper.GetRelativePath(TADFile.Filename, Path.GetDirectoryName(tacPath));

            TACFile.Unpack(tacPath, targetDirectory, TADFile);

            string cachePath = Path.GetDirectoryName(tacPath) + "\\" + Path.GetFileName(TADFile.Filename).ToLower().Replace("tad", "cache");
            Filename = cachePath;
            Write(cachePath);
        }

        public void Export(string tadFilename)
        {

        }

        public void Pack()
        {
            string tacPath = Path.GetDirectoryName(Filename) + Header.RelativeTACPath;
            string inputFolder = Path.GetDirectoryName(Filename) + Header.RelativeOutputFolder;
            TACFile.Pack(tacPath, inputFolder, TADFile);
        }

        public void Read(string filename)
        {
            Filename = filename;
            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    Header.Read(reader);
                    TADFile = new TADFile();
                    TADFile.Read(reader, true);
                }
            }
        }

        public void Write(string filename)
        {
            using (FileStream stream = File.Create(filename))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    Header.Write(writer);
                    TADFile.Write(writer, true);
                }
            }
        }

        public void ConvertLegacy(DataCollection dataCollection)
        {
            TADFile = new TADFile();
            TADFile.Header.FileCount = BitConverter.ToUInt32(dataCollection.Header.FileCount1, 0);
            TADFile.Header.HeaderChecksum = BitConverter.ToUInt32(dataCollection.Header.HeaderChecksum, 0);
            TADFile.Header.TacSize = BitConverter.ToUInt32(dataCollection.Header.TacSize, 0);
            TADFile.Header.UnixTimestamp = new DateTime(1970, 1, 1).AddSeconds(BitConverter.ToInt32(dataCollection.Header.UnixTimestamp, 0));

            foreach (FileStructure file in dataCollection.Files)
            {
                TADFileEntry entry = new TADFileEntry();
                entry.FileOffset = BitConverter.ToUInt32(file.FileStart, 0);
                entry.FileSize = BitConverter.ToUInt32(file.FileSize, 0);

                byte[] firstHash = new byte[4];
                Array.Copy(file.Hash1, firstHash, 4);
                entry.FirstHash = BitConverter.ToUInt32(firstHash, 0);

                byte[] secondHash = new byte[4];
                Array.Copy(file.Hash1, 4, secondHash, 0, 4);
                entry.SecondHash = BitConverter.ToUInt32(secondHash, 0);

                byte[] unknown = new byte[4];
                Array.Copy(file.Hash2, 0, unknown, 0, 4);
                entry.Unknown = BitConverter.ToUInt32(unknown, 0);

                entry.MD5Checksum = file.Meta.MD5Hash;

                TADFile.FileEntries.Add(entry);
            }
        }
    }
}
