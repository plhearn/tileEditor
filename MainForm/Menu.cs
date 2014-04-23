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
using XNA_Map_Editor.SubForms;


#endregion

namespace XNA_Map_Editor
{
    partial class MainForm
    {
        #region MenuItems

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about_form.ShowDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog_result;

            dialog_result = MessageBox.Show("Are you sure you want to create a new map?", "New Map", MessageBoxButtons.YesNo);

            if (dialog_result == DialogResult.Yes)
            {
                InitTileMap();
                ShowCurrentLayer();
                ResetSelectedTiles();
                undo_redo.Clear();
                ResetTools();
                CheckUndoRedo();     // Reset undo/redo collections
            }
        }

        private void ResetTools()
        {
            this.mouse_scroll_final = new System.Drawing.Point();
            this.mouse_scroll_initial = new System.Drawing.Point();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadTilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open load dialog
            DialogResult loaded_result = this.load_tiles_dialog.ShowDialog();

            if (loaded_result == DialogResult.OK)
            {
                // Load image                

                if (GLB_Data.TilesTexture != null)
                {
                    GLB_Data.TilesTexture.Dispose();
                }

                Stream s = new MemoryStream(ASCIIEncoding.Default.GetBytes(load_tiles_dialog.FileName));
                GLB_Data.TilesTexture = Texture2D.FromStream(xna_renderer.GraphicsDevice, s);
                GLB_Data.TextureFileName = load_tiles_dialog.FileName;
                tile_palette.SetImage(load_tiles_dialog.FileName);
                tile_palette.Invalidate();

                // reset selected tiles
                this.ResetSelectedTiles();

                toolbar_brush_Click(sender, e);
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DoUndo();
            CheckUndoRedo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DoRedo();
            CheckUndoRedo();
        }

        private void showHideGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowGrid = (ShowGrid == true ? false : true);
            showHideGridToolStripMenuItem.Checked = ShowGrid;
        }

        private void showHideBlockedTilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWalkLayer = ShowWalkLayer == true ? false : true;
        }

        private void showHideTerrainTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTerrainTypes = ShowTerrainTypes == true ? false : true;
        }

        private void resizeMapToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ResizeForm resize_form = new ResizeForm(this); // Launch Resize Form            
            resize_form.ShowDialog();


        }

        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open save dialog
            DialogResult saved_result = this.save_map_dialog.ShowDialog();

            if (saved_result == DialogResult.OK)
            {
                // Save tile map data
                MapWriter map_writer = new MapWriter();

                if (map_writer.WriteBinaryMap(save_map_dialog.FileName))
                {
                    // success
                    MessageBox.Show("TileMap saved successfully!", "Save Map", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                /*

                StringBuilder sb = new StringBuilder();

                    using (StreamReader sr = new StreamReader(save_map_dialog.FileName))
                    {
                        sb.AppendLine("= = = = = =");
                        sb.Append(sr.ReadToEnd());
                        sb.AppendLine();
                        sb.AppendLine();
                    }
                using (StreamWriter outfile = new StreamWriter(save_map_dialog.FileName + @"\AllTxtFiles.txt"))
                {
                    outfile.Write(sb.ToString());
                }
                
                */
            }
        }

        private void loadMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open load dialog
            DialogResult loaded_result = this.load_map_dialog.ShowDialog();

            if (loaded_result == DialogResult.OK)
            {
                // Load tile map data
                MapLoader map_loader = new MapLoader();

                GLB_Data.MapName = load_map_dialog.FileName.Replace(".xmap", "").Substring(load_map_dialog.FileName.Replace(".xmap", "").LastIndexOf("\\")+1);

                if (map_loader.LoadBinaryMap(load_map_dialog.FileName))
                {
                    // success
                    if (GLB_Data.TextureFileName == null || GLB_Data.TextureFileName == "")
                    {
                        //MessageBox.Show("TileMap loaded successfully!", "Save Map", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    TextureLoader textureLoader = new TextureLoader(GraphicsDevice);
                    GLB_Data.TilesTexture = textureLoader.FromFile(GLB_Data.TextureFileName);
                    tile_palette.SetImage(GLB_Data.TextureFileName, GLB_Data.TilePalette);
                    tile_palette.Invalidate();

                    // reset settings
                    this.ResetSelectedTiles();
                    this.ResetLayers();
                    this.ResetCamera();

                    terrain_editor_form.PopulateCombo();

                    // loading done
                    //MessageBox.Show("TileMap loaded successfully!", "Save Map", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xml_writer.Export();
        }

        private void generateTextureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.GenerateTexture();
        }

        private void blockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tile_palette.SetWalkable(false);
        }

        private void unblockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tile_palette.SetWalkable(true);
        }

        private void applyCollisionTemplateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ApplyCollisionTemplate();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedLayer();
        }

        private void manageTerrainTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (terrain_editor_form.Visible == true)
            {
                return;
            }

            terrain_editor_form.ShowDialog(this);            
        }

        private void editTileSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frm_tile_size.ShowDialog();
            this.tile_palette.ResizeControl();

            tile_palette.SetImage();
            tile_palette.Invalidate();

            // reset selected tiles
            this.ResetSelectedTiles();
        }

        #endregion
    }
}