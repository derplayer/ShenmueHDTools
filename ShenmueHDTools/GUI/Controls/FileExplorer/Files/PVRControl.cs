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
using ShenmueHDTools.Main.Utils;

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

        private void buttonDL_4x_Click(object sender, EventArgs e)
        {
            pictureBox_PreviewDL.Image = DeepLearningUtil.UpscaleBitmap(((IImageNode)m_file).GetImage(), 4);
            m_dlState = true;
            //pictureBox_PreviewDL.Width = pictureBox_PreviewDL.Width;
            //pictureBox_PreviewDL.Height = pictureBox_PreviewDL.Height;
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
