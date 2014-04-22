using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Reflection;

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
using System.Collections;



namespace XNA_Map_Editor
{

    public partial class ManagePortals : Form
    {
        #region Class Fields

        Microsoft.Xna.Framework.Point selectedLandingSpot;
        Portal selectedPortal;
        string otherFileName;
        MainForm parentForm;

        SpriteBatch sprite_batch;
        // Data Dialogs
        OpenFileDialog load_tiles_dialog;
        OpenFileDialog load_map_dialog;
        SaveFileDialog save_map_dialog;

        Texture2D grid_texture;
        Texture2D tile_texture;

        UndoRedo undo_redo;

        Boolean MouseOnMe;
        Boolean HideLayers;
        Boolean ShowGrid;
        Boolean ShowWalkLayer;
        Byte AlphaValue;
        Boolean ShowTerrainTypes;

        // Custom Controls
        TilePalette tile_palette;

        System.Drawing.Point previous_location;

        static AboutForm about_form = new AboutForm();

        // Mouse Scroll Variables
        System.Drawing.Point mouse_scroll_initial;
        System.Drawing.Point mouse_scroll_final;


        // needed for reading embeeded resources
        Assembly assembly;
        Stream pixel_texture_stream;
        Stream tile_texture_stream;

        // XML Map Writer
        XmlMapWriter xml_writer;

        // Terrain List child form
        static TerrainEditor terrain_editor_form;

        // Tile Size editor
        TileSizeEditor frm_tile_size;

        #endregion

        public ManagePortals(GraphicsDevice gfx, MainForm mainForm)
        {
            InitializeComponent();

            parentForm = mainForm;

            this.xnaRenderer1.OnDraw = new EventHandler(XnaRender);

            this.sprite_batch = new SpriteBatch(gfx);

            tile_palette = new TilePalette(this);

            assembly = Assembly.GetExecutingAssembly();
            pixel_texture_stream = (assembly.GetManifestResourceStream("XNA_Map_Editor.Resources.white_pixel.png"));
            tile_texture_stream = (assembly.GetManifestResourceStream("XNA_Map_Editor.Resources.white_default_tile.png"));

            grid_texture = Texture2D.FromStream(gfx, pixel_texture_stream);
            tile_texture = Texture2D.FromStream(gfx, tile_texture_stream);

            foreach (Portal portal in GLB_Data.portals)
            {
                ListViewItem lvi = new ListViewItem(portal.name);
                lvi.Text = portal.name;
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, portal.x.ToString()));
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, portal.y.ToString()));

                portalList.Items.Add(lvi);
            }

            this.MouseWheel += new MouseEventHandler(this.xna_renderer_MouseWheel); 

            selectedPortal.name = null;
            selectedPortal.x = -1;
            selectedPortal.y = -1;
            selectedLandingSpot.X = -1;
            selectedLandingSpot.Y = -1;
        }


        void XnaRender(object sender, EventArgs e)
        {
            xnaRenderer1.GraphicsDevice.Clear(XNA.Color.CornflowerBlue);

            //BEGIN
            sprite_batch.Begin();

            for (int id_z = 0; id_z < GLB_Data_Other.MapSize.Depth; id_z++)
            {
                for (int id_y = 0; id_y < GLB_Data_Other.MapSize.Height; id_y++)
                {
                    for (int id_x = 0; id_x < GLB_Data_Other.MapSize.Width; id_x++)
                    {
                        if (GLB_Data_Other.TileMap[id_z, id_x, id_y].id == Constants.NULL_TILE)
                        {
                            // Dont draw this tile
                            continue;
                        }

                        XNA.Rectangle source_rectangle = new XNA.Rectangle(GLB_Data_Other.TileMap[id_z, id_x, id_y].texture_location.X * GLB_Data_Other.MapSize.TileSize,
                                                                           GLB_Data_Other.TileMap[id_z, id_x, id_y].texture_location.Y * GLB_Data_Other.MapSize.TileSize,
                                                                           GLB_Data_Other.MapSize.TileSize, GLB_Data_Other.MapSize.TileSize);

                        XNA.Rectangle dest_rectangle = Camera.Transform(new XNA.Rectangle(id_x * Camera.ScaledTileSize, id_y * Camera.ScaledTileSize, Camera.ScaledTileSize, Camera.ScaledTileSize));

                        if (MapFrustrumCull(id_x, id_y))
                        {
                            continue;
                        }

                        if (HideLayers)
                        {
                            if (id_z == GLB_Data_Other.SelectedLayer)
                            {
                                // Render Normally
                                sprite_batch.Draw(GLB_Data_Other.TilesTexture, dest_rectangle, source_rectangle, XNA.Color.White);
                            }
                            else
                            {
                                // apply semi-transparency
                                sprite_batch.Draw(GLB_Data_Other.TilesTexture, dest_rectangle, source_rectangle, new XNA.Color(255, 255, 255, 22));
                            }
                        }
                        else
                        {
                            // Render Normally
                            sprite_batch.Draw(GLB_Data_Other.TilesTexture, dest_rectangle, source_rectangle, XNA.Color.White);
                        }

                    }
                }

            }
            
            if (GLB_Data_Other.portals != null)
            {
                foreach (Portal portal in GLB_Data_Other.portals)
                {
                    sprite_batch.Draw(grid_texture, Camera.Transform(new XNA.Rectangle(portal.x * Camera.ScaledTileSize, portal.y * Camera.ScaledTileSize, Camera.ScaledTileSize, Camera.ScaledTileSize)), new XNA.Color(0, 0, 255, 98));
                }
            }

            sprite_batch.Draw(grid_texture, Camera.Transform(new XNA.Rectangle(selectedLandingSpot.X * Camera.ScaledTileSize, selectedLandingSpot.Y * Camera.ScaledTileSize, Camera.ScaledTileSize, Camera.ScaledTileSize)), new XNA.Color(255, 0, 255, 98));
            sprite_batch.Draw(grid_texture, Camera.Transform(new XNA.Rectangle(selectedPortal.x * Camera.ScaledTileSize, selectedPortal.y * Camera.ScaledTileSize, Camera.ScaledTileSize, Camera.ScaledTileSize)), new XNA.Color(0, 225, 0, 98));

            //END
            sprite_batch.End();

        }// Draw Map



        private Boolean MapFrustrumCull(int id_x, int id_y)
        {
            if (!new XNA.Rectangle((int)Camera.X * -1 - Camera.ScaledTileSize, (int)Camera.Y * -1 - Camera.ScaledTileSize, xnaRenderer1.Width + Camera.ScaledTileSize, xnaRenderer1.Height + Camera.ScaledTileSize).Contains(new XNA.Point(id_x * Camera.ScaledTileSize, id_y * Camera.ScaledTileSize)))
            {
                return true;
            }

            return false;
        }

        private void toolbar_loadMapPortals_Click(object sender, EventArgs e)
        {
            load_map_dialog = new OpenFileDialog();
            load_map_dialog.InitialDirectory = Environment.CurrentDirectory + @"\Maps";
            load_map_dialog.Filter = "XNA Map Editor TileMaps (*.xmap) | *.xmap";
            load_map_dialog.Title = "Load TileMap";

            // Open load dialog
            DialogResult loaded_result = this.load_map_dialog.ShowDialog();

            if (loaded_result == DialogResult.OK)
            {
                // Load tile map data
                MapLoader map_loader = new MapLoader();

                otherFileName = load_map_dialog.FileName;

                //chop off directory info
                otherFileName = otherFileName.Substring(otherFileName.LastIndexOf("\\") + 1, otherFileName.LastIndexOf(".") - otherFileName.LastIndexOf("\\") - 1);

                if (map_loader.LoadBinaryMapOther(load_map_dialog.FileName))
                {
                    // success
                    if (GLB_Data_Other.TextureFileName == null || GLB_Data_Other.TextureFileName == "")
                    {
                        //MessageBox.Show("TileMap loaded successfully!", "Save Map", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    Stream s = new MemoryStream(ASCIIEncoding.Default.GetBytes(GLB_Data_Other.TextureFileName));
                    GLB_Data_Other.TilesTexture = Texture2D.FromStream(xnaRenderer1.GraphicsDevice, s);
                    
                    tile_palette.SetImage(GLB_Data_Other.TextureFileName, GLB_Data_Other.TilePalette);
                    tile_palette.Invalidate();

                    // reset settings
                    this.ResetSelectedTiles();
                    this.ResetLayers();
                    this.ResetCamera();

                    //terrain_editor_form.PopulateCombo();

                    // loading done
                    //MessageBox.Show("TileMap loaded successfully!", "Save Map", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void ResetSelectedTiles()
        {
            GLB_Data_Other.SelectedTiles = new Tile[1, 1];
            GLB_Data_Other.SelectedTiles[0, 0].id = Constants.NULL_TILE;
            GLB_Data_Other.SelectedTiles[0, 0].walkable = true;
            tile_palette.ClearSelection();
        }


        internal void ResetCamera()
        {
            Camera.Reset();
            this.hscroll_xna.Value = 0;
            this.vscroll_xna.Value = 0;
            InitScrollBars();
        }

        private void ResetLayers()
        {
            // Reset selected layer
            GLB_Data_Other.SelectedLayer = Constants.BASE_LAYER;
        }


        private void hscroll_xna_Scroll(object sender, ScrollEventArgs e)
        {
            Camera.X = -e.NewValue;
            this.xnaRenderer1.Invalidate();
        }

        private void vscroll_xna_Scroll(object sender, ScrollEventArgs e)
        {
            Camera.Y = -e.NewValue;
            this.xnaRenderer1.Invalidate();
        }

        private void xna_renderer_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                Camera.IncreaseZoom(xnaRenderer1.Width, xnaRenderer1.Height);
                InitScrollBars();
            }

            if (e.Delta > 0)
            {
                Camera.DecrementZoom();
                InitScrollBars();
            }

            if (Math.Abs(Camera.X) + (GLB_Data_Other.MapSize.Width * Camera.ScaledTileSize) <= xnaRenderer1.Width)
            {
                Camera.X = 0;
            }

            if (Math.Abs(Camera.Y) + (GLB_Data_Other.MapSize.Height * Camera.ScaledTileSize) <= xnaRenderer1.Height)
            {
                Camera.Y = 0;
            }

            Camera.Scroll(0, 0, xnaRenderer1.Width, xnaRenderer1.Height);

            this.Refresh();
        }



        internal void InitScrollBars()
        {
            if (GLB_Data_Other.MapSize.Width * Camera.ScaledTileSize > xnaRenderer1.Width)
            {
                // Enable Horizontal Bar
                this.hscroll_xna.Visible = true;

                // Set minimum and maximum values (not in pixels)
                hscroll_xna.Minimum = 0;
                hscroll_xna.Maximum = GLB_Data_Other.MapSize.Width * Camera.ScaledTileSize - xnaRenderer1.Width;
            }
            else
            {
                this.hscroll_xna.Visible = false;
                this.hscroll_xna.Value = 0;
            }

            if (GLB_Data_Other.MapSize.Height * Camera.ScaledTileSize > xnaRenderer1.Height)
            {
                // Enable Vertical Bar
                this.vscroll_xna.Visible = true;

                // Set minimum and maximum values (not in pixels)
                vscroll_xna.Minimum = 0;
                vscroll_xna.Maximum = GLB_Data_Other.MapSize.Height * Camera.ScaledTileSize - xnaRenderer1.Height;
            }
            else
            {
                this.vscroll_xna.Visible = false;
                this.vscroll_xna.Value = 0;
            }


            if (this.hscroll_xna.Visible || this.vscroll_xna.Visible)
            {
                this.pnl_scroll_filler.Visible = true;
            }
            else
            {
                this.pnl_scroll_filler.Visible = false;
            }

        }

        private void xnaRenderer1_mouse_down(object sender, MouseEventArgs e)
        {
            if (portalList.SelectedItem != null)
            {
                XNA.Point selected_tile = HelperClass.TileSnapToGrid(Camera.WorldPosition(e.Location));

                Portal originPortal;

                foreach (Portal portal in GLB_Data.portals)
                {
                    if (portalList.SelectedItem.ToString().Contains(portal.name))
                    {
                        originPortal = portal;
                    }
                }

                Portal destinationPortal = new Portal();
                bool portalFound = false;

                foreach (Portal portal in GLB_Data_Other.portals)
                {
                    if (portal.x == selected_tile.X && portal.y == selected_tile.Y)
                    {
                        destinationPortal = portal;
                        portalFound = true;
                    }
                }

                if (portalFound)
                {
                    selectedPortal = destinationPortal;
                }
                else
                {
                    selectedLandingSpot = selected_tile;
                }

                if (selectedPortal.name != null )//&& selectedLandingSpot.X != -1)
                {
                    PortalDestination destionation = new PortalDestination();

                    destionation.name = ((ListViewItem)portalList.SelectedItem).Text;
                    destionation.x = 0;//selectedLandingSpot.X;
                    destionation.y = 0;//selectedLandingSpot.Y;
                    destionation.destinationPortal = selectedPortal;
                    destionation.destinationMap = otherFileName;


                    bool destFound = false;

                    //replace destination if one already exists for this portal
                    for (int i = 0; i < GLB_Data.destinations.Count; i++)
                    {
                        if (GLB_Data.destinations[i].name == destionation.name)
                        {
                            GLB_Data.destinations[i] = destionation;
                            destFound = true;
                        }
                    }

                    if(!destFound)
                        GLB_Data.destinations.Add(destionation);

                    ((ListViewItem)portalList.SelectedItem).BackColor = System.Drawing.Color.Yellow;
                }

                this.Refresh();
            }
        }

        private void portalList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPortal.name = null;
            selectedPortal.x = -1;
            selectedPortal.y = -1;
            selectedLandingSpot.X = -1;
            selectedLandingSpot.Y = -1;

            if (portalList.SelectedItem != null)
            {
                //selectedLandingSpot.X = int.Parse(.SubItems[0].Text);
                //selectedLandingSpot.Y = int.Parse(((ListViewItem)portalList.SelectedItem).SubItems[1].Text);

                foreach (PortalDestination dest in GLB_Data.destinations)
                {
                    if (dest.name == ((ListViewItem)portalList.SelectedItem).Text)
                    {
                        selectedPortal = dest.destinationPortal;

                        selectedLandingSpot.X = dest.x;
                        selectedLandingSpot.Y = dest.y;
                    }
                }

            }

            parentForm.goldenTile.grid_location.X = int.Parse(((ListViewItem)portalList.SelectedItem).SubItems[1].Text);
            parentForm.goldenTile.grid_location.Y = int.Parse(((ListViewItem)portalList.SelectedItem).SubItems[2].Text);

            this.Refresh();
        }


    }


           
}
