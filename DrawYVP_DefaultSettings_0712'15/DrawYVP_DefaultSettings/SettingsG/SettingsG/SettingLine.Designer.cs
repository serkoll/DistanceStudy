namespace SettingsG
{
    partial class SettingLine
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
            this.lineWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.lineWidth = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.lineColorBox = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.nameLine1stPlaneBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.iconsLine1stPlaneList = new System.Windows.Forms.ListBox();
            this.colorLine1stPlaneBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.nameLine2ndPlaneBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.iconsLine2ndPlaneBox = new System.Windows.Forms.ListBox();
            this.colorLine2ndPlaneBox = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.nameLine3rdPlaneBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.iconsLine3rdPlaneBox = new System.Windows.Forms.ListBox();
            this.colorLine3rdPlaneBox = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineColorBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorLine1stPlaneBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorLine2ndPlaneBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorLine3rdPlaneBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lineWidthUpDown
            // 
            this.lineWidthUpDown.Location = new System.Drawing.Point(233, 35);
            this.lineWidthUpDown.Name = "lineWidthUpDown";
            this.lineWidthUpDown.Size = new System.Drawing.Size(42, 20);
            this.lineWidthUpDown.TabIndex = 0;
            // 
            // lineWidth
            // 
            this.lineWidth.AutoSize = true;
            this.lineWidth.Location = new System.Drawing.Point(51, 37);
            this.lineWidth.Name = "lineWidth";
            this.lineWidth.Size = new System.Drawing.Size(53, 13);
            this.lineWidth.TabIndex = 1;
            this.lineWidth.Text = "Толщина";
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(51, 70);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(32, 13);
            this.colorLabel.TabIndex = 2;
            this.colorLabel.Text = "Цвет";
            // 
            // lineColorBox
            // 
            this.lineColorBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lineColorBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineColorBox.Location = new System.Drawing.Point(233, 65);
            this.lineColorBox.Name = "lineColorBox";
            this.lineColorBox.Size = new System.Drawing.Size(25, 25);
            this.lineColorBox.TabIndex = 3;
            this.lineColorBox.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(54, 107);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(195, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Отображение инцидентных точек";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(54, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 232);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Проекции";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(408, 209);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.nameLine1stPlaneBox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.iconsLine1stPlaneList);
            this.tabPage1.Controls.Add(this.colorLine1stPlaneBox);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(400, 183);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1-я проекция";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // nameLine1stPlaneBox
            // 
            this.nameLine1stPlaneBox.FormattingEnabled = true;
            this.nameLine1stPlaneBox.Items.AddRange(new object[] {
            "L1",
            "L\'"});
            this.nameLine1stPlaneBox.Location = new System.Drawing.Point(316, 31);
            this.nameLine1stPlaneBox.Name = "nameLine1stPlaneBox";
            this.nameLine1stPlaneBox.Size = new System.Drawing.Size(45, 21);
            this.nameLine1stPlaneBox.TabIndex = 24;
            this.nameLine1stPlaneBox.SelectedIndexChanged += new System.EventHandler(this.nameLine1stPlaneBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Обозначение";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Значок";
            // 
            // iconsLine1stPlaneList
            // 
            this.iconsLine1stPlaneList.FormattingEnabled = true;
            this.iconsLine1stPlaneList.Items.AddRange(new object[] {
            "icon1",
            "icon2",
            "icon3"});
            this.iconsLine1stPlaneList.Location = new System.Drawing.Point(103, 63);
            this.iconsLine1stPlaneList.Name = "iconsLine1stPlaneList";
            this.iconsLine1stPlaneList.Size = new System.Drawing.Size(107, 95);
            this.iconsLine1stPlaneList.TabIndex = 21;
            // 
            // colorLine1stPlaneBox
            // 
            this.colorLine1stPlaneBox.BackColor = System.Drawing.SystemColors.Control;
            this.colorLine1stPlaneBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorLine1stPlaneBox.Location = new System.Drawing.Point(103, 25);
            this.colorLine1stPlaneBox.Name = "colorLine1stPlaneBox";
            this.colorLine1stPlaneBox.Size = new System.Drawing.Size(36, 31);
            this.colorLine1stPlaneBox.TabIndex = 20;
            this.colorLine1stPlaneBox.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Цвет";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.nameLine2ndPlaneBox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.iconsLine2ndPlaneBox);
            this.tabPage2.Controls.Add(this.colorLine2ndPlaneBox);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(400, 183);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2-я проекция";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // nameLine2ndPlaneBox
            // 
            this.nameLine2ndPlaneBox.FormattingEnabled = true;
            this.nameLine2ndPlaneBox.Items.AddRange(new object[] {
            "L2",
            "L\'\'"});
            this.nameLine2ndPlaneBox.Location = new System.Drawing.Point(316, 31);
            this.nameLine2ndPlaneBox.Name = "nameLine2ndPlaneBox";
            this.nameLine2ndPlaneBox.Size = new System.Drawing.Size(45, 21);
            this.nameLine2ndPlaneBox.TabIndex = 24;
            this.nameLine2ndPlaneBox.SelectedIndexChanged += new System.EventHandler(this.nameLine2ndPlaneBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Обозначение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Значок";
            // 
            // iconsLine2ndPlaneBox
            // 
            this.iconsLine2ndPlaneBox.FormattingEnabled = true;
            this.iconsLine2ndPlaneBox.Items.AddRange(new object[] {
            "icon1",
            "icon2",
            "icon3"});
            this.iconsLine2ndPlaneBox.Location = new System.Drawing.Point(103, 63);
            this.iconsLine2ndPlaneBox.Name = "iconsLine2ndPlaneBox";
            this.iconsLine2ndPlaneBox.Size = new System.Drawing.Size(107, 95);
            this.iconsLine2ndPlaneBox.TabIndex = 21;
            // 
            // colorLine2ndPlaneBox
            // 
            this.colorLine2ndPlaneBox.BackColor = System.Drawing.SystemColors.Control;
            this.colorLine2ndPlaneBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorLine2ndPlaneBox.Location = new System.Drawing.Point(103, 25);
            this.colorLine2ndPlaneBox.Name = "colorLine2ndPlaneBox";
            this.colorLine2ndPlaneBox.Size = new System.Drawing.Size(36, 31);
            this.colorLine2ndPlaneBox.TabIndex = 20;
            this.colorLine2ndPlaneBox.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Цвет";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.nameLine3rdPlaneBox);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.iconsLine3rdPlaneBox);
            this.tabPage3.Controls.Add(this.colorLine3rdPlaneBox);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(400, 183);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "3-я проекция";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // nameLine3rdPlaneBox
            // 
            this.nameLine3rdPlaneBox.FormattingEnabled = true;
            this.nameLine3rdPlaneBox.Items.AddRange(new object[] {
            "L3",
            "L\'\'\'"});
            this.nameLine3rdPlaneBox.Location = new System.Drawing.Point(316, 31);
            this.nameLine3rdPlaneBox.Name = "nameLine3rdPlaneBox";
            this.nameLine3rdPlaneBox.Size = new System.Drawing.Size(45, 21);
            this.nameLine3rdPlaneBox.TabIndex = 24;
            this.nameLine3rdPlaneBox.SelectedIndexChanged += new System.EventHandler(this.nameLine3rdPlaneBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(230, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Обозначение";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Значок";
            // 
            // iconsLine3rdPlaneBox
            // 
            this.iconsLine3rdPlaneBox.FormattingEnabled = true;
            this.iconsLine3rdPlaneBox.Items.AddRange(new object[] {
            "icon1",
            "icon2",
            "icon3"});
            this.iconsLine3rdPlaneBox.Location = new System.Drawing.Point(103, 63);
            this.iconsLine3rdPlaneBox.Name = "iconsLine3rdPlaneBox";
            this.iconsLine3rdPlaneBox.Size = new System.Drawing.Size(107, 95);
            this.iconsLine3rdPlaneBox.TabIndex = 21;
            // 
            // colorLine3rdPlaneBox
            // 
            this.colorLine3rdPlaneBox.BackColor = System.Drawing.SystemColors.Control;
            this.colorLine3rdPlaneBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorLine3rdPlaneBox.Location = new System.Drawing.Point(103, 25);
            this.colorLine3rdPlaneBox.Name = "colorLine3rdPlaneBox";
            this.colorLine3rdPlaneBox.Size = new System.Drawing.Size(36, 31);
            this.colorLine3rdPlaneBox.TabIndex = 20;
            this.colorLine3rdPlaneBox.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Цвет";
            // 
            // SettingLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lineColorBox);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.lineWidth);
            this.Controls.Add(this.lineWidthUpDown);
            this.Name = "SettingLine";
            this.Size = new System.Drawing.Size(496, 375);
            ((System.ComponentModel.ISupportInitialize)(this.lineWidthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineColorBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorLine1stPlaneBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorLine2ndPlaneBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorLine3rdPlaneBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lineWidth;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.ComboBox nameLine1stPlaneBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ListBox iconsLine1stPlaneList;
        public System.Windows.Forms.PictureBox colorLine1stPlaneBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.ComboBox nameLine2ndPlaneBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ListBox iconsLine2ndPlaneBox;
        public System.Windows.Forms.PictureBox colorLine2ndPlaneBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.ComboBox nameLine3rdPlaneBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ListBox iconsLine3rdPlaneBox;
        public System.Windows.Forms.PictureBox colorLine3rdPlaneBox;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.NumericUpDown lineWidthUpDown;
        public System.Windows.Forms.PictureBox lineColorBox;
        public System.Windows.Forms.CheckBox checkBox1;
    }
}
