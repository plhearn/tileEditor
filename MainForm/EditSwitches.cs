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
    public partial class EditSwitches : Form
    {
        public Switch selectedSwitch;

        public EditSwitches(Point spawnPoint, ref Switch Switch)
        {
            InitializeComponent();

            this.Location = spawnPoint;
            selectedSwitch = Switch;

            txtName.Text = Switch.name;
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GLB_Data.switches.Count; i++)
            {
                if (GLB_Data.switches[i].x == selectedSwitch.x && 
                    GLB_Data.switches[i].y == selectedSwitch.y)
                {
                    Switch newSwitch = new Switch();
                    newSwitch.name = txtName.Text;
                    newSwitch.x = selectedSwitch.x;
                    newSwitch.y = selectedSwitch.y;

                    GLB_Data.switches[i] = newSwitch;
                }
            }

            this.Close();
        }
    }
}
