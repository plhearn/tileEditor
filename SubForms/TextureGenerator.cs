using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using XNA_Map_Editor.Helpers;

namespace XNA_Map_Editor.SubForms
{
    partial class TextureGenerator : Form
    {
        #region Fields

        const int BLEED_SIZE = 1;   // pixel separation
        const int MARGIN     = 2;  // scrollbar margin

        Bitmap original_img;
        Bitmap modified_img;
        Pen    pen_grid;

        #endregion

        #region Constructor

        public TextureGenerator()
        {
            InitializeComponent();

            //this.AutoScroll = true;

            pen_grid = new Pen(Color.FromArgb(255, 255, 0, 255), 1f);

            // Scrolling properties
            this.DoubleBuffered    = true;  
            pnl_texture.AutoScroll = true;                     

            original_img    = (Bitmap)Image.FromFile(GLB_Data.TextureFileName);           

            this.BackColor  = Color.CornflowerBlue;

            GenerateImage();
        }

        #endregion

        #region Private Methods

        private void GenerateImage()
        {
            modified_img = new Bitmap(original_img.Width +  ((original_img.Width / GLB_Data.MapSize.TileSize + 1) * BLEED_SIZE),
                                      original_img.Height + ((original_img.Height / GLB_Data.MapSize.TileSize + 1) * BLEED_SIZE));

            Graphics g = Graphics.FromImage(modified_img);


            for (int id_y = 0; id_y < original_img.Height / GLB_Data.MapSize.TileSize; id_y++)
            {
                for (int id_x = 0; id_x < original_img.Width / GLB_Data.MapSize.TileSize; id_x++)
                {                    
                    Rectangle src_rectangle  = new Rectangle(id_x * GLB_Data.MapSize.TileSize,
                                                             id_y * GLB_Data.MapSize.TileSize,
                                                             GLB_Data.MapSize.TileSize, GLB_Data.MapSize.TileSize);

                    Rectangle dest_rectangle = new Rectangle(id_x * GLB_Data.MapSize.TileSize + BLEED_SIZE * id_x + +BLEED_SIZE,
                                                             id_y * GLB_Data.MapSize.TileSize + BLEED_SIZE * id_y + +BLEED_SIZE,
                                                             GLB_Data.MapSize.TileSize, GLB_Data.MapSize.TileSize);

                    g.DrawImage(original_img, dest_rectangle, src_rectangle, GraphicsUnit.Pixel); 
                }
            }

            if (BLEED_SIZE == 1)
            {
                // Draw tile grid
                // Grid paint
                for (int id_y = 0; id_y < modified_img.Height; id_y += GLB_Data.MapSize.TileSize + BLEED_SIZE)
                {
                    g.DrawLine(pen_grid, new Point(0, id_y), new Point(modified_img.Width, id_y));
                }
                for (int id_x = 0; id_x < modified_img.Width; id_x += GLB_Data.MapSize.TileSize + BLEED_SIZE)
                {
                    g.DrawLine(pen_grid, new Point(id_x, 0), new Point(id_x, modified_img.Height));
                }
            }

            // Resize form for auto-scrolling
            pnl_texture.MinimumSize = new Size(modified_img.Size.Width + MARGIN, modified_img.Height + MARGIN);
            pnl_texture.Size = new Size(modified_img.Size.Width + MARGIN, modified_img.Height + MARGIN);
        }

        #endregion

        #region Menu

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exit
            this.Dispose();
        }

        #endregion

        #region Events

        private void pnl_texture_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(modified_img, new Rectangle(0, 0, modified_img.Width, modified_img.Height));
        }

        #endregion

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_texture_dialog = new SaveFileDialog();
            save_texture_dialog.InitialDirectory = Environment.CurrentDirectory + @"\Images";
            save_texture_dialog.Filter = "PNG (*.png) | *.png";
            save_texture_dialog.Title = "Save Texture";

            DialogResult dialog_result = save_texture_dialog.ShowDialog();

            if (dialog_result == DialogResult.OK)
            {
                try
                {
                    modified_img.Save(save_texture_dialog.FileName);
                }
                catch
                {
                    MessageBox.Show("Error writing to file, check that it is not in use or that it is not write protected",
                                    "Error saving texture", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
             
        }
    }
}
