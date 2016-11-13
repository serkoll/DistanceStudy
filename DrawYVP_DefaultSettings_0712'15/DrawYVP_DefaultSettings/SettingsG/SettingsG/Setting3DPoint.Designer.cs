namespace SettingsG
{
    partial class Setting3DPoint
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
            this.color1stPlaneDialog = new System.Windows.Forms.ColorDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.name1stPlaneBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.icons1stPlaneList = new System.Windows.Forms.ListBox();
            this.color1stPlaneBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.name2ndPlaneBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.icons2ndPlaneList = new System.Windows.Forms.ListBox();
            this.color2ndPlaneBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.name3rdPlaneBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.icons3rdPlaneList = new System.Windows.Forms.ListBox();
            this.color3rdPlaneBox = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.color2ndPlaneDialog = new System.Windows.Forms.ColorDialog();
            this.color3rdPlaneDialog = new System.Windows.Forms.ColorDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color1stPlaneBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color2ndPlaneBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color3rdPlaneBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(70, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(358, 204);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.name1stPlaneBox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.icons1stPlaneList);
            this.tabPage1.Controls.Add(this.color1stPlaneBox);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(350, 178);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1-я проекция";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // name1stPlaneBox
            // 
            this.name1stPlaneBox.FormattingEnabled = true;
            this.name1stPlaneBox.Items.AddRange(new object[] {
            "P1",
            "P\'"});
            this.name1stPlaneBox.Location = new System.Drawing.Point(291, 29);
            this.name1stPlaneBox.Name = "name1stPlaneBox";
            this.name1stPlaneBox.Size = new System.Drawing.Size(45, 21);
            this.name1stPlaneBox.TabIndex = 18;
            this.name1stPlaneBox.SelectedIndexChanged += new System.EventHandler(this.name1stPlaneBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Обозначение";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Значок";
            // 
            // icons1stPlaneList
            // 
            this.icons1stPlaneList.FormattingEnabled = true;
            this.icons1stPlaneList.Items.AddRange(new object[] {
            "icon1",
            "icon2",
            "icon3"});
            this.icons1stPlaneList.Location = new System.Drawing.Point(78, 61);
            this.icons1stPlaneList.Name = "icons1stPlaneList";
            this.icons1stPlaneList.Size = new System.Drawing.Size(107, 95);
            this.icons1stPlaneList.TabIndex = 15;
            // 
            // color1stPlaneBox
            // 
            this.color1stPlaneBox.BackColor = System.Drawing.SystemColors.Control;
            this.color1stPlaneBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.color1stPlaneBox.Location = new System.Drawing.Point(78, 23);
            this.color1stPlaneBox.Name = "color1stPlaneBox";
            this.color1stPlaneBox.Size = new System.Drawing.Size(36, 31);
            this.color1stPlaneBox.TabIndex = 14;
            this.color1stPlaneBox.TabStop = false;
            this.color1stPlaneBox.Click += new System.EventHandler(this.color1stPlaneBox_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Цвет";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.name2ndPlaneBox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.icons2ndPlaneList);
            this.tabPage2.Controls.Add(this.color2ndPlaneBox);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(350, 178);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2-я проекция";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // name2ndPlaneBox
            // 
            this.name2ndPlaneBox.FormattingEnabled = true;
            this.name2ndPlaneBox.Items.AddRange(new object[] {
            "P2",
            "P\'\'"});
            this.name2ndPlaneBox.Location = new System.Drawing.Point(291, 29);
            this.name2ndPlaneBox.Name = "name2ndPlaneBox";
            this.name2ndPlaneBox.Size = new System.Drawing.Size(45, 21);
            this.name2ndPlaneBox.TabIndex = 18;
            this.name2ndPlaneBox.SelectedIndexChanged += new System.EventHandler(this.name2ndPlaneBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Обозначение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Значок";
            // 
            // icons2ndPlaneList
            // 
            this.icons2ndPlaneList.FormattingEnabled = true;
            this.icons2ndPlaneList.Items.AddRange(new object[] {
            "icon4",
            "icon5",
            "icon6"});
            this.icons2ndPlaneList.Location = new System.Drawing.Point(78, 61);
            this.icons2ndPlaneList.Name = "icons2ndPlaneList";
            this.icons2ndPlaneList.Size = new System.Drawing.Size(107, 95);
            this.icons2ndPlaneList.TabIndex = 15;
            // 
            // color2ndPlaneBox
            // 
            this.color2ndPlaneBox.BackColor = System.Drawing.SystemColors.Control;
            this.color2ndPlaneBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.color2ndPlaneBox.Location = new System.Drawing.Point(78, 23);
            this.color2ndPlaneBox.Name = "color2ndPlaneBox";
            this.color2ndPlaneBox.Size = new System.Drawing.Size(36, 31);
            this.color2ndPlaneBox.TabIndex = 14;
            this.color2ndPlaneBox.TabStop = false;
            this.color2ndPlaneBox.Click += new System.EventHandler(this.color2ndPlaneBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Цвет";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.name3rdPlaneBox);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.icons3rdPlaneList);
            this.tabPage3.Controls.Add(this.color3rdPlaneBox);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(350, 178);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "3-я проекция";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // name3rdPlaneBox
            // 
            this.name3rdPlaneBox.FormattingEnabled = true;
            this.name3rdPlaneBox.Items.AddRange(new object[] {
            "P3",
            "P\'\'\'"});
            this.name3rdPlaneBox.Location = new System.Drawing.Point(291, 29);
            this.name3rdPlaneBox.Name = "name3rdPlaneBox";
            this.name3rdPlaneBox.Size = new System.Drawing.Size(45, 21);
            this.name3rdPlaneBox.TabIndex = 18;
            this.name3rdPlaneBox.SelectedIndexChanged += new System.EventHandler(this.name3rdPlaneBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(205, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Обозначение";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Значок";
            // 
            // icons3rdPlaneList
            // 
            this.icons3rdPlaneList.FormattingEnabled = true;
            this.icons3rdPlaneList.Items.AddRange(new object[] {
            "icon8",
            "icon9",
            "icon10"});
            this.icons3rdPlaneList.Location = new System.Drawing.Point(78, 61);
            this.icons3rdPlaneList.Name = "icons3rdPlaneList";
            this.icons3rdPlaneList.Size = new System.Drawing.Size(107, 95);
            this.icons3rdPlaneList.TabIndex = 15;
            // 
            // color3rdPlaneBox
            // 
            this.color3rdPlaneBox.BackColor = System.Drawing.SystemColors.Control;
            this.color3rdPlaneBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.color3rdPlaneBox.Location = new System.Drawing.Point(78, 23);
            this.color3rdPlaneBox.Name = "color3rdPlaneBox";
            this.color3rdPlaneBox.Size = new System.Drawing.Size(36, 31);
            this.color3rdPlaneBox.TabIndex = 14;
            this.color3rdPlaneBox.TabStop = false;
            this.color3rdPlaneBox.Click += new System.EventHandler(this.color3rdPlaneBox_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Цвет";
            // 
            // Setting3DPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "Setting3DPoint";
            this.Size = new System.Drawing.Size(498, 282);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color1stPlaneBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color2ndPlaneBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color3rdPlaneBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog color1stPlaneDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.ComboBox name1stPlaneBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ListBox icons1stPlaneList;
        public System.Windows.Forms.PictureBox color1stPlaneBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.ComboBox name2ndPlaneBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ListBox icons2ndPlaneList;
        public System.Windows.Forms.PictureBox color2ndPlaneBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.ComboBox name3rdPlaneBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ListBox icons3rdPlaneList;
        public System.Windows.Forms.PictureBox color3rdPlaneBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColorDialog color2ndPlaneDialog;
        private System.Windows.Forms.ColorDialog color3rdPlaneDialog;
    }
}
