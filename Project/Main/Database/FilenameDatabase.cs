using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ShenmueHDTools.Main.Files;
using System.IO;

namespace ShenmueHDTools.Main.Database
{
    [Serializable]
    class FilenameDatabaseEntry
    {
        public uint FirstHash { get; set; } = 0;
        public uint SecondHash { get; set; } = 0;
        public uint Unknown { get; set; } = 0;
        public string Filename { get; set; } = "";
        public uint FileSize { get; set; } = 0;

        public FilenameDatabaseEntry() { }
        public FilenameDatabaseEntry(uint firstHash, uint secondHash, string filename)
        {
            FirstHash = firstHash;
            SecondHash = secondHash;
            Filename = filename;
        }

        public FilenameDatabaseEntry(uint firstHash, string filename, uint fileSize)
        {
            FirstHash = firstHash;
            FileSize = fileSize;
            Filename = filename;
        }

        public bool Compare(TADFileEntry tadFileEntry)
        {
            if (FileSize > 0)
            {
                /*
                if (FirstHash == tadFileEntry.FirstHash &&
                FileSize == tadFileEntry.FileSize) return true;
                */

                //unsafe
                if (FirstHash == tadFileEntry.FirstHash) return true;
            }
            else
            {
                if (FirstHash == tadFileEntry.FirstHash &&
                SecondHash == tadFileEntry.SecondHash) return true;
            }
            return false;
        }
    }

    class FilenameDatabase
    {
        public static List<FilenameDatabaseEntry> Entries { get; set; } = new List<FilenameDatabaseEntry>();

        public static void Load(string filename)
        {
            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Entries = (List<FilenameDatabaseEntry>)formatter.Deserialize(stream);
            }
        }
        public static void Save(string filename)
        {
            using (FileStream stream = File.Create(filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Entries);
            }
        }

        public static string GetFilename(TADFileEntry tadFileEntry)
        {
            foreach (FilenameDatabaseEntry entry in Entries)
            {
                if (entry.Compare(tadFileEntry)) return entry.Filename;
            }
            return "";
        }

        public static void MapFilenamesToTAD(TADFile tadFile)
        {
            foreach (TADFileEntry entry in tadFile.FileEntries)
            {
                foreach (FilenameDatabaseEntry dbEntry in Entries)
                {
                    if (dbEntry.Compare(entry))
                    {
                        string filename = dbEntry.Filename;
                        if (filename[0] == '.')
                        {
                            filename = filename.Substring(1);
                        }
                        entry.Filename = filename;

                        Console.WriteLine("FOUND FILE: [{0}] {1}", dbEntry.FirstHash.ToString("X8"), filename);
                    }
                }
            }
        }

        public static void Add(uint firstHash, uint secondHash, string filename)
        {
            Entries.Add(new FilenameDatabaseEntry(firstHash, secondHash, filename));
        }

        public static void Add(FilenameDatabaseEntry entry)
        {
            Entries.Add(entry);
        }

        public static void Clear()
        {
            Entries.Clear();
        }
    }
}
