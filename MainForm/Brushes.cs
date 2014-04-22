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
using System.IO;


#endregion

namespace XNA_Map_Editor
{
    partial class MainForm
    {
        #region Paint Tools

        private void SetBrush(PaintTool BrushType)
        {
            switch (BrushType)
            {
                case PaintTool.Brush:
                    toolbar_brush.CheckState = CheckState.Checked;
                    toolbar_eraser.CheckState = CheckState.Unchecked;
                    toolbar_walkability.CheckState = CheckState.Unchecked;
                    toolbar_bucket.CheckState = CheckState.Unchecked;
                    toolbar_marquee.CheckState = CheckState.Unchecked;
                    toolbar_marquee_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_terrain_brush.CheckState = CheckState.Unchecked;
                    toolbar_portal.CheckState = CheckState.Unchecked;
                    toolbar_chest.CheckState = CheckState.Unchecked;
                    toolbar_NPC.CheckState = CheckState.Unchecked;
                    toolbar_fixedCombat.CheckState = CheckState.Unchecked;
                    toolbar_block.CheckState = CheckState.Unchecked;
                    toolbar_switch.CheckState = CheckState.Unchecked;
                    ShowTerrainTypes = false;
                    break;

                case PaintTool.Eraser:
                    toolbar_eraser.CheckState = CheckState.Checked;
                    toolbar_brush.CheckState = CheckState.Unchecked;
                    toolbar_walkability.CheckState = CheckState.Unchecked;
                    toolbar_bucket.CheckState = CheckState.Unchecked;
                    toolbar_marquee.CheckState = CheckState.Unchecked;
                    toolbar_marquee_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_terrain_brush.CheckState = CheckState.Unchecked;
                    toolbar_portal.CheckState = CheckState.Unchecked;
                    toolbar_chest.CheckState = CheckState.Unchecked;
                    toolbar_NPC.CheckState = CheckState.Unchecked;
                    toolbar_fixedCombat.CheckState = CheckState.Unchecked;
                    toolbar_block.CheckState = CheckState.Unchecked;
                    toolbar_switch.CheckState = CheckState.Unchecked;
                    ShowTerrainTypes = false;
                    break;

                case PaintTool.Walk:
                    toolbar_walkability.CheckState = CheckState.Checked;
                    toolbar_brush.CheckState = CheckState.Unchecked;
                    toolbar_eraser.CheckState = CheckState.Unchecked;
                    toolbar_bucket.CheckState = CheckState.Unchecked;
                    toolbar_marquee.CheckState = CheckState.Unchecked;
                    toolbar_marquee_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_terrain_brush.CheckState = CheckState.Unchecked;
                    toolbar_portal.CheckState = CheckState.Unchecked;
                    toolbar_chest.CheckState = CheckState.Unchecked;
                    toolbar_NPC.CheckState = CheckState.Unchecked;
                    toolbar_fixedCombat.CheckState = CheckState.Unchecked;
                    toolbar_block.CheckState = CheckState.Unchecked;
                    toolbar_switch.CheckState = CheckState.Unchecked;
                    ShowTerrainTypes = false;
                    break;

                case PaintTool.Fill:
                    toolbar_bucket.CheckState = CheckState.Checked;
                    toolbar_walkability.CheckState = CheckState.Unchecked;
                    toolbar_brush.CheckState = CheckState.Unchecked;
                    toolbar_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee.CheckState = CheckState.Unchecked;
                    toolbar_marquee_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_terrain_brush.CheckState = CheckState.Unchecked;
                    toolbar_portal.CheckState = CheckState.Unchecked;
                    toolbar_chest.CheckState = CheckState.Unchecked;
                    toolbar_NPC.CheckState = CheckState.Unchecked;
                    toolbar_fixedCombat.CheckState = CheckState.Unchecked;
                    toolbar_block.CheckState = CheckState.Unchecked;
                    toolbar_switch.CheckState = CheckState.Unchecked;
                    ShowTerrainTypes = false;
                    break;

                case PaintTool.MarqueeBrush:
                    toolbar_marquee.CheckState = CheckState.Checked;
                    toolbar_bucket.CheckState = CheckState.Unchecked;
                    toolbar_walkability.CheckState = CheckState.Unchecked;
                    toolbar_brush.CheckState = CheckState.Unchecked;
                    toolbar_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_terrain_brush.CheckState = CheckState.Unchecked;
                    toolbar_portal.CheckState = CheckState.Unchecked;
                    toolbar_chest.CheckState = CheckState.Unchecked;
                    toolbar_NPC.CheckState = CheckState.Unchecked;
                    toolbar_fixedCombat.CheckState = CheckState.Unchecked;
                    toolbar_block.CheckState = CheckState.Unchecked;
                    toolbar_switch.CheckState = CheckState.Unchecked;
                    ShowTerrainTypes = false;
                    break;

                case PaintTool.MarqueeEraser:
                    toolbar_marquee_eraser.CheckState = CheckState.Checked;
                    toolbar_marquee.CheckState = CheckState.Unchecked;
                    toolbar_bucket.CheckState = CheckState.Unchecked;
                    toolbar_walkability.CheckState = CheckState.Unchecked;
                    toolbar_brush.CheckState = CheckState.Unchecked;
                    toolbar_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_terrain_brush.CheckState = CheckState.Unchecked;
                    toolbar_portal.CheckState = CheckState.Unchecked;
                    toolbar_chest.CheckState = CheckState.Unchecked;
                    toolbar_NPC.CheckState = CheckState.Unchecked;
                    toolbar_fixedCombat.CheckState = CheckState.Unchecked;
                    toolbar_block.CheckState = CheckState.Unchecked;
                    toolbar_switch.CheckState = CheckState.Unchecked;
                    ShowTerrainTypes = false;
                    break;

                case PaintTool.MarqueeWalk:
                    toolbar_marquee_walk.CheckState = CheckState.Checked;
                    toolbar_marquee_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee.CheckState = CheckState.Unchecked;
                    toolbar_bucket.CheckState = CheckState.Unchecked;
                    toolbar_walkability.CheckState = CheckState.Unchecked;
                    toolbar_brush.CheckState = CheckState.Unchecked;
                    toolbar_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_terrain_brush.CheckState = CheckState.Unchecked;
                    toolbar_portal.CheckState = CheckState.Unchecked;
                    toolbar_chest.CheckState = CheckState.Unchecked;
                    toolbar_NPC.CheckState = CheckState.Unchecked;
                    toolbar_fixedCombat.CheckState = CheckState.Unchecked;
                    toolbar_block.CheckState = CheckState.Unchecked;
                    toolbar_switch.CheckState = CheckState.Unchecked;
                    ShowTerrainTypes = false;
                    break;

                case PaintTool.MarqueeTerrain:
                    toolbar_terrain_brush.CheckState = CheckState.Checked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_marquee_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee.CheckState = CheckState.Unchecked;
                    toolbar_bucket.CheckState = CheckState.Unchecked;
                    toolbar_walkability.CheckState = CheckState.Unchecked;
                    toolbar_brush.CheckState = CheckState.Unchecked;
                    toolbar_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_portal.CheckState = CheckState.Unchecked;
                    toolbar_chest.CheckState = CheckState.Unchecked;
                    toolbar_NPC.CheckState = CheckState.Unchecked;
                    toolbar_fixedCombat.CheckState = CheckState.Unchecked;
                    toolbar_block.CheckState = CheckState.Unchecked;
                    toolbar_switch.CheckState = CheckState.Unchecked;
                    ShowTerrainTypes = true;
                    break;

                case PaintTool.Portal:
                    toolbar_portal.CheckState = CheckState.Checked;
                    toolbar_terrain_brush.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_marquee_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee.CheckState = CheckState.Unchecked;
                    toolbar_bucket.CheckState = CheckState.Unchecked;
                    toolbar_walkability.CheckState = CheckState.Unchecked;
                    toolbar_brush.CheckState = CheckState.Unchecked;
                    toolbar_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_chest.CheckState = CheckState.Unchecked;
                    toolbar_NPC.CheckState = CheckState.Unchecked;
                    toolbar_fixedCombat.CheckState = CheckState.Unchecked;
                    toolbar_block.CheckState = CheckState.Unchecked;
                    toolbar_switch.CheckState = CheckState.Unchecked;
                    ShowTerrainTypes = true;
                    break;

                case PaintTool.Chest:
                    toolbar_chest.CheckState = CheckState.Checked;
                    toolbar_portal.CheckState = CheckState.Unchecked;
                    toolbar_terrain_brush.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_marquee_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee.CheckState = CheckState.Unchecked;
                    toolbar_bucket.CheckState = CheckState.Unchecked;
                    toolbar_walkability.CheckState = CheckState.Unchecked;
                    toolbar_brush.CheckState = CheckState.Unchecked;
                    toolbar_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_NPC.CheckState = CheckState.Unchecked;
                    toolbar_fixedCombat.CheckState = CheckState.Unchecked;
                    toolbar_block.CheckState = CheckState.Unchecked;
                    toolbar_switch.CheckState = CheckState.Unchecked;
                    ShowTerrainTypes = true;
                    break;

                case PaintTool.NPC:
                    toolbar_NPC.CheckState = CheckState.Checked;
                    toolbar_portal.CheckState = CheckState.Unchecked;
                    toolbar_terrain_brush.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_marquee_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee.CheckState = CheckState.Unchecked;
                    toolbar_bucket.CheckState = CheckState.Unchecked;
                    toolbar_walkability.CheckState = CheckState.Unchecked;
                    toolbar_brush.CheckState = CheckState.Unchecked;
                    toolbar_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_chest.CheckState = CheckState.Unchecked;
                    toolbar_fixedCombat.CheckState = CheckState.Unchecked;
                    toolbar_block.CheckState = CheckState.Unchecked;
                    toolbar_switch.CheckState = CheckState.Unchecked;
                    ShowTerrainTypes = true;
                    break;

                case PaintTool.FixedCombat:
                    toolbar_fixedCombat.CheckState = CheckState.Checked;
                    toolbar_portal.CheckState = CheckState.Unchecked;
                    toolbar_terrain_brush.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_marquee_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee.CheckState = CheckState.Unchecked;
                    toolbar_bucket.CheckState = CheckState.Unchecked;
                    toolbar_walkability.CheckState = CheckState.Unchecked;
                    toolbar_brush.CheckState = CheckState.Unchecked;
                    toolbar_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_chest.CheckState = CheckState.Unchecked;
                    toolbar_NPC.CheckState = CheckState.Unchecked;
                    toolbar_block.CheckState = CheckState.Unchecked;
                    toolbar_switch.CheckState = CheckState.Unchecked;
                    ShowTerrainTypes = true;
                    break;


                case PaintTool.Block:
                    toolbar_block.CheckState = CheckState.Checked;
                    toolbar_fixedCombat.CheckState = CheckState.Unchecked;
                    toolbar_portal.CheckState = CheckState.Unchecked;
                    toolbar_terrain_brush.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_marquee_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee.CheckState = CheckState.Unchecked;
                    toolbar_bucket.CheckState = CheckState.Unchecked;
                    toolbar_walkability.CheckState = CheckState.Unchecked;
                    toolbar_brush.CheckState = CheckState.Unchecked;
                    toolbar_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_chest.CheckState = CheckState.Unchecked;
                    toolbar_NPC.CheckState = CheckState.Unchecked;
                    toolbar_switch.CheckState = CheckState.Unchecked;
                    ShowTerrainTypes = true;
                    break;


                case PaintTool.Switch:
                    toolbar_switch.CheckState = CheckState.Checked;
                    toolbar_fixedCombat.CheckState = CheckState.Unchecked;
                    toolbar_portal.CheckState = CheckState.Unchecked;
                    toolbar_terrain_brush.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_marquee_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee.CheckState = CheckState.Unchecked;
                    toolbar_bucket.CheckState = CheckState.Unchecked;
                    toolbar_walkability.CheckState = CheckState.Unchecked;
                    toolbar_brush.CheckState = CheckState.Unchecked;
                    toolbar_eraser.CheckState = CheckState.Unchecked;
                    toolbar_marquee_walk.CheckState = CheckState.Unchecked;
                    toolbar_chest.CheckState = CheckState.Unchecked;
                    toolbar_NPC.CheckState = CheckState.Unchecked;
                    toolbar_block.CheckState = CheckState.Unchecked;
                    ShowTerrainTypes = true;
                    break;


                default:
                    // should never get here
                    break;
            }

            // set the brush type in glb_data
            GLB_Data.Brush = BrushType;
        }

        private void DoBrushLogic(object sender, MouseEventArgs e)
        {
            switch (GLB_Data.Brush)
            {
                case PaintTool.Brush:
                    BrushPaint(sender, e);
                    break;

                case PaintTool.Eraser:
                    EraserPaint(sender, e);
                    break;

                case PaintTool.Walk:
                    WalkPaint(sender, e);
                    break;

                case PaintTool.Fill:
                    BucketPaint(sender, e);
                    break;

                case PaintTool.MarqueeBrush:
                    MarqueePaint(sender, e, GLB_Data.MarqueeSelection);
                    break;

                case PaintTool.MarqueeEraser:
                    MarqueeErase(sender, e, GLB_Data.MarqueeSelection);
                    break;

                case PaintTool.MarqueeWalk:
                    MarqueeWalk(sender, e, GLB_Data.MarqueeSelection);
                    break;

                case PaintTool.MarqueeTerrain:
                    MarqueeTerrain(sender, e, GLB_Data.MarqueeSelection);
                    break;

                case PaintTool.Portal:
                    PortalPaint(sender, e);
                    break;

                case PaintTool.Chest:
                    ChestPaint(sender, e);
                    break;

                case PaintTool.NPC:
                    NPCPaint(sender, e);
                    break;

                case PaintTool.FixedCombat:
                    FixedCombatPaint(sender, e);
                    break;

                case PaintTool.Block:
                    BlockPaint(sender, e);
                    break;

                case PaintTool.Switch:
                    SwitchPaint(sender, e);
                    break;

                default:
                    // default, should never get here
                    break;
            }
        }

        private void ChangeMouseCursor(PaintTool Brush)
        {
            Stream cursor_stream;

            switch (Brush)
            {
                case PaintTool.Eraser:
                    cursor_stream = (assembly.GetManifestResourceStream("XNA_Map_Editor.Resources.EraserCursor.cur"));
                    this.Cursor = new Cursor(cursor_stream);
                    break;

                case PaintTool.Walk:
                    cursor_stream = (assembly.GetManifestResourceStream("XNA_Map_Editor.Resources.WalkCursor.cur"));
                    this.Cursor = new Cursor(cursor_stream);
                    break;

                case PaintTool.Fill:
                    cursor_stream = (assembly.GetManifestResourceStream("XNA_Map_Editor.Resources.BucketCursor.cur"));
                    this.Cursor = new Cursor(cursor_stream);
                    break;

                case PaintTool.Brush:
                    this.Cursor = Cursors.Cross;
                    break;

                case PaintTool.MarqueeBrush:
                    cursor_stream = (assembly.GetManifestResourceStream("XNA_Map_Editor.Resources.MarqueeCursor.cur"));
                    this.Cursor = new Cursor(cursor_stream);
                    break;

                case PaintTool.MarqueeEraser:
                    cursor_stream = (assembly.GetManifestResourceStream("XNA_Map_Editor.Resources.MarqueeEraser.cur"));
                    this.Cursor = new Cursor(cursor_stream);
                    break;

                case PaintTool.MarqueeWalk:
                    cursor_stream = (assembly.GetManifestResourceStream("XNA_Map_Editor.Resources.curMarqueeWalk.cur"));
                    this.Cursor = new Cursor(cursor_stream);
                    break;

                case PaintTool.MarqueeTerrain:
                    cursor_stream = (assembly.GetManifestResourceStream("XNA_Map_Editor.Resources.MarqueeTerrain.cur"));
                    this.Cursor = new Cursor(cursor_stream);
                    break;


                default:
                    this.Cursor = Cursors.Arrow;
                    break;
            }
        }

        // BRUSHES FUNCTIONS

        private void MarqueeTerrain(object sender, MouseEventArgs e, MarqueeData marqueeData)
        {
            // Note:
            // MarqueeWidth and MarqueeHeight values are expressed in tile numbers

            XNA.Point selected_tile = HelperClass.TileSnapToGrid(Camera.WorldPosition(e.Location));
            Tile tile_in_map = GLB_Data.TileMap[0, selected_tile.X, selected_tile.Y];


            if (selected_tile == tile_in_map.grid_location)
            {
                TerrainType selected_terrain = (TerrainType)toolbar_terrain_combo.SelectedItem;
                // Paint the marquee selection
                for (int id_y = 0; id_y < GLB_Data.MarqueeSelection.Height; id_y++)
                {
                    for (int id_x = 0; id_x < GLB_Data.MarqueeSelection.Width; id_x++)
                    {
                        int sel_tiles_x = id_x % (GLB_Data.SelectedTiles.GetLength(0));
                        int sel_tiles_y = id_y % (GLB_Data.SelectedTiles.GetLength(1));

                        int offset_x = GLB_Data.MarqueeSelection.InitialTile.X + id_x;
                        int offset_y = GLB_Data.MarqueeSelection.InitialTile.Y + id_y;

                        if (GLB_Data.TerrainLayout[offset_x, offset_y] == selected_terrain.Id)
                        {
                            GLB_Data.TerrainLayout[offset_x, offset_y] = Constants.TERRAIN_NORMAL;
                        }
                        else
                        {
                            GLB_Data.TerrainLayout[offset_x, offset_y] = selected_terrain.Id;
                        }
                    }
                }
            }
        }

        private void MarqueeWalk(object sender, MouseEventArgs e, MarqueeData marqueeData)
        {
            // Note:
            // MarqueeWidth and MarqueeHeight values are expressed in tile numbers

            XNA.Point selected_tile = HelperClass.TileSnapToGrid(Camera.WorldPosition(e.Location));
            Tile tile_in_map = GLB_Data.TileMap[0, selected_tile.X, selected_tile.Y];

            int walk_layer = GetWalkLayer();

            if (selected_tile == tile_in_map.grid_location)
            {
                // Paint the marquee selection
                for (int id_y = 0; id_y < GLB_Data.MarqueeSelection.Height; id_y++)
                {
                    for (int id_x = 0; id_x < GLB_Data.MarqueeSelection.Width; id_x++)
                    {
                        int sel_tiles_x = id_x % (GLB_Data.SelectedTiles.GetLength(0));
                        int sel_tiles_y = id_y % (GLB_Data.SelectedTiles.GetLength(1));

                        int offset_x = GLB_Data.MarqueeSelection.InitialTile.X + id_x;
                        int offset_y = GLB_Data.MarqueeSelection.InitialTile.Y + id_y;

                        if (GLB_Data.TileMap[GetWalkLayer(), offset_x, offset_y].walkable == true)
                        {
                            GLB_Data.TileMap[GetWalkLayer(), offset_x, offset_y].walkable = false;
                        }
                        else
                        {
                            GLB_Data.TileMap[GetWalkLayer(), offset_x, offset_y].walkable = true;
                        }
                    }
                }
            }

        }

        private void MarqueeErase(object sender, MouseEventArgs e, MarqueeData marqueeData)
        {
            // Note:
            // MarqueeWidth and MarqueeHeight values are expressed in tile numbers

            XNA.Point selected_tile = HelperClass.TileSnapToGrid(Camera.WorldPosition(e.Location));
            Tile tile_in_map = GLB_Data.TileMap[0, selected_tile.X, selected_tile.Y];

            if (selected_tile == tile_in_map.grid_location)
            {
                // Paint the marquee selection
                for (int id_y = 0; id_y < GLB_Data.MarqueeSelection.Height; id_y++)
                {
                    for (int id_x = 0; id_x < GLB_Data.MarqueeSelection.Width; id_x++)
                    {
                        int sel_tiles_x = id_x % (GLB_Data.SelectedTiles.GetLength(0));
                        int sel_tiles_y = id_y % (GLB_Data.SelectedTiles.GetLength(1));

                        int offset_x = GLB_Data.MarqueeSelection.InitialTile.X + id_x;
                        int offset_y = GLB_Data.MarqueeSelection.InitialTile.Y + id_y;

                        GLB_Data.TileMap[GLB_Data.SelectedLayer, offset_x, offset_y].id = Constants.NULL_TILE; ;
                        GLB_Data.TileMap[GLB_Data.SelectedLayer, offset_x, offset_y].texture_location = new XNA.Point();
                        GLB_Data.TileMap[GetWalkLayer(), offset_x, offset_y].walkable = true;
                    }
                }
            }
        }

        private void MarqueePaint(object sender, MouseEventArgs e, MarqueeData Selection)
        {
            // Note:
            // MarqueeWidth and MarqueeHeight values are expressed in tile numbers

            XNA.Point selected_tile = HelperClass.TileSnapToGrid(Camera.WorldPosition(e.Location));
            Tile tile_in_map = GLB_Data.TileMap[0, selected_tile.X, selected_tile.Y];

            if (selected_tile == tile_in_map.grid_location)
            {
                if (selected_tile == tile_in_map.grid_location)
                {
                    // Paint the marquee selection
                    for (int id_y = 0; id_y < GLB_Data.MarqueeSelection.Height; id_y++)
                    {
                        for (int id_x = 0; id_x < GLB_Data.MarqueeSelection.Width; id_x++)
                        {
                            int sel_tiles_x = id_x % (GLB_Data.SelectedTiles.GetLength(0));
                            int sel_tiles_y = id_y % (GLB_Data.SelectedTiles.GetLength(1));

                            int offset_x = GLB_Data.MarqueeSelection.InitialTile.X + id_x;
                            int offset_y = GLB_Data.MarqueeSelection.InitialTile.Y + id_y;


                            GLB_Data.TileMap[GLB_Data.SelectedLayer, offset_x, offset_y].id = GLB_Data.SelectedTiles[sel_tiles_x, sel_tiles_y].id;
                            GLB_Data.TileMap[GLB_Data.SelectedLayer, offset_x, offset_y].texture_location = GLB_Data.SelectedTiles[sel_tiles_x, sel_tiles_y].grid_location;
                            GLB_Data.TileMap[GetWalkLayer(), offset_x, offset_y].walkable = GLB_Data.SelectedTiles[sel_tiles_x, sel_tiles_y].walkable;
                        }
                    }
                }
            }
        }

        private void BucketPaint(object sender, MouseEventArgs e)
        {
            XNA.Point selected_tile = HelperClass.TileSnapToGrid(Camera.WorldPosition(e.Location));
            Tile tile_in_map = GLB_Data.TileMap[0, selected_tile.X, selected_tile.Y];

            if (selected_tile == tile_in_map.grid_location)
            {
                // Paint the whole layer
                for (int id_y = 0; id_y < GLB_Data.MapSize.Height; id_y++)
                {
                    for (int id_x = 0; id_x < GLB_Data.MapSize.Width; id_x++)
                    {
                        int sel_tiles_x = id_x % (GLB_Data.SelectedTiles.GetLength(0));
                        int sel_tiles_y = id_y % (GLB_Data.SelectedTiles.GetLength(1));

                        GLB_Data.TileMap[GLB_Data.SelectedLayer, id_x, id_y].id = GLB_Data.SelectedTiles[sel_tiles_x, sel_tiles_y].id;
                        GLB_Data.TileMap[GLB_Data.SelectedLayer, id_x, id_y].texture_location = GLB_Data.SelectedTiles[sel_tiles_x, sel_tiles_y].grid_location;
                        GLB_Data.TileMap[GetWalkLayer(), id_x, id_y].walkable = GLB_Data.SelectedTiles[sel_tiles_x, sel_tiles_y].walkable;
                    }
                }
            }
        }

        private void WalkPaint(object sender, MouseEventArgs e)
        {
            XNA.Point selected_tile = HelperClass.TileSnapToGrid(Camera.WorldPosition(e.Location));
            Tile tile_in_map = GLB_Data.TileMap[0, selected_tile.X, selected_tile.Y];

            int walk_layer = GetWalkLayer();

            if (selected_tile == tile_in_map.grid_location)
            {
                if (GLB_Data.TileMap[walk_layer, selected_tile.X, selected_tile.Y].walkable == true)
                {
                    GLB_Data.TileMap[walk_layer, selected_tile.X, selected_tile.Y].walkable = false;
                }
                else
                {
                    GLB_Data.TileMap[walk_layer, selected_tile.X, selected_tile.Y].walkable = true;
                }
            }
        }

        private void EraserPaint(object sender, MouseEventArgs e)
        {
            XNA.Point selected_tile = HelperClass.TileSnapToGrid(Camera.WorldPosition(e.Location));
            Tile tile_in_map = GLB_Data.TileMap[0, selected_tile.X, selected_tile.Y];

            if (selected_tile == tile_in_map.grid_location)
            {
                GLB_Data.TileMap[GLB_Data.SelectedLayer, selected_tile.X, selected_tile.Y].id = Constants.NULL_TILE;
                GLB_Data.TileMap[GLB_Data.SelectedLayer, selected_tile.X, selected_tile.Y].walkable = true;
                GLB_Data.TileMap[GLB_Data.SelectedLayer, selected_tile.X, selected_tile.Y].texture_location = new XNA.Point();
                /////GLB_Data.TileMap[GetWalkLayer(),         selected_tile.X, selected_tile.Y].walkable         = true;
            }
        }

        private void BrushPaint(object sender, MouseEventArgs e)
        {
            XNA.Point selected_tile = HelperClass.TileSnapToGrid(Camera.WorldPosition(e.Location));
            Tile tile_in_map = GLB_Data.TileMap[0, selected_tile.X, selected_tile.Y];

            if (selected_tile == tile_in_map.grid_location)
            {
                for (int id_y = 0; id_y < GLB_Data.SelectedTiles.GetLength(1); id_y++)
                {
                    for (int id_x = 0; id_x < GLB_Data.SelectedTiles.GetLength(0); id_x++)
                    {
                        if (selected_tile.X + id_x < GLB_Data.TileMap.GetLength(1) && selected_tile.Y + id_y < GLB_Data.TileMap.GetLength(2))
                        {
                            GLB_Data.TileMap[GLB_Data.SelectedLayer, selected_tile.X + id_x, selected_tile.Y + id_y].id = GLB_Data.SelectedTiles[id_x, id_y].id;
                            GLB_Data.TileMap[GLB_Data.SelectedLayer, selected_tile.X + id_x, selected_tile.Y + id_y].texture_location = GLB_Data.SelectedTiles[id_x, id_y].grid_location;
                            GLB_Data.TileMap[GLB_Data.SelectedLayer, selected_tile.X + id_x, selected_tile.Y + id_y].walkable = GLB_Data.SelectedTiles[id_x, id_y].walkable;
                            GLB_Data.TileMap[GetWalkLayer(), selected_tile.X + id_x, selected_tile.Y + id_y].walkable = GLB_Data.SelectedTiles[id_x, id_y].walkable;
                        }
                    }
                }
            }
        }

        private void PortalPaint(object sender, MouseEventArgs e)
        {
            XNA.Point selected_tile = HelperClass.TileSnapToGrid(Camera.WorldPosition(e.Location));
            Tile tile_in_map = GLB_Data.TileMap[0, selected_tile.X, selected_tile.Y];

            Portal portal = new Portal();
            portal.x = tile_in_map.grid_location.X;
            portal.y = tile_in_map.grid_location.Y;
            portal.name = "P" + GLB_Data.portalIndex;


            bool portalFound = false;
            Portal deadPortal = new Portal();

            foreach (Portal p in GLB_Data.portals)
            {
                if (portal.x == p.x && portal.y == p.y)
                {
                    portalFound = true;
                    deadPortal = p;
                }
            }

            if (portalFound)
            {
                GLB_Data.portals.Remove(deadPortal);
            }
            else
            {
                GLB_Data.portals.Add(portal);
                GLB_Data.portalIndex++;
            }
        }

        private void ChestPaint(object sender, MouseEventArgs e)
        {
            XNA.Point selected_tile = HelperClass.TileSnapToGrid(Camera.WorldPosition(e.Location));
            Tile tile_in_map = GLB_Data.TileMap[0, selected_tile.X, selected_tile.Y];

            Chest Chest = new Chest();
            Chest.x = tile_in_map.grid_location.X;
            Chest.y = tile_in_map.grid_location.Y;
            Chest.name = "";


            bool ChestFound = false;
            Chest deadChest = new Chest();

            foreach (Chest c in GLB_Data.chests)
            {
                if (Chest.x == c.x && Chest.y == c.y)
                {
                    ChestFound = true;
                    deadChest = c;
                }
            }

            if (ChestFound)
            {
                GLB_Data.chests.Remove(deadChest);
            }
            else
            {
                GLB_Data.chests.Add(Chest);
            }
        }


        private void NPCPaint(object sender, MouseEventArgs e)
        {
            XNA.Point selected_tile = HelperClass.TileSnapToGrid(Camera.WorldPosition(e.Location));
            Tile tile_in_map = GLB_Data.TileMap[0, selected_tile.X, selected_tile.Y];

            NPC NPC = new NPC();
            NPC.x = tile_in_map.grid_location.X;
            NPC.y = tile_in_map.grid_location.Y;
            NPC.name = "";


            bool NPCFound = false;
            NPC deadNPC = new NPC();

            foreach (NPC n in GLB_Data.npcs)
            {
                if (NPC.x == n.x && NPC.y == n.y)
                {
                    NPCFound = true;
                    deadNPC = n;
                }
            }

            if (NPCFound)
            {
                GLB_Data.npcs.Remove(deadNPC);
            }
            else
            {
                GLB_Data.npcs.Add(NPC);
            }
        }

        private void FixedCombatPaint(object sender, MouseEventArgs e)
        {
            XNA.Point selected_tile = HelperClass.TileSnapToGrid(Camera.WorldPosition(e.Location));
            Tile tile_in_map = GLB_Data.TileMap[0, selected_tile.X, selected_tile.Y];

            FixedCombatNPC FixedCombat = new FixedCombatNPC();
            FixedCombat.x = tile_in_map.grid_location.X;
            FixedCombat.y = tile_in_map.grid_location.Y;
            FixedCombat.name = "";


            bool FixedCombatFound = false;
            FixedCombatNPC deadFixedCombat = new FixedCombatNPC();

            foreach (FixedCombatNPC f in GLB_Data.fixedCombatNPCs)
            {
                if (FixedCombat.x == f.x && FixedCombat.y == f.y)
                {
                    FixedCombatFound = true;
                    deadFixedCombat = f;
                }
            }

            if (FixedCombatFound)
            {
                GLB_Data.fixedCombatNPCs.Remove(deadFixedCombat);
            }
            else
            {
                GLB_Data.fixedCombatNPCs.Add(FixedCombat);
            }
        }

        private void BlockPaint(object sender, MouseEventArgs e)
        {
            XNA.Point selected_tile = HelperClass.TileSnapToGrid(Camera.WorldPosition(e.Location));
            Tile tile_in_map = GLB_Data.TileMap[0, selected_tile.X, selected_tile.Y];

            Block Block = new Block();
            Block.x = tile_in_map.grid_location.X;
            Block.y = tile_in_map.grid_location.Y;
            Block.name = "";


            bool BlockFound = false;
            Block deadBlock = new Block();

            foreach (Block n in GLB_Data.blocks)
            {
                if (Block.x == n.x && Block.y == n.y)
                {
                    BlockFound = true;
                    deadBlock = n;
                }
            }

            if (BlockFound)
            {
                GLB_Data.blocks.Remove(deadBlock);
            }
            else
            {
                GLB_Data.blocks.Add(Block);
            }
        }

        private void SwitchPaint(object sender, MouseEventArgs e)
        {
            XNA.Point selected_tile = HelperClass.TileSnapToGrid(Camera.WorldPosition(e.Location));
            Tile tile_in_map = GLB_Data.TileMap[0, selected_tile.X, selected_tile.Y];

            Switch Switch = new Switch();
            Switch.x = tile_in_map.grid_location.X;
            Switch.y = tile_in_map.grid_location.Y;
            Switch.name = "";


            bool SwitchFound = false;
            Switch deadSwitch = new Switch();

            foreach (Switch n in GLB_Data.switches)
            {
                if (Switch.x == n.x && Switch.y == n.y)
                {
                    SwitchFound = true;
                    deadSwitch = n;
                }
            }

            if (SwitchFound)
            {
                GLB_Data.switches.Remove(deadSwitch);
            }
            else
            {
                GLB_Data.switches.Add(Switch);
            }
        }
        // BRUSHES FUNCTIONS

        #endregion
    }
}