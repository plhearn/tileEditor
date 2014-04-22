using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace XNA_Map_Editor.Classes
{
    [Serializable()]
    class FileFormat
    {
        public      String          texture_file_name;
        public      Point           texture_dimensions;        
        public      TileMapSize     map_dimensions;
        public      Tile[,,]        tile_map;
        public      Tile[,]         tile_palette;
        public      Int32[,]        terrain_layout;
        public      TerrainType[]   terrain_list;
        public      List<Portal>    portals;
        public      int             portalIndex;
        public      List<PortalDestination> destinations;
        public      List<Chest>     chests;
        public      List<NPC>       npcs;
        public      List<FixedCombatNPC> fixedCombatNPCs;
        public      List<Block>     blocks;
        public      List<Switch>    switches;
    }
}
