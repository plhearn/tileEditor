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
    public partial class EditBlock : Form
    {
        public Block selectedBlock;

        public EditBlock(Point spawnPoint, ref Block Block)
        {
            InitializeComponent();

            this.Location = spawnPoint;
            selectedBlock = Block;

            txtName.Text = Block.name;
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GLB_Data.blocks.Count; i++)
            {
                if (GLB_Data.blocks[i].x == selectedBlock.x && 
                    GLB_Data.blocks[i].y == selectedBlock.y)
                {
                    Block newBlock = new Block();
                    newBlock.name = txtName.Text;
                    newBlock.x = selectedBlock.x;
                    newBlock.y = selectedBlock.y;

                    GLB_Data.blocks[i] = newBlock;
                }
            }

            this.Close();
        }
    }
}
