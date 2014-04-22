using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Text;

namespace XNA_Map_Editor.Classes 
{
    [Serializable()]
    public struct Tile
    {
        public Int32    id;
        public Boolean  walkable;
        public Point    grid_location;
        public Point    texture_location;
        public Int32    terrain_type;
    }

}
