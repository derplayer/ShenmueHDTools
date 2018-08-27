using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

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
        public byte[] Unknown4 { get; set; }
        public byte[] Reserved4 { get; set; }
        public byte[] TacSize { get; set; }
        public byte[] Reserved5 { get; set; }
        public byte[] Unknown5 { get; set; }
        public byte[] Reserved6 { get; set; }
        public byte[] Unknown6 { get; set; }
        public byte[] Unknown7 { get; set; }
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

    public class Data
    {

        public List<DataEntry> LoadVFS(string path, string directory)
        {
            clearVFS();
            var header = new HeaderData();
            string tempFileExt = Path.GetExtension(path);
            var containerPath = Path.ChangeExtension(path, ".tac");

            using (BinaryReader reader = new BinaryReader(new FileStream(path, FileMode.Open)))
            {
                var headerTmp = new HeaderData();

                headerTmp.Unknown1 = reader.ReadBytes(4);
                headerTmp.Unknown2 = reader.ReadBytes(4);
                headerTmp.Unknown3 = reader.ReadBytes(4);
                headerTmp.Reserved1 = reader.ReadBytes(4);
                headerTmp.Timestamp = reader.ReadBytes(4);
                headerTmp.Reserved2 = reader.ReadBytes(4);
                headerTmp.RenderType = reader.ReadBytes(4);
                headerTmp.Reserved3 = reader.ReadBytes(4);
                headerTmp.Unknown4 = reader.ReadBytes(4);
                headerTmp.Reserved4 = reader.ReadBytes(4);
                headerTmp.TacSize = reader.ReadBytes(4);
                headerTmp.Reserved5 = reader.ReadBytes(4);
                headerTmp.Unknown5 = reader.ReadBytes(4);
                headerTmp.Reserved6 = reader.ReadBytes(4);
                headerTmp.Unknown6 = reader.ReadBytes(4);
                headerTmp.Unknown7 = reader.ReadBytes(12);

                //if (headerTmp.RenderType != "dx11") return null; //tac identifier? TODO
                DataCollector.header = headerTmp;

                int i = 0;
                while (true)
                {
                    DataEntry actualFile = new DataEntry();
                    actualFile.index_position = i;

                    reader.BaseStream.Seek(4, SeekOrigin.Current); //skip padding (at file begin)
                    actualFile.file_begin = reader.ReadBytes(4);
                    reader.BaseStream.Seek(4, SeekOrigin.Current); //skip padding
                    actualFile.file_size = reader.ReadBytes(4);
                    reader.BaseStream.Seek(4, SeekOrigin.Current); //skip padding
                    actualFile.file_unknownhash = reader.ReadBytes(12);

                    actualFile.file_end = BitConverter.GetBytes(
                        BitConverter.ToInt32(actualFile.file_begin, 0) +
                        BitConverter.ToInt32(actualFile.file_size, 0)
                    );

                    DataCollector.Files.Add(actualFile);
                    i++;

                    if (reader.BaseStream.Position >= reader.BaseStream.Length) break; //TODO: check the missing values at EOF
                }

                var directoryMix = directory + "\\_" + Path.GetFileName(path) + "_\\";
                Directory.CreateDirectory(directoryMix);

                using (BinaryReader tacReader = new BinaryReader(new FileStream(containerPath, FileMode.Open)))
                {
                    foreach (var file in DataCollector.Files)
                    {

                        tacReader.BaseStream.Seek(BitConverter.ToInt32(file.file_begin, 0), SeekOrigin.Begin);

                        int startInt = BitConverter.ToInt32(file.file_begin, 0);
                        int sizeInt = BitConverter.ToInt32(file.file_size, 0);
                        int endInt = startInt + sizeInt;

                        byte[] dataArray = new byte[sizeInt];
                        tacReader.Read(dataArray, 0, dataArray.Length);

                        //load everything into memory? a bit of overkill for 1gb shenmue files
                        //file.file_data = dataArray;

                        var fileExt = ExtFinder(dataArray);
                        file.file_type = fileExt;
                        string finalFilePath = directoryMix + "\\" + file.index_position + fileExt;
                        file.file_path = finalFilePath;
                        //Extract at load...
                        try
                        {
                            using (StreamWriter writer = new StreamWriter(new FileStream(finalFilePath, FileMode.Create)))
                            {
                                writer.BaseStream.Write(dataArray, 0, dataArray.Length);
                            }
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine("Something broke...");
                        }

                    }
                    tacReader.Close();
                }

                reader.Close();

                //Create .shdcache file (for fater loading)
                try
                {
                    using (StreamWriter writer = new StreamWriter(new FileStream(directory + "\\" + Path.GetFileName(path).Replace(".tad", "") + ".shdcache", FileMode.Create)))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        using (var ms = new MemoryStream())
                        {
                            var serializeStuff = new DataCollectorClass
                            {
                                header = DataCollector.header,
                                Files = DataCollector.Files
                            };

                            bf.Serialize(ms, serializeStuff);
                            var msArr = ms.ToArray();
                            writer.BaseStream.Write(msArr, 0, msArr.Length);
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Something broke...");
                }

            }

            UpdateGUI();
            return DataCollector.Files;
        }

        public List<DataEntry> LoadCache(string path, string directory)
        {
            clearVFS();
            var header = new HeaderData();
            string tempFileExt = Path.GetExtension(path);
            var cachePath = Path.ChangeExtension(path, ".shdcache");

            //using (BinaryReader reader = new BinaryReader(new FileStream(path, FileMode.Open)))
            //{

            //Load .shdcache file
            try
                {
                    using (FileStream reader = new FileStream(directory + "\\" + Path.GetFileName(cachePath), FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();

                    var serializeStuff = new DataCollectorClass
                    {
                        header = DataCollector.header,
                        Files = DataCollector.Files
                    };

                    object o = bf.Deserialize(reader);
                    var deserializeStuff = (DataCollectorClass)o;
                    DataCollector.header = deserializeStuff.header;
                    DataCollector.Files = deserializeStuff.Files;
                    System.Diagnostics.Debug.WriteLine("Previous instance loaded...");
                }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Something broke...");
                }

            //}

            UpdateGUI();
            return DataCollector.Files;
        }

        public void SaveVFS(string path)
        {
            path = Path.ChangeExtension(path, ".tad"); // in case of shdcache import

            using (BinaryWriter writer = new BinaryWriter(new FileStream(path, FileMode.Create)))
            {
                var headerTmp = DataCollector.header;

                writer.Write(headerTmp.Unknown1);
                writer.Write(headerTmp.Unknown2);
                writer.Write(headerTmp.Unknown3);
                writer.Write(headerTmp.Reserved1);
                writer.Write(headerTmp.Timestamp);
                writer.Write(headerTmp.Reserved2);
                writer.Write(headerTmp.RenderType);
                writer.Write(headerTmp.Reserved3);
                writer.Write(headerTmp.Unknown4);
                writer.Write(headerTmp.Reserved4);
                writer.Write(headerTmp.TacSize);
                writer.Write(headerTmp.Reserved5);
                writer.Write(headerTmp.Unknown5);
                writer.Write(headerTmp.Reserved6);
                writer.Write(headerTmp.Unknown6);
                writer.Write(headerTmp.Unknown7);

                int newPosBuf = 0;
                foreach (var file in DataCollector.Files)
                {
                    using (BinaryReader vfsReader = new BinaryReader(new FileStream(file.file_path, FileMode.Open)))
                    {
                        int actualLength = (int)new FileInfo(file.file_path).Length; //Int64 -> Int32 could make a bit of an problem for big files?
                        int cachedLength = BitConverter.ToInt32(file.file_size, 0);

                        if (cachedLength == actualLength)
                            System.Diagnostics.Debug.WriteLine("File " + file.index_position + " matches the start pointer size!");
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("File " + file.index_position + " DON'T MATCHES the start pointer size!");
                            file.file_modified = true;
                        }

                        int newPos = 0;
                        int newTemPosBuf = newPosBuf;
                        bool upperMode = false;
                        if (cachedLength > actualLength)
                        {
                            newPos = cachedLength - actualLength;
                            newPosBuf -= newPos;
                            upperMode = false;
                        }

                        if (cachedLength < actualLength)
                        {
                            newPos = actualLength - cachedLength;
                            newPosBuf += newPos;
                            upperMode = true;
                        }


                        int pointerMergeIntX = BitConverter.ToInt32(file.file_begin, 0) + newTemPosBuf;
                        byte[] pointerMergeX = BitConverter.GetBytes(pointerMergeIntX);

                        int pointerMergeIntY = BitConverter.ToInt32(file.file_end, 0) + newPosBuf;
                        byte[] pointerMergeY = BitConverter.GetBytes(pointerMergeIntY);

                        int pointerMergeIntZ;
                        if (upperMode)
                            pointerMergeIntZ = BitConverter.ToInt32(file.file_size, 0) + newPos;
                        else
                            pointerMergeIntZ = BitConverter.ToInt32(file.file_size, 0) - newPos;

                        byte[] pointerMergeZ = BitConverter.GetBytes(pointerMergeIntZ);

                        file.file_begin = pointerMergeX;
                        file.file_end = pointerMergeY;
                        file.file_size = pointerMergeZ;
                    }
                }

                //Rebuild "the archive dictonary"
                foreach (var file in DataCollector.Files)
                {
                    try
                    {
                        writer.Write(0x00000000);
                        writer.Write(file.file_begin);
                        writer.Write(0x00000000);
                        writer.Write(file.file_size);
                        writer.Write(0x00000000);
                        writer.Write(file.file_unknownhash);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("Error: " + e);
                        continue;
                    }

                }

                var containerPath = Path.ChangeExtension(path, ".tac");
                using (BinaryWriter containerWriter = new BinaryWriter(new FileStream(containerPath, FileMode.Create)))
                {
                    //Data Stream - write the archive container
                    foreach (var file in DataCollector.Files)
                    {
                        using (BinaryReader tacVFSReader = new BinaryReader(new FileStream(file.file_path, FileMode.Open)))
                        {
                            int sizeInt = BitConverter.ToInt32(file.file_size, 0);
                            byte[] dataArray = new byte[sizeInt];
                            tacVFSReader.Read(dataArray, 0, dataArray.Length);
                            containerWriter.Write(dataArray);
                        }

                    }
                }
            }
        }

        public static void UpdateGUI()
        {

            foreach (var item in Program.MainWindowCore.listViewMain.Items)
            {
                Program.MainWindowCore.listViewMain.Items.Remove((ListViewItem)item);
            }

            foreach (var item in DataCollector.Files)
            {
                // Add the pet to our listview
                ListViewItem lvi = new ListViewItem();

                lvi.Text = item.index_position.ToString();


                lvi.SubItems.Add("0x" + Reverse(BitConverter.ToString((item.file_begin)).Replace("-", "")));
                lvi.SubItems.Add("0x" + Reverse(BitConverter.ToString((item.file_size)).Replace("-", "")));
                lvi.SubItems.Add("0x" + Reverse(BitConverter.ToString((item.file_end)).Replace("-", "")));
                lvi.SubItems.Add("0x" + Reverse(BitConverter.ToString((item.file_unknownhash)).Replace("-", "")));

                lvi.SubItems.Add(item.file_modified.ToString());

                Program.MainWindowCore.listViewMain.Items.Add(lvi);

            }

            Program.MainWindowCore.listViewMain.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private string ExtFinder(byte[] dataArray)
        {
            var fileExt = ".unknown";

            var semiIdentifier = Encoding.ASCII.GetString(dataArray.Take(3).ToArray());

            if (semiIdentifier == "DDS")
                fileExt = ".dds";

            if (semiIdentifier == "IDX")
                fileExt = ".idx";

            if (semiIdentifier == "AFS")
                fileExt = ".afs";

            var semiIdentifier4 = Encoding.ASCII.GetString(dataArray.Take(4).ToArray());
            if (semiIdentifier4 == "RIFF")
                fileExt = ".wav";

            if (semiIdentifier4 == "DXBC")
                fileExt = ".dxbc";

            if (semiIdentifier4 == "PAKS") //IPAC Browser
                fileExt = ".pks";

            if (semiIdentifier4 == "PAKF") //IPAC Browser
                fileExt = ".pkf";

            if (semiIdentifier4 == "MDP7" || semiIdentifier4 == "MDC7" || semiIdentifier4 == "HRCM") //MT5/MT6/MT7?
                fileExt = ".model";

            if (semiIdentifier4 == "DTPK")
                fileExt = ".SND";

            if (semiIdentifier4 == "GBIX" || semiIdentifier4 == "TEXN")
                fileExt = ".pvr";

            //7B 0A 09
            if (dataArray.Length > 0)
            {
                if ((dataArray[0] == 0x7B && dataArray[1] == 0x0A && dataArray[2] == 0x09)
                    || (dataArray[0] == 0x7B && dataArray[1] == 0x0D && dataArray[2] == 0x0A)
                    || (dataArray[0] == 0x7B && dataArray[1] == 0x09 && dataArray[2] == 0x0D))
                    fileExt = ".json";

                if (dataArray[0] == 0x12 && dataArray[1] == 0x98 && dataArray[2] == 0xEE && dataArray[3] == 0x51 && dataArray[4] == 0x40)
                    fileExt = ".modeloverride";
            }

            return fileExt;
        }

        private static string Reverse(string text)
        {
            if (text == null) return null;

            // this was posted by petebob as well 
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }

        private static void clearVFS()
        {
            DataCollector.Files = new List<DataEntry>();
            DataCollector.header = new HeaderData();
        }

    }
}
