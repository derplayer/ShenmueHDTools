using System;
using System.Collections.Generic;

namespace Shenmue_HD_Tools.ShenmueHD
{
    public static class DataCollector
    {
        public static HeaderData header { get; set; }
        public static List<DataEntry> Files { get; set; } = new List<DataEntry>();
    }

    [Serializable]
    public class DataCollectorClass
    {
        public HeaderData header { get; set; }
        public List<DataEntry> Files { get; set; } = new List<DataEntry>();
    }

    [Serializable]
    public class HeaderData
    {
        public byte[] Unknown1 { get; set; }
        public byte[] Unknown2 { get; set; }
        public byte[] Unknown3 { get; set; }
        public byte[] Reserved1 { get; set; }
        public byte[] Timestamp { get; set; }
        public byte[] Reserved2 { get; set; }
        public byte[] RenderType { get; set; }
        public byte[] Reserved3 { get; set; }
        /// <summary>
        /// Hash of the header
        /// </summary>
        public byte[] Unknown4 { get; set; }
        public byte[] Reserved4 { get; set; }
        /// <summary>
        /// Uint32 tac length
        /// </summary>
        public byte[] TacSize { get; set; }
        public byte[] Reserved5 { get; set; }
        /// <summary>
        /// Filecount in tac file
        /// </summary>
        public byte[] Unknown5 { get; set; }
        public byte[] Reserved6 { get; set; }

        // --- HASH HEADER END ---

        /// <summary>
        /// Filecount in tac file - again?
        /// </summary>
        public byte[] Unknown6 { get; set; }
        /// <summary>
        /// Unknown - seems to be uninportant? shenmue still loads tac/d stuff
        /// </summary>
        public byte[] Unknown7 { get; set; }

        public IEnumerable<byte[]> GetHeader(bool hashMode = false)
        {
            yield return Unknown1;
            yield return Unknown2;
            yield return Unknown3;
            yield return Reserved1;
            yield return Timestamp;
            yield return Reserved2;
            yield return RenderType;
            yield return Reserved3;
            if (hashMode) yield return new byte[4] { 0x00, 0x00, 0x00, 0x00 }; //nullify for murmur2!
            else yield return Unknown4;
            yield return Reserved4;
            yield return TacSize;
            yield return Reserved5;
            yield return Unknown5;
            yield return Reserved6;

            if (hashMode == false)
            {
                yield return Unknown6;
                yield return Unknown7;
            }
        }

    }

    [Serializable]
    public class DataEntry
    {
        public int index_position { get; set; }

        public byte[] file_begin { get; set; }    //Begin Pointer
        public byte[] file_size { get; set; }     //File Size
        public byte[] file_end { get; set; }     //End Pointer (Start + Size = End)
        public byte[] file_unknownhash { get; set; }

        // logical stuff only
        public string file_type { get; set; }
        public string file_path { get; set; }
        public bool file_modified { get; set; } = false;

        //public byte[] file_data { get; set; }
        public string file_name { get; set; }
        //public byte[] file_name_pointer { get; set; }
    }
    
}
