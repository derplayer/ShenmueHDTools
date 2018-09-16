using ShenmueHDTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShenmueHDTools.GUI.Dialogs
{
    public partial class AboutDialog : Form
    {
        Random random = new Random();
        System.Windows.Forms.Timer m_timer = new System.Windows.Forms.Timer();

        public AboutDialog()
        {
            InitializeComponent();

            m_timer.Interval = 2000;
            m_timer.Tick += timer_Tick;
            m_timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            vmuBox.Image = null;
            vmuBox.Image = Resources.gfx[random.Next(0, Resources.gfx.Count)];
        }

        private void About_Load(object sender, EventArgs e)
        {
            labelAbout.Text = Version.ApplicationTitle;
            vmuBox.Image = null;
            vmuBox.Image = Resources.gfx[random.Next(0, Resources.gfx.Count)];

            try
            {
                string filePath = Path.Combine(Path.GetTempPath(), random.Next(0, 8) + ".bin");
                Start(filePath, "playThread");
            }
            catch (Exception) {}
        }

        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(String command, StringBuilder buffer,
                                            Int32 bufferSize, IntPtr hwndCallback);

        public static void Start(String fileName, String alias)
        {
            mciSendString("open " + fileName + " type sequencer alias " + alias, null, 0, new IntPtr());
            mciSendString("play " + alias, null, 0, new IntPtr());

            StringBuilder result = new StringBuilder(100);
            mciSendString("set " + alias + " time format milliseconds", null, 0, new IntPtr());
            mciSendString("status " + alias + " length", result, 100, new IntPtr());
        }

        public static void Stop(String alias)
        {
            mciSendString("stop " + alias, null, 0, new IntPtr());
            mciSendString("close " + alias, null, 0, new IntPtr());
        }

        private void vmuBox_Click(object sender, EventArgs e)
        {
            vmuBox.Image = null;
            vmuBox.Image = Resources.gfx[random.Next(0, Resources.gfx.Count)];
            Stop("playThread");
            string filePath = Path.Combine(Path.GetTempPath(), random.Next(0, 8) + ".bin");
            Start(filePath, "playThread");
        }

        private void urlLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/derplayer/ShenmueHDTools");
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop("playThread");
        }
    }
}
