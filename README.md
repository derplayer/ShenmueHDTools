# Shenmue-HD-Mod-Tools
Shenmue 1&2 HD Modding & Tweak Tools

Tool that (for now) allows unpacking, editing and rebuilding of Shenmue tad/tac files.
![Alt text](https://vgy.me/av0tj0.gif "Test Preview of Shenmue HD Mod Tools")

FAQ:

How do i use it?

* Go to TAD/TAC Options and press "Create project (from .tad/.tac)"
* Select a tad/tac file that you want to open
* It will take 1-2 min to extract it as an subfolder that is created next to the selected tad/tac
* After it is extracted, you're freely to edit directory
* When you're finnished export it as a mod (TAD/TAC Options -> Export as mod container)
* Save it where you want (in "dx11/mods" folder when you want to test it out)
* This will also take 1-2 minutes
* Launch the game, when everything is fine it should start with the new files

How to install mods?
* Just copy the mod that you have into the ".../archive/dx11/mods/" folder (create the folder, when not there) from Shenmue.

Will game updates break it?
* Maybe, for now exports work without any problems with v1.0 and v1.01

Why do the gamefiles extract each time again when i restart the tools?
* After the first extract, you need to reimport your project. To do this just go to TAD/TAC Options and press "Import existing project" * This will load the project immediately and will not take 1-2 minutes each time.

Other:
* [Shenmuedojo.com Thread](https://www.shenmuedojo.com/forum/index.php?threads/shenmue-hd-unpacker-tool.366/)
* [Reserve engineering wiki notes](https://github.com/derplayer/ShenmueHDTools/wiki)
* [Changelog](https://github.com/derplayer/ShenmueHDTools/releases)

Example mod
* Reverts the textures to the original Dreamcast ones and shows a modified SEGA logo at start.
* [Download](https://www.shenmuedojo.com/forum/index.php?attachments/sdtextureoverride-zip.1109/)

TODO:
* Filenames Database from executeable
* Include the invalidation Method
* Wiki docs

License:
MIT
