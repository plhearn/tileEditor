using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XNA_Map_Editor.SubForms
{
    public partial class TileSizeEditor : Form
    {
        public TileSizeEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the current TileSize and assigns it to the form control
        /// </summary>
        public void GetData()
        {
            this.num_updwn.Value = GLB_Data.MapSize.TileSize;
        }

        /// <summary>
        /// Saves the current value to the the TileSize 
        /// </summary>
        public void SetData()
        {
            GLB_Data.MapSize.TileSize = (Int32)this.num_updwn.Value;
        }

        /// <summary>
        /// Invoked when the Ok button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.SetData();
            this.Visible = false;
        }

        /// <summary>
        /// Invoked when the Cancel button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        /// <summary>
        /// Invoked when the currend visibilty property is modified
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileSize_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                this.GetData();
            }
        }
    }
}
