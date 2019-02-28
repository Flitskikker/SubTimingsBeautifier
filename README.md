# Sub Timings Beautifier

This tool automatically aligns the timings (or "cues") of subtitles in subtitle files (e.g. SubRip/.srt) to the exact frame times. It also automatically snaps cues to nearby shot cuts (or "scene changes") for a spot-on sync, and makes the gaps (or "intervals") between subtitles consistent, resulting in a more uniform rhythm in the "flashing" of subtitles. This will sophisticate the overall subtitle and provide a better viewing experience.

I created this tool because the most common freeware subtitle files (such as SubRip) and most freeware subtitle editing tools (such as [Subtitle Edit](https://github.com/SubtitleEdit/subtitleedit) or Subtitle Workshop) are based on milliseconds, whereas videos are based on frames. Some software can be configured to show frames, but it's not always that accurate. When I create subtitles, I often had subtitles going 1 frame over a shot cut due to rounding. This makes sure everything is spot-on.

I realize this tool is quite niche, but I really like the resulting subtitles. I use this tool as a final step for all my subtitles.

### Key features
- Align all cues to the exact frame times, based on the video
- Detect shot cuts and automatically snap cues for a spot-on sync
- Make gaps consistent
- Several adjustment options, taking shot cuts into account
- Automatically extend all subtitles, taking shot cuts and gaps into account
- Fully configurable

![Example](https://i.imgur.com/ozZuWDv.png)

## Downloading and installing
The latest version of Sub Timings Beautifier, **1.2.5.0 (dd February 27, 2019)**, can be downloaded from the "Releases" tab: https://github.com/Flitskikker/SubTimingsBeautifier/releases

Installation is not required. You do, however, need to place the **FFmpeg** and **FFprobe** binaries in the same directory as SubTimingsBeautifier.exe, as Sub Timings Beautifier uses it for extracting timecodes and detecting shot cuts.
You can download these from here: https://ffmpeg.zeranoe.com/builds/

## Usage
![Main screen](https://i.imgur.com/CU8tq6W.png)

Obviously, a versatile tool like this requires some explanation. For instructions and examples for each function, please visit the wiki:
https://github.com/Flitskikker/SubTimingsBeautifier/wiki

## Roadmap
The following features are on my mind to be considered for future releases:
- Add support for other subtitle formats
- Add an option to apply minimum subtitle duration, but taking shot cuts into account
- Add profiles to save settings and values
- Add an option to extend subtitles for a desired CPS, but taking shot cuts into account
- Maybe add the possibility to only snap to scene changes and ignore frame timecodes (but it would undo the purpose of the tool)

## Building source code
Sub Timings Beautifier was developed using Visual Studio 2017 Community Edition without any special dependencies. It should compile and build straightaway.

## License
Licensed under GPL v3.

Contains code portions from Subtitle Edit by nikse, licensed under GPL v3.
