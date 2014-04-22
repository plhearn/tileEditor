using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XNA_Map_Editor
{
    public partial class EditChest : Form
    {
        public Chest selectedChest;

        public EditChest(Point spawnPoint, ref Chest chest)
        {
            InitializeComponent();

            this.Location = spawnPoint;
            selectedChest = chest;

            txtName.Text = chest.name;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GLB_Data.chests.Count; i++)
            {
                if (GLB_Data.chests[i].x == selectedChest.x && GLB_Data.chests[i].y == selectedChest.y)
                {
                    Chest newChest;
                    newChest.name = txtName.Text;
                    newChest.x = selectedChest.x;
                    newChest.y = selectedChest.y;

                    GLB_Data.chests[i] = newChest;
                }
            }

            this.Close();
        }
    }
}
