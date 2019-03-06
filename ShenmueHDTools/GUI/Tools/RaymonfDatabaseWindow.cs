using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShenmueHDTools.GUI.Dialogs;
using ShenmueHDTools.Main;
using ShenmueHDTools.Main.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShenmueHDTools.GUI.Windows
{
    public partial class RaymonfDatabaseWindow : Form, IProgressable
    {
        public RaymonfDatabaseWindow()
        {
            InitializeComponent();
            wulinshuRaymonfDataTable1.SetData(WulinshuRaymonfAPI.Entries);
        }

        public bool IsAbortable { get { return false; } }

        public event FinishedEventHandler Finished;
        public event Main.ProgressChangedEventHandler ProgressChanged;
        public event DescriptionChangedEventHandler DescriptionChanged;
        public event Main.ErrorEventHandler Error;

        private void button_Fetch_Click(object sender, EventArgs e)
        {
            WulinshuRaymonfAPI api = new WulinshuRaymonfAPI();
            LoadingDialog loadingDialog = new LoadingDialog();
            loadingDialog.SetData(api);
            Thread thread = new Thread(delegate () {
                api.FetchData("both");
            });
            loadingDialog.ShowDialog(thread);
            WulinshuRaymonfAPI.Write();
            wulinshuRaymonfDataTable1.SetData(WulinshuRaymonfAPI.Entries);
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Wulinshu Raymonf Dump (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                WulinshuRaymonfAPI.Write(saveFileDialog.FileName);
            }
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Wulinshu Raymonf Dump (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                WulinshuRaymonfAPI.Read(openFileDialog.FileName);
                wulinshuRaymonfDataTable1.SetData(WulinshuRaymonfAPI.Entries);
            }
        }

        private void button_Merge_Click(object sender, EventArgs e)
        {
            LoadingDialog loadingDialog = new LoadingDialog();
            loadingDialog.SetData(this);
            Thread thread = new Thread(delegate () {
                Merge();
            });
            loadingDialog.ShowDialog(thread);
        }

        private void button_Local_Click(object sender, EventArgs e)
        {
            MergeFallback();
        }

        private void Merge()
        {
            DescriptionChanged(this, new DescriptionChangedArgs("Merging with filename database..."));
            for (int i = 0; i < WulinshuRaymonfAPI.Entries.Count; i++)
            {
                ProgressChanged(this, new ProgressChangedArgs(i, WulinshuRaymonfAPI.Entries.Count));
                WulinshuRaymonfAPIEntry entry = WulinshuRaymonfAPI.Entries[i];
                FilenameDatabase.Add(entry.CreateDatabaseEntry());
            }
            FilenameDatabase.Save();
            Finished(this, new FinishedArgs(true));
        }

        private void MergeFallback()
        {
            //byte[] fallback = Properties.Resources.Wulinshu_Raymonf_Backup;
            //string json = System.Text.Encoding.UTF8.GetString(fallback, 0, fallback.Length);
            string json = Resources.data["backup"];
            JArray entries = (JArray)JsonConvert.DeserializeObject(json);

            foreach (JToken token in entries.Children())
            {
                WulinshuRaymonfAPIEntry entry = new WulinshuRaymonfAPIEntry
                {
                    Path = token.SelectToken("Path").Value<string>(),
                    Hash = token.SelectToken("Hash").Value<string>(),
                    Matches = token.SelectToken("Matches").Value<int>(),
                    Game = token.SelectToken("Game").Value<string>()
                };

                WulinshuRaymonfAPI.Entries.Add(entry);
            }

            wulinshuRaymonfDataTable1.SetData(WulinshuRaymonfAPI.Entries);
        }

        public void Abort()
        {
            //throw new NotImplementedException();
        }
    }
}
