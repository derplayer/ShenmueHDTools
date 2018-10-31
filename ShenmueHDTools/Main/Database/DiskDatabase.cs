using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShenmueHDTools.Main.Database
{
    public class DiskDatabase
    {
        public static void GenerateDiskFilenames()
        {
            //Swap between Shenmue 1 and 2 to improve the hash perfrmance a bit
            List<string> discCollection = new List<string>();
            //Shenmue v1.001 EU
            discCollection.Add(Resources.data["EU_D1"]);
            discCollection.Add(Resources.data["EU_D2"]);
            discCollection.Add(Resources.data["EU_D3"]);
            discCollection.Add(Resources.data["EU_PASS"]);

            //Shenmue IIx US
            discCollection.Add(Resources.data["US_2x_DVD"]);

            //Shenmue II v1.001 EU
            discCollection.Add(Resources.data["EU_2_D1"]);
            discCollection.Add(Resources.data["EU_2_D2"]);
            discCollection.Add(Resources.data["EU_2_D3"]);
            discCollection.Add(Resources.data["EU_2_PASS"]);

            //Shenmue v1.007 JAP
            discCollection.Add(Resources.data["JAP_D1"]);
            discCollection.Add(Resources.data["JAP_D2"]);
            discCollection.Add(Resources.data["JAP_D3"]);
            discCollection.Add(Resources.data["JAP_PASS"]);

            //Shenmue 2 v1.001 JAP
            discCollection.Add(Resources.data["JP_2_D1"]);
            discCollection.Add(Resources.data["JP_2_D2"]);
            discCollection.Add(Resources.data["JP_2_D3"]);
            discCollection.Add(Resources.data["JP_2_D4"]);

            //Shenmue v1.003 US
            discCollection.Add(Resources.data["US_D1"]);
            discCollection.Add(Resources.data["US_D2"]);
            discCollection.Add(Resources.data["US_D3"]);
            discCollection.Add(Resources.data["US_PASS"]);

            //Shenmue BETA v0.400
            discCollection.Add(Resources.data["B_D1"]);
            discCollection.Add(Resources.data["B_D2"]);
            discCollection.Add(Resources.data["B_D3"]);
            discCollection.Add(Resources.data["B_PASS"]);

            //What's Shemue - JP
            discCollection.Add(Resources.data["WS_D1"]);

            string fName = "/misc/SegaLogo.wav";
            uint fSize = 480044;
            uint fHash = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(fName, false), 0);
            FilenameDatabaseEntry e = new FilenameDatabaseEntry(fHash, fName, fSize, ArchiveTypes.Disk);
            FilenameDatabase.Add(e);

            foreach (string filename in HarrierFilenames)
            {
                string hFilename = filename.Replace("\\", "/");
                uint fileSize = 0;
                uint hash = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(hFilename, false), 0);
                FilenameDatabaseEntry entry = new FilenameDatabaseEntry(hash, hFilename, fileSize, ArchiveTypes.Disk);
                FilenameDatabase.Add(entry);
            }

            int actCount = 3;
            for (int i = 1; i < actCount + 1; i++)
            {
                foreach (string scene in ScenarioNames)
                {
                    string filename = String.Format(ScenarioFormat, i, scene);
                    uint hash = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(filename, false), 0);
                    FilenameDatabaseEntry entry = new FilenameDatabaseEntry(hash, 0, filename, ArchiveTypes.Disk);
                    FilenameDatabase.Add(entry);
                }
            }

            //TODO: Test 99 scenes
            foreach (string scene in ScenarioNames)
            {
                string filename = String.Format(ScenarioFormat, 99, scene);
                uint hash = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(filename, false), 0);
                FilenameDatabaseEntry entry = new FilenameDatabaseEntry(hash, 0, filename, ArchiveTypes.Disk);
                FilenameDatabase.Add(entry);
            }


            foreach (var disc in discCollection)
            {
                using (StringReader reader = new StringReader(disc))
                {
                    string line = string.Empty;
                    do
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            var lineArr = line.Split(' ');
                            string filename = lineArr[0].Replace("\\", "/");
                            uint fileSize = Convert.ToUInt32(lineArr[1]);
                            uint hash = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(filename, false), 0);
                            FilenameDatabaseEntry entry = new FilenameDatabaseEntry(hash, filename, fileSize, ArchiveTypes.Disk);
                            FilenameDatabase.Add(entry);
                        }

                    } while (line != null);
                }
            }
        }

        public static List<string> HarrierFilenames = new List<string>()
        {
            "XHAR\\sound\\sfx\\00000000.wav",
            "XHAR\\sound\\sfx\\00000001.wav",
            "XHAR\\sound\\sfx\\00000002.wav",
            "XHAR\\sound\\sfx\\00000003.wav",
            "XHAR\\sound\\sfx\\00000004.wav",
            "XHAR\\sound\\sfx\\00000005.wav",
            "XHAR\\sound\\sfx\\00000006.wav",
            "XHAR\\sound\\sfx\\00000007.wav",
            "XHAR\\sound\\sfx\\00000008.wav",
            "XHAR\\sound\\sfx\\00000009.wav",
            "XHAR\\sound\\sfx\\0000000a.wav",
            "XHAR\\sound\\sfx\\0000000b.wav",
            "XHAR\\sound\\sfx\\0000000c.wav",
            "XHAR\\sound\\sfx\\0000000d.wav",
            "XHAR\\sound\\sfx\\0000000e.wav",
            "XHAR\\sound\\sfx\\0000000f.wav",
            "XHAR\\sound\\sfx\\00000010.wav",
            "XHAR\\sound\\sfx\\00000011.wav",
            "XHAR\\sound\\sfx\\00000012.wav",
            "XHAR\\sound\\sfx\\00000013.wav",
            "XHAR\\sound\\sfx\\00000014.wav",
            "XHAR\\sound\\sfx\\00000015.wav",
            "XHAR\\sound\\sfx\\00000016.wav",
            "XHAR\\sound\\sfx\\00000017.wav",
            "XHAR\\sound\\sfx\\00000018.wav",
            "XHAR\\sound\\sfx\\00000019.wav",
            "XHAR\\sound\\sfx\\0000001a.wav",
            "XHAR\\sound\\sfx\\0000001b.wav",
            "XHAR\\sound\\sfx\\0000001c.wav",
            "XHAR\\sound\\sfx\\0000001d.wav",
            "XHAR\\sound\\sfx\\0000001e.wav",
            "XHAR\\sound\\sfx\\0000001f.wav",
            "XHAR\\sound\\sfx\\00000020.wav",
            "XHAR\\sound\\sfx\\00000021.wav",
            "XHAR\\sound\\sfx\\00000022.wav",
            "XHAR\\sound\\sfx\\00000023.wav",
            "XHAR\\sound\\sfx\\00000024.wav",
            "XHAR\\sound\\sfx\\00000025.wav",
            "XHAR\\sound\\sfx\\00000026.wav",
            "XHAR\\sound\\sfx\\00000027.wav",
            "XHAR\\sound\\sfx\\00000028.wav",
            "XHAR\\sound\\sfx\\00000029.wav",
            "XHAR\\sound\\sfx\\0000002a.wav",
            "XHAR\\sound\\sfx\\0000002b.wav",
            "XHAR\\sound\\sfx\\0000002c.wav",
            "XHAR\\sound\\sfx\\0000002d.wav",
            "XHAR\\sound\\sfx\\0000002e.wav",
            "XHAR\\sound\\sfx\\0000002f.wav",
            "XHAR\\sound\\sfx\\00000030.wav",
            "XHAR\\sound\\sfx\\00000031.wav",
            "XHAR\\sound\\sfx\\00000032.wav",
            "XHAR\\sound\\sfx\\00000033.wav",
            "XHAR\\sound\\sfx\\00000034.wav",
            "XHAR\\sound\\sfx\\00000035.wav",
            "XHAR\\sound\\sfx\\00000036.wav",
            "XHAR\\sound\\sfx\\00000037.wav",
            "XHAR\\sound\\sfx\\00000038.wav",
            "XHAR\\sound\\sfx\\00000039.wav",
            "XHAR\\sound\\sfx\\0000003a.wav",
            "XHAR\\sound\\sfx\\0000003b.wav",
            "XHAR\\sound\\sfx\\0000003c.wav",
            "XHAR\\sound\\sfx\\0000003d.wav",
            "XHAR\\sound\\sfx\\0000003e.wav",
            "XHAR\\sound\\sfx\\0000003f.wav",
            "XHAR\\sound\\sfx\\00000040.wav",
            "XHAR\\sound\\sfx\\00000041.wav",
            "XHAR\\sound\\sfx\\00000042.wav",
            "XHAR\\sound\\sfx\\00000043.wav",
            "XHAR\\sound\\sfx\\00000044.wav",
            "XHAR\\sound\\sfx\\00000045.wav",
            "XHAR\\sound\\harrier_a3.wav",
            "XHAR\\sound\\harrier_a4.wav",
            "XHAR\\sound\\harrier_a5.wav",
            "XHAR\\sound\\harrier_a6.wav",
            "XHAR\\sound\\harrier_aa.wav",
            "XHAR\\sound\\harrier_ab.wav",
            "XHAR\\sound\\harrier_ad.wav",
            "XHAR\\sound\\harrier_ae.wav",
            "XHAR\\sound\\harrier_af.wav",
            "XHAR\\sound\\harrier_b0.wav",
            "XHAR\\sound\\harrier_b1.wav",
            "XHAR\\sound\\harrier_b2.wav",
            "XHAR\\sound\\harrier_b7.wav",
            "XHAR\\sound\\harrier_b8.wav",
            "XHAR\\sound\\harrier_b9.wav",
            "XHAR\\datas\\HAR.ROM",
            "XHAR\\datas\\SHXOBJ.BIN",
            "XHAR\\datas\\SHXBG.BIN",
            "XHAR\\datas\\FILL.BMP",
            "XHAR\\datas\\SHICPAT.BMP",
            "XHAR\\datas\\SYSASCII.BMP"
        };

        public static string ScenarioFormat = "/SCENARIO/act{0:D2}_{1}.SCN";

        public static List<string> ScenarioNames = new List<string>()
        {
            "0000",
            "ARAR",
            "BETD",
            "D000",
            "DAZA",
            "DBHB",
            "DBYO",
            "DCBN",
            "DCHA",
            "DGCT",
            "DHQB",
            "DJAZ",
            "DKPA",
            "DKTY",
            "DMAJ",
            "DNOZ",
            "DOOR",
            "DPIZ",
            "DRHT",
            "DRME",
            "DRSA",
            "DSBA",
            "DSKI",
            "DSLI",
            "DSLT",
            "DSUS",
            "DTKY",
            "DURN",
            "DXMS",
            "DYKZ",
            "FACE",
            "FBGG",
            "FREE",
            "GMCT",
            "JABE",
            "JD00",
            "JD99",
            "JHD0",
            "JOMO",
            "JU00",
            "JU99",
            "M3FB",
            "MA00",
            "MB9Q",
            "MBQC",
            "MC5Q",
            "MEND",
            "MF99",
            "MFBT",
            "MFSY",
            "MK80",
            "MK99",
            "MKSG",
            "MKYU",
            "MO99",
            "MS08",
            "MS8A",
            "MS8S",
            "MSBS",
            "NBIK",
            "OP00",
            "OP02",
            "TATQ",
            "TERY",
            "TOKI",
            "VEND",
            "YD01",
            "YD8S",
            "YDB1",
            "YDMA",
            "YQ14"
        };
    }
}
