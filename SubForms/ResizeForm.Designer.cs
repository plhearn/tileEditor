namespace XNA_Map_Editor.SubForms
{
    partial class ResizeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_height = new System.Windows.Forms.TextBox();
            this.txt_width = new System.Windows.Forms.TextBox();
            this.txt_layers = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.updwn_height = new System.Windows.Forms.NumericUpDown();
            this.updwn_width = new System.Windows.Forms.NumericUpDown();
            this.updwn_depth = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_resize = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updwn_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updwn_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updwn_depth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "RESIZE MAP";
            this.label1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_height);
            this.groupBox1.Controls.Add(this.txt_width);
            this.groupBox1.Controls.Add(this.txt_layers);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 146);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Dimensions";
            // 
            // txt_height
            // 
            this.txt_height.BackColor = System.Drawing.Color.Beige;
            this.txt_height.Enabled = false;
            this.txt_height.Location = new System.Drawing.Point(70, 108);
            this.txt_height.Name = "txt_height";
            this.txt_height.Size = new System.Drawing.Size(46, 20);
            this.txt_height.TabIndex = 5;
            // 
            // txt_width
            // 
            this.txt_width.BackColor = System.Drawing.Color.Beige;
            this.txt_width.Enabled = false;
            this.txt_width.Location = new System.Drawing.Point(70, 64);
            this.txt_width.Name = "txt_width";
            this.txt_width.Size = new System.Drawing.Size(46, 20);
            this.txt_width.TabIndex = 4;
            // 
            // txt_layers
            // 
            this.txt_layers.BackColor = System.Drawing.Color.Beige;
            this.txt_layers.Enabled = false;
            this.txt_layers.Location = new System.Drawing.Point(70, 20);
            this.txt_layers.Name = "txt_layers";
            this.txt_layers.Size = new System.Drawing.Size(46, 20);
            this.txt_layers.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Layers";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.updwn_height);
            this.groupBox2.Controls.Add(this.updwn_width);
            this.groupBox2.Controls.Add(this.updwn_depth);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(157, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 146);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Dimensions";
            // 
            // updwn_height
            // 
            this.updwn_height.Location = new System.Drawing.Point(73, 108);
            this.updwn_height.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.updwn_height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updwn_height.Name = "updwn_height";
            this.updwn_height.Size = new System.Drawing.Size(46, 20);
            this.updwn_height.TabIndex = 8;
            this.updwn_height.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // updwn_width
            // 
            this.updwn_width.Location = new System.Drawing.Point(73, 64);
            this.updwn_width.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.updwn_width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updwn_width.Name = "updwn_width";
            this.updwn_width.Size = new System.Drawing.Size(46, 20);
            this.updwn_width.TabIndex = 7;
            this.updwn_width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // updwn_depth
            // 
            this.updwn_depth.Location = new System.Drawing.Point(73, 20);
            this.updwn_depth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updwn_depth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updwn_depth.Name = "updwn_depth";
            this.updwn_depth.Size = new System.Drawing.Size(46, 20);
            this.updwn_depth.TabIndex = 6;
            this.updwn_depth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Width";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Layers";
            // 
            // btn_resize
            // 
            this.btn_resize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_resize.Location = new System.Drawing.Point(28, 212);
            this.btn_resize.Name = "btn_resize";
            this.btn_resize.Size = new System.Drawing.Size(109, 33);
            this.btn_resize.TabIndex = 4;
            this.btn_resize.Text = "Resize";
            this.btn_resize.UseVisualStyleBackColor = true;
            this.btn_resize.Click += new System.EventHandler(this.btn_resize_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(175, 212);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(109, 33);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ResizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 257);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_resize);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ResizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Resize Map";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updwn_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updwn_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updwn_depth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_height;
        private System.Windows.Forms.TextBox txt_width;
        private System.Windows.Forms.TextBox txt_layers;
        private System.Windows.Forms.NumericUpDown updwn_height;
        private System.Windows.Forms.NumericUpDown updwn_width;
        private System.Windows.Forms.NumericUpDown updwn_depth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_resize;
        private System.Windows.Forms.Button btn_cancel;
    }
}