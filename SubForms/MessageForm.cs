using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace XNA_Map_Editor.SubForms
{
    // HELP INFO
    // Background image must be 389x291 px
    public class MessageForm : Form
    {
        private Button button1;
    
        public void Show ( String Text, String Caption)
        {
           
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MessageForm
            // 
            this.AcceptButton = this.button1;
            this.ClientSize = new System.Drawing.Size(373, 195);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }
    }
}
