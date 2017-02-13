namespace GraphicsModule.Controls.Menu
{
    partial class SegmentMenuSelector
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SegmentMenuSelector));
            this.mainStrip = new System.Windows.Forms.ToolStrip();
            this.buttonSegment2D = new System.Windows.Forms.ToolStripButton();
            this.buttonSegmentOfPlane1X0Y = new System.Windows.Forms.ToolStripButton();
            this.buttonSegmentOfPlane2X0Z = new System.Windows.Forms.ToolStripButton();
            this.buttonSegmentOfPlane3Y0Z = new System.Windows.Forms.ToolStripButton();
            this.buttonSegment3D = new System.Windows.Forms.ToolStripButton();
            this.buttonGenerateSegment3D = new System.Windows.Forms.ToolStripButton();
            this.mainStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainStrip
            // 
            this.mainStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonSegment2D,
            this.buttonSegmentOfPlane1X0Y,
            this.buttonSegmentOfPlane2X0Z,
            this.buttonSegmentOfPlane3Y0Z,
            this.buttonSegment3D,
            this.buttonGenerateSegment3D});
            this.mainStrip.Location = new System.Drawing.Point(0, 0);
            this.mainStrip.Name = "mainStrip";
            this.mainStrip.Size = new System.Drawing.Size(157, 38);
            this.mainStrip.TabIndex = 0;
            this.mainStrip.Text = "mainStrip";
            this.mainStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainStrip_ItemClicked);
            // 
            // buttonSegment2D
            // 
            this.buttonSegment2D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSegment2D.Image = ((System.Drawing.Image)(resources.GetObject("buttonSegment2D.Image")));
            this.buttonSegment2D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSegment2D.Name = "buttonSegment2D";
            this.buttonSegment2D.Size = new System.Drawing.Size(23, 35);
            this.buttonSegment2D.Text = "Отрезок";
            this.buttonSegment2D.Click += new System.EventHandler(this.buttonSegment2D_Click);
            // 
            // buttonSegmentOfPlane1X0Y
            // 
            this.buttonSegmentOfPlane1X0Y.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSegmentOfPlane1X0Y.Image = global::GraphicsModule.Properties.Resources.SegmentX0Y;
            this.buttonSegmentOfPlane1X0Y.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSegmentOfPlane1X0Y.Name = "buttonSegmentOfPlane1X0Y";
            this.buttonSegmentOfPlane1X0Y.Size = new System.Drawing.Size(23, 35);
            this.buttonSegmentOfPlane1X0Y.Text = "Проекция отрезка на плоскость X0Y";
            this.buttonSegmentOfPlane1X0Y.Click += new System.EventHandler(this.buttonSegmentOfPlane1X0Y_Click);
            // 
            // buttonSegmentOfPlane2X0Z
            // 
            this.buttonSegmentOfPlane2X0Z.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSegmentOfPlane2X0Z.Image = global::GraphicsModule.Properties.Resources.SegmentX0Z;
            this.buttonSegmentOfPlane2X0Z.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSegmentOfPlane2X0Z.Name = "buttonSegmentOfPlane2X0Z";
            this.buttonSegmentOfPlane2X0Z.Size = new System.Drawing.Size(23, 35);
            this.buttonSegmentOfPlane2X0Z.Text = "Проекция отрезка на плоскость X0Z";
            this.buttonSegmentOfPlane2X0Z.Click += new System.EventHandler(this.buttonSegmentOfPlane2X0Z_Click);
            // 
            // buttonSegmentOfPlane3Y0Z
            // 
            this.buttonSegmentOfPlane3Y0Z.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSegmentOfPlane3Y0Z.Image = global::GraphicsModule.Properties.Resources.SegmentY0Z;
            this.buttonSegmentOfPlane3Y0Z.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSegmentOfPlane3Y0Z.Name = "buttonSegmentOfPlane3Y0Z";
            this.buttonSegmentOfPlane3Y0Z.Size = new System.Drawing.Size(23, 35);
            this.buttonSegmentOfPlane3Y0Z.Text = "Проекция отрезка на плоскость Y0Z";
            this.buttonSegmentOfPlane3Y0Z.Click += new System.EventHandler(this.buttonSegmentOfPlane3Y0Z_Click);
            // 
            // buttonSegment3D
            // 
            this.buttonSegment3D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSegment3D.Image = global::GraphicsModule.Properties.Resources.Segment3D;
            this.buttonSegment3D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSegment3D.Name = "buttonSegment3D";
            this.buttonSegment3D.Size = new System.Drawing.Size(23, 35);
            this.buttonSegment3D.Text = "3D отрезок";
            this.buttonSegment3D.Click += new System.EventHandler(this.buttonSegment3D_Click);
            // 
            // buttonGenerateSegment3D
            // 
            this.buttonGenerateSegment3D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonGenerateSegment3D.Image = ((System.Drawing.Image)(resources.GetObject("buttonGenerateSegment3D.Image")));
            this.buttonGenerateSegment3D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonGenerateSegment3D.Name = "buttonGenerateSegment3D";
            this.buttonGenerateSegment3D.Size = new System.Drawing.Size(23, 20);
            this.buttonGenerateSegment3D.Text = "Генерация 3D отрезка";
            this.buttonGenerateSegment3D.Click += new System.EventHandler(this.GenerateSegment3D_Click);
            // 
            // SegmentMenuSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainStrip);
            this.Name = "SegmentMenuSelector";
            this.Size = new System.Drawing.Size(157, 38);
            this.mainStrip.ResumeLayout(false);
            this.mainStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainStrip;
        private System.Windows.Forms.ToolStripButton buttonSegment2D;
        private System.Windows.Forms.ToolStripButton buttonSegmentOfPlane1X0Y;
        private System.Windows.Forms.ToolStripButton buttonSegmentOfPlane2X0Z;
        private System.Windows.Forms.ToolStripButton buttonSegmentOfPlane3Y0Z;
        private System.Windows.Forms.ToolStripButton buttonSegment3D;
        private System.Windows.Forms.ToolStripButton buttonGenerateSegment3D;
    }
}
