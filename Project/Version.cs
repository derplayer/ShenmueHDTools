using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShenmueHDTools
{
    public static class Version
    {
        //Version
        public static double actualVerison = 1.01;
        public static string urlversion = "https://goo.gl/pWe4jg"; //version.json for update messages
    }

    [DataContract]
    public class Version_JSON
    {
        [DataMember]
        public double newestVersion { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string message { get; set; }
    }

}