using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShenmueDKSharp.Files.Images._PVRT;

namespace ShenmueHDTextureConverter.Controls
{
    public partial class PVRTControl : UserControl
    {
        public PVRTSettings Settings = new PVRTSettings();

        public PVRTControl()
        {
            InitializeComponent();
            foreach (PvrDataFormat format in Enum.GetValues(typeof(PvrDataFormat)).Cast<PvrDataFormat>())
            {
                if (format == PvrDataFormat.UNKNOWN ||
                    format == PvrDataFormat.SQUARE_TWIDDLED_MIPMAP_ALT ||
                    format == PvrDataFormat.RECTANGLE_MIPMAP ||
                    format == PvrDataFormat.RECTANGLE_STRIDE_MIPMAP ||
                    format == PvrDataFormat.BMP ||
                    format == PvrDataFormat.BMP_MIPMAP) continue;
                comboBox_DataCodec.Items.Add(format);
            }
            UpdatePixelFormats();
            comboBox_DataCodec.SelectedIndex = 0;
            comboBox_PixelCodec.SelectedIndex = 0;
        }

        public void UpdatePixelFormats()
        {
            comboBox_PixelCodec.Items.Clear();
            if (Settings.DataFormat == PvrDataFormat.DDS ||
                Settings.DataFormat == PvrDataFormat.DDS_2)
            {
                foreach (PvrPixelFormat format in Enum.GetValues(typeof(PvrPixelFormat)).Cast<PvrPixelFormat>())
                {
                    if (format != PvrPixelFormat.DDS_DXT1_RGB24 &&
                        format != PvrPixelFormat.DDS_DXT3_RGBA32) continue;
                    comboBox_PixelCodec.Items.Add(format);
                }
            }
            else
            {
                foreach (PvrPixelFormat format in Enum.GetValues(typeof(PvrPixelFormat)).Cast<PvrPixelFormat>())
                {
                    if (format == PvrPixelFormat.UNKNOWN ||
                        format == PvrPixelFormat.DDS_DXT1_RGB24 ||
                        format == PvrPixelFormat.DDS_DXT3_RGBA32) continue;
                    comboBox_PixelCodec.Items.Add(format);
                }
            }
            comboBox_PixelCodec.SelectedIndex = 0;
        }

        private void checkBox_CreateTEXN_CheckedChanged(object sender, EventArgs e)
        {
            Settings.CreateTEXN = checkBox_CreateTEXN.Checked;
        }

        private void checkBox_InsertDDS_CheckedChanged(object sender, EventArgs e)
        {
            Settings.InsertDDS = checkBox_InsertDDS.Checked;
        }

        private void comboBox_DataCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.DataFormat = (PvrDataFormat)comboBox_DataCodec.SelectedItem;
            UpdatePixelFormats();
        }

        private void comboBox_PixelCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.PixelFormat = (PvrPixelFormat)comboBox_PixelCodec.SelectedItem;
        }
    }

    public class PVRTSettings
    {
        public PvrDataFormat DataFormat;
        public PvrPixelFormat PixelFormat;
        public bool InsertDDS = false;
        public bool CreateTEXN = false;
    }
}
