using Ookii.Dialogs;
using ShenmueDKSharp.Files;
using ShenmueDKSharp.Files.Images;
using ShenmueDKSharp.Files.Images._DDS;
using ShenmueDKSharp.Files.Misc;
using ShenmueDKSharp.Utils;
using ShenmueHDTextureConverter.Controls;
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

namespace ShenmueHDTextureConverter
{
    public partial class TextureConverter : Form
    {
        public TextureConverter()
        {
            InitializeComponent();
            tabControl_Formats.Appearance = TabAppearance.FlatButtons;
            tabControl_Formats.ItemSize = new Size(0, 1);
            tabControl_Formats.SizeMode = TabSizeMode.Fixed;


            comboBox_ImageFormat.Items.Add(typeof(PVRT));
            comboBox_ImageFormat.Items.Add(typeof(DDS));
            comboBox_ImageFormat.Items.Add(typeof(PNG));
            comboBox_ImageFormat.Items.Add(typeof(BMP));
            comboBox_ImageFormat.Items.Add(typeof(JPEG));
            comboBox_ImageFormat.SelectedIndex = 0;
        }

        private void listBox_Images_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                string extension = Path.GetExtension(file).Replace(".", "");

                byte[] buffer = new byte[32];
                using (FileStream stream = new FileStream(file, FileMode.Open))
                {
                    stream.Read(buffer, 0, 32);
                }

                Type imageType = FileHelper.GetImageFileTypeFromSignature(buffer);
                if (imageType == null) continue;


                BaseImage entry = null;
                object image = Activator.CreateInstance(imageType, new object[] { file });
                if (typeof(BaseImage).IsAssignableFrom(imageType))
                {
                    entry = (BaseImage)image;
                }
                else
                {
                    TEXN texn = (TEXN)image;
                    entry = texn.Texture;
                }
                
                listBox_Images.Items.Add(entry);
            }
        }

        private void listBox_Images_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void listBox_Images_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                List<BaseImage> toDelete = new List<BaseImage>();
                foreach (BaseImage entry in listBox_Images.SelectedItems)
                {
                    toDelete.Add(entry);
                }
                foreach (BaseImage entry in toDelete)
                {
                    listBox_Images.Items.Remove(entry);
                }
            }
        }

        private void comboBox_ImageFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl_Formats.SelectTab(comboBox_ImageFormat.SelectedIndex);
        }

        private void listBox_Images_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Images.SelectedIndex >= listBox_Images.Items.Count || listBox_Images.SelectedIndex < 0) return;
            BaseImage image = (BaseImage)listBox_Images.Items[listBox_Images.SelectedIndex];
            pictureBox_SourcePreview.Image = image.CreateBitmap();
        }

        private void button_Convert_Click(object sender, EventArgs e)
        {
            string outputFolder = textBox_OutputFolder.Text;
            if (String.IsNullOrEmpty(outputFolder)) return;
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            List<BaseImage> images = new List<BaseImage>();
            if (checkBox_ConvertSelected.Checked)
            {
                foreach(BaseImage img in listBox_Images.SelectedItems)
                {
                    images.Add(img);
                }
            }
            else
            {
                foreach (BaseImage img in listBox_Images.Items)
                {
                    images.Add(img);
                }
            }

            if ((Type)comboBox_ImageFormat.SelectedItem == typeof(PVRT))
            {
                PVRTSettings settings = pvrtControl.Settings;
                foreach (BaseImage image in images)
                {
                    PVRT pvrt = new PVRT(image);
                    pvrt.PixelFormat = settings.PixelFormat;
                    pvrt.DataFormat = settings.DataFormat;

                    if (settings.CreateTEXN)
                    {
                        string srcFilename = Path.GetFileName(image.FilePath);
                        string[] splitted = srcFilename.Split('.');
                        string texIDString = splitted[0];
                        UInt64 texID = Convert.ToUInt64(texIDString, 16);

                        TEXN texn = new TEXN();
                        texn.TextureID.Data = texID;

                        string filename = String.Format("{0}.{1}.TEXN", Helper.ByteArrayToString(BitConverter.GetBytes(texn.TextureID.Data)), texn.TextureID.Name.Replace("\0", "_"));
                        string filepath = outputFolder + "\\" + filename;

                        using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
                        {
                            using (BinaryWriter writer = new BinaryWriter(fileStream))
                            {
                                long offset = fileStream.Position;
                                texn.WriteHeader(writer);
                                if (settings.InsertDDS && typeof(DDS).IsAssignableFrom(image.GetType()))
                                {
                                    pvrt.WriteDDSRaw(writer, (DDS)image);
                                }
                                else
                                {
                                    pvrt.Write(writer);
                                }
                                texn.EntrySize = (uint)(fileStream.Position - offset);
                                fileStream.Seek(offset, SeekOrigin.Begin);
                                texn.WriteHeader(writer);
                            }
                        }
                    }
                    else
                    {
                        string filepath = outputFolder + "\\" + Path.ChangeExtension(Path.GetFileName(image.FilePath), ".PVR");

                        using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
                        {
                            using (BinaryWriter writer = new BinaryWriter(fileStream))
                            {
                                if (settings.InsertDDS && typeof(DDS).IsAssignableFrom(image.GetType()))
                                {
                                    pvrt.WriteDDSRaw(writer, (DDS)image);
                                }
                                else
                                {
                                    pvrt.Write(writer);
                                }
                            }
                        }
                    }
                }
            }
            else if ((Type)comboBox_ImageFormat.SelectedItem == typeof(DDS))
            {
                DDSSettings settings = ddsControl.Settings;
                foreach (BaseImage image in images)
                {
                    string filepath = outputFolder + "\\" + Path.ChangeExtension(Path.GetFileName(image.FilePath), ".dds");
                    DDS dds = new DDS(image);
                    dds.AlphaSettings = settings.AlphaSettings;
                    dds.MipHandling = settings.MipHandling;
                    dds.FormatDetails = new DDSFormats.DDSFormatDetails(settings.DDSFormat, settings.DXGIFormat);
                    dds.Write(filepath);
                }
            }
            else if ((Type)comboBox_ImageFormat.SelectedItem == typeof(PNG))
            {
                foreach (BaseImage image in images)
                {
                    string filepath = outputFolder + "\\" + Path.ChangeExtension(Path.GetFileName(image.FilePath), ".png");
                    PNG png = new PNG(image);
                    png.Write(filepath);
                }
            }
            else if ((Type)comboBox_ImageFormat.SelectedItem == typeof(BMP))
            {
                foreach (BaseImage image in images)
                {
                    string filepath = outputFolder + "\\" + Path.ChangeExtension(Path.GetFileName(image.FilePath), ".bmp");
                    BMP bmp = new BMP(image);
                    bmp.Write(filepath);
                }
            }
            else if ((Type)comboBox_ImageFormat.SelectedItem == typeof(JPEG))
            {
                foreach (BaseImage image in images)
                {
                    string filepath = outputFolder + "\\" + Path.ChangeExtension(Path.GetFileName(image.FilePath), ".jpg");
                    JPEG jpg = new JPEG(image);
                    jpg.Write(filepath);
                }
            }
        }

        private void button_BrowseOutputFolder_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog folderDialog = new VistaFolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_OutputFolder.Text = folderDialog.SelectedPath;
            }
        }
    }
}
