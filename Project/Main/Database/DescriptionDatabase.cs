using ShenmueHDTools.Main.Files;
using ShenmueHDTools.Main.Files.Nodes;
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

    class DescriptionDatabase : IProgressable
    {

        public static List<DescriptionDatabaseEntry> Entries = new List<DescriptionDatabaseEntry>();

        public bool IsAbortable { get { return false; } }

        public event FinishedEventHandler Finished;
        public event ProgressChangedEventHandler ProgressChanged;
        public event DescriptionChangedEventHandler DescriptionChanged;
        public event ErrorEventHandler Error;

        public static void GenerateDatabase()
        {
            Entries.Clear();

            using (StringReader reader = new StringReader(Resources.data["desc_maps_sm1"]))
            {
                string line = string.Empty;
                line = reader.ReadLine();
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

            using (StringReader reader = new StringReader(Resources.data["desc_chars_sm1"]))
            {
                string line = string.Empty;
                line = reader.ReadLine();
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

            using (StringReader reader = new StringReader(Resources.data["desc_audio_sm1"]))
            {
                string line = string.Empty;
                line = reader.ReadLine();
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        var lineArr = line.Split(';');
                        if (lineArr.Length < 2) continue;
                        DescriptionDatabaseEntry entry = new DescriptionDatabaseEntry(lineArr[0], lineArr[1]);
                        Entries.Add(entry);
                    }
                } while (line != null);
            }
        }

        public void MapDescriptionToTADInstance(TADFile tadFile)
        {
            DescriptionChanged(this, new DescriptionChangedArgs("Mapping descriptions to TAD..."));
            for (int i = 0; i < tadFile.FileEntries.Count; i++)
            {
                ProgressChanged(this, new ProgressChangedArgs(i, tadFile.FileEntries.Count));
                TADFileEntry entry = tadFile.FileEntries[i];
                foreach (DescriptionDatabaseEntry e in Entries)
                {
                    if (entry.Filename.Contains(e.ID) || (!String.IsNullOrEmpty(e.ModelID) && entry.Filename.Contains(e.ModelID)))
                    {
                        entry.Description = e.Name;
                        continue;
                    }
                }
            }
            Finished(this, new FinishedArgs(true));
        }

        public void MapDescriptionToNodeInstance(CacheFile cacheFile)
        {
            DescriptionChanged(this, new DescriptionChangedArgs("Mapping descriptions to files..."));
            for (int i = 0; i < cacheFile.Files.Count; i++)
            {
                ProgressChanged(this, new ProgressChangedArgs(i, cacheFile.Files.Count));
                FileNode entry = cacheFile.Files[i];
                foreach (DescriptionDatabaseEntry e in Entries)
                {
                    if (entry.RelativPath.Contains(e.ID) || (!String.IsNullOrEmpty(e.ModelID) && entry.RelativPath.Contains(e.ModelID)))
                    {
                        entry.Description = e.Name;
                        continue;
                    }
                }
            }
            Finished(this, new FinishedArgs(true));
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

        public void Abort()
        {
            //throw new NotImplementedException();
        }
    }
}
