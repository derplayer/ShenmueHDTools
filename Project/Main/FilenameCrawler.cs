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

        public FilenameDatabaseEntry() { }
        public FilenameDatabaseEntry(uint firstHash, uint secondHash, string filename)
        {
            FirstHash = firstHash;
            SecondHash = secondHash;
            Filename = filename;
        }

        public bool Compare(TADFileEntry tadFileEntry)
        {
            if (FirstHash == tadFileEntry.FirstHash &&
                SecondHash == tadFileEntry.SecondHash) return true;
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
                        entry.Filename = filename.Substring(1);
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
        public static Dictionary<uint, string> FilenameDictionary = new Dictionary<uint, string>();

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

        public static void GenerateFilenameDictionary(string dataFolder = "")
        {
            FilenameDatabase.Clear();

            //AssetRemapping.json
            string assetRemapping = MurmurHash2Shenmue.GetFullFilename(AssetRemapping, false);
            byte[] assetRemappingBuffer = MurmurHash2Shenmue.GetFilenameHash(assetRemapping, false);
            uint assetRemappingFirstHash = BitConverter.ToUInt32(assetRemappingBuffer, 0);
            FilenameDatabase.Add(assetRemappingFirstHash, 0, assetRemapping);

            //SDTextureOverride.json
            uint sdTextureOverrideSecondHash = MurmurHash2Shenmue.GetFilenameHashPlain(SDTextureOverride);
            string sdTextureOverride = MurmurHash2Shenmue.GetFullFilename(SDTextureOverride, sdTextureOverrideSecondHash);
            uint sdTextureOverrideFirstHash = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(sdTextureOverride), 0);
            FilenameDatabase.Add(sdTextureOverrideFirstHash, sdTextureOverrideSecondHash, sdTextureOverride);

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
                FilenameDatabase.Add(hash, secondHash, fullFilename);
            }

            //TODO Crawl ui files
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

        private static List<string> GetImagesFromUI(byte[] buffer)
        {
            List<string> result = new List<string>();



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

            "/misc/SegaLogo.wav",

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
