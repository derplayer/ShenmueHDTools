using ShenmueHDTools.Main.Files.Nodes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Utils
{
    public class DeepLearningUtil
    {
        public static Bitmap UpscaleBitmap(Bitmap image, int resizeMultiplier)
        {
            UpscaleImage(image, resizeMultiplier);
            using (var bmpTemp = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\DL\\data\\shenmue_tmp_result\\shdtst_rlt.png"))
            {
                return bmpTemp;
            }
        }

        /// <summary>
        /// Dirty CLI wrapper for python upscale
        /// </summary>
        /// <param name="image"></param>
        /// <param name="resizeMultiplier"></param>
        public static void UpscaleImage(Bitmap image, int resizeMultiplier)
        {
            try
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\DL\\data\\shenmue_tmp_result\\shdtst_rlt.png"))
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\DL\\data\\shenmue_tmp_result\\shdtst_rlt.png");

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\DL\\data\\shenmue_tmp\\shdtst.png"))
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\DL\\data\\shenmue_tmp\\shdtst.png");

                var orig = (Image)ResizeBitmap(image, resizeMultiplier);

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

            }
            catch (Exception ex)
            {
                throw new NullReferenceException();
            }
        }

        public static void SeparateAlphaChannel() { return; }
        public static void MergeAlphaChannel() { return; }

        public static Bitmap ResizeBitmap(Bitmap sourceBMP, int resizeMultiplier)
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

    }
}
