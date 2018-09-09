using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShenmueHDTools.Main;
using ShenmueHDTools.Main.Files;

namespace ShenmueHDTools.Main
{
    class FilenameDatabaseEntry
    {
        public uint FirstHash { get; set; }
        public uint SecondHash { get; set; }
        public string Filename { get; set; }
        public uint FileSize { get; set; } = 0;

        public FilenameDatabaseEntry() { }
        public FilenameDatabaseEntry(uint firstHash, uint secondHash, string filename)
        {
            FirstHash = firstHash;
            SecondHash = secondHash;
            Filename = filename;
        }

        public FilenameDatabaseEntry(uint firstHash, string filename, uint fileSize)
        {
            FirstHash = firstHash;
            FileSize = fileSize;
            Filename = filename;
        }

        public bool Compare(TADFileEntry tadFileEntry)
        {
            if (FileSize > 0)
            {
                /*
                if (FirstHash == tadFileEntry.FirstHash &&
                FileSize == tadFileEntry.FileSize) return true;
                */

                //unsafe
                if (FirstHash == tadFileEntry.FirstHash) return true;
            }
            else
            {
                if (FirstHash == tadFileEntry.FirstHash &&
                SecondHash == tadFileEntry.SecondHash) return true;
            }
            return false;
        }
    }

    class FilenameDatabase
    {
        public static List<FilenameDatabaseEntry> Entries { get; set; } = new List<FilenameDatabaseEntry>();

        public static string GetFilename(TADFileEntry tadFileEntry)
        {
            foreach (FilenameDatabaseEntry entry in Entries)
            {
                if (entry.Compare(tadFileEntry)) return entry.Filename;
            }
            return "";
        }

        public static void MapFilenamesToTAD(TADFile tadFile)
        {
            foreach (TADFileEntry entry in tadFile.FileEntries)
            {
                foreach (FilenameDatabaseEntry dbEntry in Entries)
                {
                    if (dbEntry.Compare(entry))
                    {
                        string filename = dbEntry.Filename;
                        if (filename[0] == '.')
                        {
                            filename = filename.Substring(1); 
                        }
                        entry.Filename = filename;
                        Console.WriteLine("FOUND FILE: [{0}] {1}", dbEntry.FirstHash.ToString("X8"), filename);
                    }
                }
            }
        }

        public static void Add(uint firstHash, uint secondHash, string filename)
        {
            Entries.Add(new FilenameDatabaseEntry(firstHash, secondHash, filename));
        }

        public static void Add(FilenameDatabaseEntry entry)
        {
            Entries.Add(entry);
        }

        public static void Clear()
        {
            Entries.Clear();
        }
    }

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

        public static void GenerateFilenameDatabase(string dataFolder = "")
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
                    tacFile.Load(tacFilename, tadFile);
                    m_tacFiles.Add(tacFile);
                }
            }

            GenerateDiskFilenames();

            //AssetRemapping.json
            string assetRemapping = MurmurHash2Shenmue.GetFullFilename(AssetRemapping, false);
            byte[] assetRemappingBuffer = MurmurHash2Shenmue.GetFilenameHash(assetRemapping, false);
            uint assetRemappingFirstHash = BitConverter.ToUInt32(assetRemappingBuffer, 0);
            FilenameDatabase.Add(assetRemappingFirstHash, 0, assetRemapping);

            //SDTextureOverride.json
            uint sdTextureOverrideSecondHash = MurmurHash2Shenmue.GetFilenameHashPlain(SDTextureOverride);
            string sdTextureOverride = MurmurHash2Shenmue.GetFullFilename(SDTextureOverride, sdTextureOverrideSecondHash);
            uint sdTextureOverrideFirstHash = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(sdTextureOverride), 0);
            FilenameDatabaseEntry e = new FilenameDatabaseEntry(sdTextureOverrideFirstHash, sdTextureOverrideSecondHash, sdTextureOverride);
            FilenameDatabase.Add(e);

            bool exists = false;
            byte[] buffer = GetBufferFromEntry(e, out exists);
            if (exists)
            {
                List<string> textures = GetSDTextureOverrideFiles(buffer);
                if (textures.Count > 0)
                {
                    foreach (string texFilename in textures)
                    {
                        uint hash2 = MurmurHash2Shenmue.GetFilenameHashPlain(texFilename);
                        string fFilename = MurmurHash2Shenmue.GetFullFilename(texFilename, hash2);
                        uint hash1 = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(fFilename), 0);
                        FilenameDatabase.Add(hash1, hash2, fFilename);
                    }
                }
            }

            //Hardcoded Filenames
            foreach (string filename in HardcodedFilenames)
            {
                uint secondHash = MurmurHash2Shenmue.GetFilenameHashPlain(filename);
                string fullFilename = MurmurHash2Shenmue.GetFullFilename(filename, secondHash);
                uint hash = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(fullFilename), 0);
                FilenameDatabase.Add(hash, secondHash, fullFilename);
            }

            //Fontdefs
            foreach (string filename in GenerateFontdefFilenames())
            {
                uint secondHash = MurmurHash2Shenmue.GetFilenameHashPlain(filename);
                string fullFilename = MurmurHash2Shenmue.GetFullFilename(filename, secondHash);
                uint hash = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(fullFilename), 0);
                FilenameDatabase.Add(hash, secondHash, fullFilename);
            }

            //UI Filenames
            foreach (string filename in UIFilenames)
            {
                uint secondHash = MurmurHash2Shenmue.GetFilenameHashPlain(filename);
                string fullFilename = MurmurHash2Shenmue.GetFullFilename(filename, secondHash);
                uint hash = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(fullFilename), 0);

                FilenameDatabaseEntry entry = new FilenameDatabaseEntry(hash, secondHash, fullFilename);
                FilenameDatabase.Add(entry);

                bool exist = false;
                byte[] buf = GetBufferFromEntry(entry, out exist);

                if (exist)
                {
                    List<string> images = GetImagesFromUI(buf);
                    if (images.Count > 0)
                    {
                        foreach (string imageFilename in images)
                        {
                            uint hash2 = MurmurHash2Shenmue.GetFilenameHashPlain(imageFilename);
                            string fFilename = MurmurHash2Shenmue.GetFullFilename(imageFilename, hash2);
                            uint hash1 = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(fFilename), 0);
                            FilenameDatabase.Add(hash1, hash2, fFilename);
                        }
                    }
                }
            }

            //Disk Filenames


            m_tadFiles.Clear();
            m_tacFiles.Clear();
        }

        public static void GenerateDiskFilenames()
        {

            List<string> discCollection = new List<string>();
            discCollection.Add(Properties.Resources.EU_D1);
            discCollection.Add(Properties.Resources.EU_D2);
            discCollection.Add(Properties.Resources.EU_D3);
            discCollection.Add(Properties.Resources.EU_PASS);

            discCollection.Add(Properties.Resources.JAP_D1);
            discCollection.Add(Properties.Resources.JAP_D2);
            discCollection.Add(Properties.Resources.JAP_D3);
            discCollection.Add(Properties.Resources.JAP_PASS);

            discCollection.Add(Properties.Resources.US_D1);
            discCollection.Add(Properties.Resources.US_D2);
            discCollection.Add(Properties.Resources.US_D3);
            discCollection.Add(Properties.Resources.US_PASS);

            discCollection.Add(Properties.Resources.B_D1);
            discCollection.Add(Properties.Resources.B_D2);
            discCollection.Add(Properties.Resources.B_D3);
            discCollection.Add(Properties.Resources.B_PASS);

            discCollection.Add(Properties.Resources.WS_D1);

            string fName = "/misc/SegaLogo.wav";
            uint fSize = 480044;
            uint fHash = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(fName, false), 0);
            FilenameDatabaseEntry e = new FilenameDatabaseEntry(fHash, fName, fSize);
            FilenameDatabase.Add(e);

            foreach (var disc in discCollection)
            {
                using (StringReader reader = new StringReader(disc))
                {
                    string line = string.Empty;
                    do
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            var lineArr = line.Split(' ');
                            string filename = lineArr[0].Replace("\\", "/");
                            uint fileSize = Convert.ToUInt32(lineArr[1]);
                            uint hash = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(filename, false), 0);
                            FilenameDatabaseEntry entry = new FilenameDatabaseEntry(hash, filename, fileSize);
                            FilenameDatabase.Add(entry);
                        }

                    } while (line != null);
                }
            }
        }

        public static List<string> GenerateFontdefFilenames()
        {
            List<string> result = new List<string>();
            foreach (string fontdef in FontdefFilenames)
            {
                for (int fontId = 0; fontId < 5; fontId++)
                {
                    for (int imageId = 0; imageId < 5; imageId++)
                    {
                        result.Add(String.Format(SuffixFontdefFormat, fontdef, fontId, imageId));
                    }
                }
            }
            return result;
        }

        private static List<string> GetSDTextureOverrideFiles(byte[] buffer)
        {
            List<string> result = new List<string>();
            string jsonString = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
            JObject data = (JObject)JsonConvert.DeserializeObject(jsonString);

            JToken token = data.SelectToken("Mappings");
            if (token != null)
            {
                foreach (JToken tok in token.Children())
                {
                    //result.Add(String.Format(SuffixUIFormat, tok.Last.First, 0));
                    result.Add((string)tok.Last.First);
                }
            }
            return result;
        }

        private static List<string> GetImagesFromUI(byte[] buffer)
        {
            List<string> result = new List<string>();
            string jsonString = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
            JObject data = (JObject)JsonConvert.DeserializeObject(jsonString);

            JToken token = data.SelectToken("Images");
            if (token != null)
            {
                foreach (JToken tok in token.Children())
                {
                    result.Add(String.Format(SuffixUIFormat, tok.First, 0));
                }
            }
            return result;
        }

        /*
        public static byte[] GetBufferFromFilename(string filename)
        {

        }

        public static List<string> GetFilenamesFromUI(string filename)
        {

        }
        */

        public static string SuffixUIFormat = "{0}?usage={1}"; //for now always 0
        public static string SuffixFontdefFormat = "{0}?font={1}&image={2}";

        public static string SDTextureOverride = "/textureOverride/SDTextureOverride.json";
        public static string AssetRemapping = "/Remap/AssetRemapping.json";

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

        public static List<string> FontdefFilenames = new List<string>()
        {
            "/ui/font/english.fontdef",
            "/ui/font/Japanese.fontdef",
            "/ui/font/French.fontdef",
            "/ui/font/German.fontdef",
            "/ui/font/Korean.fontdef",
            "/ui/font/ChineseT.fontdef",
            "/ui/font/ChineseS.fontdef"
        };

        public static List<string> UIFilenames = new List<string>()
        {
            "/ui/70ManBattle/70ManBattle.ui",
            "/ui/actionselector/ActionSelector.ui",
            "/ui/Credits/Credits.ui",
            "/ui/gamemenu_New/GameMenu_Background.ui",
            "/ui/gamehud/GameHud.ui",
            "/ui/gamemenu_New/GameMenu_New.ui",
            "/ui/gamemenu_New/GameMenu_InformationBar.ui",
            "/ui/GameOver/GameOver.ui",
            "/ui/gamehud/GameHudRace.ui",
            "/ui/mainmenu_New/MainMenu.ui",
            "/ui/mainmenu_New/MainMenu_Wheel.ui",
            "/ui/PlatformIcons.ui",
            "/ui/mainmenu_New/MainMenu_PressStart.ui",
            "/ui/QTEMinigame/QTEMinigame.ui",
            "/ui/mainmenu_new/LoadScreen.ui",
            "/ui/gamemenu_new/SharedItems.ui",
            "/ui/gamemenu_New/SubMenu_Collection.ui",
            "/ui/gamemenu_New/SubMenu_Collection_Cassettes.ui",
            "/ui/gamemenu_New/SubMenu_Collection_Gacha.ui",
            "/ui/gamemenu_New/SubMenu_Collection_Scrolls.ui",
            "/ui/gamemenu_New/SubMenu_Items.ui",
            "/ui/gamemenu_New/SubMenu_Moves.ui",
            "/ui/gamemenu_New/SubMenu_Options.ui",
            "/ui/gamemenu_New/SubMenu_Options_Audio.ui",
            "/ui/gamemenu_New/SubMenu_Options_Controls.ui",
            "/ui/gamemenu_New/SubMenu_Options_Graphics.ui",
            "/ui/gamesubtitles/GameSubtitles.ui",
            "/ui/YesNoPrompt/YesNoPrompt_new.ui",
            "/ui/gamehud/GameHudWatch.ui",
            "/ui/gamemenu_New/GameHud_Battery.ui",
            "/ui/gamehud/GameHudGauge.ui",
            "/ui/gamehud/GameHudSkip.ui",
            "/ui/gamemessage/GameMessage.ui",
            "/ui/gamehud/GameHudMoveLearned.ui",
            "/ui/gameqte/GameQTE.ui",
            "/ui/gametraining/GameTraining.ui",
            "/ui/gametraining/GameTraining_Legacy.ui",
            "/ui/loadscreen/textures/headers",
            "/ui/loadscreen/LoadScreen.ui",
            "/ui/gamehelp/Help_New.ui",
            "/ui/gamehud/GameHudTraining.ui",
            "/ui/splash/Splash.ui",
            "/ui/splash/SplashSecondary.ui",
        };

        public static List<string> HardcodedFilenames = new List<string>()
        {
            //needs UI suffix "?usage=0"
            "/fx/wetness_mask01.png?usage=0",

            //dont know if valid
            "/particles/rain/rain.fbx",
            "/particles/snow/snow.fbx",
            "/foliageanim.json",

            "/subs/japanese.sub",
            "/subs/german.sub",
            "/subs/french.sub",
            "/subs/chineses.sub",
            "/subs/korean.sub",
            "/subs/english.sub",
            "/subs/chineset.sub",

            "/subs/japanese.glyphs",
            "/subs/german.glyphs",
            "/subs/french.glyphs",
            "/subs/chineses.glyphs",
            "/subs/korean.glyphs",
            "/subs/english.glyphs",
            "/subs/chineset.glyphs",

            "/shaders/fvf/fvf_pd_t_vs.hlsl",
            "/shaders/fvf/fvf_pd_t_ps.hlsl",
            "/engine/assets/shaders/DebugDraw_vs.hlsl",
            "/shaders/original_const_vs.hlsl",
            "/shaders/original_lamb_vs.hlsl",
            "/shaders/original_vcol1_vs.hlsl",
            "/shaders/original_vcol0_vs.hlsl",
            "/shaders/fullscreen_quad_vs.hlsl",
            "/shaders/lighting_vs.hlsl",
            "/shaders/fire_vs.hlsl",
            "/shaders/sv_vs.hlsl",
            "/shaders/simple_ps.hlsl",
            "/engine/assets/shaders/DebugDraw_ps.hlsl",
            "/shaders/caf_screen_ps.hlsl",
            "/shaders/caf_ps.hlsl",
            "/shaders/gray_ps.hlsl",
            "/shaders/msf_ps.hlsl",
            "/shaders/blur_ps.hlsl",
            "/shaders/default_ps.hlsl",
            "/shaders/fvf/fvf_pnt_vs.hlsl",
            "/shaders/fvf/fvf_pd_vs.hlsl",
            "/shaders/fvf/fvf_ptd_vs.hlsl",
            "/shaders/fvf/fvf_pntds_vs.hlsl",
            "/shaders/fvf/fvf_ptds_vs.hlsl",
            "/shaders/fvf/fvf_ptd_t_vs.hlsl",
            "/shaders/white_vs.hlsl",
            "/shaders/lighting_vcol_vs.hlsl",
            "/shaders/shadow_proj_ps.hlsl",
            "/shaders/shadow_proj_vs.hlsl",
            "/shaders/fvf/fvf_pnt_ps.hlsl",
            "/shaders/fvf/fvf_pd_ps.hlsl",
            "/shaders/fvf/fvf_ptd_ps.hlsl",
            "/shaders/fvf/fvf_pntds_ps.hlsl",
            "/shaders/fvf/fvf_ptds_ps.hlsl",
            "/shaders/fvf/fvf_ptd_t_ps.hlsl",
            "/engine/assets/shaders/depth_clear_vs.hlsl",
            "/shaders/original_strip00_ps.hlsl",
            "/shaders/original_strip03_ps.hlsl",
            "/shaders/original_strip03_vs.hlsl",
            "/engine/assets/shaders/depth_ps.hlsl",
            "/engine/assets/shaders/depth_vs.hlsl",
            "/engine/assets/shaders/uber_ps.hlsl",
            "/engine/assets/shaders/uber_vs.hlsl",
            "/engine/assets/shaders/depth_prepass_ps.hlsl",
            "/engine/assets/shaders/depth_prepass_vs.hlsl",

            //shader filenames that needed to be builded because missing vertex/fragment shader extension
            "/engine/assets/shaders/depth_clear_ps.hlsl",
            "/shaders/emu/emu_pdt_vs.hlsl",
            "/shaders/emu/emu_pdt_ps.hlsl",
            "/shaders/emu/emu_pd_vs.hlsl",
            "/shaders/emu/emu_pd_ps.hlsl",
            "/engine/assets/shaders/texturedquad_vs.hlsl",
            "/engine/assets/shaders/texturedquad_ps.hlsl",
            "/shaders/abuffer_write_vs.hlsl",
            "/shaders/abuffer_write_ps.hlsl",
            "/shaders/abuffer_clear_vs.hlsl",
            "/shaders/abuffer_clear_ps.hlsl",
            "/shaders/abuffer_comp_vs.hlsl",
            "/shaders/abuffer_comp_ps.hlsl",
            "/shaders/contrast_vs.hlsl",
            "/shaders/contrast_ps.hlsl",
            "/engine/assets/shaders/texturedquad_gammacorrect_vs.hlsl",
            "/engine/assets/shaders/texturedquad_gammacorrect_ps.hlsl",
            "/engine/assets/shaders/prefilter_irrmap_vs.hlsl",
            "/engine/assets/shaders/prefilter_irrmap_ps.hlsl",
            "/engine/assets/shaders/prefilter_envmap_vs.hlsl",
            "/engine/assets/shaders/prefilter_envmap_ps.hlsl",
            "/engine/assets/shaders/envprobe_vs.hlsl",
            "/engine/assets/shaders/envprobe_ps.hlsl",
            "/engine/assets/shaders/BRDF_LUT_vs.hlsl",
            "/engine/assets/shaders/BRDF_LUT_ps.hlsl",
            "/engine/assets/shaders/simple_vs.hlsl",
            "/engine/assets/shaders/simple_ps.hlsl",
            "/engine/assets/shaders/nuklear_vs.hlsl",
            "/engine/assets/shaders/nuklear_ps.hlsl"

        };
    }
}
