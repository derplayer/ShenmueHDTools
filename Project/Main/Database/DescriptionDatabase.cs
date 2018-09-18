using ShenmueHDTools.Main.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Database
{

    class DescriptionDatabaseEntry
    {
        public string ID { get; set; }
        public string ModelID { get; set; }
        public string Name { get; set; }

        public DescriptionDatabaseEntry(string id, string name, string modelId = "")
        {
            ID = id;
            Name = name;
            ModelID = modelId;
        }
    }

    class DescriptionDatabase
    {

        public static List<DescriptionDatabaseEntry> Entries = new List<DescriptionDatabaseEntry>();

        public static void GenerateDatabase()
        {
            Entries.Clear();

            using (StringReader reader = new StringReader(Properties.Resources.desc_maps_sm1))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        var lineArr = line.Split(';');
                        if (lineArr.Length < 2) continue;
                        if (lineArr[1].Length < 4) continue;
                        DescriptionDatabaseEntry entry = new DescriptionDatabaseEntry(lineArr[1].Substring(0, 4), lineArr[0]);
                        Entries.Add(entry);
                    }
                } while (line != null);
            }

            using (StringReader reader = new StringReader(Properties.Resources.desc_chars_sm1))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        var lineArr = line.Split(';');
                        if (lineArr.Length < 2) continue;
                        if (lineArr[1].Length < 4) continue;
                        DescriptionDatabaseEntry entry = new DescriptionDatabaseEntry(lineArr[1].Substring(0, 4), lineArr[0], lineArr[2].Replace(" ", ""));
                        Entries.Add(entry);
                    }

                } while (line != null);
            }
        }

        public static void MapDescriptionToTAD(TADFile tadFile)
        {
            foreach (TADFileEntry entry in tadFile.FileEntries)
            {
                foreach (DescriptionDatabaseEntry e in Entries)
                {
                    if (entry.Filename.Contains(e.ID) || (!String.IsNullOrEmpty(e.ModelID) && entry.Filename.Contains(e.ModelID)))
                    {
                        entry.Description = e.Name;
                        continue;
                    }
                }
            }
        }
    }
}
