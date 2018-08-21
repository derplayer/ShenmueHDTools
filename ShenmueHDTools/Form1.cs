using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShenmueHDTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static UInt32 ReverseBytes(UInt32 value)
        {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }

        private void unpackButton_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "The Archive Dictonary files (*.tad)|*.tad";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            List<tacItem> tacList = new List<tacItem>();
                            byte[] header = new byte[72];

                            BinaryReader reader = new BinaryReader(myStream);
                            header = reader.ReadBytes(72);

                            while (reader.BaseStream.Position != reader.BaseStream.Length)
                            {
                                try
                                {
                                    var newFile = new tacItem();
                                    reader.BaseStream.Seek(4, SeekOrigin.Current); //skip padding
                                    newFile.startPointer = reader.ReadBytes(4);
                                    reader.BaseStream.Seek(4, SeekOrigin.Current); //skip padding
                                    newFile.sizeData = reader.ReadBytes(4);
                                    reader.BaseStream.Seek(4, SeekOrigin.Current); //skip padding
                                    newFile.unknownHash = reader.ReadBytes(12);
                                    //reader.BaseStream.Seek(4, SeekOrigin.Current); //skip padding

                                    tacList.Add(newFile);
                                }
                                catch (Exception)
                                {
                                    //stop parsing when error?
                                    break;
                                }

                            }

                            var containerPath = Path.ChangeExtension(openFileDialog1.FileName, ".tac");
                            
                            string directoryPath = Path.GetDirectoryName(openFileDialog1.FileName) +
                                "\\" + Path.GetFileNameWithoutExtension(containerPath) + "\\";
                            DirectoryInfo di = Directory.CreateDirectory(directoryPath);
                            ASCIIEncoding ascii = new ASCIIEncoding();

                            //Open the stream and read it back.
                            using (FileStream fs = File.OpenRead(containerPath))
                            {
                                int fileCount = 0;
                                foreach (var file in tacList)
                                {
                                    int startInt = (BitConverter.ToInt32(file.startPointer, 0)); //first file F526 aka 62.758
                                    int sizeInt = (BitConverter.ToInt32(file.sizeData, 0));
                                    int endInt = startInt + sizeInt;

                                    fs.Seek(startInt, SeekOrigin.Begin);

                                    byte[] arrBytes = new byte[sizeInt];
                                    //byte[] arrBytes2 = File.ReadAllBytes(containerPath).Skip(startInt).Take(sizeInt).ToArray(); //Linq style hehe
                                    fs.Read(arrBytes, 0, arrBytes.Length);

                                    var semiIdentifier = Encoding.ASCII.GetString(arrBytes.Take(3).ToArray());

                                    if (semiIdentifier == "DDS")
                                        File.WriteAllBytes(directoryPath + "File_" + fileCount + ".dds", arrBytes);
                                    else
                                        File.WriteAllBytes(directoryPath + "File_" + fileCount + ".unknown", arrBytes);

                                    fileCount++;
                                }

                                MessageBox.Show("Finished!");
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
