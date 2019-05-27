namespace XNA_Map_Editor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.resizeMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTileSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unblockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.applyCollisionTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHideGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHideBlockedTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHideTerrainTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTerrainTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolbar_new_map = new System.Windows.Forms.ToolStripButton();
            this.toolbar_save_map = new System.Windows.Forms.ToolStripButton();
            this.toolbar_load_map = new System.Windows.Forms.ToolStripButton();
            this.toolbar_export_xml = new System.Windows.Forms.ToolStripButton();
            this.toolbar_load_tileset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbar_undo = new System.Windows.Forms.ToolStripButton();
            this.toolbar_redo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbar_grid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbar_layer_down = new System.Windows.Forms.ToolStripButton();
            this.toolbar_lbl_layer = new System.Windows.Forms.ToolStripTextBox();
            this.toolbar_layer_up = new System.Windows.Forms.ToolStripButton();
            this.toolbar_visibility = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbar_brush = new System.Windows.Forms.ToolStripButton();
            this.toolbar_marquee = new System.Windows.Forms.ToolStripButton();
            this.toolbar_marquee_eraser = new System.Windows.Forms.ToolStripButton();
            this.toolbar_eraser = new System.Windows.Forms.ToolStripButton();
            this.toolbar_bucket = new System.Windows.Forms.ToolStripButton();
            this.toolbar_marquee_walk = new System.Windows.Forms.ToolStripButton();
            this.toolbar_walkability = new System.Windows.Forms.ToolStripButton();
            this.toolbar_select = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbar_txt_location = new System.Windows.Forms.ToolStripLabel();
            this.toolbar_terrain_brush = new System.Windows.Forms.ToolStripButton();
            this.toolbar_terrain_combo = new System.Windows.Forms.ToolStripComboBox();
            this.toolbar_portal = new System.Windows.Forms.ToolStripButton();
            this.toolbar_ManagePortals = new System.Windows.Forms.ToolStripButton();
            this.toolbar_chest = new System.Windows.Forms.ToolStripButton();
            this.toolbar_NPC = new System.Windows.Forms.ToolStripButton();
            this.toolbar_fixedCombat = new System.Windows.Forms.ToolStripButton();
            this.toolbar_block = new System.Windows.Forms.ToolStripButton();
            this.toolbar_switch = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grp_tile_map = new System.Windows.Forms.GroupBox();
            this.pnl_tile_map = new System.Windows.Forms.Panel();
            this.tab_control = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.hscroll_xna = new System.Windows.Forms.HScrollBar();
            this.pnl_scroll_filler = new System.Windows.Forms.Panel();
            this.vscroll_xna = new System.Windows.Forms.VScrollBar();
            this.xna_renderer = new XNA_Map_Editor.XNARenderer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rch_txtbox = new System.Windows.Forms.RichTextBox();
            this.grp_tile_palette = new System.Windows.Forms.GroupBox();
            this.pnl_tile_palette = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grp_tile_map.SuspendLayout();
            this.pnl_tile_map.SuspendLayout();
            this.tab_control.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grp_tile_palette.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1020, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveMapToolStripMenuItem,
            this.loadMapToolStripMenuItem,
            this.toolStripSeparator7,
            this.loadToolStripMenuItem,
            this.toolStripSeparator8,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.newToolStripMenuItem.Text = "&New Map";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveMapToolStripMenuItem
            // 
            this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.saveMapToolStripMenuItem.Text = "&Save Map";
            this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.saveMapToolStripMenuItem_Click);
            // 
            // loadMapToolStripMenuItem
            // 
            this.loadMapToolStripMenuItem.Name = "loadMapToolStripMenuItem";
            this.loadMapToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.loadMapToolStripMenuItem.Text = "&Load Map";
            this.loadMapToolStripMenuItem.Click += new System.EventHandler(this.loadMapToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(134, 6);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.loadToolStripMenuItem.Text = "Load &Tileset";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadTilesToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(134, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator5,
            this.resizeMapToolStripMenuItem,
            this.editTileSizeToolStripMenuItem,
            this.selectedTilesToolStripMenuItem,
            this.currentLayerToolStripMenuItem,
            this.toolStripSeparator6,
            this.applyCollisionTemplateToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(222, 6);
            // 
            // resizeMapToolStripMenuItem
            // 
            this.resizeMapToolStripMenuItem.Name = "resizeMapToolStripMenuItem";
            this.resizeMapToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.resizeMapToolStripMenuItem.Text = "Resize Map";
            this.resizeMapToolStripMenuItem.Click += new System.EventHandler(this.resizeMapToolStripMenuItem_Click);
            // 
            // editTileSizeToolStripMenuItem
            // 
            this.editTileSizeToolStripMenuItem.Name = "editTileSizeToolStripMenuItem";
            this.editTileSizeToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.editTileSizeToolStripMenuItem.Text = "Edit Tile Size";
            this.editTileSizeToolStripMenuItem.Click += new System.EventHandler(this.editTileSizeToolStripMenuItem_Click);
            // 
            // selectedTilesToolStripMenuItem
            // 
            this.selectedTilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blockToolStripMenuItem,
            this.unblockToolStripMenuItem});
            this.selectedTilesToolStripMenuItem.Name = "selectedTilesToolStripMenuItem";
            this.selectedTilesToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.selectedTilesToolStripMenuItem.Text = "Selected Tiles";
            // 
            // blockToolStripMenuItem
            // 
            this.blockToolStripMenuItem.Name = "blockToolStripMenuItem";
            this.blockToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.blockToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.blockToolStripMenuItem.Text = "Block";
            this.blockToolStripMenuItem.Click += new System.EventHandler(this.blockToolStripMenuItem_Click);
            // 
            // unblockToolStripMenuItem
            // 
            this.unblockToolStripMenuItem.Name = "unblockToolStripMenuItem";
            this.unblockToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.unblockToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.unblockToolStripMenuItem.Text = "Unblock";
            this.unblockToolStripMenuItem.Click += new System.EventHandler(this.unblockToolStripMenuItem_Click);
            // 
            // currentLayerToolStripMenuItem
            // 
            this.currentLayerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.currentLayerToolStripMenuItem.Name = "currentLayerToolStripMenuItem";
            this.currentLayerToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.currentLayerToolStripMenuItem.Text = "Current Layer";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(222, 6);
            // 
            // applyCollisionTemplateToolStripMenuItem
            // 
            this.applyCollisionTemplateToolStripMenuItem.Name = "applyCollisionTemplateToolStripMenuItem";
            this.applyCollisionTemplateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.applyCollisionTemplateToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.applyCollisionTemplateToolStripMenuItem.Text = "Apply Collision Template";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHideGridToolStripMenuItem,
            this.showHideBlockedTilesToolStripMenuItem,
            this.showHideTerrainTypesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // showHideGridToolStripMenuItem
            // 
            this.showHideGridToolStripMenuItem.Name = "showHideGridToolStripMenuItem";
            this.showHideGridToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.showHideGridToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.showHideGridToolStripMenuItem.Text = "Show/Hide Grid";
            this.showHideGridToolStripMenuItem.Click += new System.EventHandler(this.showHideGridToolStripMenuItem_Click);
            // 
            // showHideBlockedTilesToolStripMenuItem
            // 
            this.showHideBlockedTilesToolStripMenuItem.Name = "showHideBlockedTilesToolStripMenuItem";
            this.showHideBlockedTilesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.showHideBlockedTilesToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.showHideBlockedTilesToolStripMenuItem.Text = "Show/Hide Blocked Tiles";
            this.showHideBlockedTilesToolStripMenuItem.Click += new System.EventHandler(this.showHideBlockedTilesToolStripMenuItem_Click);
            // 
            // showHideTerrainTypesToolStripMenuItem
            // 
            this.showHideTerrainTypesToolStripMenuItem.Name = "showHideTerrainTypesToolStripMenuItem";
            this.showHideTerrainTypesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.showHideTerrainTypesToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.showHideTerrainTypesToolStripMenuItem.Text = "Show/Hide Terrain Types";
            this.showHideTerrainTypesToolStripMenuItem.Click += new System.EventHandler(this.showHideTerrainTypesToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.generateTextureToolStripMenuItem,
            this.manageTerrainTypesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.exportToolStripMenuItem.Text = "Export to XML";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // generateTextureToolStripMenuItem
            // 
            this.generateTextureToolStripMenuItem.Name = "generateTextureToolStripMenuItem";
            this.generateTextureToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.generateTextureToolStripMenuItem.Text = "Generate &Texture";
            this.generateTextureToolStripMenuItem.Click += new System.EventHandler(this.generateTextureToolStripMenuItem_Click);
            // 
            // manageTerrainTypesToolStripMenuItem
            // 
            this.manageTerrainTypesToolStripMenuItem.Name = "manageTerrainTypesToolStripMenuItem";
            this.manageTerrainTypesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.manageTerrainTypesToolStripMenuItem.Text = "Manage Terrain Types";
            this.manageTerrainTypesToolStripMenuItem.Click += new System.EventHandler(this.manageTerrainTypesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.SystemColors.MenuBar;
            this.toolbar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbar_new_map,
            this.toolbar_save_map,
            this.toolbar_load_map,
            this.toolbar_export_xml,
            this.toolbar_load_tileset,
            this.toolStripSeparator1,
            this.toolbar_undo,
            this.toolbar_redo,
            this.toolStripSeparator2,
            this.toolbar_grid,
            this.toolStripSeparator4,
            this.toolbar_layer_down,
            this.toolbar_lbl_layer,
            this.toolbar_layer_up,
            this.toolbar_visibility,
            this.toolStripSeparator3,
            this.toolbar_brush,
            this.toolbar_marquee,
            this.toolbar_marquee_eraser,
            this.toolbar_eraser,
            this.toolbar_bucket,
            this.toolbar_marquee_walk,
            this.toolbar_walkability,
            this.toolbar_select,
            this.toolStripSeparator9,
            this.toolbar_txt_location,
            this.toolbar_terrain_brush,
            this.toolbar_terrain_combo,
            this.toolbar_portal,
            this.toolbar_ManagePortals,
            this.toolbar_chest,
            this.toolbar_NPC,
            this.toolbar_fixedCombat,
            this.toolbar_block,
            this.toolbar_switch});
            this.toolbar.Location = new System.Drawing.Point(0, 24);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(1020, 31);
            this.toolbar.TabIndex = 8;
            this.toolbar.Text = "toolStrip1";
            // 
            // toolbar_new_map
            // 
            this.toolbar_new_map.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_new_map.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_new_map.Image")));
            this.toolbar_new_map.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_new_map.Name = "toolbar_new_map";
            this.toolbar_new_map.Size = new System.Drawing.Size(28, 28);
            this.toolbar_new_map.Text = "New File";
            this.toolbar_new_map.Click += new System.EventHandler(this.toolbar_new_map_Click);
            // 
            // toolbar_save_map
            // 
            this.toolbar_save_map.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_save_map.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_save_map.Image")));
            this.toolbar_save_map.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_save_map.Name = "toolbar_save_map";
            this.toolbar_save_map.Size = new System.Drawing.Size(28, 28);
            this.toolbar_save_map.Text = "Save Map";
            this.toolbar_save_map.Click += new System.EventHandler(this.toolbar_save_map_Click);
            // 
            // toolbar_load_map
            // 
            this.toolbar_load_map.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_load_map.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_load_map.Image")));
            this.toolbar_load_map.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_load_map.Name = "toolbar_load_map";
            this.toolbar_load_map.Size = new System.Drawing.Size(28, 28);
            this.toolbar_load_map.Text = "Load Map";
            this.toolbar_load_map.Click += new System.EventHandler(this.toolbar_load_map_Click);
            // 
            // toolbar_export_xml
            // 
            this.toolbar_export_xml.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_export_xml.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_export_xml.Image")));
            this.toolbar_export_xml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_export_xml.Name = "toolbar_export_xml";
            this.toolbar_export_xml.Size = new System.Drawing.Size(28, 28);
            this.toolbar_export_xml.Text = "Export to XML";
            this.toolbar_export_xml.Click += new System.EventHandler(this.toolbar_export_xml_Click);
            // 
            // toolbar_load_tileset
            // 
            this.toolbar_load_tileset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_load_tileset.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_load_tileset.Image")));
            this.toolbar_load_tileset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_load_tileset.Name = "toolbar_load_tileset";
            this.toolbar_load_tileset.Size = new System.Drawing.Size(28, 28);
            this.toolbar_load_tileset.Text = "Load Tileset";
            this.toolbar_load_tileset.Click += new System.EventHandler(this.toolbar_load_tileset_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolbar_undo
            // 
            this.toolbar_undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_undo.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_undo.Image")));
            this.toolbar_undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_undo.Name = "toolbar_undo";
            this.toolbar_undo.Size = new System.Drawing.Size(28, 28);
            this.toolbar_undo.Text = "Undo";
            this.toolbar_undo.Click += new System.EventHandler(this.toolbar_undo_Click);
            // 
            // toolbar_redo
            // 
            this.toolbar_redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_redo.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_redo.Image")));
            this.toolbar_redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_redo.Name = "toolbar_redo";
            this.toolbar_redo.Size = new System.Drawing.Size(28, 28);
            this.toolbar_redo.Text = "Redo";
            this.toolbar_redo.Click += new System.EventHandler(this.toolbar_redo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolbar_grid
            // 
            this.toolbar_grid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_grid.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_grid.Image")));
            this.toolbar_grid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_grid.Name = "toolbar_grid";
            this.toolbar_grid.Size = new System.Drawing.Size(28, 28);
            this.toolbar_grid.Text = "Show Grid";
            this.toolbar_grid.Click += new System.EventHandler(this.toolbar_grid_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // toolbar_layer_down
            // 
            this.toolbar_layer_down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_layer_down.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_layer_down.Image")));
            this.toolbar_layer_down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_layer_down.Name = "toolbar_layer_down";
            this.toolbar_layer_down.Size = new System.Drawing.Size(28, 28);
            this.toolbar_layer_down.Text = "Move to Lower Layer";
            this.toolbar_layer_down.Click += new System.EventHandler(this.toolbar_layer_down_Click);
            // 
            // toolbar_lbl_layer
            // 
            this.toolbar_lbl_layer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolbar_lbl_layer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolbar_lbl_layer.Enabled = false;
            this.toolbar_lbl_layer.Name = "toolbar_lbl_layer";
            this.toolbar_lbl_layer.Size = new System.Drawing.Size(35, 31);
            this.toolbar_lbl_layer.Text = "xx/xx";
            this.toolbar_lbl_layer.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolbar_layer_up
            // 
            this.toolbar_layer_up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_layer_up.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_layer_up.Image")));
            this.toolbar_layer_up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_layer_up.Name = "toolbar_layer_up";
            this.toolbar_layer_up.Size = new System.Drawing.Size(28, 28);
            this.toolbar_layer_up.Text = "Move to Upper Layer";
            this.toolbar_layer_up.Click += new System.EventHandler(this.toolbar_layer_up_Click);
            // 
            // toolbar_visibility
            // 
            this.toolbar_visibility.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_visibility.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_visibility.Image")));
            this.toolbar_visibility.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_visibility.Name = "toolbar_visibility";
            this.toolbar_visibility.Size = new System.Drawing.Size(28, 28);
            this.toolbar_visibility.Text = "Show / Hide other Layers";
            this.toolbar_visibility.Click += new System.EventHandler(this.toolbar_visibility_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // toolbar_brush
            // 
            this.toolbar_brush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_brush.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_brush.Image")));
            this.toolbar_brush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_brush.Name = "toolbar_brush";
            this.toolbar_brush.Size = new System.Drawing.Size(28, 28);
            this.toolbar_brush.Text = "Tile Brush ";
            this.toolbar_brush.Click += new System.EventHandler(this.toolbar_brush_Click);
            // 
            // toolbar_marquee
            // 
            this.toolbar_marquee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_marquee.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_marquee.Image")));
            this.toolbar_marquee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_marquee.Name = "toolbar_marquee";
            this.toolbar_marquee.Size = new System.Drawing.Size(28, 28);
            this.toolbar_marquee.Text = "Marquee Paint";
            this.toolbar_marquee.Click += new System.EventHandler(this.toolbar_marquee_Click);
            // 
            // toolbar_marquee_eraser
            // 
            this.toolbar_marquee_eraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_marquee_eraser.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_marquee_eraser.Image")));
            this.toolbar_marquee_eraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_marquee_eraser.Name = "toolbar_marquee_eraser";
            this.toolbar_marquee_eraser.Size = new System.Drawing.Size(28, 28);
            this.toolbar_marquee_eraser.Text = "toolStripButton1";
            this.toolbar_marquee_eraser.ToolTipText = "Marquee Erase";
            this.toolbar_marquee_eraser.Click += new System.EventHandler(this.toolbar_marquee_eraser_Click);
            // 
            // toolbar_eraser
            // 
            this.toolbar_eraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_eraser.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_eraser.Image")));
            this.toolbar_eraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_eraser.Name = "toolbar_eraser";
            this.toolbar_eraser.Size = new System.Drawing.Size(28, 28);
            this.toolbar_eraser.Text = "Tile Eraser";
            this.toolbar_eraser.Visible = false;
            this.toolbar_eraser.Click += new System.EventHandler(this.toolbar_eraser_Click);
            // 
            // toolbar_bucket
            // 
            this.toolbar_bucket.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_bucket.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_bucket.Image")));
            this.toolbar_bucket.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_bucket.Name = "toolbar_bucket";
            this.toolbar_bucket.Size = new System.Drawing.Size(28, 28);
            this.toolbar_bucket.Text = "Tile Filler";
            this.toolbar_bucket.Click += new System.EventHandler(this.toolbar_bucket_Click);
            // 
            // toolbar_marquee_walk
            // 
            this.toolbar_marquee_walk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_marquee_walk.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_marquee_walk.Image")));
            this.toolbar_marquee_walk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_marquee_walk.Name = "toolbar_marquee_walk";
            this.toolbar_marquee_walk.Size = new System.Drawing.Size(28, 28);
            this.toolbar_marquee_walk.Click += new System.EventHandler(this.toolbar_marquee_walk_Click);
            // 
            // toolbar_walkability
            // 
            this.toolbar_walkability.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_walkability.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_walkability.Image")));
            this.toolbar_walkability.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_walkability.Name = "toolbar_walkability";
            this.toolbar_walkability.Size = new System.Drawing.Size(28, 28);
            this.toolbar_walkability.Text = "Block Tiles";
            this.toolbar_walkability.Visible = false;
            this.toolbar_walkability.Click += new System.EventHandler(this.toolbar_walkability_Click);
            // 
            // toolbar_select
            // 
            this.toolbar_select.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_select.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_select.Image")));
            this.toolbar_select.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_select.Name = "toolbar_select";
            this.toolbar_select.Size = new System.Drawing.Size(28, 28);
            this.toolbar_select.Text = "Move Tiles";
            this.toolbar_select.Click += new System.EventHandler(this.toolbar_select_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 31);
            // 
            // toolbar_txt_location
            // 
            this.toolbar_txt_location.Name = "toolbar_txt_location";
            this.toolbar_txt_location.Size = new System.Drawing.Size(0, 28);
            // 
            // toolbar_terrain_brush
            // 
            this.toolbar_terrain_brush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_terrain_brush.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_terrain_brush.Image")));
            this.toolbar_terrain_brush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_terrain_brush.Name = "toolbar_terrain_brush";
            this.toolbar_terrain_brush.Size = new System.Drawing.Size(28, 28);
            this.toolbar_terrain_brush.Text = "toolStripButton1";
            this.toolbar_terrain_brush.Click += new System.EventHandler(this.toolbar_terrain_brush_Click);
            // 
            // toolbar_terrain_combo
            // 
            this.toolbar_terrain_combo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolbar_terrain_combo.Name = "toolbar_terrain_combo";
            this.toolbar_terrain_combo.Size = new System.Drawing.Size(121, 31);
            // 
            // toolbar_portal
            // 
            this.toolbar_portal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_portal.Image = global::XNA_Map_Editor.Properties.Resources.bluePortal;
            this.toolbar_portal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_portal.Name = "toolbar_portal";
            this.toolbar_portal.Size = new System.Drawing.Size(28, 28);
            this.toolbar_portal.Text = "toolStripButton1";
            this.toolbar_portal.Click += new System.EventHandler(this.toolbar_portal_Click);
            // 
            // toolbar_ManagePortals
            // 
            this.toolbar_ManagePortals.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_ManagePortals.Image = global::XNA_Map_Editor.Properties.Resources.orangePortal;
            this.toolbar_ManagePortals.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_ManagePortals.Name = "toolbar_ManagePortals";
            this.toolbar_ManagePortals.Size = new System.Drawing.Size(28, 28);
            this.toolbar_ManagePortals.Text = "toolStripButton1";
            this.toolbar_ManagePortals.Click += new System.EventHandler(this.toolbar_ManagePortals_Click);
            // 
            // toolbar_chest
            // 
            this.toolbar_chest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_chest.Image = global::XNA_Map_Editor.Properties.Resources.chest16;
            this.toolbar_chest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_chest.Name = "toolbar_chest";
            this.toolbar_chest.Size = new System.Drawing.Size(28, 28);
            this.toolbar_chest.Text = "toolStripButton1";
            this.toolbar_chest.Click += new System.EventHandler(this.toolbar_chest_Click);
            // 
            // toolbar_NPC
            // 
            this.toolbar_NPC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_NPC.Image = global::XNA_Map_Editor.Properties.Resources.npc16;
            this.toolbar_NPC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_NPC.Name = "toolbar_NPC";
            this.toolbar_NPC.Size = new System.Drawing.Size(28, 28);
            this.toolbar_NPC.Text = "toolStripButton2";
            this.toolbar_NPC.Click += new System.EventHandler(this.toolbar_NPC_Click);
            // 
            // toolbar_fixedCombat
            // 
            this.toolbar_fixedCombat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_fixedCombat.Image = global::XNA_Map_Editor.Properties.Resources.monster16;
            this.toolbar_fixedCombat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_fixedCombat.Name = "toolbar_fixedCombat";
            this.toolbar_fixedCombat.Size = new System.Drawing.Size(28, 28);
            this.toolbar_fixedCombat.Text = "toolStripButton3";
            this.toolbar_fixedCombat.Click += new System.EventHandler(this.toolbar_fixedCombat_Click);
            // 
            // toolbar_block
            // 
            this.toolbar_block.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_block.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_block.Image")));
            this.toolbar_block.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_block.Name = "toolbar_block";
            this.toolbar_block.Size = new System.Drawing.Size(28, 28);
            this.toolbar_block.Text = "toolStripButton1";
            this.toolbar_block.Click += new System.EventHandler(this.toolbar_Block_Click);
            // 
            // toolbar_switch
            // 
            this.toolbar_switch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_switch.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_switch.Image")));
            this.toolbar_switch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_switch.Name = "toolbar_switch";
            this.toolbar_switch.Size = new System.Drawing.Size(28, 28);
            this.toolbar_switch.Text = "toolStripButton2";
            this.toolbar_switch.Click += new System.EventHandler(this.toolbar_Switch_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 55);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grp_tile_map);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grp_tile_palette);
            this.splitContainer1.Size = new System.Drawing.Size(1020, 646);
            this.splitContainer1.SplitterDistance = 646;
            this.splitContainer1.TabIndex = 9;
            // 
            // grp_tile_map
            // 
            this.grp_tile_map.Controls.Add(this.pnl_tile_map);
            this.grp_tile_map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_tile_map.Location = new System.Drawing.Point(0, 0);
            this.grp_tile_map.Margin = new System.Windows.Forms.Padding(0);
            this.grp_tile_map.Name = "grp_tile_map";
            this.grp_tile_map.Padding = new System.Windows.Forms.Padding(0);
            this.grp_tile_map.Size = new System.Drawing.Size(646, 646);
            this.grp_tile_map.TabIndex = 2;
            this.grp_tile_map.TabStop = false;
            // 
            // pnl_tile_map
            // 
            this.pnl_tile_map.Controls.Add(this.tab_control);
            this.pnl_tile_map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_tile_map.Location = new System.Drawing.Point(0, 13);
            this.pnl_tile_map.Name = "pnl_tile_map";
            this.pnl_tile_map.Size = new System.Drawing.Size(646, 633);
            this.pnl_tile_map.TabIndex = 0;
            // 
            // tab_control
            // 
            this.tab_control.Controls.Add(this.tabPage1);
            this.tab_control.Controls.Add(this.tabPage2);
            this.tab_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_control.Location = new System.Drawing.Point(0, 0);
            this.tab_control.Name = "tab_control";
            this.tab_control.SelectedIndex = 0;
            this.tab_control.Size = new System.Drawing.Size(646, 633);
            this.tab_control.TabIndex = 7;
            this.tab_control.Click += new System.EventHandler(this.tab_control_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.hscroll_xna);
            this.tabPage1.Controls.Add(this.pnl_scroll_filler);
            this.tabPage1.Controls.Add(this.vscroll_xna);
            this.tabPage1.Controls.Add(this.xna_renderer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(638, 607);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MAP";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // hscroll_xna
            // 
            this.hscroll_xna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hscroll_xna.Location = new System.Drawing.Point(3, 588);
            this.hscroll_xna.Name = "hscroll_xna";
            this.hscroll_xna.Size = new System.Drawing.Size(618, 17);
            this.hscroll_xna.TabIndex = 8;
            this.hscroll_xna.Visible = false;
            this.hscroll_xna.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscroll_xna_Scroll);
            // 
            // pnl_scroll_filler
            // 
            this.pnl_scroll_filler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_scroll_filler.Location = new System.Drawing.Point(618, 588);
            this.pnl_scroll_filler.Name = "pnl_scroll_filler";
            this.pnl_scroll_filler.Size = new System.Drawing.Size(20, 17);
            this.pnl_scroll_filler.TabIndex = 5;
            // 
            // vscroll_xna
            // 
            this.vscroll_xna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vscroll_xna.Location = new System.Drawing.Point(621, -3);
            this.vscroll_xna.Name = "vscroll_xna";
            this.vscroll_xna.Size = new System.Drawing.Size(17, 591);
            this.vscroll_xna.TabIndex = 4;
            this.vscroll_xna.Visible = false;
            this.vscroll_xna.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vscroll_xna_Scroll);
            // 
            // xna_renderer
            // 
            this.xna_renderer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xna_renderer.Location = new System.Drawing.Point(3, 3);
            this.xna_renderer.Margin = new System.Windows.Forms.Padding(0);
            this.xna_renderer.Name = "xna_renderer";
            this.xna_renderer.Size = new System.Drawing.Size(632, 601);
            this.xna_renderer.TabIndex = 7;
            this.xna_renderer.Text = "XNA Renderer";
            this.xna_renderer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xna_renderer_MouseDown);
            this.xna_renderer.MouseEnter += new System.EventHandler(this.xna_renderer_MouseEnter);
            this.xna_renderer.MouseLeave += new System.EventHandler(this.xna_renderer_MouseLeave);
            this.xna_renderer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.xna_renderer_MouseMove);
            this.xna_renderer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xna_renderer_MouseUp);
            this.xna_renderer.Resize += new System.EventHandler(this.MainForm_Resize);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rch_txtbox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(638, 607);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "XML";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rch_txtbox
            // 
            this.rch_txtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rch_txtbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rch_txtbox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rch_txtbox.Location = new System.Drawing.Point(3, 3);
            this.rch_txtbox.Margin = new System.Windows.Forms.Padding(0);
            this.rch_txtbox.Name = "rch_txtbox";
            this.rch_txtbox.ReadOnly = true;
            this.rch_txtbox.Size = new System.Drawing.Size(632, 601);
            this.rch_txtbox.TabIndex = 0;
            this.rch_txtbox.Text = "";
            this.rch_txtbox.WordWrap = false;
            // 
            // grp_tile_palette
            // 
            this.grp_tile_palette.Controls.Add(this.pnl_tile_palette);
            this.grp_tile_palette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_tile_palette.Location = new System.Drawing.Point(0, 0);
            this.grp_tile_palette.Name = "grp_tile_palette";
            this.grp_tile_palette.Size = new System.Drawing.Size(370, 646);
            this.grp_tile_palette.TabIndex = 7;
            this.grp_tile_palette.TabStop = false;
            // 
            // pnl_tile_palette
            // 
            this.pnl_tile_palette.AutoScroll = true;
            this.pnl_tile_palette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_tile_palette.Location = new System.Drawing.Point(3, 16);
            this.pnl_tile_palette.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_tile_palette.Name = "pnl_tile_palette";
            this.pnl_tile_palette.Size = new System.Drawing.Size(364, 627);
            this.pnl_tile_palette.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 701);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XNA Tile Map Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grp_tile_map.ResumeLayout(false);
            this.pnl_tile_map.ResumeLayout(false);
            this.tab_control.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.grp_tile_palette.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHideGridToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton toolbar_new_map;
        private System.Windows.Forms.ToolStripButton toolbar_load_tileset;
        private System.Windows.Forms.ToolStripButton toolbar_save_map;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolbar_undo;
        private System.Windows.Forms.ToolStripButton toolbar_redo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolbar_grid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolbar_brush;
        private System.Windows.Forms.ToolStripButton toolbar_layer_up;
        private System.Windows.Forms.ToolStripButton toolbar_layer_down;
        private System.Windows.Forms.ToolStripTextBox toolbar_lbl_layer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolbar_visibility;
        private System.Windows.Forms.ToolStripButton toolbar_eraser;
        private System.Windows.Forms.ToolStripMenuItem loadMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolbar_export_xml;
        private System.Windows.Forms.ToolStripButton toolbar_bucket;
        private System.Windows.Forms.ToolStripButton toolbar_walkability;
        private System.Windows.Forms.ToolStripButton toolbar_load_map;
        private System.Windows.Forms.ToolStripButton toolbar_marquee;
        private System.Windows.Forms.ToolStripMenuItem showHideBlockedTilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolbar_txt_location;
        private System.Windows.Forms.ToolStripMenuItem generateTextureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedTilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unblockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grp_tile_map;
        private System.Windows.Forms.Panel pnl_tile_map;
        private System.Windows.Forms.TabControl tab_control;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.HScrollBar hscroll_xna;
        private System.Windows.Forms.Panel pnl_scroll_filler;
        private System.Windows.Forms.VScrollBar vscroll_xna;
        private XNARenderer xna_renderer;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.RichTextBox rch_txtbox;
        private System.Windows.Forms.GroupBox grp_tile_palette;
        private System.Windows.Forms.Panel pnl_tile_palette;
        private System.Windows.Forms.ToolStripButton toolbar_marquee_eraser;
        private System.Windows.Forms.ToolStripButton toolbar_marquee_walk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem applyCollisionTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem manageTerrainTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHideTerrainTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolbar_terrain_brush;
        public System.Windows.Forms.ToolStripComboBox toolbar_terrain_combo;
        private System.Windows.Forms.ToolStripMenuItem editTileSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolbar_portal;
        private System.Windows.Forms.ToolStripButton toolbar_ManagePortals;
        private System.Windows.Forms.ToolStripButton toolbar_chest;
        private System.Windows.Forms.ToolStripButton toolbar_NPC;
        private System.Windows.Forms.ToolStripButton toolbar_fixedCombat;
        private System.Windows.Forms.ToolStripButton toolbar_block;
        private System.Windows.Forms.ToolStripButton toolbar_switch;
        private System.Windows.Forms.ToolStripButton toolbar_select;
    }
}

