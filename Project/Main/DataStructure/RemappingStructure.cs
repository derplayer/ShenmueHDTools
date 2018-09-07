using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShenmueHDTools.Main.DataStructure
{
    public class RemappingStructure
    {
        public int Version;
        public bool HasFullLocationPaths;
        public List<Unique> Uniques = new List<Unique>();
        public List<Location> Locations = new List<Location>();
        public List<HashCollisions> HashCollisionStrings = new List<HashCollisions>();

        //Deserialize...
        public RemappingStructure(byte[] dataArray)
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
            string[] tempStrArr = data.HashCollisionStrings.Value.Split('!');

            foreach (var str in tempStrArr)
            {
                HashCollisionStrings.Add(new HashCollisions(str));
            }

        }

    }

    public class Unique
    {
        public ContHashMD5 ContHashContainer;
        public byte[] ContHashTex;
        public byte[] FileSize;

        public Unique(dynamic FileSizeParam, dynamic ContHashTexParam, dynamic ContHashMD5Param)
        {
            FileSize = BitConverter.GetBytes(FileSizeParam.Value);
            ContHashTex = BitConverter.GetBytes(ContHashTexParam.Value);

                ContHashContainer = new ContHashMD5()
                {
                    ContHashMD5_1 = BitConverter.GetBytes(ContHashMD5Param[0].Value),
                    ContHashMD5_2 = BitConverter.GetBytes(ContHashMD5Param[1].Value),
                    ContHashMD5_3 = BitConverter.GetBytes(ContHashMD5Param[2].Value),
                    ContHashMD5_4 = BitConverter.GetBytes(ContHashMD5Param[3].Value)
                };
        }
    }

    public class Location
    {
        public byte[] LocHash;
        public byte[] UniqueIdx;
        public byte[] LocStrIdx;

        public Location(dynamic LocHashParam, dynamic UniqueIdxParam, dynamic LocStrIdxParam)
        {
            LocHash = BitConverter.GetBytes(LocHashParam.Value);
            UniqueIdx = BitConverter.GetBytes(UniqueIdxParam.Value);
            UniqueIdx = BitConverter.GetBytes(LocStrIdxParam.Value);
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
        public byte[] ContHashMD5_1;
        public byte[] ContHashMD5_2;
        public byte[] ContHashMD5_3;
        public byte[] ContHashMD5_4;
    }

}