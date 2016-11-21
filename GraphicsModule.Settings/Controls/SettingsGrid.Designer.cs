namespace GraphicsModule.Settings.Controls
{
    partial class SettingsGrid
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
            this.ListBox1_TypePointsGrid = new System.Windows.Forms.ListBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.NumericUpDown2_PointsWidth = new System.Windows.Forms.NumericUpDown();
            this.Label12 = new System.Windows.Forms.Label();
            this.CheckBox1_FlagDrawGrid = new System.Windows.Forms.CheckBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gridStep1Box = new System.Windows.Forms.ComboBox();
            this.gridStep2Box = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorEdge = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown2_PointsWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdge)).BeginInit();
            this.SuspendLayout();
            // 
            // ListBox1_TypePointsGrid
            // 
            this.ListBox1_TypePointsGrid.FormattingEnabled = true;
            this.ListBox1_TypePointsGrid.Items.AddRange(new object[] {
            "PathToImage",
            "Erf"});
            this.ListBox1_TypePointsGrid.Location = new System.Drawing.Point(220, 104);
            this.ListBox1_TypePointsGrid.Name = "ListBox1_TypePointsGrid";
            this.ListBox1_TypePointsGrid.Size = new System.Drawing.Size(81, 30);
            this.ListBox1_TypePointsGrid.TabIndex = 38;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(3, 104);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(122, 13);
            this.Label11.TabIndex = 37;
            this.Label11.Text = "Тип (знак) точек сетки";
            // 
            // NumericUpDown2_PointsWidth
            // 
            this.NumericUpDown2_PointsWidth.Location = new System.Drawing.Point(220, 55);
            this.NumericUpDown2_PointsWidth.Name = "NumericUpDown2_PointsWidth";
            this.NumericUpDown2_PointsWidth.Size = new System.Drawing.Size(53, 20);
            this.NumericUpDown2_PointsWidth.TabIndex = 36;
            this.NumericUpDown2_PointsWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(3, 55);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(133, 13);
            this.Label12.TabIndex = 35;
            this.Label12.Text = "Размер точек сетки, пкс";
            // 
            // CheckBox1_FlagDrawGrid
            // 
            this.CheckBox1_FlagDrawGrid.AutoSize = true;
            this.CheckBox1_FlagDrawGrid.Location = new System.Drawing.Point(220, 11);
            this.CheckBox1_FlagDrawGrid.Name = "CheckBox1_FlagDrawGrid";
            this.CheckBox1_FlagDrawGrid.Size = new System.Drawing.Size(75, 17);
            this.CheckBox1_FlagDrawGrid.TabIndex = 31;
            this.CheckBox1_FlagDrawGrid.Text = "Включить";
            this.CheckBox1_FlagDrawGrid.UseVisualStyleBackColor = true;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(3, 11);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(108, 13);
            this.Label13.TabIndex = 34;
            this.Label13.Text = "Отображение сетки";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Шаг сетки по горизонтали (ось 1)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Шаг сетки по вертикали (ось 2)";
            // 
            // gridStep1Box
            // 
            this.gridStep1Box.FormattingEnabled = true;
            this.gridStep1Box.Items.AddRange(new object[] {
            "1,000",
            "1,250",
            "2,500",
            "5,000",
            "10,000",
            "12,500",
            "25,000",
            "50,000",
            "100,000"});
            this.gridStep1Box.Location = new System.Drawing.Point(220, 160);
            this.gridStep1Box.Name = "gridStep1Box";
            this.gridStep1Box.Size = new System.Drawing.Size(121, 21);
            this.gridStep1Box.TabIndex = 41;
            // 
            // gridStep2Box
            // 
            this.gridStep2Box.FormattingEnabled = true;
            this.gridStep2Box.Items.AddRange(new object[] {
            "1,000",
            "1,250",
            "2,500",
            "5,000",
            "10,000",
            "12,500",
            "25,000",
            "50,000",
            "100,000"});
            this.gridStep2Box.Location = new System.Drawing.Point(220, 199);
            this.gridStep2Box.Name = "gridStep2Box";
            this.gridStep2Box.Size = new System.Drawing.Size(121, 21);
            this.gridStep2Box.TabIndex = 42;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(3, 254);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(95, 13);
            this.Label8.TabIndex = 43;
            this.Label8.Text = "Цвет точек сетки";
            // 
            // colorEdge
            // 
            this.colorEdge.BackColor = System.Drawing.Color.White;
            this.colorEdge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorEdge.Location = new System.Drawing.Point(220, 242);
            this.colorEdge.Name = "colorEdge";
            this.colorEdge.Size = new System.Drawing.Size(39, 35);
            this.colorEdge.TabIndex = 45;
            this.colorEdge.TabStop = false;
            this.colorEdge.Click += new System.EventHandler(this.colorEdge_Click);
            this.colorEdge.Paint += new System.Windows.Forms.PaintEventHandler(this.colorEdge_Paint);
            // 
            // SettingsGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorEdge);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.gridStep2Box);
            this.Controls.Add(this.gridStep1Box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListBox1_TypePointsGrid);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.NumericUpDown2_PointsWidth);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.CheckBox1_FlagDrawGrid);
            this.Controls.Add(this.Label13);
            this.Name = "SettingsGrid";
            this.Size = new System.Drawing.Size(451, 288);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown2_PointsWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox ListBox1_TypePointsGrid;
        internal System.Windows.Forms.Label Label11;
        public System.Windows.Forms.NumericUpDown NumericUpDown2_PointsWidth;
        internal System.Windows.Forms.Label Label12;
        public System.Windows.Forms.CheckBox CheckBox1_FlagDrawGrid;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox gridStep1Box;
        public System.Windows.Forms.ComboBox gridStep2Box;
        internal System.Windows.Forms.Label Label8;
        public System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.PictureBox colorEdge;
    }
}
