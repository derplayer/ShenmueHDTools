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
    public class ZipFile
    {
        public string Filename { get; set; }
        public byte[] Content { get; set; }
    }

    public static class Resources
    {
        public static List<Image> gfx = new List<Image>();
        public static List<Image> load = new List<Image>();
        public static Dictionary<string, string> data = new Dictionary<string, string>();

        /// <summary>
        /// Hacky way to unzip a embedded resource (smaller executeable)
        /// </summary>
        /// <param name="zippedBuffer"></param>
        /// <returns></returns>
        public static ZipFile[] Unzip(byte[] zippedBuffer)
        {
            List<ZipFile> tempList = new List<ZipFile>();

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
                                tempList.Add(new ZipFile
                                {
                                    Filename = entry.Name,
                                    Content = unzippedArray
                                });
                            }
                        }
                    }

                    return tempList.ToArray();
                }
            }
        }

        public static void InitResources()
        {
            var test = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ShenmueHDTools.Resources.gfx"))
            {
                byte[] bytes = new byte[stream.Length]; stream.Position = 0; stream.Read(bytes, 0, (int)stream.Length);
                var Res = Unzip(bytes);

                foreach (var Item in Res)
                {
                        TypeConverter tc = TypeDescriptor.GetConverter(typeof(Image));
                        Image newImage = (Image)tc.ConvertFrom(Item.Content);
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
                    Image newImage = (Image)tc.ConvertFrom(Item.Content);
                    load.Add(newImage);
                }
            }

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ShenmueHDTools.Resources.database"))
            {
                byte[] bytes = new byte[stream.Length]; stream.Position = 0; stream.Read(bytes, 0, (int)stream.Length);
                var Res = Unzip(bytes);

                foreach (var Item in Res)
                {
                    data.Add(Path.GetFileNameWithoutExtension(Item.Filename), System.Text.Encoding.UTF8.GetString(Item.Content));
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
                        writer.Write(Item.Content, 0, Item.Content.Length);
                        i++;
                    }
                }
            }
        }
    }
}
