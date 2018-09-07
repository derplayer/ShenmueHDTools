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
            else
            {
                buffer[0] = data[length - 3];
                buffer[1] = data[length - 2];
                buffer[2] = data[length - 1];
            }
            hash = (hash ^ BitConverter.ToUInt32(buffer, 0)) * m;

            uint edx = (hash >> 0x0D ^ hash) * m;
            hash = edx >> 0x0F ^ edx;
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
