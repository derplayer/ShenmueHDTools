using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools
{
    /* The archive container/.tac(?) */
    public class tacItem
    {
        public byte[] startPointer = new byte[4];
        public byte[] sizeData = new byte[4];
        public byte[] unknownHash = new byte[12]; //xref with exe rdata?
    }
}
