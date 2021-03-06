﻿using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

using XNA_Map_Editor.Classes;
using XNA_Map_Editor.Helpers;
using XNA = Microsoft.Xna.Framework;

namespace XNA_Map_Editor.SubForms
{
    public partial class ResizeForm : Form
    {
        private MainForm main_form;
        DialogResult dialog_result;

        public ResizeForm(MainForm FormParent)
        {
            InitializeComponent();

            main_form = FormParent;

            // init form's image
            this.pictureBox1.Image = XNA_Map_Editor.Properties.Resources.BannerResize;

            // init forms data
            txt_layers.Text = GLB_Data.MapSize.Depth.ToString();
            txt_width.Text  = GLB_Data.MapSize.Width.ToString();
            txt_height.Text = GLB_Data.MapSize.Height.ToString();

            SetMapLimits();

            updwn_depth.Value  = GLB_Data.MapSize.Depth;
            updwn_width.Value  = GLB_Data.MapSize.Width;
            updwn_height.Value = GLB_Data.MapSize.Height;

            // init position            
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void SetMapLimits()
        {
            updwn_depth.Minimum = Constants.MIN_MAP_DEPTH;
            updwn_depth.Maximum = Constants.MAX_MAP_DEPTH;

            updwn_width.Minimum = Constants.MIN_MAP_WIDTH;
            updwn_width.Maximum = Constants.MAX_MAP_WIDTH;

            updwn_height.Minimum = Constants.MIN_MAP_HEIGHT;
            updwn_height.Maximum = Constants.MAX_MAP_HEIGHT;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void btn_resize_Click(object sender, EventArgs e)
        {
            if ( GLB_Data.MapSize.Depth > updwn_depth.Value ||
                 GLB_Data.MapSize.Width > updwn_width.Value ||
                 GLB_Data.MapSize.Height > updwn_height.Value)
            {
                dialog_result = MessageBox.Show("New new size is smaller than current map dimensions, " + 
                                                             "some tiles will be lost\n Proceed?", "Warning", 
                                                             MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dialog_result == DialogResult.No)
                {
                    return;
                }
            }

            dialog_result = MessageBox.Show("Warning, the resize operation cannot be undone.\nProceed?", "Warning",
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog_result == DialogResult.No)
            {
                return;
            }

            ResizeMap(Convert.ToInt32(updwn_depth.Value), Convert.ToInt32(updwn_width.Value), Convert.ToInt32(updwn_height.Value));


            int padTop = Convert.ToInt32(nPadTop.Value);
            int padBottom = Convert.ToInt32(nPadBottom.Value);
            int padLeft = Convert.ToInt32(nPadLeft.Value);
            int padRight = Convert.ToInt32(nPadRight.Value);

            if (padTop != 0)
                PadMap(padTop, 0, 0 ,0);

            if (padBottom != 0)
                PadMap(0, padBottom, 0, 0);

            if (padLeft != 0)
                PadMap(0, 0, padLeft, 0);

            if (padRight != 0)
                PadMap(0, 0, 0, padRight);


            this.Dispose(true);

            main_form.ResetCamera();
            main_form.ClearUndoRedo();            
            main_form.CheckUndoRedo();
            main_form.InitScrollBars();
        }

        private void ResizeMap(int Depth, int Width, int Height)
        {
            // temp copy
            Tile[,,] aux_tile_map       = (Tile[,,]) GLB_Data.TileMap.Clone();
            Tile[,] aux_walk_layer      = new Tile[GLB_Data.MapSize.Width, GLB_Data.MapSize.Height];
            Int32[,] aux_terrain_layer  = new Int32[GLB_Data.MapSize.Width, GLB_Data.MapSize.Height];

            // Make a copy of the walk layer layout  & terrain layer         
            for (int id_y = 0; id_y < GLB_Data.MapSize.Height; id_y++)
            {
                for (int id_x = 0; id_x < GLB_Data.MapSize.Width; id_x++)
                {
                    aux_walk_layer[id_x, id_y].walkable = GLB_Data.TileMap[GLB_Data.MapSize.Depth, id_x, id_y].walkable;
                    //aux_terrain_layer[id_x, id_y] = GLB_Data.TerrainLayout[id_x, id_y];
                }
            }

            // Assign new tilemap dimensions
            GLB_Data.MapSize.Depth  = Depth;
            GLB_Data.MapSize.Width  = Width;
            GLB_Data.MapSize.Height = Height;

            GLB_Data.TileMap = new Tile[Depth + Constants.WALK_LAYER, Width, Height];
            GLB_Data.TerrainLayout = new Int32[GLB_Data.MapSize.Width, GLB_Data.MapSize.Height];
            main_form.InitTileMap();
            main_form.ShowCurrentLayer();

            for (int id_z = 0; id_z < GLB_Data.MapSize.Depth; id_z++)
            {
                for (int id_y = 0; id_y < GLB_Data.MapSize.Height; id_y++)
                {
                    for (int id_x = 0; id_x < GLB_Data.MapSize.Width; id_x++)
                    {
                        if ( id_z < aux_tile_map.GetLength(0) &&
                             id_x < aux_tile_map.GetLength(1) &&
                             id_y < aux_tile_map.GetLength(2) )
                        {
                            // Copy existing data
                            GLB_Data.TileMap[id_z, id_x, id_y].id               = aux_tile_map[id_z, id_x, id_y].id;
                            GLB_Data.TileMap[id_z, id_x, id_y].grid_location    = aux_tile_map[id_z, id_x, id_y].grid_location;
                            if (GLB_Data.TileMap[id_z, id_x, id_y].id == Constants.NULL_TILE)
                            {
                                GLB_Data.TileMap[id_z, id_x, id_y].texture_location = new XNA.Point();
                            }
                            else
                            {
                                GLB_Data.TileMap[id_z, id_x, id_y].texture_location = aux_tile_map[id_z, id_x, id_y].texture_location; 
                            }
                        }                        
                    }
                }
            }

            // copy previous walk layout && terrain layout
            for (int id_y = 0; id_y < aux_walk_layer.GetLength(1); id_y++)
            {
                for (int id_x = 0; id_x < aux_walk_layer.GetLength(0); id_x++)
                {
                    if (id_x < GLB_Data.MapSize.Width && id_y < GLB_Data.MapSize.Height)
                    {
                        GLB_Data.TileMap[GLB_Data.TileMap.GetLength(0) - 1, id_x, id_y].walkable = aux_walk_layer[id_x, id_y].walkable;
                        GLB_Data.TerrainLayout[id_x, id_y] = aux_terrain_layer[id_x, id_y];
                    }
                }
            }

        }

        private void PadMap(int padTop, int padBottom, int padLeft, int padRight)
        {
            int Depth = Convert.ToInt32(updwn_depth.Value);


            GLB_Data.MapSize.Width += padLeft + padRight;
            GLB_Data.MapSize.Height += padTop + padBottom;


            // temp copy
            Tile[,,] aux_tile_map = (Tile[,,])GLB_Data.TileMap.Clone();
            
            GLB_Data.TileMap = new Tile[Depth + Constants.WALK_LAYER, GLB_Data.MapSize.Width, GLB_Data.MapSize.Height];
            GLB_Data.TerrainLayout = new Int32[GLB_Data.MapSize.Width, GLB_Data.MapSize.Height];
            main_form.InitTileMap();
            main_form.ShowCurrentLayer();

            for (int id_z = 0; id_z < GLB_Data.MapSize.Depth; id_z++)
            {
                for (int id_y = 0; id_y < Math.Max(GLB_Data.MapSize.Height, GLB_Data.MapSize.Height - padTop + padBottom); id_y++)
                {
                    for (int id_x = 0; id_x < Math.Max(GLB_Data.MapSize.Width, GLB_Data.MapSize.Width - padLeft + padRight); id_x++)
                    {
                        if (id_z < aux_tile_map.GetLength(0) &&
                             id_x < aux_tile_map.GetLength(1) &&
                             id_y < aux_tile_map.GetLength(2))
                        {
                            // Copy existing data
                            GLB_Data.TileMap[id_z, Math.Max(id_x + padLeft, 0), Math.Max(id_y + padTop, 0)].id = aux_tile_map[id_z, id_x, id_y].id;
                            //GLB_Data.TileMap[id_z, id_x + padLeft, id_y + padTop].grid_location = aux_tile_map[id_z, id_x, id_y].grid_location;

                            if(id_x < GLB_Data.TileMap.GetLength(1) && id_y < GLB_Data.TileMap.GetLength(2))
                                GLB_Data.TileMap[id_z, id_x, id_y].grid_location = new XNA.Point(id_x, id_y);

                            if (GLB_Data.TileMap[id_z, Math.Max(id_x + padLeft, 0), Math.Max(id_y + padTop, 0)].id == Constants.NULL_TILE)
                            {
                                GLB_Data.TileMap[id_z, Math.Max(id_x + padLeft, 0), Math.Max(id_y + padTop, 0)].texture_location = new XNA.Point();
                            }
                            else
                            {
                                GLB_Data.TileMap[id_z, Math.Max(id_x + padLeft, 0), Math.Max(id_y + padTop, 0)].texture_location = aux_tile_map[id_z, id_x, id_y].texture_location;
                            }
                        }
                    }
                }
            }

        }

    }
}
