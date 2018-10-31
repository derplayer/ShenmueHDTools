using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShenmueHDTools.Main.Database
{
    public class AssetRemappingJSON
    {
        public int Version;
        public bool HasFullLocationPaths;
        public List<Unique> Uniques = new List<Unique>();
        public List<Location> Locations = new List<Location>();
        public List<HashCollisions> HashCollisionStrings = new List<HashCollisions>();
        private string HashCollisionString = "";

        private Dictionary<Location, Unique> LocationMap = new Dictionary<Location, Unique>();
        private static string RMPFormat = "/remap/{0}{1}-{2}{3}-{4}-{5}.rmp";

        //Deserialize...
        public AssetRemappingJSON(byte[] dataArray)
        {
            var jsonString = Encoding.ASCII.GetString(dataArray, 0, dataArray.Length);
            dynamic data = JsonConvert.DeserializeObject(jsonString);

            Version = data.Version;
            HasFullLocationPaths = data.HasFullLocationPaths;

            foreach (dynamic item in data.Uniques)
            {
                Uniques.Add(new Unique(item.FileSize, item.ContHashTex, item.ContHashMD5));
            }

            foreach (dynamic item in data.Locations)
            {
                Locations.Add(new Location(item.LocHash, item.UniqueIdx, item.LocStrIdx));
            }

            //Split HashCollisionStrings from dynamic
            HashCollisionString = data.HashCollisionStrings.Value;
            string[] tempStrArr = data.HashCollisionStrings.Value.Split('!');

            foreach (var str in tempStrArr)
            {
                HashCollisionStrings.Add(new HashCollisions(str));
            }

            GenerateLocationMap();
        }

        public Dictionary<string, string> GenerateRMPFilenames()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (KeyValuePair<Location, Unique> pair in LocationMap)
            {
                string hash1 = pair.Value.ContHashContainer.ContHashMD5_2.ToString("x");
                string hash2 = pair.Value.ContHashContainer.ContHashMD5_1.ToString("x");
                string hash3 = pair.Value.ContHashContainer.ContHashMD5_4.ToString("x");
                string hash4 = pair.Value.ContHashContainer.ContHashMD5_3.ToString("x");
                string hash5 = pair.Value.ContHashTex.ToString("x");
                string fileSize = pair.Value.FileSize.ToString();

                string filename = String.Format(RMPFormat, hash1, hash2, hash3, hash4, hash5, fileSize);

                string tmp = HashCollisionString.Substring((int)pair.Key.LocStrIdx);

                if (tmp.IndexOf('!') > 0)
                {
                    tmp = tmp.Substring(0, tmp.IndexOf('!'));
                }
                tmp = MurmurHash2Shenmue.GetFullFilename(tmp, false).Substring(1);
                result.Add(tmp.Substring(0, tmp.Length - 9), filename);

                /*
                uint hash2_ = MurmurHash2Shenmue.GetFilenameHashPlain(filename);
                string fFilename = MurmurHash2Shenmue.GetFullFilename(filename, hash2_);
                uint hash1_ = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(fFilename), 0);

                Console.WriteLine("{0} => {1} LocHash: {2:X8} ({2}), FileSize: {3}, HashedFilename: {4} ({5:X8})",
                    tmp, filename, pair.Key.LocHash, pair.Value.FileSize, fFilename, hash1_);
                    */
            }
            return result;
        }

        public void GenerateLocationMap()
        {
            foreach (Location location in Locations)
            {
                LocationMap.Add(location, Uniques[(int)location.UniqueIdx]);
            }
        }

    }

    

    public class Unique
    {
        public ContHashMD5 ContHashContainer;
        public ulong ContHashTex;
        public uint FileSize;

        public Unique(dynamic FileSizeParam, dynamic ContHashTexParam, dynamic ContHashMD5Param)
        {
            FileSize = (uint)FileSizeParam.Value;
            ContHashTex = (ulong)ContHashTexParam.Value;

                ContHashContainer = new ContHashMD5()
                {
                    ContHashMD5_1 = (uint)ContHashMD5Param[0].Value,
                    ContHashMD5_2 = (uint)ContHashMD5Param[1].Value,
                    ContHashMD5_3 = (uint)ContHashMD5Param[2].Value,
                    ContHashMD5_4 = (uint)ContHashMD5Param[3].Value
                };
        }
    }

    public class Location
    {
        public ulong LocHash;
        public uint UniqueIdx;
        public uint LocStrIdx;

        public Location(dynamic LocHashParam, dynamic UniqueIdxParam, dynamic LocStrIdxParam)
        {
            LocHash = (ulong)LocHashParam.Value;
            UniqueIdx = (uint)UniqueIdxParam.Value;
            LocStrIdx = (uint)LocStrIdxParam.Value;
        }
    }

    public class HashCollisions
    {
        public HashCollisions(string HashCollisionString)
        {
            // /engine/assets/shaders/billboard_ps.hlsl.8f8c3faf.bc77fa0f
            string[] tempStrArr = HashCollisionString.Split('.');

            FileNameFull = HashCollisionString;
            FileName = tempStrArr[0];
            FileExt = tempStrArr[1];
            FileNameHash = StringToByteArray(tempStrArr[2]);
            OtherHash = StringToByteArray(tempStrArr[3]);
        }

        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public string FileNameFull;
        public string FileName;
        public string FileExt;
        public byte[] FileNameHash;
        public byte[] OtherHash;
    }

    public class ContHashMD5
    {
        public uint ContHashMD5_1;
        public uint ContHashMD5_2;
        public uint ContHashMD5_3;
        public uint ContHashMD5_4;
    }

}