using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShenmueHDTools
{
    public partial class Loading : Form
    {
        Random random = new Random();

        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            this.vmuBox.Image = null;
            this.vmuBox.Image = Resources.load[random.Next(0, Resources.load.Count)];
        }
    }
}
