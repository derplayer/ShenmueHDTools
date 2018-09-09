using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace ShenmueHDTools.Main
{
    /// <summary>
    /// MurmurHash2 Shenmue implementation
    /// </summary>
    public class MurmurHash2Shenmue
    {
        private static uint initSeed = 0x66ee5d0;
        private static uint multiplier = 0x5BD1E995;
        private static int rotationAmount = 0x18;

        public static string Prefix = "./tex/assets/";

        /// <summary>
        /// MurmurHash2 Shenmue implementation.
        /// </summary>
        /// <param name="data">Data buffer</param>
        /// <param name="length">Length to hash</param>
        /// <returns>Shenmue MurmurHash2</returns>
        public static uint Hash(byte[] data, uint length)
        {
            //TODO: Needs a refactoring because its just plain broken up asm logic which is not that performant
            uint hash = (length / 0xFFFFFFFF + length) ^ initSeed;
            uint m = multiplier;
            int r = rotationAmount;

            UInt64 lengthRemaining = length + length / 4 * 0xfffffffffffffffc;

            if (length >= 4)
            {
                for (int i = 0; i < length; i += 4)
                {
                    if (i / 4 >= length / 4) break;
                    uint ecx = BitConverter.ToUInt32(data, i) * m;
                    hash = hash * m ^ (ecx >> r ^ ecx) * m;
                }
            }

            if (lengthRemaining > 0)
            {
                byte[] buffer = new byte[4];
                if (lengthRemaining == 1)
                {
                    buffer[0] = data[length - 1];
                }
                else if (lengthRemaining == 2)
                {
                    buffer[0] = data[length - 2];
                    buffer[1] = data[length - 1];
                }
                else if (lengthRemaining == 3)
                {
                    buffer[0] = data[length - 3];
                    buffer[1] = data[length - 2];
                    buffer[2] = data[length - 1];
                }
                hash = (hash ^ BitConverter.ToUInt32(buffer, 0)) * m;
            }

            uint edx = (hash >> 0x0D ^ hash) * m;
            hash = edx >> 0x0F ^ edx;
            return hash;
        }

        public static uint GetFilenameHashPlain(string filename)
        {
            filename = filename.ToLower();
            byte[] filenameBytes = Encoding.ASCII.GetBytes(filename);
            uint hash = Hash(filenameBytes, (uint)filenameBytes.Length);
            return hash;
        }

        public static string GetFullFilename(string filename, uint hash, bool includeHash = true)
        {
            string newFilename = filename;
            int cutoffIndex = filename.LastIndexOf('?'); //cutoff the ?usage=0 or other parameters away
            if (cutoffIndex > 0)
            {
                newFilename = filename.Substring(0, cutoffIndex);
            }
            if (includeHash)
            {
                return String.Format("{0}{1}.{2}", Prefix, newFilename, hash.ToString("x8"));
            }
            return String.Format("{0}{1}", Prefix, newFilename);
        }

        public static string GetFullFilename(string filename, bool includeHash = true)
        {
            filename = filename.ToLower();
            byte[] filenameBytes = Encoding.ASCII.GetBytes(filename);
            uint hash = Hash(filenameBytes, (uint)filenameBytes.Length);

            return GetFullFilename(filename, hash, includeHash);
        }

        public static byte[] GetFullFilenameHash(string filename)
        {
            string newFilename = GetFullFilename(filename);
            return GetFilenameHash(newFilename);
        }

        public static byte[] GetFilenameHash(string filename, bool hasHash = true)
        {
            if (filename[0] == '.')
            {
                filename = filename.Substring(1);
            }
            string strippedFilename = filename.ToLower().Replace("/", "").Replace("-", "");
            uint murmurHash = Hash(Encoding.ASCII.GetBytes(strippedFilename), (uint)strippedFilename.Length);
            uint totalLength = (uint)strippedFilename.Length;

            if (hasHash)
            {
                totalLength = (uint)strippedFilename.Length + 9; //include the " 00000000"
            }
            uint hash = murmurHash * 0x0001003F + (uint)strippedFilename.Length * totalLength * 0x0002001F;

            return BitConverter.GetBytes(hash);
        }
    }

}
