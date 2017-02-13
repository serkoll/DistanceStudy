namespace GraphicsModule.Settings.Controls
{
    partial class SettingsLink
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.linkToAxis1OnOff = new System.Windows.Forms.CheckBox();
            this.linkToAxis2OnOff = new System.Windows.Forms.CheckBox();
            this.linkToAxis3OnOff = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.link1ColorBox = new System.Windows.Forms.PictureBox();
            this.linkWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.link2ColorBox = new System.Windows.Forms.PictureBox();
            this.link3ColorBox = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.colorDialog3 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.link1ColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.link2ColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.link3ColorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // linkToAxis1OnOff
            // 
            this.linkToAxis1OnOff.AutoSize = true;
            this.linkToAxis1OnOff.Location = new System.Drawing.Point(38, 23);
            this.linkToAxis1OnOff.Name = "linkToAxis1OnOff";
            this.linkToAxis1OnOff.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.linkToAxis1OnOff.Size = new System.Drawing.Size(208, 17);
            this.linkToAxis1OnOff.TabIndex = 0;
            this.linkToAxis1OnOff.Text = "     Отобразить линию связи к оси 1";
            this.linkToAxis1OnOff.UseVisualStyleBackColor = true;
            // 
            // linkToAxis2OnOff
            // 
            this.linkToAxis2OnOff.AutoSize = true;
            this.linkToAxis2OnOff.Location = new System.Drawing.Point(38, 55);
            this.linkToAxis2OnOff.Name = "linkToAxis2OnOff";
            this.linkToAxis2OnOff.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.linkToAxis2OnOff.Size = new System.Drawing.Size(208, 17);
            this.linkToAxis2OnOff.TabIndex = 1;
            this.linkToAxis2OnOff.Text = "     Отобразить линию связи к оси 2";
            this.linkToAxis2OnOff.UseVisualStyleBackColor = true;
            // 
            // linkToAxis3OnOff
            // 
            this.linkToAxis3OnOff.AutoSize = true;
            this.linkToAxis3OnOff.Location = new System.Drawing.Point(38, 87);
            this.linkToAxis3OnOff.Name = "linkToAxis3OnOff";
            this.linkToAxis3OnOff.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.linkToAxis3OnOff.Size = new System.Drawing.Size(208, 17);
            this.linkToAxis3OnOff.TabIndex = 2;
            this.linkToAxis3OnOff.Text = "     Отобразить линию связи к оси 3";
            this.linkToAxis3OnOff.UseVisualStyleBackColor = true;
            // 
            // link1ColorBox
            // 
            this.link1ColorBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.link1ColorBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.link1ColorBox.Location = new System.Drawing.Point(324, 21);
            this.link1ColorBox.Name = "link1ColorBox";
            this.link1ColorBox.Size = new System.Drawing.Size(25, 25);
            this.link1ColorBox.TabIndex = 3;
            this.link1ColorBox.TabStop = false;
            this.link1ColorBox.Click += new System.EventHandler(this.link1ColorBox_Click);
            // 
            // linkWidth
            // 
            this.linkWidth.Location = new System.Drawing.Point(229, 135);
            this.linkWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.linkWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.linkWidth.Name = "linkWidth";
            this.linkWidth.Size = new System.Drawing.Size(35, 20);
            this.linkWidth.TabIndex = 5;
            this.linkWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Толщина";
            // 
            // link2ColorBox
            // 
            this.link2ColorBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.link2ColorBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.link2ColorBox.Location = new System.Drawing.Point(324, 52);
            this.link2ColorBox.Name = "link2ColorBox";
            this.link2ColorBox.Size = new System.Drawing.Size(25, 25);
            this.link2ColorBox.TabIndex = 7;
            this.link2ColorBox.TabStop = false;
            this.link2ColorBox.Click += new System.EventHandler(this.link2ColorBox_Click);
            // 
            // link3ColorBox
            // 
            this.link3ColorBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.link3ColorBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.link3ColorBox.Location = new System.Drawing.Point(324, 83);
            this.link3ColorBox.Name = "link3ColorBox";
            this.link3ColorBox.Size = new System.Drawing.Size(25, 25);
            this.link3ColorBox.TabIndex = 8;
            this.link3ColorBox.TabStop = false;
            this.link3ColorBox.Click += new System.EventHandler(this.link3ColorBox_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(38, 178);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(280, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "     Согласовать цвета линий связи с цветом осей";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SettingsLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.link3ColorBox);
            this.Controls.Add(this.link2ColorBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkWidth);
            this.Controls.Add(this.link1ColorBox);
            this.Controls.Add(this.linkToAxis3OnOff);
            this.Controls.Add(this.linkToAxis2OnOff);
            this.Controls.Add(this.linkToAxis1OnOff);
            this.Name = "SettingsLink";
            this.Size = new System.Drawing.Size(451, 288);
            ((System.ComponentModel.ISupportInitialize)(this.link1ColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.link2ColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.link3ColorBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox linkToAxis1OnOff;
        public System.Windows.Forms.CheckBox linkToAxis2OnOff;
        public System.Windows.Forms.CheckBox linkToAxis3OnOff;
        public System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.PictureBox link1ColorBox;
        public System.Windows.Forms.NumericUpDown linkWidth;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.PictureBox link2ColorBox;
        public System.Windows.Forms.PictureBox link3ColorBox;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.ColorDialog colorDialog2;
        public System.Windows.Forms.ColorDialog colorDialog3;
    }
}
