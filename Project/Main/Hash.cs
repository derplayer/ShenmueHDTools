using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace Shenmue_HD_Tools.ShenmueHD
{
    /// <summary>
    /// MurmurHash2 Shenmue implementation
    /// </summary>
    public class MurmurHash2Shenmue
    {
        private static uint initSeed = 0x66ee5d0;
        private static uint multiplier = 0x5BD1E995;
        private static int rotationAmount = 0x18;

        /// <summary>
        /// MurmurHash2 Shenmue implementation.
        /// This is not an complete implementation but enough for TAD.
        /// </summary>
        /// <param name="data">Data buffer</param>
        /// <param name="length">Length to hash</param>
        /// <returns>Shenmue MurmurHash2</returns>
        public static uint Hash(byte[] data, uint length)
        {
            uint hash = (length / 0xFFFFFFFF + length) ^ initSeed;
            uint m = multiplier;
            int r = rotationAmount;

            if (length >= 4)
            {
                for (int i = 0; i < length; i += 4)
                {
                    uint ecx = BitConverter.ToUInt32(data, i) * m;
                    hash = hash * m ^ (ecx >> r ^ ecx) * m;
                }
            }

            uint edx = (hash >> 13 ^ hash) * m;
            hash = edx >> 15 ^ edx;
            return hash;
        }

        /*
        /// <summary>
        /// MurmurHash2 Shenmue implementation 1:1
        /// </summary>
        /// <param name="d">Data buffer</param>
        /// <param name="length">Length to hash</param>
        /// <returns>Shenmue MurmurHash2</returns>
        public unsafe static uint HashUnsafe(byte[] d, UInt64 length)
        {
            fixed (byte* da = &d[0])
            {
                byte* data = da;
                uint hash = (uint)((length / 0xffffffff + length) ^ initSeed);
                UInt64 r8 = length;
                uint m = multiplier;
                int r = rotationAmount;

                if (length >= 4)
                {
                    UInt64 r10 = length >> 2; //length / 4
                    r8 = length + r10 * 0xfffffffffffffffc; //-4
                    do
                    {
                        uint ecx = *(uint*)data * m;
                        data += 4;
                        hash = hash * m ^ (ecx >> r ^ ecx) * m;
                        r10--;
                    } while (r10 > 0);
                }
                r8 = r8 - 1;
                if (r8 > 0)
                {
                    r8 = r8 - 1;
                    if (r8 > 0)
                    {
                        if (r8 != 1)
                        {
                            uint edx = (hash >> 13 ^ hash) * m;
                            hash = edx >> 15 ^ edx;
                            return hash;
                        }
                        else
                        {
                            Console.WriteLine("Not implemented yet");
                        }
                    }
                }
                return hash;
            }
        }
        */
    }

}
