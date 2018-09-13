using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ShenmueHDTools.Main.Database
{
    class CommonDatabase
    {
        public static string SuffixUIFormat = "{0}?usage={1}";
        public static string SuffixFontdefFormat = "{0}?font={1}&image={2}";

        public static string SDTextureOverride = "/textureOverride/SDTextureOverride.json";
        public static string AssetRemapping = "/Remap/AssetRemapping.json";

        public static void GenerateCommonFilenames()
        {
            //AssetRemapping.json
            string assetRemapping = MurmurHash2Shenmue.GetFullFilename(AssetRemapping, false);
            byte[] assetRemappingBuffer = MurmurHash2Shenmue.GetFilenameHash(assetRemapping, false);
            uint assetRemappingFirstHash = BitConverter.ToUInt32(assetRemappingBuffer, 0);
            FilenameDatabaseEntry e = new FilenameDatabaseEntry(assetRemappingFirstHash, 0, assetRemapping);
            FilenameDatabase.Add(e);

            bool exists = false;
            byte[] buffer = FilenameCrawler.GetBufferFromEntry(e, out exists);

            if (exists)
            {
                AssetRemappingJSON remappingStructure = new AssetRemappingJSON(buffer);
                foreach (KeyValuePair<string, string> filename in remappingStructure.GenerateRMPFilenames())
                {
                    uint hash2 = MurmurHash2Shenmue.GetFilenameHashPlain(filename.Value);
                    string fFilename = MurmurHash2Shenmue.GetFullFilename(filename.Value, hash2);
                    uint hash1 = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(fFilename), 0);
                    FilenameDatabase.Add(hash1, hash2, filename.Key);
                }
            }


            //SDTextureOverride.json
            uint sdTextureOverrideSecondHash = MurmurHash2Shenmue.GetFilenameHashPlain(SDTextureOverride);
            string sdTextureOverride = MurmurHash2Shenmue.GetFullFilename(SDTextureOverride, sdTextureOverrideSecondHash);
            uint sdTextureOverrideFirstHash = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(sdTextureOverride), 0);
            e = new FilenameDatabaseEntry(sdTextureOverrideFirstHash, sdTextureOverrideSecondHash, sdTextureOverride);
            FilenameDatabase.Add(e);

            exists = false;
            buffer = FilenameCrawler.GetBufferFromEntry(e, out exists);
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

                        string newString = texFilename + "?usage=0";
                        hash2 = MurmurHash2Shenmue.GetFilenameHashPlain(newString);
                        fFilename = MurmurHash2Shenmue.GetFullFilename(newString, hash2);
                        hash1 = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(fFilename), 0);
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
                byte[] buf = FilenameCrawler.GetBufferFromEntry(entry, out exist);

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

            //LD Filenames (LOADSCREEN.UI)
            foreach(string ldFile in GetLDFiles())
            {
                uint hash2 = MurmurHash2Shenmue.GetFilenameHashPlain(ldFile);
                string fFilename = MurmurHash2Shenmue.GetFullFilename(ldFile, hash2);
                uint hash1 = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(fFilename), 0);
                FilenameDatabase.Add(hash1, hash2, fFilename);
            }
        }

        public static List<string> GenerateFontdefFilenames()
        {
            List<string> result = new List<string>();
            foreach (string fontdef in FontdefFilenames)
            {
                result.Add(fontdef);
                for (int fontId = 0; fontId < 6; fontId++)
                {
                    for (int imageId = 0; imageId < 6; imageId++)
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

                    string fName = (string)tok.Last.First;
                    string[] splitted = fName.Split('.');

                    foreach (string lang in LanguageSuffix)
                    {
                        string finalName = String.Format("{0}_{1}.{2}", splitted[0], lang, splitted[1]);
                        result.Add(finalName);
                    }
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
                    string fName = (string)tok.First;
                    result.Add(String.Format(SuffixUIFormat, fName, 0));

                    //brute force all language suffixes
                    string langSuf = HasLangSuffix(fName);
                    if (langSuf.Length > 0)
                    {
                        string srcLang = String.Format("_{0}.", langSuf);
                        foreach (string lang in LanguageSuffix)
                        {
                            string tmp = String.Format(SuffixUIFormat, fName.Replace(srcLang, "_" + lang + "."), 0);
                            if (!result.Contains(tmp))
                            {
                                result.Add(tmp);
                            }
                        }
                    }
                    else
                    {
                        string[] splitted = fName.Split('.');
                        foreach (string lang in LanguageSuffix)
                        {
                            string tmp = String.Format(SuffixUIFormat, splitted[0] + String.Format("_{0}.", lang) + splitted[1], 0);
                            if (!result.Contains(tmp))
                            {
                                result.Add(tmp);
                            }
                        }
                    }
                }
            }
            return result;
        }

        private static string HasLangSuffix(string fname)
        {
            foreach (string lang in LanguageSuffix)
            {
                if (fname.ToLower().Contains("_" + lang + ".")) return lang;
            }
            return "";
        }


        private static List<string> GetLDFiles()
        {
            List<string> result = new List<string>();

            foreach(string ldFile in LDFiles)
            {
                result.Add(String.Format(LDFormat, ldFile));
            }

            return result;
        }

        public static string SkyFormat = "/{0}/{1}";

        public static List<string> SkyFolders = new List<string>()
        {
            "Sky",
            "SkyProbe"
        };

        public static List<string> SkyFilenames = new List<string>()
        {
            "HD_skyDome.fbx",
            "HD_skyHorizon2.fbx",
            "HD_skyLayer0.fbx",
            "HD_skyHorizon0.fbx",
            "HD_skyHorizon1.fbx",
            "HD_Stars0.fbx",
            "HD_Moon.fbx",
            "HD_skyLayer1.fbx",
            "HD_Corona.fbx",
        };

        public static List<string> LanguageSuffix = new List<string>()
        {
            "de",
            "fr",
            "kr",
            "sc",
            "tc",
            "jp"
        };

        public static string LDFormat = "/ui/loadscreen/textures/headers/{0}.png?usage=0";

        public static List<string> LDFiles = new List<string>()
        {
            "LD4DAYAF",
            "LDABESYO",
            "LDAJIITI",
            "LDASIARK",
            "LDBARHAR",
            "LDBARMJQ",
            "LDBARYKS",
            "LDBPIZZA",
            "LDBUNKAD",
            "LDCHIKA",
            "LDDAI10S",
            "LDDAI11S",
            "LDDAI12S",
            "LDDAI13S",
            "LDDAI14S",
            "LDDAI15S",
            "LDDAI16S",
            "LDDAI17S",
            "LDDAI18S",
            "LDDAI1SO",
            "LDDAI2SO",
            "LDDAI3SO",
            "LDDAI4SO",
            "LDDAI5SO",
            "LDDAI6SO",
            "LDDAI7SO",
            "LDDAI8SO",
            "LDDAI9SO",
            "LDDAISAN",
            "LDDOBUIT",
            "LDGAMEYU",
            "LDHAZUKI",
            "LDJIMSYO",
            "LDJYUUTA",
            "LDKARAOK",
            "LDKITAKU",
            "LDKOUJIG",
            "LDKYUKEI",
            "LDKYUSOK",
            "LDLINDA",
            "LDMANPUK",
            "LDNAGAIK",
            "LDOMOYA",
            "LDOPNING",
            "LDRAPISU",
            "LDRIYOMA",
            "LDROSIYA",
            "LDRROOMK",
            "LDRYROOM",
            "LDRYURIH",
            "LDSAKURA",
            "LDSEKAIR",
            "LDSINYKK",
            "LDSLOTHO",
            "LDSOBAYA",
            "LDSYUEIR",
            "LDTAKARA",
            "LDTATOO",
            "LDTOMATO",
            "LDWASYOK",
            "LDYAMANO",
            "LD_0101",
            "LD_0214",
            "LD_1224",
            "LD_1225",
            "LD_1231",
            "LD4DAYAF"
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
            "/ui/loadscreen/LoadScreen.ui",
            "/ui/gamehelp/Help_New.ui",
            "/ui/gamehud/GameHudTraining.ui",
            "/ui/splash/Splash.ui",
            "/ui/splash/SplashSecondary.ui",

            //not indexed files
            "/ui/splash/Splash_jp.ui",
            "/ui/gamehud/GameHudStreetFighter.ui",
        };

        public static List<string> HardcodedFilenames = new List<string>()
        {
            //Missing
            "/fx/wetness_mask01.png?usage=0",
            "/foliageanim.json",

            //dont know if valid
            "/particles/rain/rain.fbx",
            "/particles/snow/snow.fbx",

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
        };
    }
}
