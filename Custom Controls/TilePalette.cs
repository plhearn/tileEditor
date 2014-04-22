using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using XNA_Map_Editor.Classes;
using XNA_Map_Editor.Helpers;
using XNA = Microsoft.Xna.Framework;
using XNAGraphics = Microsoft.Xna.Framework.Graphics;

namespace XNA_Map_Editor
{
    // Custom Control
    class TilePalette : Panel
    {
        MainForm parent_form;

        // Graphics object 
        Pen pen_grid;
        Pen pen_highlight_a;
        Pen pen_highlight_b;
        Pen pen_blocked;

        // Class Fields
       
        public Image img_tile_set;
        static Rectangle selected_area;
        Boolean marquee_selection;

        Rectangle start_rectangle;
        Rectangle end_rectangle;
        ///////////////////////////////////////////////////////////////////////////
        // Constructor
        // Default Constructor
        ///////////////////////////////////////////////////////////////////////////
        public TilePalette()
        {
            this.Init();
        }

        // Overload Constructor
        public TilePalette(MainForm ParentForm)
        {
            parent_form = (MainForm)ParentForm;

            this.Init();
        }


        // Overload Constructor
        public TilePalette(ManagePortals ParentForm)
        {
            //parent_form = (ManagePortals)ParentForm;

            this.Init();
        }

        ///////////////////////////////////////////////////////////////////////////
        // Init() 
        // Initializes the tilepalette's data fields
        ///////////////////////////////////////////////////////////////////////////
        private void Init()
        {
            this.AutoScroll     = true;
            this.DoubleBuffered = true;

            // Init pen objects
            pen_grid            = new Pen(Color.Black,   1.0f);
            pen_highlight_a     = new Pen(Color.Fuchsia, 4.0f);
            pen_highlight_b     = new Pen(Color.White,   0.5f);
            pen_blocked         = new Pen(Color.Red,     1.0f);

        }//Init()


        ///////////////////////////////////////////////////////////////////////////
        // WINDOWS EVENTS
        // BEGIN
        ///////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////
        // PAINT
        // 
        ///////////////////////////////////////////////////////////////////////////
        protected override void OnPaint(PaintEventArgs e)
        {

            if (img_tile_set == null)
            {
                return;
            }

            if (img_tile_set != null)
            {
                e.Graphics.DrawImage(img_tile_set, 0, 0, img_tile_set.Width, img_tile_set.Height );
            }

            // Grid paint
            for (int id_y = 0; id_y < img_tile_set.Height; id_y += GLB_Data.MapSize.TileSize)
            {
                e.Graphics.DrawLine(pen_grid, new Point(0, id_y), new Point(img_tile_set.Width, id_y));
            }
            for (int id_x = 0; id_x < img_tile_set.Width; id_x += GLB_Data.MapSize.TileSize)
            {
                e.Graphics.DrawLine(pen_grid, new Point(id_x, 0), new Point(id_x, img_tile_set.Height));
            }

            // Draw non walkable highlight
            for (int id_y = 0; id_y < GLB_Data.TilePalette.GetLength(1); id_y++)
            {
                for (int id_x = 0; id_x < GLB_Data.TilePalette.GetLength(0); id_x++)
                {
                    if (GLB_Data.TilePalette[id_x, id_y].walkable == false)
                    {
                        // This could go on a helper class
                        e.Graphics.DrawRectangle(pen_blocked, new Rectangle(id_x * GLB_Data.MapSize.TileSize, id_y * GLB_Data.MapSize.TileSize, GLB_Data.MapSize.TileSize, GLB_Data.MapSize.TileSize));
                        e.Graphics.DrawLine(pen_blocked, new Point(id_x * GLB_Data.MapSize.TileSize, id_y * GLB_Data.MapSize.TileSize), new Point(id_x * GLB_Data.MapSize.TileSize + GLB_Data.MapSize.TileSize, id_y * GLB_Data.MapSize.TileSize + GLB_Data.MapSize.TileSize));
                        e.Graphics.DrawLine(pen_blocked, new Point(id_x * GLB_Data.MapSize.TileSize, id_y * GLB_Data.MapSize.TileSize + GLB_Data.MapSize.TileSize), new Point(id_x * GLB_Data.MapSize.TileSize + GLB_Data.MapSize.TileSize, id_y * GLB_Data.MapSize.TileSize));
                    }
                }
            }

            if (selected_area.Width == 0 || selected_area != null)
            {
                // Draw highlighted cell
                e.Graphics.DrawRectangle(pen_highlight_a, selected_area);
                e.Graphics.DrawRectangle(pen_highlight_b, selected_area);
            }

            base.OnPaint(e);
        }



        ///////////////////////////////////////////////////////////////////////////
        // MOUSE MOVE
        // 
        ///////////////////////////////////////////////////////////////////////////
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (img_tile_set == null)
            {
                // No need to check anything yet
                return;
            }

            Rectangle aux_rect = GetSelectedCell(e.Location);
            try
            {
                Tile aux_tile = GLB_Data.TilePalette[aux_rect.X / GLB_Data.MapSize.TileSize, aux_rect.Y / GLB_Data.MapSize.TileSize];
            }
            catch
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                marquee_selection = true;
                end_rectangle = GetSelectedCell(e.Location);

                selected_area = CreateMarqueeArea(start_rectangle, end_rectangle);
            }
            else
            {
                return;
            }

            this.Invalidate(true);

        }

        ///////////////////////////////////////////////////////////////////////////
        // MOUSE DOWN
        // 
        ///////////////////////////////////////////////////////////////////////////
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (GLB_Data.TilesTexture == null || GLB_Data.TextureFileName == "")
            {
                return;
            }

            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                marquee_selection = false;
            }

            start_rectangle         = GetSelectedCell(e.Location);
            Rectangle aux_rect      = GetSelectedCell(e.Location);
            Tile aux_tile           = GLB_Data.TilePalette[aux_rect.X / GLB_Data.MapSize.TileSize, aux_rect.Y / GLB_Data.MapSize.TileSize];


            //  Set selected tile
            parent_form.SetSelectedTile(aux_tile, aux_rect);
            selected_area = aux_rect;

            this.Invalidate(true);
        }

        ///////////////////////////////////////////////////////////////////////////
        // MOUSE UP
        // 
        ///////////////////////////////////////////////////////////////////////////
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (marquee_selection)
            {

                if (selected_area.Width == GLB_Data.MapSize.TileSize && selected_area.Height == GLB_Data.MapSize.TileSize)
                {
                    marquee_selection = false;
                    return;
                }
                //Make the the selected tiles one single selection object
                Tile[,] selected_tiles = new Tile[selected_area.Width / GLB_Data.MapSize.TileSize, selected_area.Height / GLB_Data.MapSize.TileSize];

                // Load the selected tiles data
                for (int id_y = 0; id_y < selected_area.Height / GLB_Data.MapSize.TileSize; id_y++)
                {
                    for (int id_x = 0; id_x < selected_area.Width / GLB_Data.MapSize.TileSize; id_x++)
                    {
                        selected_tiles[id_x, id_y] = GLB_Data.TilePalette[(selected_area.X + (id_x * GLB_Data.MapSize.TileSize)) / GLB_Data.MapSize.TileSize, (selected_area.Y + (id_y * GLB_Data.MapSize.TileSize)) / GLB_Data.MapSize.TileSize];
                    }
                }

                parent_form.SetSelectedTile(selected_tiles, selected_area);
            }
        }
        ///////////////////////////////////////////////////////////////////////////
        // WINDOWS EVENTS
        // END
        ///////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////
        // CreateMarqueeArea()
        // Creates a rectangle which holds the area that the mouse is currently dragging
        ///////////////////////////////////////////////////////////////////////////
        private Rectangle CreateMarqueeArea(Rectangle RectangleA, Rectangle RectangleB)
        {
            Int32 min_size      = GLB_Data.MapSize.TileSize;
            Size rect_size      = new Size();
            Point top_point     = new Point();
            Point bottom_point  = new Point();

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
                rect_size.Width = GLB_Data.MapSize.TileSize;
            }

            if (rect_size.Height == 0)
            {
                rect_size.Height = GLB_Data.MapSize.TileSize;
            }

            return new Rectangle(top_point, rect_size);

        }//CreateMarqueeArea()

        ///////////////////////////////////////////////////////////////////////////
        //  
        // DISPOSE 
        ///////////////////////////////////////////////////////////////////////////
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose pens
                if (pen_grid != null)
                {
                    pen_grid.Dispose();
                }
                if (pen_highlight_a != null)
                {
                    pen_highlight_a.Dispose();
                }
                if (pen_highlight_b != null)
                {
                    pen_highlight_b.Dispose();
                }
            }
        }// Dispose()


        ///////////////////////////////////////////////////////////////////////////
        // SetImage()
        // Displays the loaded image into the TilePalette area
        ///////////////////////////////////////////////////////////////////////////
        public void SetImage(string FileName)
        {
            img_tile_set            = null;
            img_tile_set            = Image.FromFile(FileName);
            this.MinimumSize        = new Size((img_tile_set.Width / GLB_Data.MapSize.TileSize) * GLB_Data.MapSize.TileSize, (img_tile_set.Height / GLB_Data.MapSize.TileSize) * GLB_Data.MapSize.TileSize);
            this.Size               = this.MinimumSize;
            GLB_Data.TilePalette    = new Tile[img_tile_set.Width / GLB_Data.MapSize.TileSize, img_tile_set.Height / GLB_Data.MapSize.TileSize];            

            this.InitTileData();
        }//SetImage()

        ///////////////////////////////////////////////////////////////////////////
        // TODO: Add proper coomments and function naming, add proper function calls
        //       and fix tile resize function so it does not erases collision templates
        ///////////////////////////////////////////////////////////////////////////

        internal void SetImage()
        {
            this.MinimumSize    = new Size((img_tile_set.Width / GLB_Data.MapSize.TileSize) * GLB_Data.MapSize.TileSize, (img_tile_set.Height / GLB_Data.MapSize.TileSize) * GLB_Data.MapSize.TileSize);
            this.Size           = this.MinimumSize;
            GLB_Data.TilePalette = new Tile[img_tile_set.Width / GLB_Data.MapSize.TileSize, img_tile_set.Height / GLB_Data.MapSize.TileSize];

            this.InitTileData();

        }

        ///////////////////////////////////////////////////////////////////////////
        // ResizeControl()
        // Resizes the current TilePalette area to conform with the current TilSize
        ///////////////////////////////////////////////////////////////////////////
        public void ResizeControl()
        {
            if (img_tile_set == null)
            {
                return;
            }

            this.MinimumSize = new Size((img_tile_set.Width / GLB_Data.MapSize.TileSize) * GLB_Data.MapSize.TileSize, (img_tile_set.Height / GLB_Data.MapSize.TileSize) * GLB_Data.MapSize.TileSize);
            this.Size = this.MinimumSize;
            this.Invalidate();
        }


        /////////////////////////////////////////////////////////////////////////////////////////
        // SetImage(FileName, WalkData)
        // Overloaded method, creates the new tile palette but recovers loaded walk palette data
        /////////////////////////////////////////////////////////////////////////////////////////
        internal void SetImage(string FileName, Tile[,] WalkData)
        {
            this.SetImage(FileName);

            for (int id_y = 0; id_y < WalkData.GetLength(1); id_y++)
            {
                for (int id_x = 0; id_x < WalkData.GetLength(0); id_x++)
                {
                    GLB_Data.TilePalette[id_x, id_y].walkable = WalkData[id_x, id_y].walkable;
                }
            }

        }//SetImage()

        ///////////////////////////////////////////////////////////////////////////
        // InitTileData()
        // Initializes the TilePalette tilearray data
        ///////////////////////////////////////////////////////////////////////////
        private void InitTileData()
        {
            int tile_id = 0;

            for (int id_y = 0; id_y < img_tile_set.Height / GLB_Data.MapSize.TileSize; id_y++)
            {
                for (int id_x = 0; id_x < img_tile_set.Width / GLB_Data.MapSize.TileSize; id_x++)
                {
                    tile_id++;

                    GLB_Data.TilePalette[id_x, id_y].id             = tile_id;
                    GLB_Data.TilePalette[id_x, id_y].walkable       = true;
                    GLB_Data.TilePalette[id_x, id_y].grid_location  = new XNA.Point(id_x, id_y);
                }
            }

        }// InitTileData()


        ///////////////////////////////////////////////////////////////////////////
        // SetWalkable
        // Sets the selected tile walkable flag to the desired value
        ///////////////////////////////////////////////////////////////////////////
        public void SetWalkable(Boolean Value)
        {
            //Make the the selected tiles one single selection object
            Tile[,] selected_tiles = new Tile[selected_area.Width / GLB_Data.MapSize.TileSize, selected_area.Height / GLB_Data.MapSize.TileSize];

            // Load the selected tiles data
            for (int id_y = 0; id_y < selected_area.Height / GLB_Data.MapSize.TileSize; id_y++)
            {
                for (int id_x = 0; id_x < selected_area.Width / GLB_Data.MapSize.TileSize; id_x++)
                {
                    GLB_Data.TilePalette[(selected_area.X + (id_x * GLB_Data.MapSize.TileSize)) / GLB_Data.MapSize.TileSize, (selected_area.Y + (id_y * GLB_Data.MapSize.TileSize)) / GLB_Data.MapSize.TileSize].walkable = Value;
                    selected_tiles[id_x, id_y] = GLB_Data.TilePalette[(selected_area.X + (id_x * GLB_Data.MapSize.TileSize)) / GLB_Data.MapSize.TileSize, (selected_area.Y + (id_y * GLB_Data.MapSize.TileSize)) / GLB_Data.MapSize.TileSize];
                }
            }

           parent_form.SetSelectedTile(selected_tiles, selected_area);

            this.Invalidate();
        }//SetWalkable()



        ///////////////////////////////////////////////////////////////////////////
        // ClearSelection()
        // 
        ///////////////////////////////////////////////////////////////////////////
        internal void ClearSelection()
        {
            selected_area = new Rectangle(0, 0, 0, 0);

        }//ClearSelection()


        ///////////////////////////////////////////////////////////////////////////
        // GetSelectedCell()
        // Returns the tile that owns the given XY coordinates 
        // Returns a 0px. wide rectangle when not found
        ///////////////////////////////////////////////////////////////////////////
        public static Rectangle GetSelectedCell(Point Location)
        {
            if (GLB_Data.TilesTexture == null)
            {
                return new Rectangle(0, 0, 0, 0);
            }

            for (int id_y = 0; id_y < GLB_Data.TilesTexture.Height * GLB_Data.MapSize.TileSize; id_y += GLB_Data.MapSize.TileSize)
            {
                for (int id_x = 0; id_x < GLB_Data.TilesTexture.Width * GLB_Data.MapSize.TileSize; id_x += GLB_Data.MapSize.TileSize)
                {
                    if ((Location.X >= id_x && Location.X <= id_x + GLB_Data.MapSize.TileSize) &&
                        (Location.Y >= id_y && Location.Y <= id_y + GLB_Data.MapSize.TileSize))
                    {
                        // FOUND                        
                        return new Rectangle(new Point(id_x, id_y), new Size(GLB_Data.MapSize.TileSize, GLB_Data.MapSize.TileSize));
                    }
                }
            }

            // NOT FOUND
            return new Rectangle(0, 0, 0, 0);
        }//GetSelectedCell()



    }//TilePalette


}//Namespace
