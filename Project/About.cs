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

namespace Shenmue_HD_Tools
{
    public partial class About : Form
    {
        Random random = new Random();

        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            
            this.labelAbout.Text += ShenmueHDTools.Version.actualVerison.ToString(CultureInfo.InvariantCulture);
            this.vmuBox.Image = null;
            this.vmuBox.Image = Resources.gfx[random.Next(0, Resources.gfx.Count)];

            try
            {
                string filePath = Path.Combine(Path.GetTempPath(), random.Next(0, 8) + ".bin");
                Play(filePath, "playThread");
            }
            catch (Exception)
            {

            }
            
        }

        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(String command, StringBuilder buffer,
                                            Int32 bufferSize, IntPtr hwndCallback);

        public static Dictionary<String, bool> playing = new Dictionary<String, bool>();

        public static void Play(String fileName, String alias)
        {
            if (playing.ContainsKey(alias))
                throw new Exception("alias '" + alias + "' is already playing");

            playing.Add(alias, false);

            Thread stoppingThread = new Thread(() => { StartAndStopWithDelay(fileName, alias); });
            stoppingThread.Start();
        }

        public static void StopFromOtherThread(String alias)
        {
            if (!playing.ContainsKey(alias))
                return;

            playing[alias] = true;
        }

        public static bool isPlaying(String alias)
        {
            return playing.ContainsKey(alias);
        }

        public static void StartAndStopWithDelay(String fileName, String alias)
        {
            mciSendString("open " + fileName + " type sequencer alias " + alias, null, 0, new IntPtr());
            mciSendString("play " + alias, null, 0, new IntPtr());

            StringBuilder result = new StringBuilder(100);
            mciSendString("set " + alias + " time format milliseconds", null, 0, new IntPtr());
            mciSendString("status " + alias + " length", result, 100, new IntPtr());

            int LengthInMilliseconds;
            Int32.TryParse(result.ToString(), out LengthInMilliseconds);

            Stopwatch timer = new Stopwatch();
            timer.Start();

            while (timer.ElapsedMilliseconds < LengthInMilliseconds && !playing[alias])
            {

            }

            timer.Stop();

            Stop(alias);
        }

        public static void Stop(String alias)
        {
            if (!playing.ContainsKey(alias))
                throw new Exception("alias '" + alias + "' is already stopped");

            // Execute calls to close and stop the player, on the same thread as the play and open calls
            mciSendString("stop " + alias, null, 0, new IntPtr());
            mciSendString("close " + alias, null, 0, new IntPtr());

            playing.Remove(alias);
        }

        private void vmuBox_Click(object sender, EventArgs e)
        {
            this.vmuBox.Image = null;
            this.vmuBox.Image = Resources.gfx[random.Next(0, Resources.gfx.Count)];
        }

        private void urlLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/derplayer/ShenmueHDTools");
        }
    }
}
