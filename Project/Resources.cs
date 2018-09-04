using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools
{
    public static class Resources
    {
        public static List<Image> gfx = new List<Image>();
        public static List<Image> load = new List<Image>();

        public static List<byte[]> Unzip(byte[] zippedBuffer)
        {
            List<byte[]> tempList = new List<byte[]>();

            using (var zippedStream = new MemoryStream(zippedBuffer))
            {
                using (var archive = new ZipArchive(zippedStream))
                {
                    foreach (var entry in archive.Entries)
                    {
                        using (var unzippedEntryStream = entry.Open())
                        {
                            using (var ms = new MemoryStream())
                            {
                                unzippedEntryStream.CopyTo(ms);
                                var unzippedArray = ms.ToArray();
                                tempList.Add(unzippedArray);
                            }
                        }
                    }

                    return tempList;
                }
            }
        }

        public static void InitResources()
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ShenmueHDTools.Resources.gfx"))
            {
                byte[] bytes = new byte[stream.Length]; stream.Position = 0; stream.Read(bytes, 0, (int)stream.Length);
                var Res = Unzip(bytes);

                foreach (var Item in Res)
                {
                        TypeConverter tc = TypeDescriptor.GetConverter(typeof(Image));
                        Image newImage = (Image)tc.ConvertFrom(Item);
                        gfx.Add(newImage);
                }
            }

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ShenmueHDTools.Resources.load"))
            {
                byte[] bytes = new byte[stream.Length]; stream.Position = 0; stream.Read(bytes, 0, (int)stream.Length);
                var Res = Unzip(bytes);

                foreach (var Item in Res)
                {
                    TypeConverter tc = TypeDescriptor.GetConverter(typeof(Image));
                    Image newImage = (Image)tc.ConvertFrom(Item);
                    load.Add(newImage);
                }
            }

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ShenmueHDTools.Resources.mid"))
            {
                byte[] bytes = new byte[stream.Length]; stream.Position = 0; stream.Read(bytes, 0, (int)stream.Length);
                var Res = Unzip(bytes);

                int i = 0;
                foreach (var Item in Res)
                {
                    string filePath = Path.Combine(Path.GetTempPath(), i + ".bin");
                    using (BinaryWriter writer = new BinaryWriter(new FileStream(filePath, FileMode.Create)))
                    {
                        writer.Write(Item, 0, Item.Length);
                        i++;
                    }
                }
            }
        }
    }
}
