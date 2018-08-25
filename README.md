# Shenmue-HD-Mod-Tools
Shenmue 1&2 HD Modding & Tweak Tools

Tool that (for now) allows unpacking, editing and rebuilding of Shenmue tad/tac files.
![Alt text](https://vgy.me/av0tj0.gif "Test Preview of Shenmue HD Mod Tools")

FAQ:

How do i use it?

1. Go to TAD/TAC Options and press "Create project (from *.tad/*.tac)"
2. Select a tad/tac file that you want to open
3. It will take 1-2 min to extract it as an subfolder that is created next to the selected tad/tac
4. After it is extracted, you're freely to edit directory
5. When you're finnished save the container (TAD/TAC Options -> Save)
6. This will also take 1-2 minutes
7. Launch the game, when everything is fine it should start with the new files

After the first extract, you can also reimport your project.
To do this just go to TAD/TAC Options and press "Import existing project"
This will load the project immediately and dosen't take 1-2 minutes.

Changelog:

v1.0
* New Codebase
* Allows Unpacking and Rebuilding of *.tad and *tac files
* Bigger/Smaller files at rebuilding are supported (pointer recalculation inside *.tad)
* Support for fileformat detection (~75% of files)
* Support for fast-loading of already extracted Project with *.shdcache file

v0.0 (Test01)
* Simple and dirty proof of concept of *.tad/*tac extracting

Other:

[Shenmuedojo.com Thread](https://www.shenmuedojo.com/forum/index.php?threads/shenmue-hd-unpacker-tool.366/)

TODO:
Filenames Database(?) & Hashing
Include the invalidation Method

License:
MIT