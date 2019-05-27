#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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


#endregion

namespace XNA_Map_Editor
{
    partial class MainForm
    {
        static Direction AlphaDirection = Direction.Up;
        

        Texture2D chestTex;
        Texture2D NPCTex;
        Texture2D monsterTex;
        Texture2D blockTex;
        Texture2D switchTex;

        ///////////////////////////////////////////////////////////////////////////
        // INITIALIZE METHOD
        // 
        ///////////////////////////////////////////////////////////////////////////
        void XnaInitialize(object sender, EventArgs e)
        {
            this.sprite_batch   = new SpriteBatch(GraphicsDevice);
            grid_texture        = Texture2D.FromStream(GraphicsDevice, pixel_texture_stream);
            tile_texture        = Texture2D.FromStream(GraphicsDevice, tile_texture_stream);

            chestTex = Texture2D.FromStream(GraphicsDevice, chest_texture_stream);
            NPCTex = Texture2D.FromStream(GraphicsDevice, NPC_texture_stream);
            monsterTex = Texture2D.FromStream(GraphicsDevice, monster_texture_stream);
            blockTex = Texture2D.FromStream(GraphicsDevice, block_texture_stream);
            switchTex = Texture2D.FromStream(GraphicsDevice, switch_texture_stream);

            InitScrollBars();
        }

        ///////////////////////////////////////////////////////////////////////////
        // UPDATE METHOD
        // 
        ///////////////////////////////////////////////////////////////////////////
        void XnaUpdate()
        {
            // Camera Position is updated in relation with the scrollbars values
            // soon to be deprecated.
            // Camera.SetPosition(this.hscroll_xna.Value, this.vscroll_xna.Value, this.xna_renderer.Width, this.xna_renderer.Height);
            
            UpdateWalkGridAlpha();

            // Check if texture is valid
            if (GLB_Data.TextureFileName == "" || GLB_Data.TextureFileName == null)
            {
                generateTextureToolStripMenuItem.Enabled        = false;
                applyCollisionTemplateToolStripMenuItem.Enabled = false;
                blockToolStripMenuItem.Enabled                  = false;
                unblockToolStripMenuItem.Enabled                = false;
            }
            else
            {
                generateTextureToolStripMenuItem.Enabled        = true;
                applyCollisionTemplateToolStripMenuItem.Enabled = true;
                blockToolStripMenuItem.Enabled                  = true;
                unblockToolStripMenuItem.Enabled                = true;

            }

            // Disable terrain tools is no terrain data has been specified
            if (GLB_Data.TerrainList.Count <= 0)
            {
                toolbar_terrain_brush.Enabled = false;
                toolbar_terrain_combo.Enabled = false;
            }
            else
            {
                toolbar_terrain_brush.Enabled = true;
                toolbar_terrain_combo.Enabled = true;
            }

            if ((Control.ModifierKeys & System.Windows.Forms.Keys.Alt) != 0)
                Camera.SetZoom(0.2f);

        }

        private void UpdateWalkGridAlpha()
        {
            switch (AlphaDirection)
            {
                case Direction.Up:
                    AlphaValue += Convert.ToByte(Constants.ALPHA_INCREMENT);
                    if (AlphaValue > Constants.ALPHA_MAX)
                    {
                        AlphaDirection = Direction.Down;
                    }
                    break;

                case Direction.Down:
                    AlphaValue -= Convert.ToByte(Constants.ALPHA_INCREMENT);
                    if (AlphaValue < Constants.ALPHA_MIN)
                    {
                        AlphaDirection = Direction.Up;
                    }
                    break;

                default:
                    // should never get here
                    break;
            }

        }

        ///////////////////////////////////////////////////////////////////////////
        // DRAW METHOD
        // 
        ///////////////////////////////////////////////////////////////////////////
        void XnaRender(object sender, EventArgs e)
        {
            XnaUpdate();

            if (managePortalsForm != null)
            {
                if (managePortalsForm.xnaRenderer1 != null)
                {
                    managePortalsForm.XnaRender(sender, e);
                    managePortalsForm.Show();
                }
            }

            GraphicsDevice.Clear(XNA.Color.CornflowerBlue);

            //BEGIN
            sprite_batch.Begin();

            if (GLB_Data.TilesTexture == null)
            {
                // Draw Grid
                DrawGrid();

                // TileTexture not loaded yet
                // END
                sprite_batch.End();
                return;
            }
            
            // Draw Map
            DrawMap();

            // Draw Walk Layer
            if (GLB_Data.Brush == PaintTool.MarqueeWalk)
                DrawWalkLayer();

            // Draw Portals
            DrawPortals();

            // Draw Golden Tile
            DrawGoldenTile();

            // Draw Terrain Types Colors
            DrawTerrainTypes();

            // Draw Grid
            DrawGrid();

            DrawChests();
            DrawNPCs();
            DrawMonsters();
            DrawBlocks();
            DrawSwitches();

            if (MouseOnMe && ValidTileSelected() && GLB_Data.Brush == PaintTool.Brush)
            {
                DrawSelectedTileAsCursor();
            }

            if ((GLB_Data.Brush == PaintTool.MarqueeBrush || GLB_Data.Brush == PaintTool.MarqueeEraser || 
                 GLB_Data.Brush == PaintTool.MarqueeWalk   || GLB_Data.Brush == PaintTool.MarqueeTerrain) && (GLB_Data.MarqueeSelection.Show))
            {
                DrawMarqueeSelection();
            }

            if ( GLB_Data.Brush == PaintTool.MarqueeSelect && GLB_Data.MarqueeSelection.Show)
            {
                DrawMarqueeTileSelect();

                if (movingSelectedTiles)
                    DrawMarqueeSelectedTilesAsCursor();
            }

            // END
            sprite_batch.End();
        }


        ///////////////////////////////////////////////////////////////////////////
        // DrawTerrainTypes()
        // Creates a rectangle which holds the area that the mouse is currently dragging
        ///////////////////////////////////////////////////////////////////////////
        private void DrawTerrainTypes()
        {
            if (!ShowTerrainTypes)
            {
                return;
            }

            for (int id_y = 0; id_y < GLB_Data.MapSize.Height; id_y++)
            {
                for (int id_x = 0; id_x < GLB_Data.MapSize.Width; id_x++)
                {
                    if (MapFrustrumCull(id_x, id_y))
                    {
                        continue;
                    }

                    if (GLB_Data.TerrainLayout[id_x, id_y] == Constants.TERRAIN_NORMAL)
                    {
                        continue;
                    }

                    foreach (TerrainType t in GLB_Data.TerrainList)
                    {
                        if (t.Id == GLB_Data.TerrainLayout[id_x, id_y])
                        {
                            sprite_batch.Draw(grid_texture, Camera.Transform(new XNA.Rectangle(id_x * Camera.ScaledTileSize, id_y * Camera.ScaledTileSize, Camera.ScaledTileSize, Camera.ScaledTileSize)), new XNA.Color(t.Color.R, t.Color.G, t.Color.B, 150));
                        }
                    }
                }
            }
        } // DrawTerrainTypes


        ///////////////////////////////////////////////////////////////////////////
        // DrawWalkLayer
        // 
        ///////////////////////////////////////////////////////////////////////////
        private void DrawWalkLayer()
        {
            if (ShowWalkLayer)
            {

                for (int i = 0; i < GLB_Data.marqueeHist.Count; i++)
                {
                    XNA.Color c = new XNA.Color(255, 0, 0, AlphaValue);

                    if (GLB_Data.marqueeHistType[i] == 2)
                        c = new XNA.Color(0, 255, 0, AlphaValue);

                    if (GLB_Data.marqueeHistType[i] == 5)
                        c = new XNA.Color(0, 0, 255, AlphaValue);

                    if (GLB_Data.marqueeHistType[i] == 6)
                        c = new XNA.Color(255, 255, 0, AlphaValue);

                    sprite_batch.Draw(grid_texture, Camera.Transform(
                        new XNA.Rectangle(
                            GLB_Data.marqueeHist[i].X * Camera.ScaledTileSize
                            , GLB_Data.marqueeHist[i].Y * Camera.ScaledTileSize
                            , GLB_Data.marqueeHist[i].Width * Camera.ScaledTileSize
                            , GLB_Data.marqueeHist[i].Height * Camera.ScaledTileSize))
                            , c);
                }




                /*
                int walk_layer = GetWalkLayer();

                for (int id_y = 0; id_y < GLB_Data.MapSize.Height; id_y++)
                {
                    for (int id_x = 0; id_x < GLB_Data.MapSize.Width; id_x++)
                    {
                        if (MapFrustrumCull(id_x, id_y))
                        {
                            continue;
                        }

                        if(GLB_Data.TileMap[walk_layer, id_x, id_y].terrain_type == 2)
                            sprite_batch.Draw(grid_texture, Camera.Transform(new XNA.Rectangle(id_x * Camera.ScaledTileSize, id_y * Camera.ScaledTileSize, Camera.ScaledTileSize, Camera.ScaledTileSize)), new XNA.Color(0, 255, 0, AlphaValue));
                        else if (!GLB_Data.TileMap[walk_layer, id_x, id_y].walkable)
                        {
                            // ORIGINAL RENDER CALL
                            sprite_batch.Draw(grid_texture, Camera.Transform(new XNA.Rectangle(id_x * Camera.ScaledTileSize, id_y * Camera.ScaledTileSize, Camera.ScaledTileSize, Camera.ScaledTileSize)), new XNA.Color(255, 0, 0, AlphaValue));
                        }
                    }
                }
                */
            }
        }


        private void DrawPortals()
        {
            if (GLB_Data.portals != null)
            {
                foreach (Portal portal in GLB_Data.portals)
                {
                    sprite_batch.Draw(grid_texture, Camera.Transform(new XNA.Rectangle(portal.x * Camera.ScaledTileSize, portal.y * Camera.ScaledTileSize, Camera.ScaledTileSize, Camera.ScaledTileSize)), new XNA.Color(0, 0, 255, AlphaValue));
                }
            }
        }


        private void DrawChests()
        {
            if (GLB_Data.chests != null)
            {
                foreach (Chest chest in GLB_Data.chests)
                {
                    sprite_batch.Draw(chestTex, Camera.Transform(new XNA.Rectangle(chest.x * Camera.ScaledTileSize, chest.y * Camera.ScaledTileSize, Camera.ScaledTileSize, Camera.ScaledTileSize)), new XNA.Color(255, 255, 255, 255));
                }
            }
        }

        private void DrawNPCs()
        {
            if (GLB_Data.npcs != null)
            {
                foreach (NPC NPC in GLB_Data.npcs)
                {
                    sprite_batch.Draw(NPCTex, Camera.Transform(new XNA.Rectangle(NPC.x * Camera.ScaledTileSize, NPC.y * Camera.ScaledTileSize, Camera.ScaledTileSize, Camera.ScaledTileSize)), new XNA.Color(255, 255, 255, 255));
                }
            }
        }

        private void DrawMonsters()
        {
            if (GLB_Data.fixedCombatNPCs != null)
            {
                foreach (FixedCombatNPC monster in GLB_Data.fixedCombatNPCs)
                {
                    sprite_batch.Draw(monsterTex, Camera.Transform(new XNA.Rectangle(monster.x * Camera.ScaledTileSize, monster.y * Camera.ScaledTileSize, Camera.ScaledTileSize, Camera.ScaledTileSize)), new XNA.Color(255, 255, 255, 255));
                }
            }
        }

        private void DrawBlocks()
        {
            if (GLB_Data.blocks != null)
            {
                foreach (Block block in GLB_Data.blocks)
                {
                    sprite_batch.Draw(blockTex, Camera.Transform(new XNA.Rectangle(block.x * Camera.ScaledTileSize, block.y * Camera.ScaledTileSize, Camera.ScaledTileSize, Camera.ScaledTileSize)), new XNA.Color(255, 255, 255, 255));
                }
            }
        }

        private void DrawSwitches()
        {
            if (GLB_Data.switches != null)
            {
                foreach (Switch Switch in GLB_Data.switches)
                {
                    sprite_batch.Draw(switchTex, Camera.Transform(new XNA.Rectangle(Switch.x * Camera.ScaledTileSize, Switch.y * Camera.ScaledTileSize, Camera.ScaledTileSize, Camera.ScaledTileSize)), new XNA.Color(255, 255, 255, 255));
                }
            }
        }

        private void DrawGoldenTile()
        {

            if(managePortalsForm != null)
                sprite_batch.Draw(grid_texture, Camera.Transform(new XNA.Rectangle(goldenTile.grid_location.X * Camera.ScaledTileSize, goldenTile.grid_location.Y * Camera.ScaledTileSize, Camera.ScaledTileSize, Camera.ScaledTileSize)), new XNA.Color(250, 250, 210, AlphaValue));
        }

        ///////////////////////////////////////////////////////////////////////////
        // DrawGrid
        // 
        ///////////////////////////////////////////////////////////////////////////
        private void DrawGrid()
        {
            if (ShowGrid)
            {
                for (int id_x = 0; id_x <= GLB_Data.MapSize.Height * Camera.ScaledTileSize; id_x += Camera.ScaledTileSize)
                {
                    DrawLine(Camera.Transform(new Vector2(0, id_x)), Camera.Transform(new Vector2(GLB_Data.MapSize.Width * Camera.ScaledTileSize, id_x)), XNA.Color.White);
                }

                for (int id_y = 0; id_y <= GLB_Data.MapSize.Width * Camera.ScaledTileSize; id_y += Camera.ScaledTileSize)
                {

                    DrawLine(Camera.Transform(new Vector2(id_y, 0)), Camera.Transform(new Vector2(id_y, GLB_Data.MapSize.Height * Camera.ScaledTileSize)), XNA.Color.White);
                }
            }
            else
            {
                // if ShowGrid is set to false, render just the map boundaries
                XNA.Rectangle map_bounds = Camera.Transform(new XNA.Rectangle(0, 
                                                                              0,
                                                                              GLB_Data.MapSize.Width  * Camera.ScaledTileSize,
                                                                              GLB_Data.MapSize.Height * Camera.ScaledTileSize));
                DrawRectangle(map_bounds, XNA.Color.Black);
            }
        }

        ///////////////////////////////////////////////////////////////////////////
        // DrawSelectedTileAsCursor
        // 
        ///////////////////////////////////////////////////////////////////////////
        private void DrawSelectedTileAsCursor()
        {
            System.Drawing.Point current_mouse = this.xna_renderer.PointToClient(Control.MousePosition);

            current_mouse = Camera.WorldPosition(current_mouse);

            System.Drawing.Rectangle aux_rect = HelperClass.SnapToGrid(new System.Drawing.Point(current_mouse.X, current_mouse.Y));

            if (aux_rect.Width == 0)
            {
                // out of bounds no rendering
                return;
            }

            aux_rect = Camera.TransformToGrid(aux_rect);


            XNA.Rectangle dest_rect = new XNA.Rectangle(aux_rect.X,
                                                        aux_rect.Y,
                                                        GLB_Data.SelectedTiles.GetLength(0) * Camera.ScaledTileSize,
                                                        GLB_Data.SelectedTiles.GetLength(1) * Camera.ScaledTileSize);

            XNA.Rectangle src_rect = new XNA.Rectangle(GLB_Data.SelectedTiles[0, 0].grid_location.X * GLB_Data.MapSize.TileSize,
                                                       GLB_Data.SelectedTiles[0, 0].grid_location.Y * GLB_Data.MapSize.TileSize,
                                                       GLB_Data.SelectedTiles.GetLength(0) * GLB_Data.MapSize.TileSize,
                                                       GLB_Data.SelectedTiles.GetLength(1) * GLB_Data.MapSize.TileSize);

            // white semi-transparent
            sprite_batch.Draw(GLB_Data.TilesTexture, dest_rect, src_rect, new XNA.Color(255, 255, 255, 200));


            // Store last cell mouse was positioned
            HelperClass.SetLastSelectedPoint(current_mouse);

        }

        private void DrawMarqueeSelectedTilesAsCursor()
        {
            System.Drawing.Point current_mouse = this.xna_renderer.PointToClient(Control.MousePosition);

            current_mouse = Camera.WorldPosition(current_mouse);

            System.Drawing.Rectangle aux_rect = HelperClass.SnapToGrid(new System.Drawing.Point(current_mouse.X, current_mouse.Y));

            if (aux_rect.Width == 0)
            {
                // out of bounds no rendering
                return;
            }

            aux_rect = Camera.TransformToGrid(aux_rect);

            for (int id_y = 0; id_y < GLB_Data.MarqueeSelection.Height; id_y++)
            {
                for (int id_x = 0; id_x < GLB_Data.MarqueeSelection.Width; id_x++)
                {
                    int sel_tiles_x = id_x % (GLB_Data.TileMap.GetLength(1));
                    int sel_tiles_y = id_y % (GLB_Data.TileMap.GetLength(2));

                    int offsetInitial_x = GLB_Data.MarqueeSelection.InitialTile.X + id_x;
                    int offsetInitial_y = GLB_Data.MarqueeSelection.InitialTile.Y + id_y;
                    

                    XNA.Rectangle dest_rect = new XNA.Rectangle(aux_rect.X + id_x * Camera.ScaledTileSize,
                                                                aux_rect.Y + id_y * Camera.ScaledTileSize,
                                                                Camera.ScaledTileSize,
                                                                Camera.ScaledTileSize);

                    if (HideLayers)
                    {
                        XNA.Rectangle src_rect = new XNA.Rectangle(GLB_Data.TileMap[GLB_Data.SelectedLayer, offsetInitial_x, offsetInitial_y].texture_location.X * GLB_Data.MapSize.TileSize,
                                                               GLB_Data.TileMap[GLB_Data.SelectedLayer, offsetInitial_x, offsetInitial_y].texture_location.Y * GLB_Data.MapSize.TileSize,
                                                               GLB_Data.MapSize.TileSize,
                                                               GLB_Data.MapSize.TileSize);

                        // white semi-transparent
                        sprite_batch.Draw(GLB_Data.TilesTexture, dest_rect, src_rect, new XNA.Color(255, 255, 255, 200));
                    }
                    else
                    {
                        for (int d = 0; d < GLB_Data.TileMap.GetLength(0); d++)
                        {
                            XNA.Rectangle src_rect = new XNA.Rectangle(GLB_Data.TileMap[d, offsetInitial_x, offsetInitial_y].texture_location.X * GLB_Data.MapSize.TileSize,
                                                               GLB_Data.TileMap[d, offsetInitial_x, offsetInitial_y].texture_location.Y * GLB_Data.MapSize.TileSize,
                                                               GLB_Data.MapSize.TileSize,
                                                               GLB_Data.MapSize.TileSize);

                            // white semi-transparent
                            sprite_batch.Draw(GLB_Data.TilesTexture, dest_rect, src_rect, new XNA.Color(255, 255, 255, 200));
                        }
                    }



                }
            }

            // Store last cell mouse was positioned
            HelperClass.SetLastSelectedPoint(current_mouse);

        }

        ///////////////////////////////////////////////////////////////////////////
        // DrawMap()
        // 
        ///////////////////////////////////////////////////////////////////////////
        private void DrawMap()
        {
            for (int id_z = 0; id_z < GLB_Data.MapSize.Depth; id_z++)
            {
                for (int id_y = 0; id_y < GLB_Data.MapSize.Height; id_y++)
                {
                    for (int id_x = 0; id_x < GLB_Data.MapSize.Width; id_x++)
                    {
                        if (GLB_Data.TileMap[id_z, id_x, id_y].id == Constants.NULL_TILE)
                        {
                            // Dont draw this tile
                            continue;
                        }



                        XNA.Rectangle source_rectangle = new XNA.Rectangle(GLB_Data.TileMap[id_z, id_x, id_y].texture_location.X * GLB_Data.MapSize.TileSize,
                                                                           GLB_Data.TileMap[id_z, id_x, id_y].texture_location.Y * GLB_Data.MapSize.TileSize,
                                                                           GLB_Data.MapSize.TileSize, GLB_Data.MapSize.TileSize);

                        XNA.Rectangle dest_rectangle = Camera.Transform(new XNA.Rectangle(id_x * Camera.ScaledTileSize, id_y * Camera.ScaledTileSize, Camera.ScaledTileSize, Camera.ScaledTileSize));

                        if (MapFrustrumCull(id_x, id_y))
                        {
                            continue;
                        }

                        if (HideLayers)
                        {
                            if (id_z == GLB_Data.SelectedLayer)
                            {
                                // Render Normally
                                sprite_batch.Draw(GLB_Data.TilesTexture, dest_rectangle, source_rectangle, XNA.Color.White);
                            }
                            else
                            {
                                // apply semi-transparency
                                sprite_batch.Draw(GLB_Data.TilesTexture, dest_rectangle, source_rectangle, new XNA.Color(255, 255, 255, 22));
                            }
                        }
                        else
                        {
                            // Render Normally
                            sprite_batch.Draw(GLB_Data.TilesTexture, dest_rectangle, source_rectangle, XNA.Color.White);
                        }

                    }
                }
            }
        }// Draw Map

        //////////////////////////////////////////////////////////
        // Camera Frustrum Culling
        // I dont know I this function does improve performance
        // maybe I'll uncomment it on a later time
        //////////////////////////////////////////////////////////
        private Boolean MapFrustrumCull(int id_x, int id_y)
        {
            if (!new XNA.Rectangle((int)Camera.X * -1 - Camera.ScaledTileSize, (int)Camera.Y * -1 - Camera.ScaledTileSize, xna_renderer.Width + Camera.ScaledTileSize, xna_renderer.Height + Camera.ScaledTileSize).Contains(new XNA.Point(id_x * Camera.ScaledTileSize, id_y * Camera.ScaledTileSize)))
            {
                return true;
            }

            return false;
        }

        ///////////////////////////////////////////////////////////////////////////
        // DrawMarqueeSelection()
        // draws marquee selection rectangle and possible tile texture array
        ///////////////////////////////////////////////////////////////////////////
        private void DrawMarqueeSelection()
        {
            // Note: Marquee Points are given in world coordinates            
            System.Drawing.Rectangle aux_inital_rectangle    = HelperClass.SnapToGrid(GLB_Data.MarqueeSelection.InitialLocation);
            System.Drawing.Rectangle aux_final_rectangle     = HelperClass.SnapToGrid(GLB_Data.MarqueeSelection.FinalLocation);

            XNA.Rectangle draw_rect  = Camera.Transform(CreateMarqueeArea(aux_inital_rectangle, aux_final_rectangle));
            XNA.Rectangle world_rect = CreateMarqueeArea(aux_inital_rectangle, aux_final_rectangle);

            DrawRectangle(draw_rect, XNA.Color.Fuchsia);

            // Draw tiled selection
            // Units are in tile #'s 

            int selected_tiles_width = GLB_Data.SelectedTiles.GetLength(0);
            int selected_tiles_height = GLB_Data.SelectedTiles.GetLength(1);

            int marquee_width = draw_rect.Width / Camera.ScaledTileSize;
            int marquee_height = draw_rect.Height / Camera.ScaledTileSize;

            #region MarqueeBrush
            if (GLB_Data.Brush == PaintTool.MarqueeBrush)
            {
                for (int id_y = 0; id_y < draw_rect.Height / Camera.ScaledTileSize; id_y++)
                {
                    for (int id_x = 0; id_x < draw_rect.Width / Camera.ScaledTileSize; id_x++)
                    {
                        XNA.Rectangle dest_rect = new XNA.Rectangle(draw_rect.X + (id_x * Camera.ScaledTileSize),
                                                                    draw_rect.Y + (id_y * Camera.ScaledTileSize),
                                                                    Camera.ScaledTileSize, Camera.ScaledTileSize);

                        XNA.Rectangle src_rect = new XNA.Rectangle(GLB_Data.SelectedTiles[id_x % selected_tiles_width, id_y % selected_tiles_height].grid_location.X * GLB_Data.MapSize.TileSize,
                                                                   GLB_Data.SelectedTiles[id_x % selected_tiles_width, id_y % selected_tiles_height].grid_location.Y * GLB_Data.MapSize.TileSize,
                                                                   GLB_Data.MapSize.TileSize,
                                                                   GLB_Data.MapSize.TileSize);

                        sprite_batch.Draw(GLB_Data.TilesTexture, dest_rect, src_rect, XNA.Color.White);
                    }
                }
            }
            #endregion

            #region TerrainBrush
            if (GLB_Data.Brush == PaintTool.MarqueeTerrain)
            {
                TerrainType sel_t = (TerrainType)toolbar_terrain_combo.SelectedItem;

                sprite_batch.Draw(grid_texture, world_rect, new XNA.Color(sel_t.Color.R, sel_t.Color.G, sel_t.Color.B, 100));
            }
            #endregion

            #region EraserBrush
            if (GLB_Data.Brush == PaintTool.MarqueeEraser)
            {
                sprite_batch.Draw(grid_texture, world_rect, new XNA.Color(255, 255, 255, 50));
            }
            #endregion

            #region WalkBrush
            if (GLB_Data.Brush == PaintTool.MarqueeWalk)
            {
                sprite_batch.Draw(grid_texture, world_rect, new XNA.Color(255, 0, 0, AlphaValue));
            }
            #endregion

            // set values to glb_data
            GLB_Data.MarqueeSelection.Width = world_rect.Width / Camera.ScaledTileSize;
            GLB_Data.MarqueeSelection.Height = world_rect.Height / Camera.ScaledTileSize;
            GLB_Data.MarqueeSelection.InitialTile.X = world_rect.X / Camera.ScaledTileSize;
            GLB_Data.MarqueeSelection.InitialTile.Y = world_rect.Y / Camera.ScaledTileSize;
        }

        private void DrawMarqueeTileSelect()
        {
            // Note: Marquee Points are given in world coordinates            
            System.Drawing.Rectangle aux_inital_rectangle = HelperClass.SnapToGrid(GLB_Data.MarqueeSelection.InitialLocation);
            System.Drawing.Rectangle aux_final_rectangle = HelperClass.SnapToGrid(GLB_Data.MarqueeSelection.FinalLocation);

            XNA.Rectangle draw_rect = Camera.Transform(CreateMarqueeArea(aux_inital_rectangle, aux_final_rectangle));
            XNA.Rectangle world_rect = CreateMarqueeArea(aux_inital_rectangle, aux_final_rectangle);

            DrawRectangle(draw_rect, XNA.Color.Fuchsia);

            // Draw tiled selection
            // Units are in tile #'s 

            int selected_tiles_width = GLB_Data.SelectedTiles.GetLength(0);
            int selected_tiles_height = GLB_Data.SelectedTiles.GetLength(1);

            int marquee_width = draw_rect.Width / Camera.ScaledTileSize;
            int marquee_height = draw_rect.Height / Camera.ScaledTileSize;
            

            // set values to glb_data
            GLB_Data.MarqueeSelection.Width = world_rect.Width / Camera.ScaledTileSize;
            GLB_Data.MarqueeSelection.Height = world_rect.Height / Camera.ScaledTileSize;
            GLB_Data.MarqueeSelection.InitialTile.X = world_rect.X / Camera.ScaledTileSize;
            GLB_Data.MarqueeSelection.InitialTile.Y = world_rect.Y / Camera.ScaledTileSize;

            System.Drawing.Point current_mouse = this.xna_renderer.PointToClient(Control.MousePosition);

            if (TilesSelected)
            {
                if (current_mouse.X >= draw_rect.X && current_mouse.X <= (draw_rect.X + draw_rect.Width) &&
                   current_mouse.Y >= draw_rect.Y && current_mouse.Y <= (draw_rect.Y + draw_rect.Height))
                {
                    mouseHoveringOverSelection = true;
                    this.Cursor = Cursors.SizeAll;
                }

                if(movingSelectedTiles)
                    this.Cursor = Cursors.SizeAll;
            }

            //Console.WriteLine(mouseHoveringOverSelection + "  x: " + current_mouse.X + "  y: " + current_mouse.Y + " boxW: " + draw_rect.X + "-" + (draw_rect.X + draw_rect.Width) + " boxH: " + draw_rect.Y + "-" + (draw_rect.Y + draw_rect.Height));
        }

        ///////////////////////////////////////////////////////////////////////////
        // CreateMarqueeArea()
        // Creates a rectangle which holds the area that the mouse is currently dragging
        ///////////////////////////////////////////////////////////////////////////
        private XNA.Rectangle CreateMarqueeArea(System.Drawing.Rectangle RectangleA, System.Drawing.Rectangle RectangleB)
        {
            Int32 min_size          = Camera.ScaledTileSize;
            Size rect_size          = new Size();
            XNA.Point top_point     = new XNA.Point();
            XNA.Point bottom_point  = new XNA.Point();

            if (RectangleA.Left < RectangleB.Left)
            {
                top_point.X = RectangleA.Left;
                bottom_point.X = RectangleB.Right;
            }
            else
            {
                top_point.X = RectangleB.Left;
                bottom_point.X = RectangleA.Right;
            }

            if (RectangleA.Top < RectangleB.Top)
            {
                top_point.Y = RectangleA.Top;
                bottom_point.Y = RectangleB.Bottom;
            }
            else
            {
                top_point.Y = RectangleB.Top;
                bottom_point.Y = RectangleA.Bottom;
            }

            if (top_point.X <= bottom_point.X)
            {
                rect_size.Width = bottom_point.X - top_point.X;
            }
            else
            {
                rect_size.Width = top_point.X - bottom_point.X;
            }

            if (top_point.Y <= bottom_point.Y)
            {
                rect_size.Height = bottom_point.Y - top_point.Y;
            }
            else
            {
                rect_size.Height = top_point.Y - bottom_point.Y;
            }

            if (rect_size.Width == 0)
            {
                rect_size.Width = Camera.ScaledTileSize;
            }

            if (rect_size.Height == 0)
            {
                rect_size.Height = Camera.ScaledTileSize;
            }

            return new XNA.Rectangle(top_point.X, top_point.Y, rect_size.Width, rect_size.Height);

        }//CreateMarqueeArea()


    }
}
