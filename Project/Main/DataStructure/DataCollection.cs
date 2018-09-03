using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.DataStructure
{
    [Serializable]
    public class DataCollection
    {
        public HeaderStructure Header { get; set; }
        public List<FileStructure> Files { get; set; }
    }
}
