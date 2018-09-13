using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShenmueHDTools.Main.Database
{
    public class AudioDatabase
    {
        public static int SceneCount = 3;
        public static string SearchString = "file_";
        public static string AudioStreamFormatString = "SCENE/{0:D2}/STREAM/PC/{1}/{2}.{3}";


        private static bool SearchFile(byte[] buffer, int index)
        {
            for (int i = 0; i < SearchString.Length; i++)
            {
                if (buffer[index + i] != (byte)SearchString[i]) return false;
            }
            return true;
        }

        public static List<string> CrawlExecutable(string filename)
        {
            List<string> filenames = new List<string>();

            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                Dictionary<string, string> fileEntries = new Dictionary<string, string>();
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (SearchFile(buffer, i))
                    {
                        i += 5;
                        string fileEntry = "file_";
                        while(char.IsDigit((char)buffer[i]))
                        {
                            fileEntry += (char)buffer[i];
                            i++;
                        }

                        if (buffer[i + 2] != 0) continue; 

                        i += 2;
                        string audioEntry = "";
                        while (buffer[i] == 0)
                        {
                            i++;
                        }
                        while(char.IsLetterOrDigit((char)buffer[i]))
                        {
                            audioEntry += (char)buffer[i];
                            i++;
                        }

                        if (audioEntry == "file" || audioEntry == "new") continue;

                        if (!String.IsNullOrEmpty(audioEntry))
                        {
                            Console.WriteLine("\"{1}\",", fileEntry, audioEntry);
                            //fileEntries.Add(audioEntry, fileEntry);
                        }
                    }
                }
            }
            return filenames;
        }

        public static List<string> GenerateAudioFilenames()
        {
            List<string> filenames = new List<string>();
            AudioFilenames.AddRange(CrawledAudioFilenames);

            for (int i = 1; i < SceneCount + 1; i++)
            {
                foreach(string lang in AudioLanguages)
                {
                    foreach (string file in AudioFilenames)
                    {
                        foreach (string extension in AudioExtensions)
                        {
                            string filename = String.Format(AudioStreamFormatString, i, lang, file, extension);
                            uint hash = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(filename, false), 0);
                            FilenameDatabaseEntry entry = new FilenameDatabaseEntry(hash, 0, filename);
                            FilenameDatabase.Add(entry);
                        }
                    }
                }
            }
            return filenames;
        }

        public static List<string> AudioExtensions = new List<string>()
        {
            "IDX",
            "AFS",
            "SRF"
        };

        public static List<string> AudioLanguages = new List<string>()
        {
            "JAP",
            "ENG"
        };

        public static List<string> AudioFilenames = new List<string>()
        {
            "FREE01",
            "FREE02",
            "FREE03",
            "BGM01",
            "BGM02",
            "BGM03"
        };

        public static List<string> CrawledAudioFilenames = new List<string>()
        {
            "SA1007",
            "HUMANS",
            "SA1060",
            "SA1012",
            "SA1010",
            "SA1009",
            "SA1076",
            "SA1071",
            "SA1063",
            "SA1062",
            "SA1081",
            "SA1080",
            "SA1079",
            "SA1077",
            "SA1085",
            "SA1084",
            "SA1083",
            "SA1082",
            "SA1091",
            "SA1088",
            "SA1087",
            "SA1086",
            "SA1116",
            "SA1102",
            "SA1100",
            "SA1092",
            "SY04",
            "SY03",
            "SY02",
            "SY01",
            "SY08",
            "SY07",
            "SY06",
            "SY05",
            "SY10",
            "SY09",
            "01BEDA",
            "01BEDB",
            "01BUS",
            "01CAT1",
            "01JUCE",
            "01JUCEA",
            "01FULB",
            "01LET",
            "01MEM",
            "01KAK",
            "01KOZ",
            "01NVE",
            "01REV",
            "01MUT",
            "01NEK",
            "01TEL",
            "01YOB",
            "01SKI",
            "01SKIA",
            "A01114",
            "A01124",
            "A0100",
            "A01103",
            "A0114",
            "A0119",
            "A0125",
            "A0125A",
            "A0119",
            "A0122",
            "A0134",
            "A0136",
            "A0125B",
            "A0128",
            "A0142",
            "A0142B",
            "A0136A",
            "A0139",
            "A0173",
            "E1001D",
            "E1011",
            "E1002",
            "E1003",
            "E1014A",
            "E1017",
            "E1018",
            "E1020",
            "E1024",
            "E1027",
            "E1030",
            "E1025",
            "E1026",
            "E1031",
            "E1032",
            "E1040",
            "E1041",
            "E1036",
            "E1039",
            "E1064",
            "E1065",
            "E1044",
            "E1049",
            "E1068",
            "E1072",
            "E1066",
            "E1067",
            "E1076",
            "01BTU",
            "01BNK",
            "01ETU",
            "01EAR",
            "01DIS",
            "01CAT3",
            "01GAR",
            "01GAK",
            "01FRO",
            "01FRE",
            "01KEI",
            "01JIMB",
            "01JIM",
            "01HIS",
            "01OKO",
            "01MON",
            "01MIT",
            "01MIR",
            "A0132",
            "A01136",
            "01TAZ",
            "01SOR",
            "A0165",
            "A0160",
            "A0159",
            "A0154",
            "A0172A",
            "A0172",
            "A0169",
            "A0167",
            "E1008",
            "E1006",
            "E1005",
            "E1004A",
            "E1042",
            "E1010",
            "E1009B",
            "E1009A",
            "Q1003",
            "E1081",
            "E1061",
            "E1046",
            "SA1070",
            "SA1037",
            "SA1036",
            "SA1018",
            "SA1117",
            "SA1095",
            "SA1090",
            "SA1089",
            "SA1121",
            "SA1120",
            "SA1119",
            "SA1118",
            "SA1122",
            "E1060",
            "E1079",
            "SA1008",
            "SY11",
            "01HOK",
            "01INY",
            "E1012",
            "E1079",
            "SA1035",
            "SA1039",
            "SA1096",
            "SA1097",
            "SA1098",
            "SA1099",
            "SA1104",
            "SA1108",
            "SA1109",
            "SA1079A",
            "SA1115",
            "019RN",
            "01AYU",
            "01BIKE",
            "01BIKEB",
            "01CAU",
            "01CAUA",
            "01CBK",
            "01CJP",
            "01CRA",
            "01CTS",
            "01CTSA",
            "01CTSB",
            "01GET",
            "01GHO",
            "01GMO",
            "01GOHA",
            "01GOJ",
            "01GORA",
            "01JIB",
            "01JIN",
            "01KUB",
            "01LFT",
            "01MAD",
            "01MAK",
            "01MKB",
            "01MKJ",
            "01MSO",
            "01PHO",
            "01ROO",
            "01TAP",
            "01TLY",
            "01TLYA",
            "01TLYB",
            "01TLYC",
            "01TLYD",
            "01TLYE",
            "01TOMA",
            "01TOMB",
            "01TOMC",
            "01TOU",
            "01TSM",
            "A0174",
            "A0180",
            "A0184",
            "A0184B",
            "A0184C",
            "A0184D",
            "E1001A",
            "E1001B",
            "E1001C",
            "E1001E",
            "E1016",
            "E1019",
            "E1021",
            "E1022",
            "01CTSC",
            "E1037",
            "E1045",
            "E1047",
            "E1062",
            "E1063",
            "E1069",
            "E1070",
            "E1071",
            "E1073",
            "E1077",
            "E1078",
            "SA1053",
            "SA1093",
            "SA1094",
            "SA1101",
            "SA1103",
            "SA1105",
            "SA1106",
            "SA1114",
            "E1023"
        };
    }
}
