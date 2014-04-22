using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using XNA_Map_Editor.Properties;

namespace XNA_Map_Editor
    {
    partial class MainForm
    {

        void DrawLine(Vector2 PointA, Vector2 PointB, Color XnaColor)        
        {
            int distance = (int)Vector2.Distance(PointA, PointB);

            Vector2 connection  = PointB - PointA;
            Vector2 base_vector = new Vector2(1, 0);

            float alpha = (float)Math.Acos(Vector2.Dot(connection, base_vector) / (connection.Length() * base_vector.Length()));

            sprite_batch.Draw(grid_texture, new Rectangle((int)PointA.X, (int)PointA.Y, distance, 1),
                              null, XnaColor, alpha, new Vector2(0, 0), SpriteEffects.None, 0);
        }


        //Draws a rect with the help of DrawLine
        void DrawRectangle(Rectangle Rect, Color XnaColor)
        {
            // | left
            DrawLine(new Vector2(Rect.X, Rect.Y), new Vector2(Rect.X, Rect.Y + Rect.Height), XnaColor);
            // - top
            DrawLine(new Vector2(Rect.X, Rect.Y), new Vector2(Rect.X + Rect.Width, Rect.Y), XnaColor);
            // - bottom
            DrawLine(new Vector2(Rect.X, Rect.Y + Rect.Height), new Vector2(Rect.X + Rect.Width, Rect.Y + Rect.Height), XnaColor);
            // | right
            DrawLine(new Vector2(Rect.X + Rect.Width, Rect.Y), new Vector2(Rect.X + Rect.Width, Rect.Y + Rect.Height), XnaColor);
        }

    }
}
