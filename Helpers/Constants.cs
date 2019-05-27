using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNA_Map_Editor.Helpers
{
    public static class Constants
    {
        public static readonly Int32 DEFAULT_TILE_SIZE  = 32;
        public static readonly Int32 NULL_TILE          = -1;
        public static readonly Int32 BASE_LAYER         = 0;
        public static readonly Int32 WALK_LAYER         = 1;
        public static readonly Int32 UNDO_LIMIT         = 10;
        // walk grid alpha values
        public static readonly Int32 ALPHA_INCREMENT    = 2;
        public static readonly Int32 ALPHA_MAX          = 100;
        public static readonly Byte  ALPHA_MIN          = 85;

        // TILE MAP LIMITS
        public static readonly Int32 MIN_MAP_DEPTH      = 1;
        public static readonly Int32 MAX_MAP_DEPTH      = 10;

        public static readonly Int32 MIN_MAP_WIDTH      = 1;
        public static readonly Int32 MAX_MAP_WIDTH      = 20000;

        public static readonly Int32 MIN_MAP_HEIGHT     = 1;
        public static readonly Int32 MAX_MAP_HEIGHT     = 20000;

        public static readonly float MAX_ZOOM           = -2f;
        public static readonly float MIN_ZOOM           = 4f;
        public static readonly float NORMAL_ZOOM        = 1f;

        public static readonly float ROTATION_NULL      = 0f;

        // TERRAIN DATA

        public static readonly Int32 MAX_TERRAINS                         = 5;
        public static readonly String DEFAULT_TERRAIN_NAME                = "Default";
        public static readonly System.Drawing.Color DEFAULT_TERRAIN_COLOR = System.Drawing.Color.Brown;

        public static readonly Int32 TERRAIN_DEFAULT_ID     = 1;
        public static readonly float TERRAIN_DEFAULT_SPEED  = 1f;
        public static readonly Int32 TERRAIN_NORMAL         = 0;
        
    }

    public enum PaintTool
    {
          Brush         = 1
        , Fill          = 2
        , Eraser        = 3
        , Walk          = 4
        , MarqueeBrush  = 5
        , MarqueeEraser = 6
        , MarqueeWalk   = 7
        , MarqueeTerrain = 8
        , Portal = 9
        , Chest = 10
        , NPC = 11
        , FixedCombat = 12
        , Block = 13
        , Switch = 14
        , MarqueeSelect = 15
    };

    public enum Direction
    {
        Up,
        Down
    };
}
