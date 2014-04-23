Readme.txt

A guy named EvilNando was working on a tile editor to make tile maps for the xna platform.  He eventually stopped working on the project and released the source. I've been adding different features to it. -plhearn

****************************************************************************
XNA TILE MAP EDITOR

NandoSoft 
http://xnafantasy.wordpress.com/
****************************************************************************

DISCLAIMER:

This software is free to use , but please remember to give credits to the author.

This software is released "as is", I cannot guarantee that this software will work on other computers but my own.
I am not responsible for any damage this piece of software may cause in your system.

For help and bug reports please visit my development blog at:

http://xnafantasy.wordpress.com/

or send an email to xnafantasy@gmail.com


HARDWARE REQUIREMENTS:

     CPU: anything that it is still being sold on stores.
GRAPHICS: 3D hardware accelerator that supports DirectX 9.0c.
 STORAGE: around 300 kilobytes of space.
     RAM: 700MB for medium sized maps, more is recommended for very big maps (+200x200x10)

SOFTWARE REQUIREMENTS:

      OS: WINDOWS XP or VISTA
    MISC: .NET FRAMEWORK 2.0
          .NET FRAMEWORK 3.5
          XNA REDISTRIBUTABLE 3.0
          DIRECTX 9.0c REDISTRIBUTABLE


VERSION NOTES:

version: 3.1.0

FIXES:
		- Fixed a critical bug in the tile selection while using non-standard tile sizes.
		- NOW THE APPLICATION REQUIRES THE XNA FRAMEWORK VERSION 3.0
		

version: 3.0.0

FIXES:
	    - Fixed a critical bug when using tile textures that were not divisible by the current tile size (32px for ver 2.4.2)
	    
NEW FEATURES:

        - VARIABLE TILE SIZE: Added into the Edit menu there is a new option called "Change Tile Size", this will launch a form
        where it is now possible to enter a custom tile size

version: 2.4.2

FIXES:
        - Editor will now ask the user confirmation before closing the application.

version: 2.4.1

FIXES:
        - fixed a bug while exporting to xml using a xmap saved with a previous version.


version: 2.4

FIXES:
		- marquee paint icon replaced
		- fixed a crashing bug on the tile palette functionality
		- improved performance on map rendering routines
		- minor tweaks to the menu layout
		- added visual indicators to marquee selections (diferent colors for each marquee tool)
		- xmap format supports terrain data loading
		- xml exporter exports terrain data

NEW FEATURES:

		- New tool: Marque walk block, replaces old walk block tool

		- New tool: Marquee terrain brush and terrain type editor:
		with this tool now it is possible to assing values to specific areas of the
		tile map, this areas can be assigned with a speed factor that can be applied
		to actors crossing such areas. Terrain layer and Terrain type list is exported
		to XML format as well.


version: 2.3

FIXES:

- none

NEW FEATURES:

- New tool: Marquee eraser, replaces old eraser tool

Version: 2.0

FIXES:
        - spell check on the xml exporter
        - corrected tile size value on exported xml documents
        - replaced default application icon
        - readme.txt included with the release build
        - scrollbars work again

NEW FEATURES:

        - Texture Generator window can be called from withing the editor
          it allows to save textures of tiles that have a division of 1px
          one from another

        - Collision Templates functionality, use F2 to block, F3 to unlbock
          and F5 to apply template to the current selected layer

        - Delete Layer option, this command will delete all tile information 
          from the current selected layer, note that it will NOT remove any
          collision data

EOF
 
