
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

using ImagesSrc = XNA_Map_Editor.Properties.Resources;


#endregion

namespace XNA_Map_Editor
{
    partial class MainForm
    {
        #region Toolbar

        private void InitToolbar()
        {
            toolbar_new_map.Image = ImagesSrc.NewDocument;
            toolbar_load_tileset.Image = ImagesSrc.ChooseColor;
            toolbar_save_map.Image = ImagesSrc.Save;
            toolbar_undo.Image = ImagesSrc.Edit_UndoHS;
            toolbar_redo.Image = ImagesSrc.Edit_RedoHS;
            toolbar_grid.Image = ImagesSrc.AlignToGridHS;
            toolbar_brush.Image = ImagesSrc.DefaultBrush;
            toolbar_layer_up.Image = ImagesSrc.FillUpHS;
            toolbar_layer_down.Image = ImagesSrc.FillDownHS;
            toolbar_visibility.Image = ImagesSrc.Visibility;
            toolbar_eraser.Image = ImagesSrc.Eraser;
            toolbar_load_map.Image = ImagesSrc.VSFolder_open;
            toolbar_walkability.Image = ImagesSrc.walk;
            toolbar_bucket.Image = ImagesSrc.Color_fillHH;
            toolbar_marquee.Image = ImagesSrc.Marquee;
            toolbar_export_xml.Image = ImagesSrc.XmlExport;
            toolbar_marquee_eraser.Image = ImagesSrc.MarqueeEraserBtn;
            toolbar_marquee_walk.Image = ImagesSrc.MarqueeWalk;
            toolbar_terrain_brush.Image = ImagesSrc.MarqueeTrn;


            toolbar_grid.CheckOnClick = true;
            toolbar_visibility.CheckOnClick = true;
            toolbar_brush.CheckOnClick = true;
            toolbar_eraser.CheckOnClick = true;
            toolbar_walkability.CheckOnClick = true;
            toolbar_marquee.CheckOnClick = true;
            toolbar_marquee_eraser.CheckOnClick = true;
            toolbar_marquee_walk.CheckOnClick = true;
            toolbar_terrain_brush.CheckOnClick = true;
        }

        private void toolbar_new_map_Click(object sender, EventArgs e)
        {
            this.newToolStripMenuItem_Click(sender, e);
        }

        private void toolbar_load_tileset_Click(object sender, EventArgs e)
        {
            this.loadTilesToolStripMenuItem_Click(sender, e);
        }

        private void toolbar_undo_Click(object sender, EventArgs e)
        {
            this.undoToolStripMenuItem_Click(sender, e);
        }

        private void toolbar_redo_Click(object sender, EventArgs e)
        {
            this.redoToolStripMenuItem_Click(sender, e);
        }

        private void toolbar_grid_Click(object sender, EventArgs e)
        {
            this.showHideGridToolStripMenuItem_Click(sender, e);
        }

        private void toolbar_visibility_Click(object sender, EventArgs e)
        {
            HideLayers = (HideLayers == true ? false : true);
        }

        private void toolbar_layer_up_Click(object sender, EventArgs e)
        {
            if (GLB_Data.SelectedLayer + 1 < GLB_Data.MapSize.Depth)
            {
                GLB_Data.SelectedLayer++;
                ShowCurrentLayer();
            }
        }

        private void toolbar_layer_down_Click(object sender, EventArgs e)
        {
            if (GLB_Data.SelectedLayer - 1 >= Constants.BASE_LAYER)
            {
                GLB_Data.SelectedLayer--;
                ShowCurrentLayer();
            }
        }

        private void toolbar_brush_Click(object sender, EventArgs e)
        {
            if (GLB_Data.Brush == PaintTool.Brush)
            {
                // no need to re-assign
                toolbar_brush.CheckState = CheckState.Checked;
            }
            else
            {
                // assign
                SetBrush(PaintTool.Brush);
            }
        }

        private void toolbar_eraser_Click(object sender, EventArgs e)
        {
            if (GLB_Data.Brush == PaintTool.Eraser)
            {
                // no need to re-assign
                toolbar_eraser.CheckState = CheckState.Checked;
            }
            else
            {
                // assign
                SetBrush(PaintTool.Eraser);
            }
        }

        private void toolbar_walkability_Click(object sender, EventArgs e)
        {
            if (GLB_Data.Brush == PaintTool.Walk)
            {
                // no need to re-assign
                toolbar_walkability.CheckState = CheckState.Checked;
            }
            else
            {
                // assign
                SetBrush(PaintTool.Walk);
            }
        }

        private void toolbar_bucket_Click(object sender, EventArgs e)
        {
            if (GLB_Data.Brush == PaintTool.Fill)
            {
                // no need to re-assign
                toolbar_bucket.CheckState = CheckState.Checked;
            }
            else
            {
                // assign
                SetBrush(PaintTool.Fill);
            }
        }

        private void toolbar_marquee_Click(object sender, EventArgs e)
        {
            if (GLB_Data.Brush == PaintTool.MarqueeBrush)
            {
                // no need to re-assign
                toolbar_marquee.CheckState = CheckState.Checked;
            }
            else
            {
                // assign
                SetBrush(PaintTool.MarqueeBrush);
            }
        }

        private void toolbar_marquee_eraser_Click(object sender, EventArgs e)
        {
            if (GLB_Data.Brush == PaintTool.MarqueeEraser)
            {
                // no need to re-assign
                toolbar_marquee_eraser.CheckState = CheckState.Checked;
            }
            else
            {
                SetBrush(PaintTool.MarqueeEraser);
            }
        }

        private void toolbar_marquee_walk_Click(object sender, EventArgs e)
        {
            if (GLB_Data.Brush == PaintTool.MarqueeWalk)
            {
                // no need to re-assign
                toolbar_marquee_walk.CheckState = CheckState.Checked;
            }
            else
            {
                SetBrush(PaintTool.MarqueeWalk);
            }
        }

        private void toolbar_terrain_brush_Click(object sender, EventArgs e)
        {
            if (GLB_Data.Brush == PaintTool.MarqueeTerrain)
            {
                // no need to re-assign
                toolbar_terrain_brush.CheckState = CheckState.Checked;
            }
            else
            {
                SetBrush(PaintTool.MarqueeTerrain);
            }
        }

        private void toolbar_save_map_Click(object sender, EventArgs e)
        {
            saveMapToolStripMenuItem_Click(sender, e);
        }

        private void toolbar_load_map_Click(object sender, EventArgs e)
        {
            loadMapToolStripMenuItem_Click(sender, e);
        }

        private void toolbar_export_xml_Click(object sender, EventArgs e)
        {
            this.exportToolStripMenuItem_Click(sender, e);
        }

        private void toolbar_portal_Click(object sender, EventArgs e)
        {
            if (GLB_Data.Brush == PaintTool.Portal)
            {
                // no need to re-assign
                toolbar_portal.CheckState = CheckState.Checked;
            }
            else
            {
                // assign
                SetBrush(PaintTool.Portal);
            }
        }

        private void toolbar_ManagePortals_Click(object sender, EventArgs e)
        {
            managePortalsForm = new ManagePortals(GraphicsDevice, this);

            managePortalsForm.Show();
        }


        private void toolbar_chest_Click(object sender, EventArgs e)
        {
            if (GLB_Data.Brush == PaintTool.Chest)
            {
                // no need to re-assign
                toolbar_chest.CheckState = CheckState.Checked;
            }
            else
            {
                // assign
                SetBrush(PaintTool.Chest);
            }
        }

        private void toolbar_NPC_Click(object sender, EventArgs e)
        {
            if (GLB_Data.Brush == PaintTool.NPC)
            {
                // no need to re-assign
                toolbar_NPC.CheckState = CheckState.Checked;
            }
            else
            {
                // assign
                SetBrush(PaintTool.NPC);
            }
        }

        private void toolbar_fixedCombat_Click(object sender, EventArgs e)
        {
            if (GLB_Data.Brush == PaintTool.FixedCombat)
            {
                // no need to re-assign
                toolbar_fixedCombat.CheckState = CheckState.Checked;
            }
            else
            {
                // assign
                SetBrush(PaintTool.FixedCombat);
            }
        }

        private void toolbar_Block_Click(object sender, EventArgs e)
        {
            if (GLB_Data.Brush == PaintTool.Block)
            {
                // no need to re-assign
                toolbar_block.CheckState = CheckState.Checked;
            }
            else
            {
                // assign
                SetBrush(PaintTool.Block);
            }
        }

        private void toolbar_Switch_Click(object sender, EventArgs e)
        {
            if (GLB_Data.Brush == PaintTool.Switch)
            {
                // no need to re-assign
                toolbar_switch.CheckState = CheckState.Checked;
            }
            else
            {
                // assign
                SetBrush(PaintTool.Switch);
            }
        }

        #endregion
    }
}