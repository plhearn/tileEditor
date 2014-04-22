using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using XNA_Map_Editor.Properties;

namespace XNA_Map_Editor.Classes
{
    public static class Shapes
    {
        public static void DrawLine(Vector2 PointA, Vector2 PointB, SpriteBatch SBatch, Texture2D Texture, Color XnaColor)
        {
            int distance = (int)Vector2.Distance(PointA, PointB);

            Vector2 connection  = PointB - PointA;
            Vector2 base_vector = new Vector2(1, 0);

            float alpha = (float)Math.Acos(Vector2.Dot(connection, base_vector) / (connection.Length() * base_vector.Length()));

            SBatch.Draw(Texture, new Rectangle((int)PointA.X, (int)PointA.Y, distance, 1),
                        null, XnaColor, alpha, new Vector2(0, 0), SpriteEffects.None, 0);
        }


        //Draws a rect with the help of DrawLine
        public static void DrawRectangle(Rectangle Rect, SpriteBatch SBatch, Texture2D Texture, Color XnaColor)
        {
            // | left
            DrawLine(new Vector2(Rect.X, Rect.Y), new Vector2(Rect.X, Rect.Y + Rect.Height), SBatch, Texture, XnaColor);
            // - top
            DrawLine(new Vector2(Rect.X, Rect.Y), new Vector2(Rect.X + Rect.Width, Rect.Y), SBatch, Texture, XnaColor);
            // - bottom
            DrawLine(new Vector2(Rect.X, Rect.Y + Rect.Height), new Vector2(Rect.X + Rect.Width, Rect.Y + Rect.Height), SBatch, Texture, XnaColor);
            // | right
            DrawLine(new Vector2(Rect.X + Rect.Width, Rect.Y), new Vector2(Rect.X + Rect.Width, Rect.Y + Rect.Height), SBatch, Texture, XnaColor);
        }

    }
}
