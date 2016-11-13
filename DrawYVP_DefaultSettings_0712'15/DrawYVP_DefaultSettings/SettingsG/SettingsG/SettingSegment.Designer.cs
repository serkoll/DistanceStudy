namespace SettingsG
{
    partial class SettingSegment
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
            this.endPointsOnOff = new System.Windows.Forms.CheckBox();
            this.segmentColorBox = new System.Windows.Forms.PictureBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.lineWidth = new System.Windows.Forms.Label();
            this.segmentWidth = new System.Windows.Forms.NumericUpDown();
            this.styleWidthList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.nameSegment1stPlaneBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.iconsSegment1stPlaneList = new System.Windows.Forms.ListBox();
            this.colorSegment1stPlaneBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.nameSegment2ndPlaneBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.iconsSegment2ndPlaneBox = new System.Windows.Forms.ListBox();
            this.colorSegment2ndPlaneBox = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.nameSegment3rdPlaneBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.iconsSegment3rdPlaneBox = new System.Windows.Forms.ListBox();
            this.colorSegment3rdPlaneBox = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.colorDialog3 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.segmentColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.segmentWidth)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorSegment1stPlaneBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorSegment2ndPlaneBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorSegment3rdPlaneBox)).BeginInit();
            this.SuspendLayout();
            // 
            // endPointsOnOff
            // 
            this.endPointsOnOff.AutoSize = true;
            this.endPointsOnOff.Location = new System.Drawing.Point(53, 213);
            this.endPointsOnOff.Name = "endPointsOnOff";
            this.endPointsOnOff.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.endPointsOnOff.Size = new System.Drawing.Size(193, 17);
            this.endPointsOnOff.TabIndex = 9;
            this.endPointsOnOff.Text = "     Отображение концевых точек";
            this.endPointsOnOff.UseVisualStyleBackColor = true;
            // 
            // segmentColorBox
            // 
            this.segmentColorBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.segmentColorBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.segmentColorBox.Location = new System.Drawing.Point(232, 165);
            this.segmentColorBox.Name = "segmentColorBox";
            this.segmentColorBox.Size = new System.Drawing.Size(25, 25);
            this.segmentColorBox.TabIndex = 8;
            this.segmentColorBox.TabStop = false;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(50, 172);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(32, 13);
            this.colorLabel.TabIndex = 7;
            this.colorLabel.Text = "Цвет";
            // 
            // lineWidth
            // 
            this.lineWidth.AutoSize = true;
            this.lineWidth.Location = new System.Drawing.Point(50, 35);
            this.lineWidth.Name = "lineWidth";
            this.lineWidth.Size = new System.Drawing.Size(53, 13);
            this.lineWidth.TabIndex = 6;
            this.lineWidth.Text = "Толщина";
            // 
            // segmentWidth
            // 
            this.segmentWidth.Location = new System.Drawing.Point(232, 33);
            this.segmentWidth.Name = "segmentWidth";
            this.segmentWidth.Size = new System.Drawing.Size(42, 20);
            this.segmentWidth.TabIndex = 5;
            // 
            // styleWidthList
            // 
            this.styleWidthList.FormattingEnabled = true;
            this.styleWidthList.Items.AddRange(new object[] {
            "style1",
            "style2",
            "style3"});
            this.styleWidthList.Location = new System.Drawing.Point(232, 59);
            this.styleWidthList.Name = "styleWidthList";
            this.styleWidthList.Size = new System.Drawing.Size(120, 95);
            this.styleWidthList.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Стиль";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(53, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 228);
            this.groupBox1.TabIndex = 12;
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
            this.tabPage1.Controls.Add(this.nameSegment1stPlaneBox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.iconsSegment1stPlaneList);
            this.tabPage1.Controls.Add(this.colorSegment1stPlaneBox);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(400, 183);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1-я проекция";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // nameSegment1stPlaneBox
            // 
            this.nameSegment1stPlaneBox.FormattingEnabled = true;
            this.nameSegment1stPlaneBox.Items.AddRange(new object[] {
            "S1",
            "S\'"});
            this.nameSegment1stPlaneBox.Location = new System.Drawing.Point(316, 31);
            this.nameSegment1stPlaneBox.Name = "nameSegment1stPlaneBox";
            this.nameSegment1stPlaneBox.Size = new System.Drawing.Size(45, 21);
            this.nameSegment1stPlaneBox.TabIndex = 24;
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
            // iconsSegment1stPlaneList
            // 
            this.iconsSegment1stPlaneList.FormattingEnabled = true;
            this.iconsSegment1stPlaneList.Items.AddRange(new object[] {
            "icon1",
            "icon2",
            "icon3"});
            this.iconsSegment1stPlaneList.Location = new System.Drawing.Point(103, 63);
            this.iconsSegment1stPlaneList.Name = "iconsSegment1stPlaneList";
            this.iconsSegment1stPlaneList.Size = new System.Drawing.Size(107, 95);
            this.iconsSegment1stPlaneList.TabIndex = 21;
            // 
            // colorSegment1stPlaneBox
            // 
            this.colorSegment1stPlaneBox.BackColor = System.Drawing.SystemColors.Control;
            this.colorSegment1stPlaneBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorSegment1stPlaneBox.Location = new System.Drawing.Point(103, 25);
            this.colorSegment1stPlaneBox.Name = "colorSegment1stPlaneBox";
            this.colorSegment1stPlaneBox.Size = new System.Drawing.Size(36, 31);
            this.colorSegment1stPlaneBox.TabIndex = 20;
            this.colorSegment1stPlaneBox.TabStop = false;
            this.colorSegment1stPlaneBox.Click += new System.EventHandler(this.colorSegment1stPlaneBox_Click);
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
            this.tabPage2.Controls.Add(this.nameSegment2ndPlaneBox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.iconsSegment2ndPlaneBox);
            this.tabPage2.Controls.Add(this.colorSegment2ndPlaneBox);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(400, 183);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2-я проекция";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // nameSegment2ndPlaneBox
            // 
            this.nameSegment2ndPlaneBox.FormattingEnabled = true;
            this.nameSegment2ndPlaneBox.Items.AddRange(new object[] {
            "S2",
            "S\'\'"});
            this.nameSegment2ndPlaneBox.Location = new System.Drawing.Point(316, 31);
            this.nameSegment2ndPlaneBox.Name = "nameSegment2ndPlaneBox";
            this.nameSegment2ndPlaneBox.Size = new System.Drawing.Size(45, 21);
            this.nameSegment2ndPlaneBox.TabIndex = 24;
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
            // iconsSegment2ndPlaneBox
            // 
            this.iconsSegment2ndPlaneBox.FormattingEnabled = true;
            this.iconsSegment2ndPlaneBox.Items.AddRange(new object[] {
            "icon1",
            "icon2",
            "icon3"});
            this.iconsSegment2ndPlaneBox.Location = new System.Drawing.Point(103, 63);
            this.iconsSegment2ndPlaneBox.Name = "iconsSegment2ndPlaneBox";
            this.iconsSegment2ndPlaneBox.Size = new System.Drawing.Size(107, 95);
            this.iconsSegment2ndPlaneBox.TabIndex = 21;
            // 
            // colorSegment2ndPlaneBox
            // 
            this.colorSegment2ndPlaneBox.BackColor = System.Drawing.SystemColors.Control;
            this.colorSegment2ndPlaneBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorSegment2ndPlaneBox.Location = new System.Drawing.Point(103, 25);
            this.colorSegment2ndPlaneBox.Name = "colorSegment2ndPlaneBox";
            this.colorSegment2ndPlaneBox.Size = new System.Drawing.Size(36, 31);
            this.colorSegment2ndPlaneBox.TabIndex = 20;
            this.colorSegment2ndPlaneBox.TabStop = false;
            this.colorSegment2ndPlaneBox.Click += new System.EventHandler(this.colorSegment2ndPlaneBox_Click);
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
            this.tabPage3.Controls.Add(this.nameSegment3rdPlaneBox);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.iconsSegment3rdPlaneBox);
            this.tabPage3.Controls.Add(this.colorSegment3rdPlaneBox);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(400, 183);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "3-я проекция";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // nameSegment3rdPlaneBox
            // 
            this.nameSegment3rdPlaneBox.FormattingEnabled = true;
            this.nameSegment3rdPlaneBox.Items.AddRange(new object[] {
            "S3",
            "S\'\'\'"});
            this.nameSegment3rdPlaneBox.Location = new System.Drawing.Point(316, 31);
            this.nameSegment3rdPlaneBox.Name = "nameSegment3rdPlaneBox";
            this.nameSegment3rdPlaneBox.Size = new System.Drawing.Size(45, 21);
            this.nameSegment3rdPlaneBox.TabIndex = 24;
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
            // iconsSegment3rdPlaneBox
            // 
            this.iconsSegment3rdPlaneBox.FormattingEnabled = true;
            this.iconsSegment3rdPlaneBox.Items.AddRange(new object[] {
            "icon1",
            "icon2",
            "icon3"});
            this.iconsSegment3rdPlaneBox.Location = new System.Drawing.Point(103, 63);
            this.iconsSegment3rdPlaneBox.Name = "iconsSegment3rdPlaneBox";
            this.iconsSegment3rdPlaneBox.Size = new System.Drawing.Size(107, 95);
            this.iconsSegment3rdPlaneBox.TabIndex = 21;
            // 
            // colorSegment3rdPlaneBox
            // 
            this.colorSegment3rdPlaneBox.BackColor = System.Drawing.SystemColors.Control;
            this.colorSegment3rdPlaneBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorSegment3rdPlaneBox.Location = new System.Drawing.Point(103, 25);
            this.colorSegment3rdPlaneBox.Name = "colorSegment3rdPlaneBox";
            this.colorSegment3rdPlaneBox.Size = new System.Drawing.Size(36, 31);
            this.colorSegment3rdPlaneBox.TabIndex = 20;
            this.colorSegment3rdPlaneBox.TabStop = false;
            this.colorSegment3rdPlaneBox.Click += new System.EventHandler(this.colorSegment3rdPlaneBox_Click);
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
            // SettingSegment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.styleWidthList);
            this.Controls.Add(this.endPointsOnOff);
            this.Controls.Add(this.segmentColorBox);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.lineWidth);
            this.Controls.Add(this.segmentWidth);
            this.Name = "SettingSegment";
            this.Size = new System.Drawing.Size(569, 503);
            ((System.ComponentModel.ISupportInitialize)(this.segmentColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.segmentWidth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorSegment1stPlaneBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorSegment2ndPlaneBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorSegment3rdPlaneBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox endPointsOnOff;
        public System.Windows.Forms.PictureBox segmentColorBox;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Label lineWidth;
        public System.Windows.Forms.NumericUpDown segmentWidth;
        private System.Windows.Forms.ListBox styleWidthList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.ComboBox nameSegment1stPlaneBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ListBox iconsSegment1stPlaneList;
        public System.Windows.Forms.PictureBox colorSegment1stPlaneBox;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox nameSegment2ndPlaneBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ListBox iconsSegment2ndPlaneBox;
        public System.Windows.Forms.PictureBox colorSegment2ndPlaneBox;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox nameSegment3rdPlaneBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ListBox iconsSegment3rdPlaneBox;
        public System.Windows.Forms.PictureBox colorSegment3rdPlaneBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ColorDialog colorDialog3;
    }
}
