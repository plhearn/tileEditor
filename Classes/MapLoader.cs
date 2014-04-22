#region Using Statements
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

// XNA
using Microsoft.Xna.Framework.Graphics;

// File writing system
using System.Data;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using XNA_Map_Editor.Helpers; 
#endregion

namespace XNA_Map_Editor.Classes
{
    class MapLoader
    {

        #region Class Fields

        FileStream      file_stream;
        BinaryFormatter binary_formatter;
        FileFormat      xmap;
        Boolean         return_value;

        #endregion


        internal bool LoadBinaryMap(string FileName)
        {
            return_value = true;

            try
            {
                file_stream      = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                binary_formatter = new BinaryFormatter();
                xmap             = new FileFormat();

                return_value     = LoadMapData();
            }
            catch (Exception e)
            {
                #if(DEBUG)
                MessageBox.Show(e.Message, "Load Map Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                #else // RELEASE
                MessageBox.Show("Error loading map file, the file could be corrupt", "Load Map Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                #endif

                return_value = false;
            }
            finally
            {
                file_stream.Close();
                file_stream.Dispose();
            }

            return return_value;
        }

        private Boolean LoadMapData()
        {
            
            xmap = (FileFormat)binary_formatter.Deserialize(file_stream);

            if (xmap.texture_file_name == "")
            {
                GLB_Data.MapSize = xmap.map_dimensions;
                return true;
            }

            if (CheckTileTexture(ref xmap.texture_file_name, true))
            {
                // 22-NOV-2008:
                // Variable Tilesize has been implemented but older .xmap files do not support it.
                // Check if there is a 0 tile size in current xmap structure, if yes set it to DEFAULT
                if (xmap.map_dimensions.TileSize == 0)
                {
                    xmap.map_dimensions.TileSize = Constants.DEFAULT_TILE_SIZE;
                }

                // copy deserialized data to GLB_Data
                GLB_Data.MapSize            = xmap.map_dimensions;
                GLB_Data.TileMap            = xmap.tile_map;
                GLB_Data.TextureFileName    = xmap.texture_file_name;
                GLB_Data.TilePalette        = xmap.tile_palette;

                

                GLB_Data.TerrainList.Clear();

                if (xmap.terrain_layout == null)
                {
                    // map file does not contain terrain layout information
                    // make a new empty terrain layout.
                    GLB_Data.TerrainLayout = new int[GLB_Data.MapSize.Width, GLB_Data.MapSize.Height];                    
                }
                else
                {
                    // map has terrain layout, we can copy it
                    GLB_Data.TerrainLayout = xmap.terrain_layout;

                    foreach (TerrainType t in xmap.terrain_list)
                    {
                        GLB_Data.TerrainList.Add(t);
                    }
                }

                GLB_Data.portals = xmap.portals;
                if (GLB_Data.portals == null)
                    GLB_Data.portals = new List<Portal>();

                GLB_Data.portalIndex = xmap.portalIndex;

                GLB_Data.destinations = xmap.destinations;
                if (GLB_Data.destinations == null)
                    GLB_Data.destinations = new List<PortalDestination>();

                GLB_Data.chests = xmap.chests;
                if (GLB_Data.chests == null)
                    GLB_Data.chests = new List<Chest>();

                GLB_Data.npcs = xmap.npcs;
                if (GLB_Data.npcs == null)
                    GLB_Data.npcs = new List<NPC>();

                GLB_Data.fixedCombatNPCs = xmap.fixedCombatNPCs;
                if (GLB_Data.fixedCombatNPCs == null)
                    GLB_Data.fixedCombatNPCs = new List<FixedCombatNPC>();

                GLB_Data.blocks = xmap.blocks;
                if (GLB_Data.blocks == null)
                    GLB_Data.blocks = new List<Block>();

                GLB_Data.switches = xmap.switches;
                if (GLB_Data.switches == null)
                    GLB_Data.switches = new List<Switch>();

                return true;
            }

            return false;
        }


        internal bool LoadBinaryMapOther(string FileName)
        {
            return_value = true;

            try
            {
                file_stream = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                binary_formatter = new BinaryFormatter();
                xmap = new FileFormat();

                return_value = LoadMapDataOther();
            }
            catch (Exception e)
            {
                #if(DEBUG)
                    MessageBox.Show(e.Message, "Load Map Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                #else // RELEASE
                    MessageBox.Show("Error loading map file, the file could be corrupt", "Load Map Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                #endif

                return_value = false;
            }
            finally
            {
                file_stream.Close();
                file_stream.Dispose();
            }

            return return_value;
        }

        private Boolean LoadMapDataOther()
        {

            xmap = (FileFormat)binary_formatter.Deserialize(file_stream);

            if (xmap.texture_file_name == "")
            {
                GLB_Data_Other.MapSize = xmap.map_dimensions;
                return true;
            }

            if (CheckTileTexture(ref xmap.texture_file_name, true))
            {
                // 22-NOV-2008:
                // Variable Tilesize has been implemented but older .xmap files do not support it.
                // Check if there is a 0 tile size in current xmap structure, if yes set it to DEFAULT
                if (xmap.map_dimensions.TileSize == 0)
                {
                    xmap.map_dimensions.TileSize = Constants.DEFAULT_TILE_SIZE;
                }

                // copy deserialized data to GLB_Data_Other
                GLB_Data_Other.MapSize = xmap.map_dimensions;
                GLB_Data_Other.TileMap = xmap.tile_map;
                GLB_Data_Other.TextureFileName = xmap.texture_file_name;
                GLB_Data_Other.TilePalette = xmap.tile_palette;



                /*
                GLB_Data_Other.TerrainList.Clear();

                if (xmap.terrain_layout == null)
                {
                    // map file does not contain terrain layout information
                    // make a new empty terrain layout.
                    GLB_Data_Other.TerrainLayout = new int[GLB_Data_Other.MapSize.Width, GLB_Data_Other.MapSize.Height];
                }
                else
                {
                    // map has terrain layout, we can copy it
                    GLB_Data_Other.TerrainLayout = xmap.terrain_layout;

                    foreach (TerrainType t in xmap.terrain_list)
                    {
                        GLB_Data_Other.TerrainList.Add(t);
                    }
                }
                */

                GLB_Data_Other.portals = xmap.portals;
                GLB_Data_Other.portalIndex = xmap.portalIndex;

                return true;
            }

            return false;
        }

        private Boolean CheckTileTexture(ref string TextureFile, Boolean FirstTime)
        {
            System.Drawing.Image aux_tileset; //= System.Drawing.Image.FromFile(reload_texture_dialog.FileName);
            OpenFileDialog reload_texture_dialog = new OpenFileDialog();            

            reload_texture_dialog.InitialDirectory = Environment.CurrentDirectory + @"\Tiles";
            reload_texture_dialog.Filter           = "Image files (*.img *.jpg *.png *.bmp)|*.img; *.jpg; *.png; *.bmp|All Files (*.*)| *.*";
            reload_texture_dialog.Title            = "Reload tileset texture";


            if (FirstTime)
            {
                if (File.Exists(TextureFile))
                {
                    // Check Dimensions
                    aux_tileset = System.Drawing.Image.FromFile(TextureFile);

                    if (aux_tileset.Width < xmap.texture_dimensions.X || aux_tileset.Height < xmap.texture_dimensions.Y)
                    {
                        MessageBox.Show("Tileset provided does not have the same dimensions as the original tileset, " +
                                        "please specify a tileset that at leaset matches the following dimentions:" + Environment.NewLine +
                                        xmap.texture_dimensions.ToString(), "Tileset dimensions mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        CheckTileTexture(ref TextureFile, false);
                    }
                }
                else
                {
                    MessageBox.Show("Tileset:" + Environment.NewLine +
                                    TextureFile + Environment.NewLine +
                                    "No longer exist in the specified location, specify a new Tileset location",
                                    "Error loading tileset", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                   
                    CheckTileTexture(ref TextureFile, false);
                }
            }
            else
            {
                DialogResult loaded_result = reload_texture_dialog.ShowDialog();

                if (loaded_result == DialogResult.OK)
                {
                    // check for tileset dimentions before loading
                    aux_tileset = System.Drawing.Image.FromFile(reload_texture_dialog.FileName);

                    if (aux_tileset.Width < xmap.texture_dimensions.X || aux_tileset.Height < xmap.texture_dimensions.Y)
                    {
                        MessageBox.Show("Tileset provided does not have the same dimensions as the original tileset, " +
                                        "please specify a tileset that at least matches the following dimentions:" + Environment.NewLine +
                                        xmap.texture_dimensions.ToString(), "Tileset dimensions mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        CheckTileTexture(ref TextureFile, false);
                    }
                    else
                    {
                        // Everything went ok 
                        TextureFile = reload_texture_dialog.FileName;
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Tileset load cancelled by the user, aborting load operation", "Load operation cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return_value = false;
                }
            }

            return return_value;

            #region OLD_CODE

            //// texture file not found, ask user for new texture file
            //OpenFileDialog reload_texture_dialog = new OpenFileDialog();
            //Boolean return_value = true;

            //if (File.Exists(TextureFile) && FirstTime)
            //{
            //    texture_ok = true;
            //}
            //else if (!File.Exists(TextureFile) && FirstTime)
            //{
            //    MessageBox.Show("Tileset:" + Environment.NewLine +
            //                     TextureFile + Environment.NewLine +
            //                     "No longer exist in the specified location, specify a new Tileset location",
            //                     "Error loading tileset", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    // Init file dialog
            //    reload_texture_dialog.InitialDirectory = Environment.CurrentDirectory + @"\Tiles";
            //    reload_texture_dialog.Filter = "Image files (*.img *.jpg *.png *.bmp)|*.img; *.jpg; *.png; *.bmp|All Files (*.*)| *.*";
            //    reload_texture_dialog.Title = "Reload tileset texture";
            //}
            //else if (texture_ok)
            //{
            //    return true;
            //}

            //// Open load dialog
            //DialogResult loaded_result = reload_texture_dialog.ShowDialog();

            //if (loaded_result == DialogResult.OK)
            //{
            //    // check for tileset dimentions before loading
            //    System.Drawing.Image aux_tileset = System.Drawing.Image.FromFile(reload_texture_dialog.FileName);

            //    if (aux_tileset.Width != xmap.texture_dimensions.X || aux_tileset.Height != xmap.texture_dimensions.Y)
            //    {
            //        MessageBox.Show("Tileset provided does not have the same dimensions as the original tileset, " +
            //                        "please specify a tileset that matches the following dimentions:" + Environment.NewLine +
            //                        xmap.texture_dimensions.ToString(), "Tileset dimensions mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //        texture_ok = false;
            //        CheckTileTexture(ref TextureFile, false);
            //    }
            //    else
            //    {
            //        // Everything went ok 
            //        TextureFile = reload_texture_dialog.FileName;
            //        return true;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Tileset load cancelled by the user, aborting load operation", "Load operation cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return_value = false;
            //}

            //return return_value;
            #endregion
        }

    }
}
