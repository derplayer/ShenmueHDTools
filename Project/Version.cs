using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Globalization;

namespace ShenmueHDTools
{
    public static class Version
    {
        //Version
        public static string ApplicationName = "Shenmue HD ModTools";
        public static string ApplicationTitle
        {
            get
            {
                return String.Format("{0} v{1}", ApplicationName, ActualVerison.ToString(CultureInfo.InvariantCulture));
            }
        }
        public static double ActualVerison = 1.2;
        public static string UrlVersion = "https://goo.gl/pWe4jg"; //version.json for update messages
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