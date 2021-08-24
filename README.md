# RomBrowser

A fast bowser for vintage ROM/EPROM/FLASH images

Inspired by Wolfgang Robel's ROM wizard with its graphical view, I wrote this similar tool to browse through large amounts of ROM images very quickly.

## Features

- .NET Windows single EXE application (no installation, needs at least .NET 4.5)
- Fast directory viewer to browse quickly through large libraries of ROM images
- Shows bin and Intel Hex files
- Shows the ROM contents as a graphic pattern
- Shows 8-Bit checksum, CRC32 and SHA1
- Compare function for 2 or more images, differences are shown as yellow patterns
- Tries to detect leading start address (first 2 bytes, Commodore style)
- Tries to detect IBM PC ROM extensions
- More detections to come...
- No editor functions and no hex display so far

![Screenshot](https://github.com/detlefgerhardt/RomBrowser/blob/main/screen1.png)

## Quick instructions

- Start RomBrowser.EXE
- Check if you have .NET 4.5 installed if you get an error.
- Click on the directory button in the header above the directory windows to choose the directory with the ROM files.
- Choose the number of images you want to view simultaneously from the drop-down box in der header above the ROM image displays.
- Select the first display panel bei clicking on the "ROM #x". The active panel is marked by a red border.
- In direytory window browse to the ROM image file you want to display.
- Select another panel and browse to another file.
- Check the compare button on at least 2 panel for compare. The difference are show as yellow patterns.

## Links

Wolfgang Robel's [ROM-Wizard](http://www.wolfgangrobel.de/romwizard.htm)
