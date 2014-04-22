using System;
using Microsoft.Xna.Framework;

using XNA_Map_Editor.Helpers;
using System.Windows.Forms;

namespace XNA_Map_Editor.Classes
{
    public static class Camera
    {
        #region Class Fields

        static Vector2 position;
        static Int32   scrollbar_margin = 17;
        static float   zoom;

        #endregion

        #region Properties

        public static float X
        {
            get
            {
                return position.X;
            }
            set
            {
                position.X = value;
            }
        }

        public static float Y
        {
            get
            {
                return position.Y;
            }
            set
            {
                position.Y = value;
            }
        }

        public static float Zoom 
        {
            get
            {
                return zoom;
            }
        }

        public static int ScaledTileSize
        {
            get
            {
                return (int)(GLB_Data.MapSize.TileSize * zoom);
            }
        }


        #endregion

        #region Public Methods

        public static void InitCamera()
        {
            Camera.position     = new Vector2(0f);
            Camera.zoom         = Constants.NORMAL_ZOOM;
        }

        internal static void SetPosition(int X, int Y, int CameraWidth, int CameraHeight)
        {
            if (X + CameraWidth >= GLB_Data.MapSize.Width * Camera.ScaledTileSize && CameraWidth < GLB_Data.MapSize.Width * Camera.ScaledTileSize)
            {
                X += (GLB_Data.MapSize.Width * Camera.ScaledTileSize - CameraWidth + scrollbar_margin);
            }

            if (Y + CameraHeight >= GLB_Data.MapSize.Height * Camera.ScaledTileSize && CameraHeight < GLB_Data.MapSize.Height * Camera.ScaledTileSize)
            {
                Y += (GLB_Data.MapSize.Height * Camera.ScaledTileSize - CameraHeight + scrollbar_margin);
            }

            Camera.position = new Vector2((float)X * -1, (float)Y * -1);
        }

        internal static Rectangle Transform(Rectangle AuxRectangle)
        {
            AuxRectangle.X += (int)Camera.X;
            AuxRectangle.Y += (int)Camera.Y;

            return AuxRectangle;
        }

        internal static Vector2 Transform(Vector2 Vector)
        {
            Vector.X += (int)Camera.X;
            Vector.Y += (int)Camera.Y;

            return Vector;
        }

        // Zoom Down
        // Causes problems
        public static void IncreaseZoom(int Width, int Heigth)
        {
            zoom -= 0.1f;

            if (zoom < 0.099f)
            {
                zoom = 0.099f;
                return;
            }
            //if (Camera.X * -1 + Width > GLB_Data.MapSize.Width * Camera.ScaledTileSize )
            //{
            //    //Camera.position.X = GLB_Data.MapSize.Width * Camera.ScaledTileSize - Width;
            //}

            //if (Camera.Y != 0)
            //{
            //    //Camera.position.Y += zoom * -1;
            //}

        }

        // Zoom UP
        public static void DecrementZoom()
        {
            zoom += 0.1f;

            if (zoom > 5f)
            {
                zoom = 5;
                return;
            }
        }

        #endregion

        internal static Point XWorldPosition(System.Drawing.Point ScreenPoint)
        {
            ScreenPoint.X += (int)Camera.X * -1;
            ScreenPoint.Y += (int)Camera.Y * -1;

            return new Point(ScreenPoint.X, ScreenPoint.Y);
        }

        internal static System.Drawing.Point WorldPosition(System.Drawing.Point ScreenPoint)
        {
            ScreenPoint.X += (int)Camera.X * -1;
            ScreenPoint.Y += (int)Camera.Y * -1;

            return ScreenPoint;
        }

        internal static System.Drawing.Rectangle Transform(System.Drawing.Rectangle AuxRectangle)
        {
            AuxRectangle.X += (int)Camera.X * -1;
            AuxRectangle.Y += (int)Camera.Y * -1;

            return AuxRectangle;
        }

        internal static Point Transform(Point SelectedPoint)
        {
            SelectedPoint.X += (int)Camera.X * -1;
            SelectedPoint.Y += (int)Camera.Y * -1;

            return SelectedPoint;
        }

        internal static System.Drawing.Rectangle TransformToGrid(System.Drawing.Rectangle AuxRectangle)
        {
            AuxRectangle.X += (int)Camera.X;
            AuxRectangle.Y += (int)Camera.Y;

            return AuxRectangle;
        }

        internal static Point Transform(System.Drawing.Point SelectedPoint)
        {
            SelectedPoint.X += (int)Camera.X * -1;
            SelectedPoint.Y += (int)Camera.Y * -1;

            return new Point(SelectedPoint.X, SelectedPoint.Y);
        }

        internal static System.Drawing.Point SystemPointTransform(System.Drawing.Point SelectedPoint)
        {
            SelectedPoint.X += (int)Camera.X * -1;
            SelectedPoint.Y += (int)Camera.Y * -1;

            return SelectedPoint;
        }

        internal static void Reset()
        {
            InitCamera();
        }

        internal static Vector2 GetCenter(int CameraWidth, int CameraHeight)
        {
            return new Vector2(X + CameraWidth / 2, Y + CameraHeight / 2);
        }

        internal static void Scroll(int DistanceX, int DistanceY, int CameraWidth, int CameraHeight)
        {
            if (GLB_Data.MapSize.Width * Camera.ScaledTileSize > CameraWidth)
            {
                Camera.position.X += DistanceX;

                if (Math.Abs(Camera.position.X) + CameraWidth > GLB_Data.MapSize.Width * Camera.ScaledTileSize)
                {
                    Camera.position.X = (GLB_Data.MapSize.Width * Camera.ScaledTileSize + scrollbar_margin - 3 - CameraWidth) * -1; // 3 is a quick fix for camera limit
                }

                if (Camera.X > 0)
                {
                    Camera.position.X = 0;
                }
            }
            else
            {
                Camera.position.X = 0;
            }

            if (GLB_Data.MapSize.Height * Camera.ScaledTileSize > CameraHeight)
            {
                Camera.position.Y += DistanceY;

                if (Math.Abs(Camera.position.Y) + CameraHeight > GLB_Data.MapSize.Height * Camera.ScaledTileSize)
                {
                    Camera.position.Y = (GLB_Data.MapSize.Height * Camera.ScaledTileSize + scrollbar_margin - 3 - CameraHeight) * -1; // 3 is a quick fix for camera limit
                }

                if (Camera.Y > 0)
                {
                    Camera.position.Y = 0;
                }
            }
            else
            {
                Camera.position.Y = 0;
            }
        }
    }
}

