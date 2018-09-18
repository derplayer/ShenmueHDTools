using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Database
{

    public class WulinshuRaymonfAPIEntry
    {
        public string Path { get; set; }
        public string Hash { get; set; }
        public int Matches { get; set; }
        public string Game { get; set; }

        public FilenameDatabaseEntry CreateDatabaseEntry()
        {
            FilenameDatabaseEntry entry = new FilenameDatabaseEntry();

            string[] splitted = Path.Split('.');
            bool hasHash = false;
            if (splitted[splitted.Length - 1].Length == 8)
            {
                hasHash = true;
            }

            if (hasHash)
            {
                entry.Filename = Path.Substring(0, Path.Length - 9);
                string secondHash = entry.Filename.Substring(entry.Filename.Length - 8);
                entry.SecondHash = uint.Parse(secondHash, System.Globalization.NumberStyles.HexNumber);
                entry.FirstHash = Helper.ReverseBytes(uint.Parse(Hash, System.Globalization.NumberStyles.HexNumber));
            }
            else
            {
                entry.Filename = Path;
                entry.FirstHash = Helper.ReverseBytes(uint.Parse(Hash, System.Globalization.NumberStyles.HexNumber));
            }

            return entry;
        }
    }

    public class WulinshuRaymonfAPI : IProgressable
    {
        private static readonly string Url = "https://wulinshu.raymonf.me";
        private static readonly string GetFormat = "{0}/api/hash/get?page={1}&game={2}";

        public static List<WulinshuRaymonfAPIEntry> Entries = new List<WulinshuRaymonfAPIEntry>();

        private static List<string> Games = new List<string>()
        {
            "sm1",
            "sm2",
            "both"
        };

        public event FinishedEventHandler Finished;
        public event ProgressChangedEventHandler ProgressChanged;
        public event DescriptionChangedEventHandler DescriptionChanged;
        public event ErrorEventHandler Error;

        public static void Read(string filename)
        {
            Entries.Clear();
            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    JArray entries = (JArray)JsonConvert.DeserializeObject(json);
                    foreach(JToken token in entries.Children())
                    {
                        WulinshuRaymonfAPIEntry entry = new WulinshuRaymonfAPIEntry
                        {
                            Path = token.SelectToken("Path").Value<string>(),
                            Hash = token.SelectToken("Hash").Value<string>(),
                            Matches = token.SelectToken("Matches").Value<int>(),
                            Game = token.SelectToken("Game").Value<string>()
                        };
                        Entries.Add(entry);
                    }
                }
            }
        }

        public static void Write(string filename)
        {
            using (FileStream stream = File.Create(filename))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    string json = JsonConvert.SerializeObject(Entries, Formatting.Indented);
                    writer.Write(json);
                }
            }
        }

        public void Abort()
        {
            //throw new NotImplementedException();
        }

        public void FetchData(string game)
        {
            Entries.Clear();

            string url = String.Format(GetFormat, Url, 1, game);
            WebRequest request = WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response == null || response.StatusCode != HttpStatusCode.OK)
            {
                using (MemoryStream stream = new MemoryStream(Properties.Resources.Wulinshu_Raymonf_Backup))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    JArray entries = (JArray)JsonConvert.DeserializeObject(json);
                    foreach (JToken token in entries.Children())
                    {
                        WulinshuRaymonfAPIEntry entry = new WulinshuRaymonfAPIEntry
                        {
                            Path = token.SelectToken("Path").Value<string>(),
                            Hash = token.SelectToken("Hash").Value<string>(),
                            Matches = token.SelectToken("Matches").Value<int>(),
                            Game = token.SelectToken("Game").Value<string>()
                        };
                        Entries.Add(entry);
                    }
                }
                Finished(this, new FinishedArgs(true));
                return;
            }

            string text;

            int pageCount = 1;

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
                dynamic data = JsonConvert.DeserializeObject(text);
                pageCount = (int)data.SelectToken("last_page").Value;
            }

            for (int i = 1; i < pageCount; i++)
            {
                DescriptionChanged(this, new DescriptionChangedArgs(String.Format("Fetching page {0}...", i)));
                ProgressChanged(this, new ProgressChangedArgs(i, pageCount));
                url = String.Format(GetFormat, Url, i, game);
                request = WebRequest.Create(url);
                response = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
                    dynamic data = JsonConvert.DeserializeObject(text);
                    JToken token = data.SelectToken("data");
                    foreach (JToken child in token.Children())
                    {
                        WulinshuRaymonfAPIEntry entry = new WulinshuRaymonfAPIEntry
                        {
                            Path = child.SelectToken("path").Value<string>(),
                            Hash = child.SelectToken("hash").Value<string>(),
                            Matches = child.SelectToken("matches").Value<int>(),
                            Game = child.SelectToken("game").Value<string>()
                        };
                        Entries.Add(entry);
                    }
                }
            }
            Finished(this, new FinishedArgs(true));
        }

    }
}
