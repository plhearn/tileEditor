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
    public partial class EditNPC : Form
    {
        public NPC selectedNPC;

        public EditNPC(Point spawnPoint, ref NPC NPC)
        {
            InitializeComponent();

            this.Location = spawnPoint;
            selectedNPC = NPC;

            txtName.Text = NPC.name;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GLB_Data.npcs.Count; i++)
            {
                if (GLB_Data.npcs[i].x == selectedNPC.x &&
                    GLB_Data.npcs[i].y == selectedNPC.y)
                {
                    NPC newNPC;
                    newNPC.name = txtName.Text;
                    newNPC.x = selectedNPC.x;
                    newNPC.y = selectedNPC.y;

                    GLB_Data.npcs[i] = newNPC;
                }
            }

            this.Close();
        }
    }
}