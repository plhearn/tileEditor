namespace XNA_Map_Editor
{
    partial class ManagePortals
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hscroll_xna = new System.Windows.Forms.HScrollBar();
            this.pnl_scroll_filler = new System.Windows.Forms.Panel();
            this.vscroll_xna = new System.Windows.Forms.VScrollBar();
            this.xnaRenderer1 = new XNA_Map_Editor.XNARenderer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbar_loadMapPortals = new System.Windows.Forms.ToolStripButton();
            this.portalList = new System.Windows.Forms.ListBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hscroll_xna
            // 
            this.hscroll_xna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hscroll_xna.Location = new System.Drawing.Point(3, 596);
            this.hscroll_xna.Name = "hscroll_xna";
            this.hscroll_xna.Size = new System.Drawing.Size(625, 17);
            this.hscroll_xna.TabIndex = 8;
            this.hscroll_xna.Visible = false;
            this.hscroll_xna.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscroll_xna_Scroll);
            // 
            // pnl_scroll_filler
            // 
            this.pnl_scroll_filler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_scroll_filler.Location = new System.Drawing.Point(625, 596);
            this.pnl_scroll_filler.Name = "pnl_scroll_filler";
            this.pnl_scroll_filler.Size = new System.Drawing.Size(20, 17);
            this.pnl_scroll_filler.TabIndex = 5;
            // 
            // vscroll_xna
            // 
            this.vscroll_xna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vscroll_xna.Location = new System.Drawing.Point(628, -3);
            this.vscroll_xna.Name = "vscroll_xna";
            this.vscroll_xna.Size = new System.Drawing.Size(17, 599);
            this.vscroll_xna.TabIndex = 4;
            this.vscroll_xna.Visible = false;
            this.vscroll_xna.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vscroll_xna_Scroll);
            // 
            // xnaRenderer1
            // 
            this.xnaRenderer1.Location = new System.Drawing.Point(132, 28);
            this.xnaRenderer1.Name = "xnaRenderer1";
            this.xnaRenderer1.Size = new System.Drawing.Size(594, 428);
            this.xnaRenderer1.TabIndex = 0;
            this.xnaRenderer1.Text = "xnaRenderer1";
            this.xnaRenderer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xnaRenderer1_mouse_down);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbar_loadMapPortals});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(725, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbar_loadMapPortals
            // 
            this.toolbar_loadMapPortals.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_loadMapPortals.Image = global::XNA_Map_Editor.Properties.Resources.VSFolder_open;
            this.toolbar_loadMapPortals.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_loadMapPortals.Name = "toolbar_loadMapPortals";
            this.toolbar_loadMapPortals.Size = new System.Drawing.Size(23, 22);
            this.toolbar_loadMapPortals.Text = "toolStripButton1";
            this.toolbar_loadMapPortals.Click += new System.EventHandler(this.toolbar_loadMapPortals_Click);
            // 
            // portalList
            // 
            this.portalList.FormattingEnabled = true;
            this.portalList.Location = new System.Drawing.Point(0, 23);
            this.portalList.Name = "portalList";
            this.portalList.Size = new System.Drawing.Size(126, 433);
            this.portalList.TabIndex = 2;
            this.portalList.SelectedIndexChanged += new System.EventHandler(this.portalList_SelectedIndexChanged);
            // 
            // ManagePortals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 452);
            this.Controls.Add(this.portalList);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.xnaRenderer1);
            this.Name = "ManagePortals";
            this.Text = "ManagePortals";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public XNARenderer xnaRenderer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbar_loadMapPortals;
        private System.Windows.Forms.ListBox portalList;
        private System.Windows.Forms.HScrollBar hscroll_xna;
        private System.Windows.Forms.Panel pnl_scroll_filler;
        private System.Windows.Forms.VScrollBar vscroll_xna;
    }
}