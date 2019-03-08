using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShenmueDKSharp.Files.Models;

namespace ShenmueHDModelEditor.Controls
{
    public partial class VertexControl : UserControl
    {
        public VertexControl()
        {
            InitializeComponent();
        }

        public void SetVertex(Vertex vert)
        {
            numericUpDown_PosX.Value = (decimal)vert.PosX;
            numericUpDown_PosY.Value = (decimal)vert.PosY;
            numericUpDown_PosZ.Value = (decimal)vert.PosZ;

            numericUpDown_NormX.Value = (decimal)vert.NormX;
            numericUpDown_NormY.Value = (decimal)vert.NormY;
            numericUpDown_NormZ.Value = (decimal)vert.NormZ;

            numericUpDown_U.Value = (decimal)vert.U;
            numericUpDown_V.Value = (decimal)vert.V;

            numericUpDown_R.Value = (decimal)vert.R;
            numericUpDown_G.Value = (decimal)vert.G;
            numericUpDown_B.Value = (decimal)vert.B;
            numericUpDown_A.Value = (decimal)vert.A;
        }
    }
}
