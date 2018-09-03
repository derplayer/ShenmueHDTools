using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main
{
    public class Helper
    {
        public static string Reverse(string text)
        {
            if (text == null) return null;
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
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
    }
}
