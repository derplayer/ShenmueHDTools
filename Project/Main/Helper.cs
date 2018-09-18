using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Serialization.Json;
using System.Reflection;
using System.Windows.Forms;

namespace ShenmueHDTools.Main
{
    public static class JSONSerializer<TType> where TType : class
    {
        /// <summary>
        /// Deserializes an object from JSON with 100% .net libary (system.runtime.serialization.json)
        /// </summary>
        public static TType DeSerialize(string json)
        {
            using (var stream = new MemoryStream(Encoding.Default.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(TType));
                return serializer.ReadObject(stream) as TType;
            }
        }
    }

    public class Helper
    {
        public static DataGridView DoubleBuffered(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);

            return dgv;
        }

        public static DataGridViewEx DoubleBuffered(DataGridViewEx dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);

            return dgv;
        }

        public static string Reverse(string text)
        {
            if (text == null) return null;
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }

        public static uint ReverseBytes(uint value)
        {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }

        public static uint HashReverse(uint x)
        {
            // swap adjacent 16-bit blocks
            x = (x >> 16) | (x << 16);
            // swap adjacent 8-bit blocks
            return ((x & 0xFF00FF00) >> 8) | ((x & 0x00FF00FF) << 8);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <param name="bytesToCompare"> 0 means compare entire arrays</param>
        /// <returns></returns>
        public static bool ArraysEqual(byte[] array1, byte[] array2, int bytesToCompare = 0)
        {
            if (array1.Length != array2.Length) return false;

            var length = (bytesToCompare == 0) ? array1.Length : bytesToCompare;
            var tailIdx = length - length % sizeof(Int64);

            //check in 8 byte chunks
            for (var i = 0; i < tailIdx; i += sizeof(Int64))
            {
                if (BitConverter.ToInt64(array1, i) != BitConverter.ToInt64(array2, i)) return false;
            }

            //check the remainder of the array, always shorter than 8 bytes
            for (var i = tailIdx; i < length; i++)
            {
                if (array1[i] != array2[i]) return false;
            }

            return true;
        }


        public static byte[] MD5Hash(byte[] data)
        {
            using (var md5 = MD5.Create())
            {
                md5.ComputeHash(data, 0, data.Length);
                return md5.Hash;
            }
        }

        public static byte[] MD5Hash(FileStream stream)
        {
            using (var md5 = MD5.Create())
            {
                md5.ComputeHash(stream);
                return md5.Hash;
            }
        }


        public static string ExtensionFinder(byte[] dataArray)
        {
            var fileExt = ".unknown";

            var semiIdentifier = Encoding.ASCII.GetString(dataArray.Take(3).ToArray());

            if (semiIdentifier == "DDS")
                return ".dds";

            if (semiIdentifier == "IDX")
                return ".idx";

            if (semiIdentifier == "AFS")
                return ".afs";

            var semiIdentifier4 = Encoding.ASCII.GetString(dataArray.Take(4).ToArray());
            if (semiIdentifier4 == "RIFF")
                return ".wav";

            if (semiIdentifier4 == "DXBC")
                return ".hlsl";

            if (semiIdentifier4 == "PAKS") //IPAC Browser
                return ".pks";

            if (semiIdentifier4 == "PAKF") //IPAC Browser
                return ".pkf";

            if (semiIdentifier4 == "HRCM") //MT5
                return ".mt5";

            if (semiIdentifier4 == "MDCX" || semiIdentifier4 == "MDC7" || semiIdentifier4 == "MDP7") //MT7?
                return ".mt7";

            if (semiIdentifier4 == "DTPK")
                return ".snd";

            if (semiIdentifier4 == "GBIX" || semiIdentifier4 == "TEXN")
                return ".pvr";

            if (dataArray.Length > 0)
            {
                if ((dataArray[0] == 0x7B && dataArray[1] == 0x0A)
                    || (dataArray[0] == 0x7B && dataArray[1] == 0x0D)
                    || (dataArray[0] == 0x7B && dataArray[1] == 0x09))
                    return ".json";

                if (dataArray[0] == 0x12 && dataArray[1] == 0x98 && dataArray[2] == 0xEE && dataArray[3] == 0x51 && dataArray[4] == 0x40)
                    return ".override";

                if (dataArray[0] == 0x03 && dataArray[1] == 0x00 && dataArray[2] == 0x00 && dataArray[3] == 0x00 ||
                    (dataArray[4] == 0x2F && dataArray[5] == 0x76 || dataArray[4] == 0xC2 && dataArray[5] == 0x8F))
                    return ".sub";
            }

            try
            {
                long nullCount = 0;
                for (int i = 0; i < dataArray.Length; i++)
                {
                    if (dataArray[i] == 0x00) nullCount++;
                }

                if (nullCount == 0) return fileExt = ".txt";
            }
            catch (Exception)
            {
                return fileExt;
            }

            if (
                (dataArray[0] == 0xFF && dataArray[1] == 0x86 && dataArray[2] == 0x00) ||
                (dataArray[0] == 0xFF && dataArray[1] == 0x00 && dataArray[2] == 0x40) ||
                (dataArray[0] == 0xFF && dataArray[1] == 0xC5 && dataArray[2] == 0x40) ||
                (dataArray[0] == 0xFF && dataArray[1] == 0xEB && dataArray[2] == 0x40) ||
                (dataArray[0] == 0x78 && dataArray[1] == 0x56 && dataArray[2] == 0x34)
               ) return ".fontdef";

            if (
                (dataArray[0] == 0x20 && dataArray[1] == 0x00 && dataArray[2] == 0x00) ||
                (dataArray[0] == 0x0A && dataArray[1] == 0x00 && dataArray[2] == 0x00)
               ) return ".glyphs";

            //Disk Container Detection

            if (semiIdentifier == "SCN") //MT5
                return ".scn";

            if (semiIdentifier4 == "SCRL") //MT5
                return ".spr";

            if (
                (dataArray[0] == 0x1F && dataArray[1] == 0x8B && dataArray[2] == 0x08 && dataArray[2] == 0x08)
               ) return ".gz";

            if (semiIdentifier4 == "ATTR")
                return ".bin";

            //PKS/PKF Detection
            using (var ms = new MemoryStream(dataArray))
            {
                ms.Seek(9, SeekOrigin.Begin);
                int i = 0; //saftey check
                while (true)
                {
                    byte actualVar = (byte)ms.ReadByte();
                    if (actualVar == 0x2E) //a dot
                    {
                        byte[] buffer = new byte[3];
                        ms.Read(buffer, 0, 3);

                        string semiArchiveIdentifier = Encoding.ASCII.GetString(buffer);

                        if (semiArchiveIdentifier == "PKF") return ".pkf";
                        if (semiArchiveIdentifier == "PKS") return ".pks";

                        break;
                    }

                    i++;
                    if (i >= 24) break;
                }
            }

            return fileExt;
        }

        public static string GetRelativePath(string filename, string folder)
        {
            Uri pathUri = new Uri(filename);
            if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                folder += Path.DirectorySeparatorChar;
            }
            Uri folderUri = new Uri(folder);
            return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }
    }
}
