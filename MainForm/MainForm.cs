#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Reflection;

using ImagesSrc = XNA_Map_Editor.Properties.Resources;

using GDI = System.Drawing;

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
using System.Collections;

#endregion

namespace XNA_Map_Editor
{
    [Serializable()]
    public struct TerrainType
    {
        public Int32                Id;
        public String               Name;
        public System.Drawing.Color Color;
        public float                TerrainSpeed;

        public TerrainType(Int32 id, String name, float speed, System.Drawing.Color color)
        {
            Id              = id;
            Name            = name;
            Color           = color;
            TerrainSpeed    = speed;
        }

        public override string ToString()
        {
            return "     " + Id.ToString() + "\t" + Name;
        }
    }

    [Serializable()]
    public struct Block
    {
        public string name;
        public string moveType;
        public int x;
        public int y;
    }

    [Serializable()]
    public struct Switch
    {
        public string name;
        public string alwaysActive;
        public int x;
        public int y;
    }

    [Serializable()]
    public struct FixedCombatNPC
    {
        public string name;
        public string direction;
        public int x;
        public int y;
    }


    [Serializable()]
    public struct Chest
    {
        public string name;
        public int x;
        public int y;
    }

    [Serializable()]
    public struct NPC
    {
        public string name;
        public int x;
        public int y;
    }

    [Serializable()]
    public struct Portal
    {
        public string name;
        public int x;
        public int y;
    }

    [Serializable()]
    public struct PortalDestination
    {
        public string name;
        public string destinationMap;
        public Portal destinationPortal;
        public int x;
        public int y;
    }

    [Serializable()]
    public struct TileMapSize
    {
        public int Width;
        public int Height;
        public int Depth;
        public int TileSize;
    }

    public struct MarqueeData
    {
        public int                      Width;
        public int                      Height;
        public System.Drawing.Point     InitialLocation;
        public System.Drawing.Point     FinalLocation;
        public bool                     Show;

        public System.Drawing.Point     InitialTile;
    }

    public struct GLB_Data
    {
        public static string        MapName; 
        public static TileMapSize   MapSize; 
        public static Texture2D     TilesTexture;

        public static String        TextureFileName;
        public static Tile[,,]      TileMap;
        public static Tile[,]       SelectedTiles;
        public static Tile[,]       TilePalette;
        public static Int32         SelectedLayer;

        public static PaintTool     Brush;
        public static MarqueeData   MarqueeSelection;
        // Terrain List
        public static ArrayList     TerrainList;
        public static Int32[,]      TerrainLayout;

        public static List<Portal>  portals;
        public static int           portalIndex;

        public static List<Chest>   chests;
        public static List<NPC>     npcs;
        public static List<FixedCombatNPC> fixedCombatNPCs;
        public static List<Block> blocks;
        public static List<Switch> switches;

        public static List<PortalDestination> destinations;
        public static List<XNA.Rectangle> marqueeHist = new List<XNA.Rectangle>();
        public static List<int> marqueeHistType = new List<int>();
    }

    public struct GLB_Data_Other
    {
        public static TileMapSize MapSize;
        public static Texture2D TilesTexture;

        public static String TextureFileName;
        public static Tile[, ,] TileMap;
        public static Tile[,] SelectedTiles;
        public static Tile[,] TilePalette;
        public static Int32 SelectedLayer;

        public static PaintTool Brush;
        public static MarqueeData MarqueeSelection;
        // Terrain List
        public static ArrayList TerrainList;
        public static Int32[,] TerrainLayout;

        public static List<Portal> portals;
        public static int portalIndex;

        public static List<Chest> chests;
        public static List<NPC> npcs;
        public static List<FixedCombatNPC> fixedCombatNPCs;
        public static List<Block> blocks;
        public static List<Switch> switches;

        public static List<PortalDestination> destinations;
    }

    public partial class MainForm : Form
    {
        #region Class Fields

        public Tile     goldenTile;
        public ManagePortals   managePortalsForm;

        SpriteBatch     sprite_batch;        
        // Data Dialogs
        OpenFileDialog  load_tiles_dialog;
        OpenFileDialog  load_map_dialog;
        SaveFileDialog  save_map_dialog;

        Texture2D       grid_texture;
        Texture2D       tile_texture;

        UndoRedo        undo_redo;

        Boolean         MouseOnMe;
        Boolean         HideLayers;
        Boolean         ShowGrid;        
        Boolean         ShowWalkLayer;
        Byte            AlphaValue;
        Boolean         ShowTerrainTypes;

        // needed for reading embeeded resources
        Assembly        assembly;
        Stream          pixel_texture_stream;
        Stream          tile_texture_stream;
        Stream          chest_texture_stream;
        Stream          NPC_texture_stream;
        Stream          monster_texture_stream;
        Stream          block_texture_stream;
        Stream          switch_texture_stream;

        // Custom Controls
        TilePalette     tile_palette;

        System.Drawing.Point previous_location;

        static AboutForm about_form = new AboutForm();

        // Mouse Scroll Variables
        System.Drawing.Point mouse_scroll_initial;
        System.Drawing.Point mouse_scroll_final;

        // XML Map Writer
        XmlMapWriter       xml_writer;

        // Terrain List child form
        static TerrainEditor terrain_editor_form;

        // Tile Size editor
        TileSizeEditor frm_tile_size;

        //chest edit form
        EditChest editChest;

        //NPC edit form
        EditNPC editNPC;

        //monster edit form
        EditMonster editMonster;

        //monster edit form
        EditBlock editBlock;

        //monster edit form
        EditSwitches editSwitches;

        //prevent click from registering when you open a new file
        bool openingFile = false;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            
            this.xna_renderer.OnInitialize  += new EventHandler(XnaInitialize);
            this.xna_renderer.OnDraw        += new EventHandler(XnaRender);
            Application.Idle                += delegate { xna_renderer.Invalidate(); };

            Camera.InitCamera();

            // Custom Controls
            tile_palette = new TilePalette(this);
            pnl_tile_palette.Controls.Add(tile_palette);

            InitLoadTilesDialog();
            InitLoadMapDialog();
            InitSaveMapDialog();

            // Set default initial map values
            GLB_Data.TileMap        = new Tile[3 + 1, 20, 20]; // 3 depth layers + walk layer
            // Last layer is used for walk grid!
            GLB_Data.MapSize.Depth      = GLB_Data.TileMap.GetLength(0) - 1;
            GLB_Data.MapSize.Width      = GLB_Data.TileMap.GetLength(1);
            GLB_Data.MapSize.Height     = GLB_Data.TileMap.GetLength(2);
            GLB_Data.MapSize.TileSize   = Constants.DEFAULT_TILE_SIZE;
            GLB_Data.TerrainLayout      = new Int32[GLB_Data.MapSize.Width, GLB_Data.MapSize.Height];

            InitTileMap();
            ResetSelectedTiles();

            ShowCurrentLayer();

            MouseOnMe = false;

            // Undo / Redo functionality
            undo_redo = new UndoRedo();

            CheckUndoRedo();

            HideLayers          = false;
            ShowGrid            = false;
            ShowWalkLayer       = true;
            ShowTerrainTypes    = false;

            InitToolbar();

            // Set default paint tool
            SetBrush(PaintTool.Brush);

            assembly                = Assembly.GetExecutingAssembly();
            pixel_texture_stream    = (assembly.GetManifestResourceStream("XNA_Map_Editor.Resources.white_pixel.png"));
            tile_texture_stream     = (assembly.GetManifestResourceStream("XNA_Map_Editor.Resources.white_default_tile.png"));

            chest_texture_stream     = (assembly.GetManifestResourceStream("XNA_Map_Editor.Resources.chest32.png"));
            NPC_texture_stream       = (assembly.GetManifestResourceStream("XNA_Map_Editor.Resources.NPC32.png"));
            monster_texture_stream   = (assembly.GetManifestResourceStream("XNA_Map_Editor.Resources.monster32.png"));
            block_texture_stream    = (assembly.GetManifestResourceStream("XNA_Map_Editor.Resources.block32.png"));
            switch_texture_stream   = (assembly.GetManifestResourceStream("XNA_Map_Editor.Resources.switch32.png"));

            xml_writer              = new XmlMapWriter(this);

            this.MouseWheel += new MouseEventHandler(this.xna_renderer_MouseWheel);            

            InitTerrainData();
            terrain_editor_form = new TerrainEditor(this);
            
            // combo box drawing events
            this.toolbar_terrain_combo.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.toolbar_terrain_combo.ComboBox.DrawItem += new DrawItemEventHandler(combo_terrain_DrawItem);

            // Tile Size editor
            frm_tile_size           = new TileSizeEditor();
            frm_tile_size.Visible   = false;
        }

        #endregion

        #region Properties

        public GraphicsDevice GraphicsDevice
        {
            get
            {
                return this.xna_renderer.GraphicsDevice;
            }
        }
        #endregion

        #region Control Events

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog_result = MessageBox.Show("Are you sure you want to exit the editor?", "XNA Map Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog_result == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;                
            }
        }

        private void xna_renderer_MouseWheel(object sender, MouseEventArgs e)
        {
            // check if tab_control is in map display tab
            // this prevents zooming when the map display does not have focus
            if (this.tab_control.SelectedIndex > 0)
            {
                return;
            }

            if (e.Delta < 0)
            {
                Camera.IncreaseZoom(xna_renderer.Width, xna_renderer.Height);
                InitScrollBars();
            }

            if (e.Delta > 0)
            {
                Camera.DecrementZoom();
                InitScrollBars();
            }

            if (Math.Abs(Camera.X) + (GLB_Data.MapSize.Width * Camera.ScaledTileSize) <= xna_renderer.Width)
            {
                Camera.X = 0;
            }

            if (Math.Abs(Camera.Y) + (GLB_Data.MapSize.Height * Camera.ScaledTileSize) <= xna_renderer.Height)
            {
                Camera.Y = 0;
            }

            Camera.Scroll(0, 0, xna_renderer.Width, xna_renderer.Height);
        }

        private void hscroll_xna_Scroll(object sender, ScrollEventArgs e)
        {            
            Camera.X = -e.NewValue;
            this.xna_renderer.Invalidate();
        }

        private void vscroll_xna_Scroll(object sender, ScrollEventArgs e)
        {
            Camera.Y = -e.NewValue;
            this.xna_renderer.Invalidate();
        }

        private void xna_renderer_MouseEnter(object sender, EventArgs e)
        {
            this.MouseOnMe = true;
            ChangeMouseCursor(GLB_Data.Brush);
        }

        private void xna_renderer_MouseLeave(object sender, EventArgs e)
        {
            this.MouseOnMe = false;
            this.Cursor = Cursors.Arrow;
        }

        private void xna_renderer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (GLB_Data.TilesTexture == null)
                {
                    return;
                }

                if (GLB_Data.Brush == PaintTool.MarqueeBrush || GLB_Data.Brush == PaintTool.MarqueeEraser || 
                    GLB_Data.Brush == PaintTool.MarqueeWalk  || GLB_Data.Brush == PaintTool.MarqueeTerrain)
                {
                    // Marquee is beign created, save initial point
                    GLB_Data.MarqueeSelection.Show = true;
                    GLB_Data.MarqueeSelection.InitialLocation = Camera.SystemPointTransform(e.Location);
                    return;
                }

                if (!ValidTileSelected() && 
                    GLB_Data.Brush != PaintTool.Walk &&
                    GLB_Data.Brush != PaintTool.Eraser &&
                    GLB_Data.Brush != PaintTool.Portal &&
                    GLB_Data.Brush != PaintTool.Chest &&
                    GLB_Data.Brush != PaintTool.NPC &&
                    GLB_Data.Brush != PaintTool.FixedCombat)
                {
                    // no selected tile
                    return;
                }

                XNA.Point bounds = Camera.Transform(e.Location);

                if (bounds.X > GLB_Data.MapSize.Width  * Camera.ScaledTileSize ||
                    bounds.Y > GLB_Data.MapSize.Height * Camera.ScaledTileSize || 
                    bounds.X < 0 || bounds.Y < 0)
                {
                    // out of bounds
                    return;
                }

                previous_location = e.Location;

                // Map is about to change , save current status
                undo_redo.AddUndoHistory();
                CheckUndoRedo();

                DoBrushLogic(sender, e);
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Right mouse button pressed, user is starting to do 
                // a map scroll operation.
                // Store the initial point of the Scroll

                //mouse_scroll_initial = Cursor.Position;


                XNA.Point selected_tile = HelperClass.TileSnapToGrid(Camera.WorldPosition(e.Location));
                

                //chests
                Chest selectedChest = new Chest();
                bool chestFound = false;

                foreach (Chest chest in GLB_Data.chests)
                {
                    if (chest.x == selected_tile.X && 
                        chest.y == selected_tile.Y)
                    {
                        selectedChest = chest;
                        chestFound = true;
                    }
                }

                if (chestFound)
                {
                    editChest = new EditChest(new System.Drawing.Point(e.X, e.Y), ref selectedChest);
                    editChest.ShowDialog();
                }


                //NPCs
                NPC selectedNPC = new NPC();
                bool NPCFound = false;

                foreach (NPC NPC in GLB_Data.npcs)
                {
                    if (NPC.x == selected_tile.X &&
                        NPC.y == selected_tile.Y)
                    {
                        selectedNPC = NPC;
                        NPCFound = true;
                    }
                }

                if (NPCFound)
                {
                    editNPC = new EditNPC(new System.Drawing.Point(e.X, e.Y), ref selectedNPC);
                    editNPC.ShowDialog();
                }



                //Monsters
                FixedCombatNPC selectedFixedCombatNPC = new FixedCombatNPC();
                bool FixedCombatNPCFound = false;

                foreach (FixedCombatNPC FixedCombatNPC in GLB_Data.fixedCombatNPCs)
                {
                    if (FixedCombatNPC.x == selected_tile.X &&
                        FixedCombatNPC.y == selected_tile.Y)
                    {
                        selectedFixedCombatNPC = FixedCombatNPC;
                        FixedCombatNPCFound = true;
                    }
                }

                if (FixedCombatNPCFound)
                {
                    //editMonster = new EditBlock(new System.Drawing.Point(e.X, e.Y), ref selectedFixedCombatNPC);
                    editMonster.ShowDialog();
                }

                //Blocks
                Block selectedBlock = new Block();
                bool BlockFound = false;

                foreach (Block Block in GLB_Data.blocks)
                {
                    if (Block.x == selected_tile.X &&
                        Block.y == selected_tile.Y)
                    {
                        selectedBlock = Block;
                        BlockFound = true;
                    }
                }

                if (BlockFound)
                {
                    editBlock = new EditBlock(new System.Drawing.Point(e.X, e.Y), ref selectedBlock);
                    editBlock.ShowDialog();
                }

                //Switches
                Switch selectedSwitch = new Switch();
                bool SwitchFound = false;

                foreach (Switch Switch in GLB_Data.switches)
                {
                    if (Switch.x == selected_tile.X &&
                        Switch.y == selected_tile.Y)
                    {
                        selectedSwitch = Switch;
                        SwitchFound = true;
                    }
                }

                if (SwitchFound)
                {
                    editSwitches = new EditSwitches(new System.Drawing.Point(e.X, e.Y), ref selectedSwitch);
                    editSwitches.ShowDialog();
                }
            }            
        }

        private void xna_renderer_MouseMove(object sender, MouseEventArgs e)
        {
            // Do not paint if mouse shoots out of the paint area no matter what
            if (e.X > xna_renderer.Width || e.Y > xna_renderer.Height)
            {
                return;
            }

            if (e.Button == MouseButtons.Right)
            {
                Cursor.Current     = Cursors.Hand;
                mouse_scroll_final = Cursor.Position;
                ScrollMap(); 
            }

            if (GLB_Data.Brush == PaintTool.MarqueeBrush || GLB_Data.Brush == PaintTool.MarqueeEraser || 
                GLB_Data.Brush == PaintTool.MarqueeWalk  || GLB_Data.Brush == PaintTool.MarqueeTerrain)
            {
                int aux_x = e.Location.X;
                int aux_y = e.Location.Y;

                if (e.Location.X > GLB_Data.MapSize.Width * Camera.ScaledTileSize)
                {
                    aux_x = GLB_Data.MapSize.Width * Camera.ScaledTileSize;
                }

                if (e.Location.X < 0)
                {
                    aux_x = 0;
                }

                if (e.Location.Y > GLB_Data.MapSize.Height * Camera.ScaledTileSize)
                {
                    aux_y = GLB_Data.MapSize.Height * Camera.ScaledTileSize;
                }

                if (e.Location.Y < 0)
                {
                    aux_y = 0;
                }

                System.Drawing.Point aux_point = new System.Drawing.Point(aux_x, aux_y);

                // Mouse moving set its location as last position in marquee rectangle
                GLB_Data.MarqueeSelection.FinalLocation = Camera.SystemPointTransform(aux_point);

                TrimMarqueeSelection();

                return;
            }



            if (e.Button == MouseButtons.Left && !HelperClass.SameSelectedCell(e.Location) && GLB_Data.TilesTexture != null)
            {
                if (HelperClass.SnapToGrid(previous_location) == HelperClass.SnapToGrid(e.Location))
                {
                    // same cell 
                    return;
                }
                else
                {
                    xna_renderer_MouseDown(sender, e);
                }
            }
        }

        private void TrimMarqueeSelection()
        {
            if (GLB_Data.MarqueeSelection.FinalLocation.X > GLB_Data.MapSize.Width * Camera.ScaledTileSize)
            {
                GLB_Data.MarqueeSelection.FinalLocation.X = GLB_Data.MapSize.Width * Camera.ScaledTileSize;
            }

            if (GLB_Data.MarqueeSelection.FinalLocation.Y > GLB_Data.MapSize.Height * Camera.ScaledTileSize)
            {
                GLB_Data.MarqueeSelection.FinalLocation.Y = GLB_Data.MapSize.Height * Camera.ScaledTileSize;
            }
        }

        private void xna_renderer_MouseUp(object sender, MouseEventArgs e)
        {
            if ( GLB_Data.Brush == PaintTool.MarqueeBrush && GLB_Data.TilesTexture != null && e.Button == MouseButtons.Left)
            {
                // Mouse moving set its location as last position in marquee rectangle
                GLB_Data.MarqueeSelection.FinalLocation = e.Location;

                TrimMarqueeSelection();

                // Map is about to change , save current status
                undo_redo.AddUndoHistory();
                CheckUndoRedo();

                DoBrushLogic(sender, e);

                //Marquee Selection finsihed
                GLB_Data.MarqueeSelection.Show = false;
            }

            if (GLB_Data.Brush == PaintTool.MarqueeEraser && GLB_Data.TilesTexture != null && e.Button == MouseButtons.Left)
            {
                // Mouse moving set its location as last position in marquee rectangle
                GLB_Data.MarqueeSelection.FinalLocation = e.Location;

                TrimMarqueeSelection();

                // Map is about to change , save current status
                undo_redo.AddUndoHistory();
                CheckUndoRedo();

                DoBrushLogic(sender, e);

                //Marquee Selection finsihed
                GLB_Data.MarqueeSelection.Show = false;
            }

            if (GLB_Data.Brush == PaintTool.MarqueeWalk && GLB_Data.TilesTexture != null && e.Button == MouseButtons.Left)
            {
                // Mouse moving set its location as last position in marquee rectangle
                GLB_Data.MarqueeSelection.FinalLocation = e.Location;

                TrimMarqueeSelection();

                // Map is about to change , save current status
                undo_redo.AddUndoHistory();
                CheckUndoRedo();

                DoBrushLogic(sender, e);

                //Marquee Selection finsihed
                GLB_Data.MarqueeSelection.Show = false;
            }

            if (GLB_Data.Brush == PaintTool.MarqueeTerrain && GLB_Data.TilesTexture != null && e.Button == MouseButtons.Left)
            {
                // Mouse moving set its location as last position in marquee rectangle
                GLB_Data.MarqueeSelection.FinalLocation = e.Location;

                TrimMarqueeSelection();

                // Map is about to change , save current status
                undo_redo.AddUndoHistory();
                CheckUndoRedo();

                DoBrushLogic(sender, e);

                //Marquee Selection finsihed
                GLB_Data.MarqueeSelection.Show = false;
            }

            if (GLB_Data.Brush == PaintTool.MarqueeWalk)
            {

                XNA.Rectangle r = new XNA.Rectangle(
                GLB_Data.MarqueeSelection.InitialTile.X,
                GLB_Data.MarqueeSelection.InitialTile.Y,
                GLB_Data.MarqueeSelection.Width,
                GLB_Data.MarqueeSelection.Height);

                int rType = 0;

                if ((Control.ModifierKeys & System.Windows.Forms.Keys.Shift) != 0)
                    rType = 2;
                else if (Keyboard.GetState().IsKeyDown(XNA.Input.Keys.Q))
                    rType = 6;
                else if (Keyboard.GetState().IsKeyDown(XNA.Input.Keys.E))
                    rType = 5;

                bool hit = false;
                int hitIndex = -1;

                for(int i=0; i<GLB_Data.marqueeHist.Count; i++)
                {
                    if (r.Intersects(GLB_Data.marqueeHist[i]))
                    {
                        hit = true;
                        hitIndex = i;
                    }
                }

                if (hit)
                {
                    GLB_Data.marqueeHist.RemoveAt(hitIndex);
                    GLB_Data.marqueeHistType.RemoveAt(hitIndex);
                }
                else
                {
                    GLB_Data.marqueeHist.Add(r);
                    GLB_Data.marqueeHistType.Add(rType);
                }


            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.InitScrollBars();
        }

        private void tab_control_Click(object sender, EventArgs e)
        {
            this.xml_writer.Update();
        }

        private void combo_terrain_DrawItem(object sender, DrawItemEventArgs e)
        {
            #region OldCode

            TerrainType terrain;
            try
            {
                terrain = (TerrainType)((ComboBox)sender).Items[e.Index];
            }
            catch
            {
                return;
            }


            using (Brush brush = new SolidBrush(terrain.Color))
            {

                e.Graphics.FillRectangle(brush, new GDI.Rectangle(e.Bounds.Location, new Size(e.Bounds.Height, e.Bounds.Height)));

            }

            using (Brush brush = new SolidBrush(GDI.Color.Black))
            {

                e.Graphics.DrawString(terrain.ToString(), e.Font, brush, e.Bounds);

            }

            e.DrawFocusRectangle();

            #endregion
        }

        #endregion

        #region Private Methods

        private void InitTerrainData()
        {
            GLB_Data.TerrainList = new ArrayList(Constants.MAX_TERRAINS);

            for (int id_x = 0; id_x < GLB_Data.TerrainLayout.GetLength(0); id_x++)
            {
                for (int id_y = 0; id_y < GLB_Data.TerrainLayout.GetLength(1); id_y++)
                {
                    GLB_Data.TerrainLayout[id_x, id_y] = Constants.TERRAIN_NORMAL;
                }
            } 

            // Init Combo draw properties            
            
        }

        private void ScrollMap()
        {
            // find the amount that the mouse has traveled (in each axis)
            int distance_x = mouse_scroll_final.X - mouse_scroll_initial.X;
            int distance_y = mouse_scroll_final.Y - mouse_scroll_initial.Y;

            mouse_scroll_initial = mouse_scroll_final;

            Camera.Scroll(distance_x, distance_y, xna_renderer.Width, xna_renderer.Height);
            
            // add the values to the scrollbars

            if (hscroll_xna.Visible)
            {
                if (-distance_x + hscroll_xna.Value < hscroll_xna.Minimum)
                {
                    hscroll_xna.Value = hscroll_xna.Minimum;
                }
                else if (-distance_x + hscroll_xna.Value > hscroll_xna.Maximum)
                {
                    hscroll_xna.Value = hscroll_xna.Maximum;
                }
                else
                {
                    hscroll_xna.Value += -distance_x;
                }
            }

            if (vscroll_xna.Visible)
            {
                if (-distance_y + vscroll_xna.Value < vscroll_xna.Minimum)
                {
                    vscroll_xna.Value = vscroll_xna.Minimum;
                }
                else if (-distance_y + vscroll_xna.Value > vscroll_xna.Maximum)
                {
                    vscroll_xna.Value = vscroll_xna.Maximum;
                }
                else
                {
                    vscroll_xna.Value += -distance_y;
                }
            }
        }

        internal void CheckUndoRedo()
        {
            EnableUndo();
            EnableRedo();
        }

        internal void ClearUndoRedo()
        {
            this.undo_redo.Clear();
        }

        private void ResetSelectedTiles()
        {
            GLB_Data.SelectedTiles = new Tile[1, 1];
            GLB_Data.SelectedTiles[0, 0].id       = Constants.NULL_TILE;
            GLB_Data.SelectedTiles[0, 0].walkable = true;
            tile_palette.ClearSelection();
        }

        public void ShowCurrentLayer()
        {
            toolbar_lbl_layer.Text = Convert.ToString(GLB_Data.SelectedLayer + 1) + "/" + GLB_Data.MapSize.Depth.ToString();
        }

        private int GetWalkLayer()
        {
            return GLB_Data.TileMap.GetLength(0) - 1;
        }

        public void InitTileMap()
        {
            GLB_Data.portals = new List<Portal>();
            GLB_Data.portalIndex = 0;
            GLB_Data.destinations = new List<PortalDestination>();
            GLB_Data.chests = new List<Chest>();
            GLB_Data.fixedCombatNPCs = new List<FixedCombatNPC>();
            GLB_Data.npcs = new List<NPC>();
            GLB_Data.blocks = new List<Block>();
            GLB_Data.switches = new List<Switch>();

            for (int id_z = 0; id_z < GLB_Data.MapSize.Depth + 1; id_z++) // all depth layers including walk layer, to avoid bugs :)
            {
                for (int id_y = 0; id_y < GLB_Data.MapSize.Height; id_y++)
                {
                    for (int id_x = 0; id_x < GLB_Data.MapSize.Width; id_x++)
                    {
                        GLB_Data.TileMap[id_z, id_x, id_y].id                 = Constants.NULL_TILE;
                        GLB_Data.TileMap[id_z, id_x, id_y].grid_location      = new XNA.Point(id_x, id_y);                        
                        // init walk layer
                        GLB_Data.TileMap[GetWalkLayer(), id_x, id_y].walkable = true;
                    }
                }
            }

            // Init Terrain Layout
            for (int id_y = 0; id_y < GLB_Data.MapSize.Height; id_y++)
            {
                for (int id_x = 0; id_x < GLB_Data.MapSize.Width; id_x++)
                {
                    GLB_Data.TerrainLayout[id_x, id_y] = Constants.TERRAIN_NORMAL;
                }
            }
  
            ResetLayers();
        }

        internal void InitScrollBars()
        {
            if (GLB_Data.MapSize.Width * Camera.ScaledTileSize > xna_renderer.Width)
            {
                // Enable Horizontal Bar
                this.hscroll_xna.Visible = true;

                // Set minimum and maximum values (not in pixels)
                hscroll_xna.Minimum = 0;
                hscroll_xna.Maximum = GLB_Data.MapSize.Width * Camera.ScaledTileSize - xna_renderer.Width;
            }
            else
            {
                this.hscroll_xna.Visible = false;
                this.hscroll_xna.Value = 0;
            }            

            if (GLB_Data.MapSize.Height * Camera.ScaledTileSize > xna_renderer.Height)
            {
                // Enable Vertical Bar
                this.vscroll_xna.Visible = true;

                // Set minimum and maximum values (not in pixels)
                vscroll_xna.Minimum = 0;
                vscroll_xna.Maximum = GLB_Data.MapSize.Height * Camera.ScaledTileSize - xna_renderer.Height;
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

        private void EnableUndo()
        {
            if (!undo_redo.CanUndo())
            {
                undoToolStripMenuItem.Enabled = false;
                toolbar_undo.Enabled          = false;
            }
            else
            {
                undoToolStripMenuItem.Enabled = true;
                toolbar_undo.Enabled          = true;
            }
        }

        private void DoUndo()
        {
            if (undo_redo.CanUndo())
            {
                undo_redo.Undo();
                CheckUndoRedo();                
            }
        }

        private void EnableRedo()
        {
            if (!undo_redo.CanRedo())
            {
                redoToolStripMenuItem.Enabled = false;
                toolbar_redo.Enabled          = false;
            }
            else
            {
                redoToolStripMenuItem.Enabled = true;
                toolbar_redo.Enabled          = true;
            }
        }

        private void DoRedo()
        {
            if (undo_redo.CanRedo())
            {
                undo_redo.Redo();
                CheckUndoRedo();
            }
        }

        private void InitLoadTilesDialog()
        {
          load_tiles_dialog                     = new OpenFileDialog();
          load_tiles_dialog.InitialDirectory    = Environment.CurrentDirectory + @"\Tiles";
          load_tiles_dialog.Filter              = "Image files (*.img *.jpg *.png *.bmp)|*.img; *.jpg; *.png; *.bmp|All Files (*.*)| *.*";
          load_tiles_dialog.Title               = "Load tiles";
        }

        private void InitLoadMapDialog()
        {
            load_map_dialog = new OpenFileDialog();
            load_map_dialog.InitialDirectory = Environment.CurrentDirectory + @"\Maps";
            //load_map_dialog.Filter = "XNA Map Editor TileMaps (*.xmap) | *.xmap";
            load_map_dialog.Filter = "XNA Map Editor TileMaps (*.xml) | *.xml";
            load_map_dialog.Title = "Load TileMap";

        }

        private void InitSaveMapDialog()
        {
            save_map_dialog                     = new SaveFileDialog();
            save_map_dialog.InitialDirectory    = Environment.CurrentDirectory + @"\Maps";
            //save_map_dialog.Filter              = "XNA Map Editor TileMaps (*.xmap) | *.xmap";
            save_map_dialog.Filter              = "XNA Map Editor TileMaps (*.xml) | *.xml";
            save_map_dialog.Title               = "Save TileMap";

        }

        internal void SetSelectedTile(Tile SelectedTile, System.Drawing.Rectangle SelectedArea)
        {
            GLB_Data.SelectedTiles = new Tile[1, 1];

            GLB_Data.SelectedTiles[0, 0].grid_location  = SelectedTile.grid_location;
            GLB_Data.SelectedTiles[0, 0].id             = SelectedTile.id;
            GLB_Data.SelectedTiles[0, 0].walkable       = SelectedTile.walkable;

            this.SetSelectedTile(GLB_Data.SelectedTiles, SelectedArea);
        }

        internal void SetSelectedTile(Tile[,] SelectedTiles, System.Drawing.Rectangle SelectedArea)
        {
            GLB_Data.SelectedTiles = new Tile[SelectedTiles.GetLength(0), SelectedTiles.GetLength(1)];

            // Copy all the selected tiles
            for (int id_y = 0; id_y < SelectedTiles.GetLength(1); id_y++)
            {
                for (int id_x = 0; id_x < SelectedTiles.GetLength(0); id_x++)
                {
                    GLB_Data.SelectedTiles[id_x, id_y].grid_location    = SelectedTiles[id_x, id_y].grid_location;
                    GLB_Data.SelectedTiles[id_x, id_y].id               = SelectedTiles[id_x, id_y].id;
                    GLB_Data.SelectedTiles[id_x, id_y].walkable         = SelectedTiles[id_x, id_y].walkable;
                }
            }
        }

        private bool ValidTileSelected()
        {
            // added more security
            if (GLB_Data.SelectedTiles == null || GLB_Data.SelectedTiles.GetLength(0) == 0 || GLB_Data.SelectedTiles.GetLength(1) == 0)
            {
                return false;
            }

            if (GLB_Data.SelectedTiles[0, 0].id == Constants.NULL_TILE)
            {
                return false;
            }
            else
            {
                return true;
            }
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
            GLB_Data.SelectedLayer = Constants.BASE_LAYER;
            this.ShowCurrentLayer();
        }

        private void GenerateTexture()
        {
            TextureGenerator form_texture = new TextureGenerator();

            form_texture.ShowDialog();
        }

        private void ApplyCollisionTemplate()
        {
            // Map is about to change , save current status
            undo_redo.AddUndoHistory();
            CheckUndoRedo();

            // Travel the whole map grid - this is a costly operation on larger maps
            for (int id_z = 0; id_z < GLB_Data.MapSize.Depth; id_z++)
            {
                for (int id_y = 0; id_y < GLB_Data.MapSize.Height; id_y++)
                {
                    for (int id_x = 0; id_x < GLB_Data.MapSize.Width; id_x++)
                    {
                        // for easy reading
                        int tile_palette_x = GLB_Data.TileMap[id_z, id_x, id_y].texture_location.X;
                        int tile_palette_y = GLB_Data.TileMap[id_z, id_x, id_y].texture_location.Y;

                        if (GLB_Data.TileMap[id_z, id_x, id_y].id == GLB_Data.TilePalette[tile_palette_x, tile_palette_y].id)
                        {
                            GLB_Data.TileMap[GetWalkLayer(), id_x, id_y].walkable = GLB_Data.TilePalette[tile_palette_x, tile_palette_y].walkable;
                        }
                    }
                }
            }
        }

        private void DeleteSelectedLayer()
        {
            // Map is about to change , save current status
            undo_redo.AddUndoHistory();
            CheckUndoRedo();

            for (int id_y = 0; id_y < GLB_Data.MapSize.Height; id_y++)
            {
                for (int id_x = 0; id_x < GLB_Data.MapSize.Width; id_x++)
                {
                    GLB_Data.TileMap[GLB_Data.SelectedLayer, id_x, id_y].id = Constants.NULL_TILE;
                }
            }
        }

        #endregion

    }// MainForm

}// Namespace
