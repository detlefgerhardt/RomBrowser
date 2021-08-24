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
- If you get an error, check if you have .NET 4.5 installed.
- Click on the directory button in the header (above the directory windows) to choose the directory with the your ROM files.
- Choose the number of ROM panels you want to view simultaneously from the drop-down box in der header (above the panels).
- Select the active panel bei clicking on the "ROM #X" at the top of a panel. The active panel is marked by a red border.
- In the directory window browse to the ROM image file you want to display.
- Select another panel and browse to another file - and so on...
- Check the compare button on at least 2 panel to compare them. The difference are show as yellow patterns.
- It it possible to compare ROM images of different size. The bytes that are missing in the smaller images are also shown as yellow patterns in the larger images.

## Links

Wolfgang Robel's [ROM-Wizard](http://www.wolfgangrobel.de/romwizard.htm)
