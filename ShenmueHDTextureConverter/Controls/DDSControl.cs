using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShenmueDKSharp.Files.Images._DDS;
using static ShenmueDKSharp.Files.Images._DDS.DDS_Header;

namespace ShenmueHDTextureConverter.Controls
{
    public partial class DDSControl : UserControl
    {
        public DDSSettings Settings;

        public DDSControl()
        {
            InitializeComponent();

            foreach (DDSGeneral.AlphaSettings format in Enum.GetValues(typeof(DDSGeneral.AlphaSettings)).Cast<DDSGeneral.AlphaSettings>())
            {
                comboBox_AlphaSettings.Items.Add(format);
            }
            foreach (DDSGeneral.MipHandling format in Enum.GetValues(typeof(DDSGeneral.MipHandling)).Cast<DDSGeneral.MipHandling>())
            {
                comboBox_MipHandling.Items.Add(format);
            }
            foreach (DDSFormat format in Enum.GetValues(typeof(DDSFormat)).Cast<DDSFormat>())
            {
                if (format == DDSFormat.Unknown ||
                    format == DDSFormat.DDS_CUSTOM) continue;
                comboBox_DDSFormat.Items.Add(format);
            }
            foreach (DXGI_FORMAT format in Enum.GetValues(typeof(DXGI_FORMAT)).Cast<DXGI_FORMAT>())
            {
                if (format == DXGI_FORMAT.DXGI_FORMAT_UNKNOWN) continue;
                comboBox_DXGIFormat.Items.Add(format);
            }
            comboBox_AlphaSettings.SelectedIndex = 0;
            comboBox_MipHandling.SelectedIndex = 0;
            comboBox_DDSFormat.SelectedIndex = 0;
            UpdateDXGIFormats();
        }

        private void UpdateDXGIFormats()
        {
            comboBox_DXGIFormat.Items.Clear();
            if (Settings.DDSFormat == DDSFormat.DDS_DX10)
            {
                foreach (DXGI_FORMAT format in Enum.GetValues(typeof(DXGI_FORMAT)).Cast<DXGI_FORMAT>())
                {
                    if (format == DXGI_FORMAT.DXGI_FORMAT_UNKNOWN) continue;
                    comboBox_DXGIFormat.Items.Add(format);
                }
                comboBox_DXGIFormat.SelectedIndex = 0;
            }
        }

        private void comboBox_AlphaSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.AlphaSettings = (DDSGeneral.AlphaSettings)comboBox_AlphaSettings.SelectedItem;
        }

        private void comboBox_MipHandling_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.MipHandling = (DDSGeneral.MipHandling)comboBox_MipHandling.SelectedItem;
        }

        private void comboBox_DDSFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.DDSFormat = (DDSFormat)comboBox_DDSFormat.SelectedItem;
            UpdateDXGIFormats();
        }

        private void comboBox_DXGIFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.DXGIFormat = (DXGI_FORMAT)comboBox_DXGIFormat.SelectedItem;
        }
    }

    public struct DDSSettings
    {
        public DDSGeneral.AlphaSettings AlphaSettings;
        public DDSGeneral.MipHandling MipHandling;
        public DDSFormat DDSFormat;
        public DXGI_FORMAT DXGIFormat;
    }
}
