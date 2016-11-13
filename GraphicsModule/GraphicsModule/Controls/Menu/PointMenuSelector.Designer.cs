namespace GraphicsModule.Controls.Menu
{
    partial class PointMenuSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PointMenuSelector));
            this.mainStrip = new System.Windows.Forms.ToolStrip();
            this.buttonPoint2D = new System.Windows.Forms.ToolStripButton();
            this.buttonPointOfPlane1 = new System.Windows.Forms.ToolStripButton();
            this.buttonPointOfPlane2 = new System.Windows.Forms.ToolStripButton();
            this.buttonPointOfPlane3 = new System.Windows.Forms.ToolStripButton();
            this.buttonPoint3D = new System.Windows.Forms.ToolStripButton();
            this.buttonPoint3DGenerate = new System.Windows.Forms.ToolStripButton();
            this.mainStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainStrip
            // 
            this.mainStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonPoint2D,
            this.buttonPointOfPlane1,
            this.buttonPointOfPlane2,
            this.buttonPointOfPlane3,
            this.buttonPoint3D,
            this.buttonPoint3DGenerate});
            this.mainStrip.Location = new System.Drawing.Point(0, 0);
            this.mainStrip.Name = "mainStrip";
            this.mainStrip.Size = new System.Drawing.Size(157, 38);
            this.mainStrip.TabIndex = 0;
            this.mainStrip.Text = "0";
            this.mainStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainStrip_ItemClicked);
            // 
            // buttonPoint2D
            // 
            this.buttonPoint2D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPoint2D.Image = ((System.Drawing.Image)(resources.GetObject("buttonPoint2D.Image")));
            this.buttonPoint2D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPoint2D.Name = "buttonPoint2D";
            this.buttonPoint2D.Size = new System.Drawing.Size(23, 35);
            this.buttonPoint2D.Text = "Точка";
            this.buttonPoint2D.Click += new System.EventHandler(this.buttonPoint2D_Click);
            // 
            // buttonPointOfPlane1
            // 
            this.buttonPointOfPlane1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPointOfPlane1.Image = ((System.Drawing.Image)(resources.GetObject("buttonPointOfPlane1.Image")));
            this.buttonPointOfPlane1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPointOfPlane1.Name = "buttonPointOfPlane1";
            this.buttonPointOfPlane1.Size = new System.Drawing.Size(23, 35);
            this.buttonPointOfPlane1.Text = "Проекция точки на плоскость X0Y";
            this.buttonPointOfPlane1.Click += new System.EventHandler(this.buttonPointOfPlane1_Click);
            // 
            // buttonPointOfPlane2
            // 
            this.buttonPointOfPlane2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPointOfPlane2.Image = ((System.Drawing.Image)(resources.GetObject("buttonPointOfPlane2.Image")));
            this.buttonPointOfPlane2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPointOfPlane2.Name = "buttonPointOfPlane2";
            this.buttonPointOfPlane2.Size = new System.Drawing.Size(23, 35);
            this.buttonPointOfPlane2.Text = "Проекция точки на плоскость X0Z";
            this.buttonPointOfPlane2.Click += new System.EventHandler(this.buttonPointOfPlane2_Click);
            // 
            // buttonPointOfPlane3
            // 
            this.buttonPointOfPlane3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPointOfPlane3.Image = ((System.Drawing.Image)(resources.GetObject("buttonPointOfPlane3.Image")));
            this.buttonPointOfPlane3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPointOfPlane3.Name = "buttonPointOfPlane3";
            this.buttonPointOfPlane3.Size = new System.Drawing.Size(23, 35);
            this.buttonPointOfPlane3.Text = "Проекция точки на плоскость Y0Z";
            this.buttonPointOfPlane3.Click += new System.EventHandler(this.buttonPointOfPlane3_Click);
            // 
            // buttonPoint3D
            // 
            this.buttonPoint3D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPoint3D.Image = global::GraphicsModule.Properties.Resources.dot3D;
            this.buttonPoint3D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPoint3D.Name = "buttonPoint3D";
            this.buttonPoint3D.Size = new System.Drawing.Size(23, 35);
            this.buttonPoint3D.Text = "3Д точка";
            this.buttonPoint3D.Click += new System.EventHandler(this.buttonPoint3D_Click);
            // 
            // buttonPoint3DGenerate
            // 
            this.buttonPoint3DGenerate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPoint3DGenerate.Image = ((System.Drawing.Image)(resources.GetObject("buttonPoint3DGenerate.Image")));
            this.buttonPoint3DGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPoint3DGenerate.Name = "buttonPoint3DGenerate";
            this.buttonPoint3DGenerate.Size = new System.Drawing.Size(23, 20);
            this.buttonPoint3DGenerate.Text = "Генерация 3Д точки";
            this.buttonPoint3DGenerate.Click += new System.EventHandler(this.buttonPoint3DGenerate_Click);
            // 
            // PointMenuSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainStrip);
            this.Name = "PointMenuSelector";
            this.Size = new System.Drawing.Size(157, 38);
            this.mainStrip.ResumeLayout(false);
            this.mainStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainStrip;
        private System.Windows.Forms.ToolStripButton buttonPoint2D;
        private System.Windows.Forms.ToolStripButton buttonPointOfPlane1;
        private System.Windows.Forms.ToolStripButton buttonPointOfPlane2;
        private System.Windows.Forms.ToolStripButton buttonPointOfPlane3;
        private System.Windows.Forms.ToolStripButton buttonPoint3D;
        private System.Windows.Forms.ToolStripButton buttonPoint3DGenerate;
    }
}
