#region Using Statements
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;

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

                return_value     = LoadMapData(FileName);
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

        public Boolean LoadMapDataXML(string fileName)
        {

            XmlDocument xml = new XmlDocument();
            xml.Load(fileName);

            string outie = xml.OuterXml;

            int startIndex;
            int length;
            string[] split;

            //Texture Name
            startIndex = outie.IndexOf("<TextureName>") + "<TextureName>".Length;
            length = outie.IndexOf("</TextureName>") - startIndex;

            GLB_Data.TextureFileName = outie.Substring(startIndex, length).Trim();

            
            //map dimensions
            startIndex = outie.IndexOf("<MapDimensions>") + "<MapDimensions>".Length;
            length = outie.IndexOf("</MapDimensions>") - startIndex;

            split = outie.Substring(startIndex, length).Split(' ');

            int.TryParse(split[0], out GLB_Data.MapSize.Width);
            int.TryParse(split[1], out GLB_Data.MapSize.Height);
            
            //tile size
            startIndex = outie.IndexOf("<FileTileSize>") + "<FileTileSize>".Length;
            length = outie.IndexOf("</FileTileSize>") - startIndex;

            if(length <= 0)
            {
                startIndex = outie.IndexOf("<TileSize>") + "<TileSize>".Length;
                length = outie.IndexOf("</TileSize>") - startIndex;
            }


            split = outie.Substring(startIndex, length).Split(' ');

            int.TryParse(split[0], out GLB_Data.MapSize.TileSize);

            xmap = new FileFormat();

            xmap.texture_file_name = GLB_Data.TextureFileName;

            xmap.texture_dimensions.X = GLB_Data.TilesTexture.Width;
            xmap.texture_dimensions.Y = GLB_Data.TilesTexture.Height;

            xmap.map_dimensions.Width = GLB_Data.MapSize.Width;
            xmap.map_dimensions.Height = GLB_Data.MapSize.Height;
            xmap.map_dimensions.Depth = 4;
            xmap.map_dimensions.TileSize = GLB_Data.MapSize.TileSize;

            if(CheckTileTexture(ref xmap.texture_file_name, true))
            {
                /*
                //map name
                startIndex = outie.IndexOf("<Name>") + "<Name>".Length;
                length = outie.IndexOf("</Name>") - startIndex;

                GLB_Data.MapName = outie.Substring(startIndex, length).Trim();
                */

                // palette

                Tile t;

                int x = GLB_Data.TilesTexture.Width / GLB_Data.MapSize.TileSize;
                int y = GLB_Data.TilesTexture.Height / GLB_Data.MapSize.TileSize;

                int index = 1;
                GLB_Data.TilePalette = new Tile[x, y];

                for (int j = 0; j < y; j++)
                {
                    for (int i = 0; i < x; i++)
                    {
                        t = new Tile();

                        t.grid_location.X = i;
                        t.grid_location.Y = j;

                        t.id = index;
                        index++;

                        t.terrain_type = 0;
                        t.texture_location.X = 0;
                        t.texture_location.Y = 0;
                        t.walkable = true;

                        GLB_Data.TilePalette[i, j] = t;
                    }
                }


                char[] splitChars = new char[4];
                splitChars[0] = ' ';
                splitChars[1] = '\n';
                splitChars[2] = '\r';
                splitChars[3] = '\t';

                GLB_Data.TileMap = new Tile[4, GLB_Data.MapSize.Width, GLB_Data.MapSize.Height];


                //BaseLayer
                startIndex = outie.IndexOf("<BaseLayer>") + "<BaseLayer>".Length;
                length = outie.IndexOf("</BaseLayer>") - startIndex;


                split = outie.Substring(startIndex, length).Split(splitChars);

                x = 0;
                y = 0;

                foreach(string s in split)
                {
                    if (s != "")
                    {
                        t = new Tile();

                        t.grid_location.X = x;
                        t.grid_location.Y = y;

                        t.id = int.Parse(s);

                        t.terrain_type = 0;
                        t.texture_location.X = (t.id-1) % (GLB_Data.TilesTexture.Width / GLB_Data.MapSize.TileSize);
                        t.texture_location.Y = (t.id-1) / (GLB_Data.TilesTexture.Width / GLB_Data.MapSize.TileSize);
                        t.walkable = false;

                        GLB_Data.TileMap[0, x, y] = t;
                        
                        x++;

                        if(x > GLB_Data.MapSize.Width-1)
                        {
                            x = 0;
                            y++;
                        }
                    }

                }


                //Tile d = GLB_Data.TileMap[0, 58, 79];
                //Tile f = GLB_Data.TileMap[0, 59, 79];

                //FringeLayer
                startIndex = outie.IndexOf("<FringeLayer>") + "<FringeLayer>".Length;
                length = outie.IndexOf("</FringeLayer>") - startIndex;

                split = outie.Substring(startIndex, length).Split(splitChars);

                x = 0;
                y = 0;

                foreach (string s in split)
                {
                    if (s != "")
                    {
                        t = new Tile();

                        t.grid_location.X = x;
                        t.grid_location.Y = y;

                        t.id = int.Parse(s);

                        t.terrain_type = 0;
                        t.texture_location.X = (t.id - 1) % (GLB_Data.TilesTexture.Width / GLB_Data.MapSize.TileSize);
                        t.texture_location.Y = (t.id - 1) / (GLB_Data.TilesTexture.Width / GLB_Data.MapSize.TileSize);
                        t.walkable = false;

                        GLB_Data.TileMap[1, x, y] = t;

                        x++;

                        if (x > GLB_Data.MapSize.Width - 1)
                        {
                            x = 0;
                            y++;
                        }
                    }

                }



                //ObjectLayer
                startIndex = outie.IndexOf("<ObjectLayer>") + "<ObjectLayer>".Length;
                length = outie.IndexOf("</ObjectLayer>") - startIndex;

                split = outie.Substring(startIndex, length).Split(splitChars);

                x = 0;
                y = 0;

                foreach (string s in split)
                {
                    if (s != "")
                    {
                        t = new Tile();

                        t.grid_location.X = x;
                        t.grid_location.Y = y;

                        t.id = int.Parse(s);

                        t.terrain_type = 0;
                        t.texture_location.X = (t.id - 1) % (GLB_Data.TilesTexture.Width / GLB_Data.MapSize.TileSize);
                        t.texture_location.Y = (t.id - 1) / (GLB_Data.TilesTexture.Width / GLB_Data.MapSize.TileSize);
                        t.walkable = false;

                        GLB_Data.TileMap[2, x, y] = t;

                        x++;

                        if (x > GLB_Data.MapSize.Width - 1)
                        {
                            x = 0;
                            y++;
                        }
                    }

                }



                //CollisionLayer
                startIndex = outie.IndexOf("<CollisionLayer>") + "<CollisionLayer>".Length;
                length = outie.IndexOf("</CollisionLayer>") - startIndex;

                split = outie.Substring(startIndex, length).Split(splitChars);

                x = 0;
                y = 0;

                foreach (string s in split)
                {
                    if (s != "")
                    {
                        t = new Tile();

                        t.grid_location.X = x;
                        t.grid_location.Y = y;

                        t.id = -1;

                        t.terrain_type = 0;
                        t.texture_location.X = 0;
                        t.texture_location.Y = 0;

                        bool walk = false;

                        if (int.Parse(s) == 0)
                            walk = true;

                        if (int.Parse(s) == 2)
                            t.terrain_type = 2;

                        t.walkable = walk;

                        GLB_Data.TileMap[3, x, y] = t;

                        x++;

                        if (x > GLB_Data.MapSize.Width - 1)
                        {
                            x = 0;
                            y++;
                        }
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


                xmap.tile_map = GLB_Data.TileMap;
                xmap.tile_palette = GLB_Data.TilePalette;



                return true;
            }

            return false;

        }

        private Boolean LoadMapData(string fileName)
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
                    else
                    {
                        return_value = true;
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




        public Boolean LoadMapDataXMLOther(string fileName)
        {

            XmlDocument xml = new XmlDocument();
            xml.Load(fileName);

            string outie = xml.OuterXml;

            int startIndex;
            int length;
            string[] split;

            //Texture Name
            startIndex = outie.IndexOf("<TextureName>") + "<TextureName>".Length;
            length = outie.IndexOf("</TextureName>") - startIndex;

            GLB_Data_Other.TextureFileName = outie.Substring(startIndex, length).Trim();


            //map dimensions
            startIndex = outie.IndexOf("<MapDimensions>") + "<MapDimensions>".Length;
            length = outie.IndexOf("</MapDimensions>") - startIndex;

            split = outie.Substring(startIndex, length).Split(' ');

            int.TryParse(split[0], out GLB_Data_Other.MapSize.Width);
            int.TryParse(split[1], out GLB_Data_Other.MapSize.Height);

            //tile size
            startIndex = outie.IndexOf("<FileTileSize>") + "<FileTileSize>".Length;
            length = outie.IndexOf("</FileTileSize>") - startIndex;

            if (length <= 0)
            {
                startIndex = outie.IndexOf("<TileSize>") + "<TileSize>".Length;
                length = outie.IndexOf("</TileSize>") - startIndex;
            }


            split = outie.Substring(startIndex, length).Split(' ');

            int.TryParse(split[0], out GLB_Data_Other.MapSize.TileSize);

            xmap = new FileFormat();

            xmap.texture_file_name = GLB_Data_Other.TextureFileName;

            xmap.texture_dimensions.X = GLB_Data_Other.TilesTexture.Width;
            xmap.texture_dimensions.Y = GLB_Data_Other.TilesTexture.Height;

            xmap.map_dimensions.Width = GLB_Data_Other.MapSize.Width;
            xmap.map_dimensions.Height = GLB_Data_Other.MapSize.Height;
            xmap.map_dimensions.Depth = 4;
            xmap.map_dimensions.TileSize = GLB_Data_Other.MapSize.TileSize;

            if (CheckTileTexture(ref xmap.texture_file_name, true))
            {
                /*
                //map name
                startIndex = outie.IndexOf("<Name>") + "<Name>".Length;
                length = outie.IndexOf("</Name>") - startIndex;

                GLB_Data_Other.MapName = outie.Substring(startIndex, length).Trim();
                */

                // palette

                GLB_Data_Other.MapSize.Depth = 4;

                Tile t;

                int x = GLB_Data_Other.TilesTexture.Width / GLB_Data_Other.MapSize.TileSize;
                int y = GLB_Data_Other.TilesTexture.Height / GLB_Data_Other.MapSize.TileSize;

                int index = 1;
                GLB_Data_Other.TilePalette = new Tile[x, y];

                for (int j = 0; j < y; j++)
                {
                    for (int i = 0; i < x; i++)
                    {
                        t = new Tile();

                        t.grid_location.X = i;
                        t.grid_location.Y = j;

                        t.id = index;
                        index++;

                        t.terrain_type = 0;
                        t.texture_location.X = 0;
                        t.texture_location.Y = 0;
                        t.walkable = true;

                        GLB_Data_Other.TilePalette[i, j] = t;
                    }
                }


                char[] splitChars = new char[4];
                splitChars[0] = ' ';
                splitChars[1] = '\n';
                splitChars[2] = '\r';
                splitChars[3] = '\t';

                GLB_Data_Other.TileMap = new Tile[4, GLB_Data_Other.MapSize.Width, GLB_Data_Other.MapSize.Height];


                //BaseLayer
                startIndex = outie.IndexOf("<BaseLayer>") + "<BaseLayer>".Length;
                length = outie.IndexOf("</BaseLayer>") - startIndex;


                split = outie.Substring(startIndex, length).Split(splitChars);

                x = 0;
                y = 0;

                foreach (string s in split)
                {
                    if (s != "")
                    {
                        t = new Tile();

                        t.grid_location.X = x;
                        t.grid_location.Y = y;

                        t.id = int.Parse(s);

                        t.terrain_type = 0;
                        t.texture_location.X = (t.id - 1) % (GLB_Data_Other.TilesTexture.Width / GLB_Data_Other.MapSize.TileSize);
                        t.texture_location.Y = (t.id - 1) / (GLB_Data_Other.TilesTexture.Width / GLB_Data_Other.MapSize.TileSize);
                        t.walkable = false;

                        GLB_Data_Other.TileMap[0, x, y] = t;

                        x++;

                        if (x > GLB_Data_Other.MapSize.Width - 1)
                        {
                            x = 0;
                            y++;
                        }
                    }

                }


                //Tile d = GLB_Data_Other.TileMap[0, 58, 79];
                //Tile f = GLB_Data_Other.TileMap[0, 59, 79];

                //FringeLayer
                startIndex = outie.IndexOf("<FringeLayer>") + "<FringeLayer>".Length;
                length = outie.IndexOf("</FringeLayer>") - startIndex;

                split = outie.Substring(startIndex, length).Split(splitChars);

                x = 0;
                y = 0;

                foreach (string s in split)
                {
                    if (s != "")
                    {
                        t = new Tile();

                        t.grid_location.X = x;
                        t.grid_location.Y = y;

                        t.id = int.Parse(s);

                        t.terrain_type = 0;
                        t.texture_location.X = (t.id - 1) % (GLB_Data_Other.TilesTexture.Width / GLB_Data_Other.MapSize.TileSize);
                        t.texture_location.Y = (t.id - 1) / (GLB_Data_Other.TilesTexture.Width / GLB_Data_Other.MapSize.TileSize);
                        t.walkable = false;

                        GLB_Data_Other.TileMap[1, x, y] = t;

                        x++;

                        if (x > GLB_Data_Other.MapSize.Width - 1)
                        {
                            x = 0;
                            y++;
                        }
                    }

                }



                //ObjectLayer
                startIndex = outie.IndexOf("<ObjectLayer>") + "<ObjectLayer>".Length;
                length = outie.IndexOf("</ObjectLayer>") - startIndex;

                split = outie.Substring(startIndex, length).Split(splitChars);

                x = 0;
                y = 0;

                foreach (string s in split)
                {
                    if (s != "")
                    {
                        t = new Tile();

                        t.grid_location.X = x;
                        t.grid_location.Y = y;

                        t.id = int.Parse(s);

                        t.terrain_type = 0;
                        t.texture_location.X = (t.id - 1) % (GLB_Data_Other.TilesTexture.Width / GLB_Data_Other.MapSize.TileSize);
                        t.texture_location.Y = (t.id - 1) / (GLB_Data_Other.TilesTexture.Width / GLB_Data_Other.MapSize.TileSize);
                        t.walkable = false;

                        GLB_Data_Other.TileMap[2, x, y] = t;

                        x++;

                        if (x > GLB_Data_Other.MapSize.Width - 1)
                        {
                            x = 0;
                            y++;
                        }
                    }

                }



                //CollisionLayer
                startIndex = outie.IndexOf("<CollisionLayer>") + "<CollisionLayer>".Length;
                length = outie.IndexOf("</CollisionLayer>") - startIndex;

                split = outie.Substring(startIndex, length).Split(splitChars);

                x = 0;
                y = 0;

                foreach (string s in split)
                {
                    if (s != "")
                    {
                        t = new Tile();

                        t.grid_location.X = x;
                        t.grid_location.Y = y;

                        t.id = -1;

                        t.terrain_type = 0;
                        t.texture_location.X = 0;
                        t.texture_location.Y = 0;

                        bool walk = false;

                        if (int.Parse(s) == 0)
                            walk = true;

                        if (int.Parse(s) == 2)
                            t.terrain_type = 2;

                        t.walkable = walk;

                        GLB_Data_Other.TileMap[3, x, y] = t;

                        x++;

                        if (x > GLB_Data_Other.MapSize.Width - 1)
                        {
                            x = 0;
                            y++;
                        }
                    }

                }


                GLB_Data_Other.portals = xmap.portals;
                if (GLB_Data_Other.portals == null)
                    GLB_Data_Other.portals = new List<Portal>();

                GLB_Data_Other.portalIndex = xmap.portalIndex;

                GLB_Data_Other.destinations = xmap.destinations;
                if (GLB_Data_Other.destinations == null)
                    GLB_Data_Other.destinations = new List<PortalDestination>();

                GLB_Data_Other.chests = xmap.chests;
                if (GLB_Data_Other.chests == null)
                    GLB_Data_Other.chests = new List<Chest>();

                GLB_Data_Other.npcs = xmap.npcs;
                if (GLB_Data_Other.npcs == null)
                    GLB_Data_Other.npcs = new List<NPC>();

                GLB_Data_Other.fixedCombatNPCs = xmap.fixedCombatNPCs;
                if (GLB_Data_Other.fixedCombatNPCs == null)
                    GLB_Data_Other.fixedCombatNPCs = new List<FixedCombatNPC>();

                GLB_Data_Other.blocks = xmap.blocks;
                if (GLB_Data_Other.blocks == null)
                    GLB_Data_Other.blocks = new List<Block>();

                GLB_Data_Other.switches = xmap.switches;
                if (GLB_Data_Other.switches == null)
                    GLB_Data_Other.switches = new List<Switch>();


                xmap.tile_map = GLB_Data_Other.TileMap;
                xmap.tile_palette = GLB_Data_Other.TilePalette;



                return true;
            }

            return false;

        }
    }
}
