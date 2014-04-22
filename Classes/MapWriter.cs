    #region Using Statements
using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

// File writing system
using System.Data;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


// XNA Stuff
using XNA = Microsoft.Xna.Framework;
using XNAGraphics = Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

// Custom using statements 
using XNA_Map_Editor.Classes;
using XNA_Map_Editor.Helpers;
using XNA_Map_Editor.SubForms;
#endregion

namespace XNA_Map_Editor.Classes
{
    class MapWriter
    {
        #region Class Fields

        BinaryFormatter     binary_formatter;
        Stream              serialzed_stream;
        FileFormat          xmap;

        #endregion
        
        #region Public Methods

        public Boolean WriteBinaryMap(String FileName)
        {
            try
            {
                serialzed_stream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);                
                binary_formatter = new BinaryFormatter();
                xmap             = new FileFormat();

                WriteMapData();
            }
            catch (Exception e)
            {
                #if(DEBUG)               
                MessageBox.Show(e.Message, "Save Map Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                #else // RELEASE 
                MessageBox.Show("Error while saving map, the file could be in use by another program, or is write protected", "Save Map Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                #endif

                return false;
            }
            finally
            {
                serialzed_stream.Close();
                serialzed_stream.Dispose();
            }

            // Write to file Ok
            return true;
        }

        private void WriteMapData()
        {
            // copy current map data
            if (GLB_Data.TextureFileName == null)
            {
                xmap.texture_file_name = "";
            }
            else
            {
                xmap.texture_file_name = GLB_Data.TextureFileName;
            }

            xmap.map_dimensions     = GLB_Data.MapSize;
            xmap.tile_map           = GLB_Data.TileMap;
            xmap.tile_palette       = GLB_Data.TilePalette;
            
            xmap.terrain_list       = (TerrainType[]) GLB_Data.TerrainList.ToArray(typeof(TerrainType));

            xmap.terrain_layout = GLB_Data.TerrainLayout;

            if (GLB_Data.TerrainLayout.GetLength(0) < GLB_Data.MapSize.Width ||
                GLB_Data.TerrainLayout.GetLength(1) < GLB_Data.MapSize.Height)
            {
                xmap.terrain_layout = new int[GLB_Data.MapSize.Width, GLB_Data.MapSize.Height]; ;
            }

            if (GLB_Data.TilesTexture == null)
            {
                xmap.texture_dimensions = new Point(0, 0);
            }
            else
            {
                xmap.texture_dimensions = new Point(GLB_Data.TilesTexture.Width, GLB_Data.TilesTexture.Height);
            }

            xmap.portals = GLB_Data.portals;
            xmap.portalIndex = GLB_Data.portalIndex;
            xmap.destinations = GLB_Data.destinations;
            xmap.chests = GLB_Data.chests;
            xmap.npcs = GLB_Data.npcs;
            xmap.fixedCombatNPCs = GLB_Data.fixedCombatNPCs;


            binary_formatter.Serialize(serialzed_stream, xmap);
        }

        #endregion
    }
}
