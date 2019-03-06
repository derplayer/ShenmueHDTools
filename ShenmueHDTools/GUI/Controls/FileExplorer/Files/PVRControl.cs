using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShenmueHDTools.Main.Files.Nodes;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;
using System.Drawing.Drawing2D;

namespace ShenmueHDTools.GUI.Controls.FileExplorer.Files
{
    public partial class PVRControl : UserControl
    {
        private FileNode m_file;
        private bool m_dlState = false;
        public PVRControl()
        {
            InitializeComponent();
        }

        public void SetFile(FileNode file)
        {
            m_file = file;
            pictureBox_Preview.Image = ((IImageNode)file).GetImage();
            pictureBox_PreviewDL.Image = ((IImageNode)file).GetImage();
            m_dlState = false;
        }

        /// <summary>
        /// TODO: Something is wrong with this resize...
        /// </summary>
        /// <param name="sourceImage"></param>
        /// <param name="resizeMultiplier"></param>
        /// <returns></returns>
        private Bitmap ResizeBitmap(Bitmap sourceBMP, int resizeMultiplier)
        {
            int width = sourceBMP.Size.Width * resizeMultiplier;
            int height = sourceBMP.Size.Height * resizeMultiplier;

            Bitmap result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.SmoothingMode = SmoothingMode.None;
                g.PixelOffsetMode = PixelOffsetMode.None;
                g.CompositingMode = CompositingMode.SourceCopy;

                GraphicsUnit units = GraphicsUnit.Pixel;
                Rectangle destRect = new Rectangle(0, 0, width + 2, height + 2); //WTF? .net bug?
                Rectangle srcRect = new Rectangle(0, 0, sourceBMP.Size.Width, sourceBMP.Size.Width);
                g.DrawImage(sourceBMP, destRect, srcRect, units);
            }
            return result;
        }

        private void buttonDL_4x_Click(object sender, EventArgs e)
        {
            try
            {
                if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\DL\\data\\shenmue_tmp_result\\shdtst_rlt.png"))
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\DL\\data\\shenmue_tmp_result\\shdtst_rlt.png");

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\DL\\data\\shenmue_tmp\\shdtst.png"))
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\DL\\data\\shenmue_tmp\\shdtst.png");

                var orig = (Image)ResizeBitmap(((IImageNode)m_file).GetImage(), 4);

                orig.Save(AppDomain.CurrentDomain.BaseDirectory + "\\DL\\data\\shenmue_tmp\\shdtst.png", ImageFormat.Png);

                Process process = new Process();
                process.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "\\DL\\test\\test.exe";
                process.StartInfo.Arguments = "/c DIR"; // Note the /c command (*)
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\DL//test\\";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
                string err = process.StandardError.ReadToEnd();
                Console.WriteLine(err);
                process.WaitForExit();

                using (var bmpTemp = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\DL\\data\\shenmue_tmp_result\\shdtst_rlt.png"))
                {
                    pictureBox_PreviewDL.Image = new Bitmap(bmpTemp);
                }

                m_dlState = true;
                //pictureBox_PreviewDL.Width = pictureBox_PreviewDL.Width;
                //pictureBox_PreviewDL.Height = pictureBox_PreviewDL.Height;
            }
            catch (Exception ex)
            {

            }
        }

        private void OnMouseEnterPreview(object sender, EventArgs e)
        {
            if (m_dlState) {
                using (var bmpTemp = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\DL\\data\\shenmue_tmp\\shdtst.png"))
                {
                    pictureBox_PreviewDL.Image = new Bitmap(bmpTemp);
                }
                this.label_DL.Text = "Next Neighbour Upscale";
            }
        }

        private void OnMouseLeavePreview(object sender, EventArgs e)
        {
            if (m_dlState)
            {
                using (var bmpTemp = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\DL\\data\\shenmue_tmp_result\\shdtst_rlt.png"))
                {
                    pictureBox_PreviewDL.Image = new Bitmap(bmpTemp);
                }
                this.label_DL.Text = "Deep Learning Improved";
            }
        }

        private void buttonSaveOrig_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = Path.ChangeExtension(Path.GetFileName(m_file.FullPath), ".png");
            savefile.Filter = "PNG file (*.png)|*.png";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                pictureBox_Preview.Image.Save(savefile.FileName, ImageFormat.Png);
            }
        }

        private void buttonSaveDL_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = Path.ChangeExtension(Path.GetFileName(m_file.FullPath), ".png");
            savefile.Filter = "PNG file (*.png)|*.png";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                pictureBox_PreviewDL.Image.Save(savefile.FileName, ImageFormat.Png);
            }
        }

        private void label_DL_Click(object sender, EventArgs e)
        {

        }
    }
}
