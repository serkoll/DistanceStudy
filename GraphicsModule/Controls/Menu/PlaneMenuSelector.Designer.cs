namespace GraphicsModule.Controls.Menu
{
    partial class PlaneMenuSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaneMenuSelector));
            this.mainStrip = new System.Windows.Forms.ToolStrip();
            this.buttonPlane2D = new System.Windows.Forms.ToolStripButton();
            this.buttonPlaneOfPlane1X0Y = new System.Windows.Forms.ToolStripButton();
            this.buttonPlaneOfPlane2X0Z = new System.Windows.Forms.ToolStripButton();
            this.buttonPlaneOfPlane3Y0Z = new System.Windows.Forms.ToolStripButton();
            this.buttonPlane3D = new System.Windows.Forms.ToolStripButton();
            this.buttonGeneratePlane3D = new System.Windows.Forms.ToolStripButton();
            this.mainStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainStrip
            // 
            this.mainStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonPlane2D,
            this.buttonPlaneOfPlane1X0Y,
            this.buttonPlaneOfPlane2X0Z,
            this.buttonPlaneOfPlane3Y0Z,
            this.buttonPlane3D,
            this.buttonGeneratePlane3D});
            this.mainStrip.Location = new System.Drawing.Point(0, 0);
            this.mainStrip.Name = "mainStrip";
            this.mainStrip.Size = new System.Drawing.Size(157, 38);
            this.mainStrip.TabIndex = 1;
            this.mainStrip.Text = "toolStrip2";
            this.mainStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainStrip_ItemClicked);
            // 
            // buttonPlane2D
            // 
            this.buttonPlane2D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPlane2D.Image = global::GraphicsModule.Properties.Resources.line;
            this.buttonPlane2D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPlane2D.Name = "buttonPlane2D";
            this.buttonPlane2D.Size = new System.Drawing.Size(23, 35);
            this.buttonPlane2D.Text = "Линия";
            this.buttonPlane2D.Click += new System.EventHandler(this.buttonPlane2D_Click);
            // 
            // buttonPlaneOfPlane1X0Y
            // 
            this.buttonPlaneOfPlane1X0Y.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPlaneOfPlane1X0Y.Image = global::GraphicsModule.Properties.Resources.lineX0Y;
            this.buttonPlaneOfPlane1X0Y.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPlaneOfPlane1X0Y.Name = "buttonPlaneOfPlane1X0Y";
            this.buttonPlaneOfPlane1X0Y.Size = new System.Drawing.Size(23, 35);
            this.buttonPlaneOfPlane1X0Y.Text = "Проекция линии на плоскость X0Y";
            this.buttonPlaneOfPlane1X0Y.Click += new System.EventHandler(this.buttonPlaneOfPlane1X0Y_Click);
            // 
            // buttonPlaneOfPlane2X0Z
            // 
            this.buttonPlaneOfPlane2X0Z.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPlaneOfPlane2X0Z.Image = global::GraphicsModule.Properties.Resources.lineX0Z;
            this.buttonPlaneOfPlane2X0Z.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPlaneOfPlane2X0Z.Name = "buttonPlaneOfPlane2X0Z";
            this.buttonPlaneOfPlane2X0Z.Size = new System.Drawing.Size(23, 35);
            this.buttonPlaneOfPlane2X0Z.Text = "Проекция линии на плоскость X0Z";
            this.buttonPlaneOfPlane2X0Z.Click += new System.EventHandler(this.buttonPlaneOfPlane2X0Z_Click);
            // 
            // buttonPlaneOfPlane3Y0Z
            // 
            this.buttonPlaneOfPlane3Y0Z.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPlaneOfPlane3Y0Z.Image = global::GraphicsModule.Properties.Resources.lineY0Z;
            this.buttonPlaneOfPlane3Y0Z.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPlaneOfPlane3Y0Z.Name = "buttonPlaneOfPlane3Y0Z";
            this.buttonPlaneOfPlane3Y0Z.Size = new System.Drawing.Size(23, 35);
            this.buttonPlaneOfPlane3Y0Z.Text = "Проекция линии на плоскость Y0Z";
            this.buttonPlaneOfPlane3Y0Z.Click += new System.EventHandler(this.buttonPlaneOfPlane3Y0Z_Click);
            // 
            // buttonPlane3D
            // 
            this.buttonPlane3D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPlane3D.Image = global::GraphicsModule.Properties.Resources.line3D;
            this.buttonPlane3D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPlane3D.Name = "buttonPlane3D";
            this.buttonPlane3D.Size = new System.Drawing.Size(23, 35);
            this.buttonPlane3D.Text = "toolStripButton5";
            this.buttonPlane3D.Click += new System.EventHandler(this.buttonPlane3D_Click);
            // 
            // buttonGeneratePlane3D
            // 
            this.buttonGeneratePlane3D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonGeneratePlane3D.Image = ((System.Drawing.Image)(resources.GetObject("buttonGeneratePlane3D.Image")));
            this.buttonGeneratePlane3D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonGeneratePlane3D.Name = "buttonGeneratePlane3D";
            this.buttonGeneratePlane3D.Size = new System.Drawing.Size(23, 20);
            this.buttonGeneratePlane3D.Text = "toolStripButton6";
            this.buttonGeneratePlane3D.Click += new System.EventHandler(this.buttonGeneratePlane3D_Click);
            // 
            // PlaneMenuSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainStrip);
            this.Name = "PlaneMenuSelector";
            this.Size = new System.Drawing.Size(157, 38);
            this.mainStrip.ResumeLayout(false);
            this.mainStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainStrip;
        private System.Windows.Forms.ToolStripButton buttonPlane2D;
        private System.Windows.Forms.ToolStripButton buttonPlaneOfPlane1X0Y;
        private System.Windows.Forms.ToolStripButton buttonPlaneOfPlane2X0Z;
        private System.Windows.Forms.ToolStripButton buttonPlaneOfPlane3Y0Z;
        private System.Windows.Forms.ToolStripButton buttonPlane3D;
        private System.Windows.Forms.ToolStripButton buttonGeneratePlane3D;
    }
}
