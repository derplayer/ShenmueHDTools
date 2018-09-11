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
using ShenmueHDTools.Main.DataStructure;
using System.Security.Cryptography;
using System.Threading;
using ShenmueHDTools.Main.Database;

namespace ShenmueHDTools.Main
{
    public class DataLogic
    {
        private HeaderStructure _actualHeader = new HeaderStructure();
        private List<FileStructure> _actualFiles = new List<FileStructure>();

        public List<FileStructure> LoadVFS(string path, string directory)
        {
            ClearStructures();
            string tempFileExt = Path.GetExtension(path);
            var containerPath = Path.ChangeExtension(path, ".tac");

            using (BinaryReader reader = new BinaryReader(new FileStream(path, FileMode.Open)))
            {
                _actualHeader.ReadHeader(reader);

                string identifier = new ASCIIEncoding().GetString(_actualHeader.RenderType);
                if (identifier != "dx11") throw new Exception("Header identifier isn't correct!");

                int i = 0;
                while (true)
                {
                    FileStructure actualFile = new FileStructure();
                    actualFile.Meta.Index = i;

                    actualFile.ReadHeader(reader);

                    actualFile.Meta.FileEnd = BitConverter.GetBytes(
                        BitConverter.ToInt64(actualFile.FileStart, 0) +
                        BitConverter.ToInt64(actualFile.FileSize, 0)
                    );

                    _actualFiles.Add(actualFile);
                    i++;

                    //TODO: Move to loop top?
                    if (reader.BaseStream.Position >= reader.BaseStream.Length)
                    {
                        System.Diagnostics.Debug.WriteLine("Stream position is at overflowing. Stop reading!");
                        break;
                    }
                }

                string extractDirectory = directory + "\\_" + Path.GetFileName(path) + "_\\";
                Directory.CreateDirectory(extractDirectory);

                using (BinaryReader tacReader = new BinaryReader(new FileStream(containerPath, FileMode.Open)))
                {
                    foreach (FileStructure file in _actualFiles)
                    {
                        tacReader.BaseStream.Seek(BitConverter.ToInt64(file.FileStart, 0), SeekOrigin.Begin);

                        long startInt = BitConverter.ToInt64(file.FileStart, 0);
                        long sizeInt = BitConverter.ToInt64(file.FileSize, 0);
                        long endInt = startInt + sizeInt;

                        byte[] dataArray = new byte[sizeInt];
                        tacReader.Read(dataArray, 0, dataArray.Length);

                        file.Meta.FileExt = Helper.ExtensionFinder(dataArray);
                        string finalFilePath = extractDirectory + file.Meta.Index + file.Meta.FileExt;
                        file.Meta.FilePath = finalFilePath;

                        try
                        {
                            //TODO: REMOVE/MODIFY LATER!
                            if (file.Meta.FileExt == ".json" && file.Meta.Index == 12)
                            {
                                //load stuff into memory for assertmapping/s
                                file.Meta.FileDeserialized = new AssetRemappingJSON(dataArray);
                            }

                            // TODO: Verify Filehash and Database hash!
                            //foreach (var dcFile in DCCollector.FileCollector)
                            //{
                            //    if(file.)
                            //}
                        }
                        catch (Exception e)
                        {
                            throw;
                        }

                        //Extract at load...
                        try
                        {
                            using (StreamWriter writer = new StreamWriter(new FileStream(finalFilePath, FileMode.Create)))
                            {
                                writer.BaseStream.Write(dataArray, 0, dataArray.Length);

                                using (var md5 = MD5.Create())
                                {
                                    md5.ComputeHash(dataArray, 0, dataArray.Length);
                                    file.Meta.MD5Hash = md5.Hash;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine("Something broke..." + e);
                        }

                    }
                }

                reader.Close();

                //Create .shdcache file (for fater loading)
                try
                {
                    string cachePath = Path.ChangeExtension(path, ".shdcache");
                    using (StreamWriter writer = new StreamWriter(new FileStream(cachePath, FileMode.Create)))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        using (var ms = new MemoryStream())
                        {
                            var serializeStuff = new DataCollection
                            {
                                Header = _actualHeader,
                                Files = _actualFiles
                            };

                            bf.Serialize(ms, serializeStuff);
                            var msArr = ms.ToArray();
                            writer.BaseStream.Write(msArr, 0, msArr.Length);
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Something broke..." + e);
                }

            }

            UpdateGUI();
            return _actualFiles;
        }

        public List<FileStructure> LoadCache(string path, string directory)
        {
            ClearStructures();
            string cachePath = Path.ChangeExtension(path, ".shdcache"); //TODO: why change?

            //Load .shdcache file
            try
            {
                using (FileStream reader = new FileStream(directory + "\\" + Path.GetFileName(cachePath), FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    DataCollection deserializeCache = (DataCollection)bf.Deserialize(reader);

                    _actualHeader = deserializeCache.Header;
                    _actualFiles = deserializeCache.Files;

                    System.Diagnostics.Debug.WriteLine("Previous instance loaded...");
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Something broke..." + e);
                MessageBox.Show("The loaded shdcahe was created with an older verison of ModTools, that is incompatible now!\n\n" +
                    "Please copy your modified files, create a new project and copy those over and try again!\n\n" +
                    "Remember: The fileextensions are also now changed (fewer unknowns)\n"
                    );
            }

            UpdateGUI();
            return _actualFiles;
        }

        public void SaveVFS(string path)
        {
            path = Path.ChangeExtension(path, ".tad"); // in case of shdcache import

            using (BinaryWriter writer = new BinaryWriter(new FileStream(path, FileMode.Create)))
            {
                writer.Write(_actualHeader.FileType);
                writer.Write(_actualHeader.Identifier1);
                writer.Write(_actualHeader.Identifier2);
                writer.Write(_actualHeader.Reserved1);

                writer.Write(_actualHeader.UnixTimestamp);
                writer.Write(_actualHeader.Reserved2);

                writer.Write(_actualHeader.RenderType);
                writer.Write(_actualHeader.Reserved3);

                writer.Write(_actualHeader.HeaderChecksum);
                writer.Write(_actualHeader.Reserved4);

                writer.Write(_actualHeader.TacSize);
                writer.Write(_actualHeader.Reserved5);

                writer.Write(_actualHeader.FileCount1);
                writer.Write(_actualHeader.Reserved6);

                writer.Write(_actualHeader.FileCount2);

                long newPosBuf = 0;
                foreach (var file in _actualFiles)
                {
                    using (BinaryReader vfsReader = new BinaryReader(new FileStream(file.Meta.FilePath, FileMode.Open)))
                    {
                        long actualLength = new FileInfo(file.Meta.FilePath).Length;
                        long cachedLength = BitConverter.ToInt64(file.FileSize, 0);

                        if (cachedLength == actualLength)
                            System.Diagnostics.Debug.WriteLine("File " + file.Meta.Index + " matches the start pointer size!");
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("File " + file.Meta.Index + " DON'T MATCHES the start pointer size!");
                            file.Meta.FileModified = true;
                        }

                        long newPos = 0;
                        long newTemPosBuf = newPosBuf;
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

                        long pointerMergeIntX = BitConverter.ToInt64(file.FileStart, 0) + newTemPosBuf;
                        byte[] pointerMergeX = BitConverter.GetBytes(pointerMergeIntX);

                        long pointerMergeIntY = BitConverter.ToInt64(file.Meta.FileEnd, 0) + newPosBuf;
                        byte[] pointerMergeY = BitConverter.GetBytes(pointerMergeIntY);

                        long pointerMergeIntZ;
                        if (upperMode)
                            pointerMergeIntZ = BitConverter.ToInt64(file.FileSize, 0) + newPos;
                        else
                            pointerMergeIntZ = BitConverter.ToInt64(file.FileSize, 0) - newPos;

                        byte[] pointerMergeZ = BitConverter.GetBytes(pointerMergeIntZ);

                        file.FileStart = pointerMergeX;
                        file.Meta.FileEnd = pointerMergeY;
                        file.FileSize = pointerMergeZ;
                    }
                }

                //Rebuild "the archive dictonary"
                foreach (var file in _actualFiles)
                {
                    try
                    {
                        writer.Write(file.Hash1);
                        writer.Write(file.Hash2);
                        writer.Write(file.FileStart);
                        writer.Write(file.FileSize);
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
                    foreach (var file in _actualFiles)
                    {
                        using (BinaryReader tacVFSReader = new BinaryReader(new FileStream(file.Meta.FilePath, FileMode.Open)))
                        {
                            long sizeInt = BitConverter.ToInt64(file.FileSize, 0);
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

            var headerTmp = _actualHeader;
            //var tempFiles = DataCollector.Files;
            List<FileStructure> newFiles = new List<FileStructure>();
            //var headerTmp = DataCollector.header;

            foreach (var file in _actualFiles)
            {
                using (BinaryReader vfsReader = new BinaryReader(new FileStream(file.Meta.FilePath, FileMode.Open)))
                {
                    using (var actualMD5 = MD5.Create())
                    {
                        actualMD5.ComputeHash(vfsReader.BaseStream);
                        var cachedMD5 = file.Meta.MD5Hash;
                        var actFileInfo = new FileInfo(file.Meta.FilePath);

                        if (Helper.ArraysEqual(cachedMD5, actualMD5.Hash, cachedMD5.Length))
                        {
                            file.Meta.FileModified = false;
                            continue;
                        }
                        else
                        {
                            file.Meta.FileModified = true;

                            var tempFile = file;
                            tempFile.Meta.FileModified = true;
                            tempFile.FileStart = new byte[4] { 0x00, 0x00, 0x00, 0x00 };
                            tempFile.Meta.FileEnd = new byte[4] { 0x00, 0x00, 0x00, 0x00 };
                            tempFile.FileSize = BitConverter.GetBytes(actFileInfo.Length);

                            newFiles.Add(tempFile);
                        }
                    }
                }
            }

            if (newFiles.Count <= 0)
            {
                MessageBox.Show("No files were modified! Export stopped!");
                UpdateGUI();
                return;
            }

            using (BinaryWriter writer = new BinaryWriter(new FileStream(path, FileMode.Create)))
            {
                long newPosBuf = 0;
                foreach (var file in newFiles)
                {
                    using (BinaryReader vfsReader = new BinaryReader(new FileStream(file.Meta.FilePath, FileMode.Open)))
                    {
                        long length = BitConverter.ToInt64(file.FileSize, 0);

                        file.FileStart = BitConverter.GetBytes(newPosBuf);
                        newPosBuf += length;
                        file.Meta.FileEnd = BitConverter.GetBytes(newPosBuf);
                        file.FileSize = BitConverter.GetBytes(length);
                    }
                }

                var containerPath = Path.ChangeExtension(path, ".tac");
                using (BinaryWriter containerWriter = new BinaryWriter(new FileStream(containerPath, FileMode.Create)))
                {
                    //Data Stream - write the archive container
                    foreach (var file in newFiles)
                    {
                        using (BinaryReader tacVFSReader = new BinaryReader(new FileStream(file.Meta.FilePath, FileMode.Open)))
                        {
                            long sizeInt = BitConverter.ToInt64(file.FileSize, 0);
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
                headerTmp.FileCount1 = BitConverter.GetBytes(newFiles.Count);
                headerTmp.FileCount2 = BitConverter.GetBytes(newFiles.Count);
                headerTmp.UnixTimestamp = BitConverter.GetBytes((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);

                var preHash = headerTmp.GetPreHash(headerTmp);
                var realHash = headerTmp.GetHash(preHash);
                headerTmp.HeaderChecksum = BitConverter.GetBytes(realHash);

                writer.Write(_actualHeader.FileType);
                writer.Write(_actualHeader.Identifier1);
                writer.Write(_actualHeader.Identifier2);
                writer.Write(_actualHeader.Reserved1);

                
                writer.Write(_actualHeader.UnixTimestamp);
                writer.Write(_actualHeader.Reserved2);

                writer.Write(_actualHeader.RenderType);
                writer.Write(_actualHeader.Reserved3);

                writer.Write(_actualHeader.HeaderChecksum);
                writer.Write(_actualHeader.Reserved4);

                writer.Write(_actualHeader.TacSize);
                writer.Write(_actualHeader.Reserved5);

                writer.Write(_actualHeader.FileCount1);
                writer.Write(_actualHeader.Reserved6);

                writer.Write(_actualHeader.FileCount2);

                //Rebuild "the archive dictonary"
                foreach (var file in newFiles) //extra modify flag check?
                {
                    if (file.Meta.FileModified == false) continue;
                    try
                    {
                        writer.Write(file.Hash1);
                        writer.Write(file.Hash2);
                        writer.Write(file.FileStart);
                        writer.Write(file.FileSize);
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

            foreach (var item in _actualFiles)
            {
                // Add the pet to our listview
                ListViewItem lvi = new ListViewItem();

                lvi.Text = item.Meta.Index.ToString();

                lvi.SubItems.Add("0x" + (BitConverter.ToString((item.FileStart)).Replace("-", "")));
                lvi.SubItems.Add("0x" + (BitConverter.ToString((item.FileSize)).Replace("-", "")));
                lvi.SubItems.Add("0x" + (BitConverter.ToString((item.Meta.FileEnd)).Replace("-", "")));
                lvi.SubItems.Add("0x" + (BitConverter.ToString((item.Hash1)).Replace("-", "")));
                lvi.SubItems.Add("0x" + (BitConverter.ToString((item.Hash2)).Replace("-", "")));
                lvi.SubItems.Add(item.Meta.FileModified.ToString());
                lvi.SubItems.Add(item.Meta.FileExt);
                lvi.SubItems.Add("?");

                Program.MainWindowCore.listViewMain.Items.Add(lvi);
                Program.MainWindowCore.listViewMain.LabelEdit = true;

            }

            Program.MainWindowCore.listViewMain.Items.Add(new ListViewItem());
            Program.MainWindowCore.listViewMain.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ClearStructures()
        {
            _actualFiles = new List<FileStructure>();
            _actualHeader = new HeaderStructure();
        }

    }
}