# RomBrowser

An info tool for vintage ROM/EPROM/FLASH images

Inspired by Wolfgang Robels ROM wizard with its graphical sample view, I wrote this similar tool to search through large amounts of ROM images very quickly.

## Features

- .NET Windows single EXE application (no installation, needs at least .NET 4.5)
- Fast directory viewer to browse quickly through large libraries of images
- Shows bin and Intel Hex files
- Shows the ROM contents as a graphic pattern
- Shows 8-Bit checksum, CRC32 and SHA1
- Compare function for 2 or more images, differences are shown as yellow patterns
- Tries to detect leading start address (first 2 bytes, Commodore style)
- Tries to detect IBM PC ROM extensions
- More detections to come...
- No editor functions and no hex display so far

![Screenshot](https://github.com/detlefgerhardt/RomBrowser/blob/master/screen1.png)

## Links

Wolfgang Robel's [ROM-Wizard](http://www.wolfgangrobel.de/romwizard.htm)
