# RomBrowser

A fast bowser for vintage ROM/EPROM/FLASH images

Inspired by Wolfgang Robel's ROM-Wizard with its graphical view, I wrote this similar tool to browse through large amounts of ROM images very quickly.

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
- No edit functions and no hex display so far

![Screenshot](https://github.com/detlefgerhardt/RomBrowser/blob/main/screen1.png)

## Quick instructions

- Start RomBrowser.exe
- If you get an error, check if you have .NET 4.5 installed.
- Click on the directory button in the header (above the directory windows) to choose the directory with the your ROM files.
- Choose the number of ROM panels you want to view simultaneously from the drop-down box in der header (above the panels).
- Select the active panel bei clicking on the "ROM #X" at the top of a panel. The active panel is marked by a red border.
- In the directory window browse to the ROM image file you want to display.
- Select another panel and browse to another file - and so on...
- Check the compare button on at least 2 panel to compare them. The difference are show as yellow patterns.
- It it possible to compare ROM images of different size. The bytes that are missing in the smaller images are also shown as yellow patterns in the larger images.

## Meaning of the color patterns

- Red dot: a byte with value $00
- Blue dot: a byte with value $FF
- Green dot: any other value
- If the image size is larger than 2048 bytes, each dot represents more than 1 byte. In this case the dot is red or blue if at least one of the represented bytes is $00 or $FF.
- In compare-mode the dot is yellow if at least on represented byte is different.

## Links

Wolfgang Robel's [ROM-Wizard](http://www.wolfgangrobel.de/romwizard.htm)
