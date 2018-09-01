using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace Shenmue_HD_Tools.ShenmueHD
{
    public interface IHashAlgorithm
    {
        UInt32 Hash(Byte[] data);
    }
    public interface ISeededHashAlgorithm : IHashAlgorithm
    {
        UInt32 Hash(Byte[] data, UInt32 seed);
    }

    public class MurmurHash2Simple : ISeededHashAlgorithm
    {
        public UInt32 Hash(Byte[] data)
        {
            return Hash(data, 0x66EE5D0); //shenmue own seed (at least in 1?)
        }
        const UInt32 m = 0x5bd1e995; //multiplier
        const Int32 r = 18; // rotation is 18 (not standard 24)

        public UInt32 Hash(Byte[] data, UInt32 seed)
        {
            UInt32 length = (UInt32)data.Length;
            if (length == 0)
                return 0;
            UInt32 h = (length + length / 0xFFFFFFFF) ^ seed;
            Int32 currentIndex = 0;
            while (length >= 4)
            {
                UInt32 k = BitConverter.ToUInt32(data, currentIndex);
                k *= m;
                k ^= k >> r;
                k *= m;

                h *= m;
                h ^= k;
                currentIndex += 4;
                length -= 4;
            }
            switch (length)
            {
                case 3:
                    h ^= BitConverter.ToUInt16(data, currentIndex);
                    h ^= (UInt32)data[currentIndex + 2] << 16; //24 in shenmue?
                    h *= m;
                    break;
                case 2:
                    h ^= BitConverter.ToUInt16(data, currentIndex);
                    h *= m;
                    break;
                case 1:
                    h ^= data[currentIndex];
                    h *= m;
                    break;
                default:
                    break;
            }

            // Do a few final mixes of the hash to ensure the last few
            // bytes are well-incorporated.

            h ^= h >> 13;
            h *= m;
            h ^= h >> 15;

            return h;
        }
    }

}
