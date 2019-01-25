using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShenmueDKSharp.Files.Images;
using System.IO;
using ShenmueDKSharp.Files;
using ShenmueDKSharp.Files.Models;

namespace ShenmueHDTools.GUI.Tools.ModelEditor.UserControls
{
    public partial class TextureControl : UserControl
    {
        private Texture m_texture;

        public event EventHandler OnTextureChanged;

        public TextureControl()
        {
            InitializeComponent();
        }

        public void SetTexture(Texture texture)
        {
            m_texture = texture;
            pictureBox_TextureView.Image = m_texture.Image.CreateBitmap();
            numericUpDown_MipMapIndex.Maximum = m_texture.Image.MipMaps.Count - 1;
        }

        private void numericUpDown_MipMapIndex_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown_MipMapIndex.Value > m_texture.Image.MipMaps.Count || numericUpDown_MipMapIndex.Value < 0) return;
            pictureBox_TextureView.Image = m_texture.Image.CreateBitmap((int)numericUpDown_MipMapIndex.Value);
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Supported files|*.png;*.bmp;*.jpeg;*.dds;*.pvr";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(saveFileDialog.FileName);
                Type fileType = FileHelper.GetFileTypeFromExtension(extension.Substring(1, extension.Length - 1).ToUpper());
                BaseImage baseImage = (BaseImage)Activator.CreateInstance(fileType, new object[] { m_texture });
                baseImage.Write(saveFileDialog.FileName);
            }
        }

        private void button_Import_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Supported files|*.png;*.bmp;*.jpeg;*.dds;*.pvr";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(openFileDialog.FileName);
                Type fileType = FileHelper.GetFileTypeFromExtension(extension.Substring(1, extension.Length - 1).ToUpper());
                m_texture.Image = (BaseImage)Activator.CreateInstance(fileType, new object[] { openFileDialog.FileName });

                if (numericUpDown_MipMapIndex.Value > m_texture.Image.MipMaps.Count || numericUpDown_MipMapIndex.Value < 0) return;
                pictureBox_TextureView.Image = m_texture.Image.CreateBitmap((int)numericUpDown_MipMapIndex.Value);
                OnTextureChanged(this, null);
            }
        }
    }
}
