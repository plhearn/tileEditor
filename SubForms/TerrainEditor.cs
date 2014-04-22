using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XNA_Map_Editor.Helpers;

namespace XNA_Map_Editor.SubForms
{
    public partial class TerrainEditor : Form
    {
        MainForm parent_form;

        public TerrainEditor(MainForm Parent)
        {
            InitializeComponent();
            listbx_terrain.DrawMode = DrawMode.OwnerDrawFixed;
            parent_form = Parent;
        }

        protected override void  OnClosing(CancelEventArgs e)
        {
            this.Visible = false;
            e.Cancel     = true;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (this.Visible == false)
            {
                return;
            }

            PopulateList();

            if (GLB_Data.TerrainList.Count == Constants.MAX_TERRAINS)
            {
                btn_new.Enabled = false;
            }

            CheckItemSelected();
         }

        private void PopulateList()
        {
            listbx_terrain.Items.Clear();

            foreach (TerrainType t in GLB_Data.TerrainList)
            {
                listbx_terrain.Items.Add(t);
            }

            PopulateCombo();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.OnClosing(new CancelEventArgs());
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            TerrainDialog terrain_dialog = new TerrainDialog(this);

            terrain_dialog.ShowDialog(this);
            // Refresh list
            PopulateList();

            if (this.Focused == false)
            {
                this.Focus();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (btn_edit.Enabled == false)
            {
                return;
            }

            TerrainType selected_terrain = (TerrainType)listbx_terrain.SelectedItem;

            TerrainDialog terrain_dialog = new TerrainDialog(this, selected_terrain.Id);

            terrain_dialog.ShowDialog(this);

            this.Focus();

            // Refresh list
            PopulateList();

            btn_edit.Enabled = false;
        }

        private void listbx_terrain_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckItemSelected();
        }

        private void CheckItemSelected()
        {
            if (listbx_terrain.SelectedItem != null && listbx_terrain.Items.Count > 0)
            {
                this.btn_edit.Enabled   = true;
                this.btn_delete.Enabled = true;
            }
            else
            {
                this.btn_edit.Enabled   = false;
                this.btn_delete.Enabled = false;
            }
        }

        private void listbx_terrain_DrawItem(object sender, DrawItemEventArgs e)
        {
            TerrainType terrain;
            try
            {
                terrain = (TerrainType)((ListBox)sender).Items[e.Index];
            }
            catch 
            {                
                return;
            }
           

            using (Brush brush = new SolidBrush(terrain.Color))
            {

                e.Graphics.FillRectangle(brush, new Rectangle(e.Bounds.Location, new Size(e.Bounds.Height, e.Bounds.Height)));

            }

            using (Brush brush = new SolidBrush(e.ForeColor))
            {

                e.Graphics.DrawString(terrain.ToString(), e.Font, brush, e.Bounds);

            }

            e.DrawFocusRectangle();
        }

        private void listbx_terrain_DoubleClick(object sender, EventArgs e)
        {
            if (listbx_terrain.SelectedIndices != null)
            {
                this.btn_edit_Click(sender, new EventArgs());
            }

            listbx_terrain.Invalidate();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult answer;

            answer = MessageBox.Show("Are you sure you want to remove this Terrain Type?", "Terrain Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            TerrainType selected_terrain = (TerrainType)listbx_terrain.SelectedItem;

            int index = 0;

            foreach (TerrainType t in GLB_Data.TerrainList)
            {
                if (selected_terrain.Id == t.Id)
                {
                    index = GLB_Data.TerrainList.IndexOf(t);
                }
            }

            GLB_Data.TerrainList.RemoveAt(index);

            RemoveIdFromLayout(selected_terrain.Id);

            this.PopulateList();

            this.CheckItemSelected();
        }

        private void RemoveIdFromLayout(int RemovedId)
        {
            for (int id_x = 0; id_x < GLB_Data.TerrainLayout.GetLength(0); id_x++)
            {
                for (int id_y = 0; id_y < GLB_Data.TerrainLayout.GetLength(1); id_y++)
                {
                    if (GLB_Data.TerrainLayout[id_x, id_y] == RemovedId)
                    {
                        GLB_Data.TerrainLayout[id_x, id_y] = Constants.TERRAIN_NORMAL;
                    }
                }
            } 
        }

        public void PopulateCombo()
        {
            parent_form.toolbar_terrain_combo.Items.Clear();

            if (GLB_Data.TerrainList.Count <= 0)
            {
                return;
            }

            foreach (TerrainType t in GLB_Data.TerrainList)
            {
                parent_form.toolbar_terrain_combo.Items.Add(t);
            }

            if (parent_form.toolbar_terrain_combo.SelectedIndex == -1)
            {
                parent_form.toolbar_terrain_combo.SelectedIndex = 0;
            }
        }
    }
}
