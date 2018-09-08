using Shenmue_HD_Tools.ShenmueHD;
using ShenmueHDTools.Main.DataStructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShenmueHDTools.Main
{
    public static class DataHelper
    {
        public static byte[] GetFilenameHash(String filename)
        {
            if (filename[0] == '.')
            {
                filename = filename.Substring(1);
            }
            string strippedFilename = filename.ToLower().Replace("/", "").Replace("-", "");
            uint murmurHash = MurmurHash2Shenmue.Hash(Encoding.ASCII.GetBytes(strippedFilename), (uint)strippedFilename.Length);

            Console.WriteLine(murmurHash.ToString("X"));

            uint hash = murmurHash * 0x0001003F + (uint)strippedFilename.Length * (uint)strippedFilename.Length * 0x0002001F;

            return BitConverter.GetBytes(hash);
        }

        public static void GenerateDCObject()
        {
            List<string> discCollection = new List<string>();
            discCollection.Add(Properties.Resources.EU_D1);
            discCollection.Add(Properties.Resources.EU_D2);
            discCollection.Add(Properties.Resources.EU_D3);
            discCollection.Add(Properties.Resources.EU_PASS);

            discCollection.Add(Properties.Resources.JAP_D1);
            discCollection.Add(Properties.Resources.JAP_D2);
            discCollection.Add(Properties.Resources.JAP_D3);
            discCollection.Add(Properties.Resources.JAP_PASS);

            discCollection.Add(Properties.Resources.US_D1);
            discCollection.Add(Properties.Resources.US_D2);
            discCollection.Add(Properties.Resources.US_D3);
            discCollection.Add(Properties.Resources.US_PASS);

            discCollection.Add(Properties.Resources.B_D1);
            discCollection.Add(Properties.Resources.B_D2);
            discCollection.Add(Properties.Resources.B_D3);
            discCollection.Add(Properties.Resources.B_PASS);

            discCollection.Add(Properties.Resources.WS_D1);

            foreach (var disc in discCollection)
            {
                using (StringReader reader = new StringReader(disc))
                {
                    string line = string.Empty;
                    do
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            var lineArr = line.Split(' ');
                            DCCollector.FileCollector.Add(new DCStructure
                            {
                                FilePathFull = lineArr[0],
                                FileSize = Convert.ToInt32(lineArr[1]),
                                FileName = Path.GetFileName(lineArr[0]),
                                Hash = GetFilenameHash(Path.GetFileName(lineArr[0]))
                            });
                        }

                    } while (line != null);
                }
            }

            //Create .dccache file
            //try
            //{
            //    SaveFileDialog newPathDlg = new SaveFileDialog();
            //    newPathDlg.Filter = "The Archive Dictonary files (*.dccache)|*.dccache";

            //    if (newPathDlg.ShowDialog() == DialogResult.OK)
            //    {
            //        var file = newPathDlg.FileName;
            //        var directory = Path.GetDirectoryName(file);

            //        using (StreamWriter writer = new StreamWriter(new FileStream(file, FileMode.Create)))
            //        {
            //            BinaryFormatter bf = new BinaryFormatter();
            //            using (var ms = new MemoryStream())
            //            {
            //                var serializeStuff = dcContainer;
            //                bf.Serialize(ms, serializeStuff);
            //                var msArr = ms.ToArray();
            //                writer.BaseStream.Write(msArr, 0, msArr.Length);
            //            }
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    System.Diagnostics.Debug.WriteLine("Something broke..." + e);
            //}

            return;
        }

    }
}
