﻿using System;
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
