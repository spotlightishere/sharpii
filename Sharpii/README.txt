/------------------------------------------------------------------------------>
                                 Sharpii 1.7.3
       <---------------------------------------------------------------->
                               An app by person66
                 libWiiSharp.dll by leathl (mod by scooby74029)                         
/------------------------------------------------------------------------------>



/----DESCRIPTION
/------------------------------>

Sharpii is a command line app that I made, which uses leathl's 
libWiiSharp.dll to perform tasks such as:
         - Pack, unpack, or edit .wad files
         - Pack, and unpack U8 archives
         - Patch IOS .wad files with various patches
         - Download files from NUS
         - Convert a .wav file to .bns, and vice versa
         - Convert an image file to a .tpl, and vice versa
         - Send a .dol or .wad to the Homebrew Channel over Wi-Fi


/----USAGE
/------------------------------>

I won't go in to detail here, but to see all the commands, just start 
up the command prompt, navigate to the folder containing Sharpii, and type:

                                    Sharpii.exe -h

OR, if you want help with a specific function use

                             Sharpii.exe [function] -h

Where [function] would obviously be replaced with the function you want
help with.


/----NOTES
/------------------------------>

 NUS Downloading:
/------------------>
  When downloading single contents from NUS (using the -s argument) make
  sure you have both the path, and the file name when specifying the output.
  For example, if the output is set to '.\hello.app' then the file will be
  saved as 'hello.app' in the current directory. However, if the output is 
  set to 'hello.app' you will get an error.
	
  Also note that When Downloading single contents, it will only save the
  decrypted file.
  
  If you wish to download the latest content, use '-v latest' instead of the
  actual version number.
  
  If you have the output format set only to WAD, and your your output location
  has '.wad' at the end, or you have not specified one, then instead of being
  saved inside a folder, just the wad file will be saved.

/----SOURCE
/------------------------------>

The original source for Sharpii is available at: https://github.com/mogzol/sharpii
spotlightishere's version is https://github.com/spotlightishere/sharpii and was edited
just for https://github.com/RiiConnect24/IOS-Patcher to work on a Mac + be stripped down.


/----CREDITS
/------------------------------>

Sharpii uses scooby74029's mod of libWiiSharp.dll by leathl, and 
it borrows some code from some of the examples included with libWiiSharp.

libWiiSharp can be found at: https://code.google.com/archive/p/libwiisharp/


SendWad uses CRAP's installer by WiiCrazy/I.R.on, with any edits that leathl
may have made when adding it to CustomizeMii (which is where I got the source
from). Since version 1.6, the AHBPROT code it uses is just mostly stolen from
WiiMod by jskyboo.


I would also like to thank XFlak and JoostinOnline for doing a bit of beta 
testing for me (and giving me many ideas). Thanks!


/----LICENSE
/------------------------------>

Sharpii is released under the terms of the GNU General Public License v3.
See "LICENSE.txt" for more information.


/----CHANGELOG
/------------------------------>
1.7.3
  - Still not dead!
  - Updated URLs for the downloaders to use GitHub instead of
    Google Code
  - WadInstaller.dll is now included in the release zip
1.7.2
  - I am not dead! Yay!
  - Fixed a bug that would prevent you from changing a wad type
  - Wad info now also displays the full, 16-character Title ID
1.7.1
  - Fixed a bug that prevented Sharpii from checking for SharpiiIP
    in the system variables
1.7
  - Sharpii can now be installed for use without the exe
  - SharpiiIP is now a system variable, not a user one.
  - Sharpii now looks for DLLs in the same directory as the exe
  - Bug fixes
1.6
  - SendWad now supports AHBPROT (use '-ahb')
  - IP can now be saved in an environmental variable (SharpiiIP)
    for both SendWad and SendDol (manually or with '-saveip')
  - Pointless easter eggs are fun!
  - Code cleanup/bug fixes
1.5
  - Added the ability to send WADs to the HBC using SendWad
  - You can now download an IOS with -ios # in NUSD
  - Downloaded IOS wads are now named like so: IOS##-64-####.wad
  - Under certain conditions, when downloading a wad with NUS,
    it will not be saved in a folder, just as the WAD (see ReadMe)
  - If missing dll's are detected (WadInstaller or libWiiSharp),
    Sharpii will ask to download them, if they are required.
  - You can now use a .dol file instead of a .wad with the '-dol'
    in the WAD editor/packer
  - Probably a few other little things I have forgotten
  - Even more code cleanup and bug fixes
1.4
  - Added the ability to send arguments in the SendDol function
  - Changed the way the SendDol function works a little
  - More code cleanup and bug fixes
1.3
  - Added the ability to copy parts of one WAD to a different
    WAD (either the banner, the icon, the sound, or the dol)
  - Added the ability to download just a single content from NUS
  - Code cleanup and bug fixes
  - Sharpii can now find JoostinOnline a girlfriend! :P
1.2
  - Added version patch support for IOS patching
  - Switched to scooby74029's mod of libWiiSharp 
  - Bug fixes
1.1
  - Added support for NUS downloading
1.0
  - Initial release