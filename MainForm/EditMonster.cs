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
    public partial class EditMonster : Form
    {
        public FixedCombatNPC selectedFixedCombatNPC;

        public EditMonster(Point spawnPoint, ref FixedCombatNPC FixedCombatNPC)
        {
            InitializeComponent();

            this.Location = spawnPoint;
            selectedFixedCombatNPC = FixedCombatNPC;

            txtName.Text = FixedCombatNPC.name;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GLB_Data.fixedCombatNPCs.Count; i++)
            {
                if (GLB_Data.fixedCombatNPCs[i].x == selectedFixedCombatNPC.x && 
                    GLB_Data.fixedCombatNPCs[i].y == selectedFixedCombatNPC.y)
                {
                    FixedCombatNPC newFixedCombatNPC = new FixedCombatNPC();
                    newFixedCombatNPC.name = txtName.Text;
                    newFixedCombatNPC.x = selectedFixedCombatNPC.x;
                    newFixedCombatNPC.y = selectedFixedCombatNPC.y;

                    GLB_Data.fixedCombatNPCs[i] = newFixedCombatNPC;
                }
            }

            this.Close();
        }
    }
}
