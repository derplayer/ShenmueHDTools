﻿using ShenmueHDTools;
using ShenmueHDTools.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ShenmueHDTools.Main.DataStructure;
using ShenmueHDTools.Main.Files;
using ShenmueHDTools.Main.Database;
using ShenmueHDTools.GUI.Dialogs;
using System.Text;
using ShenmueHDTools.Main.Files.Headers;
using ShenmueDKSharp.Utils;
using ShenmueDKSharp.Files.Models;

namespace Shenmue_HD_Tools
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            MT5.SearchTexturesOneDirUp = true;
            MT7.SearchTexturesOneDirUp = true;
            Headers.CreateHeaderList();
            Application.EnableVisualStyles();
            if (System.Diagnostics.Debugger.IsAttached)
            {
                ShenmueHDTools.Version.ApplicationName += " (Debug)";
            }
            Run();
        }

        public static void Run()
        {
            Resources.InitResources();
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            Application.Run(new MainWindow());
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            AboutDialog.Stop("playThread");
        }
    }
}