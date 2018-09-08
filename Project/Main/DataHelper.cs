using ShenmueHDTools.Main.DataStructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main
{
    public class DataHelper
    {
        public void GenerateDCObject()
        {
            var test = new DCCollector();
            string disc1 = Properties.Resources.EU_D1;

            using (StringReader reader = new StringReader(disc1))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        var lineArr = line.Split(' ');
                        test.FileCollector.Add(new DCStructure
                        {
                            FilePathFull = lineArr[0],
                            FileSize = Convert.ToInt32(lineArr[1]),
                            FileName = Path.GetFileName(lineArr[0])
                        });
                    }

                } while (line != null);
            }

            return;
        }

    }
}
