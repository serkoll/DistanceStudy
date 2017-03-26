namespace GraphicsModule.Configuration.Controls.General
{
    partial class GridSettingsControl
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
            this.NumericUpDownPointsSize = new System.Windows.Forms.NumericUpDown();
            this.Label12 = new System.Windows.Forms.Label();
            this.CheckBoxFlagDrawGrid = new System.Windows.Forms.CheckBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gridStepOfWidth = new System.Windows.Forms.ComboBox();
            this.gridStepOfHeight = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorEdge = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPointsSize)).BeginInit();
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
            this.ListBox1_TypePointsGrid.Size = new System.Drawing.Size(75, 30);
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
            // NumericUpDownPointsSize
            // 
            this.NumericUpDownPointsSize.Location = new System.Drawing.Point(220, 55);
            this.NumericUpDownPointsSize.Name = "NumericUpDownPointsSize";
            this.NumericUpDownPointsSize.Size = new System.Drawing.Size(53, 20);
            this.NumericUpDownPointsSize.TabIndex = 36;
            this.NumericUpDownPointsSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownPointsSize.ValueChanged += new System.EventHandler(this.NumericUpDown2_PointsWidth_ValueChanged);
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
            // CheckBoxFlagDrawGrid
            // 
            this.CheckBoxFlagDrawGrid.AutoSize = true;
            this.CheckBoxFlagDrawGrid.Checked = true;
            this.CheckBoxFlagDrawGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxFlagDrawGrid.Location = new System.Drawing.Point(220, 11);
            this.CheckBoxFlagDrawGrid.Name = "CheckBoxFlagDrawGrid";
            this.CheckBoxFlagDrawGrid.Size = new System.Drawing.Size(75, 17);
            this.CheckBoxFlagDrawGrid.TabIndex = 31;
            this.CheckBoxFlagDrawGrid.Text = "Включить";
            this.CheckBoxFlagDrawGrid.UseVisualStyleBackColor = true;
            this.CheckBoxFlagDrawGrid.CheckedChanged += new System.EventHandler(this.CheckBox1_FlagDrawGrid_CheckedChanged);
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
            this.label1.Location = new System.Drawing.Point(3, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Шаг сетки по горизонтали (ось 1)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Шаг сетки по вертикали (ось 2)";
            // 
            // gridStepOfWidth
            // 
            this.gridStepOfWidth.FormattingEnabled = true;
            this.gridStepOfWidth.Items.AddRange(new object[] {
            "1",
            "1",
            "2",
            "5",
            "10",
            "12",
            "25",
            "50",
            "100"});
            this.gridStepOfWidth.Location = new System.Drawing.Point(220, 160);
            this.gridStepOfWidth.Name = "gridStepOfWidth";
            this.gridStepOfWidth.Size = new System.Drawing.Size(75, 21);
            this.gridStepOfWidth.TabIndex = 41;
            this.gridStepOfWidth.SelectedIndexChanged += new System.EventHandler(this.gridStep1Box_SelectedIndexChanged);
            // 
            // gridStepOfHeight
            // 
            this.gridStepOfHeight.FormattingEnabled = true;
            this.gridStepOfHeight.Items.AddRange(new object[] {
            "1",
            "1",
            "2",
            "5",
            "10",
            "12",
            "25",
            "50",
            "100"});
            this.gridStepOfHeight.Location = new System.Drawing.Point(220, 200);
            this.gridStepOfHeight.Name = "gridStepOfHeight";
            this.gridStepOfHeight.Size = new System.Drawing.Size(75, 21);
            this.gridStepOfHeight.TabIndex = 42;
            this.gridStepOfHeight.SelectedIndexChanged += new System.EventHandler(this.gridStepOfHeight_SelectedIndexChanged);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(328, 12);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(95, 13);
            this.Label8.TabIndex = 43;
            this.Label8.Text = "Цвет точек сетки";
            // 
            // colorEdge
            // 
            this.colorEdge.BackColor = System.Drawing.Color.White;
            this.colorEdge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorEdge.Location = new System.Drawing.Point(354, 33);
            this.colorEdge.Name = "colorEdge";
            this.colorEdge.Size = new System.Drawing.Size(39, 35);
            this.colorEdge.TabIndex = 45;
            this.colorEdge.TabStop = false;
            this.colorEdge.Click += new System.EventHandler(this.colorEdge_Click);
            // 
            // GridSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorEdge);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.gridStepOfHeight);
            this.Controls.Add(this.gridStepOfWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListBox1_TypePointsGrid);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.NumericUpDownPointsSize);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.CheckBoxFlagDrawGrid);
            this.Controls.Add(this.Label13);
            this.Name = "GridSettingsControl";
            this.Size = new System.Drawing.Size(555, 258);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPointsSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox ListBox1_TypePointsGrid;
        internal System.Windows.Forms.Label Label11;
        public System.Windows.Forms.NumericUpDown NumericUpDownPointsSize;
        internal System.Windows.Forms.Label Label12;
        public System.Windows.Forms.CheckBox CheckBoxFlagDrawGrid;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox gridStepOfWidth;
        public System.Windows.Forms.ComboBox gridStepOfHeight;
        internal System.Windows.Forms.Label Label8;
        public System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.PictureBox colorEdge;
    }
}
