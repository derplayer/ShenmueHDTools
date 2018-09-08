using ShenmueHDTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Globalization;
using static System.Windows.Forms.ListViewItem;
using System.Collections;

namespace Shenmue_HD_Tools
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                WebClient w = new WebClient(); //TODO: Shorter Timeout Range?
                w.Headers.Add("user-agent", "Mozilla/5.0 (Shenmue HD ModTools v" + ShenmueHDTools.Version.actualVerison.ToString(CultureInfo.InvariantCulture) +
                    "; Linux; rv:1.0) Gecko/20160408 ShenmueHD-Client/" + ShenmueHDTools.Version.actualVerison.ToString(CultureInfo.InvariantCulture));
                Version_JSON actualVersion;

                try
                {
                    string json_data = w.DownloadString(ShenmueHDTools.Version.urlversion);
                    actualVersion = JSONSerializer<Version_JSON>.DeSerialize(json_data);
                }
                catch (WebException ex) //Timeout,Server dead,...
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    actualVersion = new Version_JSON();
                    actualVersion.newestVersion = 0;
                }

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxButtons buttons_ok = MessageBoxButtons.OK;
                DialogResult result;
                string caption = "Shenmue HD ModTools";

                if (actualVersion.newestVersion > ShenmueHDTools.Version.actualVerison)
                {
                    string message = " New update is available! - Version: " + actualVersion.newestVersion.ToString(CultureInfo.InvariantCulture) + "\n\n Do you want to downtload it? \n\n---Server Message---\n\n" + actualVersion.message;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        //Tricks over cmd for non-elevated EXE (UAC) to Launch a URL with default webbrowser
                        //Process.Start("cmd", "/C start \"\" \"" + actualVersion.url + "\"");
                        System.Diagnostics.Process.Start(actualVersion.url);
                        Application.Exit();
                    }

                }

                //Timeout, false/dead url
                if (actualVersion.newestVersion == 0)
                {
                    string message = "Connection to the update server could not be etablished! \n\nPress OK to continue...";
                    result = MessageBox.Show(message, caption, buttons_ok);

                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        //hmm?
                    }

                }
            }

            base.Text += ShenmueHDTools.Version.actualVerison.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().Main();
        }

        private void anaButton_Click(object sender, EventArgs e)
        {
        }

        private void fileInjector_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().SaveAs();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().Main();
        }

        private void cRC32FromLookupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ShenmueHDTools.Main.DataHelper().GenerateDCObject();
        }

        private void replaceFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().SaveAs();
        }

        private void listBoxVFS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveVFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().SaveAs();
        }

        private void listViewMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                bool match = false;

                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    foreach (ListViewItem item in listViewMain.Items)
                    {

                        if (item.Bounds.Contains(new Point(e.X, e.Y)))
                        {
                            string allCollected = "";
                            foreach (ListViewSubItem subItem in item.SubItems)
                            {
                                allCollected += subItem.Text + ", ";
                            }

                            var m = new ContextMenu();

                            var fileHash = new MenuItem("Copy FileHash", new System.EventHandler(this.listViewMain_Click));
                            fileHash.Tag = item.SubItems[4].Text;

                            var fileHashHalf = new MenuItem("Copy FileHash (half)", new System.EventHandler(this.listViewMain_Click));
                            fileHashHalf.Tag = item.SubItems[4].Text.Substring(2, 8);

                            var fileAll = new MenuItem("Copy All", new System.EventHandler(this.listViewMain_Click));
                            fileAll.Tag = allCollected;

                            m.MenuItems.Add(fileHash);
                            m.MenuItems.Add(fileHashHalf);
                            m.MenuItems.Add(fileAll);

                            listViewMain.ContextMenu = m;
                            match = true;
                            break;
                        }
                    }
                    if (match)
                    {
                        listViewMain.ContextMenu.Show(listViewMain, new Point(e.X, e.Y));
                    }
                    else
                    {
                        //Show listViews context menu
                    }

                }
            }
            catch (Exception)
            {
                return;
            }

        }

        void listViewMain_Click(object sender, EventArgs e)
        {
            MenuItem senderCasted = (MenuItem)sender;
            System.Windows.Forms.Clipboard.SetText(senderCasted.Tag.ToString());
            Program.MainWindowCore.toolStripStatusLabel1.Text = senderCasted.Tag.ToString() + " is now in clipboard!";
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            listViewMain.AllowDrop = true;
            listViewMain.DragDrop += new DragEventHandler(listViewMain_DragDrop);
            listViewMain.DragEnter += new DragEventHandler(listViewMain_DragEnter);
            listViewColumnSorter = new ListViewColumnSorterExt(listViewMain);
        }

        void listViewMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void listViewMain_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void saveVFSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().Save();
        }

        private void howToModifyAFileInVFSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Work in progress...");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About AboutWindow = new About();
            AboutWindow.ShowDialog();
        }

        private void extractVFSRecrusiveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gIMDebugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gIMShowGIMStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxPointer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void importExistingProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().ImportProj();
        }

        private void exportAsAModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ShenmueHD.Core().Export();
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void mainMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            new ShenmueHD.Core().UpdateGUI();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.refreshButton.Enabled = false;
            new ShenmueHD.Core().UpdateGUI();
            this.refreshButton.Enabled = true;
        }
    }

    public static class JSONSerializer<TType> where TType : class
    {
        /// <summary>
        /// Deserializes an object from JSON with 100% .net libary (system.runtime.serialization.json)
        /// </summary>
        public static TType DeSerialize(string json)
        {
            using (var stream = new MemoryStream(Encoding.Default.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(TType));
                return serializer.ReadObject(stream) as TType;
            }
        }
    }

    public class ListViewColumnSorterExt : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        private ListView listView;
        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorterExt(ListView lv)
        {
            listView = lv;
            listView.ListViewItemSorter = this;
            listView.ColumnClick += new ColumnClickEventHandler(listView_ColumnClick);

            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ReverseSortOrderAndSort(e.Column, (ListView)sender);
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            if (listviewY.Text == "") return 0; //dirty bugfix for an bigfix

            // Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        private int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        private SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

        private void ReverseSortOrderAndSort(int column, ListView lv)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (column == this.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (this.Order == SortOrder.Ascending)
                {
                    this.Order = SortOrder.Descending;
                }
                else
                {
                    this.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                this.SortColumn = column;
                this.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            lv.Sort();
        }
    }

}
