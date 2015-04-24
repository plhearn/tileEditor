using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using XNA = Microsoft.Xna.Framework;
using XNAGraphics = Microsoft.Xna.Framework.Graphics;

using XNA_Map_Editor.Classes;

namespace XNA_Map_Editor.Helpers
{
    static public class HelperClass
    {
        static Point last_cell_position;

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

            for (int id_y = 0; id_y < GLB_Data.TilesTexture.Height * Camera.ScaledTileSize; id_y += Camera.ScaledTileSize)
            {
                for (int id_x = 0; id_x < GLB_Data.TilesTexture.Width * Camera.ScaledTileSize; id_x += Camera.ScaledTileSize)
                {
                    if ((Location.X >= id_x && Location.X <= id_x + Camera.ScaledTileSize) &&
                        (Location.Y >= id_y && Location.Y <= id_y + Camera.ScaledTileSize))
                    {
                        // FOUND                        
                        return new Rectangle(new Point(id_x, id_y), new Size(Camera.ScaledTileSize, Camera.ScaledTileSize));
                    }
                }
            }

            // NOT FOUND
            return new Rectangle(0, 0, 0, 0);
        }//GetSelectedCell()

        ///////////////////////////////////////////////////////////////////////////
        // SnapToGrid()
        //  
        //  
        ///////////////////////////////////////////////////////////////////////////
        internal static Rectangle SnapToGrid(Point Location)
        {
            for (int id_y = 0; id_y < GLB_Data.MapSize.Height * Camera.ScaledTileSize; id_y += Camera.ScaledTileSize)
            {
                for (int id_x = 0; id_x < GLB_Data.MapSize.Width * Camera.ScaledTileSize; id_x += Camera.ScaledTileSize)
                {
                    if ((Location.X >= id_x && Location.X <= id_x + Camera.ScaledTileSize) &&
                        (Location.Y >= id_y && Location.Y <= id_y + Camera.ScaledTileSize))
                    {
                        // FOUND
                        Rectangle aux_rectangle = new Rectangle(new Point(id_x, id_y), new Size(Camera.ScaledTileSize, Camera.ScaledTileSize));
                        return aux_rectangle;
                    }
                }
            }

            // NOT FOUND
            return new Rectangle(0, 0, 0, 0);
        }

        ///////////////////////////////////////////////////////////////////////////
        // GetSelectedPoint()
        //  
        //  
        ///////////////////////////////////////////////////////////////////////////
        internal static Microsoft.Xna.Framework.Point GetSelectedPoint(Point Location)
        {
            for (int id_y = 0; id_y < GLB_Data.MapSize.Height * Camera.ScaledTileSize; id_y += Camera.ScaledTileSize)
            {
                for (int id_x = 0; id_x < GLB_Data.MapSize.Width * Camera.ScaledTileSize; id_x += Camera.ScaledTileSize)
                {
                    if ((Location.X >= id_x && Location.X <= id_x + Camera.ScaledTileSize) &&
                        (Location.Y >= id_y && Location.Y <= id_y + Camera.ScaledTileSize))
                    {
                        // FOUND                       
                        return new XNA.Point(id_x, id_y);
                    }
                }
            }

            // NOT FOUND
            return new XNA.Point();
        }


        ///////////////////////////////////////////////////////////////////////////
        // SameSelectedCell()
        // Checks if mouse is in the last cell or has moved to a new one
        // Returns true if yes , false otherwise
        ///////////////////////////////////////////////////////////////////////////
        internal static bool SameSelectedCell(Point Location)
        {

            XNA.Point aux_point = new XNA.Point(Location.X, Location.Y);

            if (GetWorldSelectedCell(last_cell_position) == GetWorldSelectedCell(Location))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ///////////////////////////////////////////////////////////////////////////
        // GetWorldSelectedCell()
        // Returns the tile that owns the given XY coordinates 
        // Returns a 0px. wide rectangle when not found
        ///////////////////////////////////////////////////////////////////////////
        public static Rectangle GetWorldSelectedCell(Point Location)
        {
            if (GLB_Data.TilesTexture == null)
            {
                return new Rectangle(0, 0, 0, 0);
            }

            for (int id_y = 0; id_y < GLB_Data.MapSize.Height * Camera.ScaledTileSize; id_y += Camera.ScaledTileSize)
            {
                for (int id_x = 0; id_x < GLB_Data.MapSize.Width * Camera.ScaledTileSize; id_x += Camera.ScaledTileSize)
                {
                    if ((Location.X >= id_x && Location.X <= id_x + Camera.ScaledTileSize) &&
                        (Location.Y >= id_y && Location.Y <= id_y + Camera.ScaledTileSize))
                    {
                        // FOUND                        
                        return new Rectangle(new Point(id_x, id_y), new Size(Camera.ScaledTileSize, Camera.ScaledTileSize));
                    }
                }
            }

            // NOT FOUND
            return new Rectangle(0, 0, 0, 0);
        }//GetSelectedCell()



        ///////////////////////////////////////////////////////////////////////////
        // SetLastSelectedPoint()
        // 
        //  
        ///////////////////////////////////////////////////////////////////////////
        public static void SetLastSelectedPoint(Point LastPoint)
        {
            Point aux_point = new Point(LastPoint.X, LastPoint.Y);

            last_cell_position = aux_point;
        }


        ///////////////////////////////////////////////////////////////////////////
        // Round()
        // 
        //  
        ///////////////////////////////////////////////////////////////////////////
        internal static XNA.Point Round(XNA.Point WorldPoint)
        {

            decimal divisionX = (decimal)WorldPoint.X / Camera.ScaledTileSize;
            int intX          = (int)divisionX;

            decimal divisionY = (decimal)WorldPoint.Y / Camera.ScaledTileSize;
            int intY = (int)divisionY;

            if (divisionX - intX > (decimal).5)
            {
                intX++;

                if (intX == GLB_Data.MapSize.Width)
                {
                    intX--;
                }
            }

            if (divisionY - intY > (decimal).5)
            {
                intY++;
                if (intY == GLB_Data.MapSize.Width)
                {
                    intY--;
                }
            }

            return new XNA.Point(intX, intY);                
        }


        internal static Microsoft.Xna.Framework.Point TileSnapToGrid(Point Location)
        {
            for (int id_y = 0; id_y < GLB_Data.MapSize.Height; id_y++)
            {
                for (int id_x = 0; id_x < GLB_Data.MapSize.Width; id_x++)
                {
                    if ((Location.X >= id_x * Camera.ScaledTileSize && Location.X <= id_x * Camera.ScaledTileSize + Camera.ScaledTileSize) &&
                        (Location.Y >= id_y * Camera.ScaledTileSize && Location.Y <= id_y * Camera.ScaledTileSize + Camera.ScaledTileSize))
                    {
                        // FOUND                       
                        return new XNA.Point(id_x, id_y);
                    }
                }
            }

            // NOT FOUND
            return new XNA.Point();
        }

        internal static Microsoft.Xna.Framework.Point TileSnapToGridOther(Point Location)
        {
            for (int id_y = 0; id_y < GLB_Data_Other.MapSize.Height; id_y++)
            {
                for (int id_x = 0; id_x < GLB_Data_Other.MapSize.Width; id_x++)
                {
                    if ((Location.X >= id_x * Camera.ScaledTileSizeOther && Location.X <= id_x * Camera.ScaledTileSizeOther + Camera.ScaledTileSizeOther) &&
                        (Location.Y >= id_y * Camera.ScaledTileSizeOther && Location.Y <= id_y * Camera.ScaledTileSizeOther + Camera.ScaledTileSizeOther))
                    {
                        // FOUND                       
                        return new XNA.Point(id_x, id_y);
                    }
                }
            }

            // NOT FOUND
            return new XNA.Point();
        }
    }

}
