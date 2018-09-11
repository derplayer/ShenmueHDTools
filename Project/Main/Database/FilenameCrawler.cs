using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ShenmueHDTools.Main;
using ShenmueHDTools.Main.Files;
using ShenmueHDTools.Main.DataStructure;

namespace ShenmueHDTools.Main.Database
{

    class FilenameCrawler
    {
        private static List<TADFile> m_tadFiles = new List<TADFile>();
        private static List<TACFile> m_tacFiles = new List<TACFile>();

        private static bool ValidChar(char character)
        {
            return (Char.IsLetterOrDigit(character) || character == '-' || character == '_' ||
                character == '.' || character == '/' || character == '\\');
        }

        public static List<string> CrawlExecutable(string filename)
        {
            List<string> filenames = new List<string>();

            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                //TODO: Only read .rdata segment by reading PE header and get offset
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                for (int i = 0; i < buffer.Length; i++)
                {
                    if (ValidChar((char)buffer[i]))
                    {
                        int start = i;
                        //look backwards
                        for (int j = 0; j < 256; j++)
                        {
                            int index = i - j;
                            if (index < 0) break;
                            if (ValidChar((char)buffer[index]))
                            {
                                start = index;
                                continue;
                            }
                            break;
                        }


                        //look forward
                        int end = i;
                        for (int j = 0; j < 256; j++)
                        {
                            int index = i + j;
                            if (index >= stream.Length) break;
                            if (ValidChar((char)buffer[index]))
                            {
                                end = index;
                                continue;
                            }
                            break;
                        }

                        //move forward by end of string
                        i += end - start;

                        string text = Encoding.ASCII.GetString(buffer, start, end - start + 1);
                        if (text.Length > 4 && (text.Contains('/') || text.Contains('\\') || text.Contains('.'))) 
                        {
                            filenames.Add(text);
                            Console.WriteLine("\"" + text + "\"");
                        }
                        continue;
                    }
                    
                }
            }

            return filenames;
        }

        public static byte[] GetBufferFromEntry(FilenameDatabaseEntry dbEntry, out bool found)
        {
            found = false;
            byte[] result = new byte[0];
            foreach (TACFile tacFile in m_tacFiles)
            {
                bool tmpFound = false;
                result = tacFile.GetFileFromEntry(dbEntry, out tmpFound);
                if (tmpFound)
                {
                    found = true;
                    break;
                }
            }
            return result;
        }

        public static void GenerateFilenameDatabase(string dataFolder = "", bool inRAM = false)
        {
            FilenameDatabase.Clear();

            m_tadFiles = new List<TADFile>();
            m_tacFiles = new List<TACFile>();
            if (!String.IsNullOrEmpty(dataFolder))
            {
                foreach (string archiveFile in ArchiveFiles)
                {
                    string tadFilename = dataFolder + "\\" + archiveFile + ".tad";
                    string tacFilename = dataFolder + "\\" + archiveFile + ".tac";
                    TADFile tadFile = new TADFile(tadFilename);
                    m_tadFiles.Add(tadFile);
                    TACFile tacFile = new TACFile();
                    
                    if (inRAM)
                    {
                        tacFile.Load(tacFilename, tadFile);
                    }
                    else
                    {
                        tacFile.Filename = tacFilename;
                        tacFile.TADFile = tadFile;
                    }
                    m_tacFiles.Add(tacFile);
                }
            }

            AudioDatabase.GenerateAudioFilenames();
            CommonDatabase.GenerateCommonFilenames();
            DiskDatabase.GenerateDiskFilenames();
            ShaderDatabase.GenerateShaderFilenames();

            m_tadFiles.Clear();
            m_tacFiles.Clear();
        }

        public static List<string> ArchiveFiles = new List<string>()
        {
            "audio_eng_5b69b0ee",
            "audio_jap_5b69b0ee",
            "common_5b6c4cd0",
            "common_5b69b0ee",
            "disk_5b69b0ee",
            "shaders_pc_5b69b0ee",
            "shaders_xb1_5b69b0ee"
        };

        
    }
}
