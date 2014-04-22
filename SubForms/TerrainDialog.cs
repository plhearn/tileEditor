using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace XNA_Map_Editor.SubForms
{
    public partial class TerrainDialog : Form
    {
        public TerrainDialog(TerrainEditor Parent)
        {
            InitializeComponent();            
        }

        public TerrainDialog(TerrainEditor Parent, Int32 EditId)
        {
            InitializeComponent();
            this.txt_id.Enabled = false;


            foreach (TerrainType t in GLB_Data.TerrainList)
            {
                if (t.Id == EditId)
                {
                    txt_id.Text         = t.Id.ToString(); 
                    txt_name.Text       = t.Name;
                    pb_color.BackColor  = t.Color;
                    txt_speed.Text      = t.TerrainSpeed.ToString();
                }
            }

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_id.Enabled == false)
            {
                SaveEdit();
                return;
            }

            if (txt_id.Text == "" || txt_id.Text == "0")
            {
                MessageBox.Show("Invalid Id: Id cannot be 0 or blank", "Invalid Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IdExists(Convert.ToInt32(txt_id.Text)))
            {
                MessageBox.Show("New Id already exists, try another one", "Duplicated Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(txt_id.Text) < 0)
            {
                MessageBox.Show("Id cannot be lower than 0", "Invalid Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txt_speed.Text[0] == '.')
            {
                txt_speed.Text = "0" + txt_speed.Text;
            }

            if ( float.Parse(txt_speed.Text) <= 0)
            {
                txt_speed.Text = "1";
            }

            GLB_Data.TerrainList.Add(new TerrainType(Convert.ToInt32(txt_id.Text), txt_name.Text, float.Parse(txt_speed.Text, CultureInfo.InvariantCulture), pb_color.BackColor));

            btn_exit_Click(sender, e);
        }

        private void SaveEdit()
        {
            int index = 0;

            foreach (TerrainType t in GLB_Data.TerrainList)
            {
                if (Convert.ToInt32(txt_id.Text) == t.Id)
                {
                    index = GLB_Data.TerrainList.IndexOf(t);
                }
            }

            GLB_Data.TerrainList.RemoveAt(index);
            GLB_Data.TerrainList.Add(new TerrainType(Convert.ToInt32(txt_id.Text), txt_name.Text, float.Parse(txt_speed.Text, CultureInfo.InvariantCulture), pb_color.BackColor));

            btn_exit_Click(new object(), new EventArgs());
        }

        private bool IdExists(int NewId)
        {
            foreach (TerrainType t in GLB_Data.TerrainList)
            {
                if (NewId == t.Id)
                {
                    return true;
                }
            }

            return false;
        }

        private void btn_color_Click(object sender, EventArgs e)
        {            
            colorDialog1.ShowDialog();
            pb_color.BackColor = colorDialog1.Color;
        }

    }
}
