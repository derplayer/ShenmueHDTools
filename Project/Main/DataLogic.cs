using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using Shenmue_HD_Tools.ShenmueHD;
using ShenmueHDTools.Main;
using Shenmue_HD_Tools;

namespace ShenmueHDTools.Main
{
    //Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

    public class DataLogic
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
                                file.LastWriteTimeUtc = new FileInfo(finalFilePath).LastWriteTimeUtc; //for export...
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

        public void Export(string path)
        {
            path = Path.ChangeExtension(path, ".tad"); // in case of shdcache import

            var headerTmp = DataCollector.header;
            var tempFiles = DataCollector.Files;
            List<DataEntry> newFiles = new List<DataEntry>();

            using (BinaryWriter writer = new BinaryWriter(new FileStream(path, FileMode.Create)))
            {
                //var headerTmp = DataCollector.header;

                foreach (var file in tempFiles)
                {
                    using (BinaryReader vfsReader = new BinaryReader(new FileStream(file.file_path, FileMode.Open)))
                    {
                        var actFileInfo = new FileInfo(file.file_path);
                        var cachedLastWriteTimeUtc = file.LastWriteTimeUtc;

                        //int actualLength = (int)actFileInfo.Length; //Int64 -> Int32 could make a bit of an problem for big files?
                        //int cachedLength = BitConverter.ToInt32(file.file_size, 0);

                        if (actFileInfo.LastWriteTimeUtc == cachedLastWriteTimeUtc)
                        {
                            //tempFiles.Remove(file);
                            file.file_modified = false;
                            continue;
                        }
                        else
                        {
                            file.file_modified = true;

                            var tempFile = file;
                            tempFile.file_modified = true;
                            tempFile.file_begin = new byte[4] { 0x00, 0x00, 0x00, 0x00 };
                            tempFile.file_end = new byte[4] { 0x00, 0x00, 0x00, 0x00 };
                            tempFile.file_size = BitConverter.GetBytes(actFileInfo.Length);

                            newFiles.Add(tempFile);
                        }

                    }
                }

                int newPosBuf = 0;
                foreach (var file in newFiles)
                {
                    using (BinaryReader vfsReader = new BinaryReader(new FileStream(file.file_path, FileMode.Open)))
                    {
                        int length = BitConverter.ToInt32(file.file_size, 0);

                        file.file_begin = BitConverter.GetBytes(newPosBuf);
                        newPosBuf += length;
                        file.file_end = BitConverter.GetBytes(newPosBuf);
                        file.file_size = BitConverter.GetBytes(length);
                    }
                }

                var containerPath = Path.ChangeExtension(path, ".tac");
                using (BinaryWriter containerWriter = new BinaryWriter(new FileStream(containerPath, FileMode.Create)))
                {
                    //Data Stream - write the archive container
                    foreach (var file in newFiles)
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

                //Update header with new known
                //...
                var actTacInfo = new FileInfo(containerPath);
                headerTmp.TacSize = BitConverter.GetBytes((uint)actTacInfo.Length);
                headerTmp.Unknown5 = BitConverter.GetBytes(newFiles.Count);
                headerTmp.Unknown6 = BitConverter.GetBytes(newFiles.Count);

                var preHash = headerTmp.GetPreHash(headerTmp);
                var realHash = headerTmp.GetHash(preHash);
                headerTmp.Unknown4 = BitConverter.GetBytes(realHash);

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

                //Rebuild "the archive dictonary"
                foreach (var file in newFiles) //extra modify flag check?
                {
                    if (file.file_modified == false) continue;
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

            }
        }

        public void UpdateGUI()
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

                lvi.SubItems.Add("0x" + Helper.Reverse(BitConverter.ToString((item.file_begin)).Replace("-", "")));
                lvi.SubItems.Add("0x" + Helper.Reverse(BitConverter.ToString((item.file_size)).Replace("-", "")));
                lvi.SubItems.Add("0x" + Helper.Reverse(BitConverter.ToString((item.file_end)).Replace("-", "")));
                lvi.SubItems.Add("0x" + Helper.Reverse(BitConverter.ToString((item.file_unknownhash)).Replace("-", "")));

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
                fileExt = ".hlsl";

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
                if ((dataArray[0] == 0x7B && dataArray[1] == 0x0A)
                    || (dataArray[0] == 0x7B && dataArray[1] == 0x0D)
                    || (dataArray[0] == 0x7B && dataArray[1] == 0x09))
                    fileExt = ".json";

                if (dataArray[0] == 0x12 && dataArray[1] == 0x98 && dataArray[2] == 0xEE && dataArray[3] == 0x51 && dataArray[4] == 0x40)
                    fileExt = ".modeloverride";

                else if (dataArray[0] == 0x03 && dataArray[1] == 0x00 && dataArray[2] == 0x00 && dataArray[3] == 0x00 && 
                    (dataArray[4] == 0x2F && dataArray[5] == 0x76 || dataArray[4] == 0xC2 && dataArray[5] == 0x8F))
                    fileExt = ".sub";
            }

            return fileExt;
        }

        private static void clearVFS()
        {
            DataCollector.Files = new List<DataEntry>();
            DataCollector.header = new HeaderData();
        }

    }
}